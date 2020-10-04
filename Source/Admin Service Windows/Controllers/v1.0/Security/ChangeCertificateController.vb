Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCBasicCryptographyLibrary.AreaEngine
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
        Public Function PutValue(<FromBody()> ByVal value As AreaCommon.Models.Security.changeCertificate) As String

            Try

                If (AreaCommon.state.currentApplication = EnumStateApplication.inRunning) Then

                    If AreaSecurity.checkClientCertification(value.currentCertificate) Then

                        Dim address As String = WalletAddressEngine.SingleWallet.cleanAddress(AreaCommon.settings.data.walletPublicAddress)

                        If Encryption.Base58Signature.verifySignature(value.newCertificate, address, value.signature) Then
                            If AreaSecurity.changeCertificate(value) Then
                                Return "Service Error"
                            Else
                                Return ""
                            End If
                        Else
                            Return "Wrong Signature"
                        End If

                    Else
                        Return "Service Unauthorized"
                    End If

                Else
                    Return "Service Offline"
                End If

            Catch ex As Exception
                Return "Service Error"
            End Try

        End Function


    End Class


End Namespace
