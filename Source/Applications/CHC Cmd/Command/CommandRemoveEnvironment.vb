Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Remove Environment
    ''' </summary>
    Public Class CommandRemoveEnvironment : Implements CommandModel

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
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environments.path")
                Dim environmentPath As String = ""

                If Not _Command.haveParameter("name") Then
                    Console.WriteLine("Error: name missing")

                    Return False
                End If

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentPath = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentPath = IO.Path.Combine(environmentPath, "Environments.list")

                    If AreaEngine.EnvironmentsEngine.removeItem(environmentPath, _Command.parameterValue("name")) Then
                        Console.WriteLine("Environment '" & _Command.parameterValue("name") & "' removed")
                    Else
                        Console.WriteLine("Environment '" & _Command.parameterValue("name") & "' missing")
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
