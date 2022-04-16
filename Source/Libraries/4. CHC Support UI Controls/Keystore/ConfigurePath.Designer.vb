<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigurePath
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
        Me.confirmButton = New System.Windows.Forms.Button()
        Me.containerBox = New System.Windows.Forms.GroupBox()
        Me.remoteStorageButton = New System.Windows.Forms.RadioButton()
        Me.pathLabel = New System.Windows.Forms.Label()
        Me.localStorageRadio = New System.Windows.Forms.RadioButton()
        Me.browseLocalPathButton = New System.Windows.Forms.Button()
        Me.localPathDataText = New System.Windows.Forms.TextBox()
        Me.mainCancelButton = New System.Windows.Forms.Button()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.containerBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'confirmButton
        '
        Me.confirmButton.Location = New System.Drawing.Point(330, 153)
        Me.confirmButton.Name = "confirmButton"
        Me.confirmButton.Size = New System.Drawing.Size(75, 23)
        Me.confirmButton.TabIndex = 7
        Me.confirmButton.Text = "Confirm"
        Me.confirmButton.UseVisualStyleBackColor = True
        '
        'container
        '
        Me.containerBox.Controls.Add(Me.remoteStorageButton)
        Me.containerBox.Controls.Add(Me.pathLabel)
        Me.containerBox.Controls.Add(Me.localStorageRadio)
        Me.containerBox.Controls.Add(Me.browseLocalPathButton)
        Me.containerBox.Controls.Add(Me.localPathDataText)
        Me.containerBox.Location = New System.Drawing.Point(14, 12)
        Me.containerBox.Name = "container"
        Me.containerBox.Size = New System.Drawing.Size(472, 135)
        Me.containerBox.TabIndex = 8
        Me.containerBox.TabStop = False
        '
        'remoteStorageButton
        '
        Me.remoteStorageButton.AutoSize = True
        Me.remoteStorageButton.Enabled = False
        Me.remoteStorageButton.Location = New System.Drawing.Point(15, 103)
        Me.remoteStorageButton.Name = "remoteStorageButton"
        Me.remoteStorageButton.Size = New System.Drawing.Size(118, 17)
        Me.remoteStorageButton.TabIndex = 11
        Me.remoteStorageButton.Text = "Remote Storage"
        Me.remoteStorageButton.UseVisualStyleBackColor = True
        '
        'pathLabel
        '
        Me.pathLabel.AutoSize = True
        Me.pathLabel.Location = New System.Drawing.Point(31, 44)
        Me.pathLabel.Name = "pathLabel"
        Me.pathLabel.Size = New System.Drawing.Size(32, 13)
        Me.pathLabel.TabIndex = 10
        Me.pathLabel.Text = "Path"
        '
        'localStorageRadio
        '
        Me.localStorageRadio.AutoSize = True
        Me.localStorageRadio.Checked = True
        Me.localStorageRadio.Location = New System.Drawing.Point(15, 20)
        Me.localStorageRadio.Name = "localStorageRadio"
        Me.localStorageRadio.Size = New System.Drawing.Size(101, 17)
        Me.localStorageRadio.TabIndex = 9
        Me.localStorageRadio.Text = "Local storage"
        Me.localStorageRadio.UseVisualStyleBackColor = True
        '
        'browseLocalPathButton
        '
        Me.browseLocalPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseLocalPathButton.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseLocalPathButton.Location = New System.Drawing.Point(425, 64)
        Me.browseLocalPathButton.Name = "browseLocalPathButton"
        Me.browseLocalPathButton.Size = New System.Drawing.Size(41, 22)
        Me.browseLocalPathButton.TabIndex = 8
        Me.browseLocalPathButton.Text = "..."
        Me.browseLocalPathButton.UseVisualStyleBackColor = True
        '
        'localPathDataText
        '
        Me.localPathDataText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.localPathDataText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.localPathDataText.Location = New System.Drawing.Point(31, 64)
        Me.localPathDataText.Name = "localPathDataText"
        Me.localPathDataText.Size = New System.Drawing.Size(388, 21)
        Me.localPathDataText.TabIndex = 7
        '
        'mainCancelButton
        '
        Me.mainCancelButton.Location = New System.Drawing.Point(411, 153)
        Me.mainCancelButton.Name = "mainCancelButton"
        Me.mainCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.mainCancelButton.TabIndex = 9
        Me.mainCancelButton.Text = "Cancel"
        Me.mainCancelButton.UseVisualStyleBackColor = True
        '
        'ConfigurePath
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 187)
        Me.Controls.Add(Me.mainCancelButton)
        Me.Controls.Add(Me.container)
        Me.Controls.Add(Me.confirmButton)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ConfigurePath"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configure Keystore Manager"
        Me.containerBox.ResumeLayout(False)
        Me.containerBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents confirmButton As Button
    Friend WithEvents containerBox As GroupBox
    Friend WithEvents remoteStorageButton As RadioButton
    Friend WithEvents pathLabel As Label
    Friend WithEvents localStorageRadio As RadioButton
    Friend WithEvents browseLocalPathButton As Button
    Friend WithEvents localPathDataText As TextBox
    Friend WithEvents mainCancelButton As Button
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
End Class
