Option Compare Text
Option Explicit On

Imports Coinbase.Pro.Models





Namespace AreaCommon.Engines.Accounts

    Module AccountModule

        Private Property _Init As Boolean = False
        Private Property _InUnauthorized As Boolean = False
        Private Property _ShowInUnauthorizedMessage As Boolean = False
        Private Property _InWork As Boolean = False
        Private Property _NotStarted As Boolean = True

        Public Property inWorkJob As Boolean = False



        Private Async Sub updateDataAccounts()
            If _InWork Then
                Return
            End If

            _InWork = True

            Try
                Dim accounts = Await AreaState.exchangeProxy.GetAllAccounts()
                Dim newAccounts As New Dictionary(Of String, Models.Account.AccountModel)
                Dim singleNewAccount As Models.Account.AccountModel
                Dim pairKey As String = ""

                _InUnauthorized = False
                _ShowInUnauthorizedMessage = False
                _NotStarted = False

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

                            If (singleNewAccount.change = 0) Then
                                _NotStarted = True
                            End If
                        End If

                        singleNewAccount.available = account.Available
                    End If
                Next

                AreaState.accounts = newAccounts
            Catch ex As Exception
                inWorkJob = False

                _InUnauthorized = (ex.Message Like "*Unauthorized*")

                If Not _ShowInUnauthorizedMessage And _InUnauthorized Then
                    _ShowInUnauthorizedMessage = True

                    MessageBox.Show("Problem during updateDataAccounts - " & ex.Message)
                End If
            End Try

            _InWork = False
        End Sub

        ''' <summary>
        ''' This method provide to start service processor
        ''' </summary>
        Private Sub startServiceProcessor()
            Try
                Do While inWorkJob
                    updateDataAccounts()

                    If _NotStarted Then
                        Threading.Thread.Sleep(1000)
                    Else
                        Threading.Thread.Sleep(15000)
                    End If
                Loop
            Catch ex As InvalidOperationException
            Catch ex As Exception
                inWorkJob = False
            End Try
        End Sub

        Private Function init() As Boolean
            Try
                _Init = True

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to refresh the data
        ''' </summary>
        ''' <returns></returns>
        Public Function refresh() As Boolean
            updateDataAccounts()

            Return True
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

            If Not inWorkJob Then
                Dim objWS As Threading.Thread

                inWorkJob = True

                objWS = New Threading.Thread(AddressOf startServiceProcessor)

                objWS.Start()
            End If

            Return True
        End Function

        Public Function [stop]() As Boolean
            inWorkJob = False

            Return True
        End Function

    End Module

End Namespace
