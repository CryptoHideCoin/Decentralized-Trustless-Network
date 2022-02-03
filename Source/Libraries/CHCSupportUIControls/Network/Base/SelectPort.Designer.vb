<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectPort
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
        Me.portNumber = New System.Windows.Forms.TextBox()
        Me.portNumberLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'portNumber
        '
        Me.portNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumber.Location = New System.Drawing.Point(216, 1)
        Me.portNumber.Name = "portNumber"
        Me.portNumber.Size = New System.Drawing.Size(59, 21)
        Me.portNumber.TabIndex = 20
        Me.portNumber.Text = "0"
        Me.portNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'portNumberLabel
        '
        Me.portNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumberLabel.Location = New System.Drawing.Point(3, 4)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(207, 13)
        Me.portNumberLabel.TabIndex = 19
        Me.portNumberLabel.Text = "Public port number (0..65535)"
        Me.portNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SelectPort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.portNumber)
        Me.Controls.Add(Me.portNumberLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SelectPort"
        Me.Size = New System.Drawing.Size(280, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents portNumber As TextBox
    Friend WithEvents portNumberLabel As Label
End Class
