<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigurationManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigurationManager))
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.mainTab = New System.Windows.Forms.TabControl()
        Me.page2 = New System.Windows.Forms.TabPage()
        Me.page1Next = New System.Windows.Forms.Button()
        Me.serviceID = New System.Windows.Forms.TextBox()
        Me.serviceUUID = New System.Windows.Forms.Label()
        Me.urlProtocol = New CHCSupportUIControls.UrlProtocol()
        Me.page4 = New System.Windows.Forms.TabPage()
        Me.personalPublicAddress = New CHCSupportUIControls.WalletAddress()
        Me.page3 = New System.Windows.Forms.TabPage()
        Me.urlService = New CHCSupportUIControls.UrlProtocol()
        Me.adminPublicAddress = New CHCSupportUIControls.WalletAddress()
        Me.adminCertificate = New CHCSupportUIControls.Certificate()
        Me.deleteConfigurationButton = New System.Windows.Forms.Button()
        Me.newConfigurationButton = New System.Windows.Forms.Button()
        Me.saveConfigurationButton = New System.Windows.Forms.Button()
        Me.configurationLabel = New System.Windows.Forms.Label()
        Me.configurationNameCombo = New System.Windows.Forms.ComboBox()
        Me.browseLocalPathButton = New System.Windows.Forms.Button()
        Me.localPathData = New System.Windows.Forms.TextBox()
        Me.localPathLabel = New System.Windows.Forms.Label()
        Me.page2Next = New System.Windows.Forms.Button()
        Me.page2Previous = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.mainTab.SuspendLayout()
        Me.page2.SuspendLayout()
        Me.page4.SuspendLayout()
        Me.page3.SuspendLayout()
        Me.SuspendLayout()
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'mainTab
        '
        Me.mainTab.Controls.Add(Me.page2)
        Me.mainTab.Controls.Add(Me.page4)
        Me.mainTab.Controls.Add(Me.page3)
        Me.mainTab.Location = New System.Drawing.Point(12, 111)
        Me.mainTab.Name = "mainTab"
        Me.mainTab.SelectedIndex = 0
        Me.mainTab.Size = New System.Drawing.Size(716, 242)
        Me.mainTab.TabIndex = 6
        '
        'page2
        '
        Me.page2.Controls.Add(Me.page1Next)
        Me.page2.Controls.Add(Me.serviceID)
        Me.page2.Controls.Add(Me.serviceUUID)
        Me.page2.Controls.Add(Me.urlProtocol)
        Me.page2.Location = New System.Drawing.Point(4, 22)
        Me.page2.Name = "page2"
        Me.page2.Padding = New System.Windows.Forms.Padding(3)
        Me.page2.Size = New System.Drawing.Size(708, 216)
        Me.page2.TabIndex = 1
        Me.page2.Text = "Connection"
        Me.page2.UseVisualStyleBackColor = True
        '
        'page1Next
        '
        Me.page1Next.Location = New System.Drawing.Point(627, 187)
        Me.page1Next.Name = "page1Next"
        Me.page1Next.Size = New System.Drawing.Size(75, 23)
        Me.page1Next.TabIndex = 9
        Me.page1Next.Text = "&Next"
        Me.page1Next.UseVisualStyleBackColor = True
        '
        'serviceID
        '
        Me.serviceID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.serviceID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceID.Location = New System.Drawing.Point(136, 54)
        Me.serviceID.Name = "serviceID"
        Me.serviceID.Size = New System.Drawing.Size(403, 21)
        Me.serviceID.TabIndex = 8
        '
        'serviceUUID
        '
        Me.serviceUUID.AutoSize = True
        Me.serviceUUID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serviceUUID.Location = New System.Drawing.Point(62, 57)
        Me.serviceUUID.Name = "serviceUUID"
        Me.serviceUUID.Size = New System.Drawing.Size(68, 13)
        Me.serviceUUID.TabIndex = 39
        Me.serviceUUID.Text = "Service ID"
        '
        'urlProtocol
        '
        Me.urlProtocol.address = ""
        Me.urlProtocol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.urlProtocol.executeCommand = False
        Me.urlProtocol.Location = New System.Drawing.Point(17, 19)
        Me.urlProtocol.MinimumSize = New System.Drawing.Size(0, 29)
        Me.urlProtocol.Name = "urlProtocol"
        Me.urlProtocol.serviceId = ""
        Me.urlProtocol.Size = New System.Drawing.Size(660, 29)
        Me.urlProtocol.TabIndex = 7
        Me.urlProtocol.useSecure = False
        '
        'page4
        '
        Me.page4.Controls.Add(Me.page2Previous)
        Me.page4.Controls.Add(Me.page2Next)
        Me.page4.Controls.Add(Me.personalPublicAddress)
        Me.page4.Location = New System.Drawing.Point(4, 22)
        Me.page4.Name = "page4"
        Me.page4.Size = New System.Drawing.Size(708, 216)
        Me.page4.TabIndex = 3
        Me.page4.Text = "Personal KeyPair"
        Me.page4.UseVisualStyleBackColor = True
        '
        'personalPublicAddress
        '
        Me.personalPublicAddress.caption = "Public address"
        Me.personalPublicAddress.dataPath = ""
        Me.personalPublicAddress.Location = New System.Drawing.Point(28, 15)
        Me.personalPublicAddress.Name = "personalPublicAddress"
        Me.personalPublicAddress.Size = New System.Drawing.Size(662, 51)
        Me.personalPublicAddress.TabIndex = 1
        Me.personalPublicAddress.value = ""
        '
        'page3
        '
        Me.page3.Controls.Add(Me.Button1)
        Me.page3.Controls.Add(Me.urlService)
        Me.page3.Controls.Add(Me.adminPublicAddress)
        Me.page3.Controls.Add(Me.adminCertificate)
        Me.page3.Location = New System.Drawing.Point(4, 22)
        Me.page3.Name = "page3"
        Me.page3.Size = New System.Drawing.Size(708, 216)
        Me.page3.TabIndex = 2
        Me.page3.Text = "Administration"
        Me.page3.UseVisualStyleBackColor = True
        '
        'urlService
        '
        Me.urlService.address = ""
        Me.urlService.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.urlService.executeCommand = False
        Me.urlService.Location = New System.Drawing.Point(21, 13)
        Me.urlService.MinimumSize = New System.Drawing.Size(0, 29)
        Me.urlService.Name = "urlService"
        Me.urlService.serviceId = ""
        Me.urlService.Size = New System.Drawing.Size(673, 29)
        Me.urlService.TabIndex = 1
        Me.urlService.useSecure = False
        '
        'adminPublicAddress
        '
        Me.adminPublicAddress.caption = "Admin wallet address"
        Me.adminPublicAddress.dataPath = ""
        Me.adminPublicAddress.Location = New System.Drawing.Point(21, 84)
        Me.adminPublicAddress.Name = "adminPublicAddress"
        Me.adminPublicAddress.Size = New System.Drawing.Size(673, 51)
        Me.adminPublicAddress.TabIndex = 3
        Me.adminPublicAddress.value = ""
        '
        'adminCertificate
        '
        Me.adminCertificate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminCertificate.dataPath = ""
        Me.adminCertificate.Location = New System.Drawing.Point(21, 48)
        Me.adminCertificate.Name = "adminCertificate"
        Me.adminCertificate.noChange = False
        Me.adminCertificate.serviceId = ""
        Me.adminCertificate.Size = New System.Drawing.Size(673, 30)
        Me.adminCertificate.TabIndex = 2
        Me.adminCertificate.urlService = ""
        Me.adminCertificate.value = ""
        '
        'deleteConfigurationButton
        '
        Me.deleteConfigurationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.deleteConfigurationButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteConfigurationButton.Location = New System.Drawing.Point(564, 74)
        Me.deleteConfigurationButton.Name = "deleteConfigurationButton"
        Me.deleteConfigurationButton.Size = New System.Drawing.Size(61, 22)
        Me.deleteConfigurationButton.TabIndex = 5
        Me.deleteConfigurationButton.Text = "Delete"
        Me.deleteConfigurationButton.UseVisualStyleBackColor = True
        '
        'newConfigurationButton
        '
        Me.newConfigurationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.newConfigurationButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newConfigurationButton.Location = New System.Drawing.Point(459, 74)
        Me.newConfigurationButton.Name = "newConfigurationButton"
        Me.newConfigurationButton.Size = New System.Drawing.Size(49, 22)
        Me.newConfigurationButton.TabIndex = 3
        Me.newConfigurationButton.Text = "New"
        Me.newConfigurationButton.UseVisualStyleBackColor = True
        '
        'saveConfigurationButton
        '
        Me.saveConfigurationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveConfigurationButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveConfigurationButton.Location = New System.Drawing.Point(512, 74)
        Me.saveConfigurationButton.Name = "saveConfigurationButton"
        Me.saveConfigurationButton.Size = New System.Drawing.Size(49, 22)
        Me.saveConfigurationButton.TabIndex = 4
        Me.saveConfigurationButton.Text = "Save"
        Me.saveConfigurationButton.UseVisualStyleBackColor = True
        '
        'configurationLabel
        '
        Me.configurationLabel.AutoSize = True
        Me.configurationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.configurationLabel.Location = New System.Drawing.Point(13, 58)
        Me.configurationLabel.Name = "configurationLabel"
        Me.configurationLabel.Size = New System.Drawing.Size(84, 13)
        Me.configurationLabel.TabIndex = 25
        Me.configurationLabel.Text = "Configuration"
        '
        'configurationNameCombo
        '
        Me.configurationNameCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.configurationNameCombo.DisplayMember = "Text"
        Me.configurationNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.configurationNameCombo.FormattingEnabled = True
        Me.configurationNameCombo.Location = New System.Drawing.Point(16, 74)
        Me.configurationNameCombo.Name = "configurationNameCombo"
        Me.configurationNameCombo.Size = New System.Drawing.Size(439, 21)
        Me.configurationNameCombo.TabIndex = 2
        Me.configurationNameCombo.ValueMember = "Value"
        '
        'browseLocalPathButton
        '
        Me.browseLocalPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPathButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPathButton.Location = New System.Drawing.Point(632, 25)
        Me.browseLocalPathButton.Name = "browseLocalPathButton"
        Me.browseLocalPathButton.Size = New System.Drawing.Size(35, 22)
        Me.browseLocalPathButton.TabIndex = 1
        Me.browseLocalPathButton.Text = "..."
        Me.browseLocalPathButton.UseVisualStyleBackColor = True
        '
        'localPathData
        '
        Me.localPathData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathData.Location = New System.Drawing.Point(16, 26)
        Me.localPathData.Name = "localPathData"
        Me.localPathData.Size = New System.Drawing.Size(609, 21)
        Me.localPathData.TabIndex = 0
        '
        'localPathLabel
        '
        Me.localPathLabel.AutoSize = True
        Me.localPathLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathLabel.Location = New System.Drawing.Point(13, 9)
        Me.localPathLabel.Name = "localPathLabel"
        Me.localPathLabel.Size = New System.Drawing.Size(158, 13)
        Me.localPathLabel.TabIndex = 26
        Me.localPathLabel.Text = "Local Path && Configuration"
        '
        'page2Next
        '
        Me.page2Next.Location = New System.Drawing.Point(627, 187)
        Me.page2Next.Name = "page2Next"
        Me.page2Next.Size = New System.Drawing.Size(75, 23)
        Me.page2Next.TabIndex = 3
        Me.page2Next.Text = "&Next"
        Me.page2Next.UseVisualStyleBackColor = True
        '
        'page2Previous
        '
        Me.page2Previous.Location = New System.Drawing.Point(6, 187)
        Me.page2Previous.Name = "page2Previous"
        Me.page2Previous.Size = New System.Drawing.Size(75, 23)
        Me.page2Previous.TabIndex = 2
        Me.page2Previous.Text = "&Previous"
        Me.page2Previous.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 187)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Previous"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConfigurationManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(740, 370)
        Me.Controls.Add(Me.localPathLabel)
        Me.Controls.Add(Me.deleteConfigurationButton)
        Me.Controls.Add(Me.newConfigurationButton)
        Me.Controls.Add(Me.saveConfigurationButton)
        Me.Controls.Add(Me.configurationLabel)
        Me.Controls.Add(Me.configurationNameCombo)
        Me.Controls.Add(Me.browseLocalPathButton)
        Me.Controls.Add(Me.localPathData)
        Me.Controls.Add(Me.mainTab)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(756, 409)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(756, 409)
        Me.Name = "ConfigurationManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuration Manager"
        Me.mainTab.ResumeLayout(False)
        Me.page2.ResumeLayout(False)
        Me.page2.PerformLayout()
        Me.page4.ResumeLayout(False)
        Me.page3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents mainTab As TabControl
    Friend WithEvents page2 As TabPage
    Friend WithEvents serviceID As TextBox
    Friend WithEvents serviceUUID As Label
    Friend WithEvents urlProtocol As CHCSupportUIControls.UrlProtocol
    Friend WithEvents page4 As TabPage
    Friend WithEvents personalPublicAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents page3 As TabPage
    Friend WithEvents adminPublicAddress As CHCSupportUIControls.WalletAddress
    Friend WithEvents adminCertificate As CHCSupportUIControls.Certificate
    Friend WithEvents urlService As CHCSupportUIControls.UrlProtocol
    Friend WithEvents deleteConfigurationButton As Button
    Friend WithEvents newConfigurationButton As Button
    Friend WithEvents saveConfigurationButton As Button
    Friend WithEvents configurationLabel As Label
    Friend WithEvents configurationNameCombo As ComboBox
    Friend WithEvents browseLocalPathButton As Button
    Friend WithEvents localPathData As TextBox
    Friend WithEvents localPathLabel As Label
    Friend WithEvents page1Next As Button
    Friend WithEvents page2Next As Button
    Friend WithEvents page2Previous As Button
    Friend WithEvents Button1 As Button
End Class
