Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Encryption




Namespace AreaEngine.Keys

    ''' <summary>
    ''' This class contain the KeyPair informations
    ''' </summary>
    Public Class KeyPair

        Public Property [public] As String = ""
        Public Property [private] As String = ""

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += [public]
            tmp += [private]

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
