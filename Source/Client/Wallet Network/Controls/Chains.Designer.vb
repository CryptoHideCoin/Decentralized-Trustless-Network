<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Chains
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
        Me.titleControl = New System.Windows.Forms.Label()
        Me.tokensDataChain = New CHCWalletNetwork.TokensChain()
        Me.chainSetProtocol = New CHCWalletNetwork.ProtocolsChain()
        Me.dataDetail = New CHCWalletNetwork.ChainDetail()
        Me.mainList = New CHCWalletNetwork.ChainList()
        Me.SuspendLayout()
        '
        'titleControl
        '
        Me.titleControl.AutoSize = True
        Me.titleControl.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleControl.Location = New System.Drawing.Point(4, 4)
        Me.titleControl.Name = "titleControl"
        Me.titleControl.Size = New System.Drawing.Size(64, 25)
        Me.titleControl.TabIndex = 12
        Me.titleControl.Text = "Title"
        '
        'tokensDataChain
        '
        Me.tokensDataChain.BackColor = System.Drawing.Color.White
        Me.tokensDataChain.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.tokensDataChain.Location = New System.Drawing.Point(9, 220)
        Me.tokensDataChain.Name = "tokensDataChain"
        Me.tokensDataChain.Size = New System.Drawing.Size(335, 205)
        Me.tokensDataChain.TabIndex = 16
        Me.tokensDataChain.tokensData = Nothing
        Me.tokensDataChain.Visible = False
        '
        'chainSetProtocol
        '
        Me.chainSetProtocol.BackColor = System.Drawing.Color.White
        Me.chainSetProtocol.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chainSetProtocol.Location = New System.Drawing.Point(487, 4)
        Me.chainSetProtocol.Name = "chainSetProtocol"
        Me.chainSetProtocol.protocolData = Nothing
        Me.chainSetProtocol.Size = New System.Drawing.Size(269, 208)
        Me.chainSetProtocol.TabIndex = 15
        Me.chainSetProtocol.Visible = False
        '
        'dataDetail
        '
        Me.dataDetail.BackColor = System.Drawing.Color.White
        Me.dataDetail.Location = New System.Drawing.Point(278, 0)
        Me.dataDetail.Name = "dataDetail"
        Me.dataDetail.Size = New System.Drawing.Size(203, 170)
        Me.dataDetail.TabIndex = 14
        Me.dataDetail.type = CHCWalletNetwork.ChainDetail.ChainSectionType.notDefined
        Me.dataDetail.Visible = False
        '
        'mainList
        '
        Me.mainList.BackColor = System.Drawing.Color.White
        Me.mainList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainList.Location = New System.Drawing.Point(0, 32)
        Me.mainList.Name = "mainList"
        Me.mainList.numChains = 0
        Me.mainList.Size = New System.Drawing.Size(272, 161)
        Me.mainList.TabIndex = 13
        '
        'Chains
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tokensDataChain)
        Me.Controls.Add(Me.chainSetProtocol)
        Me.Controls.Add(Me.dataDetail)
        Me.Controls.Add(Me.mainList)
        Me.Controls.Add(Me.titleControl)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Chains"
        Me.Size = New System.Drawing.Size(759, 440)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titleControl As Label
    Friend WithEvents mainList As ChainList
    Friend WithEvents dataDetail As ChainDetail
    Friend WithEvents chainSetProtocol As ProtocolsChain
    Friend WithEvents tokensDataChain As TokensChain
End Class
