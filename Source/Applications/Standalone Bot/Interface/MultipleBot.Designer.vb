<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultipleBot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultipleBot))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.productList = New System.Windows.Forms.CheckedListBox()
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.addNewButton = New System.Windows.Forms.Button()
        Me.selectAllButton = New System.Windows.Forms.Button()
        Me.noneButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.delayDuringAdd = New System.Windows.Forms.TextBox()
        Me.defaultSettings = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select the products to use"
        '
        'productList
        '
        Me.productList.FormattingEnabled = True
        Me.productList.Items.AddRange(New Object() {"BTC-USDT", "ETH-USDT", "ADA-USDT", "SOL-USDT", "DOT-USDT", "DOGE-USDT", "AVAX-USDT", "MATIC-USDT", "SHIB-USDT", "LINK-USDT", "CRO-USDT", "ATOM-USDT", "ENJ-USDT", "XLM-USDT", "AXS-USDT", "CHZ-USDT", "STX-USDT", "QNT-USDT", "ZEN-USDT", "IMX-USDT", "PERP-USDT", "ENS-USDT", "DESO-USDT", "SPELL-USDT", "GALA-USDT", "SUPER-USDT", "FET-USDT", "LRC-USDT", "CLV-USDT", "POLY-USDT", "ORN-USDT", "RAD-USDT", "ALCX-USDT", "BOND-USDT", "TRAC-USDT", "BADGER-USDT", "RLY-USDT", "AGLD-USDT", "POLS-USDT", "API3-USDT", "INDEX-USDT", "WCFG-USDT", "DDX-USDT", "ERN-USDT", "MASK-USDT", "POWR-USDT", "XYO-USDT", "BTRST-USDT", "REQ-USDT", "LQTY-USDT", "ARPA-USDT", "BOBA-USDT", "BICO-USDT", "WAMPL-USDT", "QSP-USDT", "C98-USDT", "DREP-USDT", "MINA-USDT", "XCN-USDT", "MEDIA-USDT", "OP-USDT", "METIS-USDT", "RNDR-USDT", "ELA-USDT", "SYLO-USDT", "HOPR-USDT", "ROSE-USDT", "MATH-USDT", "KSM-USDT", "POND-USDT", "SAND-USDT", "APE-USDT", "AIOZ-USDT", "BIT-USDT", "TIME-USDT", "STG-USDT", "ICP-USDT", "GNO-USDT", "FIDA-USDT", "AUCTION-USDT", "ATA-USDT", "MCO2-USDT", "SHPING-USDT", "UPI-USDT", "ACH-USDT", "NCT-USDT", "COVAL-USDT", "MDT-USDT", "KRL-USDT", "FOX-USDT", "ASM-USDT", "CTX-USDT", "SUKU-USDT", "DIA-USDT", "JASMY-USDT", "FARM-USDT", "DYP-USDT"})
        Me.productList.Location = New System.Drawing.Point(18, 40)
        Me.productList.Name = "productList"
        Me.productList.Size = New System.Drawing.Size(402, 340)
        Me.productList.TabIndex = 0
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(345, 414)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 35)
        Me.confirmButton.TabIndex = 3
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'addNewButton
        '
        Me.addNewButton.Location = New System.Drawing.Point(18, 415)
        Me.addNewButton.Name = "addNewButton"
        Me.addNewButton.Size = New System.Drawing.Size(75, 34)
        Me.addNewButton.TabIndex = 1
        Me.addNewButton.Text = "Add New"
        Me.addNewButton.UseVisualStyleBackColor = True
        '
        'selectAllButton
        '
        Me.selectAllButton.Location = New System.Drawing.Point(385, 13)
        Me.selectAllButton.Name = "selectAllButton"
        Me.selectAllButton.Size = New System.Drawing.Size(34, 23)
        Me.selectAllButton.TabIndex = 4
        Me.selectAllButton.TabStop = False
        Me.selectAllButton.Text = "All"
        Me.selectAllButton.UseVisualStyleBackColor = True
        '
        'noneButton
        '
        Me.noneButton.Location = New System.Drawing.Point(333, 13)
        Me.noneButton.Name = "noneButton"
        Me.noneButton.Size = New System.Drawing.Size(46, 23)
        Me.noneButton.TabIndex = 5
        Me.noneButton.TabStop = False
        Me.noneButton.Text = "None"
        Me.noneButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Delay during add (in second)"
        '
        'delayDuringAdd
        '
        Me.delayDuringAdd.Location = New System.Drawing.Point(345, 387)
        Me.delayDuringAdd.Name = "delayDuringAdd"
        Me.delayDuringAdd.Size = New System.Drawing.Size(75, 21)
        Me.delayDuringAdd.TabIndex = 7
        Me.delayDuringAdd.TabStop = False
        Me.delayDuringAdd.Text = "1"
        Me.delayDuringAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'defaultSettings
        '
        Me.defaultSettings.Location = New System.Drawing.Point(99, 415)
        Me.defaultSettings.Name = "defaultSettings"
        Me.defaultSettings.Size = New System.Drawing.Size(75, 34)
        Me.defaultSettings.TabIndex = 2
        Me.defaultSettings.Text = "Set default"
        Me.defaultSettings.UseVisualStyleBackColor = True
        '
        'MultipleBot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 461)
        Me.Controls.Add(Me.defaultSettings)
        Me.Controls.Add(Me.delayDuringAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.noneButton)
        Me.Controls.Add(Me.selectAllButton)
        Me.Controls.Add(Me.addNewButton)
        Me.Controls.Add(Me.confirmButton)
        Me.Controls.Add(Me.productList)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(447, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(447, 500)
        Me.Name = "MultipleBot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Multiple Bot Creation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents productList As CheckedListBox
    Friend WithEvents confirmButton As Button
    Friend WithEvents addNewButton As Button
    Friend WithEvents selectAllButton As Button
    Friend WithEvents noneButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents delayDuringAdd As TextBox
    Friend WithEvents defaultSettings As Button
End Class
