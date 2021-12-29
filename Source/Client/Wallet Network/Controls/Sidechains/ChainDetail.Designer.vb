<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChainDetail
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
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.dataTab = New System.Windows.Forms.TabPage()
        Me.contentPanel = New CHCWalletNetwork.ContentInformation()
        Me.priceListPanel = New CHCWalletNetwork.PriceListChain()
        Me.setProtocolChain = New CHCWalletNetwork.ProtocolChain()
        Me.parameterChainData = New CHCWalletNetwork.ParameterChain()
        Me.lastBlockData = New CHCWalletNetwork.LastBlockChain()
        Me.mainDataChain = New CHCWalletNetwork.MainChain()
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
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.dataTab)
        Me.mainTab.Controls.Add(Me.integrityTab)
        Me.mainTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainTab.Location = New System.Drawing.Point(0, 0)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(759, 427)
        Me.mainTab.TabIndex = 2
        '
        'dataTab
        '
        Me.dataTab.Controls.Add(Me.contentPanel)
        Me.dataTab.Controls.Add(Me.priceListPanel)
        Me.dataTab.Controls.Add(Me.setProtocolChain)
        Me.dataTab.Controls.Add(Me.parameterChainData)
        Me.dataTab.Controls.Add(Me.lastBlockData)
        Me.dataTab.Controls.Add(Me.mainDataChain)
        Me.dataTab.Location = New System.Drawing.Point(4, 22)
        Me.dataTab.Name = "dataTab"
        Me.dataTab.Padding = New System.Windows.Forms.Padding(3)
        Me.dataTab.Size = New System.Drawing.Size(751, 401)
        Me.dataTab.TabIndex = 0
        Me.dataTab.Text = "Data"
        Me.dataTab.UseVisualStyleBackColor = True
        '
        'contentPanel
        '
        Me.contentPanel.BackColor = System.Drawing.Color.White
        Me.contentPanel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contentPanel.Location = New System.Drawing.Point(564, 211)
        Me.contentPanel.Name = "contentPanel"
        Me.contentPanel.Size = New System.Drawing.Size(181, 166)
        Me.contentPanel.TabIndex = 5
        '
        'priceListPanel
        '
        Me.priceListPanel.BackColor = System.Drawing.Color.White
        Me.priceListPanel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.priceListPanel.Location = New System.Drawing.Point(268, 203)
        Me.priceListPanel.Name = "priceListPanel"
        Me.priceListPanel.Size = New System.Drawing.Size(290, 174)
        Me.priceListPanel.TabIndex = 4
        Me.priceListPanel.Visible = False
        '
        'setProtocolChain
        '
        Me.setProtocolChain.BackColor = System.Drawing.Color.White
        Me.setProtocolChain.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.setProtocolChain.Location = New System.Drawing.Point(28, 194)
        Me.setProtocolChain.Name = "setProtocolChain"
        Me.setProtocolChain.Size = New System.Drawing.Size(217, 183)
        Me.setProtocolChain.TabIndex = 3
        '
        'parameterChainData
        '
        Me.parameterChainData.BackColor = System.Drawing.Color.White
        Me.parameterChainData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.parameterChainData.Location = New System.Drawing.Point(316, 97)
        Me.parameterChainData.Name = "parameterChainData"
        Me.parameterChainData.Size = New System.Drawing.Size(329, 98)
        Me.parameterChainData.TabIndex = 2
        Me.parameterChainData.Visible = False
        '
        'lastBlockData
        '
        Me.lastBlockData.BackColor = System.Drawing.Color.White
        Me.lastBlockData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastBlockData.Location = New System.Drawing.Point(297, 7)
        Me.lastBlockData.Name = "lastBlockData"
        Me.lastBlockData.Size = New System.Drawing.Size(359, 91)
        Me.lastBlockData.TabIndex = 1
        Me.lastBlockData.Visible = False
        '
        'mainDataChain
        '
        Me.mainDataChain.BackColor = System.Drawing.Color.White
        Me.mainDataChain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainDataChain.Location = New System.Drawing.Point(7, 7)
        Me.mainDataChain.Name = "mainDataChain"
        Me.mainDataChain.Size = New System.Drawing.Size(284, 165)
        Me.mainDataChain.TabIndex = 0
        Me.mainDataChain.Visible = False
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
        Me.integrityTab.Size = New System.Drawing.Size(751, 401)
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
        Me.hash.Size = New System.Drawing.Size(655, 21)
        Me.hash.TabIndex = 46
        Me.hash.Text = "xxxx"
        '
        'hashLabel
        '
        Me.hashLabel.AutoSize = True
        Me.hashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hashLabel.Location = New System.Drawing.Point(29, 115)
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
        Me.responseTime.Size = New System.Drawing.Size(655, 21)
        Me.responseTime.TabIndex = 44
        Me.responseTime.Text = "xxxx"
        '
        'responseTimeLabel
        '
        Me.responseTimeLabel.AutoSize = True
        Me.responseTimeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTimeLabel.Location = New System.Drawing.Point(29, 216)
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
        Me.coordinate.Size = New System.Drawing.Size(655, 21)
        Me.coordinate.TabIndex = 42
        Me.coordinate.Text = "xxxx"
        '
        'coordinateLabel
        '
        Me.coordinateLabel.AutoSize = True
        Me.coordinateLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.coordinateLabel.Location = New System.Drawing.Point(29, 21)
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
        Me.progressiveHash.Size = New System.Drawing.Size(655, 21)
        Me.progressiveHash.TabIndex = 40
        Me.progressiveHash.Text = "xxxx"
        '
        'progressiveHashLabel
        '
        Me.progressiveHashLabel.AutoSize = True
        Me.progressiveHashLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.progressiveHashLabel.Location = New System.Drawing.Point(29, 165)
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
        Me.registrationTimeStamp.Size = New System.Drawing.Size(655, 21)
        Me.registrationTimeStamp.TabIndex = 38
        Me.registrationTimeStamp.Text = "xxxx"
        '
        'registrationTimeStampLabel
        '
        Me.registrationTimeStampLabel.AutoSize = True
        Me.registrationTimeStampLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registrationTimeStampLabel.Location = New System.Drawing.Point(29, 68)
        Me.registrationTimeStampLabel.Name = "registrationTimeStampLabel"
        Me.registrationTimeStampLabel.Size = New System.Drawing.Size(142, 13)
        Me.registrationTimeStampLabel.TabIndex = 39
        Me.registrationTimeStampLabel.Text = "Registration Timestamp"
        '
        'ChainDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.mainTab)
        Me.Name = "ChainDetail"
        Me.Size = New System.Drawing.Size(759, 427)
        Me.mainTab.ResumeLayout(False)
        Me.dataTab.ResumeLayout(False)
        Me.integrityTab.ResumeLayout(False)
        Me.integrityTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTab As TabControl
    Friend WithEvents dataTab As TabPage
    Friend WithEvents integrityTab As TabPage
    Friend WithEvents hash As TextBox
    Friend WithEvents hashLabel As Label
    Friend WithEvents responseTime As TextBox
    Friend WithEvents responseTimeLabel As Label
    Friend WithEvents coordinate As TextBox
    Friend WithEvents coordinateLabel As Label
    Friend WithEvents progressiveHash As TextBox
    Friend WithEvents progressiveHashLabel As Label
    Friend WithEvents registrationTimeStamp As TextBox
    Friend WithEvents registrationTimeStampLabel As Label
    Friend WithEvents mainDataChain As MainChain
    Friend WithEvents lastBlockData As LastBlockChain
    Friend WithEvents parameterChainData As ParameterChain
    Friend WithEvents setProtocolChain As ProtocolChain
    Friend WithEvents priceListPanel As PriceListChain
    Friend WithEvents contentPanel As ContentInformation
End Class
