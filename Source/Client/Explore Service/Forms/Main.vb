Option Compare Text
Option Explicit On

Imports System.ComponentModel
Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCProtocolLibrary.AreaCommon
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

            requesterWalletAddress.value = .requesterWalletAddress
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
                .requesterWalletAddress = requesterWalletAddress.value
                .publicAddressIPPrimaryChain = serviceUrlProtocol.address
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

                    requesterWalletAddress.dataPath = AreaCommon.paths.pathKeystore
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
                            requesterWalletAddress.value = .requesterWalletAddress
                            serviceUrlProtocol.address = .publicAddressIPPrimaryChain
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

    Private Sub serviceUrlProtocol_LockScreen()
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
    End Sub

    Private Sub serviceUrlProtocol_UnLockScreen()
        Me.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub serviceIDText_TextChanged(sender As Object, e As EventArgs) Handles serviceIDText.TextChanged
        serviceUrlProtocol.serviceId = serviceIDText.Text
    End Sub

    Private Sub mainTab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mainTab.SelectedIndexChanged
        mainTab.TabPages(1).Enabled = True
        mainTab.TabPages(2).Enabled = True
    End Sub

    Private Sub connectServiceButton_Click(sender As Object, e As EventArgs)
        If saveData() Then
            _SystemActive = serviceUrlProtocol.testServiceResponse()

            If Not _SystemActive Then
                MessageBox.Show("Test connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                mainTab.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub serviceCertificate_LockScreen() 
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
    End Sub

    Private Sub serviceCertificate_UnLockScreen()
        Me.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Function decodeComponentPosition(ByVal value As Models.Administration.EnumDataPosition) As String
        Select Case value
            Case Models.Administration.EnumDataPosition.checkControlNotPassed : Return "Check control not passed"
            Case Models.Administration.EnumDataPosition.checkControlPassed : Return "Check control passed"
            Case Models.Administration.EnumDataPosition.missing : Return "Missing"
            Case Else : Return "Not checked"
        End Select
    End Function

    Private Sub refreshDataMonitor_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub serviceUrlProtocol_Load(sender As Object, e As EventArgs) Handles serviceUrlProtocol.Load

    End Sub

    Private Sub queryInfoNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.InfoNetworkBaseModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/informationBase/"

            Dim rt As String = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                    namePlatformText.Text = remote.data.name
                    networkCreationDatePlatformText.Text = remote.data.networkCreationDate
                    genesisPublicAddressText.Text = remote.data.genesisPublicAddress

                    requestPlatformInformationText.Text = rt
                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub queryWhitePaperNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.DocumentModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/whitepaper/"

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                    whitePaperText.Text = remote.data.value
                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub queryYellowPaperNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.DocumentModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/yellowpaper/"

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                    yellowPaperText.Text = remote.data.value
                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub queryPrimaryAssetNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.InfoAssetModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/primaryAsset/"

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                    primaryAssetNameText.Text = remote.data.value.name
                    primaryAssetShortNameText.Text = remote.data.value.shortName
                    primaryAssetSymbolText.Text = remote.data.value.symbol
                    primaryAssetQtaTotalText.Text = remote.data.value.qtaTotal
                    primaryAssetDigitText.Text = remote.data.value.digit

                    If remote.data.value.stakeable Then
                        primaryAssetStakableText.Text = "Yes"
                    Else
                        primaryAssetStakableText.Text = "No"
                    End If
                    If remote.data.value.prestake Then
                        primaryAssetPreStakeText.Text = "Yes"
                    Else
                        primaryAssetPreStakeText.Text = "No"
                    End If
                    If remote.data.value.burnable Then
                        primaryAssetBurnableText.Text = "Yes"
                    Else
                        primaryAssetBurnableText.Text = "No"
                    End If

                    primaryAssetUnitNameText.Text = remote.data.value.nameUnit
                    primaryAssetQtaInitialStakeText.Text = remote.data.value.qtaInitialStake
                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub queryPrivacyPolicyNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.DocumentModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/privacyPolicy/"

            Dim rt As String = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                    privacyPolicyText.Text = remote.data.value
                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub queryGeneralConditionNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.DocumentModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/generalCondition/"

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                    generalConditionText.Text = remote.data.value
                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub queryTransactionChainSettingsNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.InfoTransactionChainSettingsModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/transactionChainSettings/"

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then

                    blockChainSizeFrequencyText.Text = remote.data.value.blockSizeFrequency
                    numberBlockInVolumeText.Text = remote.data.value.numberBlockInVolume
                    initialMaxComputeTransactionText.Text = remote.data.value.initialMaxComputeTransaction
                    ruleFutureReleaseText.Text = remote.data.value.ruleFutureRelease
                    reviewReleaseAlgorithmText.Text = remote.data.value.reviewReleaseAlgorithm
                    consensusMethodText.Text = remote.data.value.consensusMethod

                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub loadDataIntoGrid(ByVal data As Models.Network.RefundItem)
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(data.recipient)
            rowItem.Add(data.description)
            rowItem.Add(data.fixValue)
            rowItem.Add(data.percentageValue)

            If (data.fixValue <> 0) Then
                rowItem.Add(data.fixValue & " " & primaryAssetSymbolText.Text)
            Else
                rowItem.Add(data.percentageValue & " %")
            End If

            refundPlanDataGrid.Rows.Add(rowItem.ToArray)
        Catch ex As Exception
            MessageBox.Show("Error during loadDataIntoGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub queryRefundPlanNetwork()
        Try
            Dim remote As New ProxyWS(Of Models.Network.InfoRefundPlanModel)

            remote.url = serviceUrlProtocol.baseUrlComplete & "/api/" & serviceIDText.Text & "/network/refundPlan/"

            Dim rt As String = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT

            If (remote.getData() = "") Then
                If (remote.data.responseStatus = CHCCommonLibrary.AreaCommon.Models.General.RemoteResponse.EnumResponseStatus.responseComplete) Then

                    refundPlanDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
                    refundPlanDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
                    refundPlanDataGrid.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

                    refundPlanDataGrid.Rows.Clear()

                    For Each item In remote.data.value.items
                        loadDataIntoGrid(item)
                    Next

                    responsePlatformInformationTimeText.Text = rt

                Else
                    MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Connection failed", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            remote = Nothing
        Catch ex As Exception
            MessageBox.Show("QueryInfoNetwork: error occurrent", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub serviceUrlProtocol_RunCommand() Handles serviceUrlProtocol.RunCommand
        queryInfoNetwork()
        queryWhitePaperNetwork()
        queryYellowPaperNetwork()
        queryPrimaryAssetNetwork()
        queryTransactionChainSettingsNetwork()
        queryPrivacyPolicyNetwork()
        queryGeneralConditionNetwork()
        queryRefundPlanNetwork()
    End Sub

End Class