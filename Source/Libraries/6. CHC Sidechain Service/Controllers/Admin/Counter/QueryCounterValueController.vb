Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Log
Imports CHCModelsLibrary.AreaModel.Counter
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers



    ' GET: api/{GUID service}/administration/queryCounterValue/
    <Route("AdministrationApi")>
    Public Class QueryCounterValueController

        Inherits ApiController

        ''' <summary>
        ''' This method provide to get a query counter on a filter data
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="filter"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String, ByVal filter As String) As QueryCounterResponseModel
            Dim filterData As QueryCounterFilter
            Dim ownerId As String = "QueryCounter-" & Guid.NewGuid.ToString
            Dim result As New QueryCounterResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("LogBlock.GetValue", ownerId,, AccessTypeEnumeration.api)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        filterData = CHCCommonLibrary.AreaEngine.Communication.DeserializeFast(Of QueryCounterFilter).decode(filter)

                        If IsNothing(filterData) Then
                            filterData = New QueryCounterFilter

                            filterData.components = QueryCounterFilter.CounterComponentEnumeration.both
                            filterData.toTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                            filterData.fromTimestamp = filterData.toTimeStamp - 60000
                        ElseIf filterData.toTimeStamp = 0 Then
                            filterData.toTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                        End If

                        result.filter = filterData
                        result.totals = AreaCommon.Main.environment.counter.getTotals(filterData)
                        result.timeSlots = AreaCommon.Main.environment.counter.getCounterTimeSlots(filterData)
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

                AreaCommon.Main.environment.log.trackException("LogBlock.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("LogBlock.GetValue", ownerId)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
