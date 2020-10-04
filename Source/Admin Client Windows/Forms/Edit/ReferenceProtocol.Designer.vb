<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReferenceProtocolForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReferenceProtocolForm))
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        Me.referenceProtocolsTabPage = New System.Windows.Forms.TabPage()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.dataGridView = New System.Windows.Forms.DataGridView()
        Me.RowIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selectedTabPage = New System.Windows.Forms.TabPage()
        Me.containerSelected = New System.Windows.Forms.Panel()
        Me.referenceGroup = New System.Windows.Forms.GroupBox()
        Me.cancelUpdate = New System.Windows.Forms.Button()
        Me.confirmReference = New System.Windows.Forms.Button()
        Me.addNewReference = New System.Windows.Forms.Button()
        Me.descriptionValue = New System.Windows.Forms.TextBox()
        Me.descriptionLabel = New System.Windows.Forms.Label()
        Me.referenceValue = New System.Windows.Forms.TextBox()
        Me.codeLabel = New System.Windows.Forms.Label()
        Me.referenceDataGrid = New System.Windows.Forms.DataGridView()
        Me.rowIndexPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referenceProtocolValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.nameValue = New System.Windows.Forms.TextBox()
        Me.CoinNameLabel = New System.Windows.Forms.Label()
        Me.mainTabControl.SuspendLayout()
        Me.referenceProtocolsTabPage.SuspendLayout()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.selectedTabPage.SuspendLayout()
        Me.containerSelected.SuspendLayout()
        Me.referenceGroup.SuspendLayout()
        CType(Me.referenceDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainTabControl
        '
        Me.mainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTabControl.Controls.Add(Me.referenceProtocolsTabPage)
        Me.mainTabControl.Controls.Add(Me.selectedTabPage)
        Me.mainTabControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTabControl.Location = New System.Drawing.Point(10, 10)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(892, 640)
        Me.mainTabControl.TabIndex = 0
        '
        'referenceProtocolsTabPage
        '
        Me.referenceProtocolsTabPage.Controls.Add(Me.createNewButton)
        Me.referenceProtocolsTabPage.Controls.Add(Me.refreshButton)
        Me.referenceProtocolsTabPage.Controls.Add(Me.dataGridView)
        Me.referenceProtocolsTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.referenceProtocolsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.referenceProtocolsTabPage.Name = "referenceProtocolsTabPage"
        Me.referenceProtocolsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.referenceProtocolsTabPage.Size = New System.Drawing.Size(884, 614)
        Me.referenceProtocolsTabPage.TabIndex = 0
        Me.referenceProtocolsTabPage.Text = "Reference Protocols"
        Me.referenceProtocolsTabPage.UseVisualStyleBackColor = True
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
        Me.selectedTabPage.Size = New System.Drawing.Size(884, 614)
        Me.selectedTabPage.TabIndex = 1
        Me.selectedTabPage.Text = "Selected"
        Me.selectedTabPage.UseVisualStyleBackColor = True
        '
        'containerSelected
        '
        Me.containerSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.containerSelected.Controls.Add(Me.referenceGroup)
        Me.containerSelected.Controls.Add(Me.referenceProtocolValue)
        Me.containerSelected.Controls.Add(Me.Label1)
        Me.containerSelected.Controls.Add(Me.cancelButton)
        Me.containerSelected.Controls.Add(Me.confirmButton)
        Me.containerSelected.Controls.Add(Me.identityValue)
        Me.containerSelected.Controls.Add(Me.identityLabel)
        Me.containerSelected.Controls.Add(Me.nameValue)
        Me.containerSelected.Controls.Add(Me.CoinNameLabel)
        Me.containerSelected.Location = New System.Drawing.Point(6, 3)
        Me.containerSelected.Name = "containerSelected"
        Me.containerSelected.Size = New System.Drawing.Size(872, 605)
        Me.containerSelected.TabIndex = 61
        '
        'referenceGroup
        '
        Me.referenceGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.referenceGroup.Controls.Add(Me.cancelUpdate)
        Me.referenceGroup.Controls.Add(Me.confirmReference)
        Me.referenceGroup.Controls.Add(Me.addNewReference)
        Me.referenceGroup.Controls.Add(Me.descriptionValue)
        Me.referenceGroup.Controls.Add(Me.descriptionLabel)
        Me.referenceGroup.Controls.Add(Me.referenceValue)
        Me.referenceGroup.Controls.Add(Me.codeLabel)
        Me.referenceGroup.Controls.Add(Me.referenceDataGrid)
        Me.referenceGroup.Location = New System.Drawing.Point(25, 129)
        Me.referenceGroup.Name = "referenceGroup"
        Me.referenceGroup.Size = New System.Drawing.Size(825, 416)
        Me.referenceGroup.TabIndex = 3
        Me.referenceGroup.TabStop = False
        Me.referenceGroup.Text = "Price List"
        '
        'cancelUpdate
        '
        Me.cancelUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelUpdate.Enabled = False
        Me.cancelUpdate.Location = New System.Drawing.Point(699, 387)
        Me.cancelUpdate.Name = "cancelUpdate"
        Me.cancelUpdate.Size = New System.Drawing.Size(120, 23)
        Me.cancelUpdate.TabIndex = 5
        Me.cancelUpdate.Text = "Cancel"
        Me.cancelUpdate.UseVisualStyleBackColor = True
        '
        'confirmReference
        '
        Me.confirmReference.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmReference.Enabled = False
        Me.confirmReference.Location = New System.Drawing.Point(699, 341)
        Me.confirmReference.Name = "confirmReference"
        Me.confirmReference.Size = New System.Drawing.Size(120, 40)
        Me.confirmReference.TabIndex = 4
        Me.confirmReference.Text = "Confirm Reference"
        Me.confirmReference.UseVisualStyleBackColor = True
        '
        'addNewReference
        '
        Me.addNewReference.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addNewReference.Location = New System.Drawing.Point(699, 21)
        Me.addNewReference.Name = "addNewReference"
        Me.addNewReference.Size = New System.Drawing.Size(120, 39)
        Me.addNewReference.TabIndex = 1
        Me.addNewReference.Text = "Add New Reference"
        Me.addNewReference.UseVisualStyleBackColor = True
        '
        'descriptionValue
        '
        Me.descriptionValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.descriptionValue.Location = New System.Drawing.Point(15, 296)
        Me.descriptionValue.MaxLength = 150
        Me.descriptionValue.Multiline = True
        Me.descriptionValue.Name = "descriptionValue"
        Me.descriptionValue.Size = New System.Drawing.Size(678, 114)
        Me.descriptionValue.TabIndex = 3
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
        'referenceValue
        '
        Me.referenceValue.Location = New System.Drawing.Point(15, 249)
        Me.referenceValue.MaxLength = 10
        Me.referenceValue.Name = "referenceValue"
        Me.referenceValue.Size = New System.Drawing.Size(92, 21)
        Me.referenceValue.TabIndex = 2
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
        'referenceDataGrid
        '
        Me.referenceDataGrid.AllowUserToAddRows = False
        Me.referenceDataGrid.AllowUserToDeleteRows = False
        Me.referenceDataGrid.AllowUserToResizeColumns = False
        Me.referenceDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.referenceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.referenceDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowIndexPrice, Me.code, Me.description})
        Me.referenceDataGrid.Location = New System.Drawing.Point(15, 20)
        Me.referenceDataGrid.MultiSelect = False
        Me.referenceDataGrid.Name = "referenceDataGrid"
        Me.referenceDataGrid.ReadOnly = True
        Me.referenceDataGrid.RowHeadersVisible = False
        Me.referenceDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.referenceDataGrid.Size = New System.Drawing.Size(678, 201)
        Me.referenceDataGrid.TabIndex = 0
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
        Me.code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        Me.code.Width = 50
        '
        'description
        '
        Me.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'referenceProtocolValue
        '
        Me.referenceProtocolValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.referenceProtocolValue.Location = New System.Drawing.Point(724, 94)
        Me.referenceProtocolValue.MaxLength = 150
        Me.referenceProtocolValue.Name = "referenceProtocolValue"
        Me.referenceProtocolValue.Size = New System.Drawing.Size(126, 21)
        Me.referenceProtocolValue.TabIndex = 2
        Me.referenceProtocolValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(721, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Release Protocol"
        '
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Location = New System.Drawing.Point(24, 551)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 51)
        Me.cancelButton.TabIndex = 4
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmButton.Location = New System.Drawing.Point(775, 551)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 51)
        Me.confirmButton.TabIndex = 5
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
        Me.identityValue.Size = New System.Drawing.Size(825, 21)
        Me.identityValue.TabIndex = 0
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
        Me.nameValue.Size = New System.Drawing.Size(693, 21)
        Me.nameValue.TabIndex = 1
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
        'ReferenceProtocolForm
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
        Me.Name = "ReferenceProtocolForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manager Reference Protocol"
        Me.mainTabControl.ResumeLayout(False)
        Me.referenceProtocolsTabPage.ResumeLayout(False)
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.selectedTabPage.ResumeLayout(False)
        Me.containerSelected.ResumeLayout(False)
        Me.containerSelected.PerformLayout()
        Me.referenceGroup.ResumeLayout(False)
        Me.referenceGroup.PerformLayout()
        CType(Me.referenceDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTabControl As TabControl
    Friend WithEvents referenceProtocolsTabPage As TabPage
    Friend WithEvents createNewButton As Button
    Friend WithEvents refreshButton As Button
    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents RowIndex As DataGridViewTextBoxColumn
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
    Friend WithEvents selectedTabPage As TabPage
    Friend WithEvents containerSelected As Panel
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents nameValue As TextBox
    Friend WithEvents CoinNameLabel As Label
    Friend WithEvents referenceProtocolValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents referenceGroup As GroupBox
    Friend WithEvents cancelUpdate As Button
    Friend WithEvents confirmReference As Button
    Friend WithEvents addNewReference As Button
    Friend WithEvents descriptionValue As TextBox
    Friend WithEvents descriptionLabel As Label
    Friend WithEvents referenceValue As TextBox
    Friend WithEvents codeLabel As Label
    Friend WithEvents referenceDataGrid As DataGridView
    Friend WithEvents rowIndexPrice As DataGridViewTextBoxColumn
    Friend WithEvents code As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
End Class
