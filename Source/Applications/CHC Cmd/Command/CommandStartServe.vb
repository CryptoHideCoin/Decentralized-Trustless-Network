Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Start Serve
    ''' </summary>
    Public Class CommandStartServe : Implements CommandModel

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
                Dim directory As String = ""
                Dim exeFileName As String = ""

                If _Command.haveParameter("service") Then
                    parameterService = "--service:" & _Command.parameterValue("service")
                End If
                If _Command.haveParameter("dataPath") Then
                    parameterDataPath = "--dataPath:" & _Command.parameterValue("dataPath")
                End If
                If _Command.haveParameter("password") Then
                    parameterPassword = "--password:" & _Command.parameterValue("password")
                End If

#If DEBUG Then
                path = "E:\CryptoHideCoinDTN\Binary\Sidechains\Windows\CHC Sidechain Service Runtime"
#Else
                path = Environment.CurrentDirectory
#End If

                Select Case _Command.parameterValue("service").ToLower()
                    Case "sidechainservice", "primary"
                        directory = "CHC Sidechain Service Runtime"
                        exeFileName = "CHCSidechainServiceRuntime.exe"
                End Select

                path = IO.Directory.GetParent(path).FullName
                path = IO.Path.Combine(path, directory)

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, exeFileName)

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
