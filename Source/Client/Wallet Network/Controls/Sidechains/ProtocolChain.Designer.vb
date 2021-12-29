<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProtocolChain
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
        Me.setCode = New System.Windows.Forms.TextBox()
        Me.setCodeLabel = New System.Windows.Forms.Label()
        Me.documentation = New System.Windows.Forms.TextBox()
        Me.documentationLabel = New System.Windows.Forms.Label()
        Me.protocol = New System.Windows.Forms.TextBox()
        Me.protocolLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'setCode
        '
        Me.setCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setCode.Location = New System.Drawing.Point(22, 31)
        Me.setCode.Name = "setCode"
        Me.setCode.ReadOnly = True
        Me.setCode.Size = New System.Drawing.Size(145, 21)
        Me.setCode.TabIndex = 46
        Me.setCode.Text = "xxxx"
        '
        'setCodeLabel
        '
        Me.setCodeLabel.AutoSize = True
        Me.setCodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setCodeLabel.Location = New System.Drawing.Point(19, 15)
        Me.setCodeLabel.Name = "setCodeLabel"
        Me.setCodeLabel.Size = New System.Drawing.Size(57, 13)
        Me.setCodeLabel.TabIndex = 47
        Me.setCodeLabel.Text = "Set code"
        '
        'documentation
        '
        Me.documentation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.documentation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.documentation.Location = New System.Drawing.Point(22, 127)
        Me.documentation.Multiline = True
        Me.documentation.Name = "documentation"
        Me.documentation.ReadOnly = True
        Me.documentation.Size = New System.Drawing.Size(624, 149)
        Me.documentation.TabIndex = 44
        Me.documentation.Text = "xxxx"
        '
        'documentationLabel
        '
        Me.documentationLabel.AutoSize = True
        Me.documentationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.documentationLabel.Location = New System.Drawing.Point(19, 111)
        Me.documentationLabel.Name = "documentationLabel"
        Me.documentationLabel.Size = New System.Drawing.Size(93, 13)
        Me.documentationLabel.TabIndex = 45
        Me.documentationLabel.Text = "Documentation"
        '
        'protocol
        '
        Me.protocol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.protocol.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.protocol.Location = New System.Drawing.Point(22, 77)
        Me.protocol.Name = "protocol"
        Me.protocol.ReadOnly = True
        Me.protocol.Size = New System.Drawing.Size(624, 21)
        Me.protocol.TabIndex = 48
        Me.protocol.Text = "xxxx"
        '
        'protocolLabel
        '
        Me.protocolLabel.AutoSize = True
        Me.protocolLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.protocolLabel.Location = New System.Drawing.Point(19, 61)
        Me.protocolLabel.Name = "protocolLabel"
        Me.protocolLabel.Size = New System.Drawing.Size(53, 13)
        Me.protocolLabel.TabIndex = 49
        Me.protocolLabel.Text = "Protocol"
        '
        'ProtocolChain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.protocol)
        Me.Controls.Add(Me.protocolLabel)
        Me.Controls.Add(Me.setCode)
        Me.Controls.Add(Me.setCodeLabel)
        Me.Controls.Add(Me.documentation)
        Me.Controls.Add(Me.documentationLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Name = "ProtocolChain"
        Me.Size = New System.Drawing.Size(670, 293)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents setCode As TextBox
    Friend WithEvents setCodeLabel As Label
    Friend WithEvents documentation As TextBox
    Friend WithEvents documentationLabel As Label
    Friend WithEvents protocol As TextBox
    Friend WithEvents protocolLabel As Label
End Class
