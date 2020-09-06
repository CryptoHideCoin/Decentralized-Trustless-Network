<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class RequestPassword
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents passwordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RequestPassword))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.passwordTextBox = New System.Windows.Forms.TextBox()
        Me.ok = New System.Windows.Forms.Button()
        Me.cancel = New System.Windows.Forms.Button()
        Me.useKey = New System.Windows.Forms.CheckBox()
        Me.showCharacter = New System.Windows.Forms.Button()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 6)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(260, 228)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordTextBox.Location = New System.Drawing.Point(281, 35)
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTextBox.Size = New System.Drawing.Size(167, 31)
        Me.passwordTextBox.TabIndex = 3
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(281, 84)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(94, 23)
        Me.ok.TabIndex = 4
        Me.ok.Text = "&OK"
        '
        'cancel
        '
        Me.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel.Location = New System.Drawing.Point(384, 84)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(94, 23)
        Me.cancel.TabIndex = 5
        Me.cancel.Text = "&Annulla"
        '
        'useKey
        '
        Me.useKey.AutoSize = True
        Me.useKey.Checked = True
        Me.useKey.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.useKey.Location = New System.Drawing.Point(281, 12)
        Me.useKey.Name = "useKey"
        Me.useKey.Size = New System.Drawing.Size(159, 22)
        Me.useKey.TabIndex = 6
        Me.useKey.Text = "Use Protection KEY"
        Me.useKey.UseVisualStyleBackColor = True
        '
        'showCharacter
        '
        Me.showCharacter.Image = CType(resources.GetObject("showCharacter.Image"), System.Drawing.Image)
        Me.showCharacter.Location = New System.Drawing.Point(446, 35)
        Me.showCharacter.Name = "showCharacter"
        Me.showCharacter.Size = New System.Drawing.Size(32, 32)
        Me.showCharacter.TabIndex = 7
        Me.showCharacter.UseVisualStyleBackColor = True
        '
        'RequestPassword
        '
        Me.AcceptButton = Me.ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cancel
        Me.ClientSize = New System.Drawing.Size(491, 239)
        Me.ControlBox = False
        Me.Controls.Add(Me.showCharacter)
        Me.Controls.Add(Me.useKey)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.ok)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RequestPassword"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Key Protection - Crypto Hide Coin Decentralize Trustless"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents useKey As CheckBox
    Friend WithEvents showCharacter As Button
End Class
