Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Bot

    ''' <summary>
    ''' This method provide to collect all configuration parameter of a bot
    ''' </summary>
    Public Class BotConfigurationsModel

        Public Property userAccount As New BotUserAccountModel
        Public Property parameters As New BotParametersModel
        Public Property data As New BotDataModel
        'Public Property registry as 
        Public Property common As Pair.PairInformation

    End Class

End Namespace