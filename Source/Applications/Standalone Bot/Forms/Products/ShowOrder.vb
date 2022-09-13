Option Compare Text
Option Explicit On


Public Class ShowOrder

    Public Property currentOrder As AreaCommon.Models.Products.ProductOrderModel
    Public Property pairID As String = ""
    Public Property sellSide As Boolean = False


    Private Sub ShowOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If sellSide Then
                dateAcquireLabel.Text = "Date sell"
            End If

            idOrderValue.Text = currentOrder.orderNumber
            internalOrderIDValue.Text = currentOrder.internalOrderId

            pairIDValue.Text = pairID

            If (currentOrder.dateAcquire = 0) Then
                dateAcquireValue.Text = "---"
            Else
                dateAcquireValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(currentOrder.dateAcquire), True)
            End If

            If (currentOrder.amount = 0) Then
                amountValue.Text = "---"
            Else
                amountValue.Text = currentOrder.amount
            End If

            If (currentOrder.tcoQuote = 0) Then
                tcoQuoteValue.Text = "---"
            Else
                tcoQuoteValue.Text = currentOrder.tcoQuote
            End If

            orderStateValue.ForeColor = Color.Black

            Select Case currentOrder.orderState
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.filled
                    orderStateValue.ForeColor = Color.DarkGreen
                    orderStateValue.Text = "Filled"
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.placed
                    orderStateValue.Text = "Placed"
                    orderStateValue.ForeColor = Color.Yellow
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.sented : orderStateValue.Text = "Sented"
                Case AreaCommon.Models.Bot.BotOrderModel.OrderStateEnumeration.undefined : orderStateValue.Text = "Undefined"
            End Select

            quoteCurrencyValue.Text = pairID.Split("-")(0)
            baseCurrencyValue.Text = pairID.Split("-")(1)

            If (currentOrder.feeCost = 0) Then
                feeValue.Text = "---"
            Else
                feeValue.Text = currentOrder.feeCost
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class