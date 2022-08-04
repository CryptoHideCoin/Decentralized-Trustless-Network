Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports TradingBotSystemModelsLibrary.AreaModel.ExchangeCurrencies




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command exchange currency
    ''' </summary>
    Public Class CommandExchangeCurrency : Implements CommandModel

        Private Property _Command As CommandStructure
        Private WithEvents _EngineService As New AccessEngine

        Public Event WriteLine(ByVal message As String) Implements CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements CommandModel.RaiseError
        Public Event ReadKey() Implements CommandModel.ReadKey


        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        ''' <summary>
        ''' This method provide to get a data from an exchange
        ''' </summary>
        ''' <returns></returns>
        Private Function getList() As Boolean
            Try
                Dim remote As New ProxyWS(Of ExchangeCurrencyListResponseModel)
                Dim data As New List(Of ExchangeCurrencySupportStructure)
                Dim id As Integer = 0
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If _Command.haveParameter("exchangeId") Then
                    If IsNumeric(_Command.parameterValue("exchangeId")) Then
                        id = _Command.parameterValue("exchangeId")
                    End If
                Else
                    RaiseEvent RaiseError("Exchange id parameter missing")

                    Return False
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchangeCurrencies/?securityToken={_EngineService.securityToken}&exchangeId={id}")
                End If
                If proceed Then
                    proceed = (remote.getData.Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    data = remote.data.value

                    RaiseEvent WriteLine($"Exchange Currency Import Table informations")
                    RaiseEvent WriteLine($"===========================================")
                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"Exchange id           : {id}")
                    RaiseEvent WriteLine("")

                    For Each item In data
                        RaiseEvent WriteLine($"Currency id:{item.currencyId} - {item.supportedType} - {item.lastFound}")
                    Next

                    RaiseEvent WriteLine("")
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command getList executed: {id}")
                Else
                    RaiseEvent WriteLine($"Command getList failed")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during getList - " & ex.Message)

                Return False
            End Try
        End Function


        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim proceed As Boolean = True
                Dim parameterCommand As String = ""

                If _Command.haveParameter("list") Then
                    parameterCommand = "list"
                End If

                If (parameterCommand.Length = 0) Then
                    RaiseEvent RaiseError("Action not set!")

                    proceed = False
                End If

                If proceed Then
                    proceed = _EngineService.Init(_Command, CHCCommandlineSupport.AreaCommon.defaultParameters)
                End If

                If proceed Then
                    Select Case parameterCommand.ToLower()
                        Case "list".ToLower() : Return getList()
                    End Select
                End If

                Return proceed
            Catch ex As Exception
                RaiseEvent RaiseError($"Error occurence during CommandModel_Run {ex.Message}")

                Return False
            End Try
        End Function

        Private Sub _EngineService_RaiseError(message As String) Handles _EngineService.RaiseError
            RaiseEvent RaiseError(message)
        End Sub

        Private Sub _EngineService_LaunchIntegrityApplication(fileName As String) Handles _EngineService.LaunchIntegrityApplication
            RaiseEvent IntegrityApplication(fileName)
        End Sub
    End Class

End Namespace
