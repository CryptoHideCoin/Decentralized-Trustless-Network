Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace Controllers

    ' GET: api/{GUID service}/notify/requestController
    <Route("NotifyRequestApi")>
    Public Class requestController

        Inherits ApiController


        ''' <summary>
        ''' This API (put method) provide to notify a request by another masternode
        ''' </summary>
        ''' <returns></returns>
        Public Function PutValue(<FromBody()> ByVal value As Models.Network.NotifyModel) As General.RemoteResponse
            Dim result As New General.RemoteResponse
            Dim proceed As Boolean = True
            Dim toString As String
            Dim toHash As String
            Dim privateKey As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If proceed Then
                    If (AreaCommon.state.service <> Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline

                        proceed = False
                    End If
                End If

                If proceed Then
                    If Not AreaSecurity.checkSignature(value.getHash, value.signature, value.publicAddress) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                End If

                If proceed Then
                    If AreaCommon.flow.addNewRequest(value.requestHash, value.requestCode, CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT, False,, False, value.publicAddress) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete
                    Else
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                        result.errorDescription = "Internal Error"
                    End If

                    result.integrityTransactionChain = AreaCommon.state.serviceState.integrityTransactionChain
                    result.masterNodePublicAddress = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress

                    result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
                End If

            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            toString = General.RemoteResponse.determinateStringObject(result)
            toHash = HashSHA.generateSHA256(toString)

            result.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKey, toHash)

            Return result
        End Function

    End Class

End Namespace