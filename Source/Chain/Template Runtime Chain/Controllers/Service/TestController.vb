Imports System.Web.Http

Imports CHCProtocolLibrary.AreaCommon.Models.General



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
                result.error = True
                result.offline = True
                result.errorDescription = "503 - Generic Error"
            End Try

            Return result

        End Function


    End Class


End Namespace
