Option Compare Text
Option Explicit On

Imports Coinbase.Pro





Namespace AreaCommon.Engines.Currencies

    Module CurrenciesModule

        Private Property _Init As Boolean = False
        Private Property _ClientPro As CoinbaseProClient

        Public Property quoteCurrency As String = ""



        Private Async Sub updateCurrencies()
            Try
                Dim products = Await _ClientPro.MarketData.GetProductsAsync()

                For Each product In products
                    If (product.QuoteCurrency.ToLower.CompareTo(quoteCurrency.ToLower) = 0) Then

                        If (AreaState.products.getCurrency(product.QuoteCurrency).header.key.Length = 0) Then
                            With AreaState.products.addNew(product.BaseCurrency).header
                                .quoteCurrency = product.QuoteCurrency
                                .key = product.BaseCurrency
                                .baseCurrency = .key
                                .name = product.DisplayName
                            End With
                        End If

                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("Problem during updateCurrencies - " & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceProcessor()
            Try

                Task.Run(Sub() updateCurrencies()).Start()

            Catch ex As Exception
            End Try
        End Sub

        Private Function init() As Boolean
            Try
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})

                _Init = True

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to start an account job
        ''' </summary>
        ''' <returns></returns>
        Public Function [start]() As Boolean
            If Not _Init Then
                _Init = init()

                _Init = True
            End If

            Dim objWS As Threading.Thread

            objWS = New Threading.Thread(AddressOf startServiceProcessor)

            objWS.Start()

            Return True
        End Function

    End Module

End Namespace