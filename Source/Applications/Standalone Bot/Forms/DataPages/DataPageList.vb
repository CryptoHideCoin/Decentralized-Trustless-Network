Public Class DataPageList

    Private Sub DataPageList_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim rowItem As New ArrayList
        Dim dateFromFile As String = ""

        For Each fileName In AreaCommon.Engine.IO.getPageCounters()
            rowItem.Clear()

            dateFromFile = fileName.Replace(".CurrentCounterDay", "")
            dateFromFile = dateFromFile.Replace(AreaCommon.IO.dayCounterPath, "")
            dateFromFile = dateFromFile.Replace("\", "")

            rowItem.Add(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(dateFromFile).ToShortDateString)
            rowItem.Add(fileName)

            pageDataView.Rows.Add(rowItem.ToArray)
        Next
    End Sub

    Private Sub pageDataView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pageDataView.CellContentClick
        If (e.ColumnIndex = 2) Then
            If Not IsNothing(pageDataView.CurrentRow) Then
                Dim detail As DataPageDetail

                detail = New DataPageDetail

                detail.fileName = pageDataView.CurrentRow.Cells.Item(1).Value

                detail.Show()
            End If
        End If
    End Sub

End Class