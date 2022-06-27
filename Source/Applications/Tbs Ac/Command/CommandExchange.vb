Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports TradingBotSystemModelsLibrary.AreaModel.Exchange




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command exchange
    ''' </summary>
    Public Class CommandExchange : Implements CommandModel

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
                Dim remote As New ProxyWS(Of ExchangeListResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/base/exchange/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.getData().Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    Dim numExchange As Integer = 0

                    RaiseEvent WriteLine($"Exchange list result:")
                    RaiseEvent WriteLine($"=====================")
                    RaiseEvent WriteLine("")

                    For Each item In remote.data.value
                        RaiseEvent WriteLine($"{item.id} - {item.name}")

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
        ''' This method provide to add a new exchange 
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="isActive"></param>
        ''' <returns></returns>
        Private Function addNew(ByVal name As String, ByVal isActive As String) As Boolean
            Try
                Dim remote As New ProxyWS(Of ExchangeListResponseModel)
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If (isActive.ToLower.CompareTo("true") = 0) Or (isActive.CompareTo("1") = 0) Then
                    isActiveValue = 1
                Else
                    isActiveValue = 0
                End If

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/base/exchange/?securityToken={_EngineService.securityToken}&name={name}&isActive={isActiveValue}")
                End If
                If proceed Then
                    proceed = (remote.sendData("POST").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command addNew executed: {name} - {isActive}")
                Else
                    RaiseEvent WriteLine($"Command addNew failed")
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
            Try
                Dim remote As New ProxyWS(Of ExchangeListResponseModel)
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If (isActive.ToLower.CompareTo("true") = 0) Or (isActive.CompareTo("1") = 0) Then
                    isActiveValue = 1
                Else
                    isActiveValue = 0
                End If

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/base/exchange/?securityToken={_EngineService.securityToken}&id={updateId}&name={name}&isActive={isActiveValue}")
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command update executed: {name} - {isActive}")
                Else
                    RaiseEvent WriteLine($"Command update failed")
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
                Dim remote As New ProxyWS(Of ExchangeListResponseModel)
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/base/exchange/?securityToken={_EngineService.securityToken}&id={id}")
                End If
                If proceed Then
                    proceed = (remote.sendData("DELETE").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
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
                Dim remote As New ProxyWS(Of ExchangeResponseModel)
                Dim data As ExchangeResponseModel
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/base/exchange/?securityToken={_EngineService.securityToken}&id={id}")
                End If
                If proceed Then
                    proceed = (remote.getData.Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    data = remote.data

                    RaiseEvent WriteLine($"Exchange information")
                    RaiseEvent WriteLine($"====================")
                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"Exchange id                    : {data.value.id}")
                    RaiseEvent WriteLine($"Exchange name                  : {data.value.name}")
                    RaiseEvent WriteLine($"Exchange active                : {data.value.isActive}")
                    RaiseEvent WriteLine($"Exchange last currencies check : {data.value.lastCurrenciesCheck}")
                    RaiseEvent WriteLine($"Exchange last products check   : {data.value.lastProductsCheck}")
                    RaiseEvent WriteLine($"Exchange used                  : {data.value.isUsed}")
                    RaiseEvent WriteLine("")
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
                RaiseEvent RaiseError("Error during getData - " & ex.Message)

                Return False
            End Try
        End Function


        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim proceed As Boolean = True
                Dim parameterCommand As String = ""

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
                                RaiseEvent WriteLine("Problem during get a list of exchange")

                                proceed = False
                            End If
                        Case "addNew".ToLower()
                            Dim isActiveValue As String = "1"

                            If _Command.haveParameter("isActive") Then
                                isActiveValue = _Command.parameterValue("isActive")
                            End If
                            If Not addNew(_Command.parameterValue("addNew"), isActiveValue) Then
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
