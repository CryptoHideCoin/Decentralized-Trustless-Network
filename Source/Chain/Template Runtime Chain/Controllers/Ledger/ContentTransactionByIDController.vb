Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon
Imports CHCProtocolLibrary.AreaCommon.Models.Ledger




Namespace Controllers

    ' GET: api/{GUID service}/ledger/contentTransactionByIDController
    <Route("LedgerApi")>
    Public Class ContentTransactionByIDController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a Block's information
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue(ByVal transactionID As String) As BlockInformationResponseModel
            Dim result As New BlockInformationResponseModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity

                        With AreaCommon.state.ledger.getTransactionContent(transactionID)
                            result.value = .content

                            If (.fileNotFound Or .inError) Then
                                result.responseStatus = BaseRemoteResponse.EnumResponseStatus.commandNotAllowed
                            End If
                        End With

                        result.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKeyRAW, result.getHash())
                    Else
                        result.responseStatus = BaseRemoteResponse.EnumResponseStatus.systemOffline
                    End If
                Else
                    result.responseStatus = BaseRemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = BaseRemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function

    End Class

End Namespace
