<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ShowOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShowOrder))
        Me.pairIDValue = New System.Windows.Forms.Label()
        Me.pairIDLabel = New System.Windows.Forms.Label()
        Me.idOrderValue = New System.Windows.Forms.Label()
        Me.idOrderLabel = New System.Windows.Forms.Label()
        Me.dateAcquireValue = New System.Windows.Forms.Label()
        Me.dateAcquireLabel = New System.Windows.Forms.Label()
        Me.amountValue = New System.Windows.Forms.Label()
        Me.amountLabel = New System.Windows.Forms.Label()
        Me.tcoQuoteValue = New System.Windows.Forms.Label()
        Me.tcoQuoteLabel = New System.Windows.Forms.Label()
        Me.orderStateValue = New System.Windows.Forms.Label()
        Me.orderStateLabel = New System.Windows.Forms.Label()
        Me.quoteCurrencyValue = New System.Windows.Forms.Label()
        Me.baseCurrencyValue = New System.Windows.Forms.Label()
        Me.feeValue = New System.Windows.Forms.Label()
        Me.feeLabel = New System.Windows.Forms.Label()
        Me.priceCurrencyLabel = New System.Windows.Forms.Label()
        Me.priceValue = New System.Windows.Forms.Label()
        Me.priceLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pairIDValue
        '
        Me.pairIDValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pairIDValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pairIDValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pairIDValue.Location = New System.Drawing.Point(114, 97)
        Me.pairIDValue.Name = "pairIDValue"
        Me.pairIDValue.Size = New System.Drawing.Size(259, 21)
        Me.pairIDValue.TabIndex = 17
        Me.pairIDValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pairIDLabel
        '
        Me.pairIDLabel.AutoSize = True
        Me.pairIDLabel.Location = New System.Drawing.Point(61, 101)
        Me.pairIDLabel.Name = "pairIDLabel"
        Me.pairIDLabel.Size = New System.Drawing.Size(47, 13)
        Me.pairIDLabel.TabIndex = 16
        Me.pairIDLabel.Text = "Pair ID"
        '
        'idOrderValue
        '
        Me.idOrderValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.idOrderValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.idOrderValue.Location = New System.Drawing.Point(114, 23)
        Me.idOrderValue.Name = "idOrderValue"
        Me.idOrderValue.Size = New System.Drawing.Size(259, 21)
        Me.idOrderValue.TabIndex = 15
        Me.idOrderValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'idOrderLabel
        '
        Me.idOrderLabel.AutoSize = True
        Me.idOrderLabel.Location = New System.Drawing.Point(87, 27)
        Me.idOrderLabel.Name = "idOrderLabel"
        Me.idOrderLabel.Size = New System.Drawing.Size(21, 13)
        Me.idOrderLabel.TabIndex = 14
        Me.idOrderLabel.Text = "ID"
        '
        'dateAcquireValue
        '
        Me.dateAcquireValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dateAcquireValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dateAcquireValue.Location = New System.Drawing.Point(114, 142)
        Me.dateAcquireValue.Name = "dateAcquireValue"
        Me.dateAcquireValue.Size = New System.Drawing.Size(259, 21)
        Me.dateAcquireValue.TabIndex = 19
        Me.dateAcquireValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dateAcquireLabel
        '
        Me.dateAcquireLabel.AutoSize = True
        Me.dateAcquireLabel.Location = New System.Drawing.Point(28, 146)
        Me.dateAcquireLabel.Name = "dateAcquireLabel"
        Me.dateAcquireLabel.Size = New System.Drawing.Size(80, 13)
        Me.dateAcquireLabel.TabIndex = 18
        Me.dateAcquireLabel.Text = "Date acquire"
        '
        'amountValue
        '
        Me.amountValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.amountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.amountValue.Location = New System.Drawing.Point(114, 221)
        Me.amountValue.Name = "amountValue"
        Me.amountValue.Size = New System.Drawing.Size(202, 21)
        Me.amountValue.TabIndex = 21
        Me.amountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'amountLabel
        '
        Me.amountLabel.AutoSize = True
        Me.amountLabel.Location = New System.Drawing.Point(57, 225)
        Me.amountLabel.Name = "amountLabel"
        Me.amountLabel.Size = New System.Drawing.Size(51, 13)
        Me.amountLabel.TabIndex = 20
        Me.amountLabel.Text = "Amount"
        '
        'tcoQuoteValue
        '
        Me.tcoQuoteValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tcoQuoteValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tcoQuoteValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcoQuoteValue.Location = New System.Drawing.Point(114, 249)
        Me.tcoQuoteValue.Name = "tcoQuoteValue"
        Me.tcoQuoteValue.Size = New System.Drawing.Size(202, 21)
        Me.tcoQuoteValue.TabIndex = 23
        Me.tcoQuoteValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tcoQuoteLabel
        '
        Me.tcoQuoteLabel.AutoSize = True
        Me.tcoQuoteLabel.Location = New System.Drawing.Point(40, 253)
        Me.tcoQuoteLabel.Name = "tcoQuoteLabel"
        Me.tcoQuoteLabel.Size = New System.Drawing.Size(68, 13)
        Me.tcoQuoteLabel.TabIndex = 22
        Me.tcoQuoteLabel.Text = "TCO quote"
        '
        'orderStateValue
        '
        Me.orderStateValue.BackColor = System.Drawing.Color.Silver
        Me.orderStateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.orderStateValue.Location = New System.Drawing.Point(114, 323)
        Me.orderStateValue.Name = "orderStateValue"
        Me.orderStateValue.Size = New System.Drawing.Size(259, 21)
        Me.orderStateValue.TabIndex = 25
        Me.orderStateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'orderStateLabel
        '
        Me.orderStateLabel.AutoSize = True
        Me.orderStateLabel.Location = New System.Drawing.Point(36, 327)
        Me.orderStateLabel.Name = "orderStateLabel"
        Me.orderStateLabel.Size = New System.Drawing.Size(72, 13)
        Me.orderStateLabel.TabIndex = 24
        Me.orderStateLabel.Text = "Order state"
        '
        'quoteCurrencyValue
        '
        Me.quoteCurrencyValue.AutoSize = True
        Me.quoteCurrencyValue.Location = New System.Drawing.Point(322, 225)
        Me.quoteCurrencyValue.Name = "quoteCurrencyValue"
        Me.quoteCurrencyValue.Size = New System.Drawing.Size(0, 13)
        Me.quoteCurrencyValue.TabIndex = 28
        '
        'baseCurrencyValue
        '
        Me.baseCurrencyValue.AutoSize = True
        Me.baseCurrencyValue.Location = New System.Drawing.Point(322, 253)
        Me.baseCurrencyValue.Name = "baseCurrencyValue"
        Me.baseCurrencyValue.Size = New System.Drawing.Size(0, 13)
        Me.baseCurrencyValue.TabIndex = 29
        '
        'feeValue
        '
        Me.feeValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.feeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.feeValue.Location = New System.Drawing.Point(114, 281)
        Me.feeValue.Name = "feeValue"
        Me.feeValue.Size = New System.Drawing.Size(259, 21)
        Me.feeValue.TabIndex = 31
        Me.feeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'feeLabel
        '
        Me.feeLabel.AutoSize = True
        Me.feeLabel.Location = New System.Drawing.Point(81, 285)
        Me.feeLabel.Name = "feeLabel"
        Me.feeLabel.Size = New System.Drawing.Size(27, 13)
        Me.feeLabel.TabIndex = 30
        Me.feeLabel.Text = "Fee"
        '
        'priceCurrencyLabel
        '
        Me.priceCurrencyLabel.AutoSize = True
        Me.priceCurrencyLabel.Location = New System.Drawing.Point(322, 185)
        Me.priceCurrencyLabel.Name = "priceCurrencyLabel"
        Me.priceCurrencyLabel.Size = New System.Drawing.Size(0, 13)
        Me.priceCurrencyLabel.TabIndex = 34
        '
        'priceValue
        '
        Me.priceValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.priceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.priceValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.priceValue.Location = New System.Drawing.Point(114, 181)
        Me.priceValue.Name = "priceValue"
        Me.priceValue.Size = New System.Drawing.Size(202, 21)
        Me.priceValue.TabIndex = 33
        Me.priceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'priceLabel
        '
        Me.priceLabel.AutoSize = True
        Me.priceLabel.Location = New System.Drawing.Point(73, 185)
        Me.priceLabel.Name = "priceLabel"
        Me.priceLabel.Size = New System.Drawing.Size(35, 13)
        Me.priceLabel.TabIndex = 32
        Me.priceLabel.Text = "Price"
        '
        'ShowOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 357)
        Me.Controls.Add(Me.priceCurrencyLabel)
        Me.Controls.Add(Me.priceValue)
        Me.Controls.Add(Me.priceLabel)
        Me.Controls.Add(Me.feeValue)
        Me.Controls.Add(Me.feeLabel)
        Me.Controls.Add(Me.baseCurrencyValue)
        Me.Controls.Add(Me.quoteCurrencyValue)
        Me.Controls.Add(Me.orderStateValue)
        Me.Controls.Add(Me.orderStateLabel)
        Me.Controls.Add(Me.tcoQuoteValue)
        Me.Controls.Add(Me.tcoQuoteLabel)
        Me.Controls.Add(Me.amountValue)
        Me.Controls.Add(Me.amountLabel)
        Me.Controls.Add(Me.dateAcquireValue)
        Me.Controls.Add(Me.dateAcquireLabel)
        Me.Controls.Add(Me.pairIDValue)
        Me.Controls.Add(Me.pairIDLabel)
        Me.Controls.Add(Me.idOrderValue)
        Me.Controls.Add(Me.idOrderLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ShowOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Show Order"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pairIDValue As Label
    Friend WithEvents pairIDLabel As Label
    Friend WithEvents idOrderValue As Label
    Friend WithEvents idOrderLabel As Label
    Friend WithEvents dateAcquireValue As Label
    Friend WithEvents dateAcquireLabel As Label
    Friend WithEvents amountValue As Label
    Friend WithEvents amountLabel As Label
    Friend WithEvents tcoQuoteValue As Label
    Friend WithEvents tcoQuoteLabel As Label
    Friend WithEvents orderStateValue As Label
    Friend WithEvents orderStateLabel As Label
    Friend WithEvents quoteCurrencyValue As Label
    Friend WithEvents baseCurrencyValue As Label
    Friend WithEvents feeValue As Label
    Friend WithEvents feeLabel As Label
    Friend WithEvents priceCurrencyLabel As Label
    Friend WithEvents priceValue As Label
    Friend WithEvents priceLabel As Label
End Class
