Option Compare Text
Option Explicit On


Namespace AreaCommon.Engines.Bots

    Public Class AcquireEngine

        Private Property _DealList As New List(Of Models.Products.ProductModel)

        Public Property inTargetMode As Boolean = False


        Public Function changeInBlockSell(Optional ByVal normalMode As Boolean = False) As Boolean
            addLogOperation("AcquireEngine.changeInBlockSell - Begin")

            inTargetMode = False

            For Each product In AreaState.products.items
                If product.userData.isCustomized And product.activity.inUse Then
                    product.switchTarget(normalMode)

                    If normalMode Then
                        If product.currentTargetReached Then
                            inTargetMode = True
                        End If
                    End If
                End If
            Next

            addLogOperation("AcquireEngine.changeInBlockSell - Complete")

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

        Private Function completeInvestProducts(Optional ByVal ordinary As Boolean = True) As Boolean
            Dim productName As String = ""

            Try
                Dim buyInSent As Models.Products.ProductOrderModel

                addLogOperation("completeInvestProducts - Begin")

                For Each product In _DealList
                    productName = product.pairID

                    addLogOperation($"completeInvestProducts - Check previous buy before try buy - {productName}")

                    If (AreaState.automaticBot.settings.unitStep > fundAvailable()) Then
                        Exit For
                    End If

                    addLogOperation($"completeInvestProducts - Try to buy {productName}")

                    buyInSent = buyProduct(product)

                    If (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Then
                        Threading.Thread.Sleep(1000)
                    Else
                        Threading.Thread.Sleep(50)
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show($"Problem during {productName} completeInvestProducts - " & ex.Message)
            End Try

            addLogOperation("completeInvestProducts - Complete")

            Return True
        End Function

        Public Function determinateOrderValue(ByVal bottomPercentPosition As Double, ByVal unitStep As Double) As Double
            Dim temp As Double = 0

            temp = 100 - bottomPercentPosition
            temp = temp * unitStep / 100

            Return temp
        End Function

        Public Function buyProduct(ByVal product As Models.Products.ProductModel, Optional ByVal reStockMode As Boolean = False) As Models.Products.ProductOrderModel
            Dim buy As New Models.Products.ProductOrderModel
            Dim investInProduct As Boolean
            Dim totalValue As Double = 0
            Dim orderValue As Double = 0

            Try
                investInProduct = True
                totalValue = fundAvailable()

                orderValue = determinateOrderValue(product.value.bottomPercentPosition, AreaState.automaticBot.settings.unitStep)

                If investInProduct Then
                    investInProduct = (totalValue > orderValue)
                End If
                If investInProduct Then
                    investInProduct = (orderValue > 0)
                End If

                If investInProduct Then
                    product.activity.dateLastCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    product.activity.fastCheck = True
                    buy.dateAcquire = 0
                    buy.tcoQuote = orderValue
                    buy.amount = roundBase(orderValue / product.value.current, product.header.baseIncrement, True)

                    If reStockMode Then
                        buy.maxPrice = roundBase(product.dealValue(AreaState.automaticBot.settings.dealAcquireOnPercentage), product.header.quoteIncrement, True)
                    Else
                        buy.maxPrice = roundBase(product.value.current + (product.value.current / 100), product.header.quoteIncrement, True)
                    End If

                    addLogOperation($"buyProduct {product.header.key} currentFundAvailable = {totalValue} orderValue = {orderValue} qty = {buy.amount} maxPrice = {buy.maxPrice}")

                    orderValue = buy.amount * buy.maxPrice

                    If Not reStockMode Then
                        orderValue += (orderValue / 100)
                    End If

                    buy.tcoQuote = roundBase(orderValue, product.header.quoteIncrement, True)

                    If (buy.tcoQuote > product.header.minMarketFunds) And (totalValue > buy.tcoQuote) Then
                        buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented

                        product.activity.buys.Add(buy)

                        Orders.placeOrder(product, buy)
                    End If
                Else
                    addLogOperation($"buyProduct {product.header.key} orderValue = {orderValue} bottomPercentPosition = {product.value.bottomPercentPosition} unitStep = {AreaState.automaticBot.settings.unitStep}")
                End If

                Return buy
            Catch ex As Exception
                addLogOperation($"Problem during buyProduct... probabily need fund {product.header.key}")

                Return New Models.Products.ProductOrderModel
            End Try
        End Function

        Public Function [run]() As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                Threading.Thread.Sleep(50)

                addLogOperation("AcquireEngine.run - CompleteReorderProducts")

                proceed = completeReorderProducts()
            End If
            If proceed Then
                Threading.Thread.Sleep(50)

                addLogOperation("AcquireEngine.run - CompleteInvestProducts")

                proceed = completeInvestProducts()
            End If
            If proceed Then
                addLogOperation($"AcquireEngine.run - Check orders.count = {Watch.orders.count}")

                Do While (Watch.orders.count > 0)
                    Threading.Thread.Sleep(100)
                Loop
            End If
            If proceed Then
                Threading.Thread.Sleep(60000)
            End If

            Return proceed
        End Function

    End Class

End Namespace
