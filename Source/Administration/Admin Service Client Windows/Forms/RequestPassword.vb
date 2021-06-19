Option Compare Text
Option Explicit On


Public Class RequestPassword

    Public accessKey As String = ""



    Private Sub RefreshOKButton()
        If useKeyCheck.Checked Then
            confirmButton.Enabled = (passwordTextBox.Text.Length > 0)
        Else
            confirmButton.Enabled = True
        End If
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
        accessKey = passwordTextBox.Text

        DialogResult = DialogResult.OK

        Me.Close()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

    Private Sub useKeyCheck_CheckedChanged(sender As Object, e As EventArgs) Handles useKeyCheck.CheckedChanged
        If useKeyCheck.Checked Then
            passwordTextBox.Enabled = True

            passwordTextBox.Select()

            showCharacterButton.Enabled = True

        Else
            passwordTextBox.Enabled = False
            showCharacterButton.Enabled = False
            passwordTextBox.Text = ""
        End If

        RefreshOKButton()
    End Sub

    Private Sub RequestPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class