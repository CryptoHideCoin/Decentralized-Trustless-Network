Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models



Namespace AreaCommon.Models.ServiceModel


    Public Class InformationResponseModel

        Inherits General.RemoteResponse

        Public Enum enumServiceState

            notDefined
            starting
            waitToMaintenance
            started
            shutDown
            swithOff

        End Enum

        Public currentStatus As enumServiceState
        Public adminPublicWalletAddress As String = ""
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