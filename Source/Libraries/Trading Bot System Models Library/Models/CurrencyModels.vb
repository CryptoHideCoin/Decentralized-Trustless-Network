Option Compare Text
Option Explicit On

' ****************************************
' Engine: Exchange Model
' Release Engine: 1.0 
' 
' Date last successfully test: 07/06/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.Base.CHCStringExtensions



Namespace AreaModel.Currency

    ''' <summary>
    ''' This class contain the data of an Exchange
    ''' </summary>
    Public Class CurrencyStructure

        Public Enum tipologyAsset
            undefined
            fiat
            crypto
        End Enum

        Public Enum natureAsset
            undefined
            coin
            token
            stableCoin
        End Enum

        Public Property id As Integer = 0
        Public Property shortName As String = ""
        Public Property [name] As String = ""
        Public Property displayName As String = ""
        Public Property tipology As tipologyAsset = tipologyAsset.undefined
        Public Property minSize As Integer = 0
        Public Property maxPrecision As Integer = 0
        Public Property symbol As String = ""
        Public Property source As String = ""
        Public Property supplier As String = ""
        Public Property nature As natureAsset = natureAsset.undefined
        Public Property networkReferement As String = ""
        Public Property contractNetwork As String = ""
        Public Property unitName As String = ""
        Public Property acquireTimeStamp As Double = 0
        Public Property isUsed As Boolean = False

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += shortName
            tmp += [name]
            tmp += displayName
            tmp += Val(tipology).ToString()
            tmp += minSize.ToString()
            tmp += maxPrecision.ToString()
            tmp += symbol
            tmp += source
            tmp += supplier
            tmp += Val(nature).ToString()
            tmp += networkReferement
            tmp += contractNetwork
            tmp += unitName

            Return tmp
        End Function

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

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the currency list response model
    ''' </summary>
    Public Class CurrencyListResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of CurrencyStructure)
    End Class

    ''' <summary>
    ''' This class contain the asset data response model
    ''' </summary>
    Public Class CurrencyResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New CurrencyStructure
    End Class

End Namespace
