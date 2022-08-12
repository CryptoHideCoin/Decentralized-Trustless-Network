<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataBot
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataBot))
        Me.mainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.mainTab = New System.Windows.Forms.TabPage()
        Me.lastBuyValue = New System.Windows.Forms.TextBox()
        Me.lastBuyValueLabel = New System.Windows.Forms.Label()
        Me.lastBuyTimeValue = New System.Windows.Forms.TextBox()
        Me.lastBuyTimeLabel = New System.Windows.Forms.Label()
        Me.earnValue = New System.Windows.Forms.TextBox()
        Me.earnLabel = New System.Windows.Forms.Label()
        Me.plafondValue = New System.Windows.Forms.TextBox()
        Me.plafondLabel = New System.Windows.Forms.Label()
        Me.timeStartValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bootstrapCompleteValue = New System.Windows.Forms.CheckBox()
        Me.bootstrapInitialValue = New System.Windows.Forms.CheckBox()
        Me.examLimitValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pairValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.idValue = New System.Windows.Forms.TextBox()
        Me.idLabel = New System.Windows.Forms.Label()
        Me.tradePage = New System.Windows.Forms.TabPage()
        Me.tradeOpenedDataView = New System.Windows.Forms.DataGridView()
        Me.Acquire = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dismiss = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.viewButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.closedPage = New System.Windows.Forms.TabPage()
        Me.tradeClosedDataView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabControl1.SuspendLayout()
        Me.mainTab.SuspendLayout()
        Me.tradePage.SuspendLayout()
        CType(Me.tradeOpenedDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.closedPage.SuspendLayout()
        CType(Me.tradeClosedDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainTimer
        '
        Me.mainTimer.Enabled = True
        Me.mainTimer.Interval = 1000
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.mainTab)
        Me.TabControl1.Controls.Add(Me.tradePage)
        Me.TabControl1.Controls.Add(Me.closedPage)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(594, 297)
        Me.TabControl1.TabIndex = 0
        '
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.lastBuyValue)
        Me.mainTab.Controls.Add(Me.lastBuyValueLabel)
        Me.mainTab.Controls.Add(Me.lastBuyTimeValue)
        Me.mainTab.Controls.Add(Me.lastBuyTimeLabel)
        Me.mainTab.Controls.Add(Me.earnValue)
        Me.mainTab.Controls.Add(Me.earnLabel)
        Me.mainTab.Controls.Add(Me.plafondValue)
        Me.mainTab.Controls.Add(Me.plafondLabel)
        Me.mainTab.Controls.Add(Me.timeStartValue)
        Me.mainTab.Controls.Add(Me.Label3)
        Me.mainTab.Controls.Add(Me.bootstrapCompleteValue)
        Me.mainTab.Controls.Add(Me.bootstrapInitialValue)
        Me.mainTab.Controls.Add(Me.examLimitValue)
        Me.mainTab.Controls.Add(Me.Label2)
        Me.mainTab.Controls.Add(Me.pairValue)
        Me.mainTab.Controls.Add(Me.Label1)
        Me.mainTab.Controls.Add(Me.idValue)
        Me.mainTab.Controls.Add(Me.idLabel)
        Me.mainTab.Location = New System.Drawing.Point(4, 22)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.Padding = New System.Windows.Forms.Padding(3)
        Me.mainTab.Size = New System.Drawing.Size(586, 271)
        Me.mainTab.TabIndex = 0
        Me.mainTab.Text = "Main"
        Me.mainTab.UseVisualStyleBackColor = True
        '
        'lastBuyValue
        '
        Me.lastBuyValue.Location = New System.Drawing.Point(107, 230)
        Me.lastBuyValue.Name = "lastBuyValue"
        Me.lastBuyValue.ReadOnly = True
        Me.lastBuyValue.Size = New System.Drawing.Size(457, 21)
        Me.lastBuyValue.TabIndex = 38
        Me.lastBuyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lastBuyValueLabel
        '
        Me.lastBuyValueLabel.AutoSize = True
        Me.lastBuyValueLabel.Location = New System.Drawing.Point(11, 233)
        Me.lastBuyValueLabel.Name = "lastBuyValueLabel"
        Me.lastBuyValueLabel.Size = New System.Drawing.Size(90, 13)
        Me.lastBuyValueLabel.TabIndex = 37
        Me.lastBuyValueLabel.Text = "Last buy value"
        '
        'lastBuyTimeValue
        '
        Me.lastBuyTimeValue.Location = New System.Drawing.Point(107, 203)
        Me.lastBuyTimeValue.Name = "lastBuyTimeValue"
        Me.lastBuyTimeValue.ReadOnly = True
        Me.lastBuyTimeValue.Size = New System.Drawing.Size(457, 21)
        Me.lastBuyTimeValue.TabIndex = 36
        Me.lastBuyTimeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lastBuyTimeLabel
        '
        Me.lastBuyTimeLabel.AutoSize = True
        Me.lastBuyTimeLabel.Location = New System.Drawing.Point(17, 206)
        Me.lastBuyTimeLabel.Name = "lastBuyTimeLabel"
        Me.lastBuyTimeLabel.Size = New System.Drawing.Size(84, 13)
        Me.lastBuyTimeLabel.TabIndex = 35
        Me.lastBuyTimeLabel.Text = "Last buy time"
        '
        'earnValue
        '
        Me.earnValue.Location = New System.Drawing.Point(107, 176)
        Me.earnValue.Name = "earnValue"
        Me.earnValue.ReadOnly = True
        Me.earnValue.Size = New System.Drawing.Size(457, 21)
        Me.earnValue.TabIndex = 34
        Me.earnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'earnLabel
        '
        Me.earnLabel.AutoSize = True
        Me.earnLabel.Location = New System.Drawing.Point(68, 179)
        Me.earnLabel.Name = "earnLabel"
        Me.earnLabel.Size = New System.Drawing.Size(33, 13)
        Me.earnLabel.TabIndex = 33
        Me.earnLabel.Text = "Earn"
        '
        'plafondValue
        '
        Me.plafondValue.Location = New System.Drawing.Point(107, 149)
        Me.plafondValue.Name = "plafondValue"
        Me.plafondValue.ReadOnly = True
        Me.plafondValue.Size = New System.Drawing.Size(457, 21)
        Me.plafondValue.TabIndex = 32
        Me.plafondValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'plafondLabel
        '
        Me.plafondLabel.AutoSize = True
        Me.plafondLabel.Location = New System.Drawing.Point(20, 152)
        Me.plafondLabel.Name = "plafondLabel"
        Me.plafondLabel.Size = New System.Drawing.Size(81, 13)
        Me.plafondLabel.TabIndex = 31
        Me.plafondLabel.Text = "Used Plafond"
        '
        'timeStartValue
        '
        Me.timeStartValue.Location = New System.Drawing.Point(107, 122)
        Me.timeStartValue.Name = "timeStartValue"
        Me.timeStartValue.ReadOnly = True
        Me.timeStartValue.Size = New System.Drawing.Size(457, 21)
        Me.timeStartValue.TabIndex = 30
        Me.timeStartValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Time start"
        '
        'bootstrapCompleteValue
        '
        Me.bootstrapCompleteValue.AutoSize = True
        Me.bootstrapCompleteValue.Enabled = False
        Me.bootstrapCompleteValue.Location = New System.Drawing.Point(316, 72)
        Me.bootstrapCompleteValue.Name = "bootstrapCompleteValue"
        Me.bootstrapCompleteValue.Size = New System.Drawing.Size(130, 17)
        Me.bootstrapCompleteValue.TabIndex = 28
        Me.bootstrapCompleteValue.Text = "Botstrap complete"
        Me.bootstrapCompleteValue.UseVisualStyleBackColor = True
        '
        'bootstrapInitialValue
        '
        Me.bootstrapInitialValue.AutoSize = True
        Me.bootstrapInitialValue.Enabled = False
        Me.bootstrapInitialValue.Location = New System.Drawing.Point(107, 72)
        Me.bootstrapInitialValue.Name = "bootstrapInitialValue"
        Me.bootstrapInitialValue.Size = New System.Drawing.Size(115, 17)
        Me.bootstrapInitialValue.TabIndex = 27
        Me.bootstrapInitialValue.Text = "Bootstrap initial"
        Me.bootstrapInitialValue.UseVisualStyleBackColor = True
        '
        'examLimitValue
        '
        Me.examLimitValue.Location = New System.Drawing.Point(107, 95)
        Me.examLimitValue.Name = "examLimitValue"
        Me.examLimitValue.ReadOnly = True
        Me.examLimitValue.Size = New System.Drawing.Size(457, 21)
        Me.examLimitValue.TabIndex = 26
        Me.examLimitValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Exam Limit"
        '
        'pairValue
        '
        Me.pairValue.Location = New System.Drawing.Point(107, 44)
        Me.pairValue.Name = "pairValue"
        Me.pairValue.ReadOnly = True
        Me.pairValue.Size = New System.Drawing.Size(457, 21)
        Me.pairValue.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Pair"
        '
        'idValue
        '
        Me.idValue.Location = New System.Drawing.Point(107, 17)
        Me.idValue.Name = "idValue"
        Me.idValue.ReadOnly = True
        Me.idValue.Size = New System.Drawing.Size(457, 21)
        Me.idValue.TabIndex = 22
        '
        'idLabel
        '
        Me.idLabel.AutoSize = True
        Me.idLabel.Location = New System.Drawing.Point(80, 20)
        Me.idLabel.Name = "idLabel"
        Me.idLabel.Size = New System.Drawing.Size(21, 13)
        Me.idLabel.TabIndex = 21
        Me.idLabel.Text = "ID"
        '
        'tradePage
        '
        Me.tradePage.Controls.Add(Me.tradeOpenedDataView)
        Me.tradePage.Location = New System.Drawing.Point(4, 22)
        Me.tradePage.Name = "tradePage"
        Me.tradePage.Padding = New System.Windows.Forms.Padding(3)
        Me.tradePage.Size = New System.Drawing.Size(586, 271)
        Me.tradePage.TabIndex = 1
        Me.tradePage.Text = "Trade opened"
        Me.tradePage.UseVisualStyleBackColor = True
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
        Me.tradeOpenedDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Acquire, Me.Dismiss, Me.viewButton})
        Me.tradeOpenedDataView.Location = New System.Drawing.Point(0, 0)
        Me.tradeOpenedDataView.MultiSelect = False
        Me.tradeOpenedDataView.Name = "tradeOpenedDataView"
        Me.tradeOpenedDataView.RowHeadersVisible = False
        Me.tradeOpenedDataView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tradeOpenedDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tradeOpenedDataView.Size = New System.Drawing.Size(584, 271)
        Me.tradeOpenedDataView.TabIndex = 4
        '
        'Acquire
        '
        Me.Acquire.HeaderText = "Acquire"
        Me.Acquire.Name = "Acquire"
        Me.Acquire.Width = 255
        '
        'Dismiss
        '
        Me.Dismiss.HeaderText = "Dismiss"
        Me.Dismiss.Name = "Dismiss"
        Me.Dismiss.Width = 255
        '
        'viewButton
        '
        Me.viewButton.HeaderText = "View"
        Me.viewButton.Name = "viewButton"
        Me.viewButton.Text = "..."
        Me.viewButton.UseColumnTextForButtonValue = True
        Me.viewButton.Width = 50
        '
        'closedPage
        '
        Me.closedPage.Controls.Add(Me.tradeClosedDataView)
        Me.closedPage.Location = New System.Drawing.Point(4, 22)
        Me.closedPage.Name = "closedPage"
        Me.closedPage.Size = New System.Drawing.Size(586, 271)
        Me.closedPage.TabIndex = 2
        Me.closedPage.Text = "Trade closed"
        Me.closedPage.UseVisualStyleBackColor = True
        '
        'tradeClosedDataView
        '
        Me.tradeClosedDataView.AllowUserToAddRows = False
        Me.tradeClosedDataView.AllowUserToDeleteRows = False
        Me.tradeClosedDataView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tradeClosedDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.tradeClosedDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tradeClosedDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewButtonColumn1})
        Me.tradeClosedDataView.Location = New System.Drawing.Point(0, 0)
        Me.tradeClosedDataView.MultiSelect = False
        Me.tradeClosedDataView.Name = "tradeClosedDataView"
        Me.tradeClosedDataView.RowHeadersVisible = False
        Me.tradeClosedDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tradeClosedDataView.Size = New System.Drawing.Size(584, 271)
        Me.tradeClosedDataView.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Acquire"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 225
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Dismiss"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 225
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.HeaderText = "View"
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.Text = "..."
        '
        'DataBot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 319)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(628, 358)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(628, 358)
        Me.Name = "DataBot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monitor selected Bot data"
        Me.TabControl1.ResumeLayout(False)
        Me.mainTab.ResumeLayout(False)
        Me.mainTab.PerformLayout()
        Me.tradePage.ResumeLayout(False)
        CType(Me.tradeOpenedDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.closedPage.ResumeLayout(False)
        CType(Me.tradeClosedDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mainTimer As Timer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents mainTab As TabPage
    Friend WithEvents lastBuyValue As TextBox
    Friend WithEvents lastBuyValueLabel As Label
    Friend WithEvents lastBuyTimeValue As TextBox
    Friend WithEvents lastBuyTimeLabel As Label
    Friend WithEvents earnValue As TextBox
    Friend WithEvents earnLabel As Label
    Friend WithEvents plafondValue As TextBox
    Friend WithEvents plafondLabel As Label
    Friend WithEvents timeStartValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents bootstrapCompleteValue As CheckBox
    Friend WithEvents bootstrapInitialValue As CheckBox
    Friend WithEvents examLimitValue As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pairValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents idValue As TextBox
    Friend WithEvents idLabel As Label
    Friend WithEvents tradePage As TabPage
    Friend WithEvents closedPage As TabPage
    Friend WithEvents tradeOpenedDataView As DataGridView
    Friend WithEvents tradeClosedDataView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents Acquire As DataGridViewTextBoxColumn
    Friend WithEvents Dismiss As DataGridViewTextBoxColumn
    Friend WithEvents viewButton As DataGridViewButtonColumn
End Class
