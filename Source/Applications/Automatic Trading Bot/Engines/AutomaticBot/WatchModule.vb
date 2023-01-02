Option Compare Text
Option Explicit On






Namespace AreaCommon.Engines.Watch

    Module WatchModule

        Private Property _CurrentFundFree As Double = 0

        Public Property orders As New InternalList
        Public Property trades As New InternalList

        Public Property inWorkJob As Boolean = False
        Public Property stopRestockForFund As Boolean = False
        Public Property currentActivityWorkTrade As String = ""



        Private Function updateCounterInformation(ByRef product As AreaCommon.Models.Products.ProductModel, ByRef orderData As Models.Products.ProductOrderModel, Optional ByRef sideBuy As Boolean = False) As Boolean
            AreaState.journal.currentBlockCounters.feePayed += orderData.feeCost
            AreaState.journal.currentBlockCounters.volumes += CDec(orderData.tcoQuote)

            AreaState.summary.totalFeesValue += CDec(product.activity.sell.feeCost)
            AreaState.summary.totalVolumeValue += CDec(product.activity.sell.tcoQuote)

            If Not sideBuy Then
                AreaState.journal.currentBlockCounters.increase += product.activity.earn
                AreaState.summary.increaseValue += product.activity.earn
            End If

            With AreaState.journal.currentBlockCounters.addNewTransaction()
                .amount = orderData.amount
                .buy = sideBuy
                .daily = (Bots.currentPhase = Bots.AutomaticBotModule.WorkerPhaseEnum.buyTime)
                .dateCompletate = orderData.dateAcquire
                .orderNumber = orderData.id
                .pairID = product.header.key
                .value = orderData.tcoQuote
            End With

            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return True
        End Function

        Private Function decodeExchangeOrder(ByVal exchangeOrder As Coinbase.Pro.Models.Order) As String
            Dim response As String = ""

            Try
                If Not IsNothing(exchangeOrder.Id) Then response += $" id = {exchangeOrder.Id}"
                If Not IsNothing(exchangeOrder.CreatedAt) Then response += $" createdAt = {exchangeOrder.CreatedAt.ToString()}"
                If Not IsNothing(exchangeOrder.DoneAt) Then response += $" doneAt = {exchangeOrder.DoneAt.ToString}"
                If Not IsNothing(exchangeOrder.DoneReason) Then response += $" doneReason = {exchangeOrder.DoneReason}"
                If Not IsNothing(exchangeOrder.ExecutedValue) Then response += $" executedValue = {exchangeOrder.ExecutedValue.ToString()}"
                If Not IsNothing(exchangeOrder.FilledSize) Then response += $" filledSize = {exchangeOrder.FilledSize.ToString()}"
                If Not IsNothing(exchangeOrder.FillFees) Then response += $" fillFees = {exchangeOrder.FillFees.ToString()}"
                If Not IsNothing(exchangeOrder.Funds) Then response += $" funds = {exchangeOrder.Funds.ToString()}"
                If Not IsNothing(exchangeOrder.PostOnly) Then response += $" postOnly = {exchangeOrder.PostOnly}"
                If Not IsNothing(exchangeOrder.Price) Then response += $" price = {exchangeOrder.Price.ToString()}"
                If Not IsNothing(exchangeOrder.ProductId) Then response += $" productId = {exchangeOrder.ProductId}"
                If Not IsNothing(exchangeOrder.Settled) Then response += $" seattled = {exchangeOrder.Settled}"
                If Not IsNothing(exchangeOrder.Size) Then response += $" size = {exchangeOrder.Size.ToString()}"
                If Not IsNothing(exchangeOrder.SpecifiedFunds) Then response += $" specifiedFunds = {exchangeOrder.SpecifiedFunds.ToString()}"
                If Not IsNothing(exchangeOrder.Status) Then response += $" status = {exchangeOrder.Status}"
                If Not IsNothing(exchangeOrder.TimeInForce) Then response += $" timeInForce = {exchangeOrder.TimeInForce}"
                If Not IsNothing(exchangeOrder.Type) Then response += $" type = {exchangeOrder.Type}"
                If Not IsNothing(exchangeOrder.Stp) Then response += $" stp = {exchangeOrder.Stp}"

                Return response
            Catch ex As Exception
                addLogOperation($"Watch.decodeExchangeOrder - In error {ex.Message}")

                Return response
            End Try
        End Function

        Private Function cancelOpenOrder(ByVal id As String, ByVal noCancel As Boolean, ByVal forSell As Boolean) As Boolean
            addLogOperation($"Watch.cancelOpenOrder - {id}")

            Try
                Dim product As Models.Products.ProductModel
                Dim exchangeOrder As Coinbase.Pro.Models.Order

                If Not noCancel Then
                    AreaState.exchangeProxy.cancelOrderProduct(id)

                    Threading.Thread.Sleep(2000)
                End If

                For i As Integer = 0 To orders.count - 1
                    product = orders.getData(i)

                    If (product.activity.openBuy.id.CompareTo(id) = 0) Then

                        If Not noCancel Then
                            exchangeOrder = AreaState.exchangeProxy.getProductOrder(product.pairID, id)

                            Try
                                If Not IsNothing(exchangeOrder.Id) Then
                                    If (exchangeOrder.Id.Length <> 0) Then
                                        addLogOperation($"Watch.cancelOpenOrder - position order {exchangeOrder.Id} {exchangeOrder.Status} exchangeOrder {decodeExchangeOrder(exchangeOrder)}")

                                        If (exchangeOrder.Status.ToUpper.CompareTo("done".ToUpper) = 0) Or (exchangeOrder.Status.ToUpper.CompareTo("open".ToUpper) = 0) Then
                                            Return False
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        End If

                        orders.remove(product, "Orders")

                        product.activity.openBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.undefined

                        AreaCommon.Engines.Bots.AutomaticBotModule.lastBuy = Nothing

                        product.activity.removeOpenBuy()

                        product.activity.dateLastCheck = 0
                        product.activity.fastCheck = False

                        If (product.activity.buys.Count > 0) Then
                            trades.add(product, "Trades")

                            product.switchTarget(, True)
                        End If

                        Return True
                    ElseIf (product.activity.sell.id.CompareTo(id) = 0) Then
                        If Not noCancel Then
                            exchangeOrder = AreaState.exchangeProxy.getProductOrder(product.pairID, id)

                            Try
                                If Not IsNothing(exchangeOrder.Id) Then
                                    If (exchangeOrder.Id.Length <> 0) Then
                                        addLogOperation($"Watch.cancelOpenOrder - position order {exchangeOrder.Id} {exchangeOrder.Status} exchangeOrder {decodeExchangeOrder(exchangeOrder)}")

                                        If (exchangeOrder.Status.ToUpper.CompareTo("done".ToUpper) = 0) Or (exchangeOrder.Status.ToUpper.CompareTo("open".ToUpper) = 0) Then
                                            Return False
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        End If

                        orders.remove(product, "Orders")

                        If forSell Then
                            updateCounterInformation(product, product.activity.sell)
                        End If

                        product.activity.sell.state = Models.Bot.BotOrderModel.OrderStateEnumeration.undefined

                        product.activity.sell = New Models.Products.ProductOrderModel

                        product.activity.dateLastCheck = 0
                        product.activity.fastCheck = False

                        If forSell Then
                            product.resetData()
                        Else
                            trades.add(product, "Trades")

                            product.switchTarget(, True)
                        End If

                        Return True
                    End If
                Next

                Threading.Thread.Sleep(2000)

                Return False
            Catch ex As Exception
                Return False
            Finally
                addLogOperation($"Watch.cancelOpenOrder - complete")
            End Try
        End Function

        Public Function checkPreviousBuy(ByRef buyInSent As Models.Products.ProductOrderModel) As Boolean
            addLogOperation($"Watch.checkPreviousBuy - Begin")

            Dim thisTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            If Not IsNothing(buyInSent) Then
                Dim id As String = buyInSent.id

                addLogOperation($"Watch.checkPreviousBuy - Not nothing id = {buyInSent.id} and state = {buyInSent.state} and amount = {buyInSent.amount}")

                If (id.Trim.Length <> 0) Then
                    addLogOperation($"Watch.checkPreviousBuy - Begin wait. State = {buyInSent.state}")

                    Do While (((buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed)) And ((thisTime + 300000) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()))
                        Threading.Thread.Sleep(500)
                    Loop

                    addLogOperation($"Watch.checkPreviousBuy - exit wait. State = {buyInSent.state}")

                    If Not inWorkJob Then
                        addLogOperation($"Watch.checkPreviousBuy - exit from this")

                        Return False
                    End If

                    If (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed) Then
                        addLogOperation($"Watch.checkPreviousBuy - buyInSent is not close - {id}")

                        If AreaState.exchangeProxy.getOpenOrder(id) Then
                            cancelOpenOrder(id, False, False)
                        Else
                            addLogOperation($"Watch.checkPreviousBuy - Not Open")

                            If buyInSent.id.CompareTo(id) = 0 Then
                                thisTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                                Do While (((buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed)) And ((thisTime + 2000) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()))
                                    Threading.Thread.Sleep(500)
                                Loop

                                If (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed) Then
                                    addLogOperation($"Watch.checkPreviousBuy - We have a problem")
                                Else
                                    addLogOperation($"Watch.checkPreviousBuy - Order close normally")
                                End If
                            Else
                                addLogOperation($"Watch.checkPreviousBuy - Change BuyInSent")
                            End If
                        End If

                        Return True
                    End If
                End If
            End If

            addLogOperation($"Watch.checkPreviousBuy - Complete")

            Return True
        End Function

        Public Function tryRestockAll() As Boolean
            Try
                Dim inDeal As New List(Of Models.Products.ProductModel)
                Dim inDealOrdered As New List(Of Models.Products.ProductModel)
                Dim currentMaxDeal As Models.Products.ProductModel
                Dim productName As String
                Dim index As Integer
                Dim repeat As Boolean = True

                addLogOperation("TryRestockAll - try to restock all with major deal tecnique")

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

                addLogOperation($"TryRestockAll - deal list created - inDeal.count = {inDeal.Count}")

                Try
                    Do While (inDeal.Count > 1)
                        addLogOperation($"TryRestockAll - Reoder list - enter inDeal.count = {inDeal.Count}")

                        currentMaxDeal = inDeal(0)

                        addLogOperation($"TryRestockAll - Reoder list - currentMaxDeal {currentMaxDeal.header.key}")

                        For index = 1 To inDeal.Count - 1
                            If currentMaxDeal.currentSpreadPerc < inDeal(index).currentSpreadPerc Then
                                currentMaxDeal = inDeal(index)
                            End If
                        Next

                        addLogOperation($"TryRestockAll - Reoder list - for cycle complete")

                        inDealOrdered.Add(currentMaxDeal)
                        inDeal.Remove(currentMaxDeal)

                        addLogOperation($"TryRestockAll - complete element inDealOrdered.count = {inDealOrdered.Count}")

                        Threading.Thread.Sleep(10)
                    Loop

                    If inDeal.Count > 0 Then
                        inDealOrdered.Add(inDeal(0))

                        inDeal.RemoveAt(0)
                    End If

                    addLogOperation($"TryRestockAll - deadlist complete")
                Catch ex As Exception
                    addLogOperation($"TryRestockAll - Problem during before Reoder list - " & ex.Message)
                End Try

                addLogOperation($"TryRestockAll - Reorder list count - {inDealOrdered.Count}")

                inDeal = New List(Of Models.Products.ProductModel)

                Do While (inDealOrdered.Count > 0)
                    inDeal.Add(inDealOrdered(inDealOrdered.Count - 1))

                    inDealOrdered.RemoveAt(inDealOrdered.Count - 1)
                Loop

                addLogOperation($"TryRestockAll - Change order list - {inDealOrdered.Count}")

                Try
                    Dim buyInSent As Models.Products.ProductOrderModel

                    For Each product In inDeal
                        productName = product.header.name

                        If Not checkPreviousBuy(buyInSent) Then
                            Return False
                        End If

                        buyInSent = AreaCommon.Engines.Bots.AutomaticBotModule.buyProductComplete(product)

                        If (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Then
                            Threading.Thread.Sleep(1000)
                        Else
                            Threading.Thread.Sleep(50)
                        End If
                    Next
                Catch ex As Exception
                    addLogOperation($"TryRestockAll - Problem during {productName} completeInvestProducts - " & ex.Message)
                End Try

                stopRestockForFund = False
                _CurrentFundFree = 0

                addLogOperation($"TryRestockAll - procedure complete")

                Return True
            Catch ex As Exception
                addLogOperation($"TryRestockAll - Problem - " & ex.Message)

                Return False
            End Try
        End Function

        Private Sub manageCheckOrderTradeBuy(ByRef product As AreaCommon.Models.Products.ProductModel, ByRef sideTransaction As Models.Products.ProductOrderModel)
            Dim exchangeOrder As Coinbase.Pro.Models.Order
            Dim proceed As Boolean = True

            addLogOperation($"manageCheckOrderTradeBuy - getProductOrder {product.header.key}")

            exchangeOrder = AreaState.exchangeProxy.getProductOrder(product.pairID, sideTransaction.id)

            If IsNothing(exchangeOrder.Id) Then
                addLogOperation($"manageCheckOrderTradeBuy - proceed to removeProductOrder {product.header.key}")

                cancelOpenOrder(sideTransaction.id, True, False)

                Return
            Else
                addLogOperation($"manageCheckOrderTradeBuy - orderFund {product.header.key} - orderId {exchangeOrder.Id} - status {exchangeOrder.Status} - seattled {exchangeOrder.Settled} - filledSize {exchangeOrder.FilledSize}")

                If proceed Then
                    proceed = (exchangeOrder.Status.ToUpper.CompareTo("done".ToUpper) = 0)
                End If
                If proceed Then
                    proceed = Not IsNothing(exchangeOrder.DoneReason)
                End If
                If proceed Then
                    proceed = (exchangeOrder.DoneReason.ToUpper.CompareTo("filled".ToUpper) = 0) Or ((exchangeOrder.DoneReason.ToUpper.CompareTo("canceled".ToUpper) = 0))

                    addLogOperation($"manageCheckOrderTradeBuy - orderFund {product.header.key} - orderId {exchangeOrder.Id} - status {exchangeOrder.Status} - doneReason {exchangeOrder.DoneReason}")
                End If

                If proceed Then
                    addLogOperation($"manageCheckOrderTradeBuy - removeProductOrder {product.header.key} - orderId - {exchangeOrder.Id}")

                    sideTransaction.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                    sideTransaction.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(exchangeOrder.DoneAt.Value.UtcDateTime)
                    sideTransaction.amount = exchangeOrder.FilledSize
                    sideTransaction.feeCost = exchangeOrder.FillFees
                    sideTransaction.tcoQuote = (exchangeOrder.Price * sideTransaction.amount)

                    addLogOperation($"manageCheckOrderTradeBuy - before switchTarget")

                    updateCounterInformation(product, sideTransaction, True)

                    orders.remove(product, "Orders")

                    AreaCommon.Engines.Bots.AutomaticBotModule.lastBuy = Nothing

                    product.switchTarget(, True)

                    trades.add(product, "Trades")

                    product.activity.fastCheck = False

                    product.activity.dateLastCheck = 0

                    addLogOperation($"manageCheckOrderTradeBuy - reset dateLastCheck {product.header.key} - orderId - {exchangeOrder.Id}")

                    Return
                Else
                    If Not product.activity.fastCheck Then
                        addLogOperation($"manageCheckOrderTradeBuy - after fastCheck {product.header.key} - orderId - {exchangeOrder.Id} try remove order")

                        If AreaState.exchangeProxy.getOpenOrder(sideTransaction.id) Then
                            cancelOpenOrder(sideTransaction.id, False, False)
                        Else
                            addLogOperation($"manageCheckOrderTradeBuy - after fastCheck {product.header.key} - orderId - {exchangeOrder.Id} in work")
                        End If
                    Else
                        addLogOperation($"manageCheckOrderTradeBuy - fastCheck {product.header.key} - orderId - {exchangeOrder.Id}")

                        product.activity.fastCheck = False
                    End If

                    Return
                End If
            End If
        End Sub

        Private Sub manageCheckOrderTradeSell(ByRef product As AreaCommon.Models.Products.ProductModel, ByRef sideTransaction As Models.Products.ProductOrderModel)
            Dim exchangeOrder As Coinbase.Pro.Models.Order
            Dim proceed As Boolean = True

            addLogOperation($"manageCheckOrderTradeSell - getProductOrder {product.header.key}")

            exchangeOrder = AreaState.exchangeProxy.getProductOrder(product.pairID, sideTransaction.id)

            If IsNothing(exchangeOrder.Id) Then
                addLogOperation($"manageCheckOrderTradeSell - proceed to removeProductOrder {product.header.key}")

                cancelOpenOrder(exchangeOrder.Id, True, False)

                Return
            Else
                addLogOperation($"manageCheckOrderTradeSell - orderFund {product.header.key} - orderId {exchangeOrder.Id} - status {exchangeOrder.Status}")

                If proceed Then
                    proceed = (exchangeOrder.Status.ToUpper.CompareTo("done".ToUpper) = 0)
                End If
                If proceed Then
                    proceed = Not IsNothing(exchangeOrder.DoneReason)
                End If
                If proceed Then
                    proceed = (exchangeOrder.DoneReason.ToUpper.CompareTo("filled".ToUpper) = 0) Or (exchangeOrder.DoneReason.ToUpper.CompareTo("canceled".ToUpper) = 0)

                    addLogOperation($"manageCheckOrderTradeSell - orderFund {product.header.key} - orderId {exchangeOrder.Id} - status DONE - doneReason {exchangeOrder.DoneReason}")
                Else
                    If sideTransaction.cancelSellIfSlow Then
                        If AreaState.exchangeProxy.getOpenOrder(sideTransaction.id) Then
                            addLogOperation($"manageCheckOrderTradeSell - Ordercanceled {product.header.key}")

                            cancelOpenOrder(sideTransaction.id, False, False)
                        Else
                            addLogOperation($"manageCheckOrderTradeSell - Order not open not canceled {product.header.key}")
                        End If

                        Return
                    End If
                End If

                If proceed Then
                    addLogOperation($"manageCheckOrderTradeSell - removeProductOrder {product.header.key}")

                    sideTransaction.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled

                    sideTransaction.dateAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(exchangeOrder.DoneAt.Value.UtcDateTime)
                    sideTransaction.amount = exchangeOrder.FilledSize
                    sideTransaction.feeCost = exchangeOrder.FillFees
                    sideTransaction.tcoQuote = (exchangeOrder.Price * sideTransaction.amount)

                    cancelOpenOrder(sideTransaction.id, True, True)
                End If

                Return
            End If
        End Sub

        Public Function checkOrderTrade(ByRef product As AreaCommon.Models.Products.ProductModel) As Boolean
            Dim managePosition As Boolean = False
            Dim transaction As Models.Products.ProductOrderModel
            Dim thisTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim proceed As Boolean = True

            If (product.activity.dateLastCheck = 0) Then
                product.activity.dateLastCheck = thisTime
            End If

            If proceed Then
                If product.activity.fastCheck Then
                    proceed = (thisTime > product.activity.dateLastCheck + 7000)
                Else
                    proceed = (thisTime > product.activity.dateLastCheck + 60000)
                End If
            End If
            If proceed Then
                product.activity.dateLastCheck = thisTime

                addLogOperation($"checkOrderTrade - {product.header.key} in fastCheck {product.activity.fastCheck}")

                transaction = product.activity.openBuy

                addLogOperation($"checkOrderTrade - {product.header.key} transaction buy {transaction.id} ")

                If (transaction.id.Length > 0) Then
                    manageCheckOrderTradeBuy(product, transaction)
                Else
                    transaction = product.activity.sell

                    addLogOperation($"checkOrderTrade - {product.header.key} transaction sell {transaction.id} ")

                    If (transaction.id.Length > 0) Then
                        manageCheckOrderTradeSell(product, transaction)
                    End If
                End If
            End If

            Return True
        End Function

        Private Function checkTrade(ByRef product As AreaCommon.Models.Products.ProductModel) As Boolean
            Dim proceed As Boolean = True
            Dim sellTime As Boolean = False
            Dim buyTime As Boolean = False
            Dim thisTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            If (product.activity.dateLastCheck = 0) Then
                product.activity.dateLastCheck = thisTime
            End If
            If proceed Then
                proceed = (thisTime > product.activity.dateLastCheck + 60000)
            End If
            If proceed Then
                product.activity.dateLastCheck = thisTime

                sellTime = (product.currentTargetReached() And (product.activity.sell.id.Length = 0))
                buyTime = product.inDeal(AreaState.automaticBot.settings.dealAcquireOnPercentage) And Not stopRestockForFund
            End If
            If sellTime Then
                Dim orderValue As Double = 0

                addLogOperation($"Watch.checkTrade - {product.header.key} - sellTime")

                orderValue = product.currentTarget

                trades.remove(product, "Trades")

                With product.activity.sell
                    If (orderValue > 0) Then
                        addLogOperation($"Watch.checkTrade - {product.header.key} with orderValue={orderValue}")

                        .dateAcquire = 0

                        .amount = roundBase(product.activity.totalAmount, product.header.baseIncrement, True)
                        .maxPrice = roundBase(product.activity.target / product.activity.totalAmount, product.header.quoteIncrement, True)
                        .tcoQuote = roundBase(product.activity.target, product.header.quoteIncrement, True)
                        .state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented

                        Engines.Orders.placeOrder(product, product.activity.sell, False)

                        addLogOperation($"Watch.checkTrade - {product.header.key} order placed")
                    End If
                End With

                Return False
            End If
            If buyTime Then
                addLogOperation($"Watch.checkTrade - {product.header.key} - buyTime")

                If proceed Then
                    proceed = (product.activity.openBuy.id.Length = 0)
                End If
                If proceed Then
                    proceed = (thisTime > product.activity.lastBuy.dateAcquire + (AreaState.automaticBot.settings.dealIntervalMinute * 60000))
                End If
                If proceed Then
                    addLogOperation("Watch.checkTrade - The product is in deal " & product.header.name & " not order pending. I can restock")

                    If (AreaState.automaticBot.settings.plafondOperation = 0) Then
                        proceed = True
                    Else
                        proceed = (AreaState.automaticBot.settings.plafondOperation > product.activity.totalInvestment)
                    End If
                End If
                If proceed Then
                    addLogOperation("Watch.checkTrade - Try to buy. Good Plafond")

                    If Not checkPreviousBuy(AreaCommon.Engines.Bots.AutomaticBotModule.lastBuy) Then
                        Return False
                    End If

                    AreaCommon.Engines.Bots.AutomaticBotModule.buyProduct(product)

                    addLogOperation($"Watch.checkTrade - buyProduct created {Not IsNothing(AreaCommon.Engines.Bots.AutomaticBotModule.lastBuy)}")

                    If (AreaCommon.Engines.Bots.AutomaticBotModule.lastBuy.id.Length = 0) Then
                        addLogOperation($"Watch.checkTrade -   not good!")

                        If (AreaCommon.Engines.Bots.AutomaticBotModule.lastBuy.amount = 0) Then
                            addLogOperation($"Watch.checkTrade -  amount = 0")

                            stopRestockForFund = True
                            _CurrentFundFree = AreaState.accounts("USDT".ToLower()).valueUSDT

                            addLogOperation($"Watch.checkTrade - StockRestockForFund  currentFundFree = {_CurrentFundFree}")
                        End If
                    Else
                        addLogOperation("     order buy placed")
                    End If
                End If
            End If

            Return True
        End Function

        Private Function checkRestockAll() As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                proceed = stopRestockForFund
            End If
            If proceed Then
                proceed = (AreaState.accounts("USDT".ToLower).valueUSDT > _CurrentFundFree)
            End If
            If proceed Then
                proceed = (AreaCommon.Engines.Bots.currentPhase = Bots.AutomaticBotModule.WorkerPhaseEnum.workTime)

                addLogOperation($"Watch.checkRestockAll - currentPhase = {AreaCommon.Engines.Bots.currentPhase}")
            End If
            If proceed Then
                addLogOperation($"Watch.checkRestockAll - proceed = true")
            End If

            Return proceed
        End Function

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceOrderWatch()
            Try
                Dim currentIndexOrder As Integer = 0
                Dim currentIndexTrade As Integer = 0

                addLogOperation($"Watch.startServiceOrderWatch")

                Do While inWorkJob
                    Try
                        Do While inWorkJob
                            currentActivityWorkTrade = $"Before order activity {orders.count}"

                            If (orders.count > 0) Then
                                If (currentIndexOrder + 1 > orders.count) Then
                                    currentIndexOrder = 0
                                End If

                                If checkOrderTrade(orders.getData(currentIndexOrder)) Then
                                    currentIndexOrder += 1
                                End If
                            Else
                                currentIndexOrder = 0
                            End If

                            Threading.Thread.Sleep(25)
                        Loop
                    Catch ex As Exception
                    End Try
                Loop

                currentActivityWorkTrade = $"Exit watch procedure" : addLogOperation(currentActivityWorkTrade)
            Catch ex As Exception
                inWorkJob = False

                currentActivityWorkTrade = $"In error"

                MessageBox.Show("An error occurrent during startServiceOrderWatch - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceTradeWatch()
            Try
                Dim currentIndexOrder As Integer = 0
                Dim currentIndexTrade As Integer = 0

                addLogOperation($"Watch.startServiceTradeWatch")

                Do While inWorkJob
                    Try
                        Do While inWorkJob
                            currentActivityWorkTrade = $"Before trade activity {trades.count}"

                            If (trades.count > 0) Then
                                If (currentIndexTrade + 1 > trades.count) Then
                                    currentIndexTrade = 0
                                End If

                                If checkTrade(trades.getData(currentIndexTrade)) Then
                                    currentIndexTrade += 1
                                End If
                            Else
                                currentIndexTrade = 0
                            End If

                            Threading.Thread.Sleep(25)
                        Loop
                    Catch ex As Exception
                    End Try
                Loop

                currentActivityWorkTrade = $"Exit watch procedure" : addLogOperation(currentActivityWorkTrade)
            Catch ex As Exception
                inWorkJob = False

                currentActivityWorkTrade = $"In error"

                MessageBox.Show("An error occurrent during startServiceTradeWatch - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceTryRestockAll()
            Try
                Dim currentIndexOrder As Integer = 0
                Dim currentIndexTrade As Integer = 0

                addLogOperation($"Watch.startServiceTryRestockAll")

                Do While inWorkJob
                    Try
                        Do While inWorkJob
                            currentActivityWorkTrade = $"checkRestockAll"

                            If checkRestockAll() Then
                                addLogOperation($"checkRestockAll stopRestockForFund = {stopRestockForFund} USDT={AreaState.accounts("USDT".ToLower).valueUSDT} CurrentFundFree = {_CurrentFundFree}")

                                tryRestockAll()
                            End If

                            Threading.Thread.Sleep(100)
                        Loop
                    Catch ex As Exception
                    End Try
                Loop

                currentActivityWorkTrade = $"Exit watch procedure" : addLogOperation(currentActivityWorkTrade)
            Catch ex As Exception
                inWorkJob = False

                currentActivityWorkTrade = $"In error"

                MessageBox.Show("An error occurrent during startServiceTryRestockAll - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start a pair job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not inWorkJob And AreaState.automaticBot.isActive Then
                inWorkJob = True

                Dim objWS As Threading.Thread

                objWS = New Threading.Thread(AddressOf startServiceOrderWatch)

                objWS.Start()

                objWS = New Threading.Thread(AddressOf startServiceTradeWatch)

                objWS.Start()

                objWS = New Threading.Thread(AddressOf startServiceTryRestockAll)

                objWS.Start()
            End If

            Return True
        End Function

        Public Function [stop]() As Boolean
            inWorkJob = False

            Return True
        End Function

        Public Function clear() As Boolean
            orders = New InternalList
            trades = New InternalList

            Return True
        End Function

    End Module

End Namespace
