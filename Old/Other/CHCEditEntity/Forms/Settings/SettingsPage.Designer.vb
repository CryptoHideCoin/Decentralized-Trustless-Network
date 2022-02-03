<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsPage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsPage))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.adminPrivateKeyValue = New System.Windows.Forms.TextBox()
        Me.adminPrivateWalletKEYLabel = New System.Windows.Forms.Label()
        Me.apiPasswordValue = New System.Windows.Forms.TextBox()
        Me.apiPasswordLabel = New System.Windows.Forms.Label()
        Me.adminWalletAddressValue = New System.Windows.Forms.TextBox()
        Me.adminWalletAddressLabel = New System.Windows.Forms.Label()
        Me.apiKeyValue = New System.Windows.Forms.TextBox()
        Me.apiKeyLabel = New System.Windows.Forms.Label()
        Me.urlValue = New System.Windows.Forms.TextBox()
        Me.labelURL = New System.Windows.Forms.Label()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.connectButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 426)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Main data"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.adminPrivateKeyValue)
        Me.Panel1.Controls.Add(Me.adminPrivateWalletKEYLabel)
        Me.Panel1.Controls.Add(Me.apiPasswordValue)
        Me.Panel1.Controls.Add(Me.apiPasswordLabel)
        Me.Panel1.Controls.Add(Me.adminWalletAddressValue)
        Me.Panel1.Controls.Add(Me.adminWalletAddressLabel)
        Me.Panel1.Controls.Add(Me.apiKeyValue)
        Me.Panel1.Controls.Add(Me.apiKeyLabel)
        Me.Panel1.Controls.Add(Me.urlValue)
        Me.Panel1.Controls.Add(Me.labelURL)
        Me.Panel1.Location = New System.Drawing.Point(7, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 401)
        Me.Panel1.TabIndex = 0
        '
        'adminPrivateKeyValue
        '
        Me.adminPrivateKeyValue.Location = New System.Drawing.Point(16, 244)
        Me.adminPrivateKeyValue.Multiline = True
        Me.adminPrivateKeyValue.Name = "adminPrivateKeyValue"
        Me.adminPrivateKeyValue.Size = New System.Drawing.Size(376, 140)
        Me.adminPrivateKeyValue.TabIndex = 25
        '
        'adminPrivateWalletKEYLabel
        '
        Me.adminPrivateWalletKEYLabel.AutoSize = True
        Me.adminPrivateWalletKEYLabel.Location = New System.Drawing.Point(13, 228)
        Me.adminPrivateWalletKEYLabel.Name = "adminPrivateWalletKEYLabel"
        Me.adminPrivateWalletKEYLabel.Size = New System.Drawing.Size(113, 13)
        Me.adminPrivateWalletKEYLabel.TabIndex = 24
        Me.adminPrivateWalletKEYLabel.Text = "Admin Private Key"
        '
        'apiPasswordValue
        '
        Me.apiPasswordValue.Location = New System.Drawing.Point(16, 136)
        Me.apiPasswordValue.Name = "apiPasswordValue"
        Me.apiPasswordValue.Size = New System.Drawing.Size(376, 21)
        Me.apiPasswordValue.TabIndex = 23
        '
        'apiPasswordLabel
        '
        Me.apiPasswordLabel.AutoSize = True
        Me.apiPasswordLabel.Location = New System.Drawing.Point(12, 119)
        Me.apiPasswordLabel.Name = "apiPasswordLabel"
        Me.apiPasswordLabel.Size = New System.Drawing.Size(85, 13)
        Me.apiPasswordLabel.TabIndex = 22
        Me.apiPasswordLabel.Text = "API Password"
        '
        'adminWalletAddressValue
        '
        Me.adminWalletAddressValue.Location = New System.Drawing.Point(16, 188)
        Me.adminWalletAddressValue.Name = "adminWalletAddressValue"
        Me.adminWalletAddressValue.Size = New System.Drawing.Size(376, 21)
        Me.adminWalletAddressValue.TabIndex = 21
        '
        'adminWalletAddressLabel
        '
        Me.adminWalletAddressLabel.AutoSize = True
        Me.adminWalletAddressLabel.Location = New System.Drawing.Point(13, 172)
        Me.adminWalletAddressLabel.Name = "adminWalletAddressLabel"
        Me.adminWalletAddressLabel.Size = New System.Drawing.Size(172, 13)
        Me.adminWalletAddressLabel.TabIndex = 20
        Me.adminWalletAddressLabel.Text = "Admin Public Address Wallet "
        '
        'apiKeyValue
        '
        Me.apiKeyValue.Location = New System.Drawing.Point(16, 84)
        Me.apiKeyValue.Name = "apiKeyValue"
        Me.apiKeyValue.Size = New System.Drawing.Size(376, 21)
        Me.apiKeyValue.TabIndex = 19
        '
        'apiKeyLabel
        '
        Me.apiKeyLabel.AutoSize = True
        Me.apiKeyLabel.Location = New System.Drawing.Point(12, 67)
        Me.apiKeyLabel.Name = "apiKeyLabel"
        Me.apiKeyLabel.Size = New System.Drawing.Size(53, 13)
        Me.apiKeyLabel.TabIndex = 18
        Me.apiKeyLabel.Text = "API Key"
        '
        'urlValue
        '
        Me.urlValue.Location = New System.Drawing.Point(16, 31)
        Me.urlValue.Name = "urlValue"
        Me.urlValue.Size = New System.Drawing.Size(376, 21)
        Me.urlValue.TabIndex = 17
        Me.urlValue.Text = "https://localhost:44392/"
        '
        'labelURL
        '
        Me.labelURL.AutoSize = True
        Me.labelURL.Location = New System.Drawing.Point(12, 14)
        Me.labelURL.Name = "labelURL"
        Me.labelURL.Size = New System.Drawing.Size(60, 13)
        Me.labelURL.TabIndex = 16
        Me.labelURL.Text = "URL base"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(438, 52)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(87, 21)
        Me.cancelButton.TabIndex = 19
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'connectButton
        '
        Me.connectButton.Location = New System.Drawing.Point(438, 22)
        Me.connectButton.Name = "connectButton"
        Me.connectButton.Size = New System.Drawing.Size(87, 21)
        Me.connectButton.TabIndex = 18
        Me.connectButton.Text = "Save"
        Me.connectButton.UseVisualStyleBackColor = True
        '
        'SettingsPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 450)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.connectButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents adminPrivateKeyValue As TextBox
    Friend WithEvents adminPrivateWalletKEYLabel As Label
    Friend WithEvents apiPasswordValue As TextBox
    Friend WithEvents apiPasswordLabel As Label
    Friend WithEvents adminWalletAddressValue As TextBox
    Friend WithEvents adminWalletAddressLabel As Label
    Friend WithEvents apiKeyValue As TextBox
    Friend WithEvents apiKeyLabel As Label
    Friend WithEvents urlValue As TextBox
    Friend WithEvents labelURL As Label
    Friend WithEvents cancelButton As Button
    Friend WithEvents connectButton As Button
End Class
