<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutomaticBotSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutomaticBotSetting))
        Me.stateValue = New System.Windows.Forms.TextBox()
        Me.keyLabel = New System.Windows.Forms.Label()
        Me.actionButton = New System.Windows.Forms.Button()
        Me.saveDataButton = New System.Windows.Forms.Button()
        Me.plafondSingleProductValue = New System.Windows.Forms.TextBox()
        Me.plafondSinglePlafondLabel = New System.Windows.Forms.Label()
        Me.unitStepValue = New System.Windows.Forms.TextBox()
        Me.unitStepLabel = New System.Windows.Forms.Label()
        Me.minDailyEarnValue = New System.Windows.Forms.TextBox()
        Me.minDailyEarnLabel = New System.Windows.Forms.Label()
        Me.maxDailyEarnValue = New System.Windows.Forms.TextBox()
        Me.maxDailyEarnLabel = New System.Windows.Forms.Label()
        Me.dealRestockValue = New System.Windows.Forms.TextBox()
        Me.dealAcquirePercentageLabel = New System.Windows.Forms.Label()
        Me.earnConfigurationValue = New System.Windows.Forms.ComboBox()
        Me.earnConfigurationLabel = New System.Windows.Forms.Label()
        Me.backValue = New System.Windows.Forms.TextBox()
        Me.backLabel = New System.Windows.Forms.Label()
        Me.lastActivityValue = New System.Windows.Forms.TextBox()
        Me.lastActivityLabel = New System.Windows.Forms.Label()
        Me.plafondSingleProductCurrency = New System.Windows.Forms.Label()
        Me.unitStepCurrency = New System.Windows.Forms.Label()
        Me.minDailyEarnCurrency = New System.Windows.Forms.Label()
        Me.maxDailyEarnCurrency = New System.Windows.Forms.Label()
        Me.dealRestockCurrency = New System.Windows.Forms.Label()
        Me.backValueCurrency = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'stateValue
        '
        Me.stateValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stateValue.Location = New System.Drawing.Point(158, 268)
        Me.stateValue.Name = "stateValue"
        Me.stateValue.ReadOnly = True
        Me.stateValue.Size = New System.Drawing.Size(205, 21)
        Me.stateValue.TabIndex = 22
        Me.stateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'keyLabel
        '
        Me.keyLabel.AutoSize = True
        Me.keyLabel.Location = New System.Drawing.Point(115, 271)
        Me.keyLabel.Name = "keyLabel"
        Me.keyLabel.Size = New System.Drawing.Size(37, 13)
        Me.keyLabel.TabIndex = 23
        Me.keyLabel.Text = "State"
        '
        'actionButton
        '
        Me.actionButton.Location = New System.Drawing.Point(435, 278)
        Me.actionButton.Name = "actionButton"
        Me.actionButton.Size = New System.Drawing.Size(84, 38)
        Me.actionButton.TabIndex = 7
        Me.actionButton.Text = "START"
        Me.actionButton.UseVisualStyleBackColor = True
        '
        'saveDataButton
        '
        Me.saveDataButton.Location = New System.Drawing.Point(435, 25)
        Me.saveDataButton.Name = "saveDataButton"
        Me.saveDataButton.Size = New System.Drawing.Size(84, 38)
        Me.saveDataButton.TabIndex = 8
        Me.saveDataButton.Text = "Save data"
        Me.saveDataButton.UseVisualStyleBackColor = True
        '
        'plafondSingleProductValue
        '
        Me.plafondSingleProductValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plafondSingleProductValue.Location = New System.Drawing.Point(158, 25)
        Me.plafondSingleProductValue.Name = "plafondSingleProductValue"
        Me.plafondSingleProductValue.Size = New System.Drawing.Size(179, 21)
        Me.plafondSingleProductValue.TabIndex = 0
        Me.plafondSingleProductValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'plafondSinglePlafondLabel
        '
        Me.plafondSinglePlafondLabel.AutoSize = True
        Me.plafondSinglePlafondLabel.Location = New System.Drawing.Point(19, 28)
        Me.plafondSinglePlafondLabel.Name = "plafondSinglePlafondLabel"
        Me.plafondSinglePlafondLabel.Size = New System.Drawing.Size(133, 13)
        Me.plafondSinglePlafondLabel.TabIndex = 27
        Me.plafondSinglePlafondLabel.Text = "Plafond single product"
        '
        'unitStepValue
        '
        Me.unitStepValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitStepValue.Location = New System.Drawing.Point(158, 52)
        Me.unitStepValue.Name = "unitStepValue"
        Me.unitStepValue.Size = New System.Drawing.Size(179, 21)
        Me.unitStepValue.TabIndex = 1
        Me.unitStepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'unitStepLabel
        '
        Me.unitStepLabel.AutoSize = True
        Me.unitStepLabel.Location = New System.Drawing.Point(95, 55)
        Me.unitStepLabel.Name = "unitStepLabel"
        Me.unitStepLabel.Size = New System.Drawing.Size(57, 13)
        Me.unitStepLabel.TabIndex = 29
        Me.unitStepLabel.Text = "Unit step"
        '
        'minDailyEarnValue
        '
        Me.minDailyEarnValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minDailyEarnValue.Location = New System.Drawing.Point(158, 93)
        Me.minDailyEarnValue.Name = "minDailyEarnValue"
        Me.minDailyEarnValue.Size = New System.Drawing.Size(179, 21)
        Me.minDailyEarnValue.TabIndex = 2
        Me.minDailyEarnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'minDailyEarnLabel
        '
        Me.minDailyEarnLabel.AutoSize = True
        Me.minDailyEarnLabel.Location = New System.Drawing.Point(59, 96)
        Me.minDailyEarnLabel.Name = "minDailyEarnLabel"
        Me.minDailyEarnLabel.Size = New System.Drawing.Size(93, 13)
        Me.minDailyEarnLabel.TabIndex = 31
        Me.minDailyEarnLabel.Text = "Min. Daily Earn"
        '
        'maxDailyEarnValue
        '
        Me.maxDailyEarnValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxDailyEarnValue.Location = New System.Drawing.Point(158, 120)
        Me.maxDailyEarnValue.Name = "maxDailyEarnValue"
        Me.maxDailyEarnValue.Size = New System.Drawing.Size(179, 21)
        Me.maxDailyEarnValue.TabIndex = 3
        Me.maxDailyEarnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'maxDailyEarnLabel
        '
        Me.maxDailyEarnLabel.AutoSize = True
        Me.maxDailyEarnLabel.Location = New System.Drawing.Point(59, 123)
        Me.maxDailyEarnLabel.Name = "maxDailyEarnLabel"
        Me.maxDailyEarnLabel.Size = New System.Drawing.Size(93, 13)
        Me.maxDailyEarnLabel.TabIndex = 33
        Me.maxDailyEarnLabel.Text = "Max Daily Earn"
        '
        'dealRestockValue
        '
        Me.dealRestockValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dealRestockValue.Location = New System.Drawing.Point(158, 158)
        Me.dealRestockValue.Name = "dealRestockValue"
        Me.dealRestockValue.Size = New System.Drawing.Size(179, 21)
        Me.dealRestockValue.TabIndex = 4
        Me.dealRestockValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dealAcquirePercentageLabel
        '
        Me.dealAcquirePercentageLabel.AutoSize = True
        Me.dealAcquirePercentageLabel.Location = New System.Drawing.Point(72, 161)
        Me.dealAcquirePercentageLabel.Name = "dealAcquirePercentageLabel"
        Me.dealAcquirePercentageLabel.Size = New System.Drawing.Size(82, 13)
        Me.dealAcquirePercentageLabel.TabIndex = 35
        Me.dealAcquirePercentageLabel.Text = "Deal Restock"
        '
        'earnConfigurationValue
        '
        Me.earnConfigurationValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.earnConfigurationValue.FormattingEnabled = True
        Me.earnConfigurationValue.Items.AddRange(New Object() {"Restock entire amount", "Back entire amount", "Back fix amount", "Back percentage amount"})
        Me.earnConfigurationValue.Location = New System.Drawing.Point(158, 203)
        Me.earnConfigurationValue.Name = "earnConfigurationValue"
        Me.earnConfigurationValue.Size = New System.Drawing.Size(179, 21)
        Me.earnConfigurationValue.TabIndex = 5
        '
        'earnConfigurationLabel
        '
        Me.earnConfigurationLabel.AutoSize = True
        Me.earnConfigurationLabel.Location = New System.Drawing.Point(41, 206)
        Me.earnConfigurationLabel.Name = "earnConfigurationLabel"
        Me.earnConfigurationLabel.Size = New System.Drawing.Size(111, 13)
        Me.earnConfigurationLabel.TabIndex = 36
        Me.earnConfigurationLabel.Text = "Earn configuration"
        '
        'backValue
        '
        Me.backValue.Enabled = False
        Me.backValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.backValue.Location = New System.Drawing.Point(158, 230)
        Me.backValue.Name = "backValue"
        Me.backValue.Size = New System.Drawing.Size(179, 21)
        Me.backValue.TabIndex = 6
        Me.backValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'backLabel
        '
        Me.backLabel.AutoSize = True
        Me.backLabel.Enabled = False
        Me.backLabel.Location = New System.Drawing.Point(82, 233)
        Me.backLabel.Name = "backLabel"
        Me.backLabel.Size = New System.Drawing.Size(70, 13)
        Me.backLabel.TabIndex = 39
        Me.backLabel.Text = "Back value"
        '
        'lastActivityValue
        '
        Me.lastActivityValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastActivityValue.Location = New System.Drawing.Point(158, 295)
        Me.lastActivityValue.Name = "lastActivityValue"
        Me.lastActivityValue.ReadOnly = True
        Me.lastActivityValue.Size = New System.Drawing.Size(205, 21)
        Me.lastActivityValue.TabIndex = 40
        Me.lastActivityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lastActivityLabel
        '
        Me.lastActivityLabel.AutoSize = True
        Me.lastActivityLabel.Location = New System.Drawing.Point(77, 298)
        Me.lastActivityLabel.Name = "lastActivityLabel"
        Me.lastActivityLabel.Size = New System.Drawing.Size(75, 13)
        Me.lastActivityLabel.TabIndex = 41
        Me.lastActivityLabel.Text = "Last activity"
        '
        'plafondSingleProductCurrency
        '
        Me.plafondSingleProductCurrency.AutoSize = True
        Me.plafondSingleProductCurrency.Location = New System.Drawing.Point(343, 28)
        Me.plafondSingleProductCurrency.Name = "plafondSingleProductCurrency"
        Me.plafondSingleProductCurrency.Size = New System.Drawing.Size(39, 13)
        Me.plafondSingleProductCurrency.TabIndex = 42
        Me.plafondSingleProductCurrency.Text = "USDT"
        '
        'unitStepCurrency
        '
        Me.unitStepCurrency.AutoSize = True
        Me.unitStepCurrency.Location = New System.Drawing.Point(343, 55)
        Me.unitStepCurrency.Name = "unitStepCurrency"
        Me.unitStepCurrency.Size = New System.Drawing.Size(39, 13)
        Me.unitStepCurrency.TabIndex = 43
        Me.unitStepCurrency.Text = "USDT"
        '
        'minDailyEarnCurrency
        '
        Me.minDailyEarnCurrency.AutoSize = True
        Me.minDailyEarnCurrency.Location = New System.Drawing.Point(343, 96)
        Me.minDailyEarnCurrency.Name = "minDailyEarnCurrency"
        Me.minDailyEarnCurrency.Size = New System.Drawing.Size(19, 13)
        Me.minDailyEarnCurrency.TabIndex = 44
        Me.minDailyEarnCurrency.Text = "%"
        '
        'maxDailyEarnCurrency
        '
        Me.maxDailyEarnCurrency.AutoSize = True
        Me.maxDailyEarnCurrency.Location = New System.Drawing.Point(343, 123)
        Me.maxDailyEarnCurrency.Name = "maxDailyEarnCurrency"
        Me.maxDailyEarnCurrency.Size = New System.Drawing.Size(19, 13)
        Me.maxDailyEarnCurrency.TabIndex = 45
        Me.maxDailyEarnCurrency.Text = "%"
        '
        'dealRestockCurrency
        '
        Me.dealRestockCurrency.AutoSize = True
        Me.dealRestockCurrency.Location = New System.Drawing.Point(343, 161)
        Me.dealRestockCurrency.Name = "dealRestockCurrency"
        Me.dealRestockCurrency.Size = New System.Drawing.Size(19, 13)
        Me.dealRestockCurrency.TabIndex = 46
        Me.dealRestockCurrency.Text = "%"
        '
        'backValueCurrency
        '
        Me.backValueCurrency.AutoSize = True
        Me.backValueCurrency.Enabled = False
        Me.backValueCurrency.Location = New System.Drawing.Point(343, 233)
        Me.backValueCurrency.Name = "backValueCurrency"
        Me.backValueCurrency.Size = New System.Drawing.Size(0, 13)
        Me.backValueCurrency.TabIndex = 47
        '
        'AutomaticBotSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 330)
        Me.Controls.Add(Me.backValueCurrency)
        Me.Controls.Add(Me.dealRestockCurrency)
        Me.Controls.Add(Me.maxDailyEarnCurrency)
        Me.Controls.Add(Me.minDailyEarnCurrency)
        Me.Controls.Add(Me.unitStepCurrency)
        Me.Controls.Add(Me.plafondSingleProductCurrency)
        Me.Controls.Add(Me.lastActivityValue)
        Me.Controls.Add(Me.lastActivityLabel)
        Me.Controls.Add(Me.backValue)
        Me.Controls.Add(Me.backLabel)
        Me.Controls.Add(Me.earnConfigurationValue)
        Me.Controls.Add(Me.earnConfigurationLabel)
        Me.Controls.Add(Me.dealRestockValue)
        Me.Controls.Add(Me.dealAcquirePercentageLabel)
        Me.Controls.Add(Me.maxDailyEarnValue)
        Me.Controls.Add(Me.maxDailyEarnLabel)
        Me.Controls.Add(Me.minDailyEarnValue)
        Me.Controls.Add(Me.minDailyEarnLabel)
        Me.Controls.Add(Me.unitStepValue)
        Me.Controls.Add(Me.unitStepLabel)
        Me.Controls.Add(Me.plafondSingleProductValue)
        Me.Controls.Add(Me.plafondSinglePlafondLabel)
        Me.Controls.Add(Me.saveDataButton)
        Me.Controls.Add(Me.actionButton)
        Me.Controls.Add(Me.stateValue)
        Me.Controls.Add(Me.keyLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutomaticBotSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Automatic Bot Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stateValue As TextBox
    Friend WithEvents keyLabel As Label
    Friend WithEvents actionButton As Button
    Friend WithEvents saveDataButton As Button
    Friend WithEvents plafondSingleProductValue As TextBox
    Friend WithEvents plafondSinglePlafondLabel As Label
    Friend WithEvents unitStepValue As TextBox
    Friend WithEvents unitStepLabel As Label
    Friend WithEvents minDailyEarnValue As TextBox
    Friend WithEvents minDailyEarnLabel As Label
    Friend WithEvents maxDailyEarnValue As TextBox
    Friend WithEvents maxDailyEarnLabel As Label
    Friend WithEvents dealRestockValue As TextBox
    Friend WithEvents dealAcquirePercentageLabel As Label
    Friend WithEvents earnConfigurationValue As ComboBox
    Friend WithEvents earnConfigurationLabel As Label
    Friend WithEvents backValue As TextBox
    Friend WithEvents backLabel As Label
    Friend WithEvents lastActivityValue As TextBox
    Friend WithEvents lastActivityLabel As Label
    Friend WithEvents plafondSingleProductCurrency As Label
    Friend WithEvents unitStepCurrency As Label
    Friend WithEvents minDailyEarnCurrency As Label
    Friend WithEvents maxDailyEarnCurrency As Label
    Friend WithEvents dealRestockCurrency As Label
    Friend WithEvents backValueCurrency As Label
End Class
