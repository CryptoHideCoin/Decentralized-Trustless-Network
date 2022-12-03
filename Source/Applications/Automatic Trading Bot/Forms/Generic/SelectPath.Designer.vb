<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectPath
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectPath))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dataPathValue = New System.Windows.Forms.TextBox()
        Me.browsePath = New System.Windows.Forms.Button()
        Me.tenantName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.folderBrowseMain = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Root data path"
        '
        'dataPathValue
        '
        Me.dataPathValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataPathValue.Location = New System.Drawing.Point(16, 30)
        Me.dataPathValue.Name = "dataPathValue"
        Me.dataPathValue.Size = New System.Drawing.Size(451, 21)
        Me.dataPathValue.TabIndex = 1
        '
        'browsePath
        '
        Me.browsePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browsePath.Location = New System.Drawing.Point(473, 29)
        Me.browsePath.Name = "browsePath"
        Me.browsePath.Size = New System.Drawing.Size(33, 23)
        Me.browsePath.TabIndex = 2
        Me.browsePath.Text = "..."
        Me.browsePath.UseVisualStyleBackColor = True
        '
        'tenantName
        '
        Me.tenantName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tenantName.Location = New System.Drawing.Point(16, 87)
        Me.tenantName.Name = "tenantName"
        Me.tenantName.Size = New System.Drawing.Size(490, 21)
        Me.tenantName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tenant name"
        '
        'confirmButton
        '
        Me.confirmButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmButton.Enabled = False
        Me.confirmButton.Location = New System.Drawing.Point(431, 124)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 23)
        Me.confirmButton.TabIndex = 5
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'SelectPath
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 158)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.tenantName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.browsePath)
        Me.Controls.Add(Me.dataPathValue)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(533, 197)
        Me.Name = "SelectPath"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Data Path"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dataPathValue As TextBox
    Friend WithEvents browsePath As Button
    Friend WithEvents tenantName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents confirmButton As Button
    Friend WithEvents folderBrowseMain As FolderBrowserDialog
End Class
