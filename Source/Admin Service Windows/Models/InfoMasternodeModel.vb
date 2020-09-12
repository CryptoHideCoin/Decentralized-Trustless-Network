Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.Masternode


    Public Class InfoModel

        Public currentStatus As String = ""
        Public virtualName As String = ""
        Public masternodeLocalTime As String = ""
        Public publicWalletAddress As String = ""
        Public serviceOffered As String = ""
        Public platformHost As String = ""
        Public softwareRelease As String = ""
        Public protocolRelease As String = ""
        Public ipAddress As String = ""

        Public response As New CHCProtocol.AreaCommon.Models.General.RemoteResponse

    End Class

    Public Class NodeInformation

        Public Enum EnumPeerServiceType
            notDefined
            [public]
            service
            thanksTo
            file
            dns
            exChange
            vote
        End Enum

        Public Class configurationPort
            Public [type] As EnumPeerServiceType = EnumPeerServiceType.notDefined
            Public port As String = ""
        End Class


        Public address As String = ""
        Public virtualName As String = ""
        Public associatedWalletAddress As String = ""

        Public serviceList As New List(Of configurationPort)

        Public configureTransactionDefinitionID As String = ""
        Public masternodeConnectedChainStartUp As Date = Date.MinValue
        Public warrantyCoin As Double = 0

        Public response As New CHCProtocol.AreaCommon.Models.General.RemoteResponse

    End Class


End Namespace

