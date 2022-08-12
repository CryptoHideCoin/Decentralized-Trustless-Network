Option Compare Text
Option Explicit On



Public Class SettingsBot

    Public Property currentID As String = ""


    Private Property _PairExist As Boolean = False
    Private Property _ThreadInExecution As Boolean = False
    Private Property _SetPair As Double = 0





    Public Property pair() As String
        Get
            Return pairIdValue.Text
        End Get
        Set(value As String)
            pairIdValue.Text = value
        End Set
    End Property

    ''' <summary>
    ''' This method provide to check is time is major of now
    ''' </summary>
    ''' <returns></returns>
    Private Function timeStartIsMajor() As Boolean
        If (currentID.Length = 0) Then
            If activeDateStartValue.Checked Then
                Dim dateValue As New DateTime(dateStartValue.Value.Year, dateStartValue.Value.Month, dateStartValue.Value.Day, timeStartValue.Value.Hour, timeStartValue.Value.Minute, timeStartValue.Value.Second)

                If CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(dateValue.ToUniversalTime) < CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Function validateInformation() As Boolean
        If (pairIdValue.Text.Trim.Length = 0) Then
            MessageBox.Show("Insert Pair ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (plafondValue.Text.Trim.Length = 0) Then
            MessageBox.Show("Insert Plafond.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If Not IsNumeric(plafondValue.Text.Trim) Then
            MessageBox.Show("Insert Plafond numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (unitStepValue.Text.Trim.Length = 0) Then
            MessageBox.Show("Insert Unit Step.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If Not IsNumeric(unitStepValue.Text.Trim) Then
            MessageBox.Show("Insert Unit Step numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (minuteExamValue.Text.Trim().Length > 0) Then
            If Not IsNumeric(minuteExamValue.Text.Trim()) Then
                MessageBox.Show("Insert Minute exam numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If
        If (triggerValue.Text.Trim().Length > 0) Then
            If Not IsNumeric(triggerValue.Text.Trim()) Then
                MessageBox.Show("Insert Trigger numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If
        If (spreadValue.Text.Trim().Length > 0) Then
            If Not IsNumeric(spreadValue.Text.Trim()) Then
                MessageBox.Show("Insert Spread value numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf Val(spreadValue.Text.trim()) > 100 Then
                MessageBox.Show("The Spread value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If
        If (Val(unitStepValue.Text) > Val(plafondValue.Text)) Then
            MessageBox.Show("The unit step is greater than plafond.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (Val(minuteExamValue.Text) > 60) Then
            MessageBox.Show("The minute exam is greater than 60.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If _ThreadInExecution Then
            If Not _PairExist Then
                MessageBox.Show("The pair specificate not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If
        If Not timeStartIsMajor() Then
            MessageBox.Show("The time start is minor of now", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (modeValue.SelectedIndex = -1) Then
            MessageBox.Show("The mode isn't set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (stepIntervalValue.Text.Length > 0) And Not IsNumeric(stepIntervalValue.Text) Then
            MessageBox.Show("The Step Interval isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (dealAcquireValue.Text.Length > 0) And Not IsNumeric(dealAcquireValue.Text) Then
            MessageBox.Show("The Deal acquire isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (dealIntervalValue.Text.Length > 0) And Not IsNumeric(dealIntervalValue.Text) Then
            MessageBox.Show("The Deal interval acquire isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If ((dealAcquireValue.Text.Length > 0) Or (dealIntervalValue.Text.Length > 0)) And ((dealAcquireValue.Text.Length = 0) Or (dealIntervalValue.Text.Length = 0)) Then
            MessageBox.Show("The Deal information is incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If (Val(dealAcquireValue.Text) > 100) Then
            MessageBox.Show("The Deal Acquire value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
        If saveFoundValue.Checked Then
            If (observationTimeBearMarketValue.Text.Trim.Length = 0) And
               (degradePercentageValue.Text.Trim.Length = 0) And
               (bottomReboundPercentageValue.Text.Trim.Length = 0) And
               (maximumExposurePercentageValue.Text.Trim.Length = 0) Then

                saveFoundValue.Checked = False

            ElseIf (observationTimeBearMarketValue.Text.Trim.Length > 0) And Not IsNumeric(observationTimeBearMarketValue.Text) Then
                MessageBox.Show("The Observation Time Bear Market isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (degradePercentageValue.text.trim.Length > 0) And Not IsNumeric(degradePercentageValue.text) Then
                MessageBox.Show("The Degrade percentage isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf ((observationTimeBearMarketValue.Text.Trim.Length > 0) And (degradePercentageValue.text.trim.Length = 0)) Or
                   ((observationTimeBearMarketValue.Text.Trim.Length = 0) And (degradePercentageValue.text.trim.Length > 0)) Then
                MessageBox.Show("The Bear Market is incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (bottomReboundPercentageValue.Text.Trim.Length > 0) And Not IsNumeric(bottomReboundPercentageValue.Text) Then
                MessageBox.Show("The Bottom Rebound Percentage in Bear Market isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (maximumExposurePercentageValue.Text.Trim.Length > 0) And Not IsNumeric(maximumExposurePercentageValue.Text) Then
                MessageBox.Show("The Maximum Exposure Percentage in Bear Market isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (Val(degradePercentageValue) > 100) Then
                MessageBox.Show("The Deal Acquire value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (Val(bottomReboundPercentageValue) > 100) Then
                MessageBox.Show("The Bottom Rebound Percentage value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (Val(maximumExposurePercentageValue) > 100) Then
                MessageBox.Show("The Maximum Exposure Percentage value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If
        If exploreBullrun.Checked Then
            If (halvingMinuteWhenInValue.Text.Trim.Length = 0) And
               (halvingPercentageValue.Text.Trim.Length = 0) And
               (observationTimeValue.Text.Trim.Length = 0) And
               (increasePercentageBullRunValue.Text.Trim.Length = 0) And
               (topReboundPercentageValue.Text.Trim.Length = 0) Then

                exploreBullrun.Checked = False

            ElseIf (halvingMinuteWhenInValue.Text.Trim.Length > 0) And Not IsNumeric(halvingMinuteWhenInValue.Text) Then
                MessageBox.Show("The Halving Minute When isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (halvingPercentageValue.Text.Trim.Length > 0) And Not IsNumeric(halvingPercentageValue.Text) Then
                MessageBox.Show("The Halving Percentage Bullrun isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (observationTimeValue.Text.Trim.Length > 0) And Not IsNumeric(observationTimeValue.Text) Then
                MessageBox.Show("The Observation time Bullrun isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (increasePercentageBullRunValue.Text.Trim.Length > 0) And Not IsNumeric(increasePercentageBullRunValue.Text) Then
                MessageBox.Show("The Increase Percentage Bullrun isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (topReboundPercentageValue.Text.Trim.Length > 0) And Not IsNumeric(topReboundPercentageValue.Text) Then
                MessageBox.Show("The Top Rebound Percentage Bullrun isn't numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (Val(halvingPercentageValue) > 100) Then
                MessageBox.Show("The Halving Percentage Bullrun value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (Val(increasePercentageBullRunValue) > 100) Then
                MessageBox.Show("The Increase Bullrun value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            ElseIf (Val(topReboundPercentageValue) > 100) Then
                MessageBox.Show("The Top Rebound Bullrun value isn't a percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' This method provide to extract start configuration
    ''' </summary>
    ''' <returns></returns>
    Private Function extractStartConfiguration() As Double
        If activeDateStartValue.Checked Then
            Dim dateValue As New DateTime(dateStartValue.Value.Year, dateStartValue.Value.Month, dateStartValue.Value.Day, timeStartValue.Value.Hour, timeStartValue.Value.Minute, timeStartValue.Value.Second)

            Return CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(dateValue.ToUniversalTime)
        Else
            Return 0
        End If
    End Function

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        Do While (_SetPair + 1000 > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
            Threading.Thread.Sleep(100)
        Loop

        If Not validateInformation() Then Return

        Dim newJob As AreaCommon.Models.Bot.BotConfigurationsModel

        If (currentID.Length = 0) Then
            newJob = New AreaCommon.Models.Bot.BotConfigurationsModel

            newJob.parameters.header.id = Guid.NewGuid.ToString
            newJob.parameters.header.created = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
        Else
            newJob = AreaState.bots(currentID.ToString())
        End If

        newJob.parameters.header.isActive = isActiveValue.Checked

        With newJob.parameters.fundConfiguration
            .pairId = AreaState.Common.getPairID(pairIdValue.Text)
            .plafond = plafondValue.Text
            .unitStep = unitStepValue.Text
        End With

        With newJob.parameters.startConfiguration
            .timeStart = extractStartConfiguration()

            If (minuteExamValue.Text.Trim.Length > 0) Then
                .minuteExam = minuteExamValue.Text
            End If
            If (triggerValue.Text.Trim.Length > 0) Then
                .triggerValue = triggerValue.Text
            End If
        End With

        With newJob.parameters.workConfiguration
            .mode = modeValue.SelectedIndex + 1
            If spreadValue.Text.Trim.Length > 0 Then
                .spread = CDbl(Val(spreadValue.Text))
            End If
        End With

        With newJob.parameters.workConfiguration.buyConfiguration
            If (stepIntervalValue.Text.Trim.Length > 0) Then
                .stepInterval = stepIntervalValue.Text
            End If
            If (dealAcquireValue.Text.Trim.Length > 0) Then
                .dealAcquireOnPercentage = dealAcquireValue.Text
            End If
            If (dealIntervalValue.Text.Trim.Length > 0) Then
                .dealMinimalStep = dealIntervalValue.Text
            End If

            .onlyInDeal = onlyDealAcquireValue.Checked
            .notInBearMarket = notInBearMarketValue.Checked
            .duringBottonBearMarket = duringBottonBearMarketValue.Checked
        End With

        With newJob.parameters.workConfiguration.bearMarket
            If (bottomReboundPercentageValue.Text.Trim.Length > 0) Then
                .bottomReboundPercentage = bottomReboundPercentageValue.Text
            End If
            If (degradePercentageValue.Text.Trim.Length > 0) Then
                .degradePercentage = degradePercentageValue.Text
            End If
            If (observationTimeBearMarketValue.Text.Trim.Length > 0) Then
                .duringMinuteWhenIn = observationTimeBearMarketValue.Text
            End If
            If (maximumExposurePercentageValue.Text.Trim.Length > 0) Then
                .maximumExposurePercentage = maximumExposurePercentageValue.Text
            End If

            .saveFoundActive = saveFoundValue.Checked
        End With

        newJob.data.pair = pair
        newJob.userAccount = AreaState.defaultGenericAccount

        If (currentID.Length = 0) Then
            AreaState.bots.Add(newJob.parameters.header.id, newJob)
        End If

        AreaCommon.Engines.Bots.start()

        Me.Close()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

    Private Sub ModifyBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (currentID.Length > 0) Then
            With AreaState.bots(currentID).parameters
                idValue.Text = .header.id
                createdValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.header.created), True)

                isActiveValue.Checked = .header.isActive

                plafondValue.Text = .fundConfiguration.plafond
                unitStepValue.Text = .fundConfiguration.unitStep

                If (.startConfiguration.timeStart > 0) Then
                    activeDateStartValue.Checked = True

                    dateStartValue.Value = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.startConfiguration.timeStart)

                    timeStartValue.Value = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.startConfiguration.timeStart)
                End If

                minuteExamValue.Text = .startConfiguration.minuteExam
                triggerValue.Text = .startConfiguration.triggerValue

                modeValue.SelectedIndex = .workConfiguration.mode
                spreadValue.Text = .workConfiguration.spread

                stepIntervalValue.Text = .workConfiguration.buyConfiguration.stepInterval
                dealAcquireValue.Text = .workConfiguration.buyConfiguration.dealAcquireOnPercentage
                dealIntervalValue.Text = .workConfiguration.buyConfiguration.dealMinimalStep
                onlyDealAcquireValue.Checked = .workConfiguration.buyConfiguration.onlyInDeal
                notInBearMarketValue.Checked = .workConfiguration.buyConfiguration.notInBearMarket
                duringBottonBearMarketValue.Checked = .workConfiguration.buyConfiguration.duringBottonBearMarket

                saveFoundValue.Checked = .workConfiguration.bearMarket.saveFoundActive
                observationTimeBearMarketValue.Text = .workConfiguration.bearMarket.duringMinuteWhenIn
                degradePercentageValue.Text = .workConfiguration.bearMarket.degradePercentage
                bottomReboundPercentageValue.Text = .workConfiguration.bearMarket.bottomReboundPercentage
                maximumExposurePercentageValue.Text = .workConfiguration.bearMarket.maximumExposurePercentage

                exploreBullrun.Text = .workConfiguration.bullRunMarket.exploreBullRun
                halvingMinuteWhenInValue.Text = .workConfiguration.bullRunMarket.halvingMinuteWhenIn
                observationTimeValue.Text = .workConfiguration.bullRunMarket.duringMinuteWhenIn
                increasePercentageBullRunValue.Text = .workConfiguration.bullRunMarket.increasePercentage
                topReboundPercentageValue.Text = .workConfiguration.bullRunMarket.topReboundPercentage

                pairIdLabel.Enabled = False
                pairIdValue.Enabled = False
            End With
        End If
    End Sub

    Private Sub defaultButton_Click(sender As Object, e As EventArgs) Handles defaultButton.Click
        isActiveValue.Checked = True

        pairIdValue.Text = "KRL-USDT"
        plafondValue.Text = "100"
        unitStepValue.Text = "1"

        minuteExamValue.Text = "6"

        modeValue.SelectedIndex = 0
        spreadValue.Text = "5"
    End Sub

    Private Sub activeDateStartValue_CheckedChanged(sender As Object, e As EventArgs) Handles activeDateStartValue.CheckedChanged

        dateStartLabel.Enabled = activeDateStartValue.Checked
        dateStartValue.Enabled = activeDateStartValue.Checked
        timeStartValue.Enabled = activeDateStartValue.Checked
        gmtLabel.Enabled = activeDateStartValue.Checked

    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged

    End Sub

    ''' <summary>
    ''' This method provide to check the pair exist
    ''' </summary>
    Private Async Sub checkExist()
        _ThreadInExecution = True

        Try
            _PairExist = Await AreaCommon.Engines.Pairs.testPair(pairIdValue.Text)
        Catch ex As Exception
            _PairExist = False
        End Try

        _ThreadInExecution = False
    End Sub

    Private Sub pairIdValue_TextChanged(sender As Object, e As EventArgs) Handles pairIdValue.TextChanged
        Do While _ThreadInExecution
            Threading.Thread.Sleep(100)
        Loop

        Try
            Task.Run(Sub() checkExist()).Start()
        Catch ex As Exception
        End Try

        _SetPair = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
    End Sub

    Private Sub saveFoundValue_CheckedChanged(sender As Object, e As EventArgs) Handles saveFoundValue.CheckedChanged

        observationTimeLabel.Enabled = saveFoundValue.Checked
        observationTimeBearMarketValue.Enabled = saveFoundValue.Checked
        minuteSymbolObservationLabel.Enabled = saveFoundValue.Checked
        degradePercentageLabel.Enabled = saveFoundValue.Checked
        degradePercentageValue.Enabled = saveFoundValue.Checked
        percentageSymbolLabel.Enabled = saveFoundValue.Checked
        bottomReboundPercentageLabel.Enabled = saveFoundValue.Checked
        bottomReboundPercentageValue.Enabled = saveFoundValue.Checked
        percentageSymbol2Label.Enabled = saveFoundValue.Checked
        maximumExposurePercentageLabel.Enabled = saveFoundValue.Checked
        maximumExposurePercentageValue.Enabled = saveFoundValue.Checked
        percentageSymbol3Label.Enabled = saveFoundValue.Checked

        If Not saveFoundValue.Checked Then
            observationTimeBearMarketValue.Text = ""
            degradePercentageValue.Text = ""
            bottomReboundPercentageValue.Text = ""
            maximumExposurePercentageValue.Text = ""
        End If

    End Sub

    Private Sub exploreBullrun_CheckedChanged(sender As Object, e As EventArgs) Handles exploreBullrun.CheckedChanged

        halvingMinuteWhenInLabel.Enabled = exploreBullrun.Checked
        halvingMinuteWhenInValue.Enabled = exploreBullrun.Checked
        minute1Label.Enabled = exploreBullrun.Checked
        halvingPercentageLabel.Enabled = exploreBullrun.Checked
        halvingPercentageValue.Enabled = exploreBullrun.Checked
        percentageSymbol4Label.Enabled = exploreBullrun.Checked
        observationTimeBullRunLabel.Enabled = exploreBullrun.Checked
        observationTimeValue.Enabled = exploreBullrun.Checked
        minute2Label.Enabled = exploreBullrun.Checked
        increasePercentageLabel.Enabled = exploreBullrun.Checked
        increasePercentageBullRunValue.Enabled = exploreBullrun.Checked
        percentageSymbol5Label.Enabled = exploreBullrun.Checked
        topReboundPercentageLabel.Enabled = exploreBullrun.Checked
        topReboundPercentageValue.Enabled = exploreBullrun.Checked
        percentageSymbol6Label.Enabled = exploreBullrun.Checked

        If Not exploreBullrun.Checked Then
            halvingMinuteWhenInValue.Text = ""
            halvingPercentageValue.Text = ""
            observationTimeValue.Text = ""
            increasePercentageBullRunValue.Text = ""
            topReboundPercentageValue.Text = ""
        End If

    End Sub

End Class