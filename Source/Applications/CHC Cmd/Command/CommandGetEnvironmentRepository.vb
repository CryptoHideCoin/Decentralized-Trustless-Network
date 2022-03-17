Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Get Environment Repository
    ''' </summary>
    Public Class CommandGetEnvironmentRepository : Implements CommandModel

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

                Try
                    path = IO.Path.Combine(path, "Environments.path")

                    If IO.File.Exists(path) Then
                        Console.WriteLine("Environment path = " & IO.File.ReadAllText(IO.Path.Combine(path, "Environments.path")))
                    End If

                    Return True
                Catch ex As Exception
                    Console.WriteLine("Error: Problem during get environment repository")
                End Try

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
