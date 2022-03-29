<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiceList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceList))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.mainNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.serviceContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pageDataGrid = New System.Windows.Forms.DataGridView()
        Me.internalNameButton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serviceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.portNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mainStatus = New System.Windows.Forms.StatusStrip()
        Me.descriptionOperationLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.serviceContextMenu.SuspendLayout()
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainNotifyIcon
        '
        Me.mainNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.mainNotifyIcon.ContextMenuStrip = Me.serviceContextMenu
        Me.mainNotifyIcon.Icon = CType(resources.GetObject("mainNotifyIcon.Icon"), System.Drawing.Icon)
        Me.mainNotifyIcon.Text = "Local Work Machine"
        Me.mainNotifyIcon.Visible = True
        '
        'serviceContextMenu
        '
        Me.serviceContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.serviceContextMenu.Name = "serviceContextMenu"
        Me.serviceContextMenu.Size = New System.Drawing.Size(104, 48)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'pageDataGrid
        '
        Me.pageDataGrid.AllowUserToAddRows = False
        Me.pageDataGrid.AllowUserToDeleteRows = False
        Me.pageDataGrid.AllowUserToResizeColumns = False
        Me.pageDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pageDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.pageDataGrid.ColumnHeadersHeight = 42
        Me.pageDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.pageDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.internalNameButton, Me.serviceColumn, Me.portNumberColumn, Me.StateColumn})
        Me.pageDataGrid.Location = New System.Drawing.Point(2, 3)
        Me.pageDataGrid.MultiSelect = False
        Me.pageDataGrid.Name = "pageDataGrid"
        Me.pageDataGrid.ReadOnly = True
        Me.pageDataGrid.RowHeadersVisible = False
        Me.pageDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.pageDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.pageDataGrid.Size = New System.Drawing.Size(766, 213)
        Me.pageDataGrid.TabIndex = 16
        '
        'internalNameButton
        '
        Me.internalNameButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.internalNameButton.DefaultCellStyle = DataGridViewCellStyle12
        Me.internalNameButton.HeaderText = "Internal Name"
        Me.internalNameButton.Name = "internalNameButton"
        Me.internalNameButton.ReadOnly = True
        Me.internalNameButton.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.internalNameButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'serviceColumn
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.serviceColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.serviceColumn.HeaderText = "Service"
        Me.serviceColumn.Name = "serviceColumn"
        Me.serviceColumn.ReadOnly = True
        Me.serviceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.serviceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.serviceColumn.Width = 150
        '
        'portNumberColumn
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.portNumberColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.portNumberColumn.HeaderText = "Port Number"
        Me.portNumberColumn.Name = "portNumberColumn"
        Me.portNumberColumn.ReadOnly = True
        Me.portNumberColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.portNumberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.portNumberColumn.Width = 120
        '
        'StateColumn
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StateColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.StateColumn.HeaderText = "State"
        Me.StateColumn.Name = "StateColumn"
        Me.StateColumn.ReadOnly = True
        '
        'mainStatus
        '
        Me.mainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.descriptionOperationLabel})
        Me.mainStatus.Location = New System.Drawing.Point(0, 219)
        Me.mainStatus.Name = "mainStatus"
        Me.mainStatus.Size = New System.Drawing.Size(770, 22)
        Me.mainStatus.TabIndex = 17
        Me.mainStatus.Text = "StatusStrip1"
        '
        'descriptionOperationLabel
        '
        Me.descriptionOperationLabel.Name = "descriptionOperationLabel"
        Me.descriptionOperationLabel.Size = New System.Drawing.Size(0, 17)
        Me.descriptionOperationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mainTimer
        '
        Me.mainTimer.Interval = 1000
        '
        'ServiceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 241)
        Me.Controls.Add(Me.mainStatus)
        Me.Controls.Add(Me.pageDataGrid)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(786, 280)
        Me.Name = "ServiceList"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Local Work Machine"
        Me.serviceContextMenu.ResumeLayout(False)
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainStatus.ResumeLayout(False)
        Me.mainStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mainNotifyIcon As NotifyIcon
    Friend WithEvents pageDataGrid As DataGridView
    Friend WithEvents serviceContextMenu As ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mainStatus As StatusStrip
    Friend WithEvents descriptionOperationLabel As ToolStripStatusLabel
    Friend WithEvents mainTimer As Timer
    Friend WithEvents internalNameButton As DataGridViewTextBoxColumn
    Friend WithEvents serviceColumn As DataGridViewTextBoxColumn
    Friend WithEvents portNumberColumn As DataGridViewTextBoxColumn
    Friend WithEvents StateColumn As DataGridViewTextBoxColumn
End Class
