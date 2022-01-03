Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: api/{GUID service}/chain/chainMasterNodesController
    <Route("ChainApi")>
    Public Class ChainMasternodesController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a page MasterNode
        ''' </summary>
        ''' <param name="value"></param>
        ''' <param name="pageIndex"></param>
        ''' <returns></returns>
        Private Function getPageMasterNode(ByRef value As List(Of Models.Chain.NodeComplete), ByVal pageIndex As Integer) As List(Of Models.Chain.NodeComplete)
            Try
                Dim result As New List(Of Models.Chain.NodeComplete)
                Dim recordStartIndex As Integer = ((pageIndex - 1) * 10) - 1

                If recordStartIndex < 0 Then recordStartIndex = 0

                If (recordStartIndex <= value.Count + 1) Then
                    For i As Integer = recordStartIndex To 10
                        If (i <= value.Count - 1) Then
                            result.Add(value.ElementAt(i))
                        Else
                            Return result
                        End If
                    Next
                End If

                Return result
            Catch ex As Exception
                Return New List(Of Models.Chain.NodeComplete)
            End Try
        End Function


        ''' <summary>
        ''' This method provide to get a Tokens Configuration chain
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue(ByVal pageIndex As Integer, ByVal name As String) As Models.Chain.Queries.ChainMasterNodeModel
            Dim result As New Models.Chain.Queries.ChainMasterNodeModel
            Dim privateKeyRAW As String
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.genesisOperation) Or
                       (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        privateKeyRAW = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

                        result.masterNodePublicAddress = AreaCommon.state.network.publicAddressIdentity

                        With AreaCommon.state.runTimeState.chainByName(name).storedNodeList
                            result.value = getPageMasterNode(.value, pageIndex)

                            result.integrityTransactionChain.coordinate = .coordinate
                            result.integrityTransactionChain.hash = .hash
                            result.integrityTransactionChain.progressiveHash = .progressiveHash
                            result.integrityTransactionChain.registrationTimeStamp = .registrationTimeStamp
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