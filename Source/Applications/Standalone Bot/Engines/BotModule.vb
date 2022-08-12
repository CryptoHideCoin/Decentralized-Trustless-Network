Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines.Bots

    Module BotModule

        Private Const c_Second As Double = 1000

        Private Property _InWorkJob As Boolean = False


        ''' <summary>
        ''' This method provide to start the bot
        ''' </summary>
        ''' <param name="bot"></param>
        Private Sub startUp(ByRef bot As Models.Bot.BotConfigurationsModel)
            If bot.data.bootStrapInitial Then
                If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > bot.data.examTimeLimit) Then
                    bot.data.bootStrapComplete = True
                End If
            Else
                bot.data.pair = AreaState.getPairName(bot.parameters.fundConfiguration.pairId)
                bot.common = AreaState.pairs(bot.data.pair)

                If (bot.parameters.startConfiguration.timeStart > 0) Then
                    bot.data.bootStrapInitial = (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > bot.parameters.startConfiguration.timeStart)
                End If

                If (bot.parameters.startConfiguration.triggerValue > 0) Then
                    bot.data.bootStrapInitial = (AreaState.pairs(bot.data.pair).currentValue > bot.parameters.startConfiguration.triggerValue)
                End If

                If (bot.parameters.startConfiguration.timeStart = 0) And (bot.parameters.startConfiguration.triggerValue = 0) Then
                    bot.data.bootStrapInitial = True
                End If

                If (bot.parameters.startConfiguration.minuteExam > 0) Then
                    bot.data.examTimeLimit = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (bot.parameters.startConfiguration.minuteExam * 60 * 1000)
                Else
                    bot.data.bootStrapComplete = True
                End If
            End If
        End Sub

        ''' <summary>
        ''' This method provide to move a trade from open to close
        ''' </summary>
        ''' <param name="botConfiguration"></param>
        ''' <param name="trade"></param>
        ''' <returns></returns>
        Private Function switchTradeToClose(ByRef botConfiguration As Models.Bot.BotConfigurationsModel, ByRef trade As Models.Bot.TradeModel) As Boolean
            Try
                botConfiguration.data.tradeOpen.Remove(trade)
                botConfiguration.data.tradeClose.Add(trade)

                trade.earn = CDec(trade.sell.tco) - trade.buy.tco

                botConfiguration.data.earn += trade.earn

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to return a path order to delivery
        ''' </summary>
        ''' <returns></returns>
        Private Function pathOrderToDelivery(ByVal fileName As String) As String
            Return IO.Path.Combine(Environment.GetCommandLineArgs(1), "To delivery", fileName & ".order")
        End Function

        ''' <summary>
        ''' This method provide to return a path order to placed
        ''' </summary>
        ''' <returns></returns>
        Private Function pathOrderToPlaced(ByVal fileName As String) As String
            Return IO.Path.Combine(Environment.GetCommandLineArgs(1), "Placed", fileName & ".confirm")
        End Function

        ''' <summary>
        ''' This method provide to return a path order to close
        ''' </summary>
        ''' <param name="completeName"></param>
        ''' <returns></returns>
        Private Function pathOrderToClose(ByVal completeName As String) As String
            Return IO.Path.Combine(Environment.GetCommandLineArgs(1), "Closed", completeName)
        End Function

        ''' <summary>
        ''' This method provide to create file order
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function createFileOrder(ByVal pair As String, ByRef item As Models.Bot.BotOrderModel) As Boolean
            Dim content As String = $"Release=1.0{vbNewLine}"

            If item.buy Then
                content += $"Mode=Buy{vbNewLine}"
            Else
                content += $"Mode=Sell{vbNewLine}"
            End If

            content += $"Passphrase={AreaState.defaultGenericAccount.passphrase}{vbNewLine}"
            content += $"Secret={AreaState.defaultGenericAccount.secret}{vbNewLine}"
            content += $"API key={AreaState.defaultGenericAccount.APIKey}{vbNewLine}"
            content += $"Pair={pair}{vbNewLine}"
            content += $"Amount={item.amount}{vbNewLine}"
            content += $"LimitPrice={item.orderValue}{vbNewLine}"

            Dim fileName As String = pathOrderToDelivery(item.id)

            If Not IO.File.Exists(fileName) Then
                Dim objWriter As New System.IO.StreamWriter(fileName)

                objWriter.Write(content)
                objWriter.Close()
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to create a false response order
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function createFalseResponseOrder(ByRef item As Models.Bot.BotOrderModel) As Boolean
            Dim content As String = $"Release=1.0{vbNewLine}"

            content += $"OrderNumber={Guid.NewGuid.ToString()}{vbNewLine}"

            Dim fileName As String = pathOrderToPlaced(item.id)

            If Not IO.File.Exists(fileName) Then
                Dim objWriter As New System.IO.StreamWriter(fileName)

                objWriter.Write(content)
                objWriter.Close()
            End If

            IO.File.Move(pathOrderToDelivery(item.id), pathOrderToClose(item.id & ".order"))

            Return True
        End Function

        ''' <summary>
        ''' This method provide to check if the order is in 
        ''' </summary>
        ''' <param name="botId"></param>
        ''' <param name="order"></param>
        ''' <returns></returns>
        Private Function startMonitorOrder(ByVal botId As String, ByRef order As Models.Bot.BotOrderModel) As Boolean
            If Not AreaState.orders.ContainsKey(order.id) Then
                Dim newSimply As New Models.Order.SimplyOrderModel

                newSimply.accountCredentials = AreaState.defaultGenericAccount
                newSimply.botId = botId
                newSimply.internalOrderId = order.id
                newSimply.publicOrderId = order.number

                AreaState.orders.Add(order.id, newSimply)

                Orders.start()
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to create new buy order
        ''' </summary>
        ''' <param name="spread"></param>
        ''' <param name="trade"></param>
        ''' <returns></returns>
        Private Function createNewSellOrder(ByVal spread As Double, ByRef trade As Models.Bot.TradeModel) As Boolean
            trade.sell.buy = False
            trade.sell.amount = trade.buy.amount

            trade.sell.timeAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            trade.sell.orderValue = trade.buy.tco - trade.buy.feeCost
            trade.sell.orderValue += (trade.sell.orderValue * spread) / 100

            trade.sell.pairTradeValue = trade.buy.pairTradeValue + (trade.buy.pairTradeValue * spread) / 100

            Return True
        End Function

        ''' <summary>
        ''' This method provide to manage open trades
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function manageOpenTrades(ByRef item As Models.Bot.BotConfigurationsModel) As Boolean
            If (item.data.tradeOpen.Count > 0) Then
                For Each trade In item.data.tradeOpen
                    If trade.buy.sent Then
                        If trade.buy.fill And trade.sell.fill Then
                            switchTradeToClose(item, trade)

                            If (item.parameters.workConfiguration.mode = Models.Bot.BotParametersModel.BotActivityConfiguration.ModeTradeConfigEnumeration.oneshot) Then
                                item.parameters.header.isActive = False
                            End If

                            Return True
                        ElseIf trade.sell.placed And Not trade.sell.fill Then
                            startMonitorOrder(item.parameters.header.id, trade.sell)
                        ElseIf trade.buy.placed And Not trade.buy.fill Then
                            startMonitorOrder(item.parameters.header.id, trade.buy)
                        End If
                    Else
                        createFileOrder(item.data.pair, trade.buy)
                        createFalseResponseOrder(trade.buy)

                        trade.buy.sent = True

                        Return True
                    End If

                    If trade.buy.fill And Not trade.sell.sent Then
                        If (trade.sell.timeAcquire > 0) Then
                            item.data.lastBuyTime = trade.buy.timeAcquire
                            item.data.lastBuyValue = trade.buy.tco - trade.buy.feeCost
                            item.data.lastBuyChange = trade.buy.pairTradeValue
                            item.data.usedPlafond += trade.buy.tco

                            createFileOrder(item.data.pair, trade.sell)
                            createFalseResponseOrder(trade.sell)

                            trade.sell.sent = True

                            Return True
                        Else
                            createNewSellOrder(item.parameters.workConfiguration.spread, trade)
                        End If
                    End If
                Next
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to get an order number
        ''' </summary>
        ''' <param name="orderBuyId"></param>
        ''' <returns></returns>
        Private Function getOrderNumber(ByVal orderBuyId As String) As String
            Dim filePath = pathOrderToPlaced(orderBuyId)

            Dim streamFile As IO.StreamReader = IO.File.OpenText(filePath)

            Try
                Dim orderData = streamFile.ReadLine()

                Do While (orderData.Split("=")(0).CompareTo("OrderNumber") > 0)
                    orderData = streamFile.ReadLine()
                Loop

                Return orderData.Split("=")(1)
            Catch ex As Exception
                Return ""
            Finally
                streamFile.Close()

                IO.File.Move(filePath, pathOrderToClose(orderBuyId & ".confirm"))
            End Try
        End Function

        ''' <summary>
        ''' This method provide to manage order status
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function manageOrderStatus(ByRef item As Models.Bot.BotConfigurationsModel) As Boolean
            If (item.data.tradeOpen.Count > 0) Then
                For Each trade In item.data.tradeOpen
                    If trade.buy.sent And Not trade.buy.placed Then
                        If IO.File.Exists(pathOrderToPlaced(trade.buy.id)) Then
                            trade.buy.number = getOrderNumber(trade.buy.id)
                            trade.buy.placed = True

                            Return True
                        End If

                    ElseIf trade.sell.sent And Not trade.sell.placed Then
                        If IO.File.Exists(pathOrderToPlaced(trade.sell.id)) Then
                            trade.sell.number = getOrderNumber(trade.sell.id)
                            trade.sell.placed = True

                            Return True
                        End If
                    End If
                Next
            End If

            Return True
        End Function

        ''' <summary>
        ''' This method provide to create new buy order
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function createNewBuyOrder(ByRef item As Models.Bot.BotConfigurationsModel) As Boolean
            If item.common.currentValue = 0 Then Return False

            Dim trade As New Models.Bot.TradeModel

            trade.buy.buy = True
            trade.buy.amount = item.parameters.fundConfiguration.unitStep / item.common.currentValue
            trade.buy.timeAcquire = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            trade.buy.orderValue = item.parameters.fundConfiguration.unitStep + (item.parameters.fundConfiguration.unitStep * 2 / 100)

            item.data.tradeOpen.Add(trade)

            Return True
        End Function

        ''' <summary>
        ''' This method provide to evaluate to acquire another quantity
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function evaluateToBuy(ByRef item As Models.Bot.BotConfigurationsModel) As Boolean
            If (item.parameters.fundConfiguration.plafond > item.data.usedPlafond) Then
                If (item.data.lastBuyTime = 0) And (item.data.tradeOpen.Count = 0) Then
                    If Not item.parameters.workConfiguration.buyConfiguration.onlyInDeal Then
                        Return createNewBuyOrder(item)
                    End If
                End If
            End If

            Return False
        End Function

        ''' <summary>
        ''' This method provide to work with action bot
        ''' </summary>
        ''' <param name="item"></param>
        Private Sub actionBot(ByRef item As Models.Bot.BotConfigurationsModel)
            Dim proceed As Boolean = True

            If proceed Then
                If (item.data.timeStart = 0) Then
                    item.data.timeStart = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                End If
            End If
            If proceed Then
                proceed = manageOpenTrades(item)
            End If
            If proceed Then
                proceed = manageOrderStatus(item)
            End If
            If proceed Then
                proceed = evaluateToBuy(item)
            End If
        End Sub

        ''' <summary>
        ''' This method provide to process a pair
        ''' </summary>
        ''' <param name="bot"></param>
        ''' <returns></returns>
        Private Function process(ByRef bot As Models.Bot.BotConfigurationsModel) As Boolean
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = bot.parameters.header.isActive
                End If
                If proceed Then
                    If bot.data.bootStrapComplete Then
                        actionBot(bot)
                    Else
                        startUp(bot)
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
                    If (AreaState.bots.Count > 0) Then
                        If (currentIndex + 1 > AreaState.bots.Count) Then
                            currentIndex = 0
                        End If

                        If process(AreaState.bots.ElementAt(currentIndex).Value) Then
                            currentIndex += 1
                        End If
                    End If

                    Threading.Thread.Sleep(10)
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