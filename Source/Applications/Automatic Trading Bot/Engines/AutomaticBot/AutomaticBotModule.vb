Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines.Bots

    Module AutomaticBotModule

        Public Enum WorkerPhaseEnum
            undefined
            openNewBlock
            buyTime
            workTime
        End Enum

        Private Property _InWorkJob As Boolean = False
        Private Property _StartBlockWork As Double = 0
        Private Property _BlockWork As New BlockStartEngine
        Private Property _AcquireWork As New AcquireEngine

        Public Property currentPhase As WorkerPhaseEnum = WorkerPhaseEnum.undefined

        Private Property _lastInternalWork As Double = 0




        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceBot()
            Try
                With AreaState.journal
                    If (.startBlock = 0) Then
                        .startBlock = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
                        .initialFund = AreaState.accounts("USDT".ToLower()).valueUSDT
                        .lastUpdate = .startBlock
                    End If
                End With

                Do While _InWorkJob
                    _StartBlockWork = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                    currentPhase = WorkerPhaseEnum.openNewBlock : _BlockWork.run()
                    currentPhase = WorkerPhaseEnum.buyTime : _AcquireWork.run()
                    currentPhase = WorkerPhaseEnum.workTime

                    Do While (_StartBlockWork + (24 * 60 * 60000)) And _InWorkJob
                        Threading.Thread.Sleep(100)
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
            Return _AcquireWork.changeInBlockSell()
        End Function







        Private Function checkProductInformation() As Boolean

            If (_lastInternalWork = 0) Then
                _lastInternalWork = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            ElseIf (_lastInternalWork + 60000 > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                _lastInternalWork = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Else
                Return False
            End If

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

                    If (product.activity.openBuy.id.Length = 0) Then
                        If CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime > product.activity.lastBuy.dateAcquire + (AreaState.automaticBot.settings.dealIntervalMinute * 60000) Then
                            If (AreaState.automaticBot.settings.plafondOperation = 0) Or (AreaState.automaticBot.settings.dealIntervalMinute = 0) Then
                                '                                createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, 0)
                            Else
                                If (product.activity.totalInvestment < AreaState.automaticBot.settings.plafondOperation) Then
                                    'createNewOrder(product, (-1) * AreaState.automaticBot.settings.dealAcquireOnPercentage, 0)
                                End If
                            End If
                        End If
                    End If

                End If
            Next

            Return True
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
                            'If (buy.internalOrderId.CompareTo(internalOrderId) = 0) Then
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
