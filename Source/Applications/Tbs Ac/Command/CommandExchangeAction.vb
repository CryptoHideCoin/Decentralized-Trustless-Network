Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports TradingBotSystemModelsLibrary.AreaModel.Exchange




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command exchange action
    ''' </summary>
    Public Class CommandExchangeAction : Implements CommandModel

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
        ''' This method provide to read parameter
        ''' </summary>
        ''' <returns></returns>
        Private Function readParameter(ByRef parameter As ExchangeActionModel) As Boolean
            Try
                If _Command.haveParameter("exchangeId") Then
                    If IsNumeric(_Command.parameterValue("exchangeId")) Then
                        parameter.exchangeId = _Command.parameterValue("exchangeId")
                    End If
                Else
                    RaiseEvent RaiseError("Exchange id parameter missing")

                    Return False
                End If

                Return True
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during readParameter - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new exchange 
        ''' </summary>
        ''' <returns></returns>
        Private Function updateList() As Boolean
            Try
                Dim data As New ExchangeActionModel
                Dim remote As New ProxyWS(Of ExchangeActionModel)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = readParameter(data)
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchangeScheduleJob/?securityToken={_EngineService.securityToken}")

                    remote.data = data
                End If
                If proceed Then
                    proceed = (remote.sendData("POST").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command executed: {data.exchangeId} - {data.command}")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during updateList - " & ex.Message)

                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provide to get a data from an exchange
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Private Function getData() As Boolean
            Try
                Dim remote As New ProxyWS(Of ExchangeScheduleJobResponseModel)
                Dim data As New ExchangeScheduleJobModels
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
                    remote.url = _EngineService.buildURL($"/state/trade/exchangeScheduleJob/?securityToken={_EngineService.securityToken}&id={id}")
                End If
                If proceed Then
                    proceed = (remote.getData.Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    data = remote.data.value

                    RaiseEvent WriteLine($"Exchange Import Table informations")
                    RaiseEvent WriteLine($"==================================")
                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"Exchange id           : {data.exchangeId}")
                    RaiseEvent WriteLine($"Last currencies check : {data.lastCurrenciesCheck}")
                    RaiseEvent WriteLine($"Last products check   : {data.lastProductsCheck}")
                    RaiseEvent WriteLine($"Next currencies check : {data.nextCurrenciesCheck}")
                    RaiseEvent WriteLine($"Next products check   : {data.nextProductsCheck}")
                    RaiseEvent WriteLine("")
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command getData executed: {id}")
                Else
                    RaiseEvent WriteLine($"Command getData failed")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during getData - " & ex.Message)

                Return False
            End Try
        End Function


        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim proceed As Boolean = True
                Dim parameterCommand As String = ""

                If _Command.haveParameter("refreshCurrencyList") Then
                    parameterCommand = "refreshCurrencyList"
                ElseIf _Command.haveParameter("refreshProductsList") Then
                    parameterCommand = "refreshProductsList"
                ElseIf _Command.haveParameter("getData") Then
                    parameterCommand = "getData"
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
                        Case "refreshCurrencyList".ToLower() : Return updateList()
                        Case "refreshProductsList".ToLower() : Return updateList()
                        Case "getData".ToLower() : Return getData()
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
