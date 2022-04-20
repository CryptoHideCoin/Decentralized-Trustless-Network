Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/logSettings/
    <Route("AdministrationApi")>
    Public Class LogSettingsController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a log stream
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String) As ResponseLogSettingsModel
            Dim result As New ResponseLogSettingsModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("LogSettings.GetValue",, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.environment.settings.logSettings
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

                AreaCommon.Main.environment.log.trackException("LogSettings.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("LogSettings.GetValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to set a log settings service
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String, <FromBody()> ByVal data As SettingsLogSidechainService) As BaseRemoteResponse
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("LogSettings.PutValue",, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        If AreaCommon.Main.environment.settings.useLog Then
                            AreaCommon.Main.environment.settings.logSettings = data
                        Else
                            result.responseStatus = BaseRemoteResponse.EnumResponseStatus.commandNotAllowed

                            result.errorDescription = "Log Settings not manage"
                        End If
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

                AreaCommon.Main.environment.log.trackException("LogSettings.PutValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("LogSettings.PutValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace

