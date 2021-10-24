Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCPrimaryRuntimeService.AreaCommon.Models.Network.Request



Namespace AreaCommon.Models.Network

    Public Class RequestExpressionModel

        Property netWorkReferement As String = ""
        Property chainReferement As String = ""
        Property requestCode As String = ""
        Property publicAddressRequester As String = ""
        Property requestDateTimeStamp As Double = 0
        Property requestHash As String = ""

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += netWorkReferement
            tmp += chainReferement
            tmp += requestCode
            tmp += requestDateTimeStamp.ToString()
            tmp += publicAddressRequester
            tmp += requestHash

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        Public hash As String = ""
        Public signature As String = ""

    End Class

End Namespace
