Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports System.Threading
Imports CHCModelsLibrary.AreaModel.PerformanceProfile
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/performanceProfile/
    <Route("AdministrationApi")>
    Public Class PerformanceProfileController

        Inherits ApiController




        ''' <summary>
        ''' This method provide to return an update settings model
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String) As PerformanceProfileListResponseModel
            Dim ownerId As String = "PerformanceProfileGet-" & Guid.NewGuid.ToString
            Dim result As New PerformanceProfileListResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("PerformanceProfileController.GetValue", ownerId,, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        If (AreaCommon.Main.environment.performanceProfile.engine.data.lastPosition = 0) Then
                            AreaCommon.Main.environment.performanceProfile.init(AreaCommon.Main.environment.paths.system.performanceProfile)
                        End If

                        result.value = AreaCommon.Main.environment.performanceProfile.engine.data
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

                AreaCommon.Main.environment.log.trackException("PerformanceProfileController.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("PerformanceProfileController.GetValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to start a performance profile procedure
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String) As BaseRemoteResponse
            Dim ownerId As String = "PerformanceProfileAct-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim asynchThread As Thread
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("PerformanceProfileInstance.PutValue", ownerId, $"token={securityToken}", True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        asynchThread = New Thread(AddressOf AreaAsynchronous.executePerformanceProfile)

                        asynchThread.Start()
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

                AreaCommon.Main.environment.log.trackException("PerformanceProfileInstance.PutValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("PerformanceProfileInstance.PutValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
