Option Compare Text
Option Explicit On





Namespace Models.Token


    Public Enum TokenType

        [public]
        [private]
        [administration]

    End Enum


    Public Class SingleToken

        Public ipAddress As String = ""
        Public momentReleased As DateTime = DateTime.MinValue
        Public momentLastActivity As DateTime = DateTime.MinValue
        Public value As String = ""
        Public type As TokenType = TokenType.public

        Public banned As Boolean = False
        Public needAuthorization As Boolean = False
        Public authorizated As Boolean = False
        Public testNumberAuthorizationFailed As Byte = 0

    End Class


End Namespace
