Option Compare Text
Option Explicit On




Namespace AreaCommon


    Module StartUp



        Function startApplication() As Boolean

            Try

                paths.init()

                log.track("startUp.firstProcedureStart", "paths.init execute")

                If (paths.pathBaseData.Trim.Length() > 0) Then

                    settings.fileName = IO.Path.Combine(paths.pathSettings, paths.settingFileName)

                    settings.read()

                End If

                log.track("startUp.firstProcedureStart", "settings read")

                log.noSave = (settings.data.useTrack = AppSettings.TrackRuntimeModeEnum.dontTrack)

                log.init(paths.pathLogs, "main")

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

                log.track("startUp.firstProcedureStart", "Trackrotate in execute")

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function



        ''' <summary>
        ''' This method provide to prepare to start the application
        ''' </summary>
        Function main() As Boolean

            Try

                Dim definePath As String = ""

                log.track("startUp.main", "Begin")

                definePath = paths.searchDefinePath()

                log.track("startUp.main", "The path is " & definePath)

                paths.pathBaseData = paths.readDefinePath()

                log.track("startUp.main", "DataPath is " & paths.pathBaseData)

                If (paths.pathBaseData.Trim.Length() > 0) Then

                    Return startApplication()

                End If

                Return True

            Catch ex As Exception

                MessageBox.Show("An error occurrent during Startup.main " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False

            End Try

        End Function


    End Module


End Namespace
