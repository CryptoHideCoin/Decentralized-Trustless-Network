Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports TradingBotSystemModelsLibrary.AreaModel.Exchange
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/state/trade/exchangeController
    <Route("StateBaseApi")>
    Public Class ExchangeController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to return all exchange
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValues(ByVal securityToken As String) As ExchangeListResponseModel
            Dim ownerId As String = "ExchangeController-" & Guid.NewGuid.ToString
            Dim result As New ExchangeListResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeController.GetValues", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.state.exchangesEngine.list(False, ownerId)

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

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeController.GetValues", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeController.GetValues", ownerId)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get an information response model of an exchange 
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String, ByVal id As Integer) As ExchangeResponseModel
            Dim ownerId As String = "ExchangeController-" & Guid.NewGuid.ToString
            Dim result As New ExchangeResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeController.GetValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.state.exchangesEngine.select(id)

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

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeController.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeController.GetValue", ownerId)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to add a new exchange name into list
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="[name]"></param>
        Public Function PostValue(ByVal securityToken As String, <FromBody()> ByVal data As NewExchangeStructure) As BaseRemoteResponse
            Dim ownerId As String = "ExchangeController-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeController.GetValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        If Not AreaCommon.state.exchangesEngine.addNewExchange(data, ownerId) Then
                            result.responseStatus = BaseRemoteResponse.EnumResponseStatus.inError

                            result.errorDescription = "Problem during add a new exchange"
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

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeController.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeController.GetValue", ownerId)
                End If
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to update an existing element
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        Public Function PutValue(ByVal securityToken As String, <FromBody()> ByVal data As UpdateExchangeStructure) As BaseRemoteResponse
            Dim ownerId As String = "ExchangeController-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeController.PutValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        If Not AreaCommon.state.exchangesEngine.updateExchangeName(data, ownerId) Then
                            result.responseStatus = RemoteResponse.EnumResponseStatus.inError

                            result.errorDescription = "999 - Cannot update data (check id)"
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
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeController.PutValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeController.PutValue", ownerId)
                End If
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to update an existing element
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        Public Function DeleteValue(ByVal securityToken As String, ByVal id As Integer) As BaseRemoteResponse
            Dim ownerId As String = "ExchangeController-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ExchangeController.DeleteValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        If Not AreaCommon.state.exchangesEngine.delete(id, ownerId) Then
                            result.responseStatus = RemoteResponse.EnumResponseStatus.inError

                            result.errorDescription = "999 - Cannot delete data (check id or it used)"
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
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ExchangeController.DeleteValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ExchangeController.DeleteValue", ownerId)
                End If
            End Try

            Return result
        End Function

    End Class

End Namespace
