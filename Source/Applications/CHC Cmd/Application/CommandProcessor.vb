Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor






        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim executor As New CommandExecutor

                With New CommandBuilder()
                    executor.command = .run()

                    If (.lastErrorDescription.Length > 0) Then
                        Console.WriteLine("Error: " & .lastErrorDescription)
                        Console.WriteLine("")
                        Console.WriteLine("Press a key to continue")
                        Console.ReadKey()

                        Return False
                    End If
                End With

                Return executor.run()
            Catch ex As Exception
                CloseApplication(ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
