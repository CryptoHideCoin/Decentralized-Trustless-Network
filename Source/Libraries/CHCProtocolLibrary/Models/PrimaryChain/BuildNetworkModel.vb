Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.Base.CHCStringExtensions



Namespace AreaCommon.Models.Network

    Public Class AssetModel

        Public Property name As String = ""
        Public Property shortName As String = ""
        Public Property symbol As String = ""
        Public Property qtaTotal As Decimal = 0
        Public Property digit As Byte = 0
        Public Property stakeable As Boolean = False
        Public Property prestake As Boolean = False
        Public Property burnable As Boolean = False
        Public Property nameUnit As String = ""
        Public Property qtaInitialStake As Decimal = 0

        Public Sub codeSymbol()
            symbol.codeSymbol()
        End Sub

        Public Sub deCodeSymbol()
            symbol.decodeSymbol()
        End Sub

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += name
            tmp += shortName
            tmp += symbol
            tmp += qtaTotal.ToString()
            tmp += digit.ToString()
            If stakeable Then tmp += "1" Else tmp += "0"
            If prestake Then tmp += "1" Else tmp += "0"
            If burnable Then tmp += "1" Else tmp += "0"
            tmp += nameUnit
            tmp += qtaInitialStake.ToString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class RefundItem

        Public Property recipient As String = ""
        Public Property description As String = ""
        Public Property percentageValue As Single = 0
        Public Property fixValue As Decimal = 0

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += recipient
            tmp += description
            tmp += percentageValue.ToString()
            tmp += fixValue.ToString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class RefundItemList

        Public Property items As New List(Of RefundItem)

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            For Each item In items
                tmp += item.toString()
            Next

            Return tmp
        End Function
    End Class

    Public Class TransactionChainModel

        Public Property blockSizeFrequency As String = "24h"
        Public Property numberBlockInVolume As Short = "365"
        Public Property initialMaxComputeTransaction As String = "60sec"
        Public Property initialCoinReleasePerBlock As Decimal = "100000"
        Public Property ruleFutureRelease As String = ""
        Public Property reviewReleaseAlgorithm As String = "OnTransaction"
        Public Property consensusMethod As String = "Proof Of Stake"

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += blockSizeFrequency
            tmp += numberBlockInVolume.ToString()
            tmp += initialMaxComputeTransaction
            tmp += initialCoinReleasePerBlock.ToString()
            tmp += reviewReleaseAlgorithm
            tmp += consensusMethod

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class ItemPriceTableModel

        Public code As String = ""
        Public description As String = ""
        Public contribute As Decimal = 0

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += code
            tmp += description
            tmp += contribute.ToString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class ItemPriceTableListModel

        Public Property items As New List(Of ItemPriceTableModel)

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            For Each item In items
                tmp += item.toString()
            Next

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class BuildNetworkModel

        Public Property name As String = ""
        Public Property publicAddressGenesis As String = ""
        Public Property whitePaper As New Document.DocumentModel
        Public Property yellowPaper As New Document.DocumentModel
        Public Property primaryAsset As New AssetModel
        Public Property transactionChainParameter As New TransactionChainModel
        Public Property refundPlan As New RefundItemList
        Public Property privacyPolicy As New Document.DocumentModel
        Public Property generalCondition As New Document.DocumentModel
        Public Property signature As String = ""



        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += name
            tmp += publicAddressGenesis
            tmp += whitePaper.toString()
            tmp += yellowPaper.toString()
            tmp += primaryAsset.toString()
            tmp += transactionChainParameter.toString()
            tmp += refundPlan.toString()
            tmp += privacyPolicy.toString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

End Namespace