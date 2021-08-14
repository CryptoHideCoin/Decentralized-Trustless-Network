<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.connectionTab = New System.Windows.Forms.TabPage()
        Me.localPathAndDataPortNumberFrame = New System.Windows.Forms.GroupBox()
        Me.deleteConfigurationButton = New System.Windows.Forms.Button()
        Me.newConfigurationButton = New System.Windows.Forms.Button()
        Me.saveConfigurationButton = New System.Windows.Forms.Button()
        Me.configurationLabel = New System.Windows.Forms.Label()
        Me.configurationNameCombo = New System.Windows.Forms.ComboBox()
        Me.browseLocalPathButton = New System.Windows.Forms.Button()
        Me.localPathDataText = New System.Windows.Forms.TextBox()
        Me.adminServiceConnectionGroup = New System.Windows.Forms.GroupBox()
        Me.requesterWalletAddress = New CHCSupportUIControls.WalletAddress()
        Me.serviceIDText = New System.Windows.Forms.TextBox()
        Me.serviceUUID = New System.Windows.Forms.Label()
        Me.supportedProtocolsTab = New System.Windows.Forms.TabPage()
        Me.infoStatusNetwork = New System.Windows.Forms.GroupBox()
        Me.listLabel = New System.Windows.Forms.Label()
        Me.responseProtocolTimeText = New System.Windows.Forms.TextBox()
        Me.responseProtocolTimeLabel = New System.Windows.Forms.Label()
        Me.requestProtocolTimeText = New System.Windows.Forms.TextBox()
        Me.requestProtocolTimeLabel = New System.Windows.Forms.Label()
        Me.protocolList = New System.Windows.Forms.TextBox()
        Me.refreshSupportedProtocols = New System.Windows.Forms.Button()
        Me.primaryChainTab = New System.Windows.Forms.TabPage()
        Me.serviceUrlProtocol = New CHCSupportUIControls.UrlProtocol()
        Me.primaryTab = New System.Windows.Forms.TabControl()
        Me.informationBaseTab = New System.Windows.Forms.TabPage()
        Me.genesisPublicAddressText = New System.Windows.Forms.TextBox()
        Me.networkCreationDatePlatformText = New System.Windows.Forms.TextBox()
        Me.responsePlatformInformationTimeText = New System.Windows.Forms.TextBox()
        Me.requestPlatformInformationText = New System.Windows.Forms.TextBox()
        Me.namePlatformText = New System.Windows.Forms.TextBox()
        Me.genesiPublicAddressLabel = New System.Windows.Forms.Label()
        Me.networkCreationDateLabel = New System.Windows.Forms.Label()
        Me.responseMonitorTimeLabel = New System.Windows.Forms.Label()
        Me.requestMonitorTimeLabel = New System.Windows.Forms.Label()
        Me.servicePositionLabel = New System.Windows.Forms.Label()
        Me.whitePaperTab = New System.Windows.Forms.TabPage()
        Me.whitePaperText = New System.Windows.Forms.TextBox()
        Me.yellowPaperTab = New System.Windows.Forms.TabPage()
        Me.yellowPaperText = New System.Windows.Forms.TextBox()
        Me.primaryAssetTab = New System.Windows.Forms.TabPage()
        Me.primaryAssetQtaInitialStakeText = New System.Windows.Forms.TextBox()
        Me.primaryAssetQtaInitialStakeLabel = New System.Windows.Forms.Label()
        Me.primaryAssetUnitNameText = New System.Windows.Forms.TextBox()
        Me.primaryAssetUnitNameLabel = New System.Windows.Forms.Label()
        Me.primaryAssetBurnableText = New System.Windows.Forms.TextBox()
        Me.primaryAssetBurnableLabel = New System.Windows.Forms.Label()
        Me.primaryAssetPreStakeText = New System.Windows.Forms.TextBox()
        Me.primaryAssetPreStakeLabel = New System.Windows.Forms.Label()
        Me.primaryAssetStakableText = New System.Windows.Forms.TextBox()
        Me.primaryAssetStakableLabel = New System.Windows.Forms.Label()
        Me.primaryAssetDigitText = New System.Windows.Forms.TextBox()
        Me.primaryAssetDigitLabel = New System.Windows.Forms.Label()
        Me.primaryAssetQtaTotalText = New System.Windows.Forms.TextBox()
        Me.primaryAssetQtaTotalLabel = New System.Windows.Forms.Label()
        Me.primaryAssetSymbolText = New System.Windows.Forms.TextBox()
        Me.primaryAssetShortNameText = New System.Windows.Forms.TextBox()
        Me.primaryAssetNameText = New System.Windows.Forms.TextBox()
        Me.primaryAssetSymbolLabel = New System.Windows.Forms.Label()
        Me.primaryAssetShortNameLabel = New System.Windows.Forms.Label()
        Me.primaryAssetNameLabel = New System.Windows.Forms.Label()
        Me.transactionChainSettings = New System.Windows.Forms.TabPage()
        Me.consensusMethodText = New System.Windows.Forms.TextBox()
        Me.consensusMethodLabel = New System.Windows.Forms.Label()
        Me.reviewReleaseAlgorithmText = New System.Windows.Forms.TextBox()
        Me.reviewReleaseAlgorithmLabel = New System.Windows.Forms.Label()
        Me.ruleFutureReleaseText = New System.Windows.Forms.TextBox()
        Me.ruleFutureReleaseLabel = New System.Windows.Forms.Label()
        Me.initialMaxComputeTransactionText = New System.Windows.Forms.TextBox()
        Me.numberBlockInVolumeText = New System.Windows.Forms.TextBox()
        Me.blockChainSizeFrequencyText = New System.Windows.Forms.TextBox()
        Me.initialMaxComputeTransactionLabel = New System.Windows.Forms.Label()
        Me.numberBlockInVolumeLabel = New System.Windows.Forms.Label()
        Me.blockChainSizeFrequencyLabel = New System.Windows.Forms.Label()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.policyPrivacyTab = New System.Windows.Forms.TabPage()
        Me.privacyPolicyText = New System.Windows.Forms.TextBox()
        Me.generalConditionTab = New System.Windows.Forms.TabPage()
        Me.generalConditionText = New System.Windows.Forms.TextBox()
        Me.refundPlanTab = New System.Windows.Forms.TabPage()
        Me.refundPlanDataGrid = New System.Windows.Forms.DataGridView()
        Me.Recipient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fixValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercentageValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisplayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mainTab.SuspendLayout()
        Me.connectionTab.SuspendLayout()
        Me.localPathAndDataPortNumberFrame.SuspendLayout()
        Me.adminServiceConnectionGroup.SuspendLayout()
        Me.supportedProtocolsTab.SuspendLayout()
        Me.infoStatusNetwork.SuspendLayout()
        Me.primaryChainTab.SuspendLayout()
        Me.primaryTab.SuspendLayout()
        Me.informationBaseTab.SuspendLayout()
        Me.whitePaperTab.SuspendLayout()
        Me.yellowPaperTab.SuspendLayout()
        Me.primaryAssetTab.SuspendLayout()
        Me.transactionChainSettings.SuspendLayout()
        Me.policyPrivacyTab.SuspendLayout()
        Me.generalConditionTab.SuspendLayout()
        Me.refundPlanTab.SuspendLayout()
        CType(Me.refundPlanDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainTab
        '
        Me.mainTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTab.Controls.Add(Me.connectionTab)
        Me.mainTab.Controls.Add(Me.supportedProtocolsTab)
        Me.mainTab.Controls.Add(Me.primaryChainTab)
        Me.mainTab.Location = New System.Drawing.Point(2, 2)
        Me.mainTab.Multiline = True
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(695, 384)
        Me.mainTab.TabIndex = 0
        '
        'connectionTab
        '
        Me.connectionTab.Controls.Add(Me.localPathAndDataPortNumberFrame)
        Me.connectionTab.Controls.Add(Me.adminServiceConnectionGroup)
        Me.connectionTab.Location = New System.Drawing.Point(4, 22)
        Me.connectionTab.Name = "connectionTab"
        Me.connectionTab.Padding = New System.Windows.Forms.Padding(3)
        Me.connectionTab.Size = New System.Drawing.Size(687, 358)
        Me.connectionTab.TabIndex = 0
        Me.connectionTab.Text = "Settings"
        Me.connectionTab.UseVisualStyleBackColor = True
        '
        'localPathAndDataPortNumberFrame
        '
        Me.localPathAndDataPortNumberFrame.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathAndDataPortNumberFrame.Controls.Add(Me.deleteConfigurationButton)
        Me.localPathAndDataPortNumberFrame.Controls.Add(Me.newConfigurationButton)
        Me.localPathAndDataPortNumberFrame.Controls.Add(Me.saveConfigurationButton)
        Me.localPathAndDataPortNumberFrame.Controls.Add(Me.configurationLabel)
        Me.localPathAndDataPortNumberFrame.Controls.Add(Me.configurationNameCombo)
        Me.localPathAndDataPortNumberFrame.Controls.Add(Me.browseLocalPathButton)
        Me.localPathAndDataPortNumberFrame.Controls.Add(Me.localPathDataText)
        Me.localPathAndDataPortNumberFrame.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathAndDataPortNumberFrame.Location = New System.Drawing.Point(8, 6)
        Me.localPathAndDataPortNumberFrame.Name = "localPathAndDataPortNumberFrame"
        Me.localPathAndDataPortNumberFrame.Size = New System.Drawing.Size(668, 96)
        Me.localPathAndDataPortNumberFrame.TabIndex = 0
        Me.localPathAndDataPortNumberFrame.TabStop = False
        Me.localPathAndDataPortNumberFrame.Text = "Local path data && configuration"
        '
        'deleteConfigurationButton
        '
        Me.deleteConfigurationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.deleteConfigurationButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteConfigurationButton.Location = New System.Drawing.Point(600, 60)
        Me.deleteConfigurationButton.Name = "deleteConfigurationButton"
        Me.deleteConfigurationButton.Size = New System.Drawing.Size(61, 22)
        Me.deleteConfigurationButton.TabIndex = 5
        Me.deleteConfigurationButton.Text = "Delete"
        Me.deleteConfigurationButton.UseVisualStyleBackColor = True
        '
        'newConfigurationButton
        '
        Me.newConfigurationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.newConfigurationButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newConfigurationButton.Location = New System.Drawing.Point(495, 60)
        Me.newConfigurationButton.Name = "newConfigurationButton"
        Me.newConfigurationButton.Size = New System.Drawing.Size(49, 22)
        Me.newConfigurationButton.TabIndex = 3
        Me.newConfigurationButton.Text = "New"
        Me.newConfigurationButton.UseVisualStyleBackColor = True
        '
        'saveConfigurationButton
        '
        Me.saveConfigurationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveConfigurationButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveConfigurationButton.Location = New System.Drawing.Point(548, 60)
        Me.saveConfigurationButton.Name = "saveConfigurationButton"
        Me.saveConfigurationButton.Size = New System.Drawing.Size(49, 22)
        Me.saveConfigurationButton.TabIndex = 4
        Me.saveConfigurationButton.Text = "Save"
        Me.saveConfigurationButton.UseVisualStyleBackColor = True
        '
        'configurationLabel
        '
        Me.configurationLabel.AutoSize = True
        Me.configurationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.configurationLabel.Location = New System.Drawing.Point(16, 62)
        Me.configurationLabel.Name = "configurationLabel"
        Me.configurationLabel.Size = New System.Drawing.Size(84, 13)
        Me.configurationLabel.TabIndex = 11
        Me.configurationLabel.Text = "Configuration"
        '
        'configurationNameCombo
        '
        Me.configurationNameCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.configurationNameCombo.DisplayMember = "Text"
        Me.configurationNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.configurationNameCombo.FormattingEnabled = True
        Me.configurationNameCombo.Location = New System.Drawing.Point(106, 60)
        Me.configurationNameCombo.Name = "configurationNameCombo"
        Me.configurationNameCombo.Size = New System.Drawing.Size(385, 21)
        Me.configurationNameCombo.TabIndex = 2
        Me.configurationNameCombo.ValueMember = "Value"
        '
        'browseLocalPathButton
        '
        Me.browseLocalPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPathButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPathButton.Location = New System.Drawing.Point(626, 30)
        Me.browseLocalPathButton.Name = "browseLocalPathButton"
        Me.browseLocalPathButton.Size = New System.Drawing.Size(35, 22)
        Me.browseLocalPathButton.TabIndex = 1
        Me.browseLocalPathButton.Text = "..."
        Me.browseLocalPathButton.UseVisualStyleBackColor = True
        '
        'localPathDataText
        '
        Me.localPathDataText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathDataText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathDataText.Location = New System.Drawing.Point(8, 30)
        Me.localPathDataText.Name = "localPathDataText"
        Me.localPathDataText.Size = New System.Drawing.Size(612, 21)
        Me.localPathDataText.TabIndex = 0
        '
        'adminServiceConnectionGroup
        '
        Me.adminServiceConnectionGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminServiceConnectionGroup.Controls.Add(Me.requesterWalletAddress)
        Me.adminServiceConnectionGroup.Controls.Add(Me.serviceIDText)
        Me.adminServiceConnectionGroup.Controls.Add(Me.serviceUUID)
        Me.adminServiceConnectionGroup.Location = New System.Drawing.Point(8, 108)
        Me.adminServiceConnectionGroup.Name = "adminServiceConnectionGroup"
        Me.adminServiceConnectionGroup.Size = New System.Drawing.Size(668, 115)
        Me.adminServiceConnectionGroup.TabIndex = 1
        Me.adminServiceConnectionGroup.TabStop = False
        Me.adminServiceConnectionGroup.Text = "Service Connections"
        '
        'requesterWalletAddress
        '
        Me.requesterWalletAddress.caption = "Requester wallet addr"
        Me.requesterWalletAddress.dataPath = ""
        Me.requesterWalletAddress.Location = New System.Drawing.Point(6, 51)
        Me.requesterWalletAddress.Name = "requesterWalletAddress"
        Me.requesterWalletAddress.Size = New System.Drawing.Size(655, 51)
        Me.requesterWalletAddress.TabIndex = 37
        Me.requesterWalletAddress.value = ""
        '
        'serviceIDText
        '
        Me.serviceIDText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceIDText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceIDText.Location = New System.Drawing.Point(145, 25)
        Me.serviceIDText.Name = "serviceIDText"
        Me.serviceIDText.Size = New System.Drawing.Size(355, 21)
        Me.serviceIDText.TabIndex = 35
        Me.serviceIDText.Text = "a232c1bd-87bd-4074-bf26-0a6909a78f1d"
        '
        'serviceUUID
        '
        Me.serviceUUID.AutoSize = True
        Me.serviceUUID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceUUID.Location = New System.Drawing.Point(69, 29)
        Me.serviceUUID.Name = "serviceUUID"
        Me.serviceUUID.Size = New System.Drawing.Size(68, 13)
        Me.serviceUUID.TabIndex = 36
        Me.serviceUUID.Text = "Service ID"
        '
        'supportedProtocolsTab
        '
        Me.supportedProtocolsTab.Controls.Add(Me.infoStatusNetwork)
        Me.supportedProtocolsTab.Controls.Add(Me.refreshSupportedProtocols)
        Me.supportedProtocolsTab.Location = New System.Drawing.Point(4, 22)
        Me.supportedProtocolsTab.Name = "supportedProtocolsTab"
        Me.supportedProtocolsTab.Size = New System.Drawing.Size(687, 358)
        Me.supportedProtocolsTab.TabIndex = 2
        Me.supportedProtocolsTab.Text = "Supported Protocols"
        Me.supportedProtocolsTab.UseVisualStyleBackColor = True
        '
        'infoStatusNetwork
        '
        Me.infoStatusNetwork.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoStatusNetwork.Controls.Add(Me.listLabel)
        Me.infoStatusNetwork.Controls.Add(Me.responseProtocolTimeText)
        Me.infoStatusNetwork.Controls.Add(Me.responseProtocolTimeLabel)
        Me.infoStatusNetwork.Controls.Add(Me.requestProtocolTimeText)
        Me.infoStatusNetwork.Controls.Add(Me.requestProtocolTimeLabel)
        Me.infoStatusNetwork.Controls.Add(Me.protocolList)
        Me.infoStatusNetwork.Location = New System.Drawing.Point(7, 48)
        Me.infoStatusNetwork.Name = "infoStatusNetwork"
        Me.infoStatusNetwork.Size = New System.Drawing.Size(673, 299)
        Me.infoStatusNetwork.TabIndex = 4
        Me.infoStatusNetwork.TabStop = False
        Me.infoStatusNetwork.Text = "Protocol"
        '
        'listLabel
        '
        Me.listLabel.AutoSize = True
        Me.listLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listLabel.Location = New System.Drawing.Point(85, 23)
        Me.listLabel.Name = "listLabel"
        Me.listLabel.Size = New System.Drawing.Size(26, 13)
        Me.listLabel.TabIndex = 25
        Me.listLabel.Text = "List"
        '
        'responseProtocolTimeText
        '
        Me.responseProtocolTimeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responseProtocolTimeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseProtocolTimeText.Location = New System.Drawing.Point(117, 265)
        Me.responseProtocolTimeText.Name = "responseProtocolTimeText"
        Me.responseProtocolTimeText.ReadOnly = True
        Me.responseProtocolTimeText.Size = New System.Drawing.Size(536, 21)
        Me.responseProtocolTimeText.TabIndex = 22
        '
        'responseProtocolTimeLabel
        '
        Me.responseProtocolTimeLabel.AutoSize = True
        Me.responseProtocolTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseProtocolTimeLabel.Location = New System.Drawing.Point(17, 265)
        Me.responseProtocolTimeLabel.Name = "responseProtocolTimeLabel"
        Me.responseProtocolTimeLabel.Size = New System.Drawing.Size(94, 13)
        Me.responseProtocolTimeLabel.TabIndex = 24
        Me.responseProtocolTimeLabel.Text = "Response Time"
        '
        'requestProtocolTimeText
        '
        Me.requestProtocolTimeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestProtocolTimeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestProtocolTimeText.Location = New System.Drawing.Point(117, 238)
        Me.requestProtocolTimeText.Name = "requestProtocolTimeText"
        Me.requestProtocolTimeText.ReadOnly = True
        Me.requestProtocolTimeText.Size = New System.Drawing.Size(536, 21)
        Me.requestProtocolTimeText.TabIndex = 21
        '
        'requestProtocolTimeLabel
        '
        Me.requestProtocolTimeLabel.AutoSize = True
        Me.requestProtocolTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestProtocolTimeLabel.Location = New System.Drawing.Point(26, 238)
        Me.requestProtocolTimeLabel.Name = "requestProtocolTimeLabel"
        Me.requestProtocolTimeLabel.Size = New System.Drawing.Size(85, 13)
        Me.requestProtocolTimeLabel.TabIndex = 23
        Me.requestProtocolTimeLabel.Text = "Request Time"
        '
        'protocolList
        '
        Me.protocolList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.protocolList.Location = New System.Drawing.Point(117, 20)
        Me.protocolList.Multiline = True
        Me.protocolList.Name = "protocolList"
        Me.protocolList.ReadOnly = True
        Me.protocolList.Size = New System.Drawing.Size(536, 212)
        Me.protocolList.TabIndex = 0
        '
        'refreshSupportedProtocols
        '
        Me.refreshSupportedProtocols.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshSupportedProtocols.Location = New System.Drawing.Point(605, 6)
        Me.refreshSupportedProtocols.Name = "refreshSupportedProtocols"
        Me.refreshSupportedProtocols.Size = New System.Drawing.Size(75, 36)
        Me.refreshSupportedProtocols.TabIndex = 3
        Me.refreshSupportedProtocols.Text = "Refresh"
        Me.refreshSupportedProtocols.UseVisualStyleBackColor = True
        '
        'primaryChainTab
        '
        Me.primaryChainTab.Controls.Add(Me.serviceUrlProtocol)
        Me.primaryChainTab.Controls.Add(Me.primaryTab)
        Me.primaryChainTab.Location = New System.Drawing.Point(4, 22)
        Me.primaryChainTab.Name = "primaryChainTab"
        Me.primaryChainTab.Size = New System.Drawing.Size(687, 358)
        Me.primaryChainTab.TabIndex = 3
        Me.primaryChainTab.Text = "Primary Chain"
        Me.primaryChainTab.UseVisualStyleBackColor = True
        '
        'serviceUrlProtocol
        '
        Me.serviceUrlProtocol.address = ""
        Me.serviceUrlProtocol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceUrlProtocol.executeCommand = True
        Me.serviceUrlProtocol.Location = New System.Drawing.Point(0, 7)
        Me.serviceUrlProtocol.MinimumSize = New System.Drawing.Size(0, 29)
        Me.serviceUrlProtocol.Name = "serviceUrlProtocol"
        Me.serviceUrlProtocol.serviceId = ""
        Me.serviceUrlProtocol.Size = New System.Drawing.Size(687, 29)
        Me.serviceUrlProtocol.TabIndex = 27
        Me.serviceUrlProtocol.useSecure = False
        '
        'primaryTab
        '
        Me.primaryTab.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.primaryTab.Controls.Add(Me.informationBaseTab)
        Me.primaryTab.Controls.Add(Me.whitePaperTab)
        Me.primaryTab.Controls.Add(Me.yellowPaperTab)
        Me.primaryTab.Controls.Add(Me.primaryAssetTab)
        Me.primaryTab.Controls.Add(Me.transactionChainSettings)
        Me.primaryTab.Controls.Add(Me.policyPrivacyTab)
        Me.primaryTab.Controls.Add(Me.generalConditionTab)
        Me.primaryTab.Controls.Add(Me.refundPlanTab)
        Me.primaryTab.Location = New System.Drawing.Point(1, 38)
        Me.primaryTab.Multiline = True
        Me.primaryTab.Name = "primaryTab"
        Me.primaryTab.SelectedIndex = 0
        Me.primaryTab.Size = New System.Drawing.Size(687, 320)
        Me.primaryTab.TabIndex = 26
        '
        'informationBaseTab
        '
        Me.informationBaseTab.Controls.Add(Me.genesisPublicAddressText)
        Me.informationBaseTab.Controls.Add(Me.networkCreationDatePlatformText)
        Me.informationBaseTab.Controls.Add(Me.responsePlatformInformationTimeText)
        Me.informationBaseTab.Controls.Add(Me.requestPlatformInformationText)
        Me.informationBaseTab.Controls.Add(Me.namePlatformText)
        Me.informationBaseTab.Controls.Add(Me.genesiPublicAddressLabel)
        Me.informationBaseTab.Controls.Add(Me.networkCreationDateLabel)
        Me.informationBaseTab.Controls.Add(Me.responseMonitorTimeLabel)
        Me.informationBaseTab.Controls.Add(Me.requestMonitorTimeLabel)
        Me.informationBaseTab.Controls.Add(Me.servicePositionLabel)
        Me.informationBaseTab.Location = New System.Drawing.Point(64, 4)
        Me.informationBaseTab.Name = "informationBaseTab"
        Me.informationBaseTab.Padding = New System.Windows.Forms.Padding(3)
        Me.informationBaseTab.Size = New System.Drawing.Size(619, 312)
        Me.informationBaseTab.TabIndex = 0
        Me.informationBaseTab.Text = "Platform"
        Me.informationBaseTab.UseVisualStyleBackColor = True
        '
        'genesisPublicAddressText
        '
        Me.genesisPublicAddressText.Location = New System.Drawing.Point(155, 69)
        Me.genesisPublicAddressText.Name = "genesisPublicAddressText"
        Me.genesisPublicAddressText.ReadOnly = True
        Me.genesisPublicAddressText.Size = New System.Drawing.Size(476, 21)
        Me.genesisPublicAddressText.TabIndex = 32
        '
        'networkCreationDatePlatformText
        '
        Me.networkCreationDatePlatformText.Location = New System.Drawing.Point(155, 42)
        Me.networkCreationDatePlatformText.Name = "networkCreationDatePlatformText"
        Me.networkCreationDatePlatformText.ReadOnly = True
        Me.networkCreationDatePlatformText.Size = New System.Drawing.Size(476, 21)
        Me.networkCreationDatePlatformText.TabIndex = 30
        '
        'responsePlatformInformationTimeText
        '
        Me.responsePlatformInformationTimeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responsePlatformInformationTimeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responsePlatformInformationTimeText.Location = New System.Drawing.Point(155, 148)
        Me.responsePlatformInformationTimeText.Name = "responsePlatformInformationTimeText"
        Me.responsePlatformInformationTimeText.ReadOnly = True
        Me.responsePlatformInformationTimeText.Size = New System.Drawing.Size(162, 21)
        Me.responsePlatformInformationTimeText.TabIndex = 26
        '
        'requestPlatformInformationText
        '
        Me.requestPlatformInformationText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestPlatformInformationText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestPlatformInformationText.Location = New System.Drawing.Point(155, 121)
        Me.requestPlatformInformationText.Name = "requestPlatformInformationText"
        Me.requestPlatformInformationText.ReadOnly = True
        Me.requestPlatformInformationText.Size = New System.Drawing.Size(162, 21)
        Me.requestPlatformInformationText.TabIndex = 25
        '
        'namePlatformText
        '
        Me.namePlatformText.Location = New System.Drawing.Point(155, 15)
        Me.namePlatformText.Name = "namePlatformText"
        Me.namePlatformText.ReadOnly = True
        Me.namePlatformText.Size = New System.Drawing.Size(476, 21)
        Me.namePlatformText.TabIndex = 8
        '
        'genesiPublicAddressLabel
        '
        Me.genesiPublicAddressLabel.AutoSize = True
        Me.genesiPublicAddressLabel.Location = New System.Drawing.Point(12, 72)
        Me.genesiPublicAddressLabel.Name = "genesiPublicAddressLabel"
        Me.genesiPublicAddressLabel.Size = New System.Drawing.Size(138, 13)
        Me.genesiPublicAddressLabel.TabIndex = 31
        Me.genesiPublicAddressLabel.Text = "Genesis public address"
        '
        'networkCreationDateLabel
        '
        Me.networkCreationDateLabel.AutoSize = True
        Me.networkCreationDateLabel.Location = New System.Drawing.Point(16, 45)
        Me.networkCreationDateLabel.Name = "networkCreationDateLabel"
        Me.networkCreationDateLabel.Size = New System.Drawing.Size(133, 13)
        Me.networkCreationDateLabel.TabIndex = 29
        Me.networkCreationDateLabel.Text = "Network creation date"
        '
        'responseMonitorTimeLabel
        '
        Me.responseMonitorTimeLabel.AutoSize = True
        Me.responseMonitorTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseMonitorTimeLabel.Location = New System.Drawing.Point(55, 151)
        Me.responseMonitorTimeLabel.Name = "responseMonitorTimeLabel"
        Me.responseMonitorTimeLabel.Size = New System.Drawing.Size(94, 13)
        Me.responseMonitorTimeLabel.TabIndex = 28
        Me.responseMonitorTimeLabel.Text = "Response Time"
        '
        'requestMonitorTimeLabel
        '
        Me.requestMonitorTimeLabel.AutoSize = True
        Me.requestMonitorTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestMonitorTimeLabel.Location = New System.Drawing.Point(64, 124)
        Me.requestMonitorTimeLabel.Name = "requestMonitorTimeLabel"
        Me.requestMonitorTimeLabel.Size = New System.Drawing.Size(85, 13)
        Me.requestMonitorTimeLabel.TabIndex = 27
        Me.requestMonitorTimeLabel.Text = "Request Time"
        '
        'servicePositionLabel
        '
        Me.servicePositionLabel.AutoSize = True
        Me.servicePositionLabel.Location = New System.Drawing.Point(109, 18)
        Me.servicePositionLabel.Name = "servicePositionLabel"
        Me.servicePositionLabel.Size = New System.Drawing.Size(40, 13)
        Me.servicePositionLabel.TabIndex = 7
        Me.servicePositionLabel.Text = "Name"
        '
        'whitePaperTab
        '
        Me.whitePaperTab.Controls.Add(Me.whitePaperText)
        Me.whitePaperTab.Location = New System.Drawing.Point(24, 4)
        Me.whitePaperTab.Name = "whitePaperTab"
        Me.whitePaperTab.Padding = New System.Windows.Forms.Padding(3)
        Me.whitePaperTab.Size = New System.Drawing.Size(659, 312)
        Me.whitePaperTab.TabIndex = 1
        Me.whitePaperTab.Text = "Whitepaper"
        Me.whitePaperTab.UseVisualStyleBackColor = True
        '
        'whitePaperText
        '
        Me.whitePaperText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.whitePaperText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.whitePaperText.Location = New System.Drawing.Point(6, 6)
        Me.whitePaperText.Multiline = True
        Me.whitePaperText.Name = "whitePaperText"
        Me.whitePaperText.ReadOnly = True
        Me.whitePaperText.Size = New System.Drawing.Size(654, 300)
        Me.whitePaperText.TabIndex = 27
        '
        'yellowPaperTab
        '
        Me.yellowPaperTab.Controls.Add(Me.yellowPaperText)
        Me.yellowPaperTab.Location = New System.Drawing.Point(24, 4)
        Me.yellowPaperTab.Name = "yellowPaperTab"
        Me.yellowPaperTab.Size = New System.Drawing.Size(659, 312)
        Me.yellowPaperTab.TabIndex = 2
        Me.yellowPaperTab.Text = "Yellowpaper"
        Me.yellowPaperTab.UseVisualStyleBackColor = True
        '
        'yellowPaperText
        '
        Me.yellowPaperText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.yellowPaperText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.yellowPaperText.Location = New System.Drawing.Point(6, 6)
        Me.yellowPaperText.Multiline = True
        Me.yellowPaperText.Name = "yellowPaperText"
        Me.yellowPaperText.ReadOnly = True
        Me.yellowPaperText.Size = New System.Drawing.Size(654, 300)
        Me.yellowPaperText.TabIndex = 28
        '
        'primaryAssetTab
        '
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetQtaInitialStakeText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetQtaInitialStakeLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetUnitNameText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetUnitNameLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetBurnableText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetBurnableLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetPreStakeText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetPreStakeLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetStakableText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetStakableLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetDigitText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetDigitLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetQtaTotalText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetQtaTotalLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetSymbolText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetShortNameText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetNameText)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetSymbolLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetShortNameLabel)
        Me.primaryAssetTab.Controls.Add(Me.primaryAssetNameLabel)
        Me.primaryAssetTab.Location = New System.Drawing.Point(24, 4)
        Me.primaryAssetTab.Name = "primaryAssetTab"
        Me.primaryAssetTab.Size = New System.Drawing.Size(659, 312)
        Me.primaryAssetTab.TabIndex = 3
        Me.primaryAssetTab.Text = "Asset"
        Me.primaryAssetTab.UseVisualStyleBackColor = True
        '
        'primaryAssetQtaInitialStakeText
        '
        Me.primaryAssetQtaInitialStakeText.Location = New System.Drawing.Point(164, 258)
        Me.primaryAssetQtaInitialStakeText.Name = "primaryAssetQtaInitialStakeText"
        Me.primaryAssetQtaInitialStakeText.ReadOnly = True
        Me.primaryAssetQtaInitialStakeText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetQtaInitialStakeText.TabIndex = 52
        '
        'primaryAssetQtaInitialStakeLabel
        '
        Me.primaryAssetQtaInitialStakeLabel.AutoSize = True
        Me.primaryAssetQtaInitialStakeLabel.Location = New System.Drawing.Point(83, 261)
        Me.primaryAssetQtaInitialStakeLabel.Name = "primaryAssetQtaInitialStakeLabel"
        Me.primaryAssetQtaInitialStakeLabel.Size = New System.Drawing.Size(76, 13)
        Me.primaryAssetQtaInitialStakeLabel.TabIndex = 51
        Me.primaryAssetQtaInitialStakeLabel.Text = "Initial Stake"
        '
        'primaryAssetUnitNameText
        '
        Me.primaryAssetUnitNameText.Location = New System.Drawing.Point(164, 231)
        Me.primaryAssetUnitNameText.Name = "primaryAssetUnitNameText"
        Me.primaryAssetUnitNameText.ReadOnly = True
        Me.primaryAssetUnitNameText.Size = New System.Drawing.Size(449, 21)
        Me.primaryAssetUnitNameText.TabIndex = 50
        '
        'primaryAssetUnitNameLabel
        '
        Me.primaryAssetUnitNameLabel.AutoSize = True
        Me.primaryAssetUnitNameLabel.Location = New System.Drawing.Point(94, 234)
        Me.primaryAssetUnitNameLabel.Name = "primaryAssetUnitNameLabel"
        Me.primaryAssetUnitNameLabel.Size = New System.Drawing.Size(65, 13)
        Me.primaryAssetUnitNameLabel.TabIndex = 49
        Me.primaryAssetUnitNameLabel.Text = "Unit name"
        '
        'primaryAssetBurnableText
        '
        Me.primaryAssetBurnableText.Location = New System.Drawing.Point(164, 204)
        Me.primaryAssetBurnableText.Name = "primaryAssetBurnableText"
        Me.primaryAssetBurnableText.ReadOnly = True
        Me.primaryAssetBurnableText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetBurnableText.TabIndex = 48
        '
        'primaryAssetBurnableLabel
        '
        Me.primaryAssetBurnableLabel.AutoSize = True
        Me.primaryAssetBurnableLabel.Location = New System.Drawing.Point(101, 207)
        Me.primaryAssetBurnableLabel.Name = "primaryAssetBurnableLabel"
        Me.primaryAssetBurnableLabel.Size = New System.Drawing.Size(58, 13)
        Me.primaryAssetBurnableLabel.TabIndex = 47
        Me.primaryAssetBurnableLabel.Text = "Burnable"
        '
        'primaryAssetPreStakeText
        '
        Me.primaryAssetPreStakeText.Location = New System.Drawing.Point(164, 177)
        Me.primaryAssetPreStakeText.Name = "primaryAssetPreStakeText"
        Me.primaryAssetPreStakeText.ReadOnly = True
        Me.primaryAssetPreStakeText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetPreStakeText.TabIndex = 46
        '
        'primaryAssetPreStakeLabel
        '
        Me.primaryAssetPreStakeLabel.AutoSize = True
        Me.primaryAssetPreStakeLabel.Location = New System.Drawing.Point(96, 180)
        Me.primaryAssetPreStakeLabel.Name = "primaryAssetPreStakeLabel"
        Me.primaryAssetPreStakeLabel.Size = New System.Drawing.Size(62, 13)
        Me.primaryAssetPreStakeLabel.TabIndex = 45
        Me.primaryAssetPreStakeLabel.Text = "Pre-stake"
        '
        'primaryAssetStakableText
        '
        Me.primaryAssetStakableText.Location = New System.Drawing.Point(164, 150)
        Me.primaryAssetStakableText.Name = "primaryAssetStakableText"
        Me.primaryAssetStakableText.ReadOnly = True
        Me.primaryAssetStakableText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetStakableText.TabIndex = 44
        '
        'primaryAssetStakableLabel
        '
        Me.primaryAssetStakableLabel.AutoSize = True
        Me.primaryAssetStakableLabel.Location = New System.Drawing.Point(101, 153)
        Me.primaryAssetStakableLabel.Name = "primaryAssetStakableLabel"
        Me.primaryAssetStakableLabel.Size = New System.Drawing.Size(57, 13)
        Me.primaryAssetStakableLabel.TabIndex = 43
        Me.primaryAssetStakableLabel.Text = "Stakable"
        '
        'primaryAssetDigitText
        '
        Me.primaryAssetDigitText.Location = New System.Drawing.Point(164, 123)
        Me.primaryAssetDigitText.Name = "primaryAssetDigitText"
        Me.primaryAssetDigitText.ReadOnly = True
        Me.primaryAssetDigitText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetDigitText.TabIndex = 42
        '
        'primaryAssetDigitLabel
        '
        Me.primaryAssetDigitLabel.AutoSize = True
        Me.primaryAssetDigitLabel.Location = New System.Drawing.Point(125, 126)
        Me.primaryAssetDigitLabel.Name = "primaryAssetDigitLabel"
        Me.primaryAssetDigitLabel.Size = New System.Drawing.Size(33, 13)
        Me.primaryAssetDigitLabel.TabIndex = 41
        Me.primaryAssetDigitLabel.Text = "Digit"
        '
        'primaryAssetQtaTotalText
        '
        Me.primaryAssetQtaTotalText.Location = New System.Drawing.Point(164, 96)
        Me.primaryAssetQtaTotalText.Name = "primaryAssetQtaTotalText"
        Me.primaryAssetQtaTotalText.ReadOnly = True
        Me.primaryAssetQtaTotalText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetQtaTotalText.TabIndex = 40
        '
        'primaryAssetQtaTotalLabel
        '
        Me.primaryAssetQtaTotalLabel.AutoSize = True
        Me.primaryAssetQtaTotalLabel.Location = New System.Drawing.Point(72, 99)
        Me.primaryAssetQtaTotalLabel.Name = "primaryAssetQtaTotalLabel"
        Me.primaryAssetQtaTotalLabel.Size = New System.Drawing.Size(86, 13)
        Me.primaryAssetQtaTotalLabel.TabIndex = 39
        Me.primaryAssetQtaTotalLabel.Text = "Quantity Total"
        '
        'primaryAssetSymbolText
        '
        Me.primaryAssetSymbolText.Location = New System.Drawing.Point(164, 69)
        Me.primaryAssetSymbolText.Name = "primaryAssetSymbolText"
        Me.primaryAssetSymbolText.ReadOnly = True
        Me.primaryAssetSymbolText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetSymbolText.TabIndex = 38
        '
        'primaryAssetShortNameText
        '
        Me.primaryAssetShortNameText.Location = New System.Drawing.Point(164, 42)
        Me.primaryAssetShortNameText.Name = "primaryAssetShortNameText"
        Me.primaryAssetShortNameText.ReadOnly = True
        Me.primaryAssetShortNameText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetShortNameText.TabIndex = 36
        '
        'primaryAssetNameText
        '
        Me.primaryAssetNameText.Location = New System.Drawing.Point(164, 15)
        Me.primaryAssetNameText.Name = "primaryAssetNameText"
        Me.primaryAssetNameText.ReadOnly = True
        Me.primaryAssetNameText.Size = New System.Drawing.Size(448, 21)
        Me.primaryAssetNameText.TabIndex = 34
        '
        'primaryAssetSymbolLabel
        '
        Me.primaryAssetSymbolLabel.AutoSize = True
        Me.primaryAssetSymbolLabel.Location = New System.Drawing.Point(108, 72)
        Me.primaryAssetSymbolLabel.Name = "primaryAssetSymbolLabel"
        Me.primaryAssetSymbolLabel.Size = New System.Drawing.Size(50, 13)
        Me.primaryAssetSymbolLabel.TabIndex = 37
        Me.primaryAssetSymbolLabel.Text = "Symbol"
        '
        'primaryAssetShortNameLabel
        '
        Me.primaryAssetShortNameLabel.AutoSize = True
        Me.primaryAssetShortNameLabel.Location = New System.Drawing.Point(83, 45)
        Me.primaryAssetShortNameLabel.Name = "primaryAssetShortNameLabel"
        Me.primaryAssetShortNameLabel.Size = New System.Drawing.Size(75, 13)
        Me.primaryAssetShortNameLabel.TabIndex = 35
        Me.primaryAssetShortNameLabel.Text = "Short Name"
        '
        'primaryAssetNameLabel
        '
        Me.primaryAssetNameLabel.AutoSize = True
        Me.primaryAssetNameLabel.Location = New System.Drawing.Point(118, 18)
        Me.primaryAssetNameLabel.Name = "primaryAssetNameLabel"
        Me.primaryAssetNameLabel.Size = New System.Drawing.Size(40, 13)
        Me.primaryAssetNameLabel.TabIndex = 33
        Me.primaryAssetNameLabel.Text = "Name"
        '
        'transactionChainSettings
        '
        Me.transactionChainSettings.Controls.Add(Me.consensusMethodText)
        Me.transactionChainSettings.Controls.Add(Me.consensusMethodLabel)
        Me.transactionChainSettings.Controls.Add(Me.reviewReleaseAlgorithmText)
        Me.transactionChainSettings.Controls.Add(Me.reviewReleaseAlgorithmLabel)
        Me.transactionChainSettings.Controls.Add(Me.ruleFutureReleaseText)
        Me.transactionChainSettings.Controls.Add(Me.ruleFutureReleaseLabel)
        Me.transactionChainSettings.Controls.Add(Me.initialMaxComputeTransactionText)
        Me.transactionChainSettings.Controls.Add(Me.numberBlockInVolumeText)
        Me.transactionChainSettings.Controls.Add(Me.blockChainSizeFrequencyText)
        Me.transactionChainSettings.Controls.Add(Me.initialMaxComputeTransactionLabel)
        Me.transactionChainSettings.Controls.Add(Me.numberBlockInVolumeLabel)
        Me.transactionChainSettings.Controls.Add(Me.blockChainSizeFrequencyLabel)
        Me.transactionChainSettings.Location = New System.Drawing.Point(44, 4)
        Me.transactionChainSettings.Name = "transactionChainSettings"
        Me.transactionChainSettings.Size = New System.Drawing.Size(639, 312)
        Me.transactionChainSettings.TabIndex = 4
        Me.transactionChainSettings.Text = "Transaction Chain Settings"
        Me.transactionChainSettings.UseVisualStyleBackColor = True
        '
        'consensusMethodText
        '
        Me.consensusMethodText.Location = New System.Drawing.Point(206, 151)
        Me.consensusMethodText.Name = "consensusMethodText"
        Me.consensusMethodText.ReadOnly = True
        Me.consensusMethodText.Size = New System.Drawing.Size(407, 21)
        Me.consensusMethodText.TabIndex = 54
        '
        'consensusMethodLabel
        '
        Me.consensusMethodLabel.AutoSize = True
        Me.consensusMethodLabel.Location = New System.Drawing.Point(84, 154)
        Me.consensusMethodLabel.Name = "consensusMethodLabel"
        Me.consensusMethodLabel.Size = New System.Drawing.Size(114, 13)
        Me.consensusMethodLabel.TabIndex = 53
        Me.consensusMethodLabel.Text = "Consensus Method"
        '
        'reviewReleaseAlgorithmText
        '
        Me.reviewReleaseAlgorithmText.Location = New System.Drawing.Point(206, 124)
        Me.reviewReleaseAlgorithmText.Name = "reviewReleaseAlgorithmText"
        Me.reviewReleaseAlgorithmText.ReadOnly = True
        Me.reviewReleaseAlgorithmText.Size = New System.Drawing.Size(407, 21)
        Me.reviewReleaseAlgorithmText.TabIndex = 52
        '
        'reviewReleaseAlgorithmLabel
        '
        Me.reviewReleaseAlgorithmLabel.AutoSize = True
        Me.reviewReleaseAlgorithmLabel.Location = New System.Drawing.Point(46, 127)
        Me.reviewReleaseAlgorithmLabel.Name = "reviewReleaseAlgorithmLabel"
        Me.reviewReleaseAlgorithmLabel.Size = New System.Drawing.Size(152, 13)
        Me.reviewReleaseAlgorithmLabel.TabIndex = 51
        Me.reviewReleaseAlgorithmLabel.Text = "Review release algorithm"
        '
        'ruleFutureReleaseText
        '
        Me.ruleFutureReleaseText.Location = New System.Drawing.Point(206, 97)
        Me.ruleFutureReleaseText.Name = "ruleFutureReleaseText"
        Me.ruleFutureReleaseText.ReadOnly = True
        Me.ruleFutureReleaseText.Size = New System.Drawing.Size(407, 21)
        Me.ruleFutureReleaseText.TabIndex = 50
        '
        'ruleFutureReleaseLabel
        '
        Me.ruleFutureReleaseLabel.AutoSize = True
        Me.ruleFutureReleaseLabel.Location = New System.Drawing.Point(82, 100)
        Me.ruleFutureReleaseLabel.Name = "ruleFutureReleaseLabel"
        Me.ruleFutureReleaseLabel.Size = New System.Drawing.Size(116, 13)
        Me.ruleFutureReleaseLabel.TabIndex = 49
        Me.ruleFutureReleaseLabel.Text = "Rule future release"
        '
        'initialMaxComputeTransactionText
        '
        Me.initialMaxComputeTransactionText.Location = New System.Drawing.Point(206, 70)
        Me.initialMaxComputeTransactionText.Name = "initialMaxComputeTransactionText"
        Me.initialMaxComputeTransactionText.ReadOnly = True
        Me.initialMaxComputeTransactionText.Size = New System.Drawing.Size(407, 21)
        Me.initialMaxComputeTransactionText.TabIndex = 48
        '
        'numberBlockInVolumeText
        '
        Me.numberBlockInVolumeText.Location = New System.Drawing.Point(206, 43)
        Me.numberBlockInVolumeText.Name = "numberBlockInVolumeText"
        Me.numberBlockInVolumeText.ReadOnly = True
        Me.numberBlockInVolumeText.Size = New System.Drawing.Size(407, 21)
        Me.numberBlockInVolumeText.TabIndex = 46
        '
        'blockChainSizeFrequencyText
        '
        Me.blockChainSizeFrequencyText.Location = New System.Drawing.Point(206, 16)
        Me.blockChainSizeFrequencyText.Name = "blockChainSizeFrequencyText"
        Me.blockChainSizeFrequencyText.ReadOnly = True
        Me.blockChainSizeFrequencyText.Size = New System.Drawing.Size(407, 21)
        Me.blockChainSizeFrequencyText.TabIndex = 44
        '
        'initialMaxComputeTransactionLabel
        '
        Me.initialMaxComputeTransactionLabel.AutoSize = True
        Me.initialMaxComputeTransactionLabel.Location = New System.Drawing.Point(10, 73)
        Me.initialMaxComputeTransactionLabel.Name = "initialMaxComputeTransactionLabel"
        Me.initialMaxComputeTransactionLabel.Size = New System.Drawing.Size(188, 13)
        Me.initialMaxComputeTransactionLabel.TabIndex = 47
        Me.initialMaxComputeTransactionLabel.Text = "Initial max compute transaction"
        '
        'numberBlockInVolumeLabel
        '
        Me.numberBlockInVolumeLabel.AutoSize = True
        Me.numberBlockInVolumeLabel.Location = New System.Drawing.Point(52, 46)
        Me.numberBlockInVolumeLabel.Name = "numberBlockInVolumeLabel"
        Me.numberBlockInVolumeLabel.Size = New System.Drawing.Size(146, 13)
        Me.numberBlockInVolumeLabel.TabIndex = 45
        Me.numberBlockInVolumeLabel.Text = "Number block in volume"
        '
        'blockChainSizeFrequencyLabel
        '
        Me.blockChainSizeFrequencyLabel.AutoSize = True
        Me.blockChainSizeFrequencyLabel.Location = New System.Drawing.Point(73, 19)
        Me.blockChainSizeFrequencyLabel.Name = "blockChainSizeFrequencyLabel"
        Me.blockChainSizeFrequencyLabel.Size = New System.Drawing.Size(125, 13)
        Me.blockChainSizeFrequencyLabel.TabIndex = 43
        Me.blockChainSizeFrequencyLabel.Text = "Block size frequency"
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'policyPrivacyTab
        '
        Me.policyPrivacyTab.Controls.Add(Me.privacyPolicyText)
        Me.policyPrivacyTab.Location = New System.Drawing.Point(44, 4)
        Me.policyPrivacyTab.Name = "policyPrivacyTab"
        Me.policyPrivacyTab.Size = New System.Drawing.Size(639, 312)
        Me.policyPrivacyTab.TabIndex = 5
        Me.policyPrivacyTab.Text = "Privacy Policies"
        Me.policyPrivacyTab.UseVisualStyleBackColor = True
        '
        'privacyPolicyText
        '
        Me.privacyPolicyText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.privacyPolicyText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privacyPolicyText.Location = New System.Drawing.Point(6, 6)
        Me.privacyPolicyText.Multiline = True
        Me.privacyPolicyText.Name = "privacyPolicyText"
        Me.privacyPolicyText.ReadOnly = True
        Me.privacyPolicyText.Size = New System.Drawing.Size(634, 300)
        Me.privacyPolicyText.TabIndex = 28
        '
        'generalConditionTab
        '
        Me.generalConditionTab.Controls.Add(Me.generalConditionText)
        Me.generalConditionTab.Location = New System.Drawing.Point(64, 4)
        Me.generalConditionTab.Name = "generalConditionTab"
        Me.generalConditionTab.Size = New System.Drawing.Size(619, 312)
        Me.generalConditionTab.TabIndex = 6
        Me.generalConditionTab.Text = "General Condition"
        Me.generalConditionTab.UseVisualStyleBackColor = True
        '
        'generalConditionText
        '
        Me.generalConditionText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generalConditionText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generalConditionText.Location = New System.Drawing.Point(6, 6)
        Me.generalConditionText.Multiline = True
        Me.generalConditionText.Name = "generalConditionText"
        Me.generalConditionText.ReadOnly = True
        Me.generalConditionText.Size = New System.Drawing.Size(614, 300)
        Me.generalConditionText.TabIndex = 28
        '
        'refundPlanTab
        '
        Me.refundPlanTab.Controls.Add(Me.refundPlanDataGrid)
        Me.refundPlanTab.Location = New System.Drawing.Point(64, 4)
        Me.refundPlanTab.Name = "refundPlanTab"
        Me.refundPlanTab.Size = New System.Drawing.Size(619, 312)
        Me.refundPlanTab.TabIndex = 7
        Me.refundPlanTab.Text = "Refund Plan"
        Me.refundPlanTab.UseVisualStyleBackColor = True
        '
        'refundPlanDataGrid
        '
        Me.refundPlanDataGrid.AllowUserToAddRows = False
        Me.refundPlanDataGrid.AllowUserToDeleteRows = False
        Me.refundPlanDataGrid.AllowUserToResizeColumns = False
        Me.refundPlanDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.refundPlanDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Recipient, Me.Description, Me.fixValue, Me.PercentageValue, Me.DisplayValue})
        Me.refundPlanDataGrid.Location = New System.Drawing.Point(3, 2)
        Me.refundPlanDataGrid.MultiSelect = False
        Me.refundPlanDataGrid.Name = "refundPlanDataGrid"
        Me.refundPlanDataGrid.ReadOnly = True
        Me.refundPlanDataGrid.RowHeadersVisible = False
        Me.refundPlanDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.refundPlanDataGrid.Size = New System.Drawing.Size(612, 307)
        Me.refundPlanDataGrid.TabIndex = 2
        '
        'Recipient
        '
        Me.Recipient.HeaderText = "Recipient"
        Me.Recipient.Name = "Recipient"
        Me.Recipient.ReadOnly = True
        Me.Recipient.Visible = False
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 400
        '
        'fixValue
        '
        Me.fixValue.HeaderText = "Fix Value"
        Me.fixValue.Name = "fixValue"
        Me.fixValue.ReadOnly = True
        Me.fixValue.Visible = False
        '
        'PercentageValue
        '
        Me.PercentageValue.HeaderText = "Percentage Value"
        Me.PercentageValue.Name = "PercentageValue"
        Me.PercentageValue.ReadOnly = True
        Me.PercentageValue.Visible = False
        '
        'DisplayValue
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DisplayValue.DefaultCellStyle = DataGridViewCellStyle1
        Me.DisplayValue.HeaderText = "Value"
        Me.DisplayValue.Name = "DisplayValue"
        Me.DisplayValue.ReadOnly = True
        Me.DisplayValue.Width = 150
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(698, 383)
        Me.Controls.Add(Me.mainTab)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(714, 422)
        Me.MinimumSize = New System.Drawing.Size(714, 422)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service Chain Administration Client - Crypto Hide Coin DTN"
        Me.mainTab.ResumeLayout(False)
        Me.connectionTab.ResumeLayout(False)
        Me.localPathAndDataPortNumberFrame.ResumeLayout(False)
        Me.localPathAndDataPortNumberFrame.PerformLayout()
        Me.adminServiceConnectionGroup.ResumeLayout(False)
        Me.adminServiceConnectionGroup.PerformLayout()
        Me.supportedProtocolsTab.ResumeLayout(False)
        Me.infoStatusNetwork.ResumeLayout(False)
        Me.infoStatusNetwork.PerformLayout()
        Me.primaryChainTab.ResumeLayout(False)
        Me.primaryTab.ResumeLayout(False)
        Me.informationBaseTab.ResumeLayout(False)
        Me.informationBaseTab.PerformLayout()
        Me.whitePaperTab.ResumeLayout(False)
        Me.whitePaperTab.PerformLayout()
        Me.yellowPaperTab.ResumeLayout(False)
        Me.yellowPaperTab.PerformLayout()
        Me.primaryAssetTab.ResumeLayout(False)
        Me.primaryAssetTab.PerformLayout()
        Me.transactionChainSettings.ResumeLayout(False)
        Me.transactionChainSettings.PerformLayout()
        Me.policyPrivacyTab.ResumeLayout(False)
        Me.policyPrivacyTab.PerformLayout()
        Me.generalConditionTab.ResumeLayout(False)
        Me.generalConditionTab.PerformLayout()
        Me.refundPlanTab.ResumeLayout(False)
        CType(Me.refundPlanDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTab As TabControl
    Friend WithEvents connectionTab As TabPage
    Friend WithEvents localPathAndDataPortNumberFrame As GroupBox
    Friend WithEvents browseLocalPathButton As Button
    Friend WithEvents localPathDataText As TextBox
    Friend WithEvents adminServiceConnectionGroup As GroupBox
    Friend WithEvents supportedProtocolsTab As TabPage
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents infoStatusNetwork As GroupBox
    Friend WithEvents protocolList As TextBox
    Friend WithEvents refreshSupportedProtocols As Button
    Friend WithEvents configurationLabel As Label
    Friend WithEvents configurationNameCombo As ComboBox
    Friend WithEvents saveConfigurationButton As Button
    Friend WithEvents deleteConfigurationButton As Button
    Friend WithEvents newConfigurationButton As Button
    Friend WithEvents serviceIDText As TextBox
    Friend WithEvents serviceUUID As Label
    Friend WithEvents primaryChainTab As TabPage
    Friend WithEvents listLabel As Label
    Friend WithEvents responseProtocolTimeText As TextBox
    Friend WithEvents responseProtocolTimeLabel As Label
    Friend WithEvents requestProtocolTimeText As TextBox
    Friend WithEvents requestProtocolTimeLabel As Label
    Friend WithEvents requesterWalletAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents primaryTab As TabControl
    Friend WithEvents informationBaseTab As TabPage
    Friend WithEvents genesisPublicAddressText As TextBox
    Friend WithEvents networkCreationDatePlatformText As TextBox
    Friend WithEvents responsePlatformInformationTimeText As TextBox
    Friend WithEvents requestPlatformInformationText As TextBox
    Friend WithEvents namePlatformText As TextBox
    Friend WithEvents genesiPublicAddressLabel As Label
    Friend WithEvents networkCreationDateLabel As Label
    Friend WithEvents responseMonitorTimeLabel As Label
    Friend WithEvents requestMonitorTimeLabel As Label
    Friend WithEvents servicePositionLabel As Label
    Friend WithEvents whitePaperTab As TabPage
    Friend WithEvents whitePaperText As TextBox
    Friend WithEvents serviceUrlProtocol As CHCSupportUIControls.UrlProtocol
    Friend WithEvents yellowPaperTab As TabPage
    Friend WithEvents yellowPaperText As TextBox
    Friend WithEvents primaryAssetTab As TabPage
    Friend WithEvents primaryAssetQtaInitialStakeText As TextBox
    Friend WithEvents primaryAssetQtaInitialStakeLabel As Label
    Friend WithEvents primaryAssetUnitNameText As TextBox
    Friend WithEvents primaryAssetUnitNameLabel As Label
    Friend WithEvents primaryAssetBurnableText As TextBox
    Friend WithEvents primaryAssetBurnableLabel As Label
    Friend WithEvents primaryAssetPreStakeText As TextBox
    Friend WithEvents primaryAssetPreStakeLabel As Label
    Friend WithEvents primaryAssetStakableText As TextBox
    Friend WithEvents primaryAssetStakableLabel As Label
    Friend WithEvents primaryAssetDigitText As TextBox
    Friend WithEvents primaryAssetDigitLabel As Label
    Friend WithEvents primaryAssetQtaTotalText As TextBox
    Friend WithEvents primaryAssetQtaTotalLabel As Label
    Friend WithEvents primaryAssetSymbolText As TextBox
    Friend WithEvents primaryAssetShortNameText As TextBox
    Friend WithEvents primaryAssetNameText As TextBox
    Friend WithEvents primaryAssetSymbolLabel As Label
    Friend WithEvents primaryAssetShortNameLabel As Label
    Friend WithEvents primaryAssetNameLabel As Label
    Friend WithEvents transactionChainSettings As TabPage
    Friend WithEvents consensusMethodText As TextBox
    Friend WithEvents consensusMethodLabel As Label
    Friend WithEvents reviewReleaseAlgorithmText As TextBox
    Friend WithEvents reviewReleaseAlgorithmLabel As Label
    Friend WithEvents ruleFutureReleaseText As TextBox
    Friend WithEvents ruleFutureReleaseLabel As Label
    Friend WithEvents initialMaxComputeTransactionText As TextBox
    Friend WithEvents numberBlockInVolumeText As TextBox
    Friend WithEvents blockChainSizeFrequencyText As TextBox
    Friend WithEvents initialMaxComputeTransactionLabel As Label
    Friend WithEvents numberBlockInVolumeLabel As Label
    Friend WithEvents blockChainSizeFrequencyLabel As Label
    Friend WithEvents policyPrivacyTab As TabPage
    Friend WithEvents privacyPolicyText As TextBox
    Friend WithEvents generalConditionTab As TabPage
    Friend WithEvents generalConditionText As TextBox
    Friend WithEvents refundPlanTab As TabPage
    Friend WithEvents refundPlanDataGrid As DataGridView
    Friend WithEvents Recipient As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents fixValue As DataGridViewTextBoxColumn
    Friend WithEvents PercentageValue As DataGridViewTextBoxColumn
    Friend WithEvents DisplayValue As DataGridViewTextBoxColumn
End Class
