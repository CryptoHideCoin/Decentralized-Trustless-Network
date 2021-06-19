Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature




Namespace Controllers


    ' GET: api/{GUID service}/administration/doAction
    <Route("AdministrationApi")>
    Public Class doActionController

        Inherits ApiController





        Public Function GetValue(ByVal certificate As String, ByVal signature As String, ByVal action As AreaCommon.Models.Administration.AdministrationModel.enumActionAdministration) As General.RemoteResponse
            Dim result As New General.RemoteResponse

            Try
                result.requestTime = Now

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    If verifySignature(certificate, AreaCommon.state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicAddress, signature) Then

                        Select Case action
                            Case AreaCommon.Models.Administration.AdministrationModel.enumActionAdministration.verifyData

                            Case AreaCommon.Models.Administration.AdministrationModel.enumActionAdministration.requestNetworkConnection,
                                 AreaCommon.Models.Administration.AdministrationModel.enumActionAdministration.buildNetwork,
                                 AreaCommon.Models.Administration.AdministrationModel.enumActionAdministration.resumeSystemFirstNode

                                AreaCommon.state.queues.init(AreaCommon.paths.workData.internal, 1000, 3, AreaCommon.state.keys.Key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).privateKey)
                        End Select

                    Else
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = Now

            Return result

        End Function


    End Class


End Namespace