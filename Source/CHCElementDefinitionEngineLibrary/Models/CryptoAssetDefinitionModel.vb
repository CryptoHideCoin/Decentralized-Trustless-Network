﻿Option Compare Text
Option Explicit On





Namespace Models



    Public Class CryptoAssetModel

        Public Enum EnumEntityType

            notDefined
            coin
            token

        End Enum


        Public Property [type] As EnumEntityType = EnumEntityType.coin
        Public Property [name] As String = "Crypto Hide Coin DTN"
        Public Property shortName As String = "CHCS"
        Public Property symbol As String = "§"
        Public Property burnable As Boolean = False
        Public Property mintable As Boolean = False
        Public Property limitless As Boolean = False
        Public Property numberOfDecimal As Byte = 8
        Public Property preminedNumber As Decimal = 250000000
        Public Property total As Decimal = 1300000000
        Public Property isUsed As Boolean = False



        Public Overrides Function toString() As String

            Dim tmp As String = ""

            If burnable Then tmp += "x"
            If limitless Then tmp += "x"
            If mintable Then tmp += "x"

            tmp += name
            tmp += numberOfDecimal.ToString()
            tmp += preminedNumber.ToString()
            tmp += shortName
            tmp += symbol
            tmp += total.ToString()
            tmp += type.ToString()

            Return tmp

        End Function


        Public Function getHash() As String

            Return CHCCommonLibrary.CHCEngines.Encryption.HashSHA.generateSHA256(Me.toString())

        End Function



        Public Function copyIntoBaseModel() As CryptoAssetRequestModel

            Dim tmp As New CryptoAssetRequestModel

            tmp.burnable = burnable
            tmp.limitless = limitless
            tmp.mintable = mintable
            tmp.name = name
            tmp.numberOfDecimal = numberOfDecimal
            tmp.preminedNumber = preminedNumber
            tmp.shortName = shortName
            tmp.symbol = symbol
            tmp.total = total
            tmp.type = type

            Return tmp

        End Function


    End Class


    Public Class CryptoAssetRequestModel

        Inherits CryptoAssetModel

        Public [keywords] As String = ""
        Public configurationName As String = ""

    End Class




End Namespace
