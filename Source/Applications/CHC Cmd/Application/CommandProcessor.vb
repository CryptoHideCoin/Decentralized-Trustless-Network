Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor

        Private WithEvents _Executor As New CHCCommandlineSupport.AreaCommon.CommandExecutor

        Private Sub executor_WriteLine(message As String) Handles _Executor.WriteLine
            Console.WriteLine(message)
        End Sub

        Private Sub executor_ReadKey() Handles _Executor.ReadKey
            Console.ReadKey()
        End Sub

        Private Sub _Executor_Process(applicationName As String, commandLine As String) Handles _Executor.Process
            Process.Start(applicationName, commandLine)
        End Sub

        Private Sub _Executor_IntegrityApplication(fileName As String) Handles _Executor.IntegrityApplication
            IntegrityApplication.executeRepairNewton(fileName)
        End Sub

        Private Sub _Executor_RaiseError(message As String) Handles _Executor.RaiseError
            CloseApplication(message)
        End Sub

        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                With New CommandBuilder()
                    _Executor.command = .run()

                    If (.lastErrorDescription.Length > 0) Then
                        Console.WriteLine("Error: " & .lastErrorDescription)
                        Console.WriteLine("")
                        Console.WriteLine("Press a key to continue")
                        Console.ReadKey()

                        Return False
                    End If
                End With

                Return _Executor.run()
            Catch ex As Exception
                CloseApplication(ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
