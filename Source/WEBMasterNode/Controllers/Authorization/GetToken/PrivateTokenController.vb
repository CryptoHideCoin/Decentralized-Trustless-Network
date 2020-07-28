Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary







<RoutePrefix("api/v1/Authorization")>
Public Class PrivateTokenController

    Inherits ApiController



    ' GET api/PrivateToken
    '<HttpGet> <Route("api/v1/Authorization/GetPrivateToken")>
    Public Function getValues(ByVal apiKey As String) As String

        Dim newToken As CHCEngines.TokenManagerEngine.CompleteTokenData
        Dim adapterLog As CHCServerSupport.Support.LogEngine
        Dim errorDescription As String = ""

        Try

            If AreaCommon.tokenManager.canReleaseNewPrivateToken(Request, AreaCommon.systemStatus, apiKey) Then

                newToken = AreaCommon.tokenManager.createNewPrivateToken(Request)

                adapterLog = New CHCServerSupport.Support.LogEngine()

                adapterLog.init(newToken.pathTokenData, "Call", AreaCommon.registry)

                adapterLog.noSave = (AreaCommon.settings.data.useTrack = Models.Administration.SettingModel.TrackRuntimeModeEnum.trackOnlyMain)

                adapterLog.track("GetPrivateTokenController.getValues", "Begin")

                AreaCommon.counter.increase("GetPrivateTokenController.getValues",, adapterLog)

                errorDescription = ""

                Return newToken.value

            Else

                errorDescription = "Cannot release a new identity token"

                Return ""

            End If

        Catch ex As Exception

            adapterLog.track("GetPrivateTokenController.getValues", "Error:" & ex.Message, "Fatal")

            errorDescription = "Error: Problem during manage a request"

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("GetPrivateTokenController.getValues", "Complete")

        End Try

        Throw New System.Web.HttpException(500, "Error: " & errorDescription)

        Return errorDescription

    End Function



End Class