Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaBase




Public Class Settings


    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            With AreaCommon.settings.data

                If (.networkName.Trim().Length = 0) Then
                    networkName.Text = AreaCommon.state.information.networkName
                Else
                    networkName.Text = .networkName
                End If

                If (.chainName.Trim().Length = 0) Then
                    chainName.Text = AreaCommon.state.information.chainName
                Else
                    chainName.Text = .chainName
                End If

                intranetMode.Checked = .intranetMode
                noUpdateSystemDate.Checked = .noUpdateSystemDate

                dataPath.Text = .dataPath
                walletAddress.Text = .walletAddress

                publicPortNumber.Text = .publicPort
                servicePortNumber.Text = .servicePort

                certificateClient.Text = .clientCertificate

                Select Case .trackConfiguration
                    Case CHCServerSupportLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrack : trackConfiguration.SelectedIndex = 0
                    Case CHCServerSupportLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackAllRuntime : trackConfiguration.SelectedIndex = 1
                    Case CHCServerSupportLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackOnlyMain : trackConfiguration.SelectedIndex = 2
                End Select

                autoCleanOption.Checked = .useTrackRotate

                Select Case .trackRotateConfig.frequency
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h : startCleanEveryValue.SelectedIndex = 0
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.everyDay : startCleanEveryValue.SelectedIndex = 1
                End Select

                Select Case .trackRotateConfig.keepLast
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay : keepOnlyRecentFileValue.SelectedIndex = 0
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastMonth : keepOnlyRecentFileValue.SelectedIndex = 1
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastWeek : keepOnlyRecentFileValue.SelectedIndex = 2
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastYear : keepOnlyRecentFileValue.SelectedIndex = 3
                End Select

                Select Case .trackRotateConfig.keepFile
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles : keepFileTypeValue.SelectedIndex = 0
                    Case CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.onlyMainTracks : keepFileTypeValue.SelectedIndex = 1
                End Select

                useEventRegistry.Checked = .useEventRegistry

            End With

        Catch ex As Exception
            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub loadDataIntoSettings()

        Try

            With AreaCommon.settings.data

                .networkName = networkName.Text
                .chainName = chainName.Text

                .intranetMode = intranetMode.Checked
                .noUpdateSystemDate = noUpdateSystemDate.Checked

                .dataPath = dataPath.Text
                .walletAddress = walletAddress.Text

                .publicPort = publicPortNumber.Text
                .servicePort = servicePortNumber.Text

                .clientCertificate = certificateClient.Text

                Select Case trackConfiguration.SelectedIndex
                    Case 0 : .trackConfiguration = CHCServerSupportLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrack
                    Case 1 : .trackConfiguration = CHCServerSupportLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackAllRuntime
                    Case 2 : .trackConfiguration = CHCServerSupportLibrary.Support.LogEngine.TrackRuntimeModeEnum.trackOnlyMain
                End Select

                .useTrackRotate = autoCleanOption.Checked

                If (startCleanEveryValue.SelectedIndex = 0) Then
                    .trackRotateConfig.frequency = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h
                Else
                    .trackRotateConfig.frequency = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.everyDay
                End If

                Select Case keepOnlyRecentFileValue.SelectedIndex
                    Case 0 : .trackRotateConfig.keepLast = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay
                    Case 1 : .trackRotateConfig.keepLast = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastMonth
                    Case 2 : .trackRotateConfig.keepLast = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastWeek
                    Case 3 : .trackRotateConfig.keepLast = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastYear
                End Select

                If keepFileTypeValue.SelectedIndex = 0 Then
                    .trackRotateConfig.keepFile = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles
                Else
                    .trackRotateConfig.keepFile = CHCServerSupportLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.onlyMainTracks
                End If

                .useEventRegistry = useEventRegistry.Checked

            End With

        Catch ex As Exception
        End Try

    End Sub


    Private Sub browseLocalPath_Click(sender As Object, e As EventArgs)

        Try

            Dim path As String = dataPath.Text

            Dim dirName As String

            If (path.Trim().Length > 0) Then
                dirName = IO.Path.GetDirectoryName(dataPath.Text)
            Else
                dirName = ""
            End If

            Dim fileName As String = IO.Path.GetFileName(dataPath.Text)

            folderBrowserDialog.SelectedPath = dirName

            If (folderBrowserDialog.ShowDialog() = DialogResult.OK) Then
                dataPath.Text = folderBrowserDialog.SelectedPath
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during dataPath_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Private Function fieldValueMissing(ByRef field As TextBox, ByVal name As String) As Boolean

        If (field.Text.ToString.Trim.Length() = 0) Then

            MessageBox.Show("The '" & name & "' is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True

        Else
            Return False
        End If

    End Function


    Private Function portMissing(ByRef portValue As TextBox, ByVal fieldName As String) As Boolean

        If Not IsNumeric(portValue.Text) Then

            MessageBox.Show("The " & fieldName & " port must be a number", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True

        End If

        Return False

    End Function


    Private Function verifyParameter() As Boolean

        If fieldValueMissing(dataPath, "local data path") Then Return False
        If fieldValueMissing(walletAddress, "wallet address") Then Return False
        If fieldValueMissing(publicPortNumber, "public port number") Then Return False
        If portMissing(publicPortNumber, "public port number") Then Return False
        If portMissing(servicePortNumber, "service port number") Then Return False

        If Not IO.Directory.Exists(dataPath.Text) Then

            MessageBox.Show("The local path entered is incorrect", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return True

    End Function


    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        If verifyParameter() Then

            loadDataIntoSettings()

            If (AreaCommon.paths.directoryData.Trim.Length() = 0) Then

                AreaCommon.paths.directoryData = dataPath.Text

                AreaCommon.paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.runTime)

                AreaCommon.settings.fileName = IO.Path.Combine(AreaCommon.paths.settings, AreaCommon.paths.settingFileName)

            End If

            AreaCommon.paths.updateRootPath(dataPath.Text)

            AreaCommon.settings.save()

            Me.Close()

        End If

    End Sub

    Private Sub certificateMasternodeBrowserButton_Click(sender As Object, e As EventArgs)

        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                certificateClient.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateMasternodeBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub createNewCertificateUpgrade_Click(sender As Object, e As EventArgs)

        certificateClient.Text = Certificate.createNew()

    End Sub

    Private Sub autoCleanOption_CheckedChanged(sender As Object, e As EventArgs) Handles autoCleanOption.CheckedChanged

        startCleanEvery.Enabled = autoCleanOption.Checked
        startCleanEveryValue.Enabled = autoCleanOption.Checked
        keepOnlyRecentFile.Enabled = autoCleanOption.Checked
        keepOnlyRecentFileValue.Enabled = autoCleanOption.Checked
        keepFileType.Enabled = autoCleanOption.Checked
        keepFileTypeValue.Enabled = autoCleanOption.Checked

        If Not autoCleanOption.Checked Then

            startCleanEveryValue.SelectedIndex = -1
            keepOnlyRecentFileValue.SelectedIndex = -1
            keepFileTypeValue.SelectedIndex = -1

        End If

    End Sub

    Private Sub createNewCertificateClient_Click(sender As Object, e As EventArgs) Handles createNewCertificateClient.Click

        certificateClient.Text = Certificate.createNew()

    End Sub

    Private Sub browseCertificate_Click(sender As Object, e As EventArgs) Handles browseCertificate.Click

        Try

            openFileDialog.FileName = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                certificateClient.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateMasternodeClientBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class