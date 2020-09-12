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

        Public transactionChainId As String = ""
        Public transactionChainName As String = ""
        Public protocolRelease As String = ""

        Public response As New CHCProtocol.AreaCommon.Models.General.RemoteResponse

    End Class


End Namespace