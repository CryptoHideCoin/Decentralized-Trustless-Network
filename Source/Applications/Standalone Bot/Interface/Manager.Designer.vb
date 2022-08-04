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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        Me.menuMain = New System.Windows.Forms.MenuStrip()
        Me.BotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.InformationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.botPage = New System.Windows.Forms.TabPage()
        Me.botDataView = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.created = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pair = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isActive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marketPage = New System.Windows.Forms.TabPage()
        Me.mainChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lastUpdateValue = New System.Windows.Forms.TextBox()
        Me.lastUpdateLabel = New System.Windows.Forms.Label()
        Me.trendValue = New System.Windows.Forms.TextBox()
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
        Me.walletPage = New System.Windows.Forms.TabPage()
        Me.timerMain = New System.Windows.Forms.Timer(Me.components)
        Me.menuMain.SuspendLayout()
        Me.tabMain.SuspendLayout()
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
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BotToolStripMenuItem})
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(888, 24)
        Me.menuMain.TabIndex = 1
        Me.menuMain.Text = "MenuStrip1"
        '
        'BotToolStripMenuItem
        '
        Me.BotToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.ToolStripSeparator2, Me.InformationsToolStripMenuItem, Me.ToolStripSeparator1, Me.StartToolStripMenuItem, Me.StopToolStripMenuItem})
        Me.BotToolStripMenuItem.Name = "BotToolStripMenuItem"
        Me.BotToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.BotToolStripMenuItem.Text = "&Bots"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.AddNewToolStripMenuItem.Text = "Add new"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(139, 6)
        '
        'InformationsToolStripMenuItem
        '
        Me.InformationsToolStripMenuItem.Name = "InformationsToolStripMenuItem"
        Me.InformationsToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.InformationsToolStripMenuItem.Text = "Informations"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(139, 6)
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'tabMain
        '
        Me.tabMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMain.Controls.Add(Me.botPage)
        Me.tabMain.Controls.Add(Me.marketPage)
        Me.tabMain.Controls.Add(Me.walletPage)
        Me.tabMain.Location = New System.Drawing.Point(13, 28)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(863, 410)
        Me.tabMain.TabIndex = 2
        '
        'botPage
        '
        Me.botPage.Controls.Add(Me.botDataView)
        Me.botPage.Location = New System.Drawing.Point(4, 22)
        Me.botPage.Name = "botPage"
        Me.botPage.Padding = New System.Windows.Forms.Padding(3)
        Me.botPage.Size = New System.Drawing.Size(855, 384)
        Me.botPage.TabIndex = 0
        Me.botPage.Text = "Bots"
        Me.botPage.UseVisualStyleBackColor = True
        '
        'botDataView
        '
        Me.botDataView.AllowUserToAddRows = False
        Me.botDataView.AllowUserToDeleteRows = False
        Me.botDataView.AllowUserToOrderColumns = True
        Me.botDataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.botDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.botDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.botDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.created, Me.pair, Me.isActive})
        Me.botDataView.Location = New System.Drawing.Point(3, 3)
        Me.botDataView.MultiSelect = False
        Me.botDataView.Name = "botDataView"
        Me.botDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.botDataView.Size = New System.Drawing.Size(849, 378)
        Me.botDataView.TabIndex = 1
        '
        'id
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.id.DefaultCellStyle = DataGridViewCellStyle2
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 300
        '
        'created
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.created.DefaultCellStyle = DataGridViewCellStyle3
        Me.created.HeaderText = "Created"
        Me.created.Name = "created"
        Me.created.ReadOnly = True
        Me.created.Width = 200
        '
        'pair
        '
        Me.pair.HeaderText = "Pair"
        Me.pair.Name = "pair"
        Me.pair.ReadOnly = True
        '
        'isActive
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.isActive.DefaultCellStyle = DataGridViewCellStyle4
        Me.isActive.HeaderText = "Is Active"
        Me.isActive.Name = "isActive"
        Me.isActive.ReadOnly = True
        '
        'marketPage
        '
        Me.marketPage.Controls.Add(Me.mainChart)
        Me.marketPage.Controls.Add(Me.lastUpdateValue)
        Me.marketPage.Controls.Add(Me.lastUpdateLabel)
        Me.marketPage.Controls.Add(Me.trendValue)
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
        Me.mainChart.Location = New System.Drawing.Point(563, 265)
        Me.mainChart.Name = "mainChart"
        Me.mainChart.Size = New System.Drawing.Size(283, 116)
        Me.mainChart.TabIndex = 28
        Me.mainChart.Text = "Chart"
        '
        'lastUpdateValue
        '
        Me.lastUpdateValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lastUpdateValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastUpdateValue.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lastUpdateValue.Location = New System.Drawing.Point(697, 233)
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
        Me.lastUpdateLabel.Location = New System.Drawing.Point(619, 236)
        Me.lastUpdateLabel.Name = "lastUpdateLabel"
        Me.lastUpdateLabel.Size = New System.Drawing.Size(73, 13)
        Me.lastUpdateLabel.TabIndex = 26
        Me.lastUpdateLabel.Text = "Last update"
        '
        'trendValue
        '
        Me.trendValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trendValue.Location = New System.Drawing.Point(697, 206)
        Me.trendValue.Name = "trendValue"
        Me.trendValue.ReadOnly = True
        Me.trendValue.Size = New System.Drawing.Size(149, 21)
        Me.trendValue.TabIndex = 25
        Me.trendValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'trendLabel
        '
        Me.trendLabel.AutoSize = True
        Me.trendLabel.Location = New System.Drawing.Point(652, 209)
        Me.trendLabel.Name = "trendLabel"
        Me.trendLabel.Size = New System.Drawing.Size(39, 13)
        Me.trendLabel.TabIndex = 24
        Me.trendLabel.Text = "Trend"
        '
        'averageRelativeValue
        '
        Me.averageRelativeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.averageRelativeValue.Location = New System.Drawing.Point(697, 179)
        Me.averageRelativeValue.Name = "averageRelativeValue"
        Me.averageRelativeValue.ReadOnly = True
        Me.averageRelativeValue.Size = New System.Drawing.Size(149, 21)
        Me.averageRelativeValue.TabIndex = 23
        Me.averageRelativeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'averageRelativeLabel
        '
        Me.averageRelativeLabel.AutoSize = True
        Me.averageRelativeLabel.Location = New System.Drawing.Point(590, 182)
        Me.averageRelativeLabel.Name = "averageRelativeLabel"
        Me.averageRelativeLabel.Size = New System.Drawing.Size(102, 13)
        Me.averageRelativeLabel.TabIndex = 22
        Me.averageRelativeLabel.Text = "Average relative"
        '
        'averageValue
        '
        Me.averageValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.averageValue.Location = New System.Drawing.Point(697, 152)
        Me.averageValue.Name = "averageValue"
        Me.averageValue.ReadOnly = True
        Me.averageValue.Size = New System.Drawing.Size(149, 21)
        Me.averageValue.TabIndex = 21
        Me.averageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'averageLabel
        '
        Me.averageLabel.AutoSize = True
        Me.averageLabel.Location = New System.Drawing.Point(637, 155)
        Me.averageLabel.Name = "averageLabel"
        Me.averageLabel.Size = New System.Drawing.Size(55, 13)
        Me.averageLabel.TabIndex = 20
        Me.averageLabel.Text = "Average"
        '
        'maxValue
        '
        Me.maxValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxValue.Location = New System.Drawing.Point(697, 125)
        Me.maxValue.Name = "maxValue"
        Me.maxValue.ReadOnly = True
        Me.maxValue.Size = New System.Drawing.Size(149, 21)
        Me.maxValue.TabIndex = 19
        Me.maxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'maxLabel
        '
        Me.maxLabel.AutoSize = True
        Me.maxLabel.Location = New System.Drawing.Point(661, 128)
        Me.maxLabel.Name = "maxLabel"
        Me.maxLabel.Size = New System.Drawing.Size(30, 13)
        Me.maxLabel.TabIndex = 18
        Me.maxLabel.Text = "Max"
        '
        'minValue
        '
        Me.minValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minValue.Location = New System.Drawing.Point(697, 98)
        Me.minValue.Name = "minValue"
        Me.minValue.ReadOnly = True
        Me.minValue.Size = New System.Drawing.Size(149, 21)
        Me.minValue.TabIndex = 17
        Me.minValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'minLabel
        '
        Me.minLabel.AutoSize = True
        Me.minLabel.Location = New System.Drawing.Point(665, 101)
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
        Me.pairValue.Location = New System.Drawing.Point(697, 71)
        Me.pairValue.Name = "pairValue"
        Me.pairValue.ReadOnly = True
        Me.pairValue.Size = New System.Drawing.Size(149, 21)
        Me.pairValue.TabIndex = 15
        Me.pairValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pairLabel
        '
        Me.pairLabel.AutoSize = True
        Me.pairLabel.Location = New System.Drawing.Point(662, 74)
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
        Me.tickValues.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tickValues.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.value.DefaultCellStyle = DataGridViewCellStyle6
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.marketDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
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
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.currentValue.DefaultCellStyle = DataGridViewCellStyle8
        Me.currentValue.HeaderText = "Current value"
        Me.currentValue.Name = "currentValue"
        Me.currentValue.ReadOnly = True
        '
        'walletPage
        '
        Me.walletPage.Location = New System.Drawing.Point(4, 22)
        Me.walletPage.Name = "walletPage"
        Me.walletPage.Size = New System.Drawing.Size(855, 384)
        Me.walletPage.TabIndex = 2
        Me.walletPage.Text = "Wallet"
        Me.walletPage.UseVisualStyleBackColor = True
        '
        'timerMain
        '
        Me.timerMain.Interval = 30000
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
        Me.botPage.ResumeLayout(False)
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
    Friend WithEvents InformationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tabMain As TabControl
    Friend WithEvents botPage As TabPage
    Friend WithEvents botDataView As DataGridView
    Friend WithEvents marketPage As TabPage
    Friend WithEvents walletPage As TabPage
    Friend WithEvents id As DataGridViewTextBoxColumn
#Disable Warning BC40004 ' Il membro è in conflitto con il membro nel tipo di base, quindi deve essere dichiarato come 'Shadows'
    Friend WithEvents created As DataGridViewTextBoxColumn
#Enable Warning BC40004 ' Il membro è in conflitto con il membro nel tipo di base, quindi deve essere dichiarato come 'Shadows'
    Friend WithEvents pair As DataGridViewTextBoxColumn
    Friend WithEvents isActive As DataGridViewTextBoxColumn
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
    Friend WithEvents trendValue As TextBox
    Friend WithEvents trendLabel As Label
    Friend WithEvents lastUpdateValue As TextBox
    Friend WithEvents lastUpdateLabel As Label
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents currentValue As DataGridViewTextBoxColumn
    Friend WithEvents time As DataGridViewTextBoxColumn
    Friend WithEvents value As DataGridViewTextBoxColumn
    Friend WithEvents mainChart As DataVisualization.Charting.Chart
End Class
