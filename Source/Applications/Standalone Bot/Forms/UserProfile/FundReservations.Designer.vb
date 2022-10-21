<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FundReservations
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
        Me.currentLockedValue = New System.Windows.Forms.TextBox()
        Me.currentLockedLabel = New System.Windows.Forms.Label()
        Me.actionGroup = New System.Windows.Forms.GroupBox()
        Me.onlyInEarnValue = New System.Windows.Forms.CheckBox()
        Me.targetValue = New System.Windows.Forms.TextBox()
        Me.targetLabel = New System.Windows.Forms.Label()
        Me.bankCurrencyValue = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.targetDayValue = New System.Windows.Forms.TextBox()
        Me.targetDayLabel = New System.Windows.Forms.Label()
        Me.modeValue = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.userDayStartValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.actionGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'currentLockedValue
        '
        Me.currentLockedValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentLockedValue.Location = New System.Drawing.Point(140, 39)
        Me.currentLockedValue.Name = "currentLockedValue"
        Me.currentLockedValue.ReadOnly = True
        Me.currentLockedValue.Size = New System.Drawing.Size(116, 21)
        Me.currentLockedValue.TabIndex = 3
        Me.currentLockedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'currentLockedLabel
        '
        Me.currentLockedLabel.AutoSize = True
        Me.currentLockedLabel.Location = New System.Drawing.Point(39, 42)
        Me.currentLockedLabel.Name = "currentLockedLabel"
        Me.currentLockedLabel.Size = New System.Drawing.Size(95, 13)
        Me.currentLockedLabel.TabIndex = 23
        Me.currentLockedLabel.Text = "Current Locked"
        '
        'actionGroup
        '
        Me.actionGroup.Controls.Add(Me.onlyInEarnValue)
        Me.actionGroup.Controls.Add(Me.targetValue)
        Me.actionGroup.Controls.Add(Me.targetLabel)
        Me.actionGroup.Controls.Add(Me.bankCurrencyValue)
        Me.actionGroup.Controls.Add(Me.Label5)
        Me.actionGroup.Controls.Add(Me.targetDayValue)
        Me.actionGroup.Controls.Add(Me.targetDayLabel)
        Me.actionGroup.Controls.Add(Me.modeValue)
        Me.actionGroup.Controls.Add(Me.Label2)
        Me.actionGroup.Location = New System.Drawing.Point(30, 66)
        Me.actionGroup.Name = "actionGroup"
        Me.actionGroup.Size = New System.Drawing.Size(314, 184)
        Me.actionGroup.TabIndex = 0
        Me.actionGroup.TabStop = False
        Me.actionGroup.Text = "Action"
        '
        'onlyInEarnValue
        '
        Me.onlyInEarnValue.AutoSize = True
        Me.onlyInEarnValue.Enabled = False
        Me.onlyInEarnValue.Location = New System.Drawing.Point(110, 137)
        Me.onlyInEarnValue.Name = "onlyInEarnValue"
        Me.onlyInEarnValue.Size = New System.Drawing.Size(96, 17)
        Me.onlyInEarnValue.TabIndex = 4
        Me.onlyInEarnValue.Text = "Only in earn"
        Me.onlyInEarnValue.UseVisualStyleBackColor = True
        '
        'targetValue
        '
        Me.targetValue.Enabled = False
        Me.targetValue.Location = New System.Drawing.Point(110, 109)
        Me.targetValue.Name = "targetValue"
        Me.targetValue.Size = New System.Drawing.Size(66, 21)
        Me.targetValue.TabIndex = 3
        Me.targetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'targetLabel
        '
        Me.targetLabel.AutoSize = True
        Me.targetLabel.Enabled = False
        Me.targetLabel.Location = New System.Drawing.Point(26, 112)
        Me.targetLabel.Name = "targetLabel"
        Me.targetLabel.Size = New System.Drawing.Size(78, 13)
        Me.targetLabel.TabIndex = 6
        Me.targetLabel.Text = "Target value"
        '
        'bankCurrencyValue
        '
        Me.bankCurrencyValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bankCurrencyValue.Location = New System.Drawing.Point(110, 28)
        Me.bankCurrencyValue.Name = "bankCurrencyValue"
        Me.bankCurrencyValue.Size = New System.Drawing.Size(66, 21)
        Me.bankCurrencyValue.TabIndex = 0
        Me.bankCurrencyValue.Text = "USD"
        Me.bankCurrencyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Gain currency"
        '
        'targetDayValue
        '
        Me.targetDayValue.Enabled = False
        Me.targetDayValue.Location = New System.Drawing.Point(110, 82)
        Me.targetDayValue.Name = "targetDayValue"
        Me.targetDayValue.Size = New System.Drawing.Size(66, 21)
        Me.targetDayValue.TabIndex = 2
        Me.targetDayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'targetDayLabel
        '
        Me.targetDayLabel.AutoSize = True
        Me.targetDayLabel.Enabled = False
        Me.targetDayLabel.Location = New System.Drawing.Point(34, 85)
        Me.targetDayLabel.Name = "targetDayLabel"
        Me.targetDayLabel.Size = New System.Drawing.Size(70, 13)
        Me.targetDayLabel.TabIndex = 2
        Me.targetDayLabel.Text = "Target Day"
        '
        'modeValue
        '
        Me.modeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.modeValue.FormattingEnabled = True
        Me.modeValue.Items.AddRange(New Object() {"All now", "Urgent", "Immediate", "Booking"})
        Me.modeValue.Location = New System.Drawing.Point(110, 55)
        Me.modeValue.Name = "modeValue"
        Me.modeValue.Size = New System.Drawing.Size(191, 21)
        Me.modeValue.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mode"
        '
        'userDayStartValue
        '
        Me.userDayStartValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userDayStartValue.Location = New System.Drawing.Point(140, 12)
        Me.userDayStartValue.Name = "userDayStartValue"
        Me.userDayStartValue.ReadOnly = True
        Me.userDayStartValue.Size = New System.Drawing.Size(116, 21)
        Me.userDayStartValue.TabIndex = 2
        Me.userDayStartValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Day Start"
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(269, 256)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 23)
        Me.confirmButton.TabIndex = 1
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'FundReservations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 290)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.userDayStartValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.actionGroup)
        Me.Controls.Add(Me.currentLockedValue)
        Me.Controls.Add(Me.currentLockedLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FundReservations"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fund Reservations"
        Me.actionGroup.ResumeLayout(False)
        Me.actionGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents currentLockedValue As TextBox
    Friend WithEvents currentLockedLabel As Label
    Friend WithEvents actionGroup As GroupBox
    Friend WithEvents bankCurrencyValue As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents targetDayValue As TextBox
    Friend WithEvents targetDayLabel As Label
    Friend WithEvents modeValue As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents userDayStartValue As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents confirmButton As Button
    Friend WithEvents targetValue As TextBox
    Friend WithEvents targetLabel As Label
    Friend WithEvents onlyInEarnValue As CheckBox
End Class
