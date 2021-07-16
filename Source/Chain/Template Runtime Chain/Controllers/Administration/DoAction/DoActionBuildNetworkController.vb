Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models




Namespace Controllers


    ' GET: api/{GUID service}/administration/doAction/buildNetwork
    <Route("AdministrationDoActionApi")>
    Public Class buildNetworkController

        Inherits ApiController





        Public Function GetValue(ByVal dataNetwork As CHCProtocolLibrary.AreaCommon.Models.Network.BuildNetworkModel, ByVal signature As String) As General.RemoteResponse
            Dim result As New General.RemoteResponse

            Try
                result.requestTime = Now

                If (AreaCommon.state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If AreaSecurity.checkSignature(dataNetwork.getHash, signature) Then
                        For Each item In AreaCommon.state.serviceState.listAvailableCommand
                            If (item = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.buildNetwork) Then
                                AreaCommon.state.serviceState.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.buildNetwork

                                AreaCommon.state.serviceState.listAvailableCommand.Clear()
                                AreaCommon.state.serviceState.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cancelCurrentAction)

                                AreaCommon.state.keys.addNew(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity, dataNetwork.publicAddressGenesis, dataNetwork.privateKeyRAWGenesis)

                                AreaData.dataNetwork = dataNetwork

                                Dim ais As New Threading.Thread(AddressOf AreaData.buildNetwork)

                                ais.Start()

                                result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete

                                Exit For
                            End If
                        Next

                        If (result.responseStatus <> General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                            result.responseStatus = General.RemoteResponse.EnumResponseStatus.commandNotAllowed
                        End If
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