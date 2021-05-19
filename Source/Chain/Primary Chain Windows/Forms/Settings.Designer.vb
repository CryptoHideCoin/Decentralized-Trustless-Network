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
        Me.startButton = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tabCommunication = New System.Windows.Forms.TabPage()
        Me.masternodeAdministrationGroup = New System.Windows.Forms.GroupBox()
        Me.urlMasternodeAdministrationLabel = New System.Windows.Forms.Label()
        Me.masternodeAdminUrl = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeAdministrationLabel = New System.Windows.Forms.Label()
        Me.certificateMasternodeAdmin = New System.Windows.Forms.TextBox()
        Me.testMasternodeAdministration = New System.Windows.Forms.Button()
        Me.certificateBrowserButton = New System.Windows.Forms.Button()
        Me.masternodeRuntimeGroup = New System.Windows.Forms.GroupBox()
        Me.urlMasternodeRuntimeLabel = New System.Windows.Forms.Label()
        Me.masternodeStartURL = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeRuntimeLabel = New System.Windows.Forms.Label()
        Me.certificateMasternodeStarter = New System.Windows.Forms.TextBox()
        Me.testMasternodeRuntimeButton = New System.Windows.Forms.Button()
        Me.certificateMasternodeRuntimeBrowserButton = New System.Windows.Forms.Button()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.virtualName = New System.Windows.Forms.TextBox()
        Me.intranetMode = New System.Windows.Forms.CheckBox()
        Me.noUpdateSystemDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dataPath = New System.Windows.Forms.TextBox()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.walletAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.walletKey = New System.Windows.Forms.TextBox()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.localPortNumber = New System.Windows.Forms.TextBox()
        Me.portNumberLabel = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabInternal = New System.Windows.Forms.TabPage()
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
        Me.tabCommunication.SuspendLayout()
        Me.masternodeAdministrationGroup.SuspendLayout()
        Me.masternodeRuntimeGroup.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabInternal.SuspendLayout()
        Me.autoCleanGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'startButton
        '
        Me.startButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(732, 33)
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
        'tabCommunication
        '
        Me.tabCommunication.Controls.Add(Me.masternodeRuntimeGroup)
        Me.tabCommunication.Controls.Add(Me.masternodeAdministrationGroup)
        Me.tabCommunication.Location = New System.Drawing.Point(4, 22)
        Me.tabCommunication.Name = "tabCommunication"
        Me.tabCommunication.Size = New System.Drawing.Size(701, 289)
        Me.tabCommunication.TabIndex = 1
        Me.tabCommunication.Text = "Interprocess"
        Me.tabCommunication.UseVisualStyleBackColor = True
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
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.GroupBox2)
        Me.tabMain.Controls.Add(Me.GroupBox1)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(701, 289)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Size = New System.Drawing.Size(686, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General"
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.localPortNumber)
        Me.GroupBox2.Controls.Add(Me.portNumberLabel)
        Me.GroupBox2.Controls.Add(Me.walletKey)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.walletAddress)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.browseLocalPath)
        Me.GroupBox2.Controls.Add(Me.dataPath)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(686, 176)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Local path data and wallet"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Private key"
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
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabCommunication)
        Me.tabControl.Controls.Add(Me.tabInternal)
        Me.tabControl.Location = New System.Drawing.Point(14, 14)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(709, 315)
        Me.tabControl.TabIndex = 0
        '
        'localPortNumber
        '
        Me.localPortNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPortNumber.Location = New System.Drawing.Point(548, 111)
        Me.localPortNumber.Name = "localPortNumber"
        Me.localPortNumber.Size = New System.Drawing.Size(87, 21)
        Me.localPortNumber.TabIndex = 10
        Me.localPortNumber.Text = "0"
        Me.localPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'portNumberLabel
        '
        Me.portNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.portNumberLabel.AutoSize = True
        Me.portNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumberLabel.Location = New System.Drawing.Point(365, 114)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(179, 13)
        Me.portNumberLabel.TabIndex = 9
        Me.portNumberLabel.Text = "Public port number (0..65535)"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(550, 138)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(87, 21)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(358, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Service port number (0..65535)"
        '
        'tabInternal
        '
        Me.tabInternal.Controls.Add(Me.autoCleanGroup)
        Me.tabInternal.Controls.Add(Me.rememberThis)
        Me.tabInternal.Controls.Add(Me.useEventRegistry)
        Me.tabInternal.Controls.Add(Me.writeLogFile)
        Me.tabInternal.Location = New System.Drawing.Point(4, 22)
        Me.tabInternal.Name = "tabInternal"
        Me.tabInternal.Size = New System.Drawing.Size(701, 289)
        Me.tabInternal.TabIndex = 2
        Me.tabInternal.Text = "Internal"
        Me.tabInternal.UseVisualStyleBackColor = True
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
        Me.autoCleanGroup.Location = New System.Drawing.Point(12, 46)
        Me.autoCleanGroup.Name = "autoCleanGroup"
        Me.autoCleanGroup.Size = New System.Drawing.Size(674, 88)
        Me.autoCleanGroup.TabIndex = 7
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
        Me.rememberThis.Location = New System.Drawing.Point(20, 140)
        Me.rememberThis.Name = "rememberThis"
        Me.rememberThis.Size = New System.Drawing.Size(161, 17)
        Me.rememberThis.TabIndex = 8
        Me.rememberThis.Text = "Remember this settings"
        Me.rememberThis.UseVisualStyleBackColor = True
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(178, 14)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 6
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'writeLogFile
        '
        Me.writeLogFile.AutoSize = True
        Me.writeLogFile.Checked = True
        Me.writeLogFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.writeLogFile.Location = New System.Drawing.Point(20, 14)
        Me.writeLogFile.Name = "writeLogFile"
        Me.writeLogFile.Size = New System.Drawing.Size(103, 17)
        Me.writeLogFile.TabIndex = 5
        Me.writeLogFile.Text = "Write Log File"
        Me.writeLogFile.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(850, 341)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.startButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(2000, 380)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 380)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Masternode Primary Runtime Settings - Crypto Hide Coin"
        Me.tabCommunication.ResumeLayout(False)
        Me.masternodeAdministrationGroup.ResumeLayout(False)
        Me.masternodeAdministrationGroup.PerformLayout()
        Me.masternodeRuntimeGroup.ResumeLayout(False)
        Me.masternodeRuntimeGroup.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabInternal.ResumeLayout(False)
        Me.tabInternal.PerformLayout()
        Me.autoCleanGroup.ResumeLayout(False)
        Me.autoCleanGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents startButton As Button
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents tabCommunication As TabPage
    Friend WithEvents masternodeRuntimeGroup As GroupBox
    Friend WithEvents certificateMasternodeRuntimeBrowserButton As Button
    Friend WithEvents testMasternodeRuntimeButton As Button
    Friend WithEvents certificateMasternodeStarter As TextBox
    Friend WithEvents certificateMasternodeRuntimeLabel As Label
    Friend WithEvents masternodeStartURL As TextBox
    Friend WithEvents urlMasternodeRuntimeLabel As Label
    Friend WithEvents masternodeAdministrationGroup As GroupBox
    Friend WithEvents certificateBrowserButton As Button
    Friend WithEvents testMasternodeAdministration As Button
    Friend WithEvents certificateMasternodeAdmin As TextBox
    Friend WithEvents certificateMasternodeAdministrationLabel As Label
    Friend WithEvents masternodeAdminUrl As TextBox
    Friend WithEvents urlMasternodeAdministrationLabel As Label
    Friend WithEvents tabMain As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents walletKey As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents walletAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents dataPath As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents noUpdateSystemDate As CheckBox
    Friend WithEvents intranetMode As CheckBox
    Friend WithEvents virtualName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tabControl As TabControl
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents localPortNumber As TextBox
    Friend WithEvents portNumberLabel As Label
    Friend WithEvents tabInternal As TabPage
    Friend WithEvents autoCleanGroup As GroupBox
    Friend WithEvents keepFileType As Label
    Friend WithEvents keepFileTypeValue As ComboBox
    Friend WithEvents keepOnlyRecentFile As Label
    Friend WithEvents keepOnlyRecentFileValue As ComboBox
    Friend WithEvents startCleanEvery As Label
    Friend WithEvents startCleanEveryValue As ComboBox
    Friend WithEvents autoCleanOption As CheckBox
    Friend WithEvents rememberThis As CheckBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents writeLogFile As CheckBox
End Class
