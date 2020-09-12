<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.packageReleaseMajorValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.browseMainPathToProcess = New System.Windows.Forms.Button()
        Me.mainPathToProcessValue = New System.Windows.Forms.TextBox()
        Me.packageNameValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.processButton = New System.Windows.Forms.Button()
        Me.packageReleaseMinorValue = New System.Windows.Forms.TextBox()
        Me.packageReleaseBuildValue = New System.Windows.Forms.TextBox()
        Me.packageReleaseRevisionValue = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(409, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Package Release"
        '
        'packageReleaseMajorValue
        '
        Me.packageReleaseMajorValue.Location = New System.Drawing.Point(412, 89)
        Me.packageReleaseMajorValue.Name = "packageReleaseMajorValue"
        Me.packageReleaseMajorValue.Size = New System.Drawing.Size(24, 21)
        Me.packageReleaseMajorValue.TabIndex = 5
        Me.packageReleaseMajorValue.Text = "1"
        Me.packageReleaseMajorValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Main Path to work"
        '
        'browseMainPathToProcess
        '
        Me.browseMainPathToProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.browseMainPathToProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseMainPathToProcess.Location = New System.Drawing.Point(536, 39)
        Me.browseMainPathToProcess.Name = "browseMainPathToProcess"
        Me.browseMainPathToProcess.Size = New System.Drawing.Size(35, 23)
        Me.browseMainPathToProcess.TabIndex = 1
        Me.browseMainPathToProcess.Text = "..."
        Me.browseMainPathToProcess.UseVisualStyleBackColor = True
        '
        'mainPathToProcessValue
        '
        Me.mainPathToProcessValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mainPathToProcessValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainPathToProcessValue.Location = New System.Drawing.Point(10, 40)
        Me.mainPathToProcessValue.Name = "mainPathToProcessValue"
        Me.mainPathToProcessValue.Size = New System.Drawing.Size(518, 21)
        Me.mainPathToProcessValue.TabIndex = 0
        '
        'packageNameValue
        '
        Me.packageNameValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.packageNameValue.Location = New System.Drawing.Point(11, 89)
        Me.packageNameValue.Name = "packageNameValue"
        Me.packageNameValue.Size = New System.Drawing.Size(395, 21)
        Me.packageNameValue.TabIndex = 4
        Me.packageNameValue.Text = "CHCMasternode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Package Name"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(10, 126)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 33)
        Me.cancelButton.TabIndex = 6
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'processButton
        '
        Me.processButton.Location = New System.Drawing.Point(453, 126)
        Me.processButton.Name = "processButton"
        Me.processButton.Size = New System.Drawing.Size(75, 33)
        Me.processButton.TabIndex = 7
        Me.processButton.Text = "Process"
        Me.processButton.UseVisualStyleBackColor = True
        '
        'packageReleaseMinorValue
        '
        Me.packageReleaseMinorValue.Location = New System.Drawing.Point(442, 89)
        Me.packageReleaseMinorValue.Name = "packageReleaseMinorValue"
        Me.packageReleaseMinorValue.Size = New System.Drawing.Size(24, 21)
        Me.packageReleaseMinorValue.TabIndex = 12
        Me.packageReleaseMinorValue.Text = "0"
        Me.packageReleaseMinorValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'packageReleaseBuildValue
        '
        Me.packageReleaseBuildValue.Location = New System.Drawing.Point(473, 89)
        Me.packageReleaseBuildValue.Name = "packageReleaseBuildValue"
        Me.packageReleaseBuildValue.Size = New System.Drawing.Size(24, 21)
        Me.packageReleaseBuildValue.TabIndex = 13
        Me.packageReleaseBuildValue.Text = "0"
        Me.packageReleaseBuildValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'packageReleaseRevisionValue
        '
        Me.packageReleaseRevisionValue.Location = New System.Drawing.Point(504, 89)
        Me.packageReleaseRevisionValue.Name = "packageReleaseRevisionValue"
        Me.packageReleaseRevisionValue.Size = New System.Drawing.Size(24, 21)
        Me.packageReleaseRevisionValue.TabIndex = 14
        Me.packageReleaseRevisionValue.Text = "0"
        Me.packageReleaseRevisionValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(581, 176)
        Me.Controls.Add(Me.packageReleaseRevisionValue)
        Me.Controls.Add(Me.packageReleaseBuildValue)
        Me.Controls.Add(Me.packageReleaseMinorValue)
        Me.Controls.Add(Me.processButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.packageNameValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.browseMainPathToProcess)
        Me.Controls.Add(Me.mainPathToProcessValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.packageReleaseMajorValue)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Build Package - Crypto Hide Coin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents packageReleaseMajorValue As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents browseMainPathToProcess As Button
    Friend WithEvents mainPathToProcessValue As TextBox
    Friend WithEvents packageNameValue As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cancelButton As Button
    Friend WithEvents processButton As Button
    Friend WithEvents packageReleaseMinorValue As TextBox
    Friend WithEvents packageReleaseBuildValue As TextBox
    Friend WithEvents packageReleaseRevisionValue As TextBox
End Class
