Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General



Namespace Controllers


    ' GET: api/{GUID service}/qos/queueTickets
    <Route("QoSTicketApi")>
    Public Class queueTickets

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.QoSModel.RequestQueueTicketResponseModel

            Dim dataQueue As TransactionChainLibrary.AreaEngine.Requests.QueueEngine.QueueResponse
            Dim result As New AreaCommon.Models.QoSModel.RequestQueueTicketResponseModel

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    dataQueue = AreaCommon.state.queues.getQueueTickets()

                    result.queueNumber = dataQueue.queueRequestNumber
                    result.ofPriorityNumber = dataQueue.queueOfPriorNumber
                    result.ofStandardNumber = dataQueue.queueOfStandardNumber
                    result.ofUnclassified = dataQueue.queueOfUnclassified
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