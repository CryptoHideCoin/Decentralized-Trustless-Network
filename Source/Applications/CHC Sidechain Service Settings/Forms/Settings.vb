Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Administration.Security
Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCProtocolLibrary.AreaWallet.Support




''' <summary>
''' This class manage the settings form
''' </summary>
Public Class Settings

    Private Property _ParameterExist As Boolean = False
    Private Property _Password As String = ""
    Private Property _PortList = New List(Of String) From {1, 5, 7, 9, 11, 13, 17, 18, 19, 20, 21, 22, 23, 25, 37, 39, 42, 43, 49, 50, 53, 67, 68, 69, 70, 71, 79, 80, 81, 82, 88, 101, 102, 105, 107, 109, 110, 111, 113, 115, 117, 119, 123, 137, 138, 139, 143, 161, 162, 177, 179, 194, 199, 201, 209, 210, 213, 220, 369, 370, 389, 427, 443, 444, 445, 464, 500, 512, 513, 514, 515, 517, 518, 520, 521, 525, 530, 531, 532, 533, 540, 543, 544, 546, 547, 548, 554, 556, 563, 587, 631, 636, 674, 694, 749, 750, 873, 992, 993, 995, 1080, 1433, 1434, 1494, 1512, 1524, 1701, 1719, 1720, 1812, 1813, 1985, 2008, 2010, 2049, 2102, 2103, 2104, 2401, 2809, 3306, 4321, 5999, 6000, 11371, 13720, 13721, 13724, 13782, 13783, 22273, 23399, 25565, 26000, 27017, 33434}
    Private Property _Data As SettingsSidechainServiceComplete
    Private Property _DuringReadData As Boolean = False


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
                    Case "localworkmachine" : sidechainServiceName.SelectedIndex = 0
                    Case "sidechainservice" : sidechainServiceName.SelectedIndex = 1
                    Case "primary" : sidechainServiceName.SelectedIndex = 2
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
        selectPublicPort.isNecessary = False
        selectServicePort.isNecessary = False

        If readParameters() Then
            entireLoad(True)
        Else
            Dim paths As New AreaSystem.Paths

            dataPath.Text = paths.readDefinePath()
        End If
    End Sub

    Private Sub disableForm()
        tabControl.TabPages(0).Select()
        tabControl.Enabled = False

        internalNameLabel.Enabled = False
        internalName.Enabled = False

        networkNameLabel.Enabled = False
        networkName.Enabled = False

        serviceMode.Enabled = False
        serviceModeLabel.Enabled = False

        intranetMode.Enabled = False
    End Sub

    ''' <summary>
    ''' This method provide to enable all field of the form
    ''' </summary>
    Private Sub enableForm()
        tabControl.Enabled = True
        selectServicePort.Enabled = True
        certificateClient.Enabled = True
        saveButton.Enabled = True

        If (sidechainServiceName.Text.CompareTo("Local Work Machine") = 0) Then
            internalNameLabel.Enabled = False
            internalName.Enabled = False
            secureChannel.Enabled = True

            staticIPAddressLabel.Enabled = False
            staticIPAddress.Enabled = False
            pathBaseLabel.Enabled = False
            pathBase.Enabled = False
            serviceUUID.Enabled = False
            serviceID.Enabled = False

            selectPublicPort.Enabled = False

            useTrackLog.Enabled = False
            useEventRegistry.Enabled = False
            useCounter.Enabled = False
            useMessage.Enabled = False
            useProfile.Enabled = False
            useAlert.Enabled = False
            useAutoMaintenance.Enabled = False

            tabControl.TabPages(2).Enabled = True
            tabControl.TabPages(3).Enabled = False
        Else
            internalNameLabel.Enabled = True
            internalName.Enabled = True
            secureChannel.Enabled = True

            staticIPAddressLabel.Enabled = True
            staticIPAddress.Enabled = True
            pathBaseLabel.Enabled = True
            pathBase.Enabled = True
            serviceUUID.Enabled = True
            serviceID.Enabled = True

            selectPublicPort.Enabled = True

            useTrackLog.Enabled = True
            useEventRegistry.Enabled = False
            useCounter.Enabled = False
            useMessage.Enabled = False
            useProfile.Enabled = False
            useAlert.Enabled = False
            useAutoMaintenance.Enabled = True

            tabControl.TabPages(2).Enabled = True
            tabControl.TabPages(3).Enabled = True

            useTrackLog.Enabled = True
        End If

        tabControl.TabPages(0).Enabled = True

        networkNameLabel.Enabled = True
        networkName.Enabled = True

        serviceModeLabel.Enabled = True
        serviceMode.Enabled = True

        intranetMode.Enabled = True
        settingsTrack.Enabled = False
    End Sub

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
            formPassword.Close()

            formPassword = Nothing
        End Try
    End Function

    ''' <summary>
    ''' This method provide to fill all field
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Private Function fillAllField() As Boolean
        Try
            With _Data
                internalName.Text = .internalName
                networkName.Text = .networkReferement
                serviceMode.SelectedIndex = .serviceMode
                intranetMode.Checked = .intranetMode

                staticIPAddress.Text = .staticIP
                pathBase.Text = .middlePath
                serviceID.Text = .serviceID
                selectPublicPort.value = .publicPort
                selectServicePort.value = .servicePort
                secureChannel.Checked = .secureChannel

                adminPublicAddress.value = .publicAddress
                certificateClient.value = .clientCertificate

                useTrackLog.Checked = .useLog
                useEventRegistry.Checked = .useEventRegistry
                useCounter.Checked = .useRequestCounter
                useMessage.Checked = .useAdminMessage
                useProfile.Checked = .useProfile
                useAlert.Checked = .useAlert

                useAutoMaintenance.Checked = .useAutomaintenance
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
            Dim engine As New CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine
            Dim decodeData As Boolean = False
            Dim errorReading As Boolean = False
            Dim data As SettingsSidechainServiceComplete

            Do While Not decodeData And Not errorReading
                engine.dataPath = dataPath.Text
                engine.serviceName = sidechainServiceName.Text
                engine.password = _Password

                Select Case engine.read()
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.ReadError
                        _Password = getPassword()
                        _Data = New SettingsSidechainServiceComplete

                        If (_Password.CompareTo("(cancelMe)") = 0) Then
                            Return False
                        End If
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.fileNotFound
                        data = New SettingsSidechainServiceComplete
                        _Data = New SettingsSidechainServiceComplete

                        Return True
                    Case CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.Successfull
                        openAsFileButton.Enabled = True

                        _Data = engine.data

                        Return fillAllField()
                End Select
            Loop

            Return False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to get the information from the interface
    ''' </summary>
    ''' <returns></returns>
    Private Function getDataModel() As SettingsSidechainServiceComplete
        Dim data As New SettingsSidechainServiceComplete
        Try
            With data
                Select Case sidechainServiceName.SelectedIndex
                    Case 0 : .sideChainName = "Local Work Machine"
                    Case 1 : .sideChainName = "Sidechain Service"
                    Case 2 : .sideChainName = "Primary"
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
                .useLog = useTrackLog.Checked
                .useAutomaintenance = useAutoMaintenance.Checked
                .useEventRegistry = useEventRegistry.Checked
                .useRequestCounter = useCounter.Checked
                .useAdminMessage = useMessage.Checked
                .useProfile = useProfile.Checked
                .useAlert = useAlert.Checked
            End With

            data.logSettings = _Data.logSettings
            data.autoMaintenance = _Data.autoMaintenance

            Return data
        Catch ex As Exception
            MessageBox.Show("Problem during assign the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return New SettingsSidechainServiceComplete
        End Try
    End Function

    ''' <summary>
    ''' This method provide to save a data
    ''' </summary>
    ''' <returns></returns>
    Private Function saveData() As Boolean
        Try
            Dim engine As New CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine
            Dim data As SettingsSidechainServiceComplete = getDataModel()

            engine.dataPath = dataPath.Text
            engine.serviceName = sidechainServiceName.Text
            engine.password = getPassword()

            If (_Password.CompareTo("(cancelMe)") = 0) Then
                Return False
            End If

            engine.data = data

            If engine.write() Then
                Return True
            Else
                MessageBox.Show("Problem during save data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
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
        serviceMode.SelectedIndex = -1
        intranetMode.Checked = False

        staticIPAddress.Text = ""
        pathBase.Text = ""
        serviceID.Text = ""
        selectPublicPort.value = 0
        selectServicePort.value = 0
        secureChannel.Checked = False

        adminPublicAddress.value = ""
        certificateClient.value = ""

        useTrackLog.Checked = False
        useEventRegistry.Checked = False
        useCounter.Checked = False
        useMessage.Checked = False
        useProfile.Checked = False
        useAlert.Checked = False
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

            If (sidechainServiceName.Text.Length = 0) Then
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
        _DuringReadData = True

        entireLoad(False)

        fromRemoteButton.Enabled = True
        toRemoteButton.Enabled = True
        openAsFileButton.Enabled = True

        _DuringReadData = False
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
        If (serviceMode.SelectedIndex = -1) Then
            MessageBox.Show("The service mode is not define", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 0
            serviceMode.Select()

            Return False
        End If
        If (adminPublicAddress.value.Trim.Length = 0) And adminPublicAddress.Enabled Then
            MessageBox.Show("The Admin wallet address is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 2
            adminPublicAddress.Select()

            Return False
        End If
        If certificateClient.Enabled And (certificateClient.value.Trim.Length = 0) Then
            MessageBox.Show("The Certificate is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 2
            certificateClient.Select()

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
            completeFileName = IO.Path.Combine(completeFileName, sidechainServiceName.Text.Replace(" ", "") & ".Settings")

            Shell("notepad.exe " & completeFileName, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show("An error occurrent during openAsFileButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub infoButton_Click(sender As Object, e As EventArgs) Handles infoButton.Click
        informations.ShowDialog()
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
        Catch exFile As system.io.FileLoadException
            IntegrityApplication.executeRepairNewton(exFile.FileName)

            Return False
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
            Dim remote As New ProxyWS(Of SettingsSidechainServiceComplete)
            Dim proceed As Boolean = True

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
                _Data = remote.data.value
            End If
            If proceed Then
                proceed = fillAllField()
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

    Private Sub useTrackLog_CheckedChanged(sender As Object, e As EventArgs) Handles useTrackLog.CheckedChanged
        If useTrackLog.Checked Then
            settingsTrack.Enabled = True

            If _DuringReadData Then Return

            _Data.autoMaintenance.trackLogRotateConfig.keepFile = CHCModelsLibrary.AreaModel.Log.LogRotateConfig.KeepFileEnum.undefined
            _Data.autoMaintenance.trackLogRotateConfig.keepLast = CHCModelsLibrary.AreaModel.Log.KeepEnum.undefined
        Else
            settingsTrack.Enabled = False

            _Data.logSettings = New SettingsLogSidechainService
        End If
    End Sub

    Private Sub settingsTrack_Click(sender As Object, e As EventArgs) Handles settingsTrack.Click
        Dim settingPage As New trackLogSettings

        Select Case _Data.logSettings.trackConfiguration
            Case CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackOnlyBootstrapAndError : settingPage.trackConfiguration.SelectedIndex = 0
            Case CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackAll : settingPage.trackConfiguration.SelectedIndex = 1
        End Select

        settingPage.useBufferToWrite.Checked = _Data.logSettings.useBufferToWrite
        settingPage.writeToFile.Checked = _Data.logSettings.writeToFile
        settingPage.everyChangeFile.Text = _Data.logSettings.changeLogFileMaxNumHours
        settingPage.numberRegistrations.Text = _Data.logSettings.changeLogFileNumRegistrations

        If (settingPage.ShowDialog() = DialogResult.OK) Then
            Select Case settingPage.trackConfiguration.SelectedIndex
                Case 0 : _Data.logSettings.trackConfiguration = CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackOnlyBootstrapAndError
                Case 1 : _Data.logSettings.trackConfiguration = CHCModelsLibrary.AreaModel.Log.TrackRuntimeModeEnum.trackAll
            End Select

            _Data.logSettings.useBufferToWrite = settingPage.useBufferToWrite.Checked
            _Data.logSettings.writeToFile = settingPage.writeToFile.Checked
            If IsNumeric(settingPage.everyChangeFile.Text) Then
                _Data.logSettings.changeLogFileMaxNumHours = settingPage.everyChangeFile.Text
            Else
                _Data.logSettings.changeLogFileMaxNumHours = 0
            End If
            If IsNumeric(settingPage.numberRegistrations.Text) Then
                _Data.logSettings.changeLogFileNumRegistrations = settingPage.numberRegistrations.Text
            Else
                _Data.logSettings.changeLogFileNumRegistrations = 0
            End If
        End If

        settingPage.Close()

        settingPage = Nothing
    End Sub

    Private Sub sidechainServiceName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sidechainServiceName.SelectedIndexChanged
        resetAllField()
        disableForm()

        saveButton.Enabled = False
        openAsFileButton.Enabled = False
    End Sub

    Private Sub useAutoMaintenance_CheckedChanged_1(sender As Object, e As EventArgs) Handles useAutoMaintenance.CheckedChanged
        settingAutomMaintenanceButton.Enabled = useAutoMaintenance.Checked

        If Not useAutoMaintenance.Checked Then
            If _DuringReadData Then Return

            _Data.autoMaintenance.autoMaintenanceFrequencyHours = 0
            _Data.autoMaintenance.trackLogRotateConfig.keepFile = CHCModelsLibrary.AreaModel.Log.LogRotateConfig.KeepFileEnum.undefined
            _Data.autoMaintenance.trackLogRotateConfig.keepLast = CHCModelsLibrary.AreaModel.Log.KeepEnum.undefined
        End If
    End Sub

    Private Sub settingAutomMaintenanceButton_Click(sender As Object, e As EventArgs) Handles settingAutomMaintenanceButton.Click
        If _DuringReadData Then Return

        Dim autoMaintenance As New AutoMaintenanceSettings

        autoMaintenance.everyChangeFile.Text = _Data.autoMaintenance.autoMaintenanceFrequencyHours

        autoMaintenance.keepFileLabel.Enabled = _Data.useLog
        autoMaintenance.keepFile.Enabled = _Data.useLog
        autoMaintenance.keepLastLabel.Enabled = _Data.useLog
        autoMaintenance.keepLast.Enabled = _Data.useLog

        autoMaintenance.keepFile.SelectedIndex = _Data.autoMaintenance.trackLogRotateConfig.keepFile
        autoMaintenance.keepLast.SelectedIndex = _Data.autoMaintenance.trackLogRotateConfig.keepLast

        If autoMaintenance.ShowDialog = DialogResult.OK Then
            _Data.autoMaintenance.autoMaintenanceFrequencyHours = autoMaintenance.everyChangeFile.Text
            _Data.autoMaintenance.trackLogRotateConfig.keepFile = autoMaintenance.keepFile.SelectedIndex
            _Data.autoMaintenance.trackLogRotateConfig.keepLast = autoMaintenance.keepLast.SelectedIndex
        End If

    End Sub

End Class
