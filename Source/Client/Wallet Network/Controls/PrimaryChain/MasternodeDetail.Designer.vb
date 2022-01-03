<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasternodeDetail
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.identityPublicAddress = New System.Windows.Forms.TextBox()
        Me.identityPublicAddressLabel = New System.Windows.Forms.Label()
        Me.startConnectionTimeStamp = New System.Windows.Forms.TextBox()
        Me.startConnectionTimeStampLabel = New System.Windows.Forms.Label()
        Me.autoStartDisconnectTimeStamp = New System.Windows.Forms.TextBox()
        Me.autoDisconnectTimeStamp = New System.Windows.Forms.Label()
        Me.role = New System.Windows.Forms.TextBox()
        Me.roleLabel = New System.Windows.Forms.Label()
        Me.refundPublicAddress = New System.Windows.Forms.TextBox()
        Me.refundPublicAddressLabel = New System.Windows.Forms.Label()
        Me.connectTo = New System.Windows.Forms.Button()
        Me.totalPowerLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.symbolLabel = New System.Windows.Forms.Label()
        Me.guarantorsButton = New System.Windows.Forms.Button()
        Me.addressIPDataGrid = New System.Windows.Forms.DataGridView()
        Me.publicAddressIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.main = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.power = New CHCSupportUIControls.NumericText()
        CType(Me.addressIPDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'identityPublicAddress
        '
        Me.identityPublicAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.identityPublicAddress.Location = New System.Drawing.Point(22, 31)
        Me.identityPublicAddress.Multiline = True
        Me.identityPublicAddress.Name = "identityPublicAddress"
        Me.identityPublicAddress.ReadOnly = True
        Me.identityPublicAddress.Size = New System.Drawing.Size(734, 35)
        Me.identityPublicAddress.TabIndex = 46
        Me.identityPublicAddress.Text = "xxxx"
        '
        'identityPublicAddressLabel
        '
        Me.identityPublicAddressLabel.AutoSize = True
        Me.identityPublicAddressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.identityPublicAddressLabel.Location = New System.Drawing.Point(19, 15)
        Me.identityPublicAddressLabel.Name = "identityPublicAddressLabel"
        Me.identityPublicAddressLabel.Size = New System.Drawing.Size(138, 13)
        Me.identityPublicAddressLabel.TabIndex = 47
        Me.identityPublicAddressLabel.Text = "Identity Public Address"
        '
        'startConnectionTimeStamp
        '
        Me.startConnectionTimeStamp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startConnectionTimeStamp.Location = New System.Drawing.Point(22, 91)
        Me.startConnectionTimeStamp.Name = "startConnectionTimeStamp"
        Me.startConnectionTimeStamp.ReadOnly = True
        Me.startConnectionTimeStamp.Size = New System.Drawing.Size(171, 21)
        Me.startConnectionTimeStamp.TabIndex = 48
        Me.startConnectionTimeStamp.Text = "xxxx"
        '
        'startConnectionTimeStampLabel
        '
        Me.startConnectionTimeStampLabel.AutoSize = True
        Me.startConnectionTimeStampLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startConnectionTimeStampLabel.Location = New System.Drawing.Point(19, 75)
        Me.startConnectionTimeStampLabel.Name = "startConnectionTimeStampLabel"
        Me.startConnectionTimeStampLabel.Size = New System.Drawing.Size(164, 13)
        Me.startConnectionTimeStampLabel.TabIndex = 49
        Me.startConnectionTimeStampLabel.Text = "Start connection timestamp"
        '
        'autoStartDisconnectTimeStamp
        '
        Me.autoStartDisconnectTimeStamp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoStartDisconnectTimeStamp.Location = New System.Drawing.Point(244, 91)
        Me.autoStartDisconnectTimeStamp.Name = "autoStartDisconnectTimeStamp"
        Me.autoStartDisconnectTimeStamp.ReadOnly = True
        Me.autoStartDisconnectTimeStamp.Size = New System.Drawing.Size(199, 21)
        Me.autoStartDisconnectTimeStamp.TabIndex = 50
        Me.autoStartDisconnectTimeStamp.Text = "xxxx"
        '
        'autoDisconnectTimeStamp
        '
        Me.autoDisconnectTimeStamp.AutoSize = True
        Me.autoDisconnectTimeStamp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoDisconnectTimeStamp.Location = New System.Drawing.Point(241, 75)
        Me.autoDisconnectTimeStamp.Name = "autoDisconnectTimeStamp"
        Me.autoDisconnectTimeStamp.Size = New System.Drawing.Size(187, 13)
        Me.autoDisconnectTimeStamp.TabIndex = 51
        Me.autoDisconnectTimeStamp.Text = "Autostart disconnect timestamp"
        '
        'role
        '
        Me.role.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.role.Location = New System.Drawing.Point(498, 91)
        Me.role.Name = "role"
        Me.role.ReadOnly = True
        Me.role.Size = New System.Drawing.Size(258, 21)
        Me.role.TabIndex = 52
        Me.role.Text = "xxxx"
        '
        'roleLabel
        '
        Me.roleLabel.AutoSize = True
        Me.roleLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.roleLabel.Location = New System.Drawing.Point(495, 75)
        Me.roleLabel.Name = "roleLabel"
        Me.roleLabel.Size = New System.Drawing.Size(32, 13)
        Me.roleLabel.TabIndex = 53
        Me.roleLabel.Text = "Role"
        '
        'refundPublicAddress
        '
        Me.refundPublicAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refundPublicAddress.Location = New System.Drawing.Point(22, 139)
        Me.refundPublicAddress.Multiline = True
        Me.refundPublicAddress.Name = "refundPublicAddress"
        Me.refundPublicAddress.ReadOnly = True
        Me.refundPublicAddress.Size = New System.Drawing.Size(734, 35)
        Me.refundPublicAddress.TabIndex = 54
        Me.refundPublicAddress.Text = "xxxx"
        '
        'refundPublicAddressLabel
        '
        Me.refundPublicAddressLabel.AutoSize = True
        Me.refundPublicAddressLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refundPublicAddressLabel.Location = New System.Drawing.Point(19, 123)
        Me.refundPublicAddressLabel.Name = "refundPublicAddressLabel"
        Me.refundPublicAddressLabel.Size = New System.Drawing.Size(134, 13)
        Me.refundPublicAddressLabel.TabIndex = 55
        Me.refundPublicAddressLabel.Text = "Refund Public Address"
        '
        'connectTo
        '
        Me.connectTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.connectTo.Location = New System.Drawing.Point(580, 287)
        Me.connectTo.Name = "connectTo"
        Me.connectTo.Size = New System.Drawing.Size(106, 37)
        Me.connectTo.TabIndex = 56
        Me.connectTo.Text = "Connect to Masternode"
        Me.connectTo.UseVisualStyleBackColor = True
        '
        'totalPowerLabel
        '
        Me.totalPowerLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalPowerLabel.AutoSize = True
        Me.totalPowerLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPowerLabel.Location = New System.Drawing.Point(577, 196)
        Me.totalPowerLabel.Name = "totalPowerLabel"
        Me.totalPowerLabel.Size = New System.Drawing.Size(73, 13)
        Me.totalPowerLabel.TabIndex = 58
        Me.totalPowerLabel.Text = "Total power"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "mSec."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(449, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "mSec."
        '
        'symbolLabel
        '
        Me.symbolLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Location = New System.Drawing.Point(730, 218)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(21, 13)
        Me.symbolLabel.TabIndex = 61
        Me.symbolLabel.Text = "$$"
        '
        'guarantorsButton
        '
        Me.guarantorsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guarantorsButton.Location = New System.Drawing.Point(580, 244)
        Me.guarantorsButton.Name = "guarantorsButton"
        Me.guarantorsButton.Size = New System.Drawing.Size(106, 37)
        Me.guarantorsButton.TabIndex = 62
        Me.guarantorsButton.Text = "Guarantors"
        Me.guarantorsButton.UseVisualStyleBackColor = True
        '
        'addressIPDataGrid
        '
        Me.addressIPDataGrid.AllowUserToAddRows = False
        Me.addressIPDataGrid.AllowUserToDeleteRows = False
        Me.addressIPDataGrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.addressIPDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.addressIPDataGrid.ColumnHeadersHeight = 24
        Me.addressIPDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.addressIPDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.publicAddressIP, Me.main})
        Me.addressIPDataGrid.Location = New System.Drawing.Point(22, 196)
        Me.addressIPDataGrid.MultiSelect = False
        Me.addressIPDataGrid.Name = "addressIPDataGrid"
        Me.addressIPDataGrid.ReadOnly = True
        Me.addressIPDataGrid.RowHeadersVisible = False
        Me.addressIPDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.addressIPDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.addressIPDataGrid.Size = New System.Drawing.Size(537, 127)
        Me.addressIPDataGrid.TabIndex = 63
        '
        'publicAddressIP
        '
        Me.publicAddressIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.publicAddressIP.HeaderText = "Public Address IP"
        Me.publicAddressIP.Name = "publicAddressIP"
        Me.publicAddressIP.ReadOnly = True
        Me.publicAddressIP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'main
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.main.DefaultCellStyle = DataGridViewCellStyle4
        Me.main.HeaderText = "Main"
        Me.main.Name = "main"
        Me.main.ReadOnly = True
        '
        'power
        '
        Me.power.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.power.currentFormat = ""
        Me.power.Location = New System.Drawing.Point(580, 215)
        Me.power.locationCode = "it-IT"
        Me.power.Name = "power"
        Me.power.ReadOnly = True
        Me.power.Size = New System.Drawing.Size(146, 21)
        Me.power.TabIndex = 66
        Me.power.Text = "0"
        Me.power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.power.useDecimal = False
        '
        'MasternodeDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.power)
        Me.Controls.Add(Me.addressIPDataGrid)
        Me.Controls.Add(Me.guarantorsButton)
        Me.Controls.Add(Me.symbolLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.totalPowerLabel)
        Me.Controls.Add(Me.connectTo)
        Me.Controls.Add(Me.refundPublicAddress)
        Me.Controls.Add(Me.refundPublicAddressLabel)
        Me.Controls.Add(Me.role)
        Me.Controls.Add(Me.roleLabel)
        Me.Controls.Add(Me.autoStartDisconnectTimeStamp)
        Me.Controls.Add(Me.autoDisconnectTimeStamp)
        Me.Controls.Add(Me.startConnectionTimeStamp)
        Me.Controls.Add(Me.startConnectionTimeStampLabel)
        Me.Controls.Add(Me.identityPublicAddress)
        Me.Controls.Add(Me.identityPublicAddressLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "MasternodeDetail"
        Me.Size = New System.Drawing.Size(759, 351)
        CType(Me.addressIPDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents identityPublicAddress As TextBox
    Friend WithEvents identityPublicAddressLabel As Label
    Friend WithEvents startConnectionTimeStamp As TextBox
    Friend WithEvents startConnectionTimeStampLabel As Label
    Friend WithEvents autoStartDisconnectTimeStamp As TextBox
    Friend WithEvents autoDisconnectTimeStamp As Label
    Friend WithEvents role As TextBox
    Friend WithEvents roleLabel As Label
    Friend WithEvents refundPublicAddress As TextBox
    Friend WithEvents refundPublicAddressLabel As Label
    Friend WithEvents connectTo As Button
    Friend WithEvents totalPowerLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents symbolLabel As Label
    Friend WithEvents guarantorsButton As Button
    Friend WithEvents addressIPDataGrid As DataGridView
    Friend WithEvents publicAddressIP As DataGridViewTextBoxColumn
    Friend WithEvents main As DataGridViewTextBoxColumn
    Friend WithEvents power As CHCSupportUIControls.NumericText
End Class
