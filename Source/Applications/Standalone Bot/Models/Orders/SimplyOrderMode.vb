Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Order

    ''' <summary>
    ''' This class contain all element of an order
    ''' </summary>
    Public Class SimplyOrderModel

        Public Property accountCredentials As User.UserDataPersonalModel.ExchangeCredentialUserAccess
        Public Property botId As String
        Public Property internalOrderId As String
        Public Property publicOrderId As String

    End Class

End Namespace