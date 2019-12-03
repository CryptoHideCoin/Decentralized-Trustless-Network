Option Compare Text
Option Explicit On


Namespace AreaSystem


    Public Class Paths

        Public pathBaseData As String = ""
        Public pathUnitOfExchangeValue As String = ""


        Public Function init() As String

            pathUnitOfExchangeValue = System.IO.Path.Combine(pathBaseData, "CoinDefinition")

            If Not IO.Directory.Exists(pathUnitOfExchangeValue) Then

                IO.Directory.CreateDirectory(pathUnitOfExchangeValue)

            End If

            Return True

        End Function

    End Class


End Namespace