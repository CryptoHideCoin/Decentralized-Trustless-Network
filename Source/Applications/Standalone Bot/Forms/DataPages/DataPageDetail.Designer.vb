<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataPageDetail
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataPageDetail))
        Me.journalSplit = New System.Windows.Forms.SplitContainer()
        Me.dayPanel = New System.Windows.Forms.Panel()
        Me.apyDayValue = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.apiDayLabel = New System.Windows.Forms.Label()
        Me.earnDayValue = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.volumesDayValue = New System.Windows.Forms.TextBox()
        Me.volumeDayLabel = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.feeDayValue = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.dailySellDayValue = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.extraSellDayValue = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dailyBuyDayValue = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.extraBuyDayValue = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.initialOtherFundDayValue = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.initialDayFundStableValue = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.currentDayValue = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dayTransactionDataView = New System.Windows.Forms.DataGridView()
        Me.buyColumnName = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailyColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.journalSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.journalSplit.Panel1.SuspendLayout()
        Me.journalSplit.Panel2.SuspendLayout()
        Me.journalSplit.SuspendLayout()
        Me.dayPanel.SuspendLayout()
        CType(Me.dayTransactionDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'journalSplit
        '
        Me.journalSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.journalSplit.Location = New System.Drawing.Point(0, 0)
        Me.journalSplit.Name = "journalSplit"
        Me.journalSplit.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'journalSplit.Panel1
        '
        Me.journalSplit.Panel1.Controls.Add(Me.dayPanel)
        '
        'journalSplit.Panel2
        '
        Me.journalSplit.Panel2.Controls.Add(Me.dayTransactionDataView)
        Me.journalSplit.Size = New System.Drawing.Size(959, 450)
        Me.journalSplit.SplitterDistance = 192
        Me.journalSplit.TabIndex = 1
        '
        'dayPanel
        '
        Me.dayPanel.BackColor = System.Drawing.Color.White
        Me.dayPanel.Controls.Add(Me.apyDayValue)
        Me.dayPanel.Controls.Add(Me.Label38)
        Me.dayPanel.Controls.Add(Me.apiDayLabel)
        Me.dayPanel.Controls.Add(Me.earnDayValue)
        Me.dayPanel.Controls.Add(Me.Label34)
        Me.dayPanel.Controls.Add(Me.volumesDayValue)
        Me.dayPanel.Controls.Add(Me.volumeDayLabel)
        Me.dayPanel.Controls.Add(Me.Label36)
        Me.dayPanel.Controls.Add(Me.feeDayValue)
        Me.dayPanel.Controls.Add(Me.Label37)
        Me.dayPanel.Controls.Add(Me.Label32)
        Me.dayPanel.Controls.Add(Me.Label33)
        Me.dayPanel.Controls.Add(Me.Label28)
        Me.dayPanel.Controls.Add(Me.dailySellDayValue)
        Me.dayPanel.Controls.Add(Me.Label29)
        Me.dayPanel.Controls.Add(Me.Label30)
        Me.dayPanel.Controls.Add(Me.extraSellDayValue)
        Me.dayPanel.Controls.Add(Me.Label31)
        Me.dayPanel.Controls.Add(Me.Label24)
        Me.dayPanel.Controls.Add(Me.dailyBuyDayValue)
        Me.dayPanel.Controls.Add(Me.Label25)
        Me.dayPanel.Controls.Add(Me.Label26)
        Me.dayPanel.Controls.Add(Me.extraBuyDayValue)
        Me.dayPanel.Controls.Add(Me.Label27)
        Me.dayPanel.Controls.Add(Me.Label22)
        Me.dayPanel.Controls.Add(Me.initialOtherFundDayValue)
        Me.dayPanel.Controls.Add(Me.Label23)
        Me.dayPanel.Controls.Add(Me.Label20)
        Me.dayPanel.Controls.Add(Me.initialDayFundStableValue)
        Me.dayPanel.Controls.Add(Me.Label21)
        Me.dayPanel.Controls.Add(Me.currentDayValue)
        Me.dayPanel.Controls.Add(Me.Label17)
        Me.dayPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dayPanel.Location = New System.Drawing.Point(0, 0)
        Me.dayPanel.Name = "dayPanel"
        Me.dayPanel.Size = New System.Drawing.Size(959, 192)
        Me.dayPanel.TabIndex = 33
        '
        'apyDayValue
        '
        Me.apyDayValue.BackColor = System.Drawing.SystemColors.Control
        Me.apyDayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.apyDayValue.Location = New System.Drawing.Point(499, 148)
        Me.apyDayValue.Name = "apyDayValue"
        Me.apyDayValue.Size = New System.Drawing.Size(132, 21)
        Me.apyDayValue.TabIndex = 69
        Me.apyDayValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(638, 151)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(37, 13)
        Me.Label38.TabIndex = 68
        Me.Label38.Text = "USDT"
        '
        'apiDayLabel
        '
        Me.apiDayLabel.AutoSize = True
        Me.apiDayLabel.Location = New System.Drawing.Point(440, 151)
        Me.apiDayLabel.Name = "apiDayLabel"
        Me.apiDayLabel.Size = New System.Drawing.Size(59, 13)
        Me.apiDayLabel.TabIndex = 67
        Me.apiDayLabel.Text = "Earn (%)"
        '
        'earnDayValue
        '
        Me.earnDayValue.BackColor = System.Drawing.SystemColors.Control
        Me.earnDayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.earnDayValue.Location = New System.Drawing.Point(164, 148)
        Me.earnDayValue.Name = "earnDayValue"
        Me.earnDayValue.Size = New System.Drawing.Size(132, 21)
        Me.earnDayValue.TabIndex = 66
        Me.earnDayValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(638, 126)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(37, 13)
        Me.Label34.TabIndex = 65
        Me.Label34.Text = "USDT"
        '
        'volumesDayValue
        '
        Me.volumesDayValue.Location = New System.Drawing.Point(499, 123)
        Me.volumesDayValue.Name = "volumesDayValue"
        Me.volumesDayValue.ReadOnly = True
        Me.volumesDayValue.Size = New System.Drawing.Size(132, 21)
        Me.volumesDayValue.TabIndex = 64
        Me.volumesDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'volumeDayLabel
        '
        Me.volumeDayLabel.AutoSize = True
        Me.volumeDayLabel.Location = New System.Drawing.Point(440, 126)
        Me.volumeDayLabel.Name = "volumeDayLabel"
        Me.volumeDayLabel.Size = New System.Drawing.Size(55, 13)
        Me.volumeDayLabel.TabIndex = 63
        Me.volumeDayLabel.Text = "Volumes"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(303, 126)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(37, 13)
        Me.Label36.TabIndex = 62
        Me.Label36.Text = "USDT"
        '
        'feeDayValue
        '
        Me.feeDayValue.Location = New System.Drawing.Point(164, 123)
        Me.feeDayValue.Name = "feeDayValue"
        Me.feeDayValue.ReadOnly = True
        Me.feeDayValue.Size = New System.Drawing.Size(132, 21)
        Me.feeDayValue.TabIndex = 61
        Me.feeDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(125, 126)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(33, 13)
        Me.Label37.TabIndex = 60
        Me.Label37.Text = "Fees"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(303, 151)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 13)
        Me.Label32.TabIndex = 59
        Me.Label32.Text = "USDT"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(125, 151)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(33, 13)
        Me.Label33.TabIndex = 57
        Me.Label33.Text = "Earn"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(638, 99)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 56
        Me.Label28.Text = "USDT"
        '
        'dailySellDayValue
        '
        Me.dailySellDayValue.Location = New System.Drawing.Point(499, 96)
        Me.dailySellDayValue.Name = "dailySellDayValue"
        Me.dailySellDayValue.ReadOnly = True
        Me.dailySellDayValue.Size = New System.Drawing.Size(132, 21)
        Me.dailySellDayValue.TabIndex = 55
        Me.dailySellDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(415, 99)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(80, 13)
        Me.Label29.TabIndex = 54
        Me.Label29.Text = "Ordinary sell"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(303, 99)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(37, 13)
        Me.Label30.TabIndex = 53
        Me.Label30.Text = "USDT"
        '
        'extraSellDayValue
        '
        Me.extraSellDayValue.Location = New System.Drawing.Point(164, 96)
        Me.extraSellDayValue.Name = "extraSellDayValue"
        Me.extraSellDayValue.ReadOnly = True
        Me.extraSellDayValue.Size = New System.Drawing.Size(132, 21)
        Me.extraSellDayValue.TabIndex = 52
        Me.extraSellDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(98, 99)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 13)
        Me.Label31.TabIndex = 51
        Me.Label31.Text = "extra sell"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(638, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 13)
        Me.Label24.TabIndex = 50
        Me.Label24.Text = "USDT"
        '
        'dailyBuyDayValue
        '
        Me.dailyBuyDayValue.Location = New System.Drawing.Point(499, 69)
        Me.dailyBuyDayValue.Name = "dailyBuyDayValue"
        Me.dailyBuyDayValue.ReadOnly = True
        Me.dailyBuyDayValue.Size = New System.Drawing.Size(132, 21)
        Me.dailyBuyDayValue.TabIndex = 49
        Me.dailyBuyDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(413, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 13)
        Me.Label25.TabIndex = 48
        Me.Label25.Text = "Ordinary buy"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(303, 72)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 13)
        Me.Label26.TabIndex = 47
        Me.Label26.Text = "USDT"
        '
        'extraBuyDayValue
        '
        Me.extraBuyDayValue.Location = New System.Drawing.Point(164, 69)
        Me.extraBuyDayValue.Name = "extraBuyDayValue"
        Me.extraBuyDayValue.ReadOnly = True
        Me.extraBuyDayValue.Size = New System.Drawing.Size(132, 21)
        Me.extraBuyDayValue.TabIndex = 46
        Me.extraBuyDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(96, 72)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 13)
        Me.Label27.TabIndex = 45
        Me.Label27.Text = "extra buy"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(638, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "USDT"
        '
        'initialOtherFundDayValue
        '
        Me.initialOtherFundDayValue.Location = New System.Drawing.Point(499, 42)
        Me.initialOtherFundDayValue.Name = "initialOtherFundDayValue"
        Me.initialOtherFundDayValue.ReadOnly = True
        Me.initialOtherFundDayValue.Size = New System.Drawing.Size(132, 21)
        Me.initialOtherFundDayValue.TabIndex = 43
        Me.initialOtherFundDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(387, 45)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(108, 13)
        Me.Label23.TabIndex = 42
        Me.Label23.Text = "Initial other funds"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(303, 45)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "USDT"
        '
        'initialDayFundStableValue
        '
        Me.initialDayFundStableValue.Location = New System.Drawing.Point(164, 42)
        Me.initialDayFundStableValue.Name = "initialDayFundStableValue"
        Me.initialDayFundStableValue.ReadOnly = True
        Me.initialDayFundStableValue.Size = New System.Drawing.Size(132, 21)
        Me.initialDayFundStableValue.TabIndex = 40
        Me.initialDayFundStableValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(52, 45)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(106, 13)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "Initial fund stable"
        '
        'currentDayValue
        '
        Me.currentDayValue.Location = New System.Drawing.Point(164, 15)
        Me.currentDayValue.Name = "currentDayValue"
        Me.currentDayValue.ReadOnly = True
        Me.currentDayValue.Size = New System.Drawing.Size(178, 21)
        Me.currentDayValue.TabIndex = 34
        Me.currentDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(78, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Current date"
        '
        'dayTransactionDataView
        '
        Me.dayTransactionDataView.AllowUserToAddRows = False
        Me.dayTransactionDataView.AllowUserToDeleteRows = False
        Me.dayTransactionDataView.AllowUserToOrderColumns = True
        Me.dayTransactionDataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dayTransactionDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dayTransactionDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dayTransactionDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buyColumnName, Me.dateColumn, Me.pairIDColumn, Me.amountColumn, Me.DataGridViewTextBoxColumn7, Me.dailyColumn, Me.DataGridViewButtonColumn1})
        Me.dayTransactionDataView.Location = New System.Drawing.Point(0, 3)
        Me.dayTransactionDataView.MultiSelect = False
        Me.dayTransactionDataView.Name = "dayTransactionDataView"
        Me.dayTransactionDataView.RowHeadersVisible = False
        Me.dayTransactionDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dayTransactionDataView.Size = New System.Drawing.Size(958, 251)
        Me.dayTransactionDataView.TabIndex = 4
        '
        'buyColumnName
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.NullValue = False
        Me.buyColumnName.DefaultCellStyle = DataGridViewCellStyle2
        Me.buyColumnName.HeaderText = "Buy"
        Me.buyColumnName.Name = "buyColumnName"
        Me.buyColumnName.ReadOnly = True
        Me.buyColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.buyColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.buyColumnName.Width = 50
        '
        'dateColumn
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        Me.dateColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.dateColumn.HeaderText = "Date"
        Me.dateColumn.Name = "dateColumn"
        Me.dateColumn.ReadOnly = True
        Me.dateColumn.Width = 180
        '
        'pairIDColumn
        '
        Me.pairIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Wheat
        Me.pairIDColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.pairIDColumn.HeaderText = "Pair ID"
        Me.pairIDColumn.Name = "pairIDColumn"
        Me.pairIDColumn.ReadOnly = True
        Me.pairIDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pairIDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'amountColumn
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.amountColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.amountColumn.HeaderText = "Amount"
        Me.amountColumn.Name = "amountColumn"
        Me.amountColumn.ReadOnly = True
        Me.amountColumn.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn7.HeaderText = "Value in USDT"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'dailyColumn
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.NullValue = False
        Me.dailyColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.dailyColumn.HeaderText = "Recurring"
        Me.dailyColumn.Name = "dailyColumn"
        Me.dailyColumn.ReadOnly = True
        Me.dailyColumn.Width = 75
        '
        'DataGridViewButtonColumn1
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray
        Me.DataGridViewButtonColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewButtonColumn1.HeaderText = "Edit"
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Text = "..."
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn1.Visible = False
        Me.DataGridViewButtonColumn1.Width = 50
        '
        'DataPageDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 450)
        Me.Controls.Add(Me.journalSplit)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DataPageDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Page Detail"
        Me.journalSplit.Panel1.ResumeLayout(False)
        Me.journalSplit.Panel2.ResumeLayout(False)
        CType(Me.journalSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.journalSplit.ResumeLayout(False)
        Me.dayPanel.ResumeLayout(False)
        Me.dayPanel.PerformLayout()
        CType(Me.dayTransactionDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents journalSplit As SplitContainer
    Friend WithEvents dayPanel As Panel
    Friend WithEvents apyDayValue As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents apiDayLabel As Label
    Friend WithEvents earnDayValue As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents volumesDayValue As TextBox
    Friend WithEvents volumeDayLabel As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents feeDayValue As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents dailySellDayValue As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents extraSellDayValue As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents dailyBuyDayValue As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents extraBuyDayValue As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents initialOtherFundDayValue As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents initialDayFundStableValue As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents currentDayValue As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents dayTransactionDataView As DataGridView
    Friend WithEvents buyColumnName As DataGridViewCheckBoxColumn
    Friend WithEvents dateColumn As DataGridViewTextBoxColumn
    Friend WithEvents pairIDColumn As DataGridViewTextBoxColumn
    Friend WithEvents amountColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents dailyColumn As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
End Class
