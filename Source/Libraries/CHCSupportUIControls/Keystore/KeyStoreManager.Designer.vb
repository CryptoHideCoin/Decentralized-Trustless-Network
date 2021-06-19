<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyStoreManager
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
        Me.listAddress = New CHCSupportUIControls.WalletAddressList()
        Me.SuspendLayout()
        '
        'listAddress
        '
        Me.listAddress.dataPath = ""
        Me.listAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listAddress.Location = New System.Drawing.Point(-5, -2)
        Me.listAddress.Name = "listAddress"
        Me.listAddress.Size = New System.Drawing.Size(715, 303)
        Me.listAddress.TabIndex = 1
        '
        'KeyStoreManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 298)
        Me.Controls.Add(Me.listAddress)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(721, 337)
        Me.MinimumSize = New System.Drawing.Size(721, 337)
        Me.Name = "KeyStoreManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "KeyStore Manager"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents listAddress As WalletAddressList
End Class
