<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.remoteAddressLabel = New System.Windows.Forms.Label()
        Me.remoteAddressText = New System.Windows.Forms.TextBox()
        Me.connectButton = New System.Windows.Forms.Button()
        Me.responseText = New System.Windows.Forms.TextBox()
        Me.ResponseLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'remoteAddressLabel
        '
        Me.remoteAddressLabel.AutoSize = True
        Me.remoteAddressLabel.Location = New System.Drawing.Point(13, 13)
        Me.remoteAddressLabel.Name = "remoteAddressLabel"
        Me.remoteAddressLabel.Size = New System.Drawing.Size(100, 13)
        Me.remoteAddressLabel.TabIndex = 0
        Me.remoteAddressLabel.Text = "Remote address"
        '
        'remoteAddressText
        '
        Me.remoteAddressText.Location = New System.Drawing.Point(13, 30)
        Me.remoteAddressText.Name = "remoteAddressText"
        Me.remoteAddressText.Size = New System.Drawing.Size(310, 21)
        Me.remoteAddressText.TabIndex = 1
        Me.remoteAddressText.Text = "http://localhost/"
        '
        'connectButton
        '
        Me.connectButton.Location = New System.Drawing.Point(330, 29)
        Me.connectButton.Name = "connectButton"
        Me.connectButton.Size = New System.Drawing.Size(75, 23)
        Me.connectButton.TabIndex = 2
        Me.connectButton.Text = "Connect"
        Me.connectButton.UseVisualStyleBackColor = True
        '
        'responseText
        '
        Me.responseText.Location = New System.Drawing.Point(13, 80)
        Me.responseText.Multiline = True
        Me.responseText.Name = "responseText"
        Me.responseText.ReadOnly = True
        Me.responseText.Size = New System.Drawing.Size(392, 309)
        Me.responseText.TabIndex = 3
        '
        'ResponseLabel
        '
        Me.ResponseLabel.AutoSize = True
        Me.ResponseLabel.Location = New System.Drawing.Point(12, 63)
        Me.ResponseLabel.Name = "ResponseLabel"
        Me.ResponseLabel.Size = New System.Drawing.Size(62, 13)
        Me.ResponseLabel.TabIndex = 4
        Me.ResponseLabel.Text = "Response"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 400)
        Me.Controls.Add(Me.ResponseLabel)
        Me.Controls.Add(Me.responseText)
        Me.Controls.Add(Me.connectButton)
        Me.Controls.Add(Me.remoteAddressText)
        Me.Controls.Add(Me.remoteAddressLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CHC Test Connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents remoteAddressLabel As Label
    Friend WithEvents remoteAddressText As TextBox
    Friend WithEvents connectButton As Button
    Friend WithEvents responseText As TextBox
    Friend WithEvents ResponseLabel As Label
End Class
