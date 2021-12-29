<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParameterChain
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
        Me.maxTimeOutNotEvaluateNode = New System.Windows.Forms.TextBox()
        Me.maxTimeOutNotEvaluateNodeLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainInternal = New System.Windows.Forms.TextBox()
        Me.minimalMaintainInternalRegistryLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainTrashed = New System.Windows.Forms.TextBox()
        Me.minimalMaintainTrashedLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainRejected = New System.Windows.Forms.TextBox()
        Me.minimalMaintainRejectedLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainBulletines = New System.Windows.Forms.TextBox()
        Me.minimalMaintainBulletinesLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainConsensus = New System.Windows.Forms.TextBox()
        Me.minimalMaintainConsensusLabel = New System.Windows.Forms.Label()
        Me.minimalMaintainRequest = New System.Windows.Forms.TextBox()
        Me.minimalMaintainRequestLabel = New System.Windows.Forms.Label()
        Me.maxTimeOutResponseNode = New System.Windows.Forms.TextBox()
        Me.maxTimeOutNotRespondeNodeLabel = New System.Windows.Forms.Label()
        Me.numberBlockInVolume = New System.Windows.Forms.TextBox()
        Me.numberBlockInVolumeLabel = New System.Windows.Forms.Label()
        Me.blockSizeFrequency = New System.Windows.Forms.TextBox()
        Me.blockSizeFrequencyLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'maxTimeOutNotEvaluateNode
        '
        Me.maxTimeOutNotEvaluateNode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotEvaluateNode.Location = New System.Drawing.Point(581, 44)
        Me.maxTimeOutNotEvaluateNode.Name = "maxTimeOutNotEvaluateNode"
        Me.maxTimeOutNotEvaluateNode.ReadOnly = True
        Me.maxTimeOutNotEvaluateNode.Size = New System.Drawing.Size(75, 21)
        Me.maxTimeOutNotEvaluateNode.TabIndex = 117
        Me.maxTimeOutNotEvaluateNode.Text = "120 sec."
        '
        'maxTimeOutNotEvaluateNodeLabel
        '
        Me.maxTimeOutNotEvaluateNodeLabel.AutoSize = True
        Me.maxTimeOutNotEvaluateNodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotEvaluateNodeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.maxTimeOutNotEvaluateNodeLabel.Location = New System.Drawing.Point(386, 47)
        Me.maxTimeOutNotEvaluateNodeLabel.Name = "maxTimeOutNotEvaluateNodeLabel"
        Me.maxTimeOutNotEvaluateNodeLabel.Size = New System.Drawing.Size(184, 13)
        Me.maxTimeOutNotEvaluateNodeLabel.TabIndex = 118
        Me.maxTimeOutNotEvaluateNodeLabel.Text = "Max timeout not evaluate node"
        '
        'minimalMaintainInternal
        '
        Me.minimalMaintainInternal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainInternal.Location = New System.Drawing.Point(488, 125)
        Me.minimalMaintainInternal.Name = "minimalMaintainInternal"
        Me.minimalMaintainInternal.ReadOnly = True
        Me.minimalMaintainInternal.Size = New System.Drawing.Size(168, 21)
        Me.minimalMaintainInternal.TabIndex = 115
        Me.minimalMaintainInternal.Text = "5 days"
        '
        'minimalMaintainInternalRegistryLabel
        '
        Me.minimalMaintainInternalRegistryLabel.AutoSize = True
        Me.minimalMaintainInternalRegistryLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainInternalRegistryLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.minimalMaintainInternalRegistryLabel.Location = New System.Drawing.Point(332, 128)
        Me.minimalMaintainInternalRegistryLabel.Name = "minimalMaintainInternalRegistryLabel"
        Me.minimalMaintainInternalRegistryLabel.Size = New System.Drawing.Size(150, 13)
        Me.minimalMaintainInternalRegistryLabel.TabIndex = 116
        Me.minimalMaintainInternalRegistryLabel.Text = "Minimal Maintain Internal"
        '
        'minimalMaintainTrashed
        '
        Me.minimalMaintainTrashed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainTrashed.Location = New System.Drawing.Point(213, 125)
        Me.minimalMaintainTrashed.Name = "minimalMaintainTrashed"
        Me.minimalMaintainTrashed.ReadOnly = True
        Me.minimalMaintainTrashed.Size = New System.Drawing.Size(96, 21)
        Me.minimalMaintainTrashed.TabIndex = 113
        Me.minimalMaintainTrashed.Text = "7 days"
        '
        'minimalMaintainTrashedLabel
        '
        Me.minimalMaintainTrashedLabel.AutoSize = True
        Me.minimalMaintainTrashedLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainTrashedLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.minimalMaintainTrashedLabel.Location = New System.Drawing.Point(52, 128)
        Me.minimalMaintainTrashedLabel.Name = "minimalMaintainTrashedLabel"
        Me.minimalMaintainTrashedLabel.Size = New System.Drawing.Size(150, 13)
        Me.minimalMaintainTrashedLabel.TabIndex = 114
        Me.minimalMaintainTrashedLabel.Text = "Minimal Maintain Trashed"
        '
        'minimalMaintainRejected
        '
        Me.minimalMaintainRejected.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRejected.Location = New System.Drawing.Point(488, 98)
        Me.minimalMaintainRejected.Name = "minimalMaintainRejected"
        Me.minimalMaintainRejected.ReadOnly = True
        Me.minimalMaintainRejected.Size = New System.Drawing.Size(168, 21)
        Me.minimalMaintainRejected.TabIndex = 111
        Me.minimalMaintainRejected.Text = "14 days"
        '
        'minimalMaintainRejectedLabel
        '
        Me.minimalMaintainRejectedLabel.AutoSize = True
        Me.minimalMaintainRejectedLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRejectedLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.minimalMaintainRejectedLabel.Location = New System.Drawing.Point(327, 101)
        Me.minimalMaintainRejectedLabel.Name = "minimalMaintainRejectedLabel"
        Me.minimalMaintainRejectedLabel.Size = New System.Drawing.Size(155, 13)
        Me.minimalMaintainRejectedLabel.TabIndex = 112
        Me.minimalMaintainRejectedLabel.Text = "Minimal Maintain Rejected"
        '
        'minimalMaintainBulletines
        '
        Me.minimalMaintainBulletines.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainBulletines.Location = New System.Drawing.Point(213, 98)
        Me.minimalMaintainBulletines.Name = "minimalMaintainBulletines"
        Me.minimalMaintainBulletines.ReadOnly = True
        Me.minimalMaintainBulletines.Size = New System.Drawing.Size(96, 21)
        Me.minimalMaintainBulletines.TabIndex = 109
        Me.minimalMaintainBulletines.Text = "1 year"
        '
        'minimalMaintainBulletinesLabel
        '
        Me.minimalMaintainBulletinesLabel.AutoSize = True
        Me.minimalMaintainBulletinesLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainBulletinesLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.minimalMaintainBulletinesLabel.Location = New System.Drawing.Point(42, 101)
        Me.minimalMaintainBulletinesLabel.Name = "minimalMaintainBulletinesLabel"
        Me.minimalMaintainBulletinesLabel.Size = New System.Drawing.Size(160, 13)
        Me.minimalMaintainBulletinesLabel.TabIndex = 110
        Me.minimalMaintainBulletinesLabel.Text = "Minimal Maintain Bulletines"
        '
        'minimalMaintainConsensus
        '
        Me.minimalMaintainConsensus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainConsensus.Location = New System.Drawing.Point(488, 71)
        Me.minimalMaintainConsensus.Name = "minimalMaintainConsensus"
        Me.minimalMaintainConsensus.ReadOnly = True
        Me.minimalMaintainConsensus.Size = New System.Drawing.Size(168, 21)
        Me.minimalMaintainConsensus.TabIndex = 107
        Me.minimalMaintainConsensus.Text = "2 years"
        '
        'minimalMaintainConsensusLabel
        '
        Me.minimalMaintainConsensusLabel.AutoSize = True
        Me.minimalMaintainConsensusLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainConsensusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.minimalMaintainConsensusLabel.Location = New System.Drawing.Point(315, 74)
        Me.minimalMaintainConsensusLabel.Name = "minimalMaintainConsensusLabel"
        Me.minimalMaintainConsensusLabel.Size = New System.Drawing.Size(167, 13)
        Me.minimalMaintainConsensusLabel.TabIndex = 108
        Me.minimalMaintainConsensusLabel.Text = "Minimal Maintain Consensus"
        '
        'minimalMaintainRequest
        '
        Me.minimalMaintainRequest.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRequest.Location = New System.Drawing.Point(213, 71)
        Me.minimalMaintainRequest.Name = "minimalMaintainRequest"
        Me.minimalMaintainRequest.ReadOnly = True
        Me.minimalMaintainRequest.Size = New System.Drawing.Size(96, 21)
        Me.minimalMaintainRequest.TabIndex = 105
        Me.minimalMaintainRequest.Text = "3 years"
        '
        'minimalMaintainRequestLabel
        '
        Me.minimalMaintainRequestLabel.AutoSize = True
        Me.minimalMaintainRequestLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRequestLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.minimalMaintainRequestLabel.Location = New System.Drawing.Point(51, 74)
        Me.minimalMaintainRequestLabel.Name = "minimalMaintainRequestLabel"
        Me.minimalMaintainRequestLabel.Size = New System.Drawing.Size(151, 13)
        Me.minimalMaintainRequestLabel.TabIndex = 106
        Me.minimalMaintainRequestLabel.Text = "Minimal Maintain Request"
        '
        'maxTimeOutResponseNode
        '
        Me.maxTimeOutResponseNode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutResponseNode.Location = New System.Drawing.Point(213, 44)
        Me.maxTimeOutResponseNode.Name = "maxTimeOutResponseNode"
        Me.maxTimeOutResponseNode.ReadOnly = True
        Me.maxTimeOutResponseNode.Size = New System.Drawing.Size(75, 21)
        Me.maxTimeOutResponseNode.TabIndex = 96
        Me.maxTimeOutResponseNode.Text = "120 sec."
        '
        'maxTimeOutNotRespondeNodeLabel
        '
        Me.maxTimeOutNotRespondeNodeLabel.AutoSize = True
        Me.maxTimeOutNotRespondeNodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotRespondeNodeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.maxTimeOutNotRespondeNodeLabel.Location = New System.Drawing.Point(14, 47)
        Me.maxTimeOutNotRespondeNodeLabel.Name = "maxTimeOutNotRespondeNodeLabel"
        Me.maxTimeOutNotRespondeNodeLabel.Size = New System.Drawing.Size(188, 13)
        Me.maxTimeOutNotRespondeNodeLabel.TabIndex = 97
        Me.maxTimeOutNotRespondeNodeLabel.Text = "Max timeout not responde node"
        '
        'numberBlockInVolume
        '
        Me.numberBlockInVolume.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numberBlockInVolume.Location = New System.Drawing.Point(581, 17)
        Me.numberBlockInVolume.Name = "numberBlockInVolume"
        Me.numberBlockInVolume.ReadOnly = True
        Me.numberBlockInVolume.Size = New System.Drawing.Size(75, 21)
        Me.numberBlockInVolume.TabIndex = 94
        Me.numberBlockInVolume.Text = "365"
        '
        'numberBlockInVolumeLabel
        '
        Me.numberBlockInVolumeLabel.AutoSize = True
        Me.numberBlockInVolumeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numberBlockInVolumeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.numberBlockInVolumeLabel.Location = New System.Drawing.Point(421, 20)
        Me.numberBlockInVolumeLabel.Name = "numberBlockInVolumeLabel"
        Me.numberBlockInVolumeLabel.Size = New System.Drawing.Size(149, 13)
        Me.numberBlockInVolumeLabel.TabIndex = 95
        Me.numberBlockInVolumeLabel.Text = "Number Block In volume"
        '
        'blockSizeFrequency
        '
        Me.blockSizeFrequency.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blockSizeFrequency.Location = New System.Drawing.Point(213, 17)
        Me.blockSizeFrequency.Name = "blockSizeFrequency"
        Me.blockSizeFrequency.ReadOnly = True
        Me.blockSizeFrequency.Size = New System.Drawing.Size(75, 21)
        Me.blockSizeFrequency.TabIndex = 92
        Me.blockSizeFrequency.Text = "24 hours"
        '
        'blockSizeFrequencyLabel
        '
        Me.blockSizeFrequencyLabel.AutoSize = True
        Me.blockSizeFrequencyLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blockSizeFrequencyLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.blockSizeFrequencyLabel.Location = New System.Drawing.Point(73, 20)
        Me.blockSizeFrequencyLabel.Name = "blockSizeFrequencyLabel"
        Me.blockSizeFrequencyLabel.Size = New System.Drawing.Size(129, 13)
        Me.blockSizeFrequencyLabel.TabIndex = 93
        Me.blockSizeFrequencyLabel.Text = "Block Size Frequency"
        '
        'ParameterChain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.maxTimeOutNotEvaluateNode)
        Me.Controls.Add(Me.maxTimeOutNotEvaluateNodeLabel)
        Me.Controls.Add(Me.minimalMaintainInternal)
        Me.Controls.Add(Me.minimalMaintainInternalRegistryLabel)
        Me.Controls.Add(Me.minimalMaintainTrashed)
        Me.Controls.Add(Me.minimalMaintainTrashedLabel)
        Me.Controls.Add(Me.minimalMaintainRejected)
        Me.Controls.Add(Me.minimalMaintainRejectedLabel)
        Me.Controls.Add(Me.minimalMaintainBulletines)
        Me.Controls.Add(Me.minimalMaintainBulletinesLabel)
        Me.Controls.Add(Me.minimalMaintainConsensus)
        Me.Controls.Add(Me.minimalMaintainConsensusLabel)
        Me.Controls.Add(Me.minimalMaintainRequest)
        Me.Controls.Add(Me.minimalMaintainRequestLabel)
        Me.Controls.Add(Me.maxTimeOutResponseNode)
        Me.Controls.Add(Me.maxTimeOutNotRespondeNodeLabel)
        Me.Controls.Add(Me.numberBlockInVolume)
        Me.Controls.Add(Me.numberBlockInVolumeLabel)
        Me.Controls.Add(Me.blockSizeFrequency)
        Me.Controls.Add(Me.blockSizeFrequencyLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ParameterChain"
        Me.Size = New System.Drawing.Size(670, 163)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents maxTimeOutNotEvaluateNode As TextBox
    Friend WithEvents maxTimeOutNotEvaluateNodeLabel As Label
    Friend WithEvents minimalMaintainInternal As TextBox
    Friend WithEvents minimalMaintainInternalRegistryLabel As Label
    Friend WithEvents minimalMaintainTrashed As TextBox
    Friend WithEvents minimalMaintainTrashedLabel As Label
    Friend WithEvents minimalMaintainRejected As TextBox
    Friend WithEvents minimalMaintainRejectedLabel As Label
    Friend WithEvents minimalMaintainBulletines As TextBox
    Friend WithEvents minimalMaintainBulletinesLabel As Label
    Friend WithEvents minimalMaintainConsensus As TextBox
    Friend WithEvents minimalMaintainConsensusLabel As Label
    Friend WithEvents minimalMaintainRequest As TextBox
    Friend WithEvents minimalMaintainRequestLabel As Label
    Friend WithEvents maxTimeOutResponseNode As TextBox
    Friend WithEvents maxTimeOutNotRespondeNodeLabel As Label
    Friend WithEvents numberBlockInVolume As TextBox
    Friend WithEvents numberBlockInVolumeLabel As Label
    Friend WithEvents blockSizeFrequency As TextBox
    Friend WithEvents blockSizeFrequencyLabel As Label
End Class
