Option Compare Text
Option Explicit On





Namespace Models


    Public Class TransChainDefinitionModel

        Public Enum EnumTransChainMode

            notDefined
            official
            testNet

        End Enum

        Public Enum EnumTransChainType

            notDefined
            mainPlatform
            crowdfund

        End Enum


        Public Property [mode] As EnumTransChainMode = EnumTransChainMode.testNet
        Public Property [type] As EnumTransChainType = EnumTransChainType.mainPlatform

        Public Property crowdFundConfigurationName As String = ""
        Public Property [name] As String = "Crypto Hide Coin Official Platform"
        Public Property cryptoAssetID As String = ""

        Public Property scheduleFirstStart As Boolean = False
        Public Property dateFirstStart As DateTime = Nothing

        Public Property walletAddressPremined As String = ""

        Public Property consensusTypeDescription As String = "Proof Of Stake"
        Public Property protocolNameDescription As String = "CHCPTs"
        Public Property intervalConsensusStake As String = "24h"

        Public Property rewardForDays As Decimal = 0
        Public Property isUsed As Boolean = False




        Public Overrides Function toString() As String

            Dim tmp As String = ""

            tmp += [mode].ToString()
            tmp += [type].ToString()
            tmp += crowdFundConfigurationName
            tmp += [name]
            tmp += cryptoAssetID
            tmp += walletAddressPremined
            tmp += consensusTypeDescription
            tmp += protocolNameDescription
            tmp += intervalConsensusStake
            tmp += rewardForDays.ToString()

            Return tmp

        End Function


        Public Function getHash() As String

            Return CHCCommonLibrary.CHCEngines.Encryption.HashSHA.generateSHA256(Me.toString())

        End Function



        Public Function copyIntoBaseModel() As TransChainDefinitionRequestModel

            Dim tmp As New TransChainDefinitionRequestModel

            tmp.mode = [mode]
            tmp.type = [type]
            tmp.crowdFundConfigurationName = crowdFundConfigurationName
            tmp.name = [name]
            tmp.cryptoAssetID = cryptoAssetID
            tmp.consensusTypeDescription = consensusTypeDescription
            tmp.protocolNameDescription = protocolNameDescription
            tmp.walletAddressPremined = walletAddressPremined
            tmp.dateFirstStart = dateFirstStart
            tmp.scheduleFirstStart = scheduleFirstStart
            tmp.intervalConsensusStake = intervalConsensusStake
            tmp.rewardForDays = rewardForDays

            Return tmp

        End Function


    End Class


    Public Class TransChainDefinitionRequestModel

        Inherits TransChainDefinitionModel

        Public [keywords] As String = ""
        Public configurationName As String = ""

    End Class




End Namespace