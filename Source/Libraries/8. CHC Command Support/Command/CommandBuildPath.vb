Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage build a path
    ''' </summary>
    Public Class CommandBuildPath : Implements CommandModel

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
                Dim path As String = ""
                Dim applicationInfo As AreaEngine.ApplicationPathData
                Dim parameterService As String = ""
                Dim parameterDataPath As String = ""
                Dim parameterPassword As String = ""

                AreaEngine.ApplicationPathEngine.init()
                applicationInfo = ApplicationCommon.appConfigurations.getApplicationData(AreaEngine.ApplicationID.sideChainServiceSettings)

                If _Command.haveParameter("dataPath") Then
                    path = _Command.parameterValue("dataPath")
                Else
                    path = ApplicationCommon.defaultParameters.getParameter("dataPath")
                End If

                parameterDataPath = $"--dataPath:{path}"

                If IO.Directory.Exists(path) Then
                    Dim engine As New CHCProtocolLibrary.AreaSystem.VirtualPathEngine

                    engine.directoryData = path

                    If engine.init("Primary") Then
                        RaiseEvent WriteLine($"Build path '{parameterDataPath}' complete!")
                    Else
                        RaiseEvent WriteLine("Error: the directory '{parameterDataPath}' is not exist")
                    End If
                Else
                    RaiseEvent WriteLine("Error: the directory '{parameterDataPath}' is not exist")
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
