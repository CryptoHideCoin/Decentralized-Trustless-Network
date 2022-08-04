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



Namespace AreaModel.Pair

    ''' <summary>
    ''' This class contain the data of a Pair
    ''' </summary>
    Public Class PairStructure

        Public Property id As Integer = 0
        Public Property [name] As String = ""
        Public Property baseCurrencyId As Integer = 0
        Public Property quoteCurrencyId As Integer = 0

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += [name]
            tmp += baseCurrencyId.ToString()
            tmp += quoteCurrencyId.ToString()

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

    ''' <summary>
    ''' This class contain the pair list response model
    ''' </summary>
    Public Class PairListResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New List(Of PairStructure)
    End Class

    ''' <summary>
    ''' This class contain the pair data response model
    ''' </summary>
    Public Class CurrencyResponseModel
        Inherits BaseRemoteResponse

        Public Property value As New PairStructure
    End Class

End Namespace
