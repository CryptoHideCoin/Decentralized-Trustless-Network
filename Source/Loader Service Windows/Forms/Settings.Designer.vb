<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.adminSettingsButton = New System.Windows.Forms.Button()
        Me.starterSettingsButton = New System.Windows.Forms.Button()
        Me.runTimeSettingsButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'adminSettingsButton
        '
        Me.adminSettingsButton.Location = New System.Drawing.Point(132, 25)
        Me.adminSettingsButton.Name = "adminSettingsButton"
        Me.adminSettingsButton.Size = New System.Drawing.Size(106, 46)
        Me.adminSettingsButton.TabIndex = 0
        Me.adminSettingsButton.Text = "Admin Setings"
        Me.adminSettingsButton.UseVisualStyleBackColor = True
        '
        'starterSettingsButton
        '
        Me.starterSettingsButton.Location = New System.Drawing.Point(132, 77)
        Me.starterSettingsButton.Name = "starterSettingsButton"
        Me.starterSettingsButton.Size = New System.Drawing.Size(106, 46)
        Me.starterSettingsButton.TabIndex = 1
        Me.starterSettingsButton.Text = "Starter Setings"
        Me.starterSettingsButton.UseVisualStyleBackColor = True
        '
        'runTimeSettingsButton
        '
        Me.runTimeSettingsButton.Location = New System.Drawing.Point(132, 129)
        Me.runTimeSettingsButton.Name = "runTimeSettingsButton"
        Me.runTimeSettingsButton.Size = New System.Drawing.Size(106, 46)
        Me.runTimeSettingsButton.TabIndex = 2
        Me.runTimeSettingsButton.Text = "Runtime Setings"
        Me.runTimeSettingsButton.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(376, 195)
        Me.Controls.Add(Me.runTimeSettingsButton)
        Me.Controls.Add(Me.starterSettingsButton)
        Me.Controls.Add(Me.adminSettingsButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(392, 234)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(392, 234)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Masternode Settings"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents adminSettingsButton As Button
    Friend WithEvents starterSettingsButton As Button
    Friend WithEvents runTimeSettingsButton As Button
End Class
