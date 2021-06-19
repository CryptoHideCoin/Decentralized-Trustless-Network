Option Compare Text
Option Explicit On





Namespace AreaEngine.Miscellaneous

    Public Class CheckSum

        Public Class CompleteStructure
            Public Property originalText As String = ""
            Public Property checkPositive As Boolean = False
        End Class


        Public Shared Function create(ByVal value As String) As String
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

        Public Shared Function verify(ByVal value As String) As CompleteStructure
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
