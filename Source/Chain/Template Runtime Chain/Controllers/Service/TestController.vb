Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models.General





Namespace Controllers


    ' GET: api/{GUID service}/service/testController
    <Route("ServiceApi")>
    Public Class testController

        Inherits ApiController




        Public Function GetValue() As RemoteResponse
            Dim result As New RemoteResponse

            Try
                result.requestTime = Now
                result.responseTime = Now
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            Return result
        End Function


    End Class


End Namespace
