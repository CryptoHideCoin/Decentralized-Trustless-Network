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
        Me.internalName = New System.Windows.Forms.TextBox()
        Me.internalNameLabel = New System.Windows.Forms.Label()
        Me.secureChannel = New System.Windows.Forms.CheckBox()
        Me.networkName = New System.Windows.Forms.TextBox()
        Me.networkNameLabel = New System.Windows.Forms.Label()
        Me.intranetMode = New System.Windows.Forms.CheckBox()
        Me.tabInternal = New System.Windows.Forms.TabPage()
        Me.certificateClient = New CHCSupportUIControls.Certificate()
        Me.selectLocalWorkMachinePort = New CHCSupportUIControls.SelectPort()
        Me.adminPublicAddress = New CHCSupportUIControls.WalletAddress()
        Me.serviceID = New System.Windows.Forms.TextBox()
        Me.serviceUUID = New System.Windows.Forms.Label()
        Me.selectServicePort = New CHCSupportUIControls.SelectPort()
        Me.selectPublicPort = New CHCSupportUIControls.SelectPort()
        Me.tabComponents = New System.Windows.Forms.TabPage()
        Me.useMessageService = New System.Windows.Forms.CheckBox()
        Me.useCounter = New System.Windows.Forms.CheckBox()
        Me.logGroup = New System.Windows.Forms.GroupBox()
        Me.logInformations = New CHCSupportUIControls.LogControl()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.tabMaintenance = New System.Windows.Forms.TabPage()
        Me.autoMaintenanceGroup = New System.Windows.Forms.GroupBox()
        Me.frequencyAutoMaintenance = New CHCSupportUIControls.NumericText()
        Me.keepFileTypeLabel = New System.Windows.Forms.Label()
        Me.keepFileTypeValueCombo = New System.Windows.Forms.ComboBox()
        Me.keepOnlyRecentFileLabel = New System.Windows.Forms.Label()
        Me.keepOnlyRecentFileValueCombo = New System.Windows.Forms.ComboBox()
        Me.startCleanEveryLabel = New System.Windows.Forms.Label()
        Me.startCleanEveryValueCombo = New System.Windows.Forms.ComboBox()
        Me.unitMeasureFrequencyLabel = New System.Windows.Forms.Label()
        Me.frequencyLabel = New System.Windows.Forms.Label()
        Me.useAutoMaintenance = New System.Windows.Forms.CheckBox()
        Me.generalFrame = New System.Windows.Forms.GroupBox()
        Me.localDataLabel = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.dataPath = New System.Windows.Forms.TextBox()
        Me.loadSettingButton = New System.Windows.Forms.Button()
        Me.chainServiceName = New System.Windows.Forms.ComboBox()
        Me.chainSettingLabel = New System.Windows.Forms.Label()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openAsFileButton = New System.Windows.Forms.Button()
        Me.infoButton = New System.Windows.Forms.Button()
        Me.fromRemoteButton = New System.Windows.Forms.Button()
        Me.toRemoteButton = New System.Windows.Forms.Button()
        Me.tabControl.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabInternal.SuspendLayout()
        Me.tabComponents.SuspendLayout()
        Me.logGroup.SuspendLayout()
        Me.tabMaintenance.SuspendLayout()
        Me.autoMaintenanceGroup.SuspendLayout()
        Me.generalFrame.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabInternal)
        Me.tabControl.Controls.Add(Me.tabComponents)
        Me.tabControl.Controls.Add(Me.tabMaintenance)
        Me.tabControl.Enabled = False
        Me.tabControl.Location = New System.Drawing.Point(16, 126)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(709, 307)
        Me.tabControl.TabIndex = 4
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.internalName)
        Me.tabMain.Controls.Add(Me.internalNameLabel)
        Me.tabMain.Controls.Add(Me.secureChannel)
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
        'secureChannel
        '
        Me.secureChannel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.secureChannel.AutoSize = True
        Me.secureChannel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.secureChannel.Enabled = False
        Me.secureChannel.Location = New System.Drawing.Point(563, 94)
        Me.secureChannel.Name = "secureChannel"
        Me.secureChannel.Size = New System.Drawing.Size(114, 17)
        Me.secureChannel.TabIndex = 3
        Me.secureChannel.Text = "&Secure channel"
        Me.secureChannel.UseVisualStyleBackColor = True
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
        Me.intranetMode.Location = New System.Drawing.Point(435, 94)
        Me.intranetMode.Name = "intranetMode"
        Me.intranetMode.Size = New System.Drawing.Size(108, 17)
        Me.intranetMode.TabIndex = 2
        Me.intranetMode.Text = "&Intranet mode"
        Me.intranetMode.UseVisualStyleBackColor = True
        '
        'tabInternal
        '
        Me.tabInternal.Controls.Add(Me.certificateClient)
        Me.tabInternal.Controls.Add(Me.selectLocalWorkMachinePort)
        Me.tabInternal.Controls.Add(Me.adminPublicAddress)
        Me.tabInternal.Controls.Add(Me.serviceID)
        Me.tabInternal.Controls.Add(Me.serviceUUID)
        Me.tabInternal.Controls.Add(Me.selectServicePort)
        Me.tabInternal.Controls.Add(Me.selectPublicPort)
        Me.tabInternal.Location = New System.Drawing.Point(4, 22)
        Me.tabInternal.Name = "tabInternal"
        Me.tabInternal.Size = New System.Drawing.Size(701, 281)
        Me.tabInternal.TabIndex = 2
        Me.tabInternal.Text = "Internal"
        Me.tabInternal.UseVisualStyleBackColor = True
        '
        'certificateClient
        '
        Me.certificateClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateClient.dataPath = ""
        Me.certificateClient.Enabled = False
        Me.certificateClient.Location = New System.Drawing.Point(70, 93)
        Me.certificateClient.Name = "certificateClient"
        Me.certificateClient.noChange = True
        Me.certificateClient.serviceId = ""
        Me.certificateClient.Size = New System.Drawing.Size(592, 30)
        Me.certificateClient.TabIndex = 2
        Me.certificateClient.urlService = ""
        Me.certificateClient.value = ""
        '
        'selectLocalWorkMachinePort
        '
        Me.selectLocalWorkMachinePort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectLocalWorkMachinePort.Enabled = False
        Me.selectLocalWorkMachinePort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectLocalWorkMachinePort.label = "Local work machine port number (0..65535)"
        Me.selectLocalWorkMachinePort.Location = New System.Drawing.Point(89, 196)
        Me.selectLocalWorkMachinePort.Name = "selectLocalWorkMachinePort"
        Me.selectLocalWorkMachinePort.Size = New System.Drawing.Size(487, 23)
        Me.selectLocalWorkMachinePort.TabIndex = 5
        Me.selectLocalWorkMachinePort.value = 0
        '
        'adminPublicAddress
        '
        Me.adminPublicAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminPublicAddress.caption = "Public admin key"
        Me.adminPublicAddress.dataPath = ""
        Me.adminPublicAddress.Location = New System.Drawing.Point(10, 45)
        Me.adminPublicAddress.Name = "adminPublicAddress"
        Me.adminPublicAddress.Size = New System.Drawing.Size(656, 51)
        Me.adminPublicAddress.TabIndex = 1
        Me.adminPublicAddress.useFontBold = True
        Me.adminPublicAddress.value = ""
        '
        'serviceID
        '
        Me.serviceID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceID.Enabled = False
        Me.serviceID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceID.Location = New System.Drawing.Point(149, 18)
        Me.serviceID.Name = "serviceID"
        Me.serviceID.Size = New System.Drawing.Size(513, 21)
        Me.serviceID.TabIndex = 0
        '
        'serviceUUID
        '
        Me.serviceUUID.AutoSize = True
        Me.serviceUUID.Enabled = False
        Me.serviceUUID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceUUID.Location = New System.Drawing.Point(75, 21)
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
        Me.selectServicePort.label = "Service port number (0..65535)"
        Me.selectServicePort.Location = New System.Drawing.Point(237, 167)
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
        Me.selectPublicPort.label = "Public port number (0..65535)"
        Me.selectPublicPort.Location = New System.Drawing.Point(294, 138)
        Me.selectPublicPort.Name = "selectPublicPort"
        Me.selectPublicPort.Size = New System.Drawing.Size(282, 23)
        Me.selectPublicPort.TabIndex = 3
        Me.selectPublicPort.value = 0
        '
        'tabComponents
        '
        Me.tabComponents.Controls.Add(Me.useMessageService)
        Me.tabComponents.Controls.Add(Me.useCounter)
        Me.tabComponents.Controls.Add(Me.logGroup)
        Me.tabComponents.Controls.Add(Me.useEventRegistry)
        Me.tabComponents.Location = New System.Drawing.Point(4, 22)
        Me.tabComponents.Name = "tabComponents"
        Me.tabComponents.Size = New System.Drawing.Size(701, 281)
        Me.tabComponents.TabIndex = 4
        Me.tabComponents.Text = "Components"
        Me.tabComponents.UseVisualStyleBackColor = True
        '
        'useMessageService
        '
        Me.useMessageService.AutoSize = True
        Me.useMessageService.Location = New System.Drawing.Point(12, 177)
        Me.useMessageService.Name = "useMessageService"
        Me.useMessageService.Size = New System.Drawing.Size(147, 17)
        Me.useMessageService.TabIndex = 3
        Me.useMessageService.Text = "Use Message Service"
        Me.useMessageService.UseVisualStyleBackColor = True
        '
        'useCounter
        '
        Me.useCounter.AutoSize = True
        Me.useCounter.Location = New System.Drawing.Point(12, 154)
        Me.useCounter.Name = "useCounter"
        Me.useCounter.Size = New System.Drawing.Size(147, 17)
        Me.useCounter.TabIndex = 2
        Me.useCounter.Text = "Use Request Counter"
        Me.useCounter.UseVisualStyleBackColor = True
        '
        'logGroup
        '
        Me.logGroup.Controls.Add(Me.logInformations)
        Me.logGroup.Location = New System.Drawing.Point(12, 17)
        Me.logGroup.Name = "logGroup"
        Me.logGroup.Size = New System.Drawing.Size(675, 98)
        Me.logGroup.TabIndex = 0
        Me.logGroup.TabStop = False
        Me.logGroup.Text = "Log"
        '
        'logInformations
        '
        Me.logInformations.Enabled = False
        Me.logInformations.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logInformations.Location = New System.Drawing.Point(4, 20)
        Me.logInformations.maxNumberOfRegistrations = 0
        Me.logInformations.maxNumHours = 0
        Me.logInformations.Name = "logInformations"
        Me.logInformations.Size = New System.Drawing.Size(671, 63)
        Me.logInformations.TabIndex = 0
        Me.logInformations.trackConfiguration = CHCModels.AreaModel.Log.TrackRuntimeModeEnum.neverTrace
        Me.logInformations.trackRotateFrequency = CHCModels.AreaModel.Log.LogRotateConfig.FrequencyEnum.every12h
        Me.logInformations.trackRotateKeepFile = CHCModels.AreaModel.Log.LogRotateConfig.KeepFileEnum.nothingFiles
        Me.logInformations.trackRotateKeepLast = CHCModels.AreaModel.Log.KeepEnum.lastDay
        Me.logInformations.useTrackRotate = False
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Location = New System.Drawing.Point(12, 131)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 1
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'tabMaintenance
        '
        Me.tabMaintenance.Controls.Add(Me.autoMaintenanceGroup)
        Me.tabMaintenance.Location = New System.Drawing.Point(4, 22)
        Me.tabMaintenance.Name = "tabMaintenance"
        Me.tabMaintenance.Size = New System.Drawing.Size(701, 281)
        Me.tabMaintenance.TabIndex = 3
        Me.tabMaintenance.Text = "Maintenance"
        Me.tabMaintenance.UseVisualStyleBackColor = True
        '
        'autoMaintenanceGroup
        '
        Me.autoMaintenanceGroup.Controls.Add(Me.frequencyAutoMaintenance)
        Me.autoMaintenanceGroup.Controls.Add(Me.keepFileTypeLabel)
        Me.autoMaintenanceGroup.Controls.Add(Me.keepFileTypeValueCombo)
        Me.autoMaintenanceGroup.Controls.Add(Me.keepOnlyRecentFileLabel)
        Me.autoMaintenanceGroup.Controls.Add(Me.keepOnlyRecentFileValueCombo)
        Me.autoMaintenanceGroup.Controls.Add(Me.startCleanEveryLabel)
        Me.autoMaintenanceGroup.Controls.Add(Me.startCleanEveryValueCombo)
        Me.autoMaintenanceGroup.Controls.Add(Me.unitMeasureFrequencyLabel)
        Me.autoMaintenanceGroup.Controls.Add(Me.frequencyLabel)
        Me.autoMaintenanceGroup.Controls.Add(Me.useAutoMaintenance)
        Me.autoMaintenanceGroup.Location = New System.Drawing.Point(20, 14)
        Me.autoMaintenanceGroup.Name = "autoMaintenanceGroup"
        Me.autoMaintenanceGroup.Size = New System.Drawing.Size(661, 251)
        Me.autoMaintenanceGroup.TabIndex = 4
        Me.autoMaintenanceGroup.TabStop = False
        Me.autoMaintenanceGroup.Text = "Automatic Maintenance"
        '
        'frequencyAutoMaintenance
        '
        Me.frequencyAutoMaintenance.currentFormat = ""
        Me.frequencyAutoMaintenance.Location = New System.Drawing.Point(198, 66)
        Me.frequencyAutoMaintenance.locationCode = "it-IT"
        Me.frequencyAutoMaintenance.Name = "frequencyAutoMaintenance"
        Me.frequencyAutoMaintenance.Size = New System.Drawing.Size(100, 21)
        Me.frequencyAutoMaintenance.TabIndex = 1
        Me.frequencyAutoMaintenance.Text = "0"
        Me.frequencyAutoMaintenance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.frequencyAutoMaintenance.useDecimal = False
        '
        'keepFileTypeLabel
        '
        Me.keepFileTypeLabel.AutoSize = True
        Me.keepFileTypeLabel.Enabled = False
        Me.keepFileTypeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keepFileTypeLabel.Location = New System.Drawing.Point(106, 154)
        Me.keepFileTypeLabel.Name = "keepFileTypeLabel"
        Me.keepFileTypeLabel.Size = New System.Drawing.Size(86, 13)
        Me.keepFileTypeLabel.TabIndex = 36
        Me.keepFileTypeLabel.Text = "Keep file type"
        '
        'keepFileTypeValueCombo
        '
        Me.keepFileTypeValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepFileTypeValueCombo.Enabled = False
        Me.keepFileTypeValueCombo.FormattingEnabled = True
        Me.keepFileTypeValueCombo.Items.AddRange(New Object() {"Nothing exclude", "Keep only main log"})
        Me.keepFileTypeValueCombo.Location = New System.Drawing.Point(198, 151)
        Me.keepFileTypeValueCombo.Name = "keepFileTypeValueCombo"
        Me.keepFileTypeValueCombo.Size = New System.Drawing.Size(150, 21)
        Me.keepFileTypeValueCombo.TabIndex = 4
        '
        'keepOnlyRecentFileLabel
        '
        Me.keepOnlyRecentFileLabel.AutoSize = True
        Me.keepOnlyRecentFileLabel.Enabled = False
        Me.keepOnlyRecentFileLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keepOnlyRecentFileLabel.Location = New System.Drawing.Point(47, 124)
        Me.keepOnlyRecentFileLabel.Name = "keepOnlyRecentFileLabel"
        Me.keepOnlyRecentFileLabel.Size = New System.Drawing.Size(146, 13)
        Me.keepOnlyRecentFileLabel.TabIndex = 35
        Me.keepOnlyRecentFileLabel.Text = "Keep only recent file log"
        '
        'keepOnlyRecentFileValueCombo
        '
        Me.keepOnlyRecentFileValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepOnlyRecentFileValueCombo.Enabled = False
        Me.keepOnlyRecentFileValueCombo.FormattingEnabled = True
        Me.keepOnlyRecentFileValueCombo.Items.AddRange(New Object() {"last day", "last week", "last month", "last year"})
        Me.keepOnlyRecentFileValueCombo.Location = New System.Drawing.Point(198, 121)
        Me.keepOnlyRecentFileValueCombo.Name = "keepOnlyRecentFileValueCombo"
        Me.keepOnlyRecentFileValueCombo.Size = New System.Drawing.Size(207, 21)
        Me.keepOnlyRecentFileValueCombo.TabIndex = 3
        '
        'startCleanEveryLabel
        '
        Me.startCleanEveryLabel.AutoSize = True
        Me.startCleanEveryLabel.Enabled = False
        Me.startCleanEveryLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startCleanEveryLabel.Location = New System.Drawing.Point(71, 95)
        Me.startCleanEveryLabel.Name = "startCleanEveryLabel"
        Me.startCleanEveryLabel.Size = New System.Drawing.Size(121, 13)
        Me.startCleanEveryLabel.TabIndex = 34
        Me.startCleanEveryLabel.Text = "Frequency log clean"
        '
        'startCleanEveryValueCombo
        '
        Me.startCleanEveryValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.startCleanEveryValueCombo.Enabled = False
        Me.startCleanEveryValueCombo.FormattingEnabled = True
        Me.startCleanEveryValueCombo.Items.AddRange(New Object() {"12 hours", "1 day"})
        Me.startCleanEveryValueCombo.Location = New System.Drawing.Point(198, 92)
        Me.startCleanEveryValueCombo.Name = "startCleanEveryValueCombo"
        Me.startCleanEveryValueCombo.Size = New System.Drawing.Size(207, 21)
        Me.startCleanEveryValueCombo.TabIndex = 2
        '
        'unitMeasureFrequencyLabel
        '
        Me.unitMeasureFrequencyLabel.AutoSize = True
        Me.unitMeasureFrequencyLabel.Enabled = False
        Me.unitMeasureFrequencyLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitMeasureFrequencyLabel.Location = New System.Drawing.Point(304, 69)
        Me.unitMeasureFrequencyLabel.Name = "unitMeasureFrequencyLabel"
        Me.unitMeasureFrequencyLabel.Size = New System.Drawing.Size(45, 13)
        Me.unitMeasureFrequencyLabel.TabIndex = 3
        Me.unitMeasureFrequencyLabel.Text = "Hour/s"
        '
        'frequencyLabel
        '
        Me.frequencyLabel.AutoSize = True
        Me.frequencyLabel.Enabled = False
        Me.frequencyLabel.Location = New System.Drawing.Point(126, 69)
        Me.frequencyLabel.Name = "frequencyLabel"
        Me.frequencyLabel.Size = New System.Drawing.Size(66, 13)
        Me.frequencyLabel.TabIndex = 1
        Me.frequencyLabel.Text = "Frequency"
        '
        'useAutoMaintenance
        '
        Me.useAutoMaintenance.AutoSize = True
        Me.useAutoMaintenance.Location = New System.Drawing.Point(29, 30)
        Me.useAutoMaintenance.Name = "useAutoMaintenance"
        Me.useAutoMaintenance.Size = New System.Drawing.Size(184, 17)
        Me.useAutoMaintenance.TabIndex = 0
        Me.useAutoMaintenance.Text = "Use automatic maintenance"
        Me.useAutoMaintenance.UseVisualStyleBackColor = True
        '
        'generalFrame
        '
        Me.generalFrame.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generalFrame.Controls.Add(Me.localDataLabel)
        Me.generalFrame.Controls.Add(Me.browseLocalPath)
        Me.generalFrame.Controls.Add(Me.dataPath)
        Me.generalFrame.Controls.Add(Me.loadSettingButton)
        Me.generalFrame.Controls.Add(Me.chainServiceName)
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
        'chainServiceName
        '
        Me.chainServiceName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chainServiceName.FormattingEnabled = True
        Me.chainServiceName.Items.AddRange(New Object() {"Primary"})
        Me.chainServiceName.Location = New System.Drawing.Point(108, 20)
        Me.chainServiceName.Name = "chainServiceName"
        Me.chainServiceName.Size = New System.Drawing.Size(550, 21)
        Me.chainServiceName.TabIndex = 0
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
        Me.tabInternal.ResumeLayout(False)
        Me.tabInternal.PerformLayout()
        Me.tabComponents.ResumeLayout(False)
        Me.tabComponents.PerformLayout()
        Me.logGroup.ResumeLayout(False)
        Me.tabMaintenance.ResumeLayout(False)
        Me.autoMaintenanceGroup.ResumeLayout(False)
        Me.autoMaintenanceGroup.PerformLayout()
        Me.generalFrame.ResumeLayout(False)
        Me.generalFrame.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabMain As TabPage
    Friend WithEvents networkName As TextBox
    Friend WithEvents networkNameLabel As Label
    Friend WithEvents intranetMode As CheckBox
    Friend WithEvents tabInternal As TabPage
    Friend WithEvents generalFrame As GroupBox
    Friend WithEvents localDataLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents dataPath As TextBox
    Friend WithEvents loadSettingButton As Button
    Friend WithEvents chainServiceName As ComboBox
    Friend WithEvents chainSettingLabel As Label
    Friend WithEvents saveButton As Button
    Friend WithEvents secureChannel As CheckBox
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openAsFileButton As Button
    Friend WithEvents infoButton As Button
    Friend WithEvents internalName As TextBox
    Friend WithEvents internalNameLabel As Label
    Friend WithEvents selectLocalWorkMachinePort As CHCSupportUIControls.SelectPort
    Friend WithEvents adminPublicAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents serviceID As TextBox
    Friend WithEvents serviceUUID As Label
    Friend WithEvents selectServicePort As CHCSupportUIControls.SelectPort
    Friend WithEvents selectPublicPort As CHCSupportUIControls.SelectPort
    Friend WithEvents tabMaintenance As TabPage
    Friend WithEvents autoMaintenanceGroup As GroupBox
    Friend WithEvents unitMeasureFrequencyLabel As Label
    Friend WithEvents frequencyLabel As Label
    Friend WithEvents useAutoMaintenance As CheckBox
    Friend WithEvents tabComponents As TabPage
    Friend WithEvents useMessageService As CheckBox
    Friend WithEvents useCounter As CheckBox
    Friend WithEvents logGroup As GroupBox
    Friend WithEvents logInformations As CHCSupportUIControls.LogControl
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents keepFileTypeLabel As Label
    Friend WithEvents keepFileTypeValueCombo As ComboBox
    Friend WithEvents keepOnlyRecentFileLabel As Label
    Friend WithEvents keepOnlyRecentFileValueCombo As ComboBox
    Friend WithEvents startCleanEveryLabel As Label
    Friend WithEvents startCleanEveryValueCombo As ComboBox
    Friend WithEvents frequencyAutoMaintenance As CHCSupportUIControls.NumericText
    Friend WithEvents certificateClient As CHCSupportUIControls.Certificate
    Friend WithEvents fromRemoteButton As Button
    Friend WithEvents toRemoteButton As Button
End Class
