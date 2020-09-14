Option Compare Text
Option Explicit On

Imports System.ComponentModel
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaBase
Imports CHCProtocolLibrary.AreaCommon.Models.Settings
Imports CHCProtocolLibrary.AreaWallet
Imports CHCProtocolLibrary.AreaSystem
Imports CHCServerSupportLibrary.Support.LogEngine
Imports CHCServerSupportLibrary.Support.LogRotateEngine



Public Class Main

    Private _canChangeTab As Boolean = False

    Public SettingsMode As Boolean = False



    Private Sub showCertificateData()

        With AreaCommon.settings.data

            certificateMasternodeStart.Text = .serviceStart.certificate
            certificateMasternodeEngine.Text = .serviceRuntime.certificate
            certificateClient.Text = .certificateClient

        End With

    End Sub


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

            showCertificateData()

            With AreaCommon.settings.data

                localPathData.Text = .dataPath
                publicWalletAddress.Text = .walletPublicAddress
                localPortNumber.Text = .portNumber

                If .serviceStart.useSecure Then protocolMasternodeStart.SelectedIndex = 1 Else protocolMasternodeStart.SelectedIndex = 0
                If .serviceRuntime.useSecure Then protocolMasternodeEngine.SelectedIndex = 1 Else protocolMasternodeEngine.SelectedIndex = 0

                masternodeStartUrl.Text = .serviceStart.url
                masternodeEngineURL.Text = .serviceRuntime.url

                writeLogFile.Checked = (.useTrack <> TrackRuntimeModeEnum.dontTrack)
                useEventRegistry.Checked = .useEventRegistry

                autoCleanOption.Checked = .useTrackRotate

                If .useTrackRotate Then

                    Select Case .trackRotate.frequency
                        Case LogRotateConfig.FrequencyEnum.every12h : startCleanEveryValue.SelectedIndex = 0
                        Case LogRotateConfig.FrequencyEnum.everyDay : startCleanEveryValue.SelectedIndex = 1
                    End Select

                    Select Case .trackRotate.keepFile
                        Case LogRotateConfig.KeepFileEnum.nothingFiles : keepFileTypeValue.SelectedIndex = 0
                        Case LogRotateConfig.KeepFileEnum.onlyMainTracks : keepFileTypeValue.SelectedIndex = 1
                    End Select

                    Select Case .trackRotate.keepLast
                        Case LogRotateConfig.KeepEnum.lastDay : keepOnlyRecentFileValue.SelectedIndex = 0
                        Case LogRotateConfig.KeepEnum.lastMonth : keepOnlyRecentFileValue.SelectedIndex = 1
                        Case LogRotateConfig.KeepEnum.lastWeek : keepOnlyRecentFileValue.SelectedIndex = 2
                        Case LogRotateConfig.KeepEnum.lastYear : keepOnlyRecentFileValue.SelectedIndex = 3
                    End Select

                End If

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
                .walletPublicAddress = publicWalletAddress.Text
                .portNumber = localPortNumber.Text

                .serviceStart.useSecure = (protocolMasternodeStart.SelectedIndex > 0)
                .serviceStart.url = masternodeStartUrl.Text
                .serviceStart.certificate = certificateMasternodeStart.Text

                .serviceRuntime.useSecure = (protocolMasternodeEngine.SelectedIndex > 0)
                .serviceRuntime.url = masternodeEngineURL.Text
                .serviceRuntime.certificate = certificateMasternodeEngine.Text

                .certificateClient = certificateClient.Text

                If writeLogFile.Checked Then

                    .useTrack = TrackRuntimeModeEnum.trackAllRuntime

                Else

                    .useTrack = TrackRuntimeModeEnum.dontTrack

                End If

                If useEventRegistry.Checked Then

                    .useEventRegistry = TrackRuntimeModeEnum.trackAllRuntime

                Else

                    .useEventRegistry = TrackRuntimeModeEnum.dontTrack

                End If

                .useTrackRotate = autoCleanOption.Checked

                Select Case startCleanEveryValue.SelectedIndex
                    Case 0 : .trackRotate.frequency = LogRotateConfig.FrequencyEnum.every12h
                    Case 1 : .trackRotate.frequency = LogRotateConfig.FrequencyEnum.everyDay
                End Select

                Select Case keepFileTypeValue.SelectedIndex
                    Case 0 : .trackRotate.keepFile = LogRotateConfig.KeepFileEnum.nothingFiles
                    Case 1 : .trackRotate.keepFile = LogRotateConfig.KeepFileEnum.onlyMainTracks
                End Select

                Select Case keepOnlyRecentFileValue.SelectedIndex
                    Case 0 : .trackRotate.keepLast = LogRotateConfig.KeepEnum.lastDay
                    Case 1 : .trackRotate.keepLast = LogRotateConfig.KeepEnum.lastWeek
                    Case 2 : .trackRotate.keepLast = LogRotateConfig.KeepEnum.lastMonth
                    Case 3 : .trackRotate.keepLast = LogRotateConfig.KeepEnum.lastYear
                End Select

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

            masternodeStartGroup.Enabled = stateValue
            urlMasternodeStartLabel.Enabled = stateValue
            masternodeStartUrl.Enabled = stateValue

            certificateMasternodeLabel.Enabled = stateValue
            certificateMasternodeBrowserButton.Enabled = stateValue
            testMasternodeServiceButton.Enabled = stateValue

            masternodeEngineGroup.Enabled = stateValue
            urlMasternodeEngineLabel.Enabled = stateValue
            masternodeEngineURL.Enabled = stateValue
            certificateMasternodeEngineLabel.Enabled = stateValue
            certificateMasternodeEngine.Enabled = stateValue
            certificateMasternodeEngineBrowserButton.Enabled = stateValue
            testMasternodeEngineServiceButton.Enabled = stateValue

            masternodeClientGroup.Enabled = stateValue
            certificateMasternodeClientLabel.Enabled = stateValue
            certificateClient.Enabled = stateValue
            certificateMasternodeClientBrowserButton.Enabled = stateValue

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
        If (publicWalletAddress.Text.ToString.Trim.Length = 0) Then

            MessageBox.Show("The wallet address is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If Not Support.WalletAddressEngine.checkFormatPublicAddress(publicWalletAddress.Text) Then

            MessageBox.Show("The wallet address is wrong.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return True

    End Function


    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

        Try

            If verifyParameter() Then

                loadDataIntoSettings()

                If (AreaCommon.paths.directoryData.Trim.Length() = 0) Then

                    AreaCommon.paths.directoryData = localPathData.Text

                    AreaCommon.paths.init(VirtualPathEngine.EnumSystemType.admin)

                    AreaCommon.settings.fileName = IO.Path.Combine(AreaCommon.paths.settings, AreaCommon.paths.settingFileName)

                End If

                AreaCommon.paths.updateRootPath(localPathData.Text)

                If Not SettingsMode Then

                    changeStateEntireInterface()

                    _canChangeTab = True

                    startButton.Enabled = False
                    stopButton.Enabled = True
                    refreshButton.Enabled = True
                    logFileButton.Enabled = writeLogFile.Checked
                    registryEventButton.Enabled = useEventRegistry.Checked
                    tabControl.SelectedIndex = 1
                    AreaCommon.log.objectConsoleGUI = logConsoleText

                    AreaCommon.run(rememberThis.Checked)

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

            If AreaCommon.moduleMain.state.currentApplication = EnumStateApplication.inRunning Then
                AreaCommon.stop()
            Else
                Me.Dispose()

                AreaCommon.closeApplication(True)
            End If

        Else
            Me.Dispose()

            AreaCommon.closeApplication(True)
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

        If (tabControl.SelectedIndex = 2) Then

            If _canChangeTab Then
                Return
            End If

            If (AreaCommon.state.currentApplication <> EnumStateApplication.inRunning) Then
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub testMasternodeServiceButton_Click(sender As Object, e As EventArgs)

        If (masternodeStartUrl.Text.ToString.Trim.Length > 0) Then

            Try

                Dim handShakeEngine As New ProxyWS(Of General.BooleanModel)

                handShakeEngine.url = "http://" & masternodeStartUrl.Text & "/api/v1.0/system/testService"

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

    Private Sub certificateMasternodeBrowserButton_Click(sender As Object, e As EventArgs) Handles certificateMasternodeBrowserButton.Click

        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then

                certificateMasternodeStart.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateMasternodeBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub certificateMasternodeEngineBrowserButton_Click(sender As Object, e As EventArgs) Handles certificateMasternodeEngineBrowserButton.Click

        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then

                certificateMasternodeEngine.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateMasternodeEngineBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub certificateMasternodeClientBrowserButton_Click(sender As Object, e As EventArgs) Handles certificateMasternodeClientBrowserButton.Click

        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then

                certificateClient.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateMasternodeClientBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub testMasternodeEngineServiceButton_Click(sender As Object, e As EventArgs)

        If (masternodeEngineURL.Text.ToString.Trim.Length > 0) Then

            Try

                Dim handShakeEngine As New ProxyWS(Of General.BooleanModel)

                handShakeEngine.url = "http://" & masternodeEngineURL.Text & "/api/v1.0/system/testService"

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

    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click

        showCertificateData()

    End Sub

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub

    Private Sub localPathData_TextChanged(sender As Object, e As EventArgs) Handles localPathData.TextChanged

    End Sub

    Private Sub localPathData_DoubleClick(sender As Object, e As EventArgs) Handles localPathData.DoubleClick

        Try
            Process.Start("explorer.exe", localPathData.Text)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub createNewCertificateStart_Click(sender As Object, e As EventArgs) Handles createNewCertificateStart.Click

        certificateMasternodeStart.Text = Certificate.createNew()

    End Sub

    Private Sub createNewCertificateEngine_Click(sender As Object, e As EventArgs) Handles createNewCertificateEngine.Click

        certificateMasternodeEngine.Text = Certificate.createNew()

    End Sub

    Private Sub createNewCertificateClient_Click(sender As Object, e As EventArgs) Handles createNewCertificateClient.Click

        certificateClient.Text = Certificate.createNew()

    End Sub

    Private Sub enableLogRotate(ByVal value As Boolean)

        startCleanEvery.Enabled = value
        startCleanEveryValue.Enabled = value
        keepOnlyRecentFile.Enabled = value
        keepOnlyRecentFileValue.Enabled = value
        keepFileType.Enabled = value
        keepFileTypeValue.Enabled = value

    End Sub

    Private Sub autoCleanOption_CheckedChanged(sender As Object, e As EventArgs) Handles autoCleanOption.CheckedChanged

        enableLogRotate(autoCleanOption.Checked)

    End Sub

    Private Sub informationButton_Click(sender As Object, e As EventArgs) Handles informationButton.Click

        MessageBox.Show(Application.ProductName & vbNewLine & vbNewLine & "Release " & Application.ProductVersion, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Main_Scroll(sender As Object, e As ScrollEventArgs) Handles Me.Scroll

    End Sub

End Class
