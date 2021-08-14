Option Compare Text
Option Explicit On




Namespace AreaState

    Public Class ChainStateEngine

        Public Class itemIdentityStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As String = ""
        End Class

        Public Class NetworkAssetStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.AssetModel
        End Class

        Public Class NetworkTransactionStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.TransactionChainModel
        End Class

        Public Class NetworkRefundItemListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.RefundItemList
        End Class

        Public Class ChainPriceListStructure
            Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyRecordLedger

            Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel
        End Class

        Public Class DataNetwork

            Public Property networkName As New itemIdentityStructure
            Public Property whitePaper As New itemIdentityStructure
            Public Property yellowPaper As New itemIdentityStructure
            Public Property primaryAssetData As New NetworkAssetStructure
            Public Property transactionChainSettings As New NetworkTransactionStructure
            Public Property privacyPolicy As New itemIdentityStructure
            Public Property generalCondition As New itemIdentityStructure

            Public Property refundPlan As New NetworkRefundItemListStructure

            Public Property networkCreationDate As Double = 0

            Public Property genesisPublicAddress As String = ""
        End Class

        Public Class DataChain

            Public Property name As New itemIdentityStructure
            Public Property description As New itemIdentityStructure
            Public Property protocolDocument As New itemIdentityStructure
            Public Property protocolSets As New List(Of itemIdentityStructure)
            Public Property priceLists As New ChainPriceListStructure
            Public Property privacyPolicy As New itemIdentityStructure
            Public Property generalCondition As New itemIdentityStructure

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

        Public Function addNewChain(ByVal name As String, ByVal ledgerCoordinate As String, ByVal ledgerHash As String) As DataChain
            Dim newValue As New DataChain

            newValue.name.value = name

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
