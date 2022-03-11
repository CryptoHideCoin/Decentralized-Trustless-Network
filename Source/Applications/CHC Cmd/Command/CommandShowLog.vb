Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Show Log 
    ''' </summary>
    Public Class CommandShowLog : Implements CommandModel

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
                Dim parameterMode As String = ""
                Dim parameterAddress As String = ""
                Dim parameterSecurityKey As String = ""

                If _Command.haveParameter("service") Then
                    parameterService = "--service:" & _Command.parameterValue("service")
                End If
                If _Command.haveParameter("dataPath") Then
                    parameterDataPath = "--dataPath:" & _Command.parameterValue("dataPath")
                End If
                If _Command.haveParameter("password") Then
                    parameterPassword = "--password:" & _Command.parameterValue("password")
                End If
                If _Command.haveParameter("securityKey") Then
                    parameterSecurityKey = "--password:" & _Command.parameterValue("securityKey")
                End If
                If _Command.haveParameter("mode") Then
                    parameterMode = "--mode:" & _Command.parameterValue("mode")
                Else
                    parameterMode = "--mode:Console"
                End If
                If _Command.haveParameter("address") Then
                    parameterPassword = "--address:" & _Command.parameterValue("address")
                Else
                    parameterPassword = "--address:localhost"
                End If

#If DEBUG Then
                path = "E:\CryptoHideCoinDTN\Binary\Applications\Console\CHC Cmd"
#Else
                path = Environment.CurrentDirectory
#End If

                path = IO.Directory.GetParent(path).FullName
                path = IO.Path.Combine(path, "CHC Show Log")

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, "CHCShowlog.exe")

                    If Not IO.File.Exists(path) Then
                        Console.WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        Process.Start(path, "-force " & parameterService & " " & parameterDataPath & " " & parameterPassword & " " & parameterMode & " " & parameterAddress & " " & parameterSecurityKey)

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
