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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KeyPairDetail))
        Me.mainCustomizeWalletAddress = New CHCSupportUIControls.CustomizeWalletAddress()
        Me.SuspendLayout()
        '
        'mainCustomizeWalletAddress
        '
        Me.mainCustomizeWalletAddress.BackColor = System.Drawing.Color.Transparent
        Me.mainCustomizeWalletAddress.Location = New System.Drawing.Point(0, 0)
        Me.mainCustomizeWalletAddress.Name = "mainCustomizeWalletAddress"
        Me.mainCustomizeWalletAddress.pathData = ""
        Me.mainCustomizeWalletAddress.Size = New System.Drawing.Size(800, 496)
        Me.mainCustomizeWalletAddress.TabIndex = 1
        Me.mainCustomizeWalletAddress.uuid = "56a39655-65c1-41c7-9458-b59a9bc9cb3a"
        '
        'KeyPairDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 491)
        Me.Controls.Add(Me.mainCustomizeWalletAddress)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(728, 500)
        Me.Name = "KeyPairDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wallet Address Detail - Crypto Hide Coin DTN"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainCustomizeWalletAddress As CustomizeWalletAddress
End Class
