Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: api/{GUID service}/chain/chainPageDataController
    <Route("ChainApi")>
    Public Class ChainPageDataController

        Inherits ApiController


        ''' <summary>
        ''' This method provide to get a page of a chain
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue(ByVal pageNumber As Integer) As Models.Chain.Response.ChainListDataPageModel
            Dim result As New Models.Chain.Response.ChainListDataPageModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity
                        result.integrityTransactionChain.coordinate = "---"
                        result.integrityTransactionChain.hash = "---"
                        result.integrityTransactionChain.progressiveHash = "---"
                        result.integrityTransactionChain.registrationTimeStamp = 0

                        result.value.pageNumber = pageNumber
                        result.value.pageDataList = AreaCommon.state.runTimeState.getDataPageChainByNumber(pageNumber)

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
