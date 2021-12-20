Option Compare Text
Option Explicit On

Public Class NetworkInformation
    Private Sub NetworkInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NetworkInformation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            netWorkCreationDate.Width = Me.Width - 270
        Catch ex As Exception
        End Try
    End Sub
End Class
