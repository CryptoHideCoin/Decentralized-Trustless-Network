Imports Coinbase.Pro

Module Main

    Private Property _ClientPro As CoinbaseProClient

    Private Property _LastTickHour As New List(Of Double)
    Private Property _AverageHour As Double = 0
    Private Property _AverageRecent As Double = 0
    Private Property _LastAcquire As New List(Of Double)
    Private Property _MinValue As Double = 0
    Private Property _MaxValue As Double = 0

    Private Function updateTotals() As Boolean
        Dim total As Double = 0
        Dim totalTrend As Double = 0
        Dim value As Double

        _AverageHour = 0
        _AverageRecent = 0
        _MinValue = 0
        _MaxValue = 0

        For index = 0 To 59

            value = _LastTickHour(index)
            If (index = 0) Then
                _MinValue = value
                _MaxValue = value
            End If

            total += value

            If (index > 14) Then
                totalTrend += value
            End If

            If (_MinValue > value) Then
                _MinValue = value
            End If
            If (_MaxValue < value) Then
                _MaxValue = value
            End If
        Next

        _AverageHour = total / 60
        _AverageRecent = totalTrend / 30

        Return True
    End Function

    Private Function evaluationAcquire(ByVal marketPrice As Double) As Boolean
        ' Ho già fatto acquisti ?

        ' non ho già fatto acquisti
        Return True
    End Function


    Private Async Function manageTrade() As Task(Of Boolean)
        Dim market = Await _ClientPro.MarketData.GetTickerAsync("DREP-USDT")

        If (_LastTickHour.Count = 60) Then
            _LastTickHour.RemoveAt(0)
        End If

        _LastTickHour.Add(market.Price)

        If (_LastTickHour.Count = 60) Then
            updateTotals()

            If evaluationAcquire(market.Price) Then
                'acquireAsset()
            End If
        Else
            Return False
        End If

        Return True
    End Function

    'Private Async Function goal(ByVal clientPro As CoinbaseProClient, ByVal pair As String, ByVal trigger As Double) As Task(Of Boolean)

    '    Dim market = Await clientPro.MarketData.GetTickerAsync(pair)

    '    Console.WriteLine("Price = " & market.Price)

    '    Return (market.Price >= trigger)
    'End Function

    'Private Async Function convert(ByVal clientPro As CoinbaseProClient, ByVal product As String, ByVal quantity As Double) As Task(Of Boolean)

    '    'Dim order = Await clientPro.Orders.PlaceMarketOrderAsync(Models.OrderSide.Buy, "BTC-USDT", 0.00005)

    '    Dim order = Await clientPro.Orders.PlaceLimitOrderAsync(Models.OrderSide.Sell, "BTC-EUR", 0.00050469, 19815)

    '    Return True

    'End Function


    Sub Main()
        _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = "0056fd332d3742fe03e23611e458f5f6", .Passphrase = "7453tzgjyvo", .Secret = "PWgu2Ssj/O6dZZA9PGjYqqOrLjWKX4Ek6bRPHzDKLYajgiYaBDfdQv5WBuTwcW6ezuYOF6XKpx0q4eyBQTCThA==", .ApiUrl = "https://api.pro.coinbase.com"})

        Do While Not Task.Run(Function() manageTrade()).Result
            Threading.Thread.Sleep(60000)
        Loop

        'Do While Not Task.Run(Function() goal(clientPro, "BTC-USDT", 19260)).Result
        '    Threading.Thread.Sleep(1000)
        'Loop

        'Dim accounts = Task.Run(Function() clientPro.Accounts.GetAllAccountsAsync()).Result
        ''Dim limitPriceRound As Decimal = 0
        ''Dim order = Task.Run(Function() clientPro.Orders.PlaceLimitOrderAsync(Models.OrderSide.Buy, "BTC-USDT", 1, limitPriceRound, Models.TimeInForce.GoodTillCanceled)).Result


        'For Each account In accounts
        '    If account.Currency = "EUR" Or account.Currency = "BTC" Then
        '        Console.WriteLine($"Value Price: {account.Available}")

        '        If Task.Run(Function() convert(clientPro, "BTC-USDT", 0.00001)).Result Then
        '            Console.WriteLine($"Order placed!")
        '        End If
        '    End If
        'Next

        '        {
        '            If (account.Currency == "EUR" || account.Currency == "BTC" || account.Currency == "ETH")
        '            {
        '                Console.WriteLine($"====================================", Console.ForegroundColor);
        '                Console.WriteLine($"Value Price: {account.Currency}", Console.ForegroundColor);
        '                Console.WriteLine($"Value Liquidity: {account.Available}", Console.ForegroundColor);

        '                accountCoin.Add(account.Currency);
        '                accountAvailable.Add(account.Available);
        '            }
        '        }

        'Dim limitPriceRound As Decimal = 0
        'Dim order = Task.Run(Function() clientPro.Orders.PlaceLimitOrderAsync(Models.OrderSide.Buy, "EUR-BTC", 1, limitPriceRound, Models.TimeInForce.GoodTillCanceled).Result 


    End Sub

End Module
