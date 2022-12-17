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
            If (bot.data.state >= Models.Bot.BotDataModel.BotStateEnumeration.inBootstrap) Then

                bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inWork

                If (bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inWork) Then
                    If (bot.parameters.startStopConfiguration.timeStart > 0) Then
                        If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() <= bot.parameters.startStopConfiguration.timeStart) Then
                            bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inBootstrap
                        End If
                    End If
                End If

                If (bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inWork) Then
                    If (bot.data.examTimeLimit > 0) Then
                        If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() <= bot.data.examTimeLimit) Then
                            bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inBootstrap
                        End If
                    End If
                End If

                If (bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inWork) Then
                    If (bot.parameters.startStopConfiguration.activateTriggerValue > 0) Then
                        If (AreaState.pairs(bot.data.pair).currentValue <= bot.parameters.startStopConfiguration.activateTriggerValue) Then
                            bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inBootstrap
                        End If
                    End If
                End If
            Else
                bot.data.pair = AreaState.getPairName(bot.parameters.configuration.pairId)
                bot.common = AreaState.pairs(bot.data.pair)

                bot.data.state = Models.Bot.BotDataModel.BotStateEnumeration.inBootstrap

                If (bot.parameters.workConfiguration.buyConfiguration.minuteExam > 0) Then

                    If AreaState.pairs.ContainsKey(bot.data.pair) Then
                        If AreaState.pairs(bot.data.pair).marketData.ContainsKey(Models.Pair.TrendData.PeriodTypeEnumeration.lastHour) Then
                            If (AreaState.pairs(bot.data.pair).marketData(Models.Pair.TrendData.PeriodTypeEnumeration.lastHour).ticks.Count >= bot.parameters.workConfiguration.buyConfiguration.minuteExam) Then
                                Return
                            Else
                                bot.data.examTimeLimit = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + ((bot.parameters.workConfiguration.buyConfiguration.minuteExam - AreaState.pairs(bot.data.pair).marketData(Models.Pair.TrendData.PeriodTypeEnumeration.lastHour).ticks.Count) * 60 * 1000)
                            End If
                        End If
                    End If

                    If (bot.data.examTimeLimit = 0) Then
                        bot.data.examTimeLimit = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (bot.parameters.workConfiguration.buyConfiguration.minuteExam * 60 * 1000)
                    End If
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
                botConfiguration.data.tradeClose.Add(trade.id)

                trade.earn = CDec(trade.sell.tco) - trade.buy.tco

                AreaCommon.Engine.IO.updateTradeClose(botConfiguration.parameters.header.id, trade)

                botConfiguration.data.usedPlafond -= trade.buy.tco - trade.buy.feeCost
                botConfiguration.data.earn += trade.earn

                AreaState.summary.increaseValue += trade.earn

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
            Return System.IO.Path.Combine(AreaCommon.Engine.IO.orderToDeliveryPath, fileName & ".order")
        End Function

        ''' <summary>
        ''' This method provide to return a path order to placed
        ''' </summary>
        ''' <returns></returns>
        Private Function pathOrderToPlaced(ByVal fileName As String) As String
            Return System.IO.Path.Combine(AreaCommon.Engine.IO.orderPlacedPath, fileName & ".confirm")
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

            content += $"Passphrase={AreaState.defaultUserDataAccount.exchangeAccess.passphrase}{vbNewLine}"
            content += $"Secret={AreaState.defaultUserDataAccount.exchangeAccess.secret}{vbNewLine}"
            content += $"API key={AreaState.defaultUserDataAccount.exchangeAccess.APIKey}{vbNewLine}"
            content += $"Pair={pair}{vbNewLine}"
            content += $"Amount={item.amount}{vbNewLine}"
            content += $"LimitPrice={item.orderValue}{vbNewLine}"

            Dim fileName As String = pathOrderToDelivery(item.id)

            If Not System.IO.File.Exists(fileName) Then
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

            If Not System.IO.File.Exists(fileName) Then
                Dim objWriter As New System.IO.StreamWriter(fileName)

                objWriter.Write(content)
                objWriter.Close()
            End If

            System.IO.File.Move(pathOrderToDelivery(item.id), pathOrderToClose(item.id & ".order"))

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

            trade.sell.timeStart = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            trade.sell.orderValue = trade.buy.tco - trade.buy.feeCost
            trade.sell.orderValue += (trade.sell.orderValue * spread) / 100

            trade.sell.pairTradeValue = trade.buy.pairTradeValue + (trade.buy.pairTradeValue * spread) / 100

            Return True
        End Function

        ''' <summary>
        ''' This method provide to get an order number
        ''' </summary>
        ''' <param name="orderBuyId"></param>
        ''' <returns></returns>
        Private Function getOrderNumber(ByVal orderBuyId As String) As String
            Dim filePath = pathOrderToPlaced(orderBuyId)

            Dim streamFile As IO.StreamReader = System.IO.File.OpenText(filePath)

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

                System.IO.File.Move(filePath, pathOrderToClose(orderBuyId & ".confirm"))
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
                    If trade.buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented Then
                        If System.IO.File.Exists(pathOrderToPlaced(trade.buy.id)) Then
                            trade.buy.number = getOrderNumber(trade.buy.id)
                            trade.buy.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed

                            Return True
                        End If

                    ElseIf trade.sell.state = Models.Bot.BotOrderModel.OrderStateEnumeration.sented Then
                        If System.IO.File.Exists(pathOrderToPlaced(trade.sell.id)) Then
                            trade.sell.number = getOrderNumber(trade.sell.id)
                            trade.sell.state = Models.Bot.BotOrderModel.OrderStateEnumeration.placed

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
            trade.buy.amount = item.parameters.configuration.unitStep / item.common.currentValue
            trade.buy.timeStart = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            trade.buy.orderValue = item.parameters.configuration.unitStep + (item.parameters.configuration.unitStep * 2 / 100)

            item.data.tradeOpen.Add(trade)

            Return True
        End Function

        Private Function extremeForRestocking(ByRef item As Models.Bot.BotConfigurationsModel) As Boolean
            If (item.data.lastBuyTime = 0) Then
                Return False
            End If

            If item.data.lastBuyTime + (item.parameters.workConfiguration.buyConfiguration.dealMinimalStep * 60000) < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() Then
                If (item.common.currentValue <= item.data.lastBuyChange - (item.data.lastBuyChange * item.parameters.workConfiguration.buyConfiguration.dealAcquireOnPercentage / 100)) Then

                    For Each singleOrder In item.data.tradeOpen
                        If (singleOrder.buy.notBeforeThat > 0) Then
                            If (singleOrder.buy.notBeforeThatBegin + 60000 > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                                item.data.tradeOpen.Remove(singleOrder)

                                Return True
                            Else
                                Return False
                            End If
                        End If
                    Next

                    Return True
                End If
            End If

            Return False
        End Function

        ''' <summary>
        ''' This method provide to check if in the account is the fund
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function haveFund(ByRef item As Models.Bot.BotConfigurationsModel) As Boolean
            Return (AreaState.accounts(item.common.key.Split("-")(1).ToLower()).amount >= item.parameters.configuration.unitStep)
        End Function

        ''' <summary>
        ''' This method provide to evaluate to acquire another quantity
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        Private Function evaluateToBuy(ByRef item As Models.Bot.BotConfigurationsModel) As Boolean
            If (item.parameters.configuration.plafond >= item.data.usedPlafond) And haveFund(item) Then
                If (item.data.lastBuyTime = 0) And (item.data.tradeOpen.Count = 0) Then
                    If Not item.parameters.workConfiguration.buyConfiguration.onlyInDeal Then
                        Return createNewBuyOrder(item)
                    End If
                ElseIf (item.data.tradeOpen.Count = 0) And (item.parameters.configuration.mode = Models.Bot.BotParametersModel.FundBotConfiguration.ModeTradeConfigEnumeration.continuousGain) Then
                    If Not item.parameters.workConfiguration.buyConfiguration.onlyInDeal Then
                        Return createNewBuyOrder(item)
                    End If
                ElseIf (item.parameters.configuration.mode = Models.Bot.BotParametersModel.FundBotConfiguration.ModeTradeConfigEnumeration.DCA) Then
                    If Not item.parameters.workConfiguration.buyConfiguration.onlyInDeal Then

                        If (item.data.tradeOpen.Count = 0) Then
                            Return createNewBuyOrder(item)
                        ElseIf extremeForRestocking(item) And Not item.data.inRecharge Then
                            item.data.inRecharge = True

                            Return createNewBuyOrder(item)
                        End If

                    End If
                End If
            End If

            Return False
        End Function

        Public Function [stop]() As Boolean
            _InWorkJob = False

            Return True
        End Function

    End Module

End Namespace
