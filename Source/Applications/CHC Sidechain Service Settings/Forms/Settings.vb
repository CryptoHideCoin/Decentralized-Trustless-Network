Option Compare Text
Option Explicit On

Imports CHCModels.AreaModel.Administration.Security
Imports CHCModels.AreaModel.Administration.Settings
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Encrypted
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModels.AreaModel.Network.Response
Imports CHCProtocolLibrary.AreaWallet.Support




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
                Select Case command.parameterValue("service").ToLower
                    Case "localworkmachine" : chainServiceName.SelectedIndex = 0
                    Case "sidechainservice" : chainServiceName.SelectedIndex = 1
                    Case "primary" : chainServiceName.SelectedIndex = 2
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
        selectServicePort.Enabled = True
        certificateClient.Enabled = True
        saveButton.Enabled = True

        If (chainServiceName.Text.CompareTo("Local Work Machine") = 0) Then
            serviceID.Enabled = False
            serviceUUID.Enabled = False
            adminPublicAddress.Enabled = False
            selectPublicPort.Enabled = False

            tabControl.TabPages(0).Enabled = False
            tabControl.TabPages(2).Enabled = False
            tabControl.TabPages(3).Enabled = False
        Else
            tabControl.TabPages(0).Enabled = True
            tabControl.TabPages(2).Enabled = True
            tabControl.TabPages(3).Enabled = True

            internalNameLabel.Enabled = True
            internalName.Enabled = True
            networkNameLabel.Enabled = True
            networkName.Enabled = True
            intranetMode.Enabled = True
            secureChannel.Enabled = True
            serviceID.Enabled = True
            serviceUUID.Enabled = True
            adminPublicAddress.Enabled = True
            selectPublicPort.Enabled = True
            logInformations.Enabled = True
            useEventRegistry.Enabled = True
            useCounter.Enabled = True
            useMessageService.Enabled = True
        End If

    End Sub

    ''' <summary>
    ''' This method provide to get a data and request 
    ''' </summary>
    ''' <param name="engineFile"></param>
    ''' <returns></returns>
    Private Function getDataFromFile(ByRef engineFile As BaseFile(Of CHCModels.AreaModel.Administration.Settings.SettingsSidechainService)) As CHCModels.AreaModel.Administration.Settings.SettingsSidechainService
        Dim result As CHCModels.AreaModel.Administration.Settings.SettingsSidechainService
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
            result = New CHCModels.AreaModel.Administration.Settings.SettingsSidechainService
        End Try

#Disable Warning BC42104
        Return result
#Enable Warning BC42104
    End Function

    ''' <summary>
    ''' This method provide to fill all field
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Private Function fillAllField(ByVal data As SettingsSidechainService) As Boolean
        Try
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
    ''' This method provide to load data from a data path
    ''' </summary>
    ''' <returns></returns>
    Private Function loadData() As Boolean
        Try
            Dim completeFileName As String = ""
            Dim data As SettingsSidechainService
            Dim engineFile As New BaseFile(Of SettingsSidechainService)

            completeFileName = IO.Path.Combine(dataPath.Text, "Settings")
            completeFileName = IO.Path.Combine(completeFileName, chainServiceName.Text.Replace(" ", "") & ".Settings")

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

            Return fillAllField(data)
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
    ''' This method provide to get the information from the interface
    ''' </summary>
    ''' <returns></returns>
    Private Function getDataModel() As SettingsSidechainService
        Dim data As New SettingsSidechainService
        Try
            With data
                Select Case chainServiceName.SelectedIndex
                    Case 0 : .sideChainName = "Primary"
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
        Catch ex As Exception
        End Try

        Return data
    End Function

    ''' <summary>
    ''' This method provide to save a data
    ''' </summary>
    ''' <returns></returns>
    Private Function saveData() As Boolean
        Try
            Dim completeFileName As String = ""
            Dim data As New SettingsSidechainService
            Dim engineFile As New BaseFile(Of SettingsSidechainService)

            completeFileName = IO.Path.Combine(dataPath.Text, "Settings")
            completeFileName = IO.Path.Combine(completeFileName, chainServiceName.Text.Replace(" ", "") & ".Settings")

            data = getDataModel()

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

    ''' <summary>
    ''' This method provide to reset all field
    ''' </summary>
    ''' <returns></returns>
    Private Function resetAllField() As Boolean
        internalName.Text = ""
        networkName.Text = ""
        serviceID.Text = ""
        adminPublicAddress.value = ""
        certificateClient.value = ""
        selectPublicPort.value = 0
        selectServicePort.value = 0
        intranetMode.Checked = False
        secureChannel.Checked = False

        logInformations.trackConfiguration = CHCModels.AreaModel.Log.TrackRuntimeModeEnum.neverTrace
        logInformations.maxNumHours = 0
        logInformations.maxNumberOfRegistrations = 0
        logInformations.useTrackRotate = False

        logInformations.trackRotateFrequency = CHCModels.AreaModel.Log.LogRotateConfig.FrequencyEnum.every12h
        logInformations.trackRotateKeepFile = CHCModels.AreaModel.Log.LogRotateConfig.KeepFileEnum.nothingFiles
        logInformations.trackRotateKeepLast = CHCModels.AreaModel.Log.KeepEnum.lastDay

        useEventRegistry.Checked = False
        useCounter.Checked = False
        useMessageService.Checked = False
        useAutoMaintenance.Checked = False

        Return True
    End Function

    ''' <summary>
    ''' This method provide to load entire data
    ''' </summary>
    ''' <param name="silentMode"></param>
    ''' <returns></returns>
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
                resetAllField()
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

        fromRemoteButton.Enabled = True
        toRemoteButton.Enabled = True
    End Sub

    ''' <summary>
    ''' This method provide to test a data information and return true if it successfully and false is not
    ''' </summary>
    ''' <returns></returns>
    Private Function testDataInformationSuccessfully() As Boolean
        If (networkName.Text.Trim.Length = 0) And networkName.Enabled Then
            MessageBox.Show("The Network referement is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 0
            networkName.Select()

            Return False
        End If
        If (adminPublicAddress.value.Trim.Length = 0) And adminPublicAddress.Enabled Then
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
        If (selectPublicPort.value = 0) And selectPublicPort.Enabled Then
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

                Close()
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

        Return True
    End Function

    Private Sub useAutoMaintenance_CheckedChanged(sender As Object, e As EventArgs) Handles useAutoMaintenance.CheckedChanged
        enableAutoMaintenance(useAutoMaintenance.Checked)
    End Sub

    ''' <summary>
    ''' This method provide to build a URL
    ''' </summary>
    ''' <param name="api"></param>
    ''' <param name="ipAddress"></param>
    ''' <returns></returns>
    Private Function buildURL(ByVal api As String, ByVal ipAddress As String) As String
        Dim url As String = ""
        Try
            Dim proceed As Boolean = True

            If proceed Then
                If secureChannel.Checked Then
                    url += "https"
                Else
                    url += "http"
                End If
            End If
            If proceed Then
                If (ipAddress.Length = 0) Then
                    ipAddress += "localhost:" & selectServicePort.value
                Else
                    ipAddress += ":" & selectServicePort.value
                End If
            End If
            If proceed Then
                url += "://" & ipAddress & "/api"
            End If
            If proceed Then
                If (serviceID.Text.Length > 0) Then
                    url += "/" & serviceID.Text & api
                Else
                    url += api
                End If
            End If
        Catch ex As Exception
        End Try

        Return url
    End Function

    ''' <summary>
    ''' This method provide to get a service
    ''' </summary>
    ''' <returns></returns>
    Private Function serviceFound(ByVal ipAddress As String) As Boolean
        Try
            Dim remote As New ProxyWS(Of RemoteResponse)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/service/test/", ipAddress)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                Return (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If

            Return proceed
        Catch ex As Exception
            Console.WriteLine("Error during serviceFound - " & ex.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method sign a certificate with private key
    ''' </summary>
    ''' <returns></returns>
    Private Function signCertificate() As String
        Try
            Dim privateKey As String = adminPublicAddress.privateKey
            Dim certificate As String = certificateClient.value

            Return WalletAddressEngine.createSignature(privateKey, certificate)
        Catch ex As Exception
            Console.WriteLine("Error during signCertificate:" & ex.Message)

            Return ""
        End Try
    End Function

    ''' <summary>
    ''' This method provide to get an access key
    ''' </summary>
    ''' <returns></returns>
    Private Function getAccessKey(ByRef accessKey As String, ByVal ipAddress As String) As Boolean
        Try
            Dim remote As New ProxyWS(Of ResponseRequestAccessKeyModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/administration/security/requestAccessKey/?signature=" & signCertificate(), ipAddress)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                accessKey = remote.data.accessKey

                proceed = True
            End If

            Return proceed
        Catch ex As Exception
            Console.WriteLine("Error during getAccessKey - " & ex.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method sign an access key
    ''' </summary>
    ''' <returns></returns>
    Private Function signAccessKey(ByVal accessKey As String) As String
        Try
            Dim privateKey As String = adminPublicAddress.privateKey

            Return WalletAddressEngine.createSignature(privateKey, accessKey)
        Catch ex As Exception
            Console.WriteLine("Error during signAccessKey:" & ex.Message)

            Return ""
        End Try
    End Function

    ''' <summary>
    ''' This method provide to get a security token
    ''' </summary>
    ''' <returns></returns>
    Private Function getSecurityToken(ByRef securityToken As String, ByVal ipAddress As String, ByVal accessKey As String) As Boolean
        Try
            Dim remote As New ProxyWS(Of ResponseRequestAdminSecurityTokenModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = buildURL("/administration/security/requestAdminSecurityToken/?signature=" & signAccessKey(accessKey), ipAddress)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                securityToken = remote.data.tokenValue

                proceed = True
            End If

            Return proceed
        Catch ex As Exception
            Console.WriteLine("Error during serviceFound - " & ex.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to save a remote config into server
    ''' </summary>
    ''' <param name="securityToken"></param>
    ''' <param name="ipAddress"></param>
    ''' <returns></returns>
    Private Function saveRemoteConfig(ByVal securityToken As String, ByVal ipAddress As String) As Boolean
        Try
            Dim remote As New ProxyWS(Of SettingsSidechainService)
            Dim proceed As Boolean = True
            Dim data As New SettingsSidechainService

            If proceed Then
                remote.url = buildURL("/administration/settings/?securityToken=" & securityToken, ipAddress)
            End If
            If proceed Then
                remote.data = getDataModel()

                proceed = True
            End If
            If proceed Then
                proceed = (remote.sendData("PUT").Length = 0)
            End If
            If proceed Then
                proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If

            Return proceed
        Catch ex As Exception
            Console.WriteLine("Error during saveRemoteConfig - " & ex.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to read a remote config
    ''' </summary>
    ''' <param name="securityToken"></param>
    ''' <param name="ipAddress"></param>
    ''' <returns></returns>
    Private Function readRemoteConfig(ByVal securityToken As String, ByVal ipAddress As String) As Boolean
        Try
            Dim remote As New ProxyWS(Of ResponseUpdateSettingsModel)
            Dim proceed As Boolean = True
            Dim data As New ResponseUpdateSettingsModel

            If proceed Then
                remote.url = buildURL("/administration/settings/?securityToken=" & securityToken, ipAddress)
            End If
            If proceed Then
                proceed = (remote.getData().Length = 0)
            End If
            If proceed Then
                proceed = fillAllField(remote.data.value)
            End If

            Return proceed
        Catch ex As Exception
            Console.WriteLine("Error during saveRemoteConfig - " & ex.Message)

            Return False
        End Try
    End Function

    Private Sub toRemoteButton_Click(sender As Object, e As EventArgs) Handles toRemoteButton.Click
        Dim proceed As Boolean = True
        Dim ipAddress As String = "", accessKey As String = "", securityToken As String = ""

        If proceed Then
            proceed = testDataInformationSuccessfully()
        End If
        If proceed Then
            ipAddress = InputBox("Insert IP Address of remote server", "Server Address", "localhost")
        End If
        If proceed Then
            If Not serviceFound(ipAddress) Then
                MessageBox.Show("Problem during test service", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If Not getAccessKey(accessKey, ipAddress) Then
                MessageBox.Show("Problem during request an access key", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If Not getSecurityToken(securityToken, ipAddress, accessKey) Then
                MessageBox.Show("Problem during request a security token", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If Not saveRemoteConfig(securityToken, ipAddress) Then
                MessageBox.Show("Problem during transfer a remote config", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            MessageBox.Show("Remote settings update", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub fromRemoteButton_Click(sender As Object, e As EventArgs) Handles fromRemoteButton.Click
        Dim proceed As Boolean = True
        Dim ipAddress As String = "", accessKey As String = "", securityToken As String = ""

        If proceed Then
            proceed = testDataInformationSuccessfully()
        End If
        If proceed Then
            ipAddress = InputBox("Insert IP Address of remote server", "Server Address", "localhost")
        End If
        If proceed Then
            If Not serviceFound(ipAddress) Then
                MessageBox.Show("Problem during test service", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If Not getAccessKey(accessKey, ipAddress) Then
                MessageBox.Show("Problem during request an access key", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If Not getSecurityToken(securityToken, ipAddress, accessKey) Then
                MessageBox.Show("Problem during request a security token", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If Not readRemoteConfig(securityToken, ipAddress) Then
                MessageBox.Show("Problem during transfer a remote config", "Connection problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            MessageBox.Show("Remote settings update", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub chainServiceName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chainServiceName.SelectedIndexChanged

    End Sub
End Class
