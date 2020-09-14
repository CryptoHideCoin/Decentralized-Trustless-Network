Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Miscellaneous



Namespace AreaCommon


    Public Class ManageCommandLine

        Private _commandLine As New CommandLineParameters
        Private _completePathSettingFile As String = ""

        Public parameters As New AppSettings

        Public haveParameters As Boolean = False



        Private Sub decodeCommandLine()

            Try

                If _commandLine.exist("DataPath".ToLower()) Then

                    parameters.data.dataPath = _commandLine.GetValue("DataPath".ToLower())

                    If (parameters.data.dataPath.Length > 0) Then

                        If Not IO.Directory.Exists(parameters.data.dataPath) Then
                            parameters.data.dataPath = ""
                        Else
                            haveParameters = True
                        End If

                    End If

                End If

                If _commandLine.exist("Settings".ToLower()) Then

                    If (parameters.data.dataPath.Trim.Length() = 0) Then

                        paths.directoryData = paths.readDefinePath()

                        If (paths.directoryData.Trim.Length() > 0) Then
                            paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.loader)
                        End If

                    End If

                    If (paths.directoryData.Trim.Length() > 0) Then
                        settings.fileName = IO.Path.Combine(paths.directoryData, paths.settingFileName)

                        settings.read()
                    End If

                    Dim tmp As New Settings

                    tmp.ShowDialog()

                    End

                End If

                If _commandLine.exist("PortNumber".ToLower()) Then

                    If IsNumeric(_commandLine.GetValue("PortNumber".ToLower())) Then
                        parameters.data.portNumber = _commandLine.GetValue("PortNumber".ToLower())

                        haveParameters = True
                    End If

                End If
                If _commandLine.exist("WriteLogFile".ToLower()) Then
                    parameters.data.useTrack = _commandLine.GetValue("WriteLogFile".ToLower())

                    haveParameters = True
                End If
                If _commandLine.exist("UseEventRegistry".ToLower()) Then
                    parameters.data.useEventRegistry = _commandLine.GetValue("UseEventRegistry".ToLower())

                    haveParameters = True
                End If
                If _commandLine.exist("MasternodeAdminURL".ToLower()) Then
                    parameters.data.urlMasternodeAdmin = _commandLine.GetValue("MasternodeAdminURL".ToLower())

                    haveParameters = True
                End If
                If _commandLine.exist("MasternodeAdminCertificate".ToLower()) Then
                    parameters.data.certificateMasternodeAdmin = _commandLine.GetValue("MasternodeAdminCertificate".ToLower())

                    haveParameters = True
                End If
                If _commandLine.exist("MasternodeRuntimeURL".ToLower()) Then
                    parameters.data.urlMasternodeRuntime = _commandLine.GetValue("MasternodeRuntimeURL".ToLower())

                    haveParameters = True
                End If
                If _commandLine.exist("MasternodeRuntimeCertificate".ToLower()) Then
                    parameters.data.certificateMasternodeRuntime = _commandLine.GetValue("MasternodeRuntimeCertificate".ToLower())

                    haveParameters = True
                End If
                If _commandLine.exist("ConfigFileName".ToLower()) Then
                    _completePathSettingFile = _commandLine.GetValue("ConfigFileName".ToLower())
                End If
                If _commandLine.exist("Gui".ToLower()) Then
                    parameters.data.gui = True

                    haveParameters = True
                End If
                If _commandLine.exist("?") Or _commandLine.exist("help".ToLower()) Then

                    log.trackIntoConsole("Allows remote administration service to run")
                    log.trackIntoConsole()
                    log.trackIntoConsole("  /DataPath                     Force a main path when the application work")
                    log.trackIntoConsole("  /PortNumber                   Force port number to remotely control")
                    log.trackIntoConsole("  /WriteLogFile                 Enable log file writing")
                    log.trackIntoConsole("  /UseEventRegistry             Enable writing of system events")
                    log.trackIntoConsole("  /MasternodeStartURL           Set the url of the masternode start")
                    log.trackIntoConsole("  /MasternodeStartCertificate   Set the certificate of the masternode start")
                    log.trackIntoConsole("  /MasternodeRuntimeURL         Set the url of the masternode runtime")
                    log.trackIntoConsole("  /MasternodeRuntimeCertificate Set the certificate of the masternode runtime")
                    log.trackIntoConsole("  /ConfigFileName               Complete path of a config file")
                    log.trackIntoConsole("  /Gui                          Activates GUI mode")

                    End

                End If

            Catch ex As Exception
                log.track("StarterService.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "error")
            End Try

        End Sub


        Public Sub run(ByRef commandLine As String())

            Try

                _commandLine.decode(commandLine)

                decodeCommandLine()

                If (_completePathSettingFile.Trim().Length > 0) Then

                    Dim settings As New AppSettings

                    settings.fileName = _completePathSettingFile

                    If settings.read() Then
                        parameters.data = settings.data

                        haveParameters = True
                    End If

                End If

            Catch ex As Exception
                parameters = New AppSettings

                log.track("StarterService.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "error")
            End Try

        End Sub



    End Class



End Namespace
