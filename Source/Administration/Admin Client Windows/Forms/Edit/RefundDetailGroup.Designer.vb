<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class refundDetailGroup
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(refundDetailGroup))
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.nameValue = New System.Windows.Forms.TextBox()
        Me.cancelUpdate = New System.Windows.Forms.Button()
        Me.confirmGroup = New System.Windows.Forms.Button()
        Me.refundInFixValue = New System.Windows.Forms.RadioButton()
        Me.refundInPercentage = New System.Windows.Forms.RadioButton()
        Me.addNewItem = New System.Windows.Forms.Button()
        Me.value = New System.Windows.Forms.TextBox()
        Me.valueLabel = New System.Windows.Forms.Label()
        Me.recipientLabel = New System.Windows.Forms.Label()
        Me.itemDataGrid = New System.Windows.Forms.DataGridView()
        Me.rowIndexPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recipient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.refund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.containerSelected = New System.Windows.Forms.Panel()
        Me.groupValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.groupItems = New System.Windows.Forms.GroupBox()
        Me.recipientValue = New System.Windows.Forms.ComboBox()
        Me.selectedTabPage = New System.Windows.Forms.TabPage()
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        CType(Me.itemDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.containerSelected.SuspendLayout()
        Me.groupItems.SuspendLayout()
        Me.selectedTabPage.SuspendLayout()
        Me.mainTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'nameLabel
        '
        Me.nameLabel.AutoSize = True
        Me.nameLabel.Location = New System.Drawing.Point(21, 11)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(78, 13)
        Me.nameLabel.TabIndex = 71
        Me.nameLabel.Text = "Group name"
        '
        'nameValue
        '
        Me.nameValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nameValue.Location = New System.Drawing.Point(25, 27)
        Me.nameValue.MaxLength = 150
        Me.nameValue.Name = "nameValue"
        Me.nameValue.ReadOnly = True
        Me.nameValue.Size = New System.Drawing.Size(696, 21)
        Me.nameValue.TabIndex = 2
        '
        'cancelUpdate
        '
        Me.cancelUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelUpdate.Enabled = False
        Me.cancelUpdate.Location = New System.Drawing.Point(713, 385)
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
        Me.confirmGroup.Location = New System.Drawing.Point(713, 339)
        Me.confirmGroup.Name = "confirmGroup"
        Me.confirmGroup.Size = New System.Drawing.Size(120, 40)
        Me.confirmGroup.TabIndex = 7
        Me.confirmGroup.Text = "Confirm Recipient"
        Me.confirmGroup.UseVisualStyleBackColor = True
        '
        'refundInFixValue
        '
        Me.refundInFixValue.AutoSize = True
        Me.refundInFixValue.Enabled = False
        Me.refundInFixValue.Location = New System.Drawing.Point(10, 345)
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
        Me.refundInPercentage.Location = New System.Drawing.Point(10, 322)
        Me.refundInPercentage.Name = "refundInPercentage"
        Me.refundInPercentage.Size = New System.Drawing.Size(147, 17)
        Me.refundInPercentage.TabIndex = 4
        Me.refundInPercentage.TabStop = True
        Me.refundInPercentage.Text = "Refund in percentage"
        Me.refundInPercentage.UseVisualStyleBackColor = True
        '
        'addNewItem
        '
        Me.addNewItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addNewItem.Location = New System.Drawing.Point(713, 20)
        Me.addNewItem.Name = "addNewItem"
        Me.addNewItem.Size = New System.Drawing.Size(120, 39)
        Me.addNewItem.TabIndex = 1
        Me.addNewItem.Text = "Add New Recipient"
        Me.addNewItem.UseVisualStyleBackColor = True
        '
        'value
        '
        Me.value.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.value.Enabled = False
        Me.value.Location = New System.Drawing.Point(11, 388)
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
        Me.valueLabel.Location = New System.Drawing.Point(7, 372)
        Me.valueLabel.Name = "valueLabel"
        Me.valueLabel.Size = New System.Drawing.Size(38, 13)
        Me.valueLabel.TabIndex = 84
        Me.valueLabel.Text = "Value"
        '
        'recipientLabel
        '
        Me.recipientLabel.AutoSize = True
        Me.recipientLabel.Enabled = False
        Me.recipientLabel.Location = New System.Drawing.Point(8, 273)
        Me.recipientLabel.Name = "recipientLabel"
        Me.recipientLabel.Size = New System.Drawing.Size(59, 13)
        Me.recipientLabel.TabIndex = 82
        Me.recipientLabel.Text = "Recipient"
        '
        'itemDataGrid
        '
        Me.itemDataGrid.AllowUserToAddRows = False
        Me.itemDataGrid.AllowUserToDeleteRows = False
        Me.itemDataGrid.AllowUserToResizeColumns = False
        Me.itemDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.itemDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.itemDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowIndexPrice, Me.recipient, Me.refund})
        Me.itemDataGrid.Location = New System.Drawing.Point(11, 20)
        Me.itemDataGrid.MultiSelect = False
        Me.itemDataGrid.Name = "itemDataGrid"
        Me.itemDataGrid.ReadOnly = True
        Me.itemDataGrid.RowHeadersVisible = False
        Me.itemDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.itemDataGrid.Size = New System.Drawing.Size(686, 235)
        Me.itemDataGrid.TabIndex = 0
        '
        'rowIndexPrice
        '
        Me.rowIndexPrice.HeaderText = "Row Index"
        Me.rowIndexPrice.Name = "rowIndexPrice"
        Me.rowIndexPrice.ReadOnly = True
        Me.rowIndexPrice.Visible = False
        '
        'recipient
        '
        Me.recipient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.recipient.HeaderText = "Recipient"
        Me.recipient.Name = "recipient"
        Me.recipient.ReadOnly = True
        '
        'refund
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.refund.DefaultCellStyle = DataGridViewCellStyle1
        Me.refund.HeaderText = "Refund"
        Me.refund.Name = "refund"
        Me.refund.ReadOnly = True
        Me.refund.Width = 200
        '
        'containerSelected
        '
        Me.containerSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.containerSelected.Controls.Add(Me.groupValue)
        Me.containerSelected.Controls.Add(Me.Label1)
        Me.containerSelected.Controls.Add(Me.groupItems)
        Me.containerSelected.Controls.Add(Me.nameValue)
        Me.containerSelected.Controls.Add(Me.nameLabel)
        Me.containerSelected.Location = New System.Drawing.Point(6, 3)
        Me.containerSelected.Name = "containerSelected"
        Me.containerSelected.Size = New System.Drawing.Size(876, 484)
        Me.containerSelected.TabIndex = 0
        '
        'groupValue
        '
        Me.groupValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupValue.Location = New System.Drawing.Point(737, 27)
        Me.groupValue.MaxLength = 150
        Me.groupValue.Name = "groupValue"
        Me.groupValue.ReadOnly = True
        Me.groupValue.Size = New System.Drawing.Size(126, 21)
        Me.groupValue.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(734, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Group value"
        '
        'groupItems
        '
        Me.groupItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupItems.Controls.Add(Me.recipientValue)
        Me.groupItems.Controls.Add(Me.cancelUpdate)
        Me.groupItems.Controls.Add(Me.confirmGroup)
        Me.groupItems.Controls.Add(Me.refundInFixValue)
        Me.groupItems.Controls.Add(Me.refundInPercentage)
        Me.groupItems.Controls.Add(Me.addNewItem)
        Me.groupItems.Controls.Add(Me.value)
        Me.groupItems.Controls.Add(Me.valueLabel)
        Me.groupItems.Controls.Add(Me.recipientLabel)
        Me.groupItems.Controls.Add(Me.itemDataGrid)
        Me.groupItems.Location = New System.Drawing.Point(24, 54)
        Me.groupItems.Name = "groupItems"
        Me.groupItems.Size = New System.Drawing.Size(839, 419)
        Me.groupItems.TabIndex = 4
        Me.groupItems.TabStop = False
        Me.groupItems.Text = "Items"
        '
        'recipientValue
        '
        Me.recipientValue.FormattingEnabled = True
        Me.recipientValue.Items.AddRange(New Object() {"Staking_Reward_Primary", "Staking_Reward_Storage", "Staking_Reward_NetworkStat", "Staking_Reward_Value", "Staking_Reward_Vote", "Staking_Reward_Faucet", "Staking_Reward_Discussion", ""})
        Me.recipientValue.Location = New System.Drawing.Point(10, 289)
        Me.recipientValue.Name = "recipientValue"
        Me.recipientValue.Size = New System.Drawing.Size(687, 21)
        Me.recipientValue.TabIndex = 85
        '
        'selectedTabPage
        '
        Me.selectedTabPage.Controls.Add(Me.containerSelected)
        Me.selectedTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedTabPage.Location = New System.Drawing.Point(4, 22)
        Me.selectedTabPage.Name = "selectedTabPage"
        Me.selectedTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.selectedTabPage.Size = New System.Drawing.Size(888, 493)
        Me.selectedTabPage.TabIndex = 1
        Me.selectedTabPage.Text = "Detail"
        Me.selectedTabPage.UseVisualStyleBackColor = True
        '
        'mainTabControl
        '
        Me.mainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTabControl.Controls.Add(Me.selectedTabPage)
        Me.mainTabControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTabControl.Location = New System.Drawing.Point(11, 12)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(896, 519)
        Me.mainTabControl.TabIndex = 1
        '
        'refundDetailGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 536)
        Me.Controls.Add(Me.mainTabControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(935, 575)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(935, 575)
        Me.Name = "refundDetailGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Refund detail group"
        CType(Me.itemDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.containerSelected.ResumeLayout(False)
        Me.containerSelected.PerformLayout()
        Me.groupItems.ResumeLayout(False)
        Me.groupItems.PerformLayout()
        Me.selectedTabPage.ResumeLayout(False)
        Me.mainTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents nameLabel As Label
    Friend WithEvents nameValue As TextBox
    Friend WithEvents cancelUpdate As Button
    Friend WithEvents confirmGroup As Button
    Friend WithEvents refundInFixValue As RadioButton
    Friend WithEvents refundInPercentage As RadioButton
    Friend WithEvents addNewItem As Button
    Friend WithEvents value As TextBox
    Friend WithEvents valueLabel As Label
    Friend WithEvents recipientLabel As Label
    Friend WithEvents itemDataGrid As DataGridView
    Friend WithEvents containerSelected As Panel
    Friend WithEvents groupItems As GroupBox
    Friend WithEvents selectedTabPage As TabPage
    Friend WithEvents mainTabControl As TabControl
    Friend WithEvents recipientValue As ComboBox
    Friend WithEvents groupValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rowIndexPrice As DataGridViewTextBoxColumn
    Friend WithEvents recipient As DataGridViewTextBoxColumn
    Friend WithEvents refund As DataGridViewTextBoxColumn
End Class
