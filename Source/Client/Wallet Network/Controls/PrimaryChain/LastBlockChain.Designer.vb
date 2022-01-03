<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LastBlockChain
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
        Me.lastBlock = New System.Windows.Forms.TextBox()
        Me.lastBlockChainLabel = New System.Windows.Forms.Label()
        Me.activeChain = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lastBlock
        '
        Me.lastBlock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lastBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastBlock.Location = New System.Drawing.Point(22, 31)
        Me.lastBlock.Name = "lastBlock"
        Me.lastBlock.ReadOnly = True
        Me.lastBlock.Size = New System.Drawing.Size(505, 21)
        Me.lastBlock.TabIndex = 44
        Me.lastBlock.Text = "xxxx"
        '
        'lastBlockChainLabel
        '
        Me.lastBlockChainLabel.AutoSize = True
        Me.lastBlockChainLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastBlockChainLabel.Location = New System.Drawing.Point(19, 15)
        Me.lastBlockChainLabel.Name = "lastBlockChainLabel"
        Me.lastBlockChainLabel.Size = New System.Drawing.Size(139, 13)
        Me.lastBlockChainLabel.TabIndex = 45
        Me.lastBlockChainLabel.Text = "Registration Date/Time"
        '
        'activeChain
        '
        Me.activeChain.AutoSize = True
        Me.activeChain.Enabled = False
        Me.activeChain.Location = New System.Drawing.Point(22, 67)
        Me.activeChain.Name = "activeChain"
        Me.activeChain.Size = New System.Drawing.Size(98, 17)
        Me.activeChain.TabIndex = 46
        Me.activeChain.Text = "Active Chain"
        Me.activeChain.UseVisualStyleBackColor = True
        '
        'LastBlockChain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.activeChain)
        Me.Controls.Add(Me.lastBlock)
        Me.Controls.Add(Me.lastBlockChainLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "LastBlockChain"
        Me.Size = New System.Drawing.Size(563, 109)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lastBlock As TextBox
    Friend WithEvents lastBlockChainLabel As Label
    Friend WithEvents activeChain As CheckBox
End Class
