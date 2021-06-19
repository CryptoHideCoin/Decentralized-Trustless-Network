Option Compare Text
Option Explicit On


Namespace AreaSystem


    Public Class Paths

        Public Const settingFileName As String = "KeyStoreManager.Settings"
        Public Const settingsFolderName As String = "Settings"

        Public Property pathSystem As String = ""
        Public Property pathSettings As String = ""
        'Public Property pathCounters As String = ""
        'Public Property pathEvents As String = ""
        Public Property pathLogs As String = ""
        Public Property pathBaseData As String = ""
        Public Property pathWalletData As String = ""


        Public Function init() As String
            Try
                If (pathBaseData.Trim.Length > 0) Then

                    pathSystem = IO.Path.Combine(pathBaseData, "System")
                    pathSettings = IO.Path.Combine(pathBaseData, settingsFolderName)
                    pathLogs = IO.Path.Combine(pathSystem, "Logs")
                    pathWalletData = IO.Path.Combine(pathBaseData, "WalletData")

                    If Not IO.Directory.Exists(pathSystem) Then
                        IO.Directory.CreateDirectory(pathSystem)
                    End If

                    If Not IO.Directory.Exists(pathSettings) Then
                        IO.Directory.CreateDirectory(pathSettings)
                    End If

                    'If Not IO.Directory.Exists(pathCounters) Then
                    '    IO.Directory.CreateDirectory(pathCounters)
                    'End If

                    'If Not IO.Directory.Exists(pathEvents) Then
                    '    IO.Directory.CreateDirectory(pathEvents)
                    'End If

                    If Not IO.Directory.Exists(pathLogs) Then
                        IO.Directory.CreateDirectory(pathLogs)
                    End If

                    If Not IO.Directory.Exists(pathWalletData) Then
                        IO.Directory.CreateDirectory(pathWalletData)
                    End If

                End If
            Catch ex As Exception
            End Try

            Return True
        End Function






        Private Function trySettingsPath(ByVal path As String) As Boolean
            Try
                path = IO.Path.Combine(path, "define.path")

                Return IO.File.Exists(path)
            Catch ex As Exception
            End Try
            Return False
        End Function


        Private Function tryWritePath(ByVal path As String) As Boolean
            path = IO.Path.Combine(path, "define.path")

            Try

                IO.File.WriteAllText(path, "Test")

                If IO.File.Exists(path) Then

                    IO.File.Delete(path)

                    Return True

                End If
            Catch ex As Exception
            End Try

            Return False
        End Function


        Private Function testPath(ByVal found As Boolean, ByRef path As String, ByVal newPath As String, Optional ByVal trySettings As Boolean = False) As Boolean
            If Not found Then

                path = newPath

                If trySettings Then
                    Return trySettingsPath(path)
                Else
                    Return tryWritePath(path)
                End If
            End If

            Return found
        End Function


        Public Function searchDefinePath() As String
            Dim found As Boolean = False
            Dim path As String = ""

            Try

                found = testPath(found, path, Application.StartupPath, True)
                found = testPath(found, path, Application.LocalUserAppDataPath, True)
                found = testPath(found, path, Application.UserAppDataPath, True)

                If found Then
                    Return path
                Else
                    found = testPath(found, path, Application.StartupPath)
                    found = testPath(found, path, Application.LocalUserAppDataPath)
                    found = testPath(found, path, Application.UserAppDataPath)

                    If found Then
                        Return path
                    End If
                End If

            Catch ex As Exception

            End Try

            Return ""
        End Function


        Public Function readDefinePath() As String
            Try

                Dim path As String = searchDefinePath()

                If (path.Length > 0) Then
                    Return IO.File.ReadAllText(IO.Path.Combine(searchDefinePath, "define.path"))
                End If
            Catch ex As Exception
            End Try

            Return ""
        End Function


        Public Sub updateRootPath(ByVal dataPath As String)
            Dim found As Boolean = False
            Dim path As String = ""

            Try

                found = testPath(found, path, Application.StartupPath, True)
                found = testPath(found, path, Application.LocalUserAppDataPath, True)
                found = testPath(found, path, Application.UserAppDataPath, True)
                found = testPath(found, path, Application.StartupPath)
                found = testPath(found, path, Application.LocalUserAppDataPath)
                found = testPath(found, path, Application.UserAppDataPath)

                If found Then
                    IO.File.WriteAllText(IO.Path.Combine(path, "define.path"), dataPath)
                End If
            Catch ex As Exception
            End Try
        End Sub


    End Class


End Namespace