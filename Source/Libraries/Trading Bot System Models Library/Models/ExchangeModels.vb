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



Namespace AreaModel.Exchange

    ''' <summary>
    ''' This class contain the data of an Exchange
    ''' </summary>
    Public Class ExchangeStructure

        Public Property id As Integer = 0
        Public Property [name] As String = ""
        Public Property isActive As Boolean = False
        Public Property lastCurrenciesCheck As Double = 0
        Public Property lastProductsCheck As Double = 0
        Public Property isCentralized As Boolean = False
        Public Property group As String = ""
        Public Property isUsed As Boolean = False

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += [name]
            If isActive Then
                tmp += "1"
            Else
                tmp += "0"
            End If
            If isCentralized Then
                tmp += "1"
            Else
                tmp += "0"
            End If
            tmp += group

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the data of a new Exchange
    ''' </summary>
    Public Class NewExchangeStructure

        Public Property [name] As String = ""
        Public Property isActive As Boolean = False
        Public Property isCentralized As Boolean = False
        Public Property group As String = ""

    End Class

    ''' <summary>
    ''' This class contain the data of an update Exchange
    ''' </summary>
    Public Class UpdateExchangeStructure

        Public Property id As Integer = 0
        Public Property [name] As String = ""
        Public Property isActive As Boolean = False
        Public Property isCentralized As Boolean = False
        Public Property group As String = ""

    End Class

    ''' <summary>
    ''' This class contain the exchange list response
    ''' </summary>
    Public Class ExchangeListResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of ExchangeStructure)
    End Class

    ''' <summary>
    ''' This class contain the exchange data response model
    ''' </summary>
    Public Class ExchangeResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New ExchangeStructure
    End Class

End Namespace
