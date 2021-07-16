Option Compare Text
Option Explicit On




Namespace AreaState

    Public Class ChainStateEngine

        Public Class DataNetwork

            Public Property networkName As String = ""
            Public Property whitePaper As String = ""
            Public Property yellowPaper As String = ""
            Public Property primaryAssetData As New CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel
            Public Property transactionChainSettings As New CHCProtocolLibrary.AreaCommon.Models.Network.TransactionChainModel
            Public Property policyPrivacy As String = ""
            Public Property generalCondition As String = ""
            Public Property refundPlan As CHCProtocolLibrary.AreaCommon.Models.Network.RefundItemList

            Public Property creationDateNetwork As Double = 0

        End Class

        Public Class DataChain

            Public Property name As String = ""
            Public Property description As String = ""
            Public Property protocolDocument As String = ""
            Public Property protocolSets As New List(Of String)
            Public Property priceLists As New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel
            Public Property policyPrivacy As String = ""
            Public Property generalCondition As String = ""

            Public Property creationDateLedger As Double = 0

        End Class

        Public Class DataPeer

            Public Enum roleMasterNode

                fullService
                light
                frontOffice
                consensus
                arbitration

            End Enum

            Public Property identityAddressWalletId As String = ""
            Public Property warrantyAddressWalletId As String = ""
            Public Property refundAddressWalletId As String = ""
            Public Property ipAddress As String = ""
            Public Property warrantyCoin As Decimal = 0
            Public Property chainName As String = ""
            Public Property role As roleMasterNode = roleMasterNode.arbitration
            Public Property startConnectionDate As DateTime
            Public Property dayConnection As Short = 0
            Public Property lastConnectionDate As DateTime

        End Class

        Public Class PeerKey

            Public Property chainName As String = ""
            Public Property identityAddressWalletId As String = ""

        End Class

        Public Function addNewChain(ByVal name As String) As DataChain
            Dim newValue As New DataChain

            newValue.name = name

            activeChains.Add(name, newValue)

            Return newValue
        End Function

        Public Function getDataChain(ByVal name As String) As DataChain
            If activeChains.ContainsKey(name) Then
                Return activeChains.Item(name)
            Else
                Return New DataChain
            End If
        End Function

        Public Function addNewPeer(ByVal chainName As String, ByVal publicAddress As String) As DataPeer
            Dim newValue As New DataPeer
            Dim newKey As New PeerKey

            newKey.chainName = chainName
            newKey.identityAddressWalletId = publicAddress

            newValue.identityAddressWalletId = publicAddress

            activePeers.Add(newKey, newValue)

            Return newValue
        End Function

        Public Function getDataPeer(ByVal chainName As String, ByVal publicAddress As String) As DataPeer
            Dim newKey As New PeerKey

            newKey.chainName = chainName
            newKey.identityAddressWalletId = publicAddress

            If activePeers.ContainsKey(newKey) Then
                Return activePeers.Item(newKey)
            Else
                Return New DataPeer
            End If
        End Function

        Public activeNetwork As New DataNetwork
        Public activeChains As New Dictionary(Of String, DataChain)
        Public activePeers As New Dictionary(Of PeerKey, DataPeer)

    End Class

End Namespace
