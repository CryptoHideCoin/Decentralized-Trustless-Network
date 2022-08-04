Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines.Orders

    Module OrderModule

        Private Const c_Second As Double = 1000

        Private Property _InWorkJob As Boolean = False


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
                                trade.buy.effectiveValue = (AreaState.bots(order.botId).common.currentValue * trade.buy.amount)
                                trade.buy.pairTradeValue = AreaState.bots(order.botId).common.currentValue
                                trade.buy.fill = True

                                AreaState.orders.Remove(order.internalOrderId)

                                Return True
                            End If

                            If (trade.sell.id = order.internalOrderId) Then
                                If AreaState.bots(order.botId).common.currentValue >= (trade.sell.orderValue / trade.sell.amount) Then
                                    trade.sell.effectiveValue = (AreaState.bots(order.botId).common.currentValue * trade.sell.amount)
                                    trade.sell.pairTradeValue = AreaState.bots(order.botId).common.currentValue
                                    trade.sell.fill = True

                                    AreaState.orders.Remove(order.internalOrderId)
                                End If

                                Return True
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

                        If Not verify(AreaState.orders.ElementAt(currentIndex).Value) Then
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