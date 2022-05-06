Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine






Namespace AreaCommon

    ''' <summary>
    ''' This class contain the executor of a command line
    ''' </summary>
    Public Class CommandExecutor

        Private Const _CommandRelease As String = "release"
        Private Const _CommandInfo As String = "info"
        Private Const _CommandHelp As String = "help"
        Private Const _CommandUpdateSystemDate As String = "updateSystemDate"
        Private Const _CommandCurrentTime As String = "currentTime"
        Private Const _CommandChainServiceSettings As String = "sideChainServiceSettings"
        Private Const _CommandIPAddress As String = "ipAddress"
        Private Const _CommandShowLog As String = "showLog"
        Private Const _CommandStopServe As String = "stopServe"
        Private Const _CommandTestServe As String = "testServe"
        Private Const _CommandStartServe As String = "startServe"
        Private Const _CommandSetEnvironmentRepository As String = "setEnvironmentRepository"
        Private Const _CommandGetEnvironmentRepository As String = "getEnvironmentRepository"
        Private Const _CommandCreateNewEnvironment As String = "createNewEnvironment"
        Private Const _CommandGetEnvironmentList As String = "getEnvironmentList"
        Private Const _CommandRemoveEnvironment As String = "removeEnvironment"
        Private Const _CommandSetCurrentEnvironment As String = "setCurrentEnvironment"
        Private Const _CommandGetCurrentEnvironment As String = "getCurrentEnvironment"
        Private Const _CommandGetApplicationsPath As String = "getApplicationsPath"
        Private Const _CommandWait As String = "wait"
        Private Const _CommandPause As String = "pause"
        Private Const _CommandSetDefaultParameter As String = "setDefaultParameter"
        Private Const _CommandGetDefaultParameters As String = "getDefaultParameters"
        Private Const _CommandStatusServe As String = "statusServe"
        Private Const _CommandBatch As String = "batch"
        Private Const _CommandIf As String = "if"
        Private Const _CommandTestRAWServe As String = "testRAWServe"
        Private Const _CommandNote As String = "note"
        Private Const _CommandWrite As String = "write"
        Private Const _CommandBuildPath As String = "buildPath"
        Private Const _CommandLog As String = "Log"


        Public Property command As New CommandStructure


        Public Function run() As Boolean

            Dim classSupport As Models.CommandModel
            Dim response As Boolean

            If command.isPath Then
                command.parameters.Clear()

                command.addNewParameter($"--fileName:{command.code.Trim()}")

                command.code = "batch"
            End If

            Select Case command.code
                Case _CommandRelease.ToLower : classSupport = New Command.CommandRelease
                Case _CommandInfo.ToLower : classSupport = New Command.CommandInfo
                Case _CommandHelp.ToLower : classSupport = New Command.CommandHelp
                Case _CommandUpdateSystemDate.ToLower() : classSupport = New Command.CommandUpdateSystemDate
                Case _CommandCurrentTime.ToLower() : classSupport = New Command.CommandCurrentTime
                Case _CommandChainServiceSettings.ToLower() : classSupport = New Command.CommandChainServiceSettings
                Case _CommandIPAddress.ToLower() : classSupport = New Command.CommandIPAddress
                Case _CommandShowLog.ToLower() : classSupport = New Command.CommandShowLog
                Case _CommandStopServe.ToLower() : classSupport = New Command.CommandStopServe
                Case _CommandTestServe.ToLower() : classSupport = New Command.CommandTestServe
                Case _CommandStartServe.ToLower() : classSupport = New Command.CommandStartServe
                Case _CommandSetEnvironmentRepository.ToLower : classSupport = New Command.CommandSetEnvironmentRepository
                Case _CommandGetEnvironmentRepository.ToLower : classSupport = New Command.CommandGetEnvironmentRepository
                Case _CommandCreateNewEnvironment.ToLower : classSupport = New Command.CommandCreateNewEnvironment
                Case _CommandGetEnvironmentList.ToLower : classSupport = New Command.CommandGetEnvironmentList
                Case _CommandRemoveEnvironment.ToLower : classSupport = New Command.CommandRemoveEnvironment
                Case _CommandSetCurrentEnvironment.ToLower : classSupport = New Command.CommandSetCurrentEnvironment
                Case _CommandGetCurrentEnvironment.ToLower : classSupport = New Command.CommandGetCurrentEnvironment
                Case _CommandGetApplicationsPath.ToLower : classSupport = New Command.CommandGetApplicationsPath
                Case _CommandWait.ToLower() : classSupport = New Command.CommandWait
                Case _CommandSetDefaultParameter.ToLower() : classSupport = New Command.CommandSetDefaultParameter
                Case _CommandGetDefaultParameters.ToLower() : classSupport = New Command.CommandGetDefaultParameters
                Case _CommandPause.ToLower() : classSupport = New Command.CommandPause
                Case _CommandStatusServe.ToLower() : classSupport = New Command.CommandStatusServe
                Case _CommandBatch.ToLower() : classSupport = New Command.CommandBatch
                Case _CommandIf.ToLower() : classSupport = New Command.CommandIf
                Case _CommandTestRAWServe.ToLower() : classSupport = New Command.CommandTestRAWServe
                Case _CommandNote.ToLower() : classSupport = New Command.CommandNote
                Case _CommandWrite.ToLower() : classSupport = New Command.CommandWrite
                Case _CommandBuildPath.ToLower() : classSupport = New Command.CommandBuildPath
                Case _CommandLog.ToLower() : classSupport = New Command.CommandLog
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
#Disable Warning BC42016
                    Threading.Thread.Sleep(_command.parameterValue("wait"))
#Enable Warning BC42016
                Else
                    Threading.Thread.Sleep(5000)
                End If
            End If

            Return response
        End Function

    End Class

End Namespace
