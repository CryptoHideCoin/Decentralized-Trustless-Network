<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTrade
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataTrade))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.buyOrderPage = New System.Windows.Forms.TabPage()
        Me.orderPlacedBuyValue = New System.Windows.Forms.CheckBox()
        Me.orderSentBuyValue = New System.Windows.Forms.CheckBox()
        Me.orderFillBuyValue = New System.Windows.Forms.CheckBox()
        Me.numberBuy = New System.Windows.Forms.Label()
        Me.numberBuyLabel = New System.Windows.Forms.Label()
        Me.amountBuy = New System.Windows.Forms.Label()
        Me.amountLabel = New System.Windows.Forms.Label()
        Me.effectiveBuyValue = New System.Windows.Forms.Label()
        Me.effectiveValueLabel = New System.Windows.Forms.Label()
        Me.pairTradeBuyValue = New System.Windows.Forms.Label()
        Me.pairTradeValueLabel = New System.Windows.Forms.Label()
        Me.orderValueBuy = New System.Windows.Forms.Label()
        Me.orderValueBuyLabel = New System.Windows.Forms.Label()
        Me.timeAcquireBuyValue = New System.Windows.Forms.Label()
        Me.timeAcquireBuyLabel = New System.Windows.Forms.Label()
        Me.idBuyValue = New System.Windows.Forms.Label()
        Me.idBuyLabel = New System.Windows.Forms.Label()
        Me.sellOrderPage = New System.Windows.Forms.TabPage()
        Me.orderPlacedSellValue = New System.Windows.Forms.CheckBox()
        Me.orderSentSellValue = New System.Windows.Forms.CheckBox()
        Me.orderFillSellValue = New System.Windows.Forms.CheckBox()
        Me.numberSell = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.amountSell = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.effectiveSellValue = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pairTradeSellValue = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.orderValueSell = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.timeAcquireSellValue = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.idSellValue = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.updateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.earnValue = New System.Windows.Forms.TextBox()
        Me.earnLabel = New System.Windows.Forms.Label()
        Me.currentEarnValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.durateValue = New System.Windows.Forms.TextBox()
        Me.currentDurateLabel = New System.Windows.Forms.Label()
        Me.feeBuyValue = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.feeSellValue = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.buyOrderPage.SuspendLayout()
        Me.sellOrderPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.buyOrderPage)
        Me.TabControl1.Controls.Add(Me.sellOrderPage)
        Me.TabControl1.Location = New System.Drawing.Point(14, 98)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(377, 340)
        Me.TabControl1.TabIndex = 0
        '
        'buyOrderPage
        '
        Me.buyOrderPage.Controls.Add(Me.feeBuyValue)
        Me.buyOrderPage.Controls.Add(Me.Label5)
        Me.buyOrderPage.Controls.Add(Me.orderPlacedBuyValue)
        Me.buyOrderPage.Controls.Add(Me.orderSentBuyValue)
        Me.buyOrderPage.Controls.Add(Me.orderFillBuyValue)
        Me.buyOrderPage.Controls.Add(Me.numberBuy)
        Me.buyOrderPage.Controls.Add(Me.numberBuyLabel)
        Me.buyOrderPage.Controls.Add(Me.amountBuy)
        Me.buyOrderPage.Controls.Add(Me.amountLabel)
        Me.buyOrderPage.Controls.Add(Me.effectiveBuyValue)
        Me.buyOrderPage.Controls.Add(Me.effectiveValueLabel)
        Me.buyOrderPage.Controls.Add(Me.pairTradeBuyValue)
        Me.buyOrderPage.Controls.Add(Me.pairTradeValueLabel)
        Me.buyOrderPage.Controls.Add(Me.orderValueBuy)
        Me.buyOrderPage.Controls.Add(Me.orderValueBuyLabel)
        Me.buyOrderPage.Controls.Add(Me.timeAcquireBuyValue)
        Me.buyOrderPage.Controls.Add(Me.timeAcquireBuyLabel)
        Me.buyOrderPage.Controls.Add(Me.idBuyValue)
        Me.buyOrderPage.Controls.Add(Me.idBuyLabel)
        Me.buyOrderPage.Location = New System.Drawing.Point(4, 22)
        Me.buyOrderPage.Name = "buyOrderPage"
        Me.buyOrderPage.Padding = New System.Windows.Forms.Padding(3)
        Me.buyOrderPage.Size = New System.Drawing.Size(369, 314)
        Me.buyOrderPage.TabIndex = 0
        Me.buyOrderPage.Text = "Buy Order"
        Me.buyOrderPage.UseVisualStyleBackColor = True
        '
        'orderPlacedBuyValue
        '
        Me.orderPlacedBuyValue.AutoSize = True
        Me.orderPlacedBuyValue.Enabled = False
        Me.orderPlacedBuyValue.Location = New System.Drawing.Point(215, 248)
        Me.orderPlacedBuyValue.Name = "orderPlacedBuyValue"
        Me.orderPlacedBuyValue.Size = New System.Drawing.Size(100, 17)
        Me.orderPlacedBuyValue.TabIndex = 16
        Me.orderPlacedBuyValue.Text = "Order placed"
        Me.orderPlacedBuyValue.UseVisualStyleBackColor = True
        '
        'orderSentBuyValue
        '
        Me.orderSentBuyValue.AutoSize = True
        Me.orderSentBuyValue.Enabled = False
        Me.orderSentBuyValue.Location = New System.Drawing.Point(105, 248)
        Me.orderSentBuyValue.Name = "orderSentBuyValue"
        Me.orderSentBuyValue.Size = New System.Drawing.Size(87, 17)
        Me.orderSentBuyValue.TabIndex = 15
        Me.orderSentBuyValue.Text = "Order sent"
        Me.orderSentBuyValue.UseVisualStyleBackColor = True
        '
        'orderFillBuyValue
        '
        Me.orderFillBuyValue.AutoSize = True
        Me.orderFillBuyValue.Enabled = False
        Me.orderFillBuyValue.Location = New System.Drawing.Point(106, 276)
        Me.orderFillBuyValue.Name = "orderFillBuyValue"
        Me.orderFillBuyValue.Size = New System.Drawing.Size(76, 17)
        Me.orderFillBuyValue.TabIndex = 14
        Me.orderFillBuyValue.Text = "Order fill"
        Me.orderFillBuyValue.UseVisualStyleBackColor = True
        '
        'numberBuy
        '
        Me.numberBuy.BackColor = System.Drawing.Color.WhiteSmoke
        Me.numberBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numberBuy.Location = New System.Drawing.Point(106, 45)
        Me.numberBuy.Name = "numberBuy"
        Me.numberBuy.Size = New System.Drawing.Size(244, 21)
        Me.numberBuy.TabIndex = 13
        Me.numberBuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numberBuyLabel
        '
        Me.numberBuyLabel.AutoSize = True
        Me.numberBuyLabel.Location = New System.Drawing.Point(49, 49)
        Me.numberBuyLabel.Name = "numberBuyLabel"
        Me.numberBuyLabel.Size = New System.Drawing.Size(52, 13)
        Me.numberBuyLabel.TabIndex = 12
        Me.numberBuyLabel.Text = "Number"
        '
        'amountBuy
        '
        Me.amountBuy.BackColor = System.Drawing.Color.WhiteSmoke
        Me.amountBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.amountBuy.Location = New System.Drawing.Point(106, 195)
        Me.amountBuy.Name = "amountBuy"
        Me.amountBuy.Size = New System.Drawing.Size(244, 21)
        Me.amountBuy.TabIndex = 11
        Me.amountBuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'amountLabel
        '
        Me.amountLabel.AutoSize = True
        Me.amountLabel.Location = New System.Drawing.Point(49, 199)
        Me.amountLabel.Name = "amountLabel"
        Me.amountLabel.Size = New System.Drawing.Size(51, 13)
        Me.amountLabel.TabIndex = 10
        Me.amountLabel.Text = "Amount"
        '
        'effectiveBuyValue
        '
        Me.effectiveBuyValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.effectiveBuyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.effectiveBuyValue.Location = New System.Drawing.Point(106, 170)
        Me.effectiveBuyValue.Name = "effectiveBuyValue"
        Me.effectiveBuyValue.Size = New System.Drawing.Size(244, 21)
        Me.effectiveBuyValue.TabIndex = 9
        Me.effectiveBuyValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'effectiveValueLabel
        '
        Me.effectiveValueLabel.AutoSize = True
        Me.effectiveValueLabel.Location = New System.Drawing.Point(68, 174)
        Me.effectiveValueLabel.Name = "effectiveValueLabel"
        Me.effectiveValueLabel.Size = New System.Drawing.Size(32, 13)
        Me.effectiveValueLabel.TabIndex = 8
        Me.effectiveValueLabel.Text = "TCO"
        '
        'pairTradeBuyValue
        '
        Me.pairTradeBuyValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pairTradeBuyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pairTradeBuyValue.Location = New System.Drawing.Point(106, 145)
        Me.pairTradeBuyValue.Name = "pairTradeBuyValue"
        Me.pairTradeBuyValue.Size = New System.Drawing.Size(244, 21)
        Me.pairTradeBuyValue.TabIndex = 7
        Me.pairTradeBuyValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pairTradeValueLabel
        '
        Me.pairTradeValueLabel.AutoSize = True
        Me.pairTradeValueLabel.Location = New System.Drawing.Point(2, 149)
        Me.pairTradeValueLabel.Name = "pairTradeValueLabel"
        Me.pairTradeValueLabel.Size = New System.Drawing.Size(98, 13)
        Me.pairTradeValueLabel.TabIndex = 6
        Me.pairTradeValueLabel.Text = "Pair trade value"
        '
        'orderValueBuy
        '
        Me.orderValueBuy.BackColor = System.Drawing.Color.WhiteSmoke
        Me.orderValueBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.orderValueBuy.Location = New System.Drawing.Point(106, 120)
        Me.orderValueBuy.Name = "orderValueBuy"
        Me.orderValueBuy.Size = New System.Drawing.Size(244, 21)
        Me.orderValueBuy.TabIndex = 5
        Me.orderValueBuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'orderValueBuyLabel
        '
        Me.orderValueBuyLabel.AutoSize = True
        Me.orderValueBuyLabel.Location = New System.Drawing.Point(62, 124)
        Me.orderValueBuyLabel.Name = "orderValueBuyLabel"
        Me.orderValueBuyLabel.Size = New System.Drawing.Size(38, 13)
        Me.orderValueBuyLabel.TabIndex = 4
        Me.orderValueBuyLabel.Text = "Value"
        '
        'timeAcquireBuyValue
        '
        Me.timeAcquireBuyValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.timeAcquireBuyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.timeAcquireBuyValue.Location = New System.Drawing.Point(106, 82)
        Me.timeAcquireBuyValue.Name = "timeAcquireBuyValue"
        Me.timeAcquireBuyValue.Size = New System.Drawing.Size(244, 21)
        Me.timeAcquireBuyValue.TabIndex = 3
        Me.timeAcquireBuyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'timeAcquireBuyLabel
        '
        Me.timeAcquireBuyLabel.AutoSize = True
        Me.timeAcquireBuyLabel.Location = New System.Drawing.Point(19, 86)
        Me.timeAcquireBuyLabel.Name = "timeAcquireBuyLabel"
        Me.timeAcquireBuyLabel.Size = New System.Drawing.Size(81, 13)
        Me.timeAcquireBuyLabel.TabIndex = 2
        Me.timeAcquireBuyLabel.Text = "Time acquire"
        '
        'idBuyValue
        '
        Me.idBuyValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.idBuyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.idBuyValue.Location = New System.Drawing.Point(106, 20)
        Me.idBuyValue.Name = "idBuyValue"
        Me.idBuyValue.Size = New System.Drawing.Size(244, 21)
        Me.idBuyValue.TabIndex = 1
        Me.idBuyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'idBuyLabel
        '
        Me.idBuyLabel.AutoSize = True
        Me.idBuyLabel.Location = New System.Drawing.Point(79, 24)
        Me.idBuyLabel.Name = "idBuyLabel"
        Me.idBuyLabel.Size = New System.Drawing.Size(21, 13)
        Me.idBuyLabel.TabIndex = 0
        Me.idBuyLabel.Text = "ID"
        '
        'sellOrderPage
        '
        Me.sellOrderPage.Controls.Add(Me.feeSellValue)
        Me.sellOrderPage.Controls.Add(Me.Label7)
        Me.sellOrderPage.Controls.Add(Me.orderPlacedSellValue)
        Me.sellOrderPage.Controls.Add(Me.orderSentSellValue)
        Me.sellOrderPage.Controls.Add(Me.orderFillSellValue)
        Me.sellOrderPage.Controls.Add(Me.numberSell)
        Me.sellOrderPage.Controls.Add(Me.Label2)
        Me.sellOrderPage.Controls.Add(Me.amountSell)
        Me.sellOrderPage.Controls.Add(Me.Label4)
        Me.sellOrderPage.Controls.Add(Me.effectiveSellValue)
        Me.sellOrderPage.Controls.Add(Me.Label6)
        Me.sellOrderPage.Controls.Add(Me.pairTradeSellValue)
        Me.sellOrderPage.Controls.Add(Me.Label8)
        Me.sellOrderPage.Controls.Add(Me.orderValueSell)
        Me.sellOrderPage.Controls.Add(Me.Label10)
        Me.sellOrderPage.Controls.Add(Me.timeAcquireSellValue)
        Me.sellOrderPage.Controls.Add(Me.Label12)
        Me.sellOrderPage.Controls.Add(Me.idSellValue)
        Me.sellOrderPage.Controls.Add(Me.Label14)
        Me.sellOrderPage.Location = New System.Drawing.Point(4, 22)
        Me.sellOrderPage.Name = "sellOrderPage"
        Me.sellOrderPage.Padding = New System.Windows.Forms.Padding(3)
        Me.sellOrderPage.Size = New System.Drawing.Size(369, 314)
        Me.sellOrderPage.TabIndex = 1
        Me.sellOrderPage.Text = "Sell Order"
        Me.sellOrderPage.UseVisualStyleBackColor = True
        '
        'orderPlacedSellValue
        '
        Me.orderPlacedSellValue.AutoSize = True
        Me.orderPlacedSellValue.Enabled = False
        Me.orderPlacedSellValue.Location = New System.Drawing.Point(242, 252)
        Me.orderPlacedSellValue.Name = "orderPlacedSellValue"
        Me.orderPlacedSellValue.Size = New System.Drawing.Size(100, 17)
        Me.orderPlacedSellValue.TabIndex = 33
        Me.orderPlacedSellValue.Text = "Order placed"
        Me.orderPlacedSellValue.UseVisualStyleBackColor = True
        '
        'orderSentSellValue
        '
        Me.orderSentSellValue.AutoSize = True
        Me.orderSentSellValue.Enabled = False
        Me.orderSentSellValue.Location = New System.Drawing.Point(106, 252)
        Me.orderSentSellValue.Name = "orderSentSellValue"
        Me.orderSentSellValue.Size = New System.Drawing.Size(87, 17)
        Me.orderSentSellValue.TabIndex = 32
        Me.orderSentSellValue.Text = "Order sent"
        Me.orderSentSellValue.UseVisualStyleBackColor = True
        '
        'orderFillSellValue
        '
        Me.orderFillSellValue.AutoSize = True
        Me.orderFillSellValue.Enabled = False
        Me.orderFillSellValue.Location = New System.Drawing.Point(106, 276)
        Me.orderFillSellValue.Name = "orderFillSellValue"
        Me.orderFillSellValue.Size = New System.Drawing.Size(76, 17)
        Me.orderFillSellValue.TabIndex = 31
        Me.orderFillSellValue.Text = "Order fill"
        Me.orderFillSellValue.UseVisualStyleBackColor = True
        '
        'numberSell
        '
        Me.numberSell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.numberSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numberSell.Location = New System.Drawing.Point(106, 45)
        Me.numberSell.Name = "numberSell"
        Me.numberSell.Size = New System.Drawing.Size(244, 21)
        Me.numberSell.TabIndex = 30
        Me.numberSell.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Number"
        '
        'amountSell
        '
        Me.amountSell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.amountSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.amountSell.Location = New System.Drawing.Point(106, 195)
        Me.amountSell.Name = "amountSell"
        Me.amountSell.Size = New System.Drawing.Size(244, 21)
        Me.amountSell.TabIndex = 28
        Me.amountSell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Amount"
        '
        'effectiveSellValue
        '
        Me.effectiveSellValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.effectiveSellValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.effectiveSellValue.Location = New System.Drawing.Point(106, 170)
        Me.effectiveSellValue.Name = "effectiveSellValue"
        Me.effectiveSellValue.Size = New System.Drawing.Size(244, 21)
        Me.effectiveSellValue.TabIndex = 26
        Me.effectiveSellValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "TCO"
        '
        'pairTradeSellValue
        '
        Me.pairTradeSellValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pairTradeSellValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pairTradeSellValue.Location = New System.Drawing.Point(106, 145)
        Me.pairTradeSellValue.Name = "pairTradeSellValue"
        Me.pairTradeSellValue.Size = New System.Drawing.Size(244, 21)
        Me.pairTradeSellValue.TabIndex = 24
        Me.pairTradeSellValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Pair trade value"
        '
        'orderValueSell
        '
        Me.orderValueSell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.orderValueSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.orderValueSell.Location = New System.Drawing.Point(106, 120)
        Me.orderValueSell.Name = "orderValueSell"
        Me.orderValueSell.Size = New System.Drawing.Size(244, 21)
        Me.orderValueSell.TabIndex = 22
        Me.orderValueSell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(62, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Value"
        '
        'timeAcquireSellValue
        '
        Me.timeAcquireSellValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.timeAcquireSellValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.timeAcquireSellValue.Location = New System.Drawing.Point(106, 82)
        Me.timeAcquireSellValue.Name = "timeAcquireSellValue"
        Me.timeAcquireSellValue.Size = New System.Drawing.Size(244, 21)
        Me.timeAcquireSellValue.TabIndex = 20
        Me.timeAcquireSellValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Time acquire"
        '
        'idSellValue
        '
        Me.idSellValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.idSellValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.idSellValue.Location = New System.Drawing.Point(106, 20)
        Me.idSellValue.Name = "idSellValue"
        Me.idSellValue.Size = New System.Drawing.Size(244, 21)
        Me.idSellValue.TabIndex = 18
        Me.idSellValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(79, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "ID"
        '
        'updateTimer
        '
        Me.updateTimer.Enabled = True
        Me.updateTimer.Interval = 10000
        '
        'earnValue
        '
        Me.earnValue.Location = New System.Drawing.Point(124, 43)
        Me.earnValue.Name = "earnValue"
        Me.earnValue.ReadOnly = True
        Me.earnValue.Size = New System.Drawing.Size(236, 21)
        Me.earnValue.TabIndex = 36
        Me.earnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'earnLabel
        '
        Me.earnLabel.AutoSize = True
        Me.earnLabel.Location = New System.Drawing.Point(85, 46)
        Me.earnLabel.Name = "earnLabel"
        Me.earnLabel.Size = New System.Drawing.Size(33, 13)
        Me.earnLabel.TabIndex = 35
        Me.earnLabel.Text = "Earn"
        '
        'currentEarnValue
        '
        Me.currentEarnValue.Location = New System.Drawing.Point(124, 16)
        Me.currentEarnValue.Name = "currentEarnValue"
        Me.currentEarnValue.ReadOnly = True
        Me.currentEarnValue.Size = New System.Drawing.Size(236, 21)
        Me.currentEarnValue.TabIndex = 38
        Me.currentEarnValue.Text = "---"
        Me.currentEarnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Current Earn"
        '
        'durateValue
        '
        Me.durateValue.Location = New System.Drawing.Point(124, 71)
        Me.durateValue.Name = "durateValue"
        Me.durateValue.ReadOnly = True
        Me.durateValue.Size = New System.Drawing.Size(236, 21)
        Me.durateValue.TabIndex = 40
        Me.durateValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'currentDurateLabel
        '
        Me.currentDurateLabel.AutoSize = True
        Me.currentDurateLabel.Location = New System.Drawing.Point(73, 74)
        Me.currentDurateLabel.Name = "currentDurateLabel"
        Me.currentDurateLabel.Size = New System.Drawing.Size(46, 13)
        Me.currentDurateLabel.TabIndex = 39
        Me.currentDurateLabel.Text = "Durate"
        '
        'feeBuyValue
        '
        Me.feeBuyValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.feeBuyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.feeBuyValue.Location = New System.Drawing.Point(106, 220)
        Me.feeBuyValue.Name = "feeBuyValue"
        Me.feeBuyValue.Size = New System.Drawing.Size(244, 21)
        Me.feeBuyValue.TabIndex = 18
        Me.feeBuyValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(73, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Fee"
        '
        'feeSellValue
        '
        Me.feeSellValue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.feeSellValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.feeSellValue.Location = New System.Drawing.Point(106, 220)
        Me.feeSellValue.Name = "feeSellValue"
        Me.feeSellValue.Size = New System.Drawing.Size(244, 21)
        Me.feeSellValue.TabIndex = 35
        Me.feeSellValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(74, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Fee"
        '
        'DataTrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 463)
        Me.Controls.Add(Me.durateValue)
        Me.Controls.Add(Me.currentDurateLabel)
        Me.Controls.Add(Me.currentEarnValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.earnValue)
        Me.Controls.Add(Me.earnLabel)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DataTrade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Trade"
        Me.TabControl1.ResumeLayout(False)
        Me.buyOrderPage.ResumeLayout(False)
        Me.buyOrderPage.PerformLayout()
        Me.sellOrderPage.ResumeLayout(False)
        Me.sellOrderPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents buyOrderPage As TabPage
    Friend WithEvents sellOrderPage As TabPage
    Friend WithEvents idBuyValue As Label
    Friend WithEvents idBuyLabel As Label
    Friend WithEvents timeAcquireBuyValue As Label
    Friend WithEvents timeAcquireBuyLabel As Label
    Friend WithEvents orderValueBuy As Label
    Friend WithEvents orderValueBuyLabel As Label
    Friend WithEvents orderPlacedBuyValue As CheckBox
    Friend WithEvents orderSentBuyValue As CheckBox
    Friend WithEvents orderFillBuyValue As CheckBox
    Friend WithEvents numberBuy As Label
    Friend WithEvents numberBuyLabel As Label
    Friend WithEvents amountBuy As Label
    Friend WithEvents amountLabel As Label
    Friend WithEvents effectiveBuyValue As Label
    Friend WithEvents effectiveValueLabel As Label
    Friend WithEvents pairTradeBuyValue As Label
    Friend WithEvents pairTradeValueLabel As Label
    Friend WithEvents orderPlacedSellValue As CheckBox
    Friend WithEvents orderSentSellValue As CheckBox
    Friend WithEvents orderFillSellValue As CheckBox
    Friend WithEvents numberSell As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents amountSell As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents effectiveSellValue As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pairTradeSellValue As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents orderValueSell As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents timeAcquireSellValue As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents idSellValue As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents updateTimer As Timer
    Friend WithEvents earnValue As TextBox
    Friend WithEvents earnLabel As Label
    Friend WithEvents currentEarnValue As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents durateValue As TextBox
    Friend WithEvents currentDurateLabel As Label
    Friend WithEvents feeBuyValue As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents feeSellValue As Label
    Friend WithEvents Label7 As Label
End Class
