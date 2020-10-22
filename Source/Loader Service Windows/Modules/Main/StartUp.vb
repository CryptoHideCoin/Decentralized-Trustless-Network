Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon.Models.Settings
Imports CHCProtocolLibrary.AreaSystem
Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCServerSupportLibrary.Support
Imports CHCServerSupportLibrary.Support.LogEngine


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
            log.trackIntoConsole("System bootstrap " & Miscellaneous.atMomentGMT() & " (gmt)")

            state.currentApplication = EnumStateApplication.waitingToStart

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

                    paths.directoryData = paths.readDefinePath()

                    paths.init(VirtualPathEngine.EnumSystemType.loader)

                    settings.fileName = IO.Path.Combine(paths.settings, paths.settingFileName)

                    If settings.read() Then
                        paths.directoryData = settings.data.dataPath

                        haveSettings = Not settings.data.gui
                    Else
                        settings.data.dataPath = paths.directoryData
                    End If

                    If Not haveSettings Then
                        state.uiVisible = True
                    End If
                Else

                    settings.data = command.parameters.data
                    state.uiVisible = settings.data.gui
                    paths.directoryData = settings.data.dataPath

                End If

                command.parameters = Nothing
                command = Nothing

                log.trackIntoConsole("Parameters read")

                If (paths.directoryData.Trim().Length = 0) Then

                    If (definePath.Length() = 0) Then
                        MessageBox.Show("File settings is missing", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End
                    End If

                    paths.directoryData = paths.readDefinePath()
                    settings.data.dataPath = paths.directoryData

                End If

                log.trackIntoConsole("Root paths set " & paths.directoryData)

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


        Private Function testSettings(ByVal protocolSecureService As Boolean, ByVal urlService As String) As Boolean

            If (urlService.Length > 0) Then

                Try

                    Dim testEngine As New ProxyWS(Of General.BooleanModel)

                    If protocolSecureService Then
                        testEngine.url = "https://" & urlService & "/api/v1.0/system/testService"
                    Else
                        testEngine.url = "http://" & urlService & "/api/v1.0/system/testService"
                    End If

                    If (testEngine.getData() = "") Then

                        If testEngine.data.value Then
                            MessageBox.Show("Test connection succesful", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    End If

                Catch ex As Exception
                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

        End Function



        ''' <summary>
        ''' This method provide to run the admin service
        ''' </summary>
        Sub runAdminService()

            Try

                Dim timeStart As DateTime

                log.track("startUp.runAdminService", "Begin")

                Do While state.adminStateData.duringUpdate
                    Threading.Thread.Sleep(500)
                    Application.DoEvents()
                Loop

                If settings.data.debugMode Then
                    state.adminStateData.status = EnumStateApplication.inRunning
                    Return
                End If
                If testService(settings.data.protocolSecureServiceAdmin, settings.data.urlServiceAdmin) Then Return

                If Not executeExternalApplication(moduleMain.adminFileService, "/NoConsoleMessage /RecallStarter /MasternodeStartURL:localhost:" & settings.data.portNumber & " /ServiceLoaderCertificate:" & settings.data.certificateServiceAdmin & " /UseLastSettings") Then
                    Return
                End If

                timeStart = Now

                log.trackIntoConsole("Wait to connect to the admin service...")

                Do While Not state.adminStateData.connection And (Now.Subtract(timeStart).TotalSeconds < 31)
                    Application.DoEvents()
                Loop

                If Not state.adminStateData.connection Then
                    log.track("startUp.runAdminService", "Timeout to connect Admin Service", "fatal")

                    closeApplication()
                End If

                state.adminStateData.status = EnumStateApplication.inRunning

                log.trackIntoConsole("Admin Service is run")
                log.track("startUp.runAdminService", "Admin Service is run")

            Catch ex As Exception
                log.track("startUp.runAdminService", "Error:" & ex.Message, "fatal")

                closeApplication()
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to run the update Manager
        ''' </summary>
        Sub runUpdateManager()

            Try

                Dim timeStart As DateTime

                log.track("startUp.runUpdateManager", "Begin")

                If settings.data.debugMode Then Return

                If Not executeExternalApplication(moduleMain.updateFileService, "/NoConsoleMessage /RecallStarter /MasternodeStartURL:localhost:" & settings.data.portNumber & " /ServiceLoaderCertificate:" & settings.data.certificateServiceAdmin & " /UseLastSettings") Then
                    closeApplication()
                End If

                timeStart = Now

                log.trackIntoConsole("Wait to connect to the update manager...")

                Do While Not state.updateConnection And (Now.Subtract(timeStart).TotalSeconds < 31)
                    Threading.Thread.Sleep(500)
                    Application.DoEvents()
                Loop

                If Not state.updateConnection Then
                    log.track("startUp.runUpdateManager", "Timeout to connect update manager", "fatal")

                    closeApplication()
                End If

                log.trackIntoConsole("Update manager is run")
                log.track("startUp.runUpdateManager", "Update Manager is run")

            Catch ex As Exception
                log.track("startUp.runUpdateManager", "Error:" & ex.Message, "fatal")

                closeApplication()
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to create an internal structure's of state service
        ''' </summary>
        Sub buildServices()

            Dim newData As AppState.ServiceStatus

            Try
                log.track("startUp.buildServices", "Begin")

                With state.adminStateData
                    .applicationName = moduleMain.adminFileService
                    .runTimeAutoStart = True
                    .serviceName = "AdminService"
                    .status = EnumStateApplication.inStarting
                    .secureProtocol = settings.data.protocolSecureServiceAdmin
                    .url = settings.data.urlServiceAdmin
                End With

                For Each value In settings.data.services

                    newData = New AppState.ServiceStatus()

                    newData.applicationName = value.applicationPath
                    newData.url = value.url
                    newData.secureProtocol = value.protocolSecure
                    newData.status = EnumStateApplication.waitingToStart
                    newData.runTimeAutoStart = settings.data.autoStart

                    state.serviceStateData.Add(newData)

                Next

                log.track("startUp.buildServices", "Complete")
            Catch ex As Exception
                log.track("startUp.buildServices", "Error:" & ex.Message, "fatal")

                closeApplication()
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to run and engine
        ''' </summary>
        ''' <param name="service"></param>
        Private Sub runEngine(ByRef service As AppState.ServiceStatus)

            Try

                Dim timeStart As DateTime

                log.track("startUp.runEngine", "Begin")

                Do While service.duringUpdate
                    Threading.Thread.Sleep(500)
                    Application.DoEvents()
                Loop

                If settings.data.debugMode Then Return
                If testService(service.secureProtocol, service.url) Then Return

                If Not executeExternalApplication(service.applicationName, "/NoConsoleMessage /RecallStarter /MasternodeStartURL:localhost:" & settings.data.portNumber & " /ServiceLoaderCertificate:" & settings.data.certificateServiceAdmin & " /UseLastSettings") Then
                    Return
                End If

                timeStart = Now

                log.trackIntoConsole("Wait to connect to the " & service.serviceName & " service...")

                Do While Not service.connection And (Now.Subtract(timeStart).TotalSeconds < 31)
                    Threading.Thread.Sleep(500)
                    Application.DoEvents()
                Loop

                If Not service.connection Then
                    log.track("startUp.runEngine", "Timeout to connect " & service.serviceName & " Service", "fatal")
                End If

                log.trackIntoConsole("Service " & service.serviceName & "is run")
                log.track("startUp.runEngine", "Service " & service.serviceName & "is run")

            Catch ex As Exception
                log.track("startUp.runEngine", "Error:" & ex.Message, "fatal")
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to execute the application
        ''' </summary>
        Sub runApplication()

            log.track("startUp.runApplication", "Begin")

            Try

                buildServices()
                runUpdateManager()

                Do
                    state.restartSystem = False

                    runAdminService()

                    For Each singleService In state.serviceStateData
                        runEngine(singleService)
                    Next

                    log.trackIntoConsole("Loader is run")
                    log.track("startUp.runApplication", "Loader is run")

                    state.currentApplication = EnumStateApplication.inRunning

                    Do
                        Threading.Thread.Sleep(1000)
                        Application.DoEvents()
                    Loop While (state.currentApplication = EnumStateApplication.inRunning)

                Loop While (state.currentApplication = EnumStateApplication.inRestart)

            Catch ex As Exception
                log.track("startUp.runApplication", "Error:" & ex.Message, "fatal")

                closeApplication()
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
                log.track("startUp.run", "DataPath is " & paths.directoryData)
                log.track("startUp.run", "User Interface visible = " & IIf(state.uiVisible, "true", "false"))

                registry.noSave = Not settings.data.useEventRegistry

                registry.init(paths.system.events)
                registry.addNew(RegistryEngine.RegistryData.TypeEvent.applicationStartUp)

                log.track("startUp.run", "System Registry is running")

                log.noSave = (settings.data.trackMode = LogEngine.TrackRuntimeModeEnum.dontTrack)

                log.init(paths.system.logs, "main", registry)

                log.track("startUp.run", "Log engine is running")

                With settings.data

                    If .useTrackRotate Then
                        logRotate.configuration.frequency = .trackRotate.frequency
                        logRotate.configuration.keepFile = .trackRotate.keepFile
                        logRotate.configuration.keepLast = .trackRotate.keepLast

                        logRotate.path = paths.system.logs

                        logRotate.run(log)

                        log.track("startUp.run", "Trackrotate is running")
                    End If

                End With

                counter.init(paths.system.counters)

                log.track("startUp.run", "Counter is running")

                log.noSave = (settings.data.trackMode = LogEngine.TrackRuntimeModeEnum.dontTrack)

                log.track("startUp.run", "Log.noSave = " & log.noSave)

                If webserviceThread() Then
                    log.trackIntoConsole("Webservice is run")

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

                state.currentApplication = EnumStateApplication.inShutDown

                log.track("startUp.[Stop]", "Complete")

                log.trackIntoConsole("System is shutdown")
            Catch ex As Exception
            End Try

        End Sub


    End Module


End Namespace
