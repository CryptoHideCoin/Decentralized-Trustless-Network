Option Compare Text
Option Explicit On


Imports CHCModelsLibrary.AreaModel.Information




Namespace AreaService.Runtime.Models

    ''' <summary>
    ''' This class contain the service of a state
    ''' </summary>
    Public Class ServiceState

        Private Const _NextDayMilliseconds As Double = 24 * 60 * 60 * 1000

        Public Event AddScheduleJobCheckCurrencies(ByRef job As CHCModelsLibrary.AreaModel.Service.Scheduler.JobSchedule)

        Public Property serviceInformation As New InternalServiceInformation
        Public Property tradingBotSystem As New AreaEngine.TradingBotSystemServiceEngine

        Public WithEvents exchangesEngine As New AreaBusiness.ExchangeEngine
        Public WithEvents exchangeReferencesEngine As New AreaBusiness.ExchangeReferencesEngine

        Public Property currenciesEngine As New AreaBusiness.CurrenciesEngine
        Public Property currenciesDownloadEngine As New AreaJob.GetCurrenciesFromWEB


        ''' <summary>
        ''' This method provide to determinate if now is 
        ''' </summary>
        ''' <param name="lastUpdate"></param>
        ''' <returns></returns>
        Private Function determinateIfExecuteNow(ByVal lastUpdate As Double) As Boolean
            Dim nextTime As Double = lastUpdate + _NextDayMilliseconds

            Return (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > nextTime)
        End Function

        Private Sub manageDownloadCurrencies(ByVal exchangeId As Integer, ByVal lastCurrenciesUpdate As Double)
            Try
                Dim nextTime As Double = 0

                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("ServiceState.manageDownloadCurrencies", "manageDownloadCurrencies")

                If (lastCurrenciesUpdate = 0) Then
                    currenciesDownloadEngine.downloadFromExchange(exchangeId, exchangesEngine.select(exchangeId).name, False)

                    nextTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + _NextDayMilliseconds
                ElseIf determinateIfExecuteNow(lastCurrenciesUpdate) Then
                    currenciesDownloadEngine.downloadFromExchange(exchangeId, exchangesEngine.select(exchangeId).name, False)

                    nextTime = lastCurrenciesUpdate + _NextDayMilliseconds
                Else
                    nextTime = lastCurrenciesUpdate + _NextDayMilliseconds
                End If

                Dim jobObject As New AreaJob.DownloadCurrencyJob
                Dim Job As New CHCModelsLibrary.AreaModel.Service.Scheduler.JobSchedule

                Job.frequencies = _NextDayMilliseconds
                Job.nextTimeExecuted = nextTime
                Job.supportData = jobObject
                Job.type = CHCModelsLibrary.AreaModel.Service.Scheduler.JobSchedule.ScheduleJobType.other

                jobObject.parameter = exchangeId

                RaiseEvent AddScheduleJobCheckCurrencies(Job)
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("ServiceState.manageDownloadCurrencies", "manageDownloadCurrencies", ex.Message)
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("ServiceState.manageDownloadCurrencies", "manageDownloadCurrencies")
            End Try
        End Sub


        Private Sub exchangesEngine_SetExchangeActive(exchangeId As Integer, lastCurrenciesUpdate As Double, lastProductsUpdate As Double) Handles exchangesEngine.SetExchangeActive
            If exchangeReferencesEngine.currencyReferenceExist(exchangeId) Then
                If (lastCurrenciesUpdate = -1) Then
                    lastCurrenciesUpdate = exchangesEngine.select(exchangeId).lastCurrenciesCheck
                End If

                manageDownloadCurrencies(exchangeId, lastCurrenciesUpdate)
            End If
        End Sub

        Private Sub exchangeReferencesEngine_AddScheduleJobCheckCurrencies(exchangeId As Integer) Handles exchangeReferencesEngine.AddScheduleJobCheckCurrencies
            With exchangesEngine.select(exchangeId)
                If .isActive Then
                    manageDownloadCurrencies(exchangeId, .lastCurrenciesCheck)
                End If
            End With
        End Sub

    End Class

End Namespace
