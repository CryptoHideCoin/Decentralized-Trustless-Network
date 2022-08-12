Option Compare Text
Option Explicit On


Public Class DataBot

    Public Property idReferement As String = ""


    Private Sub showTrade(ByRef trade As List(Of AreaCommon.Models.Bot.TradeModel), ByRef gridView As DataGridView)
        Try
            Dim rowItem As New ArrayList

            gridView.Rows.Clear()

            For Each item In trade
                rowItem.Clear()

                rowItem.Add(item.buy.id)
                rowItem.Add(item.sell.id)

                gridView.Rows.Add(rowItem.ToArray)

                gridView.Rows(gridView.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGray
            Next
        Catch ex As Exception
        End Try
    End Sub


    Private Sub mainTimer_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick
        Dim repeatProcedure As Boolean = True

        Do While repeatProcedure
            repeatProcedure = False

            Try
                If AreaState.bots.ContainsKey(idReferement) Then

                    With AreaState.bots(idReferement)
                        idValue.Text = idReferement
                        pairValue.Text = .data.pair
                        bootstrapInitialValue.Checked = .data.bootStrapInitial
                        bootstrapCompleteValue.Checked = .data.bootStrapComplete

                        If (.data.examTimeLimit > 0) Then
                            examLimitValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.data.examTimeLimit), True)
                        Else
                            examLimitValue.Text = "---"
                        End If

                        If (.data.timeStart > 0) Then
                            timeStartValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.data.timeStart), True)
                        Else
                            timeStartValue.Text = "---"
                        End If

                        If (.data.usedPlafond = 0) Then
                            plafondValue.Text = "---"
                        Else
                            plafondValue.Text = .data.usedPlafond.ToString("#,##0.00000") & " " & .data.pair.Split("-")(1)
                        End If
                        If .data.earn = 0 Then
                            earnValue.Text = "---"
                        Else
                            earnValue.Text = .data.earn.ToString("#,##0.00000") & " " & .data.pair.Split("-")(1)
                        End If

                        If (.data.lastBuyTime > 0) Then
                            lastBuyTimeValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.data.lastBuyTime), True)
                        Else
                            lastBuyTimeValue.Text = "---"
                        End If

                        If (.data.lastBuyValue = 0) Then
                            lastBuyValue.Text = "---"
                        Else
                            lastBuyValue.Text = .data.lastBuyValue.ToString("#,##0.00000") & " (" & .data.lastBuyChange.ToString("#,##0.00000") & ") " & .data.pair.Split("-")(1)
                        End If

                        showTrade(.data.tradeOpen, tradeOpenedDataView)
                        showTrade(.data.tradeClose, tradeClosedDataView)
                    End With

                End If
            Catch ex As Exception
                repeatProcedure = True
            End Try
        Loop

    End Sub

    Private Sub DataBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub openTrade(ByRef common As AreaCommon.Models.Pair.PairInformation, ByRef value As AreaCommon.Models.Bot.TradeModel)
        Dim item As New DataTrade

        item.data = value
        item.common = common

        item.Show()
    End Sub

    Private Sub tradeOpenedDataView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tradeOpenedDataView.CellContentClick
        If (e.ColumnIndex = 2) Then
            openTrade(AreaState.bots(idReferement).common, AreaState.bots(idReferement).data.tradeOpen.ElementAt(e.RowIndex))
        End If
    End Sub

    Private Sub tradeClosedDataView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tradeClosedDataView.CellContentClick
        If (e.ColumnIndex = 2) Then
            openTrade(AreaState.bots(idReferement).common, AreaState.bots(idReferement).data.tradeClose.ElementAt(e.RowIndex))
        End If
    End Sub
End Class