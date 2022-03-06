<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplyPanel
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
        Me.titleControl = New System.Windows.Forms.Label()
        Me.supplyDetailInformation = New CHCWalletNetwork.SupplyDetail()
        Me.SuspendLayout()
        '
        'titleControl
        '
        Me.titleControl.AutoSize = True
        Me.titleControl.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleControl.Location = New System.Drawing.Point(4, 4)
        Me.titleControl.Name = "titleControl"
        Me.titleControl.Size = New System.Drawing.Size(93, 25)
        Me.titleControl.TabIndex = 13
        Me.titleControl.Text = "Supply"
        '
        'supplyDetailInformation
        '
        Me.supplyDetailInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.supplyDetailInformation.BackColor = System.Drawing.Color.White
        Me.supplyDetailInformation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplyDetailInformation.Location = New System.Drawing.Point(0, 35)
        Me.supplyDetailInformation.Name = "supplyDetailInformation"
        Me.supplyDetailInformation.Size = New System.Drawing.Size(756, 427)
        Me.supplyDetailInformation.TabIndex = 14
        '
        'SupplyPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.supplyDetailInformation)
        Me.Controls.Add(Me.titleControl)
        Me.Name = "SupplyPanel"
        Me.Size = New System.Drawing.Size(759, 462)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titleControl As Label
    Friend WithEvents supplyDetailInformation As SupplyDetail
End Class
