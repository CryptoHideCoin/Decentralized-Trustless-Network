Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command a Get Current Environment
    ''' </summary>
    Public Class CommandGetCurrentEnvironment : Implements CommandModel

        Private Property _Command As CommandStructure

        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "environment.path")
                Dim environmentSET As String = ""
                Dim currentEnvironment As String = ""

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentSET = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentSET = IO.Path.Combine(environmentSET, "Environments.list")

                    currentEnvironment = AreaEngine.EnvironmentsEngine.getCurrent(environmentSET)

                    If (currentEnvironment.Length > 0) Then
                        Console.WriteLine("Environment current = '" & currentEnvironment & "'")
                    Else
                        Console.WriteLine("Error: current environment not found")
                    End If
                Else
                    Console.WriteLine("Error: Environment Repository not set")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
