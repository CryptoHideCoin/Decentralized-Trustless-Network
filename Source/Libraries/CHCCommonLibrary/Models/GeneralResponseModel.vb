Option Compare Text
Option Explicit On

Imports System.Xml.Serialization



Namespace AreaCommon.Models.General

    Public Class BooleanModel
        Public value As Boolean
    End Class


    ' TO DELETE
    Public Class StatusWorkModel

        Public Enum EnumStatusWork
            unAuthorized
            onWork
            offWork
        End Enum

        Public value As EnumStatusWork = EnumStatusWork.unAuthorized

    End Class

    Public Class IdentifyRecordLedger

        Public Property recordCoordinate As String = ""
        Public Property recordHash As String = ""

        Public Shared Function composeCoordinate(ByVal blockChainId As String, ByVal volumeId As String, ByVal blockId As String, Optional ByVal recordId As String = "") As String
            If (recordId.Length > 0) Then
                Return blockChainId & "-" & volumeId & "-" & blockId & "-" & recordId
            Else
                Return blockChainId & "-" & volumeId & "-" & blockId
            End If
        End Function

    End Class

    Public Class RemoteResponse

        Public Enum EnumResponseStatus
            responseComplete
            commandNotAllowed
            missingAuthorization
            systemOffline
            inError
        End Enum

        <XmlIgnore()> Public Property integrityTransactionChain As New IdentifyRecordLedger
        <XmlIgnore()> Public Property responseStatus As EnumResponseStatus = EnumResponseStatus.responseComplete
        <XmlIgnore()> Public Property errorDescription As String = ""
        <XmlIgnore()> Public Property requestTime As String = ""
        <XmlIgnore()> Public Property responseTime As String = ""

        <XmlIgnore()> Public Property masterNodePublicAddress As String = ""
        Public Property signature As String = ""

        Public Shared Function determinateStringObject(ByRef value As RemoteResponse) As String
            Dim result As String = ""

            result += value.IntegrityTransactionChain.recordCoordinate
            result += value.IntegrityTransactionChain.recordHash
            result += value.masterNodePublicAddress
            result += value.requestTime

            Select Case value.responseStatus
                Case EnumResponseStatus.responseComplete : result += "1"
                Case EnumResponseStatus.commandNotAllowed : result += "2"
                Case EnumResponseStatus.missingAuthorization : result += "3"
                Case EnumResponseStatus.systemOffline : result += "4"
                Case EnumResponseStatus.inError : result += "5"
            End Select

            result += value.responseTime

            Return result
        End Function

    End Class

End Namespace
