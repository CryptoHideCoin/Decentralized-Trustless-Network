Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models



Namespace AreaCommon.Models.Service


    Public Class InformationResponseModel

        Inherits General.RemoteResponse

        Public Enum EnumInternalServiceState

            notDefined
            starting
            waitToMaintenance
            started
            shutDown
            swithOff

        End Enum

        Public currentStatus As EnumInternalServiceState = EnumInternalServiceState.notDefined
        Public adminPublicAddress As String = ""
        Public chainName As String = ""
        Public platformHost As String = ""
        Public softwareRelease As String = ""
        Public addressIP As String = ""

    End Class


    Public Class SupportedProtocolsResponseModel

        Inherits General.RemoteResponse

        Public protocols As New List(Of String)

    End Class


End Namespace