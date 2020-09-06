<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.testSignature = New System.Windows.Forms.Button()
        Me.pDialogMain = New System.Windows.Forms.PrintDialog()
        Me.pdMain = New System.Drawing.Printing.PrintDocument()
        Me.ppdMain = New System.Windows.Forms.PrintPreviewDialog()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.qrCodeImage = New System.Windows.Forms.PictureBox()
        Me.closeUserButton = New System.Windows.Forms.Button()
        Me.paperAddress = New System.Windows.Forms.Button()
        Me.loadWalletFileButton = New System.Windows.Forms.Button()
        Me.downloadWalletButton = New System.Windows.Forms.Button()
        Me.paperWalletButton = New System.Windows.Forms.Button()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.qrCodePanel = New System.Windows.Forms.Panel()
        Me.seed = New System.Windows.Forms.TabPage()
        Me.createWalletFromSeed = New System.Windows.Forms.Button()
        Me.seedValue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.userTab = New System.Windows.Forms.TabPage()
        Me.copyPrivateKEY = New System.Windows.Forms.Button()
        Me.copyPublicAddress = New System.Windows.Forms.Button()
        Me.charCounterPrivateAddress = New System.Windows.Forms.Label()
        Me.qrPrivateAddressButton = New System.Windows.Forms.Button()
        Me.qrPublicAddressButton = New System.Windows.Forms.Button()
        Me.privateKey = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.publicAddress = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.internalTab = New System.Windows.Forms.TabPage()
        Me.privateKeyInternal = New System.Windows.Forms.TextBox()
        Me.publicAddressInternal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.qrCodePanel.SuspendLayout()
        Me.seed.SuspendLayout()
        Me.mainTab.SuspendLayout()
        Me.userTab.SuspendLayout()
        Me.internalTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'testSignature
        '
        Me.testSignature.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testSignature.Location = New System.Drawing.Point(545, 247)
        Me.testSignature.Name = "testSignature"
        Me.testSignature.Size = New System.Drawing.Size(106, 36)
        Me.testSignature.TabIndex = 25
        Me.testSignature.Text = "Test Signature"
        Me.testSignature.UseVisualStyleBackColor = True
        '
        'pDialogMain
        '
        Me.pDialogMain.Document = Me.pdMain
        Me.pDialogMain.UseEXDialog = True
        '
        'pdMain
        '
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
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 13)
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
        Me.qrCodeImage.Location = New System.Drawing.Point(0, 30)
        Me.qrCodeImage.Name = "qrCodeImage"
        Me.qrCodeImage.Size = New System.Drawing.Size(527, 256)
        Me.qrCodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.qrCodeImage.TabIndex = 16
        Me.qrCodeImage.TabStop = False
        Me.qrCodeImage.Visible = False
        '
        'closeUserButton
        '
        Me.closeUserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeUserButton.Location = New System.Drawing.Point(451, 7)
        Me.closeUserButton.Name = "closeUserButton"
        Me.closeUserButton.Size = New System.Drawing.Size(73, 22)
        Me.closeUserButton.TabIndex = 0
        Me.closeUserButton.Text = "Close"
        Me.closeUserButton.UseVisualStyleBackColor = True
        '
        'paperAddress
        '
        Me.paperAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.paperAddress.Enabled = False
        Me.paperAddress.Location = New System.Drawing.Point(545, 112)
        Me.paperAddress.Name = "paperAddress"
        Me.paperAddress.Size = New System.Drawing.Size(106, 36)
        Me.paperAddress.TabIndex = 24
        Me.paperAddress.Text = "Paper Address"
        Me.paperAddress.UseVisualStyleBackColor = True
        '
        'loadWalletFileButton
        '
        Me.loadWalletFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadWalletFileButton.Location = New System.Drawing.Point(545, 200)
        Me.loadWalletFileButton.Name = "loadWalletFileButton"
        Me.loadWalletFileButton.Size = New System.Drawing.Size(106, 36)
        Me.loadWalletFileButton.TabIndex = 22
        Me.loadWalletFileButton.Text = "Load Wallet File"
        Me.loadWalletFileButton.UseVisualStyleBackColor = True
        '
        'downloadWalletButton
        '
        Me.downloadWalletButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.downloadWalletButton.Enabled = False
        Me.downloadWalletButton.Location = New System.Drawing.Point(545, 156)
        Me.downloadWalletButton.Name = "downloadWalletButton"
        Me.downloadWalletButton.Size = New System.Drawing.Size(106, 36)
        Me.downloadWalletButton.TabIndex = 21
        Me.downloadWalletButton.Text = "Download Wallet"
        Me.downloadWalletButton.UseVisualStyleBackColor = True
        '
        'paperWalletButton
        '
        Me.paperWalletButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.paperWalletButton.Enabled = False
        Me.paperWalletButton.Location = New System.Drawing.Point(545, 68)
        Me.paperWalletButton.Name = "paperWalletButton"
        Me.paperWalletButton.Size = New System.Drawing.Size(106, 36)
        Me.paperWalletButton.TabIndex = 20
        Me.paperWalletButton.Text = "Paper wallet"
        Me.paperWalletButton.UseVisualStyleBackColor = True
        '
        'createNewButton
        '
        Me.createNewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewButton.Location = New System.Drawing.Point(545, 24)
        Me.createNewButton.Name = "createNewButton"
        Me.createNewButton.Size = New System.Drawing.Size(106, 36)
        Me.createNewButton.TabIndex = 19
        Me.createNewButton.Text = "Create New"
        Me.createNewButton.UseVisualStyleBackColor = True
        '
        'qrCodePanel
        '
        Me.qrCodePanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.qrCodePanel.Controls.Add(Me.Label5)
        Me.qrCodePanel.Controls.Add(Me.qrCodeImage)
        Me.qrCodePanel.Controls.Add(Me.closeUserButton)
        Me.qrCodePanel.Location = New System.Drawing.Point(5, -1)
        Me.qrCodePanel.Name = "qrCodePanel"
        Me.qrCodePanel.Size = New System.Drawing.Size(528, 290)
        Me.qrCodePanel.TabIndex = 23
        Me.qrCodePanel.Visible = False
        '
        'seed
        '
        Me.seed.Controls.Add(Me.createWalletFromSeed)
        Me.seed.Controls.Add(Me.seedValue)
        Me.seed.Controls.Add(Me.Label6)
        Me.seed.Location = New System.Drawing.Point(4, 22)
        Me.seed.Name = "seed"
        Me.seed.Size = New System.Drawing.Size(520, 270)
        Me.seed.TabIndex = 2
        Me.seed.Text = "Seed"
        Me.seed.UseVisualStyleBackColor = True
        '
        'createWalletFromSeed
        '
        Me.createWalletFromSeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createWalletFromSeed.Enabled = False
        Me.createWalletFromSeed.Location = New System.Drawing.Point(572, 91)
        Me.createWalletFromSeed.Name = "createWalletFromSeed"
        Me.createWalletFromSeed.Size = New System.Drawing.Size(87, 40)
        Me.createWalletFromSeed.TabIndex = 2
        Me.createWalletFromSeed.Text = "Create Wallet"
        Me.createWalletFromSeed.UseVisualStyleBackColor = True
        '
        'seedValue
        '
        Me.seedValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.seedValue.Location = New System.Drawing.Point(13, 26)
        Me.seedValue.MaxLength = 250
        Me.seedValue.Multiline = True
        Me.seedValue.Name = "seedValue"
        Me.seedValue.Size = New System.Drawing.Size(646, 59)
        Me.seedValue.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(303, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Insert a phrase useful for creating the wallet (seed)"
        '
        'mainTab
        '
        Me.mainTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTab.Controls.Add(Me.userTab)
        Me.mainTab.Controls.Add(Me.internalTab)
        Me.mainTab.Controls.Add(Me.seed)
        Me.mainTab.Location = New System.Drawing.Point(5, -1)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(528, 296)
        Me.mainTab.TabIndex = 18
        '
        'userTab
        '
        Me.userTab.Controls.Add(Me.copyPrivateKEY)
        Me.userTab.Controls.Add(Me.copyPublicAddress)
        Me.userTab.Controls.Add(Me.charCounterPrivateAddress)
        Me.userTab.Controls.Add(Me.qrPrivateAddressButton)
        Me.userTab.Controls.Add(Me.qrPublicAddressButton)
        Me.userTab.Controls.Add(Me.privateKey)
        Me.userTab.Controls.Add(Me.Label2)
        Me.userTab.Controls.Add(Me.publicAddress)
        Me.userTab.Controls.Add(Me.Label1)
        Me.userTab.Location = New System.Drawing.Point(4, 22)
        Me.userTab.Name = "userTab"
        Me.userTab.Padding = New System.Windows.Forms.Padding(3)
        Me.userTab.Size = New System.Drawing.Size(520, 270)
        Me.userTab.TabIndex = 0
        Me.userTab.Text = "User"
        Me.userTab.UseVisualStyleBackColor = True
        '
        'copyPrivateKEY
        '
        Me.copyPrivateKEY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.copyPrivateKEY.Enabled = False
        Me.copyPrivateKEY.Location = New System.Drawing.Point(411, 233)
        Me.copyPrivateKEY.Name = "copyPrivateKEY"
        Me.copyPrivateKEY.Size = New System.Drawing.Size(56, 23)
        Me.copyPrivateKEY.TabIndex = 13
        Me.copyPrivateKEY.Text = "COPY"
        Me.copyPrivateKEY.UseVisualStyleBackColor = True
        '
        'copyPublicAddress
        '
        Me.copyPublicAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.copyPublicAddress.Enabled = False
        Me.copyPublicAddress.Location = New System.Drawing.Point(411, 83)
        Me.copyPublicAddress.Name = "copyPublicAddress"
        Me.copyPublicAddress.Size = New System.Drawing.Size(56, 23)
        Me.copyPublicAddress.TabIndex = 12
        Me.copyPublicAddress.Text = "COPY"
        Me.copyPublicAddress.UseVisualStyleBackColor = True
        '
        'charCounterPrivateAddress
        '
        Me.charCounterPrivateAddress.AutoSize = True
        Me.charCounterPrivateAddress.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.charCounterPrivateAddress.ForeColor = System.Drawing.Color.Teal
        Me.charCounterPrivateAddress.Location = New System.Drawing.Point(632, 119)
        Me.charCounterPrivateAddress.Name = "charCounterPrivateAddress"
        Me.charCounterPrivateAddress.Size = New System.Drawing.Size(27, 12)
        Me.charCounterPrivateAddress.TabIndex = 11
        Me.charCounterPrivateAddress.Text = "x / x"
        '
        'qrPrivateAddressButton
        '
        Me.qrPrivateAddressButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.qrPrivateAddressButton.Enabled = False
        Me.qrPrivateAddressButton.Location = New System.Drawing.Point(468, 233)
        Me.qrPrivateAddressButton.Name = "qrPrivateAddressButton"
        Me.qrPrivateAddressButton.Size = New System.Drawing.Size(38, 23)
        Me.qrPrivateAddressButton.TabIndex = 9
        Me.qrPrivateAddressButton.Text = "QR"
        Me.qrPrivateAddressButton.UseVisualStyleBackColor = True
        '
        'qrPublicAddressButton
        '
        Me.qrPublicAddressButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.qrPublicAddressButton.Enabled = False
        Me.qrPublicAddressButton.Location = New System.Drawing.Point(468, 83)
        Me.qrPublicAddressButton.Name = "qrPublicAddressButton"
        Me.qrPublicAddressButton.Size = New System.Drawing.Size(38, 23)
        Me.qrPublicAddressButton.TabIndex = 8
        Me.qrPublicAddressButton.Text = "QR"
        Me.qrPublicAddressButton.UseVisualStyleBackColor = True
        '
        'privateKey
        '
        Me.privateKey.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.privateKey.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privateKey.ForeColor = System.Drawing.Color.DarkBlue
        Me.privateKey.Location = New System.Drawing.Point(10, 134)
        Me.privateKey.Multiline = True
        Me.privateKey.Name = "privateKey"
        Me.privateKey.Size = New System.Drawing.Size(497, 123)
        Me.privateKey.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Private KEY"
        '
        'publicAddress
        '
        Me.publicAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicAddress.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicAddress.ForeColor = System.Drawing.Color.DarkBlue
        Me.publicAddress.Location = New System.Drawing.Point(10, 30)
        Me.publicAddress.Multiline = True
        Me.publicAddress.Name = "publicAddress"
        Me.publicAddress.ReadOnly = True
        Me.publicAddress.Size = New System.Drawing.Size(497, 77)
        Me.publicAddress.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Public Address"
        '
        'internalTab
        '
        Me.internalTab.Controls.Add(Me.privateKeyInternal)
        Me.internalTab.Controls.Add(Me.publicAddressInternal)
        Me.internalTab.Controls.Add(Me.Label3)
        Me.internalTab.Controls.Add(Me.Label4)
        Me.internalTab.Location = New System.Drawing.Point(4, 22)
        Me.internalTab.Name = "internalTab"
        Me.internalTab.Padding = New System.Windows.Forms.Padding(3)
        Me.internalTab.Size = New System.Drawing.Size(520, 270)
        Me.internalTab.TabIndex = 1
        Me.internalTab.Text = "RAW"
        Me.internalTab.UseVisualStyleBackColor = True
        '
        'privateKeyInternal
        '
        Me.privateKeyInternal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.privateKeyInternal.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privateKeyInternal.ForeColor = System.Drawing.Color.DarkBlue
        Me.privateKeyInternal.Location = New System.Drawing.Point(10, 134)
        Me.privateKeyInternal.Multiline = True
        Me.privateKeyInternal.Name = "privateKeyInternal"
        Me.privateKeyInternal.ReadOnly = True
        Me.privateKeyInternal.Size = New System.Drawing.Size(654, 123)
        Me.privateKeyInternal.TabIndex = 12
        '
        'publicAddressInternal
        '
        Me.publicAddressInternal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicAddressInternal.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicAddressInternal.ForeColor = System.Drawing.Color.DarkBlue
        Me.publicAddressInternal.Location = New System.Drawing.Point(10, 30)
        Me.publicAddressInternal.Multiline = True
        Me.publicAddressInternal.Name = "publicAddressInternal"
        Me.publicAddressInternal.ReadOnly = True
        Me.publicAddressInternal.Size = New System.Drawing.Size(654, 77)
        Me.publicAddressInternal.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Private KEY"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Public Address"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(656, 295)
        Me.Controls.Add(Me.testSignature)
        Me.Controls.Add(Me.paperAddress)
        Me.Controls.Add(Me.loadWalletFileButton)
        Me.Controls.Add(Me.downloadWalletButton)
        Me.Controls.Add(Me.paperWalletButton)
        Me.Controls.Add(Me.createNewButton)
        Me.Controls.Add(Me.mainTab)
        Me.Controls.Add(Me.qrCodePanel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Wallet - Crypto Hide Coin"
        CType(Me.qrCodeImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.qrCodePanel.ResumeLayout(False)
        Me.qrCodePanel.PerformLayout()
        Me.seed.ResumeLayout(False)
        Me.seed.PerformLayout()
        Me.mainTab.ResumeLayout(False)
        Me.userTab.ResumeLayout(False)
        Me.userTab.PerformLayout()
        Me.internalTab.ResumeLayout(False)
        Me.internalTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents testSignature As Button
    Friend WithEvents pDialogMain As PrintDialog
    Friend WithEvents pdMain As Printing.PrintDocument
    Friend WithEvents ppdMain As PrintPreviewDialog
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents saveFileDialog As SaveFileDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents qrCodeImage As PictureBox
    Friend WithEvents closeUserButton As Button
    Friend WithEvents paperAddress As Button
    Friend WithEvents loadWalletFileButton As Button
    Friend WithEvents downloadWalletButton As Button
    Friend WithEvents paperWalletButton As Button
    Friend WithEvents createNewButton As Button
    Friend WithEvents qrCodePanel As Panel
    Friend WithEvents seed As TabPage
    Friend WithEvents createWalletFromSeed As Button
    Friend WithEvents seedValue As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents mainTab As TabControl
    Friend WithEvents userTab As TabPage
    Friend WithEvents copyPrivateKEY As Button
    Friend WithEvents copyPublicAddress As Button
    Friend WithEvents charCounterPrivateAddress As Label
    Friend WithEvents qrPrivateAddressButton As Button
    Friend WithEvents qrPublicAddressButton As Button
    Friend WithEvents privateKey As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents publicAddress As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents internalTab As TabPage
    Friend WithEvents privateKeyInternal As TextBox
    Friend WithEvents publicAddressInternal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
