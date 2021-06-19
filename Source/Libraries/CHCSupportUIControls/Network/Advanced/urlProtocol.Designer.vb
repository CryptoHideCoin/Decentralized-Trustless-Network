<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UrlProtocol
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
        Me.urlLabel = New System.Windows.Forms.Label()
        Me.serviceAdminUrlText = New System.Windows.Forms.TextBox()
        Me.protocolCombo = New System.Windows.Forms.ComboBox()
        Me.testButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'urlLabel
        '
        Me.urlLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.urlLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.urlLabel.Location = New System.Drawing.Point(8, 8)
        Me.urlLabel.Name = "urlLabel"
        Me.urlLabel.Size = New System.Drawing.Size(29, 13)
        Me.urlLabel.TabIndex = 12
        Me.urlLabel.Text = "URL"
        Me.urlLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'serviceAdminUrlText
        '
        Me.serviceAdminUrlText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.serviceAdminUrlText.Location = New System.Drawing.Point(119, 4)
        Me.serviceAdminUrlText.Multiline = True
        Me.serviceAdminUrlText.Name = "serviceAdminUrlText"
        Me.serviceAdminUrlText.Size = New System.Drawing.Size(185, 22)
        Me.serviceAdminUrlText.TabIndex = 11
        '
        'protocolCombo
        '
        Me.protocolCombo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.protocolCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.protocolCombo.FormattingEnabled = True
        Me.protocolCombo.Items.AddRange(New Object() {"http://", "https://"})
        Me.protocolCombo.Location = New System.Drawing.Point(43, 4)
        Me.protocolCombo.Name = "protocolCombo"
        Me.protocolCombo.Size = New System.Drawing.Size(70, 21)
        Me.protocolCombo.TabIndex = 10
        '
        'testButton
        '
        Me.testButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.testButton.Enabled = False
        Me.testButton.Font = New System.Drawing.Font("Webdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.testButton.Location = New System.Drawing.Point(308, 4)
        Me.testButton.Name = "testButton"
        Me.testButton.Size = New System.Drawing.Size(20, 23)
        Me.testButton.TabIndex = 13
        Me.testButton.Text = "4"
        Me.testButton.UseVisualStyleBackColor = True
        '
        'UrlProtocol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.testButton)
        Me.Controls.Add(Me.urlLabel)
        Me.Controls.Add(Me.serviceAdminUrlText)
        Me.Controls.Add(Me.protocolCombo)
        Me.MinimumSize = New System.Drawing.Size(0, 29)
        Me.Name = "UrlProtocol"
        Me.Size = New System.Drawing.Size(334, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents urlLabel As Label
    Friend WithEvents serviceAdminUrlText As TextBox
    Friend WithEvents protocolCombo As ComboBox
    Friend WithEvents testButton As Button
End Class
