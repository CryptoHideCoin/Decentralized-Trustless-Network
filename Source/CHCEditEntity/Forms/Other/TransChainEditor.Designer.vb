<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransChainEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransChainEditor))
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.renameButton = New System.Windows.Forms.Button()
        Me.addNewButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.completePathValue = New System.Windows.Forms.ComboBox()
        Me.modeValue = New System.Windows.Forms.ComboBox()
        Me.saveBrowser = New System.Windows.Forms.SaveFileDialog()
        Me.tabControlMain = New System.Windows.Forms.TabControl()
        Me.tabPageConnection = New System.Windows.Forms.TabPage()
        Me.showKeywordValue = New System.Windows.Forms.CheckBox()
        Me.keyWordValue = New System.Windows.Forms.TextBox()
        Me.labelKeyword = New System.Windows.Forms.Label()
        Me.buttonNext = New System.Windows.Forms.Button()
        Me.urlValue = New System.Windows.Forms.TextBox()
        Me.labelURL = New System.Windows.Forms.Label()
        Me.radioButtonRemote = New System.Windows.Forms.RadioButton()
        Me.radioButtonLocal = New System.Windows.Forms.RadioButton()
        Me.tabPageEditor = New System.Windows.Forms.TabPage()
        Me.typeValue = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cryptoAssetValue = New System.Windows.Forms.ComboBox()
        Me.cryptoAssetLabel = New System.Windows.Forms.Label()
        Me.dateStartBox = New System.Windows.Forms.GroupBox()
        Me.helpNetworkNameLabel = New System.Windows.Forms.Label()
        Me.scheduleValue = New System.Windows.Forms.CheckBox()
        Me.startTransChainValue = New System.Windows.Forms.DateTimePicker()
        Me.dateStartTransChainLabel = New System.Windows.Forms.Label()
        Me.crowdFundValue = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.networkNameValue = New System.Windows.Forms.TextBox()
        Me.CoinNameLabel = New System.Windows.Forms.Label()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.pathLabel = New System.Windows.Forms.Label()
        Me.tabPageSecondary = New System.Windows.Forms.TabPage()
        Me.symbolLabel = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rewardPerDays = New System.Windows.Forms.TextBox()
        Me.numDecimalLabel = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.publicWalletPremined = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabControlMain.SuspendLayout()
        Me.tabPageConnection.SuspendLayout()
        Me.tabPageEditor.SuspendLayout()
        Me.dateStartBox.SuspendLayout()
        Me.tabPageSecondary.SuspendLayout()
        Me.SuspendLayout()
        '
        'deleteButton
        '
        Me.deleteButton.Enabled = False
        Me.deleteButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteButton.Location = New System.Drawing.Point(202, 400)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(87, 23)
        Me.deleteButton.TabIndex = 25
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'renameButton
        '
        Me.renameButton.Enabled = False
        Me.renameButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.renameButton.Location = New System.Drawing.Point(104, 400)
        Me.renameButton.Name = "renameButton"
        Me.renameButton.Size = New System.Drawing.Size(87, 23)
        Me.renameButton.TabIndex = 24
        Me.renameButton.Text = "Rename"
        Me.renameButton.UseVisualStyleBackColor = True
        '
        'addNewButton
        '
        Me.addNewButton.Enabled = False
        Me.addNewButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addNewButton.Location = New System.Drawing.Point(8, 400)
        Me.addNewButton.Name = "addNewButton"
        Me.addNewButton.Size = New System.Drawing.Size(87, 23)
        Me.addNewButton.TabIndex = 23
        Me.addNewButton.Text = "Add New"
        Me.addNewButton.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Enabled = False
        Me.confirmButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirmButton.Location = New System.Drawing.Point(522, 400)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(87, 23)
        Me.confirmButton.TabIndex = 26
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'completePathValue
        '
        Me.completePathValue.FormattingEnabled = True
        Me.completePathValue.Location = New System.Drawing.Point(21, 33)
        Me.completePathValue.Name = "completePathValue"
        Me.completePathValue.Size = New System.Drawing.Size(507, 21)
        Me.completePathValue.TabIndex = 7
        '
        'modeValue
        '
        Me.modeValue.AutoCompleteCustomSource.AddRange(New String() {"Main platform", "User Customized"})
        Me.modeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.modeValue.FormattingEnabled = True
        Me.modeValue.Items.AddRange(New Object() {"Official", "Testnet"})
        Me.modeValue.Location = New System.Drawing.Point(21, 127)
        Me.modeValue.Name = "modeValue"
        Me.modeValue.Size = New System.Drawing.Size(147, 21)
        Me.modeValue.TabIndex = 10
        '
        'saveBrowser
        '
        Me.saveBrowser.DefaultExt = "TransChainDefinition"
        Me.saveBrowser.Title = "Select file to write"
        '
        'tabControlMain
        '
        Me.tabControlMain.Controls.Add(Me.tabPageConnection)
        Me.tabControlMain.Controls.Add(Me.tabPageEditor)
        Me.tabControlMain.Controls.Add(Me.tabPageSecondary)
        Me.tabControlMain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControlMain.Location = New System.Drawing.Point(12, 12)
        Me.tabControlMain.Name = "tabControlMain"
        Me.tabControlMain.SelectedIndex = 0
        Me.tabControlMain.Size = New System.Drawing.Size(601, 372)
        Me.tabControlMain.TabIndex = 0
        '
        'tabPageConnection
        '
        Me.tabPageConnection.Controls.Add(Me.showKeywordValue)
        Me.tabPageConnection.Controls.Add(Me.keyWordValue)
        Me.tabPageConnection.Controls.Add(Me.labelKeyword)
        Me.tabPageConnection.Controls.Add(Me.buttonNext)
        Me.tabPageConnection.Controls.Add(Me.urlValue)
        Me.tabPageConnection.Controls.Add(Me.labelURL)
        Me.tabPageConnection.Controls.Add(Me.radioButtonRemote)
        Me.tabPageConnection.Controls.Add(Me.radioButtonLocal)
        Me.tabPageConnection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPageConnection.Location = New System.Drawing.Point(4, 22)
        Me.tabPageConnection.Name = "tabPageConnection"
        Me.tabPageConnection.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageConnection.Size = New System.Drawing.Size(593, 346)
        Me.tabPageConnection.TabIndex = 0
        Me.tabPageConnection.Text = "Mode"
        Me.tabPageConnection.UseVisualStyleBackColor = True
        '
        'showKeywordValue
        '
        Me.showKeywordValue.AutoSize = True
        Me.showKeywordValue.Enabled = False
        Me.showKeywordValue.Location = New System.Drawing.Point(55, 226)
        Me.showKeywordValue.Name = "showKeywordValue"
        Me.showKeywordValue.Size = New System.Drawing.Size(111, 17)
        Me.showKeywordValue.TabIndex = 5
        Me.showKeywordValue.Text = "Show Keyword"
        Me.showKeywordValue.UseVisualStyleBackColor = True
        '
        'keyWordValue
        '
        Me.keyWordValue.Enabled = False
        Me.keyWordValue.Location = New System.Drawing.Point(55, 196)
        Me.keyWordValue.Name = "keyWordValue"
        Me.keyWordValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.keyWordValue.Size = New System.Drawing.Size(499, 21)
        Me.keyWordValue.TabIndex = 4
        Me.keyWordValue.Text = "aa"
        '
        'labelKeyword
        '
        Me.labelKeyword.AutoSize = True
        Me.labelKeyword.Enabled = False
        Me.labelKeyword.Location = New System.Drawing.Point(51, 179)
        Me.labelKeyword.Name = "labelKeyword"
        Me.labelKeyword.Size = New System.Drawing.Size(118, 13)
        Me.labelKeyword.TabIndex = 5
        Me.labelKeyword.Text = "Keyword Protection"
        '
        'buttonNext
        '
        Me.buttonNext.Location = New System.Drawing.Point(467, 279)
        Me.buttonNext.Name = "buttonNext"
        Me.buttonNext.Size = New System.Drawing.Size(87, 23)
        Me.buttonNext.TabIndex = 6
        Me.buttonNext.Text = "Next"
        Me.buttonNext.UseVisualStyleBackColor = True
        '
        'urlValue
        '
        Me.urlValue.Enabled = False
        Me.urlValue.Location = New System.Drawing.Point(55, 150)
        Me.urlValue.Name = "urlValue"
        Me.urlValue.Size = New System.Drawing.Size(499, 21)
        Me.urlValue.TabIndex = 3
        Me.urlValue.Text = "https://localhost:44392/api/v1/"
        '
        'labelURL
        '
        Me.labelURL.AutoSize = True
        Me.labelURL.Enabled = False
        Me.labelURL.Location = New System.Drawing.Point(51, 133)
        Me.labelURL.Name = "labelURL"
        Me.labelURL.Size = New System.Drawing.Size(60, 13)
        Me.labelURL.TabIndex = 2
        Me.labelURL.Text = "URL base"
        '
        'radioButtonRemote
        '
        Me.radioButtonRemote.AutoSize = True
        Me.radioButtonRemote.Checked = True
        Me.radioButtonRemote.Location = New System.Drawing.Point(30, 100)
        Me.radioButtonRemote.Name = "radioButtonRemote"
        Me.radioButtonRemote.Size = New System.Drawing.Size(125, 17)
        Me.radioButtonRemote.TabIndex = 2
        Me.radioButtonRemote.TabStop = True
        Me.radioButtonRemote.Text = "Use Remote Data"
        Me.radioButtonRemote.UseVisualStyleBackColor = True
        '
        'radioButtonLocal
        '
        Me.radioButtonLocal.AutoSize = True
        Me.radioButtonLocal.Location = New System.Drawing.Point(30, 62)
        Me.radioButtonLocal.Name = "radioButtonLocal"
        Me.radioButtonLocal.Size = New System.Drawing.Size(110, 17)
        Me.radioButtonLocal.TabIndex = 1
        Me.radioButtonLocal.Text = "Use Local Data"
        Me.radioButtonLocal.UseVisualStyleBackColor = True
        '
        'tabPageEditor
        '
        Me.tabPageEditor.Controls.Add(Me.typeValue)
        Me.tabPageEditor.Controls.Add(Me.Label8)
        Me.tabPageEditor.Controls.Add(Me.cryptoAssetValue)
        Me.tabPageEditor.Controls.Add(Me.cryptoAssetLabel)
        Me.tabPageEditor.Controls.Add(Me.dateStartBox)
        Me.tabPageEditor.Controls.Add(Me.crowdFundValue)
        Me.tabPageEditor.Controls.Add(Me.Label1)
        Me.tabPageEditor.Controls.Add(Me.completePathValue)
        Me.tabPageEditor.Controls.Add(Me.modeValue)
        Me.tabPageEditor.Controls.Add(Me.Label3)
        Me.tabPageEditor.Controls.Add(Me.identityValue)
        Me.tabPageEditor.Controls.Add(Me.identityLabel)
        Me.tabPageEditor.Controls.Add(Me.networkNameValue)
        Me.tabPageEditor.Controls.Add(Me.CoinNameLabel)
        Me.tabPageEditor.Controls.Add(Me.browseButton)
        Me.tabPageEditor.Controls.Add(Me.pathLabel)
        Me.tabPageEditor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPageEditor.Location = New System.Drawing.Point(4, 22)
        Me.tabPageEditor.Name = "tabPageEditor"
        Me.tabPageEditor.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageEditor.Size = New System.Drawing.Size(593, 346)
        Me.tabPageEditor.TabIndex = 1
        Me.tabPageEditor.Text = "Main"
        Me.tabPageEditor.UseVisualStyleBackColor = True
        '
        'typeValue
        '
        Me.typeValue.AutoCompleteCustomSource.AddRange(New String() {"Main platform", "User Customized"})
        Me.typeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typeValue.FormattingEnabled = True
        Me.typeValue.Items.AddRange(New Object() {"Main Platform", "Crowdfund"})
        Me.typeValue.Location = New System.Drawing.Point(186, 127)
        Me.typeValue.Name = "typeValue"
        Me.typeValue.Size = New System.Drawing.Size(160, 21)
        Me.typeValue.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(183, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Type"
        '
        'cryptoAssetValue
        '
        Me.cryptoAssetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cryptoAssetValue.FormattingEnabled = True
        Me.cryptoAssetValue.Location = New System.Drawing.Point(363, 178)
        Me.cryptoAssetValue.Name = "cryptoAssetValue"
        Me.cryptoAssetValue.Size = New System.Drawing.Size(164, 21)
        Me.cryptoAssetValue.TabIndex = 14
        '
        'cryptoAssetLabel
        '
        Me.cryptoAssetLabel.AutoSize = True
        Me.cryptoAssetLabel.Location = New System.Drawing.Point(360, 162)
        Me.cryptoAssetLabel.Name = "cryptoAssetLabel"
        Me.cryptoAssetLabel.Size = New System.Drawing.Size(81, 13)
        Me.cryptoAssetLabel.TabIndex = 45
        Me.cryptoAssetLabel.Text = "Crypto Asset"
        '
        'dateStartBox
        '
        Me.dateStartBox.Controls.Add(Me.helpNetworkNameLabel)
        Me.dateStartBox.Controls.Add(Me.scheduleValue)
        Me.dateStartBox.Controls.Add(Me.startTransChainValue)
        Me.dateStartBox.Controls.Add(Me.dateStartTransChainLabel)
        Me.dateStartBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateStartBox.Location = New System.Drawing.Point(21, 214)
        Me.dateStartBox.Name = "dateStartBox"
        Me.dateStartBox.Size = New System.Drawing.Size(325, 93)
        Me.dateStartBox.TabIndex = 15
        Me.dateStartBox.TabStop = False
        '
        'helpNetworkNameLabel
        '
        Me.helpNetworkNameLabel.AutoSize = True
        Me.helpNetworkNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.helpNetworkNameLabel.ForeColor = System.Drawing.Color.Olive
        Me.helpNetworkNameLabel.Location = New System.Drawing.Point(242, 39)
        Me.helpNetworkNameLabel.Name = "helpNetworkNameLabel"
        Me.helpNetworkNameLabel.Size = New System.Drawing.Size(57, 13)
        Me.helpNetworkNameLabel.TabIndex = 17
        Me.helpNetworkNameLabel.Text = "(local time)"
        '
        'scheduleValue
        '
        Me.scheduleValue.AutoSize = True
        Me.scheduleValue.BackColor = System.Drawing.SystemColors.Window
        Me.scheduleValue.Location = New System.Drawing.Point(15, 0)
        Me.scheduleValue.Name = "scheduleValue"
        Me.scheduleValue.Size = New System.Drawing.Size(135, 17)
        Me.scheduleValue.TabIndex = 16
        Me.scheduleValue.Text = "Schedute first start"
        Me.scheduleValue.UseVisualStyleBackColor = False
        '
        'startTransChainValue
        '
        Me.startTransChainValue.CustomFormat = "dddd dd MMMM yyyy - HH:mm:ss"
        Me.startTransChainValue.Enabled = False
        Me.startTransChainValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.startTransChainValue.Location = New System.Drawing.Point(30, 55)
        Me.startTransChainValue.MinDate = New Date(2019, 1, 1, 0, 0, 0, 0)
        Me.startTransChainValue.Name = "startTransChainValue"
        Me.startTransChainValue.Size = New System.Drawing.Size(276, 21)
        Me.startTransChainValue.TabIndex = 17
        '
        'dateStartTransChainLabel
        '
        Me.dateStartTransChainLabel.AutoSize = True
        Me.dateStartTransChainLabel.Enabled = False
        Me.dateStartTransChainLabel.Location = New System.Drawing.Point(30, 38)
        Me.dateStartTransChainLabel.Name = "dateStartTransChainLabel"
        Me.dateStartTransChainLabel.Size = New System.Drawing.Size(143, 13)
        Me.dateStartTransChainLabel.TabIndex = 14
        Me.dateStartTransChainLabel.Text = "Network date/time start"
        '
        'crowdFundValue
        '
        Me.crowdFundValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.crowdFundValue.Enabled = False
        Me.crowdFundValue.FormattingEnabled = True
        Me.crowdFundValue.Items.AddRange(New Object() {"COIN", "TOKEN"})
        Me.crowdFundValue.Location = New System.Drawing.Point(363, 127)
        Me.crowdFundValue.Name = "crowdFundValue"
        Me.crowdFundValue.Size = New System.Drawing.Size(164, 21)
        Me.crowdFundValue.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(360, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Crowdfund configuration"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Mode"
        '
        'identityValue
        '
        Me.identityValue.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.identityValue.Location = New System.Drawing.Point(21, 79)
        Me.identityValue.Name = "identityValue"
        Me.identityValue.Size = New System.Drawing.Size(506, 21)
        Me.identityValue.TabIndex = 9
        Me.identityValue.TabStop = False
        Me.identityValue.Text = "NO FILE"
        Me.identityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'identityLabel
        '
        Me.identityLabel.AutoSize = True
        Me.identityLabel.Location = New System.Drawing.Point(17, 63)
        Me.identityLabel.Name = "identityLabel"
        Me.identityLabel.Size = New System.Drawing.Size(51, 13)
        Me.identityLabel.TabIndex = 33
        Me.identityLabel.Text = "Identity"
        '
        'networkNameValue
        '
        Me.networkNameValue.Location = New System.Drawing.Point(21, 178)
        Me.networkNameValue.Name = "networkNameValue"
        Me.networkNameValue.Size = New System.Drawing.Size(325, 21)
        Me.networkNameValue.TabIndex = 13
        '
        'CoinNameLabel
        '
        Me.CoinNameLabel.AutoSize = True
        Me.CoinNameLabel.Location = New System.Drawing.Point(18, 162)
        Me.CoinNameLabel.Name = "CoinNameLabel"
        Me.CoinNameLabel.Size = New System.Drawing.Size(91, 13)
        Me.CoinNameLabel.TabIndex = 26
        Me.CoinNameLabel.Text = "Network Name"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(534, 31)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(36, 23)
        Me.browseButton.TabIndex = 8
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'pathLabel
        '
        Me.pathLabel.AutoSize = True
        Me.pathLabel.Location = New System.Drawing.Point(17, 17)
        Me.pathLabel.Name = "pathLabel"
        Me.pathLabel.Size = New System.Drawing.Size(112, 13)
        Me.pathLabel.TabIndex = 27
        Me.pathLabel.Text = "Complete file path"
        '
        'tabPageSecondary
        '
        Me.tabPageSecondary.Controls.Add(Me.symbolLabel)
        Me.tabPageSecondary.Controls.Add(Me.TextBox3)
        Me.tabPageSecondary.Controls.Add(Me.Label7)
        Me.tabPageSecondary.Controls.Add(Me.rewardPerDays)
        Me.tabPageSecondary.Controls.Add(Me.numDecimalLabel)
        Me.tabPageSecondary.Controls.Add(Me.TextBox2)
        Me.tabPageSecondary.Controls.Add(Me.Label5)
        Me.tabPageSecondary.Controls.Add(Me.TextBox1)
        Me.tabPageSecondary.Controls.Add(Me.Label4)
        Me.tabPageSecondary.Controls.Add(Me.publicWalletPremined)
        Me.tabPageSecondary.Controls.Add(Me.Label2)
        Me.tabPageSecondary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPageSecondary.Location = New System.Drawing.Point(4, 22)
        Me.tabPageSecondary.Name = "tabPageSecondary"
        Me.tabPageSecondary.Size = New System.Drawing.Size(593, 346)
        Me.tabPageSecondary.TabIndex = 2
        Me.tabPageSecondary.Text = "Other"
        Me.tabPageSecondary.UseVisualStyleBackColor = True
        '
        'symbolLabel
        '
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.symbolLabel.Location = New System.Drawing.Point(401, 190)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(11, 14)
        Me.symbolLabel.TabIndex = 60
        Me.symbolLabel.Text = " "
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(24, 187)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(243, 21)
        Me.TextBox3.TabIndex = 21
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "Every 24h"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 13)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Interval to consensus stake"
        '
        'rewardPerDays
        '
        Me.rewardPerDays.Location = New System.Drawing.Point(283, 187)
        Me.rewardPerDays.Name = "rewardPerDays"
        Me.rewardPerDays.Size = New System.Drawing.Size(111, 21)
        Me.rewardPerDays.TabIndex = 22
        Me.rewardPerDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDecimalLabel
        '
        Me.numDecimalLabel.AutoSize = True
        Me.numDecimalLabel.Location = New System.Drawing.Point(279, 171)
        Me.numDecimalLabel.Name = "numDecimalLabel"
        Me.numDecimalLabel.Size = New System.Drawing.Size(98, 13)
        Me.numDecimalLabel.TabIndex = 57
        Me.numDecimalLabel.Text = "Reward per day"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(283, 132)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(247, 21)
        Me.TextBox2.TabIndex = 20
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "CHCPTs"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(279, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Protocol Name"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(25, 132)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(242, 21)
        Me.TextBox1.TabIndex = 19
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Proof of Stake"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Consensus Type"
        '
        'publicWalletPremined
        '
        Me.publicWalletPremined.Location = New System.Drawing.Point(24, 30)
        Me.publicWalletPremined.Multiline = True
        Me.publicWalletPremined.Name = "publicWalletPremined"
        Me.publicWalletPremined.Size = New System.Drawing.Size(506, 76)
        Me.publicWalletPremined.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Public Wallet Address Premined"
        '
        'TransChainEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 440)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.renameButton)
        Me.Controls.Add(Me.addNewButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.tabControlMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TransChainEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin DTN - Editor Transaction Chain Network"
        Me.tabControlMain.ResumeLayout(False)
        Me.tabPageConnection.ResumeLayout(False)
        Me.tabPageConnection.PerformLayout()
        Me.tabPageEditor.ResumeLayout(False)
        Me.tabPageEditor.PerformLayout()
        Me.dateStartBox.ResumeLayout(False)
        Me.dateStartBox.PerformLayout()
        Me.tabPageSecondary.ResumeLayout(False)
        Me.tabPageSecondary.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents deleteButton As Button
    Friend WithEvents renameButton As Button
    Friend WithEvents addNewButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents completePathValue As ComboBox
    Friend WithEvents modeValue As ComboBox
    Friend WithEvents saveBrowser As SaveFileDialog
    Friend WithEvents tabControlMain As TabControl
    Friend WithEvents tabPageConnection As TabPage
    Friend WithEvents showKeywordValue As CheckBox
    Friend WithEvents keyWordValue As TextBox
    Friend WithEvents labelKeyword As Label
    Friend WithEvents buttonNext As Button
    Friend WithEvents urlValue As TextBox
    Friend WithEvents labelURL As Label
    Friend WithEvents radioButtonRemote As RadioButton
    Friend WithEvents radioButtonLocal As RadioButton
    Friend WithEvents tabPageEditor As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents networkNameValue As TextBox
    Friend WithEvents CoinNameLabel As Label
    Friend WithEvents browseButton As Button
    Friend WithEvents pathLabel As Label
    Friend WithEvents crowdFundValue As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dateStartBox As GroupBox
    Friend WithEvents helpNetworkNameLabel As Label
    Friend WithEvents scheduleValue As CheckBox
    Friend WithEvents startTransChainValue As DateTimePicker
    Friend WithEvents dateStartTransChainLabel As Label
    Friend WithEvents cryptoAssetValue As ComboBox
    Friend WithEvents cryptoAssetLabel As Label
    Friend WithEvents tabPageSecondary As TabPage
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents publicWalletPremined As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents rewardPerDays As TextBox
    Friend WithEvents numDecimalLabel As Label
    Friend WithEvents typeValue As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents symbolLabel As Label
End Class
