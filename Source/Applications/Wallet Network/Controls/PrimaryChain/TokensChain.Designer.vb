<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TokensChain
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tokensDataGrid = New System.Windows.Forms.DataGridView()
        Me.token = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.shortName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.tokensDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tokensDataGrid
        '
        Me.tokensDataGrid.AllowUserToAddRows = False
        Me.tokensDataGrid.AllowUserToDeleteRows = False
        Me.tokensDataGrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tokensDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tokensDataGrid.ColumnHeadersHeight = 42
        Me.tokensDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.tokensDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.token, Me.shortName})
        Me.tokensDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tokensDataGrid.Location = New System.Drawing.Point(0, 0)
        Me.tokensDataGrid.MultiSelect = False
        Me.tokensDataGrid.Name = "tokensDataGrid"
        Me.tokensDataGrid.ReadOnly = True
        Me.tokensDataGrid.RowHeadersVisible = False
        Me.tokensDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tokensDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tokensDataGrid.Size = New System.Drawing.Size(759, 351)
        Me.tokensDataGrid.TabIndex = 11
        '
        'token
        '
        Me.token.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.token.HeaderText = "Token"
        Me.token.Name = "token"
        Me.token.ReadOnly = True
        Me.token.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.token.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'shortName
        '
        Me.shortName.HeaderText = "Short Name"
        Me.shortName.Name = "shortName"
        Me.shortName.ReadOnly = True
        Me.shortName.Width = 150
        '
        'TokensChain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tokensDataGrid)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Name = "TokensChain"
        Me.Size = New System.Drawing.Size(759, 351)
        CType(Me.tokensDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tokensDataGrid As DataGridView
    Friend WithEvents token As DataGridViewLinkColumn
    Friend WithEvents shortName As DataGridViewTextBoxColumn
End Class
