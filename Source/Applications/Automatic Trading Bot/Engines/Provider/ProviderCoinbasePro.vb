Option Compare Text
Option Explicit On

Imports Coinbase.Pro



Namespace AreaCommon.Provider

    Public Class ProviderCoinbasePro

        Private Property _ClientPro As CoinbaseProClient



        Public Function cancelOrderProduct(ByVal id As String) As Boolean
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            _ClientPro.Orders.CancelOrderByIdAsync(id)

            addLogOperation($"ProviderCoinbasePro.cancelOrderProduct - {id}")

            Return True
        End Function

        Public Function getOpenOrder(ByVal id As String) As Boolean
            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            Try
                Dim order = _ClientPro.Orders.GetOrderAsync(id).Result

                addLogOperation($"ProviderCoinbasePro.getOpenOrder - {id}")

                Return ((order.Status.CompareTo("open") = 0) And (Not order.Settled) And (order.FilledSize.CompareTo(0) = 0))
            Catch ex As Exception
                addLogOperation($"ProviderCoinbasePro.getOpenOrder - {id} error - " & ex.Message)

                Return False
            Finally
                addLogOperation($"ProviderCoinbasePro.getOpenOrder - {id} completed")
            End Try
        End Function

        Public Function getProductOrder(ByVal pairId As String, ByVal orderId As String) As Coinbase.Pro.Models.Order
            Dim exchangeOrders As Coinbase.Pro.Models.PagedResponse(Of Coinbase.Pro.Models.Order)

            If IsNothing(_ClientPro) Then
                _ClientPro = New CoinbaseProClient(New Config With {.ApiKey = AreaState.defaultUserDataAccount.exchangeAccess.APIKey, .Passphrase = AreaState.defaultUserDataAccount.exchangeAccess.passphrase, .Secret = AreaState.defaultUserDataAccount.exchangeAccess.secret, .ApiUrl = AreaState.defaultUserDataAccount.exchangeAccess.apiURL})
            End If

            exchangeOrders = _ClientPro.Orders.GetAllOrdersAsync("all", pairId.ToUpper, 1).Result

            If Not IsNothing(exchangeOrders) Then
                If (exchangeOrders.Data.Count > 0) Then
                    For Each singleOrder In exchangeOrders.Data
                        If (singleOrder.Id.CompareTo(orderId) = 0) Then
                            Return singleOrder
                        End If
                    Next
                End If
            End If

            Return New Coinbase.Pro.Models.Order
        End Function


    End Class

End Namespace
