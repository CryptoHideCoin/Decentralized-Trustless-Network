Option Compare Text
Option Explicit On

Imports CHCServerSupportLibrary.Support
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon.Models.Settings
Imports CHCProtocolLibrary.AreaBase




Public Class Main

    Private _canChangeTab As Boolean = False

    Private _dataDetail As AppSettings.SettingsData.ServiceData

    Public SettingsMode As Boolean = False



    Private Function createButtonInGrid(ByVal textValue As String, ByVal nameValue As String) As DataGridViewButtonColumn

        Dim buttonColumn As DataGridViewButtonColumn

        buttonColumn = New DataGridViewButtonColumn()

        buttonColumn.HeaderText = ""
        buttonColumn.Text = textValue
        buttonColumn.Name = nameValue
        buttonColumn.Width = 60
        buttonColumn.UseColumnTextForButtonValue = True

        Return buttonColumn

    End Function


    Private Sub createGridDetail()

        applicationDataGrid.Columns(0).Visible = False
        applicationDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        applicationDataGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft

        applicationDataGrid.Columns.Add(createButtonInGrid("Edit", "edit"))
        applicationDataGrid.Columns.Add(createButtonInGrid("Delete", "delete"))

    End Sub


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If SettingsMode Then

                refreshButton.Visible = False
                registryEventButton.Visible = False
                logFileButton.Visible = False
                stopButton.Visible = False
                rememberThis.Visible = False

                tabControl.TabPages.RemoveByKey("logTabPage")

                startButton.Text = "SAVE"

            End If

            With AreaCommon.settings.data

                localPathData.Text = .dataPath
                localPortNumber.Text = .portNumber
                publicWalletAddress.Text = .walletPublicAddress

                protocolServiceAdmin.SelectedIndex = .serviceAdmin.useSecure
                serviceAdminUrl.Text = .serviceAdmin.url
                certificateServiceAdmin.Text = .serviceAdmin.certificate

                Select Case .trackMode
                    Case LogEngine.TrackRuntimeModeEnum.dontTrack : trackConfiguration.SelectedIndex = 0
                    Case LogEngine.TrackRuntimeModeEnum.trackOnlyMain : trackConfiguration.SelectedIndex = 1
                    Case LogEngine.TrackRuntimeModeEnum.trackAllRuntime : trackConfiguration.SelectedIndex = 2
                End Select

                autoCleanOption.Checked = .useTrackRotate

                startCleanEveryValue.SelectedIndex = .trackRotate.frequency
                keepOnlyRecentFileValue.SelectedIndex = .trackRotate.keepLast
                keepFileTypeValue.SelectedIndex = .trackRotate.keepFile

                useEventRegistry.Checked = .useEventRegistry
                autoStart.Checked = .autoStart
                debugModeCheck.Checked = .debugMode

                checkUpgrade.Checked = .automaticCheckUpdate

                Select Case .sourceOfUpgrade
                    Case AppSettings.SettingsData.SourceOfUpgradeEnum.staticAddress : sourceUpgradeStaticAddress.Checked = True
                    Case AppSettings.SettingsData.SourceOfUpgradeEnum.blockChainAddress : sourceDynamicAddress.Checked = True
                End Select

                addressSourceUpgradeValue.Text = .sourceOfUpgradeAddress
                certificateUpgradeValue.Text = .upgradeCertificate

                Select Case .frequencyUpgrade
                    Case AppSettings.SettingsData.FrequencyUpgradeEnum.notDefined : frequencyUpgradeValue.SelectedIndex = -1
                    Case AppSettings.SettingsData.FrequencyUpgradeEnum.every12h : frequencyUpgradeValue.SelectedIndex = 0
                    Case AppSettings.SettingsData.FrequencyUpgradeEnum.every24h : frequencyUpgradeValue.SelectedIndex = 1
                End Select

            End With

            createGridDetail()

            reloadDataDetail()

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

                .serviceAdmin.useSecure = protocolServiceAdmin.SelectedIndex
                .serviceAdmin.url = serviceAdminUrl.Text
                .serviceAdmin.certificate = certificateServiceAdmin.Text

                Select Case trackConfiguration.SelectedIndex
                    Case 0 : .trackMode = LogEngine.TrackRuntimeModeEnum.dontTrack
                    Case 1 : .trackMode = LogEngine.TrackRuntimeModeEnum.trackOnlyMain
                    Case 2 : .trackMode = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
                End Select

                .useTrackRotate = autoCleanOption.Checked

                .trackRotate.frequency = startCleanEveryValue.SelectedIndex
                .trackRotate.keepLast = keepOnlyRecentFileValue.SelectedIndex
                .trackRotate.keepFile = keepFileTypeValue.SelectedIndex

                .useEventRegistry = useEventRegistry.Checked
                .autoStart = autoStart.Checked
                .debugMode = debugModeCheck.Checked
                .automaticCheckUpdate = checkUpgrade.Checked

                If sourceUpgradeStaticAddress.Checked Then
                    .sourceOfUpgrade = AppSettings.SettingsData.SourceOfUpgradeEnum.staticAddress
                Else
                    .sourceOfUpgrade = AppSettings.SettingsData.SourceOfUpgradeEnum.blockChainAddress
                End If

                .sourceOfUpgradeAddress = addressSourceUpgradeValue.Text
                .upgradeCertificate = certificateUpgradeValue.Text

                If (frequencyUpgradeValue.SelectedIndex = -1) Then .frequencyUpgrade = AppSettings.SettingsData.FrequencyUpgradeEnum.notDefined
                If (frequencyUpgradeValue.SelectedIndex = 0) Then .frequencyUpgrade = AppSettings.SettingsData.FrequencyUpgradeEnum.every12h
                If (frequencyUpgradeValue.SelectedIndex = 1) Then .frequencyUpgrade = AppSettings.SettingsData.FrequencyUpgradeEnum.every24h

                reloadDataDetail()

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

            serviceAdministrationGroup.Enabled = stateValue
            urlServiceAdministrationLabel.Enabled = stateValue
            serviceAdminUrl.Enabled = stateValue
            testServiceAdministration.Enabled = stateValue
            certificateServiceAdministrationLabel.Enabled = stateValue
            certificateServiceAdmin.Enabled = stateValue
            certificateBrowserButton.Enabled = stateValue

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
        If (protocolServiceAdmin.SelectedIndex = -1) Then

            MessageBox.Show("The protocol URL of Service Administration is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (serviceAdminUrl.Text.Trim.Length() = 0) Then

            MessageBox.Show("The URL of Service Administration is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (certificateServiceAdmin.Text.Trim.Length() = 0) Then

            MessageBox.Show("The certificate of Service Administration is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (trackConfiguration.SelectedIndex = -1) Then

            MessageBox.Show("The track configuration is not specify.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        Else
            If (startCleanEveryValue.SelectedIndex = -1) Then

                MessageBox.Show("The Frequency Clean is not specify.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If
            If (keepOnlyRecentFileValue.SelectedIndex = -1) Then

                MessageBox.Show("The Keep Only recent file is not specify.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If
            If (keepFileTypeValue.SelectedIndex = -1) Then

                MessageBox.Show("The Keep File Type is not specify.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If

        End If
        If checkUpgrade.Checked Then

            If Not sourceUpgradeStaticAddress.Checked And Not sourceDynamicAddress.Checked Then

                MessageBox.Show("The Storage source is not setting.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If
            If (addressSourceUpgradeValue.Text.ToString.Trim.Length = 0) Then

                MessageBox.Show("The URL of source of upgrade is not setting.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If
            If (certificateUpgradeValue.Text.ToString.Trim.Length = 0) Then

                MessageBox.Show("The certificate of upgrade is not setting.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If
            If (frequencyUpgradeValue.SelectedIndex = -1) Then

                MessageBox.Show("The frequency of upgrade is not setting.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False

            End If

        End If

        Return True

    End Function


    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

        Try
            If verifyParameter() Then

                loadDataIntoSettings()

                If (AreaCommon.paths.directoryData.Trim.Length() = 0) Then

                    AreaCommon.paths.directoryData = localPathData.Text

                    AreaCommon.paths.init(CHCProtocolLibrary.AreaSystem.VirtualPathEngine.EnumSystemType.loader)

                    AreaCommon.settings.fileName = IO.Path.Combine(AreaCommon.paths.settings, AreaCommon.paths.settingFileName)

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
                    logFileButton.Enabled = (trackConfiguration.SelectedIndex > 0)
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

        If (tabControl.SelectedIndex = 4) Then

            If _canChangeTab Then Return
            If (AreaCommon.state.currentApplication <> EnumStateApplication.inRunning) Then e.Cancel = True

        End If

    End Sub


    Private Sub certificateBrowserButton_Click(sender As Object, e As EventArgs) Handles certificateBrowserButton.Click

        Try

            openFileDialog.FileName = ""
            openFileDialog.Filter = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                certificateServiceAdmin.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub testMasternodeAdministration_Click(sender As Object, e As EventArgs) Handles testServiceAdministration.Click

        If (serviceAdminUrl.Text.ToString.Trim.Length > 0) Then

            If AreaCommon.testService((protocolServiceAdmin.SelectedIndex > 0), serviceAdminUrl.Text.ToString.Trim) Then
                MessageBox.Show("Test connection succesful", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If

    End Sub


    Private Sub trackConfiguration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles trackConfiguration.SelectedIndexChanged

        If (trackConfiguration.SelectedIndex = LogEngine.TrackRuntimeModeEnum.dontTrack) Then

            autoCleanOption.Checked = False
            autoCleanOption.Enabled = False

        Else
            autoCleanOption.Enabled = True
        End If

    End Sub


    Private Sub autoCleanOption_CheckedChanged(sender As Object, e As EventArgs) Handles autoCleanOption.CheckedChanged

        startCleanEvery.Enabled = autoCleanOption.Checked
        startCleanEveryValue.Enabled = autoCleanOption.Checked
        keepOnlyRecentFile.Enabled = autoCleanOption.Checked
        keepOnlyRecentFileValue.Enabled = autoCleanOption.Checked
        keepFileType.Enabled = autoCleanOption.Checked

        If Not autoCleanOption.Checked Then

            startCleanEveryValue.SelectedIndex = -1
            keepOnlyRecentFileValue.SelectedIndex = -1
            keepFileTypeValue.SelectedIndex = -1

        End If

    End Sub


    Private Sub certificateUpgradeBrowserButton_Click(sender As Object, e As EventArgs) Handles certificateUpgradeBrowserButton.Click

        Try

            openFileDialog.FileName = ""
            openFileDialog.Filter = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                certificateUpgradeValue.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateUpgradeBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub createNewCertificateStart_Click(sender As Object, e As EventArgs) Handles createNewCertificateUpgrade.Click

        certificateUpgradeValue.Text = Certificate.createNew()

    End Sub


    Private Sub checkUpgrade_CheckedChanged(sender As Object, e As EventArgs) Handles checkUpgrade.CheckedChanged

        sourceUpgrade.Enabled = checkUpgrade.Checked
        sourceUpgradeStaticAddress.Enabled = checkUpgrade.Checked
        sourceDynamicAddress.Enabled = checkUpgrade.Checked
        addressLabel.Enabled = checkUpgrade.Checked
        addressSourceUpgradeValue.Enabled = checkUpgrade.Checked
        certificateUpgradeLabel.Enabled = checkUpgrade.Checked
        certificateUpgradeValue.Enabled = checkUpgrade.Checked
        createNewCertificateUpgrade.Enabled = checkUpgrade.Checked
        certificateUpgradeBrowserButton.Enabled = checkUpgrade.Checked
        frequencyUpgradeLabel.Enabled = checkUpgrade.Checked
        frequencyUpgradeValue.Enabled = checkUpgrade.Checked

        If Not checkUpgrade.Checked Then

            sourceUpgradeStaticAddress.Checked = False
            sourceDynamicAddress.Checked = False
            addressSourceUpgradeValue.Text = ""
            certificateUpgradeValue.Text = ""
            frequencyUpgradeValue.SelectedIndex = -1

        End If

    End Sub


    Private Sub enableDetail(ByVal value As Boolean)

        Try

            urlDetailLabel.Enabled = value
            protocolURLDetailCombo.Enabled = value
            urlDetailValue.ReadOnly = Not value
            certificateDetailLabel.Enabled = value
            certificateDetailValue.ReadOnly = Not value
            certificateDetailButton.Enabled = value
            completeApplicationPathLabel.Enabled = value
            completeApplicationPathValue.ReadOnly = Not value
            completeApplicationDetailButton.Enabled = value
            confirmDetailButton.Enabled = value
            cancelDetailButton.Enabled = value
            newCertificateDetailButton.Enabled = value

        Catch ex As Exception

        End Try

    End Sub


    Private Sub clearFieldDetail()

        Try

            protocolURLDetailCombo.SelectedIndex = -1
            urlDetailValue.Text = ""
            certificateDetailValue.Text = ""
            completeApplicationPathValue.Text = ""

        Catch ex As Exception
        End Try

    End Sub


    Private Sub addNewService_Click(sender As Object, e As EventArgs) Handles addNewService.Click

        applicationDataGrid.ClearSelection()
        enableDetail(True)
        clearFieldDetail()

        _dataDetail = New AppSettings.SettingsData.ServiceData

        protocolURLDetailCombo.Select()

    End Sub


    Private Sub newCertificateDetailButton_Click(sender As Object, e As EventArgs) Handles newCertificateDetailButton.Click

        certificateDetailValue.Text = Certificate.createNew()

    End Sub


    Private Sub certificateDetailButton_Click(sender As Object, e As EventArgs) Handles certificateDetailButton.Click

        Try

            openFileDialog.FileName = ""
            openFileDialog.Filter = ""

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                certificateDetailValue.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during certificateDetailValue_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub completeApplicationDetailButton_Click(sender As Object, e As EventArgs) Handles completeApplicationDetailButton.Click

        Try

            openFileDialog.FileName = ""
            openFileDialog.Filter = "Exe Files (.exe)|*.exe"

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                completeApplicationPathValue.Text = openFileDialog.FileName
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurrent during completeApplicationDetailButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Function validateDataDetail() As Boolean

        If (protocolURLDetailCombo.SelectedIndex = -1) Then

            MessageBox.Show("The url protocol is not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (urlDetailValue.Text.ToString.Trim.Length = 0) Then

            MessageBox.Show("The url is not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (certificateDetailValue.Text.ToString.Trim.Length = 0) Then

            MessageBox.Show("The certificate is not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (completeApplicationPathValue.Text.ToString.Trim.Length = 0) Then

            MessageBox.Show("The Complete application path is not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return True

    End Function


    Private Sub reloadDataDetail()

        Try

            Dim rowItem As ArrayList
            Dim rowIndex As Integer = 0

            applicationDataGrid.Rows.Clear()

            For Each item In AreaCommon.settings.data.services

                rowItem = New ArrayList

                rowItem.Add(rowIndex.ToString())
                rowItem.Add(item.applicationPath)

                applicationDataGrid.Rows.Add(rowItem.ToArray)

                rowIndex += 1

            Next

        Catch ex As Exception
            MessageBox.Show("Error during reloadDataDetail " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub selectGridDetailRow()

        If (applicationDataGrid.SelectedRows.Count > 0) Then

            Try

                _dataDetail = AreaCommon.settings.data.services(applicationDataGrid.SelectedRows.Item(0).Cells(0).Value.ToString())

                If _dataDetail.protocolSecure Then
                    protocolURLDetailCombo.SelectedIndex = 1
                Else
                    protocolURLDetailCombo.SelectedIndex = 0
                End If

                urlDetailValue.Text = _dataDetail.url
                certificateDetailValue.Text = _dataDetail.certificate
                completeApplicationPathValue.Text = _dataDetail.applicationPath

            Catch ex As Exception
                MessageBox.Show("Error during selectGridDetailRow " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else

            protocolURLDetailCombo.SelectedIndex = -1
            urlDetailValue.Text = ""
            certificateDetailValue.Text = ""
            completeApplicationPathValue.Text = ""

        End If

        enableDetail(False)

    End Sub


    Private Sub confirmDetailButton_Click(sender As Object, e As EventArgs) Handles confirmDetailButton.Click

        If validateDataDetail() Then

            If (applicationDataGrid.SelectedRows.Count = 0) Then
                _dataDetail = New AppSettings.SettingsData.ServiceData

                AreaCommon.settings.data.services.Add(_dataDetail)
            Else
                _dataDetail = AreaCommon.settings.data.services(applicationDataGrid.SelectedRows.Item(0).Index)
            End If

            _dataDetail.protocolSecure = (protocolURLDetailCombo.SelectedIndex = 1)
            _dataDetail.url = urlDetailValue.Text
            _dataDetail.certificate = certificateDetailValue.Text
            _dataDetail.applicationPath = completeApplicationPathValue.Text

            reloadDataDetail()
            selectGridDetailRow()

        End If

    End Sub


    Private Sub applicationDataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles applicationDataGrid.SelectionChanged

        selectGridDetailRow()

    End Sub


    Private Sub applicationDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles applicationDataGrid.CellContentClick

        Select Case e.ColumnIndex
            Case 2
                enableDetail(True)

                protocolURLDetailCombo.Select()
            Case 3
                Try
                    AreaCommon.settings.data.services.RemoveAt(applicationDataGrid.SelectedRows.Item(0).Cells(0).Value.ToString())

                    reloadDataDetail()
                Catch ex As Exception
                    MessageBox.Show("Error during applicationDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
        End Select

    End Sub

    Private Sub cancelDetailButton_Click(sender As Object, e As EventArgs) Handles cancelDetailButton.Click
        selectGridDetailRow()

        applicationDataGrid.Select()
    End Sub


End Class
