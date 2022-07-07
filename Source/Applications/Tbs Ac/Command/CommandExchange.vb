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
                    remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}")
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
        ''' <returns></returns>
        Private Function addNew() As Boolean
            Try
                Dim data As New NewExchangeStructure
                Dim remote As New ProxyWS(Of NewExchangeStructure)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = readAddNewParameter(data)
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}")

                    remote.data = data
                End If
                If proceed Then
                    proceed = (remote.sendData("POST").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command addNew executed: {Data.name} - isActive:{(Data.isActive = 0)} - isCentralized:{(Data.isCentralized = 0)} - group:{Data.group}")
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
        ''' This method provide to update data from a parameter's
        ''' </summary>
        ''' <returns></returns>
        Private Function update() As Boolean
            Try
                Dim data As New UpdateExchangeStructure
                Dim remote As New ProxyWS(Of UpdateExchangeStructure)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = getCurrentParameter(data)
                End If
                If proceed Then
                    proceed = readUpdateParameter(data)
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
                    RaiseEvent WriteLine($"Command update executed: {data.name} - isActive:{(data.isActive = 0)} - isCentralized:{(data.isCentralized = 0)} - group:{data.group}")
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
                    remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}&id={id}")
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
                Dim remote As New ProxyWS(Of ExchangeResponseModel)
                Dim data As ExchangeResponseModel
                Dim proceed As Boolean = True
                Dim isActiveValue As Integer = 0

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}&id={id}")
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
                    RaiseEvent WriteLine($"Id                    : {data.value.id}")
                    RaiseEvent WriteLine($"Name                  : {data.value.name}")
                    RaiseEvent WriteLine($"Active                : {data.value.isActive}")
                    RaiseEvent WriteLine($"Centralized           : {data.value.isCentralized}")
                    RaiseEvent WriteLine($"Group                 : {data.value.group}")
                    RaiseEvent WriteLine($"Last currencies check : {data.value.lastCurrenciesCheck}")
                    RaiseEvent WriteLine($"Last products check   : {data.value.lastProductsCheck}")
                    RaiseEvent WriteLine($"Exchange used         : {data.value.isUsed}")
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

        ''' <summary>
        ''' This method provide to convert the value into standard value 0, 1 or ""
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function standardizeBooleanParameter(ByVal value As String) As String
            If (value.CompareTo("0") = 0) Or (value.ToLower.CompareTo("false") = 0) Or (value.ToLower.CompareTo("f") = 0) Then
                Return "0"
            ElseIf (value.CompareTo("1") = 0) Or (value.ToLower.CompareTo("true") = 0) Or (value.ToLower.CompareTo("t") = 0) Then
                Return "1"
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' This method provide to execute add new command
        ''' </summary>
        ''' <returns></returns>
        Private Function readAddNewParameter(ByRef parameter As NewExchangeStructure) As Boolean
            Try
                Dim temp As String

                If _Command.haveParameter("name") Then
                    parameter.name = _Command.parameterValue("name")
                Else
                    RaiseEvent RaiseError("Exchange name parameter missing")

                    Return False
                End If

                If _Command.haveParameter("isActive") Then
                    temp = standardizeBooleanParameter(_Command.parameterValue("isActive"))

                    If (temp.Length = 0) Then
                        RaiseEvent RaiseError("Exchange isActive parameter wrong (use 0,1 or false, true or f, t")

                        Return False
                    Else
                        parameter.isActive = (temp.CompareTo("0") <> 0)
                    End If
                End If

                If _Command.haveParameter("isCentralized") Then
                    temp = standardizeBooleanParameter(_Command.parameterValue("isCentralized"))

                    If (temp.Length = 0) Then
                        RaiseEvent RaiseError("Exchange isCentralized parameter wrong (use 0,1 or false, true or f, t")

                        Return False
                    Else
                        parameter.isCentralized = (temp.CompareTo("0") <> 0)
                    End If
                End If

                If _Command.haveParameter("group") Then
                    parameter.group = _Command.parameterValue("group")
                End If

                Return True
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during readAddNewParameter - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to read update parameter's
        ''' </summary>
        ''' <param name="parameter"></param>
        ''' <returns></returns>
        Private Function readUpdateParameter(ByRef parameter As UpdateExchangeStructure) As Boolean
            Try
                Dim temp As String

                If _Command.haveParameter("name") Then
                    parameter.name = _Command.parameterValue("name")
                End If

                If _Command.haveParameter("isActive") Then
                    temp = standardizeBooleanParameter(_Command.parameterValue("isActive"))

                    If (temp.Length = 0) Then
                        RaiseEvent RaiseError("Exchange isActive parameter wrong (use 0,1 or false, true or f, t")

                        Return False
                    Else
                        parameter.isActive = (temp.CompareTo("0") <> 0)
                    End If
                End If

                If _Command.haveParameter("isCentralized") Then
                    temp = standardizeBooleanParameter(_Command.parameterValue("isCentralized"))

                    If (temp.Length = 0) Then
                        RaiseEvent RaiseError("Exchange isCentralized parameter wrong (use 0,1 or false, true or f, t")

                        Return False
                    Else
                        parameter.isCentralized = (temp.CompareTo("0") <> 0)
                    End If
                End If

                If _Command.haveParameter("group") Then
                    parameter.group = _Command.parameterValue("group")
                End If

                Return True
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during readUpdateParameter - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to get a current parameter
        ''' </summary>
        ''' <param name="parameter"></param>
        ''' <returns></returns>
        Private Function getCurrentParameter(ByRef parameter As UpdateExchangeStructure) As Boolean
            Try
                Dim remote As New ProxyWS(Of ExchangeResponseModel)
                Dim proceed As Boolean = True

                If _Command.haveParameter("id") Then
                    parameter.id = _Command.parameterValue("id")
                Else
                    RaiseEvent RaiseError("Exchange id parameter missing")

                    Return False
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchange/?securityToken={_EngineService.securityToken}&id={parameter.id}")
                End If
                If proceed Then
                    proceed = (remote.getData.Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    parameter.name = remote.data.value.name
                    parameter.isCentralized = remote.data.value.isCentralized
                    parameter.isActive = remote.data.value.isActive
                    parameter.group = remote.data.value.group
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
                    RaiseEvent RaiseError("Action not set!")

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
                        Case "addNew".ToLower() : Return addNew()
                        Case "update" : Return update()
                        Case "delete"
                            If Not _Command.haveParameter("id") Then
                                RaiseEvent RaiseError("Id missing parameter's")

                                proceed = False
                            End If
                            If Not delete(_Command.parameterValue("id")) Then
                                RaiseEvent RaiseError("Problem during get a delete of exchange")

                                proceed = False
                            End If
                        Case "getData".ToLower()
                            If Not _Command.haveParameter("id") Then
                                RaiseEvent RaiseError("Id missing parameter's")

                                proceed = False
                            End If
                            If Not getData(_Command.parameterValue("id")) Then
                                RaiseEvent RaiseError("Problem during get data of exchange")

                                proceed = False
                            End If
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
