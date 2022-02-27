Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 21/02/2022
' ****************************************




Namespace AreaModel.Network.Response

    Public Class BaseRemoteResponse

        Public Enum EnumResponseStatus
            responseComplete
            commandNotAllowed
            wrongNetwork
            missingAuthorization
            systemOffline
            inError
        End Enum

        Public Property responseStatus As EnumResponseStatus = EnumResponseStatus.responseComplete
        Public Property errorDescription As String = ""
        Public Property responseTime As Double
        Public Property senderAddress As String = ""

        Public Overridable Property signature As String = ""

        ''' <summary>
        ''' This method provide to extend the method ToString 
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim result As String = ""

            result += senderAddress
            result += responseTime.ToString()

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

    ''' <summary>
    ''' This base class contain the information reguard the response remote of a communication with the webservice
    ''' </summary>
    Public Class RemoteResponse

        Inherits BaseRemoteResponse

        Public Property integrityTransactionChain As New AreaModel.Ledger.IdentifyLastTransaction

        ''' <summary>
        ''' This method provide to extend the method ToString 
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim result As String = ""

            result += integrityTransactionChain.toString()
            result += senderAddress

            Select Case responseStatus
                Case EnumResponseStatus.responseComplete : result += "1"
                Case EnumResponseStatus.commandNotAllowed : result += "2"
                Case EnumResponseStatus.missingAuthorization : result += "3"
                Case EnumResponseStatus.systemOffline : result += "4"
                Case EnumResponseStatus.inError : result += "5"
            End Select

            result += responseTime.ToString()

            Return result
        End Function

    End Class

End Namespace
