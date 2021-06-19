<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WalletAddressList
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
        Me.listLabel = New System.Windows.Forms.Label()
        Me.walletAddressDataGrid = New System.Windows.Forms.DataGridView()
        Me.RowIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.addNewButton = New System.Windows.Forms.Button()
        Me.noDataLabel = New System.Windows.Forms.Label()
        Me.configureButton = New System.Windows.Forms.Button()
        CType(Me.walletAddressDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listLabel
        '
        Me.listLabel.AutoSize = True
        Me.listLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listLabel.Location = New System.Drawing.Point(13, 10)
        Me.listLabel.Name = "listLabel"
        Me.listLabel.Size = New System.Drawing.Size(141, 13)
        Me.listLabel.TabIndex = 0
        Me.listLabel.Text = "Select a Wallet Address"
        '
        'walletAddressDataGrid
        '
        Me.walletAddressDataGrid.AllowUserToAddRows = False
        Me.walletAddressDataGrid.AllowUserToDeleteRows = False
        Me.walletAddressDataGrid.AllowUserToResizeColumns = False
        Me.walletAddressDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.walletAddressDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowIndex, Me.nameColumn, Me.idColumn})
        Me.walletAddressDataGrid.Location = New System.Drawing.Point(16, 26)
        Me.walletAddressDataGrid.MultiSelect = False
        Me.walletAddressDataGrid.Name = "walletAddressDataGrid"
        Me.walletAddressDataGrid.ReadOnly = True
        Me.walletAddressDataGrid.RowHeadersVisible = False
        Me.walletAddressDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.walletAddressDataGrid.Size = New System.Drawing.Size(674, 238)
        Me.walletAddressDataGrid.TabIndex = 27
        '
        'RowIndex
        '
        Me.RowIndex.HeaderText = "Row Index"
        Me.RowIndex.Name = "RowIndex"
        Me.RowIndex.ReadOnly = True
        Me.RowIndex.Visible = False
        '
        'nameColumn
        '
        Me.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.nameColumn.FillWeight = 50.0!
        Me.nameColumn.HeaderText = "Name"
        Me.nameColumn.Name = "nameColumn"
        Me.nameColumn.ReadOnly = True
        '
        'idColumn
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.idColumn.FillWeight = 300.0!
        Me.idColumn.HeaderText = "ID"
        Me.idColumn.Name = "idColumn"
        Me.idColumn.ReadOnly = True
        Me.idColumn.Width = 300
        '
        'addNewButton
        '
        Me.addNewButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.addNewButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addNewButton.Location = New System.Drawing.Point(582, 270)
        Me.addNewButton.Name = "addNewButton"
        Me.addNewButton.Size = New System.Drawing.Size(108, 23)
        Me.addNewButton.TabIndex = 28
        Me.addNewButton.Text = "Create New"
        Me.addNewButton.UseVisualStyleBackColor = True
        '
        'noDataLabel
        '
        Me.noDataLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.noDataLabel.AutoSize = True
        Me.noDataLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.noDataLabel.Location = New System.Drawing.Point(286, 59)
        Me.noDataLabel.Name = "noDataLabel"
        Me.noDataLabel.Size = New System.Drawing.Size(60, 13)
        Me.noDataLabel.TabIndex = 29
        Me.noDataLabel.Text = "(no data)"
        '
        'configureButton
        '
        Me.configureButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.configureButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.configureButton.Location = New System.Drawing.Point(16, 270)
        Me.configureButton.Name = "configureButton"
        Me.configureButton.Size = New System.Drawing.Size(108, 23)
        Me.configureButton.TabIndex = 30
        Me.configureButton.Text = "Configure"
        Me.configureButton.UseVisualStyleBackColor = True
        '
        'WalletAddressList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.configureButton)
        Me.Controls.Add(Me.noDataLabel)
        Me.Controls.Add(Me.addNewButton)
        Me.Controls.Add(Me.walletAddressDataGrid)
        Me.Controls.Add(Me.listLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "WalletAddressList"
        Me.Size = New System.Drawing.Size(707, 303)
        CType(Me.walletAddressDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents listLabel As Label
    Friend WithEvents walletAddressDataGrid As DataGridView
    Friend WithEvents addNewButton As Button
    Friend WithEvents noDataLabel As Label
    Friend WithEvents RowIndex As DataGridViewTextBoxColumn
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
    Friend WithEvents configureButton As Button
End Class
