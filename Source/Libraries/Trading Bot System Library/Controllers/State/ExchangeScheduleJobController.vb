Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports TradingBotSystemModelsLibrary.AreaModel.Exchange
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/state/trade/exchangeScheduleJobController
    <Route("StateBaseApi")>
    Public Class ExchangeScheduleJobController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get an information response model of a currency 
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String, ByVal id As Integer) As ExchangeScheduleJobResponseModel
            Dim ownerId As String = "ExchangeScheduleJob-" & Guid.NewGuid.ToString
            Dim result As New ExchangeScheduleJobResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeScheduleJobController.GetValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.state.exchangesEngine.selectScheduleJob(id, ownerId)

                        CHCSidechainServiceLibrary.AreaCommon.Main.updateLastGetServiceInformation = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                        result.errorDescription = response
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeScheduleJobController.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeScheduleJobController.GetValue", ownerId)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to add a new currency data into list
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="newDataValue"></param>
        ''' <returns></returns>
        Public Function postValue(ByVal securityToken As String, <FromBody()> ByVal data As ExchangeActionModel) As BaseRemoteResponse
            Dim ownerId As String = "ExchangeScheduleJob-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeScheduleJobController.PostValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        If AreaCommon.state.exchangesEngine.executeCommand(data, ownerId) Then
                            result.responseStatus = BaseRemoteResponse.EnumResponseStatus.inError

                            result.errorDescription = "Problem during add a new currency"
                        End If

                        CHCSidechainServiceLibrary.AreaCommon.Main.updateLastGetServiceInformation = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                        result.errorDescription = response
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeScheduleJobController.PostValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeScheduleJobController.PostValue", ownerId)
                End If
            End Try

            Return result
        End Function

    End Class

End Namespace
