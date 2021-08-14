Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Communication





Public Class ChangeCertificate

    Private Property _Certificate As String


    Public Property certificate As String
        Get
            Return _Certificate
        End Get
        Set(value As String)
            _Certificate = value

            _certificateChange.certificate = value
        End Set
    End Property
    Public Property urlService() As String
    Public Property dataPath As String = ""


    Private Sub certificateChange_Cancel() Handles _certificateChange.Cancel
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub certificateChange_Confirm() Handles _certificateChange.Confirm
        Try
            Dim url As String = ""
            Dim changeData As New AreaCommon.Models.Security.changeCertificate
            Dim webSender As New ProxyWS(Of AreaCommon.Models.Security.changeCertificate)

            changeData.currentCertificate = _Certificate
            changeData.newCertificate = _certificateChange.certificate
            changeData.typeCommunication = AreaCommon.Models.Security.enumOfService.client

            changeData.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(_certificateChange.privateKey, _certificateChange.certificate)

            webSender.url = url
            webSender.data = changeData

            If (webSender.sendData("PUT") = "") Then
                MessageBox.Show("Certificate Upgrade", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Certificate = _certificateChange.certificate
            Else
                MessageBox.Show("An error occurrent during certificateChange_Confirm " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateChange_Confirm " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        DialogResult = DialogResult.OK
    End Sub

    Private Sub certificateChange_Load(sender As Object, e As EventArgs) Handles _certificateChange.Load

    End Sub

    Private Sub certificateChange_GetWalletID(ByRef value As String) Handles _certificateChange.GetWalletID
        Try
            Dim frm As New _KeyStoreManager

            frm.dataPath = IO.Path.Combine(dataPath, "Settings")

            If (frm.ShowDialog = DialogResult.OK) Then
                value = frm.addressValue
            End If

            frm.Close()
            frm.Dispose()

            frm = Nothing
        Catch ex As Exception
            MessageBox.Show("Error during a certificateChange_GetWalletID - " & Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class