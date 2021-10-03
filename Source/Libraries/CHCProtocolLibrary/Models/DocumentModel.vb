Option Compare Text
Option Explicit On

' ****************************************
' File: Notify Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Document

    ''' <summary>
    ''' This class contain the generic class relative a document
    ''' </summary>
    Public Class DocumentModel

        Public Property content As String = ""


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Return content
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
