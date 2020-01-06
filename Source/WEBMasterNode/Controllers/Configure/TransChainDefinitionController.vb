Option Compare Text
Option Explicit On


Imports System.Web.Http






<RoutePrefix("api/v1/Configuration/TransChainDefinition")>
Public Class TransChainDefinitionController

    Inherits ApiController





    ' GET api/TransChainDefinition
    '<HttpGet> <Route("api/v1/Configuration/TransChainDefinition")>
    Public Function getValues() As IEnumerable(Of String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = Not AreaCommon.settings.logAccessActive

            adapterLog.track("TransChainDefinitionController.getValues", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.getValues",, adapterLog)

            Return AreaCommon.transChainDefinitionManager.getList(False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.getValues", "Error:" & ex.Message, "Fatal")

            Return New List(Of String)

        Finally

            adapterLog.track("TransChainDefinitionController.getValues", "Complete")

        End Try

    End Function



    ' GET api/TransChainDefinition/name
    '<HttpGet> <Route("api/v1/Configuration/TransChainDefinition/name")>
    Public Function getValue(ByVal name As String) As CHCDefinitionEngineLibrary.Models.TransChainDefinitionRequestModel

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = Not AreaCommon.settings.logAccessActive

            adapterLog.track("TransChainDefinitionController.getValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.getValue",, adapterLog)

            Return AreaCommon.transChainDefinitionManager.item(True, HttpUtility.UrlDecode(name))

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.getValue", "Error:" & ex.Message, "Fatal")

        Finally

            adapterLog.track("TransChainDefinitionController.getValue", "Complete")

        End Try

        Return New CHCDefinitionEngineLibrary.Models.TransChainDefinitionRequestModel

    End Function



    ' POST api/TransChainDefinition
    '<HttpGet> <Route("api/v1/Configuration/NetworTransChainDefinitionkDefinition")>
    Public Sub postValue(<FromBody()> ByVal value As CHCDefinitionEngineLibrary.Models.TransChainDefinitionRequestModel)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = Not AreaCommon.settings.logAccessActive

            adapterLog.track("TransChainDefinitionController.postValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.postValue",, adapterLog)

            AreaCommon.transChainDefinitionManager.addNew(value, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.postValue", "Error:" & ex.Message, "Fatal")

        Finally

            adapterLog.track("TransChainDefinitionController.postValue", "Complete")

        End Try

    End Sub



    ' PUT api/TransChainDefinition/name
    '<HttpGet> <Route("api/v1/Configuration/TransChainDefinition")>
    Public Sub putValue(ByVal name As String, <FromBody()> ByVal value As CHCDefinitionEngineLibrary.Models.TransChainDefinitionRequestModel)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = Not AreaCommon.settings.logAccessActive

            adapterLog.track("TransChainDefinitionController.putValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.putValue",, adapterLog)

            AreaCommon.transChainDefinitionManager.update(name, value, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.putValue", "Error:" & ex.Message, "Fatal")

        Finally

            adapterLog.track("TransChainDefinitionController.putValue", "Complete")

        End Try

    End Sub



    ' DELETE api/TransChainDefinition/name
    '<HttpGet> <Route("api/v1/Configuration/TransChainDefinition")>
    Public Sub deleteValue(ByVal name As String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            adapterLog = AreaCommon.log.createAccess()

            adapterLog.noSave = Not AreaCommon.settings.logAccessActive

            adapterLog.track("TransChainDefinitionController.deleteValue", "Begin")

            AreaCommon.counter.increase("TransChainDefinitionController.deleteValue",, adapterLog)

            AreaCommon.transChainDefinitionManager.delete(name, False, adapterLog)

        Catch ex As Exception

            adapterLog.track("TransChainDefinitionController.deleteValue", "Error:" & ex.Message, "Fatal")

        Finally

            adapterLog.track("TransChainDefinitionController.deleteValue", "Complete")

        End Try


    End Sub


End Class
