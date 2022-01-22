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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.connectionTab = New System.Windows.Forms.TabPage()
        Me.connectServiceButton = New System.Windows.Forms.Button()
        Me.localPathAndDataPortNumberFrame = New System.Windows.Forms.GroupBox()
        Me.deleteConfigurationButton = New System.Windows.Forms.Button()
        Me.newConfigurationButton = New System.Windows.Forms.Button()
        Me.saveConfigurationButton = New System.Windows.Forms.Button()
        Me.configurationLabel = New System.Windows.Forms.Label()
        Me.configurationNameCombo = New System.Windows.Forms.ComboBox()
        Me.browseLocalPathButton = New System.Windows.Forms.Button()
        Me.localPathDataText = New System.Windows.Forms.TextBox()
        Me.adminServiceConnectionGroup = New System.Windows.Forms.GroupBox()
        Me.serviceIDText = New System.Windows.Forms.TextBox()
        Me.serviceUUID = New System.Windows.Forms.Label()
        Me.adminWalletAddress = New CHCSupportUIControls.WalletAddress()
        Me.serviceCertificate = New CHCSupportUIControls.Certificate()
        Me.serviceUrlProtocol = New CHCSupportUIControls.UrlProtocol()
        Me.generalTab = New System.Windows.Forms.TabPage()
        Me.commondGroup = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.infoGroup = New System.Windows.Forms.GroupBox()
        Me.unitMeasureLabel = New System.Windows.Forms.Label()
        Me.addressIP = New System.Windows.Forms.TextBox()
        Me.addressIPLabel = New System.Windows.Forms.Label()
        Me.netWorkRefement = New System.Windows.Forms.TextBox()
        Me.netWorkReferementLabel = New System.Windows.Forms.Label()
        Me.netWorkName = New System.Windows.Forms.TextBox()
        Me.netWorkNameLabel = New System.Windows.Forms.Label()
        Me.chainName = New System.Windows.Forms.TextBox()
        Me.chainNameLabel = New System.Windows.Forms.Label()
        Me.publicCompleteAddress = New System.Windows.Forms.TextBox()
        Me.completeAddressLabel = New System.Windows.Forms.Label()
        Me.responseTime = New System.Windows.Forms.TextBox()
        Me.responseTimeLabel = New System.Windows.Forms.Label()
        Me.softwareRelease = New System.Windows.Forms.TextBox()
        Me.softwareReleaseLabel = New System.Windows.Forms.Label()
        Me.platformHost = New System.Windows.Forms.TextBox()
        Me.platformHostLabel = New System.Windows.Forms.Label()
        Me.identityWalletAddress = New System.Windows.Forms.TextBox()
        Me.publicWalletAddressLabel = New System.Windows.Forms.Label()
        Me.currentStatus = New System.Windows.Forms.TextBox()
        Me.currentStatusLabel = New System.Windows.Forms.Label()
        Me.refreshInformationlButton = New System.Windows.Forms.Button()
        Me.supportedProtocolsTab = New System.Windows.Forms.TabPage()
        Me.infoStatusNetwork = New System.Windows.Forms.GroupBox()
        Me.listLabel = New System.Windows.Forms.Label()
        Me.responseProtocolTimeText = New System.Windows.Forms.TextBox()
        Me.responseProtocolTimeLabel = New System.Windows.Forms.Label()
        Me.requestProtocolTimeText = New System.Windows.Forms.TextBox()
        Me.requestProtocolTimeLabel = New System.Windows.Forms.Label()
        Me.protocolList = New System.Windows.Forms.TextBox()
        Me.refreshSupportedProtocols = New System.Windows.Forms.Button()
        Me.monitorTab = New System.Windows.Forms.TabPage()
        Me.secondaryTab = New System.Windows.Forms.TabControl()
        Me.monitorGeneralTab = New System.Windows.Forms.TabPage()
        Me.cancelOperationText = New System.Windows.Forms.TextBox()
        Me.cancelOperationLabel = New System.Windows.Forms.Label()
        Me.currentOperationText = New System.Windows.Forms.TextBox()
        Me.currentOperationLabel = New System.Windows.Forms.Label()
        Me.responseMonitorTimeText = New System.Windows.Forms.TextBox()
        Me.responseMonitorTimeLabel = New System.Windows.Forms.Label()
        Me.requestMonitorTimeText = New System.Windows.Forms.TextBox()
        Me.requestMonitorTimeLabel = New System.Windows.Forms.Label()
        Me.servicePositionText = New System.Windows.Forms.TextBox()
        Me.servicePositionLabel = New System.Windows.Forms.Label()
        Me.monitorActionTab = New System.Windows.Forms.TabPage()
        Me.codeErrorText = New System.Windows.Forms.TextBox()
        Me.codeErrorLabel = New System.Windows.Forms.Label()
        Me.descriptionErrorText = New System.Windows.Forms.TextBox()
        Me.descriptionErrorLabel = New System.Windows.Forms.Label()
        Me.codeActionText = New System.Windows.Forms.TextBox()
        Me.codeActionLabel = New System.Windows.Forms.Label()
        Me.descriptionActionText = New System.Windows.Forms.TextBox()
        Me.descriptionActionLabel = New System.Windows.Forms.Label()
        Me.monitorComponentTab = New System.Windows.Forms.TabPage()
        Me.nodeListText = New System.Windows.Forms.TextBox()
        Me.nodeListLabel = New System.Windows.Forms.Label()
        Me.currentWorkText = New System.Windows.Forms.TextBox()
        Me.currentWorkLabel = New System.Windows.Forms.Label()
        Me.stateText = New System.Windows.Forms.TextBox()
        Me.stateLabel = New System.Windows.Forms.Label()
        Me.storageText = New System.Windows.Forms.TextBox()
        Me.storageLabel = New System.Windows.Forms.Label()
        Me.previousVolumeText = New System.Windows.Forms.TextBox()
        Me.previousVolumeLabel = New System.Windows.Forms.Label()
        Me.refreshDataMonitor = New System.Windows.Forms.Button()
        Me.commandPage = New System.Windows.Forms.TabPage()
        Me.requestNetworkDisconnect = New System.Windows.Forms.Button()
        Me.abortCurrentCommandButton = New System.Windows.Forms.Button()
        Me.requestNetworkConnectionButton = New System.Windows.Forms.Button()
        Me.synchroNetworkButton = New System.Windows.Forms.Button()
        Me.cleanLocalDataButton = New System.Windows.Forms.Button()
        Me.checkTrustedNodeListButton = New System.Windows.Forms.Button()
        Me.resumeSystemFirstNodeButton = New System.Windows.Forms.Button()
        Me.buildNetworkButton = New System.Windows.Forms.Button()
        Me.setTrustedIPAddressButton = New System.Windows.Forms.Button()
        Me.downloadHistoryButton = New System.Windows.Forms.Button()
        Me.rebuildStateButton = New System.Windows.Forms.Button()
        Me.verifyButton = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.mainTab.SuspendLayout()
        Me.connectionTab.SuspendLayout()
        Me.localPathAndDataPortNumberFrame.SuspendLayout()
        Me.adminServiceConnectionGroup.SuspendLayout()
        Me.generalTab.SuspendLayout()
        Me.commondGroup.SuspendLayout()
        Me.infoGroup.SuspendLayout()
        Me.supportedProtocolsTab.SuspendLayout()
        Me.infoStatusNetwork.SuspendLayout()
        Me.monitorTab.SuspendLayout()
        Me.secondaryTab.SuspendLayout()
        Me.monitorGeneralTab.SuspendLayout()
        Me.monitorActionTab.SuspendLayout()
        Me.monitorComponentTab.SuspendLayout()
        Me.commandPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainTab
        '
        Me.mainTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTab.Controls.Add(Me.connectionTab)
        Me.mainTab.Controls.Add(Me.generalTab)
        Me.mainTab.Controls.Add(Me.supportedProtocolsTab)
        Me.mainTab.Controls.Add(Me.monitorTab)
        Me.mainTab.Controls.Add(Me.commandPage)
        Me.mainTab.Location = New System.Drawing.Point(2, 2)
        Me.mainTab.Multiline = True
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(695, 384)
        Me.mainTab.TabIndex = 0
        '
        'connectionTab
        '
        Me.connectionTab.Controls.Add(Me.connectServiceButton)
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
        'connectServiceButton
        '
        Me.connectServiceButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.connectServiceButton.Enabled = False
        Me.connectServiceButton.Location = New System.Drawing.Point(541, 294)
        Me.connectServiceButton.Name = "connectServiceButton"
        Me.connectServiceButton.Size = New System.Drawing.Size(135, 49)
        Me.connectServiceButton.TabIndex = 14
        Me.connectServiceButton.Text = "Connect Service >>"
        Me.connectServiceButton.UseVisualStyleBackColor = True
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
        Me.adminServiceConnectionGroup.Controls.Add(Me.serviceIDText)
        Me.adminServiceConnectionGroup.Controls.Add(Me.serviceUUID)
        Me.adminServiceConnectionGroup.Controls.Add(Me.adminWalletAddress)
        Me.adminServiceConnectionGroup.Controls.Add(Me.serviceCertificate)
        Me.adminServiceConnectionGroup.Controls.Add(Me.serviceUrlProtocol)
        Me.adminServiceConnectionGroup.Location = New System.Drawing.Point(8, 108)
        Me.adminServiceConnectionGroup.Name = "adminServiceConnectionGroup"
        Me.adminServiceConnectionGroup.Size = New System.Drawing.Size(668, 169)
        Me.adminServiceConnectionGroup.TabIndex = 1
        Me.adminServiceConnectionGroup.TabStop = False
        Me.adminServiceConnectionGroup.Text = "Service Connections"
        '
        'serviceIDText
        '
        Me.serviceIDText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceIDText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceIDText.Location = New System.Drawing.Point(145, 54)
        Me.serviceIDText.Name = "serviceIDText"
        Me.serviceIDText.Size = New System.Drawing.Size(355, 21)
        Me.serviceIDText.TabIndex = 1
        Me.serviceIDText.Text = "a232c1bd-87bd-4074-bf26-0a6909a78f1d"
        '
        'serviceUUID
        '
        Me.serviceUUID.AutoSize = True
        Me.serviceUUID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceUUID.Location = New System.Drawing.Point(69, 58)
        Me.serviceUUID.Name = "serviceUUID"
        Me.serviceUUID.Size = New System.Drawing.Size(68, 13)
        Me.serviceUUID.TabIndex = 36
        Me.serviceUUID.Text = "Service ID"
        '
        'adminWalletAddress
        '
        Me.adminWalletAddress.caption = "Admin wallet address"
        Me.adminWalletAddress.dataPath = ""
        Me.adminWalletAddress.Location = New System.Drawing.Point(6, 112)
        Me.adminWalletAddress.Name = "adminWalletAddress"
        Me.adminWalletAddress.Size = New System.Drawing.Size(660, 51)
        Me.adminWalletAddress.TabIndex = 3
        Me.adminWalletAddress.value = ""
        '
        'serviceCertificate
        '
        Me.serviceCertificate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceCertificate.dataPath = ""
        Me.serviceCertificate.Location = New System.Drawing.Point(70, 78)
        Me.serviceCertificate.Name = "serviceCertificate"
        Me.serviceCertificate.noChange = False
        Me.serviceCertificate.serviceId = ""
        Me.serviceCertificate.Size = New System.Drawing.Size(598, 30)
        Me.serviceCertificate.TabIndex = 2
        Me.serviceCertificate.urlService = ""
        Me.serviceCertificate.value = ""
        '
        'serviceUrlProtocol
        '
        Me.serviceUrlProtocol.address = ""
        Me.serviceUrlProtocol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceUrlProtocol.executeCommand = False
        Me.serviceUrlProtocol.Location = New System.Drawing.Point(26, 20)
        Me.serviceUrlProtocol.MinimumSize = New System.Drawing.Size(0, 29)
        Me.serviceUrlProtocol.Name = "serviceUrlProtocol"
        Me.serviceUrlProtocol.serviceId = ""
        Me.serviceUrlProtocol.Size = New System.Drawing.Size(642, 29)
        Me.serviceUrlProtocol.TabIndex = 0
        Me.serviceUrlProtocol.useSecure = False
        '
        'generalTab
        '
        Me.generalTab.Controls.Add(Me.commondGroup)
        Me.generalTab.Controls.Add(Me.infoGroup)
        Me.generalTab.Controls.Add(Me.refreshInformationlButton)
        Me.generalTab.Location = New System.Drawing.Point(4, 22)
        Me.generalTab.Name = "generalTab"
        Me.generalTab.Padding = New System.Windows.Forms.Padding(3)
        Me.generalTab.Size = New System.Drawing.Size(687, 358)
        Me.generalTab.TabIndex = 1
        Me.generalTab.Text = "Peer"
        Me.generalTab.UseVisualStyleBackColor = True
        '
        'commondGroup
        '
        Me.commondGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.commondGroup.Controls.Add(Me.Button7)
        Me.commondGroup.Controls.Add(Me.Button6)
        Me.commondGroup.Controls.Add(Me.Button5)
        Me.commondGroup.Controls.Add(Me.Button4)
        Me.commondGroup.Controls.Add(Me.Button3)
        Me.commondGroup.Controls.Add(Me.Button2)
        Me.commondGroup.Controls.Add(Me.Button1)
        Me.commondGroup.Location = New System.Drawing.Point(7, 383)
        Me.commondGroup.Name = "commondGroup"
        Me.commondGroup.Size = New System.Drawing.Size(671, 106)
        Me.commondGroup.TabIndex = 2
        Me.commondGroup.TabStop = False
        Me.commondGroup.Text = "Commands"
        Me.commondGroup.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(558, 38)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(92, 50)
        Me.Button7.TabIndex = 14
        Me.Button7.Text = "Votes Management"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(466, 38)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(92, 50)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Profiler"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(374, 38)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(92, 50)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Statistics"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(282, 38)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(92, 50)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Update Management"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(190, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 50)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "View Counters"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(98, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 50)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "View Events"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 50)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "View Logs"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'infoGroup
        '
        Me.infoGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoGroup.Controls.Add(Me.unitMeasureLabel)
        Me.infoGroup.Controls.Add(Me.addressIP)
        Me.infoGroup.Controls.Add(Me.addressIPLabel)
        Me.infoGroup.Controls.Add(Me.netWorkRefement)
        Me.infoGroup.Controls.Add(Me.netWorkReferementLabel)
        Me.infoGroup.Controls.Add(Me.netWorkName)
        Me.infoGroup.Controls.Add(Me.netWorkNameLabel)
        Me.infoGroup.Controls.Add(Me.chainName)
        Me.infoGroup.Controls.Add(Me.chainNameLabel)
        Me.infoGroup.Controls.Add(Me.publicCompleteAddress)
        Me.infoGroup.Controls.Add(Me.completeAddressLabel)
        Me.infoGroup.Controls.Add(Me.responseTime)
        Me.infoGroup.Controls.Add(Me.responseTimeLabel)
        Me.infoGroup.Controls.Add(Me.softwareRelease)
        Me.infoGroup.Controls.Add(Me.softwareReleaseLabel)
        Me.infoGroup.Controls.Add(Me.platformHost)
        Me.infoGroup.Controls.Add(Me.platformHostLabel)
        Me.infoGroup.Controls.Add(Me.identityWalletAddress)
        Me.infoGroup.Controls.Add(Me.publicWalletAddressLabel)
        Me.infoGroup.Controls.Add(Me.currentStatus)
        Me.infoGroup.Controls.Add(Me.currentStatusLabel)
        Me.infoGroup.Location = New System.Drawing.Point(7, 43)
        Me.infoGroup.Name = "infoGroup"
        Me.infoGroup.Size = New System.Drawing.Size(673, 309)
        Me.infoGroup.TabIndex = 1
        Me.infoGroup.TabStop = False
        Me.infoGroup.Text = "Info Peer"
        '
        'unitMeasureLabel
        '
        Me.unitMeasureLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.unitMeasureLabel.AutoSize = True
        Me.unitMeasureLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitMeasureLabel.Location = New System.Drawing.Point(278, 286)
        Me.unitMeasureLabel.Name = "unitMeasureLabel"
        Me.unitMeasureLabel.Size = New System.Drawing.Size(38, 13)
        Me.unitMeasureLabel.TabIndex = 31
        Me.unitMeasureLabel.Text = "(ms.)"
        '
        'addressIP
        '
        Me.addressIP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addressIP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addressIP.Location = New System.Drawing.Point(165, 226)
        Me.addressIP.Name = "addressIP"
        Me.addressIP.ReadOnly = True
        Me.addressIP.Size = New System.Drawing.Size(482, 21)
        Me.addressIP.TabIndex = 29
        '
        'addressIPLabel
        '
        Me.addressIPLabel.AutoSize = True
        Me.addressIPLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addressIPLabel.Location = New System.Drawing.Point(90, 230)
        Me.addressIPLabel.Name = "addressIPLabel"
        Me.addressIPLabel.Size = New System.Drawing.Size(69, 13)
        Me.addressIPLabel.TabIndex = 30
        Me.addressIPLabel.Text = "Address IP"
        '
        'netWorkRefement
        '
        Me.netWorkRefement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.netWorkRefement.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkRefement.Location = New System.Drawing.Point(165, 91)
        Me.netWorkRefement.Name = "netWorkRefement"
        Me.netWorkRefement.ReadOnly = True
        Me.netWorkRefement.Size = New System.Drawing.Size(482, 21)
        Me.netWorkRefement.TabIndex = 27
        '
        'netWorkReferementLabel
        '
        Me.netWorkReferementLabel.AutoSize = True
        Me.netWorkReferementLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkReferementLabel.Location = New System.Drawing.Point(34, 94)
        Me.netWorkReferementLabel.Name = "netWorkReferementLabel"
        Me.netWorkReferementLabel.Size = New System.Drawing.Size(125, 13)
        Me.netWorkReferementLabel.TabIndex = 28
        Me.netWorkReferementLabel.Text = "Network Referement"
        '
        'netWorkName
        '
        Me.netWorkName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.netWorkName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkName.Location = New System.Drawing.Point(165, 64)
        Me.netWorkName.Name = "netWorkName"
        Me.netWorkName.ReadOnly = True
        Me.netWorkName.Size = New System.Drawing.Size(482, 21)
        Me.netWorkName.TabIndex = 25
        '
        'netWorkNameLabel
        '
        Me.netWorkNameLabel.AutoSize = True
        Me.netWorkNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkNameLabel.Location = New System.Drawing.Point(68, 67)
        Me.netWorkNameLabel.Name = "netWorkNameLabel"
        Me.netWorkNameLabel.Size = New System.Drawing.Size(91, 13)
        Me.netWorkNameLabel.TabIndex = 26
        Me.netWorkNameLabel.Text = "Network Name"
        '
        'chainName
        '
        Me.chainName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chainName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainName.Location = New System.Drawing.Point(165, 145)
        Me.chainName.Name = "chainName"
        Me.chainName.ReadOnly = True
        Me.chainName.Size = New System.Drawing.Size(482, 21)
        Me.chainName.TabIndex = 23
        '
        'chainNameLabel
        '
        Me.chainNameLabel.AutoSize = True
        Me.chainNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainNameLabel.Location = New System.Drawing.Point(82, 149)
        Me.chainNameLabel.Name = "chainNameLabel"
        Me.chainNameLabel.Size = New System.Drawing.Size(77, 13)
        Me.chainNameLabel.TabIndex = 24
        Me.chainNameLabel.Text = "Chain Name"
        '
        'publicCompleteAddress
        '
        Me.publicCompleteAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicCompleteAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicCompleteAddress.Location = New System.Drawing.Point(165, 253)
        Me.publicCompleteAddress.Name = "publicCompleteAddress"
        Me.publicCompleteAddress.ReadOnly = True
        Me.publicCompleteAddress.Size = New System.Drawing.Size(482, 21)
        Me.publicCompleteAddress.TabIndex = 21
        '
        'completeAddressLabel
        '
        Me.completeAddressLabel.AutoSize = True
        Me.completeAddressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.completeAddressLabel.Location = New System.Drawing.Point(106, 257)
        Me.completeAddressLabel.Name = "completeAddressLabel"
        Me.completeAddressLabel.Size = New System.Drawing.Size(53, 13)
        Me.completeAddressLabel.TabIndex = 22
        Me.completeAddressLabel.Text = "Address"
        '
        'responseTime
        '
        Me.responseTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responseTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTime.Location = New System.Drawing.Point(165, 282)
        Me.responseTime.Name = "responseTime"
        Me.responseTime.ReadOnly = True
        Me.responseTime.Size = New System.Drawing.Size(107, 21)
        Me.responseTime.TabIndex = 10
        '
        'responseTimeLabel
        '
        Me.responseTimeLabel.AutoSize = True
        Me.responseTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTimeLabel.Location = New System.Drawing.Point(65, 286)
        Me.responseTimeLabel.Name = "responseTimeLabel"
        Me.responseTimeLabel.Size = New System.Drawing.Size(94, 13)
        Me.responseTimeLabel.TabIndex = 20
        Me.responseTimeLabel.Text = "Response Time"
        '
        'softwareRelease
        '
        Me.softwareRelease.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.softwareRelease.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.softwareRelease.Location = New System.Drawing.Point(165, 199)
        Me.softwareRelease.Name = "softwareRelease"
        Me.softwareRelease.ReadOnly = True
        Me.softwareRelease.Size = New System.Drawing.Size(482, 21)
        Me.softwareRelease.TabIndex = 7
        '
        'softwareReleaseLabel
        '
        Me.softwareReleaseLabel.AutoSize = True
        Me.softwareReleaseLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.softwareReleaseLabel.Location = New System.Drawing.Point(55, 203)
        Me.softwareReleaseLabel.Name = "softwareReleaseLabel"
        Me.softwareReleaseLabel.Size = New System.Drawing.Size(104, 13)
        Me.softwareReleaseLabel.TabIndex = 14
        Me.softwareReleaseLabel.Text = "Software release"
        '
        'platformHost
        '
        Me.platformHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.platformHost.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.platformHost.Location = New System.Drawing.Point(165, 172)
        Me.platformHost.Name = "platformHost"
        Me.platformHost.ReadOnly = True
        Me.platformHost.Size = New System.Drawing.Size(482, 21)
        Me.platformHost.TabIndex = 6
        '
        'platformHostLabel
        '
        Me.platformHostLabel.AutoSize = True
        Me.platformHostLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.platformHostLabel.Location = New System.Drawing.Point(76, 176)
        Me.platformHostLabel.Name = "platformHostLabel"
        Me.platformHostLabel.Size = New System.Drawing.Size(83, 13)
        Me.platformHostLabel.TabIndex = 12
        Me.platformHostLabel.Text = "Platform host"
        '
        'identityWalletAddress
        '
        Me.identityWalletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.identityWalletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.identityWalletAddress.Location = New System.Drawing.Point(165, 19)
        Me.identityWalletAddress.Multiline = True
        Me.identityWalletAddress.Name = "identityWalletAddress"
        Me.identityWalletAddress.ReadOnly = True
        Me.identityWalletAddress.Size = New System.Drawing.Size(482, 39)
        Me.identityWalletAddress.TabIndex = 4
        '
        'publicWalletAddressLabel
        '
        Me.publicWalletAddressLabel.AutoSize = True
        Me.publicWalletAddressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicWalletAddressLabel.Location = New System.Drawing.Point(20, 23)
        Me.publicWalletAddressLabel.Name = "publicWalletAddressLabel"
        Me.publicWalletAddressLabel.Size = New System.Drawing.Size(139, 13)
        Me.publicWalletAddressLabel.TabIndex = 8
        Me.publicWalletAddressLabel.Text = "Identity Wallet Address"
        '
        'currentStatus
        '
        Me.currentStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentStatus.Location = New System.Drawing.Point(165, 118)
        Me.currentStatus.Name = "currentStatus"
        Me.currentStatus.ReadOnly = True
        Me.currentStatus.Size = New System.Drawing.Size(482, 21)
        Me.currentStatus.TabIndex = 0
        '
        'currentStatusLabel
        '
        Me.currentStatusLabel.AutoSize = True
        Me.currentStatusLabel.Location = New System.Drawing.Point(68, 123)
        Me.currentStatusLabel.Name = "currentStatusLabel"
        Me.currentStatusLabel.Size = New System.Drawing.Size(91, 13)
        Me.currentStatusLabel.TabIndex = 0
        Me.currentStatusLabel.Text = "Current Status"
        '
        'refreshInformationlButton
        '
        Me.refreshInformationlButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshInformationlButton.Location = New System.Drawing.Point(605, 6)
        Me.refreshInformationlButton.Name = "refreshInformationlButton"
        Me.refreshInformationlButton.Size = New System.Drawing.Size(75, 36)
        Me.refreshInformationlButton.TabIndex = 0
        Me.refreshInformationlButton.Text = "Refresh"
        Me.refreshInformationlButton.UseVisualStyleBackColor = True
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
        'monitorTab
        '
        Me.monitorTab.Controls.Add(Me.secondaryTab)
        Me.monitorTab.Controls.Add(Me.refreshDataMonitor)
        Me.monitorTab.Location = New System.Drawing.Point(4, 22)
        Me.monitorTab.Name = "monitorTab"
        Me.monitorTab.Size = New System.Drawing.Size(687, 358)
        Me.monitorTab.TabIndex = 3
        Me.monitorTab.Text = "Monitor"
        Me.monitorTab.UseVisualStyleBackColor = True
        '
        'secondaryTab
        '
        Me.secondaryTab.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.secondaryTab.Controls.Add(Me.monitorGeneralTab)
        Me.secondaryTab.Controls.Add(Me.monitorActionTab)
        Me.secondaryTab.Controls.Add(Me.monitorComponentTab)
        Me.secondaryTab.Location = New System.Drawing.Point(13, 48)
        Me.secondaryTab.Multiline = True
        Me.secondaryTab.Name = "secondaryTab"
        Me.secondaryTab.SelectedIndex = 0
        Me.secondaryTab.Size = New System.Drawing.Size(667, 307)
        Me.secondaryTab.TabIndex = 26
        '
        'monitorGeneralTab
        '
        Me.monitorGeneralTab.Controls.Add(Me.cancelOperationText)
        Me.monitorGeneralTab.Controls.Add(Me.cancelOperationLabel)
        Me.monitorGeneralTab.Controls.Add(Me.currentOperationText)
        Me.monitorGeneralTab.Controls.Add(Me.currentOperationLabel)
        Me.monitorGeneralTab.Controls.Add(Me.responseMonitorTimeText)
        Me.monitorGeneralTab.Controls.Add(Me.responseMonitorTimeLabel)
        Me.monitorGeneralTab.Controls.Add(Me.requestMonitorTimeText)
        Me.monitorGeneralTab.Controls.Add(Me.requestMonitorTimeLabel)
        Me.monitorGeneralTab.Controls.Add(Me.servicePositionText)
        Me.monitorGeneralTab.Controls.Add(Me.servicePositionLabel)
        Me.monitorGeneralTab.Location = New System.Drawing.Point(24, 4)
        Me.monitorGeneralTab.Name = "monitorGeneralTab"
        Me.monitorGeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.monitorGeneralTab.Size = New System.Drawing.Size(639, 299)
        Me.monitorGeneralTab.TabIndex = 0
        Me.monitorGeneralTab.Text = "General"
        Me.monitorGeneralTab.UseVisualStyleBackColor = True
        '
        'cancelOperationText
        '
        Me.cancelOperationText.Location = New System.Drawing.Point(127, 69)
        Me.cancelOperationText.Name = "cancelOperationText"
        Me.cancelOperationText.ReadOnly = True
        Me.cancelOperationText.Size = New System.Drawing.Size(194, 21)
        Me.cancelOperationText.TabIndex = 32
        '
        'cancelOperationLabel
        '
        Me.cancelOperationLabel.AutoSize = True
        Me.cancelOperationLabel.Location = New System.Drawing.Point(14, 72)
        Me.cancelOperationLabel.Name = "cancelOperationLabel"
        Me.cancelOperationLabel.Size = New System.Drawing.Size(106, 13)
        Me.cancelOperationLabel.TabIndex = 31
        Me.cancelOperationLabel.Text = "Cancel Operation"
        '
        'currentOperationText
        '
        Me.currentOperationText.Location = New System.Drawing.Point(127, 42)
        Me.currentOperationText.Name = "currentOperationText"
        Me.currentOperationText.ReadOnly = True
        Me.currentOperationText.Size = New System.Drawing.Size(194, 21)
        Me.currentOperationText.TabIndex = 30
        '
        'currentOperationLabel
        '
        Me.currentOperationLabel.AutoSize = True
        Me.currentOperationLabel.Location = New System.Drawing.Point(10, 45)
        Me.currentOperationLabel.Name = "currentOperationLabel"
        Me.currentOperationLabel.Size = New System.Drawing.Size(111, 13)
        Me.currentOperationLabel.TabIndex = 29
        Me.currentOperationLabel.Text = "Current Operation"
        '
        'responseMonitorTimeText
        '
        Me.responseMonitorTimeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responseMonitorTimeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseMonitorTimeText.Location = New System.Drawing.Point(126, 148)
        Me.responseMonitorTimeText.Name = "responseMonitorTimeText"
        Me.responseMonitorTimeText.ReadOnly = True
        Me.responseMonitorTimeText.Size = New System.Drawing.Size(203, 21)
        Me.responseMonitorTimeText.TabIndex = 26
        '
        'responseMonitorTimeLabel
        '
        Me.responseMonitorTimeLabel.AutoSize = True
        Me.responseMonitorTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseMonitorTimeLabel.Location = New System.Drawing.Point(26, 151)
        Me.responseMonitorTimeLabel.Name = "responseMonitorTimeLabel"
        Me.responseMonitorTimeLabel.Size = New System.Drawing.Size(94, 13)
        Me.responseMonitorTimeLabel.TabIndex = 28
        Me.responseMonitorTimeLabel.Text = "Response Time"
        '
        'requestMonitorTimeText
        '
        Me.requestMonitorTimeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestMonitorTimeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestMonitorTimeText.Location = New System.Drawing.Point(126, 121)
        Me.requestMonitorTimeText.Name = "requestMonitorTimeText"
        Me.requestMonitorTimeText.ReadOnly = True
        Me.requestMonitorTimeText.Size = New System.Drawing.Size(203, 21)
        Me.requestMonitorTimeText.TabIndex = 25
        '
        'requestMonitorTimeLabel
        '
        Me.requestMonitorTimeLabel.AutoSize = True
        Me.requestMonitorTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestMonitorTimeLabel.Location = New System.Drawing.Point(35, 124)
        Me.requestMonitorTimeLabel.Name = "requestMonitorTimeLabel"
        Me.requestMonitorTimeLabel.Size = New System.Drawing.Size(85, 13)
        Me.requestMonitorTimeLabel.TabIndex = 27
        Me.requestMonitorTimeLabel.Text = "Request Time"
        '
        'servicePositionText
        '
        Me.servicePositionText.Location = New System.Drawing.Point(127, 15)
        Me.servicePositionText.Name = "servicePositionText"
        Me.servicePositionText.ReadOnly = True
        Me.servicePositionText.Size = New System.Drawing.Size(194, 21)
        Me.servicePositionText.TabIndex = 8
        '
        'servicePositionLabel
        '
        Me.servicePositionLabel.AutoSize = True
        Me.servicePositionLabel.Location = New System.Drawing.Point(23, 18)
        Me.servicePositionLabel.Name = "servicePositionLabel"
        Me.servicePositionLabel.Size = New System.Drawing.Size(98, 13)
        Me.servicePositionLabel.TabIndex = 7
        Me.servicePositionLabel.Text = "Service Position"
        '
        'monitorActionTab
        '
        Me.monitorActionTab.Controls.Add(Me.codeErrorText)
        Me.monitorActionTab.Controls.Add(Me.codeErrorLabel)
        Me.monitorActionTab.Controls.Add(Me.descriptionErrorText)
        Me.monitorActionTab.Controls.Add(Me.descriptionErrorLabel)
        Me.monitorActionTab.Controls.Add(Me.codeActionText)
        Me.monitorActionTab.Controls.Add(Me.codeActionLabel)
        Me.monitorActionTab.Controls.Add(Me.descriptionActionText)
        Me.monitorActionTab.Controls.Add(Me.descriptionActionLabel)
        Me.monitorActionTab.Location = New System.Drawing.Point(24, 4)
        Me.monitorActionTab.Name = "monitorActionTab"
        Me.monitorActionTab.Padding = New System.Windows.Forms.Padding(3)
        Me.monitorActionTab.Size = New System.Drawing.Size(639, 299)
        Me.monitorActionTab.TabIndex = 1
        Me.monitorActionTab.Text = "Current Action"
        Me.monitorActionTab.UseVisualStyleBackColor = True
        '
        'codeErrorText
        '
        Me.codeErrorText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.codeErrorText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codeErrorText.Location = New System.Drawing.Point(127, 69)
        Me.codeErrorText.Name = "codeErrorText"
        Me.codeErrorText.ReadOnly = True
        Me.codeErrorText.Size = New System.Drawing.Size(252, 21)
        Me.codeErrorText.TabIndex = 31
        '
        'codeErrorLabel
        '
        Me.codeErrorLabel.AutoSize = True
        Me.codeErrorLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codeErrorLabel.Location = New System.Drawing.Point(51, 72)
        Me.codeErrorLabel.Name = "codeErrorLabel"
        Me.codeErrorLabel.Size = New System.Drawing.Size(70, 13)
        Me.codeErrorLabel.TabIndex = 32
        Me.codeErrorLabel.Text = "Code Error"
        '
        'descriptionErrorText
        '
        Me.descriptionErrorText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.descriptionErrorText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionErrorText.Location = New System.Drawing.Point(127, 96)
        Me.descriptionErrorText.Name = "descriptionErrorText"
        Me.descriptionErrorText.ReadOnly = True
        Me.descriptionErrorText.Size = New System.Drawing.Size(252, 21)
        Me.descriptionErrorText.TabIndex = 28
        '
        'descriptionErrorLabel
        '
        Me.descriptionErrorLabel.AutoSize = True
        Me.descriptionErrorLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionErrorLabel.Location = New System.Drawing.Point(17, 99)
        Me.descriptionErrorLabel.Name = "descriptionErrorLabel"
        Me.descriptionErrorLabel.Size = New System.Drawing.Size(104, 13)
        Me.descriptionErrorLabel.TabIndex = 30
        Me.descriptionErrorLabel.Text = "Description Error"
        '
        'codeActionText
        '
        Me.codeActionText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.codeActionText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codeActionText.Location = New System.Drawing.Point(127, 15)
        Me.codeActionText.Name = "codeActionText"
        Me.codeActionText.ReadOnly = True
        Me.codeActionText.Size = New System.Drawing.Size(252, 21)
        Me.codeActionText.TabIndex = 27
        '
        'codeActionLabel
        '
        Me.codeActionLabel.AutoSize = True
        Me.codeActionLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codeActionLabel.Location = New System.Drawing.Point(46, 18)
        Me.codeActionLabel.Name = "codeActionLabel"
        Me.codeActionLabel.Size = New System.Drawing.Size(75, 13)
        Me.codeActionLabel.TabIndex = 29
        Me.codeActionLabel.Text = "Code action"
        '
        'descriptionActionText
        '
        Me.descriptionActionText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.descriptionActionText.Location = New System.Drawing.Point(127, 42)
        Me.descriptionActionText.Name = "descriptionActionText"
        Me.descriptionActionText.ReadOnly = True
        Me.descriptionActionText.Size = New System.Drawing.Size(252, 21)
        Me.descriptionActionText.TabIndex = 25
        '
        'descriptionActionLabel
        '
        Me.descriptionActionLabel.AutoSize = True
        Me.descriptionActionLabel.Location = New System.Drawing.Point(12, 46)
        Me.descriptionActionLabel.Name = "descriptionActionLabel"
        Me.descriptionActionLabel.Size = New System.Drawing.Size(109, 13)
        Me.descriptionActionLabel.TabIndex = 26
        Me.descriptionActionLabel.Text = "Description action"
        '
        'monitorComponentTab
        '
        Me.monitorComponentTab.Controls.Add(Me.nodeListText)
        Me.monitorComponentTab.Controls.Add(Me.nodeListLabel)
        Me.monitorComponentTab.Controls.Add(Me.currentWorkText)
        Me.monitorComponentTab.Controls.Add(Me.currentWorkLabel)
        Me.monitorComponentTab.Controls.Add(Me.stateText)
        Me.monitorComponentTab.Controls.Add(Me.stateLabel)
        Me.monitorComponentTab.Controls.Add(Me.storageText)
        Me.monitorComponentTab.Controls.Add(Me.storageLabel)
        Me.monitorComponentTab.Controls.Add(Me.previousVolumeText)
        Me.monitorComponentTab.Controls.Add(Me.previousVolumeLabel)
        Me.monitorComponentTab.Location = New System.Drawing.Point(24, 4)
        Me.monitorComponentTab.Name = "monitorComponentTab"
        Me.monitorComponentTab.Size = New System.Drawing.Size(639, 299)
        Me.monitorComponentTab.TabIndex = 2
        Me.monitorComponentTab.Text = "Component"
        Me.monitorComponentTab.UseVisualStyleBackColor = True
        '
        'nodeListText
        '
        Me.nodeListText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nodeListText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nodeListText.Location = New System.Drawing.Point(127, 125)
        Me.nodeListText.Name = "nodeListText"
        Me.nodeListText.ReadOnly = True
        Me.nodeListText.Size = New System.Drawing.Size(252, 21)
        Me.nodeListText.TabIndex = 34
        '
        'nodeListLabel
        '
        Me.nodeListLabel.AutoSize = True
        Me.nodeListLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nodeListLabel.Location = New System.Drawing.Point(65, 128)
        Me.nodeListLabel.Name = "nodeListLabel"
        Me.nodeListLabel.Size = New System.Drawing.Size(56, 13)
        Me.nodeListLabel.TabIndex = 33
        Me.nodeListLabel.Text = "Node list"
        '
        'currentWorkText
        '
        Me.currentWorkText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentWorkText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentWorkText.Location = New System.Drawing.Point(127, 71)
        Me.currentWorkText.Name = "currentWorkText"
        Me.currentWorkText.ReadOnly = True
        Me.currentWorkText.Size = New System.Drawing.Size(252, 21)
        Me.currentWorkText.TabIndex = 31
        '
        'currentWorkLabel
        '
        Me.currentWorkLabel.AutoSize = True
        Me.currentWorkLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentWorkLabel.Location = New System.Drawing.Point(37, 74)
        Me.currentWorkLabel.Name = "currentWorkLabel"
        Me.currentWorkLabel.Size = New System.Drawing.Size(84, 13)
        Me.currentWorkLabel.TabIndex = 32
        Me.currentWorkLabel.Text = "Current Work"
        '
        'stateText
        '
        Me.stateText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stateText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stateText.Location = New System.Drawing.Point(127, 98)
        Me.stateText.Name = "stateText"
        Me.stateText.ReadOnly = True
        Me.stateText.Size = New System.Drawing.Size(252, 21)
        Me.stateText.TabIndex = 28
        '
        'stateLabel
        '
        Me.stateLabel.AutoSize = True
        Me.stateLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stateLabel.Location = New System.Drawing.Point(84, 101)
        Me.stateLabel.Name = "stateLabel"
        Me.stateLabel.Size = New System.Drawing.Size(37, 13)
        Me.stateLabel.TabIndex = 30
        Me.stateLabel.Text = "State"
        '
        'storageText
        '
        Me.storageText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.storageText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.storageText.Location = New System.Drawing.Point(127, 15)
        Me.storageText.Name = "storageText"
        Me.storageText.ReadOnly = True
        Me.storageText.Size = New System.Drawing.Size(252, 21)
        Me.storageText.TabIndex = 27
        '
        'storageLabel
        '
        Me.storageLabel.AutoSize = True
        Me.storageLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.storageLabel.Location = New System.Drawing.Point(69, 18)
        Me.storageLabel.Name = "storageLabel"
        Me.storageLabel.Size = New System.Drawing.Size(52, 13)
        Me.storageLabel.TabIndex = 29
        Me.storageLabel.Text = "Storage"
        '
        'previousVolumeText
        '
        Me.previousVolumeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.previousVolumeText.Location = New System.Drawing.Point(127, 42)
        Me.previousVolumeText.Name = "previousVolumeText"
        Me.previousVolumeText.ReadOnly = True
        Me.previousVolumeText.Size = New System.Drawing.Size(252, 21)
        Me.previousVolumeText.TabIndex = 25
        '
        'previousVolumeLabel
        '
        Me.previousVolumeLabel.AutoSize = True
        Me.previousVolumeLabel.Location = New System.Drawing.Point(19, 45)
        Me.previousVolumeLabel.Name = "previousVolumeLabel"
        Me.previousVolumeLabel.Size = New System.Drawing.Size(102, 13)
        Me.previousVolumeLabel.TabIndex = 26
        Me.previousVolumeLabel.Text = "Previous Volume"
        '
        'refreshDataMonitor
        '
        Me.refreshDataMonitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshDataMonitor.Location = New System.Drawing.Point(605, 6)
        Me.refreshDataMonitor.Name = "refreshDataMonitor"
        Me.refreshDataMonitor.Size = New System.Drawing.Size(75, 36)
        Me.refreshDataMonitor.TabIndex = 4
        Me.refreshDataMonitor.Text = "Refresh"
        Me.refreshDataMonitor.UseVisualStyleBackColor = True
        '
        'commandPage
        '
        Me.commandPage.Controls.Add(Me.requestNetworkDisconnect)
        Me.commandPage.Controls.Add(Me.abortCurrentCommandButton)
        Me.commandPage.Controls.Add(Me.requestNetworkConnectionButton)
        Me.commandPage.Controls.Add(Me.synchroNetworkButton)
        Me.commandPage.Controls.Add(Me.cleanLocalDataButton)
        Me.commandPage.Controls.Add(Me.checkTrustedNodeListButton)
        Me.commandPage.Controls.Add(Me.resumeSystemFirstNodeButton)
        Me.commandPage.Controls.Add(Me.buildNetworkButton)
        Me.commandPage.Controls.Add(Me.setTrustedIPAddressButton)
        Me.commandPage.Controls.Add(Me.downloadHistoryButton)
        Me.commandPage.Controls.Add(Me.rebuildStateButton)
        Me.commandPage.Controls.Add(Me.verifyButton)
        Me.commandPage.Location = New System.Drawing.Point(4, 22)
        Me.commandPage.Name = "commandPage"
        Me.commandPage.Padding = New System.Windows.Forms.Padding(3)
        Me.commandPage.Size = New System.Drawing.Size(687, 358)
        Me.commandPage.TabIndex = 4
        Me.commandPage.Text = "Command"
        Me.commandPage.UseVisualStyleBackColor = True
        '
        'requestNetworkDisconnect
        '
        Me.requestNetworkDisconnect.Enabled = False
        Me.requestNetworkDisconnect.Location = New System.Drawing.Point(261, 185)
        Me.requestNetworkDisconnect.Name = "requestNetworkDisconnect"
        Me.requestNetworkDisconnect.Size = New System.Drawing.Size(103, 51)
        Me.requestNetworkDisconnect.TabIndex = 11
        Me.requestNetworkDisconnect.Text = "Request Network Disconnect"
        Me.requestNetworkDisconnect.UseVisualStyleBackColor = True
        '
        'abortCurrentCommandButton
        '
        Me.abortCurrentCommandButton.Enabled = False
        Me.abortCurrentCommandButton.Location = New System.Drawing.Point(43, 256)
        Me.abortCurrentCommandButton.Name = "abortCurrentCommandButton"
        Me.abortCurrentCommandButton.Size = New System.Drawing.Size(103, 51)
        Me.abortCurrentCommandButton.TabIndex = 10
        Me.abortCurrentCommandButton.Text = "Abort Current Command"
        Me.abortCurrentCommandButton.UseVisualStyleBackColor = True
        '
        'requestNetworkConnectionButton
        '
        Me.requestNetworkConnectionButton.Enabled = False
        Me.requestNetworkConnectionButton.Location = New System.Drawing.Point(152, 185)
        Me.requestNetworkConnectionButton.Name = "requestNetworkConnectionButton"
        Me.requestNetworkConnectionButton.Size = New System.Drawing.Size(103, 51)
        Me.requestNetworkConnectionButton.TabIndex = 9
        Me.requestNetworkConnectionButton.Text = "Request Network Connection"
        Me.requestNetworkConnectionButton.UseVisualStyleBackColor = True
        '
        'synchroNetworkButton
        '
        Me.synchroNetworkButton.Enabled = False
        Me.synchroNetworkButton.Location = New System.Drawing.Point(43, 185)
        Me.synchroNetworkButton.Name = "synchroNetworkButton"
        Me.synchroNetworkButton.Size = New System.Drawing.Size(103, 51)
        Me.synchroNetworkButton.TabIndex = 8
        Me.synchroNetworkButton.Text = "Synchronize Network"
        Me.synchroNetworkButton.UseVisualStyleBackColor = True
        '
        'cleanLocalDataButton
        '
        Me.cleanLocalDataButton.Enabled = False
        Me.cleanLocalDataButton.Location = New System.Drawing.Point(370, 109)
        Me.cleanLocalDataButton.Name = "cleanLocalDataButton"
        Me.cleanLocalDataButton.Size = New System.Drawing.Size(103, 51)
        Me.cleanLocalDataButton.TabIndex = 7
        Me.cleanLocalDataButton.Text = "Clean Local Data"
        Me.cleanLocalDataButton.UseVisualStyleBackColor = True
        '
        'checkTrustedNodeListButton
        '
        Me.checkTrustedNodeListButton.Enabled = False
        Me.checkTrustedNodeListButton.Location = New System.Drawing.Point(261, 109)
        Me.checkTrustedNodeListButton.Name = "checkTrustedNodeListButton"
        Me.checkTrustedNodeListButton.Size = New System.Drawing.Size(103, 51)
        Me.checkTrustedNodeListButton.TabIndex = 6
        Me.checkTrustedNodeListButton.Text = "Check Trusted Node List"
        Me.checkTrustedNodeListButton.UseVisualStyleBackColor = True
        '
        'resumeSystemFirstNodeButton
        '
        Me.resumeSystemFirstNodeButton.Enabled = False
        Me.resumeSystemFirstNodeButton.Location = New System.Drawing.Point(152, 109)
        Me.resumeSystemFirstNodeButton.Name = "resumeSystemFirstNodeButton"
        Me.resumeSystemFirstNodeButton.Size = New System.Drawing.Size(103, 51)
        Me.resumeSystemFirstNodeButton.TabIndex = 5
        Me.resumeSystemFirstNodeButton.Text = "Resume System First Node"
        Me.resumeSystemFirstNodeButton.UseVisualStyleBackColor = True
        '
        'buildNetworkButton
        '
        Me.buildNetworkButton.Enabled = False
        Me.buildNetworkButton.Location = New System.Drawing.Point(43, 109)
        Me.buildNetworkButton.Name = "buildNetworkButton"
        Me.buildNetworkButton.Size = New System.Drawing.Size(103, 51)
        Me.buildNetworkButton.TabIndex = 4
        Me.buildNetworkButton.Text = "Build Network"
        Me.buildNetworkButton.UseVisualStyleBackColor = True
        '
        'setTrustedIPAddressButton
        '
        Me.setTrustedIPAddressButton.Enabled = False
        Me.setTrustedIPAddressButton.Location = New System.Drawing.Point(370, 37)
        Me.setTrustedIPAddressButton.Name = "setTrustedIPAddressButton"
        Me.setTrustedIPAddressButton.Size = New System.Drawing.Size(103, 51)
        Me.setTrustedIPAddressButton.TabIndex = 3
        Me.setTrustedIPAddressButton.Text = "Set Trusted IP Address"
        Me.setTrustedIPAddressButton.UseVisualStyleBackColor = True
        '
        'downloadHistoryButton
        '
        Me.downloadHistoryButton.Enabled = False
        Me.downloadHistoryButton.Location = New System.Drawing.Point(261, 37)
        Me.downloadHistoryButton.Name = "downloadHistoryButton"
        Me.downloadHistoryButton.Size = New System.Drawing.Size(103, 51)
        Me.downloadHistoryButton.TabIndex = 2
        Me.downloadHistoryButton.Text = "Download History"
        Me.downloadHistoryButton.UseVisualStyleBackColor = True
        '
        'rebuildStateButton
        '
        Me.rebuildStateButton.Enabled = False
        Me.rebuildStateButton.Location = New System.Drawing.Point(152, 37)
        Me.rebuildStateButton.Name = "rebuildStateButton"
        Me.rebuildStateButton.Size = New System.Drawing.Size(103, 51)
        Me.rebuildStateButton.TabIndex = 1
        Me.rebuildStateButton.Text = "Rebuild State"
        Me.rebuildStateButton.UseVisualStyleBackColor = True
        '
        'verifyButton
        '
        Me.verifyButton.Enabled = False
        Me.verifyButton.Location = New System.Drawing.Point(43, 37)
        Me.verifyButton.Name = "verifyButton"
        Me.verifyButton.Size = New System.Drawing.Size(103, 51)
        Me.verifyButton.TabIndex = 0
        Me.verifyButton.Text = "Verify data"
        Me.verifyButton.UseVisualStyleBackColor = True
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
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
        Me.generalTab.ResumeLayout(False)
        Me.commondGroup.ResumeLayout(False)
        Me.infoGroup.ResumeLayout(False)
        Me.infoGroup.PerformLayout()
        Me.supportedProtocolsTab.ResumeLayout(False)
        Me.infoStatusNetwork.ResumeLayout(False)
        Me.infoStatusNetwork.PerformLayout()
        Me.monitorTab.ResumeLayout(False)
        Me.secondaryTab.ResumeLayout(False)
        Me.monitorGeneralTab.ResumeLayout(False)
        Me.monitorGeneralTab.PerformLayout()
        Me.monitorActionTab.ResumeLayout(False)
        Me.monitorActionTab.PerformLayout()
        Me.monitorComponentTab.ResumeLayout(False)
        Me.monitorComponentTab.PerformLayout()
        Me.commandPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTab As TabControl
    Friend WithEvents connectionTab As TabPage
    Friend WithEvents generalTab As TabPage
    Friend WithEvents localPathAndDataPortNumberFrame As GroupBox
    Friend WithEvents browseLocalPathButton As Button
    Friend WithEvents localPathDataText As TextBox
    Friend WithEvents adminServiceConnectionGroup As GroupBox
    Friend WithEvents commondGroup As GroupBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents infoGroup As GroupBox
    Friend WithEvents identityWalletAddress As TextBox
    Friend WithEvents publicWalletAddressLabel As Label
    Friend WithEvents currentStatus As TextBox
    Friend WithEvents currentStatusLabel As Label
    Friend WithEvents refreshInformationlButton As Button
    Friend WithEvents supportedProtocolsTab As TabPage
    Friend WithEvents softwareRelease As TextBox
    Friend WithEvents softwareReleaseLabel As Label
    Friend WithEvents platformHost As TextBox
    Friend WithEvents platformHostLabel As Label
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents responseTime As TextBox
    Friend WithEvents responseTimeLabel As Label
    Friend WithEvents publicCompleteAddress As TextBox
    Friend WithEvents completeAddressLabel As Label
    Friend WithEvents infoStatusNetwork As GroupBox
    Friend WithEvents protocolList As TextBox
    Friend WithEvents refreshSupportedProtocols As Button
    Friend WithEvents configurationLabel As Label
    Friend WithEvents configurationNameCombo As ComboBox
    Friend WithEvents saveConfigurationButton As Button
    Friend WithEvents deleteConfigurationButton As Button
    Friend WithEvents newConfigurationButton As Button
    Friend WithEvents serviceUrlProtocol As CHCSupportUIControls.UrlProtocol
    Friend WithEvents serviceCertificate As CHCSupportUIControls.Certificate
    Friend WithEvents adminWalletAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents connectServiceButton As Button
    Friend WithEvents serviceIDText As TextBox
    Friend WithEvents serviceUUID As Label
    Friend WithEvents chainName As TextBox
    Friend WithEvents chainNameLabel As Label
    Friend WithEvents monitorTab As TabPage
    Friend WithEvents refreshDataMonitor As Button
    Friend WithEvents listLabel As Label
    Friend WithEvents responseProtocolTimeText As TextBox
    Friend WithEvents responseProtocolTimeLabel As Label
    Friend WithEvents requestProtocolTimeText As TextBox
    Friend WithEvents requestProtocolTimeLabel As Label
    Friend WithEvents secondaryTab As TabControl
    Friend WithEvents monitorGeneralTab As TabPage
    Friend WithEvents responseMonitorTimeText As TextBox
    Friend WithEvents responseMonitorTimeLabel As Label
    Friend WithEvents requestMonitorTimeText As TextBox
    Friend WithEvents requestMonitorTimeLabel As Label
    Friend WithEvents servicePositionText As TextBox
    Friend WithEvents servicePositionLabel As Label
    Friend WithEvents monitorActionTab As TabPage
    Friend WithEvents codeErrorText As TextBox
    Friend WithEvents codeErrorLabel As Label
    Friend WithEvents descriptionErrorText As TextBox
    Friend WithEvents descriptionErrorLabel As Label
    Friend WithEvents codeActionText As TextBox
    Friend WithEvents codeActionLabel As Label
    Friend WithEvents descriptionActionText As TextBox
    Friend WithEvents descriptionActionLabel As Label
    Friend WithEvents monitorComponentTab As TabPage
    Friend WithEvents nodeListLabel As Label
    Friend WithEvents currentWorkText As TextBox
    Friend WithEvents currentWorkLabel As Label
    Friend WithEvents stateText As TextBox
    Friend WithEvents stateLabel As Label
    Friend WithEvents storageText As TextBox
    Friend WithEvents storageLabel As Label
    Friend WithEvents previousVolumeText As TextBox
    Friend WithEvents previousVolumeLabel As Label
    Friend WithEvents nodeListText As TextBox
    Friend WithEvents commandPage As TabPage
    Friend WithEvents abortCurrentCommandButton As Button
    Friend WithEvents requestNetworkConnectionButton As Button
    Friend WithEvents synchroNetworkButton As Button
    Friend WithEvents cleanLocalDataButton As Button
    Friend WithEvents checkTrustedNodeListButton As Button
    Friend WithEvents resumeSystemFirstNodeButton As Button
    Friend WithEvents buildNetworkButton As Button
    Friend WithEvents setTrustedIPAddressButton As Button
    Friend WithEvents downloadHistoryButton As Button
    Friend WithEvents rebuildStateButton As Button
    Friend WithEvents verifyButton As Button
    Friend WithEvents cancelOperationText As TextBox
    Friend WithEvents cancelOperationLabel As Label
    Friend WithEvents currentOperationText As TextBox
    Friend WithEvents currentOperationLabel As Label
    Friend WithEvents requestNetworkDisconnect As Button
    Friend WithEvents netWorkName As TextBox
    Friend WithEvents netWorkNameLabel As Label
    Friend WithEvents netWorkRefement As TextBox
    Friend WithEvents netWorkReferementLabel As Label
    Friend WithEvents addressIP As TextBox
    Friend WithEvents addressIPLabel As Label
    Friend WithEvents unitMeasureLabel As Label
End Class
