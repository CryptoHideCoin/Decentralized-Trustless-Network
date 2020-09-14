Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaSystem



Namespace AreaCommon


    Public Class ManageCommandLine

        Private _commandLine As New Miscellaneous.CommandLineParameters
        Private _completePathSettingFile As String = ""

        Public parameters As New AppSettings
        Public haveParameters As Boolean = False
        Public useLastSettings As Boolean = False



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
                            paths.init(VirtualPathEngine.EnumSystemType.admin)
                        End If

                    End If

                    If (paths.directoryData.Trim.Length() > 0) Then
                        settings.fileName = IO.Path.Combine(paths.directoryData, paths.settingFileName)

                        settings.read()
                    End If

                    Dim tmp As New Main

                    tmp.SettingsMode = True

                    tmp.ShowDialog()

                    End

                End If

                If _commandLine.exist("PublicWalletAddress".ToLower()) Then

                    parameters.data.walletPublicAddress = _commandLine.GetValue("PublicWalletAddress")
                    haveParameters = True

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
                If _commandLine.exist("MasternodeStartUseSecure".ToLower()) Then

                    parameters.data.serviceStart.useSecure = True
                    haveParameters = True

                End If
                If _commandLine.exist("MasternodeStartURL".ToLower()) Then

                    parameters.data.serviceStart.url = _commandLine.GetValue("MasternodeStartURL".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("MasternodeStartCertificate".ToLower()) Then

                    parameters.data.serviceStart.certificate = _commandLine.GetValue("MasternodeStartCertificate".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("MasternodeEngineUseSecure".ToLower()) Then

                    parameters.data.serviceRuntime.useSecure = _commandLine.GetValue("MasternodeEngineUseSecure".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("MasternodeEngineURL".ToLower()) Then

                    parameters.data.serviceRuntime.url = _commandLine.GetValue("MasternodeEngineURL".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("MasternodeEngineCertificate".ToLower()) Then

                    parameters.data.serviceRuntime.certificate = _commandLine.GetValue("MasternodeEngineCertificate".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("ClientCertificate".ToLower()) Then

                    parameters.data.certificateClient = _commandLine.GetValue("ClientCertificate".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("ConfigFileName".ToLower()) Then

                    _completePathSettingFile = _commandLine.GetValue("ConfigFileName".ToLower())

                End If
                If _commandLine.exist("NoConsoleMessage".ToLower()) Then

                    parameters.data.noConsoleMessage = True

                End If
                If _commandLine.exist("RecallStarter".ToLower()) Then

                    parameters.data.recallStarter = True

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
                    log.trackIntoConsole("  /MasternodeEngineURL          Set the url of the masternode engine")
                    log.trackIntoConsole("  /MasternodeEngineCertificate  Set the certificate of the masternode engine")
                    log.trackIntoConsole("  /ClientCertificate            Set the certificate of the client")
                    log.trackIntoConsole("  /ConfigFileName               Complete path of a config file")
                    log.trackIntoConsole("  /Gui                          Activates GUI mode")
                    log.trackIntoConsole("  /PublicWalletAddress          Specify the public wallet address")
                    log.trackIntoConsole("  /NoConsoleMessage             Disable console write message")
                    log.trackIntoConsole("  /Help                         Show this panel")

                    End

                End If
                If _commandLine.exist("UseLastSettings".ToLower()) Then
                    haveParameters = False

                    useLastSettings = True
                End If

            Catch ex As Exception
                log.track("AdminService.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "fatal")

                closeApplication()
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

                log.track("AdminService.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "error")
            End Try

        End Sub


    End Class


End Namespace
