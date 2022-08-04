Option Compare Text
Option Explicit On


Public Class DataBot

    Public Property idReferement As String = ""

    Private Sub mainTimer_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick
        Dim repeatProcedure As Boolean = True

        Do While repeatProcedure
            repeatProcedure = False

            Try
                If AreaState.bots.ContainsKey(idReferement) Then

                    With AreaState.bots(idReferement)
                        idValue.Text = idReferement
                        pairValue.Text = .data.pair
                        bootstrapInitialValue.Checked = .data.bootStrapInitial
                        bootstrapCompleteValue.Checked = .data.bootStrapComplete

                        If (.data.examTimeLimit > 0) Then
                            examLimitValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.data.examTimeLimit), True)
                        Else
                            examLimitValue.Text = ""
                        End If

                        If (.data.timeStart > 0) Then
                            timeStartValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.data.timeStart), True)
                        Else
                            timeStartValue.Text = ""
                        End If

                        plafondValue.Text = .data.usedPlafond & " " & .data.pair.Split("-")(1)
                        earnValue.Text = .data.earn & " " & .data.pair.Split("-")(1)

                        If (.data.lastBuyTime > 0) Then
                            lastBuyTimeValue.Text = CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(.data.lastBuyTime), True)
                        Else
                            lastBuyTimeValue.Text = ""
                        End If

                        lastBuyValue.Text = .data.lastBuyValue & " " & .data.pair.Split("-")(1)
                    End With

                End If
            Catch ex As Exception
                repeatProcedure = True
            End Try
        Loop

    End Sub

    Private Sub DataBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class