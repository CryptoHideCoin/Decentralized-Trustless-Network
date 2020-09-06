Option Compare Text
Option Explicit On


Public Class Settings


    Private Function selectedIndexConfiguration(ByVal id As String) As Integer

        Return -1

    End Function

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            With AreaCommon.settings.data

                virtualName.Text = .virtualName
                intranetMode.Checked = .intranetMode
                noUpdateSystemDate.Checked = .noUpdateSystemDate
                dataPath.Text = .dataPath

                walletAddress.Text = .walletAddress
                walletKey.Text = .walletKey

                For Each item In .services

                    If (item.port.Trim.Length() > 0) Then

                        If IsNumeric(item.port) Then

                            If (item.port > 0) Then

                                Select Case item.type

                                    Case AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.dns

                                        dnsService.Checked = True
                                        dnsPort.Text = item.port

                                    Case AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.exChange

                                        exChangeService.Checked = True
                                        exChangePort.Text = item.port

                                    Case AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.file

                                        fileService.Checked = True
                                        filePort.Text = item.port

                                    Case AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.public

                                        publicService.Checked = True
                                        publicPort.Text = item.port

                                    Case AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.service

                                        chainService.Checked = True
                                        chainPort.Text = item.port

                                    Case AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.vote

                                        voteService.Checked = True
                                        voteServicePort.Text = item.port

                                End Select

                            End If

                        End If

                    End If

                Next

                writeLogFile.Checked = (.useTrack <> AppSettings.TrackRuntimeModeEnum.dontTrack)
                useEventRegistry.Checked = .useEventRegistry

                masternodeAdminUrl.Text = .urlMasternodeAdmin
                certificateMasternodeAdmin.Text = .certificateMasternodeAdmin

                masternodeStartURL.Text = .urlMasternodeStart
                certificateMasternodeStarter.Text = .certificateMasternodeStart

                autoStart.Checked = .autoStart

                chainConfiguration.SelectedIndex = selectedIndexConfiguration(.transactionChainConfig)

            End With

        Catch ex As Exception

            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub manageEnableCheck(ByRef objectCheck As CheckBox, ByRef objectText As TextBox)

        If objectCheck.Checked Then

            objectText.Enabled = True

        Else

            objectText.Enabled = False
            objectText.Text = ""

        End If

    End Sub

    Private Sub publicService_CheckedChanged(sender As Object, e As EventArgs) Handles publicService.CheckedChanged

        manageEnableCheck(publicService, publicPort)

    End Sub

    Private Sub chainService_CheckedChanged(sender As Object, e As EventArgs) Handles chainService.CheckedChanged

        manageEnableCheck(chainService, chainPort)

    End Sub

    Private Sub fileService_CheckedChanged(sender As Object, e As EventArgs) Handles fileService.CheckedChanged

        manageEnableCheck(fileService, filePort)

    End Sub

    Private Sub dnsService_CheckedChanged(sender As Object, e As EventArgs) Handles dnsService.CheckedChanged

        manageEnableCheck(dnsService, dnsPort)

    End Sub

    Private Sub exChangeService_CheckedChanged(sender As Object, e As EventArgs) Handles exChangeService.CheckedChanged

        manageEnableCheck(exChangeService, exChangePort)

    End Sub

    Private Sub loadDataIntoSettings()

        Dim item As AreaChain.NodesEngine.NodeInformation.configurationPort
        Try

            With AreaCommon.settings.data

                .autoStart = autoStart.Checked
                .certificateMasternodeAdmin = certificateMasternodeAdmin.Text
                .certificateMasternodeStart = certificateMasternodeStarter.Text
                .dataPath = dataPath.Text
                .intranetMode = intranetMode.Checked
                .noUpdateSystemDate = noUpdateSystemDate.Checked

                If publicService.Checked Then

                    If IsNumeric(publicPort.Text) Then

                        item = New AreaChain.NodesEngine.NodeInformation.configurationPort

                        item.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.public
                        item.port = publicPort.Text

                        .services.Add(item)

                    End If

                End If
                If chainService.Checked Then

                    If IsNumeric(chainPort.Text) Then

                        item = New AreaChain.NodesEngine.NodeInformation.configurationPort

                        item.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.service
                        item.port = chainPort.Text

                        .services.Add(item)

                    End If

                End If
                If fileService.Checked Then

                    If IsNumeric(filePort.Text) Then

                        item = New AreaChain.NodesEngine.NodeInformation.configurationPort

                        item.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.file
                        item.port = filePort.Text

                        .services.Add(item)

                    End If

                End If
                If dnsService.Checked Then

                    If IsNumeric(dnsPort.Text) Then

                        item = New AreaChain.NodesEngine.NodeInformation.configurationPort

                        item.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.dns
                        item.port = dnsPort.Text

                        .services.Add(item)

                    End If

                End If
                If exChangeService.Checked Then

                    If IsNumeric(exChangePort.Text) Then

                        item = New AreaChain.NodesEngine.NodeInformation.configurationPort

                        item.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.exChange
                        item.port = exChangePort.Text

                        .services.Add(item)

                    End If

                End If
                If voteService.Checked Then

                    If IsNumeric(voteServicePort.Text) Then

                        item = New AreaChain.NodesEngine.NodeInformation.configurationPort

                        item.type = AreaChain.NodesEngine.NodeInformation.EnumPeerServiceType.vote
                        item.port = voteServicePort.Text

                        .services.Add(item)

                    End If

                End If

                '.transactionChainConfig = chainConfiguration.SelectedValue
                .transactionChainConfig = ""
                .urlMasternodeAdmin = masternodeAdminUrl.Text
                .urlMasternodeStart = masternodeStartURL.Text

                .useEventRegistry = useEventRegistry.Checked

                If writeLogFile.Checked Then
                    .useTrack = AppSettings.TrackRuntimeModeEnum.trackAllRuntime
                End If
                .virtualName = virtualName.Text
                .walletAddress = walletAddress.Text
                .walletKey = walletKey.Text

            End With

        Catch ex As Exception

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

        If (masternodeStartURL.Text.ToString.Trim.Length > 0) Then

            Try

                Dim handShakeEngine As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.BooleanModel)

                handShakeEngine.url = "http://" & masternodeStartURL.Text & "/api/v1.0/system/testService"

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

                certificateMasternodeStarter.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during certificateMasternodeRuntimeBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

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


    Private Function portMissing(ByRef field As CheckBox, ByRef portValue As TextBox) As Boolean

        If field.Checked Then

            If Not IsNumeric(portValue.Text) Then

                MessageBox.Show("Specify a " & field.Text & " port", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True

            End If

        End If

        Return False

    End Function


    Private Function verifyParameter() As Boolean

        If fieldValueMissing(virtualName, "virtual name") Then Return False
        If fieldValueMissing(dataPath, "local data path") Then Return False
        If fieldValueMissing(walletAddress, "wallet address") Then Return False
        If fieldValueMissing(walletKey, "wallet private key") Then Return False
        If fieldValueMissing(certificateMasternodeAdmin, "masternode certificate administration") Then Return False
        If fieldValueMissing(certificateMasternodeStarter, "masternode certificate starter") Then Return False

        If Not IO.Directory.Exists(dataPath.Text) Then

            MessageBox.Show("The local path entered is incorrect", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (chainConfiguration.SelectedIndex = 0) Then

            MessageBox.Show("The transaction chain configuration is not select.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If Not publicService.Checked And Not chainService.Checked And Not fileService.Checked And Not dnsService.Checked And Not exChangeService.Checked And Not voteService.Checked Then

            MessageBox.Show("Select one ore more services", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If portMissing(publicService, publicPort) Then Return False
        If portMissing(chainService, chainPort) Then Return False
        If portMissing(fileService, filePort) Then Return False
        If portMissing(dnsService, dnsPort) Then Return False
        If portMissing(exChangeService, exChangePort) Then Return False
        If portMissing(voteService, voteServicePort) Then Return False

        Return True

    End Function


    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

        If verifyParameter() Then

            loadDataIntoSettings()

            If (AreaCommon.paths.pathBaseData.Trim.Length() = 0) Then

                AreaCommon.paths.pathBaseData = dataPath.Text

                AreaCommon.paths.init()

                AreaCommon.settings.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, AreaCommon.paths.settingFileName)

            End If

            AreaCommon.paths.updateRootPath(dataPath.Text)

            AreaCommon.settings.save()

            Me.Close()

        End If

    End Sub

    Private Sub voteService_CheckedChanged(sender As Object, e As EventArgs) Handles voteService.CheckedChanged

        manageEnableCheck(voteService, voteServicePort)

    End Sub


End Class