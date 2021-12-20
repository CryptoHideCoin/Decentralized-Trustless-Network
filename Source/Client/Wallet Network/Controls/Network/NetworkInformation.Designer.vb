<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NetworkInformation
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
        Me.specialEnvironment = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.networkName = New System.Windows.Forms.TextBox()
        Me.networkNameLabel = New System.Windows.Forms.Label()
        Me.netWorkID = New System.Windows.Forms.TextBox()
        Me.netWorkIDLabel = New System.Windows.Forms.Label()
        Me.netWorkCreationDate = New System.Windows.Forms.TextBox()
        Me.netWorkCreationDateLabel = New System.Windows.Forms.Label()
        Me.publicAddressCreator = New System.Windows.Forms.TextBox()
        Me.publicAddressOwnerLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'specialEnvironment
        '
        Me.specialEnvironment.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.specialEnvironment.Location = New System.Drawing.Point(22, 80)
        Me.specialEnvironment.Name = "specialEnvironment"
        Me.specialEnvironment.ReadOnly = True
        Me.specialEnvironment.Size = New System.Drawing.Size(179, 21)
        Me.specialEnvironment.TabIndex = 38
        Me.specialEnvironment.Text = "xxxx"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Special Environment"
        '
        'networkName
        '
        Me.networkName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.networkName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkName.Location = New System.Drawing.Point(22, 31)
        Me.networkName.Name = "networkName"
        Me.networkName.ReadOnly = True
        Me.networkName.Size = New System.Drawing.Size(495, 21)
        Me.networkName.TabIndex = 36
        Me.networkName.Text = "xxxx"
        '
        'networkNameLabel
        '
        Me.networkNameLabel.AutoSize = True
        Me.networkNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.networkNameLabel.Location = New System.Drawing.Point(19, 15)
        Me.networkNameLabel.Name = "networkNameLabel"
        Me.networkNameLabel.Size = New System.Drawing.Size(90, 13)
        Me.networkNameLabel.TabIndex = 37
        Me.networkNameLabel.Text = "Network name"
        '
        'netWorkID
        '
        Me.netWorkID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.netWorkID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkID.Location = New System.Drawing.Point(22, 128)
        Me.netWorkID.Name = "netWorkID"
        Me.netWorkID.ReadOnly = True
        Me.netWorkID.Size = New System.Drawing.Size(495, 21)
        Me.netWorkID.TabIndex = 40
        Me.netWorkID.Text = "xxxx"
        '
        'netWorkIDLabel
        '
        Me.netWorkIDLabel.AutoSize = True
        Me.netWorkIDLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkIDLabel.Location = New System.Drawing.Point(19, 112)
        Me.netWorkIDLabel.Name = "netWorkIDLabel"
        Me.netWorkIDLabel.Size = New System.Drawing.Size(72, 13)
        Me.netWorkIDLabel.TabIndex = 41
        Me.netWorkIDLabel.Text = "Network ID"
        '
        'netWorkCreationDate
        '
        Me.netWorkCreationDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkCreationDate.Location = New System.Drawing.Point(207, 80)
        Me.netWorkCreationDate.Name = "netWorkCreationDate"
        Me.netWorkCreationDate.ReadOnly = True
        Me.netWorkCreationDate.Size = New System.Drawing.Size(310, 21)
        Me.netWorkCreationDate.TabIndex = 42
        Me.netWorkCreationDate.Text = "xxxx"
        '
        'netWorkCreationDateLabel
        '
        Me.netWorkCreationDateLabel.AutoSize = True
        Me.netWorkCreationDateLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netWorkCreationDateLabel.Location = New System.Drawing.Point(204, 64)
        Me.netWorkCreationDateLabel.Name = "netWorkCreationDateLabel"
        Me.netWorkCreationDateLabel.Size = New System.Drawing.Size(133, 13)
        Me.netWorkCreationDateLabel.TabIndex = 43
        Me.netWorkCreationDateLabel.Text = "Network creation date"
        '
        'publicAddressCreator
        '
        Me.publicAddressCreator.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.publicAddressCreator.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicAddressCreator.Location = New System.Drawing.Point(22, 175)
        Me.publicAddressCreator.Name = "publicAddressCreator"
        Me.publicAddressCreator.ReadOnly = True
        Me.publicAddressCreator.Size = New System.Drawing.Size(495, 21)
        Me.publicAddressCreator.TabIndex = 44
        Me.publicAddressCreator.Text = "xxxx"
        '
        'publicAddressOwnerLabel
        '
        Me.publicAddressOwnerLabel.AutoSize = True
        Me.publicAddressOwnerLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publicAddressOwnerLabel.Location = New System.Drawing.Point(19, 159)
        Me.publicAddressOwnerLabel.Name = "publicAddressOwnerLabel"
        Me.publicAddressOwnerLabel.Size = New System.Drawing.Size(138, 13)
        Me.publicAddressOwnerLabel.TabIndex = 45
        Me.publicAddressOwnerLabel.Text = "Public Address Creator"
        '
        'NetworkInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.publicAddressCreator)
        Me.Controls.Add(Me.publicAddressOwnerLabel)
        Me.Controls.Add(Me.netWorkCreationDate)
        Me.Controls.Add(Me.netWorkCreationDateLabel)
        Me.Controls.Add(Me.netWorkID)
        Me.Controls.Add(Me.netWorkIDLabel)
        Me.Controls.Add(Me.specialEnvironment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.networkName)
        Me.Controls.Add(Me.networkNameLabel)
        Me.Name = "NetworkInformation"
        Me.Size = New System.Drawing.Size(563, 232)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents specialEnvironment As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents networkName As TextBox
    Friend WithEvents networkNameLabel As Label
    Friend WithEvents netWorkID As TextBox
    Friend WithEvents netWorkIDLabel As Label
    Friend WithEvents netWorkCreationDate As TextBox
    Friend WithEvents netWorkCreationDateLabel As Label
    Friend WithEvents publicAddressCreator As TextBox
    Friend WithEvents publicAddressOwnerLabel As Label
End Class
