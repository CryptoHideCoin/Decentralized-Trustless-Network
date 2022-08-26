Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.User

    ''' <summary>
    ''' This class contain all data relative of a bot data
    ''' </summary>
    Public Class UserDataPersonalModel

        ''' <summary>
        ''' This class contain all information to access into user account exchange
        ''' </summary>
        Public Class ExchangeCredentialUserAccess
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

        Public Property tenantName As String = ""

        Public Property exchangeAccess As New ExchangeCredentialUserAccess

        Public Property useVirtualAccount As Boolean = True
        Public Property initialBaseFund As Double = 0
        Public Property initialBaseFundCurrencyKey As String = ""

    End Class

End Namespace

