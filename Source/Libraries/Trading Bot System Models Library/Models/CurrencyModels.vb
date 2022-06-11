Option Compare Text
Option Explicit On

' ****************************************
' Engine: Exchange Model
' Release Engine: 1.0 
' 
' Date last successfully test: 07/06/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.Currency

    ''' <summary>
    ''' This class contain the data of an Exchange
    ''' </summary>
    Public Class CurrencyStructure

        Public Enum typologyAsset
            undefined
            fiat
            crypto
        End Enum

        Public Property id As Integer = 0
        Public Property shortName As String = ""
        Public Property [name] As String = ""
        Public Property displayName As String = ""
        Public Property tipology As typologyAsset = typologyAsset.undefined
        Public Property minSize As Integer = 0
        Public Property maxPrecision As Integer = 0
        Public Property symbol As String = ""
        Public Property source As String = ""
        Public Property supplier As String = ""
        Public Property acquireTimeStamp As Double = 0
        Public Property isUsed As Boolean = False

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
