Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.CHCEngines.Base.CHCStringExtensions
Imports CHCMasterNodeEngineLibrary






<RoutePrefix("api/v1/Definition/CryptoAssetDefinition")>
Public Class CryptoAssetDefinitionController

    Inherits ApiController





    ' GET api/ContractOfValueArchive
    '<HttpGet> <Route("api/v1/Definition/CryptoAssetDefinition")>
    Public Function getValues() As IEnumerable(Of String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CryptoAssetDefinitionController.getValues", "Begin")

            AreaCommon.counter.increase("CryptoAssetDefinitionController.getValues",, adapterLog)

            Return AreaCommon.cryptoAssetDefinitionManager.getList(False, adapterLog)

        Catch ex As Exception

            adapterLog.track("CryptoAssetDefinitionController.getValues", "Error:" & ex.Message, "Fatal")

            Return New List(Of String)

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CryptoAssetDefinitionController.getValues", "Complete")

        End Try

    End Function



    ' GET api/ContractOfValueArchive/name
    '<HttpGet> <Route("api/v1/Definition/CryptoAssetDefinition")>
    Public Function getValue(ByVal name As String) As Models.CryptoAssetModel

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CryptoAssetDefinitionController.getValue", "Begin")

            AreaCommon.counter.increase("CryptoAssetDefinitionController.getValue",, adapterLog)

            Return AreaCommon.cryptoAssetDefinitionManager.item(True, HttpUtility.UrlDecode(name), False, adapterLog)

        Catch ex As Exception

            adapterLog.track("CryptoAssetDefinitionController.getValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CryptoAssetDefinitionController.getValue", "Complete")

        End Try

        Return New Models.CryptoAssetModel

    End Function



    ' POST api/ContractOfValueArchive
    '<HttpGet> <Route("api/v1/Definition/CryptoAssetDefinition")>
    Public Sub postValue(<FromBody()> ByVal value As Models.CryptoAssetRequestModel)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CryptoAssetDefinitionController.postValue", "Begin")

            AreaCommon.counter.increase("CryptoAssetDefinitionController.postValue",, adapterLog)

            value.symbol.decodeSymbol()

            adapterLog.track("CryptoAssetDefinitionController.postValue", "decodeSymbol executed")

            AreaCommon.cryptoAssetDefinitionManager.addNew(value, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("CryptoAssetDefinitionController.postValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CryptoAssetDefinitionController.postValue", "Complete")

        End Try

    End Sub



    ' PUT api/ContractOfValueArchive/name
    '<HttpGet> <Route("api/v1/Definition/CryptoAssetDefinition")>
    Public Sub putValue(ByVal name As String, <FromBody()> ByVal value As Models.CryptoAssetRequestModel)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CryptoAssetDefinitionController.putValue", "Begin")

            AreaCommon.counter.increase("CryptoAssetDefinitionController.putValue",, adapterLog)

            value.symbol.decodeSymbol()

            adapterLog.track("CryptoAssetDefinitionController.putValue", "decodeSymbol executed")

            AreaCommon.cryptoAssetDefinitionManager.update(name, value, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("CryptoAssetDefinitionController.putValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CryptoAssetDefinitionController.putValue", "Complete")

        End Try

    End Sub



    ' DELETE api/ContractOfValueArchive/name
    '<HttpGet> <Route("api/v1/Definition/CryptoAssetDefinition")>
    Public Sub deleteValue(ByVal name As String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CryptoAssetDefinitionController.deleteValue", "Begin")

            AreaCommon.counter.increase("CryptoAssetDefinitionController.deleteValue",, adapterLog)

            AreaCommon.cryptoAssetDefinitionManager.delete(name, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("CryptoAssetDefinitionController.deleteValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CryptoAssetDefinitionController.deleteValue", "Complete")

        End Try

    End Sub


End Class
