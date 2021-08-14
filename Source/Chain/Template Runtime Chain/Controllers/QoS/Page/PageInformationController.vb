Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General




Namespace Controllers


    ' GET: api/{GUID service}/qos/informationPages
    <Route("QoSTicketApi")>
    Public Class informationPagesController

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.QoSModel.InformationPagesResponseModel

            Dim result As New AreaCommon.Models.QoSModel.InformationPagesResponseModel

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.network.position = AppState.enumConnectionState.onLine) Then
                    result.blockSize = AreaCommon.state.queues.getMaxBlockInternalLedgerSize
                    result.pages = AreaCommon.state.queues.getDataPages()
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