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
        Me.masternodeRuntimeGroup = New System.Windows.Forms.GroupBox()
        Me.certificateMasternodeRuntimeBrowserButton = New System.Windows.Forms.Button()
        Me.testMasternodeRuntimeButton = New System.Windows.Forms.Button()
        Me.certificateMasternodeRuntime = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeRuntimeLabel = New System.Windows.Forms.Label()
        Me.masternodeRuntimeURL = New System.Windows.Forms.TextBox()
        Me.urlMasternodeRuntimeLabel = New System.Windows.Forms.Label()
        Me.certificateBrowserButton = New System.Windows.Forms.Button()
        Me.testMasternodeAdministration = New System.Windows.Forms.Button()
        Me.certificateMasternodeAdmin = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeAdministrationLabel = New System.Windows.Forms.Label()
        Me.localPathAndDataPortNumber = New System.Windows.Forms.GroupBox()
        Me.publicWalletAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.localPortNumber = New System.Windows.Forms.TextBox()
        Me.portNumberLabel = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.localPathData = New System.Windows.Forms.TextBox()
        Me.LogTab = New System.Windows.Forms.TabPage()
        Me.logConsoleText = New System.Windows.Forms.TextBox()
        Me.registryEventButton = New System.Windows.Forms.Button()
        Me.masternodeAdminUrl = New System.Windows.Forms.TextBox()
        Me.logFileButton = New System.Windows.Forms.Button()
        Me.masternodeAdministrationGroup = New System.Windows.Forms.GroupBox()
        Me.urlMasternodeAdministrationLabel = New System.Windows.Forms.Label()
        Me.rememberThis = New System.Windows.Forms.CheckBox()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.writeLogFile = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.debugModeCheck = New System.Windows.Forms.CheckBox()
        Me.autoStart = New System.Windows.Forms.CheckBox()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.stopButton = New System.Windows.Forms.Button()
        Me.startButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.masternodeRuntimeGroup.SuspendLayout()
        Me.localPathAndDataPortNumber.SuspendLayout()
        Me.LogTab.SuspendLayout()
        Me.masternodeAdministrationGroup.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'masternodeRuntimeGroup
        '
        Me.masternodeRuntimeGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeRuntimeGroup.Controls.Add(Me.certificateMasternodeRuntimeBrowserButton)
        Me.masternodeRuntimeGroup.Controls.Add(Me.testMasternodeRuntimeButton)
        Me.masternodeRuntimeGroup.Controls.Add(Me.certificateMasternodeRuntime)
        Me.masternodeRuntimeGroup.Controls.Add(Me.certificateMasternodeRuntimeLabel)
        Me.masternodeRuntimeGroup.Controls.Add(Me.masternodeRuntimeURL)
        Me.masternodeRuntimeGroup.Controls.Add(Me.urlMasternodeRuntimeLabel)
        Me.masternodeRuntimeGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeRuntimeGroup.Location = New System.Drawing.Point(5, 225)
        Me.masternodeRuntimeGroup.Name = "masternodeRuntimeGroup"
        Me.masternodeRuntimeGroup.Size = New System.Drawing.Size(589, 91)
        Me.masternodeRuntimeGroup.TabIndex = 2
        Me.masternodeRuntimeGroup.TabStop = False
        Me.masternodeRuntimeGroup.Text = "Masternode Runtime"
        '
        'certificateMasternodeRuntimeBrowserButton
        '
        Me.certificateMasternodeRuntimeBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeRuntimeBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeRuntimeBrowserButton.Location = New System.Drawing.Point(507, 51)
        Me.certificateMasternodeRuntimeBrowserButton.Name = "certificateMasternodeRuntimeBrowserButton"
        Me.certificateMasternodeRuntimeBrowserButton.Size = New System.Drawing.Size(27, 22)
        Me.certificateMasternodeRuntimeBrowserButton.TabIndex = 3
        Me.certificateMasternodeRuntimeBrowserButton.Text = "..."
        Me.certificateMasternodeRuntimeBrowserButton.UseVisualStyleBackColor = True
        '
        'testMasternodeRuntimeButton
        '
        Me.testMasternodeRuntimeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testMasternodeRuntimeButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testMasternodeRuntimeButton.Location = New System.Drawing.Point(540, 25)
        Me.testMasternodeRuntimeButton.Name = "testMasternodeRuntimeButton"
        Me.testMasternodeRuntimeButton.Size = New System.Drawing.Size(43, 48)
        Me.testMasternodeRuntimeButton.TabIndex = 1
        Me.testMasternodeRuntimeButton.Text = "Test"
        Me.testMasternodeRuntimeButton.UseVisualStyleBackColor = True
        '
        'certificateMasternodeRuntime
        '
        Me.certificateMasternodeRuntime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeRuntime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeRuntime.Location = New System.Drawing.Point(80, 52)
        Me.certificateMasternodeRuntime.Name = "certificateMasternodeRuntime"
        Me.certificateMasternodeRuntime.Size = New System.Drawing.Size(423, 21)
        Me.certificateMasternodeRuntime.TabIndex = 2
        '
        'certificateMasternodeRuntimeLabel
        '
        Me.certificateMasternodeRuntimeLabel.AutoSize = True
        Me.certificateMasternodeRuntimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeRuntimeLabel.Location = New System.Drawing.Point(7, 55)
        Me.certificateMasternodeRuntimeLabel.Name = "certificateMasternodeRuntimeLabel"
        Me.certificateMasternodeRuntimeLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeRuntimeLabel.TabIndex = 2
        Me.certificateMasternodeRuntimeLabel.Text = "Certificate"
        '
        'masternodeRuntimeURL
        '
        Me.masternodeRuntimeURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeRuntimeURL.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeRuntimeURL.Location = New System.Drawing.Point(80, 26)
        Me.masternodeRuntimeURL.Name = "masternodeRuntimeURL"
        Me.masternodeRuntimeURL.Size = New System.Drawing.Size(454, 21)
        Me.masternodeRuntimeURL.TabIndex = 0
        '
        'urlMasternodeRuntimeLabel
        '
        Me.urlMasternodeRuntimeLabel.AutoSize = True
        Me.urlMasternodeRuntimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlMasternodeRuntimeLabel.Location = New System.Drawing.Point(44, 29)
        Me.urlMasternodeRuntimeLabel.Name = "urlMasternodeRuntimeLabel"
        Me.urlMasternodeRuntimeLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlMasternodeRuntimeLabel.TabIndex = 0
        Me.urlMasternodeRuntimeLabel.Text = "URL"
        '
        'certificateBrowserButton
        '
        Me.certificateBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateBrowserButton.Location = New System.Drawing.Point(506, 51)
        Me.certificateBrowserButton.Name = "certificateBrowserButton"
        Me.certificateBrowserButton.Size = New System.Drawing.Size(27, 22)
        Me.certificateBrowserButton.TabIndex = 3
        Me.certificateBrowserButton.Text = "..."
        Me.certificateBrowserButton.UseVisualStyleBackColor = True
        '
        'testMasternodeAdministration
        '
        Me.testMasternodeAdministration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testMasternodeAdministration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testMasternodeAdministration.Location = New System.Drawing.Point(539, 25)
        Me.testMasternodeAdministration.Name = "testMasternodeAdministration"
        Me.testMasternodeAdministration.Size = New System.Drawing.Size(43, 48)
        Me.testMasternodeAdministration.TabIndex = 1
        Me.testMasternodeAdministration.Text = "Test"
        Me.testMasternodeAdministration.UseVisualStyleBackColor = True
        '
        'certificateMasternodeAdmin
        '
        Me.certificateMasternodeAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeAdmin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeAdmin.Location = New System.Drawing.Point(79, 52)
        Me.certificateMasternodeAdmin.Name = "certificateMasternodeAdmin"
        Me.certificateMasternodeAdmin.Size = New System.Drawing.Size(423, 21)
        Me.certificateMasternodeAdmin.TabIndex = 2
        '
        'certificateMasternodeAdministrationLabel
        '
        Me.certificateMasternodeAdministrationLabel.AutoSize = True
        Me.certificateMasternodeAdministrationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeAdministrationLabel.Location = New System.Drawing.Point(7, 55)
        Me.certificateMasternodeAdministrationLabel.Name = "certificateMasternodeAdministrationLabel"
        Me.certificateMasternodeAdministrationLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeAdministrationLabel.TabIndex = 2
        Me.certificateMasternodeAdministrationLabel.Text = "Certificate"
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
        Me.localPathAndDataPortNumber.Location = New System.Drawing.Point(6, 6)
        Me.localPathAndDataPortNumber.Name = "localPathAndDataPortNumber"
        Me.localPathAndDataPortNumber.Size = New System.Drawing.Size(588, 116)
        Me.localPathAndDataPortNumber.TabIndex = 0
        Me.localPathAndDataPortNumber.TabStop = False
        Me.localPathAndDataPortNumber.Text = "Local path data and port number"
        '
        'publicWalletAddress
        '
        Me.publicWalletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicWalletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicWalletAddress.Location = New System.Drawing.Point(136, 57)
        Me.publicWalletAddress.Name = "publicWalletAddress"
        Me.publicWalletAddress.Size = New System.Drawing.Size(410, 21)
        Me.publicWalletAddress.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Public wallet address"
        '
        'localPortNumber
        '
        Me.localPortNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPortNumber.Location = New System.Drawing.Point(471, 84)
        Me.localPortNumber.Name = "localPortNumber"
        Me.localPortNumber.Size = New System.Drawing.Size(75, 21)
        Me.localPortNumber.TabIndex = 3
        Me.localPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'portNumberLabel
        '
        Me.portNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.portNumberLabel.AutoSize = True
        Me.portNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumberLabel.Location = New System.Drawing.Point(323, 87)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(142, 13)
        Me.portNumberLabel.TabIndex = 2
        Me.portNumberLabel.Text = "Port number (1..65535)"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(552, 28)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(30, 23)
        Me.browseLocalPath.TabIndex = 1
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'localPathData
        '
        Me.localPathData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathData.Location = New System.Drawing.Point(7, 30)
        Me.localPathData.Name = "localPathData"
        Me.localPathData.Size = New System.Drawing.Size(539, 21)
        Me.localPathData.TabIndex = 0
        '
        'LogTab
        '
        Me.LogTab.Controls.Add(Me.logConsoleText)
        Me.LogTab.Location = New System.Drawing.Point(4, 22)
        Me.LogTab.Name = "LogTab"
        Me.LogTab.Padding = New System.Windows.Forms.Padding(3)
        Me.LogTab.Size = New System.Drawing.Size(600, 429)
        Me.LogTab.TabIndex = 1
        Me.LogTab.Text = "Output"
        Me.LogTab.UseVisualStyleBackColor = True
        '
        'logConsoleText
        '
        Me.logConsoleText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logConsoleText.BackColor = System.Drawing.Color.Black
        Me.logConsoleText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logConsoleText.ForeColor = System.Drawing.SystemColors.Info
        Me.logConsoleText.Location = New System.Drawing.Point(6, 6)
        Me.logConsoleText.Multiline = True
        Me.logConsoleText.Name = "logConsoleText"
        Me.logConsoleText.ReadOnly = True
        Me.logConsoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logConsoleText.Size = New System.Drawing.Size(590, 417)
        Me.logConsoleText.TabIndex = 0
        Me.logConsoleText.Text = "01234567890123456789012345678901234567890123456789012345678901234567890123456789"
        '
        'registryEventButton
        '
        Me.registryEventButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.registryEventButton.Enabled = False
        Me.registryEventButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registryEventButton.Location = New System.Drawing.Point(626, 251)
        Me.registryEventButton.Name = "registryEventButton"
        Me.registryEventButton.Size = New System.Drawing.Size(91, 49)
        Me.registryEventButton.TabIndex = 4
        Me.registryEventButton.Text = "Registry Events"
        Me.registryEventButton.UseVisualStyleBackColor = True
        '
        'masternodeAdminUrl
        '
        Me.masternodeAdminUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeAdminUrl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeAdminUrl.Location = New System.Drawing.Point(79, 26)
        Me.masternodeAdminUrl.Name = "masternodeAdminUrl"
        Me.masternodeAdminUrl.Size = New System.Drawing.Size(454, 21)
        Me.masternodeAdminUrl.TabIndex = 0
        '
        'logFileButton
        '
        Me.logFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.logFileButton.Enabled = False
        Me.logFileButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logFileButton.Location = New System.Drawing.Point(626, 196)
        Me.logFileButton.Name = "logFileButton"
        Me.logFileButton.Size = New System.Drawing.Size(91, 49)
        Me.logFileButton.TabIndex = 3
        Me.logFileButton.Text = "Log file"
        Me.logFileButton.UseVisualStyleBackColor = True
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
        Me.masternodeAdministrationGroup.Location = New System.Drawing.Point(6, 128)
        Me.masternodeAdministrationGroup.Name = "masternodeAdministrationGroup"
        Me.masternodeAdministrationGroup.Size = New System.Drawing.Size(588, 91)
        Me.masternodeAdministrationGroup.TabIndex = 1
        Me.masternodeAdministrationGroup.TabStop = False
        Me.masternodeAdministrationGroup.Text = "Masternode Administration"
        '
        'urlMasternodeAdministrationLabel
        '
        Me.urlMasternodeAdministrationLabel.AutoSize = True
        Me.urlMasternodeAdministrationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlMasternodeAdministrationLabel.Location = New System.Drawing.Point(43, 29)
        Me.urlMasternodeAdministrationLabel.Name = "urlMasternodeAdministrationLabel"
        Me.urlMasternodeAdministrationLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlMasternodeAdministrationLabel.TabIndex = 0
        Me.urlMasternodeAdministrationLabel.Text = "URL"
        '
        'rememberThis
        '
        Me.rememberThis.AutoSize = True
        Me.rememberThis.Checked = True
        Me.rememberThis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rememberThis.Location = New System.Drawing.Point(85, 401)
        Me.rememberThis.Name = "rememberThis"
        Me.rememberThis.Size = New System.Drawing.Size(135, 17)
        Me.rememberThis.TabIndex = 6
        Me.rememberThis.Text = "Remember this settings"
        Me.rememberThis.UseVisualStyleBackColor = True
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(284, 378)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(117, 17)
        Me.useEventRegistry.TabIndex = 4
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'writeLogFile
        '
        Me.writeLogFile.AutoSize = True
        Me.writeLogFile.Checked = True
        Me.writeLogFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.writeLogFile.Location = New System.Drawing.Point(85, 378)
        Me.writeLogFile.Name = "writeLogFile"
        Me.writeLogFile.Size = New System.Drawing.Size(91, 17)
        Me.writeLogFile.TabIndex = 3
        Me.writeLogFile.Text = "Write Log File"
        Me.writeLogFile.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.debugModeCheck)
        Me.TabPage1.Controls.Add(Me.autoStart)
        Me.TabPage1.Controls.Add(Me.rememberThis)
        Me.TabPage1.Controls.Add(Me.useEventRegistry)
        Me.TabPage1.Controls.Add(Me.writeLogFile)
        Me.TabPage1.Controls.Add(Me.masternodeAdministrationGroup)
        Me.TabPage1.Controls.Add(Me.masternodeRuntimeGroup)
        Me.TabPage1.Controls.Add(Me.localPathAndDataPortNumber)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(600, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Console"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'debugModeCheck
        '
        Me.debugModeCheck.AutoSize = True
        Me.debugModeCheck.Location = New System.Drawing.Point(471, 401)
        Me.debugModeCheck.Name = "debugModeCheck"
        Me.debugModeCheck.Size = New System.Drawing.Size(88, 17)
        Me.debugModeCheck.TabIndex = 7
        Me.debugModeCheck.Text = "Debug Mode"
        Me.debugModeCheck.UseVisualStyleBackColor = True
        '
        'autoStart
        '
        Me.autoStart.AutoSize = True
        Me.autoStart.Checked = True
        Me.autoStart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoStart.Location = New System.Drawing.Point(471, 378)
        Me.autoStart.Name = "autoStart"
        Me.autoStart.Size = New System.Drawing.Size(68, 17)
        Me.autoStart.TabIndex = 5
        Me.autoStart.Text = "Autostart"
        Me.autoStart.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.TabPage1)
        Me.tabControl.Controls.Add(Me.LogTab)
        Me.tabControl.Location = New System.Drawing.Point(12, 14)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(608, 455)
        Me.tabControl.TabIndex = 0
        '
        'stopButton
        '
        Me.stopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stopButton.Enabled = False
        Me.stopButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stopButton.Location = New System.Drawing.Point(626, 109)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(91, 49)
        Me.stopButton.TabIndex = 2
        Me.stopButton.Text = "STOP []"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'startButton
        '
        Me.startButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(626, 50)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(91, 49)
        Me.startButton.TabIndex = 1
        Me.startButton.Text = "RUN >>"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'refreshButton
        '
        Me.refreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshButton.Enabled = False
        Me.refreshButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refreshButton.Location = New System.Drawing.Point(626, 359)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(91, 49)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(726, 483)
        Me.Controls.Add(Me.registryEventButton)
        Me.Controls.Add(Me.logFileButton)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.refreshButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(2000, 522)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 522)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Masternode Starter Service GUI"
        Me.masternodeRuntimeGroup.ResumeLayout(False)
        Me.masternodeRuntimeGroup.PerformLayout()
        Me.localPathAndDataPortNumber.ResumeLayout(False)
        Me.localPathAndDataPortNumber.PerformLayout()
        Me.LogTab.ResumeLayout(False)
        Me.LogTab.PerformLayout()
        Me.masternodeAdministrationGroup.ResumeLayout(False)
        Me.masternodeAdministrationGroup.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents masternodeRuntimeGroup As GroupBox
    Friend WithEvents certificateMasternodeRuntimeBrowserButton As Button
    Friend WithEvents testMasternodeRuntimeButton As Button
    Friend WithEvents certificateMasternodeRuntime As TextBox
    Friend WithEvents certificateMasternodeRuntimeLabel As Label
    Friend WithEvents masternodeRuntimeURL As TextBox
    Friend WithEvents urlMasternodeRuntimeLabel As Label
    Friend WithEvents certificateBrowserButton As Button
    Friend WithEvents testMasternodeAdministration As Button
    Friend WithEvents certificateMasternodeAdmin As TextBox
    Friend WithEvents certificateMasternodeAdministrationLabel As Label
    Friend WithEvents localPathAndDataPortNumber As GroupBox
    Friend WithEvents localPortNumber As TextBox
    Friend WithEvents portNumberLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents localPathData As TextBox
    Friend WithEvents LogTab As TabPage
    Friend WithEvents logConsoleText As TextBox
    Friend WithEvents registryEventButton As Button
    Friend WithEvents masternodeAdminUrl As TextBox
    Friend WithEvents logFileButton As Button
    Friend WithEvents masternodeAdministrationGroup As GroupBox
    Friend WithEvents urlMasternodeAdministrationLabel As Label
    Friend WithEvents rememberThis As CheckBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents writeLogFile As CheckBox
    Friend WithEvents TabPage1 As TabPage
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
End Class
