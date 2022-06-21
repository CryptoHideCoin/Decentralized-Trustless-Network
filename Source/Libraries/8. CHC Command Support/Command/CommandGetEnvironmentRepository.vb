Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Get Environment Repository
    ''' </summary>
    Public Class CommandGetEnvironmentRepository : Implements Models.CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements Models.CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements Models.CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements Models.CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements Models.CommandModel.RaiseError
        Public Event ReadKey() Implements Models.CommandModel.ReadKey


        Private Property CommandModel_command As CommandStructure Implements Models.CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Try
                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()

                Try
                    path = IO.Path.Combine(path, "Environment.path")

                    If IO.File.Exists(path) Then
                        path = IO.File.ReadAllText(path)

                        RaiseEvent WriteLine("Environment path = " & path)
                    Else
                        RaiseEvent WriteLine("Environment not set")
                    End If

                    Return True
                Catch ex As Exception
                    RaiseEvent WriteLine("Error: Problem during get environment repository")
                End Try

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
