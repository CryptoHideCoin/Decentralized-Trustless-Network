Option Compare Text
Option Explicit On


Public Class AutomaticBotSetting

    Private Sub AutomaticBotSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        plafondSingleProductValue.Text = AreaState.automaticBot.settings.plafondOperation
        unitStepValue.Text = AreaState.automaticBot.settings.unitStep

        minDailyEarnValue.Text = AreaState.automaticBot.settings.minDailyEarn
        maxDailyEarnValue.Text = AreaState.automaticBot.settings.maxDailyEarn

        dealRestockValue.Text = AreaState.automaticBot.settings.dealAcquireOnPercentage

        earnConfigurationValue.SelectedIndex = AreaState.automaticBot.settings.backConfiguration
        backValue.Text = AreaState.automaticBot.settings.backValue

        plafondSingleProductCurrency.Text = "USDT"
        unitStepCurrency.Text = "USDT"

        If AreaState.automaticBot.isActive Then
            stateValue.Text = "ACTIVE"

            actionButton.Text = "STOP"
        Else
            stateValue.Text = "READY"

            actionButton.Text = "START"
        End If

        If (AreaState.automaticBot.lastWorkAction = 0) Then
            lastActivityValue.Text = "---"
        Else
            lastActivityValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(AreaState.automaticBot.lastWorkAction)
        End If
    End Sub

    Private Sub actionButton_Click(sender As Object, e As EventArgs) Handles actionButton.Click
        If Not AreaState.automaticBot.isActive Then
            If (MessageBox.Show("Do you want to stop the automatic bot?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No) Then
                Return
            End If
            If (AreaState.products.items.Count = 0) Then
                MessageBox.Show("Products missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return
            Else
                If (MessageBox.Show("Do you want to start the automatic bot?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No) Then
                    Return
                End If

                For Each item In AreaState.products.items
                    If item.userData.isCustomized Then
                        AreaState.automaticBot.isActive = True

                        AreaCommon.Engines.Bots.AutomaticBotModule.start()

                        Close()

                        Return
                    End If
                Next

                MessageBox.Show("No Product customized missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return
            End If
        End If
    End Sub

    Private Sub earnConfigurationValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles earnConfigurationValue.SelectedIndexChanged
        Select Case earnConfigurationValue.SelectedIndex
            Case -1, 0, 1
                backLabel.Enabled = False
                backValue.Enabled = False
                backValueCurrency.Text = ""
            Case 2
                backLabel.Enabled = True
                backValue.Enabled = True
                backValueCurrency.Text = "USDT"
            Case 3
                backLabel.Enabled = True
                backValue.Enabled = True
                backValueCurrency.Text = "%"
        End Select
    End Sub

    Private Function verifyField(ByVal field As Object, ByVal nameField As String) As Boolean
        If (field.Text.Replace("---", "").Trim.Length = 0) Then
            MessageBox.Show($"Insert {nameField} value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If Not IsNumeric(field.Text.Trim()) Then
            MessageBox.Show($"The {nameField} is not numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (Val(field.Text.Trim()) = 0) Then
            MessageBox.Show($"The {nameField} is not value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If

        Return True
    End Function

    Private Function verifyData() As Boolean
        If Not verifyField(plafondSingleProductValue, "plafond single product") Then
            Return False
        End If
        If Not verifyField(unitStepValue, "unit step") Then
            Return False
        End If
        If Not verifyField(minDailyEarnValue, "min daily earn") Then
            Return False
        End If
        If Not verifyField(maxDailyEarnValue, "max daily earn") Then
            Return False
        End If
        If Not verifyField(dealRestockValue, "deal restock") Then
            Return False
        End If
        If (earnConfigurationValue.SelectedIndex = -1) Then
            MessageBox.Show("Insert the Earn configuration value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If

        If backValue.Enabled Then
            If Not verifyField(backValue, "back") Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub saveDataButton_Click(sender As Object, e As EventArgs) Handles saveDataButton.Click
        If Not verifyData() Then
            Return
        End If
        With AreaState.automaticBot.settings
            If IsNumeric(plafondSingleProductValue.Text) Then
                .plafondOperation = Val(plafondSingleProductValue.Text.Replace(".", "").Replace(",", "."))
                .unitStep = Val(unitStepValue.Text.Replace(".", "").Replace(",", "."))
                .minDailyEarn = Val(minDailyEarnValue.Text.Replace(".", "").Replace(",", "."))
                .maxDailyEarn = Val(maxDailyEarnValue.Text.Replace(".", "").Replace(",", "."))
                .dealAcquireOnPercentage = Val(dealRestockValue.Text.Replace(".", "").Replace(",", "."))
                .backConfiguration = earnConfigurationValue.SelectedIndex
                .backValue = Val(earnConfigurationValue.Text.Replace(".", "").Replace(",", "."))
            End If
        End With

        Close()
    End Sub

End Class