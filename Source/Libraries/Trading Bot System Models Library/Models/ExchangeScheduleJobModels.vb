Option Compare Text
Option Explicit On

' ****************************************
' Engine: Exchange Model
' Release Engine: 1.0 
' 
' Date last successfully test: 10/07/2022
' ****************************************

Imports CHCModelsLibrary.AreaModel.Network.Response



Namespace AreaModel.Exchange

    ''' <summary>
    ''' This class contain the data of a schedule job models
    ''' </summary>
    Public Class ExchangeScheduleJobModels

        Public Property exchangeId As Integer = 0
        Public Property lastCurrenciesCheck As Double = 0
        Public Property lastProductsCheck As Double = 0
        Public Property nextCurrenciesCheck As Double = 0
        Public Property nextProductsCheck As Double = 0

    End Class

    ''' <summary>
    ''' This method provide to determinate exchange action model
    ''' </summary>
    Public Class ExchangeActionModel

        Public Enum ActionEnumeration
            updateCurrencies
            updateProducts
        End Enum

        Public Property exchangeId As Integer = 0
        Public Property command As ActionEnumeration = ActionEnumeration.updateCurrencies

    End Class

    ''' <summary>
    ''' This class contain the exchange list response
    ''' </summary>
    Public Class ExchangeScheduleJobResponseModel
        Inherits BaseRemoteResponse

        Public Property value As ExchangeScheduleJobModels
    End Class


End Namespace
