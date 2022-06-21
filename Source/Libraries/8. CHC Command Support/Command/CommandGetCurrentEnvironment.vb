Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command a Get Current Environment
    ''' </summary>
    Public Class CommandGetCurrentEnvironment : Implements Models.CommandModel

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
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environment.path")
                Dim environmentSET As String = ""
                Dim currentEnvironment As String = ""

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentSET = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentSET = IO.Path.Combine(environmentSET, "Environments.list")

                    currentEnvironment = AreaEngine.EnvironmentsEngine.getCurrent(environmentSET)

                    If (currentEnvironment.Length > 0) Then
                        RaiseEvent WriteLine("Environment current = '" & currentEnvironment & "'")
                    Else
                        RaiseEvent WriteLine("Error: current environment not found")
                    End If
                Else
                    RaiseEvent WriteLine("Error: Environment Repository not set")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
