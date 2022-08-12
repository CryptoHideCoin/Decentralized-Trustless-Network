Option Compare Text
Option Explicit On





Public Class Manager

    Sub refreshDataBot()
        Dim rowItem As New ArrayList
        Dim execute As Boolean = True

        If botDataView.Rows.Count = AreaState.bots.Count Then
            Do While execute
                execute = False

                Try
                    For index As Integer = 0 To AreaState.bots.ToList.Count - 1
                        If AreaState.bots.ToList(index).Value.parameters.header.isActive Then
                            botDataView.Rows(index).Cells(3).Value = "OFF"
                        Else
                            botDataView.Rows(index).Cells(3).Value = "ON"
                        End If
                    Next
                Catch ex As Exception
                    execute = True
                End Try
            Loop

            Return
        End If

        Do While execute
            execute = False

            botDataView.Rows.Clear()

            Try
                For Each item In AreaState.bots.ToList
                    rowItem.Clear()

                    rowItem.Add(item.Value.parameters.header.id)
                    rowItem.Add(CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(item.Value.parameters.header.created), True))
                    rowItem.Add(item.Value.data.pair)

                    If item.Value.parameters.header.isActive Then
                        rowItem.Add("OFF")
                    Else
                        rowItem.Add("ON")
                    End If

                    botDataView.Rows.Add(rowItem.ToArray)
                Next
            Catch ex As Exception
                execute = True
            End Try
        Loop

    End Sub

    Sub refreshDataMarket()
        Dim rowItem As New ArrayList

        marketDataView.Rows.Clear()

        For Each item In AreaState.pairs.Values
            rowItem.Clear()

            rowItem.Add(item.key)
            rowItem.Add(item.currentValue.ToString("#,##0.00000"))

            marketDataView.Rows.Add(rowItem.ToArray)

            marketDataView.Rows(marketDataView.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGray
        Next
    End Sub

    Sub refreshTickValue()
        Dim rowItem As New ArrayList
        Dim pairData As AreaCommon.Models.Pair.PairInformation
        Dim singleTick As AreaCommon.Models.Pair.TickInformation
        Dim market As AreaCommon.Models.Pair.TrendData
        Dim key As AreaCommon.Models.Pair.TrendData.periodTypeEnumeration

        tickValues.Rows.Clear()

        If IsNothing(marketDataView.CurrentRow) Then Return

        pairData = AreaState.pairs.Values(marketDataView.CurrentRow.Index)

        Select Case filterDetails.SelectedIndex
            Case 0 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastHour
            Case 1 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastDay
            Case 2 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastWeek
            Case 3 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastMonth
            Case Else : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastYear
        End Select

        If pairData.marketData.ContainsKey(key) Then
            market = pairData.marketData(key)
        Else
            Return
        End If

        For pos = market.ticks.Count - 1 To 0 Step -1
            singleTick = market.ticks(pos)

            rowItem.Clear()

            rowItem.Add(CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(singleTick.time), True))
            rowItem.Add(singleTick.value.ToString("#,##0.00000"))

            tickValues.Rows.Add(rowItem.ToArray)

            Select Case singleTick.position
                Case AreaCommon.Models.Pair.TickInformation.tickPositionEnumeration.decrease
                    tickValues.Rows(tickValues.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
                Case AreaCommon.Models.Pair.TickInformation.tickPositionEnumeration.increase
                    tickValues.Rows(tickValues.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen
                Case AreaCommon.Models.Pair.TickInformation.tickPositionEnumeration.same
                    tickValues.Rows(tickValues.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Black
            End Select

            tickValues.Rows(tickValues.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGray
        Next
    End Sub

    Sub refreshGraphValue()
        If IsNothing(marketDataView.CurrentRow) Then
            Return
        End If

        Dim serie As New DataVisualization.Charting.Series
        Dim market As AreaCommon.Models.Pair.TrendData
        Dim key As AreaCommon.Models.Pair.TrendData.periodTypeEnumeration

        mainChart.Series.Clear()

        Select Case filterDetails.SelectedIndex
            Case 0 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastHour
            Case 1 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastDay
            Case 2 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastWeek
            Case 3 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastMonth
            Case Else : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastYear
        End Select

        If AreaState.pairs.Values(marketDataView.CurrentRow.Index).marketData.ContainsKey(key) Then
            market = AreaState.pairs.Values(marketDataView.CurrentRow.Index).marketData(key)
        Else
            Return
        End If

        If (mainChart.Titles.Count = 0) Then
            mainChart.Titles.Add(AreaState.pairs.Values(marketDataView.CurrentRow.Index).key)
        End If

        serie.Name = "."
        serie.ChartType = DataVisualization.Charting.SeriesChartType.Spline
        serie.BorderWidth = 3
        serie.IsVisibleInLegend = False

        For Each tick In market.ticks
            serie.Points.AddXY("", tick.value)
        Next

        mainChart.Series.Add(serie)

        mainChart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        mainChart.ChartAreas(0).AxisX.MinorGrid.Enabled = False
        'mainChart.ChartAreas(0).AxisX.Minimum = market.min
        'mainChart.ChartAreas(0).AxisX.Maximum = market.max
    End Sub

    Sub updateDataMarket()
        Dim index As Integer = 0

        For Each item In AreaState.pairs
            marketDataView.Rows.Item(index).SetValues(item.Key, item.Value.currentValue.ToString("#,##0.00000"))

            index += 1
        Next
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        Dim addNewForm As New SettingsBot

        addNewForm.Show()
    End Sub

    Private Sub loadBotParameters(ByRef jobParameters As AreaCommon.Models.Bot.BotParametersModel, ByVal pair As String)

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Not IsNothing(botDataView.CurrentRow) Then
            Dim id As String = botDataView.CurrentRow.Cells.Item(0).Value

            For Each job In AreaState.bots.ToList
                If (job.Value.parameters.header.id.CompareTo(id) = 0) Then
                    loadBotParameters(job.Value.parameters, job.Value.data.pair)

                    Return
                End If
            Next
        End If
    End Sub

    Private Sub refreshDetailValue()
        Dim rowItem As New ArrayList
        Dim pairData As AreaCommon.Models.Pair.PairInformation
        Dim market As AreaCommon.Models.Pair.TrendData
        Dim key As AreaCommon.Models.Pair.TrendData.periodTypeEnumeration

        If IsNothing(marketDataView.CurrentRow) Then Return

        pairData = AreaState.pairs.ElementAt(marketDataView.CurrentRow.Index).Value

        pairValue.Text = pairData.key

        Select Case filterDetails.SelectedIndex
            Case 0 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastHour
            Case 1 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastDay
            Case 2 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastWeek
            Case 3 : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastMonth
            Case Else : key = AreaCommon.Models.Pair.TrendData.periodTypeEnumeration.lastYear
        End Select

        If pairData.marketData.ContainsKey(key) Then
            market = pairData.marketData(key)
        Else
            minValue.Text = ""
            maxValue.Text = ""
            averageValue.Text = ""
            averageRelativeValue.Text = ""
            trendValue.Text = ""
            lastUpdateValue.Text = ""
            firstValue.Text = ""
            lastValue.Text = ""
            spreadValue.Text = ""

            Return
        End If

        minValue.Text = market.min.ToString("#,##0.00000")
        maxValue.Text = market.max.ToString("#,##0.00000")
        averageValue.Text = market.average.ToString("#,##0.00000")
        averageRelativeValue.Text = market.relativeAverage.ToString("#,##0.00000")
        firstValue.Text = market.firstValue.ToString("#,##0.00000")
        lastValue.Text = market.lastValue.ToString("#,##0.00000")
        spreadValue.Text = market.spread.ToString("#,##0.00") & " % (" & market.spreadValue.ToString("#,##0.00") & " " & pairData.key.Split("-")(1) & ")"

        If (market.spread > 0) Then
            spreadValue.ForeColor = Color.Green
            spreadLabel.ForeColor = Color.Green
        ElseIf (market.spread < 0) Then
            spreadValue.ForeColor = Color.DarkRed
            spreadLabel.ForeColor = Color.DarkRed
        ElseIf (market.spread = 0) Then
            spreadValue.ForeColor = Color.Black
            spreadLabel.ForeColor = Color.Black
        End If

        Select Case market.trend
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.decrease
                trendValue.Text = "Decrease"
                trendValue.ForeColor = Color.DarkRed
                trendLabel.ForeColor = Color.DarkRed
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.increase
                trendValue.ForeColor = Color.Green
                trendLabel.ForeColor = Color.Green
                trendValue.Text = "Increase"
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.deep
                trendValue.Text = "Deep"
                trendValue.ForeColor = Color.DarkRed
                trendLabel.ForeColor = Color.DarkRed
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.inBearMarket
                trendValue.Text = "In bear market"
                trendValue.ForeColor = Color.DarkRed
                trendLabel.ForeColor = Color.DarkRed
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.inBullRun
                trendValue.ForeColor = Color.Green
                trendLabel.ForeColor = Color.Green
                trendValue.Text = "In bullrun"
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.inHalving
                trendValue.Text = "In halving"
                trendValue.ForeColor = Color.Green
                trendLabel.ForeColor = Color.Green
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.inTop
                trendValue.Text = "Top"
                trendValue.ForeColor = Color.Green
                trendLabel.ForeColor = Color.Green
            Case AreaCommon.Models.Pair.TrendData.StatusValueEnumeration.undefined
                trendValue.Text = "Undefined"
                trendValue.ForeColor = Color.Black
                trendLabel.ForeColor = Color.Black
        End Select

        lastUpdateValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(pairData.lastUpdateTick), True)
    End Sub

    Private Sub updateAllDataMarkets()
        Dim rowIndexPair As Integer

        If IsNothing(marketDataView.CurrentRow) Then
            rowIndexPair = -1
        Else
            rowIndexPair = marketDataView.CurrentRow.Index
        End If

        If (marketDataView.Rows.Count <> AreaState.pairs.Count) And (AreaState.pairs.Count <> 0) Then
            refreshDataMarket()
            refreshTickValue()
            refreshDetailValue()
            refreshGraphValue()

            If (rowIndexPair <> -1) Then
                marketDataView.Rows.Item(rowIndexPair).Selected = True
            End If
        ElseIf (AreaState.pairs.Count <> 0) Then
            updateDataMarket()
            refreshTickValue()
            refreshDetailValue()
            refreshGraphValue()
        End If

    End Sub

    Private Sub timerMain_Tick(sender As Object, e As EventArgs) Handles timerMain.Tick
        updateAllDataMarkets()
    End Sub

    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filterDetails.SelectedIndex = 0

        With AreaState.defaultGenericAccount
            .exchange = AreaCommon.Models.Bot.BotUserAccountModel.ExchangeEnumeration.coinbasePro
            .APIKey = "0056fd332d3742fe03e23611e458f5f6"
            .passphrase = "7453tzgjyvo"
            .secret = "PWgu2Ssj/O6dZZA9PGjYqqOrLjWKX4Ek6bRPHzDKLYajgiYaBDfdQv5WBuTwcW6ezuYOF6XKpx0q4eyBQTCThA=="
            .apiURL = "https://api.pro.coinbase.com"
        End With

        Me.Text = $"Simulator - Standard Bot - rel.{Application.ProductVersion}"
    End Sub

    Private Sub marketDataView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles marketDataView.CellContentClick

    End Sub

    Private Sub marketDataView_SelectionChanged(sender As Object, e As EventArgs) Handles marketDataView.SelectionChanged
        refreshTickValue()
        refreshDetailValue()
    End Sub

    Private Sub Manager_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        AreaCommon.Engines.Bots.stop()
        AreaCommon.Engines.Pairs.stop()
        AreaCommon.Engines.Orders.stop()
    End Sub

    Private Sub noDataMarket_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub filterDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles filterDetails.SelectedIndexChanged
        updateAllDataMarkets()

        Select Case filterDetails.SelectedIndex
            Case 0 : hourGridLabel.Text = "Last hour ticks"
            Case 1 : hourGridLabel.Text = "Last day ticks"
            Case 2 : hourGridLabel.Text = "Last week ticks"
            Case 3 : hourGridLabel.Text = "Last month ticks"
            Case 4 : hourGridLabel.Text = "Last year ticks"
        End Select
    End Sub

    Private Sub activeBot()
        If Not IsNothing(botDataView.CurrentRow) Then
            Dim id As String = botDataView.CurrentRow.Cells.Item(0).Value

            For Each item In AreaState.bots
                If item.Value.parameters.header.id.CompareTo(id) = 0 Then
                    item.Value.parameters.header.isActive = Not item.Value.parameters.header.isActive

                    botDataView.CurrentRow.SetValues(id, CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(item.Value.parameters.header.created), True), item.Value.data.pair, value)

                    Return
                End If
            Next
        End If
    End Sub

    Private Sub updateBotsTimer_Tick(sender As Object, e As EventArgs) Handles updateBotsTimer.Tick
        refreshDataBot()

        If (AreaState.bots.Count > 0) And Not timerMain.Enabled Then
            timerMain.Enabled = True

            updateAllDataMarkets()
        End If
    End Sub

    Private Sub botDataView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles botDataView.CellContentClick
        Select Case e.ColumnIndex
            Case 3
                activeBot()
            Case 4
                Dim addNewForm As New SettingsBot

                addNewForm.currentID = botDataView.Rows.Item(e.RowIndex).Cells(0).Value
                addNewForm.pair = botDataView.Rows.Item(e.RowIndex).Cells(2).Value

                addNewForm.Show()
            Case 5
                Dim informationForm As New DataBot

                If Not IsNothing(botDataView.CurrentRow) Then
                    Dim id As String = botDataView.CurrentRow.Cells.Item(0).Value

                    informationForm.idReferement = id

                    informationForm.Show()
                End If
        End Select
    End Sub
End Class
