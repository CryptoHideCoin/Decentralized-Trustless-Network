Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModels.AreaModel.Network.Response





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
            Dim result As New BaseRemoteResponse
            Dim enter As Boolean = False
            Try
                AreaCommon.Main.environment.log.trackEnter("Service.Test.GetValue",, True)

                enter = True

                result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.Main.environment.log.trackException("Service.Test.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("Service.Test.GetValue",, True)
                End If
            End Try

            Return result
        End Function

    End Class

End Namespace
