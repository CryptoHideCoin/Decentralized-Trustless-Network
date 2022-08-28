Option Compare Text
Option Explicit On


Public Class SelectPath

    Public ReadOnly Property completePath As String
        Get
            Return IO.Path.Combine(dataPathValue.Text, tenantName.Text)
        End Get
    End Property

    Private Sub browsePath_Click(sender As Object, e As EventArgs) Handles browsePath.Click
        If (folderBrowseMain.ShowDialog() = DialogResult.OK) Then
            dataPathValue.Text = folderBrowseMain.SelectedPath
        End If
    End Sub

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If Not IO.Directory.Exists(dataPathValue.Text) Then
            MessageBox.Show("The path is not exist", "Error", MessageBoxButtons.OK)
        Else
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub dataPathValue_TextChanged(sender As Object, e As EventArgs) Handles dataPathValue.TextChanged
        confirmButton.Enabled = (dataPathValue.Text.Trim.Length > 0) And (tenantName.Text.Trim.Length > 0)
    End Sub

    Private Sub tenantName_TextChanged(sender As Object, e As EventArgs) Handles tenantName.TextChanged
        confirmButton.Enabled = (dataPathValue.Text.Trim.Length > 0) And (tenantName.Text.Trim.Length > 0)
    End Sub

End Class