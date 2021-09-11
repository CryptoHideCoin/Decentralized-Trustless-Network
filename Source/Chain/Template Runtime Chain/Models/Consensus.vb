Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Network

    Public Class NotifyRequestAvailable

        Public Property requestHash As String = ""
        Public Property dateAcquireNetwork As Double = 0
        Public Property publicAddressManager As String = ""


        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += requestHash.ToString
            tmp += dateAcquireNetwork.ToString
            tmp += publicAddressManager.ToString()

            Return tmp
        End Function

        Public ReadOnly Property toHash() As String
            Get
                Return HashSHA.generateSHA256(Me.toString().Replace("|", ""))
            End Get
        End Property

    End Class

End Namespace