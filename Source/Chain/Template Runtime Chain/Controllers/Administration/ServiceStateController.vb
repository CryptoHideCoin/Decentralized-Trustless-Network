Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaCommon.Models.General



Namespace Controllers


    ' GET: api/{GUID service}/administration/serviceState
    <Route("AdministrationApi")>
    Public Class serviceStateController

        Inherits ApiController




        Public Function GetValue(ByVal certificate As String, ByVal signature As String) As AreaCommon.Models.Administration.AdministrationModel.ServiceStateResponse
            Dim result As New AreaCommon.Models.Administration.AdministrationModel.ServiceStateResponse

            Try
                result.requestTime = Now

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    If verifySignature(certificate, AreaCommon.state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicAddress, signature) Then
                        Return AreaCommon.state.serviceState
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = Now

            Return result

        End Function


    End Class


End Namespace