Option Compare Text
Option Explicit On




Public Class RequestPassword

    Public PasswordKEY As String = ""




    Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
        PasswordKEY = passwordValue.Text

        DialogResult = DialogResult.OK

        Me.Close()
    End Sub

    Private Sub cancelValue_Click(sender As Object, e As EventArgs) Handles cancelValue.Click
        DialogResult = DialogResult.Cancel

        Me.Close()
    End Sub

    Private Sub useKeyCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles useKeyCheckBox.CheckedChanged
        If useKeyCheckBox.Checked Then
            passwordValue.Enabled = True
            passwordValue.Select()

            showCharacterValue.Enabled = True
        Else
            passwordValue.Enabled = False
            showCharacterValue.Enabled = False
            passwordValue.Text = ""
        End If

        refreshOKButton()
    End Sub

    Private Sub refreshOKButton()
        If useKeyCheckBox.Checked Then
            okButton.Enabled = (passwordValue.Text.Length > 0)
        Else
            okButton.Enabled = True
        End If
    End Sub

    Private Sub passwordValue_TextChanged(sender As Object, e As EventArgs) Handles passwordValue.TextChanged
        refreshOKButton()
    End Sub

    Private Sub showCharacterValue_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacterValue.MouseDown
        passwordValue.PasswordChar = ""
    End Sub

End Class