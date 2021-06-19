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
        Me.SuspendLayout()
        '
        'keepFileTypeLabel
        '
        Me.keepFileTypeLabel.AutoSize = True
        Me.keepFileTypeLabel.Enabled = False
        Me.keepFileTypeLabel.Location = New System.Drawing.Point(433, 66)
        Me.keepFileTypeLabel.Name = "keepFileTypeLabel"
        Me.keepFileTypeLabel.Size = New System.Drawing.Size(71, 13)
        Me.keepFileTypeLabel.TabIndex = 30
        Me.keepFileTypeLabel.Text = "Keep file type"
        '
        'keepFileTypeValueCombo
        '
        Me.keepFileTypeValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepFileTypeValueCombo.Enabled = False
        Me.keepFileTypeValueCombo.FormattingEnabled = True
        Me.keepFileTypeValueCombo.Items.AddRange(New Object() {"Nothing exclude", "Keep only main log"})
        Me.keepFileTypeValueCombo.Location = New System.Drawing.Point(437, 82)
        Me.keepFileTypeValueCombo.Name = "keepFileTypeValueCombo"
        Me.keepFileTypeValueCombo.Size = New System.Drawing.Size(129, 21)
        Me.keepFileTypeValueCombo.TabIndex = 26
        '
        'keepOnlyRecentFileLabel
        '
        Me.keepOnlyRecentFileLabel.AutoSize = True
        Me.keepOnlyRecentFileLabel.Enabled = False
        Me.keepOnlyRecentFileLabel.Location = New System.Drawing.Point(215, 66)
        Me.keepOnlyRecentFileLabel.Name = "keepOnlyRecentFileLabel"
        Me.keepOnlyRecentFileLabel.Size = New System.Drawing.Size(103, 13)
        Me.keepOnlyRecentFileLabel.TabIndex = 29
        Me.keepOnlyRecentFileLabel.Text = "Keep only recent file"
        '
        'keepOnlyRecentFileValueCombo
        '
        Me.keepOnlyRecentFileValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.keepOnlyRecentFileValueCombo.Enabled = False
        Me.keepOnlyRecentFileValueCombo.FormattingEnabled = True
        Me.keepOnlyRecentFileValueCombo.Items.AddRange(New Object() {"last day", "last week", "last month", "last year"})
        Me.keepOnlyRecentFileValueCombo.Location = New System.Drawing.Point(219, 82)
        Me.keepOnlyRecentFileValueCombo.Name = "keepOnlyRecentFileValueCombo"
        Me.keepOnlyRecentFileValueCombo.Size = New System.Drawing.Size(178, 21)
        Me.keepOnlyRecentFileValueCombo.TabIndex = 25
        '
        'startCleanEveryLabel
        '
        Me.startCleanEveryLabel.AutoSize = True
        Me.startCleanEveryLabel.Enabled = False
        Me.startCleanEveryLabel.Location = New System.Drawing.Point(7, 66)
        Me.startCleanEveryLabel.Name = "startCleanEveryLabel"
        Me.startCleanEveryLabel.Size = New System.Drawing.Size(86, 13)
        Me.startCleanEveryLabel.TabIndex = 28
        Me.startCleanEveryLabel.Text = "Frequency clean"
        '
        'startCleanEveryValueCombo
        '
        Me.startCleanEveryValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.startCleanEveryValueCombo.Enabled = False
        Me.startCleanEveryValueCombo.FormattingEnabled = True
        Me.startCleanEveryValueCombo.Items.AddRange(New Object() {"12 hours", "1 day"})
        Me.startCleanEveryValueCombo.Location = New System.Drawing.Point(11, 82)
        Me.startCleanEveryValueCombo.Name = "startCleanEveryValueCombo"
        Me.startCleanEveryValueCombo.Size = New System.Drawing.Size(178, 21)
        Me.startCleanEveryValueCombo.TabIndex = 24
        '
        'autoCleanOptionCheck
        '
        Me.autoCleanOptionCheck.AutoSize = True
        Me.autoCleanOptionCheck.BackColor = System.Drawing.Color.Transparent
        Me.autoCleanOptionCheck.Location = New System.Drawing.Point(11, 37)
        Me.autoCleanOptionCheck.Name = "autoCleanOptionCheck"
        Me.autoCleanOptionCheck.Size = New System.Drawing.Size(74, 17)
        Me.autoCleanOptionCheck.TabIndex = 23
        Me.autoCleanOptionCheck.Text = "Log rotate"
        Me.autoCleanOptionCheck.UseVisualStyleBackColor = False
        '
        'trackConfigurationCombo
        '
        Me.trackConfigurationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.trackConfigurationCombo.FormattingEnabled = True
        Me.trackConfigurationCombo.Items.AddRange(New Object() {"Don't track log events", "Track only main", "Track all runtime"})
        Me.trackConfigurationCombo.Location = New System.Drawing.Point(150, 3)
        Me.trackConfigurationCombo.Name = "trackConfigurationCombo"
        Me.trackConfigurationCombo.Size = New System.Drawing.Size(416, 21)
        Me.trackConfigurationCombo.TabIndex = 22
        '
        'trackConfigurationLabel
        '
        Me.trackConfigurationLabel.AutoSize = True
        Me.trackConfigurationLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trackConfigurationLabel.Location = New System.Drawing.Point(7, 6)
        Me.trackConfigurationLabel.Name = "trackConfigurationLabel"
        Me.trackConfigurationLabel.Size = New System.Drawing.Size(116, 13)
        Me.trackConfigurationLabel.TabIndex = 27
        Me.trackConfigurationLabel.Text = "Track configuration"
        '
        'LogControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.keepFileTypeLabel)
        Me.Controls.Add(Me.keepFileTypeValueCombo)
        Me.Controls.Add(Me.keepOnlyRecentFileLabel)
        Me.Controls.Add(Me.keepOnlyRecentFileValueCombo)
        Me.Controls.Add(Me.startCleanEveryLabel)
        Me.Controls.Add(Me.startCleanEveryValueCombo)
        Me.Controls.Add(Me.autoCleanOptionCheck)
        Me.Controls.Add(Me.trackConfigurationCombo)
        Me.Controls.Add(Me.trackConfigurationLabel)
        Me.Name = "LogControl"
        Me.Size = New System.Drawing.Size(575, 108)
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
End Class
