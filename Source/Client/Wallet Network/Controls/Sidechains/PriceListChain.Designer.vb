<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PriceListChain
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
        Me.codePriceList = New System.Windows.Forms.TextBox()
        Me.codeLabel = New System.Windows.Forms.Label()
        Me.priceDetailGrid = New System.Windows.Forms.DataGridView()
        Me.code = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.priceDetailGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'codePriceList
        '
        Me.codePriceList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codePriceList.Location = New System.Drawing.Point(22, 31)
        Me.codePriceList.Name = "codePriceList"
        Me.codePriceList.ReadOnly = True
        Me.codePriceList.Size = New System.Drawing.Size(201, 21)
        Me.codePriceList.TabIndex = 46
        Me.codePriceList.Text = "xxxx"
        '
        'codeLabel
        '
        Me.codeLabel.AutoSize = True
        Me.codeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codeLabel.Location = New System.Drawing.Point(19, 15)
        Me.codeLabel.Name = "codeLabel"
        Me.codeLabel.Size = New System.Drawing.Size(37, 13)
        Me.codeLabel.TabIndex = 47
        Me.codeLabel.Text = "Code"
        '
        'priceDetailGrid
        '
        Me.priceDetailGrid.AllowUserToAddRows = False
        Me.priceDetailGrid.AllowUserToDeleteRows = False
        Me.priceDetailGrid.AllowUserToResizeColumns = False
        Me.priceDetailGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.priceDetailGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.priceDetailGrid.ColumnHeadersHeight = 42
        Me.priceDetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.priceDetailGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.code, Me.description, Me.contribute})
        Me.priceDetailGrid.Location = New System.Drawing.Point(22, 58)
        Me.priceDetailGrid.MultiSelect = False
        Me.priceDetailGrid.Name = "priceDetailGrid"
        Me.priceDetailGrid.ReadOnly = True
        Me.priceDetailGrid.RowHeadersVisible = False
        Me.priceDetailGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.priceDetailGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.priceDetailGrid.Size = New System.Drawing.Size(630, 262)
        Me.priceDetailGrid.TabIndex = 48
        '
        'code
        '
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        Me.code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.code.Width = 150
        '
        'description
        '
        Me.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.DefaultCellStyle = DataGridViewCellStyle2
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'contribute
        '
        Me.contribute.HeaderText = "Fee"
        Me.contribute.Name = "contribute"
        Me.contribute.ReadOnly = True
        Me.contribute.Width = 150
        '
        'PriceListChain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.priceDetailGrid)
        Me.Controls.Add(Me.codePriceList)
        Me.Controls.Add(Me.codeLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PriceListChain"
        Me.Size = New System.Drawing.Size(670, 338)
        CType(Me.priceDetailGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents codePriceList As TextBox
    Friend WithEvents codeLabel As Label
    Friend WithEvents priceDetailGrid As DataGridView
    Friend WithEvents code As DataGridViewLinkColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents contribute As DataGridViewTextBoxColumn
End Class
