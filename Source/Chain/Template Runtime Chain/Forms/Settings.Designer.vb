<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.serviceIDText = New System.Windows.Forms.TextBox()
        Me.serviceUUID = New System.Windows.Forms.Label()
        Me.selectServicePort = New CHCSupportUIControls.SelectPort()
        Me.selectPublicPort = New CHCSupportUIControls.SelectPort()
        Me.certificateClient = New CHCSupportUIControls.Certificate()
        Me.adminWalletAddress = New CHCSupportUIControls.WalletAddress()
        Me.chainName = New System.Windows.Forms.TextBox()
        Me.chainNameLabel = New System.Windows.Forms.Label()
        Me.networkName = New System.Windows.Forms.TextBox()
        Me.networkNameLabel = New System.Windows.Forms.Label()
        Me.localDataLabel = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.dataPath = New System.Windows.Forms.TextBox()
        Me.noUpdateSystemDate = New System.Windows.Forms.CheckBox()
        Me.intranetMode = New System.Windows.Forms.CheckBox()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabInternal = New System.Windows.Forms.TabPage()
        Me.logGroup = New System.Windows.Forms.GroupBox()
        Me.logConfiguration = New CHCSupportUIControls.LogControl()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.tabMain.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabInternal.SuspendLayout()
        Me.logGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'saveButton
        '
        Me.saveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveButton.Location = New System.Drawing.Point(732, 33)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(106, 49)
        Me.saveButton.TabIndex = 1
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.serviceIDText)
        Me.tabMain.Controls.Add(Me.serviceUUID)
        Me.tabMain.Controls.Add(Me.selectServicePort)
        Me.tabMain.Controls.Add(Me.selectPublicPort)
        Me.tabMain.Controls.Add(Me.certificateClient)
        Me.tabMain.Controls.Add(Me.adminWalletAddress)
        Me.tabMain.Controls.Add(Me.chainName)
        Me.tabMain.Controls.Add(Me.chainNameLabel)
        Me.tabMain.Controls.Add(Me.networkName)
        Me.tabMain.Controls.Add(Me.networkNameLabel)
        Me.tabMain.Controls.Add(Me.localDataLabel)
        Me.tabMain.Controls.Add(Me.browseLocalPath)
        Me.tabMain.Controls.Add(Me.dataPath)
        Me.tabMain.Controls.Add(Me.noUpdateSystemDate)
        Me.tabMain.Controls.Add(Me.intranetMode)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(701, 340)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'serviceIDText
        '
        Me.serviceIDText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceIDText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceIDText.Location = New System.Drawing.Point(156, 79)
        Me.serviceIDText.Name = "serviceIDText"
        Me.serviceIDText.Size = New System.Drawing.Size(477, 21)
        Me.serviceIDText.TabIndex = 33
        Me.serviceIDText.Text = "a232c1bd-87bd-4074-bf26-0a6909a78f1d"
        '
        'serviceUUID
        '
        Me.serviceUUID.AutoSize = True
        Me.serviceUUID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceUUID.Location = New System.Drawing.Point(82, 82)
        Me.serviceUUID.Name = "serviceUUID"
        Me.serviceUUID.Size = New System.Drawing.Size(68, 13)
        Me.serviceUUID.TabIndex = 34
        Me.serviceUUID.Text = "Service ID"
        '
        'selectServicePort
        '
        Me.selectServicePort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectServicePort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectServicePort.label = "Service port number (0..65535)"
        Me.selectServicePort.Location = New System.Drawing.Point(354, 245)
        Me.selectServicePort.Name = "selectServicePort"
        Me.selectServicePort.Size = New System.Drawing.Size(282, 23)
        Me.selectServicePort.TabIndex = 32
        Me.selectServicePort.value = 0
        '
        'selectPublicPort
        '
        Me.selectPublicPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectPublicPort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectPublicPort.label = "Public port number (0..65535)"
        Me.selectPublicPort.Location = New System.Drawing.Point(354, 216)
        Me.selectPublicPort.Name = "selectPublicPort"
        Me.selectPublicPort.Size = New System.Drawing.Size(282, 23)
        Me.selectPublicPort.TabIndex = 31
        Me.selectPublicPort.value = 0
        '
        'certificateClient
        '
        Me.certificateClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateClient.dataPath = ""
        Me.certificateClient.Location = New System.Drawing.Point(81, 179)
        Me.certificateClient.Name = "certificateClient"
        Me.certificateClient.noChange = True
        Me.certificateClient.serviceId = ""
        Me.certificateClient.Size = New System.Drawing.Size(597, 30)
        Me.certificateClient.TabIndex = 30
        Me.certificateClient.urlService = ""
        Me.certificateClient.value = ""
        '
        'adminWalletAddress
        '
        Me.adminWalletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminWalletAddress.caption = "Admin wallet address"
        Me.adminWalletAddress.dataPath = ""
        Me.adminWalletAddress.Location = New System.Drawing.Point(17, 131)
        Me.adminWalletAddress.Name = "adminWalletAddress"
        Me.adminWalletAddress.Size = New System.Drawing.Size(662, 51)
        Me.adminWalletAddress.TabIndex = 4
        Me.adminWalletAddress.value = ""
        '
        'chainName
        '
        Me.chainName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chainName.Enabled = False
        Me.chainName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainName.Location = New System.Drawing.Point(156, 52)
        Me.chainName.Name = "chainName"
        Me.chainName.Size = New System.Drawing.Size(477, 21)
        Me.chainName.TabIndex = 1
        Me.chainName.Text = "(to define)"
        '
        'chainNameLabel
        '
        Me.chainNameLabel.AutoSize = True
        Me.chainNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainNameLabel.Location = New System.Drawing.Point(74, 55)
        Me.chainNameLabel.Name = "chainNameLabel"
        Me.chainNameLabel.Size = New System.Drawing.Size(76, 13)
        Me.chainNameLabel.TabIndex = 29
        Me.chainNameLabel.Text = "Chain name"
        '
        'networkName
        '
        Me.networkName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.networkName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkName.Location = New System.Drawing.Point(156, 25)
        Me.networkName.Name = "networkName"
        Me.networkName.Size = New System.Drawing.Size(477, 21)
        Me.networkName.TabIndex = 0
        Me.networkName.Text = "Chainsociety - Main net"
        '
        'networkNameLabel
        '
        Me.networkNameLabel.AutoSize = True
        Me.networkNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkNameLabel.Location = New System.Drawing.Point(60, 28)
        Me.networkNameLabel.Name = "networkNameLabel"
        Me.networkNameLabel.Size = New System.Drawing.Size(90, 13)
        Me.networkNameLabel.TabIndex = 27
        Me.networkNameLabel.Text = "Network name"
        '
        'localDataLabel
        '
        Me.localDataLabel.AutoSize = True
        Me.localDataLabel.Location = New System.Drawing.Point(85, 110)
        Me.localDataLabel.Name = "localDataLabel"
        Me.localDataLabel.Size = New System.Drawing.Size(65, 13)
        Me.localDataLabel.TabIndex = 21
        Me.localDataLabel.Text = "Local data"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(641, 106)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(35, 23)
        Me.browseLocalPath.TabIndex = 3
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'dataPath
        '
        Me.dataPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataPath.Location = New System.Drawing.Point(156, 107)
        Me.dataPath.Name = "dataPath"
        Me.dataPath.Size = New System.Drawing.Size(477, 21)
        Me.dataPath.TabIndex = 2
        '
        'noUpdateSystemDate
        '
        Me.noUpdateSystemDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.noUpdateSystemDate.AutoSize = True
        Me.noUpdateSystemDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.noUpdateSystemDate.Checked = True
        Me.noUpdateSystemDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.noUpdateSystemDate.Location = New System.Drawing.Point(472, 305)
        Me.noUpdateSystemDate.Name = "noUpdateSystemDate"
        Me.noUpdateSystemDate.Size = New System.Drawing.Size(162, 17)
        Me.noUpdateSystemDate.TabIndex = 4
        Me.noUpdateSystemDate.Text = "No update System Date"
        Me.noUpdateSystemDate.UseVisualStyleBackColor = True
        '
        'intranetMode
        '
        Me.intranetMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.intranetMode.AutoSize = True
        Me.intranetMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.intranetMode.Checked = True
        Me.intranetMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.intranetMode.Location = New System.Drawing.Point(526, 278)
        Me.intranetMode.Name = "intranetMode"
        Me.intranetMode.Size = New System.Drawing.Size(108, 17)
        Me.intranetMode.TabIndex = 3
        Me.intranetMode.Text = "Intranet mode"
        Me.intranetMode.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabInternal)
        Me.tabControl.Location = New System.Drawing.Point(14, 14)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(709, 366)
        Me.tabControl.TabIndex = 0
        '
        'tabInternal
        '
        Me.tabInternal.Controls.Add(Me.logGroup)
        Me.tabInternal.Controls.Add(Me.useEventRegistry)
        Me.tabInternal.Location = New System.Drawing.Point(4, 22)
        Me.tabInternal.Name = "tabInternal"
        Me.tabInternal.Size = New System.Drawing.Size(701, 340)
        Me.tabInternal.TabIndex = 2
        Me.tabInternal.Text = "Internal"
        Me.tabInternal.UseVisualStyleBackColor = True
        '
        'logGroup
        '
        Me.logGroup.Controls.Add(Me.logConfiguration)
        Me.logGroup.Location = New System.Drawing.Point(13, 15)
        Me.logGroup.Name = "logGroup"
        Me.logGroup.Size = New System.Drawing.Size(675, 142)
        Me.logGroup.TabIndex = 9
        Me.logGroup.TabStop = False
        Me.logGroup.Text = "Log"
        '
        'logConfiguration
        '
        Me.logConfiguration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logConfiguration.Location = New System.Drawing.Point(6, 20)
        Me.logConfiguration.Name = "logConfiguration"
        Me.logConfiguration.Size = New System.Drawing.Size(669, 105)
        Me.logConfiguration.TabIndex = 11
        Me.logConfiguration.trackConfiguration = CHCCommonLibrary.Support.LogEngine.TrackRuntimeModeEnum.dontTrackEver
        Me.logConfiguration.trackRotateFrequency = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.FrequencyEnum.every12h
        Me.logConfiguration.trackRotateKeepFile = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepFileEnum.nothingFiles
        Me.logConfiguration.trackRotateKeepLast = CHCCommonLibrary.Support.LogRotateEngine.LogRotateConfig.KeepEnum.lastDay
        Me.logConfiguration.useTrackRotate = False
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(13, 173)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 6
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(850, 391)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.saveButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(2000, 440)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 420)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Template Chain Runtime Settings - Crypto Hide Coin DTN"
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabInternal.ResumeLayout(False)
        Me.tabInternal.PerformLayout()
        Me.logGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents saveButton As Button
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents tabMain As TabPage
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabInternal As TabPage
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents logGroup As GroupBox
    Friend WithEvents localDataLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents dataPath As TextBox
    Friend WithEvents noUpdateSystemDate As CheckBox
    Friend WithEvents intranetMode As CheckBox
    Friend WithEvents chainName As TextBox
    Friend WithEvents chainNameLabel As Label
    Friend WithEvents networkName As TextBox
    Friend WithEvents networkNameLabel As Label
    Friend WithEvents adminWalletAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents certificateClient As CHCSupportUIControls.Certificate
    Friend WithEvents selectServicePort As CHCSupportUIControls.SelectPort
    Friend WithEvents selectPublicPort As CHCSupportUIControls.SelectPort
    Friend WithEvents logConfiguration As CHCSupportUIControls.LogControl
    Friend WithEvents serviceIDText As TextBox
    Friend WithEvents serviceUUID As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
