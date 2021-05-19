Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCProtocolLibrary.AreaCommon.Models




Namespace Controllers


    ' GET: api/{GUID service}/security/changeCertificateController
    <Route("ServiceApi")>
    Public Class changeCertificateController

        Inherits ApiController




        Public Function PutValue(<FromBody()> ByVal value As AreaCommon.Models.Security.changeCertificate) As General.RemoteResponse

            Dim result As New General.RemoteResponse

            result.requestTime = Now

            Try

                If (AreaCommon.state.service = AreaCommon.Models.ServiceModel.InformationResponseModel.enumServiceState.started) Then

                    If AreaSecurity.checkClientCertification(value.currentCertificate) Then

                        Dim address As String = WalletAddressEngine.SingleWallet.cleanAddress(AreaCommon.state.information.adminPublicWalletID)

                        If Encryption.Base58Signature.verifySignature(value.newCertificate, address, value.signature) Then
                            If AreaSecurity.changeCertificate(value) Then
                                result.error = True
                                result.errorDescription = "Service Error"
                            End If
                        Else
                            result.error = True
                            result.errorDescription = "Wrong Signature"
                        End If
                    Else
                        result.error = True
                        result.errorDescription = "Service Unauthorized"
                    End If
                Else
                    result.error = True
                    result.offline = True
                    result.errorDescription = "Service Offline"
                End If

            Catch ex As Exception
                result.error = True
                result.errorDescription = "Service Error"
            End Try

            result.responseTime = Now

            Return result

        End Function


    End Class


End Namespace