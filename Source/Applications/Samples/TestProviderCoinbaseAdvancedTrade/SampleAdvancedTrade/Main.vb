Option Explicit On

Imports AdvancedTrade
Imports AdvancedTrade.Models
Imports AdvancedTrade.WebSockets
Imports WebSocket4Net

Module Main

    Private Property _Sub As Subscription = New Subscription
    Private Property _Socket As AdavancedTradeWebSocket

    'Async Sub registerSocketCoinbasePro()
    '    _Socket = New AdavancedTradeWebSocket()

    '    Dim result = Await _Socket.ConnectAsync()

    '    AddHandler _Socket.RawSocket.MessageReceived, AddressOf RawSocket_MessageReceived

    '    _Socket.RawSocket.AutoSendPingInterval = 60000
    '    _Socket.RawSocket.EnableAutoSendPing = True

    '    _Sub.ProductIds.Add("BTC-USDT")
    '    _Sub.ProductIds.Add("ETH-USDT")

    '    _Sub.Channels.Add("ticker")

    '    Await _Socket.SubscribeAsync(_Sub)
    'End Sub

    Async Sub registerSocketAdvancedTrade()
        _Socket = New AdavancedTradeWebSocket()

        _Socket.Config.ApiKey = "s56G5OI9uA6rnQvA"
        _Socket.Config.ApiPrivate = "Q75nC8RWJRV0k9HRrniQx4iXUdxSHJip"

        Dim result = Await _Socket.ConnectAsync()

        AddHandler _Socket.RawSocket.MessageReceived, AddressOf RawSocket_MessageReceived

        _Socket.RawSocket.AutoSendPingInterval = 60000
        _Socket.RawSocket.EnableAutoSendPing = True

        _Sub.ProductIds.Add("BTC-USDT")
        '_Sub.ProductIds.Add("ETH-USDT")

        _Sub.Channel = "ticker"

        Await _Socket.SubscribeAsync(_Sub)
    End Sub

    Sub RawSocket_MessageReceived(sender As Object, e As MessageReceivedEventArgs)
        Dim msg As Object
        Dim tb As EventTickers
        Dim ee As ErrorEvent

        If WebSocketHelper.TryParse(e.Message, msg) Then
            If (TypeName(msg).ToUpper.CompareTo("EventTickers".ToUpper) = 0) Then
                tb = msg

                For Each eventProd In tb.Events
                    For Each prod In eventProd.Tickers
                        Console.WriteLine($"{prod.Product_Id} - {prod.Price}")
                    Next
                Next
            End If
            If (TypeName(msg).ToUpper.CompareTo("ErrorEvent".ToUpper) = 0) Then
                ee = msg

                If IsNothing(ee.Reason) Then
                    Console.WriteLine(ee.Message)
                ElseIf ee.Reason.ToString.Contains("is not a valid product") Then
                    Console.WriteLine("product wrong")
                Else
                End If
            End If
        End If
    End Sub

    Async Sub readAccounts()
        Dim clientPro As New AdvancedTradeClient(New Config With {.ApiKey = "Y7tfXj4WTgdREnXI", .ApiPrivate = "SPhfiLumFl9ebCSQ1u7irYRs89IZLVE2"})

        Dim accounts = clientPro.Accounts.GetAccountsAsync(Threading.CancellationToken.None)

    End Sub

    Async Sub readProducts()
        Dim clientPro As New AdvancedTradeClient(New Config With {.ApiKey = "Y7tfXj4WTgdREnXI", .ApiPrivate = "SPhfiLumFl9ebCSQ1u7irYRs89IZLVE2"})

        Dim products = Await clientPro.MarketData.GetSingleProductAsync("BTC-USDT")
    End Sub

    Async Sub cancelOrder()
        Dim clientPro As New AdvancedTradeClient(New Config With {.ApiKey = "Y7tfXj4WTgdREnXI", .ApiPrivate = "SPhfiLumFl9ebCSQ1u7irYRs89IZLVE2"})

        Dim orders = Await clientPro.Orders.CancelOrderByIdAsync("a2ae467d-1837-4560-ae8b-31445366aa91")
    End Sub

    Async Sub readOrder()
        Dim clientPro As New AdvancedTradeClient(New Config With {.ApiKey = "Y7tfXj4WTgdREnXI", .ApiPrivate = "SPhfiLumFl9ebCSQ1u7irYRs89IZLVE2"})

        Dim order = Await clientPro.Orders.GetOrderAsync("d3165e2d-9111-45c2-a858-502544786b22")
    End Sub

    Async Sub readProductOrders()
        Dim clientPro As New AdvancedTradeClient(New Config With {.ApiKey = "Y7tfXj4WTgdREnXI", .ApiPrivate = "SPhfiLumFl9ebCSQ1u7irYRs89IZLVE2"})

        Dim orders = Await clientPro.Orders.GetProductOrdersAsync("SOL-EUR")
    End Sub

    Async Sub readFillProductOrders()
        Dim clientPro As New AdvancedTradeClient(New Config With {.ApiKey = "Y7tfXj4WTgdREnXI", .ApiPrivate = "SPhfiLumFl9ebCSQ1u7irYRs89IZLVE2"})

        Dim order = Await clientPro.Orders.GetProductFillOrdersAsync("SOL-EUR", "")
    End Sub

    Async Sub createNewOrder()
        Dim clientPro As New AdvancedTradeClient(New Config With {.ApiKey = "Y7tfXj4WTgdREnXI", .ApiPrivate = "SPhfiLumFl9ebCSQ1u7irYRs89IZLVE2"})

        Dim order = Await clientPro.Orders.PlaceOrderAsync("SOL-EUR", True, 1, CDec(Math.Abs(2.5)))
    End Sub

    Sub Main()
        'registerSocketAdvancedTrade()
        'readAccounts()
        'readProducts()
        'cancelOrder()
        'readOrder()
        'readProductOrders()
        'readFillProductOrders()
        createNewOrder()

        Do While True
            Threading.Thread.Sleep(1000)
        Loop
    End Sub

End Module
