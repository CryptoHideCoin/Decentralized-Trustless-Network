Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary







<RoutePrefix("api/v1/Authorization")>
Public Class GetTokenController

    Inherits ApiController



    ' GET api/PublicToken
    '<HttpGet> <Route("api/v1/Authorization/GetToken")>
    Public Function getValues() As String

        Dim newToken As CHCEngines.TokenManagerEngine.CompleteTokenData
        Dim adapterLog As CHCServerSupport.Support.LogEngine
        Dim errorDescription As String = ""

        Try

            If AreaCommon.tokenManager.canReleaseNewPublicToken(Request, AreaCommon.systemStatus) Then

                newToken = AreaCommon.tokenManager.createNewPublicToken(Request)

                adapterLog = New CHCServerSupport.Support.LogEngine()

                adapterLog.init(newToken.pathTokenData, "Call", AreaCommon.registry)

                adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

                adapterLog.track("GetTokenController.getValues", "Begin")

                AreaCommon.counter.increase("GetTokenController.getValues",, adapterLog)

                errorDescription = ""

                Return newToken.value

            Else

                errorDescription = "Cannot release a new identity token"

                Return ""

            End If

        Catch ex As Exception

            adapterLog.track("GetTokenController.getValues", "Error:" & ex.Message, "Fatal")

            errorDescription = "Error: Problem during manage a request"

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("GetTokenController.getValues", "Complete")

        End Try

        Throw New System.Web.HttpException(500, "Error: " & errorDescription)

        Return errorDescription

    End Function



End Class