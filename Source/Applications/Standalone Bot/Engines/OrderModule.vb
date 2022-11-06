Option Compare Text
Option Explicit On

Imports Coinbase.Pro




Namespace AreaCommon.Engines.Orders

    Module OrderModule

        Private Const c_Second As Double = 1000

        Private Property _ClientPro As CoinbaseProClient

        Public Property stateOn As Boolean = False

        ''' <summary>
        ''' This method provide to calculate fee cost of a transaction
        ''' </summary>
        ''' <param name="totalValue"></param>
        ''' <returns></returns>
        Private Function calculateFeeCost(ByVal totalValue As Double) As Double
            Dim feePercentage As Double = 0

            Select Case New Random().Next(0, 1)
                Case 0 : feePercentage = 0.6
                Case Else : feePercentage = 0.4
            End Select

            Return totalValue * feePercentage / 100
        End Function

        ''' <summary>
        ''' This method provide to test if exist the condition to buy
        ''' </summary>
        ''' <param name="tradeBuy"></param>
        ''' <param name="pairKey"></param>
        ''' <returns></returns>
        Private Function testConditionBuy(ByRef tradeBuy As Models.Bot.BotOrderModel, ByVal pairKey As String) As Boolean
            If (tradeBuy.notBeforeThat > 0) Then
                If (tradeBuy.notBeforeThat >= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                    Return False
                End If
            End If

            If (AreaState.accounts(pairKey.Split("-")(1).ToLower()).amount >= tradeBuy.orderValue) Then
                tradeBuy.notBeforeThat = 0
                tradeBuy.notBeforeThatBegin = 0

                Return True
            Else
                tradeBuy.notBeforeThat = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000

                If (tradeBuy.notBeforeThatBegin = 0) Then
                    tradeBuy.notBeforeThatBegin = tradeBuy.notBeforeThat
                End If

                Return False
            End If
        End Function

        ''' <summary>
        ''' This method provide to make order to buy 
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="internalOrderId"></param>
        ''' <param name="tradeBuy"></param>
        ''' <returns></returns>
        Private Function makeOrderBuy(ByVal botId As String, ByVal internalOrderId As String, ByRef tradeBuy As Models.Bot.BotOrderModel) As Boolean
            Dim weightValue As Double = AreaState.bots(botId).common.currentValue * tradeBuy.amount

            tradeBuy.feeCost = calculateFeeCost(weightValue)
            tradeBuy.tco = weightValue + tradeBuy.feeCost
            tradeBuy.pairTradeValue = AreaState.bots(botId).common.currentValue
            tradeBuy.timeCompleted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            tradeBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled

            AreaState.addIntoAccount(AreaState.bots(botId).common.key, (-1) * tradeBuy.tco, True)
            AreaState.addIntoAccount(AreaState.bots(botId).common.key, tradeBuy.amount, False)

            AreaState.orders.Remove(internalOrderId)

            AreaState.summary.totalFeesValue += CDec(tradeBuy.feeCost)
            AreaState.summary.totalVolumeValue += CDec(weightValue)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to make and order to sell
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="internalOrderId"></param>
        ''' <param name="tradeSell"></param>
        ''' <returns></returns>
        Private Function makeOrderSell(ByVal botId As String, ByVal internalOrderId As String, ByRef tradeSell As Models.Bot.BotOrderModel) As Boolean
            Dim weightValue As Double = AreaState.bots(botId).common.currentValue * tradeSell.amount

            tradeSell.feeCost = calculateFeeCost(weightValue)
            tradeSell.tco = weightValue + tradeSell.feeCost
            tradeSell.pairTradeValue = AreaState.bots(botId).common.currentValue
            tradeSell.timeCompleted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            tradeSell.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled

            AreaState.addIntoAccount(AreaState.bots(botId).common.key, (-1) * tradeSell.amount, False)
            AreaState.addIntoAccount(AreaState.bots(botId).common.key, (tradeSell.tco - tradeSell.feeCost), True)

            AreaState.orders.Remove(internalOrderId)

            AreaState.summary.totalFeesValue += CDec(tradeSell.feeCost)
            AreaState.summary.totalVolumeValue += CDec(weightValue)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to verify the order
        ''' </summary>
        ''' <param name="order"></param>
        ''' <returns></returns>
        Private Function verify(ByRef order As Models.Order.SimplyOrderModel) As Boolean
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If (order.productId.Length > 0) Then
                        Return AreaCommon.Engines.Bots.AutomaticBotModule.manageOrderProduct(order.productId, order.internalOrderId)
                    ElseIf AreaState.bots.ContainsKey(order.botId) Then
                        For Each trade In AreaState.bots(order.botId).data.tradeOpen
                            If (trade.buy.id = order.internalOrderId) Then
                                If testConditionBuy(trade.buy, AreaState.bots(order.botId).common.key) Then
                                    Return makeOrderBuy(order.botId, order.internalOrderId, trade.buy)
                                End If

                                If (trade.buy.notBeforeThatBegin > 0) Then
                                    AreaState.bots(order.botId).data.tradeOpen.Remove(trade)

                                    Return True
                                End If
                            End If

                            If (trade.sell.id = order.internalOrderId) Then
                                If AreaState.bots(order.botId).common.currentValue >= (trade.sell.pairTradeValue) Then
                                    Return makeOrderSell(order.botId, order.internalOrderId, trade.sell)
                                End If
                            End If
                        Next
                    End If

                End If

                Return True
            Catch ex As Exception
                MessageBox.Show("Problem during verify the order " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceBot()
            Try
                Dim currentIndex As Integer = 0
                Dim repeat As Boolean = True

                Do While repeat
                    Try
                        repeat = False

                        Do While stateOn
                            If (AreaState.orders.Count > 0) Then
                                If (currentIndex + 1 > AreaState.orders.Count) Then
                                    currentIndex = 0
                                End If

                                If verify(AreaState.orders.ElementAt(currentIndex).Value) Then
                                    currentIndex += 1
                                End If
                            Else
                                stateOn = False

                                Return
                            End If

                            Threading.Thread.Sleep(100)
                        Loop
                    Catch ex As Exception
                        repeat = True

                        currentIndex = 0
                    End Try
                Loop

            Catch ex As Exception
                stateOn = False

                MessageBox.Show("An error occurrent during StartServiceBot - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to check into all active orders the pair
        ''' </summary>
        ''' <param name="pair"></param>
        Public Async Sub closeAllOrders(ByVal pair As String)
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Try
                Await _ClientPro.Orders.CancelAllOrdersAsync(pair)
            Catch ex As Exception
                MessageBox.Show("Problem during closeAllOrders - " & ex.Message)
            End Try

        End Sub

        Public Async Function openOrders(ByVal pair As String) As Task(Of Boolean)
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Try
                Return (_ClientPro.Orders.GetAllOrdersAsync("open", pair).Result.Data.Count > 0)
            Catch ex As Exception
                MessageBox.Show("Problem during openOrders - " & ex.Message)

                Return False
            End Try
        End Function

        Private Async Sub placeLimitOrder(ByVal obj As Object)
            Try
                Dim order = Await _ClientPro.Orders.PlaceLimitOrderAsync(Coinbase.Pro.Models.OrderSide.Sell, obj.pair, obj.sizeround, obj.limitPriceRound, Coinbase.Pro.Models.TimeInForce.ImmediateOrCancel)

                MessageBox.Show("Conversion in progress", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Problem during sellAll - " & ex.Message)
            End Try
        End Sub

        Public Sub sellAll(ByVal pair As String, ByVal amount As Decimal, ByVal marketPlaceUSDT As Decimal)
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Dim ordertype As String = "Sell"
            Dim limitPrice As Decimal = marketPlaceUSDT - (marketPlaceUSDT * 2) / 100
            Dim sizeround As Decimal = Decimal.Round(amount, 8)
            Dim limitPriceRound As Decimal = Decimal.Round(limitPrice, 2)

            Try
                Dim asynchThread As System.Threading.Thread
                Dim placeObject As New Models.Order.PlaceOrderModel

                placeObject.pair = pair
                placeObject.limitPriceRound = limitPriceRound
                placeObject.sizeround = sizeround

                asynchThread = New System.Threading.Thread(AddressOf placeLimitOrder)

                asynchThread.Start(placeObject)
            Catch ex As Exception
            End Try


            'Dim parameterData As Object
            'Dim task As New Task(AddressOf placeLimitOrder, parameterData)

            'task.Start()

        End Sub

        ''' <summary>
        ''' This method provide to start a pair job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not stateOn Then
                stateOn = True

                Dim objWS As Threading.Thread

                objWS = New Threading.Thread(AddressOf startServiceBot)

                objWS.Start()
            End If

            Return True
        End Function

        Public Function [stop]() As Boolean
            stateOn = False

            Return True
        End Function

    End Module

End Namespace