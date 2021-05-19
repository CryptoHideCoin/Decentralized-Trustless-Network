Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon.Models.Settings
Imports CHCProtocolLibrary.AreaSystem
Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCServerSupportLibrary.Support


Namespace AreaCommon


    Module StartUp


        ''' <summary>
        ''' This method provide to print a welcome message into console
        ''' </summary>
        Private Sub printWelcome()

            Dim strTitle As String = "Crypto Hide Coin Decentralized Trustless Peer Update Manager Service"

            strTitle += " rel." & My.Application.Info.Version.ToString()

            Log.trackIntoConsole(strTitle)
            Log.trackIntoConsole(New String("=", Len(strTitle)))
            Log.trackIntoConsole()
            Log.trackIntoConsole("System bootstrap " & Miscellaneous.atMomentGMT() & " (gmt)")

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
                        End
                    End If

                    paths.directoryData = paths.readDefinePath()

                    paths.init(VirtualPathEngine.EnumSystemType.updateManager)

                    settings.fileName = IO.Path.Combine(paths.settings, paths.settingFileName)

                    If settings.read() Then
                        paths.directoryData = settings.data.dataPath

                        haveSettings = Not settings.data.gui
                    Else
                        settings.data.dataPath = paths.directoryData
                    End If

                Else

                    settings.data = command.parameters.data
                    paths.directoryData = settings.data.dataPath

                    paths.init(VirtualPathEngine.EnumSystemType.updateManager)

                End If

                command.parameters = Nothing
                command = Nothing

                Log.trackIntoConsole("Parameters read")

                If (paths.directoryData.Trim().Length = 0) Then

                    If (definePath.Length() = 0) Then
                        End
                    End If

                    paths.directoryData = paths.readDefinePath()
                    settings.data.dataPath = paths.directoryData

                End If

                Log.trackIntoConsole("Root paths set " & paths.directoryData)
                log.trackIntoConsole("Silent mode active")

                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function


        ''' <summary>
        ''' This method provide to execute the application
        ''' </summary>
        Sub runApplication()

            log.track("StartUp.runApplication", "Begin")

            Try

                recallLoader()
                buildServices()
                resumeState()

                state.currentApplication = EnumStateApplication.inRunning

                Do
                    checkNewUpdates()
                    'checkAuthorizations()
                    'downloadUpdates()
                    'applyUpdates()

                    Threading.Thread.Sleep(1000)
                Loop While (state.currentApplication = EnumStateApplication.inRunning)

            Catch ex As Exception
                log.track("StartUp.runApplication", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("StartUp.runApplication", "Completed")
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to run the service
        ''' </summary>
        Sub run()

            Try

                Log.trackIntoConsole("Start Service")

                log.track("StartUp.run", "Begin")
                log.track("StartUp.run", "Commandline process execute is " & Environment.CommandLine)
                log.track("StartUp.run", "DataPath is " & paths.directoryData)

                registry.noSave = Not settings.data.useEventRegistry

                registry.init(paths.system.events)
                registry.addNew(RegistryEngine.RegistryData.TypeEvent.applicationStartUp)

                log.track("StartUp.run", "System Registry is running")

                log.noSave = (settings.data.trackMode = LogEngine.TrackRuntimeModeEnum.dontTrack)

                Log.init(paths.system.logs, "main", registry)

                log.track("StartUp.run", "Log engine is running")

                With settings.data

                    If .useTrackRotate Then
                        logRotate.configuration.frequency = .trackRotate.frequency
                        logRotate.configuration.keepFile = .trackRotate.keepFile
                        logRotate.configuration.keepLast = .trackRotate.keepLast

                        logRotate.path = paths.system.logs

                        logRotate.run(Log)

                        log.track("StartUp.run", "Trackrotate is running")
                    End If

                End With

                counter.init(paths.system.counters)

                log.track("StartUp.run", "Counter is running")

                log.noSave = (settings.data.trackMode = LogEngine.TrackRuntimeModeEnum.dontTrack)

                log.track("StartUp.run", "Log.noSave = " & log.noSave)
                log.track("StartUp.run", "webserviceThread")

            Catch ex As Exception
                log.track("StartUp.run", "Error:" & ex.Message, "fatal")

                closeApplication()
            Finally
                log.track("StartUp.run", "Completed")
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to prepare to start the application
        ''' </summary>
        Sub Main()

            Try

                If firstProcedureStartup() Then
                    run()
                    runApplication()
                End If

            Catch ex As Exception
            End Try

        End Sub


        ''' <summary>
        ''' This method provide to stop the application
        ''' </summary>
        Sub [stop]()

            Try
                Log.trackIntoConsole("Start the system shutdown operations")

                log.track("StartUp.[Stop]", "Begin")

                state.currentApplication = EnumStateApplication.inShutDown

                log.track("StartUp.[Stop]", "Complete")

                log.trackIntoConsole("System is shutdown")
            Catch ex As Exception
            End Try

        End Sub


    End Module


End Namespace
