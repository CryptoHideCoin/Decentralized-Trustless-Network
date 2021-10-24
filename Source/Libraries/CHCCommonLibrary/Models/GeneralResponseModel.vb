Option Compare Text
Option Explicit On

' ****************************************
' Engine: Date time support
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************








Namespace AreaCommon.Models.General

    ''' <summary>
    ''' This model class contain the boolean
    ''' </summary>
    Public Class BooleanModel

        Public value As Boolean

    End Class

    ''' <summary>
    ''' This class provide to contain an essential data transaction
    ''' </summary>
    Public Class EssentialDataTransaction

        Public Property coordinate As String = ""
        Public Property hash As String = ""

        ''' <summary>
        ''' This static method provide to build a coordinate string
        ''' </summary>
        ''' <param name="blockChainId"></param>
        ''' <param name="volumeId"></param>
        ''' <param name="blockId"></param>
        ''' <param name="recordId"></param>
        ''' <returns></returns>
        Public Shared Function composeCoordinate(ByVal blockChainId As String, ByVal volumeId As String, ByVal blockId As String, Optional ByVal recordId As String = "") As String
            If (recordId.Length > 0) Then
                Return blockChainId & "-" & volumeId & "-" & blockId & "-" & recordId
            Else
                Return blockChainId & "-" & volumeId & "-" & blockId
            End If
        End Function
        ''' <summary>
        ''' This method provide to create a string cumulative of the important class member
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return coordinate & hash
        End Function

    End Class

    ''' <summary>
    ''' This class contain all element identify the last transaction save into the ledger
    ''' </summary>
    Public Class IdentifyLastTransaction

        Inherits EssentialDataTransaction

        Public Property registrationTimeStamp As Double = 0
        Public Property progressiveHash As String = ""

        ''' <summary>
        ''' This method provide to create a string cumulative of the important class member
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Return MyBase.toString & progressiveHash
        End Function

    End Class

    ''' <summary>
    ''' This base class contain the information reguard the response remote of a communication with the webservice
    ''' </summary>
    Public Class RemoteResponse

        Public Enum EnumResponseStatus
            responseComplete
            commandNotAllowed
            wrongNetwork
            missingAuthorization
            systemOffline
            inError
        End Enum

        Public Property integrityTransactionChain As New IdentifyLastTransaction
        Public Property responseStatus As EnumResponseStatus = EnumResponseStatus.responseComplete
        Public Property errorDescription As String = ""
        Public Property requestTime As String = ""
        Public Property responseTime As String = ""
        Public Property masterNodePublicAddress As String = ""

        Public Overridable Property signature As String = ""

        ''' <summary>
        ''' This method provide to extend the method ToString 
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim result As String = ""

            result += integrityTransactionChain.toString()
            result += masterNodePublicAddress
            result += requestTime

            Select Case responseStatus
                Case EnumResponseStatus.responseComplete : result += "1"
                Case EnumResponseStatus.commandNotAllowed : result += "2"
                Case EnumResponseStatus.missingAuthorization : result += "3"
                Case EnumResponseStatus.systemOffline : result += "4"
                Case EnumResponseStatus.inError : result += "5"
            End Select

            result += responseTime

            Return result
        End Function

    End Class

End Namespace
