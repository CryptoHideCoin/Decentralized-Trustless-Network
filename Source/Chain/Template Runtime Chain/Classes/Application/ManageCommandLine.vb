Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine



Namespace AreaCommon


    Public Class ManageCommandLine

        Private _commandLine As New Miscellaneous.CommandLineParameters
        Private _completePathSettingFile As String = ""

        Public parameters As New CHCRuntimeChainLibrary.AreaRuntime.AppSettings
        Public haveParameters As Boolean = False
        Public forceReadSettings As Boolean = False

        Public fileSecurityKey As String = ""
        Public keyStoreSecurityKey As String = ""



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
                If _commandLine.exist("forceReadSettings".ToLower()) Then
                    forceReadSettings = True
                End If
                If _commandLine.exist("FileSecurityKey".ToLower()) Then
                    fileSecurityKey = _commandLine.GetValue("FileSecurityKey".ToLower())
                End If
                If _commandLine.exist("KeystoreSecurityKey".ToLower()) Then
                    keyStoreSecurityKey = _commandLine.GetValue("KeystoreSecurityKey".ToLower())
                End If
                If _commandLine.exist("Settings".ToLower()) Then
                    If (parameters.data.dataPath.Trim.Length() = 0) Then
                        paths.directoryData = paths.readDefinePath()
                    Else
                        paths.directoryData = parameters.data.dataPath
                    End If
                    If (paths.directoryData.Trim.Length() > 0) Then
                        paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.runTime)
                    End If
                    If (paths.directoryData.Trim.Length() > 0) Then
                        settings.fileName = IO.Path.Combine(paths.settings, paths.settingFileName)
                        settings.cryptoKEY = fileSecurityKey

                        settings.read()
                    End If

                    Dim tmp As New Settings : tmp.ShowDialog() : End
                End If
                If _commandLine.exist("NetworkName".ToLower()) Then
                    parameters.data.networkName = _commandLine.GetValue("NetworkName")
                End If
                If _commandLine.exist("IntranetMode".ToLower()) Then
                    parameters.data.intranetMode = True
                End If
                If _commandLine.exist("NoUpdateDate".ToLower()) Then
                    parameters.data.noUpdateSystemDate = True
                End If
                If _commandLine.exist("PublicWalletAddress".ToLower()) Then
                    parameters.data.walletAddress = _commandLine.GetValue("PublicWalletAddress")
                    haveParameters = True
                End If
                If _commandLine.exist("Certificate".ToLower()) Then
                    parameters.data.walletAddress = _commandLine.GetValue("Certificate")
                    haveParameters = True
                End If
                If _commandLine.exist("PublicPort".ToLower()) Then
                    parameters.data.publicPort = _commandLine.GetValue("PublicPort")
                    haveParameters = True
                End If
                If _commandLine.exist("ServicePort".ToLower()) Then
                    parameters.data.publicPort = _commandLine.GetValue("ServicePort")
                    haveParameters = True
                End If
                If _commandLine.exist("WriteLogMode".ToLower()) Then
                    parameters.data.trackConfiguration = _commandLine.GetValue("WriteLogMode".ToLower())
                End If
                If _commandLine.exist("UseTrackRotate".ToLower()) Then
                    parameters.data.useTrackRotate = (_commandLine.GetValue("UseTrackRotate".ToLower()) = "1")
                End If
                If _commandLine.exist("TrackRotateFrequency".ToLower()) Then
                    parameters.data.trackRotateConfig.frequency = _commandLine.GetValue("TrackRotateFrequency".ToLower())
                End If
                If _commandLine.exist("TrackRotateKeepFile".ToLower()) Then
                    parameters.data.trackRotateConfig.keepFile = _commandLine.GetValue("TrackRotateKeepFile".ToLower())
                End If
                If _commandLine.exist("TrackRotateKeepLast".ToLower()) Then
                    parameters.data.trackRotateConfig.keepLast = _commandLine.GetValue("TrackRotateKeepLast".ToLower())
                End If
                If _commandLine.exist("UseEventRegistry".ToLower()) Then
                    parameters.data.useEventRegistry = _commandLine.GetValue("UseEventRegistry".ToLower())
                    haveParameters = True
                End If
                If _commandLine.exist("ConfigFileName".ToLower()) Then
                    _completePathSettingFile = _commandLine.GetValue("ConfigFileName".ToLower())
                End If
                If _commandLine.exist("NoConsoleMessage".ToLower()) Then
                    state.noConsoleMessage = True
                    haveParameters = True
                End If
                If _commandLine.exist("?") Or _commandLine.exist("Help".ToLower()) Then
                    log.trackIntoConsole("Allows remote administration service to run")
                    log.trackIntoConsole()
                    log.trackIntoConsole("  /DataPath                     Force a main path when the application work")
                    log.trackIntoConsole("  /ForceReadSettings            Force application to read a local settings")
                    log.trackIntoConsole("  /FileSecurityKey              Set a security key to read a local settings file")
                    log.trackIntoConsole("  /Settings                     Show a settings page")
                    log.trackIntoConsole("  /NetworkName                  Set a intranet mode")
                    log.trackIntoConsole("  /IntranetMode                 Set a intranet mode")
                    log.trackIntoConsole("  /NoUpdateDate                 Disable automatic update of a date of a system")
                    log.trackIntoConsole("  /PublicWalletAddress          Set a public wallet address")
                    log.trackIntoConsole("  /PrivateWalletKey             Set a private wallet key")
                    log.trackIntoConsole("  /PublicPort                   Set a public port")
                    log.trackIntoConsole("  /ServicePort                  Set a service port")
                    log.trackIntoConsole("  /MasternodeLoaderURL          Set the url of the masternode start")
                    log.trackIntoConsole("  /MasternodeCertificate        Set the certificate of the masternode")
                    log.trackIntoConsole("  /WriteLogMode                 Enable log file writing and set mode (0,1,2)")
                    log.trackIntoConsole("  /TrackRotateFrequency         Set the track rotate frequency (0,1)")
                    log.trackIntoConsole("  /TrackRotateKeepFile          Set the file to keep during clean (0,1)")
                    log.trackIntoConsole("  /TrackRotateKeepLast          Set the file to keep during clean (0,1,2,3)")
                    log.trackIntoConsole("  /UseEventRegistry             Enable writing of system events")
                    log.trackIntoConsole("  /ConfigFileName               Complete path of a config file")
                    log.trackIntoConsole("  /NoConsoleMessage             Disable output into a console")
                    log.trackIntoConsole("  /Help                         Show this panel")

                    End
                End If
            Catch ex As Exception
                log.track("TemplateRuntimeChain.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "fatal")

                closeApplication()
            End Try
        End Sub


        Public Sub run(ByRef commandLine As String())
            Try
                _commandLine.decode(commandLine)

                decodeCommandLine()

                If (_completePathSettingFile.Trim().Length > 0) Then
                    Dim settings As New CHCRuntimeChainLibrary.AreaRuntime.AppSettings

                    settings.fileName = _completePathSettingFile

                    If settings.read() Then
                        parameters.data = settings.data

                        haveParameters = True
                    End If
                End If
            Catch ex As Exception
                parameters = New CHCRuntimeChainLibrary.AreaRuntime.AppSettings

                log.track("TemplateRuntimeChain.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "error")
            End Try
        End Sub



    End Class



End Namespace