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

        Private Property _BlockWork As New BlockStartEngine
        Private Property _AcquireWork As New AcquireEngine

        Private Property _InReconciliation As Boolean = False

        Public Property currentPhase As WorkerPhaseEnum = WorkerPhaseEnum.undefined
        Public Property inWorkJob As Boolean = False
        Public Property lastBuy As Models.Products.ProductOrderModel
        Public Property startBlockWork As Double = 0




        Private Function checkProductInformation() As Boolean
            Dim currentTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

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
                End If
            Next

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

                            AreaState.exchangeProxy.cancelOrderProduct(product.activity.openBuy.id)
                        Else
                            If (product.activity.sell.id.Length > 0) Then
                                addLogOperation("tryReconciliation - remove " & product.pairID & "  Order = " & product.activity.sell.id)

                                AreaState.exchangeProxy.cancelOrderProduct(product.activity.sell.id)

                                product.activity.sell = New Models.Products.ProductOrderModel
                            End If

                            Watch.trades.add(product, "Trades")
                            Watch.start()
                        End If
                    End If
                Else
                    product.resetData()
                End If

                Threading.Thread.Sleep(50)
            Next

            addLogOperation($"Try reconciliation - InReconciliation = {_InReconciliation}")

            If _InReconciliation Then
                Return Watch.tryRestockAll()
            Else
                Return True
            End If
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
                    If _InReconciliation Then
                        startBlockWork = AreaState.journal.currentBlockCounters.timeStart
                    Else
                        startBlockWork = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If

                    If Not _InReconciliation Then
                        currentPhase = WorkerPhaseEnum.openNewBlock : _BlockWork.run()
                    End If
                    If Not _InReconciliation Then
                        currentPhase = WorkerPhaseEnum.buyTime : _AcquireWork.run()
                    End If

                    _InReconciliation = False : currentPhase = WorkerPhaseEnum.workTime

                    changeInBlockInNormalSell()

                    addLogOperation("AutomaticBot - In worktime")

                    Do While ((startBlockWork + (24 * 60 * 60000)) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) And inWorkJob
                        Threading.Thread.Sleep(60 * 1000)

                        checkProductInformation()
                    Loop
                Loop
            Catch ex As Exception
                inWorkJob = False
            End Try
        End Sub

        Public Function buyProduct(ByVal product As AreaCommon.Models.Products.ProductModel) As Boolean
            Try
                Dim startTime As Double

                lastBuy = _AcquireWork.buyProduct(product)

                startTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                Do While (lastBuy.id.Length = 0) And ((startTime + 5000) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    Threading.Thread.Sleep(100)
                Loop

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function buyProductComplete(ByRef product As AreaCommon.Models.Products.ProductModel) As Models.Products.ProductOrderModel
            Try
                Dim result As Models.Products.ProductOrderModel
                Dim startTime As Double

                result = _AcquireWork.buyProduct(product)

                startTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                Do While (result.id.Length = 0) And ((startTime + 5000) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    Threading.Thread.Sleep(100)
                Loop

                Return result
            Catch ex As Exception
                Return New Models.Products.ProductOrderModel
            End Try
        End Function

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
            Watch.stop()

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
