Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/setPowerOn
    <Route("AdministrationApi")>
    Public Class SetPowerOnController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a log stream
        ''' </summary>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String) As BaseRemoteResponse
            Dim ownerId As String = "SetPowerOn-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("SetPowerOn.GetValue", ownerId,, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length <> 0) Then
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization

                        result.errorDescription = response
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.Main.environment.log.trackException("SetPowerOn.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("SetPowerOn.GetValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
