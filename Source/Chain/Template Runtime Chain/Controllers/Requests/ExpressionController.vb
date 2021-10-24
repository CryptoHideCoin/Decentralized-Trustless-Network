Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaCommon.Models




Namespace Controllers

    ' GET: API/{GUID service}/Requests/ExpressionController
    <Route("RequestApi")>
    Public Class ExpressionController

        Inherits ApiController




        ''' <summary>
        ''' This API (get method) provide to request an expression controller
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function getValue(<FromBody()> ByVal value As AreaCommon.Models.Network.RequestExpressionModel) As RemoteResponse
            Dim result As New RemoteResponse
            Dim proceed As Boolean = True
            Dim dataNode As AreaState.ChainStateEngine.DataMasternode
            Dim dataBulletin As New AreaConsensus.BulletinInformation
            Try
            AreaCommon.log.track("ExpressionController.getValue", "Begin")

                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If proceed Then
                    proceed = (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started)
                End If
                If proceed Then
                    proceed = (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine)
                End If
                If proceed Then
                    If Not AreaSecurity.checkSignature(value.signature) Or Not AreaSecurity.checkSignature(value.getHash, value.signature, value.publicAddressRequester) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
                If proceed Then
                    dataNode = AreaCommon.state.runtimeState.getDataNode(value.publicAddressRequester)

                    If (dataNode.identityPublicAddress.Length = 0) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                End If
                If proceed Then
                    dataBulletin = AreaCommon.flow.getRequest(value.requestHash).bulletin

                    If (dataBulletin.hash.Length = 0) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.commandNotAllowed

                        proceed = False
                    End If
                End If
                If proceed Then
                    proceed = AreaCommon.flow.addNewBulletinToSend(AreaCommon.Masternode.MasternodeSenders.createSingleMasterNodeList(dataNode.identityPublicAddress, dataNode.ipAddress), dataBulletin)

                    If Not proceed Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError

                        result.errorDescription = "503 - Generic Error"
                    End If
                End If

                AreaCommon.log.track("ExpressionController.getValue", "Complete")
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("ExpressionController.getValue", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            Return AreaSecurity.completeResponse(result, True)
        End Function


        ''' <summary>
        ''' This API (put method) provide to set a model A0x0 of a hashValue request
        ''' </summary>
        ''' <returns></returns>
        Public Function putValue(ByRef value As AreaProtocol.A0x0.RequestModel, ByVal ticketNumber As String) As RemoteResponse
            Dim result As New RemoteResponse
            Try
                AreaCommon.log.track("A0x0Controller.putValue", "Begin")

                If AreaSecurity.checkSignature(value.getHash(), value.common.signature, value.common.publicAddressRequester) Then
                    If AreaProtocol.A0x0.Manager.saveTemporallyRequest(value) Then
                        AreaCommon.log.track("A0x0Manager.putValue", "request - Saved")
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                        result.errorDescription = "503 - Generic Error"
                    End If

                    If Not AreaCommon.flow.addNewRequestDirect(value, ticketNumber) Then
                        result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                        result.errorDescription = "503 - Generic Error"
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                End If

                AreaCommon.log.track("A0x0Controller.putValue", "Complete")
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("A0x0Controller.putValue", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            Return AreaSecurity.completeResponse(result, value.common.signature)
        End Function

    End Class

End Namespace