<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContentInformation
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.content = New System.Windows.Forms.TextBox()
        Me.contentLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'content
        '
        Me.content.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.content.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.content.Location = New System.Drawing.Point(22, 31)
        Me.content.Multiline = True
        Me.content.Name = "content"
        Me.content.ReadOnly = True
        Me.content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.content.Size = New System.Drawing.Size(517, 115)
        Me.content.TabIndex = 39
        Me.content.Text = "xxxx"
        '
        'contentLabel
        '
        Me.contentLabel.AutoSize = True
        Me.contentLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contentLabel.Location = New System.Drawing.Point(19, 15)
        Me.contentLabel.Name = "contentLabel"
        Me.contentLabel.Size = New System.Drawing.Size(52, 13)
        Me.contentLabel.TabIndex = 40
        Me.contentLabel.Text = "Content"
        '
        'ContentInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.contentLabel)
        Me.Controls.Add(Me.content)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ContentInformation"
        Me.Size = New System.Drawing.Size(563, 166)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents content As TextBox
    Friend WithEvents contentLabel As Label
End Class
