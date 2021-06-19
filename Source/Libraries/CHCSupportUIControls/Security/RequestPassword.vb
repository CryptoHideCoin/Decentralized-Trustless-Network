Option Compare Text
Option Explicit On


Public Class RequestPassword

    Public accessKey As String = ""



    Private Sub RefreshOKButton()
        confirmButton.Enabled = (passwordTextBox.Text.Length > 0)
    End Sub

    Private Sub showCharacterButton_MouseUp(sender As Object, e As MouseEventArgs) Handles showCharacterButton.MouseUp
        passwordTextBox.PasswordChar = "*"
    End Sub

    Private Sub showCharacterButton_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacterButton.MouseDown
        passwordTextBox.PasswordChar = ""
    End Sub

    Private Sub passwordTextBox_TextChanged(sender As Object, e As EventArgs) Handles passwordTextBox.TextChanged
        RefreshOKButton()
    End Sub

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If (accessKey.Length > 0) Then
            If (accessKey.CompareTo(passwordTextBox.Text) <> 0) Then
                MessageBox.Show("The Authorization Key is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return
            End If
        End If

        accessKey = passwordTextBox.Text
        DialogResult = DialogResult.OK

        Me.Close()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

End Class