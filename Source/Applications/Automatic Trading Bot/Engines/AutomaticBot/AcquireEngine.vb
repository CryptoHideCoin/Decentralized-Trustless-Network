Option Compare Text
Option Explicit On


Namespace AreaCommon.Engines.Bots

    Public Class AcquireEngine

        Private Property _DealList As New List(Of Models.Products.ProductModel)
        Private Property _InvestmentList As New List(Of Models.Products.ProductModel)


        Private Const _TimeToComplete = 10 * 60 * 10


        Public Property inTrade As New List(Of AreaCommon.Models.Products.ProductModel)


        Public Function changeInBlockSell() As Boolean
            For Each product In inTrade
                If product.activity.inUse Then
                    product.changeTargetInMin()
                End If
            Next

            Return True
        End Function

        ''' <summary>
        ''' This method provide to determinate the trade list
        ''' </summary>
        ''' <returns></returns>
        Private Function completeReorderProducts() As Boolean
            Try
                Dim temporallyList As New List(Of Models.Products.ProductModel)
                Dim minValue As Models.Products.ProductModel
                Dim foundItem As Boolean = True

                _DealList = New List(Of Models.Products.ProductModel)

                For Each product In AreaState.products.items
                    If product.userData.isCustomized Then
                        If (product.userData.preference = Models.Products.ProductUserDataModel.PreferenceEnumeration.prefered) Then

                            If Not product.activity.inUse Then
                                temporallyList.Add(product)
                            End If

                        End If
                    End If
                Next

                For Each product In AreaState.products.items
                    If product.userData.isCustomized Then
                        If (product.userData.preference = Models.Products.ProductUserDataModel.PreferenceEnumeration.toWork) Then

                            If Not product.activity.inUse Then
                                temporallyList.Add(product)
                            End If

                        End If
                    End If
                Next

                Do While (temporallyList.Count > 0)
                    minValue = Nothing

                    If (temporallyList.Count = 1) Then
                        _DealList.Add(temporallyList.First())

                        temporallyList.Remove(temporallyList.First())
                    Else
                        For Each product In temporallyList
                            If IsNothing(minValue) Then
                                minValue = product
                            Else
                                If minValue.value.bottomPercentPosition > product.value.bottomPercentPosition Then
                                    minValue = product
                                End If
                            End If
                        Next

                        _DealList.Add(minValue)
                        temporallyList.Remove(minValue)
                    End If
                Loop

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Function fundAvailable() As Double
            Accounts.refresh()

            If AreaState.gainFund.currentLockedFund > 0 Then
                Return AreaState.accounts("USDT".ToLower()).available - AreaState.gainFund.currentLockedFund
            Else
                Return AreaState.accounts("USDT".ToLower()).available
            End If
        End Function

        Private Function determinateOrderValue(ByVal bottomPercentPosition As Double, ByVal unitStep As Double) As Double
            Dim temp As Double = 0

            temp = 100 - bottomPercentPosition
            temp = temp * unitStep / 100

            Return temp
        End Function

        Private Function completeInvestProducts(Optional ByVal ordinary As Boolean = True) As Boolean
            Dim productName As String = ""

            Try
                Dim buy As Models.Products.ProductOrderModel
                Dim buyInSent As Models.Products.ProductOrderModel
                Dim orderNumber As String = ""
                Dim orderValue As Double = 0
                Dim totalValue As Double = 0
                Dim investInProduct As Boolean

                For Each product In _DealList
                    buy = New Models.Products.ProductOrderModel

                    orderValue = determinateOrderValue(product.value.bottomPercentPosition, AreaState.automaticBot.settings.unitStep)

                    If Not IsNothing(buyInSent) Then
                        Do While (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed)
                            Threading.Thread.Sleep(500)
                        Loop
                    End If

                    investInProduct = True
                    totalValue = fundAvailable()

                    If investInProduct Then
                        investInProduct = (totalValue > orderValue)
                    End If
                    If investInProduct Then
                        investInProduct = (orderValue <> 0)
                    End If

                    If investInProduct Then
                        product.activity.dateLastCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - 45000

                        buy.dateAcquire = 0
                        buy.tcoQuote = orderValue
                        buy.amount = roundBase(orderValue / product.value.current, product.header.baseIncrement, True)
                        buy.maxPrice = roundBase(product.value.current + (product.value.current / 100), product.header.quoteIncrement, True)
                        buy.tcoQuote = roundBase(product.value.current * buy.amount, product.header.quoteIncrement, True)

                        orderValue = buy.amount * buy.maxPrice
                        orderValue += (orderValue / 100)

                        If (product.header.minMarketFunds <= buy.tcoQuote) And (totalValue > orderValue) Then
                            product.activity.buys.Add(buy)

                            Orders.placeOrder(product, buy)

                            _InvestmentList.Add(product)

                            buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented

                            buyInSent = buy
                        End If
                    End If
                    Threading.Thread.Sleep(10)
                Next
            Catch ex As Exception
                MessageBox.Show($"Problem during {productName} completeInvestProducts - " & ex.Message)
            End Try

            Return True
        End Function


        Public Function [run]() As Boolean
            Dim proceed As Boolean = True
            Dim startTimer As Double

            If proceed Then
                Threading.Thread.Sleep(50)

                proceed = completeReorderProducts()
            End If
            If proceed Then
                Threading.Thread.Sleep(50)

                proceed = completeInvestProducts()
            End If
            If proceed Then
                startTimer = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                Do While ((startTimer + _TimeToComplete) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    Threading.Thread.Sleep(50)
                Loop
            End If

            Return proceed
        End Function

    End Class

End Namespace
