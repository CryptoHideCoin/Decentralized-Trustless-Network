Option Compare Text
Option Explicit On


Imports CHCModelsLibrary.AreaModel.Information




Namespace AreaService.Runtime.Models

    ''' <summary>
    ''' This class contain the service of a state
    ''' </summary>
    Public Class ServiceState

        Public Property serviceInformation As New InternalServiceInformation
        Public Property tradingBotSystem As New AreaEngine.TradingBotSystemServiceEngine
        Public Property exchangesEngine As New AreaBusiness.ExchangeEngine
        Public Property exchangeReferencesEngine As New AreaBusiness.ExchangeReferencesEngine
        Public Property currenciesEngine As New AreaBusiness.CurrenciesEngine
        Public Property currenciesDownloadEngine As New AreaJob.GetCurrenciesFromWEB

    End Class

End Namespace
