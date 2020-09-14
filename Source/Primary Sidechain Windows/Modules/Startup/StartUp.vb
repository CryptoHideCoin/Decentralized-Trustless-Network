Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Miscellaneous
Imports CHCProtocolLibrary.AreaCommon.Models.Settings
Imports CHCServerSupportLibrary.Support
Imports CHCServerSupportLibrary.Support.LogEngine
Imports CHCServerSupport.Support




Namespace AreaCommon


    Module StartUp


        ''' <summary>
        ''' This method provide to print a welcome message into console
        ''' </summary>
        Private Sub printWelcome()

            log.trackIntoConsole("=== Welcome into ====")
            log.trackIntoConsole("Crypto Hide Coin Decentralized Trustless Masternode Engine Service")
            log.trackIntoConsole("Rel." & My.Application.Info.Version.ToString())
            log.trackIntoConsole("System bootstrap " & atMomentGMT() & " (gmt)")
            log.trackIntoConsole()

            state.stateApplication = EnumStateApplication.waitingToStart

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

                If Not command.haveParameters Then
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

                    log.trackIntoConsole("Root paths set " & paths.directoryData)

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

                Dim lastCheckUpdate As DateTime = Now.AddDays(-1)

                state.stateApplication = EnumStateApplication.inRunning

                Do
                    Application.DoEvents()
                Loop While (state.stateApplication <> enumStateApplication.inShutDown)

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

                log.noSave = (settings.data.useTrack = TrackRuntimeModeEnum.dontTrack)

                log.init(paths.system.logs, "main", registry)

                With settings.data.trackRotate

                    .frequency = LogRotateEngine.LogRotateConfig.FrequencyEnum.everyDay
                    .keepFile = LogRotateEngine.LogRotateConfig.KeepFileEnum.onlyMainTracks
                    .keepLast = LogRotateEngine.LogRotateConfig.KeepEnum.lastWeek

                    logRotate.configuration.frequency = .frequency
                    logRotate.configuration.keepFile = .keepFile
                    logRotate.configuration.keepLast = .keepLast

                End With

                logRotate.path = paths.system.logs

                logRotate.run(log)

                log.track("startUp.run", "Trackrotate in execute")

                counter.init(paths.system.counters)

                log.track("startUp.run", "Counter is running")

                log.noSave = (settings.data.useTrack = TrackRuntimeModeEnum.dontTrack)

                log.track("startUp.run", "Log.noSave = " & log.noSave)

                setDateTime()
                acquireIPAddress()

                If webserviceThread() Then

                    log.trackIntoConsole("Service is in run")

                    runApplication()

                Else
                    log.trackIntoConsole("Problem during start service")
                End If

                AreaBootstrap.startTransactionChain()

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

                state.stateApplication = EnumStateApplication.inShutDown

                log.track("startUp.[Stop]", "Complete")

                log.trackIntoConsole("System is shutdown")

            Catch ex As Exception
            End Try

        End Sub


    End Module


End Namespace
