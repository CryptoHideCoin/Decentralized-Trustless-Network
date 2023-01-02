Option Compare Text
Option Explicit On




Namespace AreaState

    Module Common

        Public Property exchangeProxy As New AreaCommon.Provider.ProviderCoinbasePro
        Public Property automaticBot As New AreaCommon.Models.Bot.BotAutomatic
        Public Property products As New AreaCommon.Models.Products.ProductsModel
        Public Property bots As New Dictionary(Of String, AreaCommon.Models.Bot.BotConfigurationsModel)
        Public Property pairs As New Dictionary(Of String, AreaCommon.Models.Pair.PairInformation)
        Public Property orders As New Dictionary(Of String, AreaCommon.Models.Order.SimplyOrderModel)
        Public Property accounts As New Dictionary(Of String, AreaCommon.Models.Account.AccountModel)
        Public Property journal As New AreaCommon.Models.Journal.CumulativeModel
        Public Property gainFund As New AreaCommon.Models.Journal.FundReservationModel
        Public Property botList As New AreaCommon.Models.Bot.BotListModel
        Public Property defaultUserDataAccount As New AreaCommon.Models.User.UserDataPersonalModel
        Public Property summary As New AreaCommon.Models.Account.SummaryModel
        Public Property closeApplication As Boolean = False

        Public Property defaultSettings As String = "isActive=1&pairId=BTC-USDT&plafond=100&unitStep=1&minuteExam=6&mode=0&spread=5"


        ''' <summary>
        ''' This method provide to get the pair id
        ''' </summary>
        ''' <param name="pair"></param>
        ''' <returns></returns>
        Public Function getPairID(ByVal pair As String) As Integer
            If pairs.ContainsKey(pair) Then
                Return pairs(pair).id
            End If

            Dim newPair As New AreaCommon.Models.Pair.PairInformation

            newPair.id = pairs.Count + 1
            newPair.key = pair

            pairs.Add(pair, newPair)

            Return newPair.id
        End Function

        ''' <summary>
        ''' This method provide to get a pair name from a id
        ''' </summary>
        ''' <param name="pairId"></param>
        ''' <returns></returns>
        Public Function getPairName(ByVal pairId As Integer) As String
            For Each item In pairs.Values
                If (item.id = pairId) Then
                    Return item.key
                End If
            Next

            Return ""
        End Function

        Public Function addIntoAccount(ByVal Id As String, ByVal value As Double, ByVal mainValue As Boolean) As Boolean
            Dim dataAccount As AreaCommon.Models.Account.AccountModel
            Dim indexCurrency As Integer = 0
            Dim currencyKey As String

            If Not defaultUserDataAccount.useVirtualAccount Then
                Return True
            End If

            If mainValue Then
                indexCurrency = 1
            End If

            currencyKey = Id.Split("-")(indexCurrency).Trim.ToLower

            If accounts.ContainsKey(currencyKey) Then
                dataAccount = accounts(currencyKey)
            Else
                dataAccount = New AreaCommon.Models.Account.AccountModel

                dataAccount.id = currencyKey.ToUpper

                accounts.Add(currencyKey, dataAccount)
            End If

            dataAccount.amount += value

            If (dataAccount.id.ToLower.CompareTo("USDT".ToLower) = 0) Or (dataAccount.id.ToLower.CompareTo("USD".ToLower) = 0) Then
                dataAccount.valueUSDT = dataAccount.amount
                dataAccount.change = 1
            Else
                dataAccount.valueUSDT = dataAccount.amount * pairs(Id).currentValue
                dataAccount.change = pairs(Id).currentValue
            End If

            dataAccount.available = dataAccount.valueUSDT

            If (Val(dataAccount.amount.ToString("0.00000").Replace(",", ".")) <= 0) Then
                accounts.Remove(currencyKey)
            End If

            Return True
        End Function

        Public Function updateChange(ByVal Id As String, ByVal value As Double) As Boolean
            Dim dataAccount As AreaCommon.Models.Account.AccountModel

            Dim currencyKey As String = Id.Split("-")(0).ToLower

            If accounts.ContainsKey(currencyKey) Then
                dataAccount = accounts(currencyKey)

                dataAccount.change = value
                dataAccount.valueUSDT = value * dataAccount.amount
            End If

            Return True
        End Function

    End Module

End Namespace
