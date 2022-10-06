<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataPageList
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataPageList))
        Me.pageDataView = New System.Windows.Forms.DataGridView()
        Me.MainContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowAllDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.initialFund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndFund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Increase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Earn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Power = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.originalFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.pageDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'pageDataView
        '
        Me.pageDataView.AllowUserToAddRows = False
        Me.pageDataView.AllowUserToDeleteRows = False
        Me.pageDataView.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pageDataView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.pageDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pageDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dateColumn, Me.initialFund, Me.EndFund, Me.Increase, Me.Earn, Me.Power, Me.originalFileName, Me.DataGridViewButtonColumn1})
        Me.pageDataView.ContextMenuStrip = Me.MainContextMenuStrip
        Me.pageDataView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageDataView.Location = New System.Drawing.Point(0, 0)
        Me.pageDataView.MultiSelect = False
        Me.pageDataView.Name = "pageDataView"
        Me.pageDataView.RowHeadersVisible = False
        Me.pageDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.pageDataView.Size = New System.Drawing.Size(1065, 273)
        Me.pageDataView.TabIndex = 5
        '
        'MainContextMenuStrip
        '
        Me.MainContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowAllDataToolStripMenuItem})
        Me.MainContextMenuStrip.Name = "MainContextMenuStrip"
        Me.MainContextMenuStrip.Size = New System.Drawing.Size(145, 26)
        '
        'ShowAllDataToolStripMenuItem
        '
        Me.ShowAllDataToolStripMenuItem.Name = "ShowAllDataToolStripMenuItem"
        Me.ShowAllDataToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.ShowAllDataToolStripMenuItem.Text = "Show all data"
        '
        'dateColumn
        '
        Me.dateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        Me.dateColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.dateColumn.HeaderText = "Page"
        Me.dateColumn.Name = "dateColumn"
        Me.dateColumn.ReadOnly = True
        '
        'initialFund
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.initialFund.DefaultCellStyle = DataGridViewCellStyle3
        Me.initialFund.HeaderText = "Initial Fund"
        Me.initialFund.Name = "initialFund"
        '
        'EndFund
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.EndFund.DefaultCellStyle = DataGridViewCellStyle4
        Me.EndFund.HeaderText = "End fund"
        Me.EndFund.Name = "EndFund"
        '
        'Increase
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Increase.DefaultCellStyle = DataGridViewCellStyle5
        Me.Increase.HeaderText = "Increase"
        Me.Increase.Name = "Increase"
        '
        'Earn
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Earn.DefaultCellStyle = DataGridViewCellStyle6
        Me.Earn.HeaderText = "Earn"
        Me.Earn.Name = "Earn"
        '
        'Power
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Power.DefaultCellStyle = DataGridViewCellStyle7
        Me.Power.HeaderText = "Power"
        Me.Power.Name = "Power"
        '
        'originalFileName
        '
        Me.originalFileName.HeaderText = "File name"
        Me.originalFileName.Name = "originalFileName"
        Me.originalFileName.Visible = False
        '
        'DataGridViewButtonColumn1
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray
        Me.DataGridViewButtonColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewButtonColumn1.HeaderText = "Show"
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Text = "..."
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn1.Width = 50
        '
        'DataPageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1065, 273)
        Me.Controls.Add(Me.pageDataView)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "DataPageList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data page list"
        CType(Me.pageDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pageDataView As DataGridView
    Friend WithEvents MainContextMenuStrip As ContextMenuStrip
    Friend WithEvents ShowAllDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dateColumn As DataGridViewTextBoxColumn
    Friend WithEvents initialFund As DataGridViewTextBoxColumn
    Friend WithEvents EndFund As DataGridViewTextBoxColumn
    Friend WithEvents Increase As DataGridViewTextBoxColumn
    Friend WithEvents Earn As DataGridViewTextBoxColumn
    Friend WithEvents Power As DataGridViewTextBoxColumn
    Friend WithEvents originalFileName As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
End Class
