﻿Option Compare Text
Option Explicit On


Public Class Informations

    Private Sub Informations_Load(sender As Object, e As EventArgs) Handles Me.Load
        releaseLabel.Text = Application.ProductVersion

        usedPortValue.Text = AreaCommon.portNumber
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Hide()
    End Sub

End Class