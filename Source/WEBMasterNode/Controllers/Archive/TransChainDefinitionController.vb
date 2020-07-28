Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary






<RoutePrefix("api/v1/Definition/TransChainDefinition")>
Public Class TransChainDefinitionController

    Inherits ApiController





    ' GET api/TransChainDefinition
    '<HttpGet> <Route("api/v1/Definition/TransChainDefinition")>
    Public Function getValues() As IEnumerable(Of String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("TransChainDefinitionController.getValues", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.getValues",, adapterLog)

            Return AreaCommon.transChainDefinitionManager.getList(False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.getValues", "Error:" & ex.Message, "Fatal")

            Return New List(Of String)

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("TransChainDefinitionController.getValues", "Complete")

        End Try

    End Function



    ' GET api/TransChainDefinition/name
    '<HttpGet> <Route("api/v1/Definition/TransChainDefinition/name")>
    Public Function getValue(ByVal name As String) As Models.TransChainDefinitionRequestModel

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("TransChainDefinitionController.getValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.getValue",, adapterLog)

            Return AreaCommon.transChainDefinitionManager.item(True, HttpUtility.UrlDecode(name))

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.getValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("TransChainDefinitionController.getValue", "Complete")

        End Try

        Return New Models.TransChainDefinitionRequestModel

    End Function



    ' POST api/TransChainDefinition
    '<HttpGet> <Route("api/v1/Definition/NetworTransChainDefinitionkDefinition")>
    Public Sub postValue(<FromBody()> ByVal value As Models.TransChainDefinitionRequestModel)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("TransChainDefinitionController.postValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.postValue",, adapterLog)

            AreaCommon.transChainDefinitionManager.addNew(value, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.postValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("TransChainDefinitionController.postValue", "Complete")

        End Try

    End Sub



    ' PUT api/TransChainDefinition/name
    '<HttpGet> <Route("api/v1/Definition/TransChainDefinition")>
    Public Sub putValue(ByVal name As String, <FromBody()> ByVal value As Models.TransChainDefinitionRequestModel)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("TransChainDefinitionController.putValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.putValue",, adapterLog)

            AreaCommon.transChainDefinitionManager.update(name, value, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.putValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("TransChainDefinitionController.putValue", "Complete")

        End Try

    End Sub



    ' DELETE api/TransChainDefinition/name
    '<HttpGet> <Route("api/v1/Definition/TransChainDefinition")>
    Public Sub deleteValue(ByVal name As String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("TransChainDefinitionController.deleteValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.deleteValue",, adapterLog)

            AreaCommon.transChainDefinitionManager.delete(name, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.deleteValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("TransChainDefinitionController.deleteValue", "Complete")

        End Try


    End Sub


End Class
