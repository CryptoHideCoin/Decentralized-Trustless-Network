Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaCommon.Models.Ledger

    ''' <summary>
    ''' This class contain the information relative the current block information
    ''' </summary>
    Public Class CurrentBlockInformationModel

        Public Property blockNumber As String = ""
        Public Property transactionNumber As Integer = 0


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = blockNumber

            tmp += transactionNumber.ToString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the page transaction information
    ''' </summary>
    Public Class CurrentBlockInformationResponseModel

        Inherits General.BaseRemoteResponse

        Public Property value As New CurrentBlockInformationModel

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = value.toString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class



End Namespace