Option Compare Text
Option Explicit On



Namespace AreaCommon.Models.Define


    Public Enum EnumMode
        testNet
        official
    End Enum

    Public Class tiersOfRewards

        Public [from] As Double = 0
        Public distribute As Double = 0

    End Class

    Public Class ItemPriceListModel

        Public codeItem As String = ""
        Public contribute As String = ""

    End Class

    Public Class ItemDistribution

        Public item As String = ""
        Public percentage As Double = 0

    End Class

    Public Class GroupDistributions

        Public group As String = ""
        Public items As New List(Of ItemDistribution)
        Public percentage As Double = 0

    End Class


    Public Class CryptoAssetBaseModel

        Public name As String = ""
        Public shortName As String = ""
        Public symbol As String = ""
        Public burnable As Boolean = False
        Public mintable As Boolean = False
        Public limitless As Boolean = False
        Public decimalDisplay As Byte = 0
        Public totalCoin As Double = 0



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

            Return CHCCommonLibrary.CHCEngines.Encryption.HashSHA.generateSHA256(Me.toString())

        End Function


    End Class

    Public Class CryptoAssetModel

        Inherits CryptoAssetBaseModel

        Public identity As String = ""

    End Class

    Public Class CryptoAssetResponseModel

        Inherits CryptoAssetBaseModel

        Public identity As String = ""

        Public response As New AreaCommon.Models.General.RemoteResponse

    End Class

    Public Class CryptoAssetKeyDescriptionModel

        Public identity As String = ""
        Public name As String = ""

        Public response As New AreaCommon.Models.General.RemoteResponse

    End Class



    Public Class ChainBaseModel

        Public name As String = ""
        Public preminedCoin As Double = 0
        Public addressWalletPremined As String = ""
        Public autoStart As Boolean
        Public firstStart As Date = Date.MinValue
        Public rewardPerDay As New List(Of tiersOfRewards)

    End Class

    Public Class ChainModel

        Inherits ChainBaseModel

        Public identity As String = ""

        Public response As New AreaCommon.Models.General.RemoteResponse

    End Class


    Public Class PriceListBaseModel

        Public effectiveDate As Date = Date.MinValue
        Public items As New List(Of ItemPriceListModel)

    End Class

    Public Class PriceListModel

        Inherits PriceListBaseModel

        Public identity As String = ""

        Public response As New AreaCommon.Models.General.RemoteResponse

    End Class


    Public Class DistributionSchemeBaseModel

        Public effectiveDate As Date = Date.MinValue
        Public groupsDistributions As New List(Of GroupDistributions)

        Public explanationId As String = ""

    End Class

    Public Class DistributionSchemeModel

        Inherits DistributionSchemeBaseModel

        Public identity As String = ""

        Public response As New AreaCommon.Models.General.RemoteResponse

    End Class


    Public Class TransactionChainBaseConfiguration

        Public name As String = ""
        Public mode As EnumMode = EnumMode.testNet

        Public cryptoAssetId As String = ""
        Public chainId As String = ""
        Public priceListId As String = ""
        Public distributionId As String = ""
        Public whitePaperId As String = ""

    End Class

    Public Class TransactionChainConfiguration

        Inherits TransactionChainBaseConfiguration

        Public identity As String = ""

        Public response As New AreaCommon.Models.General.RemoteResponse

    End Class


End Namespace