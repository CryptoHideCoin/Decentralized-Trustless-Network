Option Explicit On
Option Compare Text





Public Class ChangeCertificate

    Public certificate As String = ""
    Public publicAddress As String = ""
    Public privateKey As String = ""


    Private Sub proceedButton_Click(sender As Object, e As EventArgs) Handles proceedButton.Click

        certificate = newCertificate.Text
        privateKey = privateKeyValue.Text

        DialogResult = DialogResult.OK

        Close()

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        DialogResult = DialogResult.Cancel

        Close()

    End Sub

    Private Sub ChangeCertificate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub checkDataValue()

        Dim proceed As Boolean = True

        If proceed Then proceed = (newCertificate.Text.Trim.ToString.Length > 0)
        If proceed Then proceed = (privateKeyValue.Text.Trim.ToString.Length > 0)

        proceedButton.Enabled = proceed

    End Sub

    Private Sub newCertificate_TextChanged(sender As Object, e As EventArgs) Handles newCertificate.TextChanged

        checkDataValue()

    End Sub

    Private Sub privateKeyValue_TextChanged(sender As Object, e As EventArgs) Handles privateKeyValue.TextChanged

        checkDataValue()

    End Sub


End Class