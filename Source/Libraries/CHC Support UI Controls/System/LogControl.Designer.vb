<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogControl
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
        Me.keepFileTypeLabel = New System.Windows.Forms.Label()
        Me.keepFileTypeValueCombo = New System.Windows.Forms.ComboBox()
        Me.keepOnlyRecentFileLabel = New System.Windows.Forms.Label()
        Me.keepOnlyRecentFileValueCombo = New System.Windows.Forms.ComboBox()
        Me.startCleanEveryLabel = New System.Windows.Forms.Label()
        Me.startCleanEveryValueCombo = New System.Windows.Forms.ComboBox()
        Me.autoCleanOptionCheck = New System.Windows.Forms.CheckBox()
        Me.trackConfigurationCombo = New System.Windows.Forms.ComboBox()
        Me.trackConfigurationLabel = New System.Windows.Forms.Label()
        Me.changeFileEvery = New System.Windows.Forms.Label()
        Me.maxHourMaintain = New CHCSupportUIControls.NumericText()
        Me.hourLabel = New System.Windows.Forms.Label()
        Me.numberRegistrations = New System.Windows.Forms.Label()
        Me.maxRegistrationNumbers = New CHCSupportUIControls.NumericText()
        Me.SuspendLayout()
        '
        'keepFileTypeLabel
        '
        Me.keepFileTypeLabel.AutoSize = True
        Me.keepFileTypeLabel.Enabled = False
        Me.keepFileTypeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keepFileTypeLabel.Location = New System.Drawing.Point(507, 92)
        Me.keepFileTypeLabel.Name = "keepFileTypeLabel"
        Me.keepFileTypeLabel.Size = New System.Drawing.Size(86, 13)
        Me.keepFileTypeLabel.TabIndex = 30
        Me.keepFileTypeLabel.Text = "Keep file type"
        '
        'keepFileTypeValueCombo
        '
        Me.keepFileTypeValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepFileTypeValueCombo.Enabled = False
        Me.keepFileTypeValueCombo.FormattingEnabled = True
        Me.keepFileTypeValueCombo.Items.AddRange(New Object() {"Nothing exclude", "Keep only main log"})
        Me.keepFileTypeValueCombo.Location = New System.Drawing.Point(510, 108)
        Me.keepFileTypeValueCombo.Name = "keepFileTypeValueCombo"
        Me.keepFileTypeValueCombo.Size = New System.Drawing.Size(150, 21)
        Me.keepFileTypeValueCombo.TabIndex = 26
        '
        'keepOnlyRecentFileLabel
        '
        Me.keepOnlyRecentFileLabel.AutoSize = True
        Me.keepOnlyRecentFileLabel.Enabled = False
        Me.keepOnlyRecentFileLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keepOnlyRecentFileLabel.Location = New System.Drawing.Point(252, 92)
        Me.keepOnlyRecentFileLabel.Name = "keepOnlyRecentFileLabel"
        Me.keepOnlyRecentFileLabel.Size = New System.Drawing.Size(125, 13)
        Me.keepOnlyRecentFileLabel.TabIndex = 29
        Me.keepOnlyRecentFileLabel.Text = "Keep only recent file"
        '
        'keepOnlyRecentFileValueCombo
        '
        Me.keepOnlyRecentFileValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepOnlyRecentFileValueCombo.Enabled = False
        Me.keepOnlyRecentFileValueCombo.FormattingEnabled = True
        Me.keepOnlyRecentFileValueCombo.Items.AddRange(New Object() {"last day", "last week", "last month", "last year"})
        Me.keepOnlyRecentFileValueCombo.Location = New System.Drawing.Point(255, 108)
        Me.keepOnlyRecentFileValueCombo.Name = "keepOnlyRecentFileValueCombo"
        Me.keepOnlyRecentFileValueCombo.Size = New System.Drawing.Size(207, 21)
        Me.keepOnlyRecentFileValueCombo.TabIndex = 25
        '
        'startCleanEveryLabel
        '
        Me.startCleanEveryLabel.AutoSize = True
        Me.startCleanEveryLabel.Enabled = False
        Me.startCleanEveryLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startCleanEveryLabel.Location = New System.Drawing.Point(10, 92)
        Me.startCleanEveryLabel.Name = "startCleanEveryLabel"
        Me.startCleanEveryLabel.Size = New System.Drawing.Size(100, 13)
        Me.startCleanEveryLabel.TabIndex = 28
        Me.startCleanEveryLabel.Text = "Frequency clean"
        '
        'startCleanEveryValueCombo
        '
        Me.startCleanEveryValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.startCleanEveryValueCombo.Enabled = False
        Me.startCleanEveryValueCombo.FormattingEnabled = True
        Me.startCleanEveryValueCombo.Items.AddRange(New Object() {"12 hours", "1 day"})
        Me.startCleanEveryValueCombo.Location = New System.Drawing.Point(13, 108)
        Me.startCleanEveryValueCombo.Name = "startCleanEveryValueCombo"
        Me.startCleanEveryValueCombo.Size = New System.Drawing.Size(207, 21)
        Me.startCleanEveryValueCombo.TabIndex = 24
        '
        'autoCleanOptionCheck
        '
        Me.autoCleanOptionCheck.AutoSize = True
        Me.autoCleanOptionCheck.BackColor = System.Drawing.Color.Transparent
        Me.autoCleanOptionCheck.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoCleanOptionCheck.Location = New System.Drawing.Point(13, 63)
        Me.autoCleanOptionCheck.Name = "autoCleanOptionCheck"
        Me.autoCleanOptionCheck.Size = New System.Drawing.Size(84, 17)
        Me.autoCleanOptionCheck.TabIndex = 23
        Me.autoCleanOptionCheck.Text = "Log rotate"
        Me.autoCleanOptionCheck.UseVisualStyleBackColor = False
        '
        'trackConfigurationCombo
        '
        Me.trackConfigurationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.trackConfigurationCombo.FormattingEnabled = True
        Me.trackConfigurationCombo.Items.AddRange(New Object() {"Don't track log events", "Track only bootstrap", "Track all runtime"})
        Me.trackConfigurationCombo.Location = New System.Drawing.Point(175, 3)
        Me.trackConfigurationCombo.Name = "trackConfigurationCombo"
        Me.trackConfigurationCombo.Size = New System.Drawing.Size(485, 21)
        Me.trackConfigurationCombo.TabIndex = 22
        '
        'trackConfigurationLabel
        '
        Me.trackConfigurationLabel.AutoSize = True
        Me.trackConfigurationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trackConfigurationLabel.Location = New System.Drawing.Point(8, 6)
        Me.trackConfigurationLabel.Name = "trackConfigurationLabel"
        Me.trackConfigurationLabel.Size = New System.Drawing.Size(116, 13)
        Me.trackConfigurationLabel.TabIndex = 27
        Me.trackConfigurationLabel.Text = "Track configuration"
        '
        'changeFileEvery
        '
        Me.changeFileEvery.AutoSize = True
        Me.changeFileEvery.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changeFileEvery.Location = New System.Drawing.Point(10, 33)
        Me.changeFileEvery.Name = "changeFileEvery"
        Me.changeFileEvery.Size = New System.Drawing.Size(111, 13)
        Me.changeFileEvery.TabIndex = 31
        Me.changeFileEvery.Text = "Change File Every"
        '
        'maxHourMaintain
        '
        Me.maxHourMaintain.currentFormat = ""
        Me.maxHourMaintain.Location = New System.Drawing.Point(175, 30)
        Me.maxHourMaintain.locationCode = "it-IT"
        Me.maxHourMaintain.Name = "maxHourMaintain"
        Me.maxHourMaintain.Size = New System.Drawing.Size(68, 21)
        Me.maxHourMaintain.TabIndex = 32
        Me.maxHourMaintain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.maxHourMaintain.useDecimal = False
        '
        'hourLabel
        '
        Me.hourLabel.AutoSize = True
        Me.hourLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hourLabel.Location = New System.Drawing.Point(247, 34)
        Me.hourLabel.Name = "hourLabel"
        Me.hourLabel.Size = New System.Drawing.Size(44, 13)
        Me.hourLabel.TabIndex = 33
        Me.hourLabel.Text = "hour/s"
        '
        'numberRegistrations
        '
        Me.numberRegistrations.AutoSize = True
        Me.numberRegistrations.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numberRegistrations.Location = New System.Drawing.Point(430, 33)
        Me.numberRegistrations.Name = "numberRegistrations"
        Me.numberRegistrations.Size = New System.Drawing.Size(156, 13)
        Me.numberRegistrations.TabIndex = 34
        Me.numberRegistrations.Text = "OR   Number registrations"
        '
        'maxRegistrationNumbers
        '
        Me.maxRegistrationNumbers.currentFormat = ""
        Me.maxRegistrationNumbers.Location = New System.Drawing.Point(592, 30)
        Me.maxRegistrationNumbers.locationCode = "it-IT"
        Me.maxRegistrationNumbers.Name = "maxRegistrationNumbers"
        Me.maxRegistrationNumbers.Size = New System.Drawing.Size(68, 21)
        Me.maxRegistrationNumbers.TabIndex = 35
        Me.maxRegistrationNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.maxRegistrationNumbers.useDecimal = False
        '
        'LogControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.maxRegistrationNumbers)
        Me.Controls.Add(Me.numberRegistrations)
        Me.Controls.Add(Me.hourLabel)
        Me.Controls.Add(Me.maxHourMaintain)
        Me.Controls.Add(Me.changeFileEvery)
        Me.Controls.Add(Me.keepFileTypeLabel)
        Me.Controls.Add(Me.keepFileTypeValueCombo)
        Me.Controls.Add(Me.keepOnlyRecentFileLabel)
        Me.Controls.Add(Me.keepOnlyRecentFileValueCombo)
        Me.Controls.Add(Me.startCleanEveryLabel)
        Me.Controls.Add(Me.startCleanEveryValueCombo)
        Me.Controls.Add(Me.autoCleanOptionCheck)
        Me.Controls.Add(Me.trackConfigurationCombo)
        Me.Controls.Add(Me.trackConfigurationLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "LogControl"
        Me.Size = New System.Drawing.Size(671, 143)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents keepFileTypeLabel As Label
    Friend WithEvents keepFileTypeValueCombo As ComboBox
    Friend WithEvents keepOnlyRecentFileLabel As Label
    Friend WithEvents keepOnlyRecentFileValueCombo As ComboBox
    Friend WithEvents startCleanEveryLabel As Label
    Friend WithEvents startCleanEveryValueCombo As ComboBox
    Friend WithEvents autoCleanOptionCheck As CheckBox
    Friend WithEvents trackConfigurationCombo As ComboBox
    Friend WithEvents trackConfigurationLabel As Label
    Friend WithEvents changeFileEvery As Label
    Friend WithEvents maxHourMaintain As NumericText
    Friend WithEvents hourLabel As Label
    Friend WithEvents numberRegistrations As Label
    Friend WithEvents maxRegistrationNumbers As NumericText
End Class
