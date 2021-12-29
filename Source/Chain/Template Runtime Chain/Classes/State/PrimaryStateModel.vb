Option Compare Text
Option Explicit On



Namespace AreaState.PrimaryStateModel

    ''' <summary>
    ''' This class contain the last identify of last transaction and a value
    ''' </summary>
    Public Class ItemIdentityStructure
        Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        Public Property value As String = ""
    End Class

    ''' <summary>
    ''' This class contain the last identity of last transaction and a value
    ''' </summary>
    Public Class ParameterIdentityStructure
        Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Chain.ChainParameterModel
    End Class

    ''' <summary>
    ''' This class contain all information reguard of complete asset information
    ''' </summary>
    Public Class AssetStructure
        Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.AssetConfigurationModel
    End Class

    ''' <summary>
    ''' This class contain the complete information of a network transaction structure
    ''' </summary>
    Public Class NetworkTransactionStructure
        Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.TransactionChainModel
    End Class

    ''' <summary>
    ''' This class contain the complete information of a refund plan
    ''' </summary>
    Public Class NetworkRefundItemListStructure
        Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.RefundItemList
    End Class

    ''' <summary>
    ''' This class contain all element of a network
    ''' </summary>
    Public Class DataNetwork

        Public Property networkName As New ItemIdentityStructure
        Public Property envinronment As New ItemIdentityStructure
        Public Property whitePaper As New ItemIdentityStructure
        Public Property yellowPaper As New ItemIdentityStructure
        Public Property primaryAssetData As New AssetStructure
        Public Property transactionChainSettings As New NetworkTransactionStructure
        Public Property privacyPolicy As New ItemIdentityStructure
        Public Property generalConditions As New ItemIdentityStructure

        Public Property refundPlan As New NetworkRefundItemListStructure

        Public Property networkCreationDate As Double = 0

        Public Property genesisPublicAddress As String = ""

        Public ReadOnly Property hash() As String
            Get
                Return networkName.progressiveHash
            End Get
        End Property
    End Class

    ''' <summary>
    ''' This class contain the Price List elements
    ''' </summary>
    Public Class ChainPriceListStructure
        Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        Public Property value As New CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel
    End Class

    ''' <summary>
    ''' This class contain the element of node list chain
    ''' </summary>
    Public Class NodeListChainStructure
        Inherits CHCCommonLibrary.AreaCommon.Models.General.IdentifyLastTransaction

        Public Property value As New List(Of AreaProtocol.NodeComplete)

    End Class

End Namespace