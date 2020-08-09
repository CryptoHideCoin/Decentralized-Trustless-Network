Option Compare Text
Option Explicit On



Public Class AppState

    Public Enum enumStateApplication

        notDefined
        waitingToStart
        inStarting
        inRunning
        inShutDown
        inRestart

    End Enum


    Public uiVisible As Boolean = False
    Public currentApplication As enumStateApplication

End Class
