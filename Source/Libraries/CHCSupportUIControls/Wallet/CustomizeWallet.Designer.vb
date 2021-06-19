<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomizeWalletAddress
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomizeWalletAddress))
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.securityPage = New System.Windows.Forms.TabPage()
        Me.errorAuthorizationKEYLabel = New System.Windows.Forms.Label()
        Me.errorAccessKEYLabel = New System.Windows.Forms.Label()
        Me.repeatAuthorizationKEYLabel = New System.Windows.Forms.Label()
        Me.showCharacterRepeatAuthorizationKEYButton = New System.Windows.Forms.Button()
        Me.repeatAuthorizationKeyTextArea = New System.Windows.Forms.TextBox()
        Me.showCharacterAuthorizationKEYButton = New System.Windows.Forms.Button()
        Me.authorizationKEYTextBox = New System.Windows.Forms.TextBox()
        Me.useAuthorizationKEYCheckBox = New System.Windows.Forms.CheckBox()
        Me.repeatAccessKEYLabel = New System.Windows.Forms.Label()
        Me.showCharacterRepeatAccessKEYButton = New System.Windows.Forms.Button()
        Me.repeatAccessKEYTextBox = New System.Windows.Forms.TextBox()
        Me.showCharacterAccessKEYButton = New System.Windows.Forms.Button()
        Me.accessKEYTextBox = New System.Windows.Forms.TextBox()
        Me.useProtectionKEYCheckbox = New System.Windows.Forms.CheckBox()
        Me.seedPage = New System.Windows.Forms.TabPage()
        Me.createWalletFromSeedButton = New System.Windows.Forms.Button()
        Me.seedValueTextArea = New System.Windows.Forms.TextBox()
        Me.phraseLabel = New System.Windows.Forms.Label()
        Me.userPage = New System.Windows.Forms.TabPage()
        Me.userKeyPair = New CHCSupportUIControls.KeyPair()
        Me.rawPage = New System.Windows.Forms.TabPage()
        Me.rawKeyPair = New CHCSupportUIControls.KeyPair()
        Me.nameWalletLabel = New System.Windows.Forms.Label()
        Me.walletNameText = New System.Windows.Forms.TextBox()
        Me.testSignature = New System.Windows.Forms.Button()
        Me.paperAddress = New System.Windows.Forms.Button()
        Me.saveAddressButton = New System.Windows.Forms.Button()
        Me.paperWalletButton = New System.Windows.Forms.Button()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.UUIDText = New System.Windows.Forms.TextBox()
        Me.KeyGUIDLabel = New System.Windows.Forms.Label()
        Me.ppdMain = New System.Windows.Forms.PrintPreviewDialog()
        Me.pdMain = New System.Drawing.Printing.PrintDocument()
        Me.pDialogMain = New System.Windows.Forms.PrintDialog()
        Me.mainTab.SuspendLayout()
        Me.securityPage.SuspendLayout()
        Me.seedPage.SuspendLayout()
        Me.userPage.SuspendLayout()
        Me.rawPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.securityPage)
        Me.mainTab.Controls.Add(Me.seedPage)
        Me.mainTab.Controls.Add(Me.userPage)
        Me.mainTab.Controls.Add(Me.rawPage)
        Me.mainTab.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTab.Location = New System.Drawing.Point(14, 95)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(546, 379)
        Me.mainTab.TabIndex = 0
        '
        'securityPage
        '
        Me.securityPage.Controls.Add(Me.errorAuthorizationKEYLabel)
        Me.securityPage.Controls.Add(Me.errorAccessKEYLabel)
        Me.securityPage.Controls.Add(Me.repeatAuthorizationKEYLabel)
        Me.securityPage.Controls.Add(Me.showCharacterRepeatAuthorizationKEYButton)
        Me.securityPage.Controls.Add(Me.repeatAuthorizationKeyTextArea)
        Me.securityPage.Controls.Add(Me.showCharacterAuthorizationKEYButton)
        Me.securityPage.Controls.Add(Me.authorizationKEYTextBox)
        Me.securityPage.Controls.Add(Me.useAuthorizationKEYCheckBox)
        Me.securityPage.Controls.Add(Me.repeatAccessKEYLabel)
        Me.securityPage.Controls.Add(Me.showCharacterRepeatAccessKEYButton)
        Me.securityPage.Controls.Add(Me.repeatAccessKEYTextBox)
        Me.securityPage.Controls.Add(Me.showCharacterAccessKEYButton)
        Me.securityPage.Controls.Add(Me.accessKEYTextBox)
        Me.securityPage.Controls.Add(Me.useProtectionKEYCheckbox)
        Me.securityPage.Location = New System.Drawing.Point(4, 22)
        Me.securityPage.Name = "securityPage"
        Me.securityPage.Size = New System.Drawing.Size(538, 353)
        Me.securityPage.TabIndex = 3
        Me.securityPage.Text = "Security"
        Me.securityPage.UseVisualStyleBackColor = True
        '
        'errorAuthorizationKEYLabel
        '
        Me.errorAuthorizationKEYLabel.AutoSize = True
        Me.errorAuthorizationKEYLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.errorAuthorizationKEYLabel.ForeColor = System.Drawing.Color.Red
        Me.errorAuthorizationKEYLabel.Location = New System.Drawing.Point(277, 200)
        Me.errorAuthorizationKEYLabel.Name = "errorAuthorizationKEYLabel"
        Me.errorAuthorizationKEYLabel.Size = New System.Drawing.Size(231, 13)
        Me.errorAuthorizationKEYLabel.TabIndex = 20
        Me.errorAuthorizationKEYLabel.Text = "Repeat Authorization Key do not match"
        Me.errorAuthorizationKEYLabel.Visible = False
        '
        'errorAccessKEYLabel
        '
        Me.errorAccessKEYLabel.AutoSize = True
        Me.errorAccessKEYLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.errorAccessKEYLabel.ForeColor = System.Drawing.Color.Red
        Me.errorAccessKEYLabel.Location = New System.Drawing.Point(277, 93)
        Me.errorAccessKEYLabel.Name = "errorAccessKEYLabel"
        Me.errorAccessKEYLabel.Size = New System.Drawing.Size(195, 13)
        Me.errorAccessKEYLabel.TabIndex = 19
        Me.errorAccessKEYLabel.Text = "Repeat Access Key do not match"
        Me.errorAccessKEYLabel.Visible = False
        '
        'repeatAuthorizationKEYLabel
        '
        Me.repeatAuthorizationKEYLabel.AutoSize = True
        Me.repeatAuthorizationKEYLabel.Enabled = False
        Me.repeatAuthorizationKEYLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.repeatAuthorizationKEYLabel.Location = New System.Drawing.Point(277, 138)
        Me.repeatAuthorizationKEYLabel.Name = "repeatAuthorizationKEYLabel"
        Me.repeatAuthorizationKEYLabel.Size = New System.Drawing.Size(176, 16)
        Me.repeatAuthorizationKEYLabel.TabIndex = 18
        Me.repeatAuthorizationKEYLabel.Text = "Repeat Authorization KEY"
        '
        'showCharacterRepeatAuthorizationKEYButton
        '
        Me.showCharacterRepeatAuthorizationKEYButton.Enabled = False
        Me.showCharacterRepeatAuthorizationKEYButton.Image = CType(resources.GetObject("showCharacterRepeatAuthorizationKEYButton.Image"), System.Drawing.Image)
        Me.showCharacterRepeatAuthorizationKEYButton.Location = New System.Drawing.Point(445, 165)
        Me.showCharacterRepeatAuthorizationKEYButton.Name = "showCharacterRepeatAuthorizationKEYButton"
        Me.showCharacterRepeatAuthorizationKEYButton.Size = New System.Drawing.Size(32, 32)
        Me.showCharacterRepeatAuthorizationKEYButton.TabIndex = 17
        Me.showCharacterRepeatAuthorizationKEYButton.TabStop = False
        Me.showCharacterRepeatAuthorizationKEYButton.UseVisualStyleBackColor = True
        '
        'repeatAuthorizationKeyTextArea
        '
        Me.repeatAuthorizationKeyTextArea.Enabled = False
        Me.repeatAuthorizationKeyTextArea.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.repeatAuthorizationKeyTextArea.Location = New System.Drawing.Point(280, 165)
        Me.repeatAuthorizationKeyTextArea.Name = "repeatAuthorizationKeyTextArea"
        Me.repeatAuthorizationKeyTextArea.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.repeatAuthorizationKeyTextArea.Size = New System.Drawing.Size(167, 31)
        Me.repeatAuthorizationKeyTextArea.TabIndex = 16
        '
        'showCharacterAuthorizationKEYButton
        '
        Me.showCharacterAuthorizationKEYButton.Enabled = False
        Me.showCharacterAuthorizationKEYButton.Image = CType(resources.GetObject("showCharacterAuthorizationKEYButton.Image"), System.Drawing.Image)
        Me.showCharacterAuthorizationKEYButton.Location = New System.Drawing.Point(196, 165)
        Me.showCharacterAuthorizationKEYButton.Name = "showCharacterAuthorizationKEYButton"
        Me.showCharacterAuthorizationKEYButton.Size = New System.Drawing.Size(32, 32)
        Me.showCharacterAuthorizationKEYButton.TabIndex = 15
        Me.showCharacterAuthorizationKEYButton.TabStop = False
        Me.showCharacterAuthorizationKEYButton.UseVisualStyleBackColor = True
        '
        'authorizationKEYTextBox
        '
        Me.authorizationKEYTextBox.Enabled = False
        Me.authorizationKEYTextBox.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.authorizationKEYTextBox.Location = New System.Drawing.Point(31, 165)
        Me.authorizationKEYTextBox.Name = "authorizationKEYTextBox"
        Me.authorizationKEYTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.authorizationKEYTextBox.Size = New System.Drawing.Size(167, 31)
        Me.authorizationKEYTextBox.TabIndex = 14
        '
        'useAuthorizationKEYCheckBox
        '
        Me.useAuthorizationKEYCheckBox.AutoSize = True
        Me.useAuthorizationKEYCheckBox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.useAuthorizationKEYCheckBox.Location = New System.Drawing.Point(31, 134)
        Me.useAuthorizationKEYCheckBox.Name = "useAuthorizationKEYCheckBox"
        Me.useAuthorizationKEYCheckBox.Size = New System.Drawing.Size(173, 20)
        Me.useAuthorizationKEYCheckBox.TabIndex = 13
        Me.useAuthorizationKEYCheckBox.Text = "Use Authorization KEY"
        Me.useAuthorizationKEYCheckBox.UseVisualStyleBackColor = True
        '
        'repeatAccessKEYLabel
        '
        Me.repeatAccessKEYLabel.AutoSize = True
        Me.repeatAccessKEYLabel.Enabled = False
        Me.repeatAccessKEYLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.repeatAccessKEYLabel.Location = New System.Drawing.Point(277, 32)
        Me.repeatAccessKEYLabel.Name = "repeatAccessKEYLabel"
        Me.repeatAccessKEYLabel.Size = New System.Drawing.Size(136, 16)
        Me.repeatAccessKEYLabel.TabIndex = 12
        Me.repeatAccessKEYLabel.Text = "Repeat Access KEY"
        '
        'showCharacterRepeatAccessKEYButton
        '
        Me.showCharacterRepeatAccessKEYButton.Enabled = False
        Me.showCharacterRepeatAccessKEYButton.Image = CType(resources.GetObject("showCharacterRepeatAccessKEYButton.Image"), System.Drawing.Image)
        Me.showCharacterRepeatAccessKEYButton.Location = New System.Drawing.Point(445, 59)
        Me.showCharacterRepeatAccessKEYButton.Name = "showCharacterRepeatAccessKEYButton"
        Me.showCharacterRepeatAccessKEYButton.Size = New System.Drawing.Size(32, 32)
        Me.showCharacterRepeatAccessKEYButton.TabIndex = 11
        Me.showCharacterRepeatAccessKEYButton.TabStop = False
        Me.showCharacterRepeatAccessKEYButton.UseVisualStyleBackColor = True
        '
        'repeatAccessKEYTextBox
        '
        Me.repeatAccessKEYTextBox.Enabled = False
        Me.repeatAccessKEYTextBox.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.repeatAccessKEYTextBox.Location = New System.Drawing.Point(280, 59)
        Me.repeatAccessKEYTextBox.Name = "repeatAccessKEYTextBox"
        Me.repeatAccessKEYTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.repeatAccessKEYTextBox.Size = New System.Drawing.Size(167, 31)
        Me.repeatAccessKEYTextBox.TabIndex = 10
        '
        'showCharacterAccessKEYButton
        '
        Me.showCharacterAccessKEYButton.Enabled = False
        Me.showCharacterAccessKEYButton.Image = CType(resources.GetObject("showCharacterAccessKEYButton.Image"), System.Drawing.Image)
        Me.showCharacterAccessKEYButton.Location = New System.Drawing.Point(196, 59)
        Me.showCharacterAccessKEYButton.Name = "showCharacterAccessKEYButton"
        Me.showCharacterAccessKEYButton.Size = New System.Drawing.Size(32, 32)
        Me.showCharacterAccessKEYButton.TabIndex = 9
        Me.showCharacterAccessKEYButton.TabStop = False
        Me.showCharacterAccessKEYButton.UseVisualStyleBackColor = True
        '
        'accessKEYTextBox
        '
        Me.accessKEYTextBox.Enabled = False
        Me.accessKEYTextBox.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.accessKEYTextBox.Location = New System.Drawing.Point(31, 59)
        Me.accessKEYTextBox.Name = "accessKEYTextBox"
        Me.accessKEYTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.accessKEYTextBox.Size = New System.Drawing.Size(167, 31)
        Me.accessKEYTextBox.TabIndex = 8
        '
        'useProtectionKEYCheckbox
        '
        Me.useProtectionKEYCheckbox.AutoSize = True
        Me.useProtectionKEYCheckbox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.useProtectionKEYCheckbox.Location = New System.Drawing.Point(31, 28)
        Me.useProtectionKEYCheckbox.Name = "useProtectionKEYCheckbox"
        Me.useProtectionKEYCheckbox.Size = New System.Drawing.Size(133, 20)
        Me.useProtectionKEYCheckbox.TabIndex = 0
        Me.useProtectionKEYCheckbox.Text = "Use Access KEY"
        Me.useProtectionKEYCheckbox.UseVisualStyleBackColor = True
        '
        'seedPage
        '
        Me.seedPage.Controls.Add(Me.createWalletFromSeedButton)
        Me.seedPage.Controls.Add(Me.seedValueTextArea)
        Me.seedPage.Controls.Add(Me.phraseLabel)
        Me.seedPage.Location = New System.Drawing.Point(4, 22)
        Me.seedPage.Name = "seedPage"
        Me.seedPage.Padding = New System.Windows.Forms.Padding(3)
        Me.seedPage.Size = New System.Drawing.Size(538, 353)
        Me.seedPage.TabIndex = 0
        Me.seedPage.Text = "Seed"
        Me.seedPage.UseVisualStyleBackColor = True
        '
        'createWalletFromSeedButton
        '
        Me.createWalletFromSeedButton.Enabled = False
        Me.createWalletFromSeedButton.Location = New System.Drawing.Point(442, 120)
        Me.createWalletFromSeedButton.Name = "createWalletFromSeedButton"
        Me.createWalletFromSeedButton.Size = New System.Drawing.Size(75, 40)
        Me.createWalletFromSeedButton.TabIndex = 3
        Me.createWalletFromSeedButton.Text = "Create Wallet"
        Me.createWalletFromSeedButton.UseVisualStyleBackColor = True
        '
        'seedValueTextArea
        '
        Me.seedValueTextArea.Location = New System.Drawing.Point(14, 29)
        Me.seedValueTextArea.Multiline = True
        Me.seedValueTextArea.Name = "seedValueTextArea"
        Me.seedValueTextArea.Size = New System.Drawing.Size(502, 84)
        Me.seedValueTextArea.TabIndex = 2
        '
        'phraseLabel
        '
        Me.phraseLabel.AutoSize = True
        Me.phraseLabel.Location = New System.Drawing.Point(13, 12)
        Me.phraseLabel.Name = "phraseLabel"
        Me.phraseLabel.Size = New System.Drawing.Size(303, 13)
        Me.phraseLabel.TabIndex = 1
        Me.phraseLabel.Text = "Insert a phrase useful for creating the wallet (seed)"
        '
        'userPage
        '
        Me.userPage.Controls.Add(Me.userKeyPair)
        Me.userPage.Location = New System.Drawing.Point(4, 22)
        Me.userPage.Name = "userPage"
        Me.userPage.Padding = New System.Windows.Forms.Padding(3)
        Me.userPage.Size = New System.Drawing.Size(538, 353)
        Me.userPage.TabIndex = 1
        Me.userPage.Text = "Keypair User"
        Me.userPage.UseVisualStyleBackColor = True
        '
        'userKeyPair
        '
        Me.userKeyPair.BackColor = System.Drawing.Color.White
        Me.userKeyPair.inError = False
        Me.userKeyPair.Location = New System.Drawing.Point(0, 0)
        Me.userKeyPair.Name = "userKeyPair"
        Me.userKeyPair.noCheck = False
        Me.userKeyPair.privateKey = ""
        Me.userKeyPair.publicAddress = ""
        Me.userKeyPair.Size = New System.Drawing.Size(538, 353)
        Me.userKeyPair.TabIndex = 0
        Me.userKeyPair.userMode = True
        '
        'rawPage
        '
        Me.rawPage.Controls.Add(Me.rawKeyPair)
        Me.rawPage.Location = New System.Drawing.Point(4, 22)
        Me.rawPage.Name = "rawPage"
        Me.rawPage.Size = New System.Drawing.Size(538, 353)
        Me.rawPage.TabIndex = 2
        Me.rawPage.Text = "Keypair RAW"
        Me.rawPage.UseVisualStyleBackColor = True
        '
        'rawKeyPair
        '
        Me.rawKeyPair.BackColor = System.Drawing.Color.Transparent
        Me.rawKeyPair.inError = False
        Me.rawKeyPair.Location = New System.Drawing.Point(0, 0)
        Me.rawKeyPair.Name = "rawKeyPair"
        Me.rawKeyPair.noCheck = False
        Me.rawKeyPair.privateKey = ""
        Me.rawKeyPair.publicAddress = ""
        Me.rawKeyPair.Size = New System.Drawing.Size(538, 353)
        Me.rawKeyPair.TabIndex = 0
        Me.rawKeyPair.userMode = False
        '
        'nameWalletLabel
        '
        Me.nameWalletLabel.AutoSize = True
        Me.nameWalletLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameWalletLabel.Location = New System.Drawing.Point(11, 8)
        Me.nameWalletLabel.Name = "nameWalletLabel"
        Me.nameWalletLabel.Size = New System.Drawing.Size(89, 13)
        Me.nameWalletLabel.TabIndex = 1
        Me.nameWalletLabel.Text = "Address name"
        '
        'walletNameText
        '
        Me.walletNameText.Location = New System.Drawing.Point(14, 24)
        Me.walletNameText.Name = "walletNameText"
        Me.walletNameText.Size = New System.Drawing.Size(546, 20)
        Me.walletNameText.TabIndex = 2
        '
        'testSignature
        '
        Me.testSignature.Enabled = False
        Me.testSignature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testSignature.Location = New System.Drawing.Point(567, 434)
        Me.testSignature.Name = "testSignature"
        Me.testSignature.Size = New System.Drawing.Size(106, 36)
        Me.testSignature.TabIndex = 31
        Me.testSignature.Text = "Test Signature"
        Me.testSignature.UseVisualStyleBackColor = True
        '
        'paperAddress
        '
        Me.paperAddress.Enabled = False
        Me.paperAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.paperAddress.Location = New System.Drawing.Point(567, 205)
        Me.paperAddress.Name = "paperAddress"
        Me.paperAddress.Size = New System.Drawing.Size(106, 36)
        Me.paperAddress.TabIndex = 30
        Me.paperAddress.Text = "Paper Address"
        Me.paperAddress.UseVisualStyleBackColor = True
        '
        'saveAddressButton
        '
        Me.saveAddressButton.Enabled = False
        Me.saveAddressButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveAddressButton.Location = New System.Drawing.Point(567, 330)
        Me.saveAddressButton.Name = "saveAddressButton"
        Me.saveAddressButton.Size = New System.Drawing.Size(106, 36)
        Me.saveAddressButton.TabIndex = 28
        Me.saveAddressButton.Text = "Save"
        Me.saveAddressButton.UseVisualStyleBackColor = True
        '
        'paperWalletButton
        '
        Me.paperWalletButton.Enabled = False
        Me.paperWalletButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.paperWalletButton.Location = New System.Drawing.Point(567, 161)
        Me.paperWalletButton.Name = "paperWalletButton"
        Me.paperWalletButton.Size = New System.Drawing.Size(106, 36)
        Me.paperWalletButton.TabIndex = 27
        Me.paperWalletButton.Text = "Paper wallet"
        Me.paperWalletButton.UseVisualStyleBackColor = True
        '
        'createNewButton
        '
        Me.createNewButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createNewButton.Location = New System.Drawing.Point(566, 117)
        Me.createNewButton.Name = "createNewButton"
        Me.createNewButton.Size = New System.Drawing.Size(106, 36)
        Me.createNewButton.TabIndex = 26
        Me.createNewButton.Text = "Create New"
        Me.createNewButton.UseVisualStyleBackColor = True
        '
        'UUIDText
        '
        Me.UUIDText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UUIDText.Location = New System.Drawing.Point(14, 68)
        Me.UUIDText.Name = "UUIDText"
        Me.UUIDText.ReadOnly = True
        Me.UUIDText.Size = New System.Drawing.Size(546, 20)
        Me.UUIDText.TabIndex = 33
        '
        'KeyGUIDLabel
        '
        Me.KeyGUIDLabel.AutoSize = True
        Me.KeyGUIDLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyGUIDLabel.Location = New System.Drawing.Point(11, 52)
        Me.KeyGUIDLabel.Name = "KeyGUIDLabel"
        Me.KeyGUIDLabel.Size = New System.Drawing.Size(38, 13)
        Me.KeyGUIDLabel.TabIndex = 32
        Me.KeyGUIDLabel.Text = "GUID"
        '
        'ppdMain
        '
        Me.ppdMain.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdMain.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdMain.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdMain.Document = Me.pdMain
        Me.ppdMain.Enabled = True
        Me.ppdMain.Icon = CType(resources.GetObject("ppdMain.Icon"), System.Drawing.Icon)
        Me.ppdMain.Name = "ppdMain"
        Me.ppdMain.ShowIcon = False
        Me.ppdMain.Visible = False
        '
        'pdMain
        '
        '
        'pDialogMain
        '
        Me.pDialogMain.UseEXDialog = True
        '
        'CustomizeWalletAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.UUIDText)
        Me.Controls.Add(Me.KeyGUIDLabel)
        Me.Controls.Add(Me.testSignature)
        Me.Controls.Add(Me.paperAddress)
        Me.Controls.Add(Me.saveAddressButton)
        Me.Controls.Add(Me.paperWalletButton)
        Me.Controls.Add(Me.createNewButton)
        Me.Controls.Add(Me.walletNameText)
        Me.Controls.Add(Me.nameWalletLabel)
        Me.Controls.Add(Me.mainTab)
        Me.Name = "CustomizeWalletAddress"
        Me.Size = New System.Drawing.Size(687, 496)
        Me.mainTab.ResumeLayout(False)
        Me.securityPage.ResumeLayout(False)
        Me.securityPage.PerformLayout()
        Me.seedPage.ResumeLayout(False)
        Me.seedPage.PerformLayout()
        Me.userPage.ResumeLayout(False)
        Me.rawPage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mainTab As TabControl
    Friend WithEvents seedPage As TabPage
    Friend WithEvents userPage As TabPage
    Friend WithEvents nameWalletLabel As Label
    Friend WithEvents walletNameText As TextBox
    Friend WithEvents testSignature As Button
    Friend WithEvents paperAddress As Button
    Friend WithEvents saveAddressButton As Button
    Friend WithEvents paperWalletButton As Button
    Friend WithEvents createNewButton As Button
    Friend WithEvents securityPage As TabPage
    Friend WithEvents showCharacterAccessKEYButton As Button
    Friend WithEvents accessKEYTextBox As TextBox
    Friend WithEvents useProtectionKEYCheckbox As CheckBox
    Friend WithEvents rawPage As TabPage
    Friend WithEvents repeatAuthorizationKEYLabel As Label
    Friend WithEvents showCharacterRepeatAuthorizationKEYButton As Button
    Friend WithEvents repeatAuthorizationKeyTextArea As TextBox
    Friend WithEvents showCharacterAuthorizationKEYButton As Button
    Friend WithEvents authorizationKEYTextBox As TextBox
    Friend WithEvents useAuthorizationKEYCheckBox As CheckBox
    Friend WithEvents repeatAccessKEYLabel As Label
    Friend WithEvents showCharacterRepeatAccessKEYButton As Button
    Friend WithEvents repeatAccessKEYTextBox As TextBox
    Friend WithEvents errorAuthorizationKEYLabel As Label
    Friend WithEvents errorAccessKEYLabel As Label
    Friend WithEvents phraseLabel As Label
    Friend WithEvents seedValueTextArea As TextBox
    Friend WithEvents createWalletFromSeedButton As Button
    Friend WithEvents userKeyPair As KeyPair
    Friend WithEvents rawKeyPair As KeyPair
    Friend WithEvents UUIDText As TextBox
    Friend WithEvents KeyGUIDLabel As Label
    Friend WithEvents ppdMain As PrintPreviewDialog
    Friend WithEvents pDialogMain As PrintDialog
    Friend WithEvents pdMain As Printing.PrintDocument
End Class
