<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WalletAddressDetailForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WalletAddressDetailForm))
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
        Me.mainCustomizeWalletAddress.TabIndex = 0
        Me.mainCustomizeWalletAddress.UUID = "69cc7cef-3566-4960-8569-e57fffa483ee"
        '
        'WalletAddressDetailForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(797, 491)
        Me.Controls.Add(Me.mainCustomizeWalletAddress)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(728, 500)
        Me.Name = "WalletAddressDetailForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wallet Address Detail - Crypto Hide Coin DTN"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainCustomizeWalletAddress As CHCSupportUIControls.CustomizeWalletAddress
End Class
