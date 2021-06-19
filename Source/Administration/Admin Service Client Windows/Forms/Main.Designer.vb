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
        Me.chainNameText = New System.Windows.Forms.TextBox()
        Me.chainNameLabel = New System.Windows.Forms.Label()
        Me.addressText = New System.Windows.Forms.TextBox()
        Me.addressLabel = New System.Windows.Forms.Label()
        Me.responseTimeText = New System.Windows.Forms.TextBox()
        Me.responseTimeLabel = New System.Windows.Forms.Label()
        Me.requestTimeText = New System.Windows.Forms.TextBox()
        Me.requestTimeLabel = New System.Windows.Forms.Label()
        Me.softwareReleaseText = New System.Windows.Forms.TextBox()
        Me.softwareReleaseLabel = New System.Windows.Forms.Label()
        Me.platformHostText = New System.Windows.Forms.TextBox()
        Me.platformHostLabel = New System.Windows.Forms.Label()
        Me.walletAddressText = New System.Windows.Forms.TextBox()
        Me.publicWalletAddressLabel = New System.Windows.Forms.Label()
        Me.currentStatusText = New System.Windows.Forms.TextBox()
        Me.currentStatusLabel = New System.Windows.Forms.Label()
        Me.refreshInformationlButton = New System.Windows.Forms.Button()
        Me.supportedProtocolsTab = New System.Windows.Forms.TabPage()
        Me.infoStatusNetwork = New System.Windows.Forms.GroupBox()
        Me.protocolList = New System.Windows.Forms.TextBox()
        Me.refreshSupportedProtocols = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.adminWalletAddress = New CHCSupportUIControls.WalletAddress()
        Me.serviceCertificate = New CHCSupportUIControls.Certificate()
        Me.serviceUrlProtocol = New CHCSupportUIControls.UrlProtocol()
        Me.mainTab.SuspendLayout()
        Me.connectionTab.SuspendLayout()
        Me.localPathAndDataPortNumberFrame.SuspendLayout()
        Me.adminServiceConnectionGroup.SuspendLayout()
        Me.generalTab.SuspendLayout()
        Me.commondGroup.SuspendLayout()
        Me.infoGroup.SuspendLayout()
        Me.supportedProtocolsTab.SuspendLayout()
        Me.infoStatusNetwork.SuspendLayout()
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
        Me.serviceIDText.TabIndex = 35
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
        Me.infoGroup.Controls.Add(Me.chainNameText)
        Me.infoGroup.Controls.Add(Me.chainNameLabel)
        Me.infoGroup.Controls.Add(Me.addressText)
        Me.infoGroup.Controls.Add(Me.addressLabel)
        Me.infoGroup.Controls.Add(Me.responseTimeText)
        Me.infoGroup.Controls.Add(Me.responseTimeLabel)
        Me.infoGroup.Controls.Add(Me.requestTimeText)
        Me.infoGroup.Controls.Add(Me.requestTimeLabel)
        Me.infoGroup.Controls.Add(Me.softwareReleaseText)
        Me.infoGroup.Controls.Add(Me.softwareReleaseLabel)
        Me.infoGroup.Controls.Add(Me.platformHostText)
        Me.infoGroup.Controls.Add(Me.platformHostLabel)
        Me.infoGroup.Controls.Add(Me.walletAddressText)
        Me.infoGroup.Controls.Add(Me.publicWalletAddressLabel)
        Me.infoGroup.Controls.Add(Me.currentStatusText)
        Me.infoGroup.Controls.Add(Me.currentStatusLabel)
        Me.infoGroup.Location = New System.Drawing.Point(7, 48)
        Me.infoGroup.Name = "infoGroup"
        Me.infoGroup.Size = New System.Drawing.Size(673, 304)
        Me.infoGroup.TabIndex = 1
        Me.infoGroup.TabStop = False
        Me.infoGroup.Text = "Info Peer"
        '
        'chainNameText
        '
        Me.chainNameText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chainNameText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainNameText.Location = New System.Drawing.Point(165, 73)
        Me.chainNameText.Name = "chainNameText"
        Me.chainNameText.ReadOnly = True
        Me.chainNameText.Size = New System.Drawing.Size(482, 21)
        Me.chainNameText.TabIndex = 23
        '
        'chainNameLabel
        '
        Me.chainNameLabel.AutoSize = True
        Me.chainNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainNameLabel.Location = New System.Drawing.Point(82, 77)
        Me.chainNameLabel.Name = "chainNameLabel"
        Me.chainNameLabel.Size = New System.Drawing.Size(77, 13)
        Me.chainNameLabel.TabIndex = 24
        Me.chainNameLabel.Text = "Chain Name"
        '
        'addressText
        '
        Me.addressText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addressText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addressText.Location = New System.Drawing.Point(165, 154)
        Me.addressText.Name = "addressText"
        Me.addressText.ReadOnly = True
        Me.addressText.Size = New System.Drawing.Size(482, 21)
        Me.addressText.TabIndex = 21
        '
        'addressLabel
        '
        Me.addressLabel.AutoSize = True
        Me.addressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addressLabel.Location = New System.Drawing.Point(106, 158)
        Me.addressLabel.Name = "addressLabel"
        Me.addressLabel.Size = New System.Drawing.Size(53, 13)
        Me.addressLabel.TabIndex = 22
        Me.addressLabel.Text = "Address"
        '
        'responseTimeText
        '
        Me.responseTimeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responseTimeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTimeText.Location = New System.Drawing.Point(165, 208)
        Me.responseTimeText.Name = "responseTimeText"
        Me.responseTimeText.ReadOnly = True
        Me.responseTimeText.Size = New System.Drawing.Size(482, 21)
        Me.responseTimeText.TabIndex = 10
        '
        'responseTimeLabel
        '
        Me.responseTimeLabel.AutoSize = True
        Me.responseTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTimeLabel.Location = New System.Drawing.Point(65, 212)
        Me.responseTimeLabel.Name = "responseTimeLabel"
        Me.responseTimeLabel.Size = New System.Drawing.Size(94, 13)
        Me.responseTimeLabel.TabIndex = 20
        Me.responseTimeLabel.Text = "Response Time"
        '
        'requestTimeText
        '
        Me.requestTimeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestTimeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestTimeText.Location = New System.Drawing.Point(165, 181)
        Me.requestTimeText.Name = "requestTimeText"
        Me.requestTimeText.ReadOnly = True
        Me.requestTimeText.Size = New System.Drawing.Size(482, 21)
        Me.requestTimeText.TabIndex = 9
        '
        'requestTimeLabel
        '
        Me.requestTimeLabel.AutoSize = True
        Me.requestTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestTimeLabel.Location = New System.Drawing.Point(74, 185)
        Me.requestTimeLabel.Name = "requestTimeLabel"
        Me.requestTimeLabel.Size = New System.Drawing.Size(85, 13)
        Me.requestTimeLabel.TabIndex = 18
        Me.requestTimeLabel.Text = "Request Time"
        '
        'softwareReleaseText
        '
        Me.softwareReleaseText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.softwareReleaseText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.softwareReleaseText.Location = New System.Drawing.Point(165, 127)
        Me.softwareReleaseText.Name = "softwareReleaseText"
        Me.softwareReleaseText.ReadOnly = True
        Me.softwareReleaseText.Size = New System.Drawing.Size(482, 21)
        Me.softwareReleaseText.TabIndex = 7
        '
        'softwareReleaseLabel
        '
        Me.softwareReleaseLabel.AutoSize = True
        Me.softwareReleaseLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.softwareReleaseLabel.Location = New System.Drawing.Point(55, 131)
        Me.softwareReleaseLabel.Name = "softwareReleaseLabel"
        Me.softwareReleaseLabel.Size = New System.Drawing.Size(104, 13)
        Me.softwareReleaseLabel.TabIndex = 14
        Me.softwareReleaseLabel.Text = "Software release"
        '
        'platformHostText
        '
        Me.platformHostText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.platformHostText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.platformHostText.Location = New System.Drawing.Point(165, 100)
        Me.platformHostText.Name = "platformHostText"
        Me.platformHostText.ReadOnly = True
        Me.platformHostText.Size = New System.Drawing.Size(482, 21)
        Me.platformHostText.TabIndex = 6
        '
        'platformHostLabel
        '
        Me.platformHostLabel.AutoSize = True
        Me.platformHostLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.platformHostLabel.Location = New System.Drawing.Point(76, 104)
        Me.platformHostLabel.Name = "platformHostLabel"
        Me.platformHostLabel.Size = New System.Drawing.Size(83, 13)
        Me.platformHostLabel.TabIndex = 12
        Me.platformHostLabel.Text = "Platform host"
        '
        'walletAddressText
        '
        Me.walletAddressText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.walletAddressText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.walletAddressText.Location = New System.Drawing.Point(165, 19)
        Me.walletAddressText.Name = "walletAddressText"
        Me.walletAddressText.ReadOnly = True
        Me.walletAddressText.Size = New System.Drawing.Size(482, 21)
        Me.walletAddressText.TabIndex = 4
        '
        'publicWalletAddressLabel
        '
        Me.publicWalletAddressLabel.AutoSize = True
        Me.publicWalletAddressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicWalletAddressLabel.Location = New System.Drawing.Point(28, 23)
        Me.publicWalletAddressLabel.Name = "publicWalletAddressLabel"
        Me.publicWalletAddressLabel.Size = New System.Drawing.Size(131, 13)
        Me.publicWalletAddressLabel.TabIndex = 8
        Me.publicWalletAddressLabel.Text = "Admin Wallet Address"
        '
        'currentStatusText
        '
        Me.currentStatusText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentStatusText.Location = New System.Drawing.Point(165, 46)
        Me.currentStatusText.Name = "currentStatusText"
        Me.currentStatusText.ReadOnly = True
        Me.currentStatusText.Size = New System.Drawing.Size(482, 21)
        Me.currentStatusText.TabIndex = 0
        '
        'currentStatusLabel
        '
        Me.currentStatusLabel.AutoSize = True
        Me.currentStatusLabel.Location = New System.Drawing.Point(68, 51)
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
        Me.infoStatusNetwork.Controls.Add(Me.protocolList)
        Me.infoStatusNetwork.Location = New System.Drawing.Point(7, 48)
        Me.infoStatusNetwork.Name = "infoStatusNetwork"
        Me.infoStatusNetwork.Size = New System.Drawing.Size(673, 299)
        Me.infoStatusNetwork.TabIndex = 4
        Me.infoStatusNetwork.TabStop = False
        Me.infoStatusNetwork.Text = "Protocol List"
        '
        'protocolList
        '
        Me.protocolList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.protocolList.Location = New System.Drawing.Point(20, 20)
        Me.protocolList.Multiline = True
        Me.protocolList.Name = "protocolList"
        Me.protocolList.ReadOnly = True
        Me.protocolList.Size = New System.Drawing.Size(633, 273)
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
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'adminWalletAddress
        '
        Me.adminWalletAddress.caption = "Admin wallet address"
        Me.adminWalletAddress.dataPath = ""
        Me.adminWalletAddress.Location = New System.Drawing.Point(6, 112)
        Me.adminWalletAddress.Name = "adminWalletAddress"
        Me.adminWalletAddress.Size = New System.Drawing.Size(660, 51)
        Me.adminWalletAddress.TabIndex = 2
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
        Me.serviceCertificate.TabIndex = 1
        Me.serviceCertificate.urlService = ""
        Me.serviceCertificate.value = ""
        '
        'serviceUrlProtocol
        '
        Me.serviceUrlProtocol.address = ""
        Me.serviceUrlProtocol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceUrlProtocol.Location = New System.Drawing.Point(26, 20)
        Me.serviceUrlProtocol.MinimumSize = New System.Drawing.Size(0, 29)
        Me.serviceUrlProtocol.Name = "serviceUrlProtocol"
        Me.serviceUrlProtocol.serviceId = ""
        Me.serviceUrlProtocol.Size = New System.Drawing.Size(642, 29)
        Me.serviceUrlProtocol.TabIndex = 0
        Me.serviceUrlProtocol.useSecure = False
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
    Friend WithEvents walletAddressText As TextBox
    Friend WithEvents publicWalletAddressLabel As Label
    Friend WithEvents currentStatusText As TextBox
    Friend WithEvents currentStatusLabel As Label
    Friend WithEvents refreshInformationlButton As Button
    Friend WithEvents supportedProtocolsTab As TabPage
    Friend WithEvents softwareReleaseText As TextBox
    Friend WithEvents softwareReleaseLabel As Label
    Friend WithEvents platformHostText As TextBox
    Friend WithEvents platformHostLabel As Label
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents responseTimeText As TextBox
    Friend WithEvents responseTimeLabel As Label
    Friend WithEvents requestTimeText As TextBox
    Friend WithEvents requestTimeLabel As Label
    Friend WithEvents addressText As TextBox
    Friend WithEvents addressLabel As Label
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
    Friend WithEvents chainNameText As TextBox
    Friend WithEvents chainNameLabel As Label
End Class
