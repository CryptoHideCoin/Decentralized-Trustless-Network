Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: api/{GUID service}/network/primaryAssetController
    <Route("NetworkApi")>
    Public Class primaryAssetController

        Inherits ApiController


        ''' <summary>
        ''' This method provide to get a value of Primary Asset
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As Models.Network.InfoAssetModel
            Dim result As New Models.Network.InfoAssetModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity
                        result.integrityTransactionChain.coordinate = AreaCommon.state.runTimeState.activeNetwork.primaryAssetData.coordinate
                        result.integrityTransactionChain.hash = AreaCommon.state.runTimeState.activeNetwork.primaryAssetData.hash
                        result.integrityTransactionChain.progressiveHash = AreaCommon.state.runTimeState.activeNetwork.primaryAssetData.progressiveHash
                        result.integrityTransactionChain.registrationTimeStamp = AreaCommon.state.runTimeState.activeNetwork.primaryAssetData.registrationTimeStamp
                        result.value = AreaCommon.state.runTimeState.activeNetwork.primaryAssetData.value

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