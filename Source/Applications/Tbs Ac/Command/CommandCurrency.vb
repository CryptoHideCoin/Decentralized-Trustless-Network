Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports TradingBotSystemModelsLibrary.AreaModel.Currency




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command currency
    ''' </summary>
    Public Class CommandCurrency : Implements CommandModel

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
        ''' This method provide to get a list of a exchange
        ''' </summary>
        ''' <returns></returns>
        Private Function getList() As Boolean
            Try
                Dim remote As New ProxyWS(Of CurrencyListResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/currency/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.getData().Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    Dim numExchange As Integer = 0

                    RaiseEvent WriteLine($"Currency list result:")
                    RaiseEvent WriteLine($"=====================")
                    RaiseEvent WriteLine("")

                    For Each item In remote.data.value
                        RaiseEvent WriteLine($"{item.id} - {item.shortName}")

                        numExchange += 1
                    Next

                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"({numExchange}) Total item(s)")
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

        ''' <summary>
        ''' This method provide to execute add new command
        ''' </summary>
        ''' <returns></returns>
        Private Function readParameter(ByRef parameter As CurrencyStructure) As Boolean
            Try
                If _Command.haveParameter("shortName") Then
                    parameter.shortName = _Command.parameterValue("shortName").ToUpper
                Else
                    RaiseEvent RaiseError("Exchange short name parameter missing")

                    Return False
                End If

                If _Command.haveParameter("name") Then
                    parameter.name = StrConv(_Command.parameterValue("name"), VbStrConv.ProperCase)
                End If
                If _Command.haveParameter("displayName") Then
                    parameter.displayName = StrConv(_Command.parameterValue("displayName"), VbStrConv.ProperCase)
                End If
                If _Command.haveParameter("tipology") Then
                    Select Case _Command.parameterValue("tipology")
                        Case "1", "fiat" : parameter.tipology = CurrencyStructure.tipologyAsset.fiat
                        Case "2", "crypto" : parameter.tipology = CurrencyStructure.tipologyAsset.crypto
                        Case Else : parameter.tipology = CurrencyStructure.tipologyAsset.undefined
                    End Select
                End If
                If _Command.haveParameter("minSize") Then
                    parameter.minSize = _Command.parameterValue("minSize")
                End If
                If _Command.haveParameter("maxPrecision") Then
                    parameter.maxPrecision = _Command.parameterValue("maxPrecision")
                End If
                If _Command.haveParameter("symbol") Then
                    parameter.symbol = _Command.parameterValue("symbol")
                End If
                If _Command.haveParameter("nature") Then
                    Select Case _Command.parameterValue("nature").ToString()
                        Case "1", "coin" : parameter.nature = CurrencyStructure.natureAsset.coin
                        Case "2", "stablecoin" : parameter.nature = CurrencyStructure.natureAsset.stableCoin
                        Case "3", "token" : parameter.nature = CurrencyStructure.natureAsset.token
                        Case Else : parameter.nature = CurrencyStructure.natureAsset.undefined
                    End Select
                End If
                If _Command.haveParameter("networkReferement") Then
                    parameter.networkReferement = _Command.parameterValue("networkReferement")
                End If
                If _Command.haveParameter("contractNetwork") Then
                    parameter.contractNetwork = _Command.parameterValue("contractNetwork")
                End If

                Return True
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during readAddNewParameter - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to add a new currency 
        ''' </summary>
        ''' <returns></returns>
        Private Function addNew() As Boolean
            Try
                Dim data As New CurrencyStructure
                Dim remote As New ProxyWS(Of CurrencyStructure)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = readParameter(data)

                    data.codeSymbol()
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/currency/?securityToken={_EngineService.securityToken}")

                    remote.data = data

                    remote.standardize()
                End If
                If proceed Then
                    proceed = (remote.sendData("POST").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command addNew executed: {data.shortName}")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during addNew - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a current parameter
        ''' </summary>
        ''' <param name="parameter"></param>
        ''' <returns></returns>
        Private Function getCurrentParameter(ByRef parameter As CurrencyStructure) As Boolean
            Try
                Dim remote As New ProxyWS(Of CurrencyResponseModel)
                Dim proceed As Boolean = True

                If _Command.haveParameter("id") Then
                    parameter.id = _Command.parameterValue("id")
                Else
                    RaiseEvent RaiseError("Current id parameter missing")

                    Return False
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/currency/?securityToken={_EngineService.securityToken}&id={parameter.id}")
                End If
                If proceed Then
                    proceed = (remote.getData.Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    parameter.name = remote.data.value.name
                    parameter.acquireTimeStamp = remote.data.value.acquireTimeStamp
                    parameter.contractNetwork = remote.data.value.contractNetwork
                    parameter.displayName = remote.data.value.displayName
                    parameter.id = remote.data.value.id
                    parameter.isUsed = remote.data.value.isUsed
                    parameter.maxPrecision = remote.data.value.maxPrecision
                    parameter.minSize = remote.data.value.minSize
                    parameter.nature = remote.data.value.nature
                    parameter.networkReferement = remote.data.value.networkReferement
                    parameter.shortName = remote.data.value.shortName
                    parameter.source = remote.data.value.source
                    parameter.supplier = remote.data.value.supplier
                    parameter.symbol = remote.data.value.symbol
                    parameter.tipology = remote.data.value.tipology
                    parameter.unitName = remote.data.value.unitName
                Else
                    RaiseEvent RaiseError($"Command getData failed")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during getCurrentParameter - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to update data from a parameter's
        ''' </summary>
        ''' <returns></returns>
        Private Function update() As Boolean
            Try
                Dim data As New CurrencyStructure
                Dim remote As New ProxyWS(Of CurrencyStructure)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = getCurrentParameter(data)
                End If
                If proceed Then
                    proceed = readParameter(data)
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}")

                    remote.data = data
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command update executed: {data.shortName}")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during update - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete a precisious id of unused exchange id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Private Function delete(ByVal id As Integer) As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/currency/?securityToken={_EngineService.securityToken}&id={id}")
                End If
                If proceed Then
                    proceed = (remote.sendData("DELETE").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command delete executed: {id}")
                Else
                    RaiseEvent WriteLine($"Command delete failed")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during delete - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a data from an exchange
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Private Function getData(ByVal id As Integer) As Boolean
            Try
                Dim remote As New ProxyWS(Of CurrencyResponseModel)
                Dim data As CurrencyResponseModel
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/currency/?securityToken={_EngineService.securityToken}&id={id}")
                End If
                If proceed Then
                    proceed = (remote.getData.Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    data = remote.data

                    RaiseEvent WriteLine($"Currency information")
                    RaiseEvent WriteLine($"====================")
                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"Id                   : {data.value.id}")
                    RaiseEvent WriteLine($"Short name           : {data.value.name}")
                    RaiseEvent WriteLine($"Name                 : {data.value.shortName}")
                    RaiseEvent WriteLine($"Display name         : {data.value.displayName}")
                    RaiseEvent WriteLine($"Tipology             : {data.value.tipology}")
                    RaiseEvent WriteLine($"Min Size             : {data.value.minSize}")
                    RaiseEvent WriteLine($"Max Precision        : {data.value.maxPrecision}")
                    RaiseEvent WriteLine($"Symbol               : {data.value.symbol}")
                    RaiseEvent WriteLine($"Source               : {data.value.source}")
                    RaiseEvent WriteLine($"Supplier             : {data.value.supplier}")
                    RaiseEvent WriteLine($"Crypto tipology      : {data.value.nature}")
                    RaiseEvent WriteLine($"Network referement   : {data.value.networkReferement}")
                    RaiseEvent WriteLine($"Contract             : {data.value.contractNetwork}")
                    RaiseEvent WriteLine($"Acquire timestamp    : {data.value.acquireTimeStamp}")
                    RaiseEvent WriteLine($"Is used              : {data.value.isUsed}")

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
                Dim shortNameValue As String = ""
                Dim nameValue As String = ""
                Dim displayNameValue As String = ""
                Dim tipologyValue As String = ""
                Dim minSizeValue As String = ""
                Dim maxPrecisionValue As String = ""
                Dim symbolValue As String = ""
                Dim sourceValue As String = ""

                If _Command.haveParameter("list") Then
                    parameterCommand = "list"
                ElseIf _Command.haveParameter("addNew") Then
                    parameterCommand = "addNew"
                ElseIf _Command.haveParameter("update") Then
                    parameterCommand = "update"
                ElseIf _Command.haveParameter("delete") Then
                    parameterCommand = "delete"
                ElseIf _Command.haveParameter("getData") Then
                    parameterCommand = "getData"
                End If

                If (parameterCommand.Length = 0) Then
                    RaiseEvent WriteLine("Action not set!")

                    proceed = False
                End If

                If proceed Then
                    proceed = _EngineService.Init(_Command, CHCCommandlineSupport.AreaCommon.defaultParameters)
                End If

                If proceed Then
                    Select Case parameterCommand.ToLower()
                        Case "list".ToLower()
                            If Not getList() Then
                                RaiseEvent WriteLine("Problem during get a list of currencies")

                                proceed = False
                            End If
                        Case "addNew".ToLower() : Return addNew()
                        Case "update" : Return update()
                        Case "delete"
                            If Not _Command.haveParameter("id") Then
                                RaiseEvent RaiseError("Id missing parameter's")

                                proceed = False
                            End If
                            If Not delete(_Command.parameterValue("id")) Then
                                RaiseEvent RaiseError("Problem during get a delete of currency")

                                proceed = False
                            End If
                        Case "getData".ToLower()
                            If Not _Command.haveParameter("id") Then
                                RaiseEvent RaiseError("Id missing parameter's")

                                proceed = False
                            End If
                            If Not getData(_Command.parameterValue("id")) Then
                                RaiseEvent RaiseError("Problem during get data of currency")

                                proceed = False
                            End If
                    End Select
                End If

                Return proceed
            Catch ex As Exception
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
