Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Network.Response





Namespace Controllers

    ' GET: api/{GUID service}/service/testController
    <Route("ServiceApi")>
    Public Class TestController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to return a current time of server (test service)
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As BaseRemoteResponse
            Dim ownerId As String = "TestGet-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim enter As Boolean = False
            Try
                AreaCommon.Main.environment.log.trackEnter("Service.Test.GetValue", ownerId,, True)

                enter = True

                result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.Main.environment.log.trackException("Service.Test.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("Service.Test.GetValue", ownerId,, True)
                End If
            End Try

            Return result
        End Function

    End Class

End Namespace
