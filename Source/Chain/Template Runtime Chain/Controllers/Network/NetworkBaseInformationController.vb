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

        ''' <summary>
        ''' This method provide to get a value of Info Network Base
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As Models.Network.InfoNetworkBaseModel
            Dim result As New Models.Network.InfoNetworkBaseModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity
                        result.networkCreationDate = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimestamp(AreaCommon.state.runtimeState.activeNetwork.networkCreationDate).ToUniversalTime)
                        result.name = AreaCommon.state.runTimeState.activeNetwork.networkName.value
                        result.specialEnvironment = AreaCommon.state.runTimeState.activeNetwork.envinronment.value
                        result.genesisPublicAddress = AreaCommon.state.runtimeState.activeNetwork.genesisPublicAddress
                        result.integrityTransactionChain.coordinate = AreaCommon.state.runTimeState.activeNetwork.networkName.coordinate
                        result.integrityTransactionChain.progressiveHash = AreaCommon.state.runTimeState.activeNetwork.networkName.progressiveHash
                        result.integrityTransactionChain.hash = AreaCommon.state.runTimeState.activeNetwork.networkName.hash
                        result.integrityTransactionChain.registrationTimeStamp = AreaCommon.state.runTimeState.activeNetwork.networkName.registrationTimeStamp

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
