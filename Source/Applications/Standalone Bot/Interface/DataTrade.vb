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

        With data.buy
            idBuyValue.Text = .id
            numberBuy.Text = .number

            timeAcquireBuyValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.timeAcquire), True)

            orderValueBuy.Text = .orderValue.ToString("#,##0.00000") & " " & common.key.Split("-")(1)
            pairTradeBuyValue.Text = .pairTradeValue.ToString("#,##0.00000") & " " & common.key.Split("-")(1)
            effectiveBuyValue.Text = .tco.ToString("#,##0.00000") & " " & common.key.Split("-")(1)
            amountBuy.Text = .amount.ToString("#,##0.00000")
            feeBuyValue.Text = .feeCost.ToString("#,##0.00000") & " " & common.key.Split("-")(1)

            orderSentBuyValue.Checked = .sent
            orderPlacedBuyValue.Checked = .placed
            orderFillBuyValue.Checked = .fill
        End With

        With data.sell
            idSellValue.Text = .id
            numberSell.Text = .number

            timeAcquireSellValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.timeAcquire), True)

            orderValueSell.Text = .orderValue.ToString("#,##0.00000") & " " & common.key.Split("-")(1)
            pairTradeSellValue.Text = .pairTradeValue.ToString("#,##0.00000") & " " & common.key.Split("-")(1)
            effectiveSellValue.Text = .tco.ToString("#,##0.00000") & " " & common.key.Split("-")(1)
            amountSell.Text = .amount.ToString("#,##0.00000")
            feeSellValue.Text = .feeCost.ToString("#,##0.00000") & " " & common.key.Split("-")(1)

            orderSentSellValue.Checked = .sent
            orderPlacedSellValue.Checked = .placed
            orderFillSellValue.Checked = .fill
        End With

        Dim difference As Double = (common.currentValue * data.sell.amount) - (data.buy.tco - data.buy.feeCost)
        Dim percentage As Double = difference / (data.buy.tco - data.buy.feeCost)

        earnValue.Text = data.earn & " " & common.key.Split("-")(1)

        If data.sell.fill Then
            currentEarnValue.Text = earnValue.Text

            durateValue.Text = durate(data.sell.timeAcquire - data.buy.timeAcquire) ' ((data.sell.timeAcquire - data.buy.timeAcquire) \ 1000).ToString & " sec."
        Else
            currentEarnValue.Text = $"{(difference).ToString("#,##0.00")} {common.key.Split("-")(1)} ({percentage.ToString("#,##0.00")} %)"

            durateValue.Text = durate(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - data.buy.timeAcquire) '((CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - data.buy.timeAcquire) \ 1000).ToString & " sec."
        End If

    End Sub

    Private Sub DataTrade_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class