Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines.Orders

    Module OrderModule

        Private Const c_Second As Double = 1000

        Private Property _InWorkJob As Boolean = False

        ''' <summary>
        ''' This method provide to calculate fee cost of a transaction
        ''' </summary>
        ''' <param name="totalValue"></param>
        ''' <returns></returns>
        Private Function calculateFeeCost(ByVal totalValue As Double) As Double
            Dim feePercentage As Double = 0

            Select Case New Random().Next(0, 1)
                Case 0 : feePercentage = 0.6
                Case Else : feePercentage = 0.4
            End Select

            Return totalValue * feePercentage / 100
        End Function

        ''' <summary>
        ''' This method provide to test if exist the condition to buy
        ''' </summary>
        ''' <param name="tradeBuy"></param>
        ''' <param name="pairKey"></param>
        ''' <returns></returns>
        Private Function testConditionBuy(ByRef tradeBuy As Models.Bot.BotOrderModel, ByVal pairKey As String) As Boolean
            If (tradeBuy.notBeforeThat > 0) Then
                If (tradeBuy.notBeforeThat >= CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                    Return False
                End If
            End If

            If (AreaState.accounts(pairKey.Split("-")(1).ToLower()).amount >= tradeBuy.orderValue) Then
                tradeBuy.notBeforeThat = 0

                Return True
            Else
                tradeBuy.notBeforeThat = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + 10000

                Return False
            End If
        End Function

        ''' <summary>
        ''' This method provide to make order to buy 
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="internalOrderId"></param>
        ''' <param name="tradeBuy"></param>
        ''' <returns></returns>
        Private Function makeOrderBuy(ByVal botId As String, ByVal internalOrderId As String, ByRef tradeBuy As Models.Bot.BotOrderModel) As Boolean
            Dim weightValue As Double = AreaState.bots(botId).common.currentValue * tradeBuy.amount

            tradeBuy.feeCost = calculateFeeCost(weightValue)
            tradeBuy.tco = weightValue + tradeBuy.feeCost
            tradeBuy.pairTradeValue = AreaState.bots(botId).common.currentValue
            tradeBuy.timeCompleted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            tradeBuy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled

            AreaState.addIntoAccount(AreaState.bots(botId).common.key.Split("-")(1), (-1) * tradeBuy.tco)
            AreaState.addIntoAccount(AreaState.bots(botId).common.key, tradeBuy.amount)

            AreaState.orders.Remove(internalOrderId)

            AreaState.totalFeeTrade += CDec(tradeBuy.feeCost)
            AreaState.totalVolumeTrade += CDec(weightValue)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to make and order to sell
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="internalOrderId"></param>
        ''' <param name="tradeSell"></param>
        ''' <returns></returns>
        Private Function makeOrderSell(ByVal botId As String, ByVal internalOrderId As String, ByRef tradeSell As Models.Bot.BotOrderModel) As Boolean
            Dim weightValue As Double = AreaState.bots(botId).common.currentValue * tradeSell.amount

            tradeSell.feeCost = calculateFeeCost(weightValue)
            tradeSell.tco = weightValue + tradeSell.feeCost
            tradeSell.pairTradeValue = AreaState.bots(botId).common.currentValue
            tradeSell.timeCompleted = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            tradeSell.state = Models.Bot.BotOrderModel.OrderStateEnumeration.filled

            AreaState.addIntoAccount(AreaState.bots(botId).common.key, (-1) * tradeSell.amount)
            AreaState.addIntoAccount(AreaState.bots(botId).common.key.Split("-")(1), (tradeSell.tco - tradeSell.feeCost))

            AreaState.orders.Remove(internalOrderId)

            AreaState.totalFeeTrade += tradeSell.feeCost
            AreaState.totalVolumeTrade += weightValue

            Return True
        End Function

        ''' <summary>
        ''' This method provide to verify the order
        ''' </summary>
        ''' <param name="order"></param>
        ''' <returns></returns>
        Private Function verify(ByRef order As Models.Order.SimplyOrderModel) As Boolean
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    If AreaState.bots.ContainsKey(order.botId) Then
                        For Each trade In AreaState.bots(order.botId).data.tradeOpen
                            If (trade.buy.id = order.internalOrderId) Then
                                If testConditionBuy(trade.buy, AreaState.bots(order.botId).common.key) Then
                                    Return makeOrderBuy(order.botId, order.internalOrderId, trade.buy)
                                End If
                            End If

                            If (trade.sell.id = order.internalOrderId) Then
                                If AreaState.bots(order.botId).common.currentValue >= (trade.sell.pairTradeValue) Then
                                    Return makeOrderSell(order.botId, order.internalOrderId, trade.sell)
                                End If
                            End If
                        Next
                    End If

                End If

                Return True
            Catch ex As Exception
                Return False
            Finally
                If (AreaState.orders.Count = 0) Then
                    _InWorkJob = False
                End If

            End Try
        End Function

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceBot()
            Try
                Dim currentIndex As Integer = 0

                Do While _InWorkJob
                    If (AreaState.orders.Count > 0) Then
                        If (currentIndex + 1 > AreaState.orders.Count) Then
                            currentIndex = 0
                        End If

                        If verify(AreaState.orders.ElementAt(currentIndex).Value) Then
                            currentIndex += 1
                        End If
                    End If

                    Threading.Thread.Sleep(100)
                Loop
            Catch ex As Exception
                _InWorkJob = False
            End Try
        End Sub

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