Option Compare Text
Option Explicit On




Public Class LedgerPage

    Public Event ShowTransaction(ByVal id As Integer)
    Public Event ChangeOrder()
    Public Event ChangeBlock(ByVal value As String)


    ''' <summary>
    ''' This method provide to reset a content of a grid
    ''' </summary>
    ''' <returns></returns>
    Public Function resetGrid() As Boolean
        pageDataGrid.Rows.Clear()

        Return True
    End Function

    ''' <summary>
    ''' This method provide to add a New Row
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    Public Function addNewRow(ByRef item As CHCProtocolLibrary.AreaCommon.Models.Ledger.SingleTransactionLedger) As Boolean
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(item.id.ToString)
            rowItem.Add(item.registrationTimeStamp.ToString())
            rowItem.Add(item.type)
            rowItem.Add(item.requesterPublicAddress.Substring(0, 7) & "..." & Strings.Right(item.requesterPublicAddress, 5))
            rowItem.Add(item.approverPublicAddress.Substring(0, 7) & "..." & Strings.Right(item.approverPublicAddress, 5))
            rowItem.Add(item.currentHash)
            rowItem.Add(item.progressiveHash)

            pageDataGrid.Rows.Add(rowItem.ToArray)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error during loadDataIntoGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Sub LedgerPage_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pageDataGrid.Width = Me.Width - 10
    End Sub

    Private Sub pageDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pageDataGrid.CellContentClick
        If e.RowIndex = -1 Then
            RaiseEvent ChangeOrder()

            Return
        End If

        If e.ColumnIndex = 0 Then
            RaiseEvent ShowTransaction(pageDataGrid.Rows.Item(e.RowIndex).Cells(0).Value)
        End If
    End Sub

    ''' <summary>
    ''' This method provide to separate a field of block
    ''' </summary>
    ''' <returns></returns>
    Public Function initBlock(ByVal value As String) As Boolean
        Try
            If value.Length = 0 Then Return False

            Dim elements() = value.Split("-")

            ledgerInitial.Text = elements(0)
            volumeValue.Text = elements(1)
            blockValue.Text = elements(2)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error during initBlock " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Sub changeBlockButton_Click(sender As Object, e As EventArgs) Handles changeBlockButton.Click
        If Not IsNumeric(blockValue.Text) Then
            Beep()

            Return
        End If
        If Not IsNumeric(volumeValue.Text) Then
            Beep()

            Return
        End If

        RaiseEvent ChangeBlock(ledgerInitial.Text & "-" & volumeValue.Text & "-" & blockValue.Text)
    End Sub

End Class
