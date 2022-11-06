Option Compare Text
Option Explicit On


Public Class FundReservations

    Private Sub FundReservations_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With AreaState.gainFund
            If (.nextUserTargetDay.Trim.Length <> 0) Then
                userDayStartValue.Text = .nextUserTargetDay
            Else
                userDayStartValue.Text = "---"
            End If

            If (.currentLockedFund = 0) Then
                currentLockedValue.Text = "---"
            Else
                currentLockedValue.Text = .currentLockedFund.ToString("#,##0.00")
            End If

            modeValue.SelectedIndex = .mode - 1

            If (modeValue.SelectedIndex <> -1) Then
                If (.targetDay > 0) Then
                    targetDayValue.Text = .targetDay
                End If

                bankCurrencyValue.Text = .targetCurrency

                If (.targetValue > 0) Then
                    targetValue.Text = .targetValue
                End If

                onlyInEarnValue.Checked = .whenInEarn
            End If
        End With

    End Sub

    Private Sub modeValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modeValue.SelectedIndexChanged

        targetDayLabel.Enabled = (modeValue.SelectedIndex = 3)
        targetDayValue.Enabled = targetDayLabel.Enabled

        targetLabel.Enabled = (modeValue.SelectedIndex <> 0)
        targetValue.Enabled = targetLabel.Enabled

        onlyInEarnValue.Enabled = (modeValue.SelectedIndex > 1)

        If Not targetDayLabel.Enabled Then
            targetDayValue.Text = ""
            targetValue.Text = ""
            onlyInEarnValue.Checked = False
        End If

    End Sub

    Private Function verifyData() As Boolean
        If (modeValue.SelectedIndex = -1) Then
            MessageBox.Show("Select the mode")

            Return False
        End If

        If targetDayValue.Enabled Then
            If (targetDayValue.Text.Trim.Length = 0) Then
                MessageBox.Show("Insert target day")

                Return False
            End If
            If Not IsNumeric(targetDayValue.Text.Trim()) Then
                MessageBox.Show("Target day is not numeric")

                Return False
            End If
            If Val(targetDayValue.Text.Trim()) > 28 Then
                MessageBox.Show("Uncorrect target day")

                Return False
            End If
        End If

        If targetValue.Enabled Then
            If (targetValue.Text.Trim.Length = 0) Then
                MessageBox.Show("Target value missing")

                Return False
            End If
            If Not IsNumeric(targetValue.Text.Trim()) Then
                MessageBox.Show("Target value is not numeric")

                Return False
            End If
            If (Val(targetValue.Text.Trim()) = 0) Then
                MessageBox.Show("Target value missing")

                Return False
            End If
        End If

        Return True
    End Function

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If Not verifyData() Then
            Return
        End If

        With AreaState.gainFund
            .mode = modeValue.SelectedIndex + 1

            If (.mode = AreaCommon.Models.Journal.FundReservationModel.ModeReservationEnumeration.urgent) Or
               (.mode = AreaCommon.Models.Journal.FundReservationModel.ModeReservationEnumeration.immediate) Then

                .nextTargetDay = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                .nextUserTargetDay = Now.Day

            End If

            If (.mode = AreaCommon.Models.Journal.FundReservationModel.ModeReservationEnumeration.booking) Then
                .targetDay = targetDayValue.Text
            End If

            .targetCurrency = bankCurrencyValue.Text

            If targetValue.Enabled Then
                .targetValue = targetValue.Text
            Else
                .targetValue = 0
            End If

            .whenInEarn = onlyInEarnValue.Checked

            .targetLockedFund = .targetValue
        End With

        If (AreaState.gainFund.mode = AreaCommon.Models.Journal.FundReservationModel.ModeReservationEnumeration.allNow) Then
            If (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                AreaState.automaticBot.isActive = False

                AreaCommon.Engines.Bots.AutomaticBotModule.stop()

                For Each product In AreaState.products.items
                    If product.activity.inUse And (product.header.key.ToLower.CompareTo("USDT".ToLower) <> 0) Then
                        AreaState.addIntoAccount(product.pairID, (-1) * product.activity.totalAmount, False)
                        AreaState.addIntoAccount(AreaState.gainFund.targetCurrency, product.activity.totalInvestment, False)

                        product.resetData()
                    End If
                Next

                AreaState.orders.Clear()

                AreaState.gainFund = New AreaCommon.Models.Journal.FundReservationModel
            End If
        End If

        Me.Close()
    End Sub


End Class