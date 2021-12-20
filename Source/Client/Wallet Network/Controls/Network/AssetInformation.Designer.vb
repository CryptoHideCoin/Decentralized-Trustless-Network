<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssetInformation
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
        Me.unLimited = New System.Windows.Forms.CheckBox()
        Me.policyAssetLabel = New System.Windows.Forms.Label()
        Me.typeAsset = New System.Windows.Forms.TextBox()
        Me.typeAssetLabel = New System.Windows.Forms.Label()
        Me.generalInformationAssetLabel = New System.Windows.Forms.Label()
        Me.initialStakeQuantity = New CHCSupportUIControls.NumericText()
        Me.quantityTotal = New CHCSupportUIControls.NumericText()
        Me.digit = New CHCSupportUIControls.NumericText()
        Me.initialStakeQuantityLabel = New System.Windows.Forms.Label()
        Me.nameUnit = New System.Windows.Forms.TextBox()
        Me.nameUnitLabel = New System.Windows.Forms.Label()
        Me.burnable = New System.Windows.Forms.CheckBox()
        Me.prestake = New System.Windows.Forms.CheckBox()
        Me.stakable = New System.Windows.Forms.CheckBox()
        Me.digitLabel = New System.Windows.Forms.Label()
        Me.quantityTotalLabel = New System.Windows.Forms.Label()
        Me.symbol = New System.Windows.Forms.TextBox()
        Me.symbolLabel = New System.Windows.Forms.Label()
        Me.shortName = New System.Windows.Forms.TextBox()
        Me.shortNameLabel = New System.Windows.Forms.Label()
        Me.assetName = New System.Windows.Forms.TextBox()
        Me.assetNameLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'unLimited
        '
        Me.unLimited.AutoSize = True
        Me.unLimited.Enabled = False
        Me.unLimited.Location = New System.Drawing.Point(112, 174)
        Me.unLimited.Name = "unLimited"
        Me.unLimited.Size = New System.Drawing.Size(79, 17)
        Me.unLimited.TabIndex = 59
        Me.unLimited.Text = "Unlimited"
        Me.unLimited.UseVisualStyleBackColor = True
        '
        'policyAssetLabel
        '
        Me.policyAssetLabel.BackColor = System.Drawing.Color.CadetBlue
        Me.policyAssetLabel.Font = New System.Drawing.Font("Verdana", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.policyAssetLabel.ForeColor = System.Drawing.Color.SandyBrown
        Me.policyAssetLabel.Location = New System.Drawing.Point(36, 142)
        Me.policyAssetLabel.Name = "policyAssetLabel"
        Me.policyAssetLabel.Size = New System.Drawing.Size(631, 17)
        Me.policyAssetLabel.TabIndex = 74
        Me.policyAssetLabel.Text = "Policy Asset Information"
        '
        'typeAsset
        '
        Me.typeAsset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typeAsset.Location = New System.Drawing.Point(115, 101)
        Me.typeAsset.Name = "typeAsset"
        Me.typeAsset.ReadOnly = True
        Me.typeAsset.Size = New System.Drawing.Size(122, 21)
        Me.typeAsset.TabIndex = 57
        Me.typeAsset.Text = "xxx"
        '
        'typeAssetLabel
        '
        Me.typeAssetLabel.AutoSize = True
        Me.typeAssetLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typeAssetLabel.Location = New System.Drawing.Point(76, 104)
        Me.typeAssetLabel.Name = "typeAssetLabel"
        Me.typeAssetLabel.Size = New System.Drawing.Size(34, 13)
        Me.typeAssetLabel.TabIndex = 73
        Me.typeAssetLabel.Text = "Type"
        '
        'generalInformationAssetLabel
        '
        Me.generalInformationAssetLabel.BackColor = System.Drawing.Color.CadetBlue
        Me.generalInformationAssetLabel.Font = New System.Drawing.Font("Verdana", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generalInformationAssetLabel.ForeColor = System.Drawing.Color.SandyBrown
        Me.generalInformationAssetLabel.Location = New System.Drawing.Point(39, 16)
        Me.generalInformationAssetLabel.Name = "generalInformationAssetLabel"
        Me.generalInformationAssetLabel.Size = New System.Drawing.Size(631, 17)
        Me.generalInformationAssetLabel.TabIndex = 72
        Me.generalInformationAssetLabel.Text = "General Information"
        '
        'initialStakeQuantity
        '
        Me.initialStakeQuantity.currentFormat = "0,000"
        Me.initialStakeQuantity.Enabled = False
        Me.initialStakeQuantity.Location = New System.Drawing.Point(550, 225)
        Me.initialStakeQuantity.locationCode = "it-IT"
        Me.initialStakeQuantity.Name = "initialStakeQuantity"
        Me.initialStakeQuantity.Size = New System.Drawing.Size(100, 21)
        Me.initialStakeQuantity.TabIndex = 64
        Me.initialStakeQuantity.Text = "0.000"
        Me.initialStakeQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.initialStakeQuantity.useDecimal = False
        '
        'quantityTotal
        '
        Me.quantityTotal.currentFormat = "0,000"
        Me.quantityTotal.Location = New System.Drawing.Point(112, 197)
        Me.quantityTotal.locationCode = "it-IT"
        Me.quantityTotal.Name = "quantityTotal"
        Me.quantityTotal.ReadOnly = True
        Me.quantityTotal.Size = New System.Drawing.Size(142, 21)
        Me.quantityTotal.TabIndex = 61
        Me.quantityTotal.Text = "0.000"
        Me.quantityTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.quantityTotal.useDecimal = False
        '
        'digit
        '
        Me.digit.currentFormat = ""
        Me.digit.Location = New System.Drawing.Point(404, 74)
        Me.digit.locationCode = "it-IT"
        Me.digit.Name = "digit"
        Me.digit.ReadOnly = True
        Me.digit.Size = New System.Drawing.Size(21, 21)
        Me.digit.TabIndex = 55
        Me.digit.Text = "0"
        Me.digit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.digit.useDecimal = False
        '
        'initialStakeQuantityLabel
        '
        Me.initialStakeQuantityLabel.AutoSize = True
        Me.initialStakeQuantityLabel.Enabled = False
        Me.initialStakeQuantityLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.initialStakeQuantityLabel.Location = New System.Drawing.Point(416, 228)
        Me.initialStakeQuantityLabel.Name = "initialStakeQuantityLabel"
        Me.initialStakeQuantityLabel.Size = New System.Drawing.Size(128, 13)
        Me.initialStakeQuantityLabel.TabIndex = 71
        Me.initialStakeQuantityLabel.Text = "Initial Stake Quantity"
        '
        'nameUnit
        '
        Me.nameUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameUnit.Location = New System.Drawing.Point(528, 74)
        Me.nameUnit.Name = "nameUnit"
        Me.nameUnit.ReadOnly = True
        Me.nameUnit.Size = New System.Drawing.Size(122, 21)
        Me.nameUnit.TabIndex = 56
        Me.nameUnit.Text = "xxx"
        '
        'nameUnitLabel
        '
        Me.nameUnitLabel.AutoSize = True
        Me.nameUnitLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameUnitLabel.Location = New System.Drawing.Point(453, 77)
        Me.nameUnitLabel.Name = "nameUnitLabel"
        Me.nameUnitLabel.Size = New System.Drawing.Size(65, 13)
        Me.nameUnitLabel.TabIndex = 70
        Me.nameUnitLabel.Text = "Name unit"
        '
        'burnable
        '
        Me.burnable.AutoSize = True
        Me.burnable.Enabled = False
        Me.burnable.Location = New System.Drawing.Point(283, 174)
        Me.burnable.Name = "burnable"
        Me.burnable.Size = New System.Drawing.Size(77, 17)
        Me.burnable.TabIndex = 60
        Me.burnable.Text = "Burnable"
        Me.burnable.UseVisualStyleBackColor = True
        '
        'prestake
        '
        Me.prestake.AutoSize = True
        Me.prestake.Enabled = False
        Me.prestake.Location = New System.Drawing.Point(283, 229)
        Me.prestake.Name = "prestake"
        Me.prestake.Size = New System.Drawing.Size(76, 17)
        Me.prestake.TabIndex = 63
        Me.prestake.Text = "Prestake"
        Me.prestake.UseVisualStyleBackColor = True
        '
        'stakable
        '
        Me.stakable.AutoSize = True
        Me.stakable.Enabled = False
        Me.stakable.Location = New System.Drawing.Point(112, 229)
        Me.stakable.Name = "stakable"
        Me.stakable.Size = New System.Drawing.Size(76, 17)
        Me.stakable.TabIndex = 62
        Me.stakable.Text = "Stakable"
        Me.stakable.UseVisualStyleBackColor = True
        '
        'digitLabel
        '
        Me.digitLabel.AutoSize = True
        Me.digitLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.digitLabel.Location = New System.Drawing.Point(367, 77)
        Me.digitLabel.Name = "digitLabel"
        Me.digitLabel.Size = New System.Drawing.Size(33, 13)
        Me.digitLabel.TabIndex = 69
        Me.digitLabel.Text = "Digit"
        '
        'quantityTotalLabel
        '
        Me.quantityTotalLabel.AutoSize = True
        Me.quantityTotalLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantityTotalLabel.Location = New System.Drawing.Point(21, 200)
        Me.quantityTotalLabel.Name = "quantityTotalLabel"
        Me.quantityTotalLabel.Size = New System.Drawing.Size(86, 13)
        Me.quantityTotalLabel.TabIndex = 68
        Me.quantityTotalLabel.Text = "Quantity Total"
        '
        'symbol
        '
        Me.symbol.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.symbol.Location = New System.Drawing.Point(324, 74)
        Me.symbol.MaxLength = 1
        Me.symbol.Name = "symbol"
        Me.symbol.ReadOnly = True
        Me.symbol.Size = New System.Drawing.Size(24, 21)
        Me.symbol.TabIndex = 54
        Me.symbol.Text = "x"
        Me.symbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'symbolLabel
        '
        Me.symbolLabel.AutoSize = True
        Me.symbolLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.symbolLabel.Location = New System.Drawing.Point(269, 77)
        Me.symbolLabel.Name = "symbolLabel"
        Me.symbolLabel.Size = New System.Drawing.Size(50, 13)
        Me.symbolLabel.TabIndex = 67
        Me.symbolLabel.Text = "Symbol"
        '
        'shortName
        '
        Me.shortName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shortName.Location = New System.Drawing.Point(115, 74)
        Me.shortName.Name = "shortName"
        Me.shortName.ReadOnly = True
        Me.shortName.Size = New System.Drawing.Size(122, 21)
        Me.shortName.TabIndex = 53
        Me.shortName.Text = "xxx"
        '
        'shortNameLabel
        '
        Me.shortNameLabel.AutoSize = True
        Me.shortNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shortNameLabel.Location = New System.Drawing.Point(36, 77)
        Me.shortNameLabel.Name = "shortNameLabel"
        Me.shortNameLabel.Size = New System.Drawing.Size(74, 13)
        Me.shortNameLabel.TabIndex = 66
        Me.shortNameLabel.Text = "Short name"
        '
        'assetName
        '
        Me.assetName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assetName.Location = New System.Drawing.Point(115, 47)
        Me.assetName.Name = "assetName"
        Me.assetName.ReadOnly = True
        Me.assetName.Size = New System.Drawing.Size(535, 21)
        Me.assetName.TabIndex = 52
        Me.assetName.Text = "xxx"
        '
        'assetNameLabel
        '
        Me.assetNameLabel.AutoSize = True
        Me.assetNameLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assetNameLabel.Location = New System.Drawing.Point(36, 50)
        Me.assetNameLabel.Name = "assetNameLabel"
        Me.assetNameLabel.Size = New System.Drawing.Size(74, 13)
        Me.assetNameLabel.TabIndex = 65
        Me.assetNameLabel.Text = "Asset name"
        '
        'AssetInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.unLimited)
        Me.Controls.Add(Me.policyAssetLabel)
        Me.Controls.Add(Me.typeAsset)
        Me.Controls.Add(Me.typeAssetLabel)
        Me.Controls.Add(Me.generalInformationAssetLabel)
        Me.Controls.Add(Me.initialStakeQuantity)
        Me.Controls.Add(Me.quantityTotal)
        Me.Controls.Add(Me.digit)
        Me.Controls.Add(Me.initialStakeQuantityLabel)
        Me.Controls.Add(Me.nameUnit)
        Me.Controls.Add(Me.nameUnitLabel)
        Me.Controls.Add(Me.burnable)
        Me.Controls.Add(Me.prestake)
        Me.Controls.Add(Me.stakable)
        Me.Controls.Add(Me.digitLabel)
        Me.Controls.Add(Me.quantityTotalLabel)
        Me.Controls.Add(Me.symbol)
        Me.Controls.Add(Me.symbolLabel)
        Me.Controls.Add(Me.shortName)
        Me.Controls.Add(Me.shortNameLabel)
        Me.Controls.Add(Me.assetName)
        Me.Controls.Add(Me.assetNameLabel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AssetInformation"
        Me.Size = New System.Drawing.Size(692, 264)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents unLimited As CheckBox
    Friend WithEvents policyAssetLabel As Label
    Friend WithEvents typeAsset As TextBox
    Friend WithEvents typeAssetLabel As Label
    Friend WithEvents generalInformationAssetLabel As Label
    Friend WithEvents initialStakeQuantity As CHCSupportUIControls.NumericText
    Friend WithEvents quantityTotal As CHCSupportUIControls.NumericText
    Friend WithEvents digit As CHCSupportUIControls.NumericText
    Friend WithEvents initialStakeQuantityLabel As Label
    Friend WithEvents nameUnit As TextBox
    Friend WithEvents nameUnitLabel As Label
    Friend WithEvents burnable As CheckBox
    Friend WithEvents prestake As CheckBox
    Friend WithEvents stakable As CheckBox
    Friend WithEvents digitLabel As Label
    Friend WithEvents quantityTotalLabel As Label
    Friend WithEvents symbol As TextBox
    Friend WithEvents symbolLabel As Label
    Friend WithEvents shortName As TextBox
    Friend WithEvents shortNameLabel As Label
    Friend WithEvents assetName As TextBox
    Friend WithEvents assetNameLabel As Label
End Class
