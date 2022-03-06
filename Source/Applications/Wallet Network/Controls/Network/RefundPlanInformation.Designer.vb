<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RefundPlanInformation
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.refundPlanDataGrid = New System.Windows.Forms.DataGridView()
        Me.Recipient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fixValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PercentageValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisplayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.code = New System.Windows.Forms.TextBox()
        Me.codeLabel = New System.Windows.Forms.Label()
        CType(Me.refundPlanDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'refundPlanDataGrid
        '
        Me.refundPlanDataGrid.AllowUserToAddRows = False
        Me.refundPlanDataGrid.AllowUserToDeleteRows = False
        Me.refundPlanDataGrid.AllowUserToResizeColumns = False
        Me.refundPlanDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.refundPlanDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Recipient, Me.Description, Me.fixValue, Me.PercentageValue, Me.DisplayValue})
        Me.refundPlanDataGrid.Location = New System.Drawing.Point(12, 48)
        Me.refundPlanDataGrid.MultiSelect = False
        Me.refundPlanDataGrid.Name = "refundPlanDataGrid"
        Me.refundPlanDataGrid.ReadOnly = True
        Me.refundPlanDataGrid.RowHeadersVisible = False
        Me.refundPlanDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.refundPlanDataGrid.Size = New System.Drawing.Size(538, 168)
        Me.refundPlanDataGrid.TabIndex = 2
        '
        'Recipient
        '
        Me.Recipient.HeaderText = "Recipient"
        Me.Recipient.Name = "Recipient"
        Me.Recipient.ReadOnly = True
        Me.Recipient.Visible = False
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 375
        '
        'fixValue
        '
        Me.fixValue.HeaderText = "Fix Value"
        Me.fixValue.Name = "fixValue"
        Me.fixValue.ReadOnly = True
        Me.fixValue.Visible = False
        '
        'PercentageValue
        '
        Me.PercentageValue.HeaderText = "Percentage Value"
        Me.PercentageValue.Name = "PercentageValue"
        Me.PercentageValue.ReadOnly = True
        Me.PercentageValue.Visible = False
        '
        'DisplayValue
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DisplayValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.DisplayValue.HeaderText = "Value"
        Me.DisplayValue.Name = "DisplayValue"
        Me.DisplayValue.ReadOnly = True
        Me.DisplayValue.Width = 135
        '
        'code
        '
        Me.code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.code.Location = New System.Drawing.Point(52, 12)
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        Me.code.Size = New System.Drawing.Size(498, 21)
        Me.code.TabIndex = 67
        Me.code.Text = "xxx"
        '
        'codeLabel
        '
        Me.codeLabel.AutoSize = True
        Me.codeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codeLabel.Location = New System.Drawing.Point(9, 15)
        Me.codeLabel.Name = "codeLabel"
        Me.codeLabel.Size = New System.Drawing.Size(37, 13)
        Me.codeLabel.TabIndex = 68
        Me.codeLabel.Text = "Code"
        '
        'RefundPlanInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.code)
        Me.Controls.Add(Me.codeLabel)
        Me.Controls.Add(Me.refundPlanDataGrid)
        Me.Name = "RefundPlanInformation"
        Me.Size = New System.Drawing.Size(563, 232)
        CType(Me.refundPlanDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents refundPlanDataGrid As DataGridView
    Friend WithEvents Recipient As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents fixValue As DataGridViewTextBoxColumn
    Friend WithEvents PercentageValue As DataGridViewTextBoxColumn
    Friend WithEvents DisplayValue As DataGridViewTextBoxColumn
    Friend WithEvents code As TextBox
    Friend WithEvents codeLabel As Label
End Class
