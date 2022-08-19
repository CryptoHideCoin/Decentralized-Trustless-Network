Option Compare Text
Option Explicit On


Public Class DataTrade

    Public Property data As AreaCommon.Models.Bot.TradeModel
    Public Property common As AreaCommon.Models.Pair.PairInformation


    Private Function durate(ByVal millisecond As Double) As String
        Dim result As String
        Dim temp As Double

        temp = millisecond / 1000

        If (temp >= 1) Then
            result = $"{Int(temp).ToString()} sec."
        Else
            result = $"{millisecond} mSec."

            Return result
        End If

        temp = temp / 60

        If (temp >= 1) Then
            result = $"{Int(temp).ToString()} min."
        Else
            Return result
        End If

        temp = temp / 60

        If (temp >= 1) Then
            result = $"{Int(temp).ToString()} hour(s)"
        Else
            Return result
        End If

        temp = temp / 24

        If (temp >= 1) Then
            result = $"{Int(temp).ToString()} day(s)"
        Else
            Return result
        End If

        temp = temp / 7

        If (temp >= 1) Then
            result = $"{Int(temp).ToString()} week(s)"
        Else
            Return result
        End If

        temp = temp / 4

        If (temp >= 1) Then
            result = $"{Int(temp).ToString()} month(s)"
        Else
            Return result
        End If

        temp = temp / 12

        If (temp >= 1) Then
            result = $"{Int(temp).ToString()} year(s)"
        End If

        Return result
    End Function

    Private Sub updateTimer_Tick(sender As Object, e As EventArgs) Handles updateTimer.Tick
        Dim firstCurrency As String = $" {common.key.Split("-")(0)}"
        Dim secondCurrency As String = $" {common.key.Split("-")(1)}"

        With data.buy
            idBuyValue.Text = .id
            numberBuy.Text = .number

            timeAcquireBuyValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.timeStart), True)

            If (.timeCompleted = 0) Then
                timeBuyValue.Text = "---"
            Else
                timeBuyValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.timeCompleted), True)
            End If

            orderValueBuy.Text = .orderValue.ToString("#,##0.00000") & secondCurrency
            pairTradeBuyValue.Text = .pairTradeValue.ToString("#,##0.00000") & secondCurrency

            If (.tco = 0) Then
                effectiveBuyValue.Text = "---"
            Else
                effectiveBuyValue.Text = .tco.ToString("#,##0.00000") & secondCurrency
            End If

            amountBuy.Text = .amount.ToString("#,##0.00000") & firstCurrency

            If (.feeCost = 0) Then
                feeBuyValue.Text = "---"
            Else
                feeBuyValue.Text = .feeCost.ToString("#,##0.00000") & secondCurrency
            End If

            Select Case .state
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.sented : stateBuyValue.Text = "Sented"
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.placed : stateBuyValue.Text = "Placed"
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.filled : stateBuyValue.Text = "Filled"
            End Select

            waitFundValue.Checked = (.notBeforeThat > 0)
        End With

        With data.sell
            idSellValue.Text = .id
            numberSell.Text = .number

            timeAcquireSellValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.timeStart), True)

            If (.timeCompleted = 0) Then
                timeSellValue.Text = "---"
            Else
                timeSellValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.timeCompleted), True)
            End If

            orderValueSell.Text = .orderValue.ToString("#,##0.00000") & secondCurrency
            pairTradeSellValue.Text = .pairTradeValue.ToString("#,##0.00000") & secondCurrency

            If (.tco = 0) Then
                effectiveSellValue.Text = "---"
            Else
                effectiveSellValue.Text = .tco.ToString("#,##0.00000") & secondCurrency
            End If

            amountSell.Text = .amount.ToString("#,##0.00000") & firstCurrency

            If (.feeCost = 0) Then
                feeSellValue.Text = "---"
            Else
                feeSellValue.Text = .feeCost.ToString("#,##0.00000") & secondCurrency
            End If

            tradeClosedValue.Checked = False

            Select Case .state
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.sented : stateSellValue.Text = "Sented"
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.placed : stateSellValue.Text = "Placed"
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                    stateSellValue.Text = "Filled"
                    tradeClosedValue.Checked = True
            End Select
        End With

        Dim difference As Double = (common.currentValue * data.sell.amount) - (data.buy.tco - data.buy.feeCost)
        Dim percentage As Double = 0

        If (data.sell.state = AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.filled) Then
            difference = data.sell.tco - data.buy.tco - data.buy.feeCost - data.sell.feeCost
        End If

        If (data.buy.tco - data.buy.feeCost) > 0 Then
            percentage = difference / (data.buy.tco - data.buy.feeCost)
        End If

        If (data.sell.state = AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.filled) Then
            earnValue.Text = $"{data.earn.ToString("#,##0.00")} {common.key.Split("-")(1)} ({percentage.ToString("#,##0.00")} %)"
        Else
            earnValue.Text = "---"
        End If

        totalFeesValue.Text = (data.buy.feeCost + data.sell.feeCost).ToString("#,##0.00") & secondCurrency

        If (data.sell.state = AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.filled) Then
            currentEarnValue.Text = earnValue.Text

            durateValue.Text = durate(data.sell.timeCompleted - data.buy.timeCompleted)
        Else
            currentEarnValue.Text = $"{(difference).ToString("#,##0.00")} {common.key.Split("-")(1)} ({percentage.ToString("#,##0.00")} %)"

            durateValue.Text = durate(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - data.buy.timeStart)
        End If

    End Sub

End Class