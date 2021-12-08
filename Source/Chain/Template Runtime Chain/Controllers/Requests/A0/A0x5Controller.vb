Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Json




Namespace Controllers

    ' GET: API/{GUID service}/Requests/A0x5Controller
    <Route("RequestApi")>
    Public Class A0x5Controller

        Inherits ApiController




        ''' <summary>
        ''' This API (get method) provide to return a request model A0x5 of a hashValue request
        ''' </summary>
        ''' <param name="hashValue"></param>
        ''' <returns></returns>
        Public Function getValue(ByVal hashValue As String) As AreaProtocol.A0x5.RequestResponseModel
            Dim result As New AreaProtocol.A0x5.RequestResponseModel
            Try
                AreaCommon.log.track("A0x5Controller.getValue", "Begin")

                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then
                        Dim request As AreaFlow.RequestExtended = AreaCommon.flow.getRequest(hashValue)

                        If IsNothing(request.data) Then
                            result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                            result.errorDescription = "503 - Missing request or request expired"

                            AreaCommon.log.track("A0x1Controller.getValue", "Missing request or request expired")
                        Else
                            If (request.data.hash.lenght > 0) Then
                                result.common = request.data.common
                                result.privacyPolicy = request.data.privacyPolicy
                                result.signature = request.data.common.signature
                            End If
                        End If
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If

                AreaCommon.log.track("A0x5Controller.getValue", "Completed")
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("A0x5Controller.getValue", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            Return AreaSecurity.completeResponse(result, result.common.signature)
        End Function

        ''' <summary>
        ''' This API (put method) provide to set a model A0x5 of a hashValue request
        ''' </summary>
        ''' <returns></returns>
        Public Function putValue(ByRef value As AreaProtocol.A0x5.RequestModel, ByVal ticketNumber As String) As RemoteResponse
            Dim result As New RemoteResponse
            Try
                AreaCommon.log.track("A0x5Controller.putValue", "Begin")

                If AreaSecurity.checkSignature(value.getHash(), value.common.signature, value.common.publicAddressRequester) Then
                    If AreaProtocol.A0x5.Manager.saveTemporallyRequest(value) Then
                        AreaCommon.log.track("A0x5Manager.putValue", "request - Saved")
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

                AreaCommon.log.track("A0x5Controller.putValue", "Completed")
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("A0x5Controller.putValue", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            Return AreaSecurity.completeResponse(result, value.common.signature)
        End Function

    End Class

End Namespace