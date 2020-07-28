Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary







<RoutePrefix("api/v1/Peer/Settings")>
Public Class SettingsController

    Inherits Controller





    ' GET api/PeerSettings
    '<HttpGet> <Route("api/v1/Peer/Settings")>
    Public Function getValues() As Models.Administration.SettingModel

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("SettingsController.getValues", "Begin")

            AreaCommon.counter.increase("SettingsController.getValues",, adapterLog)

            Return AreaCommon.settings.data

        Catch ex As Exception

            adapterLog.track("SettingsController.getValues", "Error:" & ex.Message, "Fatal")

            Return New Models.Administration.SettingModel

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("SettingsController.getValues", "Complete")

        End Try

    End Function


    ' POST api/<controller>
    Public Sub postValue(<FromBody()> ByVal value As Models.Administration.SettingModel)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("SettingsController.postValue", "Begin")

            AreaCommon.counter.increase("SettingsController.postValue",, adapterLog)

            adapterLog.track("SettingsController.postValue", "Begin copyIntoBaseModel")

            AreaCommon.settings.data = value

            adapterLog.track("SettingsController.postValue", "Begin Save")

            AreaCommon.settings.save()

        Catch ex As Exception

            adapterLog.track("SettingsController.postValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("SettingsController.postValue", "Complete")

        End Try


    End Sub




End Class
