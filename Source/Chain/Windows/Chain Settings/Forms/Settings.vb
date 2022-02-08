Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Encrypted
Imports CHCCommonLibrary.AreaEngine.CommandLine




''' <summary>
''' This class manage the settings form
''' </summary>
Public Class Settings

    Private _ParameterExist As Boolean = False
    Private _Password As String = ""
    Private _PortList = New List(Of String) From {1, 5, 7, 9, 11, 13, 17, 18, 19, 20, 21, 22, 23, 25, 37, 39, 42, 43, 49, 50, 53, 67, 68, 69, 70, 71, 79, 80, 81, 82, 88, 101, 102, 105, 107, 109, 110, 111, 113, 115, 117, 119, 123, 137, 138, 139, 143, 161, 162, 177, 179, 194, 199, 201, 209, 210, 213, 220, 369, 370, 389, 427, 443, 444, 445, 464, 500, 512, 513, 514, 515, 517, 518, 520, 521, 525, 530, 531, 532, 533, 540, 543, 544, 546, 547, 548, 554, 556, 563, 587, 631, 636, 674, 694, 749, 750, 873, 992, 993, 995, 1080, 1433, 1434, 1494, 1512, 1524, 1701, 1719, 1720, 1812, 1813, 1985, 2008, 2010, 2049, 2102, 2103, 2104, 2401, 2809, 3306, 4321, 5999, 6000, 11371, 13720, 13721, 13724, 13782, 13783, 22273, 23399, 25565, 26000, 27017, 33434}


    ''' <summary>
    ''' This method provide to test if the user indicate the parameter in the command line
    ''' </summary>
    ''' <returns></returns>
    Private Function readParameters() As Boolean
        Try
            Dim command As New CommandStructure
            Dim engine As New CommandBuilder

            command = engine.run()

            If (command.code.ToLower.CompareTo("force") = 0) Then
                Select Case command.parameterValue("service")
                    Case "primary" : chainServiceName.SelectedIndex = 0
                End Select

                dataPath.Text = command.parameterValue("dataPath")
                _Password = command.parameterValue("password")

                _ParameterExist = True

                Return True
            End If
        Catch ex As Exception
        End Try

        Return False
    End Function

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If readParameters() Then
            entireLoad(True)
        Else
            Dim paths As New AreaSystem.Paths

            dataPath.Text = paths.readDefinePath()
        End If
    End Sub

    ''' <summary>
    ''' This method provide to enable all field of the form
    ''' </summary>
    Private Sub enableForm()
        tabControl.Enabled = True
        internalNameLabel.Enabled = True
        internalName.Enabled = True
        networkNameLabel.Enabled = True
        networkName.Enabled = True
        intranetMode.Enabled = True
        secureChannel.Enabled = True
        serviceID.Enabled = True
        serviceUUID.Enabled = True
        adminPublicAddress.Enabled = True
        certificateClient.Enabled = True
        selectPublicPort.Enabled = True
        selectServicePort.Enabled = True
        selectLocalWorkMachinePort.Enabled = True
        logInformations.Enabled = True
        useEventRegistry.Enabled = True
        useCounter.Enabled = True
        useMessageService.Enabled = True
        saveButton.Enabled = True
    End Sub

    ''' <summary>
    ''' This method provide to get a data and request 
    ''' </summary>
    ''' <param name="engineFile"></param>
    ''' <returns></returns>
    Private Function getDataFromFile(ByRef engineFile As BaseFile(Of CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService)) As CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService
        Dim result As CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService
        Try
            Dim decodeData As Boolean = False
            Dim errorReading As Boolean = False

            Do While Not decodeData And Not errorReading
                If engineFile.read() Then
                    result = engineFile.data

                    decodeData = True
                Else
                    _Password = getPassword()

                    If (_Password.CompareTo("(cancelMe)") = 0) Then
                        errorReading = True
                    Else
                        engineFile.cryptoKEY = _Password

                        engineFile.noCrypt = False
                    End If
                End If
            Loop
        Catch ex As Exception
            result = New CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService
        End Try

#Disable Warning BC42104
        Return result
#Enable Warning BC42104
    End Function

    ''' <summary>
    ''' This method provide to load data from a data path
    ''' </summary>
    ''' <returns></returns>
    Private Function loadData() As Boolean
        Try
            Dim completeFileName As String = ""
            Dim data As CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService
            Dim engineFile As New BaseFile(Of CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService)

            completeFileName = IO.Path.Combine(dataPath.Text, "Settings")
            completeFileName = IO.Path.Combine(completeFileName, chainServiceName.Text & ".Settings")

            If Not IO.File.Exists(completeFileName) Then Return False

            openAsFileButton.Enabled = True

            If (_Password.Length > 0) Then
                engineFile.cryptoKEY = _Password
            Else
                engineFile.noCrypt = True
            End If

            engineFile.fileName = completeFileName

            data = getDataFromFile(engineFile)

            If IsNothing(data) Then
                MessageBox.Show("Error during read file e/o parameter", "Error notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End
            End If

            With data
                internalName.Text = .internalName
                networkName.Text = .networkReferement
                intranetMode.Checked = .intranetMode
                secureChannel.Checked = .secureChannel
                serviceID.Text = .serviceID
                adminPublicAddress.value = .publicAddress
                certificateClient.value = .clientCertificate
                selectPublicPort.value = .publicPort
                selectServicePort.value = .servicePort
                selectLocalWorkMachinePort.value = .localWorkMachinePort
                useAutoMaintenance.Checked = .useAutoMaintanance

                If .useAutoMaintanance Then
                    frequencyAutoMaintenance.Text = .autoMaintenanceFrequencyHours

                    startCleanEveryValueCombo.SelectedIndex = .trackRotateConfig.frequency
                    keepOnlyRecentFileValueCombo.SelectedIndex = .trackRotateConfig.keepLast
                    keepFileTypeValueCombo.SelectedIndex = .trackRotateConfig.keepFile
                End If

                logInformations.trackConfiguration = .trackConfiguration
                logInformations.maxNumHours = .changeLogFileMaxNumHours
                logInformations.maxNumberOfRegistrations = .changeLogFileNumRegistrations

                useEventRegistry.Checked = .useEventRegistry
                useCounter.Checked = .useRequestCounter
                useMessageService.Checked = .useAdminMessage
            End With

            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to acquire the password 
    ''' </summary>
    ''' <returns></returns>
    Private Function getPassword() As String
        Dim formPassword As New RequestPassword
        Try
            If (formPassword.ShowDialog() = DialogResult.OK) Then
                Return formPassword.passwordValue.Text
            Else
                Return "(cancelMe)"
            End If
        Catch ex As Exception
            Return "(cancelMe)"
        Finally
            formPassword = Nothing
        End Try
    End Function

    ''' <summary>
    ''' This method provide to save a data
    ''' </summary>
    ''' <returns></returns>
    Private Function saveData() As Boolean
        Try
            Dim completeFileName As String = ""
            Dim data As New CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService
            Dim engineFile As New BaseFile(Of CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainService)

            completeFileName = IO.Path.Combine(dataPath.Text, "Settings")
            completeFileName = IO.Path.Combine(completeFileName, chainServiceName.Text & ".Settings")

            With data
                Select Case chainServiceName.SelectedIndex
                    Case 0 : .chainName = "Primary"
                End Select

                .internalName = internalName.Text
                .networkReferement = networkName.Text
                .intranetMode = intranetMode.Checked
                .secureChannel = secureChannel.Checked
                .serviceID = serviceID.Text
                .publicAddress = adminPublicAddress.value
                .clientCertificate = certificateClient.value
                .publicPort = selectPublicPort.value
                .servicePort = selectServicePort.value
                .localWorkMachinePort = selectLocalWorkMachinePort.value
                .useAutoMaintanance = useAutoMaintenance.Checked

                If useAutoMaintenance.Checked Then
                    .autoMaintenanceFrequencyHours = frequencyAutoMaintenance.Value
                    .trackRotateConfig.frequency = startCleanEveryValueCombo.SelectedIndex
                    .trackRotateConfig.keepLast = keepOnlyRecentFileValueCombo.SelectedIndex
                    .trackRotateConfig.keepFile = keepFileTypeValueCombo.SelectedIndex
                End If

                .trackConfiguration = logInformations.trackConfiguration
                .changeLogFileMaxNumHours = logInformations.maxNumHours
                .changeLogFileNumRegistrations = logInformations.maxNumberOfRegistrations
                .useEventRegistry = useEventRegistry.Checked
                .useRequestCounter = useCounter.Checked
                .useAdminMessage = useMessageService.Checked
            End With

            _Password = getPassword()

            If (_Password.CompareTo("(cancelMe)") = 0) Then
                Return False
            End If

            engineFile.fileName = completeFileName
            engineFile.data = data

            If (_Password.Length = 0) Then
                engineFile.noCrypt = True
            Else
                engineFile.cryptoKEY = _Password
            End If

            Return engineFile.save()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Function entireLoad(ByVal silentMode As Boolean) As Boolean
        Try
            Dim paths As New AreaSystem.Paths

            If (chainServiceName.Text.Length = 0) Then
                If Not silentMode Then
                    MessageBox.Show("The service name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Return False
            End If
            If (dataPath.Text.Trim.Length = 0) Then
                If Not silentMode Then
                    MessageBox.Show("The data path is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Return False
            End If
            If Not IO.Directory.Exists(dataPath.Text) Then
                If Not silentMode Then
                    MessageBox.Show("The data path is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Return False
            End If

            paths.pathBaseData = dataPath.Text

            paths.init()

            enableForm()

            If Not loadData() Then
                internalName.Text = ""
                networkName.Text = ""
                serviceID.Text = ""
                adminPublicAddress.value = ""
                certificateClient.value = ""
                selectPublicPort.value = 0
                selectServicePort.value = 0
                intranetMode.Checked = False
                secureChannel.Checked = False

                logInformations.trackConfiguration = CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrackEver
                logInformations.maxNumHours = 0
                logInformations.maxNumberOfRegistrations = 0
                logInformations.useTrackRotate = False

                logInformations.trackRotateFrequency = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h
                logInformations.trackRotateKeepFile = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles
                logInformations.trackRotateKeepLast = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay

                useEventRegistry.Checked = False
                useCounter.Checked = False
            Else
                If Not _ParameterExist Then
                    paths.updateRootPath(dataPath.Text)
                End If
            End If

            adminPublicAddress.dataPath = paths.pathKeystore

            internalName.Select()

            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Sub loadSettingButton_Click(sender As Object, e As EventArgs) Handles loadSettingButton.Click
        entireLoad(False)
    End Sub

    ''' <summary>
    ''' This method provide to test a data information and return true if it successfully and false is not
    ''' </summary>
    ''' <returns></returns>
    Private Function testDataInformationSuccessfully() As Boolean
        If (networkName.Text.Trim.Length = 0) Then
            MessageBox.Show("The Network referement is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 0
            networkName.Select()

            Return False
        End If
        If (adminPublicAddress.value.Trim.Length = 0) Then
            MessageBox.Show("The Admin wallet address is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 1
            adminPublicAddress.Select()

            Return False
        End If
        If (certificateClient.value.Trim.Length = 0) Then
            MessageBox.Show("The Certificate is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 1
            certificateClient.Select()

            Return False
        End If
        If (selectPublicPort.value = 0) Then
            MessageBox.Show("The Public port is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 1
            selectPublicPort.Select()

            Return False
        End If
        If (selectServicePort.value = 0) Then
            MessageBox.Show("The Service port is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 1
            selectServicePort.Select()

            Return False
        End If
        If (selectServicePort.value = selectPublicPort.value) Then
            MessageBox.Show("The service port and public is same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 1
            selectServicePort.Select()

            Return False
        End If
        If _PortList.ToString.Contains(selectServicePort.value) Then
            MessageBox.Show("The service port is used to the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 1
            selectServicePort.Select()

            Return False
        End If
        If _PortList.ToString.Contains(selectPublicPort.value) Then
            MessageBox.Show("The public port is used to the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 1
            selectServicePort.Select()

            Return False
        End If

        Return True
    End Function

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        If testDataInformationSuccessfully() Then
            If saveData() Then
                If Not _ParameterExist Then
                    Dim paths As New AreaSystem.Paths

                    paths.updateRootPath(dataPath.Text)
                End If

                MessageBox.Show("Configuration saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End
            End If
        End If
    End Sub

    Private Sub browseLocalPath_Click(sender As Object, e As EventArgs) Handles browseLocalPath.Click
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
            MessageBox.Show("An error occurrent during browseLocalPath_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub openAsFileButton_Click(sender As Object, e As EventArgs) Handles openAsFileButton.Click
        Try
            Dim completeFileName As String = ""

            completeFileName = IO.Path.Combine(dataPath.Text, "Settings")
            completeFileName = IO.Path.Combine(completeFileName, chainServiceName.Text & ".Settings")

            Shell("notepad.exe " & completeFileName, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show("An error occurrent during openAsFileButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub infoButton_Click(sender As Object, e As EventArgs) Handles infoButton.Click
        informations.ShowDialog()
    End Sub

    Private Function enableAutoMaintenance(ByVal value As Boolean) As Boolean
        Try
            frequencyLabel.Enabled = value
            frequencyAutoMaintenance.Enabled = value
            unitMeasureFrequencyLabel.Enabled = value
            startCleanEveryLabel.Enabled = value
            startCleanEveryValueCombo.Enabled = value
            keepOnlyRecentFileLabel.Enabled = value
            keepOnlyRecentFileValueCombo.Enabled = value
            keepFileTypeLabel.Enabled = value
            keepFileTypeValueCombo.Enabled = value

            If Not value Then
                frequencyAutoMaintenance.Text = "0"
                startCleanEveryValueCombo.SelectedIndex = -1
                keepOnlyRecentFileValueCombo.SelectedIndex = -1
                keepFileTypeValueCombo.SelectedIndex = -1
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Sub useAutoMaintenance_CheckedChanged(sender As Object, e As EventArgs) Handles useAutoMaintenance.CheckedChanged
        enableAutoMaintenance(useAutoMaintenance.Checked)
    End Sub

End Class
