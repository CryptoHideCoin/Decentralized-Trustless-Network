<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChainMasternodes
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.masterNodeDataGrid = New System.Windows.Forms.DataGridView()
        Me.publicAddress = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupPages = New System.Windows.Forms.GroupBox()
        Me.countLabel = New System.Windows.Forms.Label()
        Me.pageNumber = New System.Windows.Forms.TextBox()
        Me.pagePreviousButton = New System.Windows.Forms.Button()
        Me.pageNextButton = New System.Windows.Forms.Button()
        Me.masterNodeNumValueLabel = New System.Windows.Forms.Label()
        CType(Me.masterNodeDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupPages.SuspendLayout()
        Me.SuspendLayout()
        '
        'masterNodeDataGrid
        '
        Me.masterNodeDataGrid.AllowUserToAddRows = False
        Me.masterNodeDataGrid.AllowUserToDeleteRows = False
        Me.masterNodeDataGrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.masterNodeDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.masterNodeDataGrid.ColumnHeadersHeight = 42
        Me.masterNodeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.masterNodeDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.publicAddress, Me.role})
        Me.masterNodeDataGrid.Location = New System.Drawing.Point(0, 80)
        Me.masterNodeDataGrid.MultiSelect = False
        Me.masterNodeDataGrid.Name = "masterNodeDataGrid"
        Me.masterNodeDataGrid.ReadOnly = True
        Me.masterNodeDataGrid.RowHeadersVisible = False
        Me.masterNodeDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.masterNodeDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.masterNodeDataGrid.Size = New System.Drawing.Size(759, 268)
        Me.masterNodeDataGrid.TabIndex = 12
        '
        'publicAddress
        '
        Me.publicAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.publicAddress.HeaderText = "Public Address"
        Me.publicAddress.Name = "publicAddress"
        Me.publicAddress.ReadOnly = True
        Me.publicAddress.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.publicAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'role
        '
        Me.role.HeaderText = "Role"
        Me.role.Name = "role"
        Me.role.ReadOnly = True
        Me.role.Width = 150
        '
        'groupPages
        '
        Me.groupPages.Controls.Add(Me.countLabel)
        Me.groupPages.Controls.Add(Me.pageNumber)
        Me.groupPages.Controls.Add(Me.pagePreviousButton)
        Me.groupPages.Controls.Add(Me.pageNextButton)
        Me.groupPages.Location = New System.Drawing.Point(3, 3)
        Me.groupPages.Name = "groupPages"
        Me.groupPages.Size = New System.Drawing.Size(148, 71)
        Me.groupPages.TabIndex = 13
        Me.groupPages.TabStop = False
        Me.groupPages.Text = "Pages"
        '
        'countLabel
        '
        Me.countLabel.AutoSize = True
        Me.countLabel.Location = New System.Drawing.Point(41, 20)
        Me.countLabel.Name = "countLabel"
        Me.countLabel.Size = New System.Drawing.Size(64, 13)
        Me.countLabel.TabIndex = 11
        Me.countLabel.Text = "Count: 00"
        '
        'pageNumber
        '
        Me.pageNumber.Location = New System.Drawing.Point(40, 42)
        Me.pageNumber.Name = "pageNumber"
        Me.pageNumber.Size = New System.Drawing.Size(70, 21)
        Me.pageNumber.TabIndex = 10
        Me.pageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pagePreviousButton
        '
        Me.pagePreviousButton.Location = New System.Drawing.Point(12, 20)
        Me.pagePreviousButton.Name = "pagePreviousButton"
        Me.pagePreviousButton.Size = New System.Drawing.Size(22, 43)
        Me.pagePreviousButton.TabIndex = 9
        Me.pagePreviousButton.Text = "<"
        Me.pagePreviousButton.UseVisualStyleBackColor = True
        '
        'pageNextButton
        '
        Me.pageNextButton.Location = New System.Drawing.Point(116, 20)
        Me.pageNextButton.Name = "pageNextButton"
        Me.pageNextButton.Size = New System.Drawing.Size(22, 43)
        Me.pageNextButton.TabIndex = 8
        Me.pageNextButton.Text = ">"
        Me.pageNextButton.UseVisualStyleBackColor = True
        '
        'masterNodeNumValueLabel
        '
        Me.masterNodeNumValueLabel.AutoSize = True
        Me.masterNodeNumValueLabel.Location = New System.Drawing.Point(157, 53)
        Me.masterNodeNumValueLabel.Name = "masterNodeNumValueLabel"
        Me.masterNodeNumValueLabel.Size = New System.Drawing.Size(155, 13)
        Me.masterNodeNumValueLabel.TabIndex = 14
        Me.masterNodeNumValueLabel.Text = "Total MasterNodes count: "
        '
        'ChainMasternodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.masterNodeNumValueLabel)
        Me.Controls.Add(Me.groupPages)
        Me.Controls.Add(Me.masterNodeDataGrid)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ChainMasternodes"
        Me.Size = New System.Drawing.Size(759, 351)
        CType(Me.masterNodeDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupPages.ResumeLayout(False)
        Me.groupPages.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents masterNodeDataGrid As DataGridView
    Friend WithEvents publicAddress As DataGridViewLinkColumn
    Friend WithEvents role As DataGridViewTextBoxColumn
    Friend WithEvents groupPages As GroupBox
    Friend WithEvents countLabel As Label
    Friend WithEvents pageNumber As TextBox
    Friend WithEvents pagePreviousButton As Button
    Friend WithEvents pageNextButton As Button
    Friend WithEvents masterNodeNumValueLabel As Label
End Class
