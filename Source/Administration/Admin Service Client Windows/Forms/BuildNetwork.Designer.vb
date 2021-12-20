<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuildNetwork
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuildNetwork))
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        Me.generalTab = New System.Windows.Forms.TabPage()
        Me.specialEnvironmentText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.adminWalletAddress = New CHCSupportUIControls.WalletAddress()
        Me.networkNameText = New System.Windows.Forms.TextBox()
        Me.networkNameLabel = New System.Windows.Forms.Label()
        Me.whitePaperTab = New System.Windows.Forms.TabPage()
        Me.whitePaperText = New System.Windows.Forms.TextBox()
        Me.yellowPaperTab = New System.Windows.Forms.TabPage()
        Me.yellowPaperText = New System.Windows.Forms.TextBox()
        Me.primaryAssetTab = New System.Windows.Forms.TabPage()
        Me.unLimitedCheck = New System.Windows.Forms.CheckBox()
        Me.policyAssetLabel = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.typeAssetLabel = New System.Windows.Forms.Label()
        Me.generalInformationAssetLabel = New System.Windows.Forms.Label()
        Me.initialStakeQuantityText = New CHCSupportUIControls.NumericText()
        Me.quantityTotalText = New CHCSupportUIControls.NumericText()
        Me.digitText = New CHCSupportUIControls.NumericText()
        Me.initialStakeQuantityLabel = New System.Windows.Forms.Label()
        Me.nameUnitText = New System.Windows.Forms.TextBox()
        Me.nameUnitLabel = New System.Windows.Forms.Label()
        Me.burnableCheck = New System.Windows.Forms.CheckBox()
        Me.prestakeCheck = New System.Windows.Forms.CheckBox()
        Me.stakableCheck = New System.Windows.Forms.CheckBox()
        Me.digitLabel = New System.Windows.Forms.Label()
        Me.quantityTotalLabel = New System.Windows.Forms.Label()
        Me.symbolText = New System.Windows.Forms.TextBox()
        Me.symbolLabel = New System.Windows.Forms.Label()
        Me.shortNameText = New System.Windows.Forms.TextBox()
        Me.shortNameLabel = New System.Windows.Forms.Label()
        Me.assetNameText = New System.Windows.Forms.TextBox()
        Me.assetNameLabel = New System.Windows.Forms.Label()
        Me.transactionChainParameterTab = New System.Windows.Forms.TabPage()
        Me.maxTimeOutNotEvaluateNodeText = New System.Windows.Forms.TextBox()
        Me.maxTimeOutNotEvaluateNodeLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainInternalText = New System.Windows.Forms.TextBox()
        Me.minimalMaintainInternalRegistryLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainTrashedText = New System.Windows.Forms.TextBox()
        Me.minimalMaintainTrashedLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainRejectedText = New System.Windows.Forms.TextBox()
        Me.minimalMaintainRejectedLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainBulletinesText = New System.Windows.Forms.TextBox()
        Me.minimalMaintainBulletinesLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainConsensusText = New System.Windows.Forms.TextBox()
        Me.minimalMaintainConsensusLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainRequestText = New System.Windows.Forms.TextBox()
        Me.minimalMaintainRequestLabel = New System.Windows.Forms.Label()
        Me.initialCoinReleaseBlockText = New CHCSupportUIControls.NumericText()
        Me.reviewReleaseAlgorithmText = New System.Windows.Forms.TextBox()
        Me.reviewReleaseAlgorithmLabel = New System.Windows.Forms.Label()
        Me.consensusMethodText = New System.Windows.Forms.TextBox()
        Me.consensusMethodLabel = New System.Windows.Forms.Label()
        Me.ruleFutureReleaseText = New System.Windows.Forms.TextBox()
        Me.ruleFutureReleaseLabel = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.initialCoinReleaseBlockLabel = New System.Windows.Forms.Label()
        Me.maxTimeOutResponseNodeText = New System.Windows.Forms.TextBox()
        Me.maxTimeOutNotRespondeNodeLabel = New System.Windows.Forms.Label()
        Me.numberBlockInVolumeText = New System.Windows.Forms.TextBox()
        Me.numberBlockInVolumeLabel = New System.Windows.Forms.Label()
        Me.blockSizeFrequencyText = New System.Windows.Forms.TextBox()
        Me.blockSizeFrequencyLabel = New System.Windows.Forms.Label()
        Me.refundPlanTab = New System.Windows.Forms.TabPage()
        Me.addNewButton = New System.Windows.Forms.Button()
        Me.refundPlanDataGrid = New System.Windows.Forms.DataGridView()
        Me.Recipient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fixValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercentageValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisplayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.privacyPolicyTab = New System.Windows.Forms.TabPage()
        Me.privacyPolicyText = New System.Windows.Forms.TextBox()
        Me.generalConditionTab = New System.Windows.Forms.TabPage()
        Me.generalConditionText = New System.Windows.Forms.TextBox()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.loadButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.mainTabControl.SuspendLayout()
        Me.generalTab.SuspendLayout()
        Me.whitePaperTab.SuspendLayout()
        Me.yellowPaperTab.SuspendLayout()
        Me.primaryAssetTab.SuspendLayout()
        Me.transactionChainParameterTab.SuspendLayout()
        Me.refundPlanTab.SuspendLayout()
        CType(Me.refundPlanDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.privacyPolicyTab.SuspendLayout()
        Me.generalConditionTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainTabControl
        '
        Me.mainTabControl.Controls.Add(Me.generalTab)
        Me.mainTabControl.Controls.Add(Me.whitePaperTab)
        Me.mainTabControl.Controls.Add(Me.yellowPaperTab)
        Me.mainTabControl.Controls.Add(Me.primaryAssetTab)
        Me.mainTabControl.Controls.Add(Me.transactionChainParameterTab)
        Me.mainTabControl.Controls.Add(Me.refundPlanTab)
        Me.mainTabControl.Controls.Add(Me.privacyPolicyTab)
        Me.mainTabControl.Controls.Add(Me.generalConditionTab)
        Me.mainTabControl.Location = New System.Drawing.Point(2, 12)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(720, 378)
        Me.mainTabControl.TabIndex = 0
        '
        'generalTab
        '
        Me.generalTab.Controls.Add(Me.specialEnvironmentText)
        Me.generalTab.Controls.Add(Me.Label1)
        Me.generalTab.Controls.Add(Me.adminWalletAddress)
        Me.generalTab.Controls.Add(Me.networkNameText)
        Me.generalTab.Controls.Add(Me.networkNameLabel)
        Me.generalTab.Location = New System.Drawing.Point(4, 22)
        Me.generalTab.Name = "generalTab"
        Me.generalTab.Padding = New System.Windows.Forms.Padding(3)
        Me.generalTab.Size = New System.Drawing.Size(712, 352)
        Me.generalTab.TabIndex = 0
        Me.generalTab.Text = "General"
        Me.generalTab.UseVisualStyleBackColor = True
        '
        'specialEnvironmentText
        '
        Me.specialEnvironmentText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.specialEnvironmentText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.specialEnvironmentText.Location = New System.Drawing.Point(145, 49)
        Me.specialEnvironmentText.Name = "specialEnvironmentText"
        Me.specialEnvironmentText.Size = New System.Drawing.Size(470, 21)
        Me.specialEnvironmentText.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Special Environment"
        '
        'adminWalletAddress
        '
        Me.adminWalletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminWalletAddress.caption = "Admin wallet address"
        Me.adminWalletAddress.dataPath = ""
        Me.adminWalletAddress.Location = New System.Drawing.Point(6, 75)
        Me.adminWalletAddress.Name = "adminWalletAddress"
        Me.adminWalletAddress.Size = New System.Drawing.Size(684, 51)
        Me.adminWalletAddress.TabIndex = 1
        Me.adminWalletAddress.value = ""
        '
        'networkNameText
        '
        Me.networkNameText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.networkNameText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkNameText.Location = New System.Drawing.Point(145, 20)
        Me.networkNameText.Name = "networkNameText"
        Me.networkNameText.Size = New System.Drawing.Size(470, 21)
        Me.networkNameText.TabIndex = 0
        Me.networkNameText.Text = "Chainsociety - Main net"
        '
        'networkNameLabel
        '
        Me.networkNameLabel.AutoSize = True
        Me.networkNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkNameLabel.Location = New System.Drawing.Point(48, 23)
        Me.networkNameLabel.Name = "networkNameLabel"
        Me.networkNameLabel.Size = New System.Drawing.Size(90, 13)
        Me.networkNameLabel.TabIndex = 29
        Me.networkNameLabel.Text = "Network name"
        '
        'whitePaperTab
        '
        Me.whitePaperTab.Controls.Add(Me.whitePaperText)
        Me.whitePaperTab.Location = New System.Drawing.Point(4, 22)
        Me.whitePaperTab.Name = "whitePaperTab"
        Me.whitePaperTab.Padding = New System.Windows.Forms.Padding(3)
        Me.whitePaperTab.Size = New System.Drawing.Size(712, 352)
        Me.whitePaperTab.TabIndex = 1
        Me.whitePaperTab.Text = "Whitepaper"
        Me.whitePaperTab.UseVisualStyleBackColor = True
        '
        'whitePaperText
        '
        Me.whitePaperText.Location = New System.Drawing.Point(6, 6)
        Me.whitePaperText.Multiline = True
        Me.whitePaperText.Name = "whitePaperText"
        Me.whitePaperText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.whitePaperText.Size = New System.Drawing.Size(700, 343)
        Me.whitePaperText.TabIndex = 0
        '
        'yellowPaperTab
        '
        Me.yellowPaperTab.Controls.Add(Me.yellowPaperText)
        Me.yellowPaperTab.Location = New System.Drawing.Point(4, 22)
        Me.yellowPaperTab.Name = "yellowPaperTab"
        Me.yellowPaperTab.Size = New System.Drawing.Size(712, 352)
        Me.yellowPaperTab.TabIndex = 2
        Me.yellowPaperTab.Text = "Yellowpaper"
        Me.yellowPaperTab.UseVisualStyleBackColor = True
        '
        'yellowPaperText
        '
        Me.yellowPaperText.Location = New System.Drawing.Point(6, 6)
        Me.yellowPaperText.Multiline = True
        Me.yellowPaperText.Name = "yellowPaperText"
        Me.yellowPaperText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.yellowPaperText.Size = New System.Drawing.Size(700, 343)
        Me.yellowPaperText.TabIndex = 0
        '
        'primaryAssetTab
        '
        Me.primaryAssetTab.Controls.Add(Me.unLimitedCheck)
        Me.primaryAssetTab.Controls.Add(Me.policyAssetLabel)
        Me.primaryAssetTab.Controls.Add(Me.TextBox2)
        Me.primaryAssetTab.Controls.Add(Me.TextBox1)
        Me.primaryAssetTab.Controls.Add(Me.typeAssetLabel)
        Me.primaryAssetTab.Controls.Add(Me.generalInformationAssetLabel)
        Me.primaryAssetTab.Controls.Add(Me.initialStakeQuantityText)
        Me.primaryAssetTab.Controls.Add(Me.quantityTotalText)
        Me.primaryAssetTab.Controls.Add(Me.digitText)
        Me.primaryAssetTab.Controls.Add(Me.initialStakeQuantityLabel)
        Me.primaryAssetTab.Controls.Add(Me.nameUnitText)
        Me.primaryAssetTab.Controls.Add(Me.nameUnitLabel)
        Me.primaryAssetTab.Controls.Add(Me.burnableCheck)
        Me.primaryAssetTab.Controls.Add(Me.prestakeCheck)
        Me.primaryAssetTab.Controls.Add(Me.stakableCheck)
        Me.primaryAssetTab.Controls.Add(Me.digitLabel)
        Me.primaryAssetTab.Controls.Add(Me.quantityTotalLabel)
        Me.primaryAssetTab.Controls.Add(Me.symbolText)
        Me.primaryAssetTab.Controls.Add(Me.symbolLabel)
        Me.primaryAssetTab.Controls.Add(Me.shortNameText)
        Me.primaryAssetTab.Controls.Add(Me.shortNameLabel)
        Me.primaryAssetTab.Controls.Add(Me.assetNameText)
        Me.primaryAssetTab.Controls.Add(Me.assetNameLabel)
        Me.primaryAssetTab.Location = New System.Drawing.Point(4, 22)
        Me.primaryAssetTab.Name = "primaryAssetTab"
        Me.primaryAssetTab.Size = New System.Drawing.Size(712, 352)
        Me.primaryAssetTab.TabIndex = 3
        Me.primaryAssetTab.Text = "Asset"
        Me.primaryAssetTab.UseVisualStyleBackColor = True
        '
        'unLimitedCheck
        '
        Me.unLimitedCheck.AutoSize = True
        Me.unLimitedCheck.Location = New System.Drawing.Point(101, 200)
        Me.unLimitedCheck.Name = "unLimitedCheck"
        Me.unLimitedCheck.Size = New System.Drawing.Size(79, 17)
        Me.unLimitedCheck.TabIndex = 8
        Me.unLimitedCheck.Text = "Unlimited"
        Me.unLimitedCheck.UseVisualStyleBackColor = True
        '
        'policyAssetLabel
        '
        Me.policyAssetLabel.BackColor = System.Drawing.Color.CadetBlue
        Me.policyAssetLabel.Font = New System.Drawing.Font("Verdana", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.policyAssetLabel.ForeColor = System.Drawing.Color.SandyBrown
        Me.policyAssetLabel.Location = New System.Drawing.Point(25, 168)
        Me.policyAssetLabel.Name = "policyAssetLabel"
        Me.policyAssetLabel.Size = New System.Drawing.Size(631, 17)
        Me.policyAssetLabel.TabIndex = 51
        Me.policyAssetLabel.Text = "Policy Asset Information"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(101, 126)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(555, 21)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(101, 99)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(142, 21)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = "Coin"
        '
        'typeAssetLabel
        '
        Me.typeAssetLabel.AutoSize = True
        Me.typeAssetLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typeAssetLabel.Location = New System.Drawing.Point(62, 102)
        Me.typeAssetLabel.Name = "typeAssetLabel"
        Me.typeAssetLabel.Size = New System.Drawing.Size(34, 13)
        Me.typeAssetLabel.TabIndex = 49
        Me.typeAssetLabel.Text = "Type"
        '
        'generalInformationAssetLabel
        '
        Me.generalInformationAssetLabel.BackColor = System.Drawing.Color.CadetBlue
        Me.generalInformationAssetLabel.Font = New System.Drawing.Font("Verdana", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generalInformationAssetLabel.ForeColor = System.Drawing.Color.SandyBrown
        Me.generalInformationAssetLabel.Location = New System.Drawing.Point(25, 14)
        Me.generalInformationAssetLabel.Name = "generalInformationAssetLabel"
        Me.generalInformationAssetLabel.Size = New System.Drawing.Size(631, 17)
        Me.generalInformationAssetLabel.TabIndex = 47
        Me.generalInformationAssetLabel.Text = "General Information"
        '
        'initialStakeQuantityText
        '
        Me.initialStakeQuantityText.currentFormat = "0,000"
        Me.initialStakeQuantityText.Enabled = False
        Me.initialStakeQuantityText.Location = New System.Drawing.Point(328, 279)
        Me.initialStakeQuantityText.locationCode = "it-IT"
        Me.initialStakeQuantityText.Name = "initialStakeQuantityText"
        Me.initialStakeQuantityText.Size = New System.Drawing.Size(100, 21)
        Me.initialStakeQuantityText.TabIndex = 13
        Me.initialStakeQuantityText.Text = "0.000"
        Me.initialStakeQuantityText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.initialStakeQuantityText.useDecimal = False
        '
        'quantityTotalText
        '
        Me.quantityTotalText.currentFormat = "0,000"
        Me.quantityTotalText.Location = New System.Drawing.Point(101, 223)
        Me.quantityTotalText.locationCode = "it-IT"
        Me.quantityTotalText.Name = "quantityTotalText"
        Me.quantityTotalText.Size = New System.Drawing.Size(142, 21)
        Me.quantityTotalText.TabIndex = 10
        Me.quantityTotalText.Text = "0.000"
        Me.quantityTotalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.quantityTotalText.useDecimal = False
        '
        'digitText
        '
        Me.digitText.currentFormat = ""
        Me.digitText.Location = New System.Drawing.Point(390, 72)
        Me.digitText.locationCode = "it-IT"
        Me.digitText.Name = "digitText"
        Me.digitText.Size = New System.Drawing.Size(21, 21)
        Me.digitText.TabIndex = 3
        Me.digitText.Text = "0"
        Me.digitText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.digitText.useDecimal = False
        '
        'initialStakeQuantityLabel
        '
        Me.initialStakeQuantityLabel.AutoSize = True
        Me.initialStakeQuantityLabel.Enabled = False
        Me.initialStakeQuantityLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.initialStakeQuantityLabel.Location = New System.Drawing.Point(194, 283)
        Me.initialStakeQuantityLabel.Name = "initialStakeQuantityLabel"
        Me.initialStakeQuantityLabel.Size = New System.Drawing.Size(128, 13)
        Me.initialStakeQuantityLabel.TabIndex = 46
        Me.initialStakeQuantityLabel.Text = "Initial Stake Quantity"
        '
        'nameUnitText
        '
        Me.nameUnitText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nameUnitText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameUnitText.Location = New System.Drawing.Point(514, 72)
        Me.nameUnitText.Name = "nameUnitText"
        Me.nameUnitText.Size = New System.Drawing.Size(142, 21)
        Me.nameUnitText.TabIndex = 4
        Me.nameUnitText.Text = "Short"
        '
        'nameUnitLabel
        '
        Me.nameUnitLabel.AutoSize = True
        Me.nameUnitLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameUnitLabel.Location = New System.Drawing.Point(439, 75)
        Me.nameUnitLabel.Name = "nameUnitLabel"
        Me.nameUnitLabel.Size = New System.Drawing.Size(65, 13)
        Me.nameUnitLabel.TabIndex = 44
        Me.nameUnitLabel.Text = "Name unit"
        '
        'burnableCheck
        '
        Me.burnableCheck.AutoSize = True
        Me.burnableCheck.Location = New System.Drawing.Point(272, 200)
        Me.burnableCheck.Name = "burnableCheck"
        Me.burnableCheck.Size = New System.Drawing.Size(77, 17)
        Me.burnableCheck.TabIndex = 9
        Me.burnableCheck.Text = "Burnable"
        Me.burnableCheck.UseVisualStyleBackColor = True
        '
        'prestakeCheck
        '
        Me.prestakeCheck.AutoSize = True
        Me.prestakeCheck.Location = New System.Drawing.Point(101, 281)
        Me.prestakeCheck.Name = "prestakeCheck"
        Me.prestakeCheck.Size = New System.Drawing.Size(76, 17)
        Me.prestakeCheck.TabIndex = 12
        Me.prestakeCheck.Text = "Prestake"
        Me.prestakeCheck.UseVisualStyleBackColor = True
        '
        'stakableCheck
        '
        Me.stakableCheck.AutoSize = True
        Me.stakableCheck.Location = New System.Drawing.Point(101, 255)
        Me.stakableCheck.Name = "stakableCheck"
        Me.stakableCheck.Size = New System.Drawing.Size(76, 17)
        Me.stakableCheck.TabIndex = 11
        Me.stakableCheck.Text = "Stakable"
        Me.stakableCheck.UseVisualStyleBackColor = True
        '
        'digitLabel
        '
        Me.digitLabel.AutoSize = True
        Me.digitLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.digitLabel.Location = New System.Drawing.Point(353, 75)
        Me.digitLabel.Name = "digitLabel"
        Me.digitLabel.Size = New System.Drawing.Size(33, 13)
        Me.digitLabel.TabIndex = 39
        Me.digitLabel.Text = "Digit"
        '
        'quantityTotalLabel
        '
        Me.quantityTotalLabel.AutoSize = True
        Me.quantityTotalLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantityTotalLabel.Location = New System.Drawing.Point(10, 226)
        Me.quantityTotalLabel.Name = "quantityTotalLabel"
        Me.quantityTotalLabel.Size = New System.Drawing.Size(86, 13)
        Me.quantityTotalLabel.TabIndex = 37
        Me.quantityTotalLabel.Text = "Quantity Total"
        '
        'symbolText
        '
        Me.symbolText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.symbolText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.symbolText.Location = New System.Drawing.Point(310, 72)
        Me.symbolText.MaxLength = 1
        Me.symbolText.Name = "symbolText"
        Me.symbolText.Size = New System.Drawing.Size(21, 21)
        Me.symbolText.TabIndex = 2
        Me.symbolText.Text = "§"
        Me.symbolText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'symbolLabel
        '
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.symbolLabel.Location = New System.Drawing.Point(255, 75)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(50, 13)
        Me.symbolLabel.TabIndex = 35
        Me.symbolLabel.Text = "Symbol"
        '
        'shortNameText
        '
        Me.shortNameText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.shortNameText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shortNameText.Location = New System.Drawing.Point(101, 72)
        Me.shortNameText.Name = "shortNameText"
        Me.shortNameText.Size = New System.Drawing.Size(142, 21)
        Me.shortNameText.TabIndex = 1
        Me.shortNameText.Text = "CHCDTN"
        '
        'shortNameLabel
        '
        Me.shortNameLabel.AutoSize = True
        Me.shortNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shortNameLabel.Location = New System.Drawing.Point(22, 75)
        Me.shortNameLabel.Name = "shortNameLabel"
        Me.shortNameLabel.Size = New System.Drawing.Size(74, 13)
        Me.shortNameLabel.TabIndex = 33
        Me.shortNameLabel.Text = "Short name"
        '
        'assetNameText
        '
        Me.assetNameText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assetNameText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assetNameText.Location = New System.Drawing.Point(101, 45)
        Me.assetNameText.Name = "assetNameText"
        Me.assetNameText.Size = New System.Drawing.Size(555, 21)
        Me.assetNameText.TabIndex = 0
        Me.assetNameText.Text = "Crypto Hide Coin Decentralized Trustless Network"
        '
        'assetNameLabel
        '
        Me.assetNameLabel.AutoSize = True
        Me.assetNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assetNameLabel.Location = New System.Drawing.Point(22, 48)
        Me.assetNameLabel.Name = "assetNameLabel"
        Me.assetNameLabel.Size = New System.Drawing.Size(74, 13)
        Me.assetNameLabel.TabIndex = 31
        Me.assetNameLabel.Text = "Asset name"
        '
        'transactionChainParameterTab
        '
        Me.transactionChainParameterTab.Controls.Add(Me.maxTimeOutNotEvaluateNodeText)
        Me.transactionChainParameterTab.Controls.Add(Me.maxTimeOutNotEvaluateNodeLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainInternalText)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainInternalRegistryLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainTrashedText)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainTrashedLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainRejectedText)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainRejectedLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainBulletinesText)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainBulletinesLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainConsensusText)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainConsensusLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainRequestText)
        Me.transactionChainParameterTab.Controls.Add(Me.minimalMaintainRequestLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.initialCoinReleaseBlockText)
        Me.transactionChainParameterTab.Controls.Add(Me.reviewReleaseAlgorithmText)
        Me.transactionChainParameterTab.Controls.Add(Me.reviewReleaseAlgorithmLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.consensusMethodText)
        Me.transactionChainParameterTab.Controls.Add(Me.consensusMethodLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.ruleFutureReleaseText)
        Me.transactionChainParameterTab.Controls.Add(Me.ruleFutureReleaseLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.Label12)
        Me.transactionChainParameterTab.Controls.Add(Me.initialCoinReleaseBlockLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.maxTimeOutResponseNodeText)
        Me.transactionChainParameterTab.Controls.Add(Me.maxTimeOutNotRespondeNodeLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.numberBlockInVolumeText)
        Me.transactionChainParameterTab.Controls.Add(Me.numberBlockInVolumeLabel)
        Me.transactionChainParameterTab.Controls.Add(Me.blockSizeFrequencyText)
        Me.transactionChainParameterTab.Controls.Add(Me.blockSizeFrequencyLabel)
        Me.transactionChainParameterTab.Location = New System.Drawing.Point(4, 22)
        Me.transactionChainParameterTab.Name = "transactionChainParameterTab"
        Me.transactionChainParameterTab.Size = New System.Drawing.Size(712, 352)
        Me.transactionChainParameterTab.TabIndex = 4
        Me.transactionChainParameterTab.Text = "Transaction Chain"
        Me.transactionChainParameterTab.UseVisualStyleBackColor = True
        '
        'maxTimeOutNotEvaluateNodeText
        '
        Me.maxTimeOutNotEvaluateNodeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxTimeOutNotEvaluateNodeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotEvaluateNodeText.Location = New System.Drawing.Point(539, 45)
        Me.maxTimeOutNotEvaluateNodeText.Name = "maxTimeOutNotEvaluateNodeText"
        Me.maxTimeOutNotEvaluateNodeText.ReadOnly = True
        Me.maxTimeOutNotEvaluateNodeText.Size = New System.Drawing.Size(75, 21)
        Me.maxTimeOutNotEvaluateNodeText.TabIndex = 59
        Me.maxTimeOutNotEvaluateNodeText.Text = "120 sec."
        '
        'maxTimeOutNotEvaluateNodeLabel
        '
        Me.maxTimeOutNotEvaluateNodeLabel.AutoSize = True
        Me.maxTimeOutNotEvaluateNodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotEvaluateNodeLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.maxTimeOutNotEvaluateNodeLabel.Location = New System.Drawing.Point(340, 48)
        Me.maxTimeOutNotEvaluateNodeLabel.Name = "maxTimeOutNotEvaluateNodeLabel"
        Me.maxTimeOutNotEvaluateNodeLabel.Size = New System.Drawing.Size(184, 13)
        Me.maxTimeOutNotEvaluateNodeLabel.TabIndex = 60
        Me.maxTimeOutNotEvaluateNodeLabel.Text = "Max timeout not evaluate node"
        '
        'minimalMaintainInternalText
        '
        Me.minimalMaintainInternalText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimalMaintainInternalText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainInternalText.Location = New System.Drawing.Point(545, 324)
        Me.minimalMaintainInternalText.Name = "minimalMaintainInternalText"
        Me.minimalMaintainInternalText.ReadOnly = True
        Me.minimalMaintainInternalText.Size = New System.Drawing.Size(119, 21)
        Me.minimalMaintainInternalText.TabIndex = 57
        Me.minimalMaintainInternalText.Text = "5 days"
        '
        'minimalMaintainInternalRegistryLabel
        '
        Me.minimalMaintainInternalRegistryLabel.AutoSize = True
        Me.minimalMaintainInternalRegistryLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainInternalRegistryLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainInternalRegistryLabel.Location = New System.Drawing.Point(389, 327)
        Me.minimalMaintainInternalRegistryLabel.Name = "minimalMaintainInternalRegistryLabel"
        Me.minimalMaintainInternalRegistryLabel.Size = New System.Drawing.Size(150, 13)
        Me.minimalMaintainInternalRegistryLabel.TabIndex = 58
        Me.minimalMaintainInternalRegistryLabel.Text = "Minimal Maintain Internal"
        '
        'minimalMaintainTrashedText
        '
        Me.minimalMaintainTrashedText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimalMaintainTrashedText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainTrashedText.Location = New System.Drawing.Point(221, 324)
        Me.minimalMaintainTrashedText.Name = "minimalMaintainTrashedText"
        Me.minimalMaintainTrashedText.ReadOnly = True
        Me.minimalMaintainTrashedText.Size = New System.Drawing.Size(134, 21)
        Me.minimalMaintainTrashedText.TabIndex = 55
        Me.minimalMaintainTrashedText.Text = "7 days"
        '
        'minimalMaintainTrashedLabel
        '
        Me.minimalMaintainTrashedLabel.AutoSize = True
        Me.minimalMaintainTrashedLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainTrashedLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainTrashedLabel.Location = New System.Drawing.Point(60, 327)
        Me.minimalMaintainTrashedLabel.Name = "minimalMaintainTrashedLabel"
        Me.minimalMaintainTrashedLabel.Size = New System.Drawing.Size(150, 13)
        Me.minimalMaintainTrashedLabel.TabIndex = 56
        Me.minimalMaintainTrashedLabel.Text = "Minimal Maintain Trashed"
        '
        'minimalMaintainRejectedText
        '
        Me.minimalMaintainRejectedText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimalMaintainRejectedText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRejectedText.Location = New System.Drawing.Point(545, 297)
        Me.minimalMaintainRejectedText.Name = "minimalMaintainRejectedText"
        Me.minimalMaintainRejectedText.ReadOnly = True
        Me.minimalMaintainRejectedText.Size = New System.Drawing.Size(119, 21)
        Me.minimalMaintainRejectedText.TabIndex = 53
        Me.minimalMaintainRejectedText.Text = "14 days"
        '
        'minimalMaintainRejectedLabel
        '
        Me.minimalMaintainRejectedLabel.AutoSize = True
        Me.minimalMaintainRejectedLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRejectedLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainRejectedLabel.Location = New System.Drawing.Point(384, 300)
        Me.minimalMaintainRejectedLabel.Name = "minimalMaintainRejectedLabel"
        Me.minimalMaintainRejectedLabel.Size = New System.Drawing.Size(155, 13)
        Me.minimalMaintainRejectedLabel.TabIndex = 54
        Me.minimalMaintainRejectedLabel.Text = "Minimal Maintain Rejected"
        '
        'minimalMaintainBulletinesText
        '
        Me.minimalMaintainBulletinesText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimalMaintainBulletinesText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainBulletinesText.Location = New System.Drawing.Point(221, 297)
        Me.minimalMaintainBulletinesText.Name = "minimalMaintainBulletinesText"
        Me.minimalMaintainBulletinesText.ReadOnly = True
        Me.minimalMaintainBulletinesText.Size = New System.Drawing.Size(134, 21)
        Me.minimalMaintainBulletinesText.TabIndex = 51
        Me.minimalMaintainBulletinesText.Text = "1 year"
        '
        'minimalMaintainBulletinesLabel
        '
        Me.minimalMaintainBulletinesLabel.AutoSize = True
        Me.minimalMaintainBulletinesLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainBulletinesLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainBulletinesLabel.Location = New System.Drawing.Point(55, 300)
        Me.minimalMaintainBulletinesLabel.Name = "minimalMaintainBulletinesLabel"
        Me.minimalMaintainBulletinesLabel.Size = New System.Drawing.Size(160, 13)
        Me.minimalMaintainBulletinesLabel.TabIndex = 52
        Me.minimalMaintainBulletinesLabel.Text = "Minimal Maintain Bulletines"
        '
        'minimalMaintainConsensusText
        '
        Me.minimalMaintainConsensusText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimalMaintainConsensusText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainConsensusText.Location = New System.Drawing.Point(545, 270)
        Me.minimalMaintainConsensusText.Name = "minimalMaintainConsensusText"
        Me.minimalMaintainConsensusText.ReadOnly = True
        Me.minimalMaintainConsensusText.Size = New System.Drawing.Size(119, 21)
        Me.minimalMaintainConsensusText.TabIndex = 49
        Me.minimalMaintainConsensusText.Text = "2 years"
        '
        'minimalMaintainConsensusLabel
        '
        Me.minimalMaintainConsensusLabel.AutoSize = True
        Me.minimalMaintainConsensusLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainConsensusLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainConsensusLabel.Location = New System.Drawing.Point(372, 273)
        Me.minimalMaintainConsensusLabel.Name = "minimalMaintainConsensusLabel"
        Me.minimalMaintainConsensusLabel.Size = New System.Drawing.Size(167, 13)
        Me.minimalMaintainConsensusLabel.TabIndex = 50
        Me.minimalMaintainConsensusLabel.Text = "Minimal Maintain Consensus"
        '
        'minimalMaintainRequestText
        '
        Me.minimalMaintainRequestText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimalMaintainRequestText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRequestText.Location = New System.Drawing.Point(221, 270)
        Me.minimalMaintainRequestText.Name = "minimalMaintainRequestText"
        Me.minimalMaintainRequestText.ReadOnly = True
        Me.minimalMaintainRequestText.Size = New System.Drawing.Size(134, 21)
        Me.minimalMaintainRequestText.TabIndex = 47
        Me.minimalMaintainRequestText.Text = "3 years"
        '
        'minimalMaintainRequestLabel
        '
        Me.minimalMaintainRequestLabel.AutoSize = True
        Me.minimalMaintainRequestLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRequestLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainRequestLabel.Location = New System.Drawing.Point(63, 273)
        Me.minimalMaintainRequestLabel.Name = "minimalMaintainRequestLabel"
        Me.minimalMaintainRequestLabel.Size = New System.Drawing.Size(151, 13)
        Me.minimalMaintainRequestLabel.TabIndex = 48
        Me.minimalMaintainRequestLabel.Text = "Minimal Maintain Request"
        '
        'initialCoinReleaseBlockText
        '
        Me.initialCoinReleaseBlockText.currentFormat = "0,000"
        Me.initialCoinReleaseBlockText.Location = New System.Drawing.Point(221, 72)
        Me.initialCoinReleaseBlockText.locationCode = "it-IT"
        Me.initialCoinReleaseBlockText.Name = "initialCoinReleaseBlockText"
        Me.initialCoinReleaseBlockText.Size = New System.Drawing.Size(75, 21)
        Me.initialCoinReleaseBlockText.TabIndex = 0
        Me.initialCoinReleaseBlockText.Text = "0.000"
        Me.initialCoinReleaseBlockText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.initialCoinReleaseBlockText.useDecimal = False
        '
        'reviewReleaseAlgorithmText
        '
        Me.reviewReleaseAlgorithmText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reviewReleaseAlgorithmText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reviewReleaseAlgorithmText.Location = New System.Drawing.Point(221, 243)
        Me.reviewReleaseAlgorithmText.Name = "reviewReleaseAlgorithmText"
        Me.reviewReleaseAlgorithmText.ReadOnly = True
        Me.reviewReleaseAlgorithmText.Size = New System.Drawing.Size(134, 21)
        Me.reviewReleaseAlgorithmText.TabIndex = 45
        Me.reviewReleaseAlgorithmText.Text = "On transaction"
        '
        'reviewReleaseAlgorithmLabel
        '
        Me.reviewReleaseAlgorithmLabel.AutoSize = True
        Me.reviewReleaseAlgorithmLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reviewReleaseAlgorithmLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.reviewReleaseAlgorithmLabel.Location = New System.Drawing.Point(63, 246)
        Me.reviewReleaseAlgorithmLabel.Name = "reviewReleaseAlgorithmLabel"
        Me.reviewReleaseAlgorithmLabel.Size = New System.Drawing.Size(152, 13)
        Me.reviewReleaseAlgorithmLabel.TabIndex = 46
        Me.reviewReleaseAlgorithmLabel.Text = "Review release algorithm"
        '
        'consensusMethodText
        '
        Me.consensusMethodText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.consensusMethodText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consensusMethodText.Location = New System.Drawing.Point(501, 243)
        Me.consensusMethodText.Name = "consensusMethodText"
        Me.consensusMethodText.ReadOnly = True
        Me.consensusMethodText.Size = New System.Drawing.Size(163, 21)
        Me.consensusMethodText.TabIndex = 43
        Me.consensusMethodText.Text = "Proof Of Stake Declarative"
        '
        'consensusMethodLabel
        '
        Me.consensusMethodLabel.AutoSize = True
        Me.consensusMethodLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consensusMethodLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.consensusMethodLabel.Location = New System.Drawing.Point(379, 249)
        Me.consensusMethodLabel.Name = "consensusMethodLabel"
        Me.consensusMethodLabel.Size = New System.Drawing.Size(116, 13)
        Me.consensusMethodLabel.TabIndex = 44
        Me.consensusMethodLabel.Text = "Consensus method"
        '
        'ruleFutureReleaseText
        '
        Me.ruleFutureReleaseText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ruleFutureReleaseText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ruleFutureReleaseText.Location = New System.Drawing.Point(221, 99)
        Me.ruleFutureReleaseText.Multiline = True
        Me.ruleFutureReleaseText.Name = "ruleFutureReleaseText"
        Me.ruleFutureReleaseText.Size = New System.Drawing.Size(443, 138)
        Me.ruleFutureReleaseText.TabIndex = 1
        '
        'ruleFutureReleaseLabel
        '
        Me.ruleFutureReleaseLabel.AutoSize = True
        Me.ruleFutureReleaseLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ruleFutureReleaseLabel.Location = New System.Drawing.Point(94, 102)
        Me.ruleFutureReleaseLabel.Name = "ruleFutureReleaseLabel"
        Me.ruleFutureReleaseLabel.Size = New System.Drawing.Size(116, 13)
        Me.ruleFutureReleaseLabel.TabIndex = 42
        Me.ruleFutureReleaseLabel.Text = "Rule future release"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(302, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "coin"
        '
        'initialCoinReleaseBlockLabel
        '
        Me.initialCoinReleaseBlockLabel.AutoSize = True
        Me.initialCoinReleaseBlockLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.initialCoinReleaseBlockLabel.Location = New System.Drawing.Point(41, 75)
        Me.initialCoinReleaseBlockLabel.Name = "initialCoinReleaseBlockLabel"
        Me.initialCoinReleaseBlockLabel.Size = New System.Drawing.Size(169, 13)
        Me.initialCoinReleaseBlockLabel.TabIndex = 39
        Me.initialCoinReleaseBlockLabel.Text = "Initial coin release per block"
        '
        'maxTimeOutResponseNodeText
        '
        Me.maxTimeOutResponseNodeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxTimeOutResponseNodeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutResponseNodeText.Location = New System.Drawing.Point(221, 45)
        Me.maxTimeOutResponseNodeText.Name = "maxTimeOutResponseNodeText"
        Me.maxTimeOutResponseNodeText.ReadOnly = True
        Me.maxTimeOutResponseNodeText.Size = New System.Drawing.Size(75, 21)
        Me.maxTimeOutResponseNodeText.TabIndex = 36
        Me.maxTimeOutResponseNodeText.Text = "120 sec."
        '
        'maxTimeOutNotRespondeNodeLabel
        '
        Me.maxTimeOutNotRespondeNodeLabel.AutoSize = True
        Me.maxTimeOutNotRespondeNodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotRespondeNodeLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.maxTimeOutNotRespondeNodeLabel.Location = New System.Drawing.Point(22, 48)
        Me.maxTimeOutNotRespondeNodeLabel.Name = "maxTimeOutNotRespondeNodeLabel"
        Me.maxTimeOutNotRespondeNodeLabel.Size = New System.Drawing.Size(188, 13)
        Me.maxTimeOutNotRespondeNodeLabel.TabIndex = 37
        Me.maxTimeOutNotRespondeNodeLabel.Text = "Max timeout not responde node"
        '
        'numberBlockInVolumeText
        '
        Me.numberBlockInVolumeText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numberBlockInVolumeText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numberBlockInVolumeText.Location = New System.Drawing.Point(539, 18)
        Me.numberBlockInVolumeText.Name = "numberBlockInVolumeText"
        Me.numberBlockInVolumeText.ReadOnly = True
        Me.numberBlockInVolumeText.Size = New System.Drawing.Size(75, 21)
        Me.numberBlockInVolumeText.TabIndex = 34
        Me.numberBlockInVolumeText.Text = "365"
        '
        'numberBlockInVolumeLabel
        '
        Me.numberBlockInVolumeLabel.AutoSize = True
        Me.numberBlockInVolumeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numberBlockInVolumeLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.numberBlockInVolumeLabel.Location = New System.Drawing.Point(379, 21)
        Me.numberBlockInVolumeLabel.Name = "numberBlockInVolumeLabel"
        Me.numberBlockInVolumeLabel.Size = New System.Drawing.Size(149, 13)
        Me.numberBlockInVolumeLabel.TabIndex = 35
        Me.numberBlockInVolumeLabel.Text = "Number Block In volume"
        '
        'blockSizeFrequencyText
        '
        Me.blockSizeFrequencyText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.blockSizeFrequencyText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blockSizeFrequencyText.Location = New System.Drawing.Point(221, 18)
        Me.blockSizeFrequencyText.Name = "blockSizeFrequencyText"
        Me.blockSizeFrequencyText.ReadOnly = True
        Me.blockSizeFrequencyText.Size = New System.Drawing.Size(75, 21)
        Me.blockSizeFrequencyText.TabIndex = 32
        Me.blockSizeFrequencyText.Text = "24 hours"
        '
        'blockSizeFrequencyLabel
        '
        Me.blockSizeFrequencyLabel.AutoSize = True
        Me.blockSizeFrequencyLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blockSizeFrequencyLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.blockSizeFrequencyLabel.Location = New System.Drawing.Point(81, 21)
        Me.blockSizeFrequencyLabel.Name = "blockSizeFrequencyLabel"
        Me.blockSizeFrequencyLabel.Size = New System.Drawing.Size(129, 13)
        Me.blockSizeFrequencyLabel.TabIndex = 33
        Me.blockSizeFrequencyLabel.Text = "Block Size Frequency"
        '
        'refundPlanTab
        '
        Me.refundPlanTab.Controls.Add(Me.addNewButton)
        Me.refundPlanTab.Controls.Add(Me.refundPlanDataGrid)
        Me.refundPlanTab.Location = New System.Drawing.Point(4, 22)
        Me.refundPlanTab.Name = "refundPlanTab"
        Me.refundPlanTab.Size = New System.Drawing.Size(712, 352)
        Me.refundPlanTab.TabIndex = 5
        Me.refundPlanTab.Text = "Refund Plan"
        Me.refundPlanTab.UseVisualStyleBackColor = True
        '
        'addNewButton
        '
        Me.addNewButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.addNewButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addNewButton.Location = New System.Drawing.Point(599, 13)
        Me.addNewButton.Name = "addNewButton"
        Me.addNewButton.Size = New System.Drawing.Size(108, 23)
        Me.addNewButton.TabIndex = 0
        Me.addNewButton.Text = "Create New"
        Me.addNewButton.UseVisualStyleBackColor = True
        '
        'refundPlanDataGrid
        '
        Me.refundPlanDataGrid.AllowUserToAddRows = False
        Me.refundPlanDataGrid.AllowUserToDeleteRows = False
        Me.refundPlanDataGrid.AllowUserToResizeColumns = False
        Me.refundPlanDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.refundPlanDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Recipient, Me.Description, Me.fixValue, Me.PercentageValue, Me.DisplayValue})
        Me.refundPlanDataGrid.Location = New System.Drawing.Point(6, 42)
        Me.refundPlanDataGrid.MultiSelect = False
        Me.refundPlanDataGrid.Name = "refundPlanDataGrid"
        Me.refundPlanDataGrid.ReadOnly = True
        Me.refundPlanDataGrid.RowHeadersVisible = False
        Me.refundPlanDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.refundPlanDataGrid.Size = New System.Drawing.Size(701, 307)
        Me.refundPlanDataGrid.TabIndex = 1
        '
        'Recipient
        '
        Me.Recipient.HeaderText = "Recipient"
        Me.Recipient.Name = "Recipient"
        Me.Recipient.ReadOnly = True
        Me.Recipient.Visible = False
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 400
        '
        'fixValue
        '
        Me.fixValue.HeaderText = "Fix Value"
        Me.fixValue.Name = "fixValue"
        Me.fixValue.ReadOnly = True
        Me.fixValue.Visible = False
        '
        'PercentageValue
        '
        Me.PercentageValue.HeaderText = "Percentage Value"
        Me.PercentageValue.Name = "PercentageValue"
        Me.PercentageValue.ReadOnly = True
        Me.PercentageValue.Visible = False
        '
        'DisplayValue
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DisplayValue.DefaultCellStyle = DataGridViewCellStyle1
        Me.DisplayValue.HeaderText = "Value"
        Me.DisplayValue.Name = "DisplayValue"
        Me.DisplayValue.ReadOnly = True
        Me.DisplayValue.Width = 150
        '
        'privacyPolicyTab
        '
        Me.privacyPolicyTab.Controls.Add(Me.privacyPolicyText)
        Me.privacyPolicyTab.Location = New System.Drawing.Point(4, 22)
        Me.privacyPolicyTab.Name = "privacyPolicyTab"
        Me.privacyPolicyTab.Size = New System.Drawing.Size(712, 352)
        Me.privacyPolicyTab.TabIndex = 6
        Me.privacyPolicyTab.Text = "Privacy Policy"
        Me.privacyPolicyTab.UseVisualStyleBackColor = True
        '
        'privacyPolicyText
        '
        Me.privacyPolicyText.Location = New System.Drawing.Point(6, 5)
        Me.privacyPolicyText.Multiline = True
        Me.privacyPolicyText.Name = "privacyPolicyText"
        Me.privacyPolicyText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.privacyPolicyText.Size = New System.Drawing.Size(700, 343)
        Me.privacyPolicyText.TabIndex = 1
        '
        'generalConditionTab
        '
        Me.generalConditionTab.Controls.Add(Me.generalConditionText)
        Me.generalConditionTab.Location = New System.Drawing.Point(4, 22)
        Me.generalConditionTab.Name = "generalConditionTab"
        Me.generalConditionTab.Size = New System.Drawing.Size(712, 352)
        Me.generalConditionTab.TabIndex = 7
        Me.generalConditionTab.Text = "General Condition"
        Me.generalConditionTab.UseVisualStyleBackColor = True
        '
        'generalConditionText
        '
        Me.generalConditionText.Location = New System.Drawing.Point(6, 5)
        Me.generalConditionText.Multiline = True
        Me.generalConditionText.Name = "generalConditionText"
        Me.generalConditionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.generalConditionText.Size = New System.Drawing.Size(700, 343)
        Me.generalConditionText.TabIndex = 0
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(566, 392)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 23)
        Me.confirmButton.TabIndex = 3
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(643, 392)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 4
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(4, 392)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(75, 23)
        Me.loadButton.TabIndex = 1
        Me.loadButton.Text = "Load"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(85, 392)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 2
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'BuildNetwork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(725, 421)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.mainTabControl)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(741, 460)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(741, 460)
        Me.Name = "BuildNetwork"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Network Builder - Crypto Hide Coin DTN"
        Me.mainTabControl.ResumeLayout(False)
        Me.generalTab.ResumeLayout(False)
        Me.generalTab.PerformLayout()
        Me.whitePaperTab.ResumeLayout(False)
        Me.whitePaperTab.PerformLayout()
        Me.yellowPaperTab.ResumeLayout(False)
        Me.yellowPaperTab.PerformLayout()
        Me.primaryAssetTab.ResumeLayout(False)
        Me.primaryAssetTab.PerformLayout()
        Me.transactionChainParameterTab.ResumeLayout(False)
        Me.transactionChainParameterTab.PerformLayout()
        Me.refundPlanTab.ResumeLayout(False)
        CType(Me.refundPlanDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.privacyPolicyTab.ResumeLayout(False)
        Me.privacyPolicyTab.PerformLayout()
        Me.generalConditionTab.ResumeLayout(False)
        Me.generalConditionTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTabControl As TabControl
    Friend WithEvents generalTab As TabPage
    Friend WithEvents whitePaperTab As TabPage
    Friend WithEvents adminWalletAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents networkNameText As TextBox
    Friend WithEvents networkNameLabel As Label
    Friend WithEvents whitePaperText As TextBox
    Friend WithEvents yellowPaperTab As TabPage
    Friend WithEvents yellowPaperText As TextBox
    Friend WithEvents primaryAssetTab As TabPage
    Friend WithEvents initialStakeQuantityLabel As Label
    Friend WithEvents nameUnitText As TextBox
    Friend WithEvents nameUnitLabel As Label
    Friend WithEvents burnableCheck As CheckBox
    Friend WithEvents prestakeCheck As CheckBox
    Friend WithEvents stakableCheck As CheckBox
    Friend WithEvents digitLabel As Label
    Friend WithEvents quantityTotalLabel As Label
    Friend WithEvents symbolText As TextBox
    Friend WithEvents symbolLabel As Label
    Friend WithEvents shortNameText As TextBox
    Friend WithEvents shortNameLabel As Label
    Friend WithEvents assetNameText As TextBox
    Friend WithEvents assetNameLabel As Label
    Friend WithEvents transactionChainParameterTab As TabPage
    Friend WithEvents consensusMethodText As TextBox
    Friend WithEvents consensusMethodLabel As Label
    Friend WithEvents ruleFutureReleaseText As TextBox
    Friend WithEvents ruleFutureReleaseLabel As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents initialCoinReleaseBlockLabel As Label
    Friend WithEvents maxTimeOutResponseNodeText As TextBox
    Friend WithEvents maxTimeOutNotRespondeNodeLabel As Label
    Friend WithEvents numberBlockInVolumeText As TextBox
    Friend WithEvents numberBlockInVolumeLabel As Label
    Friend WithEvents blockSizeFrequencyText As TextBox
    Friend WithEvents blockSizeFrequencyLabel As Label
    Friend WithEvents refundPlanTab As TabPage
    Friend WithEvents privacyPolicyTab As TabPage
    Friend WithEvents generalConditionTab As TabPage
    Friend WithEvents confirmButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents addNewButton As Button
    Friend WithEvents refundPlanDataGrid As DataGridView
    Friend WithEvents privacyPolicyText As TextBox
    Friend WithEvents generalConditionText As TextBox
    Friend WithEvents reviewReleaseAlgorithmText As TextBox
    Friend WithEvents reviewReleaseAlgorithmLabel As Label
    Friend WithEvents loadButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents Recipient As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents fixValue As DataGridViewTextBoxColumn
    Friend WithEvents PercentageValue As DataGridViewTextBoxColumn
    Friend WithEvents DisplayValue As DataGridViewTextBoxColumn
    Friend WithEvents digitText As CHCSupportUIControls.NumericText
    Friend WithEvents initialStakeQuantityText As CHCSupportUIControls.NumericText
    Friend WithEvents quantityTotalText As CHCSupportUIControls.NumericText
    Friend WithEvents initialCoinReleaseBlockText As CHCSupportUIControls.NumericText
    Friend WithEvents specialEnvironmentText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents unLimitedCheck As CheckBox
    Friend WithEvents policyAssetLabel As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents typeAssetLabel As Label
    Friend WithEvents generalInformationAssetLabel As Label
    Friend WithEvents minimalMaintainInternalText As TextBox
    Friend WithEvents minimalMaintainInternalRegistryLabel As Label
    Friend WithEvents minimalMaintainTrashedText As TextBox
    Friend WithEvents minimalMaintainTrashedLabel As Label
    Friend WithEvents minimalMaintainRejectedText As TextBox
    Friend WithEvents minimalMaintainRejectedLabel As Label
    Friend WithEvents minimalMaintainBulletinesText As TextBox
    Friend WithEvents minimalMaintainBulletinesLabel As Label
    Friend WithEvents minimalMaintainConsensusText As TextBox
    Friend WithEvents minimalMaintainConsensusLabel As Label
    Friend WithEvents minimalMaintainRequestText As TextBox
    Friend WithEvents minimalMaintainRequestLabel As Label
    Friend WithEvents maxTimeOutNotEvaluateNodeText As TextBox
    Friend WithEvents maxTimeOutNotEvaluateNodeLabel As Label
End Class
