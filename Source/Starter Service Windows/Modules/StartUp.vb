Option Compare Text
Option Explicit On




Namespace AreaCommon


    Module StartUp


        ''' <summary>
        ''' This method provide to print a welcome message into console
        ''' </summary>
        Private Sub printWelcome()

            Dim strTitle As String = "Crypto Hide Coin Decentralized Trustless Peer Starter Service"

            strTitle += " rel." & My.Application.Info.Version.ToString()

            log.trackIntoConsole(strTitle)
            log.trackIntoConsole(New String("=", Len(strTitle)))
            log.trackIntoConsole()
            log.trackIntoConsole("System bootstrap " & CHCCommonLibrary.CHCEngines.Miscellaneous.atMomentGMT() & " (gmt)")

            state.currentApplication = AppState.enumStateApplication.waitingToStart

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

                printWelcome()

                If Not command.haveParameters Then

                    Dim haveSettings As Boolean = False

                    If (definePath.Length() = 0) Then

                        MessageBox.Show("File settings is missing", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End

                    End If

                    paths.pathBaseData = paths.readDefinePath()

                    settings.fileName = IO.Path.Combine(paths.pathSettings, "Settings", paths.settingFileName)

                    If settings.read() Then

                        paths.pathBaseData = settings.data.dataPath

                        haveSettings = Not settings.data.gui

                    Else

                        settings.data.dataPath = paths.pathBaseData

                    End If

                    If Not haveSettings Then

                        state.uiVisible = True

                    End If

                Else

                    settings.data = command.parameters.data

                    state.uiVisible = settings.data.gui

                    paths.pathBaseData = settings.data.dataPath

                End If

                command.parameters = Nothing
                command = Nothing

                log.trackIntoConsole("Parameters read")

                If (paths.pathBaseData.Trim().Length = 0) Then

                    If (definePath.Length() = 0) Then

                        MessageBox.Show("File settings is missing", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End

                    End If

                    paths.pathBaseData = paths.readDefinePath()

                    settings.data.dataPath = paths.pathBaseData

                End If

                log.trackIntoConsole("Root paths set " & paths.pathBaseData)

                If state.uiVisible Then

                    Dim tmp As New Main

                    log.trackIntoConsole("User interface active")

                    tmp.ShowDialog()

                    Return False

                End If

                log.trackIntoConsole("Silent mode active")

                Return True

            Catch ex As Exception

                MessageBox.Show("An error occurrent during firstProcedureStartup " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False

            End Try

        End Function


        ''' <summary>
        ''' This method provide to run the admin service
        ''' </summary>
        Sub runAdminService()

            Try

                Dim timeStart As DateTime

                log.track("startUp.runAdminService", "Begin")

                If settings.data.debugMode Then

                    Return

                End If

                executeExternalApplication("CHCAdminService.exe", "/NoConsoleMessage /RecallStarter /MasternodeStartURL:localhost:" & settings.data.portNumber & " /MasternodeStartCertificate:" & settings.data.certificateMasternodeAdmin & " /UseLastSettings")

                timeStart = Now

                MessageBox.Show("Mettere qua' il messaggio di attendere la connessione con il servizio...")

                Do While Not state.adminConnection And (Now.Subtract(timeStart).TotalSeconds < 31)

                    Application.DoEvents()

                Loop

                If Not state.adminConnection Then

                    log.track("startUp.runAdminService", "Timeout to connect Admin Service", "fatal")

                    closeApplication()

                End If

                log.trackIntoConsole("Admin Service is run")

                log.track("startUp.runAdminService", "Admin Service is run")

            Catch ex As Exception

                log.track("startUp.runAdminService", "Error:" & ex.Message, "fatal")

                closeApplication()

            End Try

        End Sub


        ''' <summary>
        ''' This method provide to execute a check an update of a service
        ''' </summary>
        Sub runCheckUpdate()

            Try

                ' Controllo gli aggiornamenti

                ' Da decidere poi che cosa dovrò fare...

            Catch ex As Exception

                log.track("startUp.runCheckUpdate", "Error:" & ex.Message, "fatal")

            End Try

        End Sub


        ''' <summary>
        ''' This method provide to run and engine of masternode
        ''' </summary>
        Sub runEngine()

            Try

                ' Vedremo in seguito che cosa dovrà fare questo programma

            Catch ex As Exception

            End Try

        End Sub


        ''' <summary>
        ''' This method provide to execute the application
        ''' </summary>
        Sub runApplication()

            log.track("startUp.runApplication", "Begin")

            Try

                Dim lastCheckUpdate As DateTime = Now.AddDays(-1)

                state.runTimeStart = settings.data.autoStart

                runAdminService()

                Do

                    If (lastCheckUpdate > Now) Then

                        runCheckUpdate()

                    End If

                    If state.runTimeStart And Not state.runTimeInExecute Then

                        state.runTimeStart = False
                        state.runTimeInExecute = True

                        runEngine()

                    End If

                    Application.DoEvents()

                Loop While (state.currentApplication <> AppState.enumStateApplication.inShutDown)

            Catch ex As Exception

                log.track("startUp.runApplication", "Error:" & ex.Message, "fatal")

                CloseApplication()

            Finally

                log.track("startUp.runApplication", "Completed")

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
                log.track("startUp.run", "DataPath is " & paths.pathBaseData)
                log.track("startUp.run", "User Interface visible = " & IIf(state.uiVisible, "true", "false"))

                paths.init()

                registry.noSave = Not settings.data.useEventRegistry

                registry.init(paths.pathEvents)
                registry.addNew(CHCServerSupport.Support.RegistryEngine.RegistryData.TypeEvent.applicationStartUp)

                log.track("startUp.run", "System Registry is running")

                log.noSave = (settings.data.useTrack = AppSettings.TrackRuntimeModeEnum.dontTrack)

                log.init(paths.pathLogs, "main", registry)

                log.track("startUp.run", "Log engine is running")

                With settings.data.trackRotate

                    .frequency = CHCServerSupport.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.everyDay
                    .keepFile = CHCServerSupport.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.onlyMainTracks
                    .keepLast = CHCServerSupport.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastWeek

                    logRotate.configuration.frequency = .frequency
                    logRotate.configuration.keepFile = .keepFile
                    logRotate.configuration.keepLast = .keepLast

                End With

                logRotate.path = paths.pathLogs

                logRotate.run(log)

                log.track("startUp.run", "Trackrotate is running")

                counter.init(paths.pathCounters)

                log.track("startUp.run", "Counter is running")

                log.noSave = (settings.data.useTrack = AppSettings.TrackRuntimeModeEnum.dontTrack)

                log.track("startUp.run", "Log.noSave = " & log.noSave)

                If webserviceThread() Then

                    log.trackIntoConsole("Service is in run")

                    runApplication()

                Else

                    log.trackIntoConsole("Problem during start service")

                End If

                log.track("startUp.run", "webserviceThread")

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

                state.currentApplication = AppState.enumStateApplication.inShutDown

                log.track("startUp.[Stop]", "Complete")

                log.trackIntoConsole("System is shutdown")

            Catch ex As Exception

            End Try

        End Sub


    End Module


End Namespace
