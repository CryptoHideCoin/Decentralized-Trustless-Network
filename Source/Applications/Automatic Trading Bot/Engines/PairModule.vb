Option Compare Text
Option Explicit On

Imports Coinbase.Pro
Imports Coinbase.Pro.WebSockets
Imports Coinbase.Pro.Models
Imports WebSocket4Net





Namespace AreaCommon.Engines.Pairs

    Module PairModule

        Private Enum SourceTickerEnum
            undefined
            readFromFile
            ticker
            subscription
        End Enum

        Private Const c_Second As Double = 1000
        Private Const c_Minute As Double = c_Second * 60


        Private Property _InWorkJob As Boolean = False
        Private Property _ClientPro As New CoinbaseProClient

        Private Property _Sub As Subscription = New Subscription
        Private Property _Socket As CoinbaseProWebSocket

        Private Property _LastUpdateTick As Double = 0
        Private Property _SourceMode As SourceTickerEnum = SourceTickerEnum.undefined

        Public Property lastSubscriptionTicker As Double = 0


        Private Async Sub manageFilledProductInformation(ByVal pair As String)
            With AreaState.products.getCurrency(pair.Split("-")(0)).header
                If (.name.Length > 0) And (.baseIncrement.Length = 0) Then

                    Dim currency = Await _ClientPro.MarketData.GetSingleProductAsync(pair)

                    .baseIncrement = currency.BaseIncrement.ToString()
                    .limitOnly = currency.LimitOnly
                    .minMarketFunds = currency.MinMarketFunds.ToString()
                    .postOnly = currency.PostOnly
                    .quoteIncrement = currency.QuoteIncrement.ToString()
                    .status = currency.Status
                    .statusMessage = currency.StatusMessage
                    .tradingDisabled = currency.TradingDisabled

                End If
            End With

        End Sub

        ''' <summary>
        ''' This method provide to update tick pair
        ''' </summary>
        ''' <param name="pair"></param>
        Private Async Sub updateTick(ByVal pair As Models.Pair.PairInformation)
            Try
                pair.lastUpdateTick = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                _LastUpdateTick = pair.lastUpdateTick

                Dim market = Await _ClientPro.MarketData.GetTickerAsync(pair.key)
                Dim tick As New Models.Pair.TickInformation

                pair.currentValue = market.Price

                AreaState.updateChange(pair.key, pair.currentValue)
                manageFilledProductInformation(pair.key)

                If (pair.currentRelativeAverageValue = 0) Then
                    pair.currentRelativeAverageValue = market.Price
                Else
                    pair.currentRelativeAverageValue = (pair.currentRelativeAverageValue + market.Price) / 2
                End If

                tick.time = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                tick.value = market.Price

                If (market.Price > pair.currentRelativeAverageValue) Then
                    tick.position = Models.Pair.TickInformation.tickPositionEnumeration.increase
                ElseIf market.Price = pair.currentRelativeAverageValue Then
                    tick.position = Models.Pair.TickInformation.tickPositionEnumeration.same
                Else
                    tick.position = Models.Pair.TickInformation.tickPositionEnumeration.decrease
                End If

                If AreaState.defaultUserDataAccount.saveTickToFile Then
                    Engine.IO.updateTickValue(pair.key, tick)
                End If

                pair.addNewItem(tick)
            Catch ex As Exception
                If ex.Message Like "*Bad request*" Then
                    AreaState.products.getCurrency(pair.key.Split("-")(0)).userData.preference = Models.Products.ProductUserDataModel.PreferenceEnumeration.automaticDisabled

                    AreaState.pairs.Remove(pair.key)

                    MessageBox.Show($"Problem during updateTick ({pair.id}) - " & ex.Message)
                ElseIf Not ex.Message Like "*Call timed out*" Then
                    MessageBox.Show("Problem during updateTick - " & ex.Message)
                End If

            End Try
        End Sub


        ''' <summary>
        ''' This method provide to process a pair
        ''' </summary>
        ''' <param name="currentIndex"></param>
        Private Function process(ByVal currentIndex As Integer) As Boolean
            Try
                Dim pair As Models.Pair.PairInformation = AreaState.pairs.ElementAt(currentIndex).Value
                Dim currentTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                If ((pair.lastUpdateTick + c_Minute) < currentTime) Then
                    If (currentTime > _LastUpdateTick + 100) Then
                        Task.Run(Sub() updateTick(pair)).Start()
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
            End Try

            Return True
        End Function

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceProcessor()
            Try
                Dim currentIndex As Integer = 0

                Do While _InWorkJob
                    If (AreaState.pairs.Count > 0) Then
                        If (currentIndex + 1 > AreaState.pairs.Count) Then
                            currentIndex = 0
                        End If

                        If Not process(currentIndex) Then
                            currentIndex += 1
                        End If
                    End If

                    Threading.Thread.Sleep(100)
                Loop
            Catch ex As Exception
                _InWorkJob = False
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start a reader processor
        ''' </summary>
        Private Sub startReaderProcessor()
            Try
                Dim currentIndex As Integer = 0
                Dim pair As Models.Pair.PairInformation
                Dim tick As New Models.Pair.TickInformation

                Do While _InWorkJob
                    If (AreaState.pairs.Count > 0) Then
                        If (currentIndex + 1 > AreaState.pairs.Count) Then
                            currentIndex = 0
                        End If

                        pair = AreaState.pairs.ElementAt(currentIndex).Value

                        tick = Engine.IO.readTickValue(pair.key)

                        If pair.key.CompareTo("NCT-USDT") = 0 Then
                            tick.time = tick.time
                        End If

                        If (tick.time > 0) Then
                            If (pair.lastUpdateTick < tick.time) Then
                                pair.lastUpdateTick = tick.time
                                pair.currentValue = tick.value

                                AreaState.updateChange(pair.key, pair.currentValue)
                                manageFilledProductInformation(pair.key)

                                If (pair.currentRelativeAverageValue = 0) Then
                                    pair.currentRelativeAverageValue = tick.value
                                Else
                                    pair.currentRelativeAverageValue = (pair.currentRelativeAverageValue + tick.value) / 2
                                End If

                                pair.addNewItem(tick)
                            End If
                        End If

                        currentIndex += 1
                    End If

                    Threading.Thread.Sleep(10)
                Loop
            Catch ex As Exception
                _InWorkJob = False
            End Try

        End Sub

        Sub RawSocket_MessageReceived(sender As Object, e As MessageReceivedEventArgs)
            Dim msg As Object
            Dim tb As TickerEvent
            Dim ee As ErrorEvent

            If WebSocketHelper.TryParse(e.Message, msg) Then
                If (TypeName(msg).ToUpper.CompareTo("TickerEvent".ToUpper) = 0) Then
                    tb = msg

                    If AreaState.pairs.ContainsKey(tb.ProductId) Then
                        Dim tick As New Models.Pair.TickInformation

                        With AreaState.pairs(tb.ProductId)
                            .currentValue = tb.Price

                            tick.time = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                            If (.currentRelativeAverageValue = 0) Then
                                .currentRelativeAverageValue = tb.Price
                            Else
                                .currentRelativeAverageValue = (.currentRelativeAverageValue + tb.Price) / 2
                            End If

                            tick.value = tb.Price

                            If (tb.Price > .currentRelativeAverageValue) Then
                                tick.position = Models.Pair.TickInformation.tickPositionEnumeration.increase
                            ElseIf tb.Price = .currentRelativeAverageValue Then
                                tick.position = Models.Pair.TickInformation.tickPositionEnumeration.same
                            Else
                                tick.position = Models.Pair.TickInformation.tickPositionEnumeration.decrease
                            End If

                            .addNewItem(tick)

                            If AreaState.defaultUserDataAccount.saveTickToFile Then
                                Engine.IO.updateTickValue(.key, tick)
                            End If

                            .lastUpdateTick = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                        End With

                        AreaState.updateChange(tb.ProductId, tb.Price)
                        manageFilledProductInformation(tb.ProductId)

                        lastSubscriptionTicker = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If
                End If
                If (TypeName(msg).ToUpper.CompareTo("ErrorEvent".ToUpper) = 0) Then
                    ee = msg

                    MessageBox.Show("Error subscription ticker = " & ee.Message)
                End If
            End If

        End Sub

        Private Async Sub startSubscriptionProcessor()
            Try
                _Socket = New CoinbaseProWebSocket()

                Dim result = Await _Socket.ConnectAsync()

                If (Not result.Success) Then
                    _InWorkJob = False
                End If

                AddHandler _Socket.RawSocket.MessageReceived, AddressOf RawSocket_MessageReceived

                _Socket.RawSocket.AutoSendPingInterval = 60000
                _Socket.RawSocket.EnableAutoSendPing = True

                For Each pair In AreaState.pairs
                    _Sub.ProductIds.Add(pair.Key)
                Next

                _Sub.Channels.Add("ticker")

                Await _Socket.SubscribeAsync(_Sub)

                Dim startTimer As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                Do While _InWorkJob And (startTimer + 360000 > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    Threading.Thread.Sleep(1000)
                Loop

                If _InWorkJob Then
                    [stop]()
                    start()
                End If
            Catch ex As Exception
                _InWorkJob = False
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to check if the pair exist
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Async Function testPair(ByVal value As String) As Task(Of Boolean)
            Try
                Threading.Thread.Sleep(100)

                Dim market = Await _ClientPro.MarketData.GetTickerAsync(value)

                Threading.Thread.Sleep(100)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to start a pair job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not _InWorkJob Then
                Dim objWS As Threading.Thread

                _InWorkJob = True

                If AreaState.defaultUserDataAccount.readTickFromFile Then
                    _SourceMode = SourceTickerEnum.readFromFile

                    objWS = New Threading.Thread(AddressOf startReaderProcessor)
                ElseIf AreaState.defaultUserDataAccount.useSubscription Then
                    _SourceMode = SourceTickerEnum.subscription

                    objWS = New Threading.Thread(AddressOf startSubscriptionProcessor)
                Else
                    _SourceMode = SourceTickerEnum.ticker

                    objWS = New Threading.Thread(AddressOf startServiceProcessor)
                End If

                objWS.Start()
            End If

            Return True
        End Function

        Public Function [stop]() As Boolean
            _InWorkJob = False

            If (_SourceMode = SourceTickerEnum.subscription) Then
                RemoveHandler _Socket.RawSocket.MessageReceived, AddressOf RawSocket_MessageReceived

                _Socket.Dispose()

                _Socket = Nothing

                Task.Delay(TimeSpan.FromMinutes(1))

                _Sub = New Subscription
            End If

            Return True
        End Function

        Public Function tryReset() As Boolean
            If ((_SourceMode = SourceTickerEnum.readFromFile) And Not AreaState.defaultUserDataAccount.readTickFromFile) Or
               ((_SourceMode = SourceTickerEnum.subscription) And Not AreaState.defaultUserDataAccount.useSubscription) Or
               ((_SourceMode = SourceTickerEnum.ticker) And Not (AreaState.defaultUserDataAccount.useSubscription Or AreaState.defaultUserDataAccount.readTickFromFile)) Or
               (_SourceMode = SourceTickerEnum.undefined) Then

                [stop]()
                [start]()

            End If

            Return True
        End Function

    End Module

End Namespace