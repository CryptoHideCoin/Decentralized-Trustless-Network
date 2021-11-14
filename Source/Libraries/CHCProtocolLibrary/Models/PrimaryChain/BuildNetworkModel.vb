Option Explicit On
Option Compare Text

' ****************************************
' File: Network Builder Model
' Release Engine: 1.1
' 
' Date last successfully test: 11/11/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.Base.CHCStringExtensions







Namespace AreaCommon.Models.Network

    ''' <summary>
    ''' This method provide to contain the essential data of a network
    ''' </summary>
    Public Class BaseNetworkModel

        Public Property netName As String = ""
        Public Property specialEnvironment As String = ""


        ''' <summary>
        ''' This method provide to convert into a string the element of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += netName
            tmp += specialEnvironment

            Return tmp
        End Function

        ''' <summary>
        ''' This methdo provide to get an hash of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain all member relative an element of Asset type
    ''' </summary>
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

        ''' <summary>
        ''' This method provide to code symbol to trasmit with a webservice
        ''' </summary>
        <DebuggerHiddenAttribute()> Public Sub codeSymbol()
            symbol.codeSymbol()
        End Sub

        ''' <summary>
        ''' This method provide to decoce symbol when receive a data with a webservice
        ''' </summary>
        <DebuggerHiddenAttribute()> Public Sub deCodeSymbol()
            symbol.decodeSymbol()
        End Sub

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
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

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the item of refund
    ''' </summary>
    Public Class RefundItem

        Public Property identity As String = ""
        Public Property levelStructure As Byte = 0
        Public Property parentIdentity As String = ""
        Public Property recipient As String = ""
        Public Property description As String = ""
        Public Property percentageValue As Single = 0
        Public Property fixValue As Decimal = 0

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += identity
            tmp += levelStructure.ToString
            tmp += parentIdentity
            tmp += recipient
            tmp += description
            tmp += percentageValue.ToString()
            tmp += fixValue.ToString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This refund Item list contain all element of a refund plan
    ''' </summary>
    Public Class RefundItemList

        Public Property code As String = ""
        Public Property items As New List(Of RefundItem)

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = code

            For Each item In items
                tmp += item.toString()
            Next

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the element of a transaction chain configuration
    ''' </summary>
    Public Class TransactionChainModel

        Public Property blockSizeFrequency As String = "24h"
        Public Property numberBlockInVolume As Short = 365
        Public Property initialMaxComputeTransaction As String = "300sec"
        Public Property initialCoinReleasePerBlock As Decimal = "100000"
        Public Property ruleFutureRelease As String = ""
        Public Property reviewReleaseAlgorithm As String = "OnTransaction"
        Public Property consensusMethod As String = "Proof Of Stake"

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += blockSizeFrequency
            tmp += numberBlockInVolume.ToString()
            tmp += initialMaxComputeTransaction
            tmp += initialCoinReleasePerBlock.ToString()
            tmp += reviewReleaseAlgorithm
            tmp += consensusMethod

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the information relative the item of a price
    ''' </summary>
    Public Class ItemPriceTableModel

        Public code As String = ""
        Public description As String = ""
        Public contribute As Decimal = 0

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += code
            tmp += description
            tmp += contribute.ToString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to clone this object
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As ItemPriceTableModel
            Dim result As New ItemPriceTableModel

            result.code = Me.code
            result.description = Me.description
            result.contribute = Me.contribute

            Return result
        End Function

    End Class

    ''' <summary>
    ''' This class contain the collection of Item Price of a table
    ''' </summary>
    Public Class ItemPriceTableListModel

        Public Property code As String = ""
        Public Property items As New List(Of ItemPriceTableModel)

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = code

            For Each item In items
                tmp += item.toString()
            Next

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overridable Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

        ''' <summary>
        ''' This method provide to clone the object into another
        ''' </summary>
        ''' <returns></returns>
        Public Function clone() As ItemPriceTableListModel
            Dim result As New ItemPriceTableListModel

            result.code = Me.code

            For Each item In items
                result.items.Add(item.clone())
            Next

            Return result
        End Function

    End Class

    ''' <summary>
    ''' This class contain all information relative a builder of a network
    ''' </summary>
    Public Class BuildNetworkModel

        Public Property informationBase As New BaseNetworkModel
        Public Property publicAddressGenesis As String = ""
        Public Property whitePaper As New Document.DocumentModel
        Public Property yellowPaper As New Document.DocumentModel
        Public Property primaryAsset As New AssetModel
        Public Property transactionChainParameter As New TransactionChainModel
        Public Property refundPlan As New RefundItemList
        Public Property privacyPolicy As New Document.DocumentModel
        Public Property generalCondition As New Document.DocumentModel
        Public Property signature As String = ""

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += informationBase.netName
            tmp += informationBase.specialEnvironment
            tmp += publicAddressGenesis
            tmp += whitePaper.toString()
            tmp += yellowPaper.toString()
            tmp += primaryAsset.toString()
            tmp += transactionChainParameter.toString()
            tmp += refundPlan.toString()
            tmp += privacyPolicy.toString()

            Return tmp
        End Function

        ''' <summary>
        ''' This method provide to get hash value from a string of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

End Namespace