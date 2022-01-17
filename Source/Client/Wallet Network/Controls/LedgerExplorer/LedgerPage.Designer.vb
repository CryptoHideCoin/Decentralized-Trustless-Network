<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerPage
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.groupPages = New System.Windows.Forms.GroupBox()
        Me.countLabel = New System.Windows.Forms.Label()
        Me.pageNumber = New System.Windows.Forms.TextBox()
        Me.pagePreviousButton = New System.Windows.Forms.Button()
        Me.pageNextButton = New System.Windows.Forms.Button()
        Me.pageDataGrid = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.registrationTimeStamp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.orderer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Validator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cumulativeHash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.blockNumber = New System.Windows.Forms.Label()
        Me.numTransactionInBlock = New System.Windows.Forms.Label()
        Me.groupPages.SuspendLayout()
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupPages
        '
        Me.groupPages.Controls.Add(Me.countLabel)
        Me.groupPages.Controls.Add(Me.pageNumber)
        Me.groupPages.Controls.Add(Me.pagePreviousButton)
        Me.groupPages.Controls.Add(Me.pageNextButton)
        Me.groupPages.Location = New System.Drawing.Point(9, 7)
        Me.groupPages.Name = "groupPages"
        Me.groupPages.Size = New System.Drawing.Size(173, 71)
        Me.groupPages.TabIndex = 14
        Me.groupPages.TabStop = False
        Me.groupPages.Text = "Pages"
        '
        'countLabel
        '
        Me.countLabel.AutoSize = True
        Me.countLabel.Location = New System.Drawing.Point(48, 20)
        Me.countLabel.Name = "countLabel"
        Me.countLabel.Size = New System.Drawing.Size(64, 13)
        Me.countLabel.TabIndex = 11
        Me.countLabel.Text = "Count: 00"
        '
        'pageNumber
        '
        Me.pageNumber.Location = New System.Drawing.Point(47, 42)
        Me.pageNumber.Name = "pageNumber"
        Me.pageNumber.Size = New System.Drawing.Size(81, 21)
        Me.pageNumber.TabIndex = 10
        Me.pageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pagePreviousButton
        '
        Me.pagePreviousButton.Location = New System.Drawing.Point(14, 20)
        Me.pagePreviousButton.Name = "pagePreviousButton"
        Me.pagePreviousButton.Size = New System.Drawing.Size(26, 43)
        Me.pagePreviousButton.TabIndex = 9
        Me.pagePreviousButton.Text = "<"
        Me.pagePreviousButton.UseVisualStyleBackColor = True
        '
        'pageNextButton
        '
        Me.pageNextButton.Location = New System.Drawing.Point(135, 20)
        Me.pageNextButton.Name = "pageNextButton"
        Me.pageNextButton.Size = New System.Drawing.Size(26, 43)
        Me.pageNextButton.TabIndex = 8
        Me.pageNextButton.Text = ">"
        Me.pageNextButton.UseVisualStyleBackColor = True
        '
        'pageDataGrid
        '
        Me.pageDataGrid.AllowUserToAddRows = False
        Me.pageDataGrid.AllowUserToDeleteRows = False
        Me.pageDataGrid.AllowUserToResizeColumns = False
        Me.pageDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pageDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.pageDataGrid.ColumnHeadersHeight = 42
        Me.pageDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.pageDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.registrationTimeStamp, Me.classColumn, Me.orderer, Me.Validator, Me.hash, Me.cumulativeHash})
        Me.pageDataGrid.Location = New System.Drawing.Point(3, 84)
        Me.pageDataGrid.MultiSelect = False
        Me.pageDataGrid.Name = "pageDataGrid"
        Me.pageDataGrid.ReadOnly = True
        Me.pageDataGrid.RowHeadersVisible = False
        Me.pageDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.pageDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.pageDataGrid.Size = New System.Drawing.Size(744, 313)
        Me.pageDataGrid.TabIndex = 15
        '
        'id
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.id.DefaultCellStyle = DataGridViewCellStyle2
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.id.Width = 75
        '
        'registrationTimeStamp
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.registrationTimeStamp.DefaultCellStyle = DataGridViewCellStyle3
        Me.registrationTimeStamp.HeaderText = "Registration Timestamp"
        Me.registrationTimeStamp.Name = "registrationTimeStamp"
        Me.registrationTimeStamp.ReadOnly = True
        Me.registrationTimeStamp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.registrationTimeStamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.registrationTimeStamp.Width = 140
        '
        'classColumn
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.classColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.classColumn.HeaderText = "Class"
        Me.classColumn.Name = "classColumn"
        Me.classColumn.ReadOnly = True
        Me.classColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.classColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.classColumn.Width = 60
        '
        'orderer
        '
        Me.orderer.HeaderText = "Orderer"
        Me.orderer.Name = "orderer"
        Me.orderer.ReadOnly = True
        Me.orderer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.orderer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.orderer.Width = 120
        '
        'Validator
        '
        Me.Validator.HeaderText = "Validator"
        Me.Validator.Name = "Validator"
        Me.Validator.ReadOnly = True
        Me.Validator.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Validator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Validator.Width = 120
        '
        'hash
        '
        Me.hash.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.hash.HeaderText = "Hash"
        Me.hash.Name = "hash"
        Me.hash.ReadOnly = True
        Me.hash.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cumulativeHash
        '
        Me.cumulativeHash.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cumulativeHash.HeaderText = "Cumulative Hash"
        Me.cumulativeHash.Name = "cumulativeHash"
        Me.cumulativeHash.ReadOnly = True
        Me.cumulativeHash.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cumulativeHash.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'blockNumber
        '
        Me.blockNumber.AutoSize = True
        Me.blockNumber.Location = New System.Drawing.Point(192, 26)
        Me.blockNumber.Name = "blockNumber"
        Me.blockNumber.Size = New System.Drawing.Size(28, 13)
        Me.blockNumber.TabIndex = 16
        Me.blockNumber.Text = "xxx"
        '
        'numTransactionInBlock
        '
        Me.numTransactionInBlock.AutoSize = True
        Me.numTransactionInBlock.Location = New System.Drawing.Point(192, 49)
        Me.numTransactionInBlock.Name = "numTransactionInBlock"
        Me.numTransactionInBlock.Size = New System.Drawing.Size(28, 13)
        Me.numTransactionInBlock.TabIndex = 17
        Me.numTransactionInBlock.Text = "xxx"
        '
        'LedgerPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.numTransactionInBlock)
        Me.Controls.Add(Me.blockNumber)
        Me.Controls.Add(Me.pageDataGrid)
        Me.Controls.Add(Me.groupPages)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "LedgerPage"
        Me.Size = New System.Drawing.Size(750, 400)
        Me.groupPages.ResumeLayout(False)
        Me.groupPages.PerformLayout()
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents groupPages As GroupBox
    Friend WithEvents countLabel As Label
    Friend WithEvents pageNumber As TextBox
    Friend WithEvents pagePreviousButton As Button
    Friend WithEvents pageNextButton As Button
    Friend WithEvents pageDataGrid As DataGridView
    Friend WithEvents id As DataGridViewLinkColumn
    Friend WithEvents registrationTimeStamp As DataGridViewTextBoxColumn
    Friend WithEvents classColumn As DataGridViewTextBoxColumn
    Friend WithEvents orderer As DataGridViewTextBoxColumn
    Friend WithEvents Validator As DataGridViewTextBoxColumn
    Friend WithEvents hash As DataGridViewTextBoxColumn
    Friend WithEvents cumulativeHash As DataGridViewTextBoxColumn
    Friend WithEvents blockNumber As Label
    Friend WithEvents numTransactionInBlock As Label
End Class
