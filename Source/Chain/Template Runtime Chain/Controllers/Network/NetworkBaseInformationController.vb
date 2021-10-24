Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: api/{GUID service}/network/informationBaseController
    <Route("NetworkApi")>
    Public Class informationBaseController

        Inherits ApiController


        Public Function GetValue() As Models.Network.InfoNetworkBaseModel
            Dim result As New Models.Network.InfoNetworkBaseModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity
                        result.networkCreationDate = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimestamp(AreaCommon.state.runtimeState.activeNetwork.networkCreationDate).ToUniversalTime)
                        result.name = AreaCommon.state.runtimeState.activeNetwork.networkName.value
                        result.genesisPublicAddress = AreaCommon.state.runtimeState.activeNetwork.genesisPublicAddress
                        result.integrityTransactionChain.coordinate = AreaCommon.state.runtimeState.activeNetwork.networkName.coordinate
                        result.integrityTransactionChain.hash = AreaCommon.state.runtimeState.activeNetwork.networkName.hash

                        result.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, result.getHash())
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function

    End Class

End Namespace
