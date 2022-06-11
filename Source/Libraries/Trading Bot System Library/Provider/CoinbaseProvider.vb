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
        Public Async Sub searchNewCurrenciesAsync(ByVal supplier As String)
            Dim ownerId As String = "searchNewCurrencies"
            Try
                CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackEnter("Worker.searchNewCurrencies", ownerId)

                Dim proxyEngine As New CHCCommonLibrary.AreaEngine.Communication.ProxyWS(Of List(Of Currency))
                Dim newCurrency As TradingBotSystemModelsLibrary.AreaModel.Currency.CurrencyStructure
                Dim exchange_id As Integer = 0
                Dim newCurrencyAdded As Boolean = False

                For Each item In AreaCommon.state.exchangesEngine.list
                    If (item.name.CompareTo("Coinbase") = 0) Then
                        exchange_id = item.id

                        Exit For
                    End If
                Next

                If (exchange_id > 0) Then
                    proxyEngine.url = AreaCommon.state.exchangeReferencesEngine.select(exchange_id, TradingBotSystemModelsLibrary.AreaModel.Exchange.ExchangeReferenceStructure.TypeReferenceEnumeration.apiCurrencies, ownerId).url

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

                                If (singleCurrency.max_precision > 0) Then
                                    Do While (singleCurrency.max_precision > 0)
                                        newCurrency.maxPrecision += 1

                                        singleCurrency.max_precision = singleCurrency.max_precision * 10
                                    Loop
                                End If

                                If (singleCurrency.min_size > 0) Then
                                    Do While (singleCurrency.min_size > 0)
                                        newCurrency.minSize += 1

                                        singleCurrency.min_size = singleCurrency.min_size * 10
                                    Loop
                                End If

                                newCurrency.source = "Coinbase"
                                newCurrency.supplier = supplier
                                newCurrency.symbol = singleCurrency.details.symbol
                                newCurrency.tipology = singleCurrency.details.type

                                AreaCommon.state.currenciesEngine.addOrGet(newCurrency, ownerId)

                                newCurrencyAdded = True
                            End If
                        Next

                        If newCurrencyAdded Then
                            CHCSidechainServiceLibrary.AreaCommon.Main.environment.registry.addNew(CHCModelsLibrary.AreaModel.Registry.RegistryData.TypeEvent.other, "[Business] - Add new coin into db")
                        End If
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
