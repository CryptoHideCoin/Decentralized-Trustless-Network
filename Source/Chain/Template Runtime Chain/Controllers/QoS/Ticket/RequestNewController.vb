Imports System.Web.Http




Namespace Controllers


    ' GET: api/{GUID service}/qos/requestNewTicket
    <Route("QoSTicketApi")>
    Public Class requestNewTicketController

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.QoSModel.RequestNewTicketResponseModel

            Dim newTicket As TransactionChainLibrary.AreaEngine.Requests.QueueEngine.NewTicketResponse
            Dim result As New AreaCommon.Models.QoSModel.RequestNewTicketResponseModel

            Try
                result.requestTime = Now

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    newTicket = AreaCommon.state.queues.getNewTicket()

                    result.error = False
                    result.errorDescription = ""
                    result.offline = False
                    result.ofPriorityNumber = newTicket.queueOfPriorNumber
                    result.ofStandardNumber = newTicket.queueOfStandardNumber
                    result.queueNumber = newTicket.queueRequestNumber
                    result.ofUnclassified = newTicket.queueOfUnclassified
                    result.ticketNumber = newTicket.ticketId
                    result.unAuthorized = False
                Else
                    result.offline = True
                End If
            Catch ex As Exception
                result.error = True
                result.offline = True
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = Now

            Return result

        End Function


    End Class


End Namespace