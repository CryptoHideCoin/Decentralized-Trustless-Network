<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CounterSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CounterSettings))
        Me.saveButton = New System.Windows.Forms.Button()
        Me.everyLabel = New System.Windows.Forms.Label()
        Me.timeSlotCounter = New System.Windows.Forms.ComboBox()
        Me.writeToFile = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(281, 12)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 47)
        Me.saveButton.TabIndex = 14
        Me.saveButton.Text = "Update"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'everyLabel
        '
        Me.everyLabel.AutoSize = True
        Me.everyLabel.Location = New System.Drawing.Point(29, 29)
        Me.everyLabel.Name = "everyLabel"
        Me.everyLabel.Size = New System.Drawing.Size(59, 13)
        Me.everyLabel.TabIndex = 11
        Me.everyLabel.Text = "Time slot"
        '
        'timeSlotCounter
        '
        Me.timeSlotCounter.FormattingEnabled = True
        Me.timeSlotCounter.Items.AddRange(New Object() {"Second", "Minute", "Hour"})
        Me.timeSlotCounter.Location = New System.Drawing.Point(94, 26)
        Me.timeSlotCounter.Name = "timeSlotCounter"
        Me.timeSlotCounter.Size = New System.Drawing.Size(148, 21)
        Me.timeSlotCounter.TabIndex = 15
        '
        'writeToFile
        '
        Me.writeToFile.AutoSize = True
        Me.writeToFile.Location = New System.Drawing.Point(94, 66)
        Me.writeToFile.Name = "writeToFile"
        Me.writeToFile.Size = New System.Drawing.Size(92, 17)
        Me.writeToFile.TabIndex = 16
        Me.writeToFile.Text = "Write to file"
        Me.writeToFile.UseVisualStyleBackColor = True
        '
        'CounterSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(368, 95)
        Me.Controls.Add(Me.writeToFile)
        Me.Controls.Add(Me.timeSlotCounter)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.everyLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CounterSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Counter Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents saveButton As Button
    Friend WithEvents everyLabel As Label
    Friend WithEvents timeSlotCounter As ComboBox
    Friend WithEvents writeToFile As CheckBox
End Class
