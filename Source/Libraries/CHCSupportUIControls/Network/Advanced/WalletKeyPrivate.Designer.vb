<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WalletKeyPrivate
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
        Me.privateKeyValue = New System.Windows.Forms.TextBox()
        Me.privateKeyLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'keyStoreManagerButton
        '
        Me.keyStoreManagerButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.keyStoreManagerButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keyStoreManagerButton.Location = New System.Drawing.Point(438, 22)
        Me.keyStoreManagerButton.Name = "keyStoreManagerButton"
        Me.keyStoreManagerButton.Size = New System.Drawing.Size(72, 44)
        Me.keyStoreManagerButton.TabIndex = 36
        Me.keyStoreManagerButton.Text = "Keystore"
        Me.keyStoreManagerButton.UseVisualStyleBackColor = True
        '
        'privateKeyValue
        '
        Me.privateKeyValue.Location = New System.Drawing.Point(3, 22)
        Me.privateKeyValue.Multiline = True
        Me.privateKeyValue.Name = "privateKeyValue"
        Me.privateKeyValue.Size = New System.Drawing.Size(433, 72)
        Me.privateKeyValue.TabIndex = 35
        '
        'privateKeyLabel
        '
        Me.privateKeyLabel.AutoSize = True
        Me.privateKeyLabel.Location = New System.Drawing.Point(0, 5)
        Me.privateKeyLabel.Name = "privateKeyLabel"
        Me.privateKeyLabel.Size = New System.Drawing.Size(61, 13)
        Me.privateKeyLabel.TabIndex = 34
        Me.privateKeyLabel.Text = "Private Key"
        '
        'WalletKeyPrivate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.keyStoreManagerButton)
        Me.Controls.Add(Me.privateKeyValue)
        Me.Controls.Add(Me.privateKeyLabel)
        Me.Name = "WalletKeyPrivate"
        Me.Size = New System.Drawing.Size(509, 99)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents keyStoreManagerButton As Button
    Friend WithEvents privateKeyValue As TextBox
    Friend WithEvents privateKeyLabel As Label
End Class
