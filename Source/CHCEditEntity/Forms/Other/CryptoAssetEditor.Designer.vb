<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CryptoAssetEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CryptoAssetEditor))
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
        Me.completePathValue = New System.Windows.Forms.ComboBox()
        Me.lblSymbol2 = New System.Windows.Forms.Label()
        Me.symbolValue = New System.Windows.Forms.TextBox()
        Me.symbolLabel1 = New System.Windows.Forms.Label()
        Me.symbolLabel = New System.Windows.Forms.Label()
        Me.numOfDecimalValue = New System.Windows.Forms.TextBox()
        Me.typeValue = New System.Windows.Forms.ComboBox()
        Me.numDecimalLabel = New System.Windows.Forms.Label()
        Me.shortNameValue = New System.Windows.Forms.TextBox()
        Me.noTotalValue = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mintable = New System.Windows.Forms.CheckBox()
        Me.shortNameLabel = New System.Windows.Forms.Label()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.totalCoinValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.totalCoinLabel = New System.Windows.Forms.Label()
        Me.coinNameValue = New System.Windows.Forms.TextBox()
        Me.preminedValue = New System.Windows.Forms.TextBox()
        Me.CoinNameLabel = New System.Windows.Forms.Label()
        Me.preminedLabel = New System.Windows.Forms.Label()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.burnableValue = New System.Windows.Forms.CheckBox()
        Me.pathLabel = New System.Windows.Forms.Label()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.addNewButton = New System.Windows.Forms.Button()
        Me.renameButton = New System.Windows.Forms.Button()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.tabControlMain.SuspendLayout()
        Me.tabPageConnection.SuspendLayout()
        Me.tabPageEditor.SuspendLayout()
        Me.SuspendLayout()
        '
        'saveBrowser
        '
        Me.saveBrowser.DefaultExt = "CryptoAssetDefinition"
        Me.saveBrowser.Title = "Select file to write"
        '
        'tabControlMain
        '
        Me.tabControlMain.Controls.Add(Me.tabPageConnection)
        Me.tabControlMain.Controls.Add(Me.tabPageEditor)
        Me.tabControlMain.Location = New System.Drawing.Point(14, 12)
        Me.tabControlMain.Name = "tabControlMain"
        Me.tabControlMain.SelectedIndex = 0
        Me.tabControlMain.Size = New System.Drawing.Size(601, 348)
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
        Me.tabPageConnection.Location = New System.Drawing.Point(4, 22)
        Me.tabPageConnection.Name = "tabPageConnection"
        Me.tabPageConnection.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageConnection.Size = New System.Drawing.Size(593, 322)
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
        Me.urlValue.Text = "https://localhost:44392/api/v1/configuration/CryptoAssetDefinition"
        '
        'labelURL
        '
        Me.labelURL.AutoSize = True
        Me.labelURL.Enabled = False
        Me.labelURL.Location = New System.Drawing.Point(51, 133)
        Me.labelURL.Name = "labelURL"
        Me.labelURL.Size = New System.Drawing.Size(29, 13)
        Me.labelURL.TabIndex = 2
        Me.labelURL.Text = "URL"
        '
        'radioButtonRemote
        '
        Me.radioButtonRemote.AutoSize = True
        Me.radioButtonRemote.Location = New System.Drawing.Point(30, 100)
        Me.radioButtonRemote.Name = "radioButtonRemote"
        Me.radioButtonRemote.Size = New System.Drawing.Size(125, 17)
        Me.radioButtonRemote.TabIndex = 2
        Me.radioButtonRemote.Text = "Use Remote Data"
        Me.radioButtonRemote.UseVisualStyleBackColor = True
        '
        'radioButtonLocal
        '
        Me.radioButtonLocal.AutoSize = True
        Me.radioButtonLocal.Checked = True
        Me.radioButtonLocal.Location = New System.Drawing.Point(30, 62)
        Me.radioButtonLocal.Name = "radioButtonLocal"
        Me.radioButtonLocal.Size = New System.Drawing.Size(110, 17)
        Me.radioButtonLocal.TabIndex = 1
        Me.radioButtonLocal.TabStop = True
        Me.radioButtonLocal.Text = "Use Local Data"
        Me.radioButtonLocal.UseVisualStyleBackColor = True
        '
        'tabPageEditor
        '
        Me.tabPageEditor.Controls.Add(Me.completePathValue)
        Me.tabPageEditor.Controls.Add(Me.lblSymbol2)
        Me.tabPageEditor.Controls.Add(Me.symbolValue)
        Me.tabPageEditor.Controls.Add(Me.symbolLabel1)
        Me.tabPageEditor.Controls.Add(Me.symbolLabel)
        Me.tabPageEditor.Controls.Add(Me.numOfDecimalValue)
        Me.tabPageEditor.Controls.Add(Me.typeValue)
        Me.tabPageEditor.Controls.Add(Me.numDecimalLabel)
        Me.tabPageEditor.Controls.Add(Me.shortNameValue)
        Me.tabPageEditor.Controls.Add(Me.noTotalValue)
        Me.tabPageEditor.Controls.Add(Me.Label3)
        Me.tabPageEditor.Controls.Add(Me.mintable)
        Me.tabPageEditor.Controls.Add(Me.shortNameLabel)
        Me.tabPageEditor.Controls.Add(Me.identityValue)
        Me.tabPageEditor.Controls.Add(Me.totalCoinValue)
        Me.tabPageEditor.Controls.Add(Me.identityLabel)
        Me.tabPageEditor.Controls.Add(Me.totalCoinLabel)
        Me.tabPageEditor.Controls.Add(Me.coinNameValue)
        Me.tabPageEditor.Controls.Add(Me.preminedValue)
        Me.tabPageEditor.Controls.Add(Me.CoinNameLabel)
        Me.tabPageEditor.Controls.Add(Me.preminedLabel)
        Me.tabPageEditor.Controls.Add(Me.browseButton)
        Me.tabPageEditor.Controls.Add(Me.burnableValue)
        Me.tabPageEditor.Controls.Add(Me.pathLabel)
        Me.tabPageEditor.Location = New System.Drawing.Point(4, 22)
        Me.tabPageEditor.Name = "tabPageEditor"
        Me.tabPageEditor.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageEditor.Size = New System.Drawing.Size(593, 322)
        Me.tabPageEditor.TabIndex = 1
        Me.tabPageEditor.Text = "Data"
        Me.tabPageEditor.UseVisualStyleBackColor = True
        '
        'completePathValue
        '
        Me.completePathValue.FormattingEnabled = True
        Me.completePathValue.Location = New System.Drawing.Point(21, 33)
        Me.completePathValue.Name = "completePathValue"
        Me.completePathValue.Size = New System.Drawing.Size(507, 21)
        Me.completePathValue.TabIndex = 7
        '
        'lblSymbol2
        '
        Me.lblSymbol2.AutoSize = True
        Me.lblSymbol2.Location = New System.Drawing.Point(509, 270)
        Me.lblSymbol2.Name = "lblSymbol2"
        Me.lblSymbol2.Size = New System.Drawing.Size(21, 13)
        Me.lblSymbol2.TabIndex = 40
        Me.lblSymbol2.Text = "xx"
        '
        'symbolValue
        '
        Me.symbolValue.Location = New System.Drawing.Point(189, 179)
        Me.symbolValue.Name = "symbolValue"
        Me.symbolValue.Size = New System.Drawing.Size(60, 21)
        Me.symbolValue.TabIndex = 12
        Me.symbolValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'symbolLabel1
        '
        Me.symbolLabel1.AutoSize = True
        Me.symbolLabel1.Location = New System.Drawing.Point(313, 270)
        Me.symbolLabel1.Name = "symbolLabel1"
        Me.symbolLabel1.Size = New System.Drawing.Size(21, 13)
        Me.symbolLabel1.TabIndex = 39
        Me.symbolLabel1.Text = "xx"
        '
        'symbolLabel
        '
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Location = New System.Drawing.Point(185, 163)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(50, 13)
        Me.symbolLabel.TabIndex = 35
        Me.symbolLabel.Text = "Symbol"
        '
        'numOfDecimalValue
        '
        Me.numOfDecimalValue.Location = New System.Drawing.Point(21, 267)
        Me.numOfDecimalValue.Name = "numOfDecimalValue"
        Me.numOfDecimalValue.Size = New System.Drawing.Size(111, 21)
        Me.numOfDecimalValue.TabIndex = 16
        Me.numOfDecimalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'typeValue
        '
        Me.typeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typeValue.FormattingEnabled = True
        Me.typeValue.Items.AddRange(New Object() {"COIN", "TOKEN"})
        Me.typeValue.Location = New System.Drawing.Point(21, 127)
        Me.typeValue.Name = "typeValue"
        Me.typeValue.Size = New System.Drawing.Size(147, 21)
        Me.typeValue.TabIndex = 9
        '
        'numDecimalLabel
        '
        Me.numDecimalLabel.AutoSize = True
        Me.numDecimalLabel.Location = New System.Drawing.Point(17, 251)
        Me.numDecimalLabel.Name = "numDecimalLabel"
        Me.numDecimalLabel.Size = New System.Drawing.Size(121, 13)
        Me.numDecimalLabel.TabIndex = 38
        Me.numDecimalLabel.Text = "Number of decimals"
        '
        'shortNameValue
        '
        Me.shortNameValue.Location = New System.Drawing.Point(21, 179)
        Me.shortNameValue.Name = "shortNameValue"
        Me.shortNameValue.Size = New System.Drawing.Size(157, 21)
        Me.shortNameValue.TabIndex = 11
        '
        'noTotalValue
        '
        Me.noTotalValue.AutoSize = True
        Me.noTotalValue.Location = New System.Drawing.Point(339, 219)
        Me.noTotalValue.Name = "noTotalValue"
        Me.noTotalValue.Size = New System.Drawing.Size(75, 17)
        Me.noTotalValue.TabIndex = 15
        Me.noTotalValue.Text = "Limitless"
        Me.noTotalValue.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Type"
        '
        'mintable
        '
        Me.mintable.AutoSize = True
        Me.mintable.Location = New System.Drawing.Point(160, 219)
        Me.mintable.Name = "mintable"
        Me.mintable.Size = New System.Drawing.Size(73, 17)
        Me.mintable.TabIndex = 14
        Me.mintable.Text = "Mintable"
        Me.mintable.UseVisualStyleBackColor = True
        '
        'shortNameLabel
        '
        Me.shortNameLabel.AutoSize = True
        Me.shortNameLabel.Location = New System.Drawing.Point(17, 162)
        Me.shortNameLabel.Name = "shortNameLabel"
        Me.shortNameLabel.Size = New System.Drawing.Size(75, 13)
        Me.shortNameLabel.TabIndex = 30
        Me.shortNameLabel.Text = "Short Name"
        '
        'identityValue
        '
        Me.identityValue.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.identityValue.Location = New System.Drawing.Point(21, 79)
        Me.identityValue.Name = "identityValue"
        Me.identityValue.Size = New System.Drawing.Size(506, 21)
        Me.identityValue.TabIndex = 37
        Me.identityValue.TabStop = False
        Me.identityValue.Text = "NO FILE"
        Me.identityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'totalCoinValue
        '
        Me.totalCoinValue.Location = New System.Drawing.Point(339, 267)
        Me.totalCoinValue.Name = "totalCoinValue"
        Me.totalCoinValue.Size = New System.Drawing.Size(161, 21)
        Me.totalCoinValue.TabIndex = 18
        Me.totalCoinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'totalCoinLabel
        '
        Me.totalCoinLabel.AutoSize = True
        Me.totalCoinLabel.Location = New System.Drawing.Point(336, 251)
        Me.totalCoinLabel.Name = "totalCoinLabel"
        Me.totalCoinLabel.Size = New System.Drawing.Size(34, 13)
        Me.totalCoinLabel.TabIndex = 29
        Me.totalCoinLabel.Text = "Total"
        '
        'coinNameValue
        '
        Me.coinNameValue.Location = New System.Drawing.Point(189, 127)
        Me.coinNameValue.Name = "coinNameValue"
        Me.coinNameValue.Size = New System.Drawing.Size(338, 21)
        Me.coinNameValue.TabIndex = 10
        '
        'preminedValue
        '
        Me.preminedValue.Location = New System.Drawing.Point(160, 267)
        Me.preminedValue.Name = "preminedValue"
        Me.preminedValue.Size = New System.Drawing.Size(145, 21)
        Me.preminedValue.TabIndex = 17
        Me.preminedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CoinNameLabel
        '
        Me.CoinNameLabel.AutoSize = True
        Me.CoinNameLabel.Location = New System.Drawing.Point(185, 110)
        Me.CoinNameLabel.Name = "CoinNameLabel"
        Me.CoinNameLabel.Size = New System.Drawing.Size(40, 13)
        Me.CoinNameLabel.TabIndex = 26
        Me.CoinNameLabel.Text = "Name"
        '
        'preminedLabel
        '
        Me.preminedLabel.AutoSize = True
        Me.preminedLabel.Location = New System.Drawing.Point(156, 251)
        Me.preminedLabel.Name = "preminedLabel"
        Me.preminedLabel.Size = New System.Drawing.Size(158, 13)
        Me.preminedLabel.TabIndex = 25
        Me.preminedLabel.Text = "Number of premined coins"
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
        'burnableValue
        '
        Me.burnableValue.AutoSize = True
        Me.burnableValue.Location = New System.Drawing.Point(21, 219)
        Me.burnableValue.Name = "burnableValue"
        Me.burnableValue.Size = New System.Drawing.Size(77, 17)
        Me.burnableValue.TabIndex = 13
        Me.burnableValue.Text = "Burnable"
        Me.burnableValue.UseVisualStyleBackColor = True
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
        'confirmButton
        '
        Me.confirmButton.Enabled = False
        Me.confirmButton.Location = New System.Drawing.Point(523, 372)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(87, 23)
        Me.confirmButton.TabIndex = 22
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'addNewButton
        '
        Me.addNewButton.Enabled = False
        Me.addNewButton.Location = New System.Drawing.Point(14, 372)
        Me.addNewButton.Name = "addNewButton"
        Me.addNewButton.Size = New System.Drawing.Size(87, 23)
        Me.addNewButton.TabIndex = 19
        Me.addNewButton.Text = "Add New"
        Me.addNewButton.UseVisualStyleBackColor = True
        '
        'renameButton
        '
        Me.renameButton.Enabled = False
        Me.renameButton.Location = New System.Drawing.Point(110, 372)
        Me.renameButton.Name = "renameButton"
        Me.renameButton.Size = New System.Drawing.Size(87, 23)
        Me.renameButton.TabIndex = 20
        Me.renameButton.Text = "Rename"
        Me.renameButton.UseVisualStyleBackColor = True
        '
        'deleteButton
        '
        Me.deleteButton.Enabled = False
        Me.deleteButton.Location = New System.Drawing.Point(208, 372)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(87, 23)
        Me.deleteButton.TabIndex = 21
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'CryptoAssetEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 407)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.renameButton)
        Me.Controls.Add(Me.addNewButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.tabControlMain)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CryptoAssetEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin DTN - Editor Crypto Asset"
        Me.tabControlMain.ResumeLayout(False)
        Me.tabPageConnection.ResumeLayout(False)
        Me.tabPageConnection.PerformLayout()
        Me.tabPageEditor.ResumeLayout(False)
        Me.tabPageEditor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents saveBrowser As SaveFileDialog
    Friend WithEvents tabControlMain As TabControl
    Friend WithEvents tabPageConnection As TabPage
    Friend WithEvents urlValue As TextBox
    Friend WithEvents labelURL As Label
    Friend WithEvents radioButtonRemote As RadioButton
    Friend WithEvents radioButtonLocal As RadioButton
    Friend WithEvents tabPageEditor As TabPage
    Friend WithEvents lblSymbol2 As Label
    Friend WithEvents symbolValue As TextBox
    Friend WithEvents symbolLabel1 As Label
    Friend WithEvents symbolLabel As Label
    Friend WithEvents numOfDecimalValue As TextBox
    Friend WithEvents typeValue As ComboBox
    Friend WithEvents numDecimalLabel As Label
    Friend WithEvents shortNameValue As TextBox
    Friend WithEvents noTotalValue As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents mintable As CheckBox
    Friend WithEvents shortNameLabel As Label
    Friend WithEvents identityValue As TextBox
    Friend WithEvents totalCoinValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents totalCoinLabel As Label
    Friend WithEvents coinNameValue As TextBox
    Friend WithEvents preminedValue As TextBox
    Friend WithEvents CoinNameLabel As Label
    Friend WithEvents preminedLabel As Label
    Friend WithEvents browseButton As Button
    Friend WithEvents burnableValue As CheckBox
    Friend WithEvents pathLabel As Label
    Friend WithEvents completePathValue As ComboBox
    Friend WithEvents buttonNext As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents showKeywordValue As CheckBox
    Friend WithEvents keyWordValue As TextBox
    Friend WithEvents labelKeyword As Label
    Friend WithEvents addNewButton As Button
    Friend WithEvents renameButton As Button
    Friend WithEvents deleteButton As Button
End Class
