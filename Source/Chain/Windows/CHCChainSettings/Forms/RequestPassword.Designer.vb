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
        Me.showCharacterValue = New System.Windows.Forms.Button()
        Me.useKeyCheckBox = New System.Windows.Forms.CheckBox()
        Me.cancelValue = New System.Windows.Forms.Button()
        Me.okButton = New System.Windows.Forms.Button()
        Me.passwordValue = New System.Windows.Forms.TextBox()
        Me.logoPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'showCharacterValue
        '
        Me.showCharacterValue.Enabled = False
        Me.showCharacterValue.Image = CType(resources.GetObject("showCharacterValue.Image"), System.Drawing.Image)
        Me.showCharacterValue.Location = New System.Drawing.Point(447, 31)
        Me.showCharacterValue.Name = "showCharacterValue"
        Me.showCharacterValue.Size = New System.Drawing.Size(32, 32)
        Me.showCharacterValue.TabIndex = 19
        Me.showCharacterValue.UseVisualStyleBackColor = True
        '
        'useKeyCheckBox
        '
        Me.useKeyCheckBox.AutoSize = True
        Me.useKeyCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.useKeyCheckBox.Location = New System.Drawing.Point(282, 8)
        Me.useKeyCheckBox.Name = "useKeyCheckBox"
        Me.useKeyCheckBox.Size = New System.Drawing.Size(159, 22)
        Me.useKeyCheckBox.TabIndex = 18
        Me.useKeyCheckBox.Text = "Use Protection KEY"
        Me.useKeyCheckBox.UseVisualStyleBackColor = True
        '
        'cancelValue
        '
        Me.cancelValue.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelValue.Location = New System.Drawing.Point(385, 80)
        Me.cancelValue.Name = "cancelValue"
        Me.cancelValue.Size = New System.Drawing.Size(94, 23)
        Me.cancelValue.TabIndex = 17
        Me.cancelValue.Text = "&Cancel"
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(282, 80)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(94, 23)
        Me.okButton.TabIndex = 16
        Me.okButton.Text = "&OK"
        '
        'passwordValue
        '
        Me.passwordValue.Enabled = False
        Me.passwordValue.Font = New System.Drawing.Font("Courier New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordValue.Location = New System.Drawing.Point(282, 31)
        Me.passwordValue.Name = "passwordValue"
        Me.passwordValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordValue.Size = New System.Drawing.Size(167, 31)
        Me.passwordValue.TabIndex = 15
        '
        'logoPictureBox
        '
        Me.logoPictureBox.Image = CType(resources.GetObject("logoPictureBox.Image"), System.Drawing.Image)
        Me.logoPictureBox.Location = New System.Drawing.Point(4, 2)
        Me.logoPictureBox.Name = "logoPictureBox"
        Me.logoPictureBox.Size = New System.Drawing.Size(260, 228)
        Me.logoPictureBox.TabIndex = 14
        Me.logoPictureBox.TabStop = False
        '
        'RequestPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 233)
        Me.ControlBox = False
        Me.Controls.Add(Me.showCharacterValue)
        Me.Controls.Add(Me.useKeyCheckBox)
        Me.Controls.Add(Me.cancelValue)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.passwordValue)
        Me.Controls.Add(Me.logoPictureBox)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "RequestPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Security Key"
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents showCharacterValue As Button
    Friend WithEvents useKeyCheckBox As CheckBox
    Friend WithEvents cancelValue As Button
    Friend WithEvents okButton As Button
    Friend WithEvents passwordValue As TextBox
    Friend WithEvents logoPictureBox As PictureBox
End Class
