Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General




Namespace Controllers


    ' GET: api/{GUID service}/qos/informationTicket
    <Route("QoSTicketApi")>
    Public Class informationTicketController

        Inherits ApiController




        Public Function GetValue(ByVal ticketValue As String) As AreaCommon.Models.QoSModel.RequestDataTicketResponseModel

            Dim dataTicket As TransactionChainLibrary.AreaEngine.Requests.QueueEngine.DataTicketResponse
            Dim result As New AreaCommon.Models.QoSModel.RequestDataTicketResponseModel

            Try
                result.requestTime = Now

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    dataTicket = AreaCommon.state.queues.getDataTicket(ticketValue, AreaCommon.paths.workData.currentVolume.requests, AreaCommon.paths.workData.previousVolume.requests)
                    result.queueNumber = dataTicket.queueNumber
                    result.position = dataTicket.position
                    result.ticketNumber = dataTicket.ticketId
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = Now

            Return result

        End Function


    End Class


End Namespace

