Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine



Namespace AreaCommon


    Public Class ManageCommandLine

        Private _commandLine As New Miscellaneous.CommandLineParameters
        Private _completePathSettingFile As String = ""

        Public parameters As New AppSettings
        Public haveParameters As Boolean = False
        Public forceReadSettings As Boolean = False

        Public fileSecurityKey As String = ""



        Private Sub decodeCommandLine()

            Dim confPort As AreaChain.NodesEngine.NodeInformation.configurationPort

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
                If _commandLine.exist("forceReadSettings".ToLower) Then
                    forceReadSettings = True
                End If
                If _commandLine.exist("FileSecurityKey".ToLower()) Then
                    fileSecurityKey = _commandLine.GetValue("FileSecurityKey".ToLower())
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

                        settings.fileName = IO.Path.Combine(paths.directoryData, paths.settingFileName)

                        settings.cryptoKEY = fileSecurityKey

                        settings.read()

                    End If

                    Dim tmp As New Settings

                    tmp.ShowDialog()

                    End

                End If

                If _commandLine.exist("PublicWalletAddress".ToLower()) Then

                    parameters.data.walletAddress = _commandLine.GetValue("PublicWalletAddress")
                    haveParameters = True

                End If
                If _commandLine.exist("PrivateWalletKey".ToLower()) Then

                    parameters.data.walletKey = _commandLine.GetValue("PrivateWalletKey")
                    haveParameters = True

                End If
                If _commandLine.exist("PublicPort".ToLower()) Then

                    confPort = New AreaChain.NodesEngine.NodeInformation.configurationPort

                    confPort.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.public
                    confPort.port = _commandLine.GetValue("PublicPort")

                    parameters.data.services.Add(confPort)

                    haveParameters = True

                End If
                If _commandLine.exist("ServicePort".ToLower()) Then

                    confPort = New AreaChain.NodesEngine.NodeInformation.configurationPort

                    confPort.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.service
                    confPort.port = _commandLine.GetValue("ServicePort")

                    parameters.data.services.Add(confPort)

                    haveParameters = True

                End If
                If _commandLine.exist("WriteLogFile".ToLower()) Then

                    parameters.data.useTrack = _commandLine.GetValue("WriteLogFile".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("UseEventRegistry".ToLower()) Then

                    parameters.data.useEventRegistry = _commandLine.GetValue("UseEventRegistry".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("MasternodeStartURL".ToLower()) Then

                    parameters.data.urlMasternodeStart = _commandLine.GetValue("MasternodeStartURL".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("MasternodeStartCertificate".ToLower()) Then

                    parameters.data.certificateMasternodeStart = _commandLine.GetValue("MasternodeStartCertificate".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("ConfigFileName".ToLower()) Then
                    _completePathSettingFile = _commandLine.GetValue("ConfigFileName".ToLower())
                End If
                If _commandLine.exist("NoConsoleMessage".ToLower()) Then

                    state.noConsoleMessage = True
                    haveParameters = True

                End If
                If _commandLine.exist("VirtualName".ToLower()) Then

                    parameters.data.virtualName = _commandLine.GetValue("VirtualName".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("intranetMode".ToLower()) Then

                    parameters.data.intranetMode = True
                    haveParameters = True

                End If
                If _commandLine.exist("NoUpdateData".ToLower()) Then

                    parameters.data.noUpdateSystemDate = True
                    haveParameters = True

                End If
                If _commandLine.exist("createChain".ToLower()) Then

                    state.actionToDo = AppState.enumChainPosition.toCreate
                    haveParameters = True

                End If
                If _commandLine.exist("restartChain".ToLower()) Then

                    state.actionToDo = AppState.enumChainPosition.toResume
                    haveParameters = True

                End If
                If _commandLine.exist("chainDefinition".ToLower()) Then

                    parameters.data.transactionChainConfig = _commandLine.GetValue("chainDefinition".ToLower())
                    haveParameters = True

                End If
                If _commandLine.exist("autoStart".ToLower()) Then

                    parameters.data.autoStart = True
                    haveParameters = True

                End If
                If _commandLine.exist("?") Or _commandLine.exist("Help".ToLower()) Then

                    log.trackIntoConsole("Allows remote administration service to run")
                    log.trackIntoConsole()
                    log.trackIntoConsole("  /Settings                     Show a settings page")
                    log.trackIntoConsole("  /DataPath                     Force a main path when the application work")
                    log.trackIntoConsole("  /PublicWalletAddress          Set a public wallet address")
                    log.trackIntoConsole("  /PrivateWalletKey             Set a private wallet key")
                    log.trackIntoConsole("  /PublicPort                   Set a public port")
                    log.trackIntoConsole("  /ServicePort                  Set a service port")
                    log.trackIntoConsole("  /WriteLogFile                 Enable log file writing")
                    log.trackIntoConsole("  /UseEventRegistry             Enable writing of system events")
                    log.trackIntoConsole("  /MasternodeStartURL           Set the url of the masternode start")
                    log.trackIntoConsole("  /MasternodeStartCertificate   Set the certificate of the masternode start")
                    log.trackIntoConsole("  /ConfigFileName               Complete path of a config file")
                    log.trackIntoConsole("  /NoConsoleMessage             Disable output into a console")
                    log.trackIntoConsole("  /VirtualName                  Set a virtual name of a masternode")
                    log.trackIntoConsole("  /NoUpdateData                 Disable automatic update of a date of a system")
                    log.trackIntoConsole("  /CreateChain                  Able to create a new chain")
                    log.trackIntoConsole("  /RestartChain                 Able to restart an exist chain")
                    log.trackIntoConsole("  /ChainDefinition              Set a configure definition of a chain")
                    log.trackIntoConsole("  /AutoStart                    Set the masternode in autostart mode")
                    log.trackIntoConsole("  /Help                         Show this panel")

                    End

                End If
                If _commandLine.exist("UseLastSettings".ToLower()) Then

                    haveParameters = False

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