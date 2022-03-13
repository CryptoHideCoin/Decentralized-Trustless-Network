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
        Private Const _commandChainServiceSettings As String = "sideChainServiceSettings"
        Private Const _commandIPAddress As String = "ipAddress"
        Private Const _commandShowLog As String = "showLog"
        Private Const _commandStopServe As String = "stopServe"
        Private Const _commandTestServe As String = "testServe"
        Private Const _commandStartServe As String = "startServe"
        Private Const _commandSetEnvironmentRepository As String = "setEnvironmentRepository"
        Private Const _commandGetEnvironmentRepository As String = "getEnvironmentRepository"
        Private Const _commandCreateNewEnvironment As String = "createNewEnvironment"
        Private Const _commandGetEnvironmentList As String = "getEnvironmentList"
        Private Const _commandRemoveEnvironment As String = "removeEnvironment"
        Private Const _commandSetCurrentEnvironment As String = "setCurrentEnvironment"
        Private Const _commandGetCurrentEnvironment As String = "getCurrentEnvironment"
        Private Const _commandGetApplicationsPath As String = "getApplicationsPath"
        Private Const _commandWait As String = "wait"
        Private Const _commandPause As String = "pause"
        Private Const _commandSetDefaultParameter As String = "setDefaultParameter"
        Private Const _commandGetDefaultParameters As String = "getDefaultParameters"


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
                    Case _commandIPAddress.ToLower() : classSupport = New Command.CommandIPAddress
                    Case _commandShowLog.ToLower() : classSupport = New Command.CommandShowLog
                    Case _commandStopServe.ToLower() : classSupport = New Command.CommandStopServe
                    Case _commandTestServe.ToLower() : classSupport = New Command.CommandTestServe
                    Case _commandStartServe.ToLower() : classSupport = New Command.CommandStartServe
                    Case _commandSetEnvironmentRepository.ToLower : classSupport = New Command.CommandSetEnvironmentRepository
                    Case _commandGetEnvironmentRepository.ToLower : classSupport = New Command.CommandGetEnvironmentRepository
                    Case _commandCreateNewEnvironment.ToLower : classSupport = New Command.CommandCreateNewEnvironment
                    Case _commandGetEnvironmentList.ToLower : classSupport = New Command.CommandGetEnvironmentList
                    Case _commandRemoveEnvironment.ToLower : classSupport = New Command.CommandRemoveEnvironment
                    Case _commandSetCurrentEnvironment.ToLower : classSupport = New Command.CommandSetCurrentEnvironment
                    Case _commandGetCurrentEnvironment.ToLower : classSupport = New Command.CommandGetCurrentEnvironment
                    Case _commandGetApplicationsPath.ToLower : classSupport = New Command.CommandGetApplicationsPath
                    Case _commandWait : classSupport = New Command.CommandWait
                    Case _commandSetDefaultParameter : classSupport = New Command.CommandSetDefaultParameter
                    Case _commandGetDefaultParameters : classSupport = New Command.CommandGetDefaultParameters
                    Case _commandPause : classSupport = New Command.CommandPause
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

                If command.haveParameter("pause") Or Not response Then
                    Console.WriteLine("")
                    Console.WriteLine("Press a key to continue")
                    Console.ReadKey()
                End If
                If _command.haveParameter("wait") Then
                    If IsNumeric(_command.parameterValue("wait")) Then
                        Threading.Thread.Sleep(_command.parameterValue("wait"))
                    Else
                        Threading.Thread.Sleep(5000)
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
