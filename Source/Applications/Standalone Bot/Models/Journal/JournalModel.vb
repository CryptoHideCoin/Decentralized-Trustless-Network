Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Journal

    Public Class DayCounterModel

        Public Class TransactionModel
            Public Property buy As Boolean = False
            Public Property orderNumber As String = ""
            Public Property dateCompletate As Double = 0
            Public Property pairID As String = ""
            Public Property amount As Double = 0
            Public Property value As Double = 0
            Public Property daily As Boolean = False
        End Class

        Public Property day As Double = 0
        Public Property numPage As Integer = 0

        Public Property initialFundFree As Double = 0
        Public Property initialFundManage As Double = 0

        Public Property currentFund As Double = 0
        Public Property freeFund As Double = 0
        Public Property lockedFund As Double = 0

        Public Property target As Double = 0

        Public Property extraBuy As Double = 0
        Public Property dailyBuy As Double = 0

        Public Property extraSell As Double = 0
        Public Property dailySell As Double = 0

        Public Property feePayed As Double = 0
        Public Property volumes As Double = 0

        Public Property increase As Double = 0
        Public Property earn As Double = 0

        Public Property totalPower As Double = 0


        Public ReadOnly Property power As Double
            Get
                Return currentFund + freeFund + increase
            End Get
        End Property

        Public ReadOnly Property apy As Double
            Get
                If (earn = 0) Or (currentFund = 0) Then
                    Return 0
                Else
                    Return (earn / currentFund * 100)
                End If
            End Get
        End Property

        Public ReadOnly Property increasePerc As Double
            Get
                If (increase = 0) Or (currentFund = 0) Then
                    Return 0
                Else
                    Return (increase / currentFund * 100)
                End If
            End Get
        End Property

        Public ReadOnly Property averageApy As Double
            Get
                If (apy = 0) Then
                    Return 0
                Else
                    Return (apy / numPage)
                End If
            End Get
        End Property

        Public ReadOnly Property averageIncrease As Double
            Get
                If increase = 0 Then
                    Return 0
                Else
                    Return (increase / numPage)
                End If
            End Get
        End Property

        Public ReadOnly Property sellNumber As Integer
            Get
                Dim total As Integer = 0

                For Each transaction In transactions
                    If Not transaction.buy Then
                        total += 1
                    End If
                Next

                Return total
            End Get
        End Property
        Public ReadOnly Property buyNumber As Integer
            Get
                Dim total As Integer = 0

                For Each transaction In transactions
                    If transaction.buy Then
                        total += 1
                    End If
                Next

                Return total
            End Get
        End Property

        Public Property transactions As New List(Of TransactionModel)

        Public Function addNewTransaction() As TransactionModel
            Dim newItem As New TransactionModel

            transactions.Add(newItem)

            Return newItem
        End Function

    End Class

    Public Class CumulativeModel

        Public Property initialDay As Double = 0
        Public Property lastUpdate As Double = 0

        Public Property initialFund As Double = 0

        Public Property currentFund As Double = 0
        Public Property futureGain As Double = 0

        Public Property freeFund As Double = 0
        Public Property lockedFund As Double = 0

        Public Property totalFee As Double = 0
        Public Property totalVolume As Double = 0
        Public Property numPages As Integer = 0

        Public Property totalEarn As Double = 0

        Public ReadOnly Property apy As String
            Get
                If ((totalEarn = 0) And (currentDayCounters.earn = 0)) Or (currentDayCounters.initialFundFree + currentDayCounters.initialFundManage = 0) Then
                    Return "0"
                Else
                    Return ((AreaState.journal.totalEarn + AreaState.journal.currentDayCounters.earn) / (AreaState.journal.currentDayCounters.initialFundFree + AreaState.journal.currentDayCounters.initialFundManage) * 100).ToString("#,##0.00")
                End If
            End Get
        End Property

        Public ReadOnly Property averageApy As Double
            Get
                If (numPages = 0) Then
                    Return 0
                Else
                    Return AreaState.journal.apy / numPages
                End If
            End Get
        End Property

        Public Property totalIncrease As Double = 0

        Public ReadOnly Property increasePercentual As Double
            Get
                If (totalIncrease = 0) Or (initialFund = 0) Then
                    Return 0
                Else
                    Return totalIncrease / initialFund * 100
                End If
            End Get
        End Property

        Public ReadOnly Property averageIncrease As Double
            Get
                If (increasePercentual = 0) Or (numPages = 0) Then
                    Return 0
                Else
                    Return increasePercentual / numPages
                End If
            End Get
        End Property

        Public ReadOnly Property totalPower As Double
            Get
                Dim value As Double = currentFund + freeFund + totalIncrease

                currentDayCounters.totalPower = value

                Return value
            End Get
        End Property

        Public Property currentDayCounters As New DayCounterModel

        Public Property alert As String = ""
    End Class

End Namespace