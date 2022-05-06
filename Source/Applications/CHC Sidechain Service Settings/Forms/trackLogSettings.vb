Option Explicit On
Option Compare Text




Public Class trackLogSettings

    Private Sub trackLogSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        If trackConfiguration.SelectedIndex < 0 Then
            MessageBox.Show("Select the track configuration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return
        End If

        DialogResult = DialogResult.OK
    End Sub

End Class
