<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PersonalData
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.workSpaceNameValue = New System.Windows.Forms.TextBox()
        Me.exchangeValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.APIKeyValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.passphraseValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.secretValue = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.apiURLValue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.baseFundValue = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Workspace name"
        '
        'workSpaceNameValue
        '
        Me.workSpaceNameValue.Location = New System.Drawing.Point(12, 30)
        Me.workSpaceNameValue.Name = "workSpaceNameValue"
        Me.workSpaceNameValue.Size = New System.Drawing.Size(362, 21)
        Me.workSpaceNameValue.TabIndex = 0
        '
        'exchangeValue
        '
        Me.exchangeValue.Location = New System.Drawing.Point(12, 90)
        Me.exchangeValue.Name = "exchangeValue"
        Me.exchangeValue.ReadOnly = True
        Me.exchangeValue.Size = New System.Drawing.Size(362, 21)
        Me.exchangeValue.TabIndex = 3
        Me.exchangeValue.Text = "Coinbase Pro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Exchange"
        '
        'APIKeyValue
        '
        Me.APIKeyValue.Location = New System.Drawing.Point(12, 131)
        Me.APIKeyValue.Name = "APIKeyValue"
        Me.APIKeyValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.APIKeyValue.Size = New System.Drawing.Size(362, 21)
        Me.APIKeyValue.TabIndex = 1
        Me.APIKeyValue.Text = "0056fd332d3742fe03e23611e458f5f6"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "API Key"
        '
        'passphraseValue
        '
        Me.passphraseValue.Location = New System.Drawing.Point(12, 172)
        Me.passphraseValue.Name = "passphraseValue"
        Me.passphraseValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passphraseValue.Size = New System.Drawing.Size(362, 21)
        Me.passphraseValue.TabIndex = 2
        Me.passphraseValue.Text = "7453tzgjyvo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Passphrase"
        '
        'secretValue
        '
        Me.secretValue.Location = New System.Drawing.Point(12, 213)
        Me.secretValue.Name = "secretValue"
        Me.secretValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.secretValue.Size = New System.Drawing.Size(362, 21)
        Me.secretValue.TabIndex = 3
        Me.secretValue.Text = "PWgu2Ssj/O6dZZA9PGjYqqOrLjWKX4Ek6bRPHzDKLYajgiYaBDfdQv5WBuTwcW6ezuYOF6XKpx0q4eyBQ" &
    "TCThA=="
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Secret"
        '
        'apiURLValue
        '
        Me.apiURLValue.Location = New System.Drawing.Point(12, 254)
        Me.apiURLValue.Name = "apiURLValue"
        Me.apiURLValue.Size = New System.Drawing.Size(362, 21)
        Me.apiURLValue.TabIndex = 4
        Me.apiURLValue.Text = "https://api.pro.coinbase.com"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "API URL"
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(299, 360)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 27)
        Me.confirmButton.TabIndex = 6
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'baseFundValue
        '
        Me.baseFundValue.Location = New System.Drawing.Point(12, 321)
        Me.baseFundValue.Name = "baseFundValue"
        Me.baseFundValue.Size = New System.Drawing.Size(362, 21)
        Me.baseFundValue.TabIndex = 5
        Me.baseFundValue.Text = "1522"
        Me.baseFundValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Base Fund"
        '
        'PersonalData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 399)
        Me.Controls.Add(Me.baseFundValue)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.apiURLValue)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.secretValue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.passphraseValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.APIKeyValue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.exchangeValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.workSpaceNameValue)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PersonalData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Personal Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents workSpaceNameValue As TextBox
    Friend WithEvents exchangeValue As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents APIKeyValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents passphraseValue As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents secretValue As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents apiURLValue As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents confirmButton As Button
    Friend WithEvents baseFundValue As TextBox
    Friend WithEvents Label7 As Label
End Class
