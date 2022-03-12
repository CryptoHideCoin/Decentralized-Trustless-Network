Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Sidechain Service Settings
    ''' </summary>
    Public Class CommandChainServiceSettings : Implements CommandModel

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

                If _Command.haveParameter("service") Then
                    parameterService = "--service:" & _Command.parameterValue("service")
                End If
                If _Command.haveParameter("dataPath") Then
                    parameterDataPath = "--dataPath:" & _Command.parameterValue("dataPath")
                End If
                If _Command.haveParameter("password") Then
                    parameterPassword = "--password:" & _Command.parameterValue("password")
                End If
                If _Command.haveParameter("showAsFile") Then
                    If (parameterService.Length = 0) Or (parameterDataPath.Length = 0) Then
                        Console.WriteLine("Error: insufficient parameters")
                    End If

                    path = IO.Path.Combine(_Command.parameterValue("dataPath"), "Settings")
                    path = IO.Path.Combine(path, _Command.parameterValue("service") & ".Settings")

                    If Not IO.File.Exists(path) Then Return False
                    Process.Start("notepad.exe", path)

                    Return True
                End If

                path = applicationInfo.rootPath
                path = IO.Path.Combine(path, applicationInfo.directoryName)

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, applicationInfo.applicationName)

                    If Not IO.File.Exists(path) Then
                        Console.WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        Process.Start(path, "-force " & parameterService & " " & parameterDataPath & " " & parameterPassword)

                        Return True
                    End If
                Else
                    Console.WriteLine("Error: the directory '" & path & "' is not exist")
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
