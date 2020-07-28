Option Compare Text
Option Explicit On



Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary






<RoutePrefix("api/v1/Peer/CryptoAssetSupported")>
Public Class CryptoAssetSupportedController

    Inherits ApiController





    ' GET api/CryptoAssetSupported
    '<HttpGet> <Route("api/v1/Peer/CryptoAssetSupported")>
    Public Function getValues() As IEnumerable(Of String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CryptoAssetSupportedController.getValues", "Begin")

            AreaCommon.counter.increase("CryptoAssetSupportedController.getValues",, adapterLog)

            Return AreaCommon.cryptoAssetDefinitionManager.getUsedList(, adapterLog)

        Catch ex As Exception

            adapterLog.track("CryptoAssetSupportedController.getValues", "Error:" & ex.Message, "Fatal")

            Return New List(Of String)

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CryptoAssetSupportedController.getValues", "Complete")

        End Try

    End Function

    ' GET api/CryptoAssetSupported/id
    '<HttpGet> <Route("api/v1/Peer/CryptoAssetSupported")>
    Public Function getValue(ByVal id As String) As Models.CryptoAssetModel

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            adapterLog.track("CryptoAssetSupportedController.getValue", "Begin")

            AreaCommon.counter.increase("CryptoAssetSupportedController.getValue",, adapterLog)

            Return AreaCommon.cryptoAssetDefinitionManager.item(False, id,, adapterLog)

        Catch ex As Exception

            adapterLog.track("CryptoAssetSupportedController.getValue", "Error:" & ex.Message, "Fatal")

            Return New Models.CryptoAssetModel

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("CryptoAssetSupportedController.getValue", "Complete")

        End Try

    End Function



End Class