Option Compare Text
Option Explicit On




Namespace AreaState

    Module Common

        Public Property bots As New Dictionary(Of String, AreaCommon.Models.Bot.BotConfigurationsModel)
        Public Property pairs As New Dictionary(Of String, AreaCommon.Models.Pair.PairInformation)
        Public Property orders As New Dictionary(Of String, AreaCommon.Models.Order.SimplyOrderModel)

        Public Property defaultGenericAccount As New AreaCommon.Models.Bot.BotUserAccountModel


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

    End Module

End Namespace