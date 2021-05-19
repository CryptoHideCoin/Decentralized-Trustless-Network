Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Miscellaneous



Namespace AreaCommon


    Public Class ManageCommandLine

        Private _commandLine As New CommandLineParameters
        Private _completePathSettingFile As String = ""

        Public parameters As New AppSettings

        Public haveParameters As Boolean = False



        Private Sub decodeCommandLine()

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

                If _commandLine.exist("NoConsoleMessage".ToLower()) Then
                    haveParameters = True

                    state.noConsoleMessage = True
                End If
                If _commandLine.exist("RecallLoader".ToLower()) Then
                    haveParameters = True

                    state.recallLoader = True
                End If
                If _commandLine.exist("RecallPort".ToLower()) Then
                    haveParameters = True

                    state.loaderPort = _commandLine.GetValue("RecallPort".ToLower())
                End If
                If _commandLine.exist("UseLastSettings".ToLower()) Then
                    haveParameters = True

                    state.useLastSettings = True
                End If
                If _commandLine.exist("ServiceLoaderCertificate".ToLower()) Then
                    haveParameters = True

                    state.serviceLoaderCertificate = _commandLine.GetValue("ServiceLoaderCertificate".ToLower())
                End If
                If _commandLine.exist("WriteLogFile".ToLower()) Then
                    parameters.data.trackMode = CHCServerSupportLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackAllRuntime

                    haveParameters = True
                End If
                If _commandLine.exist("UseTrackRotate".ToLower()) Then
                    parameters.data.useTrackRotate = True

                    haveParameters = True
                End If
                Try
                    If _commandLine.exist("TrackRotateFrequency".ToLower()) Then
                        parameters.data.trackRotate.frequency = _commandLine.GetValue("TrackRotateFrequency".ToLower())

                        haveParameters = True
                    End If
                Catch ex As Exception
                End Try
                Try
                    If _commandLine.exist("TrackRotateKeepLast".ToLower()) Then
                        parameters.data.trackRotate.keepLast = _commandLine.GetValue("TrackRotateKeepLast".ToLower())

                        haveParameters = True
                    End If
                Catch ex As Exception
                End Try
                Try
                    If _commandLine.exist("TrackRotatekeepFile".ToLower()) Then
                        parameters.data.trackRotate.keepFile = _commandLine.GetValue("TrackRotatekeepFile".ToLower())

                        haveParameters = True
                    End If
                Catch ex As Exception
                End Try
                If _commandLine.exist("UseEventRegistry".ToLower()) Then
                    parameters.data.useEventRegistry = _commandLine.GetValue("UseEventRegistry".ToLower())

                    haveParameters = True
                End If
                If _commandLine.exist("ConfigFileName".ToLower()) Then
                    _completePathSettingFile = _commandLine.GetValue("ConfigFileName".ToLower())
                End If

                If _commandLine.exist("?") Or _commandLine.exist("help".ToLower()) Then

                    log.trackIntoConsole("Allows remote administration service to run")
                    log.trackIntoConsole()
                    log.trackIntoConsole("  /DataPath                     Force a main path when the application work")
                    log.trackIntoConsole("  /Settings                     Show a settings dialog")
                    log.trackIntoConsole("  /WalletPublicAddress          set a wallet public address")
                    log.trackIntoConsole("  /PortNumber                   Force port number to remotely control")
                    log.trackIntoConsole("  /WriteLogFile                 Enable log file writing")
                    log.trackIntoConsole("  /TrackRotateFrequency         Set a frequency of a track rotate")
                    log.trackIntoConsole("  /TrackRotateKeepLast          Set a frequency of a track Keep Last")
                    log.trackIntoConsole("  /TrackRotatekeepFile          Set a frequency of a track Keep File")
                    log.trackIntoConsole("  /UseEventRegistry             Enable writing of system events")
                    log.trackIntoConsole("  /Autostart                    Autostart this service")
                    log.trackIntoConsole("  /DebugMode                    Debug mode")

                    log.trackIntoConsole("  /ServiceStartURL              Set the url of the service loader")
                    log.trackIntoConsole("  /ServiceLoaderCertificate     Set the certificate of the service loader")
                    log.trackIntoConsole("  /ServiceRuntimeURL            Set the url of the service runtime")
                    log.trackIntoConsole("  /ServiceRuntimeCertificate    Set the certificate of the service runtime")
                    log.trackIntoConsole("  /ConfigFileName               Complete path of a config file")
                    log.trackIntoConsole("  /Gui                          Activates GUI mode")

                    End

                End If

            Catch ex As Exception
                log.track("StarterService.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "error")
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

                log.track("StarterService.ManageCommandLine.decodeCommandLine", "Error" & ex.Message, "error")
            End Try

        End Sub



    End Class



End Namespace
