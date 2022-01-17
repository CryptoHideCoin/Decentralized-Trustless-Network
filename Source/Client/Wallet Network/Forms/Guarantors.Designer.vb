<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Guarantors
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.identityPublicAddress = New System.Windows.Forms.TextBox()
        Me.identityPublicAddressLabel = New System.Windows.Forms.Label()
        Me.guarantorsDataGrid = New System.Windows.Forms.DataGridView()
        Me.publicAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.power = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalPower = New CHCSupportUIControls.NumericText()
        Me.totalPowerLabel = New System.Windows.Forms.Label()
        Me.symbolLabel = New System.Windows.Forms.Label()
        CType(Me.guarantorsDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'identityPublicAddress
        '
        Me.identityPublicAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.identityPublicAddress.Location = New System.Drawing.Point(12, 25)
        Me.identityPublicAddress.Multiline = True
        Me.identityPublicAddress.Name = "identityPublicAddress"
        Me.identityPublicAddress.ReadOnly = True
        Me.identityPublicAddress.Size = New System.Drawing.Size(734, 35)
        Me.identityPublicAddress.TabIndex = 48
        Me.identityPublicAddress.Text = "xxxx"
        '
        'identityPublicAddressLabel
        '
        Me.identityPublicAddressLabel.AutoSize = True
        Me.identityPublicAddressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.identityPublicAddressLabel.Location = New System.Drawing.Point(9, 9)
        Me.identityPublicAddressLabel.Name = "identityPublicAddressLabel"
        Me.identityPublicAddressLabel.Size = New System.Drawing.Size(138, 13)
        Me.identityPublicAddressLabel.TabIndex = 49
        Me.identityPublicAddressLabel.Text = "Identity Public Address"
        '
        'guarantorsDataGrid
        '
        Me.guarantorsDataGrid.AllowUserToAddRows = False
        Me.guarantorsDataGrid.AllowUserToDeleteRows = False
        Me.guarantorsDataGrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.guarantorsDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.guarantorsDataGrid.ColumnHeadersHeight = 24
        Me.guarantorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.guarantorsDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.publicAddress, Me.power})
        Me.guarantorsDataGrid.Location = New System.Drawing.Point(12, 66)
        Me.guarantorsDataGrid.MultiSelect = False
        Me.guarantorsDataGrid.Name = "guarantorsDataGrid"
        Me.guarantorsDataGrid.ReadOnly = True
        Me.guarantorsDataGrid.RowHeadersVisible = False
        Me.guarantorsDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.guarantorsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.guarantorsDataGrid.Size = New System.Drawing.Size(734, 232)
        Me.guarantorsDataGrid.TabIndex = 64
        '
        'publicAddress
        '
        Me.publicAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.publicAddress.HeaderText = "Public Address"
        Me.publicAddress.Name = "publicAddress"
        Me.publicAddress.ReadOnly = True
        Me.publicAddress.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'power
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.power.DefaultCellStyle = DataGridViewCellStyle2
        Me.power.HeaderText = "Power"
        Me.power.Name = "power"
        Me.power.ReadOnly = True
        Me.power.Width = 150
        '
        'totalPower
        '
        Me.totalPower.currentFormat = "#,##0.00"
        Me.totalPower.Location = New System.Drawing.Point(12, 317)
        Me.totalPower.locationCode = "it-IT"
        Me.totalPower.Name = "totalPower"
        Me.totalPower.ReadOnly = True
        Me.totalPower.Size = New System.Drawing.Size(173, 21)
        Me.totalPower.TabIndex = 65
        Me.totalPower.Text = "0"
        Me.totalPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.totalPower.useDecimal = False
        '
        'totalPowerLabel
        '
        Me.totalPowerLabel.AutoSize = True
        Me.totalPowerLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPowerLabel.Location = New System.Drawing.Point(12, 301)
        Me.totalPowerLabel.Name = "totalPowerLabel"
        Me.totalPowerLabel.Size = New System.Drawing.Size(73, 13)
        Me.totalPowerLabel.TabIndex = 66
        Me.totalPowerLabel.Text = "Total power"
        '
        'symbolLabel
        '
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Location = New System.Drawing.Point(192, 322)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(21, 13)
        Me.symbolLabel.TabIndex = 68
        Me.symbolLabel.Text = "$$"
        '
        'Guarantors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(762, 352)
        Me.Controls.Add(Me.symbolLabel)
        Me.Controls.Add(Me.totalPowerLabel)
        Me.Controls.Add(Me.totalPower)
        Me.Controls.Add(Me.guarantorsDataGrid)
        Me.Controls.Add(Me.identityPublicAddress)
        Me.Controls.Add(Me.identityPublicAddressLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(778, 391)
        Me.MinimumSize = New System.Drawing.Size(778, 391)
        Me.Name = "Guarantors"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Masternode Guarantors"
        CType(Me.guarantorsDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents identityPublicAddress As TextBox
    Friend WithEvents identityPublicAddressLabel As Label
    Friend WithEvents guarantorsDataGrid As DataGridView
    Friend WithEvents publicAddress As DataGridViewTextBoxColumn
    Friend WithEvents power As DataGridViewTextBoxColumn
    Friend WithEvents totalPower As CHCSupportUIControls.NumericText
    Friend WithEvents totalPowerLabel As Label
    Friend WithEvents symbolLabel As Label
End Class
