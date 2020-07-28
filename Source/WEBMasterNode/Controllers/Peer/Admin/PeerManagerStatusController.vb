Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCMasterNodeEngineLibrary







<RoutePrefix("api/v1/Peer/Admin")>
Public Class ManagerStatusController

    Inherits ApiController



    ' GET api/ManagerStatus
    '<HttpGet> <Route("api/v1/Peer/Admin/ManagerStatus")>
    Public Function getValues(ByVal adminToken As String) As Models.EnumPeerStatusDetail

        Dim adapterLog As CHCServerSupport.Support.LogEngine
        Dim errorDescription As String = ""

        Try

            With AreaCommon.tokenManager.checkAdminToken(adminToken, Request)

                If .failed Then

                    errorDescription = .message

                Else

                    adapterLog = New CHCServerSupport.Support.LogEngine()

                    adapterLog.init(.token.pathTokenData, "Call", AreaCommon.registry)

                    adapterLog.track("ManagerStatusController.getValues", "Begin")

                    AreaCommon.counter.increase("ManagerStatusController.getValues",, adapterLog)

                    Return AreaCommon.systemStatus.currentStatus

                End If

            End With

        Catch ex As Exception

            adapterLog.track("ManagerStatusController.getValues", "Error:" & ex.Message, "Fatal")

            errorDescription = "Error: Problem during manage a request"

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("ManagerStatusController.getValues", "Complete")

        End Try

        Throw New System.Web.HttpException(500, "Error: " & errorDescription)

        Return Models.EnumPeerStatusDetail.offLine

    End Function



    ' POST api/ManagerStatus
    '<HttpGet> <Route("api/v1/Authorization/ManagerStatus")>
    Public Sub postValue(<FromBody()> ByVal adminToken As String, ByVal newStatus As Models.EnumChangeStatus)

        Dim adapterLog As CHCServerSupport.Support.LogEngine
        Dim errorDescription As String = ""

        Try

            With AreaCommon.tokenManager.checkAdminToken(adminToken, Request)

                If .failed Then

                    errorDescription = .message

                Else

                    adapterLog = New CHCServerSupport.Support.LogEngine()

                    adapterLog.init(.token.pathTokenData, "Call", AreaCommon.registry)

                    adapterLog.track("ManagerStatusController.postValue", "Begin")

                    AreaCommon.counter.increase("ManagerStatusController.postValue",, adapterLog)

                    errorDescription = AreaCommon.systemStatus.setChangeStatus(newStatus, .token.secureKEY)

                End If

            End With

        Catch ex As Exception

            adapterLog.track("ManagerStatusController.postValue", "Error:" & ex.Message, "Fatal")

            errorDescription = "Error: Problem during manage a request"

        Finally

            AreaCommon.refreshBatch(adapterLog)

            adapterLog.track("ManagerStatusController.postValue", "Complete")

        End Try

        If (errorDescription.Length > 0) Then

            Throw New System.Web.HttpException(500, "Error: " & errorDescription)

        End If

    End Sub



End Class