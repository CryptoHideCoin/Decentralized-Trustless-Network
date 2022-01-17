Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Ledger

    ''' <summary>
    ''' This class contain the block count information
    ''' </summary>
    Public Class VolumeInformationResponseModel

        Inherits General.BaseRemoteResponse

        Public Property value As Integer = 0

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