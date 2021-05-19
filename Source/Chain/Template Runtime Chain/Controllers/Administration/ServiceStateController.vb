Imports System.Web.Http

Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature


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
                    If verifySignature(certificate, AreaCommon.state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicWalletID, signature) Then

                        Return AreaCommon.state.serviceState

                    Else
                        result.unAuthorized = True
                    End If
                Else
                    result.offline = True
                End If
            Catch ex As Exception
                result.error = True
                result.offline = True
                result.errorDescription = "503 - Generic Error"
            End Try

            result.unAuthorized = False
            result.responseTime = Now

            Return result

        End Function


    End Class


End Namespace