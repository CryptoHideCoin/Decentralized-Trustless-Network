Option Compare Text
Option Explicit On

Imports Coinbase.Pro




Namespace AreaCommon.Engines.Orders

    Module OrderModule

        '        Private Const c_Second As Double = 1000

        Private Property _ClientPro As CoinbaseProClient

        '        Public Property stateOn As Boolean = False

        '        ''' <summary>
        '        ''' This method provide to test if exist the condition to buy
        '        ''' </summary>
        '        ''' <param name="tradeBuy"></param>
        '        ''' <param name="pairKey"></param>
        '        ''' <returns></returns>
        '        Private Function testConditionBuy(ByRef tradeBuy As Models.Bot.BotOrderModel, ByVal pairKey As String) As Boolean
        '            If (tradeBuy.notBeforeThat > 0) Then
        '                If (tradeBuy.notBeforeThat >= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
        '                    Return False
        '                End If
        '            End If

        '            If (AreaState.accounts(pairKey.Split("-")(1).ToLower()).amount >= tradeBuy.orderValue) Then
        '                tradeBuy.notBeforeThat = 0
        '                tradeBuy.notBeforeThatBegin = 0

        '                Return True
        '            Else
        '                tradeBuy.notBeforeThat = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000

        '                If (tradeBuy.notBeforeThatBegin = 0) Then
        '                    tradeBuy.notBeforeThatBegin = tradeBuy.notBeforeThat
        '                End If

        '                Return False
        '            End If
        '        End Function

        Public Sub deleteOrder(ByVal id As String)
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            _ClientPro.Orders.CancelOrderByIdAsync(id)
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

        '        ''' <summary>
        '        ''' This method provide to add a new order to the service
        '        ''' </summary>
        '        ''' <param name="productId"></param>
        '        ''' <param name="orderId"></param>
        '        ''' <param name="orderNumber"></param>
        '        ''' <returns></returns>
        '        Public Function startMonitorOrder(ByVal productId As String, ByVal orderId As String, ByVal orderNumber As String, Optional ByVal cancelProductInformation As Boolean = False) As Boolean
        '            If Not AreaState.orders.ContainsKey(orderId) Then
        '                Dim newSimply As New Models.Order.SimplyOrderModel

        '                newSimply.accountCredentials = AreaState.defaultUserDataAccount.exchangeAccess
        '                newSimply.productId = productId
        '                newSimply.internalOrderId = orderId
        '                newSimply.publicOrderId = orderNumber
        '                newSimply.cancelProductInformation = cancelProductInformation

        '                AreaState.orders.Add(orderId, newSimply)

        '                Orders.start()
        '            End If

        '            Return True
        '        End Function

        Public Async Sub placeOrder(ByVal product As AreaCommon.Models.Products.ProductModel, ByVal data As Models.Products.ProductOrderModel, Optional sideBuy As Boolean = True, Optional ByVal cancelProductInformation As Boolean = False)
            Dim order As Coinbase.Pro.Models.Order
            Dim side As Coinbase.Pro.Models.OrderSide
            Dim maxPrice As Double = 0

            Try
                If IsNothing(_ClientPro) Then
                    _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
                End If

                If sideBuy Then
                    side = Coinbase.Pro.Models.OrderSide.Buy
                Else
                    side = Coinbase.Pro.Models.OrderSide.Sell
                End If

                order = Await _ClientPro.Orders.PlaceLimitOrderAsync(side, product.pairID, CDec(Math.Abs(data.amount)), CDec(data.maxPrice), Coinbase.Pro.Models.TimeInForce.GoodTillCanceled, product.header.postOnly)

                addLogOperation($"placeOrder {product.header.key}")

                If Not IsNothing(order) Then
                    data.id = order.Id
                    data.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed

                    addLogOperation($"placeOrder {order.Id}")

                    Watch.orders.add(product)
                    Watch.start()

                End If
            Catch ex As Exception
                MessageBox.Show($"Problem during placeOrder {side} {product.pairID} {CDec(data.tcoQuote)} {CDec(Math.Abs(data.amount))} {CDec(data.maxPrice)} - " & ex.Message)
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

                Orders.placeOrder(product, sellData, False)

                sellData.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented
            End If
        End Sub

        '        ''' <summary>
        '        ''' This method provide to start a pair job
        '        ''' </summary>
        '        ''' <returns></returns>
        '        Public Function [start]() As Boolean
        '            If Not stateOn Then
        '                stateOn = True

        '                Dim objWS As Threading.Thread

        '                objWS = New Threading.Thread(AddressOf startServiceBot)

        '                objWS.Start()
        '            End If

        '            Return True
        '        End Function

        '        Public Function [stop]() As Boolean
        '            stateOn = False

        '            Return True
        '        End Function

    End Module

End Namespace
