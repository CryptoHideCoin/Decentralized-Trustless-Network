Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Miscellaneous
Imports CHCServerSupportLibrary.Support
Imports CHCServerSupportLibrary.Support.LogEngine
Imports CHCProtocolLibrary.AreaWallet.Support




Namespace AreaCommon


    Module StartUp


        ''' <summary>
        ''' This method provide to print a welcome message into console
        ''' </summary>
        Private Sub printWelcome()
            log.trackIntoConsole("=== Welcome into ====")
            log.trackIntoConsole("Crypto Hide Coin Decentralized Trustless Template Chain Engine Service")
            log.trackIntoConsole("Rel." & My.Application.Info.Version.ToString())
            log.trackIntoConsole("System bootstrap " & atMomentGMT() & " (gmt)")
            log.trackIntoConsole()

            state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.starting
        End Sub


        ''' <summary>
        ''' This method provide to load in memory an information data
        ''' </summary>
        Private Sub loadDataInformation()
            log.trackIntoConsole("Load data information")

            Try
                state.information.chainName = Customize.chainName
                state.information.adminPublicWalletID = settings.data.walletAddress

                If settings.data.intranetMode Then
                    state.information.addressIP = state.localIpAddress
                Else
                    state.information.addressIP = state.publicIpAddress
                End If

                state.information.intranetMode = settings.data.intranetMode
                state.information.networkName = settings.data.networkName
                state.information.platformHost = "Microsoft Windows Standalone service"
                state.information.softwareRelease = "0.1"
            Catch ex As Exception
                log.trackIntoConsole("Error during Load data information:" & ex.Message)
            End Try
        End Sub


        Private Function readWalletAddress(ByVal uuid As String, ByVal keyStoreSecurityKey As String) As String
            Try
                Dim engine As New WalletAddressDataEngine
                Dim dataLoaded As Boolean = False
                Dim securityValue As String = ""

                engine.fileName = IO.Path.Combine(paths.keyStore, uuid, "walletAddress.private")

                If (keyStoreSecurityKey.Length > 0) Then
                    engine.securityKey = keyStoreSecurityKey
                End If

                If Not engine.load() Then
                    Return ""
                Else
                    Return WalletAddressEngine.createNew(engine.data.privateRAWKey, True).official.publicKey
                End If

            Catch ex As Exception
                Return ""
            End Try
        End Function


        Private Sub readAdminKeyStore(ByVal keyStoreSecurityKey As String)
            Try
                Dim uuidWallet As String = ""

                If (settings.data.walletAddress.Length >= 11) Then
                    If settings.data.walletAddress.StartsWith("keystoreid:") Then

                        Try
                            Dim keyStoreManager = New KeyStoreEngine

                            uuidWallet = settings.data.walletAddress.Substring(11)

                            keyStoreManager.fileName = IO.Path.Combine(paths.keyStore, "keyAddress.list")

                            If keyStoreManager.read() Then
                                For Each item In keyStoreManager.data
                                    If (item.uuid.CompareTo(uuidWallet) = 0) Then
                                        state.keys.addNew(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration, readWalletAddress(item.uuid, keyStoreSecurityKey), "")
                                        Return
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            log.trackIntoConsole("Error during Load data keyStore :" & ex.Message)
                        End Try
                    End If
                End If

                state.keys.addNew(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration, settings.data.walletAddress, "")
            Catch ex As Exception
                log.trackIntoConsole("Error during Load data keyStore :" & ex.Message)
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to prepare a startup of application
        ''' </summary>
        ''' <returns></returns>
        Private Function firstProcedureStartup() As Boolean
            Try
                Dim command As New ManageCommandLine
                Dim definePath As String = paths.searchDefinePath()

                command.run(Environment.CommandLine.Split("/"))

                If Not command.haveParameters And Not command.forceReadSettings Then
                    closeApplication()
                Else
                    printWelcome()

                    settings.data = command.parameters.data
                    paths.directoryData = settings.data.dataPath

                    paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.runTime)

                    If command.forceReadSettings Then
                        settings.fileName = IO.Path.Combine(paths.settings, paths.settingFileName)
                        settings.cryptoKEY = command.fileSecurityKey

                        settings.read()

                        log.trackIntoConsole("Settings data read ")
                    End If

                    readAdminKeyStore(command.keyStoreSecurityKey)

                    log.trackIntoConsole("Root paths set " & paths.directoryData)

                    log.trackIntoConsole("Service GUID = " & settings.data.serviceId)
                End If

                command.parameters = Nothing
                command = Nothing

                log.trackIntoConsole("Parameters read")

                Return True
            Catch ex As Exception
                MessageBox.Show("An error occurrent during firstProcedureStartup " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to execute the application
        ''' </summary>
        Sub runApplication()
            log.track("startUp.runApplication", "Begin")

            Try
                state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.started

                state.serviceState.init()

                Do
                    Application.DoEvents()
                Loop While (state.service <> CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.shutDown)
            Catch ex As Exception
                log.track("startUp.runApplication", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("startUp.runApplication", "Completed")
            End Try
        End Sub


        Private Sub setDateTime()
            Try
                log.track("startUp.setDateTime", "Begin")

                If Not settings.data.noUpdateSystemDate Then
                    log.track("startUp.setDateTime", "Update")

                    Process.Start("CMD", "/C net start w32time & w32tm /resync /force")
                End If
            Catch ex As Exception
                log.track("startUp.setDateTime", "Failed to update datetime = " & ex.Message, "error", True)
            Finally
                log.track("startUp.setDateTime", "Completed")
            End Try
        End Sub


        Private Sub acquireIPAddress()
            Try
                log.track("startUp.acquireIPAddress", "Begin")

                state.localIpAddress = AreaNetwork.acquireLocalIP()
                state.publicIpAddress = AreaNetwork.acquirePublicIP()
            Catch ex As Exception
                log.track("startUp.acquireIPAddress", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("startUp.acquireIPAddress", "Completed")
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to run the service
        ''' </summary>
        Sub run()
            Try
                log.trackIntoConsole("Start Service")

                log.track("startUp.run", "Begin")
                log.track("startUp.run", "Commandline process execute is " & Environment.CommandLine)
                log.track("startUp.run", "DataPath is " & paths.directoryData)

                registry.noSave = Not settings.data.useEventRegistry

                registry.init(paths.system.events)
                registry.addNew(RegistryEngine.RegistryData.TypeEvent.applicationStartUp)

                log.track("startUp.run", "System Registry is running")

                log.noSave = (settings.data.trackConfiguration = TrackRuntimeModeEnum.dontTrack)

                log.init(paths.system.logs, "main", registry)

                With settings.data.trackRotateConfig
                    logRotate.configuration.frequency = .frequency
                    logRotate.configuration.keepFile = .keepFile
                    logRotate.configuration.keepLast = .keepLast
                End With

                logRotate.path = paths.system.logs

                logRotate.run(log)

                log.track("startUp.run", "Trackrotate in execute")

                counter.init(paths.system.counters)

                log.track("startUp.run", "Counter is running")

                log.noSave = (settings.data.trackConfiguration = TrackRuntimeModeEnum.dontTrack)

                log.track("startUp.run", "Log.noSave = " & log.noSave)

                setDateTime()
                acquireIPAddress()
                loadDataInformation()

                If webServiceThread(True) Then
                    log.trackIntoConsole("Service is in run")

                    'analyzeInternalState()
                    runApplication()
                Else
                    log.trackIntoConsole("Problem during start service")
                End If

                'AreaBootstrap.startTransactionChain()

            Catch ex As Exception
                log.track("startUp.run", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("startUp.run", "Completed")
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to prepare to start the application
        ''' </summary>
        Sub Main()
            Try
                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(False)

                If firstProcedureStartup() Then
                    run()
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurrent during moduleMain.startup " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        ''' <summary>
        ''' This method provide to stop the application
        ''' </summary>
        Sub [stop]()

            Try

                log.trackIntoConsole("Start the system shutdown operations")

                log.track("startUp.[Stop]", "Begin")

                state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.shutDown

                log.track("startUp.[Stop]", "Complete")

                log.trackIntoConsole("System is shutdown")

            Catch ex As Exception
            End Try

        End Sub


    End Module


End Namespace
