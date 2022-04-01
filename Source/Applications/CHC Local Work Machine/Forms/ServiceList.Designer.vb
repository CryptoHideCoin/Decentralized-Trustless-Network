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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.GeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowLogParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.setTopMostToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.serviceContextMenu.SuspendLayout()
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainStatus.SuspendLayout()
        Me.mainMenu.SuspendLayout()
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
        Me.pageDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.internalNameButton, Me.serviceColumn, Me.portNumberColumn, Me.StateColumn})
        Me.pageDataGrid.Location = New System.Drawing.Point(2, 27)
        Me.pageDataGrid.MultiSelect = False
        Me.pageDataGrid.Name = "pageDataGrid"
        Me.pageDataGrid.ReadOnly = True
        Me.pageDataGrid.RowHeadersVisible = False
        Me.pageDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.pageDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.pageDataGrid.Size = New System.Drawing.Size(766, 189)
        Me.pageDataGrid.TabIndex = 16
        '
        'internalNameButton
        '
        Me.internalNameButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.internalNameButton.DefaultCellStyle = DataGridViewCellStyle2
        Me.internalNameButton.HeaderText = "Internal Name"
        Me.internalNameButton.Name = "internalNameButton"
        Me.internalNameButton.ReadOnly = True
        Me.internalNameButton.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.internalNameButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'serviceColumn
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.serviceColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.serviceColumn.HeaderText = "Service"
        Me.serviceColumn.Name = "serviceColumn"
        Me.serviceColumn.ReadOnly = True
        Me.serviceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.serviceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.serviceColumn.Width = 150
        '
        'portNumberColumn
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.portNumberColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.portNumberColumn.HeaderText = "Port Number"
        Me.portNumberColumn.Name = "portNumberColumn"
        Me.portNumberColumn.ReadOnly = True
        Me.portNumberColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.portNumberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.portNumberColumn.Width = 120
        '
        'StateColumn
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StateColumn.DefaultCellStyle = DataGridViewCellStyle5
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
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(770, 24)
        Me.mainMenu.TabIndex = 18
        Me.mainMenu.Text = "MenuStrip1"
        '
        'GeneralToolStripMenuItem
        '
        Me.GeneralToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowLogParametersToolStripMenuItem, Me.ToolStripMenuItem1, Me.setTopMostToolStrip, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem1})
        Me.GeneralToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralToolStripMenuItem.Name = "GeneralToolStripMenuItem"
        Me.GeneralToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.GeneralToolStripMenuItem.Text = "&Tools"
        '
        'ShowLogParametersToolStripMenuItem
        '
        Me.ShowLogParametersToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowLogParametersToolStripMenuItem.Name = "ShowLogParametersToolStripMenuItem"
        Me.ShowLogParametersToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ShowLogParametersToolStripMenuItem.Text = "Show log parameters"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(206, 6)
        '
        'setTopMostToolStrip
        '
        Me.setTopMostToolStrip.Name = "setTopMostToolStrip"
        Me.setTopMostToolStrip.Size = New System.Drawing.Size(209, 22)
        Me.setTopMostToolStrip.Text = "Set top most"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(206, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(209, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem2.Text = "?"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.InfoToolStripMenuItem.Text = "&Info"
        '
        'ServiceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 241)
        Me.Controls.Add(Me.mainStatus)
        Me.Controls.Add(Me.mainMenu)
        Me.Controls.Add(Me.pageDataGrid)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mainMenu
        Me.MaximumSize = New System.Drawing.Size(786, 280)
        Me.Name = "ServiceList"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Local Work Machine - Agent - Crypto Hide Coin "
        Me.serviceContextMenu.ResumeLayout(False)
        CType(Me.pageDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainStatus.ResumeLayout(False)
        Me.mainStatus.PerformLayout()
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
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
    Friend WithEvents mainMenu As MenuStrip
    Friend WithEvents GeneralToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowLogParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents setTopMostToolStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As ToolStripMenuItem
End Class
