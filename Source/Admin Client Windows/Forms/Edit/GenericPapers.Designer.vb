<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenericPapersForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenericPapersForm))
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.ContentValue = New System.Windows.Forms.TextBox()
        Me.contentLabel = New System.Windows.Forms.Label()
        Me.identityValue = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.nameValue = New System.Windows.Forms.TextBox()
        Me.CoinNameLabel = New System.Windows.Forms.Label()
        Me.selectedTabPage = New System.Windows.Forms.TabPage()
        Me.containerSelected = New System.Windows.Forms.Panel()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createNewButton = New System.Windows.Forms.Button()
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.dataGridView = New System.Windows.Forms.DataGridView()
        Me.visionPaperTabPage = New System.Windows.Forms.TabPage()
        Me.mainTabControl = New System.Windows.Forms.TabControl()
        Me.selectedTabPage.SuspendLayout()
        Me.containerSelected.SuspendLayout()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.visionPaperTabPage.SuspendLayout()
        Me.mainTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Location = New System.Drawing.Point(24, 551)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 69
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'confirmButton
        '
        Me.confirmButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmButton.Location = New System.Drawing.Point(775, 551)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 23)
        Me.confirmButton.TabIndex = 70
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'ContentValue
        '
        Me.ContentValue.AcceptsTab = True
        Me.ContentValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContentValue.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContentValue.Location = New System.Drawing.Point(25, 143)
        Me.ContentValue.MaxLength = 50000
        Me.ContentValue.Multiline = True
        Me.ContentValue.Name = "ContentValue"
        Me.ContentValue.Size = New System.Drawing.Size(825, 391)
        Me.ContentValue.TabIndex = 65
        '
        'contentLabel
        '
        Me.contentLabel.AutoSize = True
        Me.contentLabel.Location = New System.Drawing.Point(24, 127)
        Me.contentLabel.Name = "contentLabel"
        Me.contentLabel.Size = New System.Drawing.Size(52, 13)
        Me.contentLabel.TabIndex = 72
        Me.contentLabel.Text = "Content"
        '
        'identityValue
        '
        Me.identityValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.identityValue.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.identityValue.Location = New System.Drawing.Point(25, 46)
        Me.identityValue.Name = "identityValue"
        Me.identityValue.ReadOnly = True
        Me.identityValue.Size = New System.Drawing.Size(825, 21)
        Me.identityValue.TabIndex = 75
        Me.identityValue.TabStop = False
        Me.identityValue.Text = "NO FILE"
        Me.identityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'identityLabel
        '
        Me.identityLabel.AutoSize = True
        Me.identityLabel.Location = New System.Drawing.Point(21, 31)
        Me.identityLabel.Name = "identityLabel"
        Me.identityLabel.Size = New System.Drawing.Size(51, 13)
        Me.identityLabel.TabIndex = 73
        Me.identityLabel.Text = "Identity"
        '
        'nameValue
        '
        Me.nameValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nameValue.Location = New System.Drawing.Point(25, 94)
        Me.nameValue.MaxLength = 150
        Me.nameValue.Name = "nameValue"
        Me.nameValue.Size = New System.Drawing.Size(825, 21)
        Me.nameValue.TabIndex = 61
        '
        'CoinNameLabel
        '
        Me.CoinNameLabel.AutoSize = True
        Me.CoinNameLabel.Location = New System.Drawing.Point(21, 78)
        Me.CoinNameLabel.Name = "CoinNameLabel"
        Me.CoinNameLabel.Size = New System.Drawing.Size(40, 13)
        Me.CoinNameLabel.TabIndex = 71
        Me.CoinNameLabel.Text = "Name"
        '
        'selectedTabPage
        '
        Me.selectedTabPage.Controls.Add(Me.containerSelected)
        Me.selectedTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedTabPage.Location = New System.Drawing.Point(4, 22)
        Me.selectedTabPage.Name = "selectedTabPage"
        Me.selectedTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.selectedTabPage.Size = New System.Drawing.Size(884, 614)
        Me.selectedTabPage.TabIndex = 1
        Me.selectedTabPage.Text = "Selected"
        Me.selectedTabPage.UseVisualStyleBackColor = True
        '
        'containerSelected
        '
        Me.containerSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.containerSelected.Controls.Add(Me.cancelButton)
        Me.containerSelected.Controls.Add(Me.confirmButton)
        Me.containerSelected.Controls.Add(Me.ContentValue)
        Me.containerSelected.Controls.Add(Me.contentLabel)
        Me.containerSelected.Controls.Add(Me.identityValue)
        Me.containerSelected.Controls.Add(Me.identityLabel)
        Me.containerSelected.Controls.Add(Me.nameValue)
        Me.containerSelected.Controls.Add(Me.CoinNameLabel)
        Me.containerSelected.Location = New System.Drawing.Point(6, 3)
        Me.containerSelected.Name = "containerSelected"
        Me.containerSelected.Size = New System.Drawing.Size(872, 605)
        Me.containerSelected.TabIndex = 61
        '
        'idColumn
        '
        Me.idColumn.HeaderText = "ID"
        Me.idColumn.Name = "idColumn"
        Me.idColumn.ReadOnly = True
        Me.idColumn.Width = 500
        '
        'nameColumn
        '
        Me.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nameColumn.HeaderText = "Name"
        Me.nameColumn.Name = "nameColumn"
        Me.nameColumn.ReadOnly = True
        '
        'RowIndex
        '
        Me.RowIndex.HeaderText = "Row Index"
        Me.RowIndex.Name = "RowIndex"
        Me.RowIndex.ReadOnly = True
        Me.RowIndex.Visible = False
        '
        'createNewButton
        '
        Me.createNewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.createNewButton.Location = New System.Drawing.Point(769, 6)
        Me.createNewButton.Name = "createNewButton"
        Me.createNewButton.Size = New System.Drawing.Size(109, 23)
        Me.createNewButton.TabIndex = 1
        Me.createNewButton.Text = "Add New"
        Me.createNewButton.UseVisualStyleBackColor = True
        '
        'refreshButton
        '
        Me.refreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshButton.Location = New System.Drawing.Point(654, 6)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(109, 23)
        Me.refreshButton.TabIndex = 0
        Me.refreshButton.Text = "Refresh"
        Me.refreshButton.UseVisualStyleBackColor = True
        '
        'dataGridView
        '
        Me.dataGridView.AllowUserToAddRows = False
        Me.dataGridView.AllowUserToDeleteRows = False
        Me.dataGridView.AllowUserToResizeColumns = False
        Me.dataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowIndex, Me.nameColumn, Me.idColumn})
        Me.dataGridView.Location = New System.Drawing.Point(6, 35)
        Me.dataGridView.MultiSelect = False
        Me.dataGridView.Name = "dataGridView"
        Me.dataGridView.ReadOnly = True
        Me.dataGridView.RowHeadersVisible = False
        Me.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView.Size = New System.Drawing.Size(872, 579)
        Me.dataGridView.TabIndex = 26
        '
        'visionPaperTabPage
        '
        Me.visionPaperTabPage.Controls.Add(Me.createNewButton)
        Me.visionPaperTabPage.Controls.Add(Me.refreshButton)
        Me.visionPaperTabPage.Controls.Add(Me.dataGridView)
        Me.visionPaperTabPage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.visionPaperTabPage.Location = New System.Drawing.Point(4, 22)
        Me.visionPaperTabPage.Name = "visionPaperTabPage"
        Me.visionPaperTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.visionPaperTabPage.Size = New System.Drawing.Size(884, 614)
        Me.visionPaperTabPage.TabIndex = 0
        Me.visionPaperTabPage.Text = "Complete list"
        Me.visionPaperTabPage.UseVisualStyleBackColor = True
        '
        'mainTabControl
        '
        Me.mainTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTabControl.Controls.Add(Me.visionPaperTabPage)
        Me.mainTabControl.Controls.Add(Me.selectedTabPage)
        Me.mainTabControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTabControl.Location = New System.Drawing.Point(10, 11)
        Me.mainTabControl.Name = "mainTabControl"
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(892, 640)
        Me.mainTabControl.TabIndex = 1
        '
        'GenericPapersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 661)
        Me.Controls.Add(Me.mainTabControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1244, 700)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(622, 359)
        Me.Name = "GenericPapersForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manager %Title%Papers"
        Me.selectedTabPage.ResumeLayout(False)
        Me.containerSelected.ResumeLayout(False)
        Me.containerSelected.PerformLayout()
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.visionPaperTabPage.ResumeLayout(False)
        Me.mainTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents ContentValue As TextBox
    Friend WithEvents contentLabel As Label
    Friend WithEvents identityValue As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents nameValue As TextBox
    Friend WithEvents CoinNameLabel As Label
    Friend WithEvents selectedTabPage As TabPage
    Friend WithEvents containerSelected As Panel
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents RowIndex As DataGridViewTextBoxColumn
    Friend WithEvents createNewButton As Button
    Friend WithEvents refreshButton As Button
    Friend WithEvents dataGridView As DataGridView
    Friend WithEvents visionPaperTabPage As TabPage
    Friend WithEvents mainTabControl As TabControl
End Class
