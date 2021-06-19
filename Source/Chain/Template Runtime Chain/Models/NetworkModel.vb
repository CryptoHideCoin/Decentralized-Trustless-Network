Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models



Namespace AreaCommon.Models.Network



    Public Class NetworkModel

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

        Public response As New General.RemoteResponse

    End Class


End Namespace
