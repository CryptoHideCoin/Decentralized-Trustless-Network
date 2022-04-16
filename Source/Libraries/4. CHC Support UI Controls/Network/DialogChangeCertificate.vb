Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response

' ****************************************
' File: Dialog Change Certificate
' Release Engine: 1.0 
' 
' Date last successfully test: 06/10/2021
' ****************************************







Public Class DialogChangeCertificate

    Private Property _Certificate As String

    ''' <summary>
    ''' This property get/let certificate value
    ''' </summary>
    ''' <returns></returns>
    Public Property certificate As String
        Get
            Return _Certificate
        End Get
        Set(value As String)
            _Certificate = value

            certificateChange.certificate = ""
        End Set
    End Property
    Public Property urlService As String
    Public Property dataPath As String = ""
    Public Property serviceId As String = ""
    Public Property privateKey As String = ""

    ''' <summary>
    ''' This event's method provide to manage a cancel of a CertificateChange
    ''' </summary>
    Private Sub certificateChange_Cancel() Handles certificateChange.Cancel
        DialogResult = DialogResult.Cancel
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a confirm a certificateChange
    ''' </summary>
    Private Sub certificateChange_Confirm() Handles certificateChange.Confirm
        Try
            Dim url As String = ""
            Dim changeData As New CHCProtocolLibrary.AreaCommon.Models.Security.changeCertificate
            Dim webSender As New ProxyWS(Of CHCProtocolLibrary.AreaCommon.Models.Security.changeCertificate)

            changeData.currentCertificate = _Certificate
            changeData.newCertificate = certificateChange.certificate
            'changeData.typeCommunication = CHCProtocolLibrary.AreaCommon.Models.Security.enumOfService.client

            changeData.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKey, _Certificate)

            webSender.url = urlService
            webSender.data = changeData

            If (webSender.sendData("PUT").Length = 0) Then

                Dim response As RemoteResponse = webSender.remoteResponse

                Select Case response.responseStatus
                    Case RemoteResponse.EnumResponseStatus.responseComplete
                        MessageBox.Show("Certificate Upgrade", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        _Certificate = certificateChange.certificate

                        DialogResult = DialogResult.OK
                    Case RemoteResponse.EnumResponseStatus.systemOffline
                        MessageBox.Show("System Offline", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        DialogResult = DialogResult.Cancel
                    Case RemoteResponse.EnumResponseStatus.missingAuthorization
                        MessageBox.Show("Missing Authorization", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        DialogResult = DialogResult.Cancel
                    Case RemoteResponse.EnumResponseStatus.inError
                        MessageBox.Show("Server Error: " & response.errorDescription, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        DialogResult = DialogResult.Cancel
                End Select
            Else
                MessageBox.Show("An error occurrent during certificateChange_Confirm " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                DialogResult = DialogResult.Cancel
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateChange_Confirm " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

            DialogResult = DialogResult.Cancel
        End Try
    End Sub

End Class