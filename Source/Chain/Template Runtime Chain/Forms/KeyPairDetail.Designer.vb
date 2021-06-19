<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyPairDetail
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
        Me.walletDetail = New CHCSupportUIControls.CustomizeWalletAddress()
        Me.SuspendLayout()
        '
        'walletDetail
        '
        Me.walletDetail.BackColor = System.Drawing.Color.Transparent
        Me.walletDetail.Location = New System.Drawing.Point(0, 0)
        Me.walletDetail.Name = "walletDetail"
        Me.walletDetail.pathData = ""
        Me.walletDetail.Size = New System.Drawing.Size(786, 496)
        Me.walletDetail.TabIndex = 0
        Me.walletDetail.uuid = "b051eac3-087b-4391-9916-db87614f049f"
        '
        'KeyPairDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 487)
        Me.Controls.Add(Me.walletDetail)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "KeyPairDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Wallet Info Detail"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents walletDetail As CHCSupportUIControls.CustomizeWalletAddress
End Class
