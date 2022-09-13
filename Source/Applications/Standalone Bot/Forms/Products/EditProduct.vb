Option Explicit On
Option Compare Text


Public Class EditProduct

    Private Property currentData As AreaCommon.Models.Products.ProductModel

    Public Property currencyID As String



    Private Sub loadData(Optional ByVal showAll As Boolean = True)
        Dim rowItem As New ArrayList

        keyValue.Text = currentData.header.key
        nameValue.Text = currentData.header.name
        baseCurrencyValue.Text = currentData.header.baseCurrency
        quoteCurrencyValue.Text = currentData.header.quoteCurrency

        minValueCurrency.Text = currentData.header.quoteCurrency
        maxValueCurrency.Text = currentData.header.quoteCurrency
        currentValueCurrency.Text = currentData.header.quoteCurrency
        targetCurrency.Text = currentData.header.quoteCurrency
        totalAmountCurrency.Text = currentData.header.baseCurrency
        totalInvestmentCurrency.Text = currentData.header.quoteCurrency
        spreadCurrency.Text = currentData.header.quoteCurrency

        minValue.ReadOnly = currentData.value.automaticValue
        dateLastValue.Enabled = Not currentData.value.automaticValue
        maxValue.ReadOnly = currentData.value.automaticValue
        dateMaxValue.Enabled = Not currentData.value.automaticValue

        If currentData.value.automaticValue Or (Not currentData.value.automaticValue And showAll) Then
            If currentData.value.minValue = 0 Then
                minValue.Text = "---"
            Else
                minValue.Text = CDec(currentData.value.minValue).ToString()
            End If

            If (currentData.value.dateLast = 0) Then
                dateLastValue.Text = "01/01/2010"
            Else
                dateLastValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(currentData.value.dateLast)
            End If

            If currentData.value.maxValue = 0 Then
                maxValue.Text = "---"
            Else
                maxValue.Text = CDec(currentData.value.maxValue).ToString
            End If

            If (currentData.value.dateLast = 0) Then
                dateMaxValue.Text = "01/01/2010"
            Else
                dateMaxValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(currentData.value.dateMax)
            End If

            stateValue.SelectedIndex = currentData.userData.state
            preferenceValue.SelectedIndex = currentData.userData.preference
        End If

        If (currentData.value.current = 0) Then
            currentValue.Text = "---"
        Else
            currentValue.Text = currentData.value.current
        End If

        If (currentData.value.bottomPercentPosition = 0) Then
            bottomPosition.Text = "---"
            bottomPosition.ForeColor = Color.Black
        Else
            bottomPosition.Text = currentData.value.bottomPercentPosition.ToString("0.00")

            If (currentData.value.bottomPercentPosition < 20) Then
                bottomPosition.ForeColor = Color.DarkGreen
            ElseIf (currentData.value.bottomPercentPosition < 80) Then
                bottomPosition.ForeColor = Color.DarkBlue
            Else
                bottomPosition.ForeColor = Color.DarkRed
            End If
        End If

        For Each buy In currentData.activity.buys
            rowItem.Clear()

            rowItem.Add(buy.internalOrderId)

            tradeOpenedDataView.Rows.Add(rowItem.ToArray)
        Next

        inUseValue.Checked = currentData.activity.inUse

        If (currentData.activity.dateLastCheck = 0) Then
            dateLastCheck.Text = "---"
        Else
            dateLastCheck.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(currentData.activity.dateLastCheck), True)
        End If

        If (currentData.activity.target = 0) Then
            targetValue.Text = "---"
        Else
            targetValue.Text = currentData.activity.target
        End If

        If (currentData.activity.totalAmount = 0) Then
            totalAmountValue.Text = "---"
        Else
            totalAmountValue.Text = currentData.activity.totalAmount
        End If

        If (currentData.activity.totalInvestment = 0) Then
            totalInvestmentValue.Text = "---"
        Else
            totalInvestmentValue.Text = currentData.activity.totalInvestment
        End If

        If (currentData.currentSpread() = 0) Then
            spreadValue.Text = "---"
            spreadValue.ForeColor = Color.Black
        Else
            spreadValue.Text = currentData.currentSpread()

            If (currentData.currentSpread() > 0) Then
                spreadValue.ForeColor = Color.DarkGreen
            Else
                spreadValue.ForeColor = Color.DarkRed
            End If
        End If
    End Sub


    Private Sub EditProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentData = AreaState.products.getCurrency(currencyID)

        If (currentData.header.key.Length > 0) Then
            AreaState.getPairID(currentData.pairID)

            loadData()
        End If

    End Sub

    Private Function verifyData() As Boolean
        If (minValue.Text.Replace("---", "").Trim.Length = 0) Then
            MessageBox.Show("Insert Min Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If Not IsNumeric(minValue.Text.Trim()) Then
            MessageBox.Show("The Min. Value not numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (Val(minValue.Text.Trim.Replace(".", "").Replace(",", ".")) = 0) Then
            MessageBox.Show("The Min. Value not value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (dateLastValue.Value.Year < 2020) Then
            MessageBox.Show("Insert the min. date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If

        If (maxValue.Text.Replace("---", "").Trim.Length = 0) Then
            MessageBox.Show("Insert Max Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If Not IsNumeric(maxValue.Text.Trim()) Then
            MessageBox.Show("The Max. is not numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (Val(maxValue.Text.Trim.Replace(".", "").Replace(",", ".")) = 0) Then
            MessageBox.Show("The Max. is not value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (dateMaxValue.Value.Year < 2020) Then
            MessageBox.Show("Insert the max. date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If

        If (stateValue.SelectedIndex = -1) Then
            MessageBox.Show("Insert the state value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (preferenceValue.SelectedIndex = -1) Then
            MessageBox.Show("Insert the Preference value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If

        Return True
    End Function

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If Not verifyData() Then
            Return
        End If
        If Not currentData.value.automaticValue Then
            If IsNumeric(minValue.Text) Then
                currentData.value.minValue = Val(minValue.Text.Trim.Replace(".", "").Replace(",", "."))
                currentData.value.dateLast = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(dateLastValue.Value.ToUniversalTime)

                currentData.value.maxValue = Val(maxValue.Text.Trim.Replace(".", "").Replace(",", "."))
                currentData.value.dateMax = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(dateMaxValue.Value.ToUniversalTime)
            End If

            currentData.userData.state = stateValue.SelectedIndex
            currentData.userData.preference = preferenceValue.SelectedIndex

            If Not currentData.userData.isCustomized Then
                currentData.userData.isCustomized = True
            End If

            Close()
        End If
    End Sub

    Private Sub updateMainTimer_Tick(sender As Object, e As EventArgs) Handles updateMainTimer.Tick
        loadData(False)
    End Sub

    Private Sub tradeOpenedDataView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tradeOpenedDataView.CellContentClick
        Select Case e.ColumnIndex
            Case 1
                Dim order As ShowOrder

                If Not IsNothing(currentData) Then
                    order = New ShowOrder

                    For Each buy In currentData.activity.buys
                        If (buy.internalOrderId.CompareTo(tradeOpenedDataView.Rows(e.RowIndex).Cells(0).Value) = 0) Then
                            order.currentOrder = buy
                            order.pairID = currentData.pairID

                            Exit For
                        End If
                    Next

                    order.Show()
                End If
        End Select
    End Sub

    Private Sub targetLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles targetLabel.LinkClicked
        Dim order As New ShowOrder

        order.currentOrder = currentData.activity.sell
        order.pairID = currentData.pairID
        order.sellSide = True

        order.Show()
    End Sub

End Class