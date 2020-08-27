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

    Public Enum enumStateChain

        offChain
        duringCheckLedger
        duringAdmissionProcudure
        rejectedAdmission
        chainConnected
        duringRequestDisconnect

    End Enum

    Public Enum enumChainPosition

        toCreate
        toResume
        toConnect

    End Enum


    Public stateApplication As enumStateApplication = enumStateApplication.notDefined
    Public stateInChain As enumStateChain = enumStateChain.offChain
    Public actionToDo As enumChainPosition = enumChainPosition.toConnect

    Public connectedMoment As Date = Date.MinValue
    Public transactionChainConfigID As String = ""

    Public noConsoleMessage As Boolean = False

    Public publicIpAddress As String = ""
    Public localIpAddress As String = ""

End Class
