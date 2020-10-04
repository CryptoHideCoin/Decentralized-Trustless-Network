<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SideChainConfigurationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SideChainConfigurationForm))
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.CoinNameLabel = New System.Windows.Forms.Label()
        Me.nameValue = New System.Windows.Forms.TextBox()
        Me.containerSelected = New System.Windows.Forms.Panel()
        Me.tabDetail = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.refundPlanValue = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.priceListValue = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.assetValue = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.typeValue = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TermsAndConditionsPaperValue = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.privacyPaperValue = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.yellowPaperValue = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.whitePaperValue = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.visionPaperValue = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.confirmUpdateButton = New System.Windows.Forms.Button()
        Me.distributeValue = New System.Windows.Forms.TextBox()
        Me.distributeLabel = New System.Windows.Forms.Label()
        Me.addNewHeadBand = New System.Windows.Forms.Button()
        Me.untilAvailabilityValue = New System.Windows.Forms.TextBox()
        Me.untilAvailabilityLabel = New System.Windows.Forms.Label()
        Me.rewardDataGrid = New System.Windows.Forms.DataGridView()
        Me.rowIndexPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.untilAvailability = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.distribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.walletAddressPremined = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.preminedCoin = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.uniqueChainKeyValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.selectedTabPage = New System.Windows.Forms.TabPage()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.dataGridView = New System.Windows.Forms.DataGridView()
        Me.listTabPage = New System.Windows.Forms.TabPage()
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        Me.containerSelected.SuspendLayout()
        Me.tabDetail.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.rewardDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.selectedTabPage.SuspendLayout()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.listTabPage.SuspendLayout()
        Me.mainTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Location = New System.Drawing.Point(24, 551)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 51)
        Me.cancelButton.TabIndex = 4
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmButton.Location = New System.Drawing.Point(775, 551)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 51)
        Me.confirmButton.TabIndex = 5
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'identityValue
        '
        Me.identityValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.identityValue.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.identityValue.Location = New System.Drawing.Point(25, 46)
        Me.identityValue.Name = "identityValue"
        Me.identityValue.ReadOnly = True
        Me.identityValue.Size = New System.Drawing.Size(825, 21)
        Me.identityValue.TabIndex = 0
        Me.identityValue.TabStop = False
        Me.identityValue.Text = "NO FILE"
        Me.identityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'identityLabel
        '
        Me.identityLabel.AutoSize = True
        Me.identityLabel.Location = New System.Drawing.Point(21, 31)
        Me.identityLabel.Name = "identityLabel"
        Me.identityLabel.Size = New System.Drawing.Size(51, 13)
        Me.identityLabel.TabIndex = 73
        Me.identityLabel.Text = "Identity"
        '
        'CoinNameLabel
        '
        Me.CoinNameLabel.AutoSize = True
        Me.CoinNameLabel.Location = New System.Drawing.Point(21, 78)
        Me.CoinNameLabel.Name = "CoinNameLabel"
        Me.CoinNameLabel.Size = New System.Drawing.Size(40, 13)
        Me.CoinNameLabel.TabIndex = 71
        Me.CoinNameLabel.Text = "Name"
        '
        'nameValue
        '
        Me.nameValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nameValue.Location = New System.Drawing.Point(25, 94)
        Me.nameValue.MaxLength = 150
        Me.nameValue.Name = "nameValue"
        Me.nameValue.Size = New System.Drawing.Size(426, 21)
        Me.nameValue.TabIndex = 1
        '
        'containerSelected
        '
        Me.containerSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.containerSelected.Controls.Add(Me.tabDetail)
        Me.containerSelected.Controls.Add(Me.uniqueChainKeyValue)
        Me.containerSelected.Controls.Add(Me.Label1)
        Me.containerSelected.Controls.Add(Me.cancelButton)
        Me.containerSelected.Controls.Add(Me.confirmButton)
        Me.containerSelected.Controls.Add(Me.identityValue)
        Me.containerSelected.Controls.Add(Me.identityLabel)
        Me.containerSelected.Controls.Add(Me.nameValue)
        Me.containerSelected.Controls.Add(Me.CoinNameLabel)
        Me.containerSelected.Location = New System.Drawing.Point(6, 3)
        Me.containerSelected.Name = "containerSelected"
        Me.containerSelected.Size = New System.Drawing.Size(872, 605)
        Me.containerSelected.TabIndex = 0
        '
        'tabDetail
        '
        Me.tabDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDetail.Controls.Add(Me.TabPage1)
        Me.tabDetail.Controls.Add(Me.TabPage4)
        Me.tabDetail.Controls.Add(Me.TabPage2)
        Me.tabDetail.Controls.Add(Me.TabPage3)
        Me.tabDetail.Location = New System.Drawing.Point(25, 139)
        Me.tabDetail.Name = "tabDetail"
        Me.tabDetail.SelectedIndex = 0
        Me.tabDetail.Size = New System.Drawing.Size(825, 396)
        Me.tabDetail.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.refundPlanValue)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.priceListValue)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.assetValue)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.typeValue)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(817, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'refundPlanValue
        '
        Me.refundPlanValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refundPlanValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.refundPlanValue.FormattingEnabled = True
        Me.refundPlanValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.refundPlanValue.Location = New System.Drawing.Point(58, 206)
        Me.refundPlanValue.Name = "refundPlanValue"
        Me.refundPlanValue.Size = New System.Drawing.Size(682, 21)
        Me.refundPlanValue.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(55, 189)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Refund Plan"
        '
        'priceListValue
        '
        Me.priceListValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceListValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.priceListValue.FormattingEnabled = True
        Me.priceListValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.priceListValue.Location = New System.Drawing.Point(58, 153)
        Me.priceListValue.Name = "priceListValue"
        Me.priceListValue.Size = New System.Drawing.Size(682, 21)
        Me.priceListValue.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(55, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Price List"
        '
        'assetValue
        '
        Me.assetValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.assetValue.FormattingEnabled = True
        Me.assetValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.assetValue.Location = New System.Drawing.Point(58, 100)
        Me.assetValue.Name = "assetValue"
        Me.assetValue.Size = New System.Drawing.Size(682, 21)
        Me.assetValue.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(55, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Asset"
        '
        'typeValue
        '
        Me.typeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.typeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typeValue.FormattingEnabled = True
        Me.typeValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.typeValue.Location = New System.Drawing.Point(58, 49)
        Me.typeValue.Name = "typeValue"
        Me.typeValue.Size = New System.Drawing.Size(682, 21)
        Me.typeValue.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Type"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.TermsAndConditionsPaperValue)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.privacyPaperValue)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.yellowPaperValue)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.whitePaperValue)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.visionPaperValue)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(817, 370)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Documents"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TermsAndConditionsPaperValue
        '
        Me.TermsAndConditionsPaperValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TermsAndConditionsPaperValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TermsAndConditionsPaperValue.FormattingEnabled = True
        Me.TermsAndConditionsPaperValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.TermsAndConditionsPaperValue.Location = New System.Drawing.Point(58, 260)
        Me.TermsAndConditionsPaperValue.Name = "TermsAndConditionsPaperValue"
        Me.TermsAndConditionsPaperValue.Size = New System.Drawing.Size(682, 21)
        Me.TermsAndConditionsPaperValue.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Terms and Conditions Paper"
        '
        'privacyPaperValue
        '
        Me.privacyPaperValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.privacyPaperValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.privacyPaperValue.FormattingEnabled = True
        Me.privacyPaperValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.privacyPaperValue.Location = New System.Drawing.Point(58, 206)
        Me.privacyPaperValue.Name = "privacyPaperValue"
        Me.privacyPaperValue.Size = New System.Drawing.Size(682, 21)
        Me.privacyPaperValue.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(55, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Privacy Paper"
        '
        'yellowPaperValue
        '
        Me.yellowPaperValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.yellowPaperValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.yellowPaperValue.FormattingEnabled = True
        Me.yellowPaperValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.yellowPaperValue.Location = New System.Drawing.Point(58, 153)
        Me.yellowPaperValue.Name = "yellowPaperValue"
        Me.yellowPaperValue.Size = New System.Drawing.Size(682, 21)
        Me.yellowPaperValue.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Yellow Paper"
        '
        'whitePaperValue
        '
        Me.whitePaperValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.whitePaperValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.whitePaperValue.FormattingEnabled = True
        Me.whitePaperValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.whitePaperValue.Location = New System.Drawing.Point(58, 100)
        Me.whitePaperValue.Name = "whitePaperValue"
        Me.whitePaperValue.Size = New System.Drawing.Size(682, 21)
        Me.whitePaperValue.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "White Paper"
        '
        'visionPaperValue
        '
        Me.visionPaperValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.visionPaperValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.visionPaperValue.FormattingEnabled = True
        Me.visionPaperValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.visionPaperValue.Location = New System.Drawing.Point(58, 49)
        Me.visionPaperValue.Name = "visionPaperValue"
        Me.visionPaperValue.Size = New System.Drawing.Size(682, 21)
        Me.visionPaperValue.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Vision Paper"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.confirmUpdateButton)
        Me.TabPage2.Controls.Add(Me.distributeValue)
        Me.TabPage2.Controls.Add(Me.distributeLabel)
        Me.TabPage2.Controls.Add(Me.addNewHeadBand)
        Me.TabPage2.Controls.Add(Me.untilAvailabilityValue)
        Me.TabPage2.Controls.Add(Me.untilAvailabilityLabel)
        Me.TabPage2.Controls.Add(Me.rewardDataGrid)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(817, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reward Plan"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'confirmUpdateButton
        '
        Me.confirmUpdateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmUpdateButton.Enabled = False
        Me.confirmUpdateButton.Location = New System.Drawing.Point(444, 337)
        Me.confirmUpdateButton.Name = "confirmUpdateButton"
        Me.confirmUpdateButton.Size = New System.Drawing.Size(109, 21)
        Me.confirmUpdateButton.TabIndex = 4
        Me.confirmUpdateButton.Text = "Confirm update"
        Me.confirmUpdateButton.UseVisualStyleBackColor = True
        '
        'distributeValue
        '
        Me.distributeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.distributeValue.Location = New System.Drawing.Point(282, 337)
        Me.distributeValue.MaxLength = 255
        Me.distributeValue.Name = "distributeValue"
        Me.distributeValue.ReadOnly = True
        Me.distributeValue.Size = New System.Drawing.Size(156, 21)
        Me.distributeValue.TabIndex = 3
        Me.distributeValue.Text = "0"
        Me.distributeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'distributeLabel
        '
        Me.distributeLabel.AutoSize = True
        Me.distributeLabel.Enabled = False
        Me.distributeLabel.Location = New System.Drawing.Point(279, 321)
        Me.distributeLabel.Name = "distributeLabel"
        Me.distributeLabel.Size = New System.Drawing.Size(62, 13)
        Me.distributeLabel.TabIndex = 88
        Me.distributeLabel.Text = "Distribute"
        '
        'addNewHeadBand
        '
        Me.addNewHeadBand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addNewHeadBand.Location = New System.Drawing.Point(691, 19)
        Me.addNewHeadBand.Name = "addNewHeadBand"
        Me.addNewHeadBand.Size = New System.Drawing.Size(120, 39)
        Me.addNewHeadBand.TabIndex = 1
        Me.addNewHeadBand.Text = "Add New Head Band"
        Me.addNewHeadBand.UseVisualStyleBackColor = True
        '
        'untilAvailabilityValue
        '
        Me.untilAvailabilityValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.untilAvailabilityValue.Location = New System.Drawing.Point(22, 337)
        Me.untilAvailabilityValue.MaxLength = 255
        Me.untilAvailabilityValue.Name = "untilAvailabilityValue"
        Me.untilAvailabilityValue.ReadOnly = True
        Me.untilAvailabilityValue.Size = New System.Drawing.Size(254, 21)
        Me.untilAvailabilityValue.TabIndex = 2
        Me.untilAvailabilityValue.Text = "0"
        Me.untilAvailabilityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'untilAvailabilityLabel
        '
        Me.untilAvailabilityLabel.AutoSize = True
        Me.untilAvailabilityLabel.Enabled = False
        Me.untilAvailabilityLabel.Location = New System.Drawing.Point(18, 321)
        Me.untilAvailabilityLabel.Name = "untilAvailabilityLabel"
        Me.untilAvailabilityLabel.Size = New System.Drawing.Size(98, 13)
        Me.untilAvailabilityLabel.TabIndex = 86
        Me.untilAvailabilityLabel.Text = "Until Availability"
        '
        'rewardDataGrid
        '
        Me.rewardDataGrid.AllowUserToAddRows = False
        Me.rewardDataGrid.AllowUserToDeleteRows = False
        Me.rewardDataGrid.AllowUserToResizeColumns = False
        Me.rewardDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rewardDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.rewardDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowIndexPrice, Me.untilAvailability, Me.distribute})
        Me.rewardDataGrid.Location = New System.Drawing.Point(21, 19)
        Me.rewardDataGrid.MultiSelect = False
        Me.rewardDataGrid.Name = "rewardDataGrid"
        Me.rewardDataGrid.ReadOnly = True
        Me.rewardDataGrid.RowHeadersVisible = False
        Me.rewardDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.rewardDataGrid.Size = New System.Drawing.Size(664, 299)
        Me.rewardDataGrid.TabIndex = 0
        '
        'rowIndexPrice
        '
        Me.rowIndexPrice.HeaderText = "Row Index"
        Me.rowIndexPrice.Name = "rowIndexPrice"
        Me.rowIndexPrice.ReadOnly = True
        Me.rowIndexPrice.Visible = False
        '
        'untilAvailability
        '
        Me.untilAvailability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.untilAvailability.HeaderText = "Until Availability"
        Me.untilAvailability.Name = "untilAvailability"
        Me.untilAvailability.ReadOnly = True
        '
        'distribute
        '
        Me.distribute.HeaderText = "Distribute"
        Me.distribute.Name = "distribute"
        Me.distribute.ReadOnly = True
        Me.distribute.Width = 200
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.walletAddressPremined)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.preminedCoin)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(817, 370)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Premined"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'walletAddressPremined
        '
        Me.walletAddressPremined.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.walletAddressPremined.Location = New System.Drawing.Point(58, 100)
        Me.walletAddressPremined.MaxLength = 150
        Me.walletAddressPremined.Name = "walletAddressPremined"
        Me.walletAddressPremined.Size = New System.Drawing.Size(690, 21)
        Me.walletAddressPremined.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(55, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 13)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Wallet address premined"
        '
        'preminedCoin
        '
        Me.preminedCoin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.preminedCoin.Location = New System.Drawing.Point(58, 49)
        Me.preminedCoin.MaxLength = 150
        Me.preminedCoin.Name = "preminedCoin"
        Me.preminedCoin.Size = New System.Drawing.Size(185, 21)
        Me.preminedCoin.TabIndex = 0
        Me.preminedCoin.Text = "0"
        Me.preminedCoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(55, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 13)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "Premined coin"
        '
        'uniqueChainKeyValue
        '
        Me.uniqueChainKeyValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uniqueChainKeyValue.Location = New System.Drawing.Point(457, 94)
        Me.uniqueChainKeyValue.MaxLength = 150
        Me.uniqueChainKeyValue.Name = "uniqueChainKeyValue"
        Me.uniqueChainKeyValue.Size = New System.Drawing.Size(393, 21)
        Me.uniqueChainKeyValue.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(453, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Unique Chain Key"
        '
        'selectedTabPage
        '
        Me.selectedTabPage.Controls.Add(Me.containerSelected)
        Me.selectedTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedTabPage.Location = New System.Drawing.Point(4, 22)
        Me.selectedTabPage.Name = "selectedTabPage"
        Me.selectedTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.selectedTabPage.Size = New System.Drawing.Size(884, 614)
        Me.selectedTabPage.TabIndex = 1
        Me.selectedTabPage.Text = "Selected"
        Me.selectedTabPage.UseVisualStyleBackColor = True
        '
        'idColumn
        '
        Me.idColumn.HeaderText = "ID"
        Me.idColumn.Name = "idColumn"
        Me.idColumn.ReadOnly = True
        Me.idColumn.Width = 500
        '
        'nameColumn
        '
        Me.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nameColumn.HeaderText = "Name"
        Me.nameColumn.Name = "nameColumn"
        Me.nameColumn.ReadOnly = True
        '
        'RowIndex
        '
        Me.RowIndex.HeaderText = "Row Index"
        Me.RowIndex.Name = "RowIndex"
        Me.RowIndex.ReadOnly = True
        Me.RowIndex.Visible = False
        '
        'createNewButton
        '
        Me.createNewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewButton.Location = New System.Drawing.Point(769, 6)
        Me.createNewButton.Name = "createNewButton"
        Me.createNewButton.Size = New System.Drawing.Size(109, 23)
        Me.createNewButton.TabIndex = 1
        Me.createNewButton.Text = "Add New"
        Me.createNewButton.UseVisualStyleBackColor = True
        '
        'refreshButton
        '
        Me.refreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshButton.Location = New System.Drawing.Point(654, 6)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(109, 23)
        Me.refreshButton.TabIndex = 0
        Me.refreshButton.Text = "Refresh"
        Me.refreshButton.UseVisualStyleBackColor = True
        '
        'dataGridView
        '
        Me.dataGridView.AllowUserToAddRows = False
        Me.dataGridView.AllowUserToDeleteRows = False
        Me.dataGridView.AllowUserToResizeColumns = False
        Me.dataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowIndex, Me.nameColumn, Me.idColumn})
        Me.dataGridView.Location = New System.Drawing.Point(6, 35)
        Me.dataGridView.MultiSelect = False
        Me.dataGridView.Name = "dataGridView"
        Me.dataGridView.ReadOnly = True
        Me.dataGridView.RowHeadersVisible = False
        Me.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView.Size = New System.Drawing.Size(872, 579)
        Me.dataGridView.TabIndex = 2
        '
        'listTabPage
        '
        Me.listTabPage.Controls.Add(Me.createNewButton)
        Me.listTabPage.Controls.Add(Me.refreshButton)
        Me.listTabPage.Controls.Add(Me.dataGridView)
        Me.listTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listTabPage.Location = New System.Drawing.Point(4, 22)
        Me.listTabPage.Name = "listTabPage"
        Me.listTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.listTabPage.Size = New System.Drawing.Size(884, 614)
        Me.listTabPage.TabIndex = 0
        Me.listTabPage.Text = "List"
        Me.listTabPage.UseVisualStyleBackColor = True
        '
        'mainTabControl
        '
        Me.mainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTabControl.Controls.Add(Me.listTabPage)
        Me.mainTabControl.Controls.Add(Me.selectedTabPage)
        Me.mainTabControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTabControl.Location = New System.Drawing.Point(10, 10)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(892, 640)
        Me.mainTabControl.TabIndex = 0
        '
        'SideChainConfigurationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 661)
        Me.Controls.Add(Me.mainTabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1244, 700)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "SideChainConfigurationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sidechain Contract"
        Me.containerSelected.ResumeLayout(False)
        Me.containerSelected.PerformLayout()
        Me.tabDetail.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.rewardDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.selectedTabPage.ResumeLayout(False)
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.listTabPage.ResumeLayout(False)
        Me.mainTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents CoinNameLabel As Label
    Friend WithEvents nameValue As TextBox
    Friend WithEvents containerSelected As Panel
    Friend WithEvents selectedTabPage As TabPage
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents RowIndex As DataGridViewTextBoxColumn
    Friend WithEvents createNewButton As Button
    Friend WithEvents refreshButton As Button
    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents listTabPage As TabPage
    Friend WithEvents mainTabControl As TabControl
    Friend WithEvents tabDetail As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents refundPlanValue As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents priceListValue As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents assetValue As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents typeValue As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TermsAndConditionsPaperValue As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents privacyPaperValue As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents yellowPaperValue As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents whitePaperValue As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents visionPaperValue As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents uniqueChainKeyValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents confirmUpdateButton As Button
    Friend WithEvents distributeValue As TextBox
    Friend WithEvents distributeLabel As Label
    Friend WithEvents addNewHeadBand As Button
    Friend WithEvents untilAvailabilityValue As TextBox
    Friend WithEvents untilAvailabilityLabel As Label
    Friend WithEvents rewardDataGrid As DataGridView
    Friend WithEvents rowIndexPrice As DataGridViewTextBoxColumn
    Friend WithEvents untilAvailability As DataGridViewTextBoxColumn
    Friend WithEvents distribute As DataGridViewTextBoxColumn
    Friend WithEvents walletAddressPremined As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents preminedCoin As TextBox
    Friend WithEvents Label12 As Label
End Class
