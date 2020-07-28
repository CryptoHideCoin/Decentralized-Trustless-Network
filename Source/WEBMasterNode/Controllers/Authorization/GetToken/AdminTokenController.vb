Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary







<RoutePrefix("api/v1/Authorization")>
Public Class AdminTokenController

    Inherits ApiController



    ' GET api/AdminToken
    '<HttpGet> <Route("api/v1/Authorization/AdminToken")>
    Public Function getValues(ByVal walletAddress As String) As String

        Dim newToken As CHCEngines.TokenManagerEngine.CompleteTokenData
        Dim adapterLog As CHCServerSupport.Support.LogEngine
        Dim errorDescription As String = ""

        Try

            If AreaCommon.tokenManager.canReleaseNewAdminToken(Request, AreaCommon.systemStatus, walletAddress) Then

                newToken = AreaCommon.tokenManager.createNewAdminToken(Request)

                adapterLog = New CHCServerSupport.Support.LogEngine()

                adapterLog.init(newToken.pathTokenData, "Call", AreaCommon.registry)

                adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

                adapterLog.track("GetAdminTokenController.getValues", "Begin")

                AreaCommon.counter.increase("GetAdminTokenController.getValues",, adapterLog)

                errorDescription = ""

                Return newToken.value

            Else

                errorDescription = "Cannot release a new identity token"

                Return ""

            End If

        Catch ex As Exception

            adapterLog.track("GetAdminTokenController.getValues", "Error:" & ex.Message, "Fatal")

            errorDescription = "Error: Problem during manage a request"

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("GetAdminTokenController.getValues", "Complete")

        End Try

        Throw New System.Web.HttpException(500, "Error: " & errorDescription)

        Return errorDescription

    End Function



    ' POST api/AdminToken
    '<HttpGet> <Route("api/v1/Authorization/AdminToken")>
    Public Sub postValue(<FromBody()> ByVal tokenValue As String, ByVal signature As String, ByVal secureKey As String)

        Dim adapterLog As CHCServerSupport.Support.LogEngine

        Try

            ' Cosa devo fare in tutto questo ?!?

            ' Fare i miei controlli del cazzo e se tutto è giusto autorizzo il token


            'adapterLog = AreaCommon.log.createAccess()

            'adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

            'adapterLog.track("SettingsController.postValue", "Begin")

            'AreaCommon.counter.increase("SettingsController.postValue",, adapterLog)

            'adapterLog.track("SettingsController.postValue", "Begin copyIntoBaseModel")

            'AreaCommon.settings.data = value

            'adapterLog.track("SettingsController.postValue", "Begin Save")

            'AreaCommon.settings.save()

        Catch ex As Exception

            adapterLog.track("SettingsController.postValue", "Error:" & ex.Message, "Fatal")

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("SettingsController.postValue", "Complete")

        End Try


    End Sub



End Class