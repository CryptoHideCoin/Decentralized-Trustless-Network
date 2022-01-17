<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SummaryLedgerPanel
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
        Me.identityBlockChain = New System.Windows.Forms.TextBox()
        Me.identityLabel = New System.Windows.Forms.Label()
        Me.createLedgerTimeStamp = New System.Windows.Forms.TextBox()
        Me.createLedgerTimeStampLabel = New System.Windows.Forms.Label()
        Me.lastUpdateTimeStamp = New System.Windows.Forms.TextBox()
        Me.lastUpdateTimeStampLabel = New System.Windows.Forms.Label()
        Me.numVolumes = New System.Windows.Forms.TextBox()
        Me.numVolumesLabel = New System.Windows.Forms.Label()
        Me.numBlocks = New System.Windows.Forms.TextBox()
        Me.numBlocksLabel = New System.Windows.Forms.Label()
        Me.numTransactions = New System.Windows.Forms.TextBox()
        Me.numTransactionsLabel = New System.Windows.Forms.Label()
        Me.latestTransaction = New System.Windows.Forms.TextBox()
        Me.latestTransactionLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'identityBlockChain
        '
        Me.identityBlockChain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.identityBlockChain.Location = New System.Drawing.Point(22, 31)
        Me.identityBlockChain.Name = "identityBlockChain"
        Me.identityBlockChain.ReadOnly = True
        Me.identityBlockChain.Size = New System.Drawing.Size(112, 21)
        Me.identityBlockChain.TabIndex = 38
        Me.identityBlockChain.Text = "xxxx"
        '
        'identityLabel
        '
        Me.identityLabel.AutoSize = True
        Me.identityLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.identityLabel.Location = New System.Drawing.Point(19, 15)
        Me.identityLabel.Name = "identityLabel"
        Me.identityLabel.Size = New System.Drawing.Size(115, 13)
        Me.identityLabel.TabIndex = 39
        Me.identityLabel.Text = "Identity blockchain"
        '
        'createLedgerTimeStamp
        '
        Me.createLedgerTimeStamp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createLedgerTimeStamp.Location = New System.Drawing.Point(22, 78)
        Me.createLedgerTimeStamp.Name = "createLedgerTimeStamp"
        Me.createLedgerTimeStamp.ReadOnly = True
        Me.createLedgerTimeStamp.Size = New System.Drawing.Size(310, 21)
        Me.createLedgerTimeStamp.TabIndex = 44
        Me.createLedgerTimeStamp.Text = "xxxx"
        '
        'createLedgerTimeStampLabel
        '
        Me.createLedgerTimeStampLabel.AutoSize = True
        Me.createLedgerTimeStampLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createLedgerTimeStampLabel.Location = New System.Drawing.Point(19, 62)
        Me.createLedgerTimeStampLabel.Name = "createLedgerTimeStampLabel"
        Me.createLedgerTimeStampLabel.Size = New System.Drawing.Size(158, 13)
        Me.createLedgerTimeStampLabel.TabIndex = 45
        Me.createLedgerTimeStampLabel.Text = "Create Ledger TimeStamp"
        '
        'lastUpdateTimeStamp
        '
        Me.lastUpdateTimeStamp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastUpdateTimeStamp.Location = New System.Drawing.Point(22, 126)
        Me.lastUpdateTimeStamp.Name = "lastUpdateTimeStamp"
        Me.lastUpdateTimeStamp.ReadOnly = True
        Me.lastUpdateTimeStamp.Size = New System.Drawing.Size(310, 21)
        Me.lastUpdateTimeStamp.TabIndex = 46
        Me.lastUpdateTimeStamp.Text = "xxxx"
        '
        'lastUpdateTimeStampLabel
        '
        Me.lastUpdateTimeStampLabel.AutoSize = True
        Me.lastUpdateTimeStampLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastUpdateTimeStampLabel.Location = New System.Drawing.Point(19, 110)
        Me.lastUpdateTimeStampLabel.Name = "lastUpdateTimeStampLabel"
        Me.lastUpdateTimeStampLabel.Size = New System.Drawing.Size(143, 13)
        Me.lastUpdateTimeStampLabel.TabIndex = 47
        Me.lastUpdateTimeStampLabel.Text = "Last Update TimeStamp"
        '
        'numVolumes
        '
        Me.numVolumes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numVolumes.Location = New System.Drawing.Point(22, 173)
        Me.numVolumes.Name = "numVolumes"
        Me.numVolumes.ReadOnly = True
        Me.numVolumes.Size = New System.Drawing.Size(112, 21)
        Me.numVolumes.TabIndex = 48
        Me.numVolumes.Text = "xxxx"
        '
        'numVolumesLabel
        '
        Me.numVolumesLabel.AutoSize = True
        Me.numVolumesLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numVolumesLabel.Location = New System.Drawing.Point(19, 157)
        Me.numVolumesLabel.Name = "numVolumesLabel"
        Me.numVolumesLabel.Size = New System.Drawing.Size(89, 13)
        Me.numVolumesLabel.TabIndex = 49
        Me.numVolumesLabel.Text = "Num. Volumes"
        '
        'numBlocks
        '
        Me.numBlocks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numBlocks.Location = New System.Drawing.Point(22, 221)
        Me.numBlocks.Name = "numBlocks"
        Me.numBlocks.ReadOnly = True
        Me.numBlocks.Size = New System.Drawing.Size(112, 21)
        Me.numBlocks.TabIndex = 50
        Me.numBlocks.Text = "xxxx"
        '
        'numBlocksLabel
        '
        Me.numBlocksLabel.AutoSize = True
        Me.numBlocksLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numBlocksLabel.Location = New System.Drawing.Point(19, 205)
        Me.numBlocksLabel.Name = "numBlocksLabel"
        Me.numBlocksLabel.Size = New System.Drawing.Size(78, 13)
        Me.numBlocksLabel.TabIndex = 51
        Me.numBlocksLabel.Text = "Num. Blocks"
        '
        'numTransactions
        '
        Me.numTransactions.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numTransactions.Location = New System.Drawing.Point(22, 270)
        Me.numTransactions.Name = "numTransactions"
        Me.numTransactions.ReadOnly = True
        Me.numTransactions.Size = New System.Drawing.Size(112, 21)
        Me.numTransactions.TabIndex = 52
        Me.numTransactions.Text = "xxxx"
        '
        'numTransactionsLabel
        '
        Me.numTransactionsLabel.AutoSize = True
        Me.numTransactionsLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numTransactionsLabel.Location = New System.Drawing.Point(19, 254)
        Me.numTransactionsLabel.Name = "numTransactionsLabel"
        Me.numTransactionsLabel.Size = New System.Drawing.Size(112, 13)
        Me.numTransactionsLabel.TabIndex = 53
        Me.numTransactionsLabel.Text = "Num. Transactions"
        '
        'latestTransaction
        '
        Me.latestTransaction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latestTransaction.Location = New System.Drawing.Point(22, 318)
        Me.latestTransaction.Name = "latestTransaction"
        Me.latestTransaction.ReadOnly = True
        Me.latestTransaction.Size = New System.Drawing.Size(310, 21)
        Me.latestTransaction.TabIndex = 54
        Me.latestTransaction.Text = "xxxx"
        '
        'latestTransactionLabel
        '
        Me.latestTransactionLabel.AutoSize = True
        Me.latestTransactionLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latestTransactionLabel.Location = New System.Drawing.Point(19, 302)
        Me.latestTransactionLabel.Name = "latestTransactionLabel"
        Me.latestTransactionLabel.Size = New System.Drawing.Size(108, 13)
        Me.latestTransactionLabel.TabIndex = 55
        Me.latestTransactionLabel.Text = "Latest transaction"
        '
        'SummaryLedgerPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.latestTransaction)
        Me.Controls.Add(Me.latestTransactionLabel)
        Me.Controls.Add(Me.numTransactions)
        Me.Controls.Add(Me.numTransactionsLabel)
        Me.Controls.Add(Me.numBlocks)
        Me.Controls.Add(Me.numBlocksLabel)
        Me.Controls.Add(Me.numVolumes)
        Me.Controls.Add(Me.numVolumesLabel)
        Me.Controls.Add(Me.lastUpdateTimeStamp)
        Me.Controls.Add(Me.lastUpdateTimeStampLabel)
        Me.Controls.Add(Me.createLedgerTimeStamp)
        Me.Controls.Add(Me.createLedgerTimeStampLabel)
        Me.Controls.Add(Me.identityBlockChain)
        Me.Controls.Add(Me.identityLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SummaryLedgerPanel"
        Me.Size = New System.Drawing.Size(750, 400)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents identityBlockChain As TextBox
    Friend WithEvents identityLabel As Label
    Friend WithEvents createLedgerTimeStamp As TextBox
    Friend WithEvents createLedgerTimeStampLabel As Label
    Friend WithEvents lastUpdateTimeStamp As TextBox
    Friend WithEvents lastUpdateTimeStampLabel As Label
    Friend WithEvents numVolumes As TextBox
    Friend WithEvents numVolumesLabel As Label
    Friend WithEvents numBlocks As TextBox
    Friend WithEvents numBlocksLabel As Label
    Friend WithEvents numTransactions As TextBox
    Friend WithEvents numTransactionsLabel As Label
    Friend WithEvents latestTransaction As TextBox
    Friend WithEvents latestTransactionLabel As Label
End Class
