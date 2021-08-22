Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General




Namespace Controllers


    ' GET: api/{GUID service}/qos/requestNewTicket
    <Route("QoSTicketApi")>
    Public Class requestNewTicketController

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.QoSModel.RequestNewTicketResponseModel
            Dim newTicket As TransactionChainLibrary.AreaEngine.Requests.QueueEngine.NewTicketResponse
            Dim result As New AreaCommon.Models.QoSModel.RequestNewTicketResponseModel

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.network.position = CHCRuntimeChainLibrary.AreaRuntime.AppState.EnumConnectionState.onLine) Then
                    newTicket = AreaCommon.state.queues.getNewTicket()

                    result.ofPriorityNumber = newTicket.queueOfPriorNumber
                    result.ofStandardNumber = newTicket.queueOfStandardNumber
                    result.queueNumber = newTicket.queueRequestNumber
                    result.ofUnclassified = newTicket.queueOfUnclassified
                    result.ticketNumber = newTicket.ticketId
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