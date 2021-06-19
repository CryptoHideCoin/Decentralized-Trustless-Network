<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogChangeCertificate
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
        Me.certificateChange = New CHCSupportUIControls.ChangeCertificate()
        Me.SuspendLayout()
        '
        'certificateChange
        '
        Me.certificateChange.certificate = ""
        Me.certificateChange.Location = New System.Drawing.Point(0, 1)
        Me.certificateChange.Name = "certificateChange"
        Me.certificateChange.Size = New System.Drawing.Size(841, 88)
        Me.certificateChange.TabIndex = 1
        '
        'DialogChangeCertificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(726, 84)
        Me.ControlBox = False
        Me.Controls.Add(Me.certificateChange)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DialogChangeCertificate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Certificate Procedure"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents certificateChange As ChangeCertificate
End Class
