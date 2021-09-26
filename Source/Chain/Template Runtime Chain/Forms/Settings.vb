Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaBase




Public Class Settings


    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With AreaCommon.settings.data
                If (.networkName.Trim().Length = 0) Then
                    networkName.Text = AreaCommon.state.internalInformation.networkName
                Else
                    networkName.Text = .networkName
                End If

                chainName.Text = AreaCommon.state.internalInformation.chainName

                intranetMode.Checked = .intranetMode
                noUpdateSystemDate.Checked = .noUpdateSystemDate

                dataPath.Text = .dataPath
                adminWalletAddress.value = .walletAddress

                serviceIDText.Text = .serviceId

                selectPublicPort.value = .publicPort
                selectServicePort.value = .servicePort

                certificateClient.value = .clientCertificate

                logConfiguration.useTrackRotate = .useTrackRotate

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

                .intranetMode = intranetMode.Checked
                .noUpdateSystemDate = noUpdateSystemDate.Checked

                .dataPath = dataPath.Text
                .walletAddress = adminWalletAddress.value

                .serviceId = serviceIDText.Text

                .publicPort = selectPublicPort.value
                .servicePort = selectServicePort.value

                .clientCertificate = certificateClient.value

                .useTrackRotate = logConfiguration.useTrackRotate

                .useEventRegistry = useEventRegistry.Checked
            End With
        Catch ex As Exception
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


    Private Function portMissing(ByRef portValue As TextBox, ByVal fieldName As String) As Boolean
        If Not IsNumeric(portValue.Text) Then
            MessageBox.Show("The " & fieldName & " port must be a number", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return True
        End If

        Return False
    End Function


    Private Function verifyParameter() As Boolean
        Try
            If fieldValueMissing(dataPath, "local data path") Then
                Return False
            End If
            If fieldValueMissing(serviceIDText, "Service ID") Then
                Return False
            End If
            If Not IO.Directory.Exists(dataPath.Text) Then
                MessageBox.Show("The local path entered is incorrect", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
            If (adminWalletAddress.value.ToString.Trim.Length() = 0) Then
                MessageBox.Show("The '" & Name & "' is missing.", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
            If Not selectPublicPort.checkValue() Then
                Return False
            End If
            If Not selectServicePort.checkValue() Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
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

    Private Sub adminWalletAddress_Load(sender As Object, e As EventArgs) Handles adminWalletAddress.Load

    End Sub

    Private Sub certificateClient_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub publicPortNumber_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dataPath_TextChanged(sender As Object, e As EventArgs) Handles dataPath.TextChanged
        If IO.Directory.Exists(dataPath.Text) Then
            adminWalletAddress.dataPath = dataPath.Text
        End If
    End Sub

End Class