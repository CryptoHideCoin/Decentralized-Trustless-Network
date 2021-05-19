Imports System.Web.Http




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

                    result.error = False
                    result.errorDescription = ""
                    result.offline = False

                    result.queueNumber = dataTicket.queueNumber
                    result.position = dataTicket.position
                    result.ticketNumber = dataTicket.ticketId
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

