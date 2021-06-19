﻿Option Compare Text
Option Explicit On

Imports System.ComponentModel
Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCCommonLibrary.AreaEngine.Communication




Public Class Main

    Public Class SingleConfiguration

        Public Property text As String
        Public Property value As String


        Public Sub New(ByVal text As String, ByVal value As String)
            Me.text = text
            Me.value = value
        End Sub

    End Class

    Public Class SingleConfigurationDB
        Public Property uuid As String = ""
        Public Property name As String = ""
    End Class

    Public Class ConfigurationManager
        Inherits CHCCommonLibrary.AreaEngine.DataFileManagement.BaseFileDB(Of List(Of SingleConfigurationDB))
    End Class


    Private _Configurations As New ConfigurationManager
    Private _NoWorkList As Boolean = False
    Private _SystemActive As Boolean = False





    Private Sub browseLocalPath_Click(sender As Object, e As EventArgs) Handles browseLocalPathButton.Click
        Try
            Dim path As String = localPathDataText.Text

            Dim dirName As String

            If (path.Trim().Length > 0) Then
                dirName = IO.Path.GetDirectoryName(localPathDataText.Text)
            Else
                dirName = ""
            End If

            Dim fileName As String = IO.Path.GetFileName(localPathDataText.Text)

            folderBrowserDialog.SelectedPath = dirName

            If (folderBrowserDialog.ShowDialog() = DialogResult.OK) Then
                localPathDataText.Text = folderBrowserDialog.SelectedPath
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during browseLocalPath_Click " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub showSettings()
        With AreaCommon.settings.data
            localPathDataText.Text = .dataPath

            _NoWorkList = True

            For Each item In _Configurations.data
                configurationNameCombo.Items.Add(New SingleConfiguration(item.name, item.uuid))
            Next

            _NoWorkList = False

            For Each item In configurationNameCombo.Items
                If item.value = .currentConfiguration Then
                    configurationNameCombo.SelectedItem = item
                End If
            Next

            serviceIDText.Text = .serviceId
            serviceUrlProtocol.useSecure = .useSecureProtocol
            serviceUrlProtocol.address = .urlNodeServiceAdmin

            serviceCertificate.value = .certificateServiceAdmin
            serviceCertificate.urlService = serviceUrlProtocol.baseUrlComplete
            serviceCertificate.dataPath = .dataPath
            serviceCertificate.serviceId = .serviceId

            adminWalletAddress.value = .serviceWalletAddressAdmin
        End With
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If AreaCommon.StartUp.main() Then
                serviceIDText.Text = ""

                showSettings()
            Else
                End
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub loadDataIntoSettings(ByRef engine As AppSettings)
        Try
            With engine.data
                .dataPath = localPathDataText.Text

                If Not IsNothing(configurationNameCombo.SelectedItem) Then
                    .currentConfiguration = configurationNameCombo.SelectedItem.value
                Else
                    .currentConfiguration = ""
                End If
                .serviceId = serviceIDText.Text
                .serviceWalletAddressAdmin = adminWalletAddress.value
                .useSecureProtocol = serviceUrlProtocol.useSecure
                .urlNodeServiceAdmin = serviceUrlProtocol.address
                .certificateServiceAdmin = serviceCertificate.value
            End With
        Catch ex As Exception
            MessageBox.Show("An error occurrent during loadDataIntoSettings " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function verifyParameter() As Boolean

        If (localPathDataText.Text.ToString.Trim.Length() = 0) Then
            Return False
        End If

        Return True

    End Function

    Private Function saveData() As Boolean
        If verifyParameter() Then
            loadDataIntoSettings(AreaCommon.settings)

            Return AreaCommon.settings.save()
        Else
            Return False
        End If
    End Function

    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            saveData()
        Catch ex As Exception
            MessageBox.Show("An error occurrent during Main_Closing " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub localPathData_TextChanged(sender As Object, e As EventArgs) Handles localPathDataText.TextChanged
        Try
            If IO.Directory.Exists(localPathDataText.Text) Then
                If (AreaCommon.paths.pathBaseData.Length = 0) Then
                    AreaCommon.paths.pathBaseData = localPathDataText.Text

                    If AreaCommon.startApplication() Then
                        showSettings()
                        AreaCommon.paths.updateRootPath(AreaCommon.paths.pathBaseData)
                        AreaCommon.settings.save()
                    End If
                Else
                    _Configurations.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, "Configurations.list")

                    _Configurations.read()

                    adminWalletAddress.dataPath = AreaCommon.paths.pathKeystore
                    serviceCertificate.dataPath = localPathDataText.Text
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during localPathData_TextChanged " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function createSignature(ByVal privateKey As String, ByVal newCertificate As String) As String
        Try
            Dim privateRaw As String = ""

            If privateKey.StartsWith(WalletAddressEngine.basePvt) Then

                With WalletAddressEngine.createNew(privateKey)
                    privateRaw = .raw.privateKey
                End With

            End If

            Return Encryption.Base58Signature.getSignature(privateRaw, newCertificate)
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Private Sub refreshGeneralButton_Click(sender As Object, e As EventArgs) Handles refreshInformationlButton.Click

        If (serviceUrlProtocol.baseUrlComplete.Trim.Length > 0) And
           (serviceCertificate.value.Trim.Length > 0) And
           (adminWalletAddress.value.Trim.Length > 0) Then
            Try
                Dim remote As New ProxyWS(Of AreaCommon.Models.ServiceModel.InformationResponseModel)
                Dim privateKeyValue As String = adminWalletAddress.privateKey

                If (privateKeyValue.Length = 0) Then
                    Return
                End If

                Dim signature As String = WalletAddressEngine.createSignature(privateKeyValue, serviceCertificate.value)

                remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/service/information/?signature=" & signature

                Dim rt As DateTime = Now

                If (remote.getData() = "") Then
                    If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                        walletAddressText.Text = remote.data.adminPublicAddress

                        Select Case remote.data.currentStatus
                            Case AreaCommon.Models.ServiceModel.InformationResponseModel.EnumInternalServiceState.notDefined : currentStatusText.Text = "Not defined"
                            Case AreaCommon.Models.ServiceModel.InformationResponseModel.EnumInternalServiceState.shutDown : currentStatusText.Text = "Shutdown"
                            Case AreaCommon.Models.ServiceModel.InformationResponseModel.EnumInternalServiceState.started : currentStatusText.Text = "Started"
                            Case AreaCommon.Models.ServiceModel.InformationResponseModel.EnumInternalServiceState.starting : currentStatusText.Text = "Starting"
                            Case AreaCommon.Models.ServiceModel.InformationResponseModel.EnumInternalServiceState.swithOff : currentStatusText.Text = "Switch off"
                            Case AreaCommon.Models.ServiceModel.InformationResponseModel.EnumInternalServiceState.waitToMaintenance : currentStatusText.Text = "Wait to maintenance"
                        End Select

                        chainNameText.Text = remote.data.chainName
                        platformHostText.Text = remote.data.platformHost
                        softwareReleaseText.Text = remote.data.softwareRelease
                        addressText.Text = remote.data.addressIP
                        requestTimeText.Text = rt.ToString()
                        responseTimeText.Text = remote.data.responseTime
                    ElseIf (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.systemOffline) Then
                        MessageBox.Show("Peer is offline", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.missingAuthorization) Then
                        MessageBox.Show("Unauthorize access", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Remote Error", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Select URL of service / Certificate / Admin Wallet Address", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub checkEnableButton()
        connectServiceButton.Enabled = (serviceUrlProtocol.address.Trim.ToString.Length > 0) And
                                       (serviceCertificate.value.Trim.ToString.Length > 0) And
                                       (adminWalletAddress.value.Trim.ToString.Length > 0)
    End Sub

    Private Sub masternodeAdminUrl_TextChanged(sender As Object, e As EventArgs)
        checkEnableButton()
    End Sub

    Private Sub refreshDataNetwork_Click(sender As Object, e As EventArgs) Handles refreshSupportedProtocols.Click

        If (serviceUrlProtocol.baseUrlComplete.Trim.Length > 0) Then
            Try
                Dim remote As New ProxyWS(Of AreaCommon.Models.ServiceModel.SupportedProtocolsResponseModel)

                remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/service/supportedProtocols"

                Dim rt As DateTime = Now

                If (remote.getData() = "") Then
                    If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                        protocolList.Text = String.Join(vbNewLine, remote.data.protocols)
                    ElseIf (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.systemOffline) Then
                        MessageBox.Show("Peer is offline", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.missingAuthorization) Then
                        MessageBox.Show("Unauthorize access", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Remote Error", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Select URL of service / Certificate / Admin Wallet Address", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Sub newConfigurationButton_Click(sender As Object, e As EventArgs) Handles newConfigurationButton.Click
        Try
            Dim value As String = InputBox("Enter name of a new configuration", "Request", "")
            Dim found As Boolean = False

            If (value.Length = 0) Then Return

            For Each item In configurationNameCombo.Items
                If (value.CompareTo(item.text) = 0) Then
                    found = True

                    MessageBox.Show("Name exist into collection", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit For
                End If
            Next

            If Not found Then
                Dim item As New SingleConfigurationDB

                item.uuid = Guid.NewGuid.ToString()
                item.name = value

                configurationNameCombo.Items.Add(New SingleConfiguration(value, item.UUID))

                configurationNameCombo.SelectedIndex = configurationNameCombo.Items.Count - 1

                _Configurations.data.Add(item)
            End If
        Catch ex As Exception
            MessageBox.Show("Error new configuration button - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveConfigurationButton_Click(sender As Object, e As EventArgs) Handles saveConfigurationButton.Click
        Try
            If Not IsNothing(configurationNameCombo.SelectedItem) Then
                Dim configuration As New AppSettings

                configuration.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, configurationNameCombo.SelectedItem.value & ".settings")

                loadDataIntoSettings(configuration)

                configuration.save()

                _Configurations.save()
            End If
        Catch ex As Exception
            MessageBox.Show("Error during saveConfigurationButton_Click - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub deleteConfigurationButton_Click(sender As Object, e As EventArgs) Handles deleteConfigurationButton.Click
        Try
            If Not IsNothing(configurationNameCombo.SelectedItem) Then
                If (MessageBox.Show("Do you want to delete the configuration '" & configurationNameCombo.SelectedItem.text & "' from a list ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                    Dim id As String = configurationNameCombo.SelectedItem.value

                    For Each item In _Configurations.data
                        If (item.uuid.CompareTo(configurationNameCombo.SelectedItem.value) = 0) Then
                            _Configurations.data.Remove(item)

                            Exit For
                        End If
                    Next

                    _Configurations.save()

                    configurationNameCombo.Items.Remove(configurationNameCombo.SelectedItem)

                    IO.File.Delete(IO.Path.Combine(AreaCommon.paths.pathSettings, id & ".settings"))

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error during deleteConfigurationButton_Click - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub configurationNameCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles configurationNameCombo.SelectedIndexChanged
        If Not _NoWorkList Then
            Try
                If Not IsNothing(configurationNameCombo.SelectedItem) Then
                    Dim configuration As New AppSettings

                    configuration.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, configurationNameCombo.SelectedItem.value & ".settings")

                    configuration.read()

                    Try
                        With configuration.data
                            adminWalletAddress.value = .serviceWalletAddressAdmin
                            serviceUrlProtocol.useSecure = .useSecureProtocol
                            serviceUrlProtocol.address = .urlNodeServiceAdmin
                            serviceCertificate.Text = .certificateServiceAdmin
                        End With
                    Catch ex As Exception
                        MessageBox.Show("An error occurrent during configurationNameCombo_SelectedIndexChanged " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show("Error during saveConfigurationButton_Click - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub serviceUrlProtocol_LockScreen() Handles serviceUrlProtocol.LockScreen
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
    End Sub

    Private Sub serviceUrlProtocol_UnLockScreen() Handles serviceUrlProtocol.UnLockScreen
        Me.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub serviceCertificate_Load(sender As Object, e As EventArgs) Handles serviceCertificate.Load

    End Sub

    Private Sub serviceUrlProtocol_TextChanged() Handles serviceUrlProtocol.TextChanged
        serviceCertificate.urlService = serviceUrlProtocol.baseUrlComplete
    End Sub

    Private Sub serviceCertificate_TextChanged() Handles serviceCertificate.TextChanged
        checkEnableButton()
    End Sub

    Private Sub adminWalletAddress_TextChanged() Handles adminWalletAddress.TextChanged
        checkEnableButton()
    End Sub

    Private Sub adminWalletAddress_ParentChanged(sender As Object, e As EventArgs) Handles adminWalletAddress.ParentChanged

    End Sub

    Private Sub serviceIDText_TextChanged(sender As Object, e As EventArgs) Handles serviceIDText.TextChanged
        serviceUrlProtocol.serviceId = serviceIDText.Text

        serviceCertificate.ServiceId = serviceIDText.Text
    End Sub

    Private Sub mainTab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mainTab.SelectedIndexChanged
        mainTab.TabPages(1).Enabled = _SystemActive
        mainTab.TabPages(2).Enabled = _SystemActive
    End Sub

    Private Sub connectServiceButton_Click(sender As Object, e As EventArgs) Handles connectServiceButton.Click
        If saveData() Then
            _SystemActive = serviceUrlProtocol.testServiceResponse()

            If Not _SystemActive Then
                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                mainTab.SelectedIndex = 1

                adminWalletAddress.dataPath = AreaCommon.paths.pathKeystore
            End If
        End If
    End Sub

    Private Sub serviceUrlProtocol_Load(sender As Object, e As EventArgs) Handles serviceUrlProtocol.Load

    End Sub

    Private Sub adminWalletAddress_Load(sender As Object, e As EventArgs) Handles adminWalletAddress.Load

    End Sub

    Private Sub serviceCertificate_LockScreen() Handles serviceCertificate.LockScreen
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
    End Sub

    Private Sub serviceCertificate_UnLockScreen() Handles serviceCertificate.UnLockScreen
        Me.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub serviceCertificate_GetPrivateKey(ByRef keyValue As String, ByRef cancel As Boolean) Handles serviceCertificate.GetPrivateKey
        keyValue = adminWalletAddress.privateKey

        cancel = (keyValue.Trim.Length = 0)
    End Sub

    Private Sub serviceCertificate_UpdateCertificateSetting(newValue As String) Handles serviceCertificate.UpdateCertificateSetting
        Try
            AreaCommon.settings.data.certificateServiceAdmin = newValue

            AreaCommon.settings.save()
        Catch ex As Exception
        End Try
    End Sub


End Class