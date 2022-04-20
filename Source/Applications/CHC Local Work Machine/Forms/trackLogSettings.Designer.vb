<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class trackLogSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(trackLogSettings))
        Me.changeFileBox = New System.Windows.Forms.GroupBox()
        Me.numberRegistrations = New CHCSupportUIControls.NumericText()
        Me.everyChangeFile = New CHCSupportUIControls.NumericText()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.everyLabel = New System.Windows.Forms.Label()
        Me.writeToFile = New System.Windows.Forms.CheckBox()
        Me.useBufferToWrite = New System.Windows.Forms.CheckBox()
        Me.trackConfiguration = New System.Windows.Forms.ComboBox()
        Me.trackConfigurationLabel = New System.Windows.Forms.Label()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.changeFileBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'changeFileBox
        '
        Me.changeFileBox.Controls.Add(Me.numberRegistrations)
        Me.changeFileBox.Controls.Add(Me.everyChangeFile)
        Me.changeFileBox.Controls.Add(Me.Label3)
        Me.changeFileBox.Controls.Add(Me.Label2)
        Me.changeFileBox.Controls.Add(Me.Label1)
        Me.changeFileBox.Controls.Add(Me.everyLabel)
        Me.changeFileBox.Location = New System.Drawing.Point(16, 133)
        Me.changeFileBox.Name = "changeFileBox"
        Me.changeFileBox.Size = New System.Drawing.Size(306, 111)
        Me.changeFileBox.TabIndex = 10
        Me.changeFileBox.TabStop = False
        Me.changeFileBox.Text = "Change file"
        '
        'numberRegistrations
        '
        Me.numberRegistrations.currentFormat = ""
        Me.numberRegistrations.Location = New System.Drawing.Point(143, 76)
        Me.numberRegistrations.locationCode = "it-IT"
        Me.numberRegistrations.Name = "numberRegistrations"
        Me.numberRegistrations.Size = New System.Drawing.Size(100, 21)
        Me.numberRegistrations.TabIndex = 7
        Me.numberRegistrations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numberRegistrations.useDecimal = False
        '
        'everyChangeFile
        '
        Me.everyChangeFile.currentFormat = ""
        Me.everyChangeFile.Location = New System.Drawing.Point(143, 28)
        Me.everyChangeFile.locationCode = "it-IT"
        Me.everyChangeFile.Name = "everyChangeFile"
        Me.everyChangeFile.Size = New System.Drawing.Size(100, 21)
        Me.everyChangeFile.TabIndex = 6
        Me.everyChangeFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.everyChangeFile.useDecimal = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(140, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "- - - OR - - -"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(250, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "hour/s"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Number registrations"
        '
        'everyLabel
        '
        Me.everyLabel.AutoSize = True
        Me.everyLabel.Location = New System.Drawing.Point(92, 31)
        Me.everyLabel.Name = "everyLabel"
        Me.everyLabel.Size = New System.Drawing.Size(40, 13)
        Me.everyLabel.TabIndex = 0
        Me.everyLabel.Text = "Every"
        '
        'writeToFile
        '
        Me.writeToFile.AutoSize = True
        Me.writeToFile.Location = New System.Drawing.Point(16, 101)
        Me.writeToFile.Name = "writeToFile"
        Me.writeToFile.Size = New System.Drawing.Size(92, 17)
        Me.writeToFile.TabIndex = 9
        Me.writeToFile.Text = "Write to file"
        Me.writeToFile.UseVisualStyleBackColor = True
        '
        'useBufferToWrite
        '
        Me.useBufferToWrite.AutoSize = True
        Me.useBufferToWrite.Location = New System.Drawing.Point(16, 68)
        Me.useBufferToWrite.Name = "useBufferToWrite"
        Me.useBufferToWrite.Size = New System.Drawing.Size(132, 17)
        Me.useBufferToWrite.TabIndex = 8
        Me.useBufferToWrite.Text = "Use buffer to write"
        Me.useBufferToWrite.UseVisualStyleBackColor = True
        '
        'trackConfiguration
        '
        Me.trackConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.trackConfiguration.FormattingEnabled = True
        Me.trackConfiguration.Items.AddRange(New Object() {"Don't track log events", "Track only bootstrap", "Track all runtime"})
        Me.trackConfiguration.Location = New System.Drawing.Point(16, 30)
        Me.trackConfiguration.Name = "trackConfiguration"
        Me.trackConfiguration.Size = New System.Drawing.Size(306, 21)
        Me.trackConfiguration.TabIndex = 7
        '
        'trackConfigurationLabel
        '
        Me.trackConfigurationLabel.AutoSize = True
        Me.trackConfigurationLabel.Location = New System.Drawing.Point(13, 14)
        Me.trackConfigurationLabel.Name = "trackConfigurationLabel"
        Me.trackConfigurationLabel.Size = New System.Drawing.Size(116, 13)
        Me.trackConfigurationLabel.TabIndex = 6
        Me.trackConfigurationLabel.Text = "Track configuration"
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(335, 28)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 47)
        Me.saveButton.TabIndex = 11
        Me.saveButton.Text = "Update"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'trackLogSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(423, 258)
        Me.Controls.Add(Me.changeFileBox)
        Me.Controls.Add(Me.writeToFile)
        Me.Controls.Add(Me.useBufferToWrite)
        Me.Controls.Add(Me.trackConfiguration)
        Me.Controls.Add(Me.trackConfigurationLabel)
        Me.Controls.Add(Me.saveButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "trackLogSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Remote Log Settings"
        Me.changeFileBox.ResumeLayout(False)
        Me.changeFileBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents changeFileBox As GroupBox
    Friend WithEvents numberRegistrations As CHCSupportUIControls.NumericText
    Friend WithEvents everyChangeFile As CHCSupportUIControls.NumericText
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents everyLabel As Label
    Friend WithEvents writeToFile As CheckBox
    Friend WithEvents useBufferToWrite As CheckBox
    Friend WithEvents trackConfiguration As ComboBox
    Friend WithEvents trackConfigurationLabel As Label
    Friend WithEvents saveButton As Button
End Class
