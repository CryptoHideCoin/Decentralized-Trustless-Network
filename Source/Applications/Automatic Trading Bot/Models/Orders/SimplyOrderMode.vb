Option Compare Text
Option Explicit On


Namespace AreaCommon.Models.Order

    Public Class PlaceOrderModel
        Public pair As String
        Public sizeround As Decimal
        Public limitPriceRound As Decimal
    End Class

    ''' <summary>
    ''' This class contain all element of an order
    ''' </summary>
    Public Class SimplyOrderModel

        Public Property accountCredentials As User.UserDataPersonalModel.ExchangeCredentialUserAccess
        Public Property botId As String
        Public Property internalOrderId As String
        Public Property publicOrderId As String
        Public Property cancelProductInformation As Boolean

        Public Property productId As String = ""

        Public Property lastTest As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
        Public Property firstVerify As Boolean = True

        Public ReadOnly Property nextTest As Double
            Get
                If firstVerify Then
                    Return lastTest + 10000
                Else
                    Return lastTest + 60000
                End If
            End Get
        End Property

    End Class

End Namespace