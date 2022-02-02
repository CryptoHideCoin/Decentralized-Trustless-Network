Option Compare Text
Option Explicit On





Namespace AreaCommon.CommandLine

    ''' <summary>
    ''' This class contain all method to decode a command line
    ''' </summary>
    Public Class CommandLineDecoder


        ''' <summary>
        ''' This method provide to run a split of a Commandline
        ''' </summary>
        ''' <param name="commandLine"></param>
        Public Function run() As CommandArguments
            Dim result As New CommandArguments
            Dim words()
            Dim elements As New List(Of String)
            Dim engine As New CommandComposer
            Dim firstElement As Boolean = True

            Try
                If (Environment.CommandLine.Count <> 0) Then
                    words = Environment.CommandLine.Substring(1, Environment.CommandLine.Length - 1).Split(" ")

                    For Each item In words
                        If firstElement Then
                            firstElement = False
                        Else
                            If (item.ToString.Trim().Length > 0) Then
                                elements.Add(item.ToString.Trim())
                            End If
                        End If
                    Next

                    result = engine.run(elements)
                End If
            Catch ex As Exception
                Return New CommandArguments
            End Try

            Return result
        End Function

    End Class

End Namespace
