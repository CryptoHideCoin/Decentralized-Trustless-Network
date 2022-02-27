Option Compare Text
Option Explicit On

' ****************************************
' File: Change Certificate
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************



Public Class ChangeCertificate

    Public Event Confirm()
    Public Event Cancel()

    ''' <summary>
    ''' This property get/let the certificate
    ''' </summary>
    ''' <returns></returns>
    Public Property certificate As String
        Get
            Return newCertificate.value
        End Get
        Set(value As String)
            newCertificate.value = value
        End Set
    End Property



    Private Sub proceedButton_Click(sender As Object, e As EventArgs) Handles proceedButton.Click
        RaiseEvent Confirm()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        RaiseEvent Cancel()
    End Sub

    Private Sub checkDataValue()
        Dim proceed As Boolean = True

        If proceed Then proceed = (newCertificate.value.Trim.ToString.Length > 0)

        proceedButton.Enabled = proceed
    End Sub

    Private Sub newCertificate_TextChanged() Handles newCertificate.TextChanged
        checkDataValue()
    End Sub

    Private Sub keyPrivateWallet_TextChanged()
        checkDataValue()
    End Sub

End Class
