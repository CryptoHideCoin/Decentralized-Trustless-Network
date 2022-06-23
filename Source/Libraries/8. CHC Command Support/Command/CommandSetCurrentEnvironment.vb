Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command a Set Current Environment
    ''' </summary>
    Public Class CommandSetCurrentEnvironment : Implements CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements CommandModel.RaiseError
        Public Event ReadKey() Implements CommandModel.ReadKey


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
                    RaiseEvent RaiseError("Error: name missing")

                    Return False
                End If

                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environment.path")
                Dim environmentSET As String = ""

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentSET = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentSET = IO.Path.Combine(environmentSET, "Environments.list")

                    If AreaEngine.EnvironmentsEngine.setCurrent(environmentSET, _Command.parameterValue("name")) Then
                        RaiseEvent WriteLine("Environment set current")
                    Else
                        RaiseEvent WriteLine("Error: environment not found")
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
