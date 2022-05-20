<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerformanceProfilerSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerformanceProfilerSettings))
        Me.everyProcess = New CHCSupportUIControls.NumericText()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.everyLabel = New System.Windows.Forms.Label()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'everyProcess
        '
        Me.everyProcess.currentFormat = ""
        Me.everyProcess.Location = New System.Drawing.Point(81, 24)
        Me.everyProcess.locationCode = "it-IT"
        Me.everyProcess.Name = "everyProcess"
        Me.everyProcess.Size = New System.Drawing.Size(100, 21)
        Me.everyProcess.TabIndex = 9
        Me.everyProcess.Text = "0"
        Me.everyProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.everyProcess.useDecimal = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(188, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "hour/s"
        '
        'everyLabel
        '
        Me.everyLabel.AutoSize = True
        Me.everyLabel.Location = New System.Drawing.Point(30, 27)
        Me.everyLabel.Name = "everyLabel"
        Me.everyLabel.Size = New System.Drawing.Size(40, 13)
        Me.everyLabel.TabIndex = 7
        Me.everyLabel.Text = "Every"
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(257, 10)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 47)
        Me.saveButton.TabIndex = 10
        Me.saveButton.Text = "Update"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'PerformanceProfilerSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(343, 67)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.everyProcess)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.everyLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PerformanceProfilerSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Performance Profile Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents everyProcess As CHCSupportUIControls.NumericText
    Friend WithEvents Label2 As Label
    Friend WithEvents everyLabel As Label
    Friend WithEvents saveButton As Button
End Class
