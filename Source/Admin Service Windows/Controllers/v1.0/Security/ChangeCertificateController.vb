Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCProtocolLibrary.AreaCommon.Models.Settings



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

                If (AreaCommon.state.currentApplication = EnumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(value.currentCertificate) Then

                        Dim address As String = WalletAddressEngine.SingleWallet.cleanAddress(AreaCommon.settings.data.walletPublicAddress)

                        If CHCEngine.Encryption.Base58Signature.verifySignature(value.newCertificate, address, value.signature) Then

                            AreaSecurity.changeCertificate(value)

                        Else

                            Throw New ApplicationException("Wrong Signature")

                        End If

                    Else

                        Throw New ApplicationException("Service Unauthorized")

                    End If

                Else

                    Throw New ApplicationException("Service Offline")

                End If

            Catch ex As Exception

                Throw New ApplicationException("Service Error")

            End Try

        End Sub


    End Class


End Namespace
