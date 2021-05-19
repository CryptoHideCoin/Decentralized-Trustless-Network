Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models.Settings



Public Class AppState


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


    Public stateApplication As EnumStateApplication = EnumStateApplication.notDefined
    Public stateInChain As enumStateChain = enumStateChain.offChain

    Public connectedMoment As Date = Date.MinValue
    Public transactionChainConfigID As String = ""

    Public noConsoleMessage As Boolean = False

    Public publicIpAddress As String = ""
    Public localIpAddress As String = ""

End Class
