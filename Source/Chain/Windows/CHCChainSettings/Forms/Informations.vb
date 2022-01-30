Option Compare Text
Option Explicit On



Public Class informations

    Private Sub Informations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        releaseLabel.Text = Application.ProductVersion
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Hide()
    End Sub

End Class