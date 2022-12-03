﻿Option Compare Text
Option Explicit On



Namespace AreaCommon.Engines.Bots

    Public Class BlockStartEngine

        Private Const _TimeToSell = 5 * 60 * 10


        Public Function updateJournalCounter() As Boolean
            AreaState.journal.currentFund = 0

            If AreaState.accounts.ContainsKey("USDT".ToLower()) Then
                AreaState.journal.freeFund = AreaState.accounts("USDT".ToLower()).valueUSDT
            Else
                AreaState.journal.freeFund = 0
            End If

            AreaState.journal.futureGain = 0

            For Each product In AreaState.products.items
                If product.activity.inUse Then
                    AreaState.journal.currentFund += product.activity.totalAmount * product.value.current
                    AreaState.journal.futureGain += product.activity.target
                End If
            Next

            AreaState.journal.currentBlockCounters.currentFund = AreaState.journal.currentFund
            AreaState.journal.currentBlockCounters.freeFund = AreaState.journal.freeFund
            AreaState.journal.currentBlockCounters.target = AreaState.journal.futureGain

            If (AreaState.journal.currentFund = 0) Then
                AreaState.journal.currentBlockCounters.earn = 0
            Else
                AreaState.journal.currentBlockCounters.earn = (AreaState.journal.currentBlockCounters.currentFund + AreaState.journal.currentBlockCounters.freeFund) - (AreaState.journal.currentBlockCounters.initialFundFree + AreaState.journal.currentBlockCounters.initialFundManage)
            End If

            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return True
        End Function

        Private Function openNewJournal() As Boolean
            If (AreaState.journal.currentBlockCounters.timeStart > 0) Then
                updateJournalCounter()

                AreaState.journal.totalEarn += AreaState.journal.currentBlockCounters.earn

                AreaCommon.IO.saveCurrentCounterBlock()
            End If

            AreaState.journal.numPages += 1
            AreaState.journal.currentBlockCounters.numPage = AreaState.journal.numPages

            AreaState.journal.currentBlockCounters = New AreaCommon.Models.Journal.BlockCounterModel

            AreaState.journal.currentBlockCounters.timeStart = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime
            AreaState.journal.currentBlockCounters.initialFundFree = AreaState.accounts("USDT".ToLower()).valueUSDT
            AreaState.journal.currentBlockCounters.initialFundManage = 0

            For Each product In AreaState.products.items
                If product.activity.inUse Then
                    AreaState.journal.currentBlockCounters.initialFundManage += CDec(product.activity.totalAmount) * product.value.current
                End If
            Next

            AreaState.journal.lastUpdate = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return True
        End Function


        Public Function [run]() As Boolean
            Dim proceed As Boolean = True
            Dim startTimer As Double

            If proceed Then
                Threading.Thread.Sleep(50)

                proceed = openNewJournal()
            End If
            If proceed Then
                Threading.Thread.Sleep(50)

                proceed = changeInBlockSell()
            End If
            If proceed Then
                startTimer = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                Do While ((startTimer + _TimeToSell) > CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime())
                    Threading.Thread.Sleep(50)
                Loop
            End If

            Return proceed
        End Function

    End Class

End Namespace