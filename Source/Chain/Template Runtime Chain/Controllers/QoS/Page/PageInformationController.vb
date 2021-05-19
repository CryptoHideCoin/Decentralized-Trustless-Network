Imports System.Web.Http




Namespace Controllers


    ' GET: api/{GUID service}/qos/informationPages
    <Route("QoSTicketApi")>
    Public Class informationPagesController

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.QoSModel.InformationPagesResponseModel

            Dim result As New AreaCommon.Models.QoSModel.InformationPagesResponseModel

            Try
                result.requestTime = Now

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    result.blockSize = AreaCommon.state.queues.getMaxBlockInternalLedgerSize
                    result.pages = AreaCommon.state.queues.getDataPages()

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