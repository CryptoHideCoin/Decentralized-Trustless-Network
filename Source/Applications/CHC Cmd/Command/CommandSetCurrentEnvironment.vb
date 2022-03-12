Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command a Set Current Environment
    ''' </summary>
    Public Class CommandSetCurrentEnvironment : Implements CommandModel

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
                If Not _Command.haveParameter("name") Then
                    Console.WriteLine("Error: name missing")

                    Return False
                End If

                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environments.path")
                Dim environmentSET As String = ""

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentSET = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentSET = IO.Path.Combine(environmentSET, "Environments.list")

                    If AreaEngine.EnvironmentsEngine.setCurrent(environmentSET, _Command.parameterValue("name")) Then
                        Console.WriteLine("Environment set current")
                    Else
                        Console.WriteLine("Error: environment not found")
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
