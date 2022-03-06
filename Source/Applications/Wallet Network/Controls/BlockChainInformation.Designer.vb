<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ledgerPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ledgerPanel))
        Me.titleControl = New System.Windows.Forms.Label()
        Me.backButton = New System.Windows.Forms.Button()
        Me.transactionDetailData = New CHCWalletNetwork.TransactionDetail()
        Me.ledgerPageData = New CHCWalletNetwork.LedgerPage()
        Me.summaryData = New CHCWalletNetwork.SummaryLedgerPanel()
        Me.contentInformationPanel = New CHCWalletNetwork.ContentInformation()
        Me.SuspendLayout()
        '
        'titleControl
        '
        Me.titleControl.AutoSize = True
        Me.titleControl.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleControl.Location = New System.Drawing.Point(37, 4)
        Me.titleControl.Name = "titleControl"
        Me.titleControl.Size = New System.Drawing.Size(158, 25)
        Me.titleControl.TabIndex = 14
        Me.titleControl.Text = "Ledger View"
        '
        'backButton
        '
        Me.backButton.Enabled = False
        Me.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.backButton.Image = CType(resources.GetObject("backButton.Image"), System.Drawing.Image)
        Me.backButton.Location = New System.Drawing.Point(9, 5)
        Me.backButton.Name = "backButton"
        Me.backButton.Size = New System.Drawing.Size(22, 27)
        Me.backButton.TabIndex = 18
        Me.backButton.UseVisualStyleBackColor = True
        '
        'transactionDetailData
        '
        Me.transactionDetailData.BackColor = System.Drawing.Color.White
        Me.transactionDetailData.Location = New System.Drawing.Point(9, 199)
        Me.transactionDetailData.Name = "transactionDetailData"
        Me.transactionDetailData.Size = New System.Drawing.Size(426, 243)
        Me.transactionDetailData.TabIndex = 17
        Me.transactionDetailData.Visible = False
        '
        'ledgerPageData
        '
        Me.ledgerPageData.BackColor = System.Drawing.Color.White
        Me.ledgerPageData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ledgerPageData.Location = New System.Drawing.Point(374, 35)
        Me.ledgerPageData.Name = "ledgerPageData"
        Me.ledgerPageData.Size = New System.Drawing.Size(382, 158)
        Me.ledgerPageData.TabIndex = 16
        Me.ledgerPageData.Visible = False
        '
        'summaryData
        '
        Me.summaryData.BackColor = System.Drawing.Color.White
        Me.summaryData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.summaryData.Location = New System.Drawing.Point(0, 35)
        Me.summaryData.Name = "summaryData"
        Me.summaryData.Size = New System.Drawing.Size(341, 158)
        Me.summaryData.TabIndex = 15
        '
        'contentInformationPanel
        '
        Me.contentInformationPanel.BackColor = System.Drawing.Color.White
        Me.contentInformationPanel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contentInformationPanel.Location = New System.Drawing.Point(451, 199)
        Me.contentInformationPanel.Name = "contentInformationPanel"
        Me.contentInformationPanel.Size = New System.Drawing.Size(291, 243)
        Me.contentInformationPanel.TabIndex = 19
        '
        'ledgerPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.contentInformationPanel)
        Me.Controls.Add(Me.backButton)
        Me.Controls.Add(Me.transactionDetailData)
        Me.Controls.Add(Me.ledgerPageData)
        Me.Controls.Add(Me.summaryData)
        Me.Controls.Add(Me.titleControl)
        Me.Name = "ledgerPanel"
        Me.Size = New System.Drawing.Size(759, 462)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titleControl As Label
    Friend WithEvents summaryData As SummaryLedgerPanel
    Friend WithEvents ledgerPageData As LedgerPage
    Friend WithEvents transactionDetailData As TransactionDetail
    Friend WithEvents backButton As Button
    Friend WithEvents contentInformationPanel As ContentInformation
End Class
