<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RefundPlanDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RefundPlanDetail))
        Me.recipientLabel = New System.Windows.Forms.Label()
        Me.recipientText = New System.Windows.Forms.TextBox()
        Me.descriptionText = New System.Windows.Forms.TextBox()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.modeGroup = New System.Windows.Forms.GroupBox()
        Me.fixOption = New System.Windows.Forms.RadioButton()
        Me.percentageOption = New System.Windows.Forms.RadioButton()
        Me.valueLabel = New System.Windows.Forms.Label()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.valueText = New CHCSupportUIControls.NumericText()
        Me.modeGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'recipientLabel
        '
        Me.recipientLabel.AutoSize = True
        Me.recipientLabel.Location = New System.Drawing.Point(30, 13)
        Me.recipientLabel.Name = "recipientLabel"
        Me.recipientLabel.Size = New System.Drawing.Size(59, 13)
        Me.recipientLabel.TabIndex = 0
        Me.recipientLabel.Text = "Recipient"
        '
        'recipientText
        '
        Me.recipientText.Location = New System.Drawing.Point(34, 30)
        Me.recipientText.Name = "recipientText"
        Me.recipientText.Size = New System.Drawing.Size(496, 21)
        Me.recipientText.TabIndex = 1
        '
        'descriptionText
        '
        Me.descriptionText.Location = New System.Drawing.Point(34, 74)
        Me.descriptionText.Multiline = True
        Me.descriptionText.Name = "descriptionText"
        Me.descriptionText.Size = New System.Drawing.Size(496, 73)
        Me.descriptionText.TabIndex = 3
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Location = New System.Drawing.Point(30, 57)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(71, 13)
        Me.descriptionLabel.TabIndex = 2
        Me.descriptionLabel.Text = "Description"
        '
        'modeGroup
        '
        Me.modeGroup.Controls.Add(Me.fixOption)
        Me.modeGroup.Controls.Add(Me.percentageOption)
        Me.modeGroup.Location = New System.Drawing.Point(34, 162)
        Me.modeGroup.Name = "modeGroup"
        Me.modeGroup.Size = New System.Drawing.Size(146, 118)
        Me.modeGroup.TabIndex = 4
        Me.modeGroup.TabStop = False
        Me.modeGroup.Text = "Mode"
        '
        'fixOption
        '
        Me.fixOption.AutoSize = True
        Me.fixOption.Location = New System.Drawing.Point(28, 71)
        Me.fixOption.Name = "fixOption"
        Me.fixOption.Size = New System.Drawing.Size(41, 17)
        Me.fixOption.TabIndex = 1
        Me.fixOption.TabStop = True
        Me.fixOption.Text = "Fix"
        Me.fixOption.UseVisualStyleBackColor = True
        '
        'percentageOption
        '
        Me.percentageOption.AutoSize = True
        Me.percentageOption.Location = New System.Drawing.Point(28, 30)
        Me.percentageOption.Name = "percentageOption"
        Me.percentageOption.Size = New System.Drawing.Size(89, 17)
        Me.percentageOption.TabIndex = 0
        Me.percentageOption.TabStop = True
        Me.percentageOption.Text = "Percentage"
        Me.percentageOption.UseVisualStyleBackColor = True
        '
        'valueLabel
        '
        Me.valueLabel.AutoSize = True
        Me.valueLabel.Location = New System.Drawing.Point(202, 163)
        Me.valueLabel.Name = "valueLabel"
        Me.valueLabel.Size = New System.Drawing.Size(38, 13)
        Me.valueLabel.TabIndex = 5
        Me.valueLabel.Text = "Value"
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(374, 243)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 37)
        Me.confirmButton.TabIndex = 8
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(455, 243)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 37)
        Me.cancelButton.TabIndex = 9
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'valueText
        '
        Me.valueText.currentFormat = "0,000"
        Me.valueText.Location = New System.Drawing.Point(205, 179)
        Me.valueText.locationCode = "it-IT"
        Me.valueText.Name = "valueText"
        Me.valueText.Size = New System.Drawing.Size(104, 21)
        Me.valueText.TabIndex = 7
        Me.valueText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.valueText.useDecimal = True
        '
        'RefundPlanDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 307)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.valueText)
        Me.Controls.Add(Me.valueLabel)
        Me.Controls.Add(Me.modeGroup)
        Me.Controls.Add(Me.descriptionText)
        Me.Controls.Add(Me.descriptionLabel)
        Me.Controls.Add(Me.recipientText)
        Me.Controls.Add(Me.recipientLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RefundPlanDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Refund Plan Detail"
        Me.modeGroup.ResumeLayout(False)
        Me.modeGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents recipientLabel As Label
    Friend WithEvents recipientText As TextBox
    Friend WithEvents descriptionText As TextBox
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents modeGroup As GroupBox
    Friend WithEvents fixOption As RadioButton
    Friend WithEvents percentageOption As RadioButton
    Friend WithEvents valueLabel As Label
    Friend WithEvents valueText As CHCSupportUIControls.NumericText
    Friend WithEvents confirmButton As Button
    Friend WithEvents cancelButton As Button
End Class
