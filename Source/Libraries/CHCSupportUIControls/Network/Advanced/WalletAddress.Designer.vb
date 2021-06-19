<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WalletAddress
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
        Me.keyStoreManagerButton = New System.Windows.Forms.Button()
        Me.addressText = New System.Windows.Forms.TextBox()
        Me.addressLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'keyStoreManagerButton
        '
        Me.keyStoreManagerButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.keyStoreManagerButton.Enabled = False
        Me.keyStoreManagerButton.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keyStoreManagerButton.Location = New System.Drawing.Point(588, 3)
        Me.keyStoreManagerButton.Name = "keyStoreManagerButton"
        Me.keyStoreManagerButton.Size = New System.Drawing.Size(65, 44)
        Me.keyStoreManagerButton.TabIndex = 32
        Me.keyStoreManagerButton.Text = "Keystore"
        Me.keyStoreManagerButton.UseVisualStyleBackColor = True
        '
        'addressText
        '
        Me.addressText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.addressText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addressText.Location = New System.Drawing.Point(139, 3)
        Me.addressText.Multiline = True
        Me.addressText.Name = "addressText"
        Me.addressText.Size = New System.Drawing.Size(443, 44)
        Me.addressText.TabIndex = 30
        '
        'addressLabel
        '
        Me.addressLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.addressLabel.AutoSize = True
        Me.addressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addressLabel.Location = New System.Drawing.Point(4, 3)
        Me.addressLabel.Name = "addressLabel"
        Me.addressLabel.Size = New System.Drawing.Size(129, 13)
        Me.addressLabel.TabIndex = 31
        Me.addressLabel.Text = "Admin wallet address"
        '
        'WalletAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.keyStoreManagerButton)
        Me.Controls.Add(Me.addressText)
        Me.Controls.Add(Me.addressLabel)
        Me.Name = "WalletAddress"
        Me.Size = New System.Drawing.Size(656, 51)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents keyStoreManagerButton As Button
    Friend WithEvents addressText As TextBox
    Friend WithEvents addressLabel As Label
End Class
