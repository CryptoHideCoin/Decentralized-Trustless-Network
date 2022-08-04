Option Compare Text
Option Explicit On

' ****************************************
' Engine: Exchange Model
' Release Engine: 1.0 
' 
' Date last successfully test: 07/06/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.ExchangeCurrencies

    ''' <summary>
    ''' This enumeration is relative a type of supported
    ''' </summary>
    Public Enum TypeSupportedEnumeration
        undefined
        notSupported
        supportedDirectly
        supportedDecentralized
    End Enum

    ''' <summary>
    ''' This class contain all properties relative a Exchange-Currency
    ''' </summary>
    Public Class ExchangeCurrencySupportStructure

        Public Property exchangeId As Integer
        Public Property currencyId As Integer
        Public Property supportedType As TypeSupportedEnumeration = TypeSupportedEnumeration.notSupported
        Public Property lastFound As Double = 0

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
