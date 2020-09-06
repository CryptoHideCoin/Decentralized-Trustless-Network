<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.protocolReleaseValue = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.platformValue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.walletAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.virtualNameValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.changeStatus = New System.Windows.Forms.Button()
        Me.currentStatusValue = New System.Windows.Forms.TextBox()
        Me.statusMasternode = New System.Windows.Forms.Label()
        Me.refreshGeneralButton = New System.Windows.Forms.Button()
        Me.networkTab = New System.Windows.Forms.TabPage()
        Me.peerNodeListTab = New System.Windows.Forms.TabPage()
        Me.advancedTab = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.mainTab.SuspendLayout()
        Me.connectionTab.SuspendLayout()
        Me.localPathAndDataPortNumber.SuspendLayout()
        Me.adminServiceConnectionGroup.SuspendLayout()
        Me.generalTab.SuspendLayout()
        Me.commondGroup.SuspendLayout()
        Me.infoGroup.SuspendLayout()
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
        Me.mainTab.Size = New System.Drawing.Size(695, 449)
        Me.mainTab.TabIndex = 0
        '
        'connectionTab
        '
        Me.connectionTab.Controls.Add(Me.localPathAndDataPortNumber)
        Me.connectionTab.Controls.Add(Me.adminServiceConnectionGroup)
        Me.connectionTab.Location = New System.Drawing.Point(4, 22)
        Me.connectionTab.Name = "connectionTab"
        Me.connectionTab.Padding = New System.Windows.Forms.Padding(3)
        Me.connectionTab.Size = New System.Drawing.Size(687, 423)
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
        Me.localPathAndDataPortNumber.TabIndex = 4
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
        Me.adminServiceConnectionGroup.TabIndex = 3
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
        Me.changeButton.TabIndex = 10
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
        Me.certificateMasternodeBrowserButton.TabIndex = 8
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
        Me.certificateMasternodeAdmin.TabIndex = 6
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
        Me.masternodeAdminUrl.TabIndex = 4
        '
        'protocol
        '
        Me.protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.protocol.FormattingEnabled = True
        Me.protocol.Items.AddRange(New Object() {"http://", "https://"})
        Me.protocol.Location = New System.Drawing.Point(79, 31)
        Me.protocol.Name = "protocol"
        Me.protocol.Size = New System.Drawing.Size(70, 21)
        Me.protocol.TabIndex = 3
        '
        'generalTab
        '
        Me.generalTab.Controls.Add(Me.commondGroup)
        Me.generalTab.Controls.Add(Me.infoGroup)
        Me.generalTab.Controls.Add(Me.refreshGeneralButton)
        Me.generalTab.Location = New System.Drawing.Point(4, 22)
        Me.generalTab.Name = "generalTab"
        Me.generalTab.Padding = New System.Windows.Forms.Padding(3)
        Me.generalTab.Size = New System.Drawing.Size(687, 423)
        Me.generalTab.TabIndex = 1
        Me.generalTab.Text = "General"
        Me.generalTab.UseVisualStyleBackColor = True
        '
        'commondGroup
        '
        Me.commondGroup.Controls.Add(Me.Button7)
        Me.commondGroup.Controls.Add(Me.Button6)
        Me.commondGroup.Controls.Add(Me.Button5)
        Me.commondGroup.Controls.Add(Me.Button4)
        Me.commondGroup.Controls.Add(Me.Button3)
        Me.commondGroup.Controls.Add(Me.Button2)
        Me.commondGroup.Controls.Add(Me.Button1)
        Me.commondGroup.Location = New System.Drawing.Point(7, 308)
        Me.commondGroup.Name = "commondGroup"
        Me.commondGroup.Size = New System.Drawing.Size(671, 106)
        Me.commondGroup.TabIndex = 8
        Me.commondGroup.TabStop = False
        Me.commondGroup.Text = "Commands"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(558, 38)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(92, 50)
        Me.Button7.TabIndex = 14
        Me.Button7.Text = "Votes Management"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(466, 38)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(92, 50)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Profiler"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(374, 39)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(92, 50)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Statistics"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(282, 39)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(92, 50)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Update Management"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(190, 39)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 50)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "View Counters"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(98, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 50)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "View Events"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 50)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "View Logs"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'infoGroup
        '
        Me.infoGroup.Controls.Add(Me.protocolReleaseValue)
        Me.infoGroup.Controls.Add(Me.Label8)
        Me.infoGroup.Controls.Add(Me.TextBox4)
        Me.infoGroup.Controls.Add(Me.Label7)
        Me.infoGroup.Controls.Add(Me.platformValue)
        Me.infoGroup.Controls.Add(Me.Label6)
        Me.infoGroup.Controls.Add(Me.TextBox3)
        Me.infoGroup.Controls.Add(Me.Label5)
        Me.infoGroup.Controls.Add(Me.walletAddress)
        Me.infoGroup.Controls.Add(Me.Label4)
        Me.infoGroup.Controls.Add(Me.TextBox2)
        Me.infoGroup.Controls.Add(Me.Label3)
        Me.infoGroup.Controls.Add(Me.virtualNameValue)
        Me.infoGroup.Controls.Add(Me.Label2)
        Me.infoGroup.Controls.Add(Me.changeStatus)
        Me.infoGroup.Controls.Add(Me.currentStatusValue)
        Me.infoGroup.Controls.Add(Me.statusMasternode)
        Me.infoGroup.Location = New System.Drawing.Point(7, 48)
        Me.infoGroup.Name = "infoGroup"
        Me.infoGroup.Size = New System.Drawing.Size(673, 254)
        Me.infoGroup.TabIndex = 1
        Me.infoGroup.TabStop = False
        Me.infoGroup.Text = "Info Masternode"
        '
        'protocolReleaseValue
        '
        Me.protocolReleaseValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.protocolReleaseValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.protocolReleaseValue.Location = New System.Drawing.Point(165, 211)
        Me.protocolReleaseValue.Name = "protocolReleaseValue"
        Me.protocolReleaseValue.Size = New System.Drawing.Size(421, 21)
        Me.protocolReleaseValue.TabIndex = 15
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
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(165, 184)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(421, 21)
        Me.TextBox4.TabIndex = 13
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
        Me.platformValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.platformValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.platformValue.Location = New System.Drawing.Point(165, 157)
        Me.platformValue.Name = "platformValue"
        Me.platformValue.Size = New System.Drawing.Size(421, 21)
        Me.platformValue.TabIndex = 11
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
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(165, 130)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(421, 21)
        Me.TextBox3.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Service Offered"
        '
        'walletAddress
        '
        Me.walletAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.walletAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.walletAddress.Location = New System.Drawing.Point(165, 103)
        Me.walletAddress.Name = "walletAddress"
        Me.walletAddress.Size = New System.Drawing.Size(421, 21)
        Me.walletAddress.TabIndex = 7
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
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(165, 76)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(421, 21)
        Me.TextBox2.TabIndex = 6
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
        Me.virtualNameValue.Location = New System.Drawing.Point(165, 49)
        Me.virtualNameValue.Name = "virtualNameValue"
        Me.virtualNameValue.Size = New System.Drawing.Size(421, 21)
        Me.virtualNameValue.TabIndex = 4
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
        'changeStatus
        '
        Me.changeStatus.Location = New System.Drawing.Point(592, 20)
        Me.changeStatus.Name = "changeStatus"
        Me.changeStatus.Size = New System.Drawing.Size(75, 23)
        Me.changeStatus.TabIndex = 2
        Me.changeStatus.Text = "START"
        Me.changeStatus.UseVisualStyleBackColor = True
        '
        'currentStatusValue
        '
        Me.currentStatusValue.Location = New System.Drawing.Point(165, 21)
        Me.currentStatusValue.Name = "currentStatusValue"
        Me.currentStatusValue.Size = New System.Drawing.Size(421, 21)
        Me.currentStatusValue.TabIndex = 1
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
        Me.refreshGeneralButton.Location = New System.Drawing.Point(605, 6)
        Me.refreshGeneralButton.Name = "refreshGeneralButton"
        Me.refreshGeneralButton.Size = New System.Drawing.Size(75, 36)
        Me.refreshGeneralButton.TabIndex = 0
        Me.refreshGeneralButton.Text = "Refresh"
        Me.refreshGeneralButton.UseVisualStyleBackColor = True
        '
        'networkTab
        '
        Me.networkTab.Location = New System.Drawing.Point(4, 22)
        Me.networkTab.Name = "networkTab"
        Me.networkTab.Size = New System.Drawing.Size(687, 423)
        Me.networkTab.TabIndex = 2
        Me.networkTab.Text = "Network"
        Me.networkTab.UseVisualStyleBackColor = True
        '
        'peerNodeListTab
        '
        Me.peerNodeListTab.Location = New System.Drawing.Point(4, 22)
        Me.peerNodeListTab.Name = "peerNodeListTab"
        Me.peerNodeListTab.Size = New System.Drawing.Size(687, 423)
        Me.peerNodeListTab.TabIndex = 3
        Me.peerNodeListTab.Text = "Peer node List"
        Me.peerNodeListTab.UseVisualStyleBackColor = True
        '
        'advancedTab
        '
        Me.advancedTab.Controls.Add(Me.GroupBox1)
        Me.advancedTab.Location = New System.Drawing.Point(4, 22)
        Me.advancedTab.Name = "advancedTab"
        Me.advancedTab.Size = New System.Drawing.Size(687, 423)
        Me.advancedTab.TabIndex = 4
        Me.advancedTab.Text = "Advanced"
        Me.advancedTab.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button14)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 106)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Commands"
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(6, 39)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(92, 50)
        Me.Button14.TabIndex = 8
        Me.Button14.Text = "Assets"
        Me.Button14.UseVisualStyleBackColor = True
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
        Me.ClientSize = New System.Drawing.Size(698, 450)
        Me.Controls.Add(Me.mainTab)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Masternode Admin Client"
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
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents walletAddress As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents virtualNameValue As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents changeStatus As Button
    Friend WithEvents currentStatusValue As TextBox
    Friend WithEvents statusMasternode As Label
    Friend WithEvents refreshGeneralButton As Button
    Friend WithEvents networkTab As TabPage
    Friend WithEvents changeButton As Button
    Friend WithEvents protocolReleaseValue As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents platformValue As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents peerNodeListTab As TabPage
    Friend WithEvents advancedTab As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button14 As Button
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openFileDialog As OpenFileDialog
End Class
