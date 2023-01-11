Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Journal

    Public Class BlockCounterModel

        Public Class TransactionModel
            Public Property buy As Boolean = False
            Public Property orderNumber As String = ""
            Public Property dateCompletate As Double = 0
            Public Property pairID As String = ""
            Public Property amount As Double = 0
            Public Property value As Double = 0
            Public Property daily As Boolean = False
        End Class

        Private Property _ExtraBuy As Double = 0
        Private Property _ExtraSell As Double = 0
        Private Property _DailyBuy As Double = 0
        Private Property _DailySell As Double = 0

        Private Property _SellNumber As Integer = 0
        Private Property _BuyNumber As Integer = 0

        Public Property timeStart As Double = 0
        Public Property numPage As Integer = 0

        Public Property initialFundFree As Double = 0
        Public Property initialFundManage As Double = 0

        Public Property currentFund As Double = 0
        Public Property freeFund As Double = 0
        Public Property lockedFund As Double = 0

        Public Property target As Double = 0

        Public Property feePayed As Double = 0
        Public Property volumes As Double = 0

        Public Property increase As Double = 0

        Public Property totalPower As Double = 0

        Public Property transactions As New List(Of TransactionModel)

        Public Function addNewTransaction() As TransactionModel
            Dim newItem As New TransactionModel

            transactions.Add(newItem)

            Return newItem
        End Function

        Public ReadOnly Property earn As Double
            Get
                Return (currentFund + freeFund) - (initialFundFree + initialFundManage)
            End Get
        End Property

        Public ReadOnly Property apy As Double
            Get
                If ((earn = 0) Or ((initialFundFree + initialFundManage) = 0)) Then
                    Return "0"
                Else
                    Return (earn / (initialFundFree + initialFundManage) * 100).ToString("#,##0.00")
                End If
            End Get
        End Property

        Public ReadOnly Property averageApy As Double
            Get
                If (numPage = 0) Then
                    Return 0
                Else
                    Return AreaState.journal.apy / numPage
                End If
            End Get
        End Property


        Public ReadOnly Property power As Double
            Get
                'Return currentFund + freeFund + increase
                Return initialFundFree + initialFundManage + increase
            End Get
        End Property

        Public ReadOnly Property increasePerc As Double
            Get
                If (increase = 0) Or (initialFundFree + initialFundManage = 0) Then
                    Return 0
                Else
                    Return (increase / (initialFundFree + initialFundManage) * 100)
                End If
            End Get
        End Property

        Public ReadOnly Property averageIncrease As Double
            Get
                If (increasePerc = 0) Then
                    Return 0
                Else
                    Return (increasePerc / numPage)
                End If
            End Get
        End Property


        Public ReadOnly Property sellNumber As Integer
            Get
                Return _SellNumber
            End Get
        End Property
        Public ReadOnly Property buyNumber As Integer
            Get
                Return _BuyNumber
            End Get
        End Property

        Public ReadOnly Property extraBuy As Double
            Get
                Return _ExtraBuy
            End Get
        End Property

        Public ReadOnly Property extraSell As Double
            Get
                Return _ExtraSell
            End Get
        End Property

        Public ReadOnly Property dailyBuy() As Double
            Get
                Return _DailyBuy
            End Get
        End Property

        Public ReadOnly Property dailySell() As Double
            Get
                Return _DailySell
            End Get
        End Property


        Public Sub refresh()
            _BuyNumber = 0 : _SellNumber = 0
            _ExtraBuy = 0 : _ExtraSell = 0
            _DailyBuy = 0 : _DailySell = 0

            For Each transaction In transactions
                If transaction.buy Then
                    _BuyNumber += 1

                    If transaction.daily Then
                        _DailyBuy += transaction.value
                    Else
                        _ExtraBuy += transaction.value
                    End If
                Else
                    _SellNumber += 1

                    If transaction.daily Then
                        _DailySell += transaction.value
                    Else
                        _ExtraSell += transaction.value
                    End If
                End If
            Next

        End Sub

    End Class

    Public Class HistoryCounterModel

        Public Property startBlock As Double = 0

        Public Property initialFund As Double = 0

        Public Property feePayed As Double = 0
        Public Property volumes As Double = 0

        Public Property earn As Double = 0
        Public Property increase As Double = 0

    End Class

    Public Class CumulativeModel

        Public Property currentBlockCounters As New BlockCounterModel
        Public Property history As New HistoryCounterModel

        Public Property numPages As Integer = 0

        Public Property currentFund As Double = 0
        Public Property freeFund As Double = 0
        Public Property lockedFund As Double = 0

        Public Property futureGain As Double = 0

        Public Property lastUpdate As Double = 0

        Public Property alert As String = ""


        Public ReadOnly Property earn As Double
            Get
                Return (currentFund + freeFund) - history.initialFund
            End Get
        End Property

        Public ReadOnly Property apy As String
            Get
                If ((earn = 0) Or (history.initialFund = 0)) Then
                    Return "0"
                Else
                    Return (earn / history.initialFund * 100).ToString("#,##0.00")
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


        Public ReadOnly Property totalIncrease() As Double
            Get
                Return history.increase + currentBlockCounters.increase
            End Get
        End Property

        Public ReadOnly Property increasePercentual As Double
            Get
                If (totalIncrease = 0) Or (history.initialFund = 0) Then
                    Return 0
                Else
                    Return totalIncrease / history.initialFund * 100
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
                'Dim value As Double = currentFund + freeFund + totalIncrease
                Dim value As Double = history.initialFund + totalIncrease

                currentBlockCounters.totalPower = value

                Return history.initialFund + totalIncrease
            End Get
        End Property

    End Class

End Namespace
