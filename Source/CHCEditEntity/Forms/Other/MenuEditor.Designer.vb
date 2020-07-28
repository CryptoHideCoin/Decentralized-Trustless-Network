<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuEditor))
        Me.contractOfValueMenu = New System.Windows.Forms.Button()
        Me.networkButton = New System.Windows.Forms.Button()
        Me.appReleaseLabel = New System.Windows.Forms.Label()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.systemStatusLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'contractOfValueMenu
        '
        Me.contractOfValueMenu.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractOfValueMenu.Location = New System.Drawing.Point(26, 73)
        Me.contractOfValueMenu.Name = "contractOfValueMenu"
        Me.contractOfValueMenu.Size = New System.Drawing.Size(85, 38)
        Me.contractOfValueMenu.TabIndex = 0
        Me.contractOfValueMenu.Text = "Crypto Asset"
        Me.contractOfValueMenu.UseVisualStyleBackColor = True
        '
        'networkButton
        '
        Me.networkButton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkButton.Location = New System.Drawing.Point(117, 73)
        Me.networkButton.Name = "networkButton"
        Me.networkButton.Size = New System.Drawing.Size(88, 38)
        Me.networkButton.TabIndex = 1
        Me.networkButton.Text = "Transaction Chain"
        Me.networkButton.UseVisualStyleBackColor = True
        '
        'appReleaseLabel
        '
        Me.appReleaseLabel.AutoSize = True
        Me.appReleaseLabel.Location = New System.Drawing.Point(12, 163)
        Me.appReleaseLabel.Name = "appReleaseLabel"
        Me.appReleaseLabel.Size = New System.Drawing.Size(120, 13)
        Me.appReleaseLabel.TabIndex = 2
        Me.appReleaseLabel.Text = "Application release:"
        '
        'titleLabel
        '
        Me.titleLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(12, 21)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(204, 31)
        Me.titleLabel.TabIndex = 3
        Me.titleLabel.Text = "Crypto Hide Coin DTN Platform Management Utility"
        Me.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'systemStatusLabel
        '
        Me.systemStatusLabel.AutoSize = True
        Me.systemStatusLabel.Location = New System.Drawing.Point(23, 140)
        Me.systemStatusLabel.Name = "systemStatusLabel"
        Me.systemStatusLabel.Size = New System.Drawing.Size(95, 13)
        Me.systemStatusLabel.TabIndex = 4
        Me.systemStatusLabel.Text = "System Status:"
        '
        'MenuEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(228, 190)
        Me.Controls.Add(Me.systemStatusLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.appReleaseLabel)
        Me.Controls.Add(Me.networkButton)
        Me.Controls.Add(Me.contractOfValueMenu)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MenuEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Module Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents contractOfValueMenu As Button
    Friend WithEvents networkButton As Button
    Friend WithEvents appReleaseLabel As Label
    Friend WithEvents titleLabel As Label
    Friend WithEvents systemStatusLabel As Label
End Class
