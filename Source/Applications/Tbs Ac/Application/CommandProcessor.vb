Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor

        Private Const _CommandHelpPlus As String = "helpPlus"

        Private WithEvents _Executor As New CHCCommandlineSupport.AreaCommon.CommandExecutor
        Private WithEvents _ClassSupport As CommandModel


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
            If Not _Executor.commandNotRecognized Then
                CloseApplication(message)
            End If
        End Sub

        Private Sub _ClassSupport_IntegrityApplication(fileName As String) Handles _ClassSupport.IntegrityApplication
            IntegrityApplication.executeRepairNewton(fileName)
        End Sub

        Private Sub _ClassSupport_Process(applicationName As String, commandLine As String) Handles _ClassSupport.Process
            Process.Start(applicationName, commandLine)
        End Sub

        Private Sub _ClassSupport_RaiseError(message As String) Handles _ClassSupport.RaiseError
            If Not _Executor.commandNotRecognized Then
                CloseApplication(message)
            End If
        End Sub

        Private Sub _ClassSupport_ReadKey() Handles _ClassSupport.ReadKey
            Console.ReadKey()
        End Sub

        Private Sub _ClassSupport_WriteLine(message As String) Handles _ClassSupport.WriteLine
            Console.WriteLine(message)
        End Sub

        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim response As Boolean

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

                If Not _Executor.run(False) Then
                    Select Case _Executor.command.code
                        Case _CommandHelpPlus.ToLower : _ClassSupport = New Command.CommandHelpPlus
                        Case Else
                            If (_Executor.command.code.Length > 0) Then
                                Console.WriteLine(Chr(34) & _Executor.command.code & Chr(34) & " not recognized")
                                Console.ReadKey()

                                Return False
                            ElseIf (_Executor.command.parameters.Count > 0) Then
                                If (_Executor.command.parameters.Values(_Executor.command.parameters.Values.Count - 1).value.Trim().Length = 0) Then
                                    Console.WriteLine("Syntax error")
                                Else
                                    Console.WriteLine(Chr(34) & _Executor.command.parameters.Values(_Executor.command.parameters.Values.Count - 1).value & Chr(34) & " not recognized")
                                End If

                                Console.ReadKey()

                                Return False
                            Else
                                Return False
                            End If
                    End Select

                    _ClassSupport.command = _Executor.command

                    response = _ClassSupport.run()
                End If

                If _Executor.command.haveParameter("pause") Or Not response Then
                    Console.WriteLine("")
                    Console.WriteLine("Press a key to continue")
                    Console.ReadKey()
                End If
                If _Executor.command.haveParameter("wait") Then
                    If IsNumeric(_Executor.command.parameterValue("wait")) Then
#Disable Warning BC42016
                        Threading.Thread.Sleep(_Executor.command.parameterValue("wait"))
#Enable Warning BC42016
                    Else
                        Threading.Thread.Sleep(5000)
                    End If
                End If

                Return True
            Catch ex As Exception
                CloseApplication(ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
