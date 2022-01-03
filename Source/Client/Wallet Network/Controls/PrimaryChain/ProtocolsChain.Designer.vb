<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProtocolsChain
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
        Me.protocolDataGrid = New System.Windows.Forms.DataGridView()
        Me.setCode = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.protocol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.protocolDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'protocolDataGrid
        '
        Me.protocolDataGrid.AllowUserToAddRows = False
        Me.protocolDataGrid.AllowUserToDeleteRows = False
        Me.protocolDataGrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.protocolDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.protocolDataGrid.ColumnHeadersHeight = 42
        Me.protocolDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.protocolDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.setCode, Me.protocol})
        Me.protocolDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.protocolDataGrid.Location = New System.Drawing.Point(0, 0)
        Me.protocolDataGrid.MultiSelect = False
        Me.protocolDataGrid.Name = "protocolDataGrid"
        Me.protocolDataGrid.ReadOnly = True
        Me.protocolDataGrid.RowHeadersVisible = False
        Me.protocolDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.protocolDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.protocolDataGrid.Size = New System.Drawing.Size(759, 351)
        Me.protocolDataGrid.TabIndex = 10
        '
        'setCode
        '
        Me.setCode.HeaderText = "Set Code"
        Me.setCode.Name = "setCode"
        Me.setCode.ReadOnly = True
        Me.setCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.setCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.setCode.Width = 150
        '
        'protocol
        '
        Me.protocol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.protocol.DefaultCellStyle = DataGridViewCellStyle2
        Me.protocol.HeaderText = "Protocol"
        Me.protocol.Name = "protocol"
        Me.protocol.ReadOnly = True
        '
        'ProtocolsChain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.protocolDataGrid)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ProtocolsChain"
        Me.Size = New System.Drawing.Size(759, 351)
        CType(Me.protocolDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents protocolDataGrid As DataGridView
    Friend WithEvents setCode As DataGridViewLinkColumn
    Friend WithEvents protocol As DataGridViewTextBoxColumn
End Class
