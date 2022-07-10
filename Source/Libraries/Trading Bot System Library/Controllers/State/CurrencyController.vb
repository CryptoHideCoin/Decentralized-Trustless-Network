Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports TradingBotSystemModelsLibrary.AreaModel.Currency
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/state/trade/currencyController
    <Route("StateBaseApi")>
    Public Class CurrencyController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to return all currencies
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValues(ByVal securityToken As String) As CurrencyListResponseModel
            Dim ownerId As String = "CurrencyController-" & Guid.NewGuid.ToString
            Dim result As New CurrencyListResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("CurrencyController.GetValues", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.state.currenciesEngine.list(False, ownerId)

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

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("CurrencyController.GetValues", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("CurrencyController.GetValues", ownerId)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

        ''' <summary>
        ''' This method provide to get an information response model of a currency 
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String, ByVal id As Integer) As CurrencyResponseModel
            Dim ownerId As String = "CurrencyController-" & Guid.NewGuid.ToString
            Dim result As New CurrencyResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("CurrencyController.GetValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.state.currenciesEngine.select(id, ownerId)

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

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("CurrencyController.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("CurrencyController.GetValue", ownerId)
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
        Public Function postValue(ByVal securityToken As String, <FromBody()> ByVal data As CurrencyStructure) As BaseRemoteResponse
            Dim ownerId As String = "CurrencyController-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("CurrencyController.PostValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        data.deCodeSymbol()

                        If (AreaCommon.state.currenciesEngine.addOrGet(data, ownerId, True).id = 0) Then
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

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("CurrencyController.PostValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("CurrencyController.PostValue", ownerId)
                End If
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to update an existing element
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="value"></param>
        Public Function putValue(ByVal securityToken As String, <FromBody()> ByVal data As CurrencyStructure) As BaseRemoteResponse
            Dim ownerId As String = "CurrenciesController-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("CurrenciesController.PutValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        data.deCodeSymbol()

                        If Not AreaCommon.state.currenciesEngine.updateData(data.id, data) Then
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
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("CurrenciesController.PutValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("CurrenciesController.PutValue", ownerId)
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
            Dim ownerId As String = "CurrenciesController-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("CurrenciesController.DeleteValue", ownerId,, CHCModelsLibrary.AreaModel.Log.AccessTypeEnumeration.api)

                    enter = True
                    response = CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        If Not AreaCommon.state.currenciesEngine.delete(id) Then
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
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("CurrenciesController.DeleteValue", ownerId, ex.Message)
            Finally
                If enter Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("CurrenciesController.DeleteValue", ownerId)
                End If
            End Try

            Return result
        End Function

    End Class

End Namespace
