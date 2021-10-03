Option Compare Text
Option Explicit On

' ****************************************
' File: Information Service State
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaCommon.Models





Namespace AreaCommon.Models.Service

    ''' <summary>
    ''' This class contain the information of service
    ''' </summary>
    Public Class InformationResponseModel

        Inherits General.RemoteResponse

        ''' <summary>
        ''' This enumeration contain the internal service state
        ''' </summary>
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

    ''' <summary>
    ''' This class contain the protocol supported of the service
    ''' </summary>
    Public Class SupportedProtocolsResponseModel

        Inherits General.RemoteResponse

        Public protocols As New List(Of String)

    End Class

End Namespace