Option Explicit On
Option Compare Text




Public Class trackLogSettings

    Private Sub trackLogSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub everyChangeFile_TextChanged(sender As Object, e As EventArgs) Handles everyChangeFile.TextChanged
        If IsNumeric(everyChangeFile.text) Then
            If (everyChangeFile.Value > 0) Then
                numberRegistrations.text = "0"
            End If
        End If
    End Sub

    Private Sub numberRegistrations_TextChanged(sender As Object, e As EventArgs) Handles numberRegistrations.TextChanged
        If IsNumeric(numberRegistrations.Text) Then
            If (numberRegistrations.Value > 0) Then
                everyChangeFile.text = "0"
            End If
        End If
    End Sub

End Class
