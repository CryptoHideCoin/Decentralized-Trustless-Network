Option Compare Text
Option Explicit On



Public Class SettingsBot

    Public Property insertMode As Boolean = True
    Public Property DATA As New AreaCommon.Models.Bot.BotParametersModel


    Private Property _PairExist As Boolean = False
    Private Property _ThreadInExecution As Boolean = False





    Public Property pair() As String
        Get
            Return pairIdValue.Text
        End Get
        Set(value As String)
            pairIdValue.Text = value
        End Set
    End Property

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

        Return True
    End Function

    ''' <summary>
    ''' This method provide to extract start configuration
    ''' </summary>
    ''' <returns></returns>
    Private Function extractStartConfiguration() As Double
        If activeDateStartValue.Checked Then
            Dim dateValue As New DateTime(dateStartValue.Value.Year, dateStartValue.Value.Month, dateStartValue.Value.Day, timeStartValue.Value.Hour, timeStartValue.Value.Minute, timeStartValue.Value.Second)

            Return CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(dateValue)
        Else
            Return 0
        End If
    End Function

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        If Not validateInformation() Then Return

        If insertMode Then
            DATA.header.id = Guid.NewGuid.ToString
            DATA.header.created = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            DATA.header.isActive = isActiveValue.Checked
        End If

        With DATA.fundConfiguration
            .pairId = AreaState.Common.getPairID(pairIdValue.Text)
            .plafond = plafondValue.Text
            .unitStep = unitStepValue.Text
        End With

        With DATA.startConfiguration
            .timeStart = extractStartConfiguration()

            If (minuteExamValue.Text.Trim.Length > 0) Then
                .minuteExam = minuteExamValue.Text
            End If
            If (triggerValue.Text.Trim.Length > 0) Then
                .triggerValue = triggerValue.Text
            End If
        End With

        With DATA.workConfiguration
            .mode = modeValue.SelectedIndex
            If spreadValue.Text.Trim.Length > 0 Then
                .spread = CDbl(Val(spreadValue.Text))
            End If
        End With

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ModifyBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not insertMode Then
            idValue.Text = DATA.header.id
            createdValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(DATA.header.created), True)

            isActiveValue.Checked = DATA.header.isActive

            plafondValue.Text = DATA.fundConfiguration.plafond
            unitStepValue.Text = DATA.fundConfiguration.unitStep

            If (DATA.startConfiguration.timeStart > 0) Then
                activeDateStartValue.Checked = True

                dateStartValue.Value = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(DATA.startConfiguration.timeStart)

                timeStartValue.Value = CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(DATA.startConfiguration.timeStart)
            End If

            minuteExamValue.Text = DATA.startConfiguration.minuteExam
            triggerValue.Text = DATA.startConfiguration.triggerValue

            modeValue.SelectedIndex = DATA.workConfiguration.mode
            spreadValue.Text = DATA.workConfiguration.spread
        End If

        tabMain.TabPages.Remove(acquisitionValue)
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
            System.Threading.Thread.Sleep(100)
        Loop

        Try
            Task.Run(Sub() checkExist()).Start()
        Catch ex As Exception
        End Try
    End Sub

End Class