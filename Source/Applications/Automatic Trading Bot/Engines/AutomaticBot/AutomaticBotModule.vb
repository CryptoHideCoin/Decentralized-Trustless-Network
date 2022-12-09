Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines.Bots

    Module AutomaticBotModule

        Public Enum WorkerPhaseEnum
            undefined
            tryReconciliation
            openNewBlock
            buyTime
            workTime
        End Enum

        Private Property _InWorkJob As Boolean = False
        Private Property _StartBlockWork As Double = 0
        Private Property _BlockWork As New BlockStartEngine
        Private Property _AcquireWork As New AcquireEngine
        Private Property _lastInternalWork As Double = 0
        Private Property _lastBuy As Models.Products.ProductOrderModel

        Private Property _StopRestockForFund As Boolean = False
        Private Property _CurrentFundFree As Double = 0
        Private Property _InReconciliation As Boolean = False

        Public Property currentPhase As WorkerPhaseEnum = WorkerPhaseEnum.undefined



        Private Function checkAndRestockIt(ByRef product As Models.Products.ProductModel) As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                proceed = product.inDeal(AreaState.automaticBot.settings.dealAcquireOnPercentage)
            End If
            If proceed Then
                addLogOperation("Il prodotto è in deal " & product.header.name)

                proceed = (product.activity.openBuy.id.Length = 0)
            End If
            If proceed Then
                addLogOperation("Non c'è nessun ordine di acquisto pendente")

                proceed = (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime > product.activity.lastBuy.dateAcquire + (AreaState.automaticBot.settings.dealIntervalMinute * 60000))
            End If
            If proceed Then
                addLogOperation("Posso riassortire in quanto è passato tempo")

                If (AreaState.automaticBot.settings.plafondOperation = 0) Then
                    proceed = True
                Else
                    proceed = (product.activity.totalInvestment < AreaState.automaticBot.settings.plafondOperation)
                End If
            End If
            If proceed Then
                addLogOperation("Provo a riassortire perché ci siamo anche come plafond")

                If Not IsNothing(_lastBuy) Then
                    Do While (_lastBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (_lastBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed)
                        Threading.Thread.Sleep(500)
                    Loop
                End If

                _lastBuy = _AcquireWork.buyProduct(product)

                If (_lastBuy.id.Length = 0) Then
                    If (_lastBuy.amount = 0) Then
                        _StopRestockForFund = True

                        _CurrentFundFree = AreaState.accounts("USDT").valueUSDT
                    End If
                End If

                addLogOperation("Speriamo che l'acquisto vada in porto")
            End If

            Return True
        End Function

        Private Function tryRestockAll() As Boolean
            Dim inDeal As New List(Of Models.Products.ProductModel)
            Dim inDealOrdered As New List(Of Models.Products.ProductModel)
            Dim currentMaxDeal As Models.Products.ProductModel
            Dim productName As String
            Dim index As Integer
            Dim repeat As Boolean = True

            addLogOperation("Provo a comprare basandomi sulla situazione di maggiore sofferenza")

            Do While repeat

                repeat = False

                Try
                    For Each product In AreaState.products.items
                        If product.activity.inUse Then
                            If product.inDeal(AreaState.automaticBot.settings.dealAcquireOnPercentage) Then
                                inDeal.Add(product)
                            End If
                        End If
                    Next
                Catch ex As Exception
                    inDeal = New List(Of Models.Products.ProductModel)

                    repeat = True
                End Try

                Threading.Thread.Sleep(10)
            Loop

            addLogOperation("Ho effettuato la lista dei prodotti in sofferenza")

            Do While (inDeal.Count > 1)
                currentMaxDeal = inDeal(index)

                For index = 1 To inDeal.Count - 1
                    If currentMaxDeal.currentSpreadPerc < inDeal(index).currentSpreadPerc Then
                        currentMaxDeal = inDeal(index)
                    End If
                Next

                inDealOrdered.Add(currentMaxDeal)
                inDeal.Remove(currentMaxDeal)

                Threading.Thread.Sleep(10)
            Loop

            If inDeal.Count > 0 Then
                inDealOrdered.Add(inDeal(0))

                inDeal.RemoveAt(0)
            End If

            addLogOperation("Ho riordinato la lista")

            Try
                Dim buyInSent As Models.Products.ProductOrderModel

                For Each product In inDealOrdered
                    productName = product.header.name

                    If Not IsNothing(buyInSent) Then
                        If (buyInSent.id.Length = 0) Then
                            Threading.Thread.Sleep(10)
                        End If

                        If (buyInSent.id.Length <> 0) Then
                            Do While (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed)
                                Threading.Thread.Sleep(500)
                            Loop
                        End If
                    End If

                    addLogOperation("Provo a ricomprare " & product.header.name)

                    buyInSent = _AcquireWork.buyProduct(product)

                    If (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Then
                        Threading.Thread.Sleep(1000)
                    Else
                        Threading.Thread.Sleep(50)
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show($"Problem during {productName} completeInvestProducts - " & ex.Message)
            End Try

            _StopRestockForFund = False
            _CurrentFundFree = 0

            Return True
        End Function

        Private Function checkProductInformation() As Boolean
            Dim currentTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            If (_lastInternalWork = 0) Then
                _lastInternalWork = currentTime
            ElseIf (_lastInternalWork + 60000 > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                _lastInternalWork = currentTime
            Else
                Return False
            End If

            For Each product In AreaState.products.items
                If product.activity.inUse Then
                    If (product.value.current > product.value.maxValue) Then
                        product.value.maxValue = product.value.current
                        product.value.automaticMaxValue = True
                        product.value.dateMax = currentTime
                    End If

                    If (product.value.dateMax < currentTime - (CLng(1000) * 60 * 60 * 24 * 365 * 2)) Then
                        product.value.automaticMaxValue = False
                        AreaState.journal.alert = $"The Date max value of a product {product.header.key} is out a date"
                    End If

                    If (product.value.dateLast < currentTime - (CLng(1000) * 60 * 60 * 24 * 365 * 2)) Then
                        product.value.automaticMinValue = False
                        AreaState.journal.alert = $"The Date min value of a product {product.header.key} is out a date"
                    End If

                    If (product.value.current < product.value.minValue) And (product.value.current > 0) Then
                        product.value.minValue = product.value.current
                        product.value.automaticMinValue = True
                        product.value.dateLast = currentTime
                    End If

                    Threading.Thread.Sleep(50)

                    If Not _StopRestockForFund Then
                        checkAndRestockIt(product)
                    End If
                End If
            Next

            If _StopRestockForFund And (_CurrentFundFree < AreaState.accounts("USDT".ToLower).valueUSDT) Then
                tryRestockAll()
            End If

            Return True
        End Function

        Private Function tryReconciliation() As Boolean
            addLogOperation("Provo ad effettuare la riconciliazione")

            For Each product In AreaState.products.items
                If product.activity.inUse Then
                    _InReconciliation = True

                    If AreaState.accounts.ContainsKey(product.pairID.ToLower()) Then
                        If (product.activity.openBuy.id.Length > 0) Then
                            product.activity.fastCheck = False

                            addLogOperation("tryReconciliation - addWatchOrder " & product.pairID)

                            Watch.cancelOrderProduct(product.activity.openBuy.id)
                        Else
                            If (product.activity.sell.id.Length > 0) Then
                                addLogOperation("tryReconciliation - remove " & product.pairID & "  Order = " & product.activity.sell.id)

                                Watch.cancelOrderProduct(product.activity.sell.id)

                                product.activity.sell = New Models.Products.ProductOrderModel
                            End If

                            Watch.addProductTrade(product)
                        End If
                    Else
                        addLogOperation("tryReconciliation - resetData " & product.pairID)

                        product.resetData()
                    End If
                End If

                Threading.Thread.Sleep(50)
            Next

            Return tryRestockAll()
        End Function

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceBot()
            Try
                addLogOperation("Enter into startServiceBot")

                With AreaState.journal
                    If (.startBlock = 0) Then
                        .startBlock = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
                        .initialFund = AreaState.accounts("USDT".ToLower()).valueUSDT
                        .lastUpdate = .startBlock
                    End If
                End With

                tryReconciliation()

                Do While _InWorkJob
                    _StartBlockWork = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                    If Not _InReconciliation Then
                        currentPhase = WorkerPhaseEnum.openNewBlock : _BlockWork.run()
                    End If
                    If Not _InReconciliation Then
                        currentPhase = WorkerPhaseEnum.buyTime : _AcquireWork.run()
                    End If

                    _InReconciliation = False : currentPhase = WorkerPhaseEnum.workTime

                    changeInBlockInNormalSell()

                    addLogOperation("AutomaticBot - In worktime")

                    Do While ((_StartBlockWork + (24 * 60 * 60000)) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) And _InWorkJob
                        'Do While ((_StartBlockWork + (15 * 60000)) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) And _InWorkJob
                        Threading.Thread.Sleep(100)

                        checkProductInformation()
                    Loop
                Loop
            Catch ex As Exception
                _InWorkJob = False
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start a Automatic bot job
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

        ''' <summary>
        ''' This method provide to stop the Automatic bot job
        ''' </summary>
        ''' <returns></returns>
        Public Function [stop]() As Boolean
            _InWorkJob = False

            Return True
        End Function

        ''' <summary>
        ''' This method provide to update journal counter
        ''' </summary>
        ''' <returns></returns>
        Public Function updateJournalCounter() As Boolean
            Return _BlockWork.updateJournalCounter()
        End Function

        Public Function changeInBlockSell() As Boolean
            If _AcquireWork.changeInBlockSell() Then

                If _AcquireWork.inTargetMode Then
                    Threading.Thread.Sleep(1000)
                End If

                Return True
            Else
                Return False
            End If
        End Function

        Public Function changeInBlockInNormalSell() As Boolean
            If _AcquireWork.inTargetMode Then
                Return _AcquireWork.changeInBlockSell(True)
            Else
                Return False
            End If
        End Function









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

        Private Function quoteReservation(ByVal value As Double) As Double
            Dim singleQuote As Double = (AreaState.gainFund.targetLockedFund - AreaState.gainFund.currentLockedFund)
            Dim used As Double = 0

            If (singleQuote > value) Then
                used = value
            Else
                used = singleQuote
            End If

            AreaState.journal.currentBlockCounters.lockedFund += used
            AreaState.journal.lockedFund += used
            AreaState.gainFund.currentLockedFund += used

            Return used
        End Function

        Private Sub manageQuoteReservation(ByVal quoteValue As Double)
            If (AreaState.gainFund.nextTargetDay < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                AreaState.gainFund.nextTargetDay = nextTargetDay()
            End If

            Dim dayRemain As Integer = DateDiff("d", Now.ToUniversalTime, CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(AreaState.gainFund.nextTargetDay).ToUniversalTime)
            Dim singleQuote As Double = (AreaState.gainFund.targetLockedFund - AreaState.gainFund.currentLockedFund) / dayRemain
            Dim dayQuoteRemain As Double = singleQuote - AreaState.journal.currentBlockCounters.lockedFund
            Dim quoteLock As Double = 0

            If (dayQuoteRemain > 0) Then
                If (quoteValue > dayQuoteRemain) Then
                    quoteLock = dayQuoteRemain
                Else
                    quoteLock = quoteValue
                End If
            End If

            AreaState.journal.currentBlockCounters.lockedFund += quoteLock
            AreaState.journal.lockedFund += quoteLock
            AreaState.gainFund.currentLockedFund += quoteLock
        End Sub

        Private Function nextTargetDay() As Double
            Dim dateDay As DateTime

            dateDay = DateAdd("M", 1, CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(AreaState.gainFund.nextTargetDay).ToUniversalTime)

            Return CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(dateDay)
        End Function

        Private Function manageFundReservation(ByVal pairID As String, ByVal totalInvestment As Double, ByVal tcoQuote As Double) As Boolean
            Try
                If (AreaState.gainFund.currentLockedFund < AreaState.gainFund.targetLockedFund) Then
                    Select Case AreaState.gainFund.mode
                        Case Models.Journal.FundReservationModel.ModeReservationEnumeration.urgent : quoteReservation(tcoQuote)
                        Case Models.Journal.FundReservationModel.ModeReservationEnumeration.immediate : quoteReservation(tcoQuote - totalInvestment)
                        Case Models.Journal.FundReservationModel.ModeReservationEnumeration.booking : manageQuoteReservation(tcoQuote - totalInvestment)
                    End Select
                End If

                If (AreaState.gainFund.currentLockedFund >= AreaState.gainFund.targetLockedFund) And (AreaState.gainFund.currentLockedFund + AreaState.gainFund.targetLockedFund <> 0) Then
                    AreaState.addIntoAccount("USDT", (-1) * AreaState.gainFund.currentLockedFund, False)
                    AreaState.addIntoAccount(AreaState.gainFund.targetCurrency, AreaState.gainFund.currentLockedFund, False)

                    AreaState.gainFund.currentLockedFund = 0
                    AreaState.journal.lockedFund = 0
                    AreaState.journal.currentBlockCounters.lockedFund = 0

                    If (AreaState.gainFund.mode = Models.Journal.FundReservationModel.ModeReservationEnumeration.urgent) Or
                   (AreaState.gainFund.mode = Models.Journal.FundReservationModel.ModeReservationEnumeration.immediate) Then

                        AreaState.gainFund.targetLockedFund = 0

                    End If

                End If

                Return True
            Catch ex As Exception
                MessageBox.Show("An error occurrent during manageFundReservation - " & ex.Message)

                Return False
            End Try
        End Function

        Private Function fundAvailable() As Double
            If AreaState.gainFund.currentLockedFund > 0 Then
                Return AreaState.accounts("USDT".ToLower()).available - AreaState.gainFund.currentLockedFund
            Else
                Return AreaState.accounts("USDT".ToLower()).available
            End If
        End Function

        Public Function manageOrderProductVirtual(ByVal productId As String, ByVal internalOrderId As String) As Boolean
            Try
                Dim product = AreaState.products.getCurrency(productId)
                Dim repeat As Boolean = True

                Do While repeat
                    repeat = False

                    Try
                        For Each buy In product.activity.buys
                            If (buy.id.CompareTo(internalOrderId) = 0) Then

                                If (buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed) Then
                                    If (fundAvailable() < (product.value.current * buy.amount + calculateFeeCost(product.value.current * buy.amount))) Then
                                        Return True
                                    End If

                                    If (product.value.current > 0) And (product.value.current * buy.amount <= buy.tcoQuote) Then
                                        buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                                        buy.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                                        buy.tcoQuote = product.value.current * buy.amount
                                        buy.feeCost = calculateFeeCost(buy.tcoQuote)

                                        AreaState.summary.totalFeesValue += CDec(buy.feeCost)
                                        AreaState.summary.totalVolumeValue += CDec(buy.tcoQuote)

                                        AreaState.journal.currentBlockCounters.feePayed += buy.feeCost
                                        AreaState.journal.currentBlockCounters.volumes += CDec(buy.tcoQuote)

                                        AreaState.journal.totalFee += buy.feeCost
                                        AreaState.journal.totalVolume += CDec(buy.tcoQuote)

                                        If (AreaState.automaticBot.workAction <> Models.Bot.BotAutomatic.WorkStateEnumeration.undefined) Then
                                            AreaState.journal.currentBlockCounters.dailyBuy += CDec(buy.tcoQuote)
                                        Else
                                            AreaState.journal.currentBlockCounters.extraBuy += CDec(buy.tcoQuote)
                                        End If

                                        With AreaState.journal.currentBlockCounters.addNewTransaction()
                                            .amount = buy.amount
                                            .buy = True
                                            .daily = (AreaState.automaticBot.workAction <> Models.Bot.BotAutomatic.WorkStateEnumeration.undefined)
                                            .dateCompletate = buy.dateAcquire
                                            .orderNumber = internalOrderId
                                            .pairID = product.header.key
                                            .value = buy.tcoQuote
                                        End With

                                        buy.tcoQuote += buy.feeCost

                                        'product.minTarget = product.activity.totalInvestment + (product.activity.totalInvestment * AreaState.automaticBot.settings.minDailyEarn / 100)

                                        'removeOrder(internalOrderId, buy.orderNumber)

                                        AreaState.addIntoAccount(product.pairID, (-1) * buy.tcoQuote, True)
                                        AreaState.addIntoAccount(product.pairID, buy.amount, False)

                                        If (AreaState.automaticBot.settings.dealIntervalMinute = 0) Then
                                            If (AreaState.automaticBot.settings.plafondOperation = 0) Then
                                                'createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, 0)
                                            Else
                                                If (product.activity.totalInvestment < AreaState.automaticBot.settings.plafondOperation) Then
                                                    'createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, 0)
                                                End If
                                            End If
                                        End If

                                        'If (product.activity.sell.internalOrderId.Length > 0) Then
                                        'removeOrder(product.activity.sell.internalOrderId, product.activity.sell.orderNumber)
                                        'End If

                                        'createNewOrder(product, AreaState.automaticBot.settings.maxDailyEarn, product.activity.totalAmount())

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

                'If (product.activity.sell.internalOrderId.CompareTo(internalOrderId) = 0) Then

                If (product.value.current > 0) And (product.value.current * product.activity.sell.amount >= product.activity.sell.tcoQuote) Then
                    product.activity.sell.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                    product.activity.sell.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    product.activity.sell.feeCost = calculateFeeCost(product.activity.sell.tcoQuote)

                    If (AreaState.automaticBot.workAction <> Models.Bot.BotAutomatic.WorkStateEnumeration.undefined) Then
                        AreaState.journal.currentBlockCounters.dailySell += product.activity.sell.tcoQuote
                    Else
                        AreaState.journal.currentBlockCounters.extraSell += product.activity.sell.tcoQuote
                    End If

                    AreaState.journal.currentBlockCounters.earn += product.activity.earn
                    AreaState.journal.currentBlockCounters.feePayed += product.activity.sell.feeCost

                    With AreaState.journal.currentBlockCounters.addNewTransaction()
                        .amount = product.activity.sell.amount
                        .buy = False
                        .daily = (AreaState.automaticBot.workAction <> Models.Bot.BotAutomatic.WorkStateEnumeration.undefined)
                        .dateCompletate = product.activity.sell.dateAcquire
                        .orderNumber = internalOrderId
                        .pairID = product.header.key
                        .value = product.activity.sell.tcoQuote
                    End With

                    AreaState.summary.totalFeesValue += CDec(product.activity.sell.feeCost)
                    AreaState.summary.totalVolumeValue += CDec(product.activity.sell.tcoQuote)

                    AreaState.journal.totalFee += product.activity.sell.feeCost
                    AreaState.journal.totalVolume += CDec(product.activity.sell.tcoQuote)
                    AreaState.journal.currentBlockCounters.volumes += CDec(product.activity.sell.tcoQuote)

                    'removeOrder(internalOrderId, product.activity.sell.orderNumber)

                    'If (product.activity.openBuy.internalOrderId.Length > 0) Then
                    'removeOrder(product.activity.openBuy.internalOrderId, product.activity.sell.orderNumber)
                    'End If

                    AreaState.addIntoAccount(product.pairID, product.activity.sell.tcoQuote, True)
                    AreaState.addIntoAccount(product.pairID, (-1) * product.activity.sell.amount, False)

                    manageFundReservation(product.pairID, product.activity.totalInvestment, product.activity.sell.tcoQuote)

                    AreaState.summary.increaseValue += product.activity.earn
                    AreaState.journal.totalIncrease += product.activity.earn
                    AreaState.journal.currentBlockCounters.increase += product.activity.earn

                    product.activity.sell.tcoQuote += product.activity.sell.feeCost

                    product.resetData()

                    AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                    Return False
                End If

                'End If

                Return True
            Catch ex As Exception
                MessageBox.Show("An error occurrent during manageOrderProductVirtual - " & ex.Message)

                Return False
            End Try
        End Function

        Public Function manageOrderProduct(ByVal productId As String, ByRef singleOrder As Coinbase.Pro.Models.Order, ByRef order As Models.Order.SimplyOrderModel) As Boolean
            Try
                Dim product = AreaState.products.getCurrency(order.productId)
                Dim repeat As Boolean = True

                If order.cancelProductInformation Then
                    product.resetData()
                End If

                Do While repeat
                    repeat = False

                    Try
                        For Each buy In product.activity.buys
                            'If (buy.internalOrderId.CompareTo(order.internalOrderId) = 0) Then

                            buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                            buy.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                            buy.amount = singleOrder.FilledSize
                            buy.maxPrice = singleOrder.Price
                            buy.tcoQuote = CDec(singleOrder.ExecutedValue) - singleOrder.FillFees
                            buy.feeCost = singleOrder.FillFees

                            AreaState.summary.totalFeesValue += CDec(buy.feeCost)
                            AreaState.summary.totalVolumeValue += CDec(buy.tcoQuote)

                            AreaState.journal.currentBlockCounters.feePayed += buy.feeCost
                            AreaState.journal.currentBlockCounters.volumes += CDec(buy.tcoQuote)

                            AreaState.journal.totalFee += buy.feeCost
                            AreaState.journal.totalVolume += CDec(buy.tcoQuote)

                            If (AreaState.automaticBot.workAction <> Models.Bot.BotAutomatic.WorkStateEnumeration.undefined) Then
                                AreaState.journal.currentBlockCounters.dailyBuy += CDec(buy.tcoQuote)
                            Else
                                AreaState.journal.currentBlockCounters.extraBuy += CDec(buy.tcoQuote)
                            End If

                            With AreaState.journal.currentBlockCounters.addNewTransaction()
                                .amount = buy.amount
                                .buy = True
                                .daily = (AreaState.automaticBot.workAction <> Models.Bot.BotAutomatic.WorkStateEnumeration.undefined)
                                .dateCompletate = buy.dateAcquire
                                .orderNumber = singleOrder.Id
                                .pairID = product.header.key
                                .value = buy.tcoQuote
                            End With

                            buy.tcoQuote += buy.feeCost

                            'product.minTarget = product.activity.totalInvestment + (product.activity.totalInvestment * AreaState.automaticBot.settings.minDailyEarn / 100)
                            product.activity.target = product.activity.totalInvestment + (product.activity.totalInvestment * AreaState.automaticBot.settings.maxDailyEarn / 100)

                            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                            Return False
                            'End If
                        Next
                    Catch ex As Exception
                        repeat = True
                    End Try
                Loop

                'If (product.activity.sell.internalOrderId.CompareTo(order.internalOrderId) = 0) Then
                If (product.activity.sell.amount = singleOrder.Size) Then

                    ' l'ho trovato...

                    ' ora aggiorno la posizione dell'ordine, prezzo d'acquisto e tutto il resto

                End If
                'End If

                Return True
            Catch ex As Exception
                MessageBox.Show("An error occurrent during manageOrderProduct - " & ex.Message)

                Return False
            End Try
        End Function

    End Module

End Namespace
