<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditProduct
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditProduct))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.mainTab = New System.Windows.Forms.TabPage()
        Me.baseCurrencyValue = New System.Windows.Forms.TextBox()
        Me.baseCurrencyLabel = New System.Windows.Forms.Label()
        Me.quoteCurrencyValue = New System.Windows.Forms.TextBox()
        Me.quoteCurrencyLabel = New System.Windows.Forms.Label()
        Me.nameValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.keyValue = New System.Windows.Forms.TextBox()
        Me.keyLabel = New System.Windows.Forms.Label()
        Me.valuePage = New System.Windows.Forms.TabPage()
        Me.bottomPosition = New System.Windows.Forms.Label()
        Me.currentValueCurrency = New System.Windows.Forms.Label()
        Me.dateMaxValue = New System.Windows.Forms.DateTimePicker()
        Me.dateLastValue = New System.Windows.Forms.DateTimePicker()
        Me.maxValueCurrency = New System.Windows.Forms.Label()
        Me.minValueCurrency = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.currentValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dateMaxLabel = New System.Windows.Forms.Label()
        Me.maxValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.minValue = New System.Windows.Forms.TextBox()
        Me.minValueLabel = New System.Windows.Forms.Label()
        Me.dataPage = New System.Windows.Forms.TabPage()
        Me.preferenceValue = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.stateValue = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.buyPage = New System.Windows.Forms.TabPage()
        Me.tradeOpenedDataView = New System.Windows.Forms.DataGridView()
        Me.Acquire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.viewButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.activityPage = New System.Windows.Forms.TabPage()
        Me.currentTotalCurrencyLabel = New System.Windows.Forms.Label()
        Me.currentTotalValue = New System.Windows.Forms.TextBox()
        Me.currentTotalValueLabel = New System.Windows.Forms.Label()
        Me.targetLabel = New System.Windows.Forms.LinkLabel()
        Me.spreadValue = New System.Windows.Forms.Label()
        Me.spreadCurrency = New System.Windows.Forms.Label()
        Me.totalInvestmentCurrency = New System.Windows.Forms.Label()
        Me.totalAmountCurrency = New System.Windows.Forms.Label()
        Me.targetCurrency = New System.Windows.Forms.Label()
        Me.inUseValue = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.totalInvestmentValue = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.totalAmountValue = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.targetValue = New System.Windows.Forms.TextBox()
        Me.dateLastCheck = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.updateMainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.mainTab.SuspendLayout()
        Me.valuePage.SuspendLayout()
        Me.dataPage.SuspendLayout()
        Me.buyPage.SuspendLayout()
        CType(Me.tradeOpenedDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.activityPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.mainTab)
        Me.TabControl1.Controls.Add(Me.valuePage)
        Me.TabControl1.Controls.Add(Me.dataPage)
        Me.TabControl1.Controls.Add(Me.buyPage)
        Me.TabControl1.Controls.Add(Me.activityPage)
        Me.TabControl1.Location = New System.Drawing.Point(1, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(374, 279)
        Me.TabControl1.TabIndex = 1
        '
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.baseCurrencyValue)
        Me.mainTab.Controls.Add(Me.baseCurrencyLabel)
        Me.mainTab.Controls.Add(Me.quoteCurrencyValue)
        Me.mainTab.Controls.Add(Me.quoteCurrencyLabel)
        Me.mainTab.Controls.Add(Me.nameValue)
        Me.mainTab.Controls.Add(Me.Label1)
        Me.mainTab.Controls.Add(Me.keyValue)
        Me.mainTab.Controls.Add(Me.keyLabel)
        Me.mainTab.Location = New System.Drawing.Point(4, 22)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.Padding = New System.Windows.Forms.Padding(3)
        Me.mainTab.Size = New System.Drawing.Size(366, 253)
        Me.mainTab.TabIndex = 0
        Me.mainTab.Text = "Main"
        Me.mainTab.UseVisualStyleBackColor = True
        '
        'baseCurrencyValue
        '
        Me.baseCurrencyValue.Location = New System.Drawing.Point(116, 69)
        Me.baseCurrencyValue.Name = "baseCurrencyValue"
        Me.baseCurrencyValue.ReadOnly = True
        Me.baseCurrencyValue.Size = New System.Drawing.Size(224, 21)
        Me.baseCurrencyValue.TabIndex = 40
        '
        'baseCurrencyLabel
        '
        Me.baseCurrencyLabel.AutoSize = True
        Me.baseCurrencyLabel.Location = New System.Drawing.Point(18, 72)
        Me.baseCurrencyLabel.Name = "baseCurrencyLabel"
        Me.baseCurrencyLabel.Size = New System.Drawing.Size(92, 13)
        Me.baseCurrencyLabel.TabIndex = 41
        Me.baseCurrencyLabel.Text = "Base Currency"
        '
        'quoteCurrencyValue
        '
        Me.quoteCurrencyValue.Location = New System.Drawing.Point(116, 95)
        Me.quoteCurrencyValue.Name = "quoteCurrencyValue"
        Me.quoteCurrencyValue.ReadOnly = True
        Me.quoteCurrencyValue.Size = New System.Drawing.Size(224, 21)
        Me.quoteCurrencyValue.TabIndex = 4
        '
        'quoteCurrencyLabel
        '
        Me.quoteCurrencyLabel.AutoSize = True
        Me.quoteCurrencyLabel.Location = New System.Drawing.Point(12, 98)
        Me.quoteCurrencyLabel.Name = "quoteCurrencyLabel"
        Me.quoteCurrencyLabel.Size = New System.Drawing.Size(98, 13)
        Me.quoteCurrencyLabel.TabIndex = 25
        Me.quoteCurrencyLabel.Text = "Quote Currency"
        '
        'nameValue
        '
        Me.nameValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameValue.Location = New System.Drawing.Point(116, 44)
        Me.nameValue.Name = "nameValue"
        Me.nameValue.ReadOnly = True
        Me.nameValue.Size = New System.Drawing.Size(224, 21)
        Me.nameValue.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Name"
        '
        'keyValue
        '
        Me.keyValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keyValue.Location = New System.Drawing.Point(116, 17)
        Me.keyValue.Name = "keyValue"
        Me.keyValue.ReadOnly = True
        Me.keyValue.Size = New System.Drawing.Size(224, 21)
        Me.keyValue.TabIndex = 0
        '
        'keyLabel
        '
        Me.keyLabel.AutoSize = True
        Me.keyLabel.Location = New System.Drawing.Point(81, 20)
        Me.keyLabel.Name = "keyLabel"
        Me.keyLabel.Size = New System.Drawing.Size(29, 13)
        Me.keyLabel.TabIndex = 21
        Me.keyLabel.Text = "Key"
        '
        'valuePage
        '
        Me.valuePage.Controls.Add(Me.bottomPosition)
        Me.valuePage.Controls.Add(Me.currentValueCurrency)
        Me.valuePage.Controls.Add(Me.dateMaxValue)
        Me.valuePage.Controls.Add(Me.dateLastValue)
        Me.valuePage.Controls.Add(Me.maxValueCurrency)
        Me.valuePage.Controls.Add(Me.minValueCurrency)
        Me.valuePage.Controls.Add(Me.Label14)
        Me.valuePage.Controls.Add(Me.Label5)
        Me.valuePage.Controls.Add(Me.currentValue)
        Me.valuePage.Controls.Add(Me.Label3)
        Me.valuePage.Controls.Add(Me.dateMaxLabel)
        Me.valuePage.Controls.Add(Me.maxValue)
        Me.valuePage.Controls.Add(Me.Label4)
        Me.valuePage.Controls.Add(Me.Label2)
        Me.valuePage.Controls.Add(Me.minValue)
        Me.valuePage.Controls.Add(Me.minValueLabel)
        Me.valuePage.Location = New System.Drawing.Point(4, 22)
        Me.valuePage.Name = "valuePage"
        Me.valuePage.Padding = New System.Windows.Forms.Padding(3)
        Me.valuePage.Size = New System.Drawing.Size(366, 253)
        Me.valuePage.TabIndex = 1
        Me.valuePage.Text = "Value"
        Me.valuePage.UseVisualStyleBackColor = True
        '
        'bottomPosition
        '
        Me.bottomPosition.BackColor = System.Drawing.SystemColors.Control
        Me.bottomPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bottomPosition.Location = New System.Drawing.Point(116, 209)
        Me.bottomPosition.Name = "bottomPosition"
        Me.bottomPosition.Size = New System.Drawing.Size(179, 21)
        Me.bottomPosition.TabIndex = 40
        Me.bottomPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'currentValueCurrency
        '
        Me.currentValueCurrency.AutoSize = True
        Me.currentValueCurrency.Location = New System.Drawing.Point(301, 169)
        Me.currentValueCurrency.Name = "currentValueCurrency"
        Me.currentValueCurrency.Size = New System.Drawing.Size(39, 13)
        Me.currentValueCurrency.TabIndex = 39
        Me.currentValueCurrency.Text = "USDT"
        '
        'dateMaxValue
        '
        Me.dateMaxValue.Enabled = False
        Me.dateMaxValue.Location = New System.Drawing.Point(116, 117)
        Me.dateMaxValue.Name = "dateMaxValue"
        Me.dateMaxValue.Size = New System.Drawing.Size(224, 21)
        Me.dateMaxValue.TabIndex = 38
        '
        'dateLastValue
        '
        Me.dateLastValue.Enabled = False
        Me.dateLastValue.Location = New System.Drawing.Point(116, 44)
        Me.dateLastValue.Name = "dateLastValue"
        Me.dateLastValue.Size = New System.Drawing.Size(224, 21)
        Me.dateLastValue.TabIndex = 37
        '
        'maxValueCurrency
        '
        Me.maxValueCurrency.AutoSize = True
        Me.maxValueCurrency.Location = New System.Drawing.Point(301, 93)
        Me.maxValueCurrency.Name = "maxValueCurrency"
        Me.maxValueCurrency.Size = New System.Drawing.Size(39, 13)
        Me.maxValueCurrency.TabIndex = 36
        Me.maxValueCurrency.Text = "USDT"
        '
        'minValueCurrency
        '
        Me.minValueCurrency.AutoSize = True
        Me.minValueCurrency.Location = New System.Drawing.Point(301, 20)
        Me.minValueCurrency.Name = "minValueCurrency"
        Me.minValueCurrency.Size = New System.Drawing.Size(39, 13)
        Me.minValueCurrency.TabIndex = 35
        Me.minValueCurrency.Text = "USDT"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(301, 213)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Bottom Position"
        '
        'currentValue
        '
        Me.currentValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentValue.Location = New System.Drawing.Point(116, 166)
        Me.currentValue.Name = "currentValue"
        Me.currentValue.ReadOnly = True
        Me.currentValue.Size = New System.Drawing.Size(179, 21)
        Me.currentValue.TabIndex = 30
        Me.currentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Current"
        '
        'dateMaxLabel
        '
        Me.dateMaxLabel.AutoSize = True
        Me.dateMaxLabel.Location = New System.Drawing.Point(26, 120)
        Me.dateMaxLabel.Name = "dateMaxLabel"
        Me.dateMaxLabel.Size = New System.Drawing.Size(84, 13)
        Me.dateMaxLabel.TabIndex = 29
        Me.dateMaxLabel.Text = "Date Min Last"
        '
        'maxValue
        '
        Me.maxValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxValue.Location = New System.Drawing.Point(116, 90)
        Me.maxValue.Name = "maxValue"
        Me.maxValue.ReadOnly = True
        Me.maxValue.Size = New System.Drawing.Size(179, 21)
        Me.maxValue.TabIndex = 26
        Me.maxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Max Value"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Date Min Last"
        '
        'minValue
        '
        Me.minValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minValue.Location = New System.Drawing.Point(116, 17)
        Me.minValue.Name = "minValue"
        Me.minValue.ReadOnly = True
        Me.minValue.Size = New System.Drawing.Size(179, 21)
        Me.minValue.TabIndex = 22
        Me.minValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'minValueLabel
        '
        Me.minValueLabel.AutoSize = True
        Me.minValueLabel.Location = New System.Drawing.Point(49, 20)
        Me.minValueLabel.Name = "minValueLabel"
        Me.minValueLabel.Size = New System.Drawing.Size(61, 13)
        Me.minValueLabel.TabIndex = 23
        Me.minValueLabel.Text = "Min Value"
        '
        'dataPage
        '
        Me.dataPage.Controls.Add(Me.preferenceValue)
        Me.dataPage.Controls.Add(Me.Label7)
        Me.dataPage.Controls.Add(Me.stateValue)
        Me.dataPage.Controls.Add(Me.Label6)
        Me.dataPage.Location = New System.Drawing.Point(4, 22)
        Me.dataPage.Name = "dataPage"
        Me.dataPage.Size = New System.Drawing.Size(366, 253)
        Me.dataPage.TabIndex = 2
        Me.dataPage.Text = "User data"
        Me.dataPage.UseVisualStyleBackColor = True
        '
        'preferenceValue
        '
        Me.preferenceValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.preferenceValue.FormattingEnabled = True
        Me.preferenceValue.Items.AddRange(New Object() {"Ignore", "User only", "To Work", "Prefered"})
        Me.preferenceValue.Location = New System.Drawing.Point(116, 44)
        Me.preferenceValue.Name = "preferenceValue"
        Me.preferenceValue.Size = New System.Drawing.Size(224, 21)
        Me.preferenceValue.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Preference"
        '
        'stateValue
        '
        Me.stateValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.stateValue.FormattingEnabled = True
        Me.stateValue.Items.AddRange(New Object() {"Deep", "Work", "High"})
        Me.stateValue.Location = New System.Drawing.Point(116, 17)
        Me.stateValue.Name = "stateValue"
        Me.stateValue.Size = New System.Drawing.Size(224, 21)
        Me.stateValue.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(73, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "State"
        '
        'buyPage
        '
        Me.buyPage.Controls.Add(Me.tradeOpenedDataView)
        Me.buyPage.Location = New System.Drawing.Point(4, 22)
        Me.buyPage.Name = "buyPage"
        Me.buyPage.Size = New System.Drawing.Size(366, 253)
        Me.buyPage.TabIndex = 4
        Me.buyPage.Text = "Buys"
        Me.buyPage.UseVisualStyleBackColor = True
        '
        'tradeOpenedDataView
        '
        Me.tradeOpenedDataView.AllowUserToAddRows = False
        Me.tradeOpenedDataView.AllowUserToDeleteRows = False
        Me.tradeOpenedDataView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tradeOpenedDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tradeOpenedDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tradeOpenedDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Acquire, Me.viewButton})
        Me.tradeOpenedDataView.Location = New System.Drawing.Point(0, 0)
        Me.tradeOpenedDataView.MultiSelect = False
        Me.tradeOpenedDataView.Name = "tradeOpenedDataView"
        Me.tradeOpenedDataView.RowHeadersVisible = False
        Me.tradeOpenedDataView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tradeOpenedDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tradeOpenedDataView.Size = New System.Drawing.Size(366, 253)
        Me.tradeOpenedDataView.TabIndex = 8
        '
        'Acquire
        '
        Me.Acquire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Acquire.HeaderText = "Acquire"
        Me.Acquire.Name = "Acquire"
        '
        'viewButton
        '
        Me.viewButton.HeaderText = "View"
        Me.viewButton.Name = "viewButton"
        Me.viewButton.Text = "..."
        Me.viewButton.UseColumnTextForButtonValue = True
        Me.viewButton.Width = 50
        '
        'activityPage
        '
        Me.activityPage.Controls.Add(Me.currentTotalCurrencyLabel)
        Me.activityPage.Controls.Add(Me.currentTotalValue)
        Me.activityPage.Controls.Add(Me.currentTotalValueLabel)
        Me.activityPage.Controls.Add(Me.targetLabel)
        Me.activityPage.Controls.Add(Me.spreadValue)
        Me.activityPage.Controls.Add(Me.spreadCurrency)
        Me.activityPage.Controls.Add(Me.totalInvestmentCurrency)
        Me.activityPage.Controls.Add(Me.totalAmountCurrency)
        Me.activityPage.Controls.Add(Me.targetCurrency)
        Me.activityPage.Controls.Add(Me.inUseValue)
        Me.activityPage.Controls.Add(Me.Label13)
        Me.activityPage.Controls.Add(Me.totalInvestmentValue)
        Me.activityPage.Controls.Add(Me.Label12)
        Me.activityPage.Controls.Add(Me.totalAmountValue)
        Me.activityPage.Controls.Add(Me.Label11)
        Me.activityPage.Controls.Add(Me.targetValue)
        Me.activityPage.Controls.Add(Me.dateLastCheck)
        Me.activityPage.Controls.Add(Me.Label9)
        Me.activityPage.Location = New System.Drawing.Point(4, 22)
        Me.activityPage.Name = "activityPage"
        Me.activityPage.Size = New System.Drawing.Size(366, 253)
        Me.activityPage.TabIndex = 3
        Me.activityPage.Text = "Counters"
        Me.activityPage.UseVisualStyleBackColor = True
        '
        'currentTotalCurrencyLabel
        '
        Me.currentTotalCurrencyLabel.AutoSize = True
        Me.currentTotalCurrencyLabel.Location = New System.Drawing.Point(301, 173)
        Me.currentTotalCurrencyLabel.Name = "currentTotalCurrencyLabel"
        Me.currentTotalCurrencyLabel.Size = New System.Drawing.Size(39, 13)
        Me.currentTotalCurrencyLabel.TabIndex = 45
        Me.currentTotalCurrencyLabel.Text = "USDT"
        '
        'currentTotalValue
        '
        Me.currentTotalValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentTotalValue.Location = New System.Drawing.Point(116, 170)
        Me.currentTotalValue.Name = "currentTotalValue"
        Me.currentTotalValue.ReadOnly = True
        Me.currentTotalValue.Size = New System.Drawing.Size(179, 21)
        Me.currentTotalValue.TabIndex = 43
        Me.currentTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'currentTotalValueLabel
        '
        Me.currentTotalValueLabel.AutoSize = True
        Me.currentTotalValueLabel.Location = New System.Drawing.Point(24, 173)
        Me.currentTotalValueLabel.Name = "currentTotalValueLabel"
        Me.currentTotalValueLabel.Size = New System.Drawing.Size(86, 13)
        Me.currentTotalValueLabel.TabIndex = 44
        Me.currentTotalValueLabel.Text = "Current value"
        '
        'targetLabel
        '
        Me.targetLabel.AutoSize = True
        Me.targetLabel.Location = New System.Drawing.Point(44, 92)
        Me.targetLabel.Name = "targetLabel"
        Me.targetLabel.Size = New System.Drawing.Size(66, 13)
        Me.targetLabel.TabIndex = 42
        Me.targetLabel.TabStop = True
        Me.targetLabel.Text = "Min Target"
        '
        'spreadValue
        '
        Me.spreadValue.BackColor = System.Drawing.SystemColors.Control
        Me.spreadValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spreadValue.Location = New System.Drawing.Point(116, 210)
        Me.spreadValue.Name = "spreadValue"
        Me.spreadValue.Size = New System.Drawing.Size(179, 19)
        Me.spreadValue.TabIndex = 41
        Me.spreadValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'spreadCurrency
        '
        Me.spreadCurrency.AutoSize = True
        Me.spreadCurrency.Location = New System.Drawing.Point(301, 211)
        Me.spreadCurrency.Name = "spreadCurrency"
        Me.spreadCurrency.Size = New System.Drawing.Size(39, 13)
        Me.spreadCurrency.TabIndex = 40
        Me.spreadCurrency.Text = "USDT"
        '
        'totalInvestmentCurrency
        '
        Me.totalInvestmentCurrency.AutoSize = True
        Me.totalInvestmentCurrency.Location = New System.Drawing.Point(301, 146)
        Me.totalInvestmentCurrency.Name = "totalInvestmentCurrency"
        Me.totalInvestmentCurrency.Size = New System.Drawing.Size(39, 13)
        Me.totalInvestmentCurrency.TabIndex = 39
        Me.totalInvestmentCurrency.Text = "USDT"
        '
        'totalAmountCurrency
        '
        Me.totalAmountCurrency.AutoSize = True
        Me.totalAmountCurrency.Location = New System.Drawing.Point(301, 119)
        Me.totalAmountCurrency.Name = "totalAmountCurrency"
        Me.totalAmountCurrency.Size = New System.Drawing.Size(39, 13)
        Me.totalAmountCurrency.TabIndex = 38
        Me.totalAmountCurrency.Text = "USDT"
        '
        'targetCurrency
        '
        Me.targetCurrency.AutoSize = True
        Me.targetCurrency.Location = New System.Drawing.Point(301, 92)
        Me.targetCurrency.Name = "targetCurrency"
        Me.targetCurrency.Size = New System.Drawing.Size(39, 13)
        Me.targetCurrency.TabIndex = 37
        Me.targetCurrency.Text = "USDT"
        '
        'inUseValue
        '
        Me.inUseValue.AutoSize = True
        Me.inUseValue.Enabled = False
        Me.inUseValue.Location = New System.Drawing.Point(117, 20)
        Me.inUseValue.Name = "inUseValue"
        Me.inUseValue.Size = New System.Drawing.Size(62, 17)
        Me.inUseValue.TabIndex = 36
        Me.inUseValue.Text = "In use"
        Me.inUseValue.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(77, 211)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Earn"
        '
        'totalInvestmentValue
        '
        Me.totalInvestmentValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalInvestmentValue.Location = New System.Drawing.Point(116, 143)
        Me.totalInvestmentValue.Name = "totalInvestmentValue"
        Me.totalInvestmentValue.ReadOnly = True
        Me.totalInvestmentValue.Size = New System.Drawing.Size(179, 21)
        Me.totalInvestmentValue.TabIndex = 32
        Me.totalInvestmentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 146)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Total Investment"
        '
        'totalAmountValue
        '
        Me.totalAmountValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalAmountValue.Location = New System.Drawing.Point(116, 116)
        Me.totalAmountValue.Name = "totalAmountValue"
        Me.totalAmountValue.ReadOnly = True
        Me.totalAmountValue.Size = New System.Drawing.Size(179, 21)
        Me.totalAmountValue.TabIndex = 30
        Me.totalAmountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Total Amount"
        '
        'targetValue
        '
        Me.targetValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetValue.Location = New System.Drawing.Point(116, 89)
        Me.targetValue.Name = "targetValue"
        Me.targetValue.ReadOnly = True
        Me.targetValue.Size = New System.Drawing.Size(179, 21)
        Me.targetValue.TabIndex = 28
        Me.targetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dateLastCheck
        '
        Me.dateLastCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateLastCheck.Location = New System.Drawing.Point(116, 44)
        Me.dateLastCheck.Name = "dateLastCheck"
        Me.dateLastCheck.ReadOnly = True
        Me.dateLastCheck.Size = New System.Drawing.Size(224, 21)
        Me.dateLastCheck.TabIndex = 26
        Me.dateLastCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Date last check"
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(381, 34)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 44)
        Me.confirmButton.TabIndex = 7
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'updateMainTimer
        '
        '
        'EditProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 297)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Product"
        Me.TabControl1.ResumeLayout(False)
        Me.mainTab.ResumeLayout(False)
        Me.mainTab.PerformLayout()
        Me.valuePage.ResumeLayout(False)
        Me.valuePage.PerformLayout()
        Me.dataPage.ResumeLayout(False)
        Me.dataPage.PerformLayout()
        Me.buyPage.ResumeLayout(False)
        CType(Me.tradeOpenedDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.activityPage.ResumeLayout(False)
        Me.activityPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents mainTab As TabPage
    Friend WithEvents baseCurrencyValue As TextBox
    Friend WithEvents baseCurrencyLabel As Label
    Friend WithEvents quoteCurrencyValue As TextBox
    Friend WithEvents quoteCurrencyLabel As Label
    Friend WithEvents nameValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents keyValue As TextBox
    Friend WithEvents keyLabel As Label
    Friend WithEvents valuePage As TabPage
    Friend WithEvents dataPage As TabPage
    Friend WithEvents activityPage As TabPage
    Friend WithEvents confirmButton As Button
    Friend WithEvents minValue As TextBox
    Friend WithEvents minValueLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents currentValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dateMaxLabel As Label
    Friend WithEvents maxValue As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents stateValue As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents preferenceValue As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents buyPage As TabPage
    Friend WithEvents tradeOpenedDataView As DataGridView
    Friend WithEvents Acquire As DataGridViewTextBoxColumn
    Friend WithEvents viewButton As DataGridViewButtonColumn
    Friend WithEvents Label13 As Label
    Friend WithEvents totalInvestmentValue As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents totalAmountValue As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents targetValue As TextBox
    Friend WithEvents dateLastCheck As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents maxValueCurrency As Label
    Friend WithEvents minValueCurrency As Label
    Friend WithEvents dateLastValue As DateTimePicker
    Friend WithEvents currentValueCurrency As Label
    Friend WithEvents dateMaxValue As DateTimePicker
    Friend WithEvents inUseValue As CheckBox
    Friend WithEvents spreadCurrency As Label
    Friend WithEvents totalInvestmentCurrency As Label
    Friend WithEvents totalAmountCurrency As Label
    Friend WithEvents targetCurrency As Label
    Friend WithEvents updateMainTimer As Timer
    Friend WithEvents spreadValue As Label
    Friend WithEvents bottomPosition As Label
    Friend WithEvents targetLabel As LinkLabel
    Friend WithEvents currentTotalCurrencyLabel As Label
    Friend WithEvents currentTotalValue As TextBox
    Friend WithEvents currentTotalValueLabel As Label
End Class
