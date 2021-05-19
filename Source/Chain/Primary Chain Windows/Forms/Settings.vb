Option Compare Text
Option Explicit On

Imports CHCServerSupportLibrary.Support
Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Communication





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

                writeLogFile.Checked = (.useTrack <> LogEngine.TrackRuntimeModeEnum.dontTrack)
                useEventRegistry.Checked = .useEventRegistry

                masternodeAdminUrl.Text = .urlMasternodeAdmin
                certificateMasternodeAdmin.Text = .certificateMasternodeAdmin

                masternodeStartURL.Text = .urlMasternodeStart
                certificateMasternodeStarter.Text = .certificateMasternodeStart

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








    Private Sub loadDataIntoSettings()

        Dim item As AreaChain.NodesEngine.NodeInformation.configurationPort
        Try

            With AreaCommon.settings.data

                .certificateMasternodeAdmin = certificateMasternodeAdmin.Text
                .certificateMasternodeStart = certificateMasternodeStarter.Text
                .dataPath = dataPath.Text
                .intranetMode = intranetMode.Checked
                .noUpdateSystemDate = noUpdateSystemDate.Checked

                .services.Clear()

                .urlMasternodeAdmin = masternodeAdminUrl.Text
                .urlMasternodeStart = masternodeStartURL.Text

                .useEventRegistry = useEventRegistry.Checked

                If writeLogFile.Checked Then
                    .useTrack = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
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

                Dim handShakeEngine As New ProxyWS(Of General.BooleanModel)

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

                Dim handShakeEngine As New ProxyWS(Of General.BooleanModel)

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

        Return True

    End Function


    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

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


End Class