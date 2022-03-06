<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplyInformations
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.totalLabel = New System.Windows.Forms.Label()
        Me.totalAmount = New CHCSupportUIControls.NumericText()
        Me.symbolAmountLabel = New System.Windows.Forms.Label()
        Me.symbolLockedLabel = New System.Windows.Forms.Label()
        Me.totalLocked = New CHCSupportUIControls.NumericText()
        Me.totalLockedLabel = New System.Windows.Forms.Label()
        Me.symbolAvailableLabel = New System.Windows.Forms.Label()
        Me.totalAvailable = New CHCSupportUIControls.NumericText()
        Me.totalAvailableLabel = New System.Windows.Forms.Label()
        Me.lastStakeDateTime = New System.Windows.Forms.TextBox()
        Me.lastStakeLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'totalLabel
        '
        Me.totalLabel.AutoSize = True
        Me.totalLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalLabel.Location = New System.Drawing.Point(19, 15)
        Me.totalLabel.Name = "totalLabel"
        Me.totalLabel.Size = New System.Drawing.Size(82, 13)
        Me.totalLabel.TabIndex = 45
        Me.totalLabel.Text = "Total Amount"
        '
        'totalAmount
        '
        Me.totalAmount.currentFormat = "#,##0"
        Me.totalAmount.Location = New System.Drawing.Point(22, 31)
        Me.totalAmount.locationCode = "it-IT"
        Me.totalAmount.Name = "totalAmount"
        Me.totalAmount.ReadOnly = True
        Me.totalAmount.Size = New System.Drawing.Size(205, 20)
        Me.totalAmount.TabIndex = 67
        Me.totalAmount.Text = "0"
        Me.totalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.totalAmount.useDecimal = False
        '
        'symbolAmountLabel
        '
        Me.symbolAmountLabel.AutoSize = True
        Me.symbolAmountLabel.Location = New System.Drawing.Point(233, 34)
        Me.symbolAmountLabel.Name = "symbolAmountLabel"
        Me.symbolAmountLabel.Size = New System.Drawing.Size(19, 13)
        Me.symbolAmountLabel.TabIndex = 68
        Me.symbolAmountLabel.Text = "$$"
        '
        'symbolLockedLabel
        '
        Me.symbolLockedLabel.AutoSize = True
        Me.symbolLockedLabel.Location = New System.Drawing.Point(233, 81)
        Me.symbolLockedLabel.Name = "symbolLockedLabel"
        Me.symbolLockedLabel.Size = New System.Drawing.Size(19, 13)
        Me.symbolLockedLabel.TabIndex = 71
        Me.symbolLockedLabel.Text = "$$"
        '
        'totalLocked
        '
        Me.totalLocked.currentFormat = "#,##0"
        Me.totalLocked.Location = New System.Drawing.Point(22, 78)
        Me.totalLocked.locationCode = "it-IT"
        Me.totalLocked.Name = "totalLocked"
        Me.totalLocked.ReadOnly = True
        Me.totalLocked.Size = New System.Drawing.Size(205, 20)
        Me.totalLocked.TabIndex = 70
        Me.totalLocked.Text = "0"
        Me.totalLocked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.totalLocked.useDecimal = False
        '
        'totalLockedLabel
        '
        Me.totalLockedLabel.AutoSize = True
        Me.totalLockedLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalLockedLabel.Location = New System.Drawing.Point(19, 62)
        Me.totalLockedLabel.Name = "totalLockedLabel"
        Me.totalLockedLabel.Size = New System.Drawing.Size(78, 13)
        Me.totalLockedLabel.TabIndex = 69
        Me.totalLockedLabel.Text = "Total Locked"
        '
        'symbolAvailableLabel
        '
        Me.symbolAvailableLabel.AutoSize = True
        Me.symbolAvailableLabel.Location = New System.Drawing.Point(233, 126)
        Me.symbolAvailableLabel.Name = "symbolAvailableLabel"
        Me.symbolAvailableLabel.Size = New System.Drawing.Size(19, 13)
        Me.symbolAvailableLabel.TabIndex = 74
        Me.symbolAvailableLabel.Text = "$$"
        '
        'totalAvailable
        '
        Me.totalAvailable.currentFormat = "#,##0"
        Me.totalAvailable.Location = New System.Drawing.Point(22, 123)
        Me.totalAvailable.locationCode = "it-IT"
        Me.totalAvailable.Name = "totalAvailable"
        Me.totalAvailable.ReadOnly = True
        Me.totalAvailable.Size = New System.Drawing.Size(205, 20)
        Me.totalAvailable.TabIndex = 73
        Me.totalAvailable.Text = "0"
        Me.totalAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.totalAvailable.useDecimal = False
        '
        'totalAvailableLabel
        '
        Me.totalAvailableLabel.AutoSize = True
        Me.totalAvailableLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalAvailableLabel.Location = New System.Drawing.Point(19, 107)
        Me.totalAvailableLabel.Name = "totalAvailableLabel"
        Me.totalAvailableLabel.Size = New System.Drawing.Size(90, 13)
        Me.totalAvailableLabel.TabIndex = 72
        Me.totalAvailableLabel.Text = "Total Available"
        '
        'lastStakeDateTime
        '
        Me.lastStakeDateTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastStakeDateTime.Location = New System.Drawing.Point(22, 169)
        Me.lastStakeDateTime.Name = "lastStakeDateTime"
        Me.lastStakeDateTime.ReadOnly = True
        Me.lastStakeDateTime.Size = New System.Drawing.Size(205, 21)
        Me.lastStakeDateTime.TabIndex = 75
        Me.lastStakeDateTime.Text = "xxxx"
        '
        'lastStakeLabel
        '
        Me.lastStakeLabel.AutoSize = True
        Me.lastStakeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastStakeLabel.Location = New System.Drawing.Point(19, 153)
        Me.lastStakeLabel.Name = "lastStakeLabel"
        Me.lastStakeLabel.Size = New System.Drawing.Size(124, 13)
        Me.lastStakeLabel.TabIndex = 76
        Me.lastStakeLabel.Text = "Last stake date/time"
        '
        'SupplyInformations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lastStakeDateTime)
        Me.Controls.Add(Me.lastStakeLabel)
        Me.Controls.Add(Me.symbolAvailableLabel)
        Me.Controls.Add(Me.totalAvailable)
        Me.Controls.Add(Me.totalAvailableLabel)
        Me.Controls.Add(Me.symbolLockedLabel)
        Me.Controls.Add(Me.totalLocked)
        Me.Controls.Add(Me.totalLockedLabel)
        Me.Controls.Add(Me.symbolAmountLabel)
        Me.Controls.Add(Me.totalAmount)
        Me.Controls.Add(Me.totalLabel)
        Me.Name = "SupplyInformations"
        Me.Size = New System.Drawing.Size(563, 232)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents totalLabel As Label
    Friend WithEvents totalAmount As CHCSupportUIControls.NumericText
    Friend WithEvents symbolAmountLabel As Label
    Friend WithEvents symbolLockedLabel As Label
    Friend WithEvents totalLocked As CHCSupportUIControls.NumericText
    Friend WithEvents totalLockedLabel As Label
    Friend WithEvents symbolAvailableLabel As Label
    Friend WithEvents totalAvailable As CHCSupportUIControls.NumericText
    Friend WithEvents totalAvailableLabel As Label
    Friend WithEvents lastStakeDateTime As TextBox
    Friend WithEvents lastStakeLabel As Label
End Class
