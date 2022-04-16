Option Compare Text
Option Explicit On

' ****************************************
' File: Configure path 
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************










Public Class ConfigurePath

    ''' <summary>
    ''' This property get/let the data path
    ''' </summary>
    ''' <returns></returns>
    Public Property dataPath As String
        Get
            Return localPathDataText.Text
        End Get
        Set(value As String)
            localPathDataText.Text = value
        End Set
    End Property


    Private Sub browseLocalPathButton_Click(sender As Object, e As EventArgs) Handles browseLocalPathButton.Click
        Try
            Dim path As String = localPathDataText.Text

            Dim dirName As String

            If (path.Trim().Length > 0) Then
                dirName = IO.Path.GetDirectoryName(localPathDataText.Text)
            Else
                dirName = ""
            End If

            Dim fileName As String = IO.Path.GetFileName(localPathDataText.Text)

            folderBrowserDialog.SelectedPath = dirName

            If (folderBrowserDialog.ShowDialog() = DialogResult.OK) Then
                localPathDataText.Text = folderBrowserDialog.SelectedPath
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during browseLocalPath_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles mainCancelButton.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        DialogResult = DialogResult.OK
    End Sub

End Class