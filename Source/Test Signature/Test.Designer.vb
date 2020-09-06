<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Test))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.walletPubblicAddressValue = New System.Windows.Forms.TextBox()
        Me.privateKeyValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.messageValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.createSignature = New System.Windows.Forms.Button()
        Me.signatureValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.testSignature = New System.Windows.Forms.Button()
        Me.createNewWallet = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Wallet Public Address"
        '
        'walletPubblicAddressValue
        '
        Me.walletPubblicAddressValue.Location = New System.Drawing.Point(11, 298)
        Me.walletPubblicAddressValue.Name = "walletPubblicAddressValue"
        Me.walletPubblicAddressValue.Size = New System.Drawing.Size(523, 20)
        Me.walletPubblicAddressValue.TabIndex = 1
        Me.walletPubblicAddressValue.Text = "kBpZucTJ27cWjZRBmUEHyHsVPvQvWtdSJf2pebcJkJMBq1HhcpW9G7MTqNgKVBFWxGFoTmSdPhR33gy6K" &
    "pCC84K"
        '
        'privateKeyValue
        '
        Me.privateKeyValue.Location = New System.Drawing.Point(12, 83)
        Me.privateKeyValue.Multiline = True
        Me.privateKeyValue.Name = "privateKeyValue"
        Me.privateKeyValue.Size = New System.Drawing.Size(523, 68)
        Me.privateKeyValue.TabIndex = 3
        Me.privateKeyValue.Text = resources.GetString("privateKeyValue.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Private Key"
        '
        'messageValue
        '
        Me.messageValue.Location = New System.Drawing.Point(11, 171)
        Me.messageValue.Name = "messageValue"
        Me.messageValue.Size = New System.Drawing.Size(523, 20)
        Me.messageValue.TabIndex = 5
        Me.messageValue.Text = "GSDKLT3W89JFRW3E9W389R3UWR93WJU"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Message"
        '
        'createSignature
        '
        Me.createSignature.Location = New System.Drawing.Point(424, 197)
        Me.createSignature.Name = "createSignature"
        Me.createSignature.Size = New System.Drawing.Size(110, 41)
        Me.createSignature.TabIndex = 6
        Me.createSignature.Text = "Create Signature"
        Me.createSignature.UseVisualStyleBackColor = True
        '
        'signatureValue
        '
        Me.signatureValue.Location = New System.Drawing.Point(12, 258)
        Me.signatureValue.Name = "signatureValue"
        Me.signatureValue.Size = New System.Drawing.Size(523, 20)
        Me.signatureValue.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Signature"
        '
        'testSignature
        '
        Me.testSignature.Location = New System.Drawing.Point(424, 324)
        Me.testSignature.Name = "testSignature"
        Me.testSignature.Size = New System.Drawing.Size(110, 41)
        Me.testSignature.TabIndex = 9
        Me.testSignature.Text = "Test signature"
        Me.testSignature.UseVisualStyleBackColor = True
        '
        'createNewWallet
        '
        Me.createNewWallet.Location = New System.Drawing.Point(424, 12)
        Me.createNewWallet.Name = "createNewWallet"
        Me.createNewWallet.Size = New System.Drawing.Size(110, 41)
        Me.createNewWallet.TabIndex = 10
        Me.createNewWallet.Text = "Create New Wallet"
        Me.createNewWallet.UseVisualStyleBackColor = True
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 377)
        Me.Controls.Add(Me.createNewWallet)
        Me.Controls.Add(Me.testSignature)
        Me.Controls.Add(Me.signatureValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.createSignature)
        Me.Controls.Add(Me.messageValue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.privateKeyValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.walletPubblicAddressValue)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Test"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test Signature - Crypto Hide Coin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents walletPubblicAddressValue As TextBox
    Friend WithEvents privateKeyValue As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents messageValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents createSignature As Button
    Friend WithEvents signatureValue As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents testSignature As Button
    Friend WithEvents createNewWallet As Button
End Class
