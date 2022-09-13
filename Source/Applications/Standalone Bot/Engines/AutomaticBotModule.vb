Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines.Bots

    Module AutomaticBotModule

        Private Property _InWorkJob As Boolean = False

        Private Property _InvestmentList As New List(Of Models.Products.ProductModel)




        ''' <summary>
        ''' This method provide to return a path order to delivery
        ''' </summary>
        ''' <returns></returns>
        Private Function pathOrderToDelivery(ByVal fileName As String) As String
            Return System.IO.Path.Combine(IO.orderToDeliveryPath, fileName & ".order")
        End Function

        ''' <summary>
        ''' This method provide to create file order
        ''' </summary>
        ''' <param name="pair"></param>
        ''' <param name="id"></param>
        ''' <param name="buy"></param>
        ''' <param name="amount"></param>
        ''' <param name="limitPrice"></param>
        ''' <returns></returns>
        Private Function createFileOrder(ByVal pair As String, ByVal id As String, ByVal buy As Boolean, ByVal amount As Double, ByVal limitPrice As Double) As Boolean
            Dim content As String = $"Release=1.0{vbNewLine}"

            If buy Then
                content += $"Mode=Buy{vbNewLine}"
            Else
                content += $"Mode=Sell{vbNewLine}"
            End If

            content += $"Passphrase={AreaState.defaultUserDataAccount.exchangeAccess.passphrase}{vbNewLine}"
            content += $"Secret={AreaState.defaultUserDataAccount.exchangeAccess.secret}{vbNewLine}"
            content += $"API key={AreaState.defaultUserDataAccount.exchangeAccess.APIKey}{vbNewLine}"
            content += $"Pair={pair}{vbNewLine}"
            content += $"Amount={amount}{vbNewLine}"
            content += $"LimitPrice={limitPrice}{vbNewLine}"

            Dim fileName As String = pathOrderToDelivery(id)

            If Not System.IO.File.Exists(fileName) Then
                Dim objWriter As New System.IO.StreamWriter(fileName)

                objWriter.Write(content)
                objWriter.Close()
            End If

            Return True
        End Function

        Private Function removeOrder(ByVal internalOrderId As String) As Boolean
            System.IO.File.Delete(pathOrderToPlaced(internalOrderId))

            AreaState.orders.Remove(internalOrderId)

            Return True
        End Function

        Private Function completeRemoveActiveProducts() As Boolean
            Try
                For Each product In AreaState.products.items
                    If product.userData.isCustomized Then
                        If product.targetReached() Then
                            ' Qua devo effettuare la cancellazione dell'ordine di vendita

                            ' E il piazzamento del nuovo ordine al valore attuale con il valore attuale giusto per cambiare la somma

                            ' Così recupero la somma

                            Return False
                        End If
                    End If
                Next

                Return True
            Catch ex As Exception
            End Try

            Return False
        End Function

        Private Function determinateOrderValue(ByVal bottomPercentPosition As Double, ByVal unitStep As Double) As Double
            Dim temp As Double = 0

            temp = 100 - bottomPercentPosition
            temp = temp * unitStep / 100

            Return temp
        End Function

        Private Function restockProduct(ByRef value As AreaCommon.Models.Products.ProductModel) As Boolean
            Dim orderValue As Double = 0

            orderValue = determinateOrderValue(value.value.bottomPercentPosition, AreaState.automaticBot.settings.unitStep)

            ' piazzo l'ordine

            ' Che faccio ?!?

            ' Prendo lo unit step

            ' Cerco di capire la percentuale di rischio

            ' Determino quanto devo investire

            ' Quindi faccio un nuovo ordine e lo aggiungo a quelli esistenti
        End Function

        Private Function completeDistressedInvestment() As Boolean
            Try
                For Each product In AreaState.products.items
                    If product.userData.isCustomized Then
                        If product.inDeal(AreaState.automaticBot.settings.dealAcquireOnPercentage) Then
                            restockProduct(product)

                            Return False
                        End If
                    End If
                Next

                Return True
            Catch ex As Exception
            End Try

            Return False
        End Function

        Private Function completeReorderProducts() As Boolean
            Try
                Dim temporallyList As New List(Of Models.Products.ProductModel)
                Dim minValue As Models.Products.ProductModel
                Dim foundItem As Boolean = True

                _InvestmentList = New List(Of Models.Products.ProductModel)

                For Each product In AreaState.products.items
                    If product.userData.isCustomized Then
                        If (product.userData.preference = Models.Products.ProductUserDataModel.PreferenceEnumeration.prefered) Then

                            If (product.activity.buys.Count = 0) Then
                                temporallyList.Add(product)
                            End If

                        End If
                    End If
                Next

                For Each product In AreaState.products.items
                    If product.userData.isCustomized Then
                        If (product.userData.preference = Models.Products.ProductUserDataModel.PreferenceEnumeration.toWork) Then

                            If (product.activity.buys.Count = 0) Then
                                temporallyList.Add(product)
                            End If

                        End If
                    End If
                Next

                Do While (temporallyList.Count > 0)
                    minValue = Nothing

                    If (temporallyList.Count = 1) Then
                        _InvestmentList.Add(temporallyList.First())

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

                        _InvestmentList.Add(minValue)
                        temporallyList.Remove(minValue)
                    End If
                Loop

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a path order to placed
        ''' </summary>
        ''' <returns></returns>
        Private Function pathOrderToPlaced(ByVal fileName As String) As String
            Return System.IO.Path.Combine(Engine.IO.orderPlacedPath, fileName & ".confirm")
        End Function

        ''' <summary>
        ''' This method provide to return a path order to close
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <returns></returns>
        Private Function pathOrderToClose(ByVal completeName As String) As String
            Return System.IO.Path.Combine(AreaCommon.Engine.IO.orderClosePath, completeName)
        End Function

        ''' <summary>
        ''' This method provide to create a false response order
        ''' </summary>
        ''' <param name="orderId"></param>
        ''' <returns></returns>
        Private Function createFalseResponseOrder(ByVal orderId As String, ByRef orderNumber As String) As Boolean
            Dim content As String = $"Release=1.0{vbNewLine}"

            orderNumber = Guid.NewGuid.ToString()
            content += $"OrderNumber={orderNumber}{vbNewLine}"

            Dim fileName As String = pathOrderToPlaced(orderId)

            If Not System.IO.File.Exists(fileName) Then
                Dim objWriter As New System.IO.StreamWriter(fileName)

                objWriter.Write(content)
                objWriter.Close()
            End If

            System.IO.File.Move(pathOrderToDelivery(orderId), pathOrderToClose(orderId & ".order"))

            Return True
        End Function

        ''' <summary>
        ''' This method provide to add a new order to the service
        ''' </summary>
        ''' <param name="productId"></param>
        ''' <param name="orderId"></param>
        ''' <param name="orderNumber"></param>
        ''' <returns></returns>
        Private Function startMonitorOrder(ByVal productId As String, ByVal orderId As String, ByVal orderNumber As String) As Boolean
            If Not AreaState.orders.ContainsKey(orderId) Then
                Dim newSimply As New Models.Order.SimplyOrderModel

                newSimply.accountCredentials = AreaState.defaultUserDataAccount.exchangeAccess
                newSimply.productId = productId
                newSimply.internalOrderId = orderId
                newSimply.publicOrderId = orderNumber

                AreaState.orders.Add(orderId, newSimply)

                Orders.start()
            End If

            Return True
        End Function

        Private Function completeInvestProducts() As Boolean
            Dim buy As Models.Products.ProductOrderModel
            Dim orderNumber As String = ""
            Dim orderValue As Double = 0

            For Each product In _InvestmentList
                buy = New Models.Products.ProductOrderModel

                orderValue = determinateOrderValue(product.value.bottomPercentPosition, AreaState.automaticBot.settings.unitStep)

                If (AreaState.accounts("USDT".ToLower()).valueUSDT >= orderValue) Then
                    product.activity.inUse = True
                    product.activity.dateLastCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                    buy.dateAcquire = 0
                    buy.internalOrderId = Guid.NewGuid.ToString
                    buy.tcoQuote = orderValue
                    buy.amount = orderValue / product.value.current
                    buy.tcoQuote = product.value.current * buy.amount

                    product.activity.buys.Add(buy)

                    createFileOrder(product.pairID, buy.internalOrderId, True, buy.amount, buy.tcoQuote)

                    buy.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.sented

                    createFalseResponseOrder(buy.internalOrderId, orderNumber)

                    buy.orderNumber = orderNumber
                    buy.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.placed

                    startMonitorOrder(product.header.key, buy.internalOrderId, buy.orderNumber)
                End If
            Next

            Return True
        End Function

        Private Function createNewOrder(ByRef product As Models.Products.ProductModel, ByVal spread As Double, Optional ByVal forceAmount As Double = 0) As Boolean
            Dim order As Models.Products.ProductOrderModel
            Dim orderNumber As String = ""
            Dim orderValue As Double = 0
            Dim futureValue As Double = 0

            order = New Models.Products.ProductOrderModel

            futureValue = product.value.current + (product.value.current * spread / 100)

            orderValue = determinateOrderValue(product.value.bottomPercentPosition(futureValue), AreaState.automaticBot.settings.unitStep)

            If (AreaState.accounts("USDT".ToLower()).valueUSDT >= orderValue) Then
                order.dateAcquire = 0
                order.internalOrderId = Guid.NewGuid.ToString
                order.tcoQuote = orderValue

                If forceAmount = 0 Then
                    order.amount = order.tcoQuote / futureValue
                Else
                    order.amount = forceAmount
                End If

                order.tcoQuote = futureValue * order.amount

                If (spread > 0) Then
                    product.activity.sell = order
                Else
                    product.activity.buys.Add(order)
                End If

                createFileOrder(product.pairID, order.internalOrderId, True, order.amount, order.tcoQuote)

                order.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.sented

                createFalseResponseOrder(order.internalOrderId, orderNumber)

                order.orderNumber = orderNumber
                order.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.placed

                startMonitorOrder(product.header.key, order.internalOrderId, order.orderNumber)
            End If

            Return True
        End Function


        ''' <summary>
        ''' This method provide to process a pair
        ''' </summary>
        ''' <returns></returns>
        Private Function process() As Boolean
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = AreaState.automaticBot.isActive
                End If
                If proceed Then
                    If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > (AreaState.automaticBot.lastWorkAction + 24 * 60 * 60 * 1000)) Then
                        Select Case AreaState.automaticBot.workAction
                            Case Models.Bot.BotAutomatic.WorkStateEnumeration.undefined
                                If completeRemoveActiveProducts() Then
                                    AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.checkBalance
                                End If
                            Case Models.Bot.BotAutomatic.WorkStateEnumeration.checkBalance
                                If AreaState.accounts.ContainsKey("USDT".ToLower()) Then
                                    If (AreaState.accounts("USDT".ToLower()).valueUSDT >= AreaState.automaticBot.settings.unitStep) Then
                                        AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.distressedInvestment
                                    End If
                                End If
                            Case Models.Bot.BotAutomatic.WorkStateEnumeration.distressedInvestment
                                If completeDistressedInvestment() Then
                                    AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.reorderProducts
                                End If
                            Case Models.Bot.BotAutomatic.WorkStateEnumeration.reorderProducts
                                If completeReorderProducts() Then
                                    AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.investProducts
                                End If
                            Case Models.Bot.BotAutomatic.WorkStateEnumeration.investProducts
                                If completeInvestProducts() Then
                                    AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.completeWork
                                End If
                            Case Models.Bot.BotAutomatic.WorkStateEnumeration.completeWork
                                AreaState.automaticBot.lastWorkAction = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                                ' Change current page

                                AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.undefined
                        End Select
                    Else
                        ' guardo se gli ordini sono stati piazzati e quindi ....

                        ' eventualmente aggiorno la posizione del singolo ordine... 
                    End If
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceBot()
            Try
                Dim currentIndex As Integer = 0

                Do While _InWorkJob
                    process()

                    Threading.Thread.Sleep(50)
                Loop
            Catch ex As Exception
                _InWorkJob = False
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to calculate fee cost of a transaction
        ''' </summary>
        ''' <param name="totalValue"></param>
        ''' <returns></returns>
        Private Function calculateFeeCost(ByVal totalValue As Double) As Double
            Dim feePercentage As Double

            Select Case New Random().Next(0, 2)
                Case 0 : feePercentage = 0.6
                Case Else : feePercentage = 0.4
            End Select

            Return totalValue * feePercentage / 100
        End Function

        Public Function manageOrderProduct(ByVal productId As String, ByVal internalOrderId As String) As Boolean
            Dim product = AreaState.products.getCurrency(productId)

            For Each buy In product.activity.buys
                If (buy.internalOrderId.CompareTo(internalOrderId) = 0) Then

                    If (buy.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.placed) Then

                        If (product.value.current * buy.amount <= buy.tcoQuote) Then
                            buy.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                            buy.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                            buy.feeCost = calculateFeeCost(buy.tcoQuote)

                            AreaState.summary.totalFeesValue += CDec(buy.feeCost)
                            AreaState.summary.totalVolumeValue += CDec(buy.tcoQuote)

                            buy.tcoQuote += buy.feeCost

                            AreaState.orders.Remove(internalOrderId)

                            System.IO.File.Delete(pathOrderToPlaced(internalOrderId))

                            AreaState.addIntoAccount(product.pairID, (-1) * buy.tcoQuote, True)
                            AreaState.addIntoAccount(product.pairID, buy.amount, False)

                            createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage)

                            If (product.activity.sell.internalOrderId.Length > 0) Then
                                removeOrder(product.activity.sell.internalOrderId)
                            End If

                            createNewOrder(product, AreaState.automaticBot.settings.maxDailyEarn, product.activity.totalAmount())

                            Return False
                        End If
                    End If

                End If
            Next

            ' Controllo anche la vendita
            ' Se il target è stata raggiunta... allora cancello l'ordine di deal

            Return True
        End Function

        ''' <summary>
        ''' This method provide to start a pair job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not _InWorkJob Then
                Dim objWS As Threading.Thread

                _InWorkJob = True

                objWS = New Threading.Thread(AddressOf startServiceBot)

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