Option Compare Text
Option Explicit On

Imports Coinbase.Pro



Module Startup

    Private Property _ClientProEngine As New CoinbaseProClient
    Private WithEvents _Job As New AreaCommon.Engine.Bot.BotEngine



    Private Function getDataSettings() As AreaCommon.Models.Bots.BotParameters
        Dim bot As New AreaCommon.Models.Bots.BotParameters

        bot.header.isActive = True

        bot.fundConfiguration.plafond = 100
        bot.fundConfiguration.unitStep = 1

        bot.startConfiguration.minuteExam = 60

        bot.workConfiguration.bullRunMarket.halvingMinuteWhenIn = 8
        bot.workConfiguration.bullRunMarket.halvingPercentage = 3
        bot.workConfiguration.bullRunMarket.duringMinuteWhenIn = 7
        bot.workConfiguration.bullRunMarket.increasePercentage = 5

        bot.workConfiguration.bearMarket.duringMinuteWhenIn = 10
        bot.workConfiguration.bearMarket.degradePercentage = 3

        bot.workConfiguration.deal.dealAcquireOnPercentage = 5
        bot.workConfiguration.deal.dealMinimalStep = 60 * 60 * 1000

        bot.workConfiguration.mode = AreaCommon.Models.Bots.BotParameters.BotActivityConfiguration.ModeTradeConfigEnumeration.continuosGain
        bot.workConfiguration.pairId = 1
        bot.workConfiguration.spread = 3

        Return bot
    End Function



    Sub Main()
        _ClientProEngine = New CoinbaseProClient(New Config With {.ApiKey = "0056fd332d3742fe03e23611e458f5f6", .Passphrase = "7453tzgjyvo", .Secret = "PWgu2Ssj/O6dZZA9PGjYqqOrLjWKX4Ek6bRPHzDKLYajgiYaBDfdQv5WBuTwcW6ezuYOF6XKpx0q4eyBQTCThA==", .ApiUrl = "https://api.pro.coinbase.com"})

        _Job.settings = getDataSettings()

        Do While _Job.run()
            Threading.Thread.Sleep(60000)
        Loop
    End Sub

    Private Async Sub getNewTick(ByVal pair As String)
        Dim market = Await _ClientProEngine.MarketData.GetTickerAsync(pair)

        _Job.lastPairPrice = market.Price
        _Job.inRefreshPrice = False
    End Sub

    Private Sub _Job_RequestRefreshPrice(pair As String) Handles _Job.RequestRefreshPrice
        _Job.inRefreshPrice = True

        Task.Run(Sub() getNewTick(pair))
    End Sub

End Module
