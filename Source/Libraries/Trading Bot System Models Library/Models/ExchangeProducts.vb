Option Compare Text
Option Explicit On

' ****************************************
' Engine: Exchange Model
' Release Engine: 1.0 
' 
' Date last successfully test: 14/06/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.ExchangeProducts


    ''' <summary>
    ''' This class contain all properties relative a Exchange-Products
    ''' </summary>
    Public Class ExchangeProductsStructure

        Public Property exchangeId As Integer = 0
        Public Property name As String = ""
        Public Property displayName As String = ""
        Public Property baseCurrencyId As Integer = 0
        Public Property quoteCurrencyId As Integer = 0
        Public Property baseIncrement As Double = 0
        Public Property minMarketFunds As Double = 0
        Public Property marginEnabled As Boolean = False
        Public Property postOnly As Boolean = False
        Public Property limitOnly As Boolean = False
        Public Property cancelOnly As Boolean = False
        Public Property status As String = ""
        Public Property statusMessage As String = ""
        Public Property tradingDisabled As Boolean = False

    End Class

    ''' <summary>
    ''' This class contain all properties necessary to add a currency support to an exchange
    ''' </summary>
    Public Class ModifyExchangeCurrencySupportStructure

        Public Property exchangeId As Integer
        Public Property currencyId As Integer
        Public Property supportedType As TypeSupportedEnumeration = TypeSupportedEnumeration.supportedDirectly

    End Class

    ''' <summary>
    ''' This class contain the exchange currency list response
    ''' </summary>
    Public Class ExchangeCurrencyListResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of ExchangeCurrencySupportStructure)
    End Class

    ''' <summary>
    ''' This class contain the exchange currency data response model
    ''' </summary>
    Public Class ExchangeCurrencyResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New ExchangeCurrencySupportStructure
    End Class

End Namespace
