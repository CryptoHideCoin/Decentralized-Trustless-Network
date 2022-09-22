Option Compare Text
Option Explicit On


Public Class DataPageDetail

    Private Property datePage As AreaCommon.Models.Journal.DayCounterModel

    Public Property fileName As String = ""



    Sub refreshDailyOrderGrid()
        Dim rowItem As New ArrayList

        Dim item As AreaCommon.Models.Journal.DayCounterModel.TransactionModel

        For count As Integer = datePage.transactions.Count - 1 To 0 Step -1

            item = datePage.transactions(count)

            rowItem.Clear()

            If item.buy Then
                rowItem.Add(1)
            Else
                rowItem.Add(0)
            End If

            rowItem.Add(CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(item.dateCompletate), True))
            rowItem.Add(item.pairID)
            rowItem.Add(item.amount.ToString("#,##0.00000"))
            rowItem.Add(item.value.ToString("#,##0.00000"))

            If item.daily Then
                rowItem.Add(1)
            Else
                rowItem.Add(0)
            End If

            dayTransactionDataView.Rows.Add(rowItem.ToArray)
        Next
    End Sub

    Private Sub formatValue(ByRef control As Object, ByVal value As Double, Optional ByVal colorValue As Boolean = False)
        If (value = 0) Then
            control.Text = "---"

            control.ForeColor = Color.Black
        Else
            control.Text = value.ToString("#,##0.00")

            If colorValue Then
                If (value < 0) Then
                    control.ForeColor = Color.Red
                Else
                    control.ForeColor = Color.DarkGreen
                End If
            End If
        End If
    End Sub

    Private Sub refreshJournalValue()
        currentDayValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(datePage.day), True)

        formatValue(earnDayValue, datePage.earn, True)
        formatValue(initialDayFundStableValue, datePage.initialFundFree)
        formatValue(initialOtherFundDayValue, datePage.initialFundManage)
        formatValue(extraBuyDayValue, datePage.extraBuy)
        formatValue(dailyBuyDayValue, datePage.dailyBuy)
        formatValue(extraSellDayValue, datePage.extraSell)
        formatValue(dailySellDayValue, datePage.dailySell)
        formatValue(feeDayValue, datePage.feePayed)
        formatValue(volumesDayValue, datePage.volumes)

        If (datePage.apy = 0) Then
            apyDayValue.Text = "---"
        Else
            apyDayValue.Text = (datePage.apy).ToString("#,##0.00") & " %"

            apyDayValue.ForeColor = earnDayValue.ForeColor
        End If
    End Sub


    Private Sub DataPageDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            datePage = CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Journal.DayCounterModel).read(fileName)

            refreshJournalValue()
            refreshDailyOrderGrid()
        Catch ex As Exception
            MessageBox.Show("Problem during open a file", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class