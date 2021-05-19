Imports System.Web.Http




Namespace Controllers


    ' GET: api/{GUID service}/qos/queueTickets
    <Route("QoSTicketApi")>
    Public Class queueTickets

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.QoSModel.RequestQueueTicketResponseModel

            Dim dataQueue As TransactionChainLibrary.AreaEngine.Requests.QueueEngine.QueueResponse
            Dim result As New AreaCommon.Models.QoSModel.RequestQueueTicketResponseModel

            Try
                result.requestTime = Now

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    dataQueue = AreaCommon.state.queues.getQueueTickets()

                    result.error = False
                    result.errorDescription = ""
                    result.offline = False

                    result.queueNumber = dataQueue.queueRequestNumber
                    result.ofPriorityNumber = dataQueue.queueOfPriorNumber
                    result.ofStandardNumber = dataQueue.queueOfStandardNumber
                    result.ofUnclassified = dataQueue.queueOfUnclassified
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