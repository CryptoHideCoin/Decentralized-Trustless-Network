Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command a create new environment
    ''' </summary>
    Public Class CommandCreateNewEnvironment : Implements CommandModel

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
                    RaiseEvent WriteLine("Error: name missing")

                    Return False
                End If

                If Not _Command.haveParameter("dataPath") Then
                    RaiseEvent WriteLine("Error: dataPath parameter missing")

                    Return False
                End If

                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environment.path")
                Dim environmentPath As String = ""
                Dim active As Boolean = _Command.haveParameter("setActive")

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentPath = IO.File.ReadAllText(environmentRepositoryPath)
                    environmentPath = IO.Path.Combine(environmentPath, "Environments.list")

                    If AreaEngine.EnvironmentsEngine.createNew(environmentPath, _Command.parameterValue("name"), _Command.parameterValue("dataPath"), active) Then
                        RaiseEvent WriteLine("Environment created successfully")

                        If Not IO.Directory.Exists(_Command.parameterValue("dataPath")) Then
                            RaiseEvent WriteLine("Warning: " & _Command.parameterValue("dataPath") & " not exist")
                        End If
                    Else
                        RaiseEvent WriteLine("Error: Problem during create a new environment")
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
