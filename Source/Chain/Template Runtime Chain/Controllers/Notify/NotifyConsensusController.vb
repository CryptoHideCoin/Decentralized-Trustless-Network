Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace Controllers

    ' GET: api/{GUID service}/notify/bulletinController
    <Route("NotifyRequestApi")>
    Public Class BulletinController

        Inherits ApiController


        ''' <summary>
        ''' This API (put method) provide to notify a request by another masternode
        ''' </summary>
        ''' <returns></returns>
        Public Function PutValue(<FromBody()> ByVal value As AreaConsensus.RequestProcess) As General.RemoteResponse
            Dim result As New General.RemoteResponse
            Dim proceed As Boolean = True
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
                    If Not AreaSecurity.checkSignature(value.getHash, value.signature, value.masterNodePublicAddress) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                End If

                If proceed Then
                    proceed = AreaCommon.flow.addNewRequestRemoteBulletin(value)
                End If

            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.signature = CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.createSignature(privateKey, value.getHash())

            Return result
        End Function

    End Class

End Namespace