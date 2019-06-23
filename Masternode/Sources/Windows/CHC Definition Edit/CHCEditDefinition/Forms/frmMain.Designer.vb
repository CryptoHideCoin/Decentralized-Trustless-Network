<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpDateStart = New System.Windows.Forms.GroupBox()
        Me.lblHelpNetworkName = New System.Windows.Forms.Label()
        Me.chkSchedule = New System.Windows.Forms.CheckBox()
        Me.dtpStartNetwork = New System.Windows.Forms.DateTimePicker()
        Me.lblDateStartNetwork = New System.Windows.Forms.Label()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.lblSymbol = New System.Windows.Forms.Label()
        Me.txtShortName = New System.Windows.Forms.TextBox()
        Me.lblShortName = New System.Windows.Forms.Label()
        Me.txtCoinName = New System.Windows.Forms.TextBox()
        Me.lblCoinName = New System.Windows.Forms.Label()
        Me.txtNetworkName = New System.Windows.Forms.TextBox()
        Me.lblNetworkName = New System.Windows.Forms.Label()
        Me.tpCoin = New System.Windows.Forms.TabPage()
        Me.lblSymbol2 = New System.Windows.Forms.Label()
        Me.lblSymbol1 = New System.Windows.Forms.Label()
        Me.txtNumOfDecimal = New System.Windows.Forms.TextBox()
        Me.lblNumDecimal = New System.Windows.Forms.Label()
        Me.chkNoTotal = New System.Windows.Forms.CheckBox()
        Me.chkMintable = New System.Windows.Forms.CheckBox()
        Me.txtWalletPremined = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalCoin = New System.Windows.Forms.TextBox()
        Me.lblTotalCoin = New System.Windows.Forms.Label()
        Me.txtPremined = New System.Windows.Forms.TextBox()
        Me.lblPremined = New System.Windows.Forms.Label()
        Me.chkBurnable = New System.Windows.Forms.CheckBox()
        Me.tpNodeLayer = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMinDurateConsensus = New System.Windows.Forms.Label()
        Me.txtDurateNodeConsensus = New System.Windows.Forms.TextBox()
        Me.lblDurateNodeConsensus = New System.Windows.Forms.Label()
        Me.txtHourNodeConsensus = New System.Windows.Forms.TextBox()
        Me.lblHourNode = New System.Windows.Forms.Label()
        Me.txtCompletePath = New System.Windows.Forms.TextBox()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtIdentity = New System.Windows.Forms.TextBox()
        Me.lblIdentityCOIN = New System.Windows.Forms.Label()
        Me.tcMain.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.grpDateStart.SuspendLayout()
        Me.tpCoin.SuspendLayout()
        Me.tpNodeLayer.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.tpMain)
        Me.tcMain.Controls.Add(Me.tpCoin)
        Me.tcMain.Controls.Add(Me.tpNodeLayer)
        Me.tcMain.Location = New System.Drawing.Point(16, 111)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(479, 258)
        Me.tcMain.TabIndex = 2
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.cmbType)
        Me.tpMain.Controls.Add(Me.Label3)
        Me.tpMain.Controls.Add(Me.grpDateStart)
        Me.tpMain.Controls.Add(Me.txtSymbol)
        Me.tpMain.Controls.Add(Me.lblSymbol)
        Me.tpMain.Controls.Add(Me.txtShortName)
        Me.tpMain.Controls.Add(Me.lblShortName)
        Me.tpMain.Controls.Add(Me.txtCoinName)
        Me.tpMain.Controls.Add(Me.lblCoinName)
        Me.tpMain.Controls.Add(Me.txtNetworkName)
        Me.tpMain.Controls.Add(Me.lblNetworkName)
        Me.tpMain.Location = New System.Drawing.Point(4, 22)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(471, 232)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Definition"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'cmbType
        '
        Me.cmbType.Enabled = False
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"COIN", "TOKEN"})
        Me.cmbType.Location = New System.Drawing.Point(326, 31)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(127, 21)
        Me.cmbType.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(323, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Type"
        '
        'grpDateStart
        '
        Me.grpDateStart.Controls.Add(Me.lblHelpNetworkName)
        Me.grpDateStart.Controls.Add(Me.chkSchedule)
        Me.grpDateStart.Controls.Add(Me.dtpStartNetwork)
        Me.grpDateStart.Controls.Add(Me.lblDateStartNetwork)
        Me.grpDateStart.Location = New System.Drawing.Point(16, 120)
        Me.grpDateStart.Name = "grpDateStart"
        Me.grpDateStart.Size = New System.Drawing.Size(437, 93)
        Me.grpDateStart.TabIndex = 14
        Me.grpDateStart.TabStop = False
        '
        'lblHelpNetworkName
        '
        Me.lblHelpNetworkName.AutoSize = True
        Me.lblHelpNetworkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelpNetworkName.ForeColor = System.Drawing.Color.Olive
        Me.lblHelpNetworkName.Location = New System.Drawing.Point(268, 40)
        Me.lblHelpNetworkName.Name = "lblHelpNetworkName"
        Me.lblHelpNetworkName.Size = New System.Drawing.Size(57, 13)
        Me.lblHelpNetworkName.TabIndex = 17
        Me.lblHelpNetworkName.Text = "(local time)"
        '
        'chkSchedule
        '
        Me.chkSchedule.AutoSize = True
        Me.chkSchedule.BackColor = System.Drawing.SystemColors.Window
        Me.chkSchedule.Location = New System.Drawing.Point(15, 0)
        Me.chkSchedule.Name = "chkSchedule"
        Me.chkSchedule.Size = New System.Drawing.Size(114, 17)
        Me.chkSchedule.TabIndex = 5
        Me.chkSchedule.Text = "Schedute first start"
        Me.chkSchedule.UseVisualStyleBackColor = False
        '
        'dtpStartNetwork
        '
        Me.dtpStartNetwork.CustomFormat = "dddd dd MMMM yyyy - HH:mm:ss"
        Me.dtpStartNetwork.Enabled = False
        Me.dtpStartNetwork.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartNetwork.Location = New System.Drawing.Point(36, 55)
        Me.dtpStartNetwork.MinDate = New Date(2019, 1, 1, 0, 0, 0, 0)
        Me.dtpStartNetwork.Name = "dtpStartNetwork"
        Me.dtpStartNetwork.Size = New System.Drawing.Size(289, 20)
        Me.dtpStartNetwork.TabIndex = 6
        '
        'lblDateStartNetwork
        '
        Me.lblDateStartNetwork.AutoSize = True
        Me.lblDateStartNetwork.Enabled = False
        Me.lblDateStartNetwork.Location = New System.Drawing.Point(33, 38)
        Me.lblDateStartNetwork.Name = "lblDateStartNetwork"
        Me.lblDateStartNetwork.Size = New System.Drawing.Size(118, 13)
        Me.lblDateStartNetwork.TabIndex = 14
        Me.lblDateStartNetwork.Text = "Network date/time start"
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(401, 78)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(52, 20)
        Me.txtSymbol.TabIndex = 4
        Me.txtSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Location = New System.Drawing.Point(398, 62)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(41, 13)
        Me.lblSymbol.TabIndex = 10
        Me.lblSymbol.Text = "Symbol"
        '
        'txtShortName
        '
        Me.txtShortName.Location = New System.Drawing.Point(260, 79)
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.Size = New System.Drawing.Size(135, 20)
        Me.txtShortName.TabIndex = 3
        '
        'lblShortName
        '
        Me.lblShortName.AutoSize = True
        Me.lblShortName.Location = New System.Drawing.Point(257, 62)
        Me.lblShortName.Name = "lblShortName"
        Me.lblShortName.Size = New System.Drawing.Size(63, 13)
        Me.lblShortName.TabIndex = 8
        Me.lblShortName.Text = "Short Name"
        '
        'txtCoinName
        '
        Me.txtCoinName.Location = New System.Drawing.Point(16, 79)
        Me.txtCoinName.Name = "txtCoinName"
        Me.txtCoinName.Size = New System.Drawing.Size(238, 20)
        Me.txtCoinName.TabIndex = 2
        '
        'lblCoinName
        '
        Me.lblCoinName.AutoSize = True
        Me.lblCoinName.Location = New System.Drawing.Point(13, 62)
        Me.lblCoinName.Name = "lblCoinName"
        Me.lblCoinName.Size = New System.Drawing.Size(35, 13)
        Me.lblCoinName.TabIndex = 6
        Me.lblCoinName.Text = "Name"
        '
        'txtNetworkName
        '
        Me.txtNetworkName.Location = New System.Drawing.Point(16, 32)
        Me.txtNetworkName.Name = "txtNetworkName"
        Me.txtNetworkName.Size = New System.Drawing.Size(304, 20)
        Me.txtNetworkName.TabIndex = 0
        '
        'lblNetworkName
        '
        Me.lblNetworkName.AutoSize = True
        Me.lblNetworkName.Location = New System.Drawing.Point(13, 15)
        Me.lblNetworkName.Name = "lblNetworkName"
        Me.lblNetworkName.Size = New System.Drawing.Size(78, 13)
        Me.lblNetworkName.TabIndex = 4
        Me.lblNetworkName.Text = "Network Name"
        '
        'tpCoin
        '
        Me.tpCoin.Controls.Add(Me.lblSymbol2)
        Me.tpCoin.Controls.Add(Me.lblSymbol1)
        Me.tpCoin.Controls.Add(Me.txtNumOfDecimal)
        Me.tpCoin.Controls.Add(Me.lblNumDecimal)
        Me.tpCoin.Controls.Add(Me.chkNoTotal)
        Me.tpCoin.Controls.Add(Me.chkMintable)
        Me.tpCoin.Controls.Add(Me.txtWalletPremined)
        Me.tpCoin.Controls.Add(Me.Label1)
        Me.tpCoin.Controls.Add(Me.txtTotalCoin)
        Me.tpCoin.Controls.Add(Me.lblTotalCoin)
        Me.tpCoin.Controls.Add(Me.txtPremined)
        Me.tpCoin.Controls.Add(Me.lblPremined)
        Me.tpCoin.Controls.Add(Me.chkBurnable)
        Me.tpCoin.Location = New System.Drawing.Point(4, 22)
        Me.tpCoin.Name = "tpCoin"
        Me.tpCoin.Size = New System.Drawing.Size(471, 232)
        Me.tpCoin.TabIndex = 1
        Me.tpCoin.Text = "Totals"
        Me.tpCoin.UseVisualStyleBackColor = True
        '
        'lblSymbol2
        '
        Me.lblSymbol2.AutoSize = True
        Me.lblSymbol2.Location = New System.Drawing.Point(431, 66)
        Me.lblSymbol2.Name = "lblSymbol2"
        Me.lblSymbol2.Size = New System.Drawing.Size(17, 13)
        Me.lblSymbol2.TabIndex = 16
        Me.lblSymbol2.Text = "xx"
        '
        'lblSymbol1
        '
        Me.lblSymbol1.AutoSize = True
        Me.lblSymbol1.Location = New System.Drawing.Point(263, 66)
        Me.lblSymbol1.Name = "lblSymbol1"
        Me.lblSymbol1.Size = New System.Drawing.Size(17, 13)
        Me.lblSymbol1.TabIndex = 15
        Me.lblSymbol1.Text = "xx"
        '
        'txtNumOfDecimal
        '
        Me.txtNumOfDecimal.Location = New System.Drawing.Point(13, 63)
        Me.txtNumOfDecimal.Name = "txtNumOfDecimal"
        Me.txtNumOfDecimal.Size = New System.Drawing.Size(96, 20)
        Me.txtNumOfDecimal.TabIndex = 3
        Me.txtNumOfDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumDecimal
        '
        Me.lblNumDecimal.AutoSize = True
        Me.lblNumDecimal.Location = New System.Drawing.Point(10, 47)
        Me.lblNumDecimal.Name = "lblNumDecimal"
        Me.lblNumDecimal.Size = New System.Drawing.Size(100, 13)
        Me.lblNumDecimal.TabIndex = 14
        Me.lblNumDecimal.Text = "Number of decimals"
        '
        'chkNoTotal
        '
        Me.chkNoTotal.AutoSize = True
        Me.chkNoTotal.Location = New System.Drawing.Point(286, 15)
        Me.chkNoTotal.Name = "chkNoTotal"
        Me.chkNoTotal.Size = New System.Drawing.Size(65, 17)
        Me.chkNoTotal.TabIndex = 2
        Me.chkNoTotal.Text = "Limitless"
        Me.chkNoTotal.UseVisualStyleBackColor = True
        '
        'chkMintable
        '
        Me.chkMintable.AutoSize = True
        Me.chkMintable.Location = New System.Drawing.Point(132, 15)
        Me.chkMintable.Name = "chkMintable"
        Me.chkMintable.Size = New System.Drawing.Size(66, 17)
        Me.chkMintable.TabIndex = 1
        Me.chkMintable.Text = "Mintable"
        Me.chkMintable.UseVisualStyleBackColor = True
        '
        'txtWalletPremined
        '
        Me.txtWalletPremined.Location = New System.Drawing.Point(13, 119)
        Me.txtWalletPremined.Multiline = True
        Me.txtWalletPremined.Name = "txtWalletPremined"
        Me.txtWalletPremined.Size = New System.Drawing.Size(435, 100)
        Me.txtWalletPremined.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Public Wallet Address Premined"
        '
        'txtTotalCoin
        '
        Me.txtTotalCoin.Location = New System.Drawing.Point(286, 63)
        Me.txtTotalCoin.Name = "txtTotalCoin"
        Me.txtTotalCoin.Size = New System.Drawing.Size(139, 20)
        Me.txtTotalCoin.TabIndex = 5
        Me.txtTotalCoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalCoin
        '
        Me.lblTotalCoin.AutoSize = True
        Me.lblTotalCoin.Location = New System.Drawing.Point(283, 47)
        Me.lblTotalCoin.Name = "lblTotalCoin"
        Me.lblTotalCoin.Size = New System.Drawing.Size(31, 13)
        Me.lblTotalCoin.TabIndex = 8
        Me.lblTotalCoin.Text = "Total"
        '
        'txtPremined
        '
        Me.txtPremined.Location = New System.Drawing.Point(132, 63)
        Me.txtPremined.Name = "txtPremined"
        Me.txtPremined.Size = New System.Drawing.Size(125, 20)
        Me.txtPremined.TabIndex = 4
        Me.txtPremined.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPremined
        '
        Me.lblPremined.AutoSize = True
        Me.lblPremined.Location = New System.Drawing.Point(129, 47)
        Me.lblPremined.Name = "lblPremined"
        Me.lblPremined.Size = New System.Drawing.Size(133, 13)
        Me.lblPremined.TabIndex = 6
        Me.lblPremined.Text = "Number of pre-mined coins"
        '
        'chkBurnable
        '
        Me.chkBurnable.AutoSize = True
        Me.chkBurnable.Location = New System.Drawing.Point(13, 15)
        Me.chkBurnable.Name = "chkBurnable"
        Me.chkBurnable.Size = New System.Drawing.Size(68, 17)
        Me.chkBurnable.TabIndex = 0
        Me.chkBurnable.Text = "Burnable"
        Me.chkBurnable.UseVisualStyleBackColor = True
        '
        'tpNodeLayer
        '
        Me.tpNodeLayer.Controls.Add(Me.Label2)
        Me.tpNodeLayer.Controls.Add(Me.lblMinDurateConsensus)
        Me.tpNodeLayer.Controls.Add(Me.txtDurateNodeConsensus)
        Me.tpNodeLayer.Controls.Add(Me.lblDurateNodeConsensus)
        Me.tpNodeLayer.Controls.Add(Me.txtHourNodeConsensus)
        Me.tpNodeLayer.Controls.Add(Me.lblHourNode)
        Me.tpNodeLayer.Location = New System.Drawing.Point(4, 22)
        Me.tpNodeLayer.Name = "tpNodeLayer"
        Me.tpNodeLayer.Size = New System.Drawing.Size(471, 232)
        Me.tpNodeLayer.TabIndex = 2
        Me.tpNodeLayer.Text = "Node Layer"
        Me.tpNodeLayer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Olive
        Me.Label2.Location = New System.Drawing.Point(142, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "( GMT )"
        '
        'lblMinDurateConsensus
        '
        Me.lblMinDurateConsensus.AutoSize = True
        Me.lblMinDurateConsensus.Location = New System.Drawing.Point(142, 81)
        Me.lblMinDurateConsensus.Name = "lblMinDurateConsensus"
        Me.lblMinDurateConsensus.Size = New System.Drawing.Size(38, 13)
        Me.lblMinDurateConsensus.TabIndex = 16
        Me.lblMinDurateConsensus.Text = "( min. )"
        '
        'txtDurateNodeConsensus
        '
        Me.txtDurateNodeConsensus.Location = New System.Drawing.Point(16, 81)
        Me.txtDurateNodeConsensus.Name = "txtDurateNodeConsensus"
        Me.txtDurateNodeConsensus.Size = New System.Drawing.Size(120, 20)
        Me.txtDurateNodeConsensus.TabIndex = 1
        Me.txtDurateNodeConsensus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDurateNodeConsensus
        '
        Me.lblDurateNodeConsensus.AutoSize = True
        Me.lblDurateNodeConsensus.Location = New System.Drawing.Point(13, 64)
        Me.lblDurateNodeConsensus.Name = "lblDurateNodeConsensus"
        Me.lblDurateNodeConsensus.Size = New System.Drawing.Size(128, 13)
        Me.lblDurateNodeConsensus.TabIndex = 14
        Me.lblDurateNodeConsensus.Text = "Node duration consensus"
        '
        'txtHourNodeConsensus
        '
        Me.txtHourNodeConsensus.Enabled = False
        Me.txtHourNodeConsensus.Location = New System.Drawing.Point(16, 32)
        Me.txtHourNodeConsensus.Name = "txtHourNodeConsensus"
        Me.txtHourNodeConsensus.Size = New System.Drawing.Size(120, 20)
        Me.txtHourNodeConsensus.TabIndex = 0
        Me.txtHourNodeConsensus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHourNode
        '
        Me.lblHourNode.AutoSize = True
        Me.lblHourNode.Location = New System.Drawing.Point(13, 15)
        Me.lblHourNode.Name = "lblHourNode"
        Me.lblHourNode.Size = New System.Drawing.Size(107, 13)
        Me.lblHourNode.TabIndex = 12
        Me.lblHourNode.Text = "Hour start consensus"
        '
        'txtCompletePath
        '
        Me.txtCompletePath.Location = New System.Drawing.Point(20, 29)
        Me.txtCompletePath.Name = "txtCompletePath"
        Me.txtCompletePath.Size = New System.Drawing.Size(434, 20)
        Me.txtCompletePath.TabIndex = 0
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(17, 13)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(75, 13)
        Me.lblPath.TabIndex = 7
        Me.lblPath.Text = "Complete path"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(460, 27)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(31, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtIdentity
        '
        Me.txtIdentity.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtIdentity.Location = New System.Drawing.Point(20, 75)
        Me.txtIdentity.Name = "txtIdentity"
        Me.txtIdentity.Size = New System.Drawing.Size(471, 20)
        Me.txtIdentity.TabIndex = 11
        Me.txtIdentity.Text = "NO FILE"
        Me.txtIdentity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblIdentityCOIN
        '
        Me.lblIdentityCOIN.AutoSize = True
        Me.lblIdentityCOIN.Location = New System.Drawing.Point(17, 59)
        Me.lblIdentityCOIN.Name = "lblIdentityCOIN"
        Me.lblIdentityCOIN.Size = New System.Drawing.Size(41, 13)
        Me.lblIdentityCOIN.TabIndex = 10
        Me.lblIdentityCOIN.Text = "Identity"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 386)
        Me.Controls.Add(Me.txtIdentity)
        Me.Controls.Add(Me.lblIdentityCOIN)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtCompletePath)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.tcMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Definition Editor"
        Me.tcMain.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        Me.grpDateStart.ResumeLayout(False)
        Me.grpDateStart.PerformLayout()
        Me.tpCoin.ResumeLayout(False)
        Me.tpCoin.PerformLayout()
        Me.tpNodeLayer.ResumeLayout(False)
        Me.tpNodeLayer.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tcMain As TabControl
    Friend WithEvents tpMain As TabPage
    Friend WithEvents txtSymbol As TextBox
    Friend WithEvents lblSymbol As Label
    Friend WithEvents txtShortName As TextBox
    Friend WithEvents lblShortName As Label
    Friend WithEvents txtCoinName As TextBox
    Friend WithEvents lblCoinName As Label
    Friend WithEvents txtNetworkName As TextBox
    Friend WithEvents lblNetworkName As Label
    Friend WithEvents tpCoin As TabPage
    Friend WithEvents txtCompletePath As TextBox
    Friend WithEvents lblPath As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtIdentity As TextBox
    Friend WithEvents lblIdentityCOIN As Label
    Friend WithEvents txtWalletPremined As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalCoin As TextBox
    Friend WithEvents lblTotalCoin As Label
    Friend WithEvents txtPremined As TextBox
    Friend WithEvents lblPremined As Label
    Friend WithEvents chkBurnable As CheckBox
    Friend WithEvents tpNodeLayer As TabPage
    Friend WithEvents lblMinDurateConsensus As Label
    Friend WithEvents txtDurateNodeConsensus As TextBox
    Friend WithEvents lblDurateNodeConsensus As Label
    Friend WithEvents txtHourNodeConsensus As TextBox
    Friend WithEvents lblHourNode As Label
    Friend WithEvents grpDateStart As GroupBox
    Friend WithEvents chkSchedule As CheckBox
    Friend WithEvents dtpStartNetwork As DateTimePicker
    Friend WithEvents lblDateStartNetwork As Label
    Friend WithEvents lblHelpNetworkName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkMintable As CheckBox
    Friend WithEvents lblSymbol2 As Label
    Friend WithEvents lblSymbol1 As Label
    Friend WithEvents txtNumOfDecimal As TextBox
    Friend WithEvents lblNumDecimal As Label
    Friend WithEvents chkNoTotal As CheckBox
End Class
