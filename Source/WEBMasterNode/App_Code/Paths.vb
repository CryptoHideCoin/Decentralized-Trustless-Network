Option Compare Text
Option Explicit On


Namespace AreaSystem


    Public Class Paths

        Public pathBaseData As String = ""
        Public pathUnitOfExchangeValue As String = ""


        Public Function init() As String

            pathUnitOfExchangeValue = System.IO.Path.Combine(pathBaseData, "CoinDefinition")

            Return True

        End Function

    End Class


End Namespace