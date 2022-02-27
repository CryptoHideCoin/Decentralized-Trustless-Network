Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/setPowerOff
    <RoutePrefix("AdministrationApi")>
    Public Class setPowerOffController

        Inherits ApiController



        ''' <summary>
        ''' This method provides to set a power off service
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String) As BaseRemoteResponse
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("setPowerOff.PutValue",, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        AreaCommon.Main.securityTokenSwitchOnService = securityToken
                        AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.shutDown

                        AreaCommon.Main.environment.log.trackIntoConsole("Service in switch off state")
                        AreaCommon.Main.environment.log.track("setPowerOff.PutValue", "Switch off state")
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                        result.errorDescription = response
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.Main.environment.log.trackException("setPowerOff.PutValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("setPowerOff.PutValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
