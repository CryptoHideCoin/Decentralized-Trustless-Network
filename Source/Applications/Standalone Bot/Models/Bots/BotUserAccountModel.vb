Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Bot

    ''' <summary>
    ''' This class contain all data relative of a bot data
    ''' </summary>
    Public Class BotUserAccountModel

        Public Enum ExchangeEnumeration
            undefined
            coinbase
            coinbasePro
        End Enum

        Public Property exchange As ExchangeEnumeration = ExchangeEnumeration.undefined

        Public Property APIKey As String = ""
        Public Property passphrase As String = ""
        Public Property secret As String = ""
        Public Property apiURL As String = ""

    End Class

End Namespace

