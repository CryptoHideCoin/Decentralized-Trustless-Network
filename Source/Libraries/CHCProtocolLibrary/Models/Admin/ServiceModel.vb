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
    ''' This class provides to expone the public information of this chain
    ''' </summary>
    Public Class InternalServiceInformation

        ''' <summary>
        ''' This enumeration contain the internal service state
        ''' </summary>
        Public Enum EnumInternalServiceState

            undefined
            starting
            waitToMaintenance
            started
            shutDown
            swithOff

        End Enum


        Public Property netWorkName As String = ""
        Public Property netWorkReferement As String = ""
        Public Property currentStatus As EnumInternalServiceState = EnumInternalServiceState.undefined
        Public Property chainName As String = ""
        Public Property identityPublicAddress As String = ""
        Public Property intranetMode As Boolean = False
        Public Property addressIP As String = ""
        Public Property completeAddress As String = ""
        Public Property platformHost As String = ""
        Public Property softwareRelease As String = ""

    End Class

    ''' <summary>
    ''' This class contain the information of service
    ''' </summary>
    Public Class InformationResponseModel

        Inherits General.RemoteResponse

        Public Property value As New InternalServiceInformation

    End Class

    ''' <summary>
    ''' This class contain the protocol supported of the service
    ''' </summary>
    Public Class SupportedProtocolsResponseModel

        Inherits General.RemoteResponse

        Public protocols As New List(Of String)

    End Class

End Namespace