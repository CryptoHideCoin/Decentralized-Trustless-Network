Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: api/{GUID service}/network/generalConditionsController
    <Route("NetworkApi")>
    Public Class generalConditionsController

        Inherits ApiController

        ''' <summary>
        ''' This method provide to return a general condition element
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As Models.Network.DocumentModel
            Dim result As New Models.Network.DocumentModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity
                        result.integrityTransactionChain.coordinate = AreaCommon.state.runTimeState.activeNetwork.generalConditions.coordinate
                        result.integrityTransactionChain.hash = AreaCommon.state.runTimeState.activeNetwork.generalConditions.hash
                        result.integrityTransactionChain.progressiveHash = AreaCommon.state.runTimeState.activeNetwork.generalConditions.progressiveHash
                        result.integrityTransactionChain.registrationTimeStamp = AreaCommon.state.runTimeState.activeNetwork.generalConditions.registrationTimeStamp
                        result.value = AreaCommon.state.runTimeState.activeNetwork.generalConditions.value

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