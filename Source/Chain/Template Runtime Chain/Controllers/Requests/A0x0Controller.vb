Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace Controllers

    ' GET: api/{GUID service}/requests/a0x0Controller
    <Route("RequestApi")>
    Public Class a0x0Controller

        Inherits ApiController


        ''' <summary>
        ''' This API (get method) provide to return a request model A0x0 of a hashValue request
        ''' </summary>
        ''' <param name="hashValue"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal hashValue As String) As AreaProtocol.A0x0.RequestModel
            Dim engine As New AreaProtocol.A0x0.FileEngine
            Dim result As New AreaProtocol.A0x0.RequestModel
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then

                        engine.fileName = IO.Path.Combine(AreaCommon.paths.workData.currentVolume.requests, hashValue & ".request")

                        If engine.read() Then
                            result = engine.data
                        End If
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

        ''' <summary>
        ''' This API (put method) provide to set a model A0x0 of a hashValue request
        ''' </summary>
        ''' <returns></returns>
        Public Function PutValue(ByRef value As AreaProtocol.A0x0.RequestModel, ByVal ticketNumber As String) As CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse
            Dim result As New CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse
            Dim toString As String
            Dim toHash As String
            Dim privateKey As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

            result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
            result.IntegrityTransactionChain = AreaCommon.state.serviceState.IntegrityTransactionChain
            result.masterNodePublicAddress = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress
            result.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete
            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            toString = RemoteResponse.determinateStringObject(result)
            toHash = HashSHA.generateSHA256(toString)

            result.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKey, toHash)

            Return result
        End Function

    End Class

End Namespace