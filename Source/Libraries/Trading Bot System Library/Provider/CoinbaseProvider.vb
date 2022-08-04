Option Compare Text
Option Explicit On





Namespace AreaProvider.CoinbaseProvider

    ''' <summary>
    ''' This class contain the main data of a currency for coinbase
    ''' </summary>
    Public Class Currency

        Public Property id As String
        Public Property name As String
        Public Property min_size As Decimal
        Public Property status As String
        Public Property message As String
        Public Property max_precision As Decimal
        Public Property convertible_to As New List(Of String)
        Public Property details As CurrencyDetails

    End Class

    ''' <summary>
    ''' This class contain the detail data of a currency for coinbase
    ''' </summary>
    Public Class CurrencyDetails

        Public Property type As String
        Public Property symbol As String = Nothing
        Public Property network_confirmation As Integer
        Public Property sort_order As Integer
        Public Property crypto_address_link As String
        Public Property crypto_transaction_link As String
        Public Property push_payment_methods As New List(Of String)
        Public Property group_types As New List(Of String)
        Public Property display_name As String
        Public Property processing_time_seconds As Decimal?
        Public Property min_withdrawal_amount As Decimal?
        Public Property max_withdrawal_amount As Decimal?

    End Class

    Public Module Worker

        ''' <summary>
        ''' This method provide to download a currency from a provider
        ''' </summary>
        Public Async Sub searchNewCurrenciesAsync(ByVal supplier As String, ByVal exchangeId As Integer)
            Dim ownerId As String = "searchNewCurrencies"
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("Worker.searchNewCurrencies", ownerId)

                Dim proxyEngine As New CHCCommonLibrary.AreaEngine.Communication.ProxyWS(Of List(Of Currency))
                Dim newCurrency As TradingBotSystemModelsLibrary.AreaModel.Currency.CurrencyStructure
                Dim newCurrencyAdded As Boolean = False

                proxyEngine.url = AreaCommon.state.exchangeReferencesEngine.select(exchangeId, TradingBotSystemModelsLibrary.AreaModel.Exchange.ExchangeReferenceStructure.TypeReferenceEnumeration.apiCurrencies, ownerId).url

                Dim response As String = Await proxyEngine.getData("Accept")

                If (response.Length > 0) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("Worker.searchNewCurrencies", ownerId, response)
                Else
                    For Each singleCurrency In proxyEngine.data
                        If (AreaCommon.state.currenciesEngine.select(singleCurrency.id, ownerId).id = 0) Then
                            newCurrency = New TradingBotSystemModelsLibrary.AreaModel.Currency.CurrencyStructure

                            newCurrency.shortName = singleCurrency.id
                            newCurrency.name = singleCurrency.name
                            newCurrency.acquireTimeStamp = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

                            newCurrency.displayName = singleCurrency.details.display_name

                            Do While (singleCurrency.max_precision < 1)
                                newCurrency.maxPrecision += 1

                                singleCurrency.max_precision = singleCurrency.max_precision * 10
                            Loop

                            Do While (singleCurrency.min_size < 1)
                                newCurrency.minSize += 1

                                singleCurrency.min_size = singleCurrency.min_size * 10
                            Loop

                            newCurrency.source = "Coinbase"
                            newCurrency.supplier = supplier

                            If IsNothing(singleCurrency.details.symbol) Then
                                newCurrency.symbol = ""
                            Else
                                newCurrency.symbol = singleCurrency.details.symbol
                            End If

                            Select Case singleCurrency.details.type.ToString()
                                Case "crypto" : newCurrency.tipology = TradingBotSystemModelsLibrary.AreaModel.Currency.CurrencyStructure.tipologyAsset.crypto
                                Case Else : newCurrency.tipology = TradingBotSystemModelsLibrary.AreaModel.Currency.CurrencyStructure.tipologyAsset.fiat
                            End Select

                            newCurrency.nature = TradingBotSystemModelsLibrary.AreaModel.Currency.CurrencyStructure.natureAsset.undefined
                            newCurrency.networkReferement = ""
                            newCurrency.contractNetwork = ""

                            Dim idCurrency As Integer = AreaCommon.state.currenciesEngine.addOrGet(newCurrency, ownerId).id

                            Dim newExchangeCurrency As New TradingBotSystemModelsLibrary.AreaModel.ExchangeCurrencies.ExchangeCurrencySupportStructure

                            newExchangeCurrency.currencyId = idCurrency
                            newExchangeCurrency.exchangeId = exchangeId
                            newExchangeCurrency.supportedType = TradingBotSystemModelsLibrary.AreaModel.ExchangeCurrencies.TypeSupportedEnumeration.undefined

                            AreaCommon.state.exchangeCurrenciesEngine.addIfMissing(newExchangeCurrency, ownerId)

                            newCurrencyAdded = True
                        End If
                    Next

                    AreaCommon.state.exchangesEngine.updateExchangeLast(exchangeId, True, ownerId)

                    If newCurrencyAdded Then
                        CHCSidechainServiceLibrary.AreaCommon.Main.environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.other, "[Business] - Add new coin into db")
                    End If
                End If
            Catch ex As Exception
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackException("Worker.searchNewCurrencies", ownerId, ex.Message)
            Finally
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackExit("Worker.searchNewCurrencies", ownerId)
            End Try
        End Sub


    End Module

End Namespace
