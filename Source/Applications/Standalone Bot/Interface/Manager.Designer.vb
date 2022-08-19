<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manager
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.PersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartMultipleBotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.walletPage = New System.Windows.Forms.TabPage()
        Me.earnValue = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.initialUSDTValue = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.totUSDTValue = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.totAccountValue = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.accountsGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valueColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.changeUSDT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valueUSDTColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.botPage = New System.Windows.Forms.TabPage()
        Me.numCloseBotsValue = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numOpenBotsValue = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.firstDateBotValue = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numActiveBotValue = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numBotValue = New System.Windows.Forms.Label()
        Me.numBotLabel = New System.Windows.Forms.Label()
        Me.botDataView = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.created = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pair = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.openOrdersColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.closeOrderButton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isActive = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.editBot = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.viewData = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.marketPage = New System.Windows.Forms.TabPage()
        Me.trendValue = New System.Windows.Forms.Label()
        Me.spreadValue = New System.Windows.Forms.Label()
        Me.spreadLabel = New System.Windows.Forms.Label()
        Me.lastValue = New System.Windows.Forms.TextBox()
        Me.lastLabel = New System.Windows.Forms.Label()
        Me.firstValue = New System.Windows.Forms.TextBox()
        Me.firstLabel = New System.Windows.Forms.Label()
        Me.mainChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lastUpdateValue = New System.Windows.Forms.TextBox()
        Me.lastUpdateLabel = New System.Windows.Forms.Label()
        Me.trendLabel = New System.Windows.Forms.Label()
        Me.averageRelativeValue = New System.Windows.Forms.TextBox()
        Me.averageRelativeLabel = New System.Windows.Forms.Label()
        Me.averageValue = New System.Windows.Forms.TextBox()
        Me.averageLabel = New System.Windows.Forms.Label()
        Me.maxValue = New System.Windows.Forms.TextBox()
        Me.maxLabel = New System.Windows.Forms.Label()
        Me.minValue = New System.Windows.Forms.TextBox()
        Me.minLabel = New System.Windows.Forms.Label()
        Me.pairValue = New System.Windows.Forms.TextBox()
        Me.pairLabel = New System.Windows.Forms.Label()
        Me.filterDetails = New System.Windows.Forms.ComboBox()
        Me.showDetails = New System.Windows.Forms.Label()
        Me.hourGridLabel = New System.Windows.Forms.Label()
        Me.tickValues = New System.Windows.Forms.DataGridView()
        Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marketDataView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.currentValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timerMain = New System.Windows.Forms.Timer(Me.components)
        Me.updateBotsTimer = New System.Windows.Forms.Timer(Me.components)
        Me.totalFeesValue = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.totalVolumesValue = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.menuMain.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.walletPage.SuspendLayout()
        CType(Me.accountsGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.botPage.SuspendLayout()
        CType(Me.botDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.marketPage.SuspendLayout()
        CType(Me.mainChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tickValues, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.marketDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonalToolStripMenuItem, Me.BotToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(888, 24)
        Me.menuMain.TabIndex = 1
        Me.menuMain.Text = "MenuStrip1"
        '
        'PersonalToolStripMenuItem
        '
        Me.PersonalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonalToolStripMenuItem1})
        Me.PersonalToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersonalToolStripMenuItem.Name = "PersonalToolStripMenuItem"
        Me.PersonalToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.PersonalToolStripMenuItem.Text = "&Data"
        '
        'PersonalToolStripMenuItem1
        '
        Me.PersonalToolStripMenuItem1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersonalToolStripMenuItem1.Name = "PersonalToolStripMenuItem1"
        Me.PersonalToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.PersonalToolStripMenuItem1.Text = "Personal"
        '
        'BotToolStripMenuItem
        '
        Me.BotToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.StartMultipleBotToolStripMenuItem})
        Me.BotToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotToolStripMenuItem.Name = "BotToolStripMenuItem"
        Me.BotToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.BotToolStripMenuItem.Text = "&Bot"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.AddNewToolStripMenuItem.Text = "Add new"
        '
        'StartMultipleBotToolStripMenuItem
        '
        Me.StartMultipleBotToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartMultipleBotToolStripMenuItem.Name = "StartMultipleBotToolStripMenuItem"
        Me.StartMultipleBotToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.StartMultipleBotToolStripMenuItem.Text = "Multiple Bot"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(26, 20)
        Me.ToolStripMenuItem1.Text = "&?"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.walletPage)
        Me.tabMain.Controls.Add(Me.botPage)
        Me.tabMain.Controls.Add(Me.marketPage)
        Me.tabMain.Location = New System.Drawing.Point(13, 28)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(863, 410)
        Me.tabMain.TabIndex = 2
        '
        'walletPage
        '
        Me.walletPage.Controls.Add(Me.totalFeesValue)
        Me.walletPage.Controls.Add(Me.Label10)
        Me.walletPage.Controls.Add(Me.totalVolumesValue)
        Me.walletPage.Controls.Add(Me.Label12)
        Me.walletPage.Controls.Add(Me.earnValue)
        Me.walletPage.Controls.Add(Me.Label9)
        Me.walletPage.Controls.Add(Me.initialUSDTValue)
        Me.walletPage.Controls.Add(Me.Label7)
        Me.walletPage.Controls.Add(Me.totUSDTValue)
        Me.walletPage.Controls.Add(Me.Label5)
        Me.walletPage.Controls.Add(Me.totAccountValue)
        Me.walletPage.Controls.Add(Me.Label8)
        Me.walletPage.Controls.Add(Me.accountsGridView)
        Me.walletPage.Location = New System.Drawing.Point(4, 22)
        Me.walletPage.Name = "walletPage"
        Me.walletPage.Size = New System.Drawing.Size(855, 384)
        Me.walletPage.TabIndex = 2
        Me.walletPage.Text = "Wallet"
        Me.walletPage.UseVisualStyleBackColor = True
        '
        'earnValue
        '
        Me.earnValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.earnValue.BackColor = System.Drawing.Color.LightGray
        Me.earnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.earnValue.Location = New System.Drawing.Point(458, 354)
        Me.earnValue.Name = "earnValue"
        Me.earnValue.Size = New System.Drawing.Size(148, 18)
        Me.earnValue.TabIndex = 19
        Me.earnValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(419, 357)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Earn"
        '
        'initialUSDTValue
        '
        Me.initialUSDTValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.initialUSDTValue.BackColor = System.Drawing.Color.LightGray
        Me.initialUSDTValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.initialUSDTValue.Location = New System.Drawing.Point(231, 354)
        Me.initialUSDTValue.Name = "initialUSDTValue"
        Me.initialUSDTValue.Size = New System.Drawing.Size(148, 18)
        Me.initialUSDTValue.TabIndex = 17
        Me.initialUSDTValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(152, 357)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Initial USDT"
        '
        'totUSDTValue
        '
        Me.totUSDTValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totUSDTValue.BackColor = System.Drawing.Color.LightGray
        Me.totUSDTValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totUSDTValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totUSDTValue.Location = New System.Drawing.Point(701, 354)
        Me.totUSDTValue.Name = "totUSDTValue"
        Me.totUSDTValue.Size = New System.Drawing.Size(148, 18)
        Me.totUSDTValue.TabIndex = 15
        Me.totUSDTValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(631, 357)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Tot. USDT"
        '
        'totAccountValue
        '
        Me.totAccountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totAccountValue.BackColor = System.Drawing.Color.LightGray
        Me.totAccountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totAccountValue.Location = New System.Drawing.Point(756, 327)
        Me.totAccountValue.Name = "totAccountValue"
        Me.totAccountValue.Size = New System.Drawing.Size(93, 18)
        Me.totAccountValue.TabIndex = 13
        Me.totAccountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(665, 330)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Num. account"
        '
        'accountsGridView
        '
        Me.accountsGridView.AllowUserToAddRows = False
        Me.accountsGridView.AllowUserToDeleteRows = False
        Me.accountsGridView.AllowUserToOrderColumns = True
        Me.accountsGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.accountsGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.accountsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.accountsGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.valueColumn, Me.changeUSDT, Me.valueUSDTColumn})
        Me.accountsGridView.Location = New System.Drawing.Point(3, 3)
        Me.accountsGridView.MultiSelect = False
        Me.accountsGridView.Name = "accountsGridView"
        Me.accountsGridView.RowHeadersVisible = False
        Me.accountsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.accountsGridView.Size = New System.Drawing.Size(849, 312)
        Me.accountsGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Account"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'valueColumn
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valueColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.valueColumn.HeaderText = "Amount"
        Me.valueColumn.Name = "valueColumn"
        Me.valueColumn.ReadOnly = True
        Me.valueColumn.Width = 150
        '
        'changeUSDT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.changeUSDT.DefaultCellStyle = DataGridViewCellStyle4
        Me.changeUSDT.HeaderText = "Change"
        Me.changeUSDT.Name = "changeUSDT"
        Me.changeUSDT.ReadOnly = True
        Me.changeUSDT.Width = 150
        '
        'valueUSDTColumn
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valueUSDTColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.valueUSDTColumn.HeaderText = "Value USDT"
        Me.valueUSDTColumn.Name = "valueUSDTColumn"
        Me.valueUSDTColumn.ReadOnly = True
        Me.valueUSDTColumn.Width = 150
        '
        'botPage
        '
        Me.botPage.Controls.Add(Me.numCloseBotsValue)
        Me.botPage.Controls.Add(Me.Label4)
        Me.botPage.Controls.Add(Me.numOpenBotsValue)
        Me.botPage.Controls.Add(Me.Label6)
        Me.botPage.Controls.Add(Me.firstDateBotValue)
        Me.botPage.Controls.Add(Me.Label3)
        Me.botPage.Controls.Add(Me.numActiveBotValue)
        Me.botPage.Controls.Add(Me.Label2)
        Me.botPage.Controls.Add(Me.numBotValue)
        Me.botPage.Controls.Add(Me.numBotLabel)
        Me.botPage.Controls.Add(Me.botDataView)
        Me.botPage.Location = New System.Drawing.Point(4, 22)
        Me.botPage.Name = "botPage"
        Me.botPage.Padding = New System.Windows.Forms.Padding(3)
        Me.botPage.Size = New System.Drawing.Size(855, 384)
        Me.botPage.TabIndex = 0
        Me.botPage.Text = "Bots"
        Me.botPage.UseVisualStyleBackColor = True
        '
        'numCloseBotsValue
        '
        Me.numCloseBotsValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numCloseBotsValue.BackColor = System.Drawing.Color.LightGray
        Me.numCloseBotsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numCloseBotsValue.Location = New System.Drawing.Point(756, 354)
        Me.numCloseBotsValue.Name = "numCloseBotsValue"
        Me.numCloseBotsValue.Size = New System.Drawing.Size(93, 18)
        Me.numCloseBotsValue.TabIndex = 11
        Me.numCloseBotsValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(645, 355)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Num Close Orders"
        '
        'numOpenBotsValue
        '
        Me.numOpenBotsValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numOpenBotsValue.BackColor = System.Drawing.Color.LightGray
        Me.numOpenBotsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numOpenBotsValue.Location = New System.Drawing.Point(756, 327)
        Me.numOpenBotsValue.Name = "numOpenBotsValue"
        Me.numOpenBotsValue.Size = New System.Drawing.Size(93, 18)
        Me.numOpenBotsValue.TabIndex = 9
        Me.numOpenBotsValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(645, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Num Open Orders"
        '
        'firstDateBotValue
        '
        Me.firstDateBotValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.firstDateBotValue.BackColor = System.Drawing.Color.LightGray
        Me.firstDateBotValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.firstDateBotValue.Location = New System.Drawing.Point(481, 328)
        Me.firstDateBotValue.Name = "firstDateBotValue"
        Me.firstDateBotValue.Size = New System.Drawing.Size(158, 18)
        Me.firstDateBotValue.TabIndex = 7
        Me.firstDateBotValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(422, 331)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "First bot"
        '
        'numActiveBotValue
        '
        Me.numActiveBotValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numActiveBotValue.BackColor = System.Drawing.Color.LightGray
        Me.numActiveBotValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numActiveBotValue.Location = New System.Drawing.Point(312, 354)
        Me.numActiveBotValue.Name = "numActiveBotValue"
        Me.numActiveBotValue.Size = New System.Drawing.Size(93, 18)
        Me.numActiveBotValue.TabIndex = 5
        Me.numActiveBotValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 355)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Num active bots"
        '
        'numBotValue
        '
        Me.numBotValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numBotValue.BackColor = System.Drawing.Color.LightGray
        Me.numBotValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numBotValue.Location = New System.Drawing.Point(312, 327)
        Me.numBotValue.Name = "numBotValue"
        Me.numBotValue.Size = New System.Drawing.Size(93, 18)
        Me.numBotValue.TabIndex = 3
        Me.numBotValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numBotLabel
        '
        Me.numBotLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numBotLabel.AutoSize = True
        Me.numBotLabel.Location = New System.Drawing.Point(250, 328)
        Me.numBotLabel.Name = "numBotLabel"
        Me.numBotLabel.Size = New System.Drawing.Size(61, 13)
        Me.numBotLabel.TabIndex = 2
        Me.numBotLabel.Text = "Num bots"
        '
        'botDataView
        '
        Me.botDataView.AllowUserToAddRows = False
        Me.botDataView.AllowUserToDeleteRows = False
        Me.botDataView.AllowUserToOrderColumns = True
        Me.botDataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.botDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.botDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.botDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.created, Me.pair, Me.openOrdersColumn, Me.closeOrderButton, Me.isActive, Me.editBot, Me.viewData})
        Me.botDataView.Location = New System.Drawing.Point(3, 3)
        Me.botDataView.MultiSelect = False
        Me.botDataView.Name = "botDataView"
        Me.botDataView.RowHeadersVisible = False
        Me.botDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.botDataView.Size = New System.Drawing.Size(849, 312)
        Me.botDataView.TabIndex = 1
        '
        'id
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.DefaultCellStyle = DataGridViewCellStyle7
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 250
        '
        'created
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.created.DefaultCellStyle = DataGridViewCellStyle8
        Me.created.HeaderText = "Created"
        Me.created.Name = "created"
        Me.created.ReadOnly = True
        Me.created.Width = 150
        '
        'pair
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Wheat
        Me.pair.DefaultCellStyle = DataGridViewCellStyle9
        Me.pair.HeaderText = "Pair"
        Me.pair.Name = "pair"
        Me.pair.ReadOnly = True
        '
        'openOrdersColumn
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray
        Me.openOrdersColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.openOrdersColumn.HeaderText = "Open"
        Me.openOrdersColumn.Name = "openOrdersColumn"
        Me.openOrdersColumn.ReadOnly = True
        Me.openOrdersColumn.Width = 75
        '
        'closeOrderButton
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGray
        Me.closeOrderButton.DefaultCellStyle = DataGridViewCellStyle11
        Me.closeOrderButton.HeaderText = "Close"
        Me.closeOrderButton.Name = "closeOrderButton"
        Me.closeOrderButton.ReadOnly = True
        Me.closeOrderButton.Width = 75
        '
        'isActive
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.isActive.DefaultCellStyle = DataGridViewCellStyle12
        Me.isActive.HeaderText = "Command"
        Me.isActive.Name = "isActive"
        Me.isActive.ReadOnly = True
        Me.isActive.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.isActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.isActive.Text = "ACTIVE"
        Me.isActive.Width = 70
        '
        'editBot
        '
        Me.editBot.HeaderText = "Edit"
        Me.editBot.Name = "editBot"
        Me.editBot.Text = "..."
        Me.editBot.UseColumnTextForButtonValue = True
        Me.editBot.Width = 50
        '
        'viewData
        '
        Me.viewData.HeaderText = "Data"
        Me.viewData.Name = "viewData"
        Me.viewData.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.viewData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.viewData.Text = "..."
        Me.viewData.UseColumnTextForButtonValue = True
        Me.viewData.Width = 50
        '
        'marketPage
        '
        Me.marketPage.Controls.Add(Me.trendValue)
        Me.marketPage.Controls.Add(Me.spreadValue)
        Me.marketPage.Controls.Add(Me.spreadLabel)
        Me.marketPage.Controls.Add(Me.lastValue)
        Me.marketPage.Controls.Add(Me.lastLabel)
        Me.marketPage.Controls.Add(Me.firstValue)
        Me.marketPage.Controls.Add(Me.firstLabel)
        Me.marketPage.Controls.Add(Me.mainChart)
        Me.marketPage.Controls.Add(Me.lastUpdateValue)
        Me.marketPage.Controls.Add(Me.lastUpdateLabel)
        Me.marketPage.Controls.Add(Me.trendLabel)
        Me.marketPage.Controls.Add(Me.averageRelativeValue)
        Me.marketPage.Controls.Add(Me.averageRelativeLabel)
        Me.marketPage.Controls.Add(Me.averageValue)
        Me.marketPage.Controls.Add(Me.averageLabel)
        Me.marketPage.Controls.Add(Me.maxValue)
        Me.marketPage.Controls.Add(Me.maxLabel)
        Me.marketPage.Controls.Add(Me.minValue)
        Me.marketPage.Controls.Add(Me.minLabel)
        Me.marketPage.Controls.Add(Me.pairValue)
        Me.marketPage.Controls.Add(Me.pairLabel)
        Me.marketPage.Controls.Add(Me.filterDetails)
        Me.marketPage.Controls.Add(Me.showDetails)
        Me.marketPage.Controls.Add(Me.hourGridLabel)
        Me.marketPage.Controls.Add(Me.tickValues)
        Me.marketPage.Controls.Add(Me.marketDataView)
        Me.marketPage.Location = New System.Drawing.Point(4, 22)
        Me.marketPage.Name = "marketPage"
        Me.marketPage.Padding = New System.Windows.Forms.Padding(3)
        Me.marketPage.Size = New System.Drawing.Size(855, 384)
        Me.marketPage.TabIndex = 1
        Me.marketPage.Text = "Markets"
        Me.marketPage.UseVisualStyleBackColor = True
        '
        'trendValue
        '
        Me.trendValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trendValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.trendValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trendValue.Location = New System.Drawing.Point(697, 249)
        Me.trendValue.Name = "trendValue"
        Me.trendValue.Size = New System.Drawing.Size(149, 21)
        Me.trendValue.TabIndex = 35
        Me.trendValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'spreadValue
        '
        Me.spreadValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spreadValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.spreadValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spreadValue.Location = New System.Drawing.Point(697, 222)
        Me.spreadValue.Name = "spreadValue"
        Me.spreadValue.Size = New System.Drawing.Size(149, 21)
        Me.spreadValue.TabIndex = 34
        Me.spreadValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'spreadLabel
        '
        Me.spreadLabel.AutoSize = True
        Me.spreadLabel.Location = New System.Drawing.Point(643, 226)
        Me.spreadLabel.Name = "spreadLabel"
        Me.spreadLabel.Size = New System.Drawing.Size(48, 13)
        Me.spreadLabel.TabIndex = 33
        Me.spreadLabel.Text = "Spread"
        '
        'lastValue
        '
        Me.lastValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lastValue.Location = New System.Drawing.Point(697, 196)
        Me.lastValue.Name = "lastValue"
        Me.lastValue.ReadOnly = True
        Me.lastValue.Size = New System.Drawing.Size(149, 21)
        Me.lastValue.TabIndex = 32
        Me.lastValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lastLabel
        '
        Me.lastLabel.AutoSize = True
        Me.lastLabel.Location = New System.Drawing.Point(626, 199)
        Me.lastLabel.Name = "lastLabel"
        Me.lastLabel.Size = New System.Drawing.Size(65, 13)
        Me.lastLabel.TabIndex = 31
        Me.lastLabel.Text = "Last value"
        '
        'firstValue
        '
        Me.firstValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.firstValue.Location = New System.Drawing.Point(697, 169)
        Me.firstValue.Name = "firstValue"
        Me.firstValue.ReadOnly = True
        Me.firstValue.Size = New System.Drawing.Size(149, 21)
        Me.firstValue.TabIndex = 30
        Me.firstValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'firstLabel
        '
        Me.firstLabel.AutoSize = True
        Me.firstLabel.Location = New System.Drawing.Point(626, 172)
        Me.firstLabel.Name = "firstLabel"
        Me.firstLabel.Size = New System.Drawing.Size(66, 13)
        Me.firstLabel.TabIndex = 29
        Me.firstLabel.Text = "First value"
        '
        'mainChart
        '
        Me.mainChart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainChart.BackColor = System.Drawing.Color.LightSteelBlue
        ChartArea1.Name = "ChartArea1"
        Me.mainChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.mainChart.Legends.Add(Legend1)
        Me.mainChart.Location = New System.Drawing.Point(563, 304)
        Me.mainChart.Name = "mainChart"
        Me.mainChart.Size = New System.Drawing.Size(283, 77)
        Me.mainChart.TabIndex = 28
        Me.mainChart.Text = "Chart"
        '
        'lastUpdateValue
        '
        Me.lastUpdateValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lastUpdateValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastUpdateValue.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lastUpdateValue.Location = New System.Drawing.Point(697, 277)
        Me.lastUpdateValue.Name = "lastUpdateValue"
        Me.lastUpdateValue.ReadOnly = True
        Me.lastUpdateValue.Size = New System.Drawing.Size(149, 21)
        Me.lastUpdateValue.TabIndex = 27
        Me.lastUpdateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lastUpdateLabel
        '
        Me.lastUpdateLabel.AutoSize = True
        Me.lastUpdateLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastUpdateLabel.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lastUpdateLabel.Location = New System.Drawing.Point(619, 280)
        Me.lastUpdateLabel.Name = "lastUpdateLabel"
        Me.lastUpdateLabel.Size = New System.Drawing.Size(73, 13)
        Me.lastUpdateLabel.TabIndex = 26
        Me.lastUpdateLabel.Text = "Last update"
        '
        'trendLabel
        '
        Me.trendLabel.AutoSize = True
        Me.trendLabel.Location = New System.Drawing.Point(652, 253)
        Me.trendLabel.Name = "trendLabel"
        Me.trendLabel.Size = New System.Drawing.Size(39, 13)
        Me.trendLabel.TabIndex = 24
        Me.trendLabel.Text = "Trend"
        '
        'averageRelativeValue
        '
        Me.averageRelativeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.averageRelativeValue.Location = New System.Drawing.Point(697, 115)
        Me.averageRelativeValue.Name = "averageRelativeValue"
        Me.averageRelativeValue.ReadOnly = True
        Me.averageRelativeValue.Size = New System.Drawing.Size(149, 21)
        Me.averageRelativeValue.TabIndex = 23
        Me.averageRelativeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'averageRelativeLabel
        '
        Me.averageRelativeLabel.AutoSize = True
        Me.averageRelativeLabel.Location = New System.Drawing.Point(590, 118)
        Me.averageRelativeLabel.Name = "averageRelativeLabel"
        Me.averageRelativeLabel.Size = New System.Drawing.Size(102, 13)
        Me.averageRelativeLabel.TabIndex = 22
        Me.averageRelativeLabel.Text = "Average relative"
        '
        'averageValue
        '
        Me.averageValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.averageValue.Location = New System.Drawing.Point(697, 88)
        Me.averageValue.Name = "averageValue"
        Me.averageValue.ReadOnly = True
        Me.averageValue.Size = New System.Drawing.Size(149, 21)
        Me.averageValue.TabIndex = 21
        Me.averageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'averageLabel
        '
        Me.averageLabel.AutoSize = True
        Me.averageLabel.Location = New System.Drawing.Point(637, 91)
        Me.averageLabel.Name = "averageLabel"
        Me.averageLabel.Size = New System.Drawing.Size(55, 13)
        Me.averageLabel.TabIndex = 20
        Me.averageLabel.Text = "Average"
        '
        'maxValue
        '
        Me.maxValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxValue.Location = New System.Drawing.Point(697, 142)
        Me.maxValue.Name = "maxValue"
        Me.maxValue.ReadOnly = True
        Me.maxValue.Size = New System.Drawing.Size(149, 21)
        Me.maxValue.TabIndex = 19
        Me.maxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'maxLabel
        '
        Me.maxLabel.AutoSize = True
        Me.maxLabel.Location = New System.Drawing.Point(661, 145)
        Me.maxLabel.Name = "maxLabel"
        Me.maxLabel.Size = New System.Drawing.Size(30, 13)
        Me.maxLabel.TabIndex = 18
        Me.maxLabel.Text = "Max"
        '
        'minValue
        '
        Me.minValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minValue.Location = New System.Drawing.Point(697, 61)
        Me.minValue.Name = "minValue"
        Me.minValue.ReadOnly = True
        Me.minValue.Size = New System.Drawing.Size(149, 21)
        Me.minValue.TabIndex = 17
        Me.minValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'minLabel
        '
        Me.minLabel.AutoSize = True
        Me.minLabel.Location = New System.Drawing.Point(665, 64)
        Me.minLabel.Name = "minLabel"
        Me.minLabel.Size = New System.Drawing.Size(26, 13)
        Me.minLabel.TabIndex = 16
        Me.minLabel.Text = "Min"
        '
        'pairValue
        '
        Me.pairValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pairValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pairValue.Location = New System.Drawing.Point(697, 34)
        Me.pairValue.Name = "pairValue"
        Me.pairValue.ReadOnly = True
        Me.pairValue.Size = New System.Drawing.Size(149, 21)
        Me.pairValue.TabIndex = 15
        Me.pairValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pairLabel
        '
        Me.pairLabel.AutoSize = True
        Me.pairLabel.Location = New System.Drawing.Point(662, 37)
        Me.pairLabel.Name = "pairLabel"
        Me.pairLabel.Size = New System.Drawing.Size(29, 13)
        Me.pairLabel.TabIndex = 14
        Me.pairLabel.Text = "Pair"
        '
        'filterDetails
        '
        Me.filterDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.filterDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filterDetails.FormattingEnabled = True
        Me.filterDetails.Items.AddRange(New Object() {"Last hour", "Last day", "Last week", "Last month", "Last year"})
        Me.filterDetails.Location = New System.Drawing.Point(680, 7)
        Me.filterDetails.Name = "filterDetails"
        Me.filterDetails.Size = New System.Drawing.Size(166, 21)
        Me.filterDetails.TabIndex = 6
        '
        'showDetails
        '
        Me.showDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.showDetails.AutoSize = True
        Me.showDetails.Location = New System.Drawing.Point(595, 10)
        Me.showDetails.Name = "showDetails"
        Me.showDetails.Size = New System.Drawing.Size(79, 13)
        Me.showDetails.TabIndex = 5
        Me.showDetails.Text = "Show details"
        '
        'hourGridLabel
        '
        Me.hourGridLabel.AutoSize = True
        Me.hourGridLabel.Location = New System.Drawing.Point(283, 10)
        Me.hourGridLabel.Name = "hourGridLabel"
        Me.hourGridLabel.Size = New System.Drawing.Size(90, 13)
        Me.hourGridLabel.TabIndex = 4
        Me.hourGridLabel.Text = "Last hour ticks"
        '
        'tickValues
        '
        Me.tickValues.AllowUserToAddRows = False
        Me.tickValues.AllowUserToDeleteRows = False
        Me.tickValues.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tickValues.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.tickValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tickValues.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.time, Me.value})
        Me.tickValues.Location = New System.Drawing.Point(283, 31)
        Me.tickValues.MultiSelect = False
        Me.tickValues.Name = "tickValues"
        Me.tickValues.RowHeadersVisible = False
        Me.tickValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tickValues.Size = New System.Drawing.Size(274, 350)
        Me.tickValues.TabIndex = 3
        '
        'time
        '
        Me.time.HeaderText = "Time"
        Me.time.Name = "time"
        Me.time.ReadOnly = True
        Me.time.Width = 150
        '
        'value
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.value.DefaultCellStyle = DataGridViewCellStyle14
        Me.value.HeaderText = "Value"
        Me.value.Name = "value"
        Me.value.ReadOnly = True
        '
        'marketDataView
        '
        Me.marketDataView.AllowUserToAddRows = False
        Me.marketDataView.AllowUserToDeleteRows = False
        Me.marketDataView.AllowUserToOrderColumns = True
        Me.marketDataView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.marketDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.marketDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.marketDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.currentValue})
        Me.marketDataView.Location = New System.Drawing.Point(3, 3)
        Me.marketDataView.MultiSelect = False
        Me.marketDataView.Name = "marketDataView"
        Me.marketDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.marketDataView.Size = New System.Drawing.Size(274, 378)
        Me.marketDataView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Pair"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'currentValue
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.currentValue.DefaultCellStyle = DataGridViewCellStyle16
        Me.currentValue.HeaderText = "Current value"
        Me.currentValue.Name = "currentValue"
        Me.currentValue.ReadOnly = True
        '
        'timerMain
        '
        Me.timerMain.Interval = 30000
        '
        'updateBotsTimer
        '
        Me.updateBotsTimer.Enabled = True
        Me.updateBotsTimer.Interval = 1000
        '
        'totalFeesValue
        '
        Me.totalFeesValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalFeesValue.BackColor = System.Drawing.Color.LightGray
        Me.totalFeesValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totalFeesValue.Location = New System.Drawing.Point(458, 327)
        Me.totalFeesValue.Name = "totalFeesValue"
        Me.totalFeesValue.Size = New System.Drawing.Size(148, 18)
        Me.totalFeesValue.TabIndex = 23
        Me.totalFeesValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(390, 330)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Total fees"
        '
        'totalVolumesValue
        '
        Me.totalVolumesValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalVolumesValue.BackColor = System.Drawing.Color.LightGray
        Me.totalVolumesValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totalVolumesValue.Location = New System.Drawing.Point(231, 327)
        Me.totalVolumesValue.Name = "totalVolumesValue"
        Me.totalVolumesValue.Size = New System.Drawing.Size(148, 18)
        Me.totalVolumesValue.TabIndex = 21
        Me.totalVolumesValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(141, 330)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Total volumes"
        '
        'Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 450)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.menuMain)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuMain
        Me.Name = "Manager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Standard Bot"
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.walletPage.ResumeLayout(False)
        Me.walletPage.PerformLayout()
        CType(Me.accountsGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.botPage.ResumeLayout(False)
        Me.botPage.PerformLayout()
        CType(Me.botDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.marketPage.ResumeLayout(False)
        Me.marketPage.PerformLayout()
        CType(Me.mainChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tickValues, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.marketDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuMain As MenuStrip
    Friend WithEvents BotToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddNewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tabMain As TabControl
    Friend WithEvents botPage As TabPage
    Friend WithEvents botDataView As DataGridView
    Friend WithEvents marketPage As TabPage
    Friend WithEvents walletPage As TabPage
#Disable Warning BC40004 ' Il membro è in conflitto con il membro nel tipo di base, quindi deve essere dichiarato come 'Shadows'
#Enable Warning BC40004 ' Il membro è in conflitto con il membro nel tipo di base, quindi deve essere dichiarato come 'Shadows'
    Friend WithEvents marketDataView As DataGridView
    Friend WithEvents tickValues As DataGridView
    Friend WithEvents filterDetails As ComboBox
    Friend WithEvents showDetails As Label
    Friend WithEvents hourGridLabel As Label
    Friend WithEvents timerMain As Timer
    Friend WithEvents pairValue As TextBox
    Friend WithEvents pairLabel As Label
    Friend WithEvents minValue As TextBox
    Friend WithEvents minLabel As Label
    Friend WithEvents maxValue As TextBox
    Friend WithEvents maxLabel As Label
    Friend WithEvents averageValue As TextBox
    Friend WithEvents averageLabel As Label
    Friend WithEvents averageRelativeValue As TextBox
    Friend WithEvents averageRelativeLabel As Label
    Friend WithEvents trendLabel As Label
    Friend WithEvents lastUpdateValue As TextBox
    Friend WithEvents lastUpdateLabel As Label
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents currentValue As DataGridViewTextBoxColumn
    Friend WithEvents mainChart As DataVisualization.Charting.Chart
    Friend WithEvents spreadLabel As Label
    Friend WithEvents lastValue As TextBox
    Friend WithEvents lastLabel As Label
    Friend WithEvents firstValue As TextBox
    Friend WithEvents firstLabel As Label
    Friend WithEvents spreadValue As Label
    Friend WithEvents trendValue As Label
    Friend WithEvents time As DataGridViewTextBoxColumn
    Friend WithEvents value As DataGridViewTextBoxColumn
    Friend WithEvents updateBotsTimer As Timer
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartMultipleBotToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents accountsGridView As DataGridView
    Friend WithEvents numCloseBotsValue As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents numOpenBotsValue As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents firstDateBotValue As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents numActiveBotValue As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents numBotValue As Label
    Friend WithEvents numBotLabel As Label
    Friend WithEvents totUSDTValue As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents totAccountValue As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents initialUSDTValue As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents earnValue As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents valueColumn As DataGridViewTextBoxColumn
    Friend WithEvents changeUSDT As DataGridViewTextBoxColumn
    Friend WithEvents valueUSDTColumn As DataGridViewTextBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents created As DataGridViewTextBoxColumn
    Friend WithEvents pair As DataGridViewTextBoxColumn
    Friend WithEvents openOrdersColumn As DataGridViewTextBoxColumn
    Friend WithEvents closeOrderButton As DataGridViewTextBoxColumn
    Friend WithEvents isActive As DataGridViewButtonColumn
    Friend WithEvents editBot As DataGridViewButtonColumn
    Friend WithEvents viewData As DataGridViewButtonColumn
    Friend WithEvents PersonalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PersonalToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents totalFeesValue As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents totalVolumesValue As Label
    Friend WithEvents Label12 As Label
End Class
