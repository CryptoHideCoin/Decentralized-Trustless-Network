Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class provide to send a performance profile command to serve
    ''' </summary>
    Public Class CommandGetPerformanceProfile : Implements CommandModel

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
                Dim applicationInfo As AreaEngine.ApplicationPathData
                Dim path As String = "", parameterService As String = "", parameterServiceName As String = ""
                Dim parameterDataPath As String = "", parameterDataPathValue As String = "", parameterPassword As String = ""
                Dim parameterSecurityKey As String = "", parameters As String = ""
                Dim directory As String = "", exeFileName As String = ""

                AreaEngine.ApplicationPathEngine.init()

                applicationInfo = ApplicationCommon.appConfigurations.getApplicationData(AreaEngine.ApplicationID.showPerformance)

                If _Command.haveParameter("service") Then
                    parameterServiceName = _Command.parameterValue("service")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("service").Length > 0) Then
                    parameterServiceName = ApplicationCommon.defaultParameters.getParameter("service")
                End If
                If (parameterService.Length > 0) Then
                    parameterService = $"--service:{parameterServiceName}"
                End If

                If _Command.haveParameter("dataPath") Then
                    parameterDataPathValue = _Command.parameterValue("dataPath")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("dataPath").Length > 0) Then
                    parameterDataPathValue = ApplicationCommon.defaultParameters.getParameter("dataPath")
                End If
                If (parameterDataPathValue.Length > 0) Then
                    parameterDataPath = $"--dataPath:{parameterDataPathValue}"
                End If

                If _Command.haveParameter("password") Then
                    parameterPassword = "--password:" & _Command.parameterValue("password")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("password").Length > 0) Then
                    parameterPassword = "--password:" & ApplicationCommon.defaultParameters.getParameter("password")
                End If
                If _Command.haveParameter("securityKey") Then
                    parameterSecurityKey = "--securityKey:" & _Command.parameterValue("securityKey")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("securityKey").Length > 0) Then
                    parameterSecurityKey = "--securityKey:" & ApplicationCommon.defaultParameters.getParameter("securityKey")
                End If

                Select Case parameterServiceName.ToLower()
                    Case "localworkmachine"
                        applicationInfo = ApplicationCommon.appConfigurations.getApplicationData(AreaEngine.ApplicationID.localWorkMachine)
                        directory = applicationInfo.directoryName
                        exeFileName = "CHCLocalWorkMachine.exe"
                        parameters = parameterDataPath & " " & parameterPassword
                    Case "sidechainservice"
                        applicationInfo = ApplicationCommon.appConfigurations.getApplicationData(AreaEngine.ApplicationID.sideChainService)
                        directory = applicationInfo.directoryName
                        exeFileName = applicationInfo.applicationName
                        parameters = parameterDataPath & " " & parameterPassword
                    Case "primary"
                        directory = "CHC Primary Service Runtime"
                        exeFileName = "CHCPrimaryServiceRuntime.exe"
                        parameters = parameterDataPath & " " & parameterPassword
                    Case Else
                        Console.WriteLine($"Error: {parameterServiceName} service not managed")

                        Return False
                End Select

                path = applicationInfo.rootPath
                path = IO.Path.Combine(path, directory)

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, exeFileName)

                    If Not IO.File.Exists(path) Then
                        Console.WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        Process.Start(path, "-force " & parameters)

                        Return True
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
