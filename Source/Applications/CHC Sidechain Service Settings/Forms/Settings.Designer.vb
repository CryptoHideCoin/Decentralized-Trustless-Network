<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.serviceMode = New System.Windows.Forms.ComboBox()
        Me.serviceModeLabel = New System.Windows.Forms.Label()
        Me.internalName = New System.Windows.Forms.TextBox()
        Me.internalNameLabel = New System.Windows.Forms.Label()
        Me.networkName = New System.Windows.Forms.TextBox()
        Me.networkNameLabel = New System.Windows.Forms.Label()
        Me.intranetMode = New System.Windows.Forms.CheckBox()
        Me.tabConnection = New System.Windows.Forms.TabPage()
        Me.pathBase = New System.Windows.Forms.TextBox()
        Me.pathBaseLabel = New System.Windows.Forms.Label()
        Me.staticIPAddress = New System.Windows.Forms.TextBox()
        Me.staticIPAddressLabel = New System.Windows.Forms.Label()
        Me.secureChannel = New System.Windows.Forms.CheckBox()
        Me.serviceID = New System.Windows.Forms.TextBox()
        Me.serviceUUID = New System.Windows.Forms.Label()
        Me.selectServicePort = New CHCSupportUIControls.SelectPort()
        Me.selectPublicPort = New CHCSupportUIControls.SelectPort()
        Me.tabSecurity = New System.Windows.Forms.TabPage()
        Me.certificateClient = New CHCSupportUIControls.Certificate()
        Me.adminPublicAddress = New CHCSupportUIControls.WalletAddress()
        Me.tabService = New System.Windows.Forms.TabPage()
        Me.settingAutomMaintenanceButton = New System.Windows.Forms.Button()
        Me.useAutoMaintenance = New System.Windows.Forms.CheckBox()
        Me.settingsTrack = New System.Windows.Forms.Button()
        Me.useTrackLog = New System.Windows.Forms.CheckBox()
        Me.useAlert = New System.Windows.Forms.CheckBox()
        Me.useProfile = New System.Windows.Forms.CheckBox()
        Me.useMessage = New System.Windows.Forms.CheckBox()
        Me.useCounter = New System.Windows.Forms.CheckBox()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.generalFrame = New System.Windows.Forms.GroupBox()
        Me.localDataLabel = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.dataPath = New System.Windows.Forms.TextBox()
        Me.loadSettingButton = New System.Windows.Forms.Button()
        Me.sidechainServiceName = New System.Windows.Forms.ComboBox()
        Me.chainSettingLabel = New System.Windows.Forms.Label()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openAsFileButton = New System.Windows.Forms.Button()
        Me.infoButton = New System.Windows.Forms.Button()
        Me.fromRemoteButton = New System.Windows.Forms.Button()
        Me.toRemoteButton = New System.Windows.Forms.Button()
        Me.tabControl.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabConnection.SuspendLayout()
        Me.tabSecurity.SuspendLayout()
        Me.tabService.SuspendLayout()
        Me.generalFrame.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabConnection)
        Me.tabControl.Controls.Add(Me.tabSecurity)
        Me.tabControl.Controls.Add(Me.tabService)
        Me.tabControl.Enabled = False
        Me.tabControl.Location = New System.Drawing.Point(16, 126)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(709, 307)
        Me.tabControl.TabIndex = 4
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.serviceMode)
        Me.tabMain.Controls.Add(Me.serviceModeLabel)
        Me.tabMain.Controls.Add(Me.internalName)
        Me.tabMain.Controls.Add(Me.internalNameLabel)
        Me.tabMain.Controls.Add(Me.networkName)
        Me.tabMain.Controls.Add(Me.networkNameLabel)
        Me.tabMain.Controls.Add(Me.intranetMode)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(701, 281)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'serviceMode
        '
        Me.serviceMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceMode.Enabled = False
        Me.serviceMode.FormattingEnabled = True
        Me.serviceMode.Items.AddRange(New Object() {"Desktop  Application", "System Service ", "Webservice"})
        Me.serviceMode.Location = New System.Drawing.Point(157, 82)
        Me.serviceMode.Name = "serviceMode"
        Me.serviceMode.Size = New System.Drawing.Size(520, 21)
        Me.serviceMode.TabIndex = 2
        '
        'serviceModeLabel
        '
        Me.serviceModeLabel.AutoSize = True
        Me.serviceModeLabel.Enabled = False
        Me.serviceModeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceModeLabel.Location = New System.Drawing.Point(55, 85)
        Me.serviceModeLabel.Name = "serviceModeLabel"
        Me.serviceModeLabel.Size = New System.Drawing.Size(96, 13)
        Me.serviceModeLabel.TabIndex = 40
        Me.serviceModeLabel.Text = "&Service mode"
        '
        'internalName
        '
        Me.internalName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.internalName.Enabled = False
        Me.internalName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.internalName.Location = New System.Drawing.Point(157, 28)
        Me.internalName.Name = "internalName"
        Me.internalName.Size = New System.Drawing.Size(520, 21)
        Me.internalName.TabIndex = 0
        '
        'internalNameLabel
        '
        Me.internalNameLabel.AutoSize = True
        Me.internalNameLabel.Enabled = False
        Me.internalNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.internalNameLabel.Location = New System.Drawing.Point(63, 31)
        Me.internalNameLabel.Name = "internalNameLabel"
        Me.internalNameLabel.Size = New System.Drawing.Size(88, 13)
        Me.internalNameLabel.TabIndex = 38
        Me.internalNameLabel.Text = "&Internal name"
        '
        'networkName
        '
        Me.networkName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.networkName.Enabled = False
        Me.networkName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkName.Location = New System.Drawing.Point(157, 55)
        Me.networkName.Name = "networkName"
        Me.networkName.Size = New System.Drawing.Size(520, 21)
        Me.networkName.TabIndex = 1
        '
        'networkNameLabel
        '
        Me.networkNameLabel.AutoSize = True
        Me.networkNameLabel.Enabled = False
        Me.networkNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkNameLabel.Location = New System.Drawing.Point(12, 58)
        Me.networkNameLabel.Name = "networkNameLabel"
        Me.networkNameLabel.Size = New System.Drawing.Size(139, 13)
        Me.networkNameLabel.TabIndex = 27
        Me.networkNameLabel.Text = "&Network referement"
        '
        'intranetMode
        '
        Me.intranetMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.intranetMode.AutoSize = True
        Me.intranetMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.intranetMode.Enabled = False
        Me.intranetMode.Location = New System.Drawing.Point(569, 109)
        Me.intranetMode.Name = "intranetMode"
        Me.intranetMode.Size = New System.Drawing.Size(108, 17)
        Me.intranetMode.TabIndex = 3
        Me.intranetMode.Text = "&Intranet mode"
        Me.intranetMode.UseVisualStyleBackColor = True
        '
        'tabConnection
        '
        Me.tabConnection.Controls.Add(Me.pathBase)
        Me.tabConnection.Controls.Add(Me.pathBaseLabel)
        Me.tabConnection.Controls.Add(Me.staticIPAddress)
        Me.tabConnection.Controls.Add(Me.staticIPAddressLabel)
        Me.tabConnection.Controls.Add(Me.secureChannel)
        Me.tabConnection.Controls.Add(Me.serviceID)
        Me.tabConnection.Controls.Add(Me.serviceUUID)
        Me.tabConnection.Controls.Add(Me.selectServicePort)
        Me.tabConnection.Controls.Add(Me.selectPublicPort)
        Me.tabConnection.Location = New System.Drawing.Point(4, 22)
        Me.tabConnection.Name = "tabConnection"
        Me.tabConnection.Size = New System.Drawing.Size(701, 281)
        Me.tabConnection.TabIndex = 2
        Me.tabConnection.Text = "Connection"
        Me.tabConnection.UseVisualStyleBackColor = True
        '
        'pathBase
        '
        Me.pathBase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pathBase.Enabled = False
        Me.pathBase.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pathBase.Location = New System.Drawing.Point(141, 61)
        Me.pathBase.Name = "pathBase"
        Me.pathBase.Size = New System.Drawing.Size(513, 21)
        Me.pathBase.TabIndex = 1
        '
        'pathBaseLabel
        '
        Me.pathBaseLabel.AutoSize = True
        Me.pathBaseLabel.Enabled = False
        Me.pathBaseLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pathBaseLabel.Location = New System.Drawing.Point(72, 64)
        Me.pathBaseLabel.Name = "pathBaseLabel"
        Me.pathBaseLabel.Size = New System.Drawing.Size(63, 13)
        Me.pathBaseLabel.TabIndex = 50
        Me.pathBaseLabel.Text = "&Path base"
        '
        'staticIPAddress
        '
        Me.staticIPAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.staticIPAddress.Enabled = False
        Me.staticIPAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.staticIPAddress.Location = New System.Drawing.Point(141, 34)
        Me.staticIPAddress.Name = "staticIPAddress"
        Me.staticIPAddress.Size = New System.Drawing.Size(513, 21)
        Me.staticIPAddress.TabIndex = 0
        '
        'staticIPAddressLabel
        '
        Me.staticIPAddressLabel.AutoSize = True
        Me.staticIPAddressLabel.Enabled = False
        Me.staticIPAddressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.staticIPAddressLabel.Location = New System.Drawing.Point(31, 37)
        Me.staticIPAddressLabel.Name = "staticIPAddressLabel"
        Me.staticIPAddressLabel.Size = New System.Drawing.Size(104, 13)
        Me.staticIPAddressLabel.TabIndex = 48
        Me.staticIPAddressLabel.Text = "&Static IP address"
        '
        'secureChannel
        '
        Me.secureChannel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.secureChannel.AutoSize = True
        Me.secureChannel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.secureChannel.Enabled = False
        Me.secureChannel.Location = New System.Drawing.Point(540, 174)
        Me.secureChannel.Name = "secureChannel"
        Me.secureChannel.Size = New System.Drawing.Size(114, 17)
        Me.secureChannel.TabIndex = 5
        Me.secureChannel.Text = "&Secure channel"
        Me.secureChannel.UseVisualStyleBackColor = True
        '
        'serviceID
        '
        Me.serviceID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceID.Enabled = False
        Me.serviceID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceID.Location = New System.Drawing.Point(141, 88)
        Me.serviceID.Name = "serviceID"
        Me.serviceID.Size = New System.Drawing.Size(513, 21)
        Me.serviceID.TabIndex = 2
        '
        'serviceUUID
        '
        Me.serviceUUID.AutoSize = True
        Me.serviceUUID.Enabled = False
        Me.serviceUUID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceUUID.Location = New System.Drawing.Point(67, 91)
        Me.serviceUUID.Name = "serviceUUID"
        Me.serviceUUID.Size = New System.Drawing.Size(68, 13)
        Me.serviceUUID.TabIndex = 45
        Me.serviceUUID.Text = "&Service ID"
        '
        'selectServicePort
        '
        Me.selectServicePort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectServicePort.Enabled = False
        Me.selectServicePort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectServicePort.isNecessary = True
        Me.selectServicePort.label = "Service port number (0..65535)"
        Me.selectServicePort.Location = New System.Drawing.Point(319, 145)
        Me.selectServicePort.Name = "selectServicePort"
        Me.selectServicePort.Size = New System.Drawing.Size(339, 23)
        Me.selectServicePort.TabIndex = 4
        Me.selectServicePort.value = 0
        '
        'selectPublicPort
        '
        Me.selectPublicPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectPublicPort.Enabled = False
        Me.selectPublicPort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectPublicPort.isNecessary = True
        Me.selectPublicPort.label = "Public port number (0..65535)"
        Me.selectPublicPort.Location = New System.Drawing.Point(376, 116)
        Me.selectPublicPort.Name = "selectPublicPort"
        Me.selectPublicPort.Size = New System.Drawing.Size(282, 23)
        Me.selectPublicPort.TabIndex = 3
        Me.selectPublicPort.value = 0
        '
        'tabSecurity
        '
        Me.tabSecurity.Controls.Add(Me.certificateClient)
        Me.tabSecurity.Controls.Add(Me.adminPublicAddress)
        Me.tabSecurity.Location = New System.Drawing.Point(4, 22)
        Me.tabSecurity.Name = "tabSecurity"
        Me.tabSecurity.Size = New System.Drawing.Size(701, 281)
        Me.tabSecurity.TabIndex = 4
        Me.tabSecurity.Text = "Security"
        Me.tabSecurity.UseVisualStyleBackColor = True
        '
        'certificateClient
        '
        Me.certificateClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateClient.dataPath = ""
        Me.certificateClient.Enabled = False
        Me.certificateClient.Location = New System.Drawing.Point(87, 69)
        Me.certificateClient.Name = "certificateClient"
        Me.certificateClient.noChange = True
        Me.certificateClient.serviceId = ""
        Me.certificateClient.Size = New System.Drawing.Size(595, 30)
        Me.certificateClient.TabIndex = 1
        Me.certificateClient.urlService = ""
        Me.certificateClient.value = ""
        '
        'adminPublicAddress
        '
        Me.adminPublicAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminPublicAddress.caption = "Public admin key"
        Me.adminPublicAddress.dataPath = ""
        Me.adminPublicAddress.Location = New System.Drawing.Point(17, 21)
        Me.adminPublicAddress.Name = "adminPublicAddress"
        Me.adminPublicAddress.Size = New System.Drawing.Size(665, 51)
        Me.adminPublicAddress.TabIndex = 0
        Me.adminPublicAddress.useFontBold = True
        Me.adminPublicAddress.value = ""
        '
        'tabService
        '
        Me.tabService.Controls.Add(Me.settingAutomMaintenanceButton)
        Me.tabService.Controls.Add(Me.useAutoMaintenance)
        Me.tabService.Controls.Add(Me.settingsTrack)
        Me.tabService.Controls.Add(Me.useTrackLog)
        Me.tabService.Controls.Add(Me.useAlert)
        Me.tabService.Controls.Add(Me.useProfile)
        Me.tabService.Controls.Add(Me.useMessage)
        Me.tabService.Controls.Add(Me.useCounter)
        Me.tabService.Controls.Add(Me.useEventRegistry)
        Me.tabService.Location = New System.Drawing.Point(4, 22)
        Me.tabService.Name = "tabService"
        Me.tabService.Size = New System.Drawing.Size(701, 281)
        Me.tabService.TabIndex = 3
        Me.tabService.Text = "Components"
        Me.tabService.UseVisualStyleBackColor = True
        '
        'settingAutomMaintenanceButton
        '
        Me.settingAutomMaintenanceButton.Enabled = False
        Me.settingAutomMaintenanceButton.Location = New System.Drawing.Point(539, 106)
        Me.settingAutomMaintenanceButton.Name = "settingAutomMaintenanceButton"
        Me.settingAutomMaintenanceButton.Size = New System.Drawing.Size(75, 23)
        Me.settingAutomMaintenanceButton.TabIndex = 10
        Me.settingAutomMaintenanceButton.Text = "Settings"
        Me.settingAutomMaintenanceButton.UseVisualStyleBackColor = True
        '
        'useAutoMaintenance
        '
        Me.useAutoMaintenance.AutoSize = True
        Me.useAutoMaintenance.Location = New System.Drawing.Point(404, 110)
        Me.useAutoMaintenance.Name = "useAutoMaintenance"
        Me.useAutoMaintenance.Size = New System.Drawing.Size(129, 17)
        Me.useAutoMaintenance.TabIndex = 9
        Me.useAutoMaintenance.Text = "Auto maintenance"
        Me.useAutoMaintenance.UseVisualStyleBackColor = True
        '
        'settingsTrack
        '
        Me.settingsTrack.Enabled = False
        Me.settingsTrack.Location = New System.Drawing.Point(206, 31)
        Me.settingsTrack.Name = "settingsTrack"
        Me.settingsTrack.Size = New System.Drawing.Size(75, 23)
        Me.settingsTrack.TabIndex = 7
        Me.settingsTrack.Text = "Settings"
        Me.settingsTrack.UseVisualStyleBackColor = True
        '
        'useTrackLog
        '
        Me.useTrackLog.AutoSize = True
        Me.useTrackLog.Enabled = False
        Me.useTrackLog.Location = New System.Drawing.Point(48, 34)
        Me.useTrackLog.Name = "useTrackLog"
        Me.useTrackLog.Size = New System.Drawing.Size(101, 17)
        Me.useTrackLog.TabIndex = 0
        Me.useTrackLog.Text = "Use track log"
        Me.useTrackLog.UseVisualStyleBackColor = True
        '
        'useAlert
        '
        Me.useAlert.AutoSize = True
        Me.useAlert.Enabled = False
        Me.useAlert.Location = New System.Drawing.Point(404, 72)
        Me.useAlert.Name = "useAlert"
        Me.useAlert.Size = New System.Drawing.Size(78, 17)
        Me.useAlert.TabIndex = 5
        Me.useAlert.Text = "Use Alert"
        Me.useAlert.UseVisualStyleBackColor = True
        '
        'useProfile
        '
        Me.useProfile.AutoSize = True
        Me.useProfile.Enabled = False
        Me.useProfile.Location = New System.Drawing.Point(404, 34)
        Me.useProfile.Name = "useProfile"
        Me.useProfile.Size = New System.Drawing.Size(87, 17)
        Me.useProfile.TabIndex = 4
        Me.useProfile.Text = "Use Profile"
        Me.useProfile.UseVisualStyleBackColor = True
        '
        'useMessage
        '
        Me.useMessage.AutoSize = True
        Me.useMessage.Enabled = False
        Me.useMessage.Location = New System.Drawing.Point(48, 148)
        Me.useMessage.Name = "useMessage"
        Me.useMessage.Size = New System.Drawing.Size(100, 17)
        Me.useMessage.TabIndex = 3
        Me.useMessage.Text = "Use Message"
        Me.useMessage.UseVisualStyleBackColor = True
        '
        'useCounter
        '
        Me.useCounter.AutoSize = True
        Me.useCounter.Enabled = False
        Me.useCounter.Location = New System.Drawing.Point(48, 110)
        Me.useCounter.Name = "useCounter"
        Me.useCounter.Size = New System.Drawing.Size(147, 17)
        Me.useCounter.TabIndex = 2
        Me.useCounter.Text = "Use Request Counter"
        Me.useCounter.UseVisualStyleBackColor = True
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Location = New System.Drawing.Point(48, 72)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 1
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'generalFrame
        '
        Me.generalFrame.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generalFrame.Controls.Add(Me.localDataLabel)
        Me.generalFrame.Controls.Add(Me.browseLocalPath)
        Me.generalFrame.Controls.Add(Me.dataPath)
        Me.generalFrame.Controls.Add(Me.loadSettingButton)
        Me.generalFrame.Controls.Add(Me.sidechainServiceName)
        Me.generalFrame.Controls.Add(Me.chainSettingLabel)
        Me.generalFrame.Location = New System.Drawing.Point(16, 13)
        Me.generalFrame.Name = "generalFrame"
        Me.generalFrame.Size = New System.Drawing.Size(705, 107)
        Me.generalFrame.TabIndex = 0
        Me.generalFrame.TabStop = False
        '
        'localDataLabel
        '
        Me.localDataLabel.AutoSize = True
        Me.localDataLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localDataLabel.Location = New System.Drawing.Point(32, 50)
        Me.localDataLabel.Name = "localDataLabel"
        Me.localDataLabel.Size = New System.Drawing.Size(70, 13)
        Me.localDataLabel.TabIndex = 24
        Me.localDataLabel.Text = "&Data path"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(664, 46)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(35, 23)
        Me.browseLocalPath.TabIndex = 2
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'dataPath
        '
        Me.dataPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataPath.Location = New System.Drawing.Point(108, 47)
        Me.dataPath.Name = "dataPath"
        Me.dataPath.Size = New System.Drawing.Size(550, 21)
        Me.dataPath.TabIndex = 1
        '
        'loadSettingButton
        '
        Me.loadSettingButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadSettingButton.Location = New System.Drawing.Point(594, 78)
        Me.loadSettingButton.Name = "loadSettingButton"
        Me.loadSettingButton.Size = New System.Drawing.Size(105, 23)
        Me.loadSettingButton.TabIndex = 3
        Me.loadSettingButton.Text = "&Load / New"
        Me.loadSettingButton.UseVisualStyleBackColor = True
        '
        'sidechainServiceName
        '
        Me.sidechainServiceName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sidechainServiceName.FormattingEnabled = True
        Me.sidechainServiceName.Items.AddRange(New Object() {"Local Work Machine", "Sidechain Service"})
        Me.sidechainServiceName.Location = New System.Drawing.Point(108, 20)
        Me.sidechainServiceName.Name = "sidechainServiceName"
        Me.sidechainServiceName.Size = New System.Drawing.Size(550, 21)
        Me.sidechainServiceName.TabIndex = 0
        '
        'chainSettingLabel
        '
        Me.chainSettingLabel.AutoSize = True
        Me.chainSettingLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainSettingLabel.Location = New System.Drawing.Point(6, 23)
        Me.chainSettingLabel.Name = "chainSettingLabel"
        Me.chainSettingLabel.Size = New System.Drawing.Size(96, 13)
        Me.chainSettingLabel.TabIndex = 3
        Me.chainSettingLabel.Text = "&Service Chain"
        '
        'saveButton
        '
        Me.saveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveButton.Enabled = False
        Me.saveButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveButton.Location = New System.Drawing.Point(732, 19)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(106, 49)
        Me.saveButton.TabIndex = 5
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'openAsFileButton
        '
        Me.openAsFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.openAsFileButton.Enabled = False
        Me.openAsFileButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.openAsFileButton.Location = New System.Drawing.Point(732, 149)
        Me.openAsFileButton.Name = "openAsFileButton"
        Me.openAsFileButton.Size = New System.Drawing.Size(106, 27)
        Me.openAsFileButton.TabIndex = 6
        Me.openAsFileButton.Text = "Show a file"
        Me.openAsFileButton.UseVisualStyleBackColor = True
        '
        'infoButton
        '
        Me.infoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoButton.Location = New System.Drawing.Point(732, 182)
        Me.infoButton.Name = "infoButton"
        Me.infoButton.Size = New System.Drawing.Size(106, 27)
        Me.infoButton.TabIndex = 7
        Me.infoButton.Text = "Info"
        Me.infoButton.UseVisualStyleBackColor = True
        '
        'fromRemoteButton
        '
        Me.fromRemoteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fromRemoteButton.Enabled = False
        Me.fromRemoteButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fromRemoteButton.Location = New System.Drawing.Point(732, 373)
        Me.fromRemoteButton.Name = "fromRemoteButton"
        Me.fromRemoteButton.Size = New System.Drawing.Size(106, 27)
        Me.fromRemoteButton.TabIndex = 8
        Me.fromRemoteButton.Text = "From remote"
        Me.fromRemoteButton.UseVisualStyleBackColor = True
        '
        'toRemoteButton
        '
        Me.toRemoteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toRemoteButton.Enabled = False
        Me.toRemoteButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toRemoteButton.Location = New System.Drawing.Point(731, 406)
        Me.toRemoteButton.Name = "toRemoteButton"
        Me.toRemoteButton.Size = New System.Drawing.Size(106, 27)
        Me.toRemoteButton.TabIndex = 9
        Me.toRemoteButton.Text = "To remote"
        Me.toRemoteButton.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(850, 445)
        Me.Controls.Add(Me.toRemoteButton)
        Me.Controls.Add(Me.fromRemoteButton)
        Me.Controls.Add(Me.infoButton)
        Me.Controls.Add(Me.openAsFileButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.generalFrame)
        Me.Controls.Add(Me.tabControl)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chain Service Settings - Crypto Hide Coin DTN"
        Me.tabControl.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabConnection.ResumeLayout(False)
        Me.tabConnection.PerformLayout()
        Me.tabSecurity.ResumeLayout(False)
        Me.tabService.ResumeLayout(False)
        Me.tabService.PerformLayout()
        Me.generalFrame.ResumeLayout(False)
        Me.generalFrame.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabMain As TabPage
    Friend WithEvents networkName As TextBox
    Friend WithEvents networkNameLabel As Label
    Friend WithEvents intranetMode As CheckBox
    Friend WithEvents tabConnection As TabPage
    Friend WithEvents generalFrame As GroupBox
    Friend WithEvents localDataLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents dataPath As TextBox
    Friend WithEvents loadSettingButton As Button
    Friend WithEvents sidechainServiceName As ComboBox
    Friend WithEvents chainSettingLabel As Label
    Friend WithEvents saveButton As Button
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openAsFileButton As Button
    Friend WithEvents infoButton As Button
    Friend WithEvents internalName As TextBox
    Friend WithEvents internalNameLabel As Label
    Friend WithEvents serviceID As TextBox
    Friend WithEvents serviceUUID As Label
    Friend WithEvents selectServicePort As CHCSupportUIControls.SelectPort
    Friend WithEvents selectPublicPort As CHCSupportUIControls.SelectPort
    Friend WithEvents tabService As TabPage
    Friend WithEvents tabSecurity As TabPage
    Friend WithEvents fromRemoteButton As Button
    Friend WithEvents toRemoteButton As Button
    Friend WithEvents serviceMode As ComboBox
    Friend WithEvents serviceModeLabel As Label
    Friend WithEvents pathBase As TextBox
    Friend WithEvents pathBaseLabel As Label
    Friend WithEvents staticIPAddress As TextBox
    Friend WithEvents staticIPAddressLabel As Label
    Friend WithEvents secureChannel As CheckBox
    Friend WithEvents certificateClient As CHCSupportUIControls.Certificate
    Friend WithEvents adminPublicAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents useTrackLog As CheckBox
    Friend WithEvents useAlert As CheckBox
    Friend WithEvents useProfile As CheckBox
    Friend WithEvents useMessage As CheckBox
    Friend WithEvents useCounter As CheckBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents settingsTrack As Button
    Friend WithEvents settingAutomMaintenanceButton As Button
    Friend WithEvents useAutoMaintenance As CheckBox
End Class
