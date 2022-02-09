Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This class contain the processor of a command line
    ''' </summary>
    Public Class CommandProcessor

        Private Const _commandRelease As String = "release"
        Private Const _commandInfo As String = "info"
        Private Const _commandHelp As String = "help"
        Private Const _commandUpdateSystemDate As String = "updateSystemDate"
        Private Const _commandCurrentTime As String = "currentTime"
        Private Const _commandChainServiceSettings As String = "chainServiceSettings"
        Private Const _commandIPAddress As String = "ipAddress"


        Public Property command As New CommandStructure



        ''' <summary>
        ''' This method provide to execute a command
        ''' </summary>
        ''' <returns></returns>
        Public Function run() As Boolean
            Try
                Dim response As Boolean
                Dim classSupport As Models.CommandModel
                Dim engine As New CommandBuilder

                command = engine.run()

                Select Case command.code
                    Case _commandRelease.ToLower : classSupport = New Command.CommandRelease
                    Case _commandInfo.ToLower : classSupport = New Command.CommandInfo
                    Case _commandHelp.ToLower : classSupport = New Command.CommandHelp
                    Case _commandUpdateSystemDate.ToLower() : classSupport = New Command.CommandUpdateSystemDate
                    Case _commandCurrentTime.ToLower() : classSupport = New Command.CommandCurrentTime
                    Case _commandChainServiceSettings.ToLower() : classSupport = New Command.CommandChainServiceSettings
                    Case _commandIPAddress.ToLower() : classSupport = New Command.CommandIpAddress
                    Case Else
                        If (command.code.Length > 0) Then
                            Console.WriteLine(Chr(34) & command.code & Chr(34) & " not recognized")
                            Return False
                        ElseIf (command.parameters.Count > 0) Then
                            If (command.parameters.Values(command.parameters.Values.Count - 1).value.Trim().Length = 0) Then
                                Console.WriteLine("Syntax error")
                            Else
                                Console.WriteLine(Chr(34) & command.parameters.Values(command.parameters.Values.Count - 1).value & Chr(34) & " not recognized")
                            End If

                            Return False
                        Else
                            Return False
                        End If
                End Select

                classSupport.command = command

                response = classSupport.run()

                If response Then
                    If command.haveParameter("pause") Then
                        Console.WriteLine("")
                        Console.WriteLine("Press a key to continue")
                        Console.ReadKey()
                    End If
                End If

                Return response
            Catch ex As Exception
                CloseApplication(ex.Message)

                Return False
            End Try
        End Function

    End Class

End Namespace
