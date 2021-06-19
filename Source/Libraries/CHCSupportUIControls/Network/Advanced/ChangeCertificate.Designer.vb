<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeCertificate
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.proceedButton = New System.Windows.Forms.Button()
        Me.groupCertificate = New System.Windows.Forms.GroupBox()
        Me.newCertificate = New CHCSupportUIControls.Certificate()
        Me.groupCertificate.SuspendLayout()
        Me.SuspendLayout()
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(538, 48)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 30)
        Me.cancelButton.TabIndex = 7
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'proceedButton
        '
        Me.proceedButton.Enabled = False
        Me.proceedButton.Location = New System.Drawing.Point(538, 9)
        Me.proceedButton.Name = "proceedButton"
        Me.proceedButton.Size = New System.Drawing.Size(75, 34)
        Me.proceedButton.TabIndex = 6
        Me.proceedButton.Text = "Proceed"
        Me.proceedButton.UseVisualStyleBackColor = True
        '
        'groupCertificate
        '
        Me.groupCertificate.Controls.Add(Me.newCertificate)
        Me.groupCertificate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupCertificate.Location = New System.Drawing.Point(3, 3)
        Me.groupCertificate.Name = "groupCertificate"
        Me.groupCertificate.Size = New System.Drawing.Size(529, 77)
        Me.groupCertificate.TabIndex = 4
        Me.groupCertificate.TabStop = False
        Me.groupCertificate.Text = "New Certificate"
        '
        'newCertificate
        '
        Me.newCertificate.dataPath = ""
        Me.newCertificate.Location = New System.Drawing.Point(11, 30)
        Me.newCertificate.Name = "newCertificate"
        Me.newCertificate.noChange = True
        Me.newCertificate.serviceId = ""
        Me.newCertificate.Size = New System.Drawing.Size(504, 30)
        Me.newCertificate.TabIndex = 4
        Me.newCertificate.urlService = ""
        Me.newCertificate.value = ""
        '
        'ChangeCertificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.proceedButton)
        Me.Controls.Add(Me.groupCertificate)
        Me.Name = "ChangeCertificate"
        Me.Size = New System.Drawing.Size(623, 85)
        Me.groupCertificate.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cancelButton As Button
    Friend WithEvents proceedButton As Button
    Friend WithEvents groupCertificate As GroupBox
    Friend WithEvents newCertificate As Certificate
End Class
