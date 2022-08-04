Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Bot

    ''' <summary>
    ''' This class contain all data relative an order bot
    ''' </summary>
    Public Class BotOrderModel

        Public Property id As String
        Public Property timeAcquire As Double = 0
        Public Property buy As Boolean = False
        Public Property orderValue As Double = 0
        Public Property pairTradeValue As Double = 0
        Public Property effectiveValue As Double = 0
        Public Property amount As Double = 0

        Public Property number As String = ""

        Public Property fill As Boolean = False
        Public Property sent As Boolean = False
        Public Property placed As Boolean = False

        Public Sub New()
            id = Guid.NewGuid.ToString()
        End Sub

    End Class

    ''' <summary>
    ''' This class provide to 
    ''' </summary>
    Public Class TradeModel

        Public Property buy As New BotOrderModel
        Public Property sell As New BotOrderModel

        Public Property [close] As Boolean = False
        Public Property earn As Double = 0

    End Class

    ''' <summary>
    ''' This class contain all data relative of a bot data
    ''' </summary>
    Public Class BotDataModel

        Public Property pair As String = ""

        Public Property bootStrapInitial As Boolean = False
        Public Property bootStrapComplete As Boolean = False
        Public Property examTimeLimit As Double = 0

        Public Property timeStart As Double = 0

        Public Property usedPlafond As Double = 0
        Public Property earn As Double = 0
        Public Property lastBuyTime As Double = 0
        Public Property lastBuyValue As Double = 0

        Public Property tradeOpen As New List(Of TradeModel)
        Public Property tradeClose As New List(Of TradeModel)

    End Class

End Namespace