<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowLogConfiguration
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
        Me.groupMain = New System.Windows.Forms.GroupBox()
        Me.showAllTracks = New System.Windows.Forms.RadioButton()
        Me.showOnlyInfo = New System.Windows.Forms.RadioButton()
        Me.inPause = New System.Windows.Forms.CheckBox()
        Me.frequencyRefresh = New System.Windows.Forms.NumericUpDown()
        Me.frequencyRefreshLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.groupMain.SuspendLayout()
        CType(Me.frequencyRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupMain
        '
        Me.groupMain.Controls.Add(Me.showAllTracks)
        Me.groupMain.Controls.Add(Me.showOnlyInfo)
        Me.groupMain.Location = New System.Drawing.Point(12, 12)
        Me.groupMain.Name = "groupMain"
        Me.groupMain.Size = New System.Drawing.Size(247, 106)
        Me.groupMain.TabIndex = 0
        Me.groupMain.TabStop = False
        Me.groupMain.Text = "Mode"
        '
        'showAllTracks
        '
        Me.showAllTracks.AutoSize = True
        Me.showAllTracks.Location = New System.Drawing.Point(20, 66)
        Me.showAllTracks.Name = "showAllTracks"
        Me.showAllTracks.Size = New System.Drawing.Size(112, 17)
        Me.showAllTracks.TabIndex = 1
        Me.showAllTracks.TabStop = True
        Me.showAllTracks.Text = "Show all tracks"
        Me.showAllTracks.UseVisualStyleBackColor = True
        '
        'showOnlyInfo
        '
        Me.showOnlyInfo.AutoSize = True
        Me.showOnlyInfo.Location = New System.Drawing.Point(20, 31)
        Me.showOnlyInfo.Name = "showOnlyInfo"
        Me.showOnlyInfo.Size = New System.Drawing.Size(173, 17)
        Me.showOnlyInfo.TabIndex = 0
        Me.showOnlyInfo.TabStop = True
        Me.showOnlyInfo.Text = "Show only info and errors"
        Me.showOnlyInfo.UseVisualStyleBackColor = True
        '
        'inPause
        '
        Me.inPause.AutoSize = True
        Me.inPause.Location = New System.Drawing.Point(105, 130)
        Me.inPause.Name = "inPause"
        Me.inPause.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.inPause.Size = New System.Drawing.Size(154, 17)
        Me.inPause.TabIndex = 3
        Me.inPause.Text = "Stop show information"
        Me.inPause.UseVisualStyleBackColor = True
        '
        'frequencyRefresh
        '
        Me.frequencyRefresh.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.frequencyRefresh.Location = New System.Drawing.Point(150, 160)
        Me.frequencyRefresh.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.frequencyRefresh.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.frequencyRefresh.Name = "frequencyRefresh"
        Me.frequencyRefresh.Size = New System.Drawing.Size(81, 21)
        Me.frequencyRefresh.TabIndex = 4
        Me.frequencyRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.frequencyRefresh.ThousandsSeparator = True
        Me.frequencyRefresh.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'frequencyRefreshLabel
        '
        Me.frequencyRefreshLabel.AutoSize = True
        Me.frequencyRefreshLabel.Location = New System.Drawing.Point(35, 163)
        Me.frequencyRefreshLabel.Name = "frequencyRefreshLabel"
        Me.frequencyRefreshLabel.Size = New System.Drawing.Size(111, 13)
        Me.frequencyRefreshLabel.TabIndex = 5
        Me.frequencyRefreshLabel.Text = "Frequency refresh"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(235, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ms."
        '
        'ShowLogConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(272, 198)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.frequencyRefreshLabel)
        Me.Controls.Add(Me.frequencyRefresh)
        Me.Controls.Add(Me.inPause)
        Me.Controls.Add(Me.groupMain)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ShowLogConfiguration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Show Log Configuration"
        Me.groupMain.ResumeLayout(False)
        Me.groupMain.PerformLayout()
        CType(Me.frequencyRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents groupMain As GroupBox
    Friend WithEvents showAllTracks As RadioButton
    Friend WithEvents showOnlyInfo As RadioButton
    Friend WithEvents inPause As CheckBox
    Friend WithEvents frequencyRefresh As NumericUpDown
    Friend WithEvents frequencyRefreshLabel As Label
    Friend WithEvents Label1 As Label
End Class
