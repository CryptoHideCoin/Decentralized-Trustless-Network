<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataBot
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataBot))
        Me.idValue = New System.Windows.Forms.TextBox()
        Me.idLabel = New System.Windows.Forms.Label()
        Me.pairValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.examLimitValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bootstrapInitialValue = New System.Windows.Forms.CheckBox()
        Me.bootstrapCompleteValue = New System.Windows.Forms.CheckBox()
        Me.timeStartValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.plafondValue = New System.Windows.Forms.TextBox()
        Me.plafondLabel = New System.Windows.Forms.Label()
        Me.earnValue = New System.Windows.Forms.TextBox()
        Me.earnLabel = New System.Windows.Forms.Label()
        Me.lastBuyTimeValue = New System.Windows.Forms.TextBox()
        Me.lastBuyTimeLabel = New System.Windows.Forms.Label()
        Me.lastBuyValue = New System.Windows.Forms.TextBox()
        Me.lastBuyValueLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'idValue
        '
        Me.idValue.Location = New System.Drawing.Point(102, 12)
        Me.idValue.Name = "idValue"
        Me.idValue.ReadOnly = True
        Me.idValue.Size = New System.Drawing.Size(457, 21)
        Me.idValue.TabIndex = 4
        '
        'idLabel
        '
        Me.idLabel.AutoSize = True
        Me.idLabel.Location = New System.Drawing.Point(75, 15)
        Me.idLabel.Name = "idLabel"
        Me.idLabel.Size = New System.Drawing.Size(21, 13)
        Me.idLabel.TabIndex = 3
        Me.idLabel.Text = "ID"
        '
        'pairValue
        '
        Me.pairValue.Location = New System.Drawing.Point(102, 39)
        Me.pairValue.Name = "pairValue"
        Me.pairValue.ReadOnly = True
        Me.pairValue.Size = New System.Drawing.Size(457, 21)
        Me.pairValue.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Pair"
        '
        'examLimitValue
        '
        Me.examLimitValue.Location = New System.Drawing.Point(102, 90)
        Me.examLimitValue.Name = "examLimitValue"
        Me.examLimitValue.ReadOnly = True
        Me.examLimitValue.Size = New System.Drawing.Size(457, 21)
        Me.examLimitValue.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Exam Limit"
        '
        'bootstrapInitialValue
        '
        Me.bootstrapInitialValue.AutoSize = True
        Me.bootstrapInitialValue.Enabled = False
        Me.bootstrapInitialValue.Location = New System.Drawing.Point(102, 67)
        Me.bootstrapInitialValue.Name = "bootstrapInitialValue"
        Me.bootstrapInitialValue.Size = New System.Drawing.Size(115, 17)
        Me.bootstrapInitialValue.TabIndex = 9
        Me.bootstrapInitialValue.Text = "Bootstrap initial"
        Me.bootstrapInitialValue.UseVisualStyleBackColor = True
        '
        'bootstrapCompleteValue
        '
        Me.bootstrapCompleteValue.AutoSize = True
        Me.bootstrapCompleteValue.Enabled = False
        Me.bootstrapCompleteValue.Location = New System.Drawing.Point(311, 67)
        Me.bootstrapCompleteValue.Name = "bootstrapCompleteValue"
        Me.bootstrapCompleteValue.Size = New System.Drawing.Size(130, 17)
        Me.bootstrapCompleteValue.TabIndex = 10
        Me.bootstrapCompleteValue.Text = "Botstrap complete"
        Me.bootstrapCompleteValue.UseVisualStyleBackColor = True
        '
        'timeStartValue
        '
        Me.timeStartValue.Location = New System.Drawing.Point(102, 117)
        Me.timeStartValue.Name = "timeStartValue"
        Me.timeStartValue.ReadOnly = True
        Me.timeStartValue.Size = New System.Drawing.Size(457, 21)
        Me.timeStartValue.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Time start"
        '
        'mainTimer
        '
        Me.mainTimer.Enabled = True
        Me.mainTimer.Interval = 1000
        '
        'plafondValue
        '
        Me.plafondValue.Location = New System.Drawing.Point(102, 144)
        Me.plafondValue.Name = "plafondValue"
        Me.plafondValue.ReadOnly = True
        Me.plafondValue.Size = New System.Drawing.Size(457, 21)
        Me.plafondValue.TabIndex = 14
        Me.plafondValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'plafondLabel
        '
        Me.plafondLabel.AutoSize = True
        Me.plafondLabel.Location = New System.Drawing.Point(15, 147)
        Me.plafondLabel.Name = "plafondLabel"
        Me.plafondLabel.Size = New System.Drawing.Size(81, 13)
        Me.plafondLabel.TabIndex = 13
        Me.plafondLabel.Text = "Used Plafond"
        '
        'earnValue
        '
        Me.earnValue.Location = New System.Drawing.Point(102, 171)
        Me.earnValue.Name = "earnValue"
        Me.earnValue.ReadOnly = True
        Me.earnValue.Size = New System.Drawing.Size(457, 21)
        Me.earnValue.TabIndex = 16
        Me.earnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'earnLabel
        '
        Me.earnLabel.AutoSize = True
        Me.earnLabel.Location = New System.Drawing.Point(63, 174)
        Me.earnLabel.Name = "earnLabel"
        Me.earnLabel.Size = New System.Drawing.Size(33, 13)
        Me.earnLabel.TabIndex = 15
        Me.earnLabel.Text = "Earn"
        '
        'lastBuyTimeValue
        '
        Me.lastBuyTimeValue.Location = New System.Drawing.Point(102, 198)
        Me.lastBuyTimeValue.Name = "lastBuyTimeValue"
        Me.lastBuyTimeValue.ReadOnly = True
        Me.lastBuyTimeValue.Size = New System.Drawing.Size(457, 21)
        Me.lastBuyTimeValue.TabIndex = 18
        '
        'lastBuyTimeLabel
        '
        Me.lastBuyTimeLabel.AutoSize = True
        Me.lastBuyTimeLabel.Location = New System.Drawing.Point(12, 201)
        Me.lastBuyTimeLabel.Name = "lastBuyTimeLabel"
        Me.lastBuyTimeLabel.Size = New System.Drawing.Size(84, 13)
        Me.lastBuyTimeLabel.TabIndex = 17
        Me.lastBuyTimeLabel.Text = "Last buy time"
        '
        'lastBuyValue
        '
        Me.lastBuyValue.Location = New System.Drawing.Point(102, 225)
        Me.lastBuyValue.Name = "lastBuyValue"
        Me.lastBuyValue.ReadOnly = True
        Me.lastBuyValue.Size = New System.Drawing.Size(457, 21)
        Me.lastBuyValue.TabIndex = 20
        Me.lastBuyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lastBuyValueLabel
        '
        Me.lastBuyValueLabel.AutoSize = True
        Me.lastBuyValueLabel.Location = New System.Drawing.Point(6, 228)
        Me.lastBuyValueLabel.Name = "lastBuyValueLabel"
        Me.lastBuyValueLabel.Size = New System.Drawing.Size(90, 13)
        Me.lastBuyValueLabel.TabIndex = 19
        Me.lastBuyValueLabel.Text = "Last buy value"
        '
        'DataBot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 259)
        Me.Controls.Add(Me.lastBuyValue)
        Me.Controls.Add(Me.lastBuyValueLabel)
        Me.Controls.Add(Me.lastBuyTimeValue)
        Me.Controls.Add(Me.lastBuyTimeLabel)
        Me.Controls.Add(Me.earnValue)
        Me.Controls.Add(Me.earnLabel)
        Me.Controls.Add(Me.plafondValue)
        Me.Controls.Add(Me.plafondLabel)
        Me.Controls.Add(Me.timeStartValue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.bootstrapCompleteValue)
        Me.Controls.Add(Me.bootstrapInitialValue)
        Me.Controls.Add(Me.examLimitValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pairValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.idValue)
        Me.Controls.Add(Me.idLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DataBot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Bot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents idValue As TextBox
    Friend WithEvents idLabel As Label
    Friend WithEvents pairValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents examLimitValue As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents bootstrapInitialValue As CheckBox
    Friend WithEvents bootstrapCompleteValue As CheckBox
    Friend WithEvents timeStartValue As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents mainTimer As Timer
    Friend WithEvents plafondValue As TextBox
    Friend WithEvents plafondLabel As Label
    Friend WithEvents earnValue As TextBox
    Friend WithEvents earnLabel As Label
    Friend WithEvents lastBuyTimeValue As TextBox
    Friend WithEvents lastBuyTimeLabel As Label
    Friend WithEvents lastBuyValue As TextBox
    Friend WithEvents lastBuyValueLabel As Label
End Class
