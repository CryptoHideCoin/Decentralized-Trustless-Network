﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.connectionTab = New System.Windows.Forms.TabPage()
        Me.localPathAndDataPortNumber = New System.Windows.Forms.GroupBox()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.localPathData = New System.Windows.Forms.TextBox()
        Me.adminServiceConnectionGroup = New System.Windows.Forms.GroupBox()
        Me.changeButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.certificateMasternodeBrowserButton = New System.Windows.Forms.Button()
        Me.certificateMasternodeAdmin = New System.Windows.Forms.TextBox()
        Me.certificateMasternodeLabel = New System.Windows.Forms.Label()
        Me.testButton = New System.Windows.Forms.Button()
        Me.masternodeAdminUrl = New System.Windows.Forms.TextBox()
        Me.protocol = New System.Windows.Forms.ComboBox()
        Me.generalTab = New System.Windows.Forms.TabPage()
        Me.commondGroup = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.infoGroup = New System.Windows.Forms.GroupBox()
        Me.addressValue = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.responseTime = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.requestTime = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.protocolReleaseValue = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.softwareRelease = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.platformValue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.serviceOffered = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.walletAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.masternodeLocalTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.virtualNameValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.currentStatusValue = New System.Windows.Forms.TextBox()
        Me.statusMasternode = New System.Windows.Forms.Label()
        Me.refreshGeneralButton = New System.Windows.Forms.Button()
        Me.networkTab = New System.Windows.Forms.TabPage()
        Me.startStopGroup = New System.Windows.Forms.GroupBox()
        Me.valueCoinToLock = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.privateKeyValue = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.operationNetwork = New System.Windows.Forms.Button()
        Me.infoStatusNetwork = New System.Windows.Forms.GroupBox()
        Me.responseNetworkTimeValue = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.requestNetworkTimeValue = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.networkProtocolReleaseValue = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.transactionChainNameValue = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.networkStatusValue = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.refreshDataNetwork = New System.Windows.Forms.Button()
        Me.peerNodeListTab = New System.Windows.Forms.TabPage()
        Me.advancedTab = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.termsAndConditionsButton = New System.Windows.Forms.Button()
        Me.privacyPaperButton = New System.Windows.Forms.Button()
        Me.sideChainConfiguration = New System.Windows.Forms.Button()
        Me.refundPlanButton = New System.Windows.Forms.Button()
        Me.referenceProtocolButton = New System.Windows.Forms.Button()
        Me.priceTableButton = New System.Windows.Forms.Button()
        Me.yellowPapersButton = New System.Windows.Forms.Button()
        Me.whitePapersButton = New System.Windows.Forms.Button()
        Me.visionPapersButton = New System.Windows.Forms.Button()
        Me.assetsButton = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.mainTab.SuspendLayout()
        Me.connectionTab.SuspendLayout()
        Me.localPathAndDataPortNumber.SuspendLayout()
        Me.adminServiceConnectionGroup.SuspendLayout()
        Me.generalTab.SuspendLayout()
        Me.commondGroup.SuspendLayout()
        Me.infoGroup.SuspendLayout()
        Me.networkTab.SuspendLayout()
        Me.startStopGroup.SuspendLayout()
        Me.infoStatusNetwork.SuspendLayout()
        Me.advancedTab.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainTab
        '
        Me.mainTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainTab.Controls.Add(Me.connectionTab)
        Me.mainTab.Controls.Add(Me.generalTab)
        Me.mainTab.Controls.Add(Me.networkTab)
        Me.mainTab.Controls.Add(Me.peerNodeListTab)
        Me.mainTab.Controls.Add(Me.advancedTab)
        Me.mainTab.Location = New System.Drawing.Point(2, 2)
        Me.mainTab.Multiline = True
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(695, 524)
        Me.mainTab.TabIndex = 0
        '
        'connectionTab
        '
        Me.connectionTab.Controls.Add(Me.localPathAndDataPortNumber)
        Me.connectionTab.Controls.Add(Me.adminServiceConnectionGroup)
        Me.connectionTab.Location = New System.Drawing.Point(4, 22)
        Me.connectionTab.Name = "connectionTab"
        Me.connectionTab.Padding = New System.Windows.Forms.Padding(3)
        Me.connectionTab.Size = New System.Drawing.Size(687, 498)
        Me.connectionTab.TabIndex = 0
        Me.connectionTab.Text = "Settings"
        Me.connectionTab.UseVisualStyleBackColor = True
        '
        'localPathAndDataPortNumber
        '
        Me.localPathAndDataPortNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathAndDataPortNumber.Controls.Add(Me.browseLocalPath)
        Me.localPathAndDataPortNumber.Controls.Add(Me.localPathData)
        Me.localPathAndDataPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathAndDataPortNumber.Location = New System.Drawing.Point(8, 6)
        Me.localPathAndDataPortNumber.Name = "localPathAndDataPortNumber"
        Me.localPathAndDataPortNumber.Size = New System.Drawing.Size(668, 96)
        Me.localPathAndDataPortNumber.TabIndex = 0
        Me.localPathAndDataPortNumber.TabStop = False
        Me.localPathAndDataPortNumber.Text = "Local path data"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(626, 28)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(35, 23)
        Me.browseLocalPath.TabIndex = 1
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'localPathData
        '
        Me.localPathData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathData.Location = New System.Drawing.Point(8, 30)
        Me.localPathData.Name = "localPathData"
        Me.localPathData.Size = New System.Drawing.Size(610, 21)
        Me.localPathData.TabIndex = 0
        '
        'adminServiceConnectionGroup
        '
        Me.adminServiceConnectionGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminServiceConnectionGroup.Controls.Add(Me.changeButton)
        Me.adminServiceConnectionGroup.Controls.Add(Me.Label1)
        Me.adminServiceConnectionGroup.Controls.Add(Me.certificateMasternodeBrowserButton)
        Me.adminServiceConnectionGroup.Controls.Add(Me.certificateMasternodeAdmin)
        Me.adminServiceConnectionGroup.Controls.Add(Me.certificateMasternodeLabel)
        Me.adminServiceConnectionGroup.Controls.Add(Me.testButton)
        Me.adminServiceConnectionGroup.Controls.Add(Me.masternodeAdminUrl)
        Me.adminServiceConnectionGroup.Controls.Add(Me.protocol)
        Me.adminServiceConnectionGroup.Location = New System.Drawing.Point(8, 108)
        Me.adminServiceConnectionGroup.Name = "adminServiceConnectionGroup"
        Me.adminServiceConnectionGroup.Size = New System.Drawing.Size(668, 93)
        Me.adminServiceConnectionGroup.TabIndex = 1
        Me.adminServiceConnectionGroup.TabStop = False
        Me.adminServiceConnectionGroup.Text = "Admin Service Connections"
        '
        'changeButton
        '
        Me.changeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.changeButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changeButton.Location = New System.Drawing.Point(535, 56)
        Me.changeButton.Name = "changeButton"
        Me.changeButton.Size = New System.Drawing.Size(65, 23)
        Me.changeButton.TabIndex = 4
        Me.changeButton.Text = "Change"
        Me.changeButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "URL"
        '
        'certificateMasternodeBrowserButton
        '
        Me.certificateMasternodeBrowserButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeBrowserButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeBrowserButton.Location = New System.Drawing.Point(498, 56)
        Me.certificateMasternodeBrowserButton.Name = "certificateMasternodeBrowserButton"
        Me.certificateMasternodeBrowserButton.Size = New System.Drawing.Size(31, 23)
        Me.certificateMasternodeBrowserButton.TabIndex = 3
        Me.certificateMasternodeBrowserButton.Text = "..."
        Me.certificateMasternodeBrowserButton.UseVisualStyleBackColor = True
        '
        'certificateMasternodeAdmin
        '
        Me.certificateMasternodeAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.certificateMasternodeAdmin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeAdmin.Location = New System.Drawing.Point(155, 57)
        Me.certificateMasternodeAdmin.Name = "certificateMasternodeAdmin"
        Me.certificateMasternodeAdmin.Size = New System.Drawing.Size(337, 21)
        Me.certificateMasternodeAdmin.TabIndex = 2
        '
        'certificateMasternodeLabel
        '
        Me.certificateMasternodeLabel.AutoSize = True
        Me.certificateMasternodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeLabel.Location = New System.Drawing.Point(83, 60)
        Me.certificateMasternodeLabel.Name = "certificateMasternodeLabel"
        Me.certificateMasternodeLabel.Size = New System.Drawing.Size(66, 13)
        Me.certificateMasternodeLabel.TabIndex = 7
        Me.certificateMasternodeLabel.Text = "Certificate"
        '
        'testButton
        '
        Me.testButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testButton.Enabled = False
        Me.testButton.Location = New System.Drawing.Point(606, 29)
        Me.testButton.Name = "testButton"
        Me.testButton.Size = New System.Drawing.Size(55, 49)
        Me.testButton.TabIndex = 5
        Me.testButton.Text = "Test"
        Me.testButton.UseVisualStyleBackColor = True
        '
        'masternodeAdminUrl
        '
        Me.masternodeAdminUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeAdminUrl.Location = New System.Drawing.Point(155, 30)
        Me.masternodeAdminUrl.Name = "masternodeAdminUrl"
        Me.masternodeAdminUrl.Size = New System.Drawing.Size(445, 21)
        Me.masternodeAdminUrl.TabIndex = 1
        '
        'protocol
        '
        Me.protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.protocol.FormattingEnabled = True
        Me.protocol.Items.AddRange(New Object() {"http://", "https://"})
        Me.protocol.Location = New System.Drawing.Point(79, 31)
        Me.protocol.Name = "protocol"
        Me.protocol.Size = New System.Drawing.Size(70, 21)
        Me.protocol.TabIndex = 0
        '
        'generalTab
        '
        Me.generalTab.Controls.Add(Me.commondGroup)
        Me.generalTab.Controls.Add(Me.infoGroup)
        Me.generalTab.Controls.Add(Me.refreshGeneralButton)
        Me.generalTab.Location = New System.Drawing.Point(4, 22)
        Me.generalTab.Name = "generalTab"
        Me.generalTab.Padding = New System.Windows.Forms.Padding(3)
        Me.generalTab.Size = New System.Drawing.Size(687, 498)
        Me.generalTab.TabIndex = 1
        Me.generalTab.Text = "General"
        Me.generalTab.UseVisualStyleBackColor = True
        '
        'commondGroup
        '
        Me.commondGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.commondGroup.Controls.Add(Me.Button7)
        Me.commondGroup.Controls.Add(Me.Button6)
        Me.commondGroup.Controls.Add(Me.Button5)
        Me.commondGroup.Controls.Add(Me.Button4)
        Me.commondGroup.Controls.Add(Me.Button3)
        Me.commondGroup.Controls.Add(Me.Button2)
        Me.commondGroup.Controls.Add(Me.Button1)
        Me.commondGroup.Location = New System.Drawing.Point(7, 383)
        Me.commondGroup.Name = "commondGroup"
        Me.commondGroup.Size = New System.Drawing.Size(671, 106)
        Me.commondGroup.TabIndex = 2
        Me.commondGroup.TabStop = False
        Me.commondGroup.Text = "Commands"
        Me.commondGroup.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(558, 38)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(92, 50)
        Me.Button7.TabIndex = 14
        Me.Button7.Text = "Votes Management"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(466, 38)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(92, 50)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Profiler"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(374, 38)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(92, 50)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Statistics"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(282, 38)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(92, 50)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Update Management"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(190, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 50)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "View Counters"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(98, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 50)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "View Events"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 50)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "View Logs"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'infoGroup
        '
        Me.infoGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoGroup.Controls.Add(Me.addressValue)
        Me.infoGroup.Controls.Add(Me.Label11)
        Me.infoGroup.Controls.Add(Me.responseTime)
        Me.infoGroup.Controls.Add(Me.Label10)
        Me.infoGroup.Controls.Add(Me.requestTime)
        Me.infoGroup.Controls.Add(Me.Label9)
        Me.infoGroup.Controls.Add(Me.protocolReleaseValue)
        Me.infoGroup.Controls.Add(Me.Label8)
        Me.infoGroup.Controls.Add(Me.softwareRelease)
        Me.infoGroup.Controls.Add(Me.Label7)
        Me.infoGroup.Controls.Add(Me.platformValue)
        Me.infoGroup.Controls.Add(Me.Label6)
        Me.infoGroup.Controls.Add(Me.serviceOffered)
        Me.infoGroup.Controls.Add(Me.Label5)
        Me.infoGroup.Controls.Add(Me.walletAddress)
        Me.infoGroup.Controls.Add(Me.Label4)
        Me.infoGroup.Controls.Add(Me.masternodeLocalTime)
        Me.infoGroup.Controls.Add(Me.Label3)
        Me.infoGroup.Controls.Add(Me.virtualNameValue)
        Me.infoGroup.Controls.Add(Me.Label2)
        Me.infoGroup.Controls.Add(Me.currentStatusValue)
        Me.infoGroup.Controls.Add(Me.statusMasternode)
        Me.infoGroup.Location = New System.Drawing.Point(7, 48)
        Me.infoGroup.Name = "infoGroup"
        Me.infoGroup.Size = New System.Drawing.Size(673, 329)
        Me.infoGroup.TabIndex = 1
        Me.infoGroup.TabStop = False
        Me.infoGroup.Text = "Info Masternode"
        '
        'addressValue
        '
        Me.addressValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addressValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addressValue.Location = New System.Drawing.Point(165, 238)
        Me.addressValue.Name = "addressValue"
        Me.addressValue.ReadOnly = True
        Me.addressValue.Size = New System.Drawing.Size(482, 21)
        Me.addressValue.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(102, 241)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Address"
        '
        'responseTime
        '
        Me.responseTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responseTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseTime.Location = New System.Drawing.Point(165, 292)
        Me.responseTime.Name = "responseTime"
        Me.responseTime.ReadOnly = True
        Me.responseTime.Size = New System.Drawing.Size(482, 21)
        Me.responseTime.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(61, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Response Time"
        '
        'requestTime
        '
        Me.requestTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestTime.Location = New System.Drawing.Point(165, 265)
        Me.requestTime.Name = "requestTime"
        Me.requestTime.ReadOnly = True
        Me.requestTime.Size = New System.Drawing.Size(482, 21)
        Me.requestTime.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(70, 268)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Request Time"
        '
        'protocolReleaseValue
        '
        Me.protocolReleaseValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.protocolReleaseValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.protocolReleaseValue.Location = New System.Drawing.Point(165, 211)
        Me.protocolReleaseValue.Name = "protocolReleaseValue"
        Me.protocolReleaseValue.ReadOnly = True
        Me.protocolReleaseValue.Size = New System.Drawing.Size(482, 21)
        Me.protocolReleaseValue.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Protocol release"
        '
        'softwareRelease
        '
        Me.softwareRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.softwareRelease.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.softwareRelease.Location = New System.Drawing.Point(165, 184)
        Me.softwareRelease.Name = "softwareRelease"
        Me.softwareRelease.ReadOnly = True
        Me.softwareRelease.Size = New System.Drawing.Size(482, 21)
        Me.softwareRelease.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Software release"
        '
        'platformValue
        '
        Me.platformValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.platformValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.platformValue.Location = New System.Drawing.Point(165, 157)
        Me.platformValue.Name = "platformValue"
        Me.platformValue.ReadOnly = True
        Me.platformValue.Size = New System.Drawing.Size(482, 21)
        Me.platformValue.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(72, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Platform host"
        '
        'serviceOffered
        '
        Me.serviceOffered.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceOffered.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceOffered.Location = New System.Drawing.Point(165, 130)
        Me.serviceOffered.Name = "serviceOffered"
        Me.serviceOffered.ReadOnly = True
        Me.serviceOffered.Size = New System.Drawing.Size(482, 21)
        Me.serviceOffered.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(52, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Services Offered"
        '
        'walletAddress
        '
        Me.walletAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.walletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.walletAddress.Location = New System.Drawing.Point(165, 103)
        Me.walletAddress.Name = "walletAddress"
        Me.walletAddress.ReadOnly = True
        Me.walletAddress.Size = New System.Drawing.Size(482, 21)
        Me.walletAddress.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Public wallet address"
        '
        'masternodeLocalTime
        '
        Me.masternodeLocalTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.masternodeLocalTime.Location = New System.Drawing.Point(165, 76)
        Me.masternodeLocalTime.Name = "masternodeLocalTime"
        Me.masternodeLocalTime.ReadOnly = True
        Me.masternodeLocalTime.Size = New System.Drawing.Size(482, 21)
        Me.masternodeLocalTime.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Masternode local time"
        '
        'virtualNameValue
        '
        Me.virtualNameValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.virtualNameValue.Location = New System.Drawing.Point(165, 49)
        Me.virtualNameValue.Name = "virtualNameValue"
        Me.virtualNameValue.ReadOnly = True
        Me.virtualNameValue.Size = New System.Drawing.Size(482, 21)
        Me.virtualNameValue.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Virtual Name"
        '
        'currentStatusValue
        '
        Me.currentStatusValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentStatusValue.Location = New System.Drawing.Point(165, 21)
        Me.currentStatusValue.Name = "currentStatusValue"
        Me.currentStatusValue.ReadOnly = True
        Me.currentStatusValue.Size = New System.Drawing.Size(482, 21)
        Me.currentStatusValue.TabIndex = 0
        '
        'statusMasternode
        '
        Me.statusMasternode.AutoSize = True
        Me.statusMasternode.Location = New System.Drawing.Point(64, 25)
        Me.statusMasternode.Name = "statusMasternode"
        Me.statusMasternode.Size = New System.Drawing.Size(91, 13)
        Me.statusMasternode.TabIndex = 0
        Me.statusMasternode.Text = "Current Status"
        '
        'refreshGeneralButton
        '
        Me.refreshGeneralButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.refreshGeneralButton.Enabled = False
        Me.refreshGeneralButton.Location = New System.Drawing.Point(605, 6)
        Me.refreshGeneralButton.Name = "refreshGeneralButton"
        Me.refreshGeneralButton.Size = New System.Drawing.Size(75, 36)
        Me.refreshGeneralButton.TabIndex = 0
        Me.refreshGeneralButton.Text = "Refresh"
        Me.refreshGeneralButton.UseVisualStyleBackColor = True
        '
        'networkTab
        '
        Me.networkTab.Controls.Add(Me.startStopGroup)
        Me.networkTab.Controls.Add(Me.infoStatusNetwork)
        Me.networkTab.Controls.Add(Me.refreshDataNetwork)
        Me.networkTab.Location = New System.Drawing.Point(4, 22)
        Me.networkTab.Name = "networkTab"
        Me.networkTab.Size = New System.Drawing.Size(687, 498)
        Me.networkTab.TabIndex = 2
        Me.networkTab.Text = "Network"
        Me.networkTab.UseVisualStyleBackColor = True
        '
        'startStopGroup
        '
        Me.startStopGroup.Controls.Add(Me.valueCoinToLock)
        Me.startStopGroup.Controls.Add(Me.Label16)
        Me.startStopGroup.Controls.Add(Me.privateKeyValue)
        Me.startStopGroup.Controls.Add(Me.Label12)
        Me.startStopGroup.Controls.Add(Me.operationNetwork)
        Me.startStopGroup.Location = New System.Drawing.Point(7, 223)
        Me.startStopGroup.Name = "startStopGroup"
        Me.startStopGroup.Size = New System.Drawing.Size(673, 179)
        Me.startStopGroup.TabIndex = 5
        Me.startStopGroup.TabStop = False
        Me.startStopGroup.Text = "Commands"
        Me.startStopGroup.Visible = False
        '
        'valueCoinToLock
        '
        Me.valueCoinToLock.Location = New System.Drawing.Point(517, 133)
        Me.valueCoinToLock.Name = "valueCoinToLock"
        Me.valueCoinToLock.Size = New System.Drawing.Size(136, 21)
        Me.valueCoinToLock.TabIndex = 12
        Me.valueCoinToLock.Text = "0,00"
        Me.valueCoinToLock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.valueCoinToLock.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(296, 136)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(215, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Amount of CHCS to lock in warranty"
        Me.Label16.Visible = False
        '
        'privateKeyValue
        '
        Me.privateKeyValue.Location = New System.Drawing.Point(165, 55)
        Me.privateKeyValue.Multiline = True
        Me.privateKeyValue.Name = "privateKeyValue"
        Me.privateKeyValue.Size = New System.Drawing.Size(488, 72)
        Me.privateKeyValue.TabIndex = 10
        Me.privateKeyValue.Text = resources.GetString("privateKeyValue.Text")
        Me.privateKeyValue.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(162, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Private Key"
        Me.Label12.Visible = False
        '
        'operationNetwork
        '
        Me.operationNetwork.Location = New System.Drawing.Point(59, 55)
        Me.operationNetwork.Name = "operationNetwork"
        Me.operationNetwork.Size = New System.Drawing.Size(92, 50)
        Me.operationNetwork.TabIndex = 8
        Me.operationNetwork.Text = "START >>"
        Me.operationNetwork.UseVisualStyleBackColor = True
        Me.operationNetwork.Visible = False
        '
        'infoStatusNetwork
        '
        Me.infoStatusNetwork.Controls.Add(Me.responseNetworkTimeValue)
        Me.infoStatusNetwork.Controls.Add(Me.Label13)
        Me.infoStatusNetwork.Controls.Add(Me.requestNetworkTimeValue)
        Me.infoStatusNetwork.Controls.Add(Me.Label14)
        Me.infoStatusNetwork.Controls.Add(Me.networkProtocolReleaseValue)
        Me.infoStatusNetwork.Controls.Add(Me.Label15)
        Me.infoStatusNetwork.Controls.Add(Me.transactionChainNameValue)
        Me.infoStatusNetwork.Controls.Add(Me.Label21)
        Me.infoStatusNetwork.Controls.Add(Me.networkStatusValue)
        Me.infoStatusNetwork.Controls.Add(Me.Label22)
        Me.infoStatusNetwork.Location = New System.Drawing.Point(7, 48)
        Me.infoStatusNetwork.Name = "infoStatusNetwork"
        Me.infoStatusNetwork.Size = New System.Drawing.Size(673, 167)
        Me.infoStatusNetwork.TabIndex = 4
        Me.infoStatusNetwork.TabStop = False
        Me.infoStatusNetwork.Text = "Info Masternode"
        '
        'responseNetworkTimeValue
        '
        Me.responseNetworkTimeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.responseNetworkTimeValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.responseNetworkTimeValue.Location = New System.Drawing.Point(165, 130)
        Me.responseNetworkTimeValue.Name = "responseNetworkTimeValue"
        Me.responseNetworkTimeValue.ReadOnly = True
        Me.responseNetworkTimeValue.Size = New System.Drawing.Size(488, 21)
        Me.responseNetworkTimeValue.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(61, 133)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Response Time"
        '
        'requestNetworkTimeValue
        '
        Me.requestNetworkTimeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.requestNetworkTimeValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestNetworkTimeValue.Location = New System.Drawing.Point(165, 103)
        Me.requestNetworkTimeValue.Name = "requestNetworkTimeValue"
        Me.requestNetworkTimeValue.ReadOnly = True
        Me.requestNetworkTimeValue.Size = New System.Drawing.Size(488, 21)
        Me.requestNetworkTimeValue.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(70, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Request Time"
        '
        'networkProtocolReleaseValue
        '
        Me.networkProtocolReleaseValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.networkProtocolReleaseValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkProtocolReleaseValue.Location = New System.Drawing.Point(165, 76)
        Me.networkProtocolReleaseValue.Name = "networkProtocolReleaseValue"
        Me.networkProtocolReleaseValue.ReadOnly = True
        Me.networkProtocolReleaseValue.Size = New System.Drawing.Size(488, 21)
        Me.networkProtocolReleaseValue.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(56, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Protocol release"
        '
        'transactionChainNameValue
        '
        Me.transactionChainNameValue.Location = New System.Drawing.Point(165, 49)
        Me.transactionChainNameValue.Name = "transactionChainNameValue"
        Me.transactionChainNameValue.ReadOnly = True
        Me.transactionChainNameValue.Size = New System.Drawing.Size(488, 21)
        Me.transactionChainNameValue.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 53)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(145, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Transaction Chain name"
        '
        'networkStatusValue
        '
        Me.networkStatusValue.Location = New System.Drawing.Point(165, 21)
        Me.networkStatusValue.Name = "networkStatusValue"
        Me.networkStatusValue.ReadOnly = True
        Me.networkStatusValue.Size = New System.Drawing.Size(488, 21)
        Me.networkStatusValue.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(64, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(91, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Current Status"
        '
        'refreshDataNetwork
        '
        Me.refreshDataNetwork.Enabled = False
        Me.refreshDataNetwork.Location = New System.Drawing.Point(605, 6)
        Me.refreshDataNetwork.Name = "refreshDataNetwork"
        Me.refreshDataNetwork.Size = New System.Drawing.Size(75, 36)
        Me.refreshDataNetwork.TabIndex = 3
        Me.refreshDataNetwork.Text = "Refresh"
        Me.refreshDataNetwork.UseVisualStyleBackColor = True
        '
        'peerNodeListTab
        '
        Me.peerNodeListTab.Location = New System.Drawing.Point(4, 22)
        Me.peerNodeListTab.Name = "peerNodeListTab"
        Me.peerNodeListTab.Size = New System.Drawing.Size(687, 498)
        Me.peerNodeListTab.TabIndex = 3
        Me.peerNodeListTab.Text = "Peer node List"
        Me.peerNodeListTab.UseVisualStyleBackColor = True
        '
        'advancedTab
        '
        Me.advancedTab.Controls.Add(Me.GroupBox1)
        Me.advancedTab.Location = New System.Drawing.Point(4, 22)
        Me.advancedTab.Name = "advancedTab"
        Me.advancedTab.Size = New System.Drawing.Size(687, 498)
        Me.advancedTab.TabIndex = 4
        Me.advancedTab.Text = "Advanced"
        Me.advancedTab.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.termsAndConditionsButton)
        Me.GroupBox1.Controls.Add(Me.privacyPaperButton)
        Me.GroupBox1.Controls.Add(Me.sideChainConfiguration)
        Me.GroupBox1.Controls.Add(Me.refundPlanButton)
        Me.GroupBox1.Controls.Add(Me.referenceProtocolButton)
        Me.GroupBox1.Controls.Add(Me.priceTableButton)
        Me.GroupBox1.Controls.Add(Me.yellowPapersButton)
        Me.GroupBox1.Controls.Add(Me.whitePapersButton)
        Me.GroupBox1.Controls.Add(Me.visionPapersButton)
        Me.GroupBox1.Controls.Add(Me.assetsButton)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 495)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control Panel workarea elements contracts"
        '
        'termsAndConditionsButton
        '
        Me.termsAndConditionsButton.Location = New System.Drawing.Point(194, 104)
        Me.termsAndConditionsButton.Name = "termsAndConditionsButton"
        Me.termsAndConditionsButton.Size = New System.Drawing.Size(134, 50)
        Me.termsAndConditionsButton.TabIndex = 17
        Me.termsAndConditionsButton.Text = "Terms and Conditions Papers"
        Me.termsAndConditionsButton.UseVisualStyleBackColor = True
        '
        'privacyPaperButton
        '
        Me.privacyPaperButton.Location = New System.Drawing.Point(54, 104)
        Me.privacyPaperButton.Name = "privacyPaperButton"
        Me.privacyPaperButton.Size = New System.Drawing.Size(134, 50)
        Me.privacyPaperButton.TabIndex = 16
        Me.privacyPaperButton.Text = "Policy Privacy Papers"
        Me.privacyPaperButton.UseVisualStyleBackColor = True
        '
        'sideChainConfiguration
        '
        Me.sideChainConfiguration.Location = New System.Drawing.Point(194, 160)
        Me.sideChainConfiguration.Name = "sideChainConfiguration"
        Me.sideChainConfiguration.Size = New System.Drawing.Size(134, 50)
        Me.sideChainConfiguration.TabIndex = 15
        Me.sideChainConfiguration.Text = "Sidechain Contract"
        Me.sideChainConfiguration.UseVisualStyleBackColor = True
        '
        'refundPlanButton
        '
        Me.refundPlanButton.Location = New System.Drawing.Point(54, 160)
        Me.refundPlanButton.Name = "refundPlanButton"
        Me.refundPlanButton.Size = New System.Drawing.Size(134, 50)
        Me.refundPlanButton.TabIndex = 14
        Me.refundPlanButton.Text = "Refund Plan"
        Me.refundPlanButton.UseVisualStyleBackColor = True
        '
        'referenceProtocolButton
        '
        Me.referenceProtocolButton.Location = New System.Drawing.Point(334, 104)
        Me.referenceProtocolButton.Name = "referenceProtocolButton"
        Me.referenceProtocolButton.Size = New System.Drawing.Size(134, 50)
        Me.referenceProtocolButton.TabIndex = 13
        Me.referenceProtocolButton.Text = "Reference Protocol"
        Me.referenceProtocolButton.UseVisualStyleBackColor = True
        '
        'priceTableButton
        '
        Me.priceTableButton.Location = New System.Drawing.Point(474, 104)
        Me.priceTableButton.Name = "priceTableButton"
        Me.priceTableButton.Size = New System.Drawing.Size(134, 50)
        Me.priceTableButton.TabIndex = 12
        Me.priceTableButton.Text = "Price Table"
        Me.priceTableButton.UseVisualStyleBackColor = True
        '
        'yellowPapersButton
        '
        Me.yellowPapersButton.Location = New System.Drawing.Point(474, 48)
        Me.yellowPapersButton.Name = "yellowPapersButton"
        Me.yellowPapersButton.Size = New System.Drawing.Size(134, 50)
        Me.yellowPapersButton.TabIndex = 11
        Me.yellowPapersButton.Text = "Yellow Papers"
        Me.yellowPapersButton.UseVisualStyleBackColor = True
        '
        'whitePapersButton
        '
        Me.whitePapersButton.Location = New System.Drawing.Point(334, 48)
        Me.whitePapersButton.Name = "whitePapersButton"
        Me.whitePapersButton.Size = New System.Drawing.Size(134, 50)
        Me.whitePapersButton.TabIndex = 10
        Me.whitePapersButton.Text = "White Papers"
        Me.whitePapersButton.UseVisualStyleBackColor = True
        '
        'visionPapersButton
        '
        Me.visionPapersButton.Location = New System.Drawing.Point(194, 48)
        Me.visionPapersButton.Name = "visionPapersButton"
        Me.visionPapersButton.Size = New System.Drawing.Size(134, 50)
        Me.visionPapersButton.TabIndex = 9
        Me.visionPapersButton.Text = "Vision Papers"
        Me.visionPapersButton.UseVisualStyleBackColor = True
        '
        'assetsButton
        '
        Me.assetsButton.Location = New System.Drawing.Point(54, 48)
        Me.assetsButton.Name = "assetsButton"
        Me.assetsButton.Size = New System.Drawing.Size(134, 50)
        Me.assetsButton.TabIndex = 8
        Me.assetsButton.Text = "Assets"
        Me.assetsButton.UseVisualStyleBackColor = True
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(698, 525)
        Me.Controls.Add(Me.mainTab)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Masternode Admin Client - Crypto Hide Coin"
        Me.mainTab.ResumeLayout(False)
        Me.connectionTab.ResumeLayout(False)
        Me.localPathAndDataPortNumber.ResumeLayout(False)
        Me.localPathAndDataPortNumber.PerformLayout()
        Me.adminServiceConnectionGroup.ResumeLayout(False)
        Me.adminServiceConnectionGroup.PerformLayout()
        Me.generalTab.ResumeLayout(False)
        Me.commondGroup.ResumeLayout(False)
        Me.infoGroup.ResumeLayout(False)
        Me.infoGroup.PerformLayout()
        Me.networkTab.ResumeLayout(False)
        Me.startStopGroup.ResumeLayout(False)
        Me.startStopGroup.PerformLayout()
        Me.infoStatusNetwork.ResumeLayout(False)
        Me.infoStatusNetwork.PerformLayout()
        Me.advancedTab.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainTab As TabControl
    Friend WithEvents connectionTab As TabPage
    Friend WithEvents generalTab As TabPage
    Friend WithEvents localPathAndDataPortNumber As GroupBox
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents localPathData As TextBox
    Friend WithEvents adminServiceConnectionGroup As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents certificateMasternodeBrowserButton As Button
    Friend WithEvents certificateMasternodeAdmin As TextBox
    Friend WithEvents certificateMasternodeLabel As Label
    Friend WithEvents testButton As Button
    Friend WithEvents masternodeAdminUrl As TextBox
    Friend WithEvents protocol As ComboBox
    Friend WithEvents commondGroup As GroupBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents infoGroup As GroupBox
    Friend WithEvents serviceOffered As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents walletAddress As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents masternodeLocalTime As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents virtualNameValue As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents currentStatusValue As TextBox
    Friend WithEvents statusMasternode As Label
    Friend WithEvents refreshGeneralButton As Button
    Friend WithEvents networkTab As TabPage
    Friend WithEvents changeButton As Button
    Friend WithEvents protocolReleaseValue As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents softwareRelease As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents platformValue As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents peerNodeListTab As TabPage
    Friend WithEvents advancedTab As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents assetsButton As Button
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents responseTime As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents requestTime As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents addressValue As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents startStopGroup As GroupBox
    Friend WithEvents operationNetwork As Button
    Friend WithEvents infoStatusNetwork As GroupBox
    Friend WithEvents responseNetworkTimeValue As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents requestNetworkTimeValue As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents networkProtocolReleaseValue As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents transactionChainNameValue As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents networkStatusValue As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents refreshDataNetwork As Button
    Friend WithEvents valueCoinToLock As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents privateKeyValue As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents visionPapersButton As Button
    Friend WithEvents whitePapersButton As Button
    Friend WithEvents yellowPapersButton As Button
    Friend WithEvents priceTableButton As Button
    Friend WithEvents referenceProtocolButton As Button
    Friend WithEvents sideChainConfiguration As Button
    Friend WithEvents refundPlanButton As Button
    Friend WithEvents privacyPaperButton As Button
    Friend WithEvents termsAndConditionsButton As Button
End Class
