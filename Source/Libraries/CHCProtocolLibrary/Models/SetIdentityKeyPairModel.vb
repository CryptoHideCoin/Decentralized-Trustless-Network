Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Security


    Public Class SetIdentityKeyPairModel

        Public publicAddress As String = ""
        Public privateKey As String = ""

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += publicAddress
            tmp += privateKey

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class


End Namespace