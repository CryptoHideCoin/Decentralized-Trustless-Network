Option Compare Text
Option Explicit On
Imports System.ComponentModel


Public Class Main

    Private _canChangeTab As Boolean = False

    Public SettingsMode As Boolean = False


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If SettingsMode Then

                refreshButton.Visible = False
                registryEventButton.Visible = False
                logFileButton.Visible = False
                stopButton.Visible = False
                rememberThis.Visible = False

                tabControl.TabPages.RemoveByKey("LogTab")

                startButton.Text = "SAVE"

            End If

            With AreaCommon.settings.data

                localPathData.Text = .dataPath
                localPortNumber.Text = .portNumber

                publicWalletAddress.Text = .walletPublicAddress

                masternodeAdminUrl.Text = .urlMasternodeAdmin
                certificateMasternodeAdmin.Text = .certificateMasternodeAdmin

                masternodeRuntimeURL.Text = .urlMasternodeRuntime
                certificateMasternodeRuntime.Text = .certificateMasternodeRuntime

                writeLogFile.Checked = (.useTrack <> AppSettings.TrackRuntimeModeEnum.dontTrack)
                useEventRegistry.Checked = .useEventRegistry

                autoStart.Checked = .autoStart

            End With

        Catch ex As Exception

            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub loadDataIntoSettings()

        Try

            With AreaCommon.settings.data

                .gui = True

                .dataPath = localPathData.Text
                .portNumber = localPortNumber.Text

                .walletPublicAddress = publicWalletAddress.Text

                .urlMasternodeAdmin = masternodeAdminUrl.Text
                .certificateMasternodeAdmin = certificateMasternodeAdmin.Text

                .urlMasternodeRuntime = masternodeRuntimeURL.Text
                .certificateMasternodeRuntime = certificateMasternodeRuntime.Text

                If writeLogFile.Checked Then

                    .useTrack = AppSettings.TrackRuntimeModeEnum.trackAllRuntime

                Else

                    .useTrack = AppSettings.TrackRuntimeModeEnum.dontTrack

                End If

                If useEventRegistry.Checked Then

                    .useEventRegistry = AppSettings.TrackRuntimeModeEnum.trackAllRuntime

                Else

                    .useEventRegistry = AppSettings.TrackRuntimeModeEnum.dontTrack

                End If

                .autoStart = autoStart.Checked
                .debugMode = debugModeCheck.Checked

            End With

        Catch ex As Exception

            MessageBox.Show("An error occurrent during loadDataIntoSettings " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    Private Sub changeStateEntireInterface(Optional ByVal stateValue As Boolean = False)

        Try

            localPathAndDataPortNumber.Enabled = stateValue
            localPathData.Enabled = stateValue
            browseLocalPath.Enabled = stateValue
            portNumberLabel.Enabled = stateValue

            masternodeAdministrationGroup.Enabled = stateValue
            urlMasternodeAdministrationLabel.Enabled = stateValue
            masternodeAdminUrl.Enabled = stateValue
            testMasternodeAdministration.Enabled = stateValue
            certificateMasternodeAdministrationLabel.Enabled = stateValue
            certificateMasternodeAdmin.Enabled = stateValue
            certificateBrowserButton.Enabled = stateValue

            masternodeRuntimeGroup.Enabled = stateValue
            urlMasternodeRuntimeLabel.Enabled = stateValue
            masternodeRuntimeURL.Enabled = stateValue
            testMasternodeRuntimeButton.Enabled = stateValue
            certificateMasternodeRuntimeLabel.Enabled = stateValue
            certificateMasternodeRuntime.Enabled = stateValue
            certificateMasternodeRuntimeBrowserButton.Enabled = stateValue

        Catch ex As Exception

            MessageBox.Show("An error occurrent during changeStateEntireInterface " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    Private Function verifyParameter() As Boolean

        If (localPathData.Text.ToString.Trim.Length() = 0) Then

            MessageBox.Show("The local data path is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If Not IO.Directory.Exists(localPathData.Text) Then

            MessageBox.Show("The local path entered is incorrect", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (localPortNumber.Text.Trim.Length() = 0) Then

            MessageBox.Show("The local port number is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If Not IsNumeric(localPortNumber.Text) Then

            MessageBox.Show("The local port number must be a numeric.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return True

    End Function



    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

        Try

            If verifyParameter() Then

                loadDataIntoSettings()

                If (AreaCommon.paths.pathBaseData.Trim.Length() = 0) Then

                    AreaCommon.paths.pathBaseData = localPathData.Text

                    AreaCommon.paths.init()

                    AreaCommon.settings.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, AreaCommon.paths.settingFileName)

                End If

                AreaCommon.paths.updateRootPath(localPathData.Text)

                If Not SettingsMode Then

                    changeStateEntireInterface()

                    If rememberThis.Checked Then

                        AreaCommon.settings.save()

                    End If

                    _canChangeTab = True

                    startButton.Enabled = False
                    stopButton.Enabled = True
                    refreshButton.Enabled = True
                    logFileButton.Enabled = writeLogFile.Checked
                    registryEventButton.Enabled = useEventRegistry.Checked
                    tabControl.SelectedIndex = 1
                    AreaCommon.log.objectConsoleGUI = logConsoleText

                    Application.DoEvents()

                    AreaCommon.run()

                Else

                    AreaCommon.settings.save()

                    Me.Close()

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during startButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click

        Try

            If (MessageBox.Show(text:="Do you want to stop the Admin Service?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.OK) Then

                AreaCommon.[stop]()

                changeStateEntireInterface(True)

                startButton.Enabled = True
                stopButton.Enabled = False
                refreshButton.Enabled = False

                logFileButton.Enabled = False
                registryEventButton.Enabled = False

                _canChangeTab = False

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during startButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Main_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed



    End Sub

    Private Sub openComponent_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub browseLocalPath_Click(sender As Object, e As EventArgs) Handles browseLocalPath.Click

        Try

            Dim path As String = localPathData.Text

            Dim dirName As String

            If (path.Trim().Length > 0) Then

                dirName = IO.Path.GetDirectoryName(localPathData.Text)

            Else

                dirName = ""

            End If

            Dim fileName As String = IO.Path.GetFileName(localPathData.Text)

            folderBrowserDialog.SelectedPath = dirName

            If (folderBrowserDialog.ShowDialog() = DialogResult.OK) Then

                localPathData.Text = folderBrowserDialog.SelectedPath

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during browseLocalPath_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Main_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not SettingsMode Then

            AreaCommon.stop()

        End If

    End Sub

    Private Sub logFileButton_Click(sender As Object, e As EventArgs) Handles logFileButton.Click

        Try

            Process.Start(AreaCommon.log.completeFileName)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub registryEventButton_Click(sender As Object, e As EventArgs) Handles registryEventButton.Click

        Try

            Process.Start(AreaCommon.registry.fileName)

        Catch ex As Exception

        End Try

    End Sub


    Private Sub tabControl_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting

        If (tabControl.SelectedIndex = 1) Then

            If _canChangeTab Then

                Return

            End If

            If (AreaCommon.state.currentApplication <> AppState.enumStateApplication.inRunning) Then

                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub certificateBrowserButton_Click(sender As Object, e As EventArgs) Handles certificateBrowserButton.Click

        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then

                certificateMasternodeAdmin.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during certificateBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub certificateMasternodeRuntimeBrowserButton_Click(sender As Object, e As EventArgs) Handles certificateMasternodeRuntimeBrowserButton.Click

        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then

                certificateMasternodeRuntime.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during certificateMasternodeRuntimeBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub testMasternodeAdministration_Click(sender As Object, e As EventArgs) Handles testMasternodeAdministration.Click

        If (masternodeAdminUrl.Text.ToString.Trim.Length > 0) Then

            Try

                Dim handShakeEngine As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.BooleanModel)

                handShakeEngine.url = "http://" & masternodeAdminUrl.Text & "/api/v1.0/system/testService"

                If (handShakeEngine.getData() = "") Then

                    If handShakeEngine.data.value Then

                        MessageBox.Show("Test connection succesful", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                End If

            Catch ex As Exception

                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub

    Private Sub testMasternodeRuntimeButton_Click(sender As Object, e As EventArgs) Handles testMasternodeRuntimeButton.Click

        If (masternodeRuntimeURL.Text.ToString.Trim.Length > 0) Then

            Try

                Dim handShakeEngine As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.BooleanModel)

                handShakeEngine.url = "http://" & masternodeRuntimeURL.Text & "/api/v1.0/system/testService"

                If (handShakeEngine.getData() = "") Then

                    If handShakeEngine.data.value Then

                        MessageBox.Show("Test connection succesful", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                End If

            Catch ex As Exception

                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub


End Class
