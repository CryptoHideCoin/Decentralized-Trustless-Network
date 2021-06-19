<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Certificate
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
        Me.createButton = New System.Windows.Forms.Button()
        Me.changeButton = New System.Windows.Forms.Button()
        Me.browserButton = New System.Windows.Forms.Button()
        Me.valueText = New System.Windows.Forms.TextBox()
        Me.valueLabel = New System.Windows.Forms.Label()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'createButton
        '
        Me.createButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.createButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createButton.Location = New System.Drawing.Point(415, 6)
        Me.createButton.Name = "createButton"
        Me.createButton.Size = New System.Drawing.Size(49, 22)
        Me.createButton.TabIndex = 1
        Me.createButton.Text = "New"
        Me.createButton.UseVisualStyleBackColor = True
        '
        'changeButton
        '
        Me.changeButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.changeButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changeButton.Location = New System.Drawing.Point(436, 6)
        Me.changeButton.Name = "changeButton"
        Me.changeButton.Size = New System.Drawing.Size(65, 22)
        Me.changeButton.TabIndex = 3
        Me.changeButton.Text = "Change"
        Me.changeButton.UseVisualStyleBackColor = True
        '
        'browserButton
        '
        Me.browserButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.browserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browserButton.Location = New System.Drawing.Point(470, 6)
        Me.browserButton.Name = "browserButton"
        Me.browserButton.Size = New System.Drawing.Size(31, 22)
        Me.browserButton.TabIndex = 2
        Me.browserButton.Text = "..."
        Me.browserButton.UseVisualStyleBackColor = True
        '
        'valueText
        '
        Me.valueText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.valueText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valueText.Location = New System.Drawing.Point(75, 6)
        Me.valueText.Name = "valueText"
        Me.valueText.Size = New System.Drawing.Size(334, 21)
        Me.valueText.TabIndex = 0
        '
        'valueLabel
        '
        Me.valueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.valueLabel.AutoSize = True
        Me.valueLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valueLabel.Location = New System.Drawing.Point(3, 9)
        Me.valueLabel.Name = "valueLabel"
        Me.valueLabel.Size = New System.Drawing.Size(66, 13)
        Me.valueLabel.TabIndex = 28
        Me.valueLabel.Text = "Certificate"
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'Certificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.createButton)
        Me.Controls.Add(Me.changeButton)
        Me.Controls.Add(Me.browserButton)
        Me.Controls.Add(Me.valueText)
        Me.Controls.Add(Me.valueLabel)
        Me.Name = "Certificate"
        Me.Size = New System.Drawing.Size(504, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents createButton As Button
    Friend WithEvents changeButton As Button
    Friend WithEvents browserButton As Button
    Friend WithEvents valueText As TextBox
    Friend WithEvents valueLabel As Label
    Friend WithEvents openFileDialog As OpenFileDialog
End Class
