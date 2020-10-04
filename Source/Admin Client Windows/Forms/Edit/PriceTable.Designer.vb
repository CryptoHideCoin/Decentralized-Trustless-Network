<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PriceTableForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PriceTableForm))
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.nameValue = New System.Windows.Forms.TextBox()
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.selectedTabPage = New System.Windows.Forms.TabPage()
        Me.containerSelected = New System.Windows.Forms.Panel()
        Me.referenceProtocolValue = New System.Windows.Forms.ComboBox()
        Me.referenceProtocolLabel = New System.Windows.Forms.Label()
        Me.priceGroup = New System.Windows.Forms.GroupBox()
        Me.loadReference = New System.Windows.Forms.Button()
        Me.descriptionValue = New System.Windows.Forms.TextBox()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.priceValue = New System.Windows.Forms.TextBox()
        Me.priceLabel = New System.Windows.Forms.Label()
        Me.codePriceValue = New System.Windows.Forms.TextBox()
        Me.codeLabel = New System.Windows.Forms.Label()
        Me.priceDataGrid = New System.Windows.Forms.DataGridView()
        Me.rowIndexPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.effectiveDateValue = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.dataGridView = New System.Windows.Forms.DataGridView()
        Me.RowIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assetsTabPage = New System.Windows.Forms.TabPage()
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        Me.selectedTabPage.SuspendLayout()
        Me.containerSelected.SuspendLayout()
        Me.priceGroup.SuspendLayout()
        CType(Me.priceDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.assetsTabPage.SuspendLayout()
        Me.mainTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Location = New System.Drawing.Point(24, 554)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 51)
        Me.cancelButton.TabIndex = 6
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmButton.Location = New System.Drawing.Point(784, 554)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 51)
        Me.confirmButton.TabIndex = 7
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'identityValue
        '
        Me.identityValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.identityValue.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.identityValue.Location = New System.Drawing.Point(25, 46)
        Me.identityValue.Name = "identityValue"
        Me.identityValue.ReadOnly = True
        Me.identityValue.Size = New System.Drawing.Size(834, 21)
        Me.identityValue.TabIndex = 1
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
        'nameValue
        '
        Me.nameValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nameValue.Location = New System.Drawing.Point(25, 94)
        Me.nameValue.MaxLength = 150
        Me.nameValue.Name = "nameValue"
        Me.nameValue.Size = New System.Drawing.Size(302, 21)
        Me.nameValue.TabIndex = 2
        '
        'nameLabel
        '
        Me.nameLabel.AutoSize = True
        Me.nameLabel.Location = New System.Drawing.Point(21, 78)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(40, 13)
        Me.nameLabel.TabIndex = 71
        Me.nameLabel.Text = "Name"
        '
        'selectedTabPage
        '
        Me.selectedTabPage.Controls.Add(Me.containerSelected)
        Me.selectedTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedTabPage.Location = New System.Drawing.Point(4, 22)
        Me.selectedTabPage.Name = "selectedTabPage"
        Me.selectedTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.selectedTabPage.Size = New System.Drawing.Size(884, 614)
        Me.selectedTabPage.TabIndex = 1
        Me.selectedTabPage.Text = "Detail"
        Me.selectedTabPage.UseVisualStyleBackColor = True
        '
        'containerSelected
        '
        Me.containerSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.containerSelected.Controls.Add(Me.referenceProtocolValue)
        Me.containerSelected.Controls.Add(Me.referenceProtocolLabel)
        Me.containerSelected.Controls.Add(Me.priceGroup)
        Me.containerSelected.Controls.Add(Me.effectiveDateValue)
        Me.containerSelected.Controls.Add(Me.Label1)
        Me.containerSelected.Controls.Add(Me.cancelButton)
        Me.containerSelected.Controls.Add(Me.confirmButton)
        Me.containerSelected.Controls.Add(Me.identityValue)
        Me.containerSelected.Controls.Add(Me.identityLabel)
        Me.containerSelected.Controls.Add(Me.nameValue)
        Me.containerSelected.Controls.Add(Me.nameLabel)
        Me.containerSelected.Location = New System.Drawing.Point(6, 3)
        Me.containerSelected.Name = "containerSelected"
        Me.containerSelected.Size = New System.Drawing.Size(872, 608)
        Me.containerSelected.TabIndex = 0
        '
        'referenceProtocolValue
        '
        Me.referenceProtocolValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.referenceProtocolValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.referenceProtocolValue.FormattingEnabled = True
        Me.referenceProtocolValue.Location = New System.Drawing.Point(333, 94)
        Me.referenceProtocolValue.Name = "referenceProtocolValue"
        Me.referenceProtocolValue.Size = New System.Drawing.Size(306, 21)
        Me.referenceProtocolValue.TabIndex = 3
        '
        'referenceProtocolLabel
        '
        Me.referenceProtocolLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.referenceProtocolLabel.AutoSize = True
        Me.referenceProtocolLabel.Location = New System.Drawing.Point(330, 77)
        Me.referenceProtocolLabel.Name = "referenceProtocolLabel"
        Me.referenceProtocolLabel.Size = New System.Drawing.Size(115, 13)
        Me.referenceProtocolLabel.TabIndex = 78
        Me.referenceProtocolLabel.Text = "Reference Protocol"
        '
        'priceGroup
        '
        Me.priceGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceGroup.Controls.Add(Me.loadReference)
        Me.priceGroup.Controls.Add(Me.descriptionValue)
        Me.priceGroup.Controls.Add(Me.descriptionLabel)
        Me.priceGroup.Controls.Add(Me.priceValue)
        Me.priceGroup.Controls.Add(Me.priceLabel)
        Me.priceGroup.Controls.Add(Me.codePriceValue)
        Me.priceGroup.Controls.Add(Me.codeLabel)
        Me.priceGroup.Controls.Add(Me.priceDataGrid)
        Me.priceGroup.Location = New System.Drawing.Point(25, 132)
        Me.priceGroup.Name = "priceGroup"
        Me.priceGroup.Size = New System.Drawing.Size(834, 416)
        Me.priceGroup.TabIndex = 5
        Me.priceGroup.TabStop = False
        Me.priceGroup.Text = "Price List"
        '
        'loadReference
        '
        Me.loadReference.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loadReference.Enabled = False
        Me.loadReference.Location = New System.Drawing.Point(707, 20)
        Me.loadReference.Name = "loadReference"
        Me.loadReference.Size = New System.Drawing.Size(120, 23)
        Me.loadReference.TabIndex = 1
        Me.loadReference.Text = "Load reference"
        Me.loadReference.UseVisualStyleBackColor = True
        '
        'descriptionValue
        '
        Me.descriptionValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.descriptionValue.Enabled = False
        Me.descriptionValue.Location = New System.Drawing.Point(15, 296)
        Me.descriptionValue.MaxLength = 150
        Me.descriptionValue.Multiline = True
        Me.descriptionValue.Name = "descriptionValue"
        Me.descriptionValue.ReadOnly = True
        Me.descriptionValue.Size = New System.Drawing.Size(677, 114)
        Me.descriptionValue.TabIndex = 5
        '
        'descriptionLabel
        '
        Me.descriptionLabel.AutoSize = True
        Me.descriptionLabel.Enabled = False
        Me.descriptionLabel.Location = New System.Drawing.Point(11, 280)
        Me.descriptionLabel.Name = "descriptionLabel"
        Me.descriptionLabel.Size = New System.Drawing.Size(71, 13)
        Me.descriptionLabel.TabIndex = 86
        Me.descriptionLabel.Text = "Description"
        '
        'priceValue
        '
        Me.priceValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceValue.Location = New System.Drawing.Point(568, 249)
        Me.priceValue.MaxLength = 150
        Me.priceValue.Name = "priceValue"
        Me.priceValue.ReadOnly = True
        Me.priceValue.Size = New System.Drawing.Size(124, 21)
        Me.priceValue.TabIndex = 4
        Me.priceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'priceLabel
        '
        Me.priceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceLabel.AutoSize = True
        Me.priceLabel.Enabled = False
        Me.priceLabel.Location = New System.Drawing.Point(564, 233)
        Me.priceLabel.Name = "priceLabel"
        Me.priceLabel.Size = New System.Drawing.Size(35, 13)
        Me.priceLabel.TabIndex = 84
        Me.priceLabel.Text = "Price"
        '
        'codePriceValue
        '
        Me.codePriceValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.codePriceValue.Enabled = False
        Me.codePriceValue.Location = New System.Drawing.Point(15, 249)
        Me.codePriceValue.MaxLength = 10
        Me.codePriceValue.Name = "codePriceValue"
        Me.codePriceValue.ReadOnly = True
        Me.codePriceValue.Size = New System.Drawing.Size(547, 21)
        Me.codePriceValue.TabIndex = 3
        '
        'codeLabel
        '
        Me.codeLabel.AutoSize = True
        Me.codeLabel.Enabled = False
        Me.codeLabel.Location = New System.Drawing.Point(11, 233)
        Me.codeLabel.Name = "codeLabel"
        Me.codeLabel.Size = New System.Drawing.Size(37, 13)
        Me.codeLabel.TabIndex = 82
        Me.codeLabel.Text = "Code"
        '
        'priceDataGrid
        '
        Me.priceDataGrid.AllowUserToAddRows = False
        Me.priceDataGrid.AllowUserToDeleteRows = False
        Me.priceDataGrid.AllowUserToResizeColumns = False
        Me.priceDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.priceDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowIndexPrice, Me.code, Me.price})
        Me.priceDataGrid.Location = New System.Drawing.Point(6, 20)
        Me.priceDataGrid.MultiSelect = False
        Me.priceDataGrid.Name = "priceDataGrid"
        Me.priceDataGrid.ReadOnly = True
        Me.priceDataGrid.RowHeadersVisible = False
        Me.priceDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.priceDataGrid.Size = New System.Drawing.Size(686, 207)
        Me.priceDataGrid.TabIndex = 0
        '
        'rowIndexPrice
        '
        Me.rowIndexPrice.HeaderText = "Row Index"
        Me.rowIndexPrice.Name = "rowIndexPrice"
        Me.rowIndexPrice.ReadOnly = True
        Me.rowIndexPrice.Visible = False
        '
        'code
        '
        Me.code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        Me.price.Width = 200
        '
        'effectiveDateValue
        '
        Me.effectiveDateValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.effectiveDateValue.Location = New System.Drawing.Point(645, 94)
        Me.effectiveDateValue.Name = "effectiveDateValue"
        Me.effectiveDateValue.Size = New System.Drawing.Size(214, 21)
        Me.effectiveDateValue.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(642, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Effective date"
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
        Me.dataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowIndex, Me.nameColumn, Me.id})
        Me.dataGridView.Location = New System.Drawing.Point(6, 35)
        Me.dataGridView.MultiSelect = False
        Me.dataGridView.Name = "dataGridView"
        Me.dataGridView.ReadOnly = True
        Me.dataGridView.RowHeadersVisible = False
        Me.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView.Size = New System.Drawing.Size(872, 579)
        Me.dataGridView.TabIndex = 2
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
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 485
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
        Me.assetsTabPage.Size = New System.Drawing.Size(884, 614)
        Me.assetsTabPage.TabIndex = 0
        Me.assetsTabPage.Text = "Price Tables"
        Me.assetsTabPage.UseVisualStyleBackColor = True
        '
        'mainTabControl
        '
        Me.mainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTabControl.Controls.Add(Me.assetsTabPage)
        Me.mainTabControl.Controls.Add(Me.selectedTabPage)
        Me.mainTabControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTabControl.Location = New System.Drawing.Point(10, 11)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(892, 640)
        Me.mainTabControl.TabIndex = 0
        '
        'PriceTableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 661)
        Me.Controls.Add(Me.mainTabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1244, 700)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "PriceTableForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Price Table Manager"
        Me.selectedTabPage.ResumeLayout(False)
        Me.containerSelected.ResumeLayout(False)
        Me.containerSelected.PerformLayout()
        Me.priceGroup.ResumeLayout(False)
        Me.priceGroup.PerformLayout()
        CType(Me.priceDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.assetsTabPage.ResumeLayout(False)
        Me.mainTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents nameValue As TextBox
    Friend WithEvents nameLabel As Label
    Friend WithEvents selectedTabPage As TabPage
    Friend WithEvents containerSelected As Panel
    Friend WithEvents createNewButton As Button
    Friend WithEvents refreshButton As Button
    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents assetsTabPage As TabPage
    Friend WithEvents mainTabControl As TabControl
    Friend WithEvents effectiveDateValue As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents priceGroup As GroupBox
    Friend WithEvents loadReference As Button
    Friend WithEvents descriptionValue As TextBox
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents priceValue As TextBox
    Friend WithEvents priceLabel As Label
    Friend WithEvents codePriceValue As TextBox
    Friend WithEvents codeLabel As Label
    Friend WithEvents priceDataGrid As DataGridView
    Friend WithEvents rowIndexPrice As DataGridViewTextBoxColumn
    Friend WithEvents code As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents RowIndex As DataGridViewTextBoxColumn
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents referenceProtocolValue As ComboBox
    Friend WithEvents referenceProtocolLabel As Label
End Class
