Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Products

    Public Class ProductBaseModel

        Public Property key As String = ""
        Public Property name As String = ""

        Public Property baseCurrency As String = ""
        Public Property quoteCurrency As String = ""

        Public Property baseIncrement As String = ""
        Public Property quoteIncrement As String = ""

        Public Property minMarketFunds As String = ""

        Public Property postOnly As Boolean = False
        Public Property limitOnly As Boolean = False

        Public Property tradingDisabled As Boolean = False
        Public Property status As String = ""
        Public Property statusMessage As String = ""

    End Class

    Public Class ProductValueModel

        Public Property automaticMinValue As Boolean = False
        Public Property automaticMaxValue As Boolean = False

        Public Property minValue As Double = 0
        Public Property dateLast As Double = 0

        Public Property maxValue As Double = 0
        Public Property dateMax As Double = 0

        Public Property current As Double = 0

        Public ReadOnly Property averageWork As Double
            Get
                Return (maxValue - minValue) / 2
            End Get
        End Property

        Public Function bottomPercentPosition(Optional ByVal currentValue As Double = 0) As Double
            If currentValue = 0 Then
                currentValue = current
            End If

            If (averageWork = 0) Then
                Return 0
            Else
                Return (currentValue - minValue) / (maxValue - minValue) * 100
            End If
        End Function

    End Class

    Public Class ProductUserDataModel

        Public Enum StateEnumeration
            undefined = -1
            deep = 0
            work = 1
            high = 2
        End Enum

        Public Enum PreferenceEnumeration
            undefined = -1
            ignore = 0
            userOnly = 1
            toWork = 2
            prefered = 3
            automaticDisabled = 4
        End Enum

        Public Property state As StateEnumeration = StateEnumeration.undefined
        Public Property preference As PreferenceEnumeration = PreferenceEnumeration.undefined

        Public Property isCustomized As Boolean = False

    End Class

    Public Class ProductOrderModel

        Public Property id As String = ""
        Public Property dateAcquire As Double = 0
        Public Property datePlaced As Double = 0
        Public Property amount As Double = 0
        Public Property tcoQuote As Double = 0
        Public Property maxPrice As Double = 0
        Public Property feeCost As Double = 0
        Public Property state As Models.Bot.BotOrderModel.OrderStateEnumeration = Bot.BotOrderModel.OrderStateEnumeration.undefined
        Public Property cancelSellIfSlow As Boolean = False

    End Class

    Public Class ProductActivityModel

        Private m_dbl_Target As Double = 0

        Public Property dateLastCheck As Double = 0
        Public Property fastCheck As Boolean = False

        Public Property buys As New List(Of ProductOrderModel)

        Public Property sell As New ProductOrderModel

        Public ReadOnly Property inUse As Boolean
            Get
                Return (buys.Count > 0)
            End Get
        End Property

        Public Property target As Double
            Get
                If AreaState.defaultUserDataAccount.useVirtualAccount Then
                    Return sell.tcoQuote
                Else
                    Return m_dbl_Target
                End If
            End Get
            Set(value As Double)
                m_dbl_Target = value
            End Set
        End Property

        Public ReadOnly Property earn As Double
            Get
                Return sell.tcoQuote - totalInvestment
            End Get
        End Property

        Public ReadOnly Property totalAmount As Double
            Get
                Dim total As Double = 0
                Dim repeat As Boolean = True

                Do While repeat
                    repeat = False

                    Try
                        For Each buy In buys
                            If (buy.state = Bot.BotOrderModel.OrderStateEnumeration.filled) Then
                                total += CDec(buy.amount)
                            End If
                        Next
                    Catch ex As Exception
                        repeat = True
                    End Try
                Loop

                Return total
            End Get
        End Property

        Public ReadOnly Property totalInvestment As Double
            Get
                Dim total As Double = 0

                For Each buy In buys
                    If (buy.state = Bot.BotOrderModel.OrderStateEnumeration.filled) Then
                        total += CDec(buy.tcoQuote)
                    End If
                Next

                Return total
            End Get
        End Property

        Public ReadOnly Property totalFee As Double
            Get
                Dim total As Double = 0

                For Each buy In buys
                    If (buy.state = Bot.BotOrderModel.OrderStateEnumeration.filled) Then
                        total += CDec(buy.feeCost)
                    End If
                Next

                Return total
            End Get
        End Property

        Public ReadOnly Property openBuy() As ProductOrderModel
            Get
                For Each buy In buys
                    If (buy.state = Bot.BotOrderModel.OrderStateEnumeration.placed) Then
                        Return buy
                    End If
                Next

                Return New ProductOrderModel
            End Get
        End Property

        Public Function removeOpenBuy() As Boolean
            For Each buy In buys
                If (buy.state <> Bot.BotOrderModel.OrderStateEnumeration.filled) Then
                    buys.Remove(buy)

                    Return True
                End If
            Next

            Return False
        End Function

        Public ReadOnly Property lastBuy() As ProductOrderModel
            Get
                Dim lastOrderBuy As New ProductOrderModel

                For Each buy In buys
                    If (buy.state = Bot.BotOrderModel.OrderStateEnumeration.filled) Then
                        If (lastOrderBuy.dateAcquire < buy.dateAcquire) Then
                            lastOrderBuy = buy
                        End If
                    End If
                Next

                Return lastOrderBuy
            End Get
        End Property

        Public ReadOnly Property firstBuy() As ProductOrderModel
            Get
                Dim firstOrderBuy As New ProductOrderModel

                For Each buy In buys
                    If (buy.state = Bot.BotOrderModel.OrderStateEnumeration.filled) Then
                        If (firstOrderBuy.dateAcquire > buy.dateAcquire) Or (firstOrderBuy.dateAcquire = 0) Then
                            firstOrderBuy = buy
                        End If
                    End If
                Next

                Return firstOrderBuy
            End Get
        End Property

    End Class


    Public Class ProductModel

        Public Property header As New ProductBaseModel
        Public Property value As New ProductValueModel
        Public Property userData As New ProductUserDataModel
        Public Property activity As New ProductActivityModel
        Public Property useMaxTarget As Boolean = True
        Public Property applyTargetPercent As Double = 0

        Public ReadOnly Property pairID As String
            Get
                Return $"{header.baseCurrency}-{header.quoteCurrency}"
            End Get
        End Property

        Public ReadOnly Property currentValue As Double
            Get
                Return CDec(value.current) * activity.totalAmount
            End Get
        End Property

        Public ReadOnly Property currentSpread() As Double
            Get
                Return CDec(currentValue) - activity.totalInvestment
            End Get
        End Property

        Public ReadOnly Property currentSpreadPerc() As Double
            Get
                Return currentSpread / activity.totalInvestment * 100
            End Get
        End Property

        Public ReadOnly Property currentTarget() As Double
            Get
                Return activity.target
            End Get
        End Property

        Public ReadOnly Property currentTargetReached() As Boolean
            Get
                Return (currentValue >= activity.target)
            End Get
        End Property

        Public Function inDeal(ByVal dealPercValue As Double) As Boolean
            If (activity.totalInvestment = 0) Then
                Return False
            Else
                Return (dealValue(dealPercValue) >= value.current)
            End If
        End Function

        Public Function dealValue(ByVal dealPercValue As Double) As Double
            With activity.lastBuy
                Return .maxPrice - (.maxPrice * dealPercValue / 100)
            End With
        End Function

        Public Function resetData() As Boolean
            If userData.isCustomized Then
                activity.buys = New List(Of ProductOrderModel)
                activity.sell = New ProductOrderModel

                activity.dateLastCheck = 0

                activity.target = 0
            End If

            Return True
        End Function

        Private Function numWeekStock() As Integer
            Return Math.Truncate((activity.lastBuy.dateAcquire - activity.firstBuy.dateAcquire) / 1000 / 60 / 24 / 7)
        End Function

        Public Function switchTarget(Optional ByVal useMax As Boolean = True, Optional ByVal fromBuy As Boolean = False) As Boolean
            useMaxTarget = useMax

            If useMax Then
                applyTargetPercent = AreaState.automaticBot.settings.maxDailyEarn + numWeekStock()
            Else
                applyTargetPercent = AreaState.automaticBot.settings.minDailyEarn + numWeekStock()
            End If

            activity.target = activity.totalInvestment + (activity.totalInvestment * applyTargetPercent / 100)

            If fromBuy Then
                Return True
            End If

            ' Devo cancellare l'ordine in corso se non è aperto ...
            If Not AreaState.exchangeProxy.getOpenOrder(activity.sell.id) Then
                Try
                    Dim clientPro As Coinbase.Pro.CoinbaseProClient

                    clientPro = New Coinbase.Pro.CoinbaseProClient(New Coinbase.Pro.Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})

                    clientPro.Orders.CancelOrderByIdAsync(activity.sell.id)

                    addLogOperation($"switchTarget - after Cancel Order {activity.sell.id}")

                    activity.sell = New ProductOrderModel

                    Engines.Watch.orders.remove(Me, "Orders")

                    Engines.Watch.start()
                Catch ex As Exception
                    addLogOperation($"switchTarget - Error {activity.sell.id} - {ex.Message}")
                End Try
            End If

            Engines.Watch.trades.add(Me, "Trades")

            Return True
        End Function

    End Class



    Public Class ProductsModel

        Private Property _Index As New Dictionary(Of String, ProductModel)

        Public Property items As New List(Of ProductModel)

        Public Function addNew(ByVal key As String) As ProductModel
            Dim newItem As New ProductModel

            Try
                newItem.header.key = key

                items.Add(newItem)
                _Index.Add(key, newItem)
            Catch ex As Exception
            End Try

            Return newItem
        End Function

        Public Function addNew(ByVal key As String, ByRef data As ProductModel) As Boolean
            Try
                items.Add(data)
                _Index.Add(key, data)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function exist(ByVal key As String) As Boolean
            Return _Index.ContainsKey(key)
        End Function

        Public Function getCurrency(ByVal key As String) As ProductModel
            If _Index.ContainsKey(key) Then
                Return _Index(key)
            Else
                Return New ProductModel
            End If
        End Function

    End Class

End Namespace
