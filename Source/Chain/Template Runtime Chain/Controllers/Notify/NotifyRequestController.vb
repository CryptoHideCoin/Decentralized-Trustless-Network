Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace Controllers

    ' GET: API/{GUID service}/Notify/RequestController
    <Route("NotifyRequestApi")>
    Public Class RequestController

        Inherits ApiController


        ''' <summary>
        ''' This API (put method) provide to notify a request by another masternode
        ''' </summary>
        ''' <returns></returns>
        Public Function putValue(<FromBody()> ByVal value As Models.Network.NotifyModel) As General.RemoteResponse
            Dim result As New General.RemoteResponse
            Dim proceed As Boolean = True
            Dim privateKey As String = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).privateKey

            Try
                AreaCommon.log.track("RequestController.putValue", "Begin")

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
                    If Not AreaSecurity.checkNetwork(value) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.wrongNetwork

                        proceed = False
                    End If
                End If
                If proceed Then
                    If AreaCommon.state.runtimeState.getDataNode(value.publicAddress).ipAddress Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                End If
                If proceed Then
                    If AreaCommon.flow.addNewRequestNotify(value.requestHash, value.type, CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT, value.publicAddress) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete
                    Else
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                        result.errorDescription = "Internal Error"
                    End If

                    result.integrityTransactionChain = AreaCommon.state.currentService.integrityTransactionChain
                    result.masterNodePublicAddress = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.identity).publicAddress

                    result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
                End If

                AreaCommon.log.track("RequestController.putValue", "Complete")
            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("RequestController.putValue", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            Try
                result.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKey, value.getHash())
            Catch ex As Exception
            End Try

            Return result
        End Function

    End Class

End Namespace