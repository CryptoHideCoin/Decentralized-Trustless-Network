Option Compare Text
Option Explicit On

' ****************************************
' Engine: Check Sum functions
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************







Namespace AreaEngine.Miscellaneous

    ''' <summary>
    ''' This static class contain a check sum function
    ''' </summary>
    Public Class CheckSum

        ''' <summary>
        ''' This class contain the property of a complete structure of checksum
        ''' </summary>
        Public Class CompleteStructure

            Public Property originalText As String = ""
            Public Property checkPositive As Boolean = False

        End Class

        ''' <summary>
        ''' This method provide to create a checksum
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function create(ByVal value As String) As String
            Dim result As Integer = 0

            Try
                For a = 1 To value.Length
                    result = result + Asc(Mid(value, a, 1))
                Next

                Return Strings.Right("0000" & Hex(result), 4)
            Catch ex As Exception
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to verify a checksum of a file
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function verify(ByVal value As String) As CompleteStructure
            Dim result As New CompleteStructure

            Try
                Dim checkSumValue As String = value.Substring(value.Length - 6, 4)
                Dim checkBuildValue As String = ""

                result.originalText = value.Substring(4, value.Length - 10)

                checkBuildValue = create(result.originalText)

                result.checkPositive = (checkSumValue.CompareTo(checkBuildValue) = 0)
            Catch ex As Exception
            End Try

            Return result
        End Function

    End Class

End Namespace
