Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models



Namespace AreaCommon.Models.Network


    'Public Class SingleNodeResponseModel

    '    Inherits TransactionChainNodeLibrary.AreaTransactionChain.Models.SingleNodeModel

    '    Public response As New General.RemoteResponse

    'End Class



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
