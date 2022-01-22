Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon



Namespace Controllers


    ' GET: API/{GUID service}/Administration/ServiceState
    <Route("AdministrationApi")>
    Public Class ServiceStateController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a service state position
        ''' </summary>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        Public Function getValue(ByVal signature As String) As Models.Administration.ServiceStateResponse
            Dim result As New Models.Administration.ServiceStateResponse

            Try
                AreaCommon.log.track("ServiceStateController.getValue", "Begin")

                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    If Not AreaSecurity.checkSignature(signature) Then
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                    Else
                        result.componentPosition = AreaCommon.state.currentService.componentPosition
                        result.currentAction = AreaCommon.state.currentService.currentAction
                        result.listAvailableCommand = AreaCommon.state.currentService.listAvailableCommand
                        result.servicePosition = AreaCommon.state.currentService.servicePosition
                        result.currentRunCommand = AreaCommon.state.currentService.currentRunCommand
                        result.requestCancelCurrentRunCommand = AreaCommon.state.currentService.requestCancelCurrentRunCommand
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If

                AreaCommon.log.track("ServiceStateController.getValue", "Completed")
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.log.track("ServiceStateController.get", "An error occurrent during execute: " & ex.Message, "fatal")
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function

    End Class


End Namespace