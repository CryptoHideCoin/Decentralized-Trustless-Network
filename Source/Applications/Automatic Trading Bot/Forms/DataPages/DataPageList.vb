Public Class DataPageList

    Public Class SingleDataPage

        Public Property showDate As String = ""

        Public Property initialFund As String = "---"
        Public Property endFund As String = "---"
        Public Property increase As String = "---"
        Public Property earn As String = "---"
        Public Property power As String = "---"

        Public Property completeFileName As String = ""

    End Class

    Private Function getRowData(ByVal fileName As String, ByVal dataComplete As Boolean) As SingleDataPage
        Dim newData As New SingleDataPage

        newData.showDate = fileName.Replace(".CurrentCounterBlock", "")
        newData.showDate = newData.showDate.Replace(AreaCommon.IO.blockCounterPath, "")
        newData.showDate = newData.showDate.Replace("\", "")

        newData.showDate = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(newData.showDate).ToUniversalTime

        newData.completeFileName = fileName

        If dataComplete Then
            With CHCCommonLibrary.AreaEngine.DataFileManagement.Json.IOFast(Of AreaCommon.Models.Journal.BlockCounterModel).read(newData.completeFileName)
                If (.apy <> 0) Then
                    newData.earn = .apy.ToString("#,##0.00") & " %"
                End If

                If (.increasePerc <> 0) Then
                    newData.increase = .increasePerc.ToString("#,##0.00") & " %"
                End If

                If (.totalPower <> 0) Then
                    newData.power = .totalPower.ToString("#,##0.00")
                End If

                If (.initialFundFree + .initialFundManage <> 0) Then
                    newData.initialFund = (.initialFundFree + .initialFundManage).ToString("#,##0.00")
                End If

                If (.currentFund + .freeFund <> 0) Then
                    newData.endFund = (.currentFund + .freeFund).ToString("#,##0.00")
                End If
            End With
        End If

        Return newData
    End Function

    Private Sub showData(Optional ByVal dataComplete As Boolean = False)
        Dim rowItem As New ArrayList
        Dim rowData As SingleDataPage

        pageDataView.Rows.Clear()

        For Each fileName In AreaCommon.Engine.IO.getPageCounters()

            rowData = getRowData(fileName, dataComplete)

            rowItem.Clear()

            rowItem.Add(rowData.showDate)
            rowItem.Add(rowData.initialFund)
            rowItem.Add(rowData.endFund)
            rowItem.Add(rowData.increase)
            rowItem.Add(rowData.earn)
            rowItem.Add(rowData.power)
            rowItem.Add(rowData.completeFileName)

            pageDataView.Rows.Add(rowItem.ToArray)

            My.Application.DoEvents()
        Next
    End Sub

    Private Sub DataPageList_Load(sender As Object, e As EventArgs) Handles Me.Load
        showData()
    End Sub



    Private Sub pageDataView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pageDataView.CellContentClick
        If (e.ColumnIndex = pageDataView.Rows(e.RowIndex).Cells.Count - 1) Then
            If Not IsNothing(pageDataView.CurrentRow) Then
                Dim detail As DataPageDetail

                detail = New DataPageDetail

                detail.fileName = pageDataView.CurrentRow.Cells.Item(pageDataView.Rows(e.RowIndex).Cells.Count - 2).Value

                detail.Show()
            End If
        End If
    End Sub

    Private Sub pageDataView_MouseDown(sender As Object, e As MouseEventArgs) Handles pageDataView.MouseDown
    End Sub

    Private Sub ShowAllDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllDataToolStripMenuItem.Click
        showData(True)
    End Sub

End Class