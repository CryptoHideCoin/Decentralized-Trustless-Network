Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models



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

        Public response As New General.RemoteResponse

    End Class


End Namespace