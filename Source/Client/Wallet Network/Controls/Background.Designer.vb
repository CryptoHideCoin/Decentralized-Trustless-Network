<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Background
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
        Me.pictureContainer = New System.Windows.Forms.PictureBox()
        Me.applicationName = New System.Windows.Forms.Label()
        Me.releaseApplication = New System.Windows.Forms.Label()
        CType(Me.pictureContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureContainer
        '
        Me.pictureContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureContainer.Image = Global.CHCWalletNetwork.My.Resources.Resources.BigBanner
        Me.pictureContainer.Location = New System.Drawing.Point(0, 0)
        Me.pictureContainer.Name = "pictureContainer"
        Me.pictureContainer.Size = New System.Drawing.Size(759, 462)
        Me.pictureContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureContainer.TabIndex = 2
        Me.pictureContainer.TabStop = False
        '
        'applicationName
        '
        Me.applicationName.AutoSize = True
        Me.applicationName.BackColor = System.Drawing.Color.White
        Me.applicationName.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.applicationName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.applicationName.Location = New System.Drawing.Point(13, 12)
        Me.applicationName.Name = "applicationName"
        Me.applicationName.Size = New System.Drawing.Size(140, 32)
        Me.applicationName.TabIndex = 3
        Me.applicationName.Text = "OXEANIX"
        '
        'releaseApplication
        '
        Me.releaseApplication.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.releaseApplication.AutoSize = True
        Me.releaseApplication.BackColor = System.Drawing.Color.White
        Me.releaseApplication.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.releaseApplication.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.releaseApplication.Location = New System.Drawing.Point(678, 434)
        Me.releaseApplication.Name = "releaseApplication"
        Me.releaseApplication.Size = New System.Drawing.Size(65, 13)
        Me.releaseApplication.TabIndex = 4
        Me.releaseApplication.Text = "Rel. xx.xx"
        '
        'Background
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.releaseApplication)
        Me.Controls.Add(Me.applicationName)
        Me.Controls.Add(Me.pictureContainer)
        Me.Name = "Background"
        Me.Size = New System.Drawing.Size(759, 462)
        CType(Me.pictureContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pictureContainer As PictureBox
    Friend WithEvents applicationName As Label
    Friend WithEvents releaseApplication As Label
End Class
