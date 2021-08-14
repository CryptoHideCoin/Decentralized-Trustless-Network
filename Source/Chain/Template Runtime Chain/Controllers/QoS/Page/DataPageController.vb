Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General




Namespace Controllers


    ' GET: api/{GUID service}/qos/dataPage
    <Route("QoSTicketApi")>
    Public Class DataPageController

        Inherits ApiController




        Public Function GetValue(ByVal pageNumber As Integer) As AreaCommon.Models.QoSModel.DataPageResponseModel

            Dim result As New AreaCommon.Models.QoSModel.DataPageResponseModel

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    result.content = AreaCommon.state.queues.getDataFile(pageNumber)
                    result.pageNumber = pageNumber
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result

        End Function


    End Class


End Namespace
