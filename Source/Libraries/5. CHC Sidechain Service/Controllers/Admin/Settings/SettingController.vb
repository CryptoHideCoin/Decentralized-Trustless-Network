Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModels.AreaModel.Administration.Settings
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/settings/
    <RoutePrefix("AdministrationApi")>
    Public Class SettingsController

        Inherits ApiController




        ''' <summary>
        ''' This method provide to return an update settings model
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String) As ResponseUpdateSettingsModel
            Dim result As New ResponseUpdateSettingsModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("AcquireSettings.GetValue",, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.environment.settings
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

                AreaCommon.Main.environment.log.trackException("AcquireSettings.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("AcquireSettings.GetValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

        ''' <summary>
        ''' This method provides to return an Admin Security Token 
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String, <FromBody()> ByVal data As SettingsSidechainService) As BaseRemoteResponse
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("AcquireSettings.PutValue",, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        AreaCommon.Main.environment.settings = data

                        If AreaCommon.Main.environment.saveSettings() Then
                            AreaCommon.Main.environment.registry.addNew(CHCCommonLibrary.Support.RegistryEngine.RegistryData.TypeEvent.other, "Settings update")
                            AreaCommon.Main.environment.log.trackIntoConsole("Settings update")
                            AreaCommon.Main.environment.log.track("AcquireSettings.PutValue", "Settings update")
                        Else
                            result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                            result.errorDescription = "503 - Generic Error"

                            AreaCommon.Main.environment.log.trackException("AcquireSettings.PutValue", "Save settings fault")
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

                AreaCommon.Main.environment.log.trackException("AcquireSettings.PutValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("AcquireSettings.PutValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
