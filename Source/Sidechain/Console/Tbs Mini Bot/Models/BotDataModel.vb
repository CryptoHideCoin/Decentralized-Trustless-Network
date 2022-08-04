Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Bots

    ''' <summary>
    ''' This class contain the bot parameter
    ''' </summary>
    Public Class BotDataMode

        Public Enum StatusValueEnumeration
            undefined
            increase
            inHalving
            inBullRun
            inTop
            decrease
            inBearMarket
            inBottom
        End Enum

        Public Property pair As String = ""
        Public Property bootStrapComplete As Boolean = False

        Public Property timeStart As Double = 0
        Public Property orderStatedSended As Boolean = False
        Public Property orderFundFill As Boolean = False

        Public Property lastAcquire As Double = 0
        Public Property lastValueAcquire As Double = 0

        Public Property currentValue As Double = 0
        Public Property relativeAverageValue As Double = 0
        Public Property marketTrend As StatusValueEnumeration = StatusValueEnumeration.undefined

        Public Property lastRecentValue As New List(Of Double)

        Public Property halvingDataValue As New List(Of Double)
        Public Property bullRunDataValue As New List(Of Double)
        Public Property bearMarketDataValue As New List(Of Double)


    End Class

End Namespace
