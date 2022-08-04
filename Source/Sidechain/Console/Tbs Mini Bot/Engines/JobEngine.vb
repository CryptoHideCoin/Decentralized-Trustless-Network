Option Compare Text
Option Explicit On

Namespace AreaCommon.Engine.Bot

    Public Class BotEngine

        Private Property _BotData As New Models.Bots.BotDataMode


        Public Property settings As Models.Bots.BotParameters
        Public Property inRefreshPrice As Boolean = False

        Public Property lastPairPrice As Double
            Get
                Return _BotData.currentValue
            End Get
            Set(value As Double)
                _BotData.currentValue = value
            End Set
        End Property

        Public Event SendBuyOrder()
        Public Event UpdateOrderFundFill()
        Public Event RequestRefreshPrice(ByVal pair As String)
        Public Event SendSellOrder()


        Private Sub printMessage(ByVal value As String)
            Console.WriteLine(value)
        End Sub


        ''' <summary>
        ''' This method provide to return if the market is in the botton
        ''' </summary>
        ''' <returns></returns>
        Private Function inBottonMarket() As Boolean
            Return False
        End Function

        ''' <summary>
        ''' This method provide to return if the market is in the bear
        ''' </summary>
        ''' <returns></returns>
        Private Function inBearMarket() As Boolean
            Return False
        End Function

        ''' <summary>
        ''' This method provide 
        ''' </summary>
        ''' <returns></returns>
        Private Function inBullRun() As Boolean
            Return False
        End Function

        ''' <summary>
        ''' This method provide to return if the market is in Top
        ''' </summary>
        ''' <returns></returns>
        Private Function inTopMarket() As Boolean
            Return False
        End Function

        ''' <summary>
        ''' This method provide to return is the market is in halving state
        ''' </summary>
        ''' <returns></returns>
        Private Function inHalvingMarket() As Boolean
            Return False
        End Function


        ''' <summary>
        ''' This method provide to add new tick
        ''' </summary>
        ''' <returns></returns>
        Private Function addNewTick() As Boolean
            Dim indexOfDecimalPoint As Integer

            RaiseEvent RequestRefreshPrice(_BotData.pair)

            Do While inRefreshPrice
                Threading.Thread.Sleep(10)
            Loop

            If (_BotData.relativeAverageValue = 0) Then
                _BotData.relativeAverageValue = _BotData.currentValue
            Else
                _BotData.relativeAverageValue = (_BotData.currentValue + _BotData.relativeAverageValue) / 2
            End If

            indexOfDecimalPoint = _BotData.currentValue.ToString().IndexOf(",")

            If indexOfDecimalPoint = -1 Then
                indexOfDecimalPoint = 0
            Else
                indexOfDecimalPoint = _BotData.currentValue.ToString().Substring(indexOfDecimalPoint + 1).Length
            End If

            _BotData.relativeAverageValue = Math.Round(_BotData.relativeAverageValue, indexOfDecimalPoint, MidpointRounding.AwayFromZero)

            _BotData.lastRecentValue.Add(_BotData.currentValue)

            If (_BotData.lastRecentValue.Count > settings.startConfiguration.minuteExam) Then
                _BotData.lastRecentValue.RemoveAt(0)
            End If

            If inBottonMarket() Then
                _BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.inBottom

                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = In Bottom")
            ElseIf inBearMarket() Then
                _BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.inBearMarket

                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = In Bear Market")
            ElseIf inBullRun() Then
                _BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.inBullRun

                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = In bull run")
            ElseIf inTopMarket() Then
                _BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.inTop

                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = In Top")
            ElseIf inHalvingMarket() Then
                _BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.inHalving

                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = In Halving")
            ElseIf (_BotData.relativeAverageValue > _BotData.currentValue) Then
                _BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.decrease

                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = Decrease")
            ElseIf (_BotData.relativeAverageValue < _BotData.currentValue) Then
                _BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.increase

                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = Increase")
            ElseIf (_BotData.marketTrend = Models.Bots.BotDataMode.StatusValueEnumeration.undefined) Then
                printMessage($"Price = {_BotData.currentValue} | Average = {_BotData.relativeAverageValue} | recent values = {_BotData.lastRecentValue.Count} | Status = Undefined")
            End If

            Return True
        End Function


        Private Function tryToStartJob() As Boolean
            Dim value As Boolean = False

            If _BotData.bootStrapComplete Then Return True

            If (_BotData.pair.Length = 0) Then
                _BotData.pair = "NU-EUR"
            End If

            If (settings.startConfiguration.startConfiguration > 0) Then
                If (settings.startConfiguration.startConfiguration > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()) Then
                    settings.startConfiguration.startConfiguration = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    Return True
                Else
                    Return False
                End If
            End If

            If (settings.startConfiguration.triggerValue > 0) Then
                If Not _BotData.orderStatedSended Then
                    RaiseEvent SendBuyOrder()

                    _BotData.orderStatedSended = True

                    printMessage($"Buy order sended " & settings.fundConfiguration.unitStep & " €")

                    Return True
                End If
                If Not _BotData.orderFundFill Then
                    RaiseEvent UpdateOrderFundFill()

                    printMessage($"First buy order sended " & settings.fundConfiguration.unitStep & " €")

                    Return _BotData.orderFundFill
                End If
            End If

            If (settings.startConfiguration.minuteExam > 0) Then
                addNewTick()

                If (_BotData.lastRecentValue.Count >= settings.startConfiguration.minuteExam) Then
                    _BotData.bootStrapComplete = True
                Else
                    Return False
                End If
            End If

            Return True
        End Function


        Public Function run() As Boolean
            Dim proceed As Boolean = True

            If proceed Then
                If (_BotData.timeStart = 0) Then
                    proceed = tryToStartJob()

                    If proceed Then
                        _BotData.timeStart = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    End If
                End If
            End If

            If proceed Then
                If (_BotData.lastAcquire = 0) Then
                    RaiseEvent SendBuyOrder()

                    Do While (_BotData.lastAcquire = 0)
                        Threading.Thread.Sleep(100)
                    Loop

                    printMessage($"First buy order sended " & settings.fundConfiguration.unitStep & " €")

                    RaiseEvent SendSellOrder()

                    printMessage($"Order sell placed")

                    Return True
                End If

                ' A questo punto vedo il prezzo, se è inferiore della percentuale che ho impostato
                ' ed è passato il tempo limite... allora effettuo un nuovo rifornimento...

            End If

            Return True
        End Function

    End Class

End Namespace
