Option Compare Text
Option Explicit On

Imports Coinbase.Pro





Namespace AreaCommon.Engines.Accounts

    Module AccountModule

        Private Property _InWorkJob As Boolean = False
        Private Property _Init As Boolean = False
        Private Property _ClientPro As CoinbaseProClient



        Private Async Sub updateDataAccounts()
            Try
                Dim accounts = Await _ClientPro.Accounts.GetAllAccountsAsync()
                Dim newAccounts As New Dictionary(Of String, Models.Account.AccountModel)
                Dim singleNewAccount As Models.Account.AccountModel
                Dim pairKey As String = ""

                For Each account In accounts
                    If (account.Balance > 0) Then
                        singleNewAccount = New Models.Account.AccountModel With {.id = account.Currency, .amount = account.Balance}

                        If (account.Currency.ToLower.CompareTo("usdt") = 0) Then
                            newAccounts.Add(account.Currency.ToLower, singleNewAccount)

                            singleNewAccount.change = 1
                            singleNewAccount.valueUSDT = singleNewAccount.amount
                        Else
                            pairKey = account.Currency.ToLower & "-usdt"

                            newAccounts.Add(pairKey, singleNewAccount)

                            If pairKey.ToLower.CompareTo("eur-usdt") <> 0 Then
                                AreaState.getPairID(pairKey.ToUpper())
                            Else
                                singleNewAccount.change = 1
                                singleNewAccount.valueUSDT = singleNewAccount.amount
                            End If

                            If AreaState.pairs.ContainsKey(pairKey.ToUpper) Then
                                singleNewAccount.change = AreaState.pairs(pairKey.ToUpper).currentValue
                                singleNewAccount.valueUSDT = CDec(singleNewAccount.change) * singleNewAccount.amount
                            End If
                        End If
                    End If
                Next

                AreaState.accounts = newAccounts
            Catch ex As Exception
                MessageBox.Show("Problem during updateDataAccounts - " & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceProcessor()
            Try
                Dim currentIndex As Integer = 0

                Do While _InWorkJob
                    Task.Run(Sub() updateDataAccounts()).Start()

                    Threading.Thread.Sleep(30000)
                Loop
            Catch ex As Exception
                _InWorkJob = False
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

            If Not _InWorkJob Then
                Dim objWS As Threading.Thread

                _InWorkJob = True

                objWS = New Threading.Thread(AddressOf startServiceProcessor)

                objWS.Start()
            End If

            Return True
        End Function

        Public Function [stop]() As Boolean
            _InWorkJob = False

            Return True
        End Function

    End Module

End Namespace
