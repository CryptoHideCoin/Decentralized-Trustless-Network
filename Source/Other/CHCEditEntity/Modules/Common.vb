Option Compare Text
Option Explicit On


Module Common

    Private Const _settingFileName As String = "CHCClient.Settings"

    Private settings As New SettingsEngine





    Private Function trySettingsPath(ByVal path As String) As Boolean

        Try

            path = IO.Path.Combine(path, _settingFileName)

            Return IO.File.Exists(path)

        Catch ex As Exception

        End Try

        Return False

    End Function


    Private Function tryWritePath(ByVal path As String) As Boolean

        Dim clsFile As System.IO.StreamWriter

        path = IO.Path.Combine(path, IO.Path.GetFileName(IO.Path.GetTempFileName()))

        Try

            clsFile = My.Computer.FileSystem.OpenTextFileWriter(path, False)
            clsFile.WriteLine("Test")
            clsFile.Close()

            IO.File.Delete(path)

            Return True

        Catch ex As Exception

        End Try

        Return False

    End Function


    Private Function searchSettingsPath() As String

        Dim found As Boolean = False
        Dim path As String = ""

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

        If found Then

            Return IO.Path.Combine(path, _settingFileName)

        Else

            Return ""

        End If

    End Function


    Public Function readSettings() As Boolean

        Dim settingsPath As String = searchSettingsPath()
        Dim cancel As Boolean = False, openFile As Boolean = False

        settings.fileName = settingsPath

        If IO.File.Exists(settingsPath) Then

            Do While (Not cancel And Not openFile)

                openFile = settings.read()

                If Not openFile Then

                    If (RequestPassword.ShowDialog() = DialogResult.OK) Then

                        settings.cryptoKEY = RequestPassword.PasswordKEY

                    Else

                        cancel = True

                    End If

                End If

            Loop

            Return openFile

        Else

            SettingsPage.data = settings.data

            SettingsPage.init()

            If (SettingsPage.ShowDialog = DialogResult.OK) Then

                settings.data = SettingsPage.data
                settings.cryptoKEY = SettingsPage.passwordKey

                Return settings.save()

            End If

            Return False

        End If

    End Function


End Module
