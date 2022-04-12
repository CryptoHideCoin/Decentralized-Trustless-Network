Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage build a path
    ''' </summary>
    Public Class CommandBuildPath : Implements CommandModel

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

                    If engine.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.runTime, "Primary") Then
                        Console.WriteLine("Build path '" & parameterDataPath & "' complete!")
                    Else
                        Console.WriteLine("Error: the directory '" & parameterDataPath & "' is not exist")
                    End If
                Else
                    Console.WriteLine("Error: the directory '" & parameterDataPath & "' is not exist")
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
