Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: api/{GUID service}/chain/chainTermsAndConditionsController
    <Route("ChainApi")>
    Public Class ChainTermsAndConditionsController

        Inherits ApiController




        ''' <summary>
        ''' This method provide to get a Terms and Conditions chain
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue(ByVal name As String) As Models.Chain.Queries.ChainTermsAndConditionsModel
            Dim result As New Models.Chain.Queries.ChainTermsAndConditionsModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity

                        With AreaCommon.state.runTimeState.chainByName(name).termsAndConditions
                            result.value.content = .value

                            If (.coordinate.Length > 0) Then
                                result.integrityTransactionChain.coordinate = .coordinate
                                result.integrityTransactionChain.hash = .hash
                                result.integrityTransactionChain.progressiveHash = .progressiveHash
                                result.integrityTransactionChain.registrationTimeStamp = .registrationTimeStamp
                            Else
                                result.integrityTransactionChain.coordinate = "(not set)"
                                result.integrityTransactionChain.hash = "(not set)"
                                result.integrityTransactionChain.progressiveHash = "(not set)"
                                result.integrityTransactionChain.registrationTimeStamp = 0
                            End If
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