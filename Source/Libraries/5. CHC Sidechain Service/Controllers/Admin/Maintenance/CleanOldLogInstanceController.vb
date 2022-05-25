Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports System.Threading
Imports CHCModelsLibrary.AreaModel.Log
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCProtocolLibrary.AreaCommon
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/maintenance/cleanOldLogInstance
    <Route("MaintenanceApi")>
    Public Class CleanOldLogInstanceController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to delete massive log instance
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String) As BaseRemoteResponse
            Dim ownerId As String = "CleanOldLogInstanceAct-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim asynchThread As Thread
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("CleanOldLogInstance.PutValue", ownerId, $"token={securityToken}", True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        asynchThread = New Thread(AddressOf AreaAsynchronous.executeCleanOldLogInstance)

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

                AreaCommon.Main.environment.log.trackException("CleanLog.PutValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("CleanLog.PutValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
