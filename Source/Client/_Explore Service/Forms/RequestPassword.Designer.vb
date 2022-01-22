<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RequestPassword))
        Me.showCharacterButton = New System.Windows.Forms.Button()
        Me.useKeyCheck = New System.Windows.Forms.CheckBox()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.passwordTextBox = New System.Windows.Forms.TextBox()
        Me.logoPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'showCharacterButton
        '
        Me.showCharacterButton.Image = CType(resources.GetObject("showCharacterButton.Image"), System.Drawing.Image)
        Me.showCharacterButton.Location = New System.Drawing.Point(443, 41)
        Me.showCharacterButton.Name = "showCharacterButton"
        Me.showCharacterButton.Size = New System.Drawing.Size(32, 32)
        Me.showCharacterButton.TabIndex = 13
        Me.showCharacterButton.UseVisualStyleBackColor = True
        '
        'useKeyCheck
        '
        Me.useKeyCheck.AutoSize = True
        Me.useKeyCheck.Checked = True
        Me.useKeyCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useKeyCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.useKeyCheck.Location = New System.Drawing.Point(278, 18)
        Me.useKeyCheck.Name = "useKeyCheck"
        Me.useKeyCheck.Size = New System.Drawing.Size(159, 22)
        Me.useKeyCheck.TabIndex = 12
        Me.useKeyCheck.Text = "Use Protection KEY"
        Me.useKeyCheck.UseVisualStyleBackColor = True
        Me.useKeyCheck.Visible = False
        '
        'cancelButton
        '
        Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelButton.Location = New System.Drawing.Point(381, 90)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(94, 23)
        Me.cancelButton.TabIndex = 11
        Me.cancelButton.Text = "&Annulla"
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(278, 90)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(94, 23)
        Me.confirmButton.TabIndex = 10
        Me.confirmButton.Text = "&OK"
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordTextBox.Location = New System.Drawing.Point(278, 41)
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTextBox.Size = New System.Drawing.Size(167, 31)
        Me.passwordTextBox.TabIndex = 9
        '
        'logoPictureBox
        '
        Me.logoPictureBox.Image = CType(resources.GetObject("logoPictureBox.Image"), System.Drawing.Image)
        Me.logoPictureBox.Location = New System.Drawing.Point(0, 12)
        Me.logoPictureBox.Name = "logoPictureBox"
        Me.logoPictureBox.Size = New System.Drawing.Size(260, 228)
        Me.logoPictureBox.TabIndex = 8
        Me.logoPictureBox.TabStop = False
        '
        'RequestPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 238)
        Me.Controls.Add(Me.showCharacterButton)
        Me.Controls.Add(Me.useKeyCheck)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Controls.Add(Me.logoPictureBox)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RequestPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Request Secret Key "
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents showCharacterButton As Button
    Friend WithEvents useKeyCheck As CheckBox
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents passwordTextBox As TextBox
    Friend WithEvents logoPictureBox As PictureBox
End Class
