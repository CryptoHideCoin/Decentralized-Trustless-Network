Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/logBlockDelete/
    <Route("AdministrationApi")>
    Public Class LogBlockDeleteController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a log block delete informations
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="blockNumber"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String, ByVal blockNumber As String) As BaseRemoteResponse
            Dim ownerId As String = "LogBlockDelete-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Dim engine As CHCCommonLibrary.AreaEngine.Log.LogBlockEngine
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("LogBlockDelete.PutValue", ownerId, $"token={securityToken} blockNumber={blockNumber}", True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        engine = New CHCCommonLibrary.AreaEngine.Log.LogBlockEngine

                        engine.logFilePath = AreaCommon.Main.environment.log.settings.pathFileLog
                        engine.logInstance = ""

                        If engine.exist(blockNumber) Then
                            If Not engine.delete(blockNumber) Then
                                result.responseStatus = BaseRemoteResponse.EnumResponseStatus.inError

                                result.errorDescription = "Delete incomplete"
                            End If
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

                AreaCommon.Main.environment.log.trackException("LogBlockDelete.PutValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("LogBlockDelete.PutValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
