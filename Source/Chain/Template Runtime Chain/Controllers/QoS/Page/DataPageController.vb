Imports System.Web.Http




Namespace Controllers


    ' GET: api/{GUID service}/qos/dataPage
    <Route("QoSTicketApi")>
    Public Class DataPageController

        Inherits ApiController




        Public Function GetValue(ByVal pageNumber As Integer) As AreaCommon.Models.QoSModel.DataPageResponseModel

            Dim result As New AreaCommon.Models.QoSModel.DataPageResponseModel

            Try
                result.requestTime = Now

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    result.content = AreaCommon.state.queues.getDataFile(pageNumber)
                    result.pageNumber = pageNumber

                    result.error = False
                    result.errorDescription = ""
                    result.offline = False
                Else
                    result.offline = True
                End If
            Catch ex As Exception
                result.error = True
                result.offline = True
                result.errorDescription = "503 - Generic Error"
            End Try

            result.unAuthorized = False
            result.responseTime = Now

            Return result

        End Function


    End Class


End Namespace
