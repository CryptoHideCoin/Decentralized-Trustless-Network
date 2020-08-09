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
        Me.refreshButton = New System.Windows.Forms.Button()
        Me.stopButton = New System.Windows.Forms.Button()
        Me.startButton = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.rememberThis = New System.Windows.Forms.CheckBox()
        Me.useEventRegistry = New System.Windows.Forms.CheckBox()
        Me.writeLogFile = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.certificateClient = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.certificateMasternodeStart = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.masternodeStartUrl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.certificateMasternodeRuntime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.masternodeRuntimeURL = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.localPathAndDataPortNumber = New System.Windows.Forms.GroupBox()
        Me.localPortNumber = New System.Windows.Forms.TextBox()
        Me.portNumberLabel = New System.Windows.Forms.Label()
        Me.browseLocalPath = New System.Windows.Forms.Button()
        Me.localPathData = New System.Windows.Forms.TextBox()
        Me.LogTab = New System.Windows.Forms.TabPage()
        Me.logConsoleText = New System.Windows.Forms.TextBox()
        Me.logFileButton = New System.Windows.Forms.Button()
        Me.registryEventButton = New System.Windows.Forms.Button()
        Me.tabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.localPathAndDataPortNumber.SuspendLayout()
        Me.LogTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'refreshButton
        '
        Me.refreshButton.Enabled = False
        Me.refreshButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refreshButton.Location = New System.Drawing.Point(626, 361)
        Me.refreshButton.Name = "refreshButton"
        Me.refreshButton.Size = New System.Drawing.Size(91, 49)
        Me.refreshButton.TabIndex = 13
        Me.refreshButton.Text = "Refresh"
        Me.refreshButton.UseVisualStyleBackColor = True
        '
        'stopButton
        '
        Me.stopButton.Enabled = False
        Me.stopButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stopButton.Location = New System.Drawing.Point(626, 111)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(91, 49)
        Me.stopButton.TabIndex = 11
        Me.stopButton.Text = "STOP []"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'startButton
        '
        Me.startButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startButton.Location = New System.Drawing.Point(626, 52)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(91, 49)
        Me.startButton.TabIndex = 10
        Me.startButton.Text = "RUN >>"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.TabPage1)
        Me.tabControl.Controls.Add(Me.LogTab)
        Me.tabControl.Location = New System.Drawing.Point(12, 16)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(608, 455)
        Me.tabControl.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.rememberThis)
        Me.TabPage1.Controls.Add(Me.useEventRegistry)
        Me.TabPage1.Controls.Add(Me.writeLogFile)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.localPathAndDataPortNumber)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(600, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Console"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'rememberThis
        '
        Me.rememberThis.AutoSize = True
        Me.rememberThis.Checked = True
        Me.rememberThis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rememberThis.Location = New System.Drawing.Point(85, 401)
        Me.rememberThis.Name = "rememberThis"
        Me.rememberThis.Size = New System.Drawing.Size(135, 17)
        Me.rememberThis.TabIndex = 23
        Me.rememberThis.Text = "Remember this settings"
        Me.rememberThis.UseVisualStyleBackColor = True
        '
        'useEventRegistry
        '
        Me.useEventRegistry.AutoSize = True
        Me.useEventRegistry.Checked = True
        Me.useEventRegistry.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useEventRegistry.Location = New System.Drawing.Point(284, 378)
        Me.useEventRegistry.Name = "useEventRegistry"
        Me.useEventRegistry.Size = New System.Drawing.Size(117, 17)
        Me.useEventRegistry.TabIndex = 22
        Me.useEventRegistry.Text = "Use Event Registry"
        Me.useEventRegistry.UseVisualStyleBackColor = True
        '
        'writeLogFile
        '
        Me.writeLogFile.AutoSize = True
        Me.writeLogFile.Checked = True
        Me.writeLogFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.writeLogFile.Location = New System.Drawing.Point(85, 378)
        Me.writeLogFile.Name = "writeLogFile"
        Me.writeLogFile.Size = New System.Drawing.Size(91, 17)
        Me.writeLogFile.TabIndex = 21
        Me.writeLogFile.Text = "Write Log File"
        Me.writeLogFile.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.certificateClient)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(5, 310)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(589, 61)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Client"
        '
        'certificateClient
        '
        Me.certificateClient.Enabled = False
        Me.certificateClient.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateClient.Location = New System.Drawing.Point(80, 28)
        Me.certificateClient.Name = "certificateClient"
        Me.certificateClient.Size = New System.Drawing.Size(503, 21)
        Me.certificateClient.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Certificate"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.certificateMasternodeStart)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.masternodeStartUrl)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(588, 91)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Masternode Start"
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(506, 51)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(27, 22)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "..."
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(539, 25)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 48)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Test"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'certificateMasternodeStart
        '
        Me.certificateMasternodeStart.Enabled = False
        Me.certificateMasternodeStart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeStart.Location = New System.Drawing.Point(79, 52)
        Me.certificateMasternodeStart.Name = "certificateMasternodeStart"
        Me.certificateMasternodeStart.Size = New System.Drawing.Size(423, 21)
        Me.certificateMasternodeStart.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Certificate"
        '
        'masternodeStartUrl
        '
        Me.masternodeStartUrl.Enabled = False
        Me.masternodeStartUrl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeStartUrl.Location = New System.Drawing.Point(79, 26)
        Me.masternodeStartUrl.Name = "masternodeStartUrl"
        Me.masternodeStartUrl.Size = New System.Drawing.Size(454, 21)
        Me.masternodeStartUrl.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "URL"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.certificateMasternodeRuntime)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.masternodeRuntimeURL)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(5, 213)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(589, 91)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Masternode Runtime"
        '
        'Button7
        '
        Me.Button7.Enabled = False
        Me.Button7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(507, 51)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(27, 22)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "..."
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(540, 25)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(43, 48)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Test"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'certificateMasternodeRuntime
        '
        Me.certificateMasternodeRuntime.Enabled = False
        Me.certificateMasternodeRuntime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.certificateMasternodeRuntime.Location = New System.Drawing.Point(80, 52)
        Me.certificateMasternodeRuntime.Name = "certificateMasternodeRuntime"
        Me.certificateMasternodeRuntime.Size = New System.Drawing.Size(423, 21)
        Me.certificateMasternodeRuntime.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Certificate"
        '
        'masternodeRuntimeURL
        '
        Me.masternodeRuntimeURL.Enabled = False
        Me.masternodeRuntimeURL.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masternodeRuntimeURL.Location = New System.Drawing.Point(80, 26)
        Me.masternodeRuntimeURL.Name = "masternodeRuntimeURL"
        Me.masternodeRuntimeURL.Size = New System.Drawing.Size(454, 21)
        Me.masternodeRuntimeURL.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "URL"
        '
        'localPathAndDataPortNumber
        '
        Me.localPathAndDataPortNumber.Controls.Add(Me.localPortNumber)
        Me.localPathAndDataPortNumber.Controls.Add(Me.portNumberLabel)
        Me.localPathAndDataPortNumber.Controls.Add(Me.browseLocalPath)
        Me.localPathAndDataPortNumber.Controls.Add(Me.localPathData)
        Me.localPathAndDataPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathAndDataPortNumber.Location = New System.Drawing.Point(6, 6)
        Me.localPathAndDataPortNumber.Name = "localPathAndDataPortNumber"
        Me.localPathAndDataPortNumber.Size = New System.Drawing.Size(588, 104)
        Me.localPathAndDataPortNumber.TabIndex = 17
        Me.localPathAndDataPortNumber.TabStop = False
        Me.localPathAndDataPortNumber.Text = "Local path data and port number"
        '
        'localPortNumber
        '
        Me.localPortNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPortNumber.Location = New System.Drawing.Point(471, 66)
        Me.localPortNumber.Name = "localPortNumber"
        Me.localPortNumber.Size = New System.Drawing.Size(75, 21)
        Me.localPortNumber.TabIndex = 3
        Me.localPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'portNumberLabel
        '
        Me.portNumberLabel.AutoSize = True
        Me.portNumberLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.portNumberLabel.Location = New System.Drawing.Point(323, 69)
        Me.portNumberLabel.Name = "portNumberLabel"
        Me.portNumberLabel.Size = New System.Drawing.Size(142, 13)
        Me.portNumberLabel.TabIndex = 2
        Me.portNumberLabel.Text = "Port number (1..65535)"
        '
        'browseLocalPath
        '
        Me.browseLocalPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPath.Location = New System.Drawing.Point(552, 28)
        Me.browseLocalPath.Name = "browseLocalPath"
        Me.browseLocalPath.Size = New System.Drawing.Size(30, 23)
        Me.browseLocalPath.TabIndex = 1
        Me.browseLocalPath.Text = "..."
        Me.browseLocalPath.UseVisualStyleBackColor = True
        '
        'localPathData
        '
        Me.localPathData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathData.Location = New System.Drawing.Point(7, 30)
        Me.localPathData.Name = "localPathData"
        Me.localPathData.Size = New System.Drawing.Size(539, 21)
        Me.localPathData.TabIndex = 0
        '
        'LogTab
        '
        Me.LogTab.Controls.Add(Me.logConsoleText)
        Me.LogTab.Location = New System.Drawing.Point(4, 22)
        Me.LogTab.Name = "LogTab"
        Me.LogTab.Padding = New System.Windows.Forms.Padding(3)
        Me.LogTab.Size = New System.Drawing.Size(600, 429)
        Me.LogTab.TabIndex = 1
        Me.LogTab.Text = "Output"
        Me.LogTab.UseVisualStyleBackColor = True
        '
        'logConsoleText
        '
        Me.logConsoleText.BackColor = System.Drawing.Color.Black
        Me.logConsoleText.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logConsoleText.ForeColor = System.Drawing.SystemColors.Info
        Me.logConsoleText.Location = New System.Drawing.Point(6, 6)
        Me.logConsoleText.Multiline = True
        Me.logConsoleText.Name = "logConsoleText"
        Me.logConsoleText.ReadOnly = True
        Me.logConsoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.logConsoleText.Size = New System.Drawing.Size(590, 417)
        Me.logConsoleText.TabIndex = 0
        Me.logConsoleText.Text = "01234567890123456789012345678901234567890123456789012345678901234567890123456789"
        '
        'logFileButton
        '
        Me.logFileButton.Enabled = False
        Me.logFileButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logFileButton.Location = New System.Drawing.Point(626, 198)
        Me.logFileButton.Name = "logFileButton"
        Me.logFileButton.Size = New System.Drawing.Size(91, 49)
        Me.logFileButton.TabIndex = 18
        Me.logFileButton.Text = "Log file"
        Me.logFileButton.UseVisualStyleBackColor = True
        '
        'registryEventButton
        '
        Me.registryEventButton.Enabled = False
        Me.registryEventButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registryEventButton.Location = New System.Drawing.Point(626, 253)
        Me.registryEventButton.Name = "registryEventButton"
        Me.registryEventButton.Size = New System.Drawing.Size(91, 49)
        Me.registryEventButton.TabIndex = 19
        Me.registryEventButton.Text = "Registry Events"
        Me.registryEventButton.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(729, 483)
        Me.Controls.Add(Me.registryEventButton)
        Me.Controls.Add(Me.logFileButton)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.refreshButton)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.startButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crypto Hide Coin - Masternode Admin Service GUI"
        Me.tabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.localPathAndDataPortNumber.ResumeLayout(False)
        Me.localPathAndDataPortNumber.PerformLayout()
        Me.LogTab.ResumeLayout(False)
        Me.LogTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents refreshButton As Button
    Friend WithEvents stopButton As Button
    Friend WithEvents startButton As Button
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents tabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents rememberThis As CheckBox
    Friend WithEvents useEventRegistry As CheckBox
    Friend WithEvents writeLogFile As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents certificateClient As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents certificateMasternodeStart As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents masternodeStartUrl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents certificateMasternodeRuntime As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents masternodeRuntimeURL As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents localPathAndDataPortNumber As GroupBox
    Friend WithEvents localPortNumber As TextBox
    Friend WithEvents portNumberLabel As Label
    Friend WithEvents browseLocalPath As Button
    Friend WithEvents localPathData As TextBox
    Friend WithEvents LogTab As TabPage
    Friend WithEvents logConsoleText As TextBox
    Friend WithEvents logFileButton As Button
    Friend WithEvents registryEventButton As Button
End Class
