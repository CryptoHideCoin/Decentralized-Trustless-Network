Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports TradingBotSystemModelsLibrary.AreaModel.Exchange




Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command exchange references
    ''' </summary>
    Public Class CommandExchangeReference : Implements CommandModel

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
        ''' This method provide to get a list of a exchange references
        ''' </summary>
        ''' <returns></returns>
        Private Function getList(ByVal exchangeId As Integer) As Boolean
            Try
                Dim remote As New ProxyWS(Of ExchangeReferenceListResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchangeReference/?securityToken={_EngineService.securityToken}&exchangeId={exchangeId}")
                End If
                If proceed Then
                    proceed = (remote.getData().Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    Dim numExchangeReference As Integer = 0
                    Dim urlTypeValue As String

                    RaiseEvent WriteLine($"Exchange refernce list result:")
                    RaiseEvent WriteLine($"==============================")
                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"Exchange ID: {exchangeId}")
                    RaiseEvent WriteLine("")

                    For Each item In remote.data.value
                        urlTypeValue = $"{item.urlType}{Space(20)}"

                        RaiseEvent WriteLine($"{urlTypeValue.Substring(0, 20)} {item.url}")

                        numExchangeReference += 1
                    Next

                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"({numExchangeReference}) Total item(s)")
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
        ''' This method provide to get a data from an exchange
        ''' </summary>
        ''' <param name="exchangeId"></param>
        ''' <param name="urlType"></param>
        ''' <returns></returns>
        Private Function getData(ByVal exchangeId As Integer, ByVal urlType As String) As Boolean
            Try
                Dim remote As New ProxyWS(Of ExchangeReferenceResponseModel)
                Dim data As ExchangeReferenceResponseModel
                Dim proceed As Boolean = True
                Dim urlTypeValue As ExchangeReferenceStructure.TypeReferenceEnumeration

                If proceed Then
                    Select Case urlType.ToLower
                        Case "1", "mainApi".ToLower
                            urlTypeValue = ExchangeReferenceStructure.TypeReferenceEnumeration.mainApiReferement
                        Case "2", "apiCurrencies".ToLower
                            urlTypeValue = ExchangeReferenceStructure.TypeReferenceEnumeration.apiCurrencies
                        Case "3", "apiCurrenciesHelp".ToLower
                            urlTypeValue = ExchangeReferenceStructure.TypeReferenceEnumeration.apiCurrenciesHelp
                    End Select

                    remote.url = _EngineService.buildURL($"/state/trade/exchangeReference/?securityToken={_EngineService.securityToken}&exchangeId={exchangeId}&urlType={urlTypeValue}")
                End If
                If proceed Then
                    proceed = (remote.getData.Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    data = remote.data

                    RaiseEvent WriteLine($"Exchange Reference information")
                    RaiseEvent WriteLine($"==============================")
                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine($"Exchange id                    : {exchangeId}")
                    RaiseEvent WriteLine($"Exchange Reference type        : {data.value.urlType}")
                    RaiseEvent WriteLine($"Exchange Reference url         : {data.value.url}")
                    RaiseEvent WriteLine("")
                End If
                If Not proceed Then
                    RaiseEvent WriteLine($"Command get failed")
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
        ''' This method provide to execute add new command
        ''' </summary>
        ''' <returns></returns>
        Private Function readAddNewParameter(ByRef parameter As ExchangeReferenceStructure, Optional ByVal extended As Boolean = False) As Boolean
            Try
                If _Command.haveParameter("exchangeId") Then
                    parameter.exchangeId = _Command.parameterValue("exchangeId")
                Else
                    RaiseEvent RaiseError("Exchange Id parameter missing")

                    Return False
                End If

                If _Command.haveParameter("urlType") Then

                    Select Case _Command.parameterValue("urlType").ToLower
                        Case "1", "homepage".ToLower
                            parameter.urlType = ExchangeReferenceStructure.TypeReferenceEnumeration.homePage
                        Case "2", "mainApi".ToLower
                            parameter.urlType = ExchangeReferenceStructure.TypeReferenceEnumeration.mainApiReferement
                        Case "3", "apiCurrencies".ToLower
                            parameter.urlType = ExchangeReferenceStructure.TypeReferenceEnumeration.apiCurrencies
                        Case "4", "apiCurrenciesHelp".ToLower
                            parameter.urlType = ExchangeReferenceStructure.TypeReferenceEnumeration.apiCurrenciesHelp
                    End Select
                Else
                    RaiseEvent RaiseError("Exchange url type parameter missing")

                    Return False
                End If

                If extended Then
                    If _Command.haveParameter("url") Then
                        parameter.url = _Command.parameterValue("url")
                    Else
                        RaiseEvent RaiseError("Exchange url parameter missing")

                        Return False
                    End If
                End If

                Return True
            Catch ex As Exception
                RaiseEvent RaiseError($"Error during readAddNewParameter - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to addNew / Update an exchange reference
        ''' </summary>
        Private Function addNewUpdate(ByVal sendType As String) As Boolean
            Try
                Dim data As New ExchangeReferenceStructure
                Dim remote As New ProxyWS(Of ExchangeReferenceStructure)
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = readAddNewParameter(data, (sendType.CompareTo("POST") = 0))
                End If
                If proceed Then
                    remote.url = _EngineService.buildURL($"/state/trade/exchangeReference/?securityToken={_EngineService.securityToken}")

                    remote.data = data
                End If
                If proceed Then
                    proceed = (remote.sendData(sendType).Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command addNew/Update executed: ExchangeId={data.exchangeId} - type:{data.urlType} - url:{data.url}")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent RaiseError("Error during addNewUpdate - " & ex.Message)

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
                    Dim exchangeID As String = _Command.parameterValue("exchangeId")

                    If Not IsNumeric(exchangeID) Then
                        RaiseEvent WriteLine("The exchange value missing")

                        proceed = False
                    End If

                    Select Case parameterCommand.ToLower()
                        Case "list".ToLower()
                            If Not getList(exchangeID) Then
                                RaiseEvent WriteLine("Problem during get a list of exchange")

                                proceed = False
                            End If

                        Case "addNew".ToLower() : Return addNewUpdate("POST")
                        Case "update" : Return addNewUpdate("PUT")
                        Case "delete" : Return addNewUpdate("DELETE")
                        Case "getData".ToLower()
                            Dim urlType As String = _Command.parameterValue("urlType")

                            If Not getData(exchangeID, urlType) Then
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
