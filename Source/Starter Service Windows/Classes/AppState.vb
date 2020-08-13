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
    Public runTimeStart As Boolean = False
    Public runTimeInExecute As Boolean = False

    Public adminConnection As Boolean = False
    Public engineConnection As Boolean = False

End Class
