Option Compare Text
Option Explicit On
Imports System.ComponentModel

Public Class Main


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

    Private Sub showSettings()

        With AreaCommon.settings.data

            localPathData.Text = .dataPath

            If .useSecureAddress Then

                protocol.SelectedIndex = 1

            Else

                protocol.SelectedIndex = 0

            End If

            masternodeAdminUrl.Text = .urlMasternodeAdmin
            certificateMasternodeAdmin.Text = .certificateMasternodeAdmin

        End With

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If AreaCommon.StartUp.main() Then

                showSettings()

            Else

                End

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub loadDataIntoSettings()

        Try

            With AreaCommon.settings.data

                .dataPath = localPathData.Text
                .useSecureAddress = (protocol.SelectedIndex > 0)
                .urlMasternodeAdmin = masternodeAdminUrl.Text
                .certificateMasternodeAdmin = certificateMasternodeAdmin.Text

            End With

        Catch ex As Exception

            MessageBox.Show("An error occurrent during loadDataIntoSettings " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function verifyParameter() As Boolean

        If (localPathData.Text.ToString.Trim.Length() = 0) Then

            Return False

        End If

        Return True

    End Function

    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Try

            If verifyParameter() Then

                loadDataIntoSettings()

                AreaCommon.settings.save()

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during Main_Closing " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub localPathData_TextChanged(sender As Object, e As EventArgs) Handles localPathData.TextChanged

        Try

            If IO.Directory.Exists(localPathData.Text) Then

                If (AreaCommon.paths.pathBaseData.Length = 0) Then

                    AreaCommon.paths.pathBaseData = localPathData.Text

                    If AreaCommon.startApplication() Then

                        showSettings()

                        AreaCommon.paths.updateRootPath(AreaCommon.paths.pathBaseData)

                        AreaCommon.settings.save()

                    End If

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during localPathData_TextChanged " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub testButton_Click(sender As Object, e As EventArgs) Handles testButton.Click

        If (masternodeAdminUrl.Text.ToString.Trim.Length > 0) Then

            Try

                Dim handShakeEngine As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of AreaCommon.Models.General.BooleanModel)

                If (protocol.SelectedIndex = 0) Then

                    handShakeEngine.url = "http://"

                Else

                    handShakeEngine.url = "https://"

                End If

                handShakeEngine.url += masternodeAdminUrl.Text & "/api/v1.0/system/testService"

                If (handShakeEngine.getData() = "") Then

                    If handShakeEngine.data.value Then

                        MessageBox.Show("Test connection succesful", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Else

                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

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

                certificateMasternodeAdmin.Text = My.Computer.FileSystem.ReadAllText(openFileDialog.FileName)

            End If

        Catch ex As Exception

            MessageBox.Show("An error occurrent during certificateMasternodeBrowserButton_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Function createSignature(ByVal privateKey As String, ByVal newCertificate As String) As String

        Try

            Dim privateRaw As String = ""

            If privateKey.StartsWith(CHCProtocol.AreaWallet.Support.WalletAddressEngine.basePvt) Then

                With CHCProtocol.AreaWallet.Support.WalletAddressEngine.createNew(privateKey)

                    privateRaw = .raw.privateKey

                End With

            End If

            Return CHCEngine.Encryption.Base58Signature.getSignature(privateRaw, newCertificate)

        Catch ex As Exception

            Return ""

        End Try

    End Function



    Private Sub changeButton_Click(sender As Object, e As EventArgs) Handles changeButton.Click

        Try

            Dim change As New ChangeCertificate

            If (change.ShowDialog() = DialogResult.OK) Then

                Dim url As String = ""
                Dim changeData As New AreaCommon.Models.Security.changeCertificate
                Dim webSender As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of AreaCommon.Models.Security.changeCertificate)

                changeData.currentCertificate = certificateMasternodeAdmin.Text
                changeData.newCertificate = change.certificate
                changeData.typeCommunication = AreaCommon.Models.Security.enumOfService.client

                changeData.signature = CHCProtocol.AreaWallet.Support.WalletAddressEngine.createSignature(change.privateKey, change.certificate)

                If protocol.SelectedIndex = 0 Then

                    url = "http://"

                Else

                    url = "https://"

                End If

                url += masternodeAdminUrl.Text & "/api/v1.0/security/changeCertificate"

                webSender.url = url

                webSender.data = changeData

                If (webSender.sendData("PUT") = "") Then

                    MessageBox.Show("Certificate Upgrade", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    certificateMasternodeAdmin.Text = change.certificate

                Else

                    MessageBox.Show("Error during update data")

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("Error during a changeButton_Click", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub refreshGeneralButton_Click(sender As Object, e As EventArgs) Handles refreshGeneralButton.Click

        If (masternodeAdminUrl.Text.ToString.Trim.Length > 0) Then

            Try

                Dim remote As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of AreaCommon.Models.Masternode.InfoMasternodeModel)
                Dim rt As DateTime = Now

                If (protocol.SelectedIndex = 0) Then

                    remote.url = "http://"

                Else

                    remote.url = "https://"

                End If

                remote.url += masternodeAdminUrl.Text & "/api/v1.0/system/infoMasternode/?certificate=" & certificateMasternodeAdmin.Text

                If (remote.getData() = "") Then

                    If Not remote.data.response.error Then

                        currentStatusValue.Text = remote.data.currentStatus
                        virtualNameValue.Text = remote.data.virtualName
                        masternodeLocalTime.Text = remote.data.masternodeLocalTime
                        walletAddress.Text = remote.data.publicWalletAddress
                        serviceOffered.Text = remote.data.serviceOffered
                        platformValue.Text = remote.data.platformHost
                        softwareRelease.Text = remote.data.softwareRelease
                        protocolReleaseValue.Text = remote.data.protocolRelease
                        addressValue.Text = remote.data.ipAddress
                        requestTime.Text = rt
                        responseTime.Text = Now

                    Else

                        MessageBox.Show("Masternode is offline", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Else

                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Catch ex As Exception

                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub

    Private Sub masternodeAdminUrl_TextChanged(sender As Object, e As EventArgs) Handles masternodeAdminUrl.TextChanged

        testButton.Enabled = (masternodeAdminUrl.Text.Trim.ToString.Length > 0)
        refreshGeneralButton.Enabled = testButton.Enabled
        refreshDataNetwork.Enabled = testButton.Enabled

    End Sub

    Private Sub refreshDataNetwork_Click(sender As Object, e As EventArgs) Handles refreshDataNetwork.Click

        If (masternodeAdminUrl.Text.ToString.Trim.Length > 0) Then

            Try

                Dim remote As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of AreaCommon.Models.Network.InfoNetworkModel)
                Dim rt As DateTime = Now

                If (protocol.SelectedIndex = 0) Then

                    remote.url = "http://"

                Else

                    remote.url = "https://"

                End If

                remote.url += masternodeAdminUrl.Text & "/api/v1.0/network/status/?certificate=" & AreaCommon.settings.data.certificateMasternodeAdmin

                If (remote.getData() = "") Then

                    With remote.data

                        If Not .response.error Then

                            Select Case .currentStatus

                                Case AreaCommon.Models.Network.InfoNetworkModel.EnumNetworkStatus.off : networkStatusValue.Text = "Offline"
                                Case AreaCommon.Models.Network.InfoNetworkModel.EnumNetworkStatus.prepareToConnect : networkStatusValue.Text = "Prepare to connect"
                                Case AreaCommon.Models.Network.InfoNetworkModel.EnumNetworkStatus.inConnection : networkStatusValue.Text = "In connection"
                                Case AreaCommon.Models.Network.InfoNetworkModel.EnumNetworkStatus.connected : networkStatusValue.Text = "Connect"
                                Case AreaCommon.Models.Network.InfoNetworkModel.EnumNetworkStatus.duringDisconnected : networkStatusValue.Text = "During disconnect"

                            End Select

                            transactionChainNameValue.Text = .transactionChainName
                            networkProtocolReleaseValue.Text = .protocolRelease

                            requestNetworkTimeValue.Text = rt
                            responseNetworkTimeValue.Text = Now

                        Else

                            MessageBox.Show("Masternode is offline", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If

                    End With

                Else

                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Catch ex As Exception

                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub


End Class
