Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCProtocolLibrary.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.Base.CHCStringExtensions



Namespace AreaCommon.Models.Define


    Public Class CryptoAssetBaseModel

        Public name As String = ""
        Public shortName As String = ""
        Public symbol As String = ""
        Public burnable As Boolean = False
        Public mintable As Boolean = False
        Public limitless As Boolean = False
        Public decimalDisplay As Byte = 0
        Public totalCoin As Double = 0


        Public Sub codeSymbol()
            symbol.codeSymbol()
        End Sub

        Public Sub deCodeSymbol()
            symbol.decodeSymbol()
        End Sub


        Public Overrides Function toString() As String

            Dim tmp As String = ""

            If burnable Then tmp += "1" Else tmp += "0"
            If limitless Then tmp += "1" Else tmp += "0"
            If mintable Then tmp += "1" Else tmp += "0"

            tmp += decimalDisplay.ToString()
            tmp += name
            tmp += shortName
            tmp += symbol
            tmp += totalCoin.ToString()

            Return tmp

        End Function

        Public Function getHash() As String

            Return HashSHA.generateSHA256(Me.toString())

        End Function


    End Class

    Public Class CryptoAssetModel

        Inherits CryptoAssetBaseModel

        Public identity As String = ""

    End Class

    Public Class CryptoAssetResponseModel

        Inherits CryptoAssetModel

        Public response As New General.RemoteResponse

    End Class


    Public Class GenericPaperBaseModel

        Public name As String = ""
        Public content As String = ""

        Public Sub codeSymbol()
            content.codeSymbol()
        End Sub

        Public Sub deCodeSymbol()
            content.decodeSymbol()
        End Sub


        Public Overrides Function toString() As String

            Dim tmp As String = ""

            tmp += name
            tmp += content

            Return tmp

        End Function

        Public Function getHash() As String

            Return HashSHA.generateSHA256(Me.toString())

        End Function

    End Class

    Public Class GenericPaperModel

        Inherits GenericPaperBaseModel

        Public identity As String = ""

    End Class

    Public Class GenericPaperResponseModel

        Inherits GenericPaperModel

        Public response As New General.RemoteResponse

    End Class


    Public Class ReferenceModel

        Public code As String = ""
        Public description As String = ""


        Public Overrides Function toString() As String

            Dim tmp As String = ""

            tmp += code
            tmp += description

            Return tmp

        End Function

    End Class

    Public Class ReferenceProtocolBaseModel

        Public name As String = ""
        Public releaseProtocol As String = ""

        Public references As New List(Of ReferenceModel)

        Public Overrides Function toString() As String

            Dim tmp As String = ""

            tmp += name
            tmp += releaseProtocol

            For Each reference In references
                tmp += reference.toString()
            Next

            Return tmp

        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class ReferenceProtocolModel

        Inherits ReferenceProtocolBaseModel

        Public Identity As String = ""

    End Class

    Public Class ReferenceProtocolResponseModel

        Inherits ReferenceProtocolModel

        Public response As New General.RemoteResponse

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

    End Class

    Public Class PriceTableBaseModel

        Public name As String = ""
        Public effectiveDate As Date = Date.MinValue
        Public items As New List(Of ItemPriceTableModel)


        Public Overrides Function toString() As String

            Dim tmp As String = ""

            tmp += name
            tmp += CHCCommonLibrary.AreaEngine.Miscellaneous.timestampFromDateTime(effectiveDate).ToString.Trim()

            For Each item In items
                tmp += item.toString()
            Next

            Return tmp

        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function


    End Class

    Public Class PriceTableModel

        Inherits PriceTableBaseModel

        Public identity As String = ""

    End Class

    Public Class PriceTableResponseModel

        Inherits PriceTableModel

        Public response As New General.RemoteResponse

    End Class


    Public Class RefundItem

        Public recipient As String = ""
        Public percentage As Double = 0
        Public fixValue As Decimal = 0

        Public Overrides Function toString() As String

            Dim tmp As String = ""

            tmp += recipient
            tmp += percentage.ToString()
            tmp += fixValue.ToString()

            Return tmp

        End Function

    End Class

    Public Class RefundGroup

        Public name As String = ""
        Public items As New List(Of RefundItem)
        Public percentage As Double = 0
        Public fixValue As Decimal = 0

        Public Overrides Function toString() As String

            Dim tmp As String = name

            tmp += percentage.ToString()
            tmp += fixValue.ToString()

            For Each item In items
                tmp += item.toString()
            Next

            Return tmp

        End Function

    End Class

    Public Class RefundPlanBaseModel

        Public name As String = ""
        Public effectiveDate As Date = Date.MinValue
        Public groups As New List(Of RefundGroup)


        Public Overrides Function toString() As String

            Dim tmp As String = ""

            tmp += name

            For Each item In groups
                tmp += item.toString()
            Next

            Return tmp

        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class RefundPlanModel

        Inherits RefundPlanBaseModel

        Public identity As String = ""

    End Class

    Public Class RefundPlanResponseModel

        Inherits RefundPlanModel

        Public response As New General.RemoteResponse

    End Class


    Public Class ItemKeyDescriptionModel

        Public identity As String = ""
        Public name As String = ""

        Public response As New General.RemoteResponse

    End Class


    Public Enum EnumMode
        testNet
        official
    End Enum

    Public Class TiersOfRewards

        Public [from] As Double = 0
        Public distribute As Double = 0


        Public Overrides Function toString() As String

            Dim tmp As String = [from].ToString

            tmp += distribute.ToString()

            Return tmp

        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class ChainBaseModel

        Public name As String = ""
        Public uniqueChainKey As String = ""
        Public type As EnumMode = EnumMode.official

        Public visionPaperId As String = ""
        Public whitePaperId As String = ""
        Public yellowPaperId As String = ""
        Public privacyPaperId As String = ""
        Public termsAndConditionsId As String = ""
        Public assetId As String = ""
        Public priceListId As String = ""
        Public refundPlanId As String = ""

        Public preminedCoin As Double = 0
        Public walletAddressPremined As String = ""

        Public rewardPlan As New List(Of TiersOfRewards)


        Public Overrides Function toString() As String

            Dim tmp As String = name

            tmp += uniqueChainKey
            tmp += type.ToString
            tmp += visionPaperId
            tmp += whitePaperId
            tmp += yellowPaperId
            tmp += privacyPaperId
            tmp += termsAndConditionsId
            tmp += assetId
            tmp += priceListId
            tmp += refundPlanId
            tmp += preminedCoin.ToString()
            tmp += walletAddressPremined

            For Each item In rewardPlan
                tmp += item.toString()
            Next

            Return tmp

        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    Public Class ChainModel

        Inherits ChainBaseModel

        Public identity As String = ""

    End Class

    Public Class ChainResponseModel

        Inherits ChainModel

        Public response As New General.RemoteResponse

    End Class


End Namespace