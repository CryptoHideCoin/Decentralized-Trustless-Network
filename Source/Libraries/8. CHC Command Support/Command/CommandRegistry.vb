Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Registry
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaEngine.Service





Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Stop Serve 
    ''' </summary>
    Public Class CommandRegistry : Implements CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements CommandModel.RaiseError
        Public Event ReadKey() Implements CommandModel.ReadKey

        Private WithEvents _EngineService As New AccessEngine


        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        ''' <summary>
        ''' This method provide to get e registry list
        ''' </summary>
        ''' <returns></returns>
        Private Function getLogList() As Boolean
            Try
                Dim remote As New ProxyWS(Of RegistryListResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/registryList/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.getData().Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Registry list of Service = {_EngineService.input.service}")
                    RaiseEvent WriteLine("")

                    For Each item In remote.data.value
                        RaiseEvent WriteLine(item)
                    Next

                    RaiseEvent WriteLine("")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine($"Error during getLogList - {ex.Message}")

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete old data
        ''' </summary>
        ''' <returns></returns>
        Private Function deleteOld() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/maintenance/cleanRegistry/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command delete old registry")
                    RaiseEvent WriteLine("")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine($"Error during deleteOld - {ex.Message}")

                Return False
            End Try
        End Function


        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim parameterCommand As String = ""
                Dim proceed As Boolean = True

                If _Command.haveParameter("getList") Then
                    parameterCommand = "getList"
                End If
                If _Command.haveParameter("clean") Then
                    parameterCommand = "clean"
                End If

                If (parameterCommand.Length = 0) Then
                    RaiseEvent WriteLine("Action not set!")

                    Return False
                End If

                If proceed Then
                    proceed = _EngineService.Init(_Command, defaultParameters)
                End If

                If proceed Then
                    Select Case parameterCommand.ToLower()
                        Case "getList".ToLower()
                            If Not getLogList() Then
                                RaiseEvent WriteLine("Problem during read the Log Index!")

                                proceed = False
                            End If
                        Case "clean".ToLower()
                            If Not deleteOld() Then
                                RaiseEvent WriteLine("Problem during delete old log")

                                proceed = False
                            End If
                    End Select
                End If

                Return proceed
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Sub _EngineService_LaunchIntegrityApplication(fileName As String) Handles _EngineService.LaunchIntegrityApplication
            RaiseEvent IntegrityApplication(fileName)
        End Sub

        Private Sub _EngineService_RaiseError(message As String) Handles _EngineService.RaiseError
            RaiseEvent RaiseError(message)
        End Sub
    End Class

End Namespace
