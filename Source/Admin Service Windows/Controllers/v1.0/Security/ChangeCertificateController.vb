Imports System.Web.Http



Namespace Controllers


    ' GET: api/v1.0/Security/ChangeCertificate
    ''' <summary>
    ''' This API permit to change a certificate of a Admin service
    ''' </summary>
    <Route("SecurityApi")>
    Public Class ChangeCertificateController

        Inherits ApiController





        ' PUT api/v1.0/security/changeCertificate
        Public Sub PutValue(<FromBody()> ByVal value As AreaCommon.Models.Security.changeCertificate)

            Try

                If (AreaCommon.state.currentApplication = AppState.enumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(value.currentCertificate) Then

                        Dim address As String = CHCProtocol.AreaWallet.Support.WalletAddressEngine.SingleWallet.cleanAddress(AreaCommon.settings.data.walletPublicAddress)

                        If CHCEngine.Encryption.Base58Signature.verifySignature(value.newCertificate, address, value.signature) Then

                            AreaSecurity.changeCertificate(value)

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub


    End Class


End Namespace
