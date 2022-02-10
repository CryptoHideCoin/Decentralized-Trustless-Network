Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Current Time 
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
                Dim parameterService As String = ""
                Dim parameterDataPath As String = ""
                Dim parameterPassword As String = ""

                If _Command.haveParameter("service") Then
                    parameterService = "--service:" & _Command.parameters("service").value
                End If
                If _Command.haveParameter("dataPath") Then
                    parameterDataPath = "--dataPath:" & _Command.parameters("dataPath").value
                End If
                If _Command.haveParameter("password") Then
                    parameterPassword = "--password:" & _Command.parameters("password").value
                End If
                If _Command.haveParameter("showAsFile") Then
                    If (parameterService.Length = 0) Or (parameterDataPath.Length = 0) Then
                        Console.WriteLine("Error: insufficient parameters")
                    End If

                    path = IO.Path.Combine(_Command.parameters("dataPath").value, "Settings")
                    path = IO.Path.Combine(path, _Command.parameters("service").value & ".Settings")

                    If Not IO.File.Exists(path) Then Return False
                    Process.Start("notepad.exe", path)

                    Return True
                End If

                path = Environment.CurrentDirectory
                path = IO.Directory.GetParent(path).FullName
                path = IO.Path.Combine(path, "CHC Sidechain Service Settings")

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, "CHCSidechainServiceSettings.exe")

                    If Not IO.File.Exists(path) Then
                        Console.WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        Process.Start(path, "-force " & parameterService & " " & parameterDataPath)
                    End If
                Else
                    Console.WriteLine("Error: the directory '" & path & "' is not exist")
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
