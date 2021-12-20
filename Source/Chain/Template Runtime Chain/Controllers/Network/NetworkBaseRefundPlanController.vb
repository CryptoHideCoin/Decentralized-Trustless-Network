Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: api/{GUID service}/network/refundPlanController
    <Route("NetworkApi")>
    Public Class refundPlanController

        Inherits ApiController


        Public Function GetValue() As Models.Network.InfoRefundPlanModel
            Dim result As New Models.Network.InfoRefundPlanModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity
                        result.integrityTransactionChain.coordinate = AreaCommon.state.runTimeState.activeNetwork.refundPlan.coordinate
                        result.integrityTransactionChain.hash = AreaCommon.state.runTimeState.activeNetwork.refundPlan.hash
                        result.integrityTransactionChain.progressiveHash = AreaCommon.state.runTimeState.activeNetwork.refundPlan.progressiveHash
                        result.integrityTransactionChain.registrationTimeStamp = AreaCommon.state.runTimeState.activeNetwork.refundPlan.registrationTimeStamp
                        result.value = AreaCommon.state.runtimeState.activeNetwork.refundPlan.value

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