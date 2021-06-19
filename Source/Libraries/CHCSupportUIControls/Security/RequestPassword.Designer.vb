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
        Me.showCharacterButton.Location = New System.Drawing.Point(414, 5)
        Me.showCharacterButton.Name = "showCharacterButton"
        Me.showCharacterButton.Size = New System.Drawing.Size(32, 32)
        Me.showCharacterButton.TabIndex = 1
        Me.showCharacterButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelButton.Location = New System.Drawing.Point(352, 54)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(94, 23)
        Me.cancelButton.TabIndex = 3
        Me.cancelButton.Text = "&Annulla"
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(249, 54)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(94, 23)
        Me.confirmButton.TabIndex = 2
        Me.confirmButton.Text = "&OK"
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordTextBox.Location = New System.Drawing.Point(249, 5)
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordTextBox.Size = New System.Drawing.Size(167, 31)
        Me.passwordTextBox.TabIndex = 0
        '
        'logoPictureBox
        '
        Me.logoPictureBox.Image = CType(resources.GetObject("logoPictureBox.Image"), System.Drawing.Image)
        Me.logoPictureBox.Location = New System.Drawing.Point(4, 5)
        Me.logoPictureBox.Name = "logoPictureBox"
        Me.logoPictureBox.Size = New System.Drawing.Size(260, 228)
        Me.logoPictureBox.TabIndex = 14
        Me.logoPictureBox.TabStop = False
        '
        'RequestPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 238)
        Me.Controls.Add(Me.showCharacterButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Controls.Add(Me.logoPictureBox)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RequestPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Request Secret Key"
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents showCharacterButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents confirmButton As Button
    Friend WithEvents passwordTextBox As TextBox
    Friend WithEvents logoPictureBox As PictureBox
End Class
