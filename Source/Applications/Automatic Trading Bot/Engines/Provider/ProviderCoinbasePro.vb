Option Compare Text
Option Explicit On

Imports Coinbase.Pro
Imports Coinbase.Pro.Models
Imports Coinbase.Pro.WebSockets
Imports WebSocket4Net





Namespace AreaCommon.Provider

    Public Class ProviderCoinbasePro

        Private Property _ClientPro As CoinbaseProClient
        Private Property _Sub As Subscription = New Subscription
        Private Property _Socket As CoinbaseProWebSocket

        Public Property lastSubscriptionTicker As Double = 0



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

                        AreaCommon.Engines.Pairs.manageFilledProductInformation(tb.ProductId)

                        lastSubscriptionTicker = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If
                End If
                If (TypeName(msg).ToUpper.CompareTo("ErrorEvent".ToUpper) = 0) Then
                    ee = msg

                    If ee.Reason.ToString.Contains("is not a valid product") Then
                        Dim keyProduct As String = ee.Reason.ToString.Replace("is not a valid product", "").TrimEnd()

                        AreaState.products.getCurrency(keyProduct).userData.preference = Models.Products.ProductUserDataModel.PreferenceEnumeration.automaticDisabled

                        AreaState.pairs.Remove(keyProduct)

                        addLogOperation("Error message subscription receiver ticker = " & ee.Message & " " & keyProduct & " is removed")
                    Else
                        addLogOperation("Error message subscription receiver ticker = " & ee.Message & " " & ee.Reason)
                    End If
                End If
            End If

        End Sub




        Public Function cancelOrderProduct(ByVal id As String) As Boolean
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            _ClientPro.Orders.CancelOrderByIdAsync(id)

            addLogOperation($"ProviderCoinbasePro.cancelOrderProduct - {id}")

            Return True
        End Function

        Public Function getOpenOrder(ByVal id As String) As Boolean
            If (id.Length = 0) Then
                Return True
            End If

            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Try
                Dim order = _ClientPro.Orders.GetOrderAsync(id).Result

                addLogOperation($"ProviderCoinbasePro.getOpenOrder - {id}")

                Return ((order.Status.CompareTo("open") = 0) And (Not order.Settled) And (order.FilledSize.CompareTo(0) = 0))
            Catch ex As Exception
                addLogOperation($"ProviderCoinbasePro.getOpenOrder - {id} error - " & ex.Message)

                Return False
            Finally
                addLogOperation($"ProviderCoinbasePro.getOpenOrder - {id} completed")
            End Try
        End Function

        Public Function getProductOrder(ByVal pairId As String, ByVal orderId As String) As Coinbase.Pro.Models.Order
            Dim exchangeOrders As Coinbase.Pro.Models.PagedResponse(Of Coinbase.Pro.Models.Order)

            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            exchangeOrders = _ClientPro.Orders.GetAllOrdersAsync("all", pairId.ToUpper, 1).Result

            If Not IsNothing(exchangeOrders) Then
                If (exchangeOrders.Data.Count > 0) Then
                    For Each singleOrder In exchangeOrders.Data
                        If (singleOrder.Id.CompareTo(orderId) = 0) Then
                            Return singleOrder
                        End If
                    Next
                End If
            End If

            Return New Order
        End Function

        Public Async Function GetAllAccounts() As Task(Of List(Of Account))
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Dim accounts = Await _ClientPro.Accounts.GetAllAccountsAsync()

            Return accounts
        End Function

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

        Public Async Sub placeOrder(ByVal product As AreaCommon.Models.Products.ProductModel, ByVal data As Models.Products.ProductOrderModel, Optional sideBuy As Boolean = True, Optional ByVal cancelProductInformation As Boolean = False)
            Dim order As Order
            Dim side As OrderSide
            Dim maxPrice As Double = 0

            Try
                If IsNothing(_ClientPro) Then
                    _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
                End If

                If sideBuy Then
                    side = OrderSide.Buy
                Else
                    side = OrderSide.Sell
                End If

                order = Await _ClientPro.Orders.PlaceLimitOrderAsync(side, product.pairID, CDec(Math.Abs(data.amount)), CDec(data.maxPrice), Coinbase.Pro.Models.TimeInForce.GoodTillCanceled, product.header.postOnly)

                addLogOperation($"placeOrder {product.header.key}")

                If Not IsNothing(order) Then
                    data.id = order.Id
                    data.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed

                    Engines.Watch.orders.add(product, "Orders")

                    addLogOperation($"placeOrder {order.Id} - Watch.start")

                    Engines.Watch.start()

                    product.activity.dateLastCheck = 0
                End If
            Catch ex As Exception
                addLogOperation($"Problem during placeOrder {side} {product.pairID} {CDec(data.tcoQuote)} {CDec(Math.Abs(data.amount))} {CDec(data.maxPrice)} - " & ex.Message)
            End Try
        End Sub

        Public Sub sellImmediatly(ByVal pair As String, ByVal amount As Decimal)
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Dim sellData As New Models.Products.ProductOrderModel
            Dim product As Models.Products.ProductModel = AreaState.products.getCurrency(pair.Split("-")(0).ToUpper)

            sellData.amount = roundBase(amount, product.header.baseIncrement, True)
            sellData.maxPrice = roundBase(product.value.current - (product.value.current * 10 / 100), product.header.quoteIncrement, True)
            sellData.tcoQuote = roundBase(sellData.maxPrice * sellData.amount, product.header.quoteIncrement, True)

            If (sellData.tcoQuote > product.header.minMarketFunds) Then
                product.activity.sell = sellData

                sellData.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented

                placeOrder(product, sellData, False)

                If (sellData.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Then
                    Threading.Thread.Sleep(2000)

                    If (sellData.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Then
                        product.activity.sell = New Models.Products.ProductOrderModel
                    End If
                End If
            End If
        End Sub

        Public Async Function getSingleProduct(ByVal pair As String) As Task(Of Product)
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Return Await _ClientPro.MarketData.GetSingleProductAsync(pair)
        End Function

        Public Async Function getTicker(ByVal pair As String) As Task(Of Ticker)
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Return Await _ClientPro.MarketData.GetTickerAsync(pair)
        End Function

        Public Async Sub startSubscriptionProcessor()
            Try
                _Socket = New CoinbaseProWebSocket()

                Dim result = Await _Socket.ConnectAsync()

                If (Not result.Success) Then
                    Engines.Pairs.inWorkJob = False
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

                Do While Engines.Pairs.inWorkJob And (startTimer + 360000 > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    Threading.Thread.Sleep(1000)
                Loop

                If Engines.Pairs.inWorkJob Then
                    Engines.Pairs.[stop]()
                    Engines.Pairs.start()
                End If
            Catch ex As Exception
                Engines.Pairs.inWorkJob = False
            End Try
        End Sub

        Public Function removeSubscription() As Boolean
            RemoveHandler _Socket.RawSocket.MessageReceived, AddressOf RawSocket_MessageReceived

            _Socket.Dispose()

            _Socket = Nothing

            Task.Delay(TimeSpan.FromMinutes(1))

            _Sub = New Subscription

            Return True
        End Function

    End Class

End Namespace
