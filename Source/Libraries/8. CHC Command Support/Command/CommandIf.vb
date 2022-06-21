Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command info 
    ''' </summary>
    Public Class CommandIf : Implements Models.CommandModel

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

        ''' <summary>
        ''' This method provide to execute batch command
        ''' </summary>
        ''' <param name="fileName"></param>
        ''' <returns></returns>
        Private Function executeBatchCommand(ByVal fileName As String) As Boolean
            Dim executor As New CommandExecutor
            Try
                executor.command = New CommandBuilder().run("-batch --fileName:" & fileName)

                Return executor.run()
            Catch ex As Exception
                RaiseEvent RaiseError($"Problem during processing batch command - {fileName}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to test if the Environment Repository not set or not
        ''' </summary>
        ''' <returns></returns>
        Private Function testEnvironmentRepositoryNotSet() As Boolean
            Try
                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()

                Try
                    path = IO.Path.Combine(path, "Environment.path")

                    If IO.File.Exists(path) Then
                        path = IO.File.ReadAllText(IO.Path.Combine(path, "Environment.path"))

                        Return (path.Length = 0)
                    Else
                        Return True
                    End If
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to test if environment current not set
        ''' </summary>
        ''' <returns></returns>
        Private Function testEnvironmentCurrentNotSet() As Boolean
            Try
                Dim path As String = AreaEngine.EnvironmentRepositoryEngine.searchUserEnvironmentPath()
                Dim environmentRepositoryPath As String = IO.Path.Combine(path, "Environment.path")
                Dim environmentSET As String = ""
                Dim currentEnvironment As String = ""

                If IO.File.Exists(environmentRepositoryPath) Then
                    environmentSET = IO.File.ReadAllText(environmentRepositoryPath)

                    environmentSET = IO.Path.Combine(environmentSET, "Environments.list")

                    currentEnvironment = AreaEngine.EnvironmentsEngine.getCurrent(environmentSET)

                    Return (currentEnvironment.Length = 0)
                Else
                    Return True
                End If
            Catch ex As Exception
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to get a default parameters not define or not
        ''' </summary>
        ''' <returns></returns>
        Private Function defaultParametersNotDefine() As Boolean
            Try
                Return (ApplicationCommon.defaultParameters.data.Count = 0)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get applications path not define
        ''' </summary>
        ''' <returns></returns>
        Private Function applicationsPathNotDefine() As Boolean
            Try
                Return (ApplicationCommon.appConfigurations.data.Count = 0)
            Catch ex As Exception
                Return False
            End Try
        End Function


        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Dim proceed As Boolean = True

            If proceed Then
                proceed = _Command.haveParameter("environmentRepositoryNotSet")
            End If
            If proceed Then
                proceed = _Command.haveParameter("batch")
            End If
            If proceed Then
                proceed = testEnvironmentRepositoryNotSet()
            End If
            If proceed Then
                Return executeBatchCommand(_Command.parameterValue("batch"))
            Else
                proceed = True
            End If

            If proceed Then
                proceed = _Command.haveParameter("environmentDefaultNotSet")
            End If
            If proceed Then
                proceed = _Command.haveParameter("batch")
            End If
            If proceed Then
                proceed = testEnvironmentCurrentNotSet()
            End If
            If proceed Then
                Return executeBatchCommand(_Command.parameterValue("batch"))
            Else
                proceed = True
            End If

            If proceed Then
                proceed = _Command.haveParameter("defaultParametersNotDefine")
            End If
            If proceed Then
                proceed = _Command.haveParameter("batch")
            End If
            If proceed Then
                proceed = defaultParametersNotDefine()
            End If
            If proceed Then
                Return executeBatchCommand(_Command.parameterValue("batch"))
            Else
                proceed = True
            End If

            If proceed Then
                proceed = _Command.haveParameter("applicationsPathNotDefine")
            End If
            If proceed Then
                proceed = _Command.haveParameter("batch")
            End If
            If proceed Then
                proceed = applicationsPathNotDefine()
            End If
            If proceed Then
                Return executeBatchCommand(_Command.parameterValue("batch"))
            Else
                proceed = True
            End If

            Return proceed
        End Function

    End Class

End Namespace
