Option Compare Text
Option Explicit On



Namespace AreaCommon.Request

    Public Class RequestModel

        Public Property requestDateTimeStamp As Double = 0
        Public Property publicWalletAddressRequester As String = ""

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += requestDateTimeStamp.ToString()
            tmp += publicWalletAddressRequester

            Return tmp
        End Function

        Public Property requestHash As String = ""
        Public Property signature As String = ""

    End Class

End Namespace