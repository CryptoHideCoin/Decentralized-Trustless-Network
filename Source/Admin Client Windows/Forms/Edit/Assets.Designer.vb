<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AssetsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssetsForm))
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        Me.assetsTabPage = New System.Windows.Forms.TabPage()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.dataGridView = New System.Windows.Forms.DataGridView()
        Me.RowIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selectedTabPage = New System.Windows.Forms.TabPage()
        Me.containerSelected = New System.Windows.Forms.Panel()
        Me.lblSymbol2 = New System.Windows.Forms.Label()
        Me.totalCoinValue = New System.Windows.Forms.TextBox()
        Me.totalCoinLabel = New System.Windows.Forms.Label()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.symbolValue = New System.Windows.Forms.TextBox()
        Me.symbolLabel = New System.Windows.Forms.Label()
        Me.numOfDecimalValue = New System.Windows.Forms.TextBox()
        Me.numDecimalLabel = New System.Windows.Forms.Label()
        Me.shortNameValue = New System.Windows.Forms.TextBox()
        Me.noTotalValue = New System.Windows.Forms.CheckBox()
        Me.mintable = New System.Windows.Forms.CheckBox()
        Me.shortNameLabel = New System.Windows.Forms.Label()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.coinNameValue = New System.Windows.Forms.TextBox()
        Me.CoinNameLabel = New System.Windows.Forms.Label()
        Me.burnableValue = New System.Windows.Forms.CheckBox()
        Me.mainTabControl.SuspendLayout()
        Me.assetsTabPage.SuspendLayout()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.selectedTabPage.SuspendLayout()
        Me.containerSelected.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainTabControl
        '
        Me.mainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTabControl.Controls.Add(Me.assetsTabPage)
        Me.mainTabControl.Controls.Add(Me.selectedTabPage)
        Me.mainTabControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTabControl.Location = New System.Drawing.Point(12, 12)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(892, 299)
        Me.mainTabControl.TabIndex = 0
        '
        'assetsTabPage
        '
        Me.assetsTabPage.Controls.Add(Me.createNewButton)
        Me.assetsTabPage.Controls.Add(Me.refreshButton)
        Me.assetsTabPage.Controls.Add(Me.dataGridView)
        Me.assetsTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assetsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.assetsTabPage.Name = "assetsTabPage"
        Me.assetsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.assetsTabPage.Size = New System.Drawing.Size(884, 273)
        Me.assetsTabPage.TabIndex = 0
        Me.assetsTabPage.Text = "Assets"
        Me.assetsTabPage.UseVisualStyleBackColor = True
        '
        'createNewButton
        '
        Me.createNewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewButton.Location = New System.Drawing.Point(769, 6)
        Me.createNewButton.Name = "createNewButton"
        Me.createNewButton.Size = New System.Drawing.Size(109, 23)
        Me.createNewButton.TabIndex = 1
        Me.createNewButton.Text = "Add New"
        Me.createNewButton.UseVisualStyleBackColor = True
        '
        'refreshButton
        '
        Me.refreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshButton.Location = New System.Drawing.Point(654, 6)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(109, 23)
        Me.refreshButton.TabIndex = 0
        Me.refreshButton.Text = "Refresh"
        Me.refreshButton.UseVisualStyleBackColor = True
        '
        'dataGridView
        '
        Me.dataGridView.AllowUserToAddRows = False
        Me.dataGridView.AllowUserToDeleteRows = False
        Me.dataGridView.AllowUserToResizeColumns = False
        Me.dataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowIndex, Me.nameColumn, Me.idColumn})
        Me.dataGridView.Location = New System.Drawing.Point(6, 35)
        Me.dataGridView.MultiSelect = False
        Me.dataGridView.Name = "dataGridView"
        Me.dataGridView.ReadOnly = True
        Me.dataGridView.RowHeadersVisible = False
        Me.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView.Size = New System.Drawing.Size(872, 238)
        Me.dataGridView.TabIndex = 26
        '
        'RowIndex
        '
        Me.RowIndex.HeaderText = "Row Index"
        Me.RowIndex.Name = "RowIndex"
        Me.RowIndex.ReadOnly = True
        Me.RowIndex.Visible = False
        '
        'nameColumn
        '
        Me.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nameColumn.HeaderText = "Name"
        Me.nameColumn.Name = "nameColumn"
        Me.nameColumn.ReadOnly = True
        '
        'idColumn
        '
        Me.idColumn.HeaderText = "ID"
        Me.idColumn.Name = "idColumn"
        Me.idColumn.ReadOnly = True
        Me.idColumn.Width = 500
        '
        'selectedTabPage
        '
        Me.selectedTabPage.Controls.Add(Me.containerSelected)
        Me.selectedTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedTabPage.Location = New System.Drawing.Point(4, 22)
        Me.selectedTabPage.Name = "selectedTabPage"
        Me.selectedTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.selectedTabPage.Size = New System.Drawing.Size(884, 273)
        Me.selectedTabPage.TabIndex = 1
        Me.selectedTabPage.Text = "Detail"
        Me.selectedTabPage.UseVisualStyleBackColor = True
        '
        'containerSelected
        '
        Me.containerSelected.Controls.Add(Me.lblSymbol2)
        Me.containerSelected.Controls.Add(Me.totalCoinValue)
        Me.containerSelected.Controls.Add(Me.totalCoinLabel)
        Me.containerSelected.Controls.Add(Me.cancelButton)
        Me.containerSelected.Controls.Add(Me.confirmButton)
        Me.containerSelected.Controls.Add(Me.symbolValue)
        Me.containerSelected.Controls.Add(Me.symbolLabel)
        Me.containerSelected.Controls.Add(Me.numOfDecimalValue)
        Me.containerSelected.Controls.Add(Me.numDecimalLabel)
        Me.containerSelected.Controls.Add(Me.shortNameValue)
        Me.containerSelected.Controls.Add(Me.noTotalValue)
        Me.containerSelected.Controls.Add(Me.mintable)
        Me.containerSelected.Controls.Add(Me.shortNameLabel)
        Me.containerSelected.Controls.Add(Me.identityValue)
        Me.containerSelected.Controls.Add(Me.identityLabel)
        Me.containerSelected.Controls.Add(Me.coinNameValue)
        Me.containerSelected.Controls.Add(Me.CoinNameLabel)
        Me.containerSelected.Controls.Add(Me.burnableValue)
        Me.containerSelected.Location = New System.Drawing.Point(6, 3)
        Me.containerSelected.Name = "containerSelected"
        Me.containerSelected.Size = New System.Drawing.Size(547, 273)
        Me.containerSelected.TabIndex = 61
        '
        'lblSymbol2
        '
        Me.lblSymbol2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSymbol2.AutoSize = True
        Me.lblSymbol2.Location = New System.Drawing.Point(504, 169)
        Me.lblSymbol2.Name = "lblSymbol2"
        Me.lblSymbol2.Size = New System.Drawing.Size(21, 13)
        Me.lblSymbol2.TabIndex = 78
        Me.lblSymbol2.Text = "xx"
        '
        'totalCoinValue
        '
        Me.totalCoinValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalCoinValue.Location = New System.Drawing.Point(340, 166)
        Me.totalCoinValue.Name = "totalCoinValue"
        Me.totalCoinValue.Size = New System.Drawing.Size(158, 21)
        Me.totalCoinValue.TabIndex = 68
        Me.totalCoinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'totalCoinLabel
        '
        Me.totalCoinLabel.AutoSize = True
        Me.totalCoinLabel.Location = New System.Drawing.Point(337, 150)
        Me.totalCoinLabel.Name = "totalCoinLabel"
        Me.totalCoinLabel.Size = New System.Drawing.Size(34, 13)
        Me.totalCoinLabel.TabIndex = 77
        Me.totalCoinLabel.Text = "Total"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(24, 219)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 69
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.confirmButton.Location = New System.Drawing.Point(450, 219)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 23)
        Me.confirmButton.TabIndex = 70
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'symbolValue
        '
        Me.symbolValue.Location = New System.Drawing.Point(163, 166)
        Me.symbolValue.MaxLength = 2
        Me.symbolValue.Name = "symbolValue"
        Me.symbolValue.Size = New System.Drawing.Size(46, 21)
        Me.symbolValue.TabIndex = 66
        Me.symbolValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'symbolLabel
        '
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Location = New System.Drawing.Point(159, 150)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(50, 13)
        Me.symbolLabel.TabIndex = 74
        Me.symbolLabel.Text = "Symbol"
        '
        'numOfDecimalValue
        '
        Me.numOfDecimalValue.Location = New System.Drawing.Point(214, 166)
        Me.numOfDecimalValue.MaxLength = 2
        Me.numOfDecimalValue.Name = "numOfDecimalValue"
        Me.numOfDecimalValue.Size = New System.Drawing.Size(117, 21)
        Me.numOfDecimalValue.TabIndex = 67
        Me.numOfDecimalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDecimalLabel
        '
        Me.numDecimalLabel.AutoSize = True
        Me.numDecimalLabel.Location = New System.Drawing.Point(210, 150)
        Me.numDecimalLabel.Name = "numDecimalLabel"
        Me.numDecimalLabel.Size = New System.Drawing.Size(121, 13)
        Me.numDecimalLabel.TabIndex = 76
        Me.numDecimalLabel.Text = "Number of decimals"
        '
        'shortNameValue
        '
        Me.shortNameValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.shortNameValue.Location = New System.Drawing.Point(25, 166)
        Me.shortNameValue.MaxLength = 10
        Me.shortNameValue.Name = "shortNameValue"
        Me.shortNameValue.Size = New System.Drawing.Size(133, 21)
        Me.shortNameValue.TabIndex = 65
        '
        'noTotalValue
        '
        Me.noTotalValue.AutoSize = True
        Me.noTotalValue.Location = New System.Drawing.Point(340, 121)
        Me.noTotalValue.Name = "noTotalValue"
        Me.noTotalValue.Size = New System.Drawing.Size(75, 17)
        Me.noTotalValue.TabIndex = 64
        Me.noTotalValue.Text = "Limitless"
        Me.noTotalValue.UseVisualStyleBackColor = True
        '
        'mintable
        '
        Me.mintable.AutoSize = True
        Me.mintable.Location = New System.Drawing.Point(165, 121)
        Me.mintable.Name = "mintable"
        Me.mintable.Size = New System.Drawing.Size(73, 17)
        Me.mintable.TabIndex = 63
        Me.mintable.Text = "Mintable"
        Me.mintable.UseVisualStyleBackColor = True
        '
        'shortNameLabel
        '
        Me.shortNameLabel.AutoSize = True
        Me.shortNameLabel.Location = New System.Drawing.Point(21, 150)
        Me.shortNameLabel.Name = "shortNameLabel"
        Me.shortNameLabel.Size = New System.Drawing.Size(75, 13)
        Me.shortNameLabel.TabIndex = 72
        Me.shortNameLabel.Text = "Short Name"
        '
        'identityValue
        '
        Me.identityValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.identityValue.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.identityValue.Location = New System.Drawing.Point(25, 46)
        Me.identityValue.Name = "identityValue"
        Me.identityValue.ReadOnly = True
        Me.identityValue.Size = New System.Drawing.Size(500, 21)
        Me.identityValue.TabIndex = 75
        Me.identityValue.TabStop = False
        Me.identityValue.Text = "NO FILE"
        Me.identityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'identityLabel
        '
        Me.identityLabel.AutoSize = True
        Me.identityLabel.Location = New System.Drawing.Point(21, 31)
        Me.identityLabel.Name = "identityLabel"
        Me.identityLabel.Size = New System.Drawing.Size(51, 13)
        Me.identityLabel.TabIndex = 73
        Me.identityLabel.Text = "Identity"
        '
        'coinNameValue
        '
        Me.coinNameValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.coinNameValue.Location = New System.Drawing.Point(25, 94)
        Me.coinNameValue.MaxLength = 150
        Me.coinNameValue.Name = "coinNameValue"
        Me.coinNameValue.Size = New System.Drawing.Size(500, 21)
        Me.coinNameValue.TabIndex = 61
        '
        'CoinNameLabel
        '
        Me.CoinNameLabel.AutoSize = True
        Me.CoinNameLabel.Location = New System.Drawing.Point(21, 78)
        Me.CoinNameLabel.Name = "CoinNameLabel"
        Me.CoinNameLabel.Size = New System.Drawing.Size(40, 13)
        Me.CoinNameLabel.TabIndex = 71
        Me.CoinNameLabel.Text = "Name"
        '
        'burnableValue
        '
        Me.burnableValue.AutoSize = True
        Me.burnableValue.Location = New System.Drawing.Point(26, 121)
        Me.burnableValue.Name = "burnableValue"
        Me.burnableValue.Size = New System.Drawing.Size(77, 17)
        Me.burnableValue.TabIndex = 62
        Me.burnableValue.Text = "Burnable"
        Me.burnableValue.UseVisualStyleBackColor = True
        '
        'AssetsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 320)
        Me.Controls.Add(Me.mainTabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1244, 359)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(622, 359)
        Me.Name = "AssetsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manager Assets"
        Me.mainTabControl.ResumeLayout(False)
        Me.assetsTabPage.ResumeLayout(False)
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.selectedTabPage.ResumeLayout(False)
        Me.containerSelected.ResumeLayout(False)
        Me.containerSelected.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTabControl As TabControl
    Friend WithEvents assetsTabPage As TabPage
    Friend WithEvents refreshButton As Button
    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents selectedTabPage As TabPage
    Friend WithEvents createNewButton As Button
    Friend WithEvents containerSelected As Panel
    Friend WithEvents lblSymbol2 As Label
    Friend WithEvents totalCoinValue As TextBox
    Friend WithEvents totalCoinLabel As Label
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents symbolValue As TextBox
    Friend WithEvents symbolLabel As Label
    Friend WithEvents numOfDecimalValue As TextBox
    Friend WithEvents numDecimalLabel As Label
    Friend WithEvents shortNameValue As TextBox
    Friend WithEvents noTotalValue As CheckBox
    Friend WithEvents mintable As CheckBox
    Friend WithEvents shortNameLabel As Label
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents coinNameValue As TextBox
    Friend WithEvents CoinNameLabel As Label
    Friend WithEvents burnableValue As CheckBox
    Friend WithEvents RowIndex As DataGridViewTextBoxColumn
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
End Class
