Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary







<RoutePrefix("api/v1/Peer/Information")>
Public Class CurrentStatusController

    Inherits ApiController



    ' GET api/CurrentStatus
    '<HttpGet> <Route("api/v1/Peer/Information/CurrentStatus")>
    Public Function getValues() As Models.EnumPeerStatus

        Dim adapterLog As CHCServerSupport.Support.LogEngine
        Dim errorDescription As String = ""

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CurrentStatusController.getValues", "Begin")

            errorDescription = ""

            AreaCommon.counter.increase("CurrentStatusController.getValues",, adapterLog)

            Return AreaCommon.systemStatus.officialStatus

        Catch ex As Exception

            adapterLog.track("CurrentStatusController.getValues", "Error:" & ex.Message, "Fatal")

            Return Models.EnumPeerStatus.offLine

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CurrentStatusController.getValues", "Complete")

        End Try

    End Function



End Class