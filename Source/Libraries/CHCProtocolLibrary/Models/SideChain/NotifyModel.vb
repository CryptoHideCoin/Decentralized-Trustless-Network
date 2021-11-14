Option Explicit On
Option Compare Text

' ****************************************
' File: Notify Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption


Namespace AreaCommon.Models.Network

    ''' <summary>
    ''' This class contain all information reguard the notify of a request
    ''' </summary>
    Public Class NotifyModel

        Public Property netWorkHash As String = ""
        Public Property chainHash As String = ""
        Public Property [type] As String = ""
        Public Property requestHash As String = ""
        Public Property publicAddress As String = ""
        Public Property signature As String = ""


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += netWorkHash
            tmp += chainHash
            tmp += [type]
            tmp += requestHash
            tmp += publicAddress

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