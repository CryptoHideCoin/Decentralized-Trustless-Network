<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RefundPlanForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RefundPlanForm))
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        Me.listTabPage = New System.Windows.Forms.TabPage()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.dataGridView = New System.Windows.Forms.DataGridView()
        Me.RowIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selectedTabPage = New System.Windows.Forms.TabPage()
        Me.containerSelected = New System.Windows.Forms.Panel()
        Me.priceGroup = New System.Windows.Forms.GroupBox()
        Me.detailGroup = New System.Windows.Forms.Button()
        Me.cancelUpdate = New System.Windows.Forms.Button()
        Me.confirmGroup = New System.Windows.Forms.Button()
        Me.refundInFixValue = New System.Windows.Forms.RadioButton()
        Me.refundInPercentage = New System.Windows.Forms.RadioButton()
        Me.addNewGroup = New System.Windows.Forms.Button()
        Me.value = New System.Windows.Forms.TextBox()
        Me.valueLabel = New System.Windows.Forms.Label()
        Me.groupName = New System.Windows.Forms.TextBox()
        Me.groupLabel = New System.Windows.Forms.Label()
        Me.groupDataGrid = New System.Windows.Forms.DataGridView()
        Me.rowIndexPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.group = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.refund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.effectiveDateValue = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.nameValue = New System.Windows.Forms.TextBox()
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.mainTabControl.SuspendLayout()
        Me.listTabPage.SuspendLayout()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.selectedTabPage.SuspendLayout()
        Me.containerSelected.SuspendLayout()
        Me.priceGroup.SuspendLayout()
        CType(Me.groupDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainTabControl
        '
        Me.mainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTabControl.Controls.Add(Me.listTabPage)
        Me.mainTabControl.Controls.Add(Me.selectedTabPage)
        Me.mainTabControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTabControl.Location = New System.Drawing.Point(10, 10)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(892, 640)
        Me.mainTabControl.TabIndex = 0
        '
        'listTabPage
        '
        Me.listTabPage.Controls.Add(Me.createNewButton)
        Me.listTabPage.Controls.Add(Me.refreshButton)
        Me.listTabPage.Controls.Add(Me.dataGridView)
        Me.listTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listTabPage.Location = New System.Drawing.Point(4, 22)
        Me.listTabPage.Name = "listTabPage"
        Me.listTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.listTabPage.Size = New System.Drawing.Size(884, 614)
        Me.listTabPage.TabIndex = 0
        Me.listTabPage.Text = "Complete List"
        Me.listTabPage.UseVisualStyleBackColor = True
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
        'priceGroup
        '
        Me.priceGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceGroup.Controls.Add(Me.detailGroup)
        Me.priceGroup.Controls.Add(Me.cancelUpdate)
        Me.priceGroup.Controls.Add(Me.confirmGroup)
        Me.priceGroup.Controls.Add(Me.refundInFixValue)
        Me.priceGroup.Controls.Add(Me.refundInPercentage)
        Me.priceGroup.Controls.Add(Me.addNewGroup)
        Me.priceGroup.Controls.Add(Me.value)
        Me.priceGroup.Controls.Add(Me.valueLabel)
        Me.priceGroup.Controls.Add(Me.groupName)
        Me.priceGroup.Controls.Add(Me.groupLabel)
        Me.priceGroup.Controls.Add(Me.groupDataGrid)
        Me.priceGroup.Location = New System.Drawing.Point(25, 132)
        Me.priceGroup.Name = "priceGroup"
        Me.priceGroup.Size = New System.Drawing.Size(834, 416)
        Me.priceGroup.TabIndex = 4
        Me.priceGroup.TabStop = False
        Me.priceGroup.Text = "Groups"
        '
        'detailGroup
        '
        Me.detailGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.detailGroup.Enabled = False
        Me.detailGroup.Location = New System.Drawing.Point(662, 286)
        Me.detailGroup.Name = "detailGroup"
        Me.detailGroup.Size = New System.Drawing.Size(30, 24)
        Me.detailGroup.TabIndex = 3
        Me.detailGroup.Text = "..."
        Me.detailGroup.UseVisualStyleBackColor = True
        '
        'cancelUpdate
        '
        Me.cancelUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelUpdate.Enabled = False
        Me.cancelUpdate.Location = New System.Drawing.Point(708, 384)
        Me.cancelUpdate.Name = "cancelUpdate"
        Me.cancelUpdate.Size = New System.Drawing.Size(120, 23)
        Me.cancelUpdate.TabIndex = 8
        Me.cancelUpdate.Text = "Cancel"
        Me.cancelUpdate.UseVisualStyleBackColor = True
        '
        'confirmGroup
        '
        Me.confirmGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmGroup.Enabled = False
        Me.confirmGroup.Location = New System.Drawing.Point(708, 338)
        Me.confirmGroup.Name = "confirmGroup"
        Me.confirmGroup.Size = New System.Drawing.Size(120, 40)
        Me.confirmGroup.TabIndex = 7
        Me.confirmGroup.Text = "Confirm Group"
        Me.confirmGroup.UseVisualStyleBackColor = True
        '
        'refundInFixValue
        '
        Me.refundInFixValue.AutoSize = True
        Me.refundInFixValue.Enabled = False
        Me.refundInFixValue.Location = New System.Drawing.Point(6, 345)
        Me.refundInFixValue.Name = "refundInFixValue"
        Me.refundInFixValue.Size = New System.Drawing.Size(132, 17)
        Me.refundInFixValue.TabIndex = 5
        Me.refundInFixValue.Text = "Refund in fix value"
        Me.refundInFixValue.UseVisualStyleBackColor = True
        '
        'refundInPercentage
        '
        Me.refundInPercentage.AutoSize = True
        Me.refundInPercentage.Checked = True
        Me.refundInPercentage.Enabled = False
        Me.refundInPercentage.Location = New System.Drawing.Point(6, 322)
        Me.refundInPercentage.Name = "refundInPercentage"
        Me.refundInPercentage.Size = New System.Drawing.Size(147, 17)
        Me.refundInPercentage.TabIndex = 4
        Me.refundInPercentage.TabStop = True
        Me.refundInPercentage.Text = "Refund in percentage"
        Me.refundInPercentage.UseVisualStyleBackColor = True
        '
        'addNewGroup
        '
        Me.addNewGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addNewGroup.Location = New System.Drawing.Point(708, 20)
        Me.addNewGroup.Name = "addNewGroup"
        Me.addNewGroup.Size = New System.Drawing.Size(120, 39)
        Me.addNewGroup.TabIndex = 1
        Me.addNewGroup.Text = "Add New Group"
        Me.addNewGroup.UseVisualStyleBackColor = True
        '
        'value
        '
        Me.value.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.value.Enabled = False
        Me.value.Location = New System.Drawing.Point(6, 388)
        Me.value.MaxLength = 50
        Me.value.Name = "value"
        Me.value.Size = New System.Drawing.Size(124, 21)
        Me.value.TabIndex = 6
        Me.value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'valueLabel
        '
        Me.valueLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.valueLabel.AutoSize = True
        Me.valueLabel.Enabled = False
        Me.valueLabel.Location = New System.Drawing.Point(2, 372)
        Me.valueLabel.Name = "valueLabel"
        Me.valueLabel.Size = New System.Drawing.Size(38, 13)
        Me.valueLabel.TabIndex = 84
        Me.valueLabel.Text = "Value"
        '
        'groupName
        '
        Me.groupName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupName.Enabled = False
        Me.groupName.Location = New System.Drawing.Point(6, 288)
        Me.groupName.MaxLength = 255
        Me.groupName.Name = "groupName"
        Me.groupName.Size = New System.Drawing.Size(650, 21)
        Me.groupName.TabIndex = 2
        '
        'groupLabel
        '
        Me.groupLabel.AutoSize = True
        Me.groupLabel.Enabled = False
        Me.groupLabel.Location = New System.Drawing.Point(2, 272)
        Me.groupLabel.Name = "groupLabel"
        Me.groupLabel.Size = New System.Drawing.Size(78, 13)
        Me.groupLabel.TabIndex = 82
        Me.groupLabel.Text = "Group name"
        '
        'groupDataGrid
        '
        Me.groupDataGrid.AllowUserToAddRows = False
        Me.groupDataGrid.AllowUserToDeleteRows = False
        Me.groupDataGrid.AllowUserToResizeColumns = False
        Me.groupDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.groupDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowIndexPrice, Me.group, Me.refund})
        Me.groupDataGrid.Location = New System.Drawing.Point(6, 20)
        Me.groupDataGrid.MultiSelect = False
        Me.groupDataGrid.Name = "groupDataGrid"
        Me.groupDataGrid.ReadOnly = True
        Me.groupDataGrid.RowHeadersVisible = False
        Me.groupDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.groupDataGrid.Size = New System.Drawing.Size(686, 235)
        Me.groupDataGrid.TabIndex = 0
        '
        'rowIndexPrice
        '
        Me.rowIndexPrice.HeaderText = "Row Index"
        Me.rowIndexPrice.Name = "rowIndexPrice"
        Me.rowIndexPrice.ReadOnly = True
        Me.rowIndexPrice.Visible = False
        '
        'group
        '
        Me.group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.group.HeaderText = "Group"
        Me.group.Name = "group"
        Me.group.ReadOnly = True
        '
        'refund
        '
        Me.refund.HeaderText = "Refund"
        Me.refund.Name = "refund"
        Me.refund.ReadOnly = True
        Me.refund.Width = 200
        '
        'effectiveDateValue
        '
        Me.effectiveDateValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.effectiveDateValue.Location = New System.Drawing.Point(645, 94)
        Me.effectiveDateValue.Name = "effectiveDateValue"
        Me.effectiveDateValue.Size = New System.Drawing.Size(214, 21)
        Me.effectiveDateValue.TabIndex = 3
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
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Location = New System.Drawing.Point(24, 554)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 51)
        Me.cancelButton.TabIndex = 5
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmButton.Location = New System.Drawing.Point(784, 554)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 51)
        Me.confirmButton.TabIndex = 6
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
        Me.nameValue.Size = New System.Drawing.Size(614, 21)
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
        'RefundPlanForm
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
        Me.Name = "RefundPlanForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Refund Plan Manager"
        Me.mainTabControl.ResumeLayout(False)
        Me.listTabPage.ResumeLayout(False)
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.selectedTabPage.ResumeLayout(False)
        Me.containerSelected.ResumeLayout(False)
        Me.containerSelected.PerformLayout()
        Me.priceGroup.ResumeLayout(False)
        Me.priceGroup.PerformLayout()
        CType(Me.groupDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTabControl As TabControl
    Friend WithEvents listTabPage As TabPage
    Friend WithEvents createNewButton As Button
    Friend WithEvents refreshButton As Button
    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents RowIndex As DataGridViewTextBoxColumn
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents selectedTabPage As TabPage
    Friend WithEvents containerSelected As Panel
    Friend WithEvents priceGroup As GroupBox
    Friend WithEvents value As TextBox
    Friend WithEvents valueLabel As Label
    Friend WithEvents groupName As TextBox
    Friend WithEvents groupLabel As Label
    Friend WithEvents groupDataGrid As DataGridView
    Friend WithEvents effectiveDateValue As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents nameValue As TextBox
    Friend WithEvents nameLabel As Label
    Friend WithEvents rowIndexPrice As DataGridViewTextBoxColumn
    Friend WithEvents group As DataGridViewTextBoxColumn
    Friend WithEvents refund As DataGridViewTextBoxColumn
    Friend WithEvents addNewGroup As Button
    Friend WithEvents refundInFixValue As RadioButton
    Friend WithEvents refundInPercentage As RadioButton
    Friend WithEvents detailGroup As Button
    Friend WithEvents cancelUpdate As Button
    Friend WithEvents confirmGroup As Button
End Class
