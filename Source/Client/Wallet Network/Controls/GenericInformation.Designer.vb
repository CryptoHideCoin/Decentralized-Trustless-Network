<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GenericInformation
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.titlePage = New System.Windows.Forms.Label()
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.dataTab = New System.Windows.Forms.TabPage()
        Me.refundPlanContent = New CHCWalletNetwork.RefundPlanInformation()
        Me.transactionChainContent = New CHCWalletNetwork.TransactionChainInformation()
        Me.assetContent = New CHCWalletNetwork.AssetInformation()
        Me.documentContent = New CHCWalletNetwork.ContentInformation()
        Me.networkContent = New CHCWalletNetwork.NetworkInformation()
        Me.integrityTab = New System.Windows.Forms.TabPage()
        Me.hash = New System.Windows.Forms.TextBox()
        Me.hashLabel = New System.Windows.Forms.Label()
        Me.responseTime = New System.Windows.Forms.TextBox()
        Me.responseTimeLabel = New System.Windows.Forms.Label()
        Me.coordinate = New System.Windows.Forms.TextBox()
        Me.coordinateLabel = New System.Windows.Forms.Label()
        Me.progressiveHash = New System.Windows.Forms.TextBox()
        Me.progressiveHashLabel = New System.Windows.Forms.Label()
        Me.registrationTimeStamp = New System.Windows.Forms.TextBox()
        Me.registrationTimeStampLabel = New System.Windows.Forms.Label()
        Me.mainTab.SuspendLayout()
        Me.dataTab.SuspendLayout()
        Me.integrityTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'titlePage
        '
        Me.titlePage.AutoSize = True
        Me.titlePage.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titlePage.Location = New System.Drawing.Point(4, 4)
        Me.titlePage.Name = "titlePage"
        Me.titlePage.Size = New System.Drawing.Size(64, 25)
        Me.titlePage.TabIndex = 0
        Me.titlePage.Text = "Title"
        '
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.dataTab)
        Me.mainTab.Controls.Add(Me.integrityTab)
        Me.mainTab.Location = New System.Drawing.Point(9, 56)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(738, 403)
        Me.mainTab.TabIndex = 1
        '
        'dataTab
        '
        Me.dataTab.Controls.Add(Me.refundPlanContent)
        Me.dataTab.Controls.Add(Me.transactionChainContent)
        Me.dataTab.Controls.Add(Me.assetContent)
        Me.dataTab.Controls.Add(Me.documentContent)
        Me.dataTab.Controls.Add(Me.networkContent)
        Me.dataTab.Location = New System.Drawing.Point(4, 22)
        Me.dataTab.Name = "dataTab"
        Me.dataTab.Padding = New System.Windows.Forms.Padding(3)
        Me.dataTab.Size = New System.Drawing.Size(730, 377)
        Me.dataTab.TabIndex = 0
        Me.dataTab.Text = "Data"
        Me.dataTab.UseVisualStyleBackColor = True
        '
        'refundPlanContent
        '
        Me.refundPlanContent.BackColor = System.Drawing.Color.White
        Me.refundPlanContent.Location = New System.Drawing.Point(361, 6)
        Me.refundPlanContent.Name = "refundPlanContent"
        Me.refundPlanContent.Size = New System.Drawing.Size(348, 135)
        Me.refundPlanContent.TabIndex = 4
        '
        'transactionChainContent
        '
        Me.transactionChainContent.BackColor = System.Drawing.Color.White
        Me.transactionChainContent.Location = New System.Drawing.Point(19, 260)
        Me.transactionChainContent.Name = "transactionChainContent"
        Me.transactionChainContent.Size = New System.Drawing.Size(670, 95)
        Me.transactionChainContent.TabIndex = 3
        Me.transactionChainContent.Visible = False
        '
        'assetContent
        '
        Me.assetContent.BackColor = System.Drawing.Color.White
        Me.assetContent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assetContent.Location = New System.Drawing.Point(6, 128)
        Me.assetContent.Name = "assetContent"
        Me.assetContent.Size = New System.Drawing.Size(718, 126)
        Me.assetContent.TabIndex = 2
        '
        'documentContent
        '
        Me.documentContent.BackColor = System.Drawing.Color.White
        Me.documentContent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.documentContent.Location = New System.Drawing.Point(160, 6)
        Me.documentContent.Name = "documentContent"
        Me.documentContent.Size = New System.Drawing.Size(148, 105)
        Me.documentContent.TabIndex = 1
        '
        'networkContent
        '
        Me.networkContent.BackColor = System.Drawing.Color.White
        Me.networkContent.Location = New System.Drawing.Point(6, 6)
        Me.networkContent.Name = "networkContent"
        Me.networkContent.Size = New System.Drawing.Size(148, 105)
        Me.networkContent.TabIndex = 0
        Me.networkContent.Visible = False
        '
        'integrityTab
        '
        Me.integrityTab.Controls.Add(Me.hash)
        Me.integrityTab.Controls.Add(Me.hashLabel)
        Me.integrityTab.Controls.Add(Me.responseTime)
        Me.integrityTab.Controls.Add(Me.responseTimeLabel)
        Me.integrityTab.Controls.Add(Me.coordinate)
        Me.integrityTab.Controls.Add(Me.coordinateLabel)
        Me.integrityTab.Controls.Add(Me.progressiveHash)
        Me.integrityTab.Controls.Add(Me.progressiveHashLabel)
        Me.integrityTab.Controls.Add(Me.registrationTimeStamp)
        Me.integrityTab.Controls.Add(Me.registrationTimeStampLabel)
        Me.integrityTab.Location = New System.Drawing.Point(4, 22)
        Me.integrityTab.Name = "integrityTab"
        Me.integrityTab.Padding = New System.Windows.Forms.Padding(3)
        Me.integrityTab.Size = New System.Drawing.Size(730, 377)
        Me.integrityTab.TabIndex = 1
        Me.integrityTab.Text = "Integrity"
        Me.integrityTab.UseVisualStyleBackColor = True
        '
        'hash
        '
        Me.hash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hash.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hash.Location = New System.Drawing.Point(32, 131)
        Me.hash.Name = "hash"
        Me.hash.ReadOnly = True
        Me.hash.Size = New System.Drawing.Size(634, 21)
        Me.hash.TabIndex = 46
        Me.hash.Text = "xxxx"
        '
        'hashLabel
        '
        Me.hashLabel.AutoSize = True
        Me.hashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hashLabel.Location = New System.Drawing.Point(27, 115)
        Me.hashLabel.Name = "hashLabel"
        Me.hashLabel.Size = New System.Drawing.Size(35, 13)
        Me.hashLabel.TabIndex = 47
        Me.hashLabel.Text = "Hash"
        '
        'responseTime
        '
        Me.responseTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responseTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTime.Location = New System.Drawing.Point(32, 232)
        Me.responseTime.Name = "responseTime"
        Me.responseTime.ReadOnly = True
        Me.responseTime.Size = New System.Drawing.Size(634, 21)
        Me.responseTime.TabIndex = 44
        Me.responseTime.Text = "xxxx"
        '
        'responseTimeLabel
        '
        Me.responseTimeLabel.AutoSize = True
        Me.responseTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTimeLabel.Location = New System.Drawing.Point(27, 216)
        Me.responseTimeLabel.Name = "responseTimeLabel"
        Me.responseTimeLabel.Size = New System.Drawing.Size(94, 13)
        Me.responseTimeLabel.TabIndex = 45
        Me.responseTimeLabel.Text = "Response Time"
        '
        'coordinate
        '
        Me.coordinate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.coordinate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.coordinate.Location = New System.Drawing.Point(32, 37)
        Me.coordinate.Name = "coordinate"
        Me.coordinate.ReadOnly = True
        Me.coordinate.Size = New System.Drawing.Size(634, 21)
        Me.coordinate.TabIndex = 42
        Me.coordinate.Text = "xxxx"
        '
        'coordinateLabel
        '
        Me.coordinateLabel.AutoSize = True
        Me.coordinateLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.coordinateLabel.Location = New System.Drawing.Point(27, 21)
        Me.coordinateLabel.Name = "coordinateLabel"
        Me.coordinateLabel.Size = New System.Drawing.Size(70, 13)
        Me.coordinateLabel.TabIndex = 43
        Me.coordinateLabel.Text = "Coordinate"
        '
        'progressiveHash
        '
        Me.progressiveHash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressiveHash.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.progressiveHash.Location = New System.Drawing.Point(32, 181)
        Me.progressiveHash.Name = "progressiveHash"
        Me.progressiveHash.ReadOnly = True
        Me.progressiveHash.Size = New System.Drawing.Size(634, 21)
        Me.progressiveHash.TabIndex = 40
        Me.progressiveHash.Text = "xxxx"
        '
        'progressiveHashLabel
        '
        Me.progressiveHashLabel.AutoSize = True
        Me.progressiveHashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.progressiveHashLabel.Location = New System.Drawing.Point(27, 165)
        Me.progressiveHashLabel.Name = "progressiveHashLabel"
        Me.progressiveHashLabel.Size = New System.Drawing.Size(106, 13)
        Me.progressiveHashLabel.TabIndex = 41
        Me.progressiveHashLabel.Text = "Progressive Hash"
        '
        'registrationTimeStamp
        '
        Me.registrationTimeStamp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.registrationTimeStamp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registrationTimeStamp.Location = New System.Drawing.Point(32, 84)
        Me.registrationTimeStamp.Name = "registrationTimeStamp"
        Me.registrationTimeStamp.ReadOnly = True
        Me.registrationTimeStamp.Size = New System.Drawing.Size(634, 21)
        Me.registrationTimeStamp.TabIndex = 38
        Me.registrationTimeStamp.Text = "xxxx"
        '
        'registrationTimeStampLabel
        '
        Me.registrationTimeStampLabel.AutoSize = True
        Me.registrationTimeStampLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registrationTimeStampLabel.Location = New System.Drawing.Point(27, 68)
        Me.registrationTimeStampLabel.Name = "registrationTimeStampLabel"
        Me.registrationTimeStampLabel.Size = New System.Drawing.Size(142, 13)
        Me.registrationTimeStampLabel.TabIndex = 39
        Me.registrationTimeStampLabel.Text = "Registration Timestamp"
        '
        'GenericInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.mainTab)
        Me.Controls.Add(Me.titlePage)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "GenericInformation"
        Me.Size = New System.Drawing.Size(759, 462)
        Me.mainTab.ResumeLayout(False)
        Me.dataTab.ResumeLayout(False)
        Me.integrityTab.ResumeLayout(False)
        Me.integrityTab.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titlePage As Label
    Friend WithEvents mainTab As TabControl
    Friend WithEvents dataTab As TabPage
    Friend WithEvents integrityTab As TabPage
    Friend WithEvents networkContent As NetworkInformation
    Friend WithEvents coordinate As TextBox
    Friend WithEvents coordinateLabel As Label
    Friend WithEvents progressiveHash As TextBox
    Friend WithEvents progressiveHashLabel As Label
    Friend WithEvents registrationTimeStamp As TextBox
    Friend WithEvents registrationTimeStampLabel As Label
    Friend WithEvents documentContent As ContentInformation
    Friend WithEvents responseTime As TextBox
    Friend WithEvents responseTimeLabel As Label
    Friend WithEvents assetContent As AssetInformation
    Friend WithEvents transactionChainContent As TransactionChainInformation
    Friend WithEvents hash As TextBox
    Friend WithEvents hashLabel As Label
    Friend WithEvents refundPlanContent As RefundPlanInformation
End Class
