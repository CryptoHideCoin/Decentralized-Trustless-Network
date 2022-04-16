Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command info 
    ''' </summary>
    Public Class CommandBatch : Implements CommandModel

        Private Property _Command As CommandStructure

        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        ''' <summary>
        ''' This method provide to process a single command
        ''' </summary>
        ''' <param name="singleCommand"></param>
        ''' <returns></returns>
        Private Function processSingleCommand(ByVal singleCommand As String) As Boolean
            Dim executor As New CommandExecutor
            Try
                If (singleCommand.Length > 0) Then
                    If (singleCommand.Substring(0, 1).CompareTo("-") <> 0) Then
                        singleCommand = "-" & singleCommand
                    End If

                    executor.command = New CommandBuilder().run(singleCommand)

                    Return executor.run()
                Else
                    Console.WriteLine("")
                End If

                Return True
            Catch ex As Exception
                Console.WriteLine("Problem during processing single command - " & singleCommand)

            Return False
            End Try
        End Function

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim fileName As String

                If Not _Command.haveParameter("fileName") Then
                    Console.WriteLine("Error: file name batch missing")

                    Return False
                End If

                fileName = _Command.parameterValue("fileName")

                If Not IO.File.Exists(fileName) Then
                    Console.WriteLine("Error: file not found")

                    Return False
                End If

                Dim fileContent As String = My.Computer.FileSystem.ReadAllText(fileName)
#Disable Warning BC42016
                Dim commands As String() = fileContent.Split(vbNewLine)
#Enable Warning BC42016

                For Each singleCommand In commands
                    singleCommand = singleCommand.Replace(vbLf, "").Trim()

                    If (singleCommand.Length > 0) Then
                        processSingleCommand(singleCommand.Trim())
                    End If
                Next
            Catch ex As Exception
                Console.WriteLine("Error: Problem during process batch")

                Return False
            End Try

            Return True
        End Function

    End Class

End Namespace
