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
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.browseCertificate = New System.Windows.Forms.Button()
        Me.createNewCertificateClient = New System.Windows.Forms.Button()
        Me.certificateClient = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeClientLabel = New System.Windows.Forms.Label()
        Me.localDataLabel = New System.Windows.Forms.Label()
        Me.servicePortNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.publicPortNumber = New System.Windows.Forms.TextBox()
        Me.portNumberLabel = New System.Windows.Forms.Label()
        Me.walletAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.dataPath = New System.Windows.Forms.TextBox()
        Me.noUpdateSystemDate = New System.Windows.Forms.CheckBox()
        Me.intranetMode = New System.Windows.Forms.CheckBox()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabInternal = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.keepFileType = New System.Windows.Forms.Label()
        Me.keepFileTypeValue = New System.Windows.Forms.ComboBox()
        Me.keepOnlyRecentFile = New System.Windows.Forms.Label()
        Me.keepOnlyRecentFileValue = New System.Windows.Forms.ComboBox()
        Me.startCleanEvery = New System.Windows.Forms.Label()
        Me.startCleanEveryValue = New System.Windows.Forms.ComboBox()
        Me.autoCleanOption = New System.Windows.Forms.CheckBox()
        Me.trackConfiguration = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.networkName = New System.Windows.Forms.TextBox()
        Me.networkNameLabel = New System.Windows.Forms.Label()
        Me.chainName = New System.Windows.Forms.TextBox()
        Me.chainNameLabel = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabInternal.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.tabMain.Controls.Add(Me.chainName)
        Me.tabMain.Controls.Add(Me.chainNameLabel)
        Me.tabMain.Controls.Add(Me.networkName)
        Me.tabMain.Controls.Add(Me.networkNameLabel)
        Me.tabMain.Controls.Add(Me.browseCertificate)
        Me.tabMain.Controls.Add(Me.createNewCertificateClient)
        Me.tabMain.Controls.Add(Me.certificateClient)
        Me.tabMain.Controls.Add(Me.certificateMasternodeClientLabel)
        Me.tabMain.Controls.Add(Me.localDataLabel)
        Me.tabMain.Controls.Add(Me.servicePortNumber)
        Me.tabMain.Controls.Add(Me.Label4)
        Me.tabMain.Controls.Add(Me.publicPortNumber)
        Me.tabMain.Controls.Add(Me.portNumberLabel)
        Me.tabMain.Controls.Add(Me.walletAddress)
        Me.tabMain.Controls.Add(Me.Label2)
        Me.tabMain.Controls.Add(Me.browseLocalPath)
        Me.tabMain.Controls.Add(Me.dataPath)
        Me.tabMain.Controls.Add(Me.noUpdateSystemDate)
        Me.tabMain.Controls.Add(Me.intranetMode)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(701, 289)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'browseCertificate
        '
        Me.browseCertificate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseCertificate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseCertificate.Location = New System.Drawing.Point(641, 136)
        Me.browseCertificate.Name = "browseCertificate"
        Me.browseCertificate.Size = New System.Drawing.Size(35, 23)
        Me.browseCertificate.TabIndex = 25
        Me.browseCertificate.Text = "..."
        Me.browseCertificate.UseVisualStyleBackColor = True
        '
        'createNewCertificateClient
        '
        Me.createNewCertificateClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewCertificateClient.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createNewCertificateClient.Location = New System.Drawing.Point(584, 136)
        Me.createNewCertificateClient.Name = "createNewCertificateClient"
        Me.createNewCertificateClient.Size = New System.Drawing.Size(49, 22)
        Me.createNewCertificateClient.TabIndex = 23
        Me.createNewCertificateClient.Text = "New"
        Me.createNewCertificateClient.UseVisualStyleBackColor = True
        '
        'certificateClient
        '
        Me.certificateClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateClient.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateClient.Location = New System.Drawing.Point(156, 136)
        Me.certificateClient.Name = "certificateClient"
        Me.certificateClient.Size = New System.Drawing.Size(422, 21)
        Me.certificateClient.TabIndex = 22
        '
        'certificateMasternodeClientLabel
        '
        Me.certificateMasternodeClientLabel.AutoSize = True
        Me.certificateMasternodeClientLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeClientLabel.Location = New System.Drawing.Point(77, 140)
        Me.certificateMasternodeClientLabel.Name = "certificateMasternodeClientLabel"
        Me.certificateMasternodeClientLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeClientLabel.TabIndex = 24
        Me.certificateMasternodeClientLabel.Text = "Certificate"
        '
        'localDataLabel
        '
        Me.localDataLabel.AutoSize = True
        Me.localDataLabel.Location = New System.Drawing.Point(78, 85)
        Me.localDataLabel.Name = "localDataLabel"
        Me.localDataLabel.Size = New System.Drawing.Size(65, 13)
        Me.localDataLabel.TabIndex = 21
        Me.localDataLabel.Text = "Local data"
        '
        'servicePortNumber
        '
        Me.servicePortNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.servicePortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servicePortNumber.Location = New System.Drawing.Point(546, 191)
        Me.servicePortNumber.Name = "servicePortNumber"
        Me.servicePortNumber.Size = New System.Drawing.Size(87, 21)
        Me.servicePortNumber.TabIndex = 20
        Me.servicePortNumber.Text = "0"
        Me.servicePortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(351, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Service port number (0..65535)"
        '
        'publicPortNumber
        '
        Me.publicPortNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicPortNumber.Location = New System.Drawing.Point(546, 164)
        Me.publicPortNumber.Name = "publicPortNumber"
        Me.publicPortNumber.Size = New System.Drawing.Size(87, 21)
        Me.publicPortNumber.TabIndex = 18
        Me.publicPortNumber.Text = "0"
        Me.publicPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'portNumberLabel
        '
        Me.portNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.portNumberLabel.AutoSize = True
        Me.portNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumberLabel.Location = New System.Drawing.Point(361, 167)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(179, 13)
        Me.portNumberLabel.TabIndex = 17
        Me.portNumberLabel.Text = "Public port number (0..65535)"
        '
        'walletAddress
        '
        Me.walletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.walletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.walletAddress.Location = New System.Drawing.Point(156, 109)
        Me.walletAddress.Name = "walletAddress"
        Me.walletAddress.Size = New System.Drawing.Size(477, 21)
        Me.walletAddress.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Public wallet address"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(641, 80)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(35, 23)
        Me.browseLocalPath.TabIndex = 14
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'dataPath
        '
        Me.dataPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataPath.Location = New System.Drawing.Point(156, 82)
        Me.dataPath.Name = "dataPath"
        Me.dataPath.Size = New System.Drawing.Size(477, 21)
        Me.dataPath.TabIndex = 13
        '
        'noUpdateSystemDate
        '
        Me.noUpdateSystemDate.AutoSize = True
        Me.noUpdateSystemDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.noUpdateSystemDate.Checked = True
        Me.noUpdateSystemDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.noUpdateSystemDate.Location = New System.Drawing.Point(472, 252)
        Me.noUpdateSystemDate.Name = "noUpdateSystemDate"
        Me.noUpdateSystemDate.Size = New System.Drawing.Size(162, 17)
        Me.noUpdateSystemDate.TabIndex = 4
        Me.noUpdateSystemDate.Text = "No update System Date"
        Me.noUpdateSystemDate.UseVisualStyleBackColor = True
        '
        'intranetMode
        '
        Me.intranetMode.AutoSize = True
        Me.intranetMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.intranetMode.Checked = True
        Me.intranetMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.intranetMode.Location = New System.Drawing.Point(526, 229)
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
        Me.tabControl.Size = New System.Drawing.Size(709, 315)
        Me.tabControl.TabIndex = 0
        '
        'tabInternal
        '
        Me.tabInternal.Controls.Add(Me.GroupBox3)
        Me.tabInternal.Controls.Add(Me.useEventRegistry)
        Me.tabInternal.Location = New System.Drawing.Point(4, 22)
        Me.tabInternal.Name = "tabInternal"
        Me.tabInternal.Size = New System.Drawing.Size(701, 289)
        Me.tabInternal.TabIndex = 2
        Me.tabInternal.Text = "Internal"
        Me.tabInternal.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.keepFileType)
        Me.GroupBox3.Controls.Add(Me.keepFileTypeValue)
        Me.GroupBox3.Controls.Add(Me.keepOnlyRecentFile)
        Me.GroupBox3.Controls.Add(Me.keepOnlyRecentFileValue)
        Me.GroupBox3.Controls.Add(Me.startCleanEvery)
        Me.GroupBox3.Controls.Add(Me.startCleanEveryValue)
        Me.GroupBox3.Controls.Add(Me.autoCleanOption)
        Me.GroupBox3.Controls.Add(Me.trackConfiguration)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(674, 142)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Log"
        '
        'keepFileType
        '
        Me.keepFileType.AutoSize = True
        Me.keepFileType.Enabled = False
        Me.keepFileType.Location = New System.Drawing.Point(485, 80)
        Me.keepFileType.Name = "keepFileType"
        Me.keepFileType.Size = New System.Drawing.Size(86, 13)
        Me.keepFileType.TabIndex = 21
        Me.keepFileType.Text = "Keep file type"
        '
        'keepFileTypeValue
        '
        Me.keepFileTypeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepFileTypeValue.Enabled = False
        Me.keepFileTypeValue.FormattingEnabled = True
        Me.keepFileTypeValue.Items.AddRange(New Object() {"Nothing exclude", "Keep only main log"})
        Me.keepFileTypeValue.Location = New System.Drawing.Point(489, 96)
        Me.keepFileTypeValue.Name = "keepFileTypeValue"
        Me.keepFileTypeValue.Size = New System.Drawing.Size(131, 21)
        Me.keepFileTypeValue.TabIndex = 4
        '
        'keepOnlyRecentFile
        '
        Me.keepOnlyRecentFile.AutoSize = True
        Me.keepOnlyRecentFile.Enabled = False
        Me.keepOnlyRecentFile.Location = New System.Drawing.Point(267, 80)
        Me.keepOnlyRecentFile.Name = "keepOnlyRecentFile"
        Me.keepOnlyRecentFile.Size = New System.Drawing.Size(125, 13)
        Me.keepOnlyRecentFile.TabIndex = 20
        Me.keepOnlyRecentFile.Text = "Keep only recent file"
        '
        'keepOnlyRecentFileValue
        '
        Me.keepOnlyRecentFileValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepOnlyRecentFileValue.Enabled = False
        Me.keepOnlyRecentFileValue.FormattingEnabled = True
        Me.keepOnlyRecentFileValue.Items.AddRange(New Object() {"last day", "last week", "last month", "last year"})
        Me.keepOnlyRecentFileValue.Location = New System.Drawing.Point(271, 96)
        Me.keepOnlyRecentFileValue.Name = "keepOnlyRecentFileValue"
        Me.keepOnlyRecentFileValue.Size = New System.Drawing.Size(178, 21)
        Me.keepOnlyRecentFileValue.TabIndex = 3
        '
        'startCleanEvery
        '
        Me.startCleanEvery.AutoSize = True
        Me.startCleanEvery.Enabled = False
        Me.startCleanEvery.Location = New System.Drawing.Point(59, 80)
        Me.startCleanEvery.Name = "startCleanEvery"
        Me.startCleanEvery.Size = New System.Drawing.Size(100, 13)
        Me.startCleanEvery.TabIndex = 18
        Me.startCleanEvery.Text = "Frequency clean"
        '
        'startCleanEveryValue
        '
        Me.startCleanEveryValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.startCleanEveryValue.Enabled = False
        Me.startCleanEveryValue.FormattingEnabled = True
        Me.startCleanEveryValue.Items.AddRange(New Object() {"12 hours", "1 day"})
        Me.startCleanEveryValue.Location = New System.Drawing.Point(63, 96)
        Me.startCleanEveryValue.Name = "startCleanEveryValue"
        Me.startCleanEveryValue.Size = New System.Drawing.Size(178, 21)
        Me.startCleanEveryValue.TabIndex = 2
        '
        'autoCleanOption
        '
        Me.autoCleanOption.AutoSize = True
        Me.autoCleanOption.BackColor = System.Drawing.Color.White
        Me.autoCleanOption.Location = New System.Drawing.Point(63, 51)
        Me.autoCleanOption.Name = "autoCleanOption"
        Me.autoCleanOption.Size = New System.Drawing.Size(84, 17)
        Me.autoCleanOption.TabIndex = 1
        Me.autoCleanOption.Text = "Log rotate"
        Me.autoCleanOption.UseVisualStyleBackColor = False
        '
        'trackConfiguration
        '
        Me.trackConfiguration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.trackConfiguration.FormattingEnabled = True
        Me.trackConfiguration.Items.AddRange(New Object() {"Don't track log events", "Track only main", "Track all runtime"})
        Me.trackConfiguration.Location = New System.Drawing.Point(202, 17)
        Me.trackConfiguration.Name = "trackConfiguration"
        Me.trackConfiguration.Size = New System.Drawing.Size(418, 21)
        Me.trackConfiguration.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(59, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Track configuration"
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(13, 163)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 6
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'networkName
        '
        Me.networkName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.networkName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkName.Location = New System.Drawing.Point(156, 25)
        Me.networkName.Name = "networkName"
        Me.networkName.Size = New System.Drawing.Size(477, 21)
        Me.networkName.TabIndex = 26
        Me.networkName.Text = "Chainsociety - Main net"
        '
        'networkNameLabel
        '
        Me.networkNameLabel.AutoSize = True
        Me.networkNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkNameLabel.Location = New System.Drawing.Point(53, 28)
        Me.networkNameLabel.Name = "networkNameLabel"
        Me.networkNameLabel.Size = New System.Drawing.Size(90, 13)
        Me.networkNameLabel.TabIndex = 27
        Me.networkNameLabel.Text = "Network name"
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
        Me.chainName.TabIndex = 28
        Me.chainName.Text = "(to define)"
        '
        'chainNameLabel
        '
        Me.chainNameLabel.AutoSize = True
        Me.chainNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainNameLabel.Location = New System.Drawing.Point(67, 55)
        Me.chainNameLabel.Name = "chainNameLabel"
        Me.chainNameLabel.Size = New System.Drawing.Size(76, 13)
        Me.chainNameLabel.TabIndex = 29
        Me.chainNameLabel.Text = "Chain name"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(850, 341)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.saveButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(2000, 380)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 380)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Template Chain Runtime Settings - Crypto Hide Coin"
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabInternal.ResumeLayout(False)
        Me.tabInternal.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents saveButton As Button
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents tabMain As TabPage
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabInternal As TabPage
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents keepFileType As Label
    Friend WithEvents keepFileTypeValue As ComboBox
    Friend WithEvents keepOnlyRecentFile As Label
    Friend WithEvents keepOnlyRecentFileValue As ComboBox
    Friend WithEvents startCleanEvery As Label
    Friend WithEvents startCleanEveryValue As ComboBox
    Friend WithEvents autoCleanOption As CheckBox
    Friend WithEvents trackConfiguration As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents browseCertificate As Button
    Friend WithEvents createNewCertificateClient As Button
    Friend WithEvents certificateClient As TextBox
    Friend WithEvents certificateMasternodeClientLabel As Label
    Friend WithEvents localDataLabel As Label
    Friend WithEvents servicePortNumber As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents publicPortNumber As TextBox
    Friend WithEvents portNumberLabel As Label
    Friend WithEvents walletAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents dataPath As TextBox
    Friend WithEvents noUpdateSystemDate As CheckBox
    Friend WithEvents intranetMode As CheckBox
    Friend WithEvents chainName As TextBox
    Friend WithEvents chainNameLabel As Label
    Friend WithEvents networkName As TextBox
    Friend WithEvents networkNameLabel As Label
End Class
