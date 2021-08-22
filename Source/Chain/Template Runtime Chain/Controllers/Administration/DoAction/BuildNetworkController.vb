Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/{GUID service}/administration/doAction/buildNetwork
    <Route("AdministrationDoActionApi")>
    Public Class BuildNetworkController

        Inherits ApiController





        Public Function PutValue(ByVal signature As String, <FromBody()> ByVal value As Models.Network.BuildNetworkModel) As General.RemoteResponse
            Dim result As New General.RemoteResponse
            Dim proceed As Boolean = True

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If proceed Then
                    If (AreaCommon.state.service <> Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline

                        proceed = False
                    End If
                End If

                If proceed Then
                    If Not AreaSecurity.checkSignature(signature) Or
                       Not AreaSecurity.checkSignature(value.getHash, value.signature, TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                End If

                If proceed Then
                    value.primaryAsset.deCodeSymbol()

                    For Each item In AreaCommon.state.serviceState.listAvailableCommand
                        If (item = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.buildNetwork) Then
                            AreaCommon.state.serviceState.currentRunCommand = Models.Administration.EnumActionAdministration.buildNetwork

                            AreaCommon.state.serviceState.listAvailableCommand.Clear()
                            AreaCommon.state.serviceState.listAvailableCommand.Add(Models.Administration.EnumActionAdministration.cancelCurrentAction)

                            AreaData.dataNetwork = value

                            Dim ais As New Threading.Thread(AddressOf AreaData.buildNetwork)

                            ais.Start()

                            result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete

                            Exit For
                        End If
                    Next

                    If (result.responseStatus <> General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.commandNotAllowed
                    End If
                End If
            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function


    End Class


End Namespace