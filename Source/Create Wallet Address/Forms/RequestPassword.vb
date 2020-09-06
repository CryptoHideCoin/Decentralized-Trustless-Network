Public Class RequestPassword

    Public PasswordKEY As String = ""



    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click

        PasswordKEY = passwordTextBox.Text

        DialogResult = DialogResult.OK

        Me.Close()

    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click

        Me.Close()

    End Sub

    Private Sub useKey_CheckedChanged(sender As Object, e As EventArgs)

        If useKey.Checked Then

            passwordTextBox.Enabled = True
            passwordTextBox.Select()

            showCharacter.Enabled = True

        Else

            passwordTextBox.Enabled = False
            showCharacter.Enabled = False
            passwordTextBox.Text = ""

        End If

        RefreshOKButton()

    End Sub

    Private Sub RefreshOKButton()

        If useKey.Checked Then

            ok.Enabled = (passwordTextBox.Text.Length > 0)

        Else

            ok.Enabled = True

        End If

    End Sub

    Private Sub passwordTextBox_TextChanged(sender As Object, e As EventArgs) Handles passwordTextBox.TextChanged

        RefreshOKButton()

    End Sub

    Private Sub showCharacter_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub showCharacter_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacter.MouseDown

        passwordTextBox.PasswordChar = ""

    End Sub

    Private Sub showCharacter_MouseUp(sender As Object, e As MouseEventArgs) Handles showCharacter.MouseUp

        passwordTextBox.PasswordChar = "*"

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
