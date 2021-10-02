Option Compare Text
Option Explicit On

' ****************************************
' Engine: String Extension
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************

Imports System.Runtime.CompilerServices






Namespace AreaEngine.Base

    ''' <summary>
    ''' This module contain the function to extend the string
    ''' </summary>
    Public Module CHCStringExtensions

        ''' <summary>
        ''' This method provide to code symbol to trasmission
        ''' </summary>
        ''' <param name="baseString"></param>
        <Extension()> Public Sub codeSymbol(ByRef baseString As String)
            baseString = baseString.Replace("§", "\0167")
        End Sub

        ''' <summary>
        ''' This method provide to decode symbol from trasmission
        ''' </summary>
        ''' <param name="baseString"></param>
        <Extension()> Public Sub decodeSymbol(ByRef baseString As String)
            baseString = baseString.Replace("\0167", "§")
        End Sub

    End Module

End Namespace