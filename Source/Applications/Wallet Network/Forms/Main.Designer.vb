<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.InfoMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NetworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneralInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhitepaperToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.YellowpaperToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssetPolicyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionChainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrivacyPolicyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TermsAndConditionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefundPlanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrentChainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LastBlockInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chainParametersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetProtocolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriceListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.privacyPolicyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TermsAndConditionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TokensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasternodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.supplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviousRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlockchainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.generalInformationsBlockChainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.monitorLedgerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dataLedgerContainer = New CHCWalletNetwork.ledgerPanel()
        Me.dataSupplyContainer = New CHCWalletNetwork.SupplyPanel()
        Me.dataChainContainer = New CHCWalletNetwork.Chains()
        Me.dataNetworkContainer = New CHCWalletNetwork.GenericInformation()
        Me.mainBackGround = New CHCWalletNetwork.Background()
        Me.InfoMenuStrip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InfoMenuStrip
        '
        Me.InfoMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationToolStripMenuItem, Me.ExplorerToolStripMenuItem, Me.CommandsToolStripMenuItem, Me.ToolStripMenuItem1, Me.BlockchainToolStripMenuItem})
        Me.InfoMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.InfoMenuStrip.Name = "InfoMenuStrip"
        Me.InfoMenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.InfoMenuStrip.Size = New System.Drawing.Size(800, 24)
        Me.InfoMenuStrip.TabIndex = 0
        Me.InfoMenuStrip.Text = "MenuStrip1"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationManagerToolStripMenuItem})
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.ConfigurationToolStripMenuItem.Text = "&Configuration"
        '
        'ConfigurationManagerToolStripMenuItem
        '
        Me.ConfigurationManagerToolStripMenuItem.Name = "ConfigurationManagerToolStripMenuItem"
        Me.ConfigurationManagerToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ConfigurationManagerToolStripMenuItem.Text = "C&onfiguration Manager"
        '
        'ExplorerToolStripMenuItem
        '
        Me.ExplorerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NetworkToolStripMenuItem, Me.ToolStripSeparator1, Me.ChainToolStripMenuItem, Me.CurrentChainToolStripMenuItem, Me.ToolStripSeparator4, Me.supplyToolStripMenuItem})
        Me.ExplorerToolStripMenuItem.Name = "ExplorerToolStripMenuItem"
        Me.ExplorerToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ExplorerToolStripMenuItem.Text = "Explorer"
        '
        'NetworkToolStripMenuItem
        '
        Me.NetworkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralInformationToolStripMenuItem, Me.WhitepaperToolStripMenuItem1, Me.YellowpaperToolStripMenuItem1, Me.AssetPolicyToolStripMenuItem, Me.TransactionChainToolStripMenuItem, Me.PrivacyPolicyToolStripMenuItem1, Me.TermsAndConditionsToolStripMenuItem1, Me.RefundPlanToolStripMenuItem1})
        Me.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem"
        Me.NetworkToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NetworkToolStripMenuItem.Text = "Network"
        '
        'GeneralInformationToolStripMenuItem
        '
        Me.GeneralInformationToolStripMenuItem.Name = "GeneralInformationToolStripMenuItem"
        Me.GeneralInformationToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GeneralInformationToolStripMenuItem.Text = "General information"
        '
        'WhitepaperToolStripMenuItem1
        '
        Me.WhitepaperToolStripMenuItem1.Name = "WhitepaperToolStripMenuItem1"
        Me.WhitepaperToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.WhitepaperToolStripMenuItem1.Text = "Whitepaper"
        '
        'YellowpaperToolStripMenuItem1
        '
        Me.YellowpaperToolStripMenuItem1.Name = "YellowpaperToolStripMenuItem1"
        Me.YellowpaperToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.YellowpaperToolStripMenuItem1.Text = "Yellowpaper"
        '
        'AssetPolicyToolStripMenuItem
        '
        Me.AssetPolicyToolStripMenuItem.Name = "AssetPolicyToolStripMenuItem"
        Me.AssetPolicyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AssetPolicyToolStripMenuItem.Text = "Asset Policy"
        '
        'TransactionChainToolStripMenuItem
        '
        Me.TransactionChainToolStripMenuItem.Name = "TransactionChainToolStripMenuItem"
        Me.TransactionChainToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TransactionChainToolStripMenuItem.Text = "Transaction Chain"
        '
        'PrivacyPolicyToolStripMenuItem1
        '
        Me.PrivacyPolicyToolStripMenuItem1.Name = "PrivacyPolicyToolStripMenuItem1"
        Me.PrivacyPolicyToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.PrivacyPolicyToolStripMenuItem1.Text = "Privacy Policy"
        '
        'TermsAndConditionsToolStripMenuItem1
        '
        Me.TermsAndConditionsToolStripMenuItem1.Name = "TermsAndConditionsToolStripMenuItem1"
        Me.TermsAndConditionsToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.TermsAndConditionsToolStripMenuItem1.Text = "General Conditions"
        '
        'RefundPlanToolStripMenuItem1
        '
        Me.RefundPlanToolStripMenuItem1.Name = "RefundPlanToolStripMenuItem1"
        Me.RefundPlanToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.RefundPlanToolStripMenuItem1.Text = "Refund Plan"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'ChainToolStripMenuItem
        '
        Me.ChainToolStripMenuItem.Name = "ChainToolStripMenuItem"
        Me.ChainToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ChainToolStripMenuItem.Text = "Sidechains"
        '
        'CurrentChainToolStripMenuItem
        '
        Me.CurrentChainToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LastBlockInformationToolStripMenuItem, Me.chainParametersToolStripMenuItem, Me.SetProtocolsToolStripMenuItem, Me.PriceListToolStripMenuItem, Me.privacyPolicyToolStripMenuItem, Me.TermsAndConditionsToolStripMenuItem, Me.TokensToolStripMenuItem, Me.MasternodesToolStripMenuItem})
        Me.CurrentChainToolStripMenuItem.Enabled = False
        Me.CurrentChainToolStripMenuItem.Name = "CurrentChainToolStripMenuItem"
        Me.CurrentChainToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.CurrentChainToolStripMenuItem.Text = "Current chain"
        '
        'LastBlockInformationToolStripMenuItem
        '
        Me.LastBlockInformationToolStripMenuItem.Name = "LastBlockInformationToolStripMenuItem"
        Me.LastBlockInformationToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.LastBlockInformationToolStripMenuItem.Text = "Active / Last block information"
        '
        'chainParametersToolStripMenuItem
        '
        Me.chainParametersToolStripMenuItem.Name = "chainParametersToolStripMenuItem"
        Me.chainParametersToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.chainParametersToolStripMenuItem.Text = "Parameters"
        '
        'SetProtocolsToolStripMenuItem
        '
        Me.SetProtocolsToolStripMenuItem.Name = "SetProtocolsToolStripMenuItem"
        Me.SetProtocolsToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.SetProtocolsToolStripMenuItem.Text = "Set Protocols"
        '
        'PriceListToolStripMenuItem
        '
        Me.PriceListToolStripMenuItem.Name = "PriceListToolStripMenuItem"
        Me.PriceListToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.PriceListToolStripMenuItem.Text = "Price list"
        '
        'privacyPolicyToolStripMenuItem
        '
        Me.privacyPolicyToolStripMenuItem.Name = "privacyPolicyToolStripMenuItem"
        Me.privacyPolicyToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.privacyPolicyToolStripMenuItem.Text = "Privacy Policy"
        '
        'TermsAndConditionsToolStripMenuItem
        '
        Me.TermsAndConditionsToolStripMenuItem.Name = "TermsAndConditionsToolStripMenuItem"
        Me.TermsAndConditionsToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.TermsAndConditionsToolStripMenuItem.Text = "Terms and conditions"
        '
        'TokensToolStripMenuItem
        '
        Me.TokensToolStripMenuItem.Name = "TokensToolStripMenuItem"
        Me.TokensToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.TokensToolStripMenuItem.Text = "Tokens"
        '
        'MasternodesToolStripMenuItem
        '
        Me.MasternodesToolStripMenuItem.Name = "MasternodesToolStripMenuItem"
        Me.MasternodesToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.MasternodesToolStripMenuItem.Text = "Masternodes"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(143, 6)
        '
        'supplyToolStripMenuItem
        '
        Me.supplyToolStripMenuItem.Name = "supplyToolStripMenuItem"
        Me.supplyToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.supplyToolStripMenuItem.Text = "Supply"
        '
        'CommandsToolStripMenuItem
        '
        Me.CommandsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviousRequestToolStripMenuItem, Me.ToolStripSeparator2, Me.NewRequestToolStripMenuItem})
        Me.CommandsToolStripMenuItem.Name = "CommandsToolStripMenuItem"
        Me.CommandsToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.CommandsToolStripMenuItem.Text = "Requests"
        Me.CommandsToolStripMenuItem.Visible = False
        '
        'PreviousRequestToolStripMenuItem
        '
        Me.PreviousRequestToolStripMenuItem.Name = "PreviousRequestToolStripMenuItem"
        Me.PreviousRequestToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PreviousRequestToolStripMenuItem.Text = "Previous Requests"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
        '
        'NewRequestToolStripMenuItem
        '
        Me.NewRequestToolStripMenuItem.Name = "NewRequestToolStripMenuItem"
        Me.NewRequestToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.NewRequestToolStripMenuItem.Text = "New Request"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'BlockchainToolStripMenuItem
        '
        Me.BlockchainToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.generalInformationsBlockChainToolStripMenuItem, Me.ToolStripSeparator3, Me.monitorLedgerToolStripMenuItem})
        Me.BlockchainToolStripMenuItem.Name = "BlockchainToolStripMenuItem"
        Me.BlockchainToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.BlockchainToolStripMenuItem.Text = "Ledger"
        '
        'generalInformationsBlockChainToolStripMenuItem
        '
        Me.generalInformationsBlockChainToolStripMenuItem.Name = "generalInformationsBlockChainToolStripMenuItem"
        Me.generalInformationsBlockChainToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.generalInformationsBlockChainToolStripMenuItem.Text = "General Informations"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(182, 6)
        Me.ToolStripSeparator3.Visible = False
        '
        'monitorLedgerToolStripMenuItem
        '
        Me.monitorLedgerToolStripMenuItem.Name = "monitorLedgerToolStripMenuItem"
        Me.monitorLedgerToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.monitorLedgerToolStripMenuItem.Text = "Monitor"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(800, 426)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'dataLedgerContainer
        '
        Me.dataLedgerContainer.BackColor = System.Drawing.Color.White
        Me.dataLedgerContainer.Location = New System.Drawing.Point(356, 152)
        Me.dataLedgerContainer.Name = "dataLedgerContainer"
        Me.dataLedgerContainer.Size = New System.Drawing.Size(432, 312)
        Me.dataLedgerContainer.TabIndex = 5
        Me.dataLedgerContainer.type = CHCWalletNetwork.ledgerPanel.ManageType.undefined
        '
        'dataSupplyContainer
        '
        Me.dataSupplyContainer.BackColor = System.Drawing.Color.White
        Me.dataSupplyContainer.Location = New System.Drawing.Point(14, 151)
        Me.dataSupplyContainer.Name = "dataSupplyContainer"
        Me.dataSupplyContainer.Size = New System.Drawing.Size(304, 313)
        Me.dataSupplyContainer.TabIndex = 4
        '
        'dataChainContainer
        '
        Me.dataChainContainer.BackColor = System.Drawing.Color.White
        Me.dataChainContainer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataChainContainer.Location = New System.Drawing.Point(537, 28)
        Me.dataChainContainer.Name = "dataChainContainer"
        Me.dataChainContainer.Size = New System.Drawing.Size(251, 118)
        Me.dataChainContainer.TabIndex = 3
        Me.dataChainContainer.type = CHCWalletNetwork.Chains.ManageType.undefined
        '
        'dataNetworkContainer
        '
        Me.dataNetworkContainer.BackColor = System.Drawing.Color.White
        Me.dataNetworkContainer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataNetworkContainer.Location = New System.Drawing.Point(271, 27)
        Me.dataNetworkContainer.Name = "dataNetworkContainer"
        Me.dataNetworkContainer.Size = New System.Drawing.Size(245, 118)
        Me.dataNetworkContainer.TabIndex = 2
        Me.dataNetworkContainer.type = CHCWalletNetwork.GenericInformation.ManageType.undefined
        Me.dataNetworkContainer.Visible = False
        '
        'mainBackGround
        '
        Me.mainBackGround.Location = New System.Drawing.Point(14, 27)
        Me.mainBackGround.Name = "mainBackGround"
        Me.mainBackGround.Size = New System.Drawing.Size(251, 119)
        Me.mainBackGround.TabIndex = 1
        Me.mainBackGround.Visible = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 466)
        Me.Controls.Add(Me.dataLedgerContainer)
        Me.Controls.Add(Me.dataSupplyContainer)
        Me.Controls.Add(Me.dataChainContainer)
        Me.Controls.Add(Me.dataNetworkContainer)
        Me.Controls.Add(Me.mainBackGround)
        Me.Controls.Add(Me.InfoMenuStrip)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.InfoMenuStrip
        Me.MinimumSize = New System.Drawing.Size(816, 505)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OXEANIX - Wallet Network - Crypto Hide Coin Decentralized Trustless"
        Me.InfoMenuStrip.ResumeLayout(False)
        Me.InfoMenuStrip.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InfoMenuStrip As MenuStrip
    Friend WithEvents ConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommandsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ConfigurationManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NetworkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneralInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WhitepaperToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents YellowpaperToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AssetPolicyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransactionChainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrivacyPolicyToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TermsAndConditionsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RefundPlanToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ChainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreviousRequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents NewRequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BlockchainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents monitorLedgerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mainBackGround As Background
    Friend WithEvents dataNetworkContainer As GenericInformation
    Friend WithEvents supplyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dataChainContainer As Chains
    Friend WithEvents CurrentChainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LastBlockInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents chainParametersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetProtocolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PriceListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents privacyPolicyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TermsAndConditionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TokensToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MasternodesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dataSupplyContainer As SupplyPanel
    Friend WithEvents generalInformationsBlockChainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dataLedgerContainer As ledgerPanel
End Class
