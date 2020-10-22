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
        Me.certificateBrowserButton = New System.Windows.Forms.Button()
        Me.testServiceAdministration = New System.Windows.Forms.Button()
        Me.certificateServiceAdmin = New System.Windows.Forms.TextBox()
        Me.certificateServiceAdministrationLabel = New System.Windows.Forms.Label()
        Me.localPathAndDataPortNumber = New System.Windows.Forms.GroupBox()
        Me.publicWalletAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.localPortNumber = New System.Windows.Forms.TextBox()
        Me.portNumberLabel = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.localPathData = New System.Windows.Forms.TextBox()
        Me.logTabPage = New System.Windows.Forms.TabPage()
        Me.logConsoleText = New System.Windows.Forms.TextBox()
        Me.registryEventButton = New System.Windows.Forms.Button()
        Me.serviceAdminUrl = New System.Windows.Forms.TextBox()
        Me.logFileButton = New System.Windows.Forms.Button()
        Me.serviceAdministrationGroup = New System.Windows.Forms.GroupBox()
        Me.protocolServiceAdmin = New System.Windows.Forms.ComboBox()
        Me.urlServiceAdministrationLabel = New System.Windows.Forms.Label()
        Me.rememberThis = New System.Windows.Forms.CheckBox()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.generalTabPage = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.keepFileType = New System.Windows.Forms.Label()
        Me.keepFileTypeValue = New System.Windows.Forms.ComboBox()
        Me.keepOnlyRecentFile = New System.Windows.Forms.Label()
        Me.keepOnlyRecentFileValue = New System.Windows.Forms.ComboBox()
        Me.startCleanEvery = New System.Windows.Forms.Label()
        Me.startCleanEveryValue = New System.Windows.Forms.ComboBox()
        Me.autoCleanOption = New System.Windows.Forms.CheckBox()
        Me.trackConfiguration = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.debugModeCheck = New System.Windows.Forms.CheckBox()
        Me.autoStart = New System.Windows.Forms.CheckBox()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.upgradeTabPage = New System.Windows.Forms.TabPage()
        Me.createNewCertificateUpgrade = New System.Windows.Forms.Button()
        Me.frequencyUpgradeValue = New System.Windows.Forms.ComboBox()
        Me.frequencyUpgradeLabel = New System.Windows.Forms.Label()
        Me.certificateUpgradeBrowserButton = New System.Windows.Forms.Button()
        Me.certificateUpgradeValue = New System.Windows.Forms.TextBox()
        Me.certificateUpgradeLabel = New System.Windows.Forms.Label()
        Me.checkUpgrade = New System.Windows.Forms.CheckBox()
        Me.sourceUpgrade = New System.Windows.Forms.GroupBox()
        Me.addressSourceUpgradeValue = New System.Windows.Forms.TextBox()
        Me.addressLabel = New System.Windows.Forms.Label()
        Me.sourceDynamicAddress = New System.Windows.Forms.RadioButton()
        Me.sourceUpgradeStaticAddress = New System.Windows.Forms.RadioButton()
        Me.servicesTabPage = New System.Windows.Forms.TabPage()
        Me.newCertificateDetailButton = New System.Windows.Forms.Button()
        Me.protocolURLDetailCombo = New System.Windows.Forms.ComboBox()
        Me.certificateDetailButton = New System.Windows.Forms.Button()
        Me.certificateDetailValue = New System.Windows.Forms.TextBox()
        Me.certificateDetailLabel = New System.Windows.Forms.Label()
        Me.urlDetailValue = New System.Windows.Forms.TextBox()
        Me.urlDetailLabel = New System.Windows.Forms.Label()
        Me.completeApplicationDetailButton = New System.Windows.Forms.Button()
        Me.cancelDetailButton = New System.Windows.Forms.Button()
        Me.confirmDetailButton = New System.Windows.Forms.Button()
        Me.completeApplicationPathValue = New System.Windows.Forms.TextBox()
        Me.completeApplicationPathLabel = New System.Windows.Forms.Label()
        Me.addNewService = New System.Windows.Forms.Button()
        Me.applicationDataGrid = New System.Windows.Forms.DataGridView()
        Me.rowIndexPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.applicationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.stopButton = New System.Windows.Forms.Button()
        Me.startButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.localPathAndDataPortNumber.SuspendLayout()
        Me.logTabPage.SuspendLayout()
        Me.serviceAdministrationGroup.SuspendLayout()
        Me.generalTabPage.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.upgradeTabPage.SuspendLayout()
        Me.sourceUpgrade.SuspendLayout()
        Me.servicesTabPage.SuspendLayout()
        CType(Me.applicationDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'certificateBrowserButton
        '
        Me.certificateBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateBrowserButton.Location = New System.Drawing.Point(590, 51)
        Me.certificateBrowserButton.Name = "certificateBrowserButton"
        Me.certificateBrowserButton.Size = New System.Drawing.Size(31, 22)
        Me.certificateBrowserButton.TabIndex = 3
        Me.certificateBrowserButton.Text = "..."
        Me.certificateBrowserButton.UseVisualStyleBackColor = True
        '
        'testServiceAdministration
        '
        Me.testServiceAdministration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testServiceAdministration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testServiceAdministration.Location = New System.Drawing.Point(629, 25)
        Me.testServiceAdministration.Name = "testServiceAdministration"
        Me.testServiceAdministration.Size = New System.Drawing.Size(50, 48)
        Me.testServiceAdministration.TabIndex = 4
        Me.testServiceAdministration.Text = "Test"
        Me.testServiceAdministration.UseVisualStyleBackColor = True
        '
        'certificateServiceAdmin
        '
        Me.certificateServiceAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateServiceAdmin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateServiceAdmin.Location = New System.Drawing.Point(92, 52)
        Me.certificateServiceAdmin.Name = "certificateServiceAdmin"
        Me.certificateServiceAdmin.Size = New System.Drawing.Size(493, 21)
        Me.certificateServiceAdmin.TabIndex = 2
        '
        'certificateServiceAdministrationLabel
        '
        Me.certificateServiceAdministrationLabel.AutoSize = True
        Me.certificateServiceAdministrationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateServiceAdministrationLabel.Location = New System.Drawing.Point(13, 56)
        Me.certificateServiceAdministrationLabel.Name = "certificateServiceAdministrationLabel"
        Me.certificateServiceAdministrationLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateServiceAdministrationLabel.TabIndex = 2
        Me.certificateServiceAdministrationLabel.Text = "Certificate"
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
        Me.localPathAndDataPortNumber.Size = New System.Drawing.Size(686, 116)
        Me.localPathAndDataPortNumber.TabIndex = 0
        Me.localPathAndDataPortNumber.TabStop = False
        Me.localPathAndDataPortNumber.Text = "Local path data and port number"
        '
        'publicWalletAddress
        '
        Me.publicWalletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicWalletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicWalletAddress.Location = New System.Drawing.Point(140, 57)
        Me.publicWalletAddress.Name = "publicWalletAddress"
        Me.publicWalletAddress.Size = New System.Drawing.Size(496, 21)
        Me.publicWalletAddress.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Public wallet address"
        '
        'localPortNumber
        '
        Me.localPortNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPortNumber.Location = New System.Drawing.Point(549, 84)
        Me.localPortNumber.Name = "localPortNumber"
        Me.localPortNumber.Size = New System.Drawing.Size(87, 21)
        Me.localPortNumber.TabIndex = 3
        Me.localPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'portNumberLabel
        '
        Me.portNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.portNumberLabel.AutoSize = True
        Me.portNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumberLabel.Location = New System.Drawing.Point(377, 87)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(142, 13)
        Me.portNumberLabel.TabIndex = 2
        Me.portNumberLabel.Text = "Port number (1..65535)"
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
        'localPathData
        '
        Me.localPathData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathData.Location = New System.Drawing.Point(8, 30)
        Me.localPathData.Name = "localPathData"
        Me.localPathData.Size = New System.Drawing.Size(628, 21)
        Me.localPathData.TabIndex = 0
        '
        'logTabPage
        '
        Me.logTabPage.Controls.Add(Me.logConsoleText)
        Me.logTabPage.Location = New System.Drawing.Point(4, 22)
        Me.logTabPage.Name = "logTabPage"
        Me.logTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.logTabPage.Size = New System.Drawing.Size(701, 399)
        Me.logTabPage.TabIndex = 1
        Me.logTabPage.Text = "Output"
        Me.logTabPage.UseVisualStyleBackColor = True
        '
        'logConsoleText
        '
        Me.logConsoleText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logConsoleText.BackColor = System.Drawing.Color.Black
        Me.logConsoleText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logConsoleText.ForeColor = System.Drawing.SystemColors.Info
        Me.logConsoleText.Location = New System.Drawing.Point(7, 6)
        Me.logConsoleText.Multiline = True
        Me.logConsoleText.Name = "logConsoleText"
        Me.logConsoleText.ReadOnly = True
        Me.logConsoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logConsoleText.Size = New System.Drawing.Size(688, 417)
        Me.logConsoleText.TabIndex = 0
        Me.logConsoleText.Text = "01234567890123456789012345678901234567890123456789012345678901234567890123456789"
        '
        'registryEventButton
        '
        Me.registryEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.registryEventButton.Enabled = False
        Me.registryEventButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registryEventButton.Location = New System.Drawing.Point(730, 251)
        Me.registryEventButton.Name = "registryEventButton"
        Me.registryEventButton.Size = New System.Drawing.Size(106, 49)
        Me.registryEventButton.TabIndex = 4
        Me.registryEventButton.Text = "Registry Events"
        Me.registryEventButton.UseVisualStyleBackColor = True
        '
        'serviceAdminUrl
        '
        Me.serviceAdminUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceAdminUrl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceAdminUrl.Location = New System.Drawing.Point(181, 26)
        Me.serviceAdminUrl.Name = "serviceAdminUrl"
        Me.serviceAdminUrl.Size = New System.Drawing.Size(440, 21)
        Me.serviceAdminUrl.TabIndex = 1
        '
        'logFileButton
        '
        Me.logFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logFileButton.Enabled = False
        Me.logFileButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logFileButton.Location = New System.Drawing.Point(730, 196)
        Me.logFileButton.Name = "logFileButton"
        Me.logFileButton.Size = New System.Drawing.Size(106, 49)
        Me.logFileButton.TabIndex = 3
        Me.logFileButton.Text = "Log file"
        Me.logFileButton.UseVisualStyleBackColor = True
        '
        'serviceAdministrationGroup
        '
        Me.serviceAdministrationGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceAdministrationGroup.Controls.Add(Me.protocolServiceAdmin)
        Me.serviceAdministrationGroup.Controls.Add(Me.certificateBrowserButton)
        Me.serviceAdministrationGroup.Controls.Add(Me.testServiceAdministration)
        Me.serviceAdministrationGroup.Controls.Add(Me.certificateServiceAdmin)
        Me.serviceAdministrationGroup.Controls.Add(Me.certificateServiceAdministrationLabel)
        Me.serviceAdministrationGroup.Controls.Add(Me.serviceAdminUrl)
        Me.serviceAdministrationGroup.Controls.Add(Me.urlServiceAdministrationLabel)
        Me.serviceAdministrationGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceAdministrationGroup.Location = New System.Drawing.Point(7, 128)
        Me.serviceAdministrationGroup.Name = "serviceAdministrationGroup"
        Me.serviceAdministrationGroup.Size = New System.Drawing.Size(686, 91)
        Me.serviceAdministrationGroup.TabIndex = 1
        Me.serviceAdministrationGroup.TabStop = False
        Me.serviceAdministrationGroup.Text = "Service Administration"
        '
        'protocolServiceAdmin
        '
        Me.protocolServiceAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.protocolServiceAdmin.FormattingEnabled = True
        Me.protocolServiceAdmin.Items.AddRange(New Object() {"http://", "https://"})
        Me.protocolServiceAdmin.Location = New System.Drawing.Point(92, 25)
        Me.protocolServiceAdmin.Name = "protocolServiceAdmin"
        Me.protocolServiceAdmin.Size = New System.Drawing.Size(81, 21)
        Me.protocolServiceAdmin.TabIndex = 0
        '
        'urlServiceAdministrationLabel
        '
        Me.urlServiceAdministrationLabel.AutoSize = True
        Me.urlServiceAdministrationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlServiceAdministrationLabel.Location = New System.Drawing.Point(50, 29)
        Me.urlServiceAdministrationLabel.Name = "urlServiceAdministrationLabel"
        Me.urlServiceAdministrationLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlServiceAdministrationLabel.TabIndex = 0
        Me.urlServiceAdministrationLabel.Text = "URL"
        '
        'rememberThis
        '
        Me.rememberThis.AutoSize = True
        Me.rememberThis.Checked = True
        Me.rememberThis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rememberThis.Location = New System.Drawing.Point(495, 367)
        Me.rememberThis.Name = "rememberThis"
        Me.rememberThis.Size = New System.Drawing.Size(161, 17)
        Me.rememberThis.TabIndex = 6
        Me.rememberThis.Text = "Remember this settings"
        Me.rememberThis.UseVisualStyleBackColor = True
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(71, 367)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(134, 17)
        Me.useEventRegistry.TabIndex = 3
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'generalTabPage
        '
        Me.generalTabPage.Controls.Add(Me.GroupBox1)
        Me.generalTabPage.Controls.Add(Me.debugModeCheck)
        Me.generalTabPage.Controls.Add(Me.autoStart)
        Me.generalTabPage.Controls.Add(Me.rememberThis)
        Me.generalTabPage.Controls.Add(Me.useEventRegistry)
        Me.generalTabPage.Controls.Add(Me.serviceAdministrationGroup)
        Me.generalTabPage.Controls.Add(Me.localPathAndDataPortNumber)
        Me.generalTabPage.Location = New System.Drawing.Point(4, 22)
        Me.generalTabPage.Name = "generalTabPage"
        Me.generalTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.generalTabPage.Size = New System.Drawing.Size(701, 399)
        Me.generalTabPage.TabIndex = 0
        Me.generalTabPage.Text = "General"
        Me.generalTabPage.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.keepFileType)
        Me.GroupBox1.Controls.Add(Me.keepFileTypeValue)
        Me.GroupBox1.Controls.Add(Me.keepOnlyRecentFile)
        Me.GroupBox1.Controls.Add(Me.keepOnlyRecentFileValue)
        Me.GroupBox1.Controls.Add(Me.startCleanEvery)
        Me.GroupBox1.Controls.Add(Me.startCleanEveryValue)
        Me.GroupBox1.Controls.Add(Me.autoCleanOption)
        Me.GroupBox1.Controls.Add(Me.trackConfiguration)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(685, 123)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Log"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(59, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Track configuration"
        '
        'debugModeCheck
        '
        Me.debugModeCheck.AutoSize = True
        Me.debugModeCheck.Location = New System.Drawing.Point(369, 367)
        Me.debugModeCheck.Name = "debugModeCheck"
        Me.debugModeCheck.Size = New System.Drawing.Size(97, 17)
        Me.debugModeCheck.TabIndex = 5
        Me.debugModeCheck.Text = "Debug Mode"
        Me.debugModeCheck.UseVisualStyleBackColor = True
        '
        'autoStart
        '
        Me.autoStart.AutoSize = True
        Me.autoStart.Checked = True
        Me.autoStart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoStart.Location = New System.Drawing.Point(251, 367)
        Me.autoStart.Name = "autoStart"
        Me.autoStart.Size = New System.Drawing.Size(78, 17)
        Me.autoStart.TabIndex = 4
        Me.autoStart.Text = "Autostart"
        Me.autoStart.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.generalTabPage)
        Me.tabControl.Controls.Add(Me.upgradeTabPage)
        Me.tabControl.Controls.Add(Me.servicesTabPage)
        Me.tabControl.Controls.Add(Me.logTabPage)
        Me.tabControl.Location = New System.Drawing.Point(14, 14)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(709, 425)
        Me.tabControl.TabIndex = 0
        '
        'upgradeTabPage
        '
        Me.upgradeTabPage.Controls.Add(Me.createNewCertificateUpgrade)
        Me.upgradeTabPage.Controls.Add(Me.frequencyUpgradeValue)
        Me.upgradeTabPage.Controls.Add(Me.frequencyUpgradeLabel)
        Me.upgradeTabPage.Controls.Add(Me.certificateUpgradeBrowserButton)
        Me.upgradeTabPage.Controls.Add(Me.certificateUpgradeValue)
        Me.upgradeTabPage.Controls.Add(Me.certificateUpgradeLabel)
        Me.upgradeTabPage.Controls.Add(Me.checkUpgrade)
        Me.upgradeTabPage.Controls.Add(Me.sourceUpgrade)
        Me.upgradeTabPage.Location = New System.Drawing.Point(4, 22)
        Me.upgradeTabPage.Name = "upgradeTabPage"
        Me.upgradeTabPage.Size = New System.Drawing.Size(701, 399)
        Me.upgradeTabPage.TabIndex = 2
        Me.upgradeTabPage.Text = "Upgrade"
        Me.upgradeTabPage.UseVisualStyleBackColor = True
        '
        'createNewCertificateUpgrade
        '
        Me.createNewCertificateUpgrade.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewCertificateUpgrade.Enabled = False
        Me.createNewCertificateUpgrade.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createNewCertificateUpgrade.Location = New System.Drawing.Point(548, 188)
        Me.createNewCertificateUpgrade.Name = "createNewCertificateUpgrade"
        Me.createNewCertificateUpgrade.Size = New System.Drawing.Size(57, 22)
        Me.createNewCertificateUpgrade.TabIndex = 3
        Me.createNewCertificateUpgrade.Text = "New"
        Me.createNewCertificateUpgrade.UseVisualStyleBackColor = True
        '
        'frequencyUpgradeValue
        '
        Me.frequencyUpgradeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.frequencyUpgradeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.frequencyUpgradeValue.Enabled = False
        Me.frequencyUpgradeValue.FormattingEnabled = True
        Me.frequencyUpgradeValue.Items.AddRange(New Object() {"Every 12 hours", "Every 24 hours"})
        Me.frequencyUpgradeValue.Location = New System.Drawing.Point(104, 215)
        Me.frequencyUpgradeValue.Name = "frequencyUpgradeValue"
        Me.frequencyUpgradeValue.Size = New System.Drawing.Size(539, 21)
        Me.frequencyUpgradeValue.TabIndex = 5
        '
        'frequencyUpgradeLabel
        '
        Me.frequencyUpgradeLabel.AutoSize = True
        Me.frequencyUpgradeLabel.Enabled = False
        Me.frequencyUpgradeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frequencyUpgradeLabel.Location = New System.Drawing.Point(22, 218)
        Me.frequencyUpgradeLabel.Name = "frequencyUpgradeLabel"
        Me.frequencyUpgradeLabel.Size = New System.Drawing.Size(66, 13)
        Me.frequencyUpgradeLabel.TabIndex = 16
        Me.frequencyUpgradeLabel.Text = "Frequency"
        '
        'certificateUpgradeBrowserButton
        '
        Me.certificateUpgradeBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateUpgradeBrowserButton.Enabled = False
        Me.certificateUpgradeBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateUpgradeBrowserButton.Location = New System.Drawing.Point(612, 187)
        Me.certificateUpgradeBrowserButton.Name = "certificateUpgradeBrowserButton"
        Me.certificateUpgradeBrowserButton.Size = New System.Drawing.Size(31, 22)
        Me.certificateUpgradeBrowserButton.TabIndex = 4
        Me.certificateUpgradeBrowserButton.Text = "..."
        Me.certificateUpgradeBrowserButton.UseVisualStyleBackColor = True
        '
        'certificateUpgradeValue
        '
        Me.certificateUpgradeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateUpgradeValue.Enabled = False
        Me.certificateUpgradeValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateUpgradeValue.Location = New System.Drawing.Point(104, 188)
        Me.certificateUpgradeValue.Name = "certificateUpgradeValue"
        Me.certificateUpgradeValue.Size = New System.Drawing.Size(437, 21)
        Me.certificateUpgradeValue.TabIndex = 2
        '
        'certificateUpgradeLabel
        '
        Me.certificateUpgradeLabel.AutoSize = True
        Me.certificateUpgradeLabel.Enabled = False
        Me.certificateUpgradeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateUpgradeLabel.Location = New System.Drawing.Point(20, 191)
        Me.certificateUpgradeLabel.Name = "certificateUpgradeLabel"
        Me.certificateUpgradeLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateUpgradeLabel.TabIndex = 5
        Me.certificateUpgradeLabel.Text = "Certificate"
        '
        'checkUpgrade
        '
        Me.checkUpgrade.AutoSize = True
        Me.checkUpgrade.BackColor = System.Drawing.Color.White
        Me.checkUpgrade.Location = New System.Drawing.Point(21, 14)
        Me.checkUpgrade.Name = "checkUpgrade"
        Me.checkUpgrade.Size = New System.Drawing.Size(171, 17)
        Me.checkUpgrade.TabIndex = 0
        Me.checkUpgrade.Text = "Automatic check upgrade"
        Me.checkUpgrade.UseVisualStyleBackColor = False
        '
        'sourceUpgrade
        '
        Me.sourceUpgrade.Controls.Add(Me.addressSourceUpgradeValue)
        Me.sourceUpgrade.Controls.Add(Me.addressLabel)
        Me.sourceUpgrade.Controls.Add(Me.sourceDynamicAddress)
        Me.sourceUpgrade.Controls.Add(Me.sourceUpgradeStaticAddress)
        Me.sourceUpgrade.Enabled = False
        Me.sourceUpgrade.Location = New System.Drawing.Point(21, 37)
        Me.sourceUpgrade.Name = "sourceUpgrade"
        Me.sourceUpgrade.Size = New System.Drawing.Size(658, 129)
        Me.sourceUpgrade.TabIndex = 1
        Me.sourceUpgrade.TabStop = False
        Me.sourceUpgrade.Text = "Storage source of upgrade"
        '
        'addressSourceUpgradeValue
        '
        Me.addressSourceUpgradeValue.Enabled = False
        Me.addressSourceUpgradeValue.Location = New System.Drawing.Point(28, 89)
        Me.addressSourceUpgradeValue.Name = "addressSourceUpgradeValue"
        Me.addressSourceUpgradeValue.Size = New System.Drawing.Size(594, 21)
        Me.addressSourceUpgradeValue.TabIndex = 2
        '
        'addressLabel
        '
        Me.addressLabel.AutoSize = True
        Me.addressLabel.Enabled = False
        Me.addressLabel.Location = New System.Drawing.Point(24, 73)
        Me.addressLabel.Name = "addressLabel"
        Me.addressLabel.Size = New System.Drawing.Size(53, 13)
        Me.addressLabel.TabIndex = 2
        Me.addressLabel.Text = "Address"
        '
        'sourceDynamicAddress
        '
        Me.sourceDynamicAddress.AutoSize = True
        Me.sourceDynamicAddress.Enabled = False
        Me.sourceDynamicAddress.Location = New System.Drawing.Point(423, 36)
        Me.sourceDynamicAddress.Name = "sourceDynamicAddress"
        Me.sourceDynamicAddress.Size = New System.Drawing.Size(197, 17)
        Me.sourceDynamicAddress.TabIndex = 1
        Me.sourceDynamicAddress.TabStop = True
        Me.sourceDynamicAddress.Text = "Blockchain address (dynamic)"
        Me.sourceDynamicAddress.UseVisualStyleBackColor = True
        '
        'sourceUpgradeStaticAddress
        '
        Me.sourceUpgradeStaticAddress.AutoSize = True
        Me.sourceUpgradeStaticAddress.Enabled = False
        Me.sourceUpgradeStaticAddress.Location = New System.Drawing.Point(28, 36)
        Me.sourceUpgradeStaticAddress.Name = "sourceUpgradeStaticAddress"
        Me.sourceUpgradeStaticAddress.Size = New System.Drawing.Size(135, 17)
        Me.sourceUpgradeStaticAddress.TabIndex = 0
        Me.sourceUpgradeStaticAddress.TabStop = True
        Me.sourceUpgradeStaticAddress.Text = "Static address (url)"
        Me.sourceUpgradeStaticAddress.UseVisualStyleBackColor = True
        '
        'servicesTabPage
        '
        Me.servicesTabPage.Controls.Add(Me.newCertificateDetailButton)
        Me.servicesTabPage.Controls.Add(Me.protocolURLDetailCombo)
        Me.servicesTabPage.Controls.Add(Me.certificateDetailButton)
        Me.servicesTabPage.Controls.Add(Me.certificateDetailValue)
        Me.servicesTabPage.Controls.Add(Me.certificateDetailLabel)
        Me.servicesTabPage.Controls.Add(Me.urlDetailValue)
        Me.servicesTabPage.Controls.Add(Me.urlDetailLabel)
        Me.servicesTabPage.Controls.Add(Me.completeApplicationDetailButton)
        Me.servicesTabPage.Controls.Add(Me.cancelDetailButton)
        Me.servicesTabPage.Controls.Add(Me.confirmDetailButton)
        Me.servicesTabPage.Controls.Add(Me.completeApplicationPathValue)
        Me.servicesTabPage.Controls.Add(Me.completeApplicationPathLabel)
        Me.servicesTabPage.Controls.Add(Me.addNewService)
        Me.servicesTabPage.Controls.Add(Me.applicationDataGrid)
        Me.servicesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.servicesTabPage.Name = "servicesTabPage"
        Me.servicesTabPage.Size = New System.Drawing.Size(701, 399)
        Me.servicesTabPage.TabIndex = 4
        Me.servicesTabPage.Text = "Services"
        Me.servicesTabPage.UseVisualStyleBackColor = True
        '
        'newCertificateDetailButton
        '
        Me.newCertificateDetailButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.newCertificateDetailButton.Enabled = False
        Me.newCertificateDetailButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newCertificateDetailButton.Location = New System.Drawing.Point(501, 322)
        Me.newCertificateDetailButton.Name = "newCertificateDetailButton"
        Me.newCertificateDetailButton.Size = New System.Drawing.Size(57, 22)
        Me.newCertificateDetailButton.TabIndex = 5
        Me.newCertificateDetailButton.Text = "New"
        Me.newCertificateDetailButton.UseVisualStyleBackColor = True
        '
        'protocolURLDetailCombo
        '
        Me.protocolURLDetailCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.protocolURLDetailCombo.Enabled = False
        Me.protocolURLDetailCombo.FormattingEnabled = True
        Me.protocolURLDetailCombo.Items.AddRange(New Object() {"http://", "https://"})
        Me.protocolURLDetailCombo.Location = New System.Drawing.Point(16, 277)
        Me.protocolURLDetailCombo.Name = "protocolURLDetailCombo"
        Me.protocolURLDetailCombo.Size = New System.Drawing.Size(81, 21)
        Me.protocolURLDetailCombo.TabIndex = 2
        '
        'certificateDetailButton
        '
        Me.certificateDetailButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateDetailButton.Enabled = False
        Me.certificateDetailButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateDetailButton.Location = New System.Drawing.Point(564, 322)
        Me.certificateDetailButton.Name = "certificateDetailButton"
        Me.certificateDetailButton.Size = New System.Drawing.Size(31, 23)
        Me.certificateDetailButton.TabIndex = 6
        Me.certificateDetailButton.Text = "..."
        Me.certificateDetailButton.UseVisualStyleBackColor = True
        '
        'certificateDetailValue
        '
        Me.certificateDetailValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateDetailValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateDetailValue.Location = New System.Drawing.Point(16, 323)
        Me.certificateDetailValue.Name = "certificateDetailValue"
        Me.certificateDetailValue.ReadOnly = True
        Me.certificateDetailValue.Size = New System.Drawing.Size(479, 21)
        Me.certificateDetailValue.TabIndex = 4
        '
        'certificateDetailLabel
        '
        Me.certificateDetailLabel.AutoSize = True
        Me.certificateDetailLabel.Enabled = False
        Me.certificateDetailLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateDetailLabel.Location = New System.Drawing.Point(12, 307)
        Me.certificateDetailLabel.Name = "certificateDetailLabel"
        Me.certificateDetailLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateDetailLabel.TabIndex = 93
        Me.certificateDetailLabel.Text = "Certificate"
        '
        'urlDetailValue
        '
        Me.urlDetailValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.urlDetailValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlDetailValue.Location = New System.Drawing.Point(104, 278)
        Me.urlDetailValue.Name = "urlDetailValue"
        Me.urlDetailValue.ReadOnly = True
        Me.urlDetailValue.Size = New System.Drawing.Size(491, 21)
        Me.urlDetailValue.TabIndex = 3
        '
        'urlDetailLabel
        '
        Me.urlDetailLabel.AutoSize = True
        Me.urlDetailLabel.Enabled = False
        Me.urlDetailLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlDetailLabel.Location = New System.Drawing.Point(12, 259)
        Me.urlDetailLabel.Name = "urlDetailLabel"
        Me.urlDetailLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlDetailLabel.TabIndex = 91
        Me.urlDetailLabel.Text = "URL"
        '
        'completeApplicationDetailButton
        '
        Me.completeApplicationDetailButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.completeApplicationDetailButton.Enabled = False
        Me.completeApplicationDetailButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.completeApplicationDetailButton.Location = New System.Drawing.Point(564, 364)
        Me.completeApplicationDetailButton.Name = "completeApplicationDetailButton"
        Me.completeApplicationDetailButton.Size = New System.Drawing.Size(31, 23)
        Me.completeApplicationDetailButton.TabIndex = 8
        Me.completeApplicationDetailButton.Text = "..."
        Me.completeApplicationDetailButton.UseVisualStyleBackColor = True
        '
        'cancelDetailButton
        '
        Me.cancelDetailButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelDetailButton.Enabled = False
        Me.cancelDetailButton.Location = New System.Drawing.Point(602, 364)
        Me.cancelDetailButton.Name = "cancelDetailButton"
        Me.cancelDetailButton.Size = New System.Drawing.Size(84, 23)
        Me.cancelDetailButton.TabIndex = 10
        Me.cancelDetailButton.Text = "Cancel"
        Me.cancelDetailButton.UseVisualStyleBackColor = True
        '
        'confirmDetailButton
        '
        Me.confirmDetailButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmDetailButton.Enabled = False
        Me.confirmDetailButton.Location = New System.Drawing.Point(602, 335)
        Me.confirmDetailButton.Name = "confirmDetailButton"
        Me.confirmDetailButton.Size = New System.Drawing.Size(84, 23)
        Me.confirmDetailButton.TabIndex = 9
        Me.confirmDetailButton.Text = "Confirm"
        Me.confirmDetailButton.UseVisualStyleBackColor = True
        '
        'completeApplicationPathValue
        '
        Me.completeApplicationPathValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.completeApplicationPathValue.Location = New System.Drawing.Point(16, 364)
        Me.completeApplicationPathValue.MaxLength = 1000
        Me.completeApplicationPathValue.Name = "completeApplicationPathValue"
        Me.completeApplicationPathValue.ReadOnly = True
        Me.completeApplicationPathValue.Size = New System.Drawing.Size(542, 21)
        Me.completeApplicationPathValue.TabIndex = 7
        '
        'completeApplicationPathLabel
        '
        Me.completeApplicationPathLabel.AutoSize = True
        Me.completeApplicationPathLabel.Enabled = False
        Me.completeApplicationPathLabel.Location = New System.Drawing.Point(12, 349)
        Me.completeApplicationPathLabel.Name = "completeApplicationPathLabel"
        Me.completeApplicationPathLabel.Size = New System.Drawing.Size(157, 13)
        Me.completeApplicationPathLabel.TabIndex = 86
        Me.completeApplicationPathLabel.Text = "Complete Application Path"
        '
        'addNewService
        '
        Me.addNewService.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addNewService.Location = New System.Drawing.Point(602, 14)
        Me.addNewService.Name = "addNewService"
        Me.addNewService.Size = New System.Drawing.Size(84, 23)
        Me.addNewService.TabIndex = 1
        Me.addNewService.Text = "Add new"
        Me.addNewService.UseVisualStyleBackColor = True
        '
        'applicationDataGrid
        '
        Me.applicationDataGrid.AllowUserToAddRows = False
        Me.applicationDataGrid.AllowUserToDeleteRows = False
        Me.applicationDataGrid.AllowUserToResizeColumns = False
        Me.applicationDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.applicationDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.applicationDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowIndexPrice, Me.applicationColumn})
        Me.applicationDataGrid.Location = New System.Drawing.Point(15, 14)
        Me.applicationDataGrid.MultiSelect = False
        Me.applicationDataGrid.Name = "applicationDataGrid"
        Me.applicationDataGrid.ReadOnly = True
        Me.applicationDataGrid.RowHeadersVisible = False
        Me.applicationDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.applicationDataGrid.Size = New System.Drawing.Size(580, 228)
        Me.applicationDataGrid.TabIndex = 0
        '
        'rowIndexPrice
        '
        Me.rowIndexPrice.HeaderText = "Row Index"
        Me.rowIndexPrice.Name = "rowIndexPrice"
        Me.rowIndexPrice.ReadOnly = True
        Me.rowIndexPrice.Visible = False
        '
        'applicationColumn
        '
        Me.applicationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.applicationColumn.HeaderText = "Application"
        Me.applicationColumn.Name = "applicationColumn"
        Me.applicationColumn.ReadOnly = True
        '
        'stopButton
        '
        Me.stopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stopButton.Enabled = False
        Me.stopButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stopButton.Location = New System.Drawing.Point(730, 109)
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
        Me.startButton.Location = New System.Drawing.Point(730, 50)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(106, 49)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "RUN >>"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'refreshButton
        '
        Me.refreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshButton.Enabled = False
        Me.refreshButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refreshButton.Location = New System.Drawing.Point(730, 359)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(106, 49)
        Me.refreshButton.TabIndex = 5
        Me.refreshButton.Text = "Refresh"
        Me.refreshButton.UseVisualStyleBackColor = True
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
        Me.ClientSize = New System.Drawing.Size(847, 451)
        Me.Controls.Add(Me.registryEventButton)
        Me.Controls.Add(Me.logFileButton)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.refreshButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(2331, 522)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(814, 490)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Masternode Loader Service GUI"
        Me.localPathAndDataPortNumber.ResumeLayout(False)
        Me.localPathAndDataPortNumber.PerformLayout()
        Me.logTabPage.ResumeLayout(False)
        Me.logTabPage.PerformLayout()
        Me.serviceAdministrationGroup.ResumeLayout(False)
        Me.serviceAdministrationGroup.PerformLayout()
        Me.generalTabPage.ResumeLayout(False)
        Me.generalTabPage.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.upgradeTabPage.ResumeLayout(False)
        Me.upgradeTabPage.PerformLayout()
        Me.sourceUpgrade.ResumeLayout(False)
        Me.sourceUpgrade.PerformLayout()
        Me.servicesTabPage.ResumeLayout(False)
        Me.servicesTabPage.PerformLayout()
        CType(Me.applicationDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents certificateBrowserButton As Button
    Friend WithEvents testServiceAdministration As Button
    Friend WithEvents certificateServiceAdmin As TextBox
    Friend WithEvents certificateServiceAdministrationLabel As Label
    Friend WithEvents localPathAndDataPortNumber As GroupBox
    Friend WithEvents localPortNumber As TextBox
    Friend WithEvents portNumberLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents localPathData As TextBox
    Friend WithEvents logTabPage As TabPage
    Friend WithEvents logConsoleText As TextBox
    Friend WithEvents registryEventButton As Button
    Friend WithEvents serviceAdminUrl As TextBox
    Friend WithEvents logFileButton As Button
    Friend WithEvents serviceAdministrationGroup As GroupBox
    Friend WithEvents urlServiceAdministrationLabel As Label
    Friend WithEvents rememberThis As CheckBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents generalTabPage As TabPage
    Friend WithEvents tabControl As TabControl
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents stopButton As Button
    Friend WithEvents startButton As Button
    Friend WithEvents refreshButton As Button
    Friend WithEvents autoStart As CheckBox
    Friend WithEvents publicWalletAddress As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents debugModeCheck As CheckBox
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents upgradeTabPage As TabPage
    Friend WithEvents protocolServiceAdmin As ComboBox
    Friend WithEvents servicesTabPage As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents keepFileType As Label
    Friend WithEvents keepFileTypeValue As ComboBox
    Friend WithEvents keepOnlyRecentFile As Label
    Friend WithEvents keepOnlyRecentFileValue As ComboBox
    Friend WithEvents startCleanEvery As Label
    Friend WithEvents startCleanEveryValue As ComboBox
    Friend WithEvents autoCleanOption As CheckBox
    Friend WithEvents trackConfiguration As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents checkUpgrade As CheckBox
    Friend WithEvents sourceUpgrade As GroupBox
    Friend WithEvents addressSourceUpgradeValue As TextBox
    Friend WithEvents addressLabel As Label
    Friend WithEvents sourceDynamicAddress As RadioButton
    Friend WithEvents sourceUpgradeStaticAddress As RadioButton
    Friend WithEvents frequencyUpgradeValue As ComboBox
    Friend WithEvents frequencyUpgradeLabel As Label
    Friend WithEvents certificateUpgradeBrowserButton As Button
    Friend WithEvents certificateUpgradeValue As TextBox
    Friend WithEvents certificateUpgradeLabel As Label
    Friend WithEvents createNewCertificateUpgrade As Button
    Friend WithEvents addNewService As Button
    Friend WithEvents applicationDataGrid As DataGridView
    Friend WithEvents completeApplicationDetailButton As Button
    Friend WithEvents cancelDetailButton As Button
    Friend WithEvents confirmDetailButton As Button
    Friend WithEvents completeApplicationPathValue As TextBox
    Friend WithEvents completeApplicationPathLabel As Label
    Friend WithEvents protocolURLDetailCombo As ComboBox
    Friend WithEvents certificateDetailButton As Button
    Friend WithEvents certificateDetailValue As TextBox
    Friend WithEvents certificateDetailLabel As Label
    Friend WithEvents urlDetailValue As TextBox
    Friend WithEvents urlDetailLabel As Label
    Friend WithEvents rowIndexPrice As DataGridViewTextBoxColumn
    Friend WithEvents applicationColumn As DataGridViewTextBoxColumn
    Friend WithEvents newCertificateDetailButton As Button
End Class
