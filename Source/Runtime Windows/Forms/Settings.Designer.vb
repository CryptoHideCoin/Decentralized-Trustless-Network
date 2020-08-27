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
        Me.autoStart = New System.Windows.Forms.CheckBox()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.writeLogFile = New System.Windows.Forms.CheckBox()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.chainConfiguration = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.walletKey = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.walletAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.dataPath = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.noUpdateSystemDate = New System.Windows.Forms.CheckBox()
        Me.intranetMode = New System.Windows.Forms.CheckBox()
        Me.virtualName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabCommunication = New System.Windows.Forms.TabPage()
        Me.masternodeRuntimeGroup = New System.Windows.Forms.GroupBox()
        Me.certificateMasternodeRuntimeBrowserButton = New System.Windows.Forms.Button()
        Me.testMasternodeRuntimeButton = New System.Windows.Forms.Button()
        Me.certificateMasternodeStarter = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeRuntimeLabel = New System.Windows.Forms.Label()
        Me.masternodeStartURL = New System.Windows.Forms.TextBox()
        Me.urlMasternodeRuntimeLabel = New System.Windows.Forms.Label()
        Me.masternodeAdministrationGroup = New System.Windows.Forms.GroupBox()
        Me.certificateBrowserButton = New System.Windows.Forms.Button()
        Me.testMasternodeAdministration = New System.Windows.Forms.Button()
        Me.certificateMasternodeAdmin = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeAdministrationLabel = New System.Windows.Forms.Label()
        Me.masternodeAdminUrl = New System.Windows.Forms.TextBox()
        Me.urlMasternodeAdministrationLabel = New System.Windows.Forms.Label()
        Me.tabServices = New System.Windows.Forms.TabPage()
        Me.localPathAndDataPortNumber = New System.Windows.Forms.GroupBox()
        Me.exChangePort = New System.Windows.Forms.TextBox()
        Me.exChangeService = New System.Windows.Forms.CheckBox()
        Me.dnsPort = New System.Windows.Forms.TextBox()
        Me.dnsService = New System.Windows.Forms.CheckBox()
        Me.filePort = New System.Windows.Forms.TextBox()
        Me.fileService = New System.Windows.Forms.CheckBox()
        Me.chainPort = New System.Windows.Forms.TextBox()
        Me.chainService = New System.Windows.Forms.CheckBox()
        Me.publicPort = New System.Windows.Forms.TextBox()
        Me.publicService = New System.Windows.Forms.CheckBox()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.startButton = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tabMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabCommunication.SuspendLayout()
        Me.masternodeRuntimeGroup.SuspendLayout()
        Me.masternodeAdministrationGroup.SuspendLayout()
        Me.tabServices.SuspendLayout()
        Me.localPathAndDataPortNumber.SuspendLayout()
        Me.SuspendLayout()
        '
        'autoStart
        '
        Me.autoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.autoStart.AutoSize = True
        Me.autoStart.Checked = True
        Me.autoStart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoStart.Location = New System.Drawing.Point(576, 275)
        Me.autoStart.Name = "autoStart"
        Me.autoStart.Size = New System.Drawing.Size(78, 17)
        Me.autoStart.TabIndex = 5
        Me.autoStart.Text = "Autostart"
        Me.autoStart.UseVisualStyleBackColor = True
        '
        'useEventRegistry
        '
        Me.useEventRegistry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(392, 275)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 4
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'writeLogFile
        '
        Me.writeLogFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.writeLogFile.AutoSize = True
        Me.writeLogFile.Checked = True
        Me.writeLogFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.writeLogFile.Location = New System.Drawing.Point(239, 275)
        Me.writeLogFile.Name = "writeLogFile"
        Me.writeLogFile.Size = New System.Drawing.Size(103, 17)
        Me.writeLogFile.TabIndex = 3
        Me.writeLogFile.Text = "Write Log File"
        Me.writeLogFile.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.chainConfiguration)
        Me.tabMain.Controls.Add(Me.Label4)
        Me.tabMain.Controls.Add(Me.GroupBox2)
        Me.tabMain.Controls.Add(Me.GroupBox1)
        Me.tabMain.Controls.Add(Me.autoStart)
        Me.tabMain.Controls.Add(Me.useEventRegistry)
        Me.tabMain.Controls.Add(Me.writeLogFile)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(701, 332)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'chainConfiguration
        '
        Me.chainConfiguration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chainConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chainConfiguration.FormattingEnabled = True
        Me.chainConfiguration.Location = New System.Drawing.Point(238, 248)
        Me.chainConfiguration.Name = "chainConfiguration"
        Me.chainConfiguration.Size = New System.Drawing.Size(404, 21)
        Me.chainConfiguration.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Transaction Chain configuration"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.walletKey)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.walletAddress)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.browseLocalPath)
        Me.GroupBox2.Controls.Add(Me.dataPath)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(686, 148)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Local path data and wallet"
        '
        'walletKey
        '
        Me.walletKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.walletKey.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.walletKey.Location = New System.Drawing.Point(159, 84)
        Me.walletKey.Name = "walletKey"
        Me.walletKey.Size = New System.Drawing.Size(478, 21)
        Me.walletKey.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Private wallet key"
        '
        'walletAddress
        '
        Me.walletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.walletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.walletAddress.Location = New System.Drawing.Point(159, 57)
        Me.walletAddress.Name = "walletAddress"
        Me.walletAddress.Size = New System.Drawing.Size(478, 21)
        Me.walletAddress.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Public wallet address"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(644, 28)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(35, 23)
        Me.browseLocalPath.TabIndex = 1
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'dataPath
        '
        Me.dataPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataPath.Location = New System.Drawing.Point(8, 30)
        Me.dataPath.Name = "dataPath"
        Me.dataPath.Size = New System.Drawing.Size(628, 21)
        Me.dataPath.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.noUpdateSystemDate)
        Me.GroupBox1.Controls.Add(Me.intranetMode)
        Me.GroupBox1.Controls.Add(Me.virtualName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(686, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General"
        '
        'noUpdateSystemDate
        '
        Me.noUpdateSystemDate.AutoSize = True
        Me.noUpdateSystemDate.Checked = True
        Me.noUpdateSystemDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.noUpdateSystemDate.Location = New System.Drawing.Point(280, 50)
        Me.noUpdateSystemDate.Name = "noUpdateSystemDate"
        Me.noUpdateSystemDate.Size = New System.Drawing.Size(162, 17)
        Me.noUpdateSystemDate.TabIndex = 2
        Me.noUpdateSystemDate.Text = "No update System Date"
        Me.noUpdateSystemDate.UseVisualStyleBackColor = True
        '
        'intranetMode
        '
        Me.intranetMode.AutoSize = True
        Me.intranetMode.Checked = True
        Me.intranetMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.intranetMode.Location = New System.Drawing.Point(107, 50)
        Me.intranetMode.Name = "intranetMode"
        Me.intranetMode.Size = New System.Drawing.Size(108, 17)
        Me.intranetMode.TabIndex = 1
        Me.intranetMode.Text = "Intranet mode"
        Me.intranetMode.UseVisualStyleBackColor = True
        '
        'virtualName
        '
        Me.virtualName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.virtualName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.virtualName.Location = New System.Drawing.Point(107, 23)
        Me.virtualName.Name = "virtualName"
        Me.virtualName.Size = New System.Drawing.Size(528, 21)
        Me.virtualName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Virtual Name"
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabCommunication)
        Me.tabControl.Controls.Add(Me.tabServices)
        Me.tabControl.Location = New System.Drawing.Point(14, 14)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(709, 358)
        Me.tabControl.TabIndex = 0
        '
        'tabCommunication
        '
        Me.tabCommunication.Controls.Add(Me.masternodeRuntimeGroup)
        Me.tabCommunication.Controls.Add(Me.masternodeAdministrationGroup)
        Me.tabCommunication.Location = New System.Drawing.Point(4, 22)
        Me.tabCommunication.Name = "tabCommunication"
        Me.tabCommunication.Size = New System.Drawing.Size(701, 332)
        Me.tabCommunication.TabIndex = 1
        Me.tabCommunication.Text = "Interprocess"
        Me.tabCommunication.UseVisualStyleBackColor = True
        '
        'masternodeRuntimeGroup
        '
        Me.masternodeRuntimeGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeRuntimeGroup.Controls.Add(Me.certificateMasternodeRuntimeBrowserButton)
        Me.masternodeRuntimeGroup.Controls.Add(Me.testMasternodeRuntimeButton)
        Me.masternodeRuntimeGroup.Controls.Add(Me.certificateMasternodeStarter)
        Me.masternodeRuntimeGroup.Controls.Add(Me.certificateMasternodeRuntimeLabel)
        Me.masternodeRuntimeGroup.Controls.Add(Me.masternodeStartURL)
        Me.masternodeRuntimeGroup.Controls.Add(Me.urlMasternodeRuntimeLabel)
        Me.masternodeRuntimeGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeRuntimeGroup.Location = New System.Drawing.Point(6, 111)
        Me.masternodeRuntimeGroup.Name = "masternodeRuntimeGroup"
        Me.masternodeRuntimeGroup.Size = New System.Drawing.Size(687, 91)
        Me.masternodeRuntimeGroup.TabIndex = 1
        Me.masternodeRuntimeGroup.TabStop = False
        Me.masternodeRuntimeGroup.Text = "Masternode Starter"
        '
        'certificateMasternodeRuntimeBrowserButton
        '
        Me.certificateMasternodeRuntimeBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeRuntimeBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeRuntimeBrowserButton.Location = New System.Drawing.Point(591, 51)
        Me.certificateMasternodeRuntimeBrowserButton.Name = "certificateMasternodeRuntimeBrowserButton"
        Me.certificateMasternodeRuntimeBrowserButton.Size = New System.Drawing.Size(31, 22)
        Me.certificateMasternodeRuntimeBrowserButton.TabIndex = 2
        Me.certificateMasternodeRuntimeBrowserButton.Text = "..."
        Me.certificateMasternodeRuntimeBrowserButton.UseVisualStyleBackColor = True
        '
        'testMasternodeRuntimeButton
        '
        Me.testMasternodeRuntimeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testMasternodeRuntimeButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testMasternodeRuntimeButton.Location = New System.Drawing.Point(630, 25)
        Me.testMasternodeRuntimeButton.Name = "testMasternodeRuntimeButton"
        Me.testMasternodeRuntimeButton.Size = New System.Drawing.Size(50, 48)
        Me.testMasternodeRuntimeButton.TabIndex = 3
        Me.testMasternodeRuntimeButton.Text = "Test"
        Me.testMasternodeRuntimeButton.UseVisualStyleBackColor = True
        '
        'certificateMasternodeStarter
        '
        Me.certificateMasternodeStarter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeStarter.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeStarter.Location = New System.Drawing.Point(93, 52)
        Me.certificateMasternodeStarter.Name = "certificateMasternodeStarter"
        Me.certificateMasternodeStarter.Size = New System.Drawing.Size(493, 21)
        Me.certificateMasternodeStarter.TabIndex = 1
        '
        'certificateMasternodeRuntimeLabel
        '
        Me.certificateMasternodeRuntimeLabel.AutoSize = True
        Me.certificateMasternodeRuntimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeRuntimeLabel.Location = New System.Drawing.Point(8, 55)
        Me.certificateMasternodeRuntimeLabel.Name = "certificateMasternodeRuntimeLabel"
        Me.certificateMasternodeRuntimeLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeRuntimeLabel.TabIndex = 2
        Me.certificateMasternodeRuntimeLabel.Text = "Certificate"
        '
        'masternodeStartURL
        '
        Me.masternodeStartURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeStartURL.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeStartURL.Location = New System.Drawing.Point(93, 26)
        Me.masternodeStartURL.Name = "masternodeStartURL"
        Me.masternodeStartURL.Size = New System.Drawing.Size(529, 21)
        Me.masternodeStartURL.TabIndex = 0
        '
        'urlMasternodeRuntimeLabel
        '
        Me.urlMasternodeRuntimeLabel.AutoSize = True
        Me.urlMasternodeRuntimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlMasternodeRuntimeLabel.Location = New System.Drawing.Point(51, 29)
        Me.urlMasternodeRuntimeLabel.Name = "urlMasternodeRuntimeLabel"
        Me.urlMasternodeRuntimeLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlMasternodeRuntimeLabel.TabIndex = 0
        Me.urlMasternodeRuntimeLabel.Text = "URL"
        '
        'masternodeAdministrationGroup
        '
        Me.masternodeAdministrationGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeAdministrationGroup.Controls.Add(Me.certificateBrowserButton)
        Me.masternodeAdministrationGroup.Controls.Add(Me.testMasternodeAdministration)
        Me.masternodeAdministrationGroup.Controls.Add(Me.certificateMasternodeAdmin)
        Me.masternodeAdministrationGroup.Controls.Add(Me.certificateMasternodeAdministrationLabel)
        Me.masternodeAdministrationGroup.Controls.Add(Me.masternodeAdminUrl)
        Me.masternodeAdministrationGroup.Controls.Add(Me.urlMasternodeAdministrationLabel)
        Me.masternodeAdministrationGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeAdministrationGroup.Location = New System.Drawing.Point(7, 14)
        Me.masternodeAdministrationGroup.Name = "masternodeAdministrationGroup"
        Me.masternodeAdministrationGroup.Size = New System.Drawing.Size(686, 91)
        Me.masternodeAdministrationGroup.TabIndex = 0
        Me.masternodeAdministrationGroup.TabStop = False
        Me.masternodeAdministrationGroup.Text = "Masternode Administration"
        '
        'certificateBrowserButton
        '
        Me.certificateBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateBrowserButton.Location = New System.Drawing.Point(590, 51)
        Me.certificateBrowserButton.Name = "certificateBrowserButton"
        Me.certificateBrowserButton.Size = New System.Drawing.Size(31, 22)
        Me.certificateBrowserButton.TabIndex = 2
        Me.certificateBrowserButton.Text = "..."
        Me.certificateBrowserButton.UseVisualStyleBackColor = True
        '
        'testMasternodeAdministration
        '
        Me.testMasternodeAdministration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testMasternodeAdministration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testMasternodeAdministration.Location = New System.Drawing.Point(629, 25)
        Me.testMasternodeAdministration.Name = "testMasternodeAdministration"
        Me.testMasternodeAdministration.Size = New System.Drawing.Size(50, 48)
        Me.testMasternodeAdministration.TabIndex = 3
        Me.testMasternodeAdministration.Text = "Test"
        Me.testMasternodeAdministration.UseVisualStyleBackColor = True
        '
        'certificateMasternodeAdmin
        '
        Me.certificateMasternodeAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeAdmin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeAdmin.Location = New System.Drawing.Point(92, 52)
        Me.certificateMasternodeAdmin.Name = "certificateMasternodeAdmin"
        Me.certificateMasternodeAdmin.Size = New System.Drawing.Size(493, 21)
        Me.certificateMasternodeAdmin.TabIndex = 1
        '
        'certificateMasternodeAdministrationLabel
        '
        Me.certificateMasternodeAdministrationLabel.AutoSize = True
        Me.certificateMasternodeAdministrationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeAdministrationLabel.Location = New System.Drawing.Point(8, 55)
        Me.certificateMasternodeAdministrationLabel.Name = "certificateMasternodeAdministrationLabel"
        Me.certificateMasternodeAdministrationLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeAdministrationLabel.TabIndex = 2
        Me.certificateMasternodeAdministrationLabel.Text = "Certificate"
        '
        'masternodeAdminUrl
        '
        Me.masternodeAdminUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeAdminUrl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeAdminUrl.Location = New System.Drawing.Point(92, 26)
        Me.masternodeAdminUrl.Name = "masternodeAdminUrl"
        Me.masternodeAdminUrl.Size = New System.Drawing.Size(529, 21)
        Me.masternodeAdminUrl.TabIndex = 0
        '
        'urlMasternodeAdministrationLabel
        '
        Me.urlMasternodeAdministrationLabel.AutoSize = True
        Me.urlMasternodeAdministrationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlMasternodeAdministrationLabel.Location = New System.Drawing.Point(50, 29)
        Me.urlMasternodeAdministrationLabel.Name = "urlMasternodeAdministrationLabel"
        Me.urlMasternodeAdministrationLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlMasternodeAdministrationLabel.TabIndex = 0
        Me.urlMasternodeAdministrationLabel.Text = "URL"
        '
        'tabServices
        '
        Me.tabServices.Controls.Add(Me.localPathAndDataPortNumber)
        Me.tabServices.Location = New System.Drawing.Point(4, 22)
        Me.tabServices.Name = "tabServices"
        Me.tabServices.Size = New System.Drawing.Size(701, 332)
        Me.tabServices.TabIndex = 2
        Me.tabServices.Text = "Services"
        Me.tabServices.UseVisualStyleBackColor = True
        '
        'localPathAndDataPortNumber
        '
        Me.localPathAndDataPortNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathAndDataPortNumber.Controls.Add(Me.exChangePort)
        Me.localPathAndDataPortNumber.Controls.Add(Me.exChangeService)
        Me.localPathAndDataPortNumber.Controls.Add(Me.dnsPort)
        Me.localPathAndDataPortNumber.Controls.Add(Me.dnsService)
        Me.localPathAndDataPortNumber.Controls.Add(Me.filePort)
        Me.localPathAndDataPortNumber.Controls.Add(Me.fileService)
        Me.localPathAndDataPortNumber.Controls.Add(Me.chainPort)
        Me.localPathAndDataPortNumber.Controls.Add(Me.chainService)
        Me.localPathAndDataPortNumber.Controls.Add(Me.publicPort)
        Me.localPathAndDataPortNumber.Controls.Add(Me.publicService)
        Me.localPathAndDataPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathAndDataPortNumber.Location = New System.Drawing.Point(7, 3)
        Me.localPathAndDataPortNumber.Name = "localPathAndDataPortNumber"
        Me.localPathAndDataPortNumber.Size = New System.Drawing.Size(686, 182)
        Me.localPathAndDataPortNumber.TabIndex = 0
        Me.localPathAndDataPortNumber.TabStop = False
        Me.localPathAndDataPortNumber.Text = "Configuration Port"
        '
        'exChangePort
        '
        Me.exChangePort.Enabled = False
        Me.exChangePort.Location = New System.Drawing.Point(322, 136)
        Me.exChangePort.Name = "exChangePort"
        Me.exChangePort.Size = New System.Drawing.Size(116, 21)
        Me.exChangePort.TabIndex = 9
        Me.exChangePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'exChangeService
        '
        Me.exChangeService.AutoSize = True
        Me.exChangeService.Enabled = False
        Me.exChangeService.Location = New System.Drawing.Point(167, 138)
        Me.exChangeService.Name = "exChangeService"
        Me.exChangeService.Size = New System.Drawing.Size(126, 17)
        Me.exChangeService.TabIndex = 8
        Me.exChangeService.Text = "Exchange service"
        Me.exChangeService.UseVisualStyleBackColor = True
        '
        'dnsPort
        '
        Me.dnsPort.Enabled = False
        Me.dnsPort.Location = New System.Drawing.Point(322, 109)
        Me.dnsPort.Name = "dnsPort"
        Me.dnsPort.Size = New System.Drawing.Size(116, 21)
        Me.dnsPort.TabIndex = 7
        Me.dnsPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dnsService
        '
        Me.dnsService.AutoSize = True
        Me.dnsService.Enabled = False
        Me.dnsService.Location = New System.Drawing.Point(167, 110)
        Me.dnsService.Name = "dnsService"
        Me.dnsService.Size = New System.Drawing.Size(96, 17)
        Me.dnsService.TabIndex = 6
        Me.dnsService.Text = "DNS service"
        Me.dnsService.UseVisualStyleBackColor = True
        '
        'filePort
        '
        Me.filePort.Enabled = False
        Me.filePort.Location = New System.Drawing.Point(322, 82)
        Me.filePort.Name = "filePort"
        Me.filePort.Size = New System.Drawing.Size(116, 21)
        Me.filePort.TabIndex = 5
        Me.filePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fileService
        '
        Me.fileService.AutoSize = True
        Me.fileService.Enabled = False
        Me.fileService.Location = New System.Drawing.Point(167, 83)
        Me.fileService.Name = "fileService"
        Me.fileService.Size = New System.Drawing.Size(90, 17)
        Me.fileService.TabIndex = 4
        Me.fileService.Text = "File service"
        Me.fileService.UseVisualStyleBackColor = True
        '
        'chainPort
        '
        Me.chainPort.Enabled = False
        Me.chainPort.Location = New System.Drawing.Point(322, 55)
        Me.chainPort.Name = "chainPort"
        Me.chainPort.Size = New System.Drawing.Size(116, 21)
        Me.chainPort.TabIndex = 3
        Me.chainPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chainService
        '
        Me.chainService.AutoSize = True
        Me.chainService.Location = New System.Drawing.Point(167, 56)
        Me.chainService.Name = "chainService"
        Me.chainService.Size = New System.Drawing.Size(104, 17)
        Me.chainService.TabIndex = 2
        Me.chainService.Text = "Chain service"
        Me.chainService.UseVisualStyleBackColor = True
        '
        'publicPort
        '
        Me.publicPort.Enabled = False
        Me.publicPort.Location = New System.Drawing.Point(322, 28)
        Me.publicPort.Name = "publicPort"
        Me.publicPort.Size = New System.Drawing.Size(116, 21)
        Me.publicPort.TabIndex = 1
        Me.publicPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'publicService
        '
        Me.publicService.AutoSize = True
        Me.publicService.Location = New System.Drawing.Point(167, 29)
        Me.publicService.Name = "publicService"
        Me.publicService.Size = New System.Drawing.Size(104, 17)
        Me.publicService.TabIndex = 0
        Me.publicService.Text = "Public service"
        Me.publicService.UseVisualStyleBackColor = True
        '
        'startButton
        '
        Me.startButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(730, 50)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(106, 49)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "Save"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(850, 386)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.startButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(2000, 425)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 425)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Masternode Runtime Settings"
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabCommunication.ResumeLayout(False)
        Me.masternodeRuntimeGroup.ResumeLayout(False)
        Me.masternodeRuntimeGroup.PerformLayout()
        Me.masternodeAdministrationGroup.ResumeLayout(False)
        Me.masternodeAdministrationGroup.PerformLayout()
        Me.tabServices.ResumeLayout(False)
        Me.localPathAndDataPortNumber.ResumeLayout(False)
        Me.localPathAndDataPortNumber.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents autoStart As CheckBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents writeLogFile As CheckBox
    Friend WithEvents tabMain As TabPage
    Friend WithEvents tabControl As TabControl
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents startButton As Button
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents noUpdateSystemDate As CheckBox
    Friend WithEvents intranetMode As CheckBox
    Friend WithEvents virtualName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents walletKey As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents walletAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents dataPath As TextBox
    Friend WithEvents tabCommunication As TabPage
    Friend WithEvents masternodeAdministrationGroup As GroupBox
    Friend WithEvents certificateBrowserButton As Button
    Friend WithEvents testMasternodeAdministration As Button
    Friend WithEvents certificateMasternodeAdmin As TextBox
    Friend WithEvents certificateMasternodeAdministrationLabel As Label
    Friend WithEvents masternodeAdminUrl As TextBox
    Friend WithEvents urlMasternodeAdministrationLabel As Label
    Friend WithEvents tabServices As TabPage
    Friend WithEvents localPathAndDataPortNumber As GroupBox
    Friend WithEvents chainPort As TextBox
    Friend WithEvents chainService As CheckBox
    Friend WithEvents publicPort As TextBox
    Friend WithEvents publicService As CheckBox
    Friend WithEvents exChangePort As TextBox
    Friend WithEvents exChangeService As CheckBox
    Friend WithEvents dnsPort As TextBox
    Friend WithEvents dnsService As CheckBox
    Friend WithEvents filePort As TextBox
    Friend WithEvents fileService As CheckBox
    Friend WithEvents masternodeRuntimeGroup As GroupBox
    Friend WithEvents certificateMasternodeRuntimeBrowserButton As Button
    Friend WithEvents testMasternodeRuntimeButton As Button
    Friend WithEvents certificateMasternodeStarter As TextBox
    Friend WithEvents certificateMasternodeRuntimeLabel As Label
    Friend WithEvents masternodeStartURL As TextBox
    Friend WithEvents urlMasternodeRuntimeLabel As Label
    Friend WithEvents chainConfiguration As ComboBox
    Friend WithEvents Label4 As Label
End Class
