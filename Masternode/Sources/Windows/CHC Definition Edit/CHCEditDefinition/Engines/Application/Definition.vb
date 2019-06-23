Option Compare Text
Option Explicit On





Namespace CryptoHideCoinEditDefinition


    ' Release 1.3 - Type of element

    Public Class SystemDefinition


        Private m_dt_StartNetwork As DateTime = DateTime.MinValue



        Public Class ConsensusConfiguration

            Public Enum EnumUnitMeasure

                NotDefined
                Days
                Hours
                Minutes

            End Enum

            Public Property UnitOfMeasure As EnumUnitMeasure = ConsensusConfiguration.EnumUnitMeasure.Hours
            Public Property Interval As Byte = 24
            Public Property Start As Byte = 1
            Public Property Durate As Byte = 30
            Public Property DurateUnitOfMeasure As EnumUnitMeasure = ConsensusConfiguration.EnumUnitMeasure.Minutes

        End Class

        Public Enum EnumEntityType

            NotDefined
            COIN
            TOKEN

        End Enum

        Public ReadOnly Property Identity As String
            Get

                Dim lngTotalHash As Long = 0

                lngTotalHash += NetworkName.GetHashCode()
                lngTotalHash += Type.ToString.GetHashCode()
                lngTotalHash += Name.GetHashCode()
                lngTotalHash += ShortName.GetHashCode()
                lngTotalHash += Symbol.GetHashCode()
                lngTotalHash += ConsensusTypeDescription.GetHashCode()
                lngTotalHash += ProtocolNameDescription.GetHashCode()
                lngTotalHash += DateStartNetwork.GetHashCode()
                lngTotalHash += Burnable.GetHashCode()
                lngTotalHash += PreminedNumber.GetHashCode()
                lngTotalHash += Total.GetHashCode()
                lngTotalHash += WalletAddressPremined.GetHashCode()
                lngTotalHash += CreationBlockIntervalMinute.GetHashCode()
                lngTotalHash += NodeConsensusQuorumMinimal.GetHashCode()
                lngTotalHash += NodeLayerConsensusConfiguration.Start.GetHashCode()
                lngTotalHash += NodeLayerConsensusConfiguration.Interval.GetHashCode()

                Return lngTotalHash

            End Get
        End Property

        Public Property NetworkName As String = "Crypto Hide Coin Decentralized Trustless Network Main v.1"
        Public Property [Type] As EnumEntityType = EnumEntityType.COIN
        Public Property [Name] As String = "Crypto Hide Coin"
        Public Property ShortName As String = "CHCS"
        Public Property Symbol As String = "§"

        Public Property ConsensusTypeDescription As String = "Proof Of Stake"
        Public Property ProtocolNameDescription As String = "CHCPTs"

        Public Property DateStartNetwork As DateTime
            Get
                Return m_dt_StartNetwork
            End Get
            Set(value As DateTime)
                m_dt_StartNetwork = value

                NodeLayerConsensusConfiguration.Start = m_dt_StartNetwork.ToUniversalTime.Hour()
            End Set
        End Property

        Public Property [Burnable] As Boolean = False
        Public Property Mintable As Boolean = False
        Public Property NoLimit As Boolean = False
        Public Property NumberOfDecimal As Byte = 8
        Public Property PreminedNumber As Decimal = 250000000
        Public Property Total As Decimal = 1300000000
        Public Property WalletAddressPremined As String = "CHC-DT-0:MkZRkncP6QFu7TH7Pem9qhU8YJNnuBKuCRBpKJSodk7vPRuKSw1ZxpLTKX6AKMqMpdoPhz98wJaoeb9UQaw79yaf"

        Public Property CreationBlockIntervalMinute As Byte = 10
        Public Property NodeConsensusQuorumMinimal As Double = 66.67

        Public Property NodeLayerConsensusConfiguration As New ConsensusConfiguration



    End Class



    Public Class SystemDefinitionEngine

        Inherits AreaInfrastructure.Secure.BaseEncryption(Of SystemDefinition)




        Public Sub CreateFileName(ByVal Path As String, ByVal FileName As String)

            MyBase.FileName = IO.Path.Combine(Path, FileName)

        End Sub

    End Class


End Namespace
