Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.Network


    Public Class InfoNetworkModel

        Public Enum EnumNetworkStatus

            off
            prepareToConnect
            inConnection
            connected
            duringDisconnected

        End Enum

        Public currentStatus As EnumNetworkStatus = EnumNetworkStatus.off
        Public transactionChainName As String = ""
        Public protocolRelease As String = ""

        Public response As General.RemoteResponse

    End Class


End Namespace