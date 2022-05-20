Option Compare Text
Option Explicit On

Imports System.Web.Http
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
            Dim result As New PerformanceProfileListResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("PerformanceProfileController.GetValue",, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.environment.performanceProfile.data
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

                AreaCommon.Main.environment.log.trackException("PerformanceProfileController.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("PerformanceProfileController.GetValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
