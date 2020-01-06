Option Compare Text
Option Explicit On


Namespace AreaSystem


    Public Class Paths

        Public pathBaseData As String = ""
        Public pathCryptoAssetValue As String = ""
        Public pathTransChainValue As String = ""


        Public Function init() As String

            pathCryptoAssetValue = IO.Path.Combine(pathBaseData, "CryptoAssetDefinition")
            pathTransChainValue = IO.Path.Combine(pathBaseData, "TransChainDefinition")

            If Not IO.Directory.Exists(pathCryptoAssetValue) Then

                IO.Directory.CreateDirectory(pathCryptoAssetValue)

            End If

            If Not IO.Directory.Exists(pathTransChainValue) Then

                IO.Directory.CreateDirectory(pathTransChainValue)

            End If

            Return True

        End Function

    End Class


End Namespace