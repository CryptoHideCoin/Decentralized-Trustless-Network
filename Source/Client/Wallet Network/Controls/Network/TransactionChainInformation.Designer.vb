<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionChainInformation
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
        Me.initialCoinReleaseBlock = New CHCSupportUIControls.NumericText()
        Me.reviewReleaseAlgorithm = New System.Windows.Forms.TextBox()
        Me.reviewReleaseAlgorithmLabel = New System.Windows.Forms.Label()
        Me.consensusMethod = New System.Windows.Forms.TextBox()
        Me.consensusMethodLabel = New System.Windows.Forms.Label()
        Me.ruleFutureRelease = New System.Windows.Forms.TextBox()
        Me.ruleFutureReleaseLabel = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.initialCoinReleaseBlockLabel = New System.Windows.Forms.Label()
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
        Me.maxTimeOutNotEvaluateNode.Location = New System.Drawing.Point(574, 42)
        Me.maxTimeOutNotEvaluateNode.Name = "maxTimeOutNotEvaluateNode"
        Me.maxTimeOutNotEvaluateNode.ReadOnly = True
        Me.maxTimeOutNotEvaluateNode.Size = New System.Drawing.Size(75, 21)
        Me.maxTimeOutNotEvaluateNode.TabIndex = 88
        Me.maxTimeOutNotEvaluateNode.Text = "120 sec."
        '
        'maxTimeOutNotEvaluateNodeLabel
        '
        Me.maxTimeOutNotEvaluateNodeLabel.AutoSize = True
        Me.maxTimeOutNotEvaluateNodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotEvaluateNodeLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.maxTimeOutNotEvaluateNodeLabel.Location = New System.Drawing.Point(379, 45)
        Me.maxTimeOutNotEvaluateNodeLabel.Name = "maxTimeOutNotEvaluateNodeLabel"
        Me.maxTimeOutNotEvaluateNodeLabel.Size = New System.Drawing.Size(184, 13)
        Me.maxTimeOutNotEvaluateNodeLabel.TabIndex = 89
        Me.maxTimeOutNotEvaluateNodeLabel.Text = "Max timeout not evaluate node"
        '
        'minimalMaintainInternal
        '
        Me.minimalMaintainInternal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainInternal.Location = New System.Drawing.Point(481, 321)
        Me.minimalMaintainInternal.Name = "minimalMaintainInternal"
        Me.minimalMaintainInternal.ReadOnly = True
        Me.minimalMaintainInternal.Size = New System.Drawing.Size(168, 21)
        Me.minimalMaintainInternal.TabIndex = 86
        Me.minimalMaintainInternal.Text = "5 days"
        '
        'minimalMaintainInternalRegistryLabel
        '
        Me.minimalMaintainInternalRegistryLabel.AutoSize = True
        Me.minimalMaintainInternalRegistryLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainInternalRegistryLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainInternalRegistryLabel.Location = New System.Drawing.Point(325, 324)
        Me.minimalMaintainInternalRegistryLabel.Name = "minimalMaintainInternalRegistryLabel"
        Me.minimalMaintainInternalRegistryLabel.Size = New System.Drawing.Size(150, 13)
        Me.minimalMaintainInternalRegistryLabel.TabIndex = 87
        Me.minimalMaintainInternalRegistryLabel.Text = "Minimal Maintain Internal"
        '
        'minimalMaintainTrashed
        '
        Me.minimalMaintainTrashed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainTrashed.Location = New System.Drawing.Point(206, 321)
        Me.minimalMaintainTrashed.Name = "minimalMaintainTrashed"
        Me.minimalMaintainTrashed.ReadOnly = True
        Me.minimalMaintainTrashed.Size = New System.Drawing.Size(96, 21)
        Me.minimalMaintainTrashed.TabIndex = 84
        Me.minimalMaintainTrashed.Text = "7 days"
        '
        'minimalMaintainTrashedLabel
        '
        Me.minimalMaintainTrashedLabel.AutoSize = True
        Me.minimalMaintainTrashedLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainTrashedLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainTrashedLabel.Location = New System.Drawing.Point(45, 324)
        Me.minimalMaintainTrashedLabel.Name = "minimalMaintainTrashedLabel"
        Me.minimalMaintainTrashedLabel.Size = New System.Drawing.Size(150, 13)
        Me.minimalMaintainTrashedLabel.TabIndex = 85
        Me.minimalMaintainTrashedLabel.Text = "Minimal Maintain Trashed"
        '
        'minimalMaintainRejected
        '
        Me.minimalMaintainRejected.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRejected.Location = New System.Drawing.Point(481, 294)
        Me.minimalMaintainRejected.Name = "minimalMaintainRejected"
        Me.minimalMaintainRejected.ReadOnly = True
        Me.minimalMaintainRejected.Size = New System.Drawing.Size(168, 21)
        Me.minimalMaintainRejected.TabIndex = 82
        Me.minimalMaintainRejected.Text = "14 days"
        '
        'minimalMaintainRejectedLabel
        '
        Me.minimalMaintainRejectedLabel.AutoSize = True
        Me.minimalMaintainRejectedLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRejectedLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainRejectedLabel.Location = New System.Drawing.Point(320, 297)
        Me.minimalMaintainRejectedLabel.Name = "minimalMaintainRejectedLabel"
        Me.minimalMaintainRejectedLabel.Size = New System.Drawing.Size(155, 13)
        Me.minimalMaintainRejectedLabel.TabIndex = 83
        Me.minimalMaintainRejectedLabel.Text = "Minimal Maintain Rejected"
        '
        'minimalMaintainBulletines
        '
        Me.minimalMaintainBulletines.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainBulletines.Location = New System.Drawing.Point(206, 294)
        Me.minimalMaintainBulletines.Name = "minimalMaintainBulletines"
        Me.minimalMaintainBulletines.ReadOnly = True
        Me.minimalMaintainBulletines.Size = New System.Drawing.Size(96, 21)
        Me.minimalMaintainBulletines.TabIndex = 80
        Me.minimalMaintainBulletines.Text = "1 year"
        '
        'minimalMaintainBulletinesLabel
        '
        Me.minimalMaintainBulletinesLabel.AutoSize = True
        Me.minimalMaintainBulletinesLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainBulletinesLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainBulletinesLabel.Location = New System.Drawing.Point(40, 297)
        Me.minimalMaintainBulletinesLabel.Name = "minimalMaintainBulletinesLabel"
        Me.minimalMaintainBulletinesLabel.Size = New System.Drawing.Size(160, 13)
        Me.minimalMaintainBulletinesLabel.TabIndex = 81
        Me.minimalMaintainBulletinesLabel.Text = "Minimal Maintain Bulletines"
        '
        'minimalMaintainConsensus
        '
        Me.minimalMaintainConsensus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainConsensus.Location = New System.Drawing.Point(481, 267)
        Me.minimalMaintainConsensus.Name = "minimalMaintainConsensus"
        Me.minimalMaintainConsensus.ReadOnly = True
        Me.minimalMaintainConsensus.Size = New System.Drawing.Size(168, 21)
        Me.minimalMaintainConsensus.TabIndex = 78
        Me.minimalMaintainConsensus.Text = "2 years"
        '
        'minimalMaintainConsensusLabel
        '
        Me.minimalMaintainConsensusLabel.AutoSize = True
        Me.minimalMaintainConsensusLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainConsensusLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainConsensusLabel.Location = New System.Drawing.Point(308, 270)
        Me.minimalMaintainConsensusLabel.Name = "minimalMaintainConsensusLabel"
        Me.minimalMaintainConsensusLabel.Size = New System.Drawing.Size(167, 13)
        Me.minimalMaintainConsensusLabel.TabIndex = 79
        Me.minimalMaintainConsensusLabel.Text = "Minimal Maintain Consensus"
        '
        'minimalMaintainRequest
        '
        Me.minimalMaintainRequest.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRequest.Location = New System.Drawing.Point(206, 267)
        Me.minimalMaintainRequest.Name = "minimalMaintainRequest"
        Me.minimalMaintainRequest.ReadOnly = True
        Me.minimalMaintainRequest.Size = New System.Drawing.Size(96, 21)
        Me.minimalMaintainRequest.TabIndex = 76
        Me.minimalMaintainRequest.Text = "3 years"
        '
        'minimalMaintainRequestLabel
        '
        Me.minimalMaintainRequestLabel.AutoSize = True
        Me.minimalMaintainRequestLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimalMaintainRequestLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.minimalMaintainRequestLabel.Location = New System.Drawing.Point(48, 270)
        Me.minimalMaintainRequestLabel.Name = "minimalMaintainRequestLabel"
        Me.minimalMaintainRequestLabel.Size = New System.Drawing.Size(151, 13)
        Me.minimalMaintainRequestLabel.TabIndex = 77
        Me.minimalMaintainRequestLabel.Text = "Minimal Maintain Request"
        '
        'initialCoinReleaseBlock
        '
        Me.initialCoinReleaseBlock.currentFormat = "0,000"
        Me.initialCoinReleaseBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.initialCoinReleaseBlock.Location = New System.Drawing.Point(206, 69)
        Me.initialCoinReleaseBlock.locationCode = "it-IT"
        Me.initialCoinReleaseBlock.Name = "initialCoinReleaseBlock"
        Me.initialCoinReleaseBlock.ReadOnly = True
        Me.initialCoinReleaseBlock.Size = New System.Drawing.Size(75, 21)
        Me.initialCoinReleaseBlock.TabIndex = 61
        Me.initialCoinReleaseBlock.Text = "0.000"
        Me.initialCoinReleaseBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.initialCoinReleaseBlock.useDecimal = False
        '
        'reviewReleaseAlgorithm
        '
        Me.reviewReleaseAlgorithm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reviewReleaseAlgorithm.Location = New System.Drawing.Point(206, 240)
        Me.reviewReleaseAlgorithm.Name = "reviewReleaseAlgorithm"
        Me.reviewReleaseAlgorithm.ReadOnly = True
        Me.reviewReleaseAlgorithm.Size = New System.Drawing.Size(96, 21)
        Me.reviewReleaseAlgorithm.TabIndex = 74
        Me.reviewReleaseAlgorithm.Text = "On transaction"
        '
        'reviewReleaseAlgorithmLabel
        '
        Me.reviewReleaseAlgorithmLabel.AutoSize = True
        Me.reviewReleaseAlgorithmLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reviewReleaseAlgorithmLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.reviewReleaseAlgorithmLabel.Location = New System.Drawing.Point(48, 243)
        Me.reviewReleaseAlgorithmLabel.Name = "reviewReleaseAlgorithmLabel"
        Me.reviewReleaseAlgorithmLabel.Size = New System.Drawing.Size(152, 13)
        Me.reviewReleaseAlgorithmLabel.TabIndex = 75
        Me.reviewReleaseAlgorithmLabel.Text = "Review release algorithm"
        '
        'consensusMethod
        '
        Me.consensusMethod.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consensusMethod.Location = New System.Drawing.Point(430, 240)
        Me.consensusMethod.Name = "consensusMethod"
        Me.consensusMethod.ReadOnly = True
        Me.consensusMethod.Size = New System.Drawing.Size(219, 21)
        Me.consensusMethod.TabIndex = 72
        Me.consensusMethod.Text = "Delegate Proof of Stake Declarative"
        '
        'consensusMethodLabel
        '
        Me.consensusMethodLabel.AutoSize = True
        Me.consensusMethodLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consensusMethodLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.consensusMethodLabel.Location = New System.Drawing.Point(308, 246)
        Me.consensusMethodLabel.Name = "consensusMethodLabel"
        Me.consensusMethodLabel.Size = New System.Drawing.Size(116, 13)
        Me.consensusMethodLabel.TabIndex = 73
        Me.consensusMethodLabel.Text = "Consensus method"
        '
        'ruleFutureRelease
        '
        Me.ruleFutureRelease.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ruleFutureRelease.Location = New System.Drawing.Point(206, 96)
        Me.ruleFutureRelease.Multiline = True
        Me.ruleFutureRelease.Name = "ruleFutureRelease"
        Me.ruleFutureRelease.ReadOnly = True
        Me.ruleFutureRelease.Size = New System.Drawing.Size(443, 138)
        Me.ruleFutureRelease.TabIndex = 62
        '
        'ruleFutureReleaseLabel
        '
        Me.ruleFutureReleaseLabel.AutoSize = True
        Me.ruleFutureReleaseLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ruleFutureReleaseLabel.Location = New System.Drawing.Point(79, 99)
        Me.ruleFutureReleaseLabel.Name = "ruleFutureReleaseLabel"
        Me.ruleFutureReleaseLabel.Size = New System.Drawing.Size(116, 13)
        Me.ruleFutureReleaseLabel.TabIndex = 71
        Me.ruleFutureReleaseLabel.Text = "Rule future release"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(287, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "coin"
        '
        'initialCoinReleaseBlockLabel
        '
        Me.initialCoinReleaseBlockLabel.AutoSize = True
        Me.initialCoinReleaseBlockLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.initialCoinReleaseBlockLabel.Location = New System.Drawing.Point(26, 72)
        Me.initialCoinReleaseBlockLabel.Name = "initialCoinReleaseBlockLabel"
        Me.initialCoinReleaseBlockLabel.Size = New System.Drawing.Size(169, 13)
        Me.initialCoinReleaseBlockLabel.TabIndex = 69
        Me.initialCoinReleaseBlockLabel.Text = "Initial coin release per block"
        '
        'maxTimeOutResponseNode
        '
        Me.maxTimeOutResponseNode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutResponseNode.Location = New System.Drawing.Point(206, 42)
        Me.maxTimeOutResponseNode.Name = "maxTimeOutResponseNode"
        Me.maxTimeOutResponseNode.ReadOnly = True
        Me.maxTimeOutResponseNode.Size = New System.Drawing.Size(75, 21)
        Me.maxTimeOutResponseNode.TabIndex = 67
        Me.maxTimeOutResponseNode.Text = "120 sec."
        '
        'maxTimeOutNotRespondeNodeLabel
        '
        Me.maxTimeOutNotRespondeNodeLabel.AutoSize = True
        Me.maxTimeOutNotRespondeNodeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxTimeOutNotRespondeNodeLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.maxTimeOutNotRespondeNodeLabel.Location = New System.Drawing.Point(7, 45)
        Me.maxTimeOutNotRespondeNodeLabel.Name = "maxTimeOutNotRespondeNodeLabel"
        Me.maxTimeOutNotRespondeNodeLabel.Size = New System.Drawing.Size(188, 13)
        Me.maxTimeOutNotRespondeNodeLabel.TabIndex = 68
        Me.maxTimeOutNotRespondeNodeLabel.Text = "Max timeout not responde node"
        '
        'numberBlockInVolume
        '
        Me.numberBlockInVolume.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numberBlockInVolume.Location = New System.Drawing.Point(574, 15)
        Me.numberBlockInVolume.Name = "numberBlockInVolume"
        Me.numberBlockInVolume.ReadOnly = True
        Me.numberBlockInVolume.Size = New System.Drawing.Size(75, 21)
        Me.numberBlockInVolume.TabIndex = 65
        Me.numberBlockInVolume.Text = "365"
        '
        'numberBlockInVolumeLabel
        '
        Me.numberBlockInVolumeLabel.AutoSize = True
        Me.numberBlockInVolumeLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numberBlockInVolumeLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.numberBlockInVolumeLabel.Location = New System.Drawing.Point(414, 18)
        Me.numberBlockInVolumeLabel.Name = "numberBlockInVolumeLabel"
        Me.numberBlockInVolumeLabel.Size = New System.Drawing.Size(149, 13)
        Me.numberBlockInVolumeLabel.TabIndex = 66
        Me.numberBlockInVolumeLabel.Text = "Number Block In volume"
        '
        'blockSizeFrequency
        '
        Me.blockSizeFrequency.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blockSizeFrequency.Location = New System.Drawing.Point(206, 15)
        Me.blockSizeFrequency.Name = "blockSizeFrequency"
        Me.blockSizeFrequency.ReadOnly = True
        Me.blockSizeFrequency.Size = New System.Drawing.Size(75, 21)
        Me.blockSizeFrequency.TabIndex = 63
        Me.blockSizeFrequency.Text = "24 hours"
        '
        'blockSizeFrequencyLabel
        '
        Me.blockSizeFrequencyLabel.AutoSize = True
        Me.blockSizeFrequencyLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blockSizeFrequencyLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.blockSizeFrequencyLabel.Location = New System.Drawing.Point(66, 18)
        Me.blockSizeFrequencyLabel.Name = "blockSizeFrequencyLabel"
        Me.blockSizeFrequencyLabel.Size = New System.Drawing.Size(129, 13)
        Me.blockSizeFrequencyLabel.TabIndex = 64
        Me.blockSizeFrequencyLabel.Text = "Block Size Frequency"
        '
        'TransactionChainInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
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
        Me.Controls.Add(Me.initialCoinReleaseBlock)
        Me.Controls.Add(Me.reviewReleaseAlgorithm)
        Me.Controls.Add(Me.reviewReleaseAlgorithmLabel)
        Me.Controls.Add(Me.consensusMethod)
        Me.Controls.Add(Me.consensusMethodLabel)
        Me.Controls.Add(Me.ruleFutureRelease)
        Me.Controls.Add(Me.ruleFutureReleaseLabel)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.initialCoinReleaseBlockLabel)
        Me.Controls.Add(Me.maxTimeOutResponseNode)
        Me.Controls.Add(Me.maxTimeOutNotRespondeNodeLabel)
        Me.Controls.Add(Me.numberBlockInVolume)
        Me.Controls.Add(Me.numberBlockInVolumeLabel)
        Me.Controls.Add(Me.blockSizeFrequency)
        Me.Controls.Add(Me.blockSizeFrequencyLabel)
        Me.Name = "TransactionChainInformation"
        Me.Size = New System.Drawing.Size(670, 360)
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
    Friend WithEvents initialCoinReleaseBlock As CHCSupportUIControls.NumericText
    Friend WithEvents reviewReleaseAlgorithm As TextBox
    Friend WithEvents reviewReleaseAlgorithmLabel As Label
    Friend WithEvents consensusMethod As TextBox
    Friend WithEvents consensusMethodLabel As Label
    Friend WithEvents ruleFutureRelease As TextBox
    Friend WithEvents ruleFutureReleaseLabel As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents initialCoinReleaseBlockLabel As Label
    Friend WithEvents maxTimeOutResponseNode As TextBox
    Friend WithEvents maxTimeOutNotRespondeNodeLabel As Label
    Friend WithEvents numberBlockInVolume As TextBox
    Friend WithEvents numberBlockInVolumeLabel As Label
    Friend WithEvents blockSizeFrequency As TextBox
    Friend WithEvents blockSizeFrequencyLabel As Label
End Class
