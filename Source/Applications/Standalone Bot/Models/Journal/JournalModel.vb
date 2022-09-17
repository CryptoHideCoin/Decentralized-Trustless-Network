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

        Public Property initialFundFree As Double = 0
        Public Property initialFundManage As Double = 0

        Public Property extraBuy As Double = 0
        Public Property dailyBuy As Double = 0

        Public Property extraSell As Double = 0
        Public Property dailySell As Double = 0

        Public Property feePayed As Double = 0
        Public Property volumes As Double = 0
        Public Property earn As Double = 0

        Public Property sellNumber As Integer = 0
        Public Property buyNumber As Integer = 0

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

        Public Property increaseValue As Double = 0
        Public Property totalFee As Double = 0
        Public Property totalVolume As Double = 0
        Public Property totalEarn As Double = 0

        Public Property currentDayCounters As New DayCounterModel

    End Class

End Namespace