Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers

    ' GET: API/{GUID service}/Requests/A0x0Controller
    <Route("RequestApi")>
    Public Class A0x0Controller

        Inherits ApiController




        ''' <summary>
        ''' This API (get method) provide to return a request model A0x0 of a hashValue request
        ''' </summary>
        ''' <param name="hashValue"></param>
        ''' <returns></returns>
        Public Function getValue(ByVal hashValue As String) As AreaProtocol.A0x0.RequestResponseModel
            Dim result As New AreaProtocol.A0x0.RequestResponseModel
            Try
                AreaCommon.log.track("A0x0Controller.getValue", "Begin")

                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then
                        Dim request As AreaFlow.RequestExtended = AreaCommon.flow.getRequest(hashValue)

                        If IsNothing(request.data) Then
                            result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                            result.errorDescription = "503 - Missing request or request expired"

                            AreaCommon.log.track("A0x0Controller.getValue", "Missing request or request expired")
                        Else
                            If (request.data.hash.lenght > 0) Then
                                result.common = request.data.common
                                result.content.netName = request.data.netName
                                result.content.specialEnvironment = request.data.specialEnvironment
                                result.signature = request.data.common.signature
                            End If
                        End If
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If

                AreaCommon.log.track("A0x0Controller.getValue", "Complete")
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("A0x0Controller.getValue", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            Return AreaSecurity.completeResponse(result, result.common.signature)
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