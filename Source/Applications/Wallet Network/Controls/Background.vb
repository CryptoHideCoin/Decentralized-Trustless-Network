Option Compare Text
Option Explicit On



Public Class Background

    Private Sub Background_Load(sender As Object, e As EventArgs) Handles Me.Load
        releaseApplication.Text = "Release: " & Application.ProductVersion
    End Sub

End Class
