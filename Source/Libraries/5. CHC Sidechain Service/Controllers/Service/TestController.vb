Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModels.AreaModel.Network.Response





Namespace Controllers

    ' GET: api/{GUID service}/service/testController
    <RoutePrefix("ServiceApi")>
    Public Class testController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to return a current time of server (test service)
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As RemoteResponse
            Dim result As New RemoteResponse
            Dim enter As Boolean = False
            Try
                AreaCommon.Main.environment.log.trackEnter("test.GetValue",, True)

                enter = True

                result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.Main.environment.log.trackException("test.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("test.GetValue",, True)
                End If
            End Try

            Return result
        End Function

    End Class

End Namespace
