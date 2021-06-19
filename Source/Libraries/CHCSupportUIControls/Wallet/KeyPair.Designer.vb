<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyPair
    Inherits System.Windows.Forms.UserControl

    'UserControl1 esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.privateKeyText = New System.Windows.Forms.TextBox()
        Me.publicKeyText = New System.Windows.Forms.TextBox()
        Me.privateKeyLabel = New System.Windows.Forms.Label()
        Me.publicKeyLabel = New System.Windows.Forms.Label()
        Me.copyPublicAddressButton = New System.Windows.Forms.Button()
        Me.qrPublicAddressButton = New System.Windows.Forms.Button()
        Me.copyPrivateAddressButton = New System.Windows.Forms.Button()
        Me.qrPrivateAddressButton = New System.Windows.Forms.Button()
        Me.charCounterPrivateAddress = New System.Windows.Forms.Label()
        Me.qrCodePanel = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.qrCodeImage = New System.Windows.Forms.PictureBox()
        Me.closeUserButton = New System.Windows.Forms.Button()
        Me.qrCodePanel.SuspendLayout()
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'privateKeyText
        '
        Me.privateKeyText.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privateKeyText.ForeColor = System.Drawing.Color.DarkBlue
        Me.privateKeyText.Location = New System.Drawing.Point(15, 132)
        Me.privateKeyText.Multiline = True
        Me.privateKeyText.Name = "privateKeyText"
        Me.privateKeyText.ReadOnly = True
        Me.privateKeyText.Size = New System.Drawing.Size(502, 248)
        Me.privateKeyText.TabIndex = 16
        '
        'publicKeyText
        '
        Me.publicKeyText.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicKeyText.ForeColor = System.Drawing.Color.DarkBlue
        Me.publicKeyText.Location = New System.Drawing.Point(15, 28)
        Me.publicKeyText.Multiline = True
        Me.publicKeyText.Name = "publicKeyText"
        Me.publicKeyText.ReadOnly = True
        Me.publicKeyText.Size = New System.Drawing.Size(502, 77)
        Me.publicKeyText.TabIndex = 15
        '
        'privateKeyLabel
        '
        Me.privateKeyLabel.AutoSize = True
        Me.privateKeyLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privateKeyLabel.Location = New System.Drawing.Point(12, 116)
        Me.privateKeyLabel.Name = "privateKeyLabel"
        Me.privateKeyLabel.Size = New System.Drawing.Size(47, 13)
        Me.privateKeyLabel.TabIndex = 14
        Me.privateKeyLabel.Text = "Private"
        '
        'publicKeyLabel
        '
        Me.publicKeyLabel.AutoSize = True
        Me.publicKeyLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicKeyLabel.Location = New System.Drawing.Point(12, 11)
        Me.publicKeyLabel.Name = "publicKeyLabel"
        Me.publicKeyLabel.Size = New System.Drawing.Size(40, 13)
        Me.publicKeyLabel.TabIndex = 13
        Me.publicKeyLabel.Text = "Public"
        '
        'copyPublicAddressButton
        '
        Me.copyPublicAddressButton.Enabled = False
        Me.copyPublicAddressButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyPublicAddressButton.Location = New System.Drawing.Point(420, 80)
        Me.copyPublicAddressButton.Name = "copyPublicAddressButton"
        Me.copyPublicAddressButton.Size = New System.Drawing.Size(56, 23)
        Me.copyPublicAddressButton.TabIndex = 18
        Me.copyPublicAddressButton.Text = "COPY"
        Me.copyPublicAddressButton.UseVisualStyleBackColor = True
        '
        'qrPublicAddressButton
        '
        Me.qrPublicAddressButton.Enabled = False
        Me.qrPublicAddressButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qrPublicAddressButton.Location = New System.Drawing.Point(477, 80)
        Me.qrPublicAddressButton.Name = "qrPublicAddressButton"
        Me.qrPublicAddressButton.Size = New System.Drawing.Size(38, 23)
        Me.qrPublicAddressButton.TabIndex = 17
        Me.qrPublicAddressButton.Text = "QR"
        Me.qrPublicAddressButton.UseVisualStyleBackColor = True
        '
        'copyPrivateAddressButton
        '
        Me.copyPrivateAddressButton.Enabled = False
        Me.copyPrivateAddressButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.copyPrivateAddressButton.Location = New System.Drawing.Point(420, 355)
        Me.copyPrivateAddressButton.Name = "copyPrivateAddressButton"
        Me.copyPrivateAddressButton.Size = New System.Drawing.Size(56, 23)
        Me.copyPrivateAddressButton.TabIndex = 20
        Me.copyPrivateAddressButton.Text = "COPY"
        Me.copyPrivateAddressButton.UseVisualStyleBackColor = True
        '
        'qrPrivateAddressButton
        '
        Me.qrPrivateAddressButton.Enabled = False
        Me.qrPrivateAddressButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qrPrivateAddressButton.Location = New System.Drawing.Point(477, 355)
        Me.qrPrivateAddressButton.Name = "qrPrivateAddressButton"
        Me.qrPrivateAddressButton.Size = New System.Drawing.Size(38, 23)
        Me.qrPrivateAddressButton.TabIndex = 19
        Me.qrPrivateAddressButton.Text = "QR"
        Me.qrPrivateAddressButton.UseVisualStyleBackColor = True
        '
        'charCounterPrivateAddress
        '
        Me.charCounterPrivateAddress.AutoSize = True
        Me.charCounterPrivateAddress.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.charCounterPrivateAddress.ForeColor = System.Drawing.Color.Teal
        Me.charCounterPrivateAddress.Location = New System.Drawing.Point(488, 116)
        Me.charCounterPrivateAddress.Name = "charCounterPrivateAddress"
        Me.charCounterPrivateAddress.Size = New System.Drawing.Size(27, 12)
        Me.charCounterPrivateAddress.TabIndex = 21
        Me.charCounterPrivateAddress.Text = "x / x"
        '
        'qrCodePanel
        '
        Me.qrCodePanel.Controls.Add(Me.Label5)
        Me.qrCodePanel.Controls.Add(Me.qrCodeImage)
        Me.qrCodePanel.Controls.Add(Me.closeUserButton)
        Me.qrCodePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.qrCodePanel.Location = New System.Drawing.Point(0, 0)
        Me.qrCodePanel.Name = "qrCodePanel"
        Me.qrCodePanel.Size = New System.Drawing.Size(538, 401)
        Me.qrCodePanel.TabIndex = 24
        Me.qrCodePanel.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "QR Code"
        '
        'qrCodeImage
        '
        Me.qrCodeImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.qrCodeImage.BackColor = System.Drawing.SystemColors.Window
        Me.qrCodeImage.Location = New System.Drawing.Point(0, 41)
        Me.qrCodeImage.Name = "qrCodeImage"
        Me.qrCodeImage.Size = New System.Drawing.Size(537, 356)
        Me.qrCodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.qrCodeImage.TabIndex = 16
        Me.qrCodeImage.TabStop = False
        Me.qrCodeImage.Visible = False
        '
        'closeUserButton
        '
        Me.closeUserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeUserButton.Location = New System.Drawing.Point(461, 2)
        Me.closeUserButton.Name = "closeUserButton"
        Me.closeUserButton.Size = New System.Drawing.Size(73, 22)
        Me.closeUserButton.TabIndex = 0
        Me.closeUserButton.Text = "Close"
        Me.closeUserButton.UseVisualStyleBackColor = True
        '
        'KeyPair
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.qrCodePanel)
        Me.Controls.Add(Me.charCounterPrivateAddress)
        Me.Controls.Add(Me.copyPrivateAddressButton)
        Me.Controls.Add(Me.qrPrivateAddressButton)
        Me.Controls.Add(Me.copyPublicAddressButton)
        Me.Controls.Add(Me.qrPublicAddressButton)
        Me.Controls.Add(Me.privateKeyText)
        Me.Controls.Add(Me.publicKeyText)
        Me.Controls.Add(Me.privateKeyLabel)
        Me.Controls.Add(Me.publicKeyLabel)
        Me.Name = "KeyPair"
        Me.Size = New System.Drawing.Size(538, 401)
        Me.qrCodePanel.ResumeLayout(False)
        Me.qrCodePanel.PerformLayout()
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents privateKeyText As TextBox
    Friend WithEvents publicKeyText As TextBox
    Friend WithEvents privateKeyLabel As Label
    Friend WithEvents publicKeyLabel As Label
    Friend WithEvents copyPublicAddressButton As Button
    Friend WithEvents qrPublicAddressButton As Button
    Friend WithEvents copyPrivateAddressButton As Button
    Friend WithEvents qrPrivateAddressButton As Button
    Friend WithEvents charCounterPrivateAddress As Label
    Friend WithEvents qrCodePanel As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents qrCodeImage As PictureBox
    Friend WithEvents closeUserButton As Button
End Class
