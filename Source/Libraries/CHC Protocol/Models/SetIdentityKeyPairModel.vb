Option Explicit On
Option Compare Text


' ****************************************
' File: Set Identity Keypair model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption





Namespace AreaCommon.Models.Security

    ''' <summary>
    ''' This class contain a KeyPair data
    ''' </summary>
    Public Class SetIdentityKeyPairModel

        Public Property publicAddress As String = ""
        Public Property privateKey As String = ""

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += publicAddress
            tmp += privateKey

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