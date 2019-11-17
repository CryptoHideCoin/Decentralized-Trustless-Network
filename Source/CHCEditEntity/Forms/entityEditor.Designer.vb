<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class entityEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(entityEditor))
        Me.symbolValue = New System.Windows.Forms.TextBox()
        Me.symbolLabel = New System.Windows.Forms.Label()
        Me.shortNameValue = New System.Windows.Forms.TextBox()
        Me.shortNameLabel = New System.Windows.Forms.Label()
        Me.coinNameValue = New System.Windows.Forms.TextBox()
        Me.CoinNameLabel = New System.Windows.Forms.Label()
        Me.lblSymbol2 = New System.Windows.Forms.Label()
        Me.symbolLabel1 = New System.Windows.Forms.Label()
        Me.numOfDecimalValue = New System.Windows.Forms.TextBox()
        Me.numDecimalLabel = New System.Windows.Forms.Label()
        Me.noTotalValue = New System.Windows.Forms.CheckBox()
        Me.mintable = New System.Windows.Forms.CheckBox()
        Me.totalCoinValue = New System.Windows.Forms.TextBox()
        Me.totalCoinLabel = New System.Windows.Forms.Label()
        Me.preminedValue = New System.Windows.Forms.TextBox()
        Me.preminedLabel = New System.Windows.Forms.Label()
        Me.burnableValue = New System.Windows.Forms.CheckBox()
        Me.completePathValue = New System.Windows.Forms.TextBox()
        Me.pathLabel = New System.Windows.Forms.Label()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.saveBrowser = New System.Windows.Forms.SaveFileDialog()
        Me.typeValue = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'symbolValue
        '
        Me.symbolValue.Location = New System.Drawing.Point(164, 175)
        Me.symbolValue.Name = "symbolValue"
        Me.symbolValue.Size = New System.Drawing.Size(52, 20)
        Me.symbolValue.TabIndex = 5
        Me.symbolValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'symbolLabel
        '
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Location = New System.Drawing.Point(161, 159)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(41, 13)
        Me.symbolLabel.TabIndex = 10
        Me.symbolLabel.Text = "Symbol"
        '
        'shortNameValue
        '
        Me.shortNameValue.Location = New System.Drawing.Point(20, 175)
        Me.shortNameValue.Name = "shortNameValue"
        Me.shortNameValue.Size = New System.Drawing.Size(135, 20)
        Me.shortNameValue.TabIndex = 4
        '
        'shortNameLabel
        '
        Me.shortNameLabel.AutoSize = True
        Me.shortNameLabel.Location = New System.Drawing.Point(17, 158)
        Me.shortNameLabel.Name = "shortNameLabel"
        Me.shortNameLabel.Size = New System.Drawing.Size(63, 13)
        Me.shortNameLabel.TabIndex = 8
        Me.shortNameLabel.Text = "Short Name"
        '
        'coinNameValue
        '
        Me.coinNameValue.Location = New System.Drawing.Point(164, 123)
        Me.coinNameValue.Name = "coinNameValue"
        Me.coinNameValue.Size = New System.Drawing.Size(290, 20)
        Me.coinNameValue.TabIndex = 3
        '
        'CoinNameLabel
        '
        Me.CoinNameLabel.AutoSize = True
        Me.CoinNameLabel.Location = New System.Drawing.Point(161, 106)
        Me.CoinNameLabel.Name = "CoinNameLabel"
        Me.CoinNameLabel.Size = New System.Drawing.Size(35, 13)
        Me.CoinNameLabel.TabIndex = 6
        Me.CoinNameLabel.Text = "Name"
        '
        'lblSymbol2
        '
        Me.lblSymbol2.AutoSize = True
        Me.lblSymbol2.Location = New System.Drawing.Point(438, 266)
        Me.lblSymbol2.Name = "lblSymbol2"
        Me.lblSymbol2.Size = New System.Drawing.Size(17, 13)
        Me.lblSymbol2.TabIndex = 16
        Me.lblSymbol2.Text = "xx"
        '
        'symbolLabel1
        '
        Me.symbolLabel1.AutoSize = True
        Me.symbolLabel1.Location = New System.Drawing.Point(270, 266)
        Me.symbolLabel1.Name = "symbolLabel1"
        Me.symbolLabel1.Size = New System.Drawing.Size(17, 13)
        Me.symbolLabel1.TabIndex = 15
        Me.symbolLabel1.Text = "xx"
        '
        'numOfDecimalValue
        '
        Me.numOfDecimalValue.Location = New System.Drawing.Point(20, 263)
        Me.numOfDecimalValue.Name = "numOfDecimalValue"
        Me.numOfDecimalValue.Size = New System.Drawing.Size(96, 20)
        Me.numOfDecimalValue.TabIndex = 9
        Me.numOfDecimalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDecimalLabel
        '
        Me.numDecimalLabel.AutoSize = True
        Me.numDecimalLabel.Location = New System.Drawing.Point(17, 247)
        Me.numDecimalLabel.Name = "numDecimalLabel"
        Me.numDecimalLabel.Size = New System.Drawing.Size(100, 13)
        Me.numDecimalLabel.TabIndex = 14
        Me.numDecimalLabel.Text = "Number of decimals"
        '
        'noTotalValue
        '
        Me.noTotalValue.AutoSize = True
        Me.noTotalValue.Location = New System.Drawing.Point(293, 215)
        Me.noTotalValue.Name = "noTotalValue"
        Me.noTotalValue.Size = New System.Drawing.Size(65, 17)
        Me.noTotalValue.TabIndex = 8
        Me.noTotalValue.Text = "Limitless"
        Me.noTotalValue.UseVisualStyleBackColor = True
        '
        'mintable
        '
        Me.mintable.AutoSize = True
        Me.mintable.Location = New System.Drawing.Point(139, 215)
        Me.mintable.Name = "mintable"
        Me.mintable.Size = New System.Drawing.Size(66, 17)
        Me.mintable.TabIndex = 7
        Me.mintable.Text = "Mintable"
        Me.mintable.UseVisualStyleBackColor = True
        '
        'totalCoinValue
        '
        Me.totalCoinValue.Location = New System.Drawing.Point(293, 263)
        Me.totalCoinValue.Name = "totalCoinValue"
        Me.totalCoinValue.Size = New System.Drawing.Size(139, 20)
        Me.totalCoinValue.TabIndex = 11
        Me.totalCoinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'totalCoinLabel
        '
        Me.totalCoinLabel.AutoSize = True
        Me.totalCoinLabel.Location = New System.Drawing.Point(290, 247)
        Me.totalCoinLabel.Name = "totalCoinLabel"
        Me.totalCoinLabel.Size = New System.Drawing.Size(31, 13)
        Me.totalCoinLabel.TabIndex = 8
        Me.totalCoinLabel.Text = "Total"
        '
        'preminedValue
        '
        Me.preminedValue.Location = New System.Drawing.Point(139, 263)
        Me.preminedValue.Name = "preminedValue"
        Me.preminedValue.Size = New System.Drawing.Size(125, 20)
        Me.preminedValue.TabIndex = 10
        Me.preminedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'preminedLabel
        '
        Me.preminedLabel.AutoSize = True
        Me.preminedLabel.Location = New System.Drawing.Point(136, 247)
        Me.preminedLabel.Name = "preminedLabel"
        Me.preminedLabel.Size = New System.Drawing.Size(133, 13)
        Me.preminedLabel.TabIndex = 6
        Me.preminedLabel.Text = "Number of pre-mined coins"
        '
        'burnableValue
        '
        Me.burnableValue.AutoSize = True
        Me.burnableValue.Location = New System.Drawing.Point(20, 215)
        Me.burnableValue.Name = "burnableValue"
        Me.burnableValue.Size = New System.Drawing.Size(68, 17)
        Me.burnableValue.TabIndex = 6
        Me.burnableValue.Text = "Burnable"
        Me.burnableValue.UseVisualStyleBackColor = True
        '
        'completePathValue
        '
        Me.completePathValue.Location = New System.Drawing.Point(20, 29)
        Me.completePathValue.Name = "completePathValue"
        Me.completePathValue.Size = New System.Drawing.Size(434, 20)
        Me.completePathValue.TabIndex = 0
        '
        'pathLabel
        '
        Me.pathLabel.AutoSize = True
        Me.pathLabel.Location = New System.Drawing.Point(17, 13)
        Me.pathLabel.Name = "pathLabel"
        Me.pathLabel.Size = New System.Drawing.Size(91, 13)
        Me.pathLabel.TabIndex = 7
        Me.pathLabel.Text = "Complete file path"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(460, 27)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(31, 23)
        Me.browseButton.TabIndex = 1
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'identityValue
        '
        Me.identityValue.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.identityValue.Location = New System.Drawing.Point(20, 75)
        Me.identityValue.Name = "identityValue"
        Me.identityValue.Size = New System.Drawing.Size(434, 20)
        Me.identityValue.TabIndex = 11
        Me.identityValue.TabStop = False
        Me.identityValue.Text = "NO FILE"
        Me.identityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'identityLabel
        '
        Me.identityLabel.AutoSize = True
        Me.identityLabel.Location = New System.Drawing.Point(17, 59)
        Me.identityLabel.Name = "identityLabel"
        Me.identityLabel.Size = New System.Drawing.Size(41, 13)
        Me.identityLabel.TabIndex = 10
        Me.identityLabel.Text = "Identity"
        '
        'saveBrowser
        '
        Me.saveBrowser.DefaultExt = "definition"
        Me.saveBrowser.Title = "Select file to write"
        '
        'typeValue
        '
        Me.typeValue.FormattingEnabled = True
        Me.typeValue.Items.AddRange(New Object() {"COIN", "TOKEN"})
        Me.typeValue.Location = New System.Drawing.Point(20, 123)
        Me.typeValue.Name = "typeValue"
        Me.typeValue.Size = New System.Drawing.Size(127, 21)
        Me.typeValue.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Type"
        '
        'entityEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 305)
        Me.Controls.Add(Me.lblSymbol2)
        Me.Controls.Add(Me.symbolValue)
        Me.Controls.Add(Me.symbolLabel1)
        Me.Controls.Add(Me.symbolLabel)
        Me.Controls.Add(Me.numOfDecimalValue)
        Me.Controls.Add(Me.typeValue)
        Me.Controls.Add(Me.numDecimalLabel)
        Me.Controls.Add(Me.shortNameValue)
        Me.Controls.Add(Me.noTotalValue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mintable)
        Me.Controls.Add(Me.shortNameLabel)
        Me.Controls.Add(Me.identityValue)
        Me.Controls.Add(Me.totalCoinValue)
        Me.Controls.Add(Me.identityLabel)
        Me.Controls.Add(Me.totalCoinLabel)
        Me.Controls.Add(Me.coinNameValue)
        Me.Controls.Add(Me.preminedValue)
        Me.Controls.Add(Me.CoinNameLabel)
        Me.Controls.Add(Me.preminedLabel)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.burnableValue)
        Me.Controls.Add(Me.completePathValue)
        Me.Controls.Add(Me.pathLabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "entityEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin DTN - Editor Exchange Of Value"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents symbolValue As TextBox
    Friend WithEvents symbolLabel As Label
    Friend WithEvents shortNameValue As TextBox
    Friend WithEvents shortNameLabel As Label
    Friend WithEvents coinNameValue As TextBox
    Friend WithEvents CoinNameLabel As Label
    Friend WithEvents completePathValue As TextBox
    Friend WithEvents pathLabel As Label
    Friend WithEvents browseButton As Button
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents totalCoinValue As TextBox
    Friend WithEvents totalCoinLabel As Label
    Friend WithEvents preminedValue As TextBox
    Friend WithEvents preminedLabel As Label
    Friend WithEvents burnableValue As CheckBox
    Friend WithEvents mintable As CheckBox
    Friend WithEvents lblSymbol2 As Label
    Friend WithEvents symbolLabel1 As Label
    Friend WithEvents numOfDecimalValue As TextBox
    Friend WithEvents numDecimalLabel As Label
    Friend WithEvents noTotalValue As CheckBox
    Friend WithEvents saveBrowser As SaveFileDialog
    Friend WithEvents typeValue As ComboBox
    Friend WithEvents Label3 As Label
End Class
