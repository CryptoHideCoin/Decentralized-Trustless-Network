Option Compare Text
Option Explicit On

' ****************************************
' File: Request Password
' Release Engine: 1.0 
' 
' Date last successfully test: 06/10/2021
' ****************************************









Public Class RequestPassword

    Public Property accessKey As String = ""


    ''' <summary>
    ''' This method provide to refresh OK button
    ''' </summary>
    Private Sub RefreshOKButton()
        confirmButton.Enabled = (passwordTextBox.Text.Length > 0)
    End Sub


    ''' <summary>
    ''' This event's method provide to manage MouseUp on Show Character Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub showCharacterButton_MouseUp(sender As Object, e As MouseEventArgs) Handles showCharacterButton.MouseUp
        passwordTextBox.PasswordChar = "*"
    End Sub
    ''' <summary>
    ''' This event's method provide to manage MouseDown a showCharacterButton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub showCharacterButton_MouseDown(sender As Object, e As MouseEventArgs) Handles showCharacterButton.MouseDown
        passwordTextBox.PasswordChar = ""
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a TextChanged a Password Text Box
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub passwordTextBox_TextChanged(sender As Object, e As EventArgs) Handles passwordTextBox.TextChanged
        RefreshOKButton()
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a click on confirmButton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
    ''' <summary>
    ''' This event's method provide to manage a click on cancelButton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

End Class