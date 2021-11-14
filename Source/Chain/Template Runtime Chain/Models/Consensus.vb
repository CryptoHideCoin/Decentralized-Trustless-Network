Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Network

    Namespace Request

        Public Class CommonRequest

            Property netWorkReferement As String = ""
            Property chainReferement As String = ""
            Property [type] As String = ""
            Property publicAddressRequester As String = ""
            Property requestDateTimeStamp As Double = 0

            Public Overrides Function toString() As String
                Dim tmp As String = ""

                tmp += netWorkReferement
                tmp += chainReferement
                tmp += [type]
                tmp += requestDateTimeStamp.ToString()
                tmp += publicAddressRequester

                Return tmp
            End Function

            Public Function getHash() As String
                Return HashSHA.generateSHA256(Me.toString())
            End Function

            Public hash As String = ""
            Public signature As String = ""

        End Class

        Public Interface IRequestModel

            Property common As CommonRequest

            Function toString() As String
            Function getHash() As String

        End Interface

    End Namespace

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