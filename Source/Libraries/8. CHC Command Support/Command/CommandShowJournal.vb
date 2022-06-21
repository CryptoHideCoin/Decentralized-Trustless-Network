Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Show Log 
    ''' </summary>
    Public Class CommandShowJournal : Implements Models.CommandModel

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

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Try
                Dim path As String = ""
                Dim applicationInfo As AreaEngine.ApplicationPathData
                Dim parameterService As String = ""
                Dim parameterDataPath As String = ""
                Dim parameterPassword As String = ""
                Dim parameterDate As String = ""
                Dim parameterAddress As String = ""
                Dim parameterSecurityKey As String = ""
                Dim parameterPause As String = ""

                AreaEngine.ApplicationPathEngine.init()
                applicationInfo = ApplicationCommon.appConfigurations.getApplicationData(AreaEngine.ApplicationID.showJournal)

                If _Command.haveParameter("service") Then
                    parameterService = "--service:" & _Command.parameterValue("service")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("service").Trim.Length > 0) Then
                    parameterService = "--service:" & ApplicationCommon.defaultParameters.getParameter("service")
                End If
                If (parameterService.Length = 0) Then
                    RaiseEvent WriteLine("Service parameter not defined")

                    Return False
                End If
                If _Command.haveParameter("dataPath") Then
                    parameterDataPath = "--dataPath:" & _Command.parameterValue("dataPath")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("dataPath").Trim.Length > 0) Then
                    parameterDataPath = "--dataPath:" & ApplicationCommon.defaultParameters.getParameter("dataPath")
                End If
                If (parameterService.Length = 0) Then
                    RaiseEvent WriteLine("DataPath parameter not defined")

                    Return False
                End If
                If _Command.haveParameter("date") Then
                    parameterDate = "--date:" & _Command.parameterValue("date")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("date").Trim.Length > 0) Then
                    parameterDate = "--date:" & ApplicationCommon.defaultParameters.getParameter("date")
                Else
                    parameterDate = "--date:" & Now.ToString("dd/MM/yyyy")
                End If
                If _Command.haveParameter("password") Then
                    parameterPassword = "--password:" & _Command.parameterValue("password")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("password").Trim.Length > 0) Then
                    parameterPassword = "--password:" & ApplicationCommon.defaultParameters.getParameter("password")
                End If
                If _Command.haveParameter("securityKey") Then
                    parameterSecurityKey = "--password:" & _Command.parameterValue("securityKey")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("securityKey").Trim.Length > 0) Then
                    parameterPassword = "--securitykey:" & ApplicationCommon.defaultParameters.getParameter("securityKey")
                End If
                If _Command.haveParameter("address") Then
                    parameterPassword = "--address:" & _Command.parameterValue("address")
                ElseIf (ApplicationCommon.defaultParameters.getParameter("address").Length > 0) Then
                    parameterPassword = "--address:" & ApplicationCommon.defaultParameters.getParameter("address")
                Else
                    parameterPassword = ""
                End If
                If _Command.haveParameter("pause") Then
                    parameterPause = "--pause"
                End If

                path = applicationInfo.rootPath
                path = IO.Path.Combine(path, applicationInfo.directoryName)

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, applicationInfo.applicationName)

                    If Not IO.File.Exists(path) Then
                        RaiseEvent WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        RaiseEvent Process(path, "-page " & parameterService & " " & parameterDataPath & " " & parameterPassword & " " & parameterDate & " " & parameterAddress & " " & parameterSecurityKey & " " & parameterPause)

                        Return True
                    End If
                Else
                    RaiseEvent WriteLine("Error: the directory '" & path & "' is not exist")
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
