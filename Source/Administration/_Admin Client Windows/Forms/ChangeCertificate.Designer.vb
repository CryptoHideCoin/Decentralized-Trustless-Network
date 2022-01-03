<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeCertificate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeCertificate))
        Me.groupCertificate = New System.Windows.Forms.GroupBox()
        Me.newCertificate = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.privateKeyValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.proceedButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.groupCertificate.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupCertificate
        '
        Me.groupCertificate.Controls.Add(Me.newCertificate)
        Me.groupCertificate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupCertificate.Location = New System.Drawing.Point(4, 3)
        Me.groupCertificate.Name = "groupCertificate"
        Me.groupCertificate.Size = New System.Drawing.Size(469, 77)
        Me.groupCertificate.TabIndex = 0
        Me.groupCertificate.TabStop = False
        Me.groupCertificate.Text = "New Certificate"
        '
        'newCertificate
        '
        Me.newCertificate.Location = New System.Drawing.Point(11, 40)
        Me.newCertificate.Name = "newCertificate"
        Me.newCertificate.Size = New System.Drawing.Size(439, 21)
        Me.newCertificate.TabIndex = 3
        Me.newCertificate.Text = "GSDKLT3W89JFRW3E9W389R3UWR93WJU"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.privateKeyValue)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(469, 117)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Signature"
        '
        'privateKeyValue
        '
        Me.privateKeyValue.Location = New System.Drawing.Point(11, 39)
        Me.privateKeyValue.Multiline = True
        Me.privateKeyValue.Name = "privateKeyValue"
        Me.privateKeyValue.Size = New System.Drawing.Size(439, 72)
        Me.privateKeyValue.TabIndex = 3
        Me.privateKeyValue.Text = resources.GetString("privateKeyValue.Text")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Private Key"
        '
        'proceedButton
        '
        Me.proceedButton.Location = New System.Drawing.Point(479, 12)
        Me.proceedButton.Name = "proceedButton"
        Me.proceedButton.Size = New System.Drawing.Size(75, 34)
        Me.proceedButton.TabIndex = 2
        Me.proceedButton.Text = "Proceed"
        Me.proceedButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(479, 52)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 30)
        Me.cancelButton.TabIndex = 3
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'ChangeCertificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(562, 211)
        Me.ControlBox = False
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.proceedButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupCertificate)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ChangeCertificate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Procedure"
        Me.groupCertificate.ResumeLayout(False)
        Me.groupCertificate.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupCertificate As GroupBox
    Friend WithEvents newCertificate As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents privateKeyValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents proceedButton As Button
    Friend WithEvents cancelButton As Button
End Class
