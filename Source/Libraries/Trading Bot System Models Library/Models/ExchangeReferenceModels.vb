Option Compare Text
Option Explicit On

' ****************************************
' Engine: Exchange Reference Model
' Release Engine: 1.0 
' 
' Date last successfully test: 10/06/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaModel.Exchange

    ''' <summary>
    ''' This class contain the data of an Exchange Reference
    ''' </summary>
    Public Class ExchangeReferenceStructure

        Public Enum TypeReferenceEnumeration
            undefined
            homePage
            mainApiReferement
            apiCurrencies
            apiCurrenciesHelp
        End Enum

        Public Property exchangeId As Integer = 0
        Public Property urlType As TypeReferenceEnumeration = TypeReferenceEnumeration.undefined
        Public Property url As String = ""

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += urlType
            tmp += url

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the exchange reference list response
    ''' </summary>
    Public Class ExchangeReferenceListResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of ExchangeReferenceStructure)
    End Class

    ''' <summary>
    ''' This class contain the exchange reference data response model
    ''' </summary>
    Public Class ExchangeReferenceResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New ExchangeReferenceStructure
    End Class

End Namespace
