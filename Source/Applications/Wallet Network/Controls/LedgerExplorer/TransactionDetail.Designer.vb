<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionDetail
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
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.generalPage = New System.Windows.Forms.TabPage()
        Me.orderHash = New System.Windows.Forms.LinkLabel()
        Me.specificDetail = New System.Windows.Forms.LinkLabel()
        Me.specificDetailLabel = New System.Windows.Forms.Label()
        Me.orderHashLabel = New System.Windows.Forms.Label()
        Me.validator = New System.Windows.Forms.TextBox()
        Me.validatorLabel = New System.Windows.Forms.Label()
        Me.orderer = New System.Windows.Forms.TextBox()
        Me.ordererLabel = New System.Windows.Forms.Label()
        Me.classTransaction = New System.Windows.Forms.TextBox()
        Me.classLabel = New System.Windows.Forms.Label()
        Me.registrationTimeStamp = New System.Windows.Forms.TextBox()
        Me.registrationTimeStampLabel = New System.Windows.Forms.Label()
        Me.completeID = New System.Windows.Forms.TextBox()
        Me.completeIDLabel = New System.Windows.Forms.Label()
        Me.integrityPage = New System.Windows.Forms.TabPage()
        Me.cumulativeHash = New System.Windows.Forms.TextBox()
        Me.cumulativeHashLabel = New System.Windows.Forms.Label()
        Me.transactionHash = New System.Windows.Forms.TextBox()
        Me.transactionHashLabel = New System.Windows.Forms.Label()
        Me.consensusHashLabel = New System.Windows.Forms.Label()
        Me.consensusHash = New System.Windows.Forms.LinkLabel()
        Me.mainTab.SuspendLayout()
        Me.generalPage.SuspendLayout()
        Me.integrityPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.generalPage)
        Me.mainTab.Controls.Add(Me.integrityPage)
        Me.mainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainTab.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainTab.Location = New System.Drawing.Point(0, 0)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(750, 400)
        Me.mainTab.TabIndex = 0
        '
        'generalPage
        '
        Me.generalPage.Controls.Add(Me.orderHash)
        Me.generalPage.Controls.Add(Me.specificDetail)
        Me.generalPage.Controls.Add(Me.specificDetailLabel)
        Me.generalPage.Controls.Add(Me.orderHashLabel)
        Me.generalPage.Controls.Add(Me.validator)
        Me.generalPage.Controls.Add(Me.validatorLabel)
        Me.generalPage.Controls.Add(Me.orderer)
        Me.generalPage.Controls.Add(Me.ordererLabel)
        Me.generalPage.Controls.Add(Me.classTransaction)
        Me.generalPage.Controls.Add(Me.classLabel)
        Me.generalPage.Controls.Add(Me.registrationTimeStamp)
        Me.generalPage.Controls.Add(Me.registrationTimeStampLabel)
        Me.generalPage.Controls.Add(Me.completeID)
        Me.generalPage.Controls.Add(Me.completeIDLabel)
        Me.generalPage.Location = New System.Drawing.Point(4, 22)
        Me.generalPage.Name = "generalPage"
        Me.generalPage.Padding = New System.Windows.Forms.Padding(3)
        Me.generalPage.Size = New System.Drawing.Size(742, 374)
        Me.generalPage.TabIndex = 0
        Me.generalPage.Text = "General"
        Me.generalPage.UseVisualStyleBackColor = True
        '
        'orderHash
        '
        Me.orderHash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.orderHash.BackColor = System.Drawing.SystemColors.Control
        Me.orderHash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.orderHash.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.orderHash.Location = New System.Drawing.Point(154, 196)
        Me.orderHash.Name = "orderHash"
        Me.orderHash.Size = New System.Drawing.Size(553, 21)
        Me.orderHash.TabIndex = 81
        Me.orderHash.TabStop = True
        Me.orderHash.Text = "xxx"
        '
        'specificDetail
        '
        Me.specificDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.specificDetail.BackColor = System.Drawing.SystemColors.Control
        Me.specificDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.specificDetail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.specificDetail.Location = New System.Drawing.Point(154, 223)
        Me.specificDetail.Name = "specificDetail"
        Me.specificDetail.Size = New System.Drawing.Size(553, 103)
        Me.specificDetail.TabIndex = 80
        Me.specificDetail.TabStop = True
        Me.specificDetail.Text = "xxx"
        '
        'specificDetailLabel
        '
        Me.specificDetailLabel.AutoSize = True
        Me.specificDetailLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.specificDetailLabel.Location = New System.Drawing.Point(61, 226)
        Me.specificDetailLabel.Name = "specificDetailLabel"
        Me.specificDetailLabel.Size = New System.Drawing.Size(86, 13)
        Me.specificDetailLabel.TabIndex = 79
        Me.specificDetailLabel.Text = "Specific detail"
        '
        'orderHashLabel
        '
        Me.orderHashLabel.AutoSize = True
        Me.orderHashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orderHashLabel.Location = New System.Drawing.Point(77, 199)
        Me.orderHashLabel.Name = "orderHashLabel"
        Me.orderHashLabel.Size = New System.Drawing.Size(71, 13)
        Me.orderHashLabel.TabIndex = 77
        Me.orderHashLabel.Text = "Order hash"
        '
        'validator
        '
        Me.validator.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.validator.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.validator.Location = New System.Drawing.Point(154, 151)
        Me.validator.MinimumSize = New System.Drawing.Size(247, 21)
        Me.validator.Multiline = True
        Me.validator.Name = "validator"
        Me.validator.ReadOnly = True
        Me.validator.Size = New System.Drawing.Size(553, 39)
        Me.validator.TabIndex = 74
        Me.validator.Text = "xxx"
        '
        'validatorLabel
        '
        Me.validatorLabel.AutoSize = True
        Me.validatorLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.validatorLabel.Location = New System.Drawing.Point(91, 154)
        Me.validatorLabel.Name = "validatorLabel"
        Me.validatorLabel.Size = New System.Drawing.Size(57, 13)
        Me.validatorLabel.TabIndex = 75
        Me.validatorLabel.Text = "Validator"
        '
        'orderer
        '
        Me.orderer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.orderer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orderer.Location = New System.Drawing.Point(154, 106)
        Me.orderer.MinimumSize = New System.Drawing.Size(247, 21)
        Me.orderer.Multiline = True
        Me.orderer.Name = "orderer"
        Me.orderer.ReadOnly = True
        Me.orderer.Size = New System.Drawing.Size(553, 39)
        Me.orderer.TabIndex = 72
        Me.orderer.Text = "xxx"
        '
        'ordererLabel
        '
        Me.ordererLabel.AutoSize = True
        Me.ordererLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ordererLabel.Location = New System.Drawing.Point(96, 109)
        Me.ordererLabel.Name = "ordererLabel"
        Me.ordererLabel.Size = New System.Drawing.Size(52, 13)
        Me.ordererLabel.TabIndex = 73
        Me.ordererLabel.Text = "Orderer"
        '
        'classTransaction
        '
        Me.classTransaction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.classTransaction.Location = New System.Drawing.Point(154, 79)
        Me.classTransaction.Name = "classTransaction"
        Me.classTransaction.ReadOnly = True
        Me.classTransaction.Size = New System.Drawing.Size(149, 21)
        Me.classTransaction.TabIndex = 70
        Me.classTransaction.Text = "xxx"
        '
        'classLabel
        '
        Me.classLabel.AutoSize = True
        Me.classLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.classLabel.Location = New System.Drawing.Point(110, 82)
        Me.classLabel.Name = "classLabel"
        Me.classLabel.Size = New System.Drawing.Size(38, 13)
        Me.classLabel.TabIndex = 71
        Me.classLabel.Text = "Class"
        '
        'registrationTimeStamp
        '
        Me.registrationTimeStamp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registrationTimeStamp.Location = New System.Drawing.Point(154, 52)
        Me.registrationTimeStamp.Name = "registrationTimeStamp"
        Me.registrationTimeStamp.ReadOnly = True
        Me.registrationTimeStamp.Size = New System.Drawing.Size(149, 21)
        Me.registrationTimeStamp.TabIndex = 68
        Me.registrationTimeStamp.Text = "xxx"
        '
        'registrationTimeStampLabel
        '
        Me.registrationTimeStampLabel.AutoSize = True
        Me.registrationTimeStampLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registrationTimeStampLabel.Location = New System.Drawing.Point(6, 55)
        Me.registrationTimeStampLabel.Name = "registrationTimeStampLabel"
        Me.registrationTimeStampLabel.Size = New System.Drawing.Size(142, 13)
        Me.registrationTimeStampLabel.TabIndex = 69
        Me.registrationTimeStampLabel.Text = "Registration Timestamp"
        '
        'completeID
        '
        Me.completeID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.completeID.Location = New System.Drawing.Point(154, 25)
        Me.completeID.Name = "completeID"
        Me.completeID.ReadOnly = True
        Me.completeID.Size = New System.Drawing.Size(149, 21)
        Me.completeID.TabIndex = 66
        Me.completeID.Text = "xxx"
        '
        'completeIDLabel
        '
        Me.completeIDLabel.AutoSize = True
        Me.completeIDLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.completeIDLabel.Location = New System.Drawing.Point(61, 28)
        Me.completeIDLabel.Name = "completeIDLabel"
        Me.completeIDLabel.Size = New System.Drawing.Size(87, 13)
        Me.completeIDLabel.TabIndex = 67
        Me.completeIDLabel.Text = "Complete ID"
        '
        'integrityPage
        '
        Me.integrityPage.Controls.Add(Me.consensusHash)
        Me.integrityPage.Controls.Add(Me.cumulativeHash)
        Me.integrityPage.Controls.Add(Me.cumulativeHashLabel)
        Me.integrityPage.Controls.Add(Me.transactionHash)
        Me.integrityPage.Controls.Add(Me.transactionHashLabel)
        Me.integrityPage.Controls.Add(Me.consensusHashLabel)
        Me.integrityPage.Location = New System.Drawing.Point(4, 22)
        Me.integrityPage.Name = "integrityPage"
        Me.integrityPage.Padding = New System.Windows.Forms.Padding(3)
        Me.integrityPage.Size = New System.Drawing.Size(742, 374)
        Me.integrityPage.TabIndex = 1
        Me.integrityPage.Text = "Integrity"
        Me.integrityPage.UseVisualStyleBackColor = True
        '
        'cumulativeHash
        '
        Me.cumulativeHash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cumulativeHash.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cumulativeHash.Location = New System.Drawing.Point(154, 79)
        Me.cumulativeHash.Name = "cumulativeHash"
        Me.cumulativeHash.ReadOnly = True
        Me.cumulativeHash.Size = New System.Drawing.Size(553, 21)
        Me.cumulativeHash.TabIndex = 72
        Me.cumulativeHash.Text = "xxx"
        '
        'cumulativeHashLabel
        '
        Me.cumulativeHashLabel.AutoSize = True
        Me.cumulativeHashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cumulativeHashLabel.Location = New System.Drawing.Point(44, 82)
        Me.cumulativeHashLabel.Name = "cumulativeHashLabel"
        Me.cumulativeHashLabel.Size = New System.Drawing.Size(104, 13)
        Me.cumulativeHashLabel.TabIndex = 73
        Me.cumulativeHashLabel.Text = "Cumulative Hash"
        '
        'transactionHash
        '
        Me.transactionHash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.transactionHash.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transactionHash.Location = New System.Drawing.Point(154, 52)
        Me.transactionHash.Name = "transactionHash"
        Me.transactionHash.ReadOnly = True
        Me.transactionHash.Size = New System.Drawing.Size(553, 21)
        Me.transactionHash.TabIndex = 70
        Me.transactionHash.Text = "xxx"
        '
        'transactionHashLabel
        '
        Me.transactionHashLabel.AutoSize = True
        Me.transactionHashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transactionHashLabel.Location = New System.Drawing.Point(44, 55)
        Me.transactionHashLabel.Name = "transactionHashLabel"
        Me.transactionHashLabel.Size = New System.Drawing.Size(104, 13)
        Me.transactionHashLabel.TabIndex = 71
        Me.transactionHashLabel.Text = "Transaction Hash"
        '
        'consensusHashLabel
        '
        Me.consensusHashLabel.AutoSize = True
        Me.consensusHashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consensusHashLabel.Location = New System.Drawing.Point(47, 28)
        Me.consensusHashLabel.Name = "consensusHashLabel"
        Me.consensusHashLabel.Size = New System.Drawing.Size(101, 13)
        Me.consensusHashLabel.TabIndex = 69
        Me.consensusHashLabel.Text = "Consensus Hash"
        '
        'consensusHash
        '
        Me.consensusHash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.consensusHash.BackColor = System.Drawing.SystemColors.Control
        Me.consensusHash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.consensusHash.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.consensusHash.Location = New System.Drawing.Point(154, 25)
        Me.consensusHash.Name = "consensusHash"
        Me.consensusHash.Size = New System.Drawing.Size(553, 21)
        Me.consensusHash.TabIndex = 82
        Me.consensusHash.TabStop = True
        Me.consensusHash.Text = "xxx"
        '
        'TransactionDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.mainTab)
        Me.Name = "TransactionDetail"
        Me.Size = New System.Drawing.Size(750, 400)
        Me.mainTab.ResumeLayout(False)
        Me.generalPage.ResumeLayout(False)
        Me.generalPage.PerformLayout()
        Me.integrityPage.ResumeLayout(False)
        Me.integrityPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTab As TabControl
    Friend WithEvents generalPage As TabPage
    Friend WithEvents integrityPage As TabPage
    Private WithEvents specificDetailLabel As Label
    Private WithEvents orderHashLabel As Label
    Friend WithEvents validator As TextBox
    Private WithEvents validatorLabel As Label
    Friend WithEvents orderer As TextBox
    Private WithEvents ordererLabel As Label
    Friend WithEvents classTransaction As TextBox
    Private WithEvents classLabel As Label
    Friend WithEvents registrationTimeStamp As TextBox
    Private WithEvents registrationTimeStampLabel As Label
    Friend WithEvents completeID As TextBox
    Private WithEvents completeIDLabel As Label
    Friend WithEvents cumulativeHash As TextBox
    Private WithEvents cumulativeHashLabel As Label
    Friend WithEvents transactionHash As TextBox
    Private WithEvents transactionHashLabel As Label
    Private WithEvents consensusHashLabel As Label
    Friend WithEvents specificDetail As LinkLabel
    Friend WithEvents orderHash As LinkLabel
    Friend WithEvents consensusHash As LinkLabel
End Class
