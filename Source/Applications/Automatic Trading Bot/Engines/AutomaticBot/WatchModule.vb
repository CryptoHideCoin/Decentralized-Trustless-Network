Option Compare Text
Option Explicit On

Imports Coinbase.Pro




Namespace AreaCommon.Engines.Watch

    Module WatchModule

        Private Const c_Second As Double = 1000

        Private Property _InWorkJob As Boolean = False
        Private Property _ClientPro As CoinbaseProClient

        Private Property _OrderInMonitor As New List(Of Models.Products.ProductModel)
        Private Property _IndexOrderInMonitor As New Dictionary(Of String, String)

        Private Property _TradeInMonitor As New List(Of Models.Products.ProductModel)
        Private Property _IndexTradeInMonitor As New Dictionary(Of String, String)



        ''' <summary>
        ''' This method provide to add a product into internal list
        ''' </summary>
        ''' <param name="product"></param>
        ''' <returns></returns>
        Public Function addProductOrder(ByRef product As Models.Products.ProductModel) As Boolean
            If _IndexOrderInMonitor.ContainsKey(product.header.key) Then
                Return True
            Else
                _OrderInMonitor.Add(product)
                _IndexOrderInMonitor.Add(product.header.key, product.header.key)

                If Not _InWorkJob Then
                    start()
                End If
            End If

            Return True
        End Function

        Public Function removeProductOrder(ByRef product As Models.Products.ProductModel) As Boolean
            Try
                If _IndexOrderInMonitor.ContainsKey(product.header.key) Then
                    _IndexOrderInMonitor.Remove(product.header.key)
                    _OrderInMonitor.Remove(product)
                End If
            Catch ex As Exception
            End Try

            Return True
        End Function


        Public Function addProductTrade(ByRef product As Models.Products.ProductModel) As Boolean
            If _IndexTradeInMonitor.ContainsKey(product.header.key) Then
                Return True
            Else
                _TradeInMonitor.Add(product)
                _IndexTradeInMonitor.Add(product.header.key, product.header.key)

                If Not _InWorkJob Then
                    start()
                End If
            End If

            Return True
        End Function

        Public Function removeProductTrade(ByRef product As Models.Products.ProductModel) As Boolean
            Try
                If _IndexTradeInMonitor.ContainsKey(product.header.key) Then
                    _IndexTradeInMonitor.Remove(product.header.key)
                    _TradeInMonitor.Remove(product)
                End If
            Catch ex As Exception
            End Try

            Return True
        End Function


        Private Function updateCounterInformation(ByRef product As AreaCommon.Models.Products.ProductModel, ByRef orderData As Models.Products.ProductOrderModel, Optional ByRef sideBuy As Boolean = False) As Boolean
            AreaState.journal.currentBlockCounters.feePayed += orderData.feeCost
            AreaState.journal.currentBlockCounters.volumes += CDec(orderData.tcoQuote)

            AreaState.journal.totalFee += orderData.feeCost
            AreaState.journal.totalVolume += CDec(orderData.tcoQuote)

            If sideBuy Then
                If (Bots.currentPhase = Bots.AutomaticBotModule.WorkerPhaseEnum.buyTime) Then
                    AreaState.journal.currentBlockCounters.dailyBuy += CDec(orderData.tcoQuote)
                Else
                    AreaState.journal.currentBlockCounters.extraBuy += CDec(orderData.tcoQuote)
                End If
            Else
                If (Bots.currentPhase = Bots.AutomaticBotModule.WorkerPhaseEnum.buyTime) Then
                    AreaState.journal.currentBlockCounters.dailySell += CDec(orderData.tcoQuote)
                Else
                    AreaState.journal.currentBlockCounters.extraSell += CDec(orderData.tcoQuote)
                End If
            End If

            With AreaState.journal.currentBlockCounters.addNewTransaction()
                .amount = orderData.amount
                .buy = sideBuy
                .daily = (AreaState.automaticBot.workAction <> Models.Bot.BotAutomatic.WorkStateEnumeration.undefined)
                .dateCompletate = orderData.dateAcquire
                .orderNumber = orderData.id
                .pairID = product.header.key
                .value = orderData.tcoQuote
            End With

            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return True
        End Function

        Private Function checkOrderTrade(ByRef product As AreaCommon.Models.Products.ProductModel) As Boolean
            Dim managePosition As Boolean = False
            Dim orders As Coinbase.Pro.Models.PagedResponse(Of Coinbase.Pro.Models.Order)
            Dim buy As Models.Products.ProductOrderModel

            If ((product.activity.dateLastCheck <> 0) And (product.activity.dateLastCheck + 60000 < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())) Then
                product.activity.dateLastCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                If IsNothing(_ClientPro) Then
                    _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
                End If

                orders = _ClientPro.Orders.GetAllOrdersAsync("all", product.pairID.ToUpper, 1).Result

                buy = product.activity.openBuy

                If (buy.id.Length > 0) Then
                    If Not IsNothing(orders) Then
                        If (orders.Data.Count = 0) Then
                            removeProductOrder(product)

                            Return True
                        Else
                            managePosition = True
                        End If
                    End If

                    If managePosition Then
                        For Each singleOrder In orders.Data
                            If (singleOrder.Id.CompareTo(buy.id) = 0) Then
                                removeProductOrder(product)

                                If (singleOrder.Status.CompareTo("done") = 0) And (singleOrder.DoneReason.ToUpper.CompareTo("filled".ToUpper) = 0) Then
                                    buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                                    buy.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(singleOrder.DoneAt.Value.UtcDateTime)
                                    buy.amount = singleOrder.FilledSize
                                    buy.feeCost = singleOrder.FillFees
                                    buy.tcoQuote = (singleOrder.Price * buy.amount)

                                    product.changeTargetInMax()

                                    addProductTrade(product)
                                    updateCounterInformation(product, buy, True)
                                Else
                                    _ClientPro.Orders.CancelOrderByIdAsync(buy.id)
                                    removeProductOrder(product)
                                End If

                                product.activity.dateLastCheck = 0

                                Return True
                            End If
                        Next
                    End If

                    managePosition = False
                End If

                With product.activity.sell
                    If (.id.Length = 0) Then
                        Return True
                    Else
                        If Not IsNothing(orders) Then
                            If (orders.Data.Count = 0) Then
                                product.activity.sell = New Models.Products.ProductOrderModel

                                removeProductOrder(product)

                                Return True
                            Else
                                managePosition = True
                            End If

                            If managePosition Then
                                For Each singleOrder In orders.Data
                                    If (singleOrder.Id.CompareTo(.id) = 0) Then
                                        removeProductOrder(product)

                                        If (singleOrder.Status.CompareTo("done") = 0) Then
                                            .state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled

                                            updateCounterInformation(product, product.activity.sell)
                                        ElseIf .cancelSellIfSlow Then
                                            _ClientPro.Orders.CancelOrderByIdAsync(.id)
                                            removeProductOrder(product)
                                        End If

                                        Return True
                                    End If
                                Next
                            End If
                        End If
                    End If
                End With
            End If

            Return True
        End Function

        Private Function checkTrade(ByRef product As AreaCommon.Models.Products.ProductModel) As Boolean
            If (product.activity.dateLastCheck = 0) Or (product.activity.dateLastCheck + 60000 < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                product.activity.dateLastCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                If product.currentTargetReached() And (product.activity.sell.id.Length = 0) Then
                    Dim orderValue As Double = 0

                    orderValue = product.currentTarget

                    With product.activity.sell
                        If (orderValue <> 0) Then
                            .dateAcquire = 0
                            .tcoQuote = orderValue
                            .amount = roundBase(orderValue / product.value.current, product.header.baseIncrement, True)
                            .maxPrice = roundBase(product.value.current + (product.value.current / 100), product.header.quoteIncrement, True)
                            .tcoQuote = roundBase(product.value.current * .amount, product.header.quoteIncrement, True)

                            Orders.placeOrder(product, product.activity.sell)

                            .state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented
                        End If

                    End With
                End If

            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceWatch()
            Try
                Dim currentIndexOrder As Integer = 0
                Dim currentIndexTrade As Integer = 0

                Do While _InWorkJob

                    Try
                        Do While _InWorkJob
                            If (_OrderInMonitor.Count > 0) Then
                                If (currentIndexOrder + 1 > _OrderInMonitor.Count) Then
                                    currentIndexOrder = 0
                                End If

                                If checkOrderTrade(_OrderInMonitor(currentIndexOrder)) Then
                                    currentIndexOrder += 1
                                End If
                            Else
                                currentIndexOrder = 0
                            End If

                            Threading.Thread.Sleep(25)

                            If (_TradeInMonitor.Count > 0) Then
                                If (currentIndexTrade + 1 > _TradeInMonitor.Count) Then
                                    currentIndexTrade = 0
                                End If

                                If checkTrade(_TradeInMonitor(currentIndexTrade)) Then
                                    currentIndexTrade += 1
                                End If
                            Else
                                currentIndexTrade = 0
                            End If

                            Threading.Thread.Sleep(25)

                            _InWorkJob = (_OrderInMonitor.Count > 0) Or (_TradeInMonitor.Count > 0)
                        Loop
                    Catch ex As Exception
                    End Try
                Loop

            Catch ex As Exception
                _InWorkJob = False

                MessageBox.Show("An error occurrent during StartServiceWatch - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start a pair job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not _InWorkJob Then
                _InWorkJob = True

                Dim objWS As Threading.Thread

                objWS = New Threading.Thread(AddressOf startServiceWatch)

                objWS.Start()
            End If

            Return True
        End Function

        Public Function [stop]() As Boolean
            _InWorkJob = False

            Return True
        End Function

    End Module

End Namespace
