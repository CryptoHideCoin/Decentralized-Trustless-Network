Option Compare Text
Option Explicit On


Namespace AreaSystem


    Public Class Paths

        Public Const settingFileName As String = "StarterService.Settings"
        Public Const settingsFolderName As String = "Settings"

        Public Property pathSystem As String = ""
        Public Property pathSettings As String = ""
        Public Property pathCounters As String = ""
        Public Property pathEvents As String = ""
        Public Property pathLogs As String = ""
        Public Property pathBaseData As String



        Public Function init() As String

            Try

                If (pathBaseData.Trim.Length > 0) Then

                    pathSystem = IO.Path.Combine(pathBaseData, "System")
                    pathSettings = IO.Path.Combine(pathBaseData, settingsFolderName)
                    pathCounters = IO.Path.Combine(pathSystem, "Counters", "Starter")
                    pathEvents = IO.Path.Combine(pathSystem, "Events", "Starter")
                    pathLogs = IO.Path.Combine(pathSystem, "Logs", "Starter")

                    If Not IO.Directory.Exists(pathSystem) Then

                        IO.Directory.CreateDirectory(pathSystem)

                    End If

                    If Not IO.Directory.Exists(pathSettings) Then

                        IO.Directory.CreateDirectory(pathSettings)

                    End If

                    If Not IO.Directory.Exists(pathCounters) Then

                        IO.Directory.CreateDirectory(pathCounters)

                    End If

                    If Not IO.Directory.Exists(pathEvents) Then

                        IO.Directory.CreateDirectory(pathEvents)

                    End If

                    If Not IO.Directory.Exists(pathLogs) Then

                        IO.Directory.CreateDirectory(pathLogs)

                    End If

                End If

            Catch ex As Exception

            End Try

            Return True

        End Function






        Private Function trySettingsPath(ByVal path As String) As Boolean

            Try

                path = IO.Path.Combine(path, AreaSystem.Paths.settingsFolderName)

                Return IO.Directory.Exists(path)

            Catch ex As Exception

            End Try

            Return False

        End Function


        Private Function tryWritePath(ByVal path As String) As Boolean


            path = IO.Path.Combine(path, settingsFolderName)

            Try

                If IO.Directory.CreateDirectory(path).Exists Then

                    IO.Directory.Delete(path)

                    Return True

                End If

            Catch ex As Exception

            End Try

            Return False

        End Function


        Public Function searchRootPath() As String

            Dim found As Boolean = False
            Dim path As String = ""

            Try

                If Not found Then

                    path = IO.Path.Combine(Application.StartupPath)
                    found = trySettingsPath(path)

                End If

                If Not found Then

                    path = Application.LocalUserAppDataPath
                    found = trySettingsPath(path)

                End If

                If Not found Then

                    path = Application.UserAppDataPath
                    found = trySettingsPath(path)

                End If

                If Not found Then

                    path = Application.StartupPath
                    found = tryWritePath(path)

                End If

                If Not found Then

                    path = Application.LocalUserAppDataPath
                    found = tryWritePath(path)

                End If

                If Not found Then

                    path = Application.UserAppDataPath
                    found = trySettingsPath(path)

                End If

            Catch ex As Exception

            End Try

            If found Then

                Return path

            Else

                Return ""

            End If

        End Function


    End Class


End Namespace