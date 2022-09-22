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
                        If (product.value.current * product.activity.totalAmount >= product.minTarget) And (product.minTarget > 0) Then
                            If (product.activity.sell.internalOrderId.Length > 0) Then
                                removeOrder(product.activity.sell.internalOrderId)
                            End If

                            createNewOrder(product, 0, True, product.activity.totalAmount())

                            Return False
                        End If
                    End If
                Next

                Return True
            Catch ex As Exception
            End Try

            Return False
        End Function

        Private Function checkAllSellProduct() As Boolean
            Try
                For Each product In AreaState.products.items
                    If product.userData.isCustomized Then
                        If (product.value.current >= product.minTarget) And (product.minTarget > 0) Then
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
                    buy.ordinary = True

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

        Private Function createNewOrder(ByRef product As Models.Products.ProductModel, ByVal spread As Double, ByVal ordinary As Boolean, Optional ByVal forceAmount As Double = 0) As Boolean
            Dim order As Models.Products.ProductOrderModel
            Dim orderNumber As String = ""
            Dim orderValue As Double = 0
            Dim futureValue As Double = 0

            order = New Models.Products.ProductOrderModel

            futureValue = product.value.current + (product.value.current * spread / 100)

            orderValue = determinateOrderValue(product.value.bottomPercentPosition(futureValue), AreaState.automaticBot.settings.unitStep)

            If (AreaState.accounts("USDT".ToLower()).valueUSDT >= orderValue) Or (forceAmount > 0) Then
                order.dateAcquire = 0
                order.internalOrderId = Guid.NewGuid.ToString
                order.tcoQuote = orderValue

                If (forceAmount = 0) Then
                    order.amount = order.tcoQuote / futureValue
                Else
                    order.amount = forceAmount
                End If

                If (spread > 0) Then
                    order.tcoQuote = product.activity.totalInvestment + (product.activity.totalInvestment * spread / 100)
                Else
                    order.tcoQuote = futureValue * order.amount
                End If

                order.ordinary = ordinary

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

        Public Function updateJournalCounter() As Boolean
            AreaState.journal.currentFund = AreaState.accounts("USDT".ToLower()).valueUSDT
            AreaState.journal.futureGain = 0
            AreaState.journal.currentDayCounters.earn = 0

            For Each product In AreaState.products.items
                If product.activity.inUse Then
                    AreaState.journal.currentFund += product.activity.totalAmount * product.value.current
                    AreaState.journal.futureGain += product.activity.target
                    AreaState.journal.currentDayCounters.earn += product.currentSpread
                End If
            Next

            If (AreaState.journal.currentDayCounters.earn = 0) Or (AreaState.journal.currentDayCounters.initialFundFree + AreaState.journal.currentDayCounters.initialFundManage = 0) Then
                AreaState.journal.currentDayCounters.apy = 0
            Else
                AreaState.journal.currentDayCounters.apy = AreaState.journal.currentDayCounters.earn / (AreaState.journal.currentDayCounters.initialFundFree + AreaState.journal.currentDayCounters.initialFundManage) * 100
            End If

            If ((AreaState.journal.totalEarn = 0) And (AreaState.journal.currentDayCounters.earn = 0)) Or (AreaState.journal.currentDayCounters.initialFundFree + AreaState.journal.currentDayCounters.initialFundManage = 0) Then
                AreaState.journal.apy = 0
            Else
                AreaState.journal.apy = ((AreaState.journal.totalEarn + AreaState.journal.currentDayCounters.earn) / (AreaState.journal.currentDayCounters.initialFundFree + AreaState.journal.currentDayCounters.initialFundManage) * 100).ToString("#,##0.00")
            End If

            If (AreaState.journal.numPages = 0) Then
                AreaState.journal.averageApy = 0
            Else
                AreaState.journal.averageApy = AreaState.journal.apy / AreaState.journal.numPages
            End If

            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return True
        End Function

        Private Function checkProductInformation() As Boolean
            For Each product In AreaState.products.items
                If product.activity.inUse Then

                    If (product.value.current > product.value.maxValue) Then
                        product.value.maxValue = product.value.current
                        product.value.automaticMaxValue = True
                        product.value.dateMax = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If

                    If (product.value.dateMax < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - (CLng(1000) * 60 * 60 * 24 * 365 * 2)) Then
                        product.value.automaticMaxValue = False
                        AreaState.journal.alert = $"The Date max value of a product {product.header.key} is out a date"
                    End If

                    If (product.value.dateLast < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - (CLng(1000) * 60 * 60 * 24 * 365 * 2)) Then
                        product.value.automaticMinValue = False
                        AreaState.journal.alert = $"The Date min value of a product {product.header.key} is out a date"
                    End If

                    If (product.value.current < product.value.minValue) And (product.value.current > 0) Then
                        product.value.minValue = product.value.current
                        product.value.automaticMinValue = True
                        product.value.dateLast = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If

                    If (product.activity.openBuy.orderNumber.Length = 0) Then
                        If CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime > product.activity.lastBuy.dateAcquire + (AreaState.automaticBot.settings.dealIntervalMinute * 60000) Then
                            If (AreaState.automaticBot.settings.plafondOperation = 0) Or (AreaState.automaticBot.settings.dealIntervalMinute = 0) Then
                                createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, False)
                            Else
                                If (product.activity.totalInvestment < AreaState.automaticBot.settings.plafondOperation) Then
                                    createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, False)
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            Return True
        End Function

        Private Function openNewJournal() As Boolean
            If (AreaState.journal.currentDayCounters.day > 0) Then
                updateJournalCounter()

                AreaState.journal.totalEarn += AreaState.journal.currentDayCounters.earn

                IO.saveCurrentCounterDay()
            End If

            AreaState.journal.numPages += 1

            AreaState.journal.currentDayCounters = New Models.Journal.DayCounterModel

            AreaState.journal.currentDayCounters.day = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime

            AreaState.journal.currentDayCounters.initialFundFree = AreaState.accounts("USDT".ToLower()).valueUSDT
            AreaState.journal.currentDayCounters.initialFundManage = 0

            For Each product In AreaState.products.items
                If product.activity.inUse Then
                    AreaState.journal.currentDayCounters.initialFundManage += CDec(product.activity.totalAmount) * product.value.current
                End If
            Next

            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

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
                    proceed = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > (AreaState.automaticBot.lastWorkAction + 24 * 60 * 60 * 1000)
                    'proceed = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > (AreaState.automaticBot.lastWorkAction + 5 * 60 * 1000)
                Else
                    Return True
                End If
                If proceed Then
                    Select Case AreaState.automaticBot.workAction
                        Case Models.Bot.BotAutomatic.WorkStateEnumeration.undefined
                            If openNewJournal() Then
                                AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.completeRemoveActiveProducts
                            End If
                        Case Models.Bot.BotAutomatic.WorkStateEnumeration.completeRemoveActiveProducts
                            If completeRemoveActiveProducts() Then
                                AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.checkAllSellDailyProduct
                            End If
                        Case Models.Bot.BotAutomatic.WorkStateEnumeration.checkAllSellDailyProduct
                            If checkAllSellProduct() Then
                                AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.checkBalance
                            End If
                        Case Models.Bot.BotAutomatic.WorkStateEnumeration.checkBalance
                            If AreaState.accounts.ContainsKey("USDT".ToLower()) Then
                                If (AreaState.accounts("USDT".ToLower()).valueUSDT >= AreaState.automaticBot.settings.unitStep) Then
                                    AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.restockProducts
                                End If
                            End If
                        Case Models.Bot.BotAutomatic.WorkStateEnumeration.restockProducts
                            If checkProductInformation() Then
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

                            AreaState.automaticBot.workAction = Models.Bot.BotAutomatic.WorkStateEnumeration.undefined
                    End Select
                Else
                    checkProductInformation()
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

                With AreaState.journal
                    If (.initialDay = 0) Then
                        .initialDay = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
                        .initialFund = AreaState.accounts("USDT".ToLower()).valueUSDT
                        .lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If
                End With

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
            Try
                Dim product = AreaState.products.getCurrency(productId)
                Dim repeat As Boolean = True

                Do While repeat
                    repeat = False

                    Try
                        For Each buy In product.activity.buys
                            If (buy.internalOrderId.CompareTo(internalOrderId) = 0) Then

                                If (buy.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.placed) Then

                                    If (AreaState.accounts("USDT".ToLower()).valueUSDT < buy.tcoQuote) Then
                                        Return True
                                    End If

                                    If (product.value.current > 0) And (product.value.current * buy.amount <= buy.tcoQuote) Then
                                        buy.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                                        buy.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                                        buy.feeCost = calculateFeeCost(buy.tcoQuote)

                                        AreaState.summary.totalFeesValue += CDec(buy.feeCost)
                                        AreaState.summary.totalVolumeValue += CDec(buy.tcoQuote)

                                        AreaState.journal.currentDayCounters.buyNumber += 1
                                        AreaState.journal.currentDayCounters.feePayed += buy.feeCost
                                        AreaState.journal.currentDayCounters.volumes += CDec(buy.tcoQuote)

                                        AreaState.journal.totalFee += buy.feeCost
                                        AreaState.journal.totalVolume += CDec(buy.tcoQuote)

                                        If buy.ordinary Then
                                            AreaState.journal.currentDayCounters.dailyBuy += CDec(buy.tcoQuote)
                                        Else
                                            AreaState.journal.currentDayCounters.extraBuy += CDec(buy.tcoQuote)
                                        End If

                                        With AreaState.journal.currentDayCounters.addNewTransaction()
                                            .amount = buy.amount
                                            .buy = True
                                            .daily = buy.ordinary
                                            .dateCompletate = buy.dateAcquire
                                            .orderNumber = internalOrderId
                                            .pairID = product.header.key
                                            .value = buy.tcoQuote
                                        End With

                                        buy.tcoQuote += buy.feeCost

                                        product.minTarget = product.activity.totalInvestment + (product.activity.totalInvestment * AreaState.automaticBot.settings.minDailyEarn / 100)

                                        removeOrder(internalOrderId)

                                        AreaState.addIntoAccount(product.pairID, (-1) * buy.tcoQuote, True)
                                        AreaState.addIntoAccount(product.pairID, buy.amount, False)

                                        If (AreaState.automaticBot.settings.dealIntervalMinute = 0) Then
                                            If (AreaState.automaticBot.settings.plafondOperation = 0) Then
                                                createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, False)
                                            Else
                                                If (product.activity.totalInvestment < AreaState.automaticBot.settings.plafondOperation) Then
                                                    createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, False)
                                                End If
                                            End If
                                        End If

                                        If (product.activity.sell.internalOrderId.Length > 0) Then
                                            removeOrder(product.activity.sell.internalOrderId)
                                        End If

                                        createNewOrder(product, AreaState.automaticBot.settings.maxDailyEarn, False, product.activity.totalAmount())

                                        AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                                        Return False
                                    End If
                                End If

                            End If
                        Next
                    Catch ex As Exception
                        repeat = True
                    End Try
                Loop

                If (product.activity.sell.internalOrderId.CompareTo(internalOrderId) = 0) Then

                    If (product.value.current > 0) And (product.value.current * product.activity.sell.amount >= product.activity.sell.tcoQuote) Then
                        product.activity.sell.orderState = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                        product.activity.sell.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                        product.activity.sell.feeCost = calculateFeeCost(product.activity.sell.tcoQuote)

                        AreaState.journal.currentDayCounters.sellNumber += 1

                        If product.activity.sell.ordinary Then
                            AreaState.journal.currentDayCounters.dailySell += product.activity.sell.tcoQuote
                        Else
                            AreaState.journal.currentDayCounters.extraSell += product.activity.sell.tcoQuote
                        End If

                        AreaState.journal.currentDayCounters.earn += product.activity.earn
                        AreaState.journal.currentDayCounters.feePayed += product.activity.sell.feeCost

                        With AreaState.journal.currentDayCounters.addNewTransaction()
                            .amount = product.activity.sell.amount
                            .buy = False
                            .daily = product.activity.sell.ordinary
                            .dateCompletate = product.activity.sell.dateAcquire
                            .orderNumber = internalOrderId
                            .pairID = product.header.key
                            .value = product.activity.sell.tcoQuote
                        End With

                        AreaState.summary.totalFeesValue += CDec(product.activity.sell.feeCost)
                        AreaState.summary.totalVolumeValue += CDec(product.activity.sell.tcoQuote)

                        AreaState.journal.totalFee += product.activity.sell.feeCost
                        AreaState.journal.totalVolume += CDec(product.activity.sell.tcoQuote)

                        removeOrder(internalOrderId)

                        If (product.activity.openBuy.internalOrderId.Length > 0) Then
                            removeOrder(product.activity.openBuy.internalOrderId)
                        End If

                        AreaState.addIntoAccount(product.pairID, product.activity.sell.tcoQuote, True)
                        AreaState.addIntoAccount(product.pairID, (-1) * product.activity.sell.amount, False)

                        AreaState.summary.increaseValue += product.activity.earn
                        AreaState.journal.increaseValue += product.activity.earn

                        product.activity.sell.tcoQuote += product.activity.sell.feeCost

                        product.resetData()

                        AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                        Return False
                    End If

                End If

                Return True
            Catch ex As Exception
                MessageBox.Show("An error occurrent during manageOrderProduct - " & ex.Message)

                Return False
            End Try
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