Option Compare Text
Option Explicit On

' ****************************************
' Engine: Common
' Release Engine: 1.0 
' 
' Date last successfully test: 03/06/2022
' ****************************************




Namespace AreaCommon

    Module Main

        Public WithEvents state As New TradingBotSystemLibrary.AreaService.Runtime.Models.ServiceState

        Public Property consoleSupport As New Startup.ConsoleWriter

        Private Sub state_AddScheduleJobCheckCurrencies(ByRef job As CHCModelsLibrary.AreaModel.Service.Scheduler.JobSchedule) Handles state.AddScheduleJobCheckCurrencies
            AreaCommon.Startup.Scheduler.addTradeJob(job)
        End Sub

    End Module

End Namespace
