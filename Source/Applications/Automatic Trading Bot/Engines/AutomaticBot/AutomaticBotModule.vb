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

        Private Property _StartBlockWork As Double = 0
        Private Property _BlockWork As New BlockStartEngine
        Private Property _AcquireWork As New AcquireEngine
        Private Property _lastInternalWork As Double = 0
        Private Property _lastBuy As Models.Products.ProductOrderModel

        Private Property _CurrentFundFree As Double = 0
        Private Property _InReconciliation As Boolean = False

        Public Property currentPhase As WorkerPhaseEnum = WorkerPhaseEnum.undefined
        Public Property inWorkJob As Boolean = False
        Public Property stopRestockForFund As Boolean = False



        Private Function checkAndRestockIt(ByRef product As Models.Products.ProductModel) As Boolean
            Dim proceed As Boolean = True

            Try
                If proceed Then
                    proceed = ((product.activity.dateLastCheck + 60000) < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime)
                End If
                If proceed Then
                    product.activity.dateLastCheck = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime

                    proceed = product.inDeal(AreaState.automaticBot.settings.dealAcquireOnPercentage)
                End If
                If proceed Then
                    proceed = (product.activity.openBuy.id.Length = 0)
                End If
                If proceed Then
                    proceed = (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime > product.activity.lastBuy.dateAcquire + (AreaState.automaticBot.settings.dealIntervalMinute * 60000))
                End If
                If proceed Then
                    addLogOperation("Il prodotto is in deal " & product.header.name & " non c'è nessun ordine di acquisto pendente. Posso riassortire in quanto è passato tempo")

                    If (AreaState.automaticBot.settings.plafondOperation = 0) Then
                        proceed = True
                    Else
                        proceed = (product.activity.totalInvestment < AreaState.automaticBot.settings.plafondOperation)
                    End If
                End If
                If proceed Then
                    addLogOperation("Try to buy. Good Plafond")

                    If Not IsNothing(_lastBuy) Then
                        Do While (_lastBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Or (_lastBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed)
                            Threading.Thread.Sleep(500)
                        Loop
                    End If

                    _lastBuy = _AcquireWork.buyProduct(product)

                    addLogOperation($"buyProduct created {IsNothing(_lastBuy)}")

                    If (_lastBuy.id.Length = 0) Then
                        addLogOperation($"  not good!")

                        If (_lastBuy.amount = 0) Then
                            addLogOperation($"  amount = 0")
                            stopRestockForFund = True

                            _CurrentFundFree = AreaState.accounts("USDT".ToLower()).valueUSDT
                        End If
                    Else
                        addLogOperation("  buy not complete")
                    End If
                End If

                Return True
            Catch ex As Exception
                MessageBox.Show($"Problem during {product.header.name} checkAndRestockIt - " & ex.Message)

                Return False
            End Try
        End Function

        Private Function tryRestockAll() As Boolean
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

            addLogOperation("TryRestockAll - deal list created")

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

            addLogOperation("TryRestockAll - Reorder list")

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

                    addLogOperation("Try to rebuy " & product.header.name)

                    buyInSent = _AcquireWork.buyProduct(product)

                    If (buyInSent.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented) Then
                        Threading.Thread.Sleep(1000)
                    Else
                        Threading.Thread.Sleep(50)
                    End If
                Next
            Catch ex As Exception
                addLogOperation($"Problem during {productName} completeInvestProducts - " & ex.Message)
            End Try

            stopRestockForFund = False
            _CurrentFundFree = 0

            Return True
        End Function

        Private Function checkProductInformation() As Boolean
            Dim currentTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            If (_lastInternalWork = 0) Or (currentTime > _lastInternalWork + 60000) Then
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

                    If Not stopRestockForFund Then
                        checkAndRestockIt(product)
                    End If
                End If
            Next

            If stopRestockForFund And (AreaState.accounts("USDT".ToLower).valueUSDT > _CurrentFundFree) Then
                addLogOperation($"checkProductInformation stopRestockForFund = {stopRestockForFund} USDT={AreaState.accounts("USDT".ToLower).valueUSDT} CurrentFundFree = {_CurrentFundFree}")

                tryRestockAll()
            End If

            Return True
        End Function

        Private Function tryReconciliation() As Boolean
            addLogOperation("Try reconciliation")

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

                            Watch.trades.add(product)
                            Watch.start()
                        End If
                    End If
                Else
                    addLogOperation("tryReconciliation - resetData " & product.pairID)

                    product.resetData()
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

                With AreaState.journal.history
                    If (.startBlock = 0) Then
                        .startBlock = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
                        .initialFund = AreaState.accounts("USDT".ToLower()).valueUSDT
                    End If
                End With

                AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime

                tryReconciliation()

                Do While inWorkJob
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

                    Do While ((_StartBlockWork + (24 * 60 * 60000)) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) And inWorkJob
                        Threading.Thread.Sleep(100)

                        checkProductInformation()
                    Loop
                Loop
            Catch ex As Exception
                inWorkJob = False
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start a Automatic bot job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not inWorkJob Then
                Dim objWS As Threading.Thread

                inWorkJob = True

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
            inWorkJob = False

            Watch.clear()

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

    End Module

End Namespace
