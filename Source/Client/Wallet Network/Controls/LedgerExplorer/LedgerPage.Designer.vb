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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.blockGroup = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ledgerInitial = New System.Windows.Forms.TextBox()
        Me.blockValue = New System.Windows.Forms.TextBox()
        Me.changeBlockButton = New System.Windows.Forms.Button()
        Me.volumeValue = New System.Windows.Forms.TextBox()
        Me.informationsGroups = New System.Windows.Forms.GroupBox()
        Me.numTransactionInBlock = New System.Windows.Forms.Label()
        Me.blockNumber = New System.Windows.Forms.Label()
        Me.groupPages.SuspendLayout()
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.blockGroup.SuspendLayout()
        Me.informationsGroups.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupPages
        '
        Me.groupPages.Controls.Add(Me.countLabel)
        Me.groupPages.Controls.Add(Me.pageNumber)
        Me.groupPages.Controls.Add(Me.pagePreviousButton)
        Me.groupPages.Controls.Add(Me.pageNextButton)
        Me.groupPages.Location = New System.Drawing.Point(251, 7)
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pageDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.id.DefaultCellStyle = DataGridViewCellStyle6
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.id.Width = 75
        '
        'registrationTimeStamp
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.registrationTimeStamp.DefaultCellStyle = DataGridViewCellStyle7
        Me.registrationTimeStamp.HeaderText = "Registration Timestamp"
        Me.registrationTimeStamp.Name = "registrationTimeStamp"
        Me.registrationTimeStamp.ReadOnly = True
        Me.registrationTimeStamp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.registrationTimeStamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.registrationTimeStamp.Width = 140
        '
        'classColumn
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.classColumn.DefaultCellStyle = DataGridViewCellStyle8
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
        'blockGroup
        '
        Me.blockGroup.Controls.Add(Me.Label2)
        Me.blockGroup.Controls.Add(Me.Label1)
        Me.blockGroup.Controls.Add(Me.ledgerInitial)
        Me.blockGroup.Controls.Add(Me.blockValue)
        Me.blockGroup.Controls.Add(Me.changeBlockButton)
        Me.blockGroup.Controls.Add(Me.volumeValue)
        Me.blockGroup.Location = New System.Drawing.Point(3, 7)
        Me.blockGroup.Name = "blockGroup"
        Me.blockGroup.Size = New System.Drawing.Size(242, 71)
        Me.blockGroup.TabIndex = 21
        Me.blockGroup.TabStop = False
        Me.blockGroup.Text = "Change block"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "-"
        '
        'ledgerInitial
        '
        Me.ledgerInitial.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ledgerInitial.Location = New System.Drawing.Point(6, 30)
        Me.ledgerInitial.Name = "ledgerInitial"
        Me.ledgerInitial.ReadOnly = True
        Me.ledgerInitial.Size = New System.Drawing.Size(34, 22)
        Me.ledgerInitial.TabIndex = 28
        Me.ledgerInitial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'blockValue
        '
        Me.blockValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blockValue.Location = New System.Drawing.Point(98, 30)
        Me.blockValue.Name = "blockValue"
        Me.blockValue.Size = New System.Drawing.Size(67, 22)
        Me.blockValue.TabIndex = 27
        Me.blockValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'changeBlockButton
        '
        Me.changeBlockButton.Location = New System.Drawing.Point(173, 24)
        Me.changeBlockButton.Name = "changeBlockButton"
        Me.changeBlockButton.Size = New System.Drawing.Size(63, 34)
        Me.changeBlockButton.TabIndex = 26
        Me.changeBlockButton.Text = "Change"
        Me.changeBlockButton.UseVisualStyleBackColor = True
        '
        'volumeValue
        '
        Me.volumeValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.volumeValue.Location = New System.Drawing.Point(52, 30)
        Me.volumeValue.Name = "volumeValue"
        Me.volumeValue.Size = New System.Drawing.Size(34, 22)
        Me.volumeValue.TabIndex = 25
        Me.volumeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'informationsGroups
        '
        Me.informationsGroups.Controls.Add(Me.numTransactionInBlock)
        Me.informationsGroups.Controls.Add(Me.blockNumber)
        Me.informationsGroups.Location = New System.Drawing.Point(430, 7)
        Me.informationsGroups.Name = "informationsGroups"
        Me.informationsGroups.Size = New System.Drawing.Size(200, 71)
        Me.informationsGroups.TabIndex = 22
        Me.informationsGroups.TabStop = False
        Me.informationsGroups.Text = "Informations"
        '
        'numTransactionInBlock
        '
        Me.numTransactionInBlock.AutoSize = True
        Me.numTransactionInBlock.Location = New System.Drawing.Point(6, 53)
        Me.numTransactionInBlock.Name = "numTransactionInBlock"
        Me.numTransactionInBlock.Size = New System.Drawing.Size(28, 13)
        Me.numTransactionInBlock.TabIndex = 19
        Me.numTransactionInBlock.Text = "xxx"
        '
        'blockNumber
        '
        Me.blockNumber.AutoSize = True
        Me.blockNumber.Location = New System.Drawing.Point(6, 30)
        Me.blockNumber.Name = "blockNumber"
        Me.blockNumber.Size = New System.Drawing.Size(28, 13)
        Me.blockNumber.TabIndex = 18
        Me.blockNumber.Text = "xxx"
        '
        'LedgerPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.informationsGroups)
        Me.Controls.Add(Me.blockGroup)
        Me.Controls.Add(Me.pageDataGrid)
        Me.Controls.Add(Me.groupPages)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "LedgerPage"
        Me.Size = New System.Drawing.Size(750, 400)
        Me.groupPages.ResumeLayout(False)
        Me.groupPages.PerformLayout()
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.blockGroup.ResumeLayout(False)
        Me.blockGroup.PerformLayout()
        Me.informationsGroups.ResumeLayout(False)
        Me.informationsGroups.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents blockGroup As GroupBox
    Friend WithEvents changeBlockButton As Button
    Friend WithEvents volumeValue As TextBox
    Friend WithEvents informationsGroups As GroupBox
    Friend WithEvents numTransactionInBlock As Label
    Friend WithEvents blockNumber As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ledgerInitial As TextBox
    Friend WithEvents blockValue As TextBox
End Class
