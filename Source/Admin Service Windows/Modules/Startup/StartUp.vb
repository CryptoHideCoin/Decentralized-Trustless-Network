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

            Dim strTitle As String = "Crypto Hide Coin Decentralized Trustless Peer Admin Service"

            strTitle += " rel." & My.Application.Info.Version.ToString()

            log.trackIntoConsole(strTitle)
            log.trackIntoConsole(New String("=", Len(strTitle)))
            log.trackIntoConsole()
            log.trackIntoConsole("System bootstrap " & Miscellaneous.atMomentGMT() & " (gmt)")

            state.currentApplication = EnumStateApplication.waitingToStart

        End Sub


        ''' <summary>
        ''' This method provide to copy a command Parameters
        ''' </summary>
        ''' <param name="command"></param>
        Private Sub copyCommandParameters(ByRef command As ManageCommandLine)

            Try

                With command.parameters.data

                    If (.certificateClient.Trim.Length > 0) Then settings.data.certificateClient = .certificateClient
                    If (.serviceRuntime.url.Trim.Length > 0) Then

                        settings.data.serviceRuntime.useSecure = .serviceRuntime.useSecure
                        settings.data.serviceRuntime.url = .serviceRuntime.url
                        settings.data.serviceRuntime.certificate = .serviceRuntime.certificate

                    End If
                    If (.serviceStart.url.Trim.Length > 0) Then

                        settings.data.serviceStart.useSecure = .serviceStart.useSecure
                        settings.data.serviceStart.url = .serviceStart.url
                        settings.data.serviceStart.certificate = .serviceStart.certificate

                    End If
                    If (.dataPath.Trim.Length > 0) Then settings.data.dataPath = .dataPath
                    If (.gui) Then settings.data.gui = .gui
                    If (.noConsoleMessage) Then settings.data.noConsoleMessage = .noConsoleMessage
                    If (.portNumber <> 1122) Then settings.data.portNumber = .portNumber
                    If (.recallStarter) Then settings.data.recallStarter = .recallStarter
                    If (.walletPublicAddress.Trim.Length > 0) Then settings.data.walletPublicAddress = .walletPublicAddress

                End With

            Catch ex As Exception
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

                log.noPrintConsole = settings.data.noConsoleMessage

                printWelcome()

                If Not command.haveParameters Then

                    Dim haveSettings As Boolean = False

                    If (definePath.Length() = 0) Then

                        MessageBox.Show("File settings is missing", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End

                    End If

                    paths.directoryData = paths.readDefinePath()

                    paths.init(VirtualPathEngine.EnumSystemType.admin)

                    settings.fileName = IO.Path.Combine(paths.directoryData, "Settings", paths.settingFileName)

                    If settings.read() Then

                        paths.directoryData = settings.data.dataPath

                        haveSettings = Not settings.data.gui

                    Else

                        settings.data.dataPath = paths.directoryData

                    End If

                    If Not haveSettings Then

                        state.uiVisible = True

                    Else

                        If command.useLastSettings Then

                            copyCommandParameters(command)

                            state.uiVisible = False

                            paths.directoryData = settings.data.dataPath

                        End If

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


        ''' <summary>
        ''' This method provide to recall the Starter Service
        ''' </summary>
        Private Sub recallStarter()

            Try

                log.track("moduleMain.recallStarter", "Begin")

                Dim handShakeEngine As New ProxyWS(Of General.BooleanModel)

                handShakeEngine.url = AreaCommon.settings.data.serviceStart.composeURL("/api/v1.0/System/handShake/?serviceAdministrative=true&serviceEngine=false&certificateValue=" & AreaCommon.settings.data.serviceStart.certificate)

                If handShakeEngine.getData() Then

                    If Not handShakeEngine.data.value Then

                        log.track("moduleMain.recallStarter", "Cannot connection with the service or wrong certificate", "fatal")

                    End If

                End If

            Catch ex As Exception
                log.track("moduleMain.recallStarter", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("moduleMain.recallStarter", "Complete")
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to run the service
        ''' </summary>
        Sub run(Optional ByVal saveSettings As Boolean = False)

            Try

                log.trackIntoConsole("Start Service")

                state.currentApplication = EnumStateApplication.inStarting

                log.track("moduleMain.run", "Begin")
                log.track("moduleMain.run", "Commandline process execute is " & Environment.CommandLine)
                log.track("moduleMain.run", "DataPath is " & paths.directoryData)
                log.track("moduleMain.run", "User Interface visible = " & IIf(state.uiVisible, "true", "false"))

                registry.noSave = Not settings.data.useEventRegistry

                registry.init(paths.system.events)
                registry.addNew(RegistryEngine.RegistryData.TypeEvent.applicationStartUp)

                log.track("moduleMain.run", "System Registry is running")

                log.noSave = (settings.data.useTrack = TrackRuntimeModeEnum.dontTrack)

                log.init(paths.system.logs, "main", registry)

                log.track("moduleMain.run", "Log engine is running")

                If settings.data.useTrackRotate Then

                    With settings.data.trackRotate

                        logRotate.configuration.frequency = .frequency
                        logRotate.configuration.keepFile = .keepFile
                        logRotate.configuration.keepLast = .keepLast

                    End With

                    logRotate.path = paths.system.logs

                    logRotate.run(log)

                End If

                log.track("moduleMain.run", "Trackrotate is running")

                counter.init(paths.system.counters)

                log.track("moduleMain.run", "Counter is running")

                log.noSave = (settings.data.useTrack = TrackRuntimeModeEnum.dontTrack)

                log.track("moduleMain.run", "Log.noSave = " & log.noSave)

                If saveSettings Then
                    settings.save()

                    log.track("moduleMain.run", "Settings saved")
                End If

                If webserviceThread() Then
                    log.trackIntoConsole("Service is in run")
                Else
                    log.trackIntoConsole("Problem during start service")

                    End
                End If

                AreaApplication.Application.assets.init()

                If settings.data.recallStarter Then
                    recallStarter()
                End If

                state.currentApplication = EnumStateApplication.inRunning

            Catch ex As Exception
                log.track("moduleMain.run", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("moduleMain.run", "Completed")
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

                log.track("moduleMain.[Stop]", "Begin")

                state.currentApplication = EnumStateApplication.inShutDown

                log.track("moduleMain.[Stop]", "Complete")

                state.currentApplication = EnumStateApplication.waitingToStart

                log.trackIntoConsole("System is shutdown")

            Catch ex As Exception
            End Try

        End Sub


    End Module


End Namespace
