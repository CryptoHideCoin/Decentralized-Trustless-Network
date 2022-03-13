Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModels.AreaModel.Log
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/logStream/
    <Route("AdministrationApi")>
    Public Class LogStreamController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a log stream
        ''' </summary>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String, ByVal mode As String) As LogStreamResponseModel
            Dim result As New LogStreamResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("LogStream.GetValue",, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.environment.log.getDataNewer(0, (mode.ToLower() = "console"))
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

                AreaCommon.Main.environment.log.trackException("LogStream.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("LogStream.GetValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function


    End Class


End Namespace
