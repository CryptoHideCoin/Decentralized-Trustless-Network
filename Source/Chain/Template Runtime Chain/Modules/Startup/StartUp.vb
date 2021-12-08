Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Miscellaneous
Imports CHCProtocolLibrary.AreaWallet.Support




Namespace AreaCommon

    Module StartUp

        ''' <summary>
        ''' This method provide to print a welcome message into console
        ''' </summary>
        Private Sub printWelcome()
            log.trackIntoConsole("=== Welcome into ====")
            log.trackIntoConsole("Crypto Hide Coin Decentralized Trustless Network")
            log.trackIntoConsole("Template Chain Engine Service")
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
                log.track("startUp.loadDataInformation", "Begin")

                With state.internalInformation
                    .chainName = Customize.chainName
                    .adminPublicAddress = settings.data.walletAddress

                    If settings.data.intranetMode Then
                        .addressIP = state.localIpAddress
                    Else
                        .addressIP = state.publicIpAddress
                    End If

                    .intranetMode = settings.data.intranetMode
                    .networkName = settings.data.networkName
                    .platformHost = "Microsoft Windows Standalone service"
                    .softwareRelease = "0.2"
                End With
            Catch ex As Exception
                log.track("StartUp.loadDataInformation", "Error during Load data information:" & ex.Message, "fatal", True)

                closeApplication()
            Finally
                log.track("startUp.setDateTime", "Completed")
            End Try
        End Sub

        ''' <summary>
        ''' This method provide a read a wallet address from file
        ''' </summary>
        ''' <param name="uuid"></param>
        ''' <param name="keyStoreSecurityKey"></param>
        ''' <returns></returns>
        Private Function readWalletAddress(ByVal uuid As String, ByVal keyStoreSecurityKey As String) As String
            Try
                Dim engine As New WalletAddressDataEngine
                Dim dataLoaded As Boolean = False
                Dim securityValue As String = ""

                log.track("StartUp.readWalletAddress", "Begin")

                engine.fileName = IO.Path.Combine(paths.keyStore, uuid, "walletAddress.private")

                If (keyStoreSecurityKey.Length > 0) Then
                    engine.securityKey = keyStoreSecurityKey
                End If

                If Not engine.load() Then
                    log.track("StartUp.readWalletAddress", "Error during load wallet", "fatal", True)

                    End
                Else
                    Return WalletAddressEngine.createNew(engine.data.privateRAWKey, True).official.publicKey
                End If

                log.track("StartUp.readWalletAddress", "Completed")
            Catch ex As Exception
                log.track("StartUp.readWalletAddress", "Error during read wallet address:" & ex.Message, "fatal", True)

                closeApplication()

                Return ""
            End Try
        End Function

        ''' <summary>
        ''' This method provide to read a KeyStore
        ''' </summary>
        ''' <param name="keyStoreSecurityKey"></param>
        Private Sub readAdminKeyStore(ByVal keyStoreSecurityKey As String)
            Try
                Dim uuidWallet As String = ""

                log.track("StartUp.readAdminKeyStore", "Begin")

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
                            log.track("StartUp.readAdminKeyStore", "Error during Load data keyStore :" & ex.Message, "fatal", True)

                            End
                        End Try
                    End If
                End If

                state.keys.addNew(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration, settings.data.walletAddress, "")

                log.track("StartUp.readAdminKeyStore", "Completed")
            Catch ex As Exception
                log.track("StartUp.readAdminKeyStore", "Error during Load data keyStore :" & ex.Message, "fatal", True)

                closeApplication()
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to prepare a startup of application
        ''' </summary>
        ''' <returns></returns>
        Private Function bootStrap() As Boolean
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

                        If settings.read() Then
                            log.track("StartUp.bootStrap", "Settings data read", , True)
                        Else
                            log.track("StartUp.bootStrap", "Problem during read data", "fatal", True)

                            Return False
                        End If

                        readAdminKeyStore(command.keyStoreSecurityKey)

                        log.track("StartUp.bootStrap", "KeyStore procedure Completed", , True)
                    End If

                    log.track("StartUp.bootStrap", "Root paths set " & paths.directoryData, , True)
                    log.track("StartUp.bootStrap", "Service GUID = " & settings.data.serviceId, , True)
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
        Private Sub runApplication()
            log.track("startUp.runApplication", "Begin")

            Try
                state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.started

                state.currentService.init()

                state.serviceParameters = AreaService.ServiceParameterEngine.acquireDefaultParameter()

                Do
                    Application.DoEvents()
                    Threading.Thread.Sleep(AreaCommon.support.timeSleep)
                Loop While (state.service <> CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.shutDown)
            Catch ex As Exception
                log.track("startUp.runApplication", ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("startUp.runApplication", "Completed")
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to synchronize a system date time
        ''' </summary>
        Private Sub setDateTime()
            Try
                log.track("startUp.setDateTime", "Begin")

                If Not settings.data.noUpdateSystemDate Then
                    log.track("startUp.setDateTime", "Update")

                    Process.Start("CMD", "/C net start w32time & w32tm /resync /force")
                End If
            Catch ex As Exception
                log.track("startUp.setDateTime", "Failed to update datetime = " & ex.Message, "fatal", True)
            Finally
                log.track("startUp.setDateTime", "Completed")
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to acquire an IP Address
        ''' </summary>
        Private Sub acquireIPAddress()
            Try
                log.track("startUp.acquireIPAddress", "Begin")

                state.localIpAddress = AreaNetwork.acquireLocalIP()
                state.publicIpAddress = AreaNetwork.acquirePublicIP()
            Catch ex As Exception
                log.track("startUp.acquireIPAddress", ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("startUp.acquireIPAddress", "Completed")
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to run the service
        ''' </summary>
        Private Sub runService()
            Try
                log.trackIntoConsole("Start Service")

                log.inBootStrapAction = True

                log.track("startUp.runService", "Begin")
                log.track("startUp.runService", "Commandline process execute is " & Environment.CommandLine)
                log.track("startUp.runService", "DataPath is " & paths.directoryData)

                registry.noSave = Not settings.data.useEventRegistry

                registry.init(paths.system.events)
                registry.addNew(CHCCommonLibrary.Support.RegistryEngine.RegistryData.TypeEvent.applicationStartUp)

                log.track("startUp.runService", "System Registry is running")

                log.saveMode = settings.data.trackConfiguration

                log.init(paths.system.logs, "main", registry)

                With settings.data.trackRotateConfig
                    logRotate.configuration.frequency = .frequency
                    logRotate.configuration.keepFile = .keepFile
                    logRotate.configuration.keepLast = .keepLast
                End With

                logRotate.path = paths.system.logs

                logRotate.run(log)

                log.track("startUp.runService", "Trackrotate in execute")

                counter.init(paths.system.counters)

                log.track("startUp.runService", "Counter is running")

                setDateTime()
                acquireIPAddress()
                loadDataInformation()

                If webServiceThread(True) Then
                    log.inBootStrapAction = False

                    log.trackIntoConsole("Admin port (" & settings.data.servicePort & ") chain in listen")

                    runApplication()
                Else
                    log.trackIntoConsole("Problem during start service")
                End If
            Catch ex As Exception
                log.track("startUp.runService", ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("startUp.runService", "Completed")
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to prepare to start the application
        ''' </summary>
        Public Sub main()
            Try
                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(False)

                If bootStrap() Then
                    runService()
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurrent during moduleMain.startup " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to stop the application
        ''' </summary>
        Public Sub [stop]()
            Try
                log.trackIntoConsole("Start the system shutdown operations")

                log.track("startUp.[Stop]", "Begin")

                state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.shutDown

                log.track("startUp.[Stop]", "Completed")

                log.trackIntoConsole("System is shutdown")
            Catch ex As Exception
            End Try
        End Sub

    End Module

End Namespace
