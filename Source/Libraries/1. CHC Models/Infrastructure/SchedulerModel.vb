Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 21/02/2022
' ****************************************



Namespace AreaModel.Service.Scheduler

    ''' <summary>
    ''' This class contain all element of single slot of a scheduler
    ''' </summary>
    Public Class JobSchedule

        ''' <summary>
        ''' This list contain the costant of a job of type
        ''' </summary>
        Public Enum ScheduleJobType
            notDefined
            notifyLocalWorkMachine
            logRotate
            registryRotate
            performanceProfile
            refreshTracker
            counterRotate
            other
        End Enum

        Public Property [type] As ScheduleJobType
        Public Property nextTimeExecuted As Double = 0
        Public Property frequencies As Double = 0
        Public Property supportData As Object
    End Class

End Namespace
