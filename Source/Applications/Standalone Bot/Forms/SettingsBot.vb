Option Compare Text
Option Explicit On



Public Class SettingsBot

    Public Property currentID As String = ""


    Private Property _PairExist As Boolean = False
    Private Property _ThreadInExecution As Boolean = False
    Private Property _SetPair As Double = 0



    Public Property defaultMode As Boolean = False

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
            ElseIf (Val(minuteExamValue.text) > 60) Then
                MessageBox.Show("The Minute exam is too expansive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

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
        If Not _ThreadInExecution Then
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

    Private Sub confirmData()
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

        With newJob.parameters.configuration
            .pairId = AreaState.Common.getPairID(pairIdValue.Text)
            .pairKey = pairIdValue.Text
            .plafond = plafondValue.Text
            .unitStep = unitStepValue.Text
            .mode = modeValue.SelectedIndex + 1
            If spreadValue.Text.Trim.Length > 0 Then
                .spread = CDbl(Val(spreadValue.Text.Replace(",", ".")))
            End If
        End With

        With newJob.parameters.startStopConfiguration
            .timeStart = extractStartConfiguration()

            If (triggerValue.Text.Trim.Length > 0) Then
                .activateTriggerValue = triggerValue.Text
            End If
        End With

        With newJob.parameters.workConfiguration.buyConfiguration
            If (minuteExamValue.Text.Trim.Length > 0) Then
                .minuteExam = minuteExamValue.Text
            End If

            If (stepIntervalValue.Text.Trim.Length > 0) Then
                .stepInterval = stepIntervalValue.Text
            End If
            If (dealAcquireValue.Text.Trim.Length > 0) Then
                .dealAcquireOnPercentage = CDbl(Val(dealAcquireValue.Text.Replace(",", ".")))
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

        If (currentID.Length = 0) Then
            AreaEngine.IO.updateBotSetting(newJob)
        End If

        AreaCommon.Engines.Bots.start()

        Me.Close()
    End Sub

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If defaultMode Then
            saveDefaultData()

            Me.Close()
        Else
            confirmData()
        End If
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

                plafondValue.Text = .configuration.plafond
                unitStepValue.Text = .configuration.unitStep

                If (.startStopConfiguration.timeStart > 0) Then
                    activeDateStartValue.Checked = True

                    dateStartValue.Value = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.startStopConfiguration.timeStart)

                    timeStartValue.Value = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.startStopConfiguration.timeStart)
                End If

                minuteExamValue.Text = .workConfiguration.buyConfiguration.minuteExam
                triggerValue.Text = .startStopConfiguration.activateTriggerValue

                modeValue.SelectedIndex = .configuration.mode - 1
                spreadValue.Text = .configuration.spread

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
        ElseIf defaultMode Then
            getDefaultData()

            Me.Text = "Default settings bot"

            defaultButton.Visible = False
            setAsDefault.Visible = False
        End If
    End Sub

    Private Sub getDefaultData()
        Dim prop = AreaState.Common.defaultSettings.Split("&")
        Dim commands

        For Each singleCommand In prop
            commands = singleCommand.Split("=")

            Select Case commands(0).ToString.ToLower()
                Case "isActive".ToLower() : isActiveValue.Checked = (commands(1).ToString.CompareTo("1") = 0)
                Case "pairId".ToLower() : pairIdValue.Text = commands(1).ToString()
                Case "plafond".ToLower() : plafondValue.Text = commands(1).ToString()
                Case "unitStep".ToLower() : unitStepValue.Text = commands(1).ToString()
                Case "minuteExam".ToLower() : minuteExamValue.Text = commands(1).ToString()
                Case "mode".ToLower() : modeValue.SelectedIndex = Val(commands(1).ToString())
                Case "spread".ToLower() : spreadValue.Text = commands(1).ToString()
                Case "stepInterval".ToLower() : stepIntervalValue.Text = commands(1).ToString()
                Case "dealAcquire".ToLower() : dealAcquireValue.Text = commands(1).ToString()
                Case "dealInterval".ToLower() : dealIntervalValue.Text = commands(1).ToString()
                Case "onlyInDeal".ToLower() : onlyDealAcquireValue.Checked = (commands(1).ToString() = "1")
                Case "notInBearMarketValue".ToLower() : notInBearMarketValue.Checked = (commands(1).ToString() = "1")
                Case "duringBottonBearMarketValue".ToLower() : duringBottonBearMarketValue.Checked = (commands(1).ToString() = "1")
            End Select
        Next
    End Sub

    Private Sub defaultButton_Click(sender As Object, e As EventArgs) Handles defaultButton.Click
        getDefaultData()
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

    Private Sub saveDefaultData()
        Dim temp As String = "isActive=%isActive%&pairId=%pairId%&plafond=%plafond%&unitStep=%unitStep%&minuteExam=%minuteExam%&mode=%mode%&spread=%spread%&stepInterval=%stepInterval%&dealAcquire=%dealAcquire%&dealInterval=%dealInterval%&onlyInDeal=%onlyInDeal%&notInBearMarket=%notInBearMarket%&duringBottomBearMarket=%duringBottomBearMarket%"

        If isActiveValue.Checked Then
            temp = temp.Replace("%isActive%", "1")
        Else
            temp = temp.Replace("%isActive%", "0")
        End If

        temp = temp.Replace("%pairId%", pairIdValue.Text)
        temp = temp.Replace("%plafond%", plafondValue.Text)
        temp = temp.Replace("%unitStep%", unitStepValue.Text)
        temp = temp.Replace("%minuteExam%", minuteExamValue.Text)
        temp = temp.Replace("%mode%", modeValue.SelectedIndex.ToString())
        temp = temp.Replace("%spread%", spreadValue.Text)
        temp = temp.Replace("%stepInterval%", stepIntervalValue.Text)
        temp = temp.Replace("%dealAcquire%", dealAcquireValue.Text)
        temp = temp.Replace("%dealInterval%", dealIntervalValue.Text)

        If onlyDealAcquireValue.Checked Then
            temp = temp.Replace("%onlyInDeal%", "1")
        Else
            temp = temp.Replace("%onlyInDeal%", "0")
        End If

        If notInBearMarketValue.Checked Then
            temp = temp.Replace("%notInBearMarketValue%", "1")
        Else
            temp = temp.Replace("%notInBearMarketValue%", "0")
        End If

        If duringBottonBearMarketValue.Checked Then
            temp = temp.Replace("%duringBottonBearMarketValue%", "1")
        Else
            temp = temp.Replace("%duringBottonBearMarketValue%", "0")
        End If

        AreaState.Common.defaultSettings = temp
    End Sub

    Private Sub setAsDefault_Click(sender As Object, e As EventArgs) Handles setAsDefault.Click
        saveDefaultData()

        MessageBox.Show("Default updated")
    End Sub

    Public Sub createNewBot(ByVal pairKey As String)
        getDefaultData()

        pairIdValue.Text = pairKey

        confirmData()
    End Sub

End Class