Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Pair

    ''' <summary>
    ''' This class provide to tick information
    ''' </summary>
    Public Class TickInformation

        Public Enum tickPositionEnumeration
            increase
            decrease
            same
        End Enum

        Public Property time As Double = 0
        Public Property value As Double = 0
        Public Property position As tickPositionEnumeration = tickPositionEnumeration.same

    End Class

    ''' <summary>
    ''' This class contain all information of a trand of a pair
    ''' </summary>
    Public Class TrendData

        Public Enum periodTypeEnumeration
            lastHour
            lastDay
            lastWeek
            lastMonth
            lastYear
        End Enum

        Public Enum StatusValueEnumeration
            undefined
            increase
            inHalving
            inBullRun
            inTop
            decrease
            inBearMarket
            deep
        End Enum


        Public Property firstItem As Double = 0
        Public Property periodType As periodTypeEnumeration = periodTypeEnumeration.lastHour
        Public Property trend As StatusValueEnumeration = StatusValueEnumeration.undefined
        Public Property nextSummary As Double = 0
        Public Property min As Double = 0
        Public Property max As Double = 0
        Public Property average As Double = 0
        Public Property relativeAverage As Double = 0
        Public Property ticks As New List(Of TickInformation)

        Public ReadOnly Property firstValue As Double
            Get
                Return ticks.First.value
            End Get
        End Property

        Public ReadOnly Property lastValue As Double
            Get
                Return ticks.Last.value
            End Get
        End Property

        Public ReadOnly Property spread() As Double
            Get
                Return (ticks.Last.value - ticks.First.value) / ticks.First.value * 100
            End Get
        End Property

        Public ReadOnly Property spreadValue() As Double
            Get
                Return (ticks.Last.value - ticks.First.value)
            End Get
        End Property

    End Class

    ''' <summary>
    ''' This class contain all information of a pair
    ''' </summary>
    Public Class PairInformation

        Public Property id As Integer = 0
        Public Property key As String = ""
        Public Property currentValue As Double = 0
        Public Property currentRelativeAverageValue As Double = 0

        Public Property lastUpdateTick As Double = 0

        Public Property marketData As New Dictionary(Of TrendData.periodTypeEnumeration, TrendData)



        Private Function maxItem(ByVal newValue As TrendData.periodTypeEnumeration) As Integer
            Select Case newValue
                Case TrendData.periodTypeEnumeration.lastHour : Return 60
                Case TrendData.periodTypeEnumeration.lastDay : Return 24
                Case TrendData.periodTypeEnumeration.lastWeek : Return 7
                Case TrendData.periodTypeEnumeration.lastMonth : Return 30
                Case Else : Return 365
            End Select
        End Function

        Private Sub determinateNextSummary(ByVal item As TrendData)
            Select Case item.periodType
                Case TrendData.periodTypeEnumeration.lastHour
                    item.nextSummary = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (CDec(60) * 60 * 1000)
                Case TrendData.periodTypeEnumeration.lastDay
                    item.nextSummary = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (CDec(24) * 60 * 60 * 1000)
                Case TrendData.periodTypeEnumeration.lastWeek
                    item.nextSummary = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (CDec(7) * 24 * 60 * 60 * 1000)
                Case TrendData.periodTypeEnumeration.lastMonth
                    item.nextSummary = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (CDec(30) * 24 * 60 * 60 * 1000)
                Case TrendData.periodTypeEnumeration.lastYear
                    item.nextSummary = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + (CDec(365) * 30 * 24 * 60 * 60 * 1000)
            End Select
        End Sub

        Private Sub processNextMarketData(ByVal item As TrendData)
            Dim newTick As New TickInformation

            newTick.time = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            newTick.value = item.average

            If (item.periodType = TrendData.periodTypeEnumeration.lastHour) Then
                addNewItem(newTick, TrendData.periodTypeEnumeration.lastDay)
            Else
                addNewItem(newTick, TrendData.periodTypeEnumeration.lastWeek)
                addNewItem(newTick, TrendData.periodTypeEnumeration.lastMonth)
                addNewItem(newTick, TrendData.periodTypeEnumeration.lastYear)
            End If
        End Sub


        Private Sub summary(ByRef newTrendData As TrendData)
            Try
                If (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() > newTrendData.nextSummary) Then
                    determinateNextSummary(newTrendData)

                    processNextMarketData(newTrendData)
                End If

                If (newTrendData.ticks.Count > maxItem(newTrendData.periodType)) Then
                    newTrendData.ticks.RemoveAt(0)
                End If

                newTrendData.average = 0 : newTrendData.max = 0
                newTrendData.min = 0 : newTrendData.relativeAverage = 0
                newTrendData.trend = TrendData.StatusValueEnumeration.undefined

                For Each singleTick In newTrendData.ticks
                    newTrendData.average = newTrendData.average + singleTick.value

                    If (newTrendData.max < singleTick.value) Then
                        newTrendData.max = singleTick.value
                    End If
                    If (newTrendData.min > singleTick.value) Or (newTrendData.min = 0) Then
                        newTrendData.min = singleTick.value
                    End If

                    If (newTrendData.relativeAverage = 0) Then
                        newTrendData.relativeAverage = singleTick.value
                    Else
                        newTrendData.relativeAverage = (newTrendData.relativeAverage + singleTick.value) / 2
                    End If
                Next

                newTrendData.average = newTrendData.average / newTrendData.ticks.Count

                If (currentValue > newTrendData.relativeAverage) Then
                    newTrendData.trend = TrendData.StatusValueEnumeration.increase
                ElseIf (currentValue < newTrendData.relativeAverage) Then
                    newTrendData.trend = TrendData.StatusValueEnumeration.decrease
                End If
            Catch ex As Exception
            End Try
        End Sub


        Public Sub addNewItem(ByRef tick As TickInformation, Optional ByVal periodType As TrendData.periodTypeEnumeration = TrendData.periodTypeEnumeration.lastHour)
            Try
                If marketData.ContainsKey(periodType) Then
                    marketData.Values(periodType).ticks.Add(tick)

                    summary(marketData.Values(periodType))
                Else
                    Dim newTrendData As New TrendData

                    newTrendData.periodType = periodType

                    determinateNextSummary(newTrendData)

                    newTrendData.ticks.Add(tick)

                    marketData.Add(periodType, newTrendData)

                    summary(newTrendData)
                End If
            Catch ex As Exception
            End Try
        End Sub

    End Class

End Namespace