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
        Me.adminPublicAddress = New CHCSupportUIControls.WalletAddress()
        Me.secureChannel = New System.Windows.Forms.CheckBox()
        Me.serviceID = New System.Windows.Forms.TextBox()
        Me.serviceUUID = New System.Windows.Forms.Label()
        Me.selectServicePort = New CHCSupportUIControls.SelectPort()
        Me.selectPublicPort = New CHCSupportUIControls.SelectPort()
        Me.certificateClient = New CHCSupportUIControls.Certificate()
        Me.networkName = New System.Windows.Forms.TextBox()
        Me.networkNameLabel = New System.Windows.Forms.Label()
        Me.intranetMode = New System.Windows.Forms.CheckBox()
        Me.tabInternal = New System.Windows.Forms.TabPage()
        Me.useCounter = New System.Windows.Forms.CheckBox()
        Me.logGroup = New System.Windows.Forms.GroupBox()
        Me.logInformations = New CHCSupportUIControls.LogControl()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
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
        Me.internalName = New System.Windows.Forms.TextBox()
        Me.internalNameLabel = New System.Windows.Forms.Label()
        Me.tabControl.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabInternal.SuspendLayout()
        Me.logGroup.SuspendLayout()
        Me.generalFrame.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabInternal)
        Me.tabControl.Enabled = False
        Me.tabControl.Location = New System.Drawing.Point(16, 127)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(709, 306)
        Me.tabControl.TabIndex = 1
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.internalName)
        Me.tabMain.Controls.Add(Me.internalNameLabel)
        Me.tabMain.Controls.Add(Me.adminPublicAddress)
        Me.tabMain.Controls.Add(Me.secureChannel)
        Me.tabMain.Controls.Add(Me.serviceID)
        Me.tabMain.Controls.Add(Me.serviceUUID)
        Me.tabMain.Controls.Add(Me.selectServicePort)
        Me.tabMain.Controls.Add(Me.selectPublicPort)
        Me.tabMain.Controls.Add(Me.certificateClient)
        Me.tabMain.Controls.Add(Me.networkName)
        Me.tabMain.Controls.Add(Me.networkNameLabel)
        Me.tabMain.Controls.Add(Me.intranetMode)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(701, 280)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'adminPublicAddress
        '
        Me.adminPublicAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminPublicAddress.caption = "Public admin address"
        Me.adminPublicAddress.dataPath = ""
        Me.adminPublicAddress.Location = New System.Drawing.Point(18, 109)
        Me.adminPublicAddress.Name = "adminPublicAddress"
        Me.adminPublicAddress.Size = New System.Drawing.Size(659, 51)
        Me.adminPublicAddress.TabIndex = 3
        Me.adminPublicAddress.value = ""
        '
        'secureChannel
        '
        Me.secureChannel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.secureChannel.AutoSize = True
        Me.secureChannel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.secureChannel.Enabled = False
        Me.secureChannel.Location = New System.Drawing.Point(563, 231)
        Me.secureChannel.Name = "secureChannel"
        Me.secureChannel.Size = New System.Drawing.Size(114, 17)
        Me.secureChannel.TabIndex = 8
        Me.secureChannel.Text = "&Secure channel"
        Me.secureChannel.UseVisualStyleBackColor = True
        '
        'serviceID
        '
        Me.serviceID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceID.Enabled = False
        Me.serviceID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceID.Location = New System.Drawing.Point(157, 82)
        Me.serviceID.Name = "serviceID"
        Me.serviceID.Size = New System.Drawing.Size(520, 21)
        Me.serviceID.TabIndex = 2
        '
        'serviceUUID
        '
        Me.serviceUUID.AutoSize = True
        Me.serviceUUID.Enabled = False
        Me.serviceUUID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceUUID.Location = New System.Drawing.Point(83, 85)
        Me.serviceUUID.Name = "serviceUUID"
        Me.serviceUUID.Size = New System.Drawing.Size(68, 13)
        Me.serviceUUID.TabIndex = 34
        Me.serviceUUID.Text = "&Service ID"
        '
        'selectServicePort
        '
        Me.selectServicePort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectServicePort.Enabled = False
        Me.selectServicePort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectServicePort.label = "Service port number (0..65535)"
        Me.selectServicePort.Location = New System.Drawing.Point(398, 202)
        Me.selectServicePort.Name = "selectServicePort"
        Me.selectServicePort.Size = New System.Drawing.Size(282, 23)
        Me.selectServicePort.TabIndex = 6
        Me.selectServicePort.value = 0
        '
        'selectPublicPort
        '
        Me.selectPublicPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectPublicPort.Enabled = False
        Me.selectPublicPort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectPublicPort.label = "Public port number (0..65535)"
        Me.selectPublicPort.Location = New System.Drawing.Point(120, 202)
        Me.selectPublicPort.Name = "selectPublicPort"
        Me.selectPublicPort.Size = New System.Drawing.Size(282, 23)
        Me.selectPublicPort.TabIndex = 5
        Me.selectPublicPort.value = 0
        '
        'certificateClient
        '
        Me.certificateClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateClient.dataPath = ""
        Me.certificateClient.Enabled = False
        Me.certificateClient.Location = New System.Drawing.Point(82, 166)
        Me.certificateClient.Name = "certificateClient"
        Me.certificateClient.noChange = True
        Me.certificateClient.serviceId = ""
        Me.certificateClient.Size = New System.Drawing.Size(597, 30)
        Me.certificateClient.TabIndex = 4
        Me.certificateClient.urlService = ""
        Me.certificateClient.value = ""
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
        Me.networkNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkNameLabel.Location = New System.Drawing.Point(29, 58)
        Me.networkNameLabel.Name = "networkNameLabel"
        Me.networkNameLabel.Size = New System.Drawing.Size(122, 13)
        Me.networkNameLabel.TabIndex = 27
        Me.networkNameLabel.Text = "&Network referement"
        '
        'intranetMode
        '
        Me.intranetMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.intranetMode.AutoSize = True
        Me.intranetMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.intranetMode.Enabled = False
        Me.intranetMode.Location = New System.Drawing.Point(435, 231)
        Me.intranetMode.Name = "intranetMode"
        Me.intranetMode.Size = New System.Drawing.Size(108, 17)
        Me.intranetMode.TabIndex = 7
        Me.intranetMode.Text = "&Intranet mode"
        Me.intranetMode.UseVisualStyleBackColor = True
        '
        'tabInternal
        '
        Me.tabInternal.Controls.Add(Me.useCounter)
        Me.tabInternal.Controls.Add(Me.logGroup)
        Me.tabInternal.Controls.Add(Me.useEventRegistry)
        Me.tabInternal.Location = New System.Drawing.Point(4, 22)
        Me.tabInternal.Name = "tabInternal"
        Me.tabInternal.Size = New System.Drawing.Size(701, 280)
        Me.tabInternal.TabIndex = 2
        Me.tabInternal.Text = "Internal"
        Me.tabInternal.UseVisualStyleBackColor = True
        '
        'useCounter
        '
        Me.useCounter.AutoSize = True
        Me.useCounter.Location = New System.Drawing.Point(174, 191)
        Me.useCounter.Name = "useCounter"
        Me.useCounter.Size = New System.Drawing.Size(147, 17)
        Me.useCounter.TabIndex = 2
        Me.useCounter.Text = "Use Request Counter"
        Me.useCounter.UseVisualStyleBackColor = True
        '
        'logGroup
        '
        Me.logGroup.Controls.Add(Me.logInformations)
        Me.logGroup.Location = New System.Drawing.Point(13, 15)
        Me.logGroup.Name = "logGroup"
        Me.logGroup.Size = New System.Drawing.Size(675, 170)
        Me.logGroup.TabIndex = 0
        Me.logGroup.TabStop = False
        Me.logGroup.Text = "Log"
        '
        'logInformations
        '
        Me.logInformations.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logInformations.Location = New System.Drawing.Point(4, 20)
        Me.logInformations.maxNumberOfRegistrations = 0
        Me.logInformations.maxNumHours = 0
        Me.logInformations.Name = "logInformations"
        Me.logInformations.Size = New System.Drawing.Size(671, 143)
        Me.logInformations.TabIndex = 0
        Me.logInformations.trackConfiguration = CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrackEver
        Me.logInformations.trackRotateFrequency = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h
        Me.logInformations.trackRotateKeepFile = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles
        Me.logInformations.trackRotateKeepLast = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay
        Me.logInformations.useTrackRotate = False
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Location = New System.Drawing.Point(13, 191)
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
        Me.generalFrame.Controls.Add(Me.chainServiceName)
        Me.generalFrame.Controls.Add(Me.chainSettingLabel)
        Me.generalFrame.Location = New System.Drawing.Point(16, 13)
        Me.generalFrame.Name = "generalFrame"
        Me.generalFrame.Size = New System.Drawing.Size(705, 108)
        Me.generalFrame.TabIndex = 0
        Me.generalFrame.TabStop = False
        '
        'localDataLabel
        '
        Me.localDataLabel.AutoSize = True
        Me.localDataLabel.Location = New System.Drawing.Point(30, 50)
        Me.localDataLabel.Name = "localDataLabel"
        Me.localDataLabel.Size = New System.Drawing.Size(63, 13)
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
        Me.dataPath.Location = New System.Drawing.Point(99, 47)
        Me.dataPath.Name = "dataPath"
        Me.dataPath.Size = New System.Drawing.Size(559, 21)
        Me.dataPath.TabIndex = 1
        '
        'loadSettingButton
        '
        Me.loadSettingButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadSettingButton.Location = New System.Drawing.Point(594, 74)
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
        Me.chainServiceName.Location = New System.Drawing.Point(99, 20)
        Me.chainServiceName.Name = "chainServiceName"
        Me.chainServiceName.Size = New System.Drawing.Size(559, 21)
        Me.chainServiceName.TabIndex = 0
        '
        'chainSettingLabel
        '
        Me.chainSettingLabel.AutoSize = True
        Me.chainSettingLabel.Location = New System.Drawing.Point(6, 23)
        Me.chainSettingLabel.Name = "chainSettingLabel"
        Me.chainSettingLabel.Size = New System.Drawing.Size(87, 13)
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
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(850, 445)
        Me.Controls.Add(Me.infoButton)
        Me.Controls.Add(Me.openAsFileButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.generalFrame)
        Me.Controls.Add(Me.tabControl)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chain Service Settings - Crypto Hide Coin DTN"
        Me.tabControl.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabInternal.ResumeLayout(False)
        Me.tabInternal.PerformLayout()
        Me.logGroup.ResumeLayout(False)
        Me.generalFrame.ResumeLayout(False)
        Me.generalFrame.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabMain As TabPage
    Friend WithEvents serviceID As TextBox
    Friend WithEvents serviceUUID As Label
    Friend WithEvents selectServicePort As CHCSupportUIControls.SelectPort
    Friend WithEvents selectPublicPort As CHCSupportUIControls.SelectPort
    Friend WithEvents certificateClient As CHCSupportUIControls.Certificate
    Friend WithEvents networkName As TextBox
    Friend WithEvents networkNameLabel As Label
    Friend WithEvents intranetMode As CheckBox
    Friend WithEvents tabInternal As TabPage
    Friend WithEvents logGroup As GroupBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents generalFrame As GroupBox
    Friend WithEvents localDataLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents dataPath As TextBox
    Friend WithEvents loadSettingButton As Button
    Friend WithEvents chainServiceName As ComboBox
    Friend WithEvents chainSettingLabel As Label
    Friend WithEvents saveButton As Button
    Friend WithEvents secureChannel As CheckBox
    Friend WithEvents useCounter As CheckBox
    Friend WithEvents logInformations As CHCSupportUIControls.LogControl
    Friend WithEvents adminPublicAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openAsFileButton As Button
    Friend WithEvents infoButton As Button
    Friend WithEvents internalName As TextBox
    Friend WithEvents internalNameLabel As Label
End Class
