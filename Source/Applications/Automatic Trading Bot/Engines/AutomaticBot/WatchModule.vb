Option Compare Text
Option Explicit On

Imports Coinbase.Pro




Namespace AreaCommon.Engines.Watch

    Module WatchModule

        Private Property _ClientPro As CoinbaseProClient

        Public Property orders As New InternalList
        Public Property trades As New InternalList

        Public Property inWorkJob As Boolean = False


        Public Function cancelOrderProduct(ByVal id As String) As Boolean
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            _ClientPro.Orders.CancelOrderByIdAsync(id)

            addLogOperation($"cancelOrderProduct - {id}")

            Return True
        End Function


        Private Function updateCounterInformation(ByRef product As AreaCommon.Models.Products.ProductModel, ByRef orderData As Models.Products.ProductOrderModel, Optional ByRef sideBuy As Boolean = False) As Boolean
            AreaState.journal.currentBlockCounters.feePayed += orderData.feeCost
            AreaState.journal.currentBlockCounters.volumes += CDec(orderData.tcoQuote)

            AreaState.summary.totalFeesValue += CDec(product.activity.sell.feeCost)
            AreaState.summary.totalVolumeValue += CDec(product.activity.sell.tcoQuote)

            If Not sideBuy Then
                AreaState.journal.currentBlockCounters.increase += product.activity.earn
                AreaState.summary.increaseValue += product.activity.earn
            End If

            With AreaState.journal.currentBlockCounters.addNewTransaction()
                .amount = orderData.amount
                .buy = sideBuy
                .daily = (Bots.currentPhase = Bots.AutomaticBotModule.WorkerPhaseEnum.buyTime)
                .dateCompletate = orderData.dateAcquire
                .orderNumber = orderData.id
                .pairID = product.header.key
                .value = orderData.tcoQuote
            End With

            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return True
        End Function

        Public Function checkOrderTrade(ByRef product As AreaCommon.Models.Products.ProductModel) As Boolean
            Dim managePosition As Boolean = False
            Dim exchangeOrders As Coinbase.Pro.Models.PagedResponse(Of Coinbase.Pro.Models.Order)
            Dim buy As Models.Products.ProductOrderModel
            Dim thisTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim proceed As Boolean = True

            If (product.activity.dateLastCheck = 0) Then
                product.activity.dateLastCheck = product.activity.dateLastCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            End If

            If proceed Then
                If product.activity.fastCheck Then
                    proceed = (product.activity.dateLastCheck + 15000 < thisTime)
                Else
                    proceed = (product.activity.dateLastCheck + 60000 < thisTime)
                End If
            End If
            If proceed Then
                product.activity.dateLastCheck = thisTime

                addLogOperation($"checkOrderTrade - {product.header.key}")

                If IsNothing(_ClientPro) Then
                    _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
                End If

                exchangeOrders = _ClientPro.Orders.GetAllOrdersAsync("all", product.pairID.ToUpper, 1).Result

                buy = product.activity.openBuy

                If (buy.id.Length > 0) Then
                    If Not IsNothing(exchangeOrders) Then
                        If (exchangeOrders.Data.Count = 0) Then
                            addLogOperation($"checkOrderTrade - proceed to removeProductOrder {product.header.key}")

                            orders.remove(product)

                            Return True
                        Else
                            managePosition = True
                        End If
                    End If

                    If managePosition Then

                        For Each singleOrder In exchangeOrders.Data
                            If (singleOrder.Id.CompareTo(buy.id) = 0) Then
                                addLogOperation($"checkOrderTrade - orderFund {product.header.key} - orderId {singleOrder.Id} - status {singleOrder.Status}")

                                If proceed Then
                                    proceed = (singleOrder.Status.CompareTo("done") = 0)
                                End If
                                If proceed Then
                                    proceed = Not IsNothing(singleOrder.DoneReason)
                                End If
                                If proceed Then
                                    proceed = (singleOrder.DoneReason.ToUpper.CompareTo("filled".ToUpper) = 0)

                                    addLogOperation($"checkOrderTrade - orderFund {product.header.key} - orderId {singleOrder.Id} - status {singleOrder.Status} - doneReason {singleOrder.DoneReason}")
                                End If

                                If proceed Then
                                    addLogOperation($"checkOrderTrade - removeProductOrder {product.header.key} - orderId - {singleOrder.Id}")

                                    orders.remove(product)

                                    buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                                    buy.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(singleOrder.DoneAt.Value.UtcDateTime)
                                    buy.amount = singleOrder.FilledSize
                                    buy.feeCost = singleOrder.FillFees
                                    buy.tcoQuote = (singleOrder.Price * buy.amount)

                                    product.switchTarget()

                                    trades.add(product)
                                    updateCounterInformation(product, buy, True)

                                    product.activity.fastCheck = False

                                    Return False
                                Else
                                    If Not product.activity.fastCheck Then
                                        addLogOperation($"checkOrderTrade - after fastCheck {product.header.key} - orderId - {singleOrder.Id}")

                                        orders.remove(product)

                                        _ClientPro.Orders.CancelOrderByIdAsync(buy.id)

                                        product.activity.openBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.undefined

                                        product.activity.removeOpenBuy()
                                    Else
                                        addLogOperation($"checkOrderTrade - fastCheck {product.header.key} - orderId - {singleOrder.Id}")

                                        product.activity.fastCheck = False
                                    End If

                                    Return False
                                End If

                                addLogOperation($"checkOrderTrade - reset dateLastCheck {product.header.key} - orderId - {singleOrder.Id}")

                                product.activity.dateLastCheck = 0

                                Return True
                            End If
                        Next

                        orders.remove(product)

                        Return True
                    End If

                    managePosition = False
                End If

                With product.activity.sell
                    If (.id.Length = 0) Then
                        addLogOperation($"checkOrderTrade - sellId=0 {product.header.key}")

                        If (buy.id.Length = 0) Then
                            orders.remove(product)
                        End If

                        Return True
                    Else
                        If Not IsNothing(exchangeOrders) Then
                            If (exchangeOrders.Data.Count = 0) Then
                                addLogOperation($"checkOrderTrade - orders.data.count=0")

                                product.activity.sell = New Models.Products.ProductOrderModel

                                orders.remove(product)

                                Return True
                            Else
                                managePosition = True
                            End If

                            If managePosition Then
                                For Each singleOrder In exchangeOrders.Data
                                    If (singleOrder.Id.CompareTo(.id) = 0) Then
                                        addLogOperation($"checkOrderTrade - Sell {product.header.key} for singleOrder {singleOrder.Id}")

                                        proceed = True

                                        If proceed Then
                                            proceed = (singleOrder.Status.CompareTo("done") = 0)
                                        End If
                                        If proceed Then
                                            proceed = Not IsNothing(singleOrder.DoneReason)
                                        End If
                                        If proceed Then
                                            proceed = (singleOrder.DoneReason.ToUpper.CompareTo("filled".ToUpper) = 0)
                                        End If

                                        If proceed Then
                                            addLogOperation($"checkOrderTrade - removeProductOrder {product.header.key}")

                                            orders.remove(product)

                                            .state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled

                                            .dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(singleOrder.DoneAt.Value.UtcDateTime)
                                            .amount = singleOrder.FilledSize
                                            .feeCost = singleOrder.FillFees
                                            .tcoQuote = (singleOrder.Price * .amount)

                                            updateCounterInformation(product, product.activity.sell)

                                            product.resetData()
                                        ElseIf (singleOrder.Status.CompareTo("done") <> 0) And .cancelSellIfSlow Then
                                            addLogOperation($"checkOrderTrade - CancelOrderByIdAsync {product.header.key}")

                                            _ClientPro.Orders.CancelOrderByIdAsync(.id)
                                            orders.remove(product)
                                        End If

                                        Return False
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

                    addLogOperation($"checkTrade - {product.header.key}")

                    orderValue = product.currentTarget

                    trades.remove(product)

                    With product.activity.sell
                        If (orderValue <> 0) Then
                            addLogOperation($"checkTrade - {product.header.key} with orderValue={orderValue}")

                            .dateAcquire = 0

                            .amount = roundBase(product.activity.totalAmount, product.header.baseIncrement, True)
                            .maxPrice = roundBase(product.activity.target / product.activity.totalAmount, product.header.quoteIncrement, True)
                            .tcoQuote = roundBase(product.activity.target, product.header.quoteIncrement, True)

                            Engines.Orders.placeOrder(product, product.activity.sell, False)

                            addLogOperation($"checkTrade - {product.header.key} order placed")

                            .state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented
                        End If
                    End With

                    Return False
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

                Do While inWorkJob

                    Try
                        Do While inWorkJob
                            If (orders.count > 0) Then
                                If (currentIndexOrder + 1 > orders.count) Then
                                    currentIndexOrder = 0
                                End If

                                If checkOrderTrade(orders.getData(currentIndexOrder)) Then
                                    currentIndexOrder += 1
                                End If
                            Else
                                currentIndexOrder = 0
                            End If

                            Threading.Thread.Sleep(25)

                            If (trades.count > 0) Then
                                If (currentIndexTrade + 1 > trades.count) Then
                                    currentIndexTrade = 0
                                End If

                                If checkTrade(trades.getData(currentIndexTrade)) Then
                                    currentIndexTrade += 1
                                End If
                            Else
                                currentIndexTrade = 0
                            End If

                            Threading.Thread.Sleep(25)

                            inWorkJob = (orders.count > 0) Or (trades.count > 0)
                        Loop
                    Catch ex As Exception
                    End Try
                Loop

            Catch ex As Exception
                inWorkJob = False

                MessageBox.Show("An error occurrent during StartServiceWatch - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start a pair job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not inWorkJob Then
                inWorkJob = True

                Dim objWS As Threading.Thread

                objWS = New Threading.Thread(AddressOf startServiceWatch)

                objWS.Start()
            End If

            Return True
        End Function

        Public Function [stop]() As Boolean
            inWorkJob = False

            Return True
        End Function

        Public Function clear() As Boolean
            orders = New InternalList
            trades = New InternalList

            Return True
        End Function

    End Module

End Namespace
