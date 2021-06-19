<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class KeyStoreManagerExplorer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KeyStoreManagerExplorer))
        Me.mainWalletAddressList = New CHCSupportUIControls.WalletAddressList()
        Me.SuspendLayout()
        '
        'mainWalletAddressList
        '
        Me.mainWalletAddressList.dataPath = ""
        Me.mainWalletAddressList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainWalletAddressList.Location = New System.Drawing.Point(0, 0)
        Me.mainWalletAddressList.Name = "mainWalletAddressList"
        Me.mainWalletAddressList.Size = New System.Drawing.Size(800, 304)
        Me.mainWalletAddressList.TabIndex = 0
        '
        'KeyStoreManagerExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 302)
        Me.Controls.Add(Me.mainWalletAddressList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KeyStoreManagerExplorer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KeyStore Manager Explorer - Crypto Hide Coin DTN"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainWalletAddressList As CHCSupportUIControls.WalletAddressList
End Class
