<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangeCertificate
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me._certificateChange = New CHCSupportUIControls.ChangeCertificate()
        Me.SuspendLayout()
        '
        '_certificateChange
        '
        Me._certificateChange.certificate = ""
        Me._certificateChange.Location = New System.Drawing.Point(3, 1)
        Me._certificateChange.Name = "_certificateChange"
        Me._certificateChange.privateKey = ""
        Me._certificateChange.Size = New System.Drawing.Size(721, 223)
        Me._certificateChange.TabIndex = 0
        '
        'ChangeCertificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(726, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me._certificateChange)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ChangeCertificate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Certificate Procedure"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents _certificateChange As CHCSupportUIControls.ChangeCertificate
End Class
