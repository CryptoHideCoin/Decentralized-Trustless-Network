Option Compare Text
Option Explicit On


Imports System.Runtime.CompilerServices







Namespace CHCEngines.Base


    Public Module CHCStringExtensions


        <Extension()> Public Sub codeSymbol(ByRef baseString As String)

            baseString = baseString.Replace("§", "\0167")

        End Sub

        <Extension()> Public Sub decodeSymbol(ByRef baseString As String)

            baseString = baseString.Replace("\0167", "§")

        End Sub


    End Module


End Namespace