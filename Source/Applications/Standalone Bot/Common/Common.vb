Option Compare Text
Option Explicit On




Namespace AreaState

    Module Common

        Public Property bots As New Dictionary(Of String, AreaCommon.Models.Bot.BotConfigurationsModel)
        Public Property pairs As New Dictionary(Of String, AreaCommon.Models.Pair.PairInformation)
        Public Property orders As New Dictionary(Of String, AreaCommon.Models.Order.SimplyOrderModel)
        Public Property accounts As New Dictionary(Of String, AreaCommon.Models.Account.AccountModel)
        Public Property defaultGenericAccount As New AreaCommon.Models.Bot.BotUserAccountModel
        Public Property nameArea As String = "default"
        Public Property closeApplication As Boolean = False

        Public Property totalVolumeTrade As Double = 0
        Public Property totalFeeTrade As Double = 0

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

            AreaCommon.Engines.Pairs.start()

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

        Public Function addIntoAccount(ByVal Id As String, ByVal value As Double) As Boolean
            Dim dataAccount As AreaCommon.Models.Account.AccountModel

            If accounts.ContainsKey(Id.ToLower()) Then
                dataAccount = accounts(Id.ToLower())
            Else
                dataAccount = New AreaCommon.Models.Account.AccountModel

                dataAccount.id = Id.Split("-")(0)

                accounts.Add(Id.ToLower(), dataAccount)
            End If

            dataAccount.amount += value

            If (dataAccount.id.ToLower.CompareTo("USDT".ToLower) = 0) Then
                dataAccount.valueUSDT = dataAccount.amount
                dataAccount.change = 1
            Else
                dataAccount.valueUSDT = dataAccount.amount * pairs(Id).currentValue
                dataAccount.change = pairs(Id).currentValue
            End If

            If (dataAccount.amount = 0) Then
                accounts.Remove(Id.ToLower())
            End If

            Return True
        End Function

        Public Function updateChange(ByVal Id As String, ByVal value As Double) As Boolean
            Dim dataAccount As AreaCommon.Models.Account.AccountModel

            If accounts.ContainsKey(Id.ToLower) Then
                dataAccount = accounts(Id.ToLower)

                dataAccount.change = value
                dataAccount.valueUSDT = value * dataAccount.amount
            End If

            Return True
        End Function

    End Module

End Namespace