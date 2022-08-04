Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Bot

    ''' <summary>
    ''' This class contain the bot parameter
    ''' </summary>
    Public Class BotParametersModel

        ''' <summary>
        ''' This class contain the header general information of bot
        ''' </summary>
        Public Class HeaderBotConfiguration

            Public Property id As String = ""
            Public Property created As Double = 0
            Public Property isActive As Boolean = False

        End Class

        ''' <summary>
        ''' This class contain the information reguard the source of investiment
        ''' </summary>
        Public Class FundBotConfiguration

            Public Property pairId As Integer = 0
            Public Property plafond As Double = 0
            Public Property unitStep As Double = 0

        End Class

        ''' <summary>
        ''' This class contain the information reguard the start of job
        ''' </summary>
        Public Class StartJobConfiguration

            Public Property timeStart As Double = 0
            Public Property minuteExam As Integer = 0
            Public Property triggerValue As Double = 0

        End Class

        ''' <summary>
        ''' This information contain the information reguard the future acquire of currency
        ''' </summary>
        Public Class AcquisitionValueConfiguration

            Public Property stepInterval As Double = 0
            Public Property dealAcquireOnPercentage As Double = 0
            Public Property dealMinimalStep As Double = 0
            Public Property onlyInDeal As Boolean = False
            Public Property notInBearMarket As Boolean = False
            Public Property duringBottonBearMarket As Boolean = False

        End Class

        ''' <summary>
        ''' This class contain the specification action during bear market
        ''' </summary>
        Public Class BearMarketConfiguration

            Public Property saveFoundActive As Boolean = False
            Public Property duringMinuteWhenIn As Integer = 0
            Public Property degradePercentage As Double = 0
            Public Property bottomReboundPercentage As Double = 0
            Public Property maximumExposurePercentage As Double = 0

        End Class

        ''' <summary>
        ''' This class contain the specification action during bull run market
        ''' </summary>
        Public Class BullRunConfiguration

            Public Property exploreBullRun As Boolean = False
            Public Property halvingMinuteWhenIn As Integer = 0
            Public Property halvingPercentage As Double = 0
            Public Property duringMinuteWhenIn As Integer = 0
            Public Property increasePercentage As Double = 0
            Public Property topReboundPercentage As Double = 0

        End Class

        ''' <summary>
        ''' This class contain the information relative the activity of the bot
        ''' </summary>
        Public Class BotActivityConfiguration

            ''' <summary>
            ''' This enumeration contain the mode of trade configuration
            ''' 
            ''' undefined - Not define
            ''' continuousGain - use the job continuousely 
            ''' dayTrading - mean the work all day to enter and exit position
            ''' weekTrading - mean the work all week to enter and exit position
            ''' monthTrading - mean the work all month to enter and exit position
            ''' yearTradint - mean the work long time to enter and exit position
            ''' investiment - help to cumulate coin into account
            ''' </summary>
            Public Enum ModeTradeConfigEnumeration
                undefined
                simpleAct
                continuosGain
                DCA
                onlyDeal
            End Enum

            Public Property mode As ModeTradeConfigEnumeration = ModeTradeConfigEnumeration.undefined
            Public Property spread As Double = 0
            Public Property buyConfiguration As New AcquisitionValueConfiguration
            Public Property bearMarket As New BearMarketConfiguration
            Public Property bullRunMarket As New BullRunConfiguration

        End Class

        Public Property header As New HeaderBotConfiguration
        Public Property fundConfiguration As New FundBotConfiguration
        Public Property startConfiguration As New StartJobConfiguration
        Public Property workConfiguration As New BotActivityConfiguration

        Public Property accountOutId As Integer = 0

    End Class

End Namespace