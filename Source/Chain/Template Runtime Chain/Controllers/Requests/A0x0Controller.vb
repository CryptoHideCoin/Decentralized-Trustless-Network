Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML




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
                        With IOFast(Of AreaProtocol.A0x0.RequestModel).read(IO.Path.Combine(AreaCommon.paths.workData.currentVolume.requests, hashValue & ".request"))
                            result.common = .common
                            result.netName = .netName
                            result.signature = .signature
                        End With
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

            Return AreaSecurity.completeResponse(result, result.requestSignature)
        End Function

        ''' <summary>
        ''' This API (put method) provide to set a model A0x0 of a hashValue request
        ''' </summary>
        ''' <returns></returns>
        Public Function putValue(ByRef value As AreaProtocol.A0x0.RequestModel, ByVal ticketNumber As String) As RemoteResponse
            Dim result As New RemoteResponse
            Try
                AreaCommon.log.track("A0x0Controller.putValue", "Begin")

                If AreaSecurity.checkSignature(value.getHash(), value.signature, value.common.publicAddressRequester) Then
                    If AreaProtocol.A0x0.Manager.saveTemporallyRequest(value) Then
                        AreaCommon.log.track("A0x0Manager.putValue", "request - Saved")

                        If Not AreaCommon.flow.addNewRequestDirect(value.getHash(), value.common.requestCode, value.common.requestDateTimeStamp, ticketNumber) Then
                            AreaCommon.log.track("A0x0Manager.putValue", "Error during addNewRequestDirect")
                        End If
                    End If

                    If Not AreaCommon.flow.addNewRequestDirect(value.getHash(), value.common.requestCode, value.common.requestDateTimeStamp, ticketNumber) Then
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

            Return AreaSecurity.completeResponse(result, value.signature)
        End Function

    End Class

End Namespace