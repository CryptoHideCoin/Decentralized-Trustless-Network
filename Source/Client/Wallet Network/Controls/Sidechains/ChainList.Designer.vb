<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChainList
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.groupPages = New System.Windows.Forms.GroupBox()
        Me.countLabel = New System.Windows.Forms.Label()
        Me.pageNumber = New System.Windows.Forms.TextBox()
        Me.pagePreviousButton = New System.Windows.Forms.Button()
        Me.pageNextButton = New System.Windows.Forms.Button()
        Me.chainDataGrid = New System.Windows.Forms.DataGridView()
        Me.chainName = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupPages.SuspendLayout()
        CType(Me.chainDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupPages
        '
        Me.groupPages.Controls.Add(Me.countLabel)
        Me.groupPages.Controls.Add(Me.pageNumber)
        Me.groupPages.Controls.Add(Me.pagePreviousButton)
        Me.groupPages.Controls.Add(Me.pageNextButton)
        Me.groupPages.Location = New System.Drawing.Point(9, 7)
        Me.groupPages.Name = "groupPages"
        Me.groupPages.Size = New System.Drawing.Size(148, 71)
        Me.groupPages.TabIndex = 10
        Me.groupPages.TabStop = False
        Me.groupPages.Text = "Pages"
        '
        'countLabel
        '
        Me.countLabel.AutoSize = True
        Me.countLabel.Location = New System.Drawing.Point(41, 20)
        Me.countLabel.Name = "countLabel"
        Me.countLabel.Size = New System.Drawing.Size(64, 13)
        Me.countLabel.TabIndex = 11
        Me.countLabel.Text = "Count: 00"
        '
        'pageNumber
        '
        Me.pageNumber.Location = New System.Drawing.Point(40, 42)
        Me.pageNumber.Name = "pageNumber"
        Me.pageNumber.Size = New System.Drawing.Size(70, 21)
        Me.pageNumber.TabIndex = 10
        Me.pageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pagePreviousButton
        '
        Me.pagePreviousButton.Location = New System.Drawing.Point(12, 20)
        Me.pagePreviousButton.Name = "pagePreviousButton"
        Me.pagePreviousButton.Size = New System.Drawing.Size(22, 43)
        Me.pagePreviousButton.TabIndex = 9
        Me.pagePreviousButton.Text = "<"
        Me.pagePreviousButton.UseVisualStyleBackColor = True
        '
        'pageNextButton
        '
        Me.pageNextButton.Location = New System.Drawing.Point(116, 20)
        Me.pageNextButton.Name = "pageNextButton"
        Me.pageNextButton.Size = New System.Drawing.Size(22, 43)
        Me.pageNextButton.TabIndex = 8
        Me.pageNextButton.Text = ">"
        Me.pageNextButton.UseVisualStyleBackColor = True
        '
        'chainDataGrid
        '
        Me.chainDataGrid.AllowUserToAddRows = False
        Me.chainDataGrid.AllowUserToDeleteRows = False
        Me.chainDataGrid.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chainDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.chainDataGrid.ColumnHeadersHeight = 42
        Me.chainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.chainDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chainName, Me.Description})
        Me.chainDataGrid.Location = New System.Drawing.Point(7, 84)
        Me.chainDataGrid.MultiSelect = False
        Me.chainDataGrid.Name = "chainDataGrid"
        Me.chainDataGrid.ReadOnly = True
        Me.chainDataGrid.RowHeadersVisible = False
        Me.chainDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.chainDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.chainDataGrid.Size = New System.Drawing.Size(744, 339)
        Me.chainDataGrid.TabIndex = 9
        '
        'chainName
        '
        Me.chainName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.chainName.HeaderText = "Name"
        Me.chainName.Name = "chainName"
        Me.chainName.ReadOnly = True
        Me.chainName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chainName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Description
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Description.DefaultCellStyle = DataGridViewCellStyle2
        Me.Description.HeaderText = "Private"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'ChainList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.groupPages)
        Me.Controls.Add(Me.chainDataGrid)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ChainList"
        Me.Size = New System.Drawing.Size(759, 427)
        Me.groupPages.ResumeLayout(False)
        Me.groupPages.PerformLayout()
        CType(Me.chainDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupPages As GroupBox
    Friend WithEvents countLabel As Label
    Friend WithEvents pageNumber As TextBox
    Friend WithEvents pagePreviousButton As Button
    Friend WithEvents pageNextButton As Button
    Friend WithEvents chainDataGrid As DataGridView
    Friend WithEvents chainName As DataGridViewLinkColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
End Class
