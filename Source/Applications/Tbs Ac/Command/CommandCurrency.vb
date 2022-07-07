Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports TradingBotSystemModelsLibrary.AreaModel.Currency




Namespace AreaCommon.Command

    Public Class DataCurrency
        Public Property description As String = ""
        Public Property age As String = ""
    End Class

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
        ''' This method provide to add a new currency
        ''' </summary>
        ''' <param name="nameValue"></param>
        ''' <param name="displayNameValue"></param>
        ''' <param name="tipologyValue"></param>
        ''' <param name="minSizeValue"></param>
        ''' <param name="maxPrecisionValue"></param>
        ''' <param name="symbolValue"></param>
        ''' <param name="sourceValue"></param>
        ''' <returns></returns>
        Private Function addNew(ByVal shortNameValue As String, ByVal nameValue As String, ByVal displayNameValue As String, ByVal tipologyValue As String, ByVal minSizeValue As String, ByVal maxPrecisionValue As String, ByVal symbolValue As String, ByVal sourceValue As String) As Boolean
            Try
                Dim remote As New ProxyWS(Of DataCurrency) ', BaseRemoteResponse)
                Dim data As New DataCurrency
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                'data.shortName = shortNameValue
                'data.name = nameValue
                'data.displayName = displayNameValue

                'Select Case tipologyValue.ToLower
                '    Case "crypto".ToLower : data.tipology = CurrencyStructure.typologyAsset.crypto
                '    Case "fiat".ToLower : data.tipology = CurrencyStructure.typologyAsset.fiat
                '    Case Else : data.tipology = CurrencyStructure.typologyAsset.undefined
                'End Select

                'data.minSize = Val(minSizeValue)
                'data.maxPrecision = Val(maxPrecisionValue)
                'data.symbol = symbolValue
                'data.source = sourceValue

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/currency/?securityToken={_EngineService.securityToken}")

                    'remote.options = New CHCModelsLibrary.AreaModel.Network.Communication.Options With {
                    '            .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0",
                    '            .Headers = New System.Net.WebHeaderCollection From {
                    '                {"key", "value"}
                    '            }
                    '}

                End If
                If proceed Then
                    remote.data = data

                    'proceed = (remote.sendData(CHCModelsLibrary.AreaModel.Network.Communication.Method.Post).Length = 0)
                    proceed = (remote.sendData("POST").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command addNew executed: {nameValue}")
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
        ''' This method provide to update a name of exchange or isActive flag
        ''' </summary>
        ''' <param name="updateId"></param>
        ''' <param name="name"></param>
        ''' <param name="isActive"></param>
        ''' <returns></returns>
        Private Function update(ByVal updateId As Integer, ByVal name As String, ByVal isActive As String) As Boolean
            'Try
            '    Dim remote As New ProxyWS(Of ExchangeListResponseModel)
            '    Dim proceed As Boolean = True
            '    Dim isActiveValue As Integer = 0

            '    If (isActive.ToLower.CompareTo("true") = 0) Or (isActive.CompareTo("1") = 0) Then
            '        isActiveValue = 1
            '    Else
            '        isActiveValue = 0
            '    End If

            '    If proceed Then
            '        remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}&id={updateId}&name={name}&isActive={isActiveValue}")
            '    End If
            '    If proceed Then
            '        proceed = (remote.sendData("PUT").Length = 0)
            '    End If
            '    If proceed Then
            '        proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            '    End If
            '    If proceed Then
            '        RaiseEvent WriteLine($"Command update executed: {name} - {isActive}")
            '    Else
            '        RaiseEvent WriteLine($"Command update failed")
            '    End If

            '    Return proceed
            'Catch exFile As System.IO.FileLoadException
            '    RaiseEvent IntegrityApplication(exFile.FileName)

            '    Return False
            'Catch ex As Exception
            '    RaiseEvent RaiseError("Error during update - " & ex.Message)

            '    Return False
            'End Try
        End Function

        ''' <summary>
        ''' This method provide to delete a precisious id of unused exchange id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Private Function delete(ByVal id As Integer) As Boolean
            'Try
            '    Dim remote As New ProxyWS(Of ExchangeListResponseModel)
            '    Dim proceed As Boolean = True
            '    Dim isActiveValue As Integer = 0

            '    If proceed Then
            '        remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}&id={id}")
            '    End If
            '    If proceed Then
            '        proceed = (remote.sendData("DELETE").Length = 0)
            '    End If
            '    If proceed Then
            '        proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            '    End If
            '    If proceed Then
            '        RaiseEvent WriteLine($"Command delete executed: {id}")
            '    Else
            '        RaiseEvent WriteLine($"Command delete failed")
            '    End If

            '    Return proceed
            'Catch exFile As System.IO.FileLoadException
            '    RaiseEvent IntegrityApplication(exFile.FileName)

            '    Return False
            'Catch ex As Exception
            '    RaiseEvent RaiseError("Error during delete - " & ex.Message)

            '    Return False
            'End Try
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
                        Case "addNew".ToLower()
                            If _Command.haveParameter("shortName") Then
                                shortNameValue = _Command.parameterValue("shortName")
                            End If
                            If _Command.haveParameter("name") Then
                                nameValue = _Command.parameterValue("name")
                            End If
                            If _Command.haveParameter("displayName") Then
                                displayNameValue = _Command.parameterValue("displayName")
                            End If
                            If _Command.haveParameter("tipology") Then
                                tipologyValue = _Command.parameterValue("tipology")
                            End If
                            If _Command.haveParameter("minSize") Then
                                minSizeValue = _Command.parameterValue("minSize")
                            End If
                            If _Command.haveParameter("maxPrecision") Then
                                maxPrecisionValue = _Command.parameterValue("maxPrecision")
                            End If
                            If _Command.haveParameter("symbol") Then
                                symbolValue = _Command.parameterValue("symbol")
                            End If
                            If _Command.haveParameter("source") Then
                                sourceValue = _Command.parameterValue("source")
                            End If

                            If Not addNew(shortNameValue, nameValue, displayNameValue, tipologyValue, minSizeValue, maxPrecisionValue, symbolValue, sourceValue) Then
                                RaiseEvent WriteLine("Problem during get a addNew of exchange")

                                proceed = False
                            End If
                        Case "update"
                            Dim name As String = ""
                            Dim isActiveValue As String = "1"

                            If _Command.haveParameter("isActive") Then
                                isActiveValue = _Command.parameterValue("isActive")
                            End If
                            If _Command.haveParameter("name") Then
                                name = _Command.parameterValue("name")
                            End If
                            If Not update(_Command.parameterValue("update"), name, isActiveValue) Then
                                RaiseEvent WriteLine("Problem during get an update of exchange")

                                proceed = False
                            End If
                        Case "delete"
                            If Not delete(_Command.parameterValue("delete")) Then
                                RaiseEvent WriteLine("Problem during get a delete of exchange")

                                proceed = False
                            End If
                        Case "getData".ToLower()
                            If Not getData(_Command.parameterValue("getData")) Then
                                RaiseEvent WriteLine("Problem during get data of exchange")

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
