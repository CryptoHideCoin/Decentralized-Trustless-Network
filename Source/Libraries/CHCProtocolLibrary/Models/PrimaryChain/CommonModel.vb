Option Compare Text
Option Explicit On

' ****************************************
' File: Network General Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************


Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.Base.CHCStringExtensions



Namespace AreaCommon.Models.PrimaryChain


    ''' <summary>
    ''' This class contain all member relative an element of Asset type
    ''' </summary>
    Public Class AssetModel

        Public Enum AssetTypeEnum
            coin
            token
            nft
        End Enum

        Public Property name As String = ""
        Public Property shortName As String = ""
        Public Property symbol As String = ""
        Public Property digit As Byte = 0
        Public Property nameUnit As String = ""
        Public Property [type] As AssetTypeEnum = AssetTypeEnum.coin
        Public Property netWorkReferement As String = ""

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
            tmp += digit.ToString()
            tmp += nameUnit

            If [type] Then
                tmp += "1"
            Else
                tmp += "0"
            End If

            tmp += netWorkReferement

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
    ''' This class contain all information reguard the minting information
    ''' </summary>
    Public Class AssetPolicyModel

        Public Property shortAssetReferement As String = ""
        Public Property unlimited As Boolean = False
        Public Property burnable As Boolean = False
        Public Property qtaTotal As Decimal = 0
        Public Property stakeable As Boolean = False
        Public Property preStake As Boolean = False
        Public Property qtaInitialStake As Decimal = 0

        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += shortAssetReferement

            If unlimited Then tmp += "1" Else tmp += "0"
            If burnable Then tmp += "1" Else tmp += "0"

            tmp += qtaTotal.ToString()

            If stakeable Then tmp += "1" Else tmp += "0"
            If preStake Then tmp += "1" Else tmp += "0"

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
    ''' This class contain the information complete of the asset (data and mint)
    ''' </summary>
    Public Class AssetConfigurationModel

        Public Property assetInformation As New AssetModel
        Public Property assetPolicyInformation As New AssetPolicyModel


        ''' <summary>
        ''' This method provide to create a string summary of the member of a class
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += assetInformation.toString()
            tmp += assetPolicyInformation.toString()

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
