Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Bot

    ''' <summary>
    ''' This class contain all data relative an order bot
    ''' </summary>
    Public Class BotOrderModel

        Public Enum OrderStateEnumeration
            undefined
            sented
            placed
            filled
        End Enum

        Public Property id As String
        Public Property timeStart As Double = 0
        Public Property timeCompleted As Double = 0

        Public Property notBeforeThatBegin As Double = 0
        Public Property notBeforeThat As Double = 0

        Public Property buy As Boolean = False
        Public Property orderValue As Double = 0
        Public Property pairTradeValue As Double = 0

        Public Property feeCost As Double = 0
        Public Property tco As Double = 0
        Public Property amount As Double = 0

        Public Property number As String = ""

        Public Property state As OrderStateEnumeration = OrderStateEnumeration.undefined

        Public Sub New()
            id = Guid.NewGuid.ToString()
        End Sub

    End Class

    ''' <summary>
    ''' This class provide to 
    ''' </summary>
    Public Class TradeModel

        Public ReadOnly Property id As String
            Get
                Return buy.timeStart.ToString
            End Get
        End Property

        Public Property buy As New BotOrderModel
        Public Property sell As New BotOrderModel

        Public Property [close] As Boolean = False
        Public Property earn As Double = 0

        Public ReadOnly Property totalFee As Double
            Get
                Return buy.feeCost + sell.feeCost
            End Get
        End Property

    End Class

    ''' <summary>
    ''' This class contain all data relative of a bot data
    ''' </summary>
    Public Class BotDataModel

        Public Enum BotStateEnumeration
            undefined
            inBootstrap
            inWork
            ultimate
        End Enum

        Public Property pair As String = ""

        Public Property state As BotStateEnumeration = BotStateEnumeration.undefined
        Public Property inRecharge As Boolean = False
        Public Property examTimeLimit As Double = 0

        Public Property timeStart As Double = 0
        Public Property timeEnd As Double = 0

        Public Property usedPlafond As Double = 0
        Public Property earn As Double = 0
        Public Property lastBuyTime As Double = 0
        Public Property lastBuyChange As Double = 0
        Public Property lastBuyValue As Double = 0

        Public Property tradeOpen As New List(Of TradeModel)
        'Public Property tradeClose As New List(Of TradeModel)
        Public Property tradeClose As New List(Of String)

    End Class

End Namespace