<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainChain
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
        Me.description = New System.Windows.Forms.TextBox()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.privateChain = New System.Windows.Forms.TextBox()
        Me.privateChainLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'description
        '
        Me.description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.description.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(22, 80)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        Me.description.Size = New System.Drawing.Size(505, 132)
        Me.description.TabIndex = 40
        Me.description.Text = "xxxx"
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionLabel.Location = New System.Drawing.Point(19, 64)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(71, 13)
        Me.descriptionLabel.TabIndex = 41
        Me.descriptionLabel.Text = "Description"
        '
        'privateChain
        '
        Me.privateChain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.privateChain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privateChain.Location = New System.Drawing.Point(22, 31)
        Me.privateChain.Name = "privateChain"
        Me.privateChain.ReadOnly = True
        Me.privateChain.Size = New System.Drawing.Size(505, 21)
        Me.privateChain.TabIndex = 42
        Me.privateChain.Text = "xxxx"
        '
        'privateChainLabel
        '
        Me.privateChainLabel.AutoSize = True
        Me.privateChainLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privateChainLabel.Location = New System.Drawing.Point(19, 15)
        Me.privateChainLabel.Name = "privateChainLabel"
        Me.privateChainLabel.Size = New System.Drawing.Size(81, 13)
        Me.privateChainLabel.TabIndex = 43
        Me.privateChainLabel.Text = "Private chain"
        '
        'MainChain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.privateChain)
        Me.Controls.Add(Me.privateChainLabel)
        Me.Controls.Add(Me.description)
        Me.Controls.Add(Me.descriptionLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "MainChain"
        Me.Size = New System.Drawing.Size(563, 232)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents description As TextBox
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents privateChain As TextBox
    Friend WithEvents privateChainLabel As Label
End Class
