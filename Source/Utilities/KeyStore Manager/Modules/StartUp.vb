Option Compare Text
Option Explicit On

Imports CHCServerSupportLibrary.Support.LogEngine
Imports CHCServerSupportLibrary.Support.LogRotateEngine




Namespace AreaCommon


    Module StartUp



        Function startApplication() As Boolean
            Try
                paths.init()

                log.track("startUp.startApplication", "paths.init execute")

                If (paths.pathBaseData.Trim.Length() > 0) Then
                    settings.fileName = IO.Path.Combine(paths.pathSettings, paths.settingFileName)

                    settings.read()
                End If

                log.track("startUp.startApplication", "settings read")

                log.noSave = (settings.data.useTrack = TrackRuntimeModeEnum.dontTrack)

                log.init(paths.pathLogs, "main")

                With settings.data.trackRotate
                    .frequency = LogRotateConfig.FrequencyEnum.everyDay
                    .keepFile = LogRotateConfig.KeepFileEnum.onlyMainTracks
                    .keepLast = LogRotateConfig.KeepEnum.lastWeek
                End With

                log.track("startUp.startApplication", "Trackrotate in execute")

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

                paths.pathBaseData = definePath

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
