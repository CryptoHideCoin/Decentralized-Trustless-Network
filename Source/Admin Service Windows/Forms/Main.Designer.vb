<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.stopButton = New System.Windows.Forms.Button()
        Me.startButton = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.autoCleanGroup = New System.Windows.Forms.GroupBox()
        Me.keepFileType = New System.Windows.Forms.Label()
        Me.keepFileTypeValue = New System.Windows.Forms.ComboBox()
        Me.keepOnlyRecentFile = New System.Windows.Forms.Label()
        Me.keepOnlyRecentFileValue = New System.Windows.Forms.ComboBox()
        Me.startCleanEvery = New System.Windows.Forms.Label()
        Me.startCleanEveryValue = New System.Windows.Forms.ComboBox()
        Me.autoCleanOption = New System.Windows.Forms.CheckBox()
        Me.rememberThis = New System.Windows.Forms.CheckBox()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.writeLogFile = New System.Windows.Forms.CheckBox()
        Me.localPathAndDataPortNumber = New System.Windows.Forms.GroupBox()
        Me.publicWalletAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.localPortNumber = New System.Windows.Forms.TextBox()
        Me.portNumberLabel = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.localPathData = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.masternodeClientGroup = New System.Windows.Forms.GroupBox()
        Me.createNewCertificateClient = New System.Windows.Forms.Button()
        Me.certificateMasternodeClientBrowserButton = New System.Windows.Forms.Button()
        Me.certificateClient = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeClientLabel = New System.Windows.Forms.Label()
        Me.masternodeStartGroup = New System.Windows.Forms.GroupBox()
        Me.protocolMasternodeStart = New System.Windows.Forms.ComboBox()
        Me.createNewCertificateUpgrade = New System.Windows.Forms.Button()
        Me.certificateMasternodeBrowserButton = New System.Windows.Forms.Button()
        Me.testMasternodeServiceButton = New System.Windows.Forms.Button()
        Me.certificateMasternodeStart = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeLabel = New System.Windows.Forms.Label()
        Me.masternodeStartUrl = New System.Windows.Forms.TextBox()
        Me.urlMasternodeStartLabel = New System.Windows.Forms.Label()
        Me.masternodeEngineGroup = New System.Windows.Forms.GroupBox()
        Me.protocolMasternodeEngine = New System.Windows.Forms.ComboBox()
        Me.createNewCertificateEngine = New System.Windows.Forms.Button()
        Me.certificateMasternodeEngineBrowserButton = New System.Windows.Forms.Button()
        Me.testMasternodeEngineServiceButton = New System.Windows.Forms.Button()
        Me.certificateMasternodeEngine = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeEngineLabel = New System.Windows.Forms.Label()
        Me.masternodeEngineURL = New System.Windows.Forms.TextBox()
        Me.urlMasternodeEngineLabel = New System.Windows.Forms.Label()
        Me.LogTab = New System.Windows.Forms.TabPage()
        Me.logConsoleText = New System.Windows.Forms.TextBox()
        Me.logFileButton = New System.Windows.Forms.Button()
        Me.registryEventButton = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.informationButton = New System.Windows.Forms.Button()
        Me.tabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.autoCleanGroup.SuspendLayout()
        Me.localPathAndDataPortNumber.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.masternodeClientGroup.SuspendLayout()
        Me.masternodeStartGroup.SuspendLayout()
        Me.masternodeEngineGroup.SuspendLayout()
        Me.LogTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'refreshButton
        '
        Me.refreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshButton.Enabled = False
        Me.refreshButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refreshButton.Location = New System.Drawing.Point(934, 337)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(106, 49)
        Me.refreshButton.TabIndex = 5
        Me.refreshButton.Text = "Refresh"
        Me.refreshButton.UseVisualStyleBackColor = True
        '
        'stopButton
        '
        Me.stopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stopButton.Enabled = False
        Me.stopButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stopButton.Location = New System.Drawing.Point(934, 111)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(106, 49)
        Me.stopButton.TabIndex = 2
        Me.stopButton.Text = "STOP []"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'startButton
        '
        Me.startButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(934, 52)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(106, 49)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "RUN >>"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.TabPage1)
        Me.tabControl.Controls.Add(Me.TabPage2)
        Me.tabControl.Controls.Add(Me.LogTab)
        Me.tabControl.Location = New System.Drawing.Point(14, 16)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(913, 460)
        Me.tabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.autoCleanGroup)
        Me.TabPage1.Controls.Add(Me.rememberThis)
        Me.TabPage1.Controls.Add(Me.useEventRegistry)
        Me.TabPage1.Controls.Add(Me.writeLogFile)
        Me.TabPage1.Controls.Add(Me.localPathAndDataPortNumber)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(905, 434)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Parameters"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'autoCleanGroup
        '
        Me.autoCleanGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.autoCleanGroup.Controls.Add(Me.keepFileType)
        Me.autoCleanGroup.Controls.Add(Me.keepFileTypeValue)
        Me.autoCleanGroup.Controls.Add(Me.keepOnlyRecentFile)
        Me.autoCleanGroup.Controls.Add(Me.keepOnlyRecentFileValue)
        Me.autoCleanGroup.Controls.Add(Me.startCleanEvery)
        Me.autoCleanGroup.Controls.Add(Me.startCleanEveryValue)
        Me.autoCleanGroup.Controls.Add(Me.autoCleanOption)
        Me.autoCleanGroup.Location = New System.Drawing.Point(7, 160)
        Me.autoCleanGroup.Name = "autoCleanGroup"
        Me.autoCleanGroup.Size = New System.Drawing.Size(890, 88)
        Me.autoCleanGroup.TabIndex = 3
        Me.autoCleanGroup.TabStop = False
        '
        'keepFileType
        '
        Me.keepFileType.AutoSize = True
        Me.keepFileType.Enabled = False
        Me.keepFileType.Location = New System.Drawing.Point(419, 28)
        Me.keepFileType.Name = "keepFileType"
        Me.keepFileType.Size = New System.Drawing.Size(86, 13)
        Me.keepFileType.TabIndex = 6
        Me.keepFileType.Text = "Keep file type"
        '
        'keepFileTypeValue
        '
        Me.keepFileTypeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepFileTypeValue.Enabled = False
        Me.keepFileTypeValue.FormattingEnabled = True
        Me.keepFileTypeValue.Items.AddRange(New Object() {"Nothing exclude", "Keep only main log"})
        Me.keepFileTypeValue.Location = New System.Drawing.Point(422, 44)
        Me.keepFileTypeValue.Name = "keepFileTypeValue"
        Me.keepFileTypeValue.Size = New System.Drawing.Size(153, 21)
        Me.keepFileTypeValue.TabIndex = 3
        '
        'keepOnlyRecentFile
        '
        Me.keepOnlyRecentFile.AutoSize = True
        Me.keepOnlyRecentFile.Enabled = False
        Me.keepOnlyRecentFile.Location = New System.Drawing.Point(232, 28)
        Me.keepOnlyRecentFile.Name = "keepOnlyRecentFile"
        Me.keepOnlyRecentFile.Size = New System.Drawing.Size(125, 13)
        Me.keepOnlyRecentFile.TabIndex = 4
        Me.keepOnlyRecentFile.Text = "Keep only recent file"
        '
        'keepOnlyRecentFileValue
        '
        Me.keepOnlyRecentFileValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepOnlyRecentFileValue.Enabled = False
        Me.keepOnlyRecentFileValue.FormattingEnabled = True
        Me.keepOnlyRecentFileValue.Items.AddRange(New Object() {"last day", "last week", "last month", "last year"})
        Me.keepOnlyRecentFileValue.Location = New System.Drawing.Point(235, 44)
        Me.keepOnlyRecentFileValue.Name = "keepOnlyRecentFileValue"
        Me.keepOnlyRecentFileValue.Size = New System.Drawing.Size(153, 21)
        Me.keepOnlyRecentFileValue.TabIndex = 2
        '
        'startCleanEvery
        '
        Me.startCleanEvery.AutoSize = True
        Me.startCleanEvery.Enabled = False
        Me.startCleanEvery.Location = New System.Drawing.Point(54, 28)
        Me.startCleanEvery.Name = "startCleanEvery"
        Me.startCleanEvery.Size = New System.Drawing.Size(106, 13)
        Me.startCleanEvery.TabIndex = 2
        Me.startCleanEvery.Text = "Start clean every"
        '
        'startCleanEveryValue
        '
        Me.startCleanEveryValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.startCleanEveryValue.Enabled = False
        Me.startCleanEveryValue.FormattingEnabled = True
        Me.startCleanEveryValue.Items.AddRange(New Object() {"12 hours", "1 day"})
        Me.startCleanEveryValue.Location = New System.Drawing.Point(57, 44)
        Me.startCleanEveryValue.Name = "startCleanEveryValue"
        Me.startCleanEveryValue.Size = New System.Drawing.Size(153, 21)
        Me.startCleanEveryValue.TabIndex = 1
        '
        'autoCleanOption
        '
        Me.autoCleanOption.AutoSize = True
        Me.autoCleanOption.BackColor = System.Drawing.Color.White
        Me.autoCleanOption.Location = New System.Drawing.Point(18, 0)
        Me.autoCleanOption.Name = "autoCleanOption"
        Me.autoCleanOption.Size = New System.Drawing.Size(84, 17)
        Me.autoCleanOption.TabIndex = 0
        Me.autoCleanOption.Text = "Log rotate"
        Me.autoCleanOption.UseVisualStyleBackColor = False
        '
        'rememberThis
        '
        Me.rememberThis.AutoSize = True
        Me.rememberThis.Checked = True
        Me.rememberThis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rememberThis.Location = New System.Drawing.Point(15, 254)
        Me.rememberThis.Name = "rememberThis"
        Me.rememberThis.Size = New System.Drawing.Size(161, 17)
        Me.rememberThis.TabIndex = 4
        Me.rememberThis.Text = "Remember this settings"
        Me.rememberThis.UseVisualStyleBackColor = True
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(173, 128)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 2
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'writeLogFile
        '
        Me.writeLogFile.AutoSize = True
        Me.writeLogFile.Checked = True
        Me.writeLogFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.writeLogFile.Location = New System.Drawing.Point(15, 128)
        Me.writeLogFile.Name = "writeLogFile"
        Me.writeLogFile.Size = New System.Drawing.Size(103, 17)
        Me.writeLogFile.TabIndex = 1
        Me.writeLogFile.Text = "Write Log File"
        Me.writeLogFile.UseVisualStyleBackColor = True
        '
        'localPathAndDataPortNumber
        '
        Me.localPathAndDataPortNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathAndDataPortNumber.Controls.Add(Me.publicWalletAddress)
        Me.localPathAndDataPortNumber.Controls.Add(Me.Label6)
        Me.localPathAndDataPortNumber.Controls.Add(Me.localPortNumber)
        Me.localPathAndDataPortNumber.Controls.Add(Me.portNumberLabel)
        Me.localPathAndDataPortNumber.Controls.Add(Me.browseLocalPath)
        Me.localPathAndDataPortNumber.Controls.Add(Me.localPathData)
        Me.localPathAndDataPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathAndDataPortNumber.Location = New System.Drawing.Point(7, 6)
        Me.localPathAndDataPortNumber.Name = "localPathAndDataPortNumber"
        Me.localPathAndDataPortNumber.Size = New System.Drawing.Size(890, 116)
        Me.localPathAndDataPortNumber.TabIndex = 0
        Me.localPathAndDataPortNumber.TabStop = False
        Me.localPathAndDataPortNumber.Text = "Local root path data, administration wallet and port number"
        '
        'publicWalletAddress
        '
        Me.publicWalletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicWalletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicWalletAddress.Location = New System.Drawing.Point(137, 58)
        Me.publicWalletAddress.Name = "publicWalletAddress"
        Me.publicWalletAddress.Size = New System.Drawing.Size(704, 21)
        Me.publicWalletAddress.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Public wallet address"
        '
        'localPortNumber
        '
        Me.localPortNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPortNumber.Location = New System.Drawing.Point(753, 85)
        Me.localPortNumber.Name = "localPortNumber"
        Me.localPortNumber.Size = New System.Drawing.Size(87, 21)
        Me.localPortNumber.TabIndex = 3
        Me.localPortNumber.Text = "0"
        Me.localPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'portNumberLabel
        '
        Me.portNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.portNumberLabel.AutoSize = True
        Me.portNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumberLabel.Location = New System.Drawing.Point(605, 88)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(142, 13)
        Me.portNumberLabel.TabIndex = 2
        Me.portNumberLabel.Text = "Port number (0..65535)"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(848, 28)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(35, 23)
        Me.browseLocalPath.TabIndex = 1
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'localPathData
        '
        Me.localPathData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathData.Location = New System.Drawing.Point(8, 30)
        Me.localPathData.Name = "localPathData"
        Me.localPathData.Size = New System.Drawing.Size(832, 21)
        Me.localPathData.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.masternodeClientGroup)
        Me.TabPage2.Controls.Add(Me.masternodeStartGroup)
        Me.TabPage2.Controls.Add(Me.masternodeEngineGroup)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(905, 434)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Internal"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'masternodeClientGroup
        '
        Me.masternodeClientGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeClientGroup.Controls.Add(Me.createNewCertificateClient)
        Me.masternodeClientGroup.Controls.Add(Me.certificateMasternodeClientBrowserButton)
        Me.masternodeClientGroup.Controls.Add(Me.certificateClient)
        Me.masternodeClientGroup.Controls.Add(Me.certificateMasternodeClientLabel)
        Me.masternodeClientGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeClientGroup.Location = New System.Drawing.Point(7, 203)
        Me.masternodeClientGroup.Name = "masternodeClientGroup"
        Me.masternodeClientGroup.Size = New System.Drawing.Size(891, 61)
        Me.masternodeClientGroup.TabIndex = 2
        Me.masternodeClientGroup.TabStop = False
        Me.masternodeClientGroup.Text = "Client"
        '
        'createNewCertificateClient
        '
        Me.createNewCertificateClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewCertificateClient.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createNewCertificateClient.Location = New System.Drawing.Point(798, 27)
        Me.createNewCertificateClient.Name = "createNewCertificateClient"
        Me.createNewCertificateClient.Size = New System.Drawing.Size(49, 22)
        Me.createNewCertificateClient.TabIndex = 1
        Me.createNewCertificateClient.Text = "New"
        Me.createNewCertificateClient.UseVisualStyleBackColor = True
        '
        'certificateMasternodeClientBrowserButton
        '
        Me.certificateMasternodeClientBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeClientBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeClientBrowserButton.Location = New System.Drawing.Point(853, 27)
        Me.certificateMasternodeClientBrowserButton.Name = "certificateMasternodeClientBrowserButton"
        Me.certificateMasternodeClientBrowserButton.Size = New System.Drawing.Size(31, 22)
        Me.certificateMasternodeClientBrowserButton.TabIndex = 3
        Me.certificateMasternodeClientBrowserButton.Text = "..."
        Me.certificateMasternodeClientBrowserButton.UseVisualStyleBackColor = True
        '
        'certificateClient
        '
        Me.certificateClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateClient.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateClient.Location = New System.Drawing.Point(93, 27)
        Me.certificateClient.Name = "certificateClient"
        Me.certificateClient.Size = New System.Drawing.Size(699, 21)
        Me.certificateClient.TabIndex = 0
        '
        'certificateMasternodeClientLabel
        '
        Me.certificateMasternodeClientLabel.AutoSize = True
        Me.certificateMasternodeClientLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeClientLabel.Location = New System.Drawing.Point(14, 31)
        Me.certificateMasternodeClientLabel.Name = "certificateMasternodeClientLabel"
        Me.certificateMasternodeClientLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeClientLabel.TabIndex = 2
        Me.certificateMasternodeClientLabel.Text = "Certificate"
        '
        'masternodeStartGroup
        '
        Me.masternodeStartGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeStartGroup.Controls.Add(Me.protocolMasternodeStart)
        Me.masternodeStartGroup.Controls.Add(Me.createNewCertificateUpgrade)
        Me.masternodeStartGroup.Controls.Add(Me.certificateMasternodeBrowserButton)
        Me.masternodeStartGroup.Controls.Add(Me.testMasternodeServiceButton)
        Me.masternodeStartGroup.Controls.Add(Me.certificateMasternodeStart)
        Me.masternodeStartGroup.Controls.Add(Me.certificateMasternodeLabel)
        Me.masternodeStartGroup.Controls.Add(Me.masternodeStartUrl)
        Me.masternodeStartGroup.Controls.Add(Me.urlMasternodeStartLabel)
        Me.masternodeStartGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeStartGroup.Location = New System.Drawing.Point(8, 9)
        Me.masternodeStartGroup.Name = "masternodeStartGroup"
        Me.masternodeStartGroup.Size = New System.Drawing.Size(890, 91)
        Me.masternodeStartGroup.TabIndex = 0
        Me.masternodeStartGroup.TabStop = False
        Me.masternodeStartGroup.Text = "Masternode Start"
        '
        'protocolMasternodeStart
        '
        Me.protocolMasternodeStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.protocolMasternodeStart.FormattingEnabled = True
        Me.protocolMasternodeStart.Items.AddRange(New Object() {"http://", "https://"})
        Me.protocolMasternodeStart.Location = New System.Drawing.Point(92, 26)
        Me.protocolMasternodeStart.Name = "protocolMasternodeStart"
        Me.protocolMasternodeStart.Size = New System.Drawing.Size(70, 21)
        Me.protocolMasternodeStart.TabIndex = 0
        '
        'createNewCertificateUpgrade
        '
        Me.createNewCertificateUpgrade.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewCertificateUpgrade.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createNewCertificateUpgrade.Location = New System.Drawing.Point(740, 51)
        Me.createNewCertificateUpgrade.Name = "createNewCertificateUpgrade"
        Me.createNewCertificateUpgrade.Size = New System.Drawing.Size(49, 22)
        Me.createNewCertificateUpgrade.TabIndex = 3
        Me.createNewCertificateUpgrade.Text = "New"
        Me.createNewCertificateUpgrade.UseVisualStyleBackColor = True
        '
        'certificateMasternodeBrowserButton
        '
        Me.certificateMasternodeBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeBrowserButton.Location = New System.Drawing.Point(794, 51)
        Me.certificateMasternodeBrowserButton.Name = "certificateMasternodeBrowserButton"
        Me.certificateMasternodeBrowserButton.Size = New System.Drawing.Size(31, 22)
        Me.certificateMasternodeBrowserButton.TabIndex = 4
        Me.certificateMasternodeBrowserButton.Text = "..."
        Me.certificateMasternodeBrowserButton.UseVisualStyleBackColor = True
        '
        'testMasternodeServiceButton
        '
        Me.testMasternodeServiceButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testMasternodeServiceButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testMasternodeServiceButton.Location = New System.Drawing.Point(833, 25)
        Me.testMasternodeServiceButton.Name = "testMasternodeServiceButton"
        Me.testMasternodeServiceButton.Size = New System.Drawing.Size(50, 48)
        Me.testMasternodeServiceButton.TabIndex = 5
        Me.testMasternodeServiceButton.Text = "Test"
        Me.testMasternodeServiceButton.UseVisualStyleBackColor = True
        '
        'certificateMasternodeStart
        '
        Me.certificateMasternodeStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeStart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeStart.Location = New System.Drawing.Point(92, 51)
        Me.certificateMasternodeStart.Name = "certificateMasternodeStart"
        Me.certificateMasternodeStart.Size = New System.Drawing.Size(642, 21)
        Me.certificateMasternodeStart.TabIndex = 2
        '
        'certificateMasternodeLabel
        '
        Me.certificateMasternodeLabel.AutoSize = True
        Me.certificateMasternodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeLabel.Location = New System.Drawing.Point(13, 55)
        Me.certificateMasternodeLabel.Name = "certificateMasternodeLabel"
        Me.certificateMasternodeLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeLabel.TabIndex = 2
        Me.certificateMasternodeLabel.Text = "Certificate"
        '
        'masternodeStartUrl
        '
        Me.masternodeStartUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeStartUrl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeStartUrl.Location = New System.Drawing.Point(168, 26)
        Me.masternodeStartUrl.Name = "masternodeStartUrl"
        Me.masternodeStartUrl.Size = New System.Drawing.Size(657, 21)
        Me.masternodeStartUrl.TabIndex = 1
        '
        'urlMasternodeStartLabel
        '
        Me.urlMasternodeStartLabel.AutoSize = True
        Me.urlMasternodeStartLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlMasternodeStartLabel.Location = New System.Drawing.Point(50, 29)
        Me.urlMasternodeStartLabel.Name = "urlMasternodeStartLabel"
        Me.urlMasternodeStartLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlMasternodeStartLabel.TabIndex = 0
        Me.urlMasternodeStartLabel.Text = "URL"
        '
        'masternodeEngineGroup
        '
        Me.masternodeEngineGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeEngineGroup.Controls.Add(Me.protocolMasternodeEngine)
        Me.masternodeEngineGroup.Controls.Add(Me.createNewCertificateEngine)
        Me.masternodeEngineGroup.Controls.Add(Me.certificateMasternodeEngineBrowserButton)
        Me.masternodeEngineGroup.Controls.Add(Me.testMasternodeEngineServiceButton)
        Me.masternodeEngineGroup.Controls.Add(Me.certificateMasternodeEngine)
        Me.masternodeEngineGroup.Controls.Add(Me.certificateMasternodeEngineLabel)
        Me.masternodeEngineGroup.Controls.Add(Me.masternodeEngineURL)
        Me.masternodeEngineGroup.Controls.Add(Me.urlMasternodeEngineLabel)
        Me.masternodeEngineGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeEngineGroup.Location = New System.Drawing.Point(7, 106)
        Me.masternodeEngineGroup.Name = "masternodeEngineGroup"
        Me.masternodeEngineGroup.Size = New System.Drawing.Size(891, 91)
        Me.masternodeEngineGroup.TabIndex = 1
        Me.masternodeEngineGroup.TabStop = False
        Me.masternodeEngineGroup.Text = "Masternode Primary Runtime"
        '
        'protocolMasternodeEngine
        '
        Me.protocolMasternodeEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.protocolMasternodeEngine.FormattingEnabled = True
        Me.protocolMasternodeEngine.Items.AddRange(New Object() {"http://", "https://"})
        Me.protocolMasternodeEngine.Location = New System.Drawing.Point(93, 26)
        Me.protocolMasternodeEngine.Name = "protocolMasternodeEngine"
        Me.protocolMasternodeEngine.Size = New System.Drawing.Size(70, 21)
        Me.protocolMasternodeEngine.TabIndex = 0
        '
        'createNewCertificateEngine
        '
        Me.createNewCertificateEngine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewCertificateEngine.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createNewCertificateEngine.Location = New System.Drawing.Point(741, 51)
        Me.createNewCertificateEngine.Name = "createNewCertificateEngine"
        Me.createNewCertificateEngine.Size = New System.Drawing.Size(49, 22)
        Me.createNewCertificateEngine.TabIndex = 3
        Me.createNewCertificateEngine.Text = "New"
        Me.createNewCertificateEngine.UseVisualStyleBackColor = True
        '
        'certificateMasternodeEngineBrowserButton
        '
        Me.certificateMasternodeEngineBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeEngineBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeEngineBrowserButton.Location = New System.Drawing.Point(795, 51)
        Me.certificateMasternodeEngineBrowserButton.Name = "certificateMasternodeEngineBrowserButton"
        Me.certificateMasternodeEngineBrowserButton.Size = New System.Drawing.Size(31, 22)
        Me.certificateMasternodeEngineBrowserButton.TabIndex = 4
        Me.certificateMasternodeEngineBrowserButton.Text = "..."
        Me.certificateMasternodeEngineBrowserButton.UseVisualStyleBackColor = True
        '
        'testMasternodeEngineServiceButton
        '
        Me.testMasternodeEngineServiceButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testMasternodeEngineServiceButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testMasternodeEngineServiceButton.Location = New System.Drawing.Point(834, 25)
        Me.testMasternodeEngineServiceButton.Name = "testMasternodeEngineServiceButton"
        Me.testMasternodeEngineServiceButton.Size = New System.Drawing.Size(50, 48)
        Me.testMasternodeEngineServiceButton.TabIndex = 5
        Me.testMasternodeEngineServiceButton.Text = "Test"
        Me.testMasternodeEngineServiceButton.UseVisualStyleBackColor = True
        '
        'certificateMasternodeEngine
        '
        Me.certificateMasternodeEngine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeEngine.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeEngine.Location = New System.Drawing.Point(93, 51)
        Me.certificateMasternodeEngine.Name = "certificateMasternodeEngine"
        Me.certificateMasternodeEngine.Size = New System.Drawing.Size(642, 21)
        Me.certificateMasternodeEngine.TabIndex = 2
        '
        'certificateMasternodeEngineLabel
        '
        Me.certificateMasternodeEngineLabel.AutoSize = True
        Me.certificateMasternodeEngineLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeEngineLabel.Location = New System.Drawing.Point(14, 55)
        Me.certificateMasternodeEngineLabel.Name = "certificateMasternodeEngineLabel"
        Me.certificateMasternodeEngineLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeEngineLabel.TabIndex = 2
        Me.certificateMasternodeEngineLabel.Text = "Certificate"
        '
        'masternodeEngineURL
        '
        Me.masternodeEngineURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeEngineURL.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeEngineURL.Location = New System.Drawing.Point(169, 26)
        Me.masternodeEngineURL.Name = "masternodeEngineURL"
        Me.masternodeEngineURL.Size = New System.Drawing.Size(657, 21)
        Me.masternodeEngineURL.TabIndex = 1
        '
        'urlMasternodeEngineLabel
        '
        Me.urlMasternodeEngineLabel.AutoSize = True
        Me.urlMasternodeEngineLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlMasternodeEngineLabel.Location = New System.Drawing.Point(51, 29)
        Me.urlMasternodeEngineLabel.Name = "urlMasternodeEngineLabel"
        Me.urlMasternodeEngineLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlMasternodeEngineLabel.TabIndex = 0
        Me.urlMasternodeEngineLabel.Text = "URL"
        '
        'LogTab
        '
        Me.LogTab.Controls.Add(Me.logConsoleText)
        Me.LogTab.Location = New System.Drawing.Point(4, 22)
        Me.LogTab.Name = "LogTab"
        Me.LogTab.Padding = New System.Windows.Forms.Padding(3)
        Me.LogTab.Size = New System.Drawing.Size(905, 434)
        Me.LogTab.TabIndex = 1
        Me.LogTab.Text = "Output"
        Me.LogTab.UseVisualStyleBackColor = True
        '
        'logConsoleText
        '
        Me.logConsoleText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logConsoleText.BackColor = System.Drawing.Color.Black
        Me.logConsoleText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logConsoleText.ForeColor = System.Drawing.SystemColors.Info
        Me.logConsoleText.Location = New System.Drawing.Point(7, 6)
        Me.logConsoleText.Multiline = True
        Me.logConsoleText.Name = "logConsoleText"
        Me.logConsoleText.ReadOnly = True
        Me.logConsoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logConsoleText.Size = New System.Drawing.Size(890, 417)
        Me.logConsoleText.TabIndex = 0
        Me.logConsoleText.Text = "01234567890123456789012345678901234567890123456789012345678901234567890123456789"
        '
        'logFileButton
        '
        Me.logFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logFileButton.Enabled = False
        Me.logFileButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logFileButton.Location = New System.Drawing.Point(934, 198)
        Me.logFileButton.Name = "logFileButton"
        Me.logFileButton.Size = New System.Drawing.Size(106, 49)
        Me.logFileButton.TabIndex = 3
        Me.logFileButton.Text = "Log file"
        Me.logFileButton.UseVisualStyleBackColor = True
        '
        'registryEventButton
        '
        Me.registryEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.registryEventButton.Enabled = False
        Me.registryEventButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registryEventButton.Location = New System.Drawing.Point(934, 253)
        Me.registryEventButton.Name = "registryEventButton"
        Me.registryEventButton.Size = New System.Drawing.Size(106, 49)
        Me.registryEventButton.TabIndex = 4
        Me.registryEventButton.Text = "Registry Events"
        Me.registryEventButton.UseVisualStyleBackColor = True
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'informationButton
        '
        Me.informationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.informationButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.informationButton.Location = New System.Drawing.Point(936, 423)
        Me.informationButton.Name = "informationButton"
        Me.informationButton.Size = New System.Drawing.Size(106, 49)
        Me.informationButton.TabIndex = 6
        Me.informationButton.Text = "Info"
        Me.informationButton.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1054, 488)
        Me.Controls.Add(Me.informationButton)
        Me.Controls.Add(Me.registryEventButton)
        Me.Controls.Add(Me.logFileButton)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.refreshButton)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.startButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(3000, 527)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1070, 527)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Masternode Administration Service GUI Mode - Crypto Hide Coin DT"
        Me.tabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.autoCleanGroup.ResumeLayout(False)
        Me.autoCleanGroup.PerformLayout()
        Me.localPathAndDataPortNumber.ResumeLayout(False)
        Me.localPathAndDataPortNumber.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.masternodeClientGroup.ResumeLayout(False)
        Me.masternodeClientGroup.PerformLayout()
        Me.masternodeStartGroup.ResumeLayout(False)
        Me.masternodeStartGroup.PerformLayout()
        Me.masternodeEngineGroup.ResumeLayout(False)
        Me.masternodeEngineGroup.PerformLayout()
        Me.LogTab.ResumeLayout(False)
        Me.LogTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents refreshButton As Button
    Friend WithEvents stopButton As Button
    Friend WithEvents startButton As Button
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents tabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents rememberThis As CheckBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents writeLogFile As CheckBox
    Friend WithEvents localPathAndDataPortNumber As GroupBox
    Friend WithEvents localPortNumber As TextBox
    Friend WithEvents portNumberLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents localPathData As TextBox
    Friend WithEvents LogTab As TabPage
    Friend WithEvents logConsoleText As TextBox
    Friend WithEvents logFileButton As Button
    Friend WithEvents registryEventButton As Button
    Friend WithEvents publicWalletAddress As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents masternodeClientGroup As GroupBox
    Friend WithEvents certificateMasternodeClientBrowserButton As Button
    Friend WithEvents certificateClient As TextBox
    Friend WithEvents certificateMasternodeClientLabel As Label
    Friend WithEvents masternodeStartGroup As GroupBox
    Friend WithEvents certificateMasternodeBrowserButton As Button
    Friend WithEvents testMasternodeServiceButton As Button
    Friend WithEvents certificateMasternodeStart As TextBox
    Friend WithEvents certificateMasternodeLabel As Label
    Friend WithEvents masternodeStartUrl As TextBox
    Friend WithEvents urlMasternodeStartLabel As Label
    Friend WithEvents masternodeEngineGroup As GroupBox
    Friend WithEvents certificateMasternodeEngineBrowserButton As Button
    Friend WithEvents testMasternodeEngineServiceButton As Button
    Friend WithEvents certificateMasternodeEngine As TextBox
    Friend WithEvents certificateMasternodeEngineLabel As Label
    Friend WithEvents masternodeEngineURL As TextBox
    Friend WithEvents urlMasternodeEngineLabel As Label
    Friend WithEvents createNewCertificateClient As Button
    Friend WithEvents protocolMasternodeStart As ComboBox
    Friend WithEvents createNewCertificateUpgrade As Button
    Friend WithEvents protocolMasternodeEngine As ComboBox
    Friend WithEvents createNewCertificateEngine As Button
    Friend WithEvents autoCleanGroup As GroupBox
    Friend WithEvents keepFileType As Label
    Friend WithEvents keepFileTypeValue As ComboBox
    Friend WithEvents keepOnlyRecentFile As Label
    Friend WithEvents keepOnlyRecentFileValue As ComboBox
    Friend WithEvents startCleanEvery As Label
    Friend WithEvents startCleanEveryValue As ComboBox
    Friend WithEvents autoCleanOption As CheckBox
    Friend WithEvents informationButton As Button
End Class
