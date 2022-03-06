Option Compare Text
Option Explicit On




Public Class RefundPlanInformation

    Public Property symbolCurrency As String = ""

    ''' <summary>
    ''' This method provide to load a Symbol
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Function loadDataIntoGrid(ByVal data As CHCProtocolLibrary.AreaCommon.Models.Network.RefundItem) As Boolean
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(data.recipient)
            rowItem.Add(data.description)
            rowItem.Add(data.fixValue)
            rowItem.Add(data.percentageValue)

            If (data.fixValue <> 0) Then
                rowItem.Add(data.fixValue & " " & symbolCurrency)
            Else
                rowItem.Add(data.percentageValue & " %")
            End If

            refundPlanDataGrid.Rows.Add(rowItem.ToArray)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error during loadDataIntoGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Sub RefundPlanInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refundPlanDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        refundPlanDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        refundPlanDataGrid.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
    End Sub

    Private Sub RefundPlanInformation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            code.Width = Me.Width - 72
        Catch ex As Exception
        End Try
        Try
            refundPlanDataGrid.Width = Me.Width - 25
        Catch ex As Exception
        End Try
        Try
            refundPlanDataGrid.Height = Me.Height - 64
        Catch ex As Exception
        End Try
    End Sub

End Class
