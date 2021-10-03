Option Compare Text
Option Explicit On

' ****************************************
' File: Settings Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************






Namespace AreaCommon.Models.Settings

    ''' <summary>
    ''' This enumeration contain the value of position of the service
    ''' </summary>
    Public Enum EnumStateApplication
        notDefined
        waitingToStart
        inStarting
        inRunning
        inShutDown
        inRestart
    End Enum

End Namespace

