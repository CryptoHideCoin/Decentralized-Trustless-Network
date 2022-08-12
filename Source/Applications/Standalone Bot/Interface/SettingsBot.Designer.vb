<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsBot
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
        Me.idLabel = New System.Windows.Forms.Label()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.fundConfigurationPage = New System.Windows.Forms.TabPage()
        Me.unitStepValue = New System.Windows.Forms.TextBox()
        Me.unitStepLabel = New System.Windows.Forms.Label()
        Me.plafondValue = New System.Windows.Forms.TextBox()
        Me.plafondLabel = New System.Windows.Forms.Label()
        Me.pairIdValue = New System.Windows.Forms.TextBox()
        Me.pairIdLabel = New System.Windows.Forms.Label()
        Me.startPage = New System.Windows.Forms.TabPage()
        Me.dateStartGroupBox = New System.Windows.Forms.GroupBox()
        Me.gmtLabel = New System.Windows.Forms.Label()
        Me.timeStartValue = New System.Windows.Forms.DateTimePicker()
        Me.dateStartValue = New System.Windows.Forms.DateTimePicker()
        Me.dateStartLabel = New System.Windows.Forms.Label()
        Me.activeDateStartValue = New System.Windows.Forms.CheckBox()
        Me.waitExamMinuteLabel = New System.Windows.Forms.Label()
        Me.triggerValue = New System.Windows.Forms.TextBox()
        Me.triggerLabel = New System.Windows.Forms.Label()
        Me.minuteExamValue = New System.Windows.Forms.TextBox()
        Me.minuteExamLabel = New System.Windows.Forms.Label()
        Me.configuration = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.spreadValue = New System.Windows.Forms.TextBox()
        Me.spreadLabel = New System.Windows.Forms.Label()
        Me.modeValue = New System.Windows.Forms.ComboBox()
        Me.modeLabel = New System.Windows.Forms.Label()
        Me.acquisitionValue = New System.Windows.Forms.TabPage()
        Me.duringBottonBearMarketValue = New System.Windows.Forms.CheckBox()
        Me.notInBearMarketValue = New System.Windows.Forms.CheckBox()
        Me.onlyDealAcquireValue = New System.Windows.Forms.CheckBox()
        Me.otherDealIntervalStep = New System.Windows.Forms.Label()
        Me.dealIntervalValue = New System.Windows.Forms.TextBox()
        Me.dealIntervalLabel = New System.Windows.Forms.Label()
        Me.dealAcquireOnAcquireLabel = New System.Windows.Forms.Label()
        Me.dealAcquireValue = New System.Windows.Forms.TextBox()
        Me.dealAcquireLabel = New System.Windows.Forms.Label()
        Me.otherStepIntervalLabel = New System.Windows.Forms.Label()
        Me.stepIntervalValue = New System.Windows.Forms.TextBox()
        Me.stepIntervalLabel = New System.Windows.Forms.Label()
        Me.bearMarketPage = New System.Windows.Forms.TabPage()
        Me.percentageSymbol3Label = New System.Windows.Forms.Label()
        Me.maximumExposurePercentageValue = New System.Windows.Forms.TextBox()
        Me.maximumExposurePercentageLabel = New System.Windows.Forms.Label()
        Me.percentageSymbol2Label = New System.Windows.Forms.Label()
        Me.bottomReboundPercentageValue = New System.Windows.Forms.TextBox()
        Me.bottomReboundPercentageLabel = New System.Windows.Forms.Label()
        Me.percentageSymbolLabel = New System.Windows.Forms.Label()
        Me.degradePercentageValue = New System.Windows.Forms.TextBox()
        Me.degradePercentageLabel = New System.Windows.Forms.Label()
        Me.minuteSymbolObservationLabel = New System.Windows.Forms.Label()
        Me.observationTimeBearMarketValue = New System.Windows.Forms.TextBox()
        Me.observationTimeLabel = New System.Windows.Forms.Label()
        Me.saveFoundValue = New System.Windows.Forms.CheckBox()
        Me.bullRunPage = New System.Windows.Forms.TabPage()
        Me.percentageSymbol6Label = New System.Windows.Forms.Label()
        Me.topReboundPercentageValue = New System.Windows.Forms.TextBox()
        Me.topReboundPercentageLabel = New System.Windows.Forms.Label()
        Me.percentageSymbol5Label = New System.Windows.Forms.Label()
        Me.increasePercentageBullRunValue = New System.Windows.Forms.TextBox()
        Me.increasePercentageLabel = New System.Windows.Forms.Label()
        Me.minute2Label = New System.Windows.Forms.Label()
        Me.observationTimeValue = New System.Windows.Forms.TextBox()
        Me.observationTimeBullRunLabel = New System.Windows.Forms.Label()
        Me.percentageSymbol4Label = New System.Windows.Forms.Label()
        Me.halvingPercentageValue = New System.Windows.Forms.TextBox()
        Me.halvingPercentageLabel = New System.Windows.Forms.Label()
        Me.minute1Label = New System.Windows.Forms.Label()
        Me.halvingMinuteWhenInValue = New System.Windows.Forms.TextBox()
        Me.halvingMinuteWhenInLabel = New System.Windows.Forms.Label()
        Me.exploreBullrun = New System.Windows.Forms.CheckBox()
        Me.idValue = New System.Windows.Forms.TextBox()
        Me.createdValue = New System.Windows.Forms.TextBox()
        Me.createdLabel = New System.Windows.Forms.Label()
        Me.isActiveValue = New System.Windows.Forms.CheckBox()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.defaultButton = New System.Windows.Forms.Button()
        Me.tabMain.SuspendLayout()
        Me.fundConfigurationPage.SuspendLayout()
        Me.startPage.SuspendLayout()
        Me.dateStartGroupBox.SuspendLayout()
        Me.configuration.SuspendLayout()
        Me.acquisitionValue.SuspendLayout()
        Me.bearMarketPage.SuspendLayout()
        Me.bullRunPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'idLabel
        '
        Me.idLabel.AutoSize = True
        Me.idLabel.Location = New System.Drawing.Point(45, 16)
        Me.idLabel.Name = "idLabel"
        Me.idLabel.Size = New System.Drawing.Size(21, 13)
        Me.idLabel.TabIndex = 0
        Me.idLabel.Text = "ID"
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.fundConfigurationPage)
        Me.tabMain.Controls.Add(Me.startPage)
        Me.tabMain.Controls.Add(Me.configuration)
        Me.tabMain.Controls.Add(Me.acquisitionValue)
        Me.tabMain.Controls.Add(Me.bearMarketPage)
        Me.tabMain.Controls.Add(Me.bullRunPage)
        Me.tabMain.Location = New System.Drawing.Point(12, 106)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(660, 332)
        Me.tabMain.TabIndex = 1
        '
        'fundConfigurationPage
        '
        Me.fundConfigurationPage.Controls.Add(Me.unitStepValue)
        Me.fundConfigurationPage.Controls.Add(Me.unitStepLabel)
        Me.fundConfigurationPage.Controls.Add(Me.plafondValue)
        Me.fundConfigurationPage.Controls.Add(Me.plafondLabel)
        Me.fundConfigurationPage.Controls.Add(Me.pairIdValue)
        Me.fundConfigurationPage.Controls.Add(Me.pairIdLabel)
        Me.fundConfigurationPage.Location = New System.Drawing.Point(4, 22)
        Me.fundConfigurationPage.Name = "fundConfigurationPage"
        Me.fundConfigurationPage.Padding = New System.Windows.Forms.Padding(3)
        Me.fundConfigurationPage.Size = New System.Drawing.Size(652, 306)
        Me.fundConfigurationPage.TabIndex = 0
        Me.fundConfigurationPage.Text = "Fund"
        Me.fundConfigurationPage.UseVisualStyleBackColor = True
        '
        'unitStepValue
        '
        Me.unitStepValue.Location = New System.Drawing.Point(93, 79)
        Me.unitStepValue.Name = "unitStepValue"
        Me.unitStepValue.Size = New System.Drawing.Size(117, 21)
        Me.unitStepValue.TabIndex = 8
        Me.unitStepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'unitStepLabel
        '
        Me.unitStepLabel.AutoSize = True
        Me.unitStepLabel.Location = New System.Drawing.Point(30, 82)
        Me.unitStepLabel.Name = "unitStepLabel"
        Me.unitStepLabel.Size = New System.Drawing.Size(57, 13)
        Me.unitStepLabel.TabIndex = 7
        Me.unitStepLabel.Text = "Unit step"
        '
        'plafondValue
        '
        Me.plafondValue.Location = New System.Drawing.Point(93, 52)
        Me.plafondValue.Name = "plafondValue"
        Me.plafondValue.Size = New System.Drawing.Size(117, 21)
        Me.plafondValue.TabIndex = 6
        Me.plafondValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'plafondLabel
        '
        Me.plafondLabel.AutoSize = True
        Me.plafondLabel.Location = New System.Drawing.Point(38, 55)
        Me.plafondLabel.Name = "plafondLabel"
        Me.plafondLabel.Size = New System.Drawing.Size(49, 13)
        Me.plafondLabel.TabIndex = 5
        Me.plafondLabel.Text = "Plafond"
        '
        'pairIdValue
        '
        Me.pairIdValue.Location = New System.Drawing.Point(93, 25)
        Me.pairIdValue.Name = "pairIdValue"
        Me.pairIdValue.Size = New System.Drawing.Size(117, 21)
        Me.pairIdValue.TabIndex = 4
        Me.pairIdValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pairIdLabel
        '
        Me.pairIdLabel.AutoSize = True
        Me.pairIdLabel.Location = New System.Drawing.Point(58, 28)
        Me.pairIdLabel.Name = "pairIdLabel"
        Me.pairIdLabel.Size = New System.Drawing.Size(29, 13)
        Me.pairIdLabel.TabIndex = 3
        Me.pairIdLabel.Text = "Pair"
        '
        'startPage
        '
        Me.startPage.Controls.Add(Me.dateStartGroupBox)
        Me.startPage.Controls.Add(Me.waitExamMinuteLabel)
        Me.startPage.Controls.Add(Me.triggerValue)
        Me.startPage.Controls.Add(Me.triggerLabel)
        Me.startPage.Controls.Add(Me.minuteExamValue)
        Me.startPage.Controls.Add(Me.minuteExamLabel)
        Me.startPage.Location = New System.Drawing.Point(4, 22)
        Me.startPage.Name = "startPage"
        Me.startPage.Padding = New System.Windows.Forms.Padding(3)
        Me.startPage.Size = New System.Drawing.Size(652, 306)
        Me.startPage.TabIndex = 1
        Me.startPage.Text = "Start"
        Me.startPage.UseVisualStyleBackColor = True
        '
        'dateStartGroupBox
        '
        Me.dateStartGroupBox.Controls.Add(Me.gmtLabel)
        Me.dateStartGroupBox.Controls.Add(Me.timeStartValue)
        Me.dateStartGroupBox.Controls.Add(Me.dateStartValue)
        Me.dateStartGroupBox.Controls.Add(Me.dateStartLabel)
        Me.dateStartGroupBox.Controls.Add(Me.activeDateStartValue)
        Me.dateStartGroupBox.Location = New System.Drawing.Point(23, 32)
        Me.dateStartGroupBox.Name = "dateStartGroupBox"
        Me.dateStartGroupBox.Size = New System.Drawing.Size(563, 76)
        Me.dateStartGroupBox.TabIndex = 15
        Me.dateStartGroupBox.TabStop = False
        '
        'gmtLabel
        '
        Me.gmtLabel.AutoSize = True
        Me.gmtLabel.Enabled = False
        Me.gmtLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.gmtLabel.Location = New System.Drawing.Point(402, 36)
        Me.gmtLabel.Name = "gmtLabel"
        Me.gmtLabel.Size = New System.Drawing.Size(42, 13)
        Me.gmtLabel.TabIndex = 14
        Me.gmtLabel.Text = "(GMT)"
        '
        'timeStartValue
        '
        Me.timeStartValue.Enabled = False
        Me.timeStartValue.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.timeStartValue.Location = New System.Drawing.Point(301, 33)
        Me.timeStartValue.Name = "timeStartValue"
        Me.timeStartValue.Size = New System.Drawing.Size(95, 21)
        Me.timeStartValue.TabIndex = 13
        '
        'dateStartValue
        '
        Me.dateStartValue.Enabled = False
        Me.dateStartValue.Location = New System.Drawing.Point(95, 33)
        Me.dateStartValue.Name = "dateStartValue"
        Me.dateStartValue.Size = New System.Drawing.Size(200, 21)
        Me.dateStartValue.TabIndex = 12
        '
        'dateStartLabel
        '
        Me.dateStartLabel.AutoSize = True
        Me.dateStartLabel.Enabled = False
        Me.dateStartLabel.Location = New System.Drawing.Point(25, 36)
        Me.dateStartLabel.Name = "dateStartLabel"
        Me.dateStartLabel.Size = New System.Drawing.Size(64, 13)
        Me.dateStartLabel.TabIndex = 11
        Me.dateStartLabel.Text = "Date start"
        '
        'activeDateStartValue
        '
        Me.activeDateStartValue.AutoSize = True
        Me.activeDateStartValue.BackColor = System.Drawing.Color.White
        Me.activeDateStartValue.Location = New System.Drawing.Point(9, 0)
        Me.activeDateStartValue.Name = "activeDateStartValue"
        Me.activeDateStartValue.Size = New System.Drawing.Size(157, 17)
        Me.activeDateStartValue.TabIndex = 10
        Me.activeDateStartValue.Text = "Activate on date / time"
        Me.activeDateStartValue.UseVisualStyleBackColor = False
        '
        'waitExamMinuteLabel
        '
        Me.waitExamMinuteLabel.AutoSize = True
        Me.waitExamMinuteLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.waitExamMinuteLabel.Location = New System.Drawing.Point(232, 117)
        Me.waitExamMinuteLabel.Name = "waitExamMinuteLabel"
        Me.waitExamMinuteLabel.Size = New System.Drawing.Size(54, 13)
        Me.waitExamMinuteLabel.TabIndex = 14
        Me.waitExamMinuteLabel.Text = "(Minute)"
        '
        'triggerValue
        '
        Me.triggerValue.Location = New System.Drawing.Point(109, 141)
        Me.triggerValue.Name = "triggerValue"
        Me.triggerValue.Size = New System.Drawing.Size(117, 21)
        Me.triggerValue.TabIndex = 13
        Me.triggerValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'triggerLabel
        '
        Me.triggerLabel.AutoSize = True
        Me.triggerLabel.Location = New System.Drawing.Point(21, 144)
        Me.triggerLabel.Name = "triggerLabel"
        Me.triggerLabel.Size = New System.Drawing.Size(82, 13)
        Me.triggerLabel.TabIndex = 12
        Me.triggerLabel.Text = "Trigger value"
        '
        'minuteExamValue
        '
        Me.minuteExamValue.Location = New System.Drawing.Point(109, 114)
        Me.minuteExamValue.Name = "minuteExamValue"
        Me.minuteExamValue.Size = New System.Drawing.Size(117, 21)
        Me.minuteExamValue.TabIndex = 11
        Me.minuteExamValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'minuteExamLabel
        '
        Me.minuteExamLabel.AutoSize = True
        Me.minuteExamLabel.Location = New System.Drawing.Point(36, 117)
        Me.minuteExamLabel.Name = "minuteExamLabel"
        Me.minuteExamLabel.Size = New System.Drawing.Size(67, 13)
        Me.minuteExamLabel.TabIndex = 10
        Me.minuteExamLabel.Text = "Wait exam"
        '
        'configuration
        '
        Me.configuration.Controls.Add(Me.Label1)
        Me.configuration.Controls.Add(Me.spreadValue)
        Me.configuration.Controls.Add(Me.spreadLabel)
        Me.configuration.Controls.Add(Me.modeValue)
        Me.configuration.Controls.Add(Me.modeLabel)
        Me.configuration.Location = New System.Drawing.Point(4, 22)
        Me.configuration.Name = "configuration"
        Me.configuration.Size = New System.Drawing.Size(652, 306)
        Me.configuration.TabIndex = 3
        Me.configuration.Text = "Configuration"
        Me.configuration.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(194, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "%"
        '
        'spreadValue
        '
        Me.spreadValue.Location = New System.Drawing.Point(71, 49)
        Me.spreadValue.Name = "spreadValue"
        Me.spreadValue.Size = New System.Drawing.Size(117, 21)
        Me.spreadValue.TabIndex = 15
        Me.spreadValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'spreadLabel
        '
        Me.spreadLabel.AutoSize = True
        Me.spreadLabel.Location = New System.Drawing.Point(17, 52)
        Me.spreadLabel.Name = "spreadLabel"
        Me.spreadLabel.Size = New System.Drawing.Size(48, 13)
        Me.spreadLabel.TabIndex = 14
        Me.spreadLabel.Text = "Spread"
        '
        'modeValue
        '
        Me.modeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.modeValue.FormattingEnabled = True
        Me.modeValue.Items.AddRange(New Object() {"One shot", "Continuous gain", "DCA", "Only deal"})
        Me.modeValue.Location = New System.Drawing.Point(71, 22)
        Me.modeValue.Name = "modeValue"
        Me.modeValue.Size = New System.Drawing.Size(162, 21)
        Me.modeValue.TabIndex = 7
        '
        'modeLabel
        '
        Me.modeLabel.AutoSize = True
        Me.modeLabel.Location = New System.Drawing.Point(28, 25)
        Me.modeLabel.Name = "modeLabel"
        Me.modeLabel.Size = New System.Drawing.Size(37, 13)
        Me.modeLabel.TabIndex = 5
        Me.modeLabel.Text = "Mode"
        '
        'acquisitionValue
        '
        Me.acquisitionValue.Controls.Add(Me.duringBottonBearMarketValue)
        Me.acquisitionValue.Controls.Add(Me.notInBearMarketValue)
        Me.acquisitionValue.Controls.Add(Me.onlyDealAcquireValue)
        Me.acquisitionValue.Controls.Add(Me.otherDealIntervalStep)
        Me.acquisitionValue.Controls.Add(Me.dealIntervalValue)
        Me.acquisitionValue.Controls.Add(Me.dealIntervalLabel)
        Me.acquisitionValue.Controls.Add(Me.dealAcquireOnAcquireLabel)
        Me.acquisitionValue.Controls.Add(Me.dealAcquireValue)
        Me.acquisitionValue.Controls.Add(Me.dealAcquireLabel)
        Me.acquisitionValue.Controls.Add(Me.otherStepIntervalLabel)
        Me.acquisitionValue.Controls.Add(Me.stepIntervalValue)
        Me.acquisitionValue.Controls.Add(Me.stepIntervalLabel)
        Me.acquisitionValue.Location = New System.Drawing.Point(4, 22)
        Me.acquisitionValue.Name = "acquisitionValue"
        Me.acquisitionValue.Size = New System.Drawing.Size(652, 306)
        Me.acquisitionValue.TabIndex = 2
        Me.acquisitionValue.Text = "Restocking"
        Me.acquisitionValue.UseVisualStyleBackColor = True
        '
        'duringBottonBearMarketValue
        '
        Me.duringBottonBearMarketValue.AutoSize = True
        Me.duringBottonBearMarketValue.Location = New System.Drawing.Point(99, 154)
        Me.duringBottonBearMarketValue.Name = "duringBottonBearMarketValue"
        Me.duringBottonBearMarketValue.Size = New System.Drawing.Size(179, 17)
        Me.duringBottonBearMarketValue.TabIndex = 26
        Me.duringBottonBearMarketValue.Text = "During botton bear market"
        Me.duringBottonBearMarketValue.UseVisualStyleBackColor = True
        '
        'notInBearMarketValue
        '
        Me.notInBearMarketValue.AutoSize = True
        Me.notInBearMarketValue.Location = New System.Drawing.Point(99, 131)
        Me.notInBearMarketValue.Name = "notInBearMarketValue"
        Me.notInBearMarketValue.Size = New System.Drawing.Size(134, 17)
        Me.notInBearMarketValue.TabIndex = 25
        Me.notInBearMarketValue.Text = "Not in bear market"
        Me.notInBearMarketValue.UseVisualStyleBackColor = True
        '
        'onlyDealAcquireValue
        '
        Me.onlyDealAcquireValue.AutoSize = True
        Me.onlyDealAcquireValue.Location = New System.Drawing.Point(99, 107)
        Me.onlyDealAcquireValue.Name = "onlyDealAcquireValue"
        Me.onlyDealAcquireValue.Size = New System.Drawing.Size(94, 17)
        Me.onlyDealAcquireValue.TabIndex = 24
        Me.onlyDealAcquireValue.Text = "Only in deal"
        Me.onlyDealAcquireValue.UseVisualStyleBackColor = True
        '
        'otherDealIntervalStep
        '
        Me.otherDealIntervalStep.AutoSize = True
        Me.otherDealIntervalStep.ForeColor = System.Drawing.Color.ForestGreen
        Me.otherDealIntervalStep.Location = New System.Drawing.Point(222, 82)
        Me.otherDealIntervalStep.Name = "otherDealIntervalStep"
        Me.otherDealIntervalStep.Size = New System.Drawing.Size(54, 13)
        Me.otherDealIntervalStep.TabIndex = 23
        Me.otherDealIntervalStep.Text = "(Minute)"
        '
        'dealIntervalValue
        '
        Me.dealIntervalValue.Location = New System.Drawing.Point(99, 79)
        Me.dealIntervalValue.Name = "dealIntervalValue"
        Me.dealIntervalValue.Size = New System.Drawing.Size(117, 21)
        Me.dealIntervalValue.TabIndex = 22
        Me.dealIntervalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dealIntervalLabel
        '
        Me.dealIntervalLabel.AutoSize = True
        Me.dealIntervalLabel.Location = New System.Drawing.Point(13, 82)
        Me.dealIntervalLabel.Name = "dealIntervalLabel"
        Me.dealIntervalLabel.Size = New System.Drawing.Size(80, 13)
        Me.dealIntervalLabel.TabIndex = 21
        Me.dealIntervalLabel.Text = "Deal interval"
        '
        'dealAcquireOnAcquireLabel
        '
        Me.dealAcquireOnAcquireLabel.AutoSize = True
        Me.dealAcquireOnAcquireLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.dealAcquireOnAcquireLabel.Location = New System.Drawing.Point(222, 55)
        Me.dealAcquireOnAcquireLabel.Name = "dealAcquireOnAcquireLabel"
        Me.dealAcquireOnAcquireLabel.Size = New System.Drawing.Size(19, 13)
        Me.dealAcquireOnAcquireLabel.TabIndex = 20
        Me.dealAcquireOnAcquireLabel.Text = "%"
        '
        'dealAcquireValue
        '
        Me.dealAcquireValue.Location = New System.Drawing.Point(99, 52)
        Me.dealAcquireValue.Name = "dealAcquireValue"
        Me.dealAcquireValue.Size = New System.Drawing.Size(117, 21)
        Me.dealAcquireValue.TabIndex = 19
        Me.dealAcquireValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dealAcquireLabel
        '
        Me.dealAcquireLabel.AutoSize = True
        Me.dealAcquireLabel.Location = New System.Drawing.Point(13, 55)
        Me.dealAcquireLabel.Name = "dealAcquireLabel"
        Me.dealAcquireLabel.Size = New System.Drawing.Size(79, 13)
        Me.dealAcquireLabel.TabIndex = 18
        Me.dealAcquireLabel.Text = "Deal acquire"
        '
        'otherStepIntervalLabel
        '
        Me.otherStepIntervalLabel.AutoSize = True
        Me.otherStepIntervalLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.otherStepIntervalLabel.Location = New System.Drawing.Point(222, 28)
        Me.otherStepIntervalLabel.Name = "otherStepIntervalLabel"
        Me.otherStepIntervalLabel.Size = New System.Drawing.Size(54, 13)
        Me.otherStepIntervalLabel.TabIndex = 17
        Me.otherStepIntervalLabel.Text = "(Minute)"
        '
        'stepIntervalValue
        '
        Me.stepIntervalValue.Location = New System.Drawing.Point(99, 25)
        Me.stepIntervalValue.Name = "stepIntervalValue"
        Me.stepIntervalValue.Size = New System.Drawing.Size(117, 21)
        Me.stepIntervalValue.TabIndex = 16
        Me.stepIntervalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stepIntervalLabel
        '
        Me.stepIntervalLabel.AutoSize = True
        Me.stepIntervalLabel.Location = New System.Drawing.Point(13, 28)
        Me.stepIntervalLabel.Name = "stepIntervalLabel"
        Me.stepIntervalLabel.Size = New System.Drawing.Size(80, 13)
        Me.stepIntervalLabel.TabIndex = 15
        Me.stepIntervalLabel.Text = "Step interval"
        '
        'bearMarketPage
        '
        Me.bearMarketPage.Controls.Add(Me.percentageSymbol3Label)
        Me.bearMarketPage.Controls.Add(Me.maximumExposurePercentageValue)
        Me.bearMarketPage.Controls.Add(Me.maximumExposurePercentageLabel)
        Me.bearMarketPage.Controls.Add(Me.percentageSymbol2Label)
        Me.bearMarketPage.Controls.Add(Me.bottomReboundPercentageValue)
        Me.bearMarketPage.Controls.Add(Me.bottomReboundPercentageLabel)
        Me.bearMarketPage.Controls.Add(Me.percentageSymbolLabel)
        Me.bearMarketPage.Controls.Add(Me.degradePercentageValue)
        Me.bearMarketPage.Controls.Add(Me.degradePercentageLabel)
        Me.bearMarketPage.Controls.Add(Me.minuteSymbolObservationLabel)
        Me.bearMarketPage.Controls.Add(Me.observationTimeBearMarketValue)
        Me.bearMarketPage.Controls.Add(Me.observationTimeLabel)
        Me.bearMarketPage.Controls.Add(Me.saveFoundValue)
        Me.bearMarketPage.Location = New System.Drawing.Point(4, 22)
        Me.bearMarketPage.Name = "bearMarketPage"
        Me.bearMarketPage.Size = New System.Drawing.Size(652, 306)
        Me.bearMarketPage.TabIndex = 4
        Me.bearMarketPage.Text = "Bear market"
        Me.bearMarketPage.UseVisualStyleBackColor = True
        '
        'percentageSymbol3Label
        '
        Me.percentageSymbol3Label.AutoSize = True
        Me.percentageSymbol3Label.Enabled = False
        Me.percentageSymbol3Label.ForeColor = System.Drawing.Color.ForestGreen
        Me.percentageSymbol3Label.Location = New System.Drawing.Point(303, 135)
        Me.percentageSymbol3Label.Name = "percentageSymbol3Label"
        Me.percentageSymbol3Label.Size = New System.Drawing.Size(19, 13)
        Me.percentageSymbol3Label.TabIndex = 27
        Me.percentageSymbol3Label.Text = "%"
        '
        'maximumExposurePercentageValue
        '
        Me.maximumExposurePercentageValue.Enabled = False
        Me.maximumExposurePercentageValue.Location = New System.Drawing.Point(216, 132)
        Me.maximumExposurePercentageValue.Name = "maximumExposurePercentageValue"
        Me.maximumExposurePercentageValue.Size = New System.Drawing.Size(81, 21)
        Me.maximumExposurePercentageValue.TabIndex = 26
        Me.maximumExposurePercentageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'maximumExposurePercentageLabel
        '
        Me.maximumExposurePercentageLabel.AutoSize = True
        Me.maximumExposurePercentageLabel.Enabled = False
        Me.maximumExposurePercentageLabel.Location = New System.Drawing.Point(24, 135)
        Me.maximumExposurePercentageLabel.Name = "maximumExposurePercentageLabel"
        Me.maximumExposurePercentageLabel.Size = New System.Drawing.Size(187, 13)
        Me.maximumExposurePercentageLabel.TabIndex = 25
        Me.maximumExposurePercentageLabel.Text = "Maximum exposure percentage"
        '
        'percentageSymbol2Label
        '
        Me.percentageSymbol2Label.AutoSize = True
        Me.percentageSymbol2Label.Enabled = False
        Me.percentageSymbol2Label.ForeColor = System.Drawing.Color.ForestGreen
        Me.percentageSymbol2Label.Location = New System.Drawing.Point(303, 108)
        Me.percentageSymbol2Label.Name = "percentageSymbol2Label"
        Me.percentageSymbol2Label.Size = New System.Drawing.Size(19, 13)
        Me.percentageSymbol2Label.TabIndex = 24
        Me.percentageSymbol2Label.Text = "%"
        '
        'bottomReboundPercentageValue
        '
        Me.bottomReboundPercentageValue.Enabled = False
        Me.bottomReboundPercentageValue.Location = New System.Drawing.Point(216, 105)
        Me.bottomReboundPercentageValue.Name = "bottomReboundPercentageValue"
        Me.bottomReboundPercentageValue.Size = New System.Drawing.Size(81, 21)
        Me.bottomReboundPercentageValue.TabIndex = 23
        Me.bottomReboundPercentageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bottomReboundPercentageLabel
        '
        Me.bottomReboundPercentageLabel.AutoSize = True
        Me.bottomReboundPercentageLabel.Enabled = False
        Me.bottomReboundPercentageLabel.Location = New System.Drawing.Point(43, 108)
        Me.bottomReboundPercentageLabel.Name = "bottomReboundPercentageLabel"
        Me.bottomReboundPercentageLabel.Size = New System.Drawing.Size(167, 13)
        Me.bottomReboundPercentageLabel.TabIndex = 22
        Me.bottomReboundPercentageLabel.Text = "Bottom rebound percentage"
        '
        'percentageSymbolLabel
        '
        Me.percentageSymbolLabel.AutoSize = True
        Me.percentageSymbolLabel.Enabled = False
        Me.percentageSymbolLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.percentageSymbolLabel.Location = New System.Drawing.Point(303, 81)
        Me.percentageSymbolLabel.Name = "percentageSymbolLabel"
        Me.percentageSymbolLabel.Size = New System.Drawing.Size(19, 13)
        Me.percentageSymbolLabel.TabIndex = 21
        Me.percentageSymbolLabel.Text = "%"
        '
        'degradePercentageValue
        '
        Me.degradePercentageValue.Enabled = False
        Me.degradePercentageValue.Location = New System.Drawing.Point(216, 78)
        Me.degradePercentageValue.Name = "degradePercentageValue"
        Me.degradePercentageValue.Size = New System.Drawing.Size(81, 21)
        Me.degradePercentageValue.TabIndex = 20
        Me.degradePercentageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'degradePercentageLabel
        '
        Me.degradePercentageLabel.AutoSize = True
        Me.degradePercentageLabel.Enabled = False
        Me.degradePercentageLabel.Location = New System.Drawing.Point(86, 81)
        Me.degradePercentageLabel.Name = "degradePercentageLabel"
        Me.degradePercentageLabel.Size = New System.Drawing.Size(124, 13)
        Me.degradePercentageLabel.TabIndex = 19
        Me.degradePercentageLabel.Text = "Degrade percentage"
        '
        'minuteSymbolObservationLabel
        '
        Me.minuteSymbolObservationLabel.AutoSize = True
        Me.minuteSymbolObservationLabel.Enabled = False
        Me.minuteSymbolObservationLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.minuteSymbolObservationLabel.Location = New System.Drawing.Point(303, 54)
        Me.minuteSymbolObservationLabel.Name = "minuteSymbolObservationLabel"
        Me.minuteSymbolObservationLabel.Size = New System.Drawing.Size(54, 13)
        Me.minuteSymbolObservationLabel.TabIndex = 18
        Me.minuteSymbolObservationLabel.Text = "(Minute)"
        '
        'observationTimeBearMarketValue
        '
        Me.observationTimeBearMarketValue.Enabled = False
        Me.observationTimeBearMarketValue.Location = New System.Drawing.Point(216, 51)
        Me.observationTimeBearMarketValue.Name = "observationTimeBearMarketValue"
        Me.observationTimeBearMarketValue.Size = New System.Drawing.Size(81, 21)
        Me.observationTimeBearMarketValue.TabIndex = 2
        Me.observationTimeBearMarketValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'observationTimeLabel
        '
        Me.observationTimeLabel.AutoSize = True
        Me.observationTimeLabel.Enabled = False
        Me.observationTimeLabel.Location = New System.Drawing.Point(105, 54)
        Me.observationTimeLabel.Name = "observationTimeLabel"
        Me.observationTimeLabel.Size = New System.Drawing.Size(105, 13)
        Me.observationTimeLabel.TabIndex = 1
        Me.observationTimeLabel.Text = "Observation time"
        '
        'saveFoundValue
        '
        Me.saveFoundValue.AutoSize = True
        Me.saveFoundValue.Location = New System.Drawing.Point(216, 18)
        Me.saveFoundValue.Name = "saveFoundValue"
        Me.saveFoundValue.Size = New System.Drawing.Size(132, 17)
        Me.saveFoundValue.TabIndex = 0
        Me.saveFoundValue.Text = "Auto protect found"
        Me.saveFoundValue.UseVisualStyleBackColor = True
        '
        'bullRunPage
        '
        Me.bullRunPage.Controls.Add(Me.percentageSymbol6Label)
        Me.bullRunPage.Controls.Add(Me.topReboundPercentageValue)
        Me.bullRunPage.Controls.Add(Me.topReboundPercentageLabel)
        Me.bullRunPage.Controls.Add(Me.percentageSymbol5Label)
        Me.bullRunPage.Controls.Add(Me.increasePercentageBullRunValue)
        Me.bullRunPage.Controls.Add(Me.increasePercentageLabel)
        Me.bullRunPage.Controls.Add(Me.minute2Label)
        Me.bullRunPage.Controls.Add(Me.observationTimeValue)
        Me.bullRunPage.Controls.Add(Me.observationTimeBullRunLabel)
        Me.bullRunPage.Controls.Add(Me.percentageSymbol4Label)
        Me.bullRunPage.Controls.Add(Me.halvingPercentageValue)
        Me.bullRunPage.Controls.Add(Me.halvingPercentageLabel)
        Me.bullRunPage.Controls.Add(Me.minute1Label)
        Me.bullRunPage.Controls.Add(Me.halvingMinuteWhenInValue)
        Me.bullRunPage.Controls.Add(Me.halvingMinuteWhenInLabel)
        Me.bullRunPage.Controls.Add(Me.exploreBullrun)
        Me.bullRunPage.Location = New System.Drawing.Point(4, 22)
        Me.bullRunPage.Name = "bullRunPage"
        Me.bullRunPage.Size = New System.Drawing.Size(652, 306)
        Me.bullRunPage.TabIndex = 5
        Me.bullRunPage.Text = "Bull run"
        Me.bullRunPage.UseVisualStyleBackColor = True
        '
        'percentageSymbol6Label
        '
        Me.percentageSymbol6Label.AutoSize = True
        Me.percentageSymbol6Label.Enabled = False
        Me.percentageSymbol6Label.ForeColor = System.Drawing.Color.ForestGreen
        Me.percentageSymbol6Label.Location = New System.Drawing.Point(303, 162)
        Me.percentageSymbol6Label.Name = "percentageSymbol6Label"
        Me.percentageSymbol6Label.Size = New System.Drawing.Size(19, 13)
        Me.percentageSymbol6Label.TabIndex = 43
        Me.percentageSymbol6Label.Text = "%"
        '
        'topReboundPercentageValue
        '
        Me.topReboundPercentageValue.Enabled = False
        Me.topReboundPercentageValue.Location = New System.Drawing.Point(216, 159)
        Me.topReboundPercentageValue.Name = "topReboundPercentageValue"
        Me.topReboundPercentageValue.Size = New System.Drawing.Size(81, 21)
        Me.topReboundPercentageValue.TabIndex = 42
        Me.topReboundPercentageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'topReboundPercentageLabel
        '
        Me.topReboundPercentageLabel.AutoSize = True
        Me.topReboundPercentageLabel.Enabled = False
        Me.topReboundPercentageLabel.Location = New System.Drawing.Point(64, 162)
        Me.topReboundPercentageLabel.Name = "topReboundPercentageLabel"
        Me.topReboundPercentageLabel.Size = New System.Drawing.Size(146, 13)
        Me.topReboundPercentageLabel.TabIndex = 41
        Me.topReboundPercentageLabel.Text = "Top rebound percentage"
        '
        'percentageSymbol5Label
        '
        Me.percentageSymbol5Label.AutoSize = True
        Me.percentageSymbol5Label.Enabled = False
        Me.percentageSymbol5Label.ForeColor = System.Drawing.Color.ForestGreen
        Me.percentageSymbol5Label.Location = New System.Drawing.Point(303, 135)
        Me.percentageSymbol5Label.Name = "percentageSymbol5Label"
        Me.percentageSymbol5Label.Size = New System.Drawing.Size(19, 13)
        Me.percentageSymbol5Label.TabIndex = 40
        Me.percentageSymbol5Label.Text = "%"
        '
        'increasePercentageBullRunValue
        '
        Me.increasePercentageBullRunValue.Enabled = False
        Me.increasePercentageBullRunValue.Location = New System.Drawing.Point(216, 132)
        Me.increasePercentageBullRunValue.Name = "increasePercentageBullRunValue"
        Me.increasePercentageBullRunValue.Size = New System.Drawing.Size(81, 21)
        Me.increasePercentageBullRunValue.TabIndex = 39
        Me.increasePercentageBullRunValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'increasePercentageLabel
        '
        Me.increasePercentageLabel.AutoSize = True
        Me.increasePercentageLabel.Enabled = False
        Me.increasePercentageLabel.Location = New System.Drawing.Point(85, 135)
        Me.increasePercentageLabel.Name = "increasePercentageLabel"
        Me.increasePercentageLabel.Size = New System.Drawing.Size(125, 13)
        Me.increasePercentageLabel.TabIndex = 38
        Me.increasePercentageLabel.Text = "Increase percentage"
        '
        'minute2Label
        '
        Me.minute2Label.AutoSize = True
        Me.minute2Label.Enabled = False
        Me.minute2Label.ForeColor = System.Drawing.Color.ForestGreen
        Me.minute2Label.Location = New System.Drawing.Point(303, 108)
        Me.minute2Label.Name = "minute2Label"
        Me.minute2Label.Size = New System.Drawing.Size(54, 13)
        Me.minute2Label.TabIndex = 37
        Me.minute2Label.Text = "(Minute)"
        '
        'observationTimeValue
        '
        Me.observationTimeValue.Enabled = False
        Me.observationTimeValue.Location = New System.Drawing.Point(216, 105)
        Me.observationTimeValue.Name = "observationTimeValue"
        Me.observationTimeValue.Size = New System.Drawing.Size(81, 21)
        Me.observationTimeValue.TabIndex = 36
        Me.observationTimeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'observationTimeBullRunLabel
        '
        Me.observationTimeBullRunLabel.AutoSize = True
        Me.observationTimeBullRunLabel.Enabled = False
        Me.observationTimeBullRunLabel.Location = New System.Drawing.Point(105, 108)
        Me.observationTimeBullRunLabel.Name = "observationTimeBullRunLabel"
        Me.observationTimeBullRunLabel.Size = New System.Drawing.Size(105, 13)
        Me.observationTimeBullRunLabel.TabIndex = 35
        Me.observationTimeBullRunLabel.Text = "Observation time"
        '
        'percentageSymbol4Label
        '
        Me.percentageSymbol4Label.AutoSize = True
        Me.percentageSymbol4Label.Enabled = False
        Me.percentageSymbol4Label.ForeColor = System.Drawing.Color.ForestGreen
        Me.percentageSymbol4Label.Location = New System.Drawing.Point(303, 81)
        Me.percentageSymbol4Label.Name = "percentageSymbol4Label"
        Me.percentageSymbol4Label.Size = New System.Drawing.Size(19, 13)
        Me.percentageSymbol4Label.TabIndex = 34
        Me.percentageSymbol4Label.Text = "%"
        '
        'halvingPercentageValue
        '
        Me.halvingPercentageValue.Enabled = False
        Me.halvingPercentageValue.Location = New System.Drawing.Point(216, 78)
        Me.halvingPercentageValue.Name = "halvingPercentageValue"
        Me.halvingPercentageValue.Size = New System.Drawing.Size(81, 21)
        Me.halvingPercentageValue.TabIndex = 33
        Me.halvingPercentageValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'halvingPercentageLabel
        '
        Me.halvingPercentageLabel.AutoSize = True
        Me.halvingPercentageLabel.Enabled = False
        Me.halvingPercentageLabel.Location = New System.Drawing.Point(93, 81)
        Me.halvingPercentageLabel.Name = "halvingPercentageLabel"
        Me.halvingPercentageLabel.Size = New System.Drawing.Size(117, 13)
        Me.halvingPercentageLabel.TabIndex = 32
        Me.halvingPercentageLabel.Text = "Halving percentage"
        '
        'minute1Label
        '
        Me.minute1Label.AutoSize = True
        Me.minute1Label.Enabled = False
        Me.minute1Label.ForeColor = System.Drawing.Color.ForestGreen
        Me.minute1Label.Location = New System.Drawing.Point(303, 54)
        Me.minute1Label.Name = "minute1Label"
        Me.minute1Label.Size = New System.Drawing.Size(54, 13)
        Me.minute1Label.TabIndex = 31
        Me.minute1Label.Text = "(Minute)"
        '
        'halvingMinuteWhenInValue
        '
        Me.halvingMinuteWhenInValue.Enabled = False
        Me.halvingMinuteWhenInValue.Location = New System.Drawing.Point(216, 51)
        Me.halvingMinuteWhenInValue.Name = "halvingMinuteWhenInValue"
        Me.halvingMinuteWhenInValue.Size = New System.Drawing.Size(81, 21)
        Me.halvingMinuteWhenInValue.TabIndex = 30
        Me.halvingMinuteWhenInValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'halvingMinuteWhenInLabel
        '
        Me.halvingMinuteWhenInLabel.AutoSize = True
        Me.halvingMinuteWhenInLabel.Enabled = False
        Me.halvingMinuteWhenInLabel.Location = New System.Drawing.Point(70, 54)
        Me.halvingMinuteWhenInLabel.Name = "halvingMinuteWhenInLabel"
        Me.halvingMinuteWhenInLabel.Size = New System.Drawing.Size(140, 13)
        Me.halvingMinuteWhenInLabel.TabIndex = 29
        Me.halvingMinuteWhenInLabel.Text = "Halving minute when in"
        '
        'exploreBullrun
        '
        Me.exploreBullrun.AutoSize = True
        Me.exploreBullrun.Location = New System.Drawing.Point(216, 18)
        Me.exploreBullrun.Name = "exploreBullrun"
        Me.exploreBullrun.Size = New System.Drawing.Size(112, 17)
        Me.exploreBullrun.TabIndex = 28
        Me.exploreBullrun.Text = "Explore bullrun"
        Me.exploreBullrun.UseVisualStyleBackColor = True
        '
        'idValue
        '
        Me.idValue.Location = New System.Drawing.Point(78, 13)
        Me.idValue.Name = "idValue"
        Me.idValue.ReadOnly = True
        Me.idValue.Size = New System.Drawing.Size(590, 21)
        Me.idValue.TabIndex = 2
        '
        'createdValue
        '
        Me.createdValue.Location = New System.Drawing.Point(78, 40)
        Me.createdValue.Name = "createdValue"
        Me.createdValue.ReadOnly = True
        Me.createdValue.Size = New System.Drawing.Size(590, 21)
        Me.createdValue.TabIndex = 4
        '
        'createdLabel
        '
        Me.createdLabel.AutoSize = True
        Me.createdLabel.Location = New System.Drawing.Point(13, 43)
        Me.createdLabel.Name = "createdLabel"
        Me.createdLabel.Size = New System.Drawing.Size(53, 13)
        Me.createdLabel.TabIndex = 3
        Me.createdLabel.Text = "Created"
        '
        'isActiveValue
        '
        Me.isActiveValue.AutoSize = True
        Me.isActiveValue.Location = New System.Drawing.Point(78, 71)
        Me.isActiveValue.Name = "isActiveValue"
        Me.isActiveValue.Size = New System.Drawing.Size(75, 17)
        Me.isActiveValue.TabIndex = 5
        Me.isActiveValue.Text = "Is active"
        Me.isActiveValue.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(675, 12)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 44)
        Me.confirmButton.TabIndex = 6
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(678, 415)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 7
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'defaultButton
        '
        Me.defaultButton.Location = New System.Drawing.Point(678, 386)
        Me.defaultButton.Name = "defaultButton"
        Me.defaultButton.Size = New System.Drawing.Size(75, 23)
        Me.defaultButton.TabIndex = 8
        Me.defaultButton.Text = "Default"
        Me.defaultButton.UseVisualStyleBackColor = True
        '
        'SettingsBot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 447)
        Me.ControlBox = False
        Me.Controls.Add(Me.defaultButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.isActiveValue)
        Me.Controls.Add(Me.createdValue)
        Me.Controls.Add(Me.createdLabel)
        Me.Controls.Add(Me.idValue)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.idLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(778, 486)
        Me.MinimumSize = New System.Drawing.Size(778, 486)
        Me.Name = "SettingsBot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bot parameters"
        Me.tabMain.ResumeLayout(False)
        Me.fundConfigurationPage.ResumeLayout(False)
        Me.fundConfigurationPage.PerformLayout()
        Me.startPage.ResumeLayout(False)
        Me.startPage.PerformLayout()
        Me.dateStartGroupBox.ResumeLayout(False)
        Me.dateStartGroupBox.PerformLayout()
        Me.configuration.ResumeLayout(False)
        Me.configuration.PerformLayout()
        Me.acquisitionValue.ResumeLayout(False)
        Me.acquisitionValue.PerformLayout()
        Me.bearMarketPage.ResumeLayout(False)
        Me.bearMarketPage.PerformLayout()
        Me.bullRunPage.ResumeLayout(False)
        Me.bullRunPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents idLabel As Label
    Friend WithEvents tabMain As TabControl
    Friend WithEvents fundConfigurationPage As TabPage
    Friend WithEvents startPage As TabPage
    Friend WithEvents idValue As TextBox
    Friend WithEvents createdValue As TextBox
    Friend WithEvents createdLabel As Label
    Friend WithEvents isActiveValue As CheckBox
    Friend WithEvents unitStepValue As TextBox
    Friend WithEvents unitStepLabel As Label
    Friend WithEvents plafondValue As TextBox
    Friend WithEvents plafondLabel As Label
    Friend WithEvents pairIdValue As TextBox
    Friend WithEvents pairIdLabel As Label
    Friend WithEvents confirmButton As Button
#Disable Warning BC40004
    Friend WithEvents cancelButton As Button
#Enable Warning BC40004
    Friend WithEvents defaultButton As Button
    Friend WithEvents waitExamMinuteLabel As Label
    Friend WithEvents triggerValue As TextBox
    Friend WithEvents triggerLabel As Label
    Friend WithEvents minuteExamValue As TextBox
    Friend WithEvents minuteExamLabel As Label
    Friend WithEvents dateStartGroupBox As GroupBox
    Friend WithEvents gmtLabel As Label
    Friend WithEvents timeStartValue As DateTimePicker
    Friend WithEvents dateStartValue As DateTimePicker
    Friend WithEvents dateStartLabel As Label
    Friend WithEvents activeDateStartValue As CheckBox
    Friend WithEvents acquisitionValue As TabPage
    Friend WithEvents duringBottonBearMarketValue As CheckBox
    Friend WithEvents notInBearMarketValue As CheckBox
    Friend WithEvents onlyDealAcquireValue As CheckBox
    Friend WithEvents otherDealIntervalStep As Label
    Friend WithEvents dealIntervalValue As TextBox
    Friend WithEvents dealIntervalLabel As Label
    Friend WithEvents dealAcquireOnAcquireLabel As Label
    Friend WithEvents dealAcquireValue As TextBox
    Friend WithEvents dealAcquireLabel As Label
    Friend WithEvents otherStepIntervalLabel As Label
    Friend WithEvents stepIntervalValue As TextBox
    Friend WithEvents stepIntervalLabel As Label
    Friend WithEvents configuration As TabPage
    Friend WithEvents modeValue As ComboBox
    Friend WithEvents modeLabel As Label
    Friend WithEvents spreadValue As TextBox
    Friend WithEvents spreadLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents bearMarketPage As TabPage
    Friend WithEvents bullRunPage As TabPage
    Friend WithEvents saveFoundValue As CheckBox
    Friend WithEvents percentageSymbolLabel As Label
    Friend WithEvents degradePercentageValue As TextBox
    Friend WithEvents degradePercentageLabel As Label
    Friend WithEvents minuteSymbolObservationLabel As Label
    Friend WithEvents observationTimeBearMarketValue As TextBox
    Friend WithEvents observationTimeLabel As Label
    Friend WithEvents percentageSymbol3Label As Label
    Friend WithEvents maximumExposurePercentageValue As TextBox
    Friend WithEvents maximumExposurePercentageLabel As Label
    Friend WithEvents percentageSymbol2Label As Label
    Friend WithEvents bottomReboundPercentageValue As TextBox
    Friend WithEvents bottomReboundPercentageLabel As Label
    Friend WithEvents percentageSymbol6Label As Label
    Friend WithEvents topReboundPercentageValue As TextBox
    Friend WithEvents topReboundPercentageLabel As Label
    Friend WithEvents percentageSymbol5Label As Label
    Friend WithEvents increasePercentageBullRunValue As TextBox
    Friend WithEvents increasePercentageLabel As Label
    Friend WithEvents minute2Label As Label
    Friend WithEvents observationTimeValue As TextBox
    Friend WithEvents observationTimeBullRunLabel As Label
    Friend WithEvents percentageSymbol4Label As Label
    Friend WithEvents halvingPercentageValue As TextBox
    Friend WithEvents halvingPercentageLabel As Label
    Friend WithEvents minute1Label As Label
    Friend WithEvents halvingMinuteWhenInValue As TextBox
    Friend WithEvents halvingMinuteWhenInLabel As Label
    Friend WithEvents exploreBullrun As CheckBox
End Class
