Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon



Namespace Controllers

    ' GET: api/{GUID service}/chain/chainDataController
    <Route("ChainApi")>
    Public Class ChainDataController

        Inherits ApiController


        ''' <summary>
        ''' This method provide to get a main data of chain
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue(ByVal name As String) As Models.Chain.Response.ChainDataModel
            Dim result As New Models.Chain.Response.ChainDataModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity

                        With AreaCommon.state.runTimeState.chainByName(name)
                            result.integrityTransactionChain.coordinate = .name.coordinate
                            result.integrityTransactionChain.hash = .name.hash
                            result.integrityTransactionChain.progressiveHash = .name.progressiveHash
                            result.integrityTransactionChain.registrationTimeStamp = .name.registrationTimeStamp
                            result.information = .extractMinimalData()
                        End With

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
