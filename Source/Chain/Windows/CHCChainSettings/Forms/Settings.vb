Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML


Public Class Settings

    Private _ParameterExist As Boolean = False


    ''' <summary>
    ''' This method provide to test if the user indicate the parameter in the command line
    ''' </summary>
    ''' <returns></returns>
    Private Function haveParameters() As Boolean
        Try
            Dim commandManager As New AreaCommon.CommandProcessor

            commandManager.command = (New AreaCommon.CommandLineDecoder).run()

            If commandManager.execute() Then

                Select Case commandManager.command.parameterValue("chain")
                    Case "primary" : chainServiceName.SelectedIndex = 0
                End Select

                dataPath.Text = commandManager.command.parameterValue("dataPath")

                _ParameterExist = True

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If haveParameters() Then
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
        networkNameLabel.Enabled = True
        networkName.Enabled = True
        serviceID.Enabled = True
        serviceUUID.Enabled = True
        adminPublicAddress.Enabled = True
        certificateClient.Enabled = True
        selectPublicPort.Enabled = True
        selectServicePort.Enabled = True
        intranetMode.Enabled = True
        secureChannel.Enabled = True
        logInformations.Enabled = True
        useEventRegistry.Enabled = True
        useCounter.Enabled = True

        saveButton.Enabled = True
    End Sub

    ''' <summary>
    ''' This method provide to load data from a data path
    ''' </summary>
    ''' <returns></returns>
    Private Function loadData() As Boolean
        Try
            Dim completeFileName As String = ""

            completeFileName = IO.Path.Combine(dataPath.Text, "Settings")
            completeFileName = IO.Path.Combine(completeFileName, chainServiceName.Text & ".Settings")

            If Not IO.File.Exists(completeFileName) Then Return False

            With IOFast(Of CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainRuntime).read(completeFileName)
                networkName.Text = .networkReferement
                serviceID.Text = .serviceID
                adminPublicAddress.value = .publicAddress
                certificateClient.value = .clientCertificate
                selectPublicPort.value = .publicPort
                selectServicePort.value = .servicePort
                intranetMode.Checked = .intranetMode
                secureChannel.Checked = .secureChannel

                logInformations.trackConfiguration = .trackConfiguration
                logInformations.maxNumHours = .logFileMaxNumHours
                logInformations.maxNumberOfRegistrations = .logFileNumRegistrations
                logInformations.useTrackRotate = .useTrackRotate

                If .useTrackRotate Then
                    logInformations.trackRotateFrequency = .trackRotateConfig.frequency
                    logInformations.trackRotateKeepFile = .trackRotateConfig.keepFile
                    logInformations.trackRotateKeepLast = .trackRotateConfig.keepLast
                End If

                useEventRegistry.Checked = .useEventRegistry
                useCounter.Checked = .useRequestCounter
            End With

            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to save a data
    ''' </summary>
    ''' <returns></returns>
    Private Function saveData() As Boolean
        Try
            Dim completeFileName As String = ""
            Dim data As New CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainRuntime

            completeFileName = IO.Path.Combine(dataPath.Text, "Settings")
            completeFileName = IO.Path.Combine(completeFileName, chainServiceName.Text & ".Settings")

            With data
                Select Case chainServiceName.SelectedIndex
                    Case 0 : .chainName = "Primary"
                End Select

                .networkReferement = networkName.Text
                .serviceID = serviceID.Text
                .publicAddress = adminPublicAddress.value
                .clientCertificate = certificateClient.value
                .publicPort = selectPublicPort.value
                .servicePort = selectServicePort.value
                .intranetMode = intranetMode.Checked
                .secureChannel = secureChannel.Checked

                .trackConfiguration = logInformations.trackConfiguration
                .logFileMaxNumHours = logInformations.maxNumHours
                .logFileNumRegistrations = logInformations.maxNumberOfRegistrations
                .useTrackRotate = logInformations.useTrackRotate

                If logInformations.useTrackRotate Then
                    .trackRotateConfig.frequency = logInformations.trackRotateFrequency
                    .trackRotateConfig.keepFile = logInformations.trackRotateKeepFile
                    .trackRotateConfig.keepLast = logInformations.trackRotateKeepLast
                End If

                .useEventRegistry = useEventRegistry.Checked
                .useRequestCounter = useCounter.Checked
            End With

            Return IOFast(Of CHCChainServiceLibrary.AreaChain.Runtime.Models.SettingsChainRuntime).save(completeFileName, data)
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
            End If

            adminPublicAddress.dataPath = paths.pathKeystore

            networkName.Select()

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

            tabControl.SelectedIndex = 0
            adminPublicAddress.Select()

            Return False
        End If
        If (certificateClient.value.Trim.Length = 0) Then
            MessageBox.Show("The Certificate is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 0
            certificateClient.Select()

            Return False
        End If
        If (selectPublicPort.value = 0) Then
            MessageBox.Show("The Public port is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 0
            selectPublicPort.Select()

            Return False
        End If
        If (selectServicePort.value = 0) Then
            MessageBox.Show("The Service port is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            tabControl.SelectedIndex = 0
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

                MessageBox.Show("Configuration saved", "Information")

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

End Class
