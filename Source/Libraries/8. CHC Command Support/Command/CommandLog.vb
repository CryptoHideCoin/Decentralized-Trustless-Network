Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Log
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaEngine.Service





Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Log
    ''' </summary>
    Public Class CommandLog : Implements Models.CommandModel

        Private Property _Command As CommandStructure

        Public Event WriteLine(ByVal message As String) Implements Models.CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements Models.CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements Models.CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements Models.CommandModel.RaiseError
        Public Event ReadKey() Implements Models.CommandModel.ReadKey

        Private WithEvents _EngineService As New AccessEngine


        Private Property CommandModel_command As CommandStructure Implements Models.CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        ''' <summary>
        ''' This method provide to stop a serve
        ''' </summary>
        ''' <returns></returns>
        Private Function getLogList() As Boolean
            Try
                Dim remote As New ProxyWS(Of LogListResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/logList/?securityToken={_EngineService.SecurityToken}")
                End If
                If proceed Then
                    proceed = (remote.getData().Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Log list of Service = {_EngineService.input.service}")
                    RaiseEvent WriteLine("")

                    For Each item In remote.data.value.items
#Disable Warning BC42016
                        RaiseEvent WriteLine(item.name & Space(40 - item.name.Length) & CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(item.startAt.ToString()))
#Enable Warning BC42016
                    Next

                    RaiseEvent WriteLine("")
                End If

                Return proceed
            Catch exFile As IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine("Error during getLogList - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to show block log
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Private Function showBlockLog(ByVal value As String) As Boolean
            Try
                Dim path As String = ""
                Dim applicationInfo As AreaEngine.ApplicationPathData
                Dim parameters As String = ""
                Dim parameterService As String = $"--service:{_EngineService.input.service} "
                Dim parameterDataPath As String = $"--dataPath:{_EngineService.input.dataPath} "
                Dim parameterPassword As String = ""
                Dim parameterLoadBlock As String = $"--loadBlock:{value} "
                Dim parameterAddress As String = $"--address:{_EngineService.input.address} "
                Dim parameterSecurityKey As String = ""

                AreaEngine.ApplicationPathEngine.init()

                applicationInfo = ApplicationCommon.appConfigurations.getApplicationData(AreaEngine.ApplicationID.showLog)

                If (_EngineService.input.password.Length > 0) Then
                    parameterPassword = $"--password:{_EngineService.input.password} "
                End If
                If (_EngineService.input.securityKey.Length > 0) Then
                    parameterSecurityKey = $"--securityKey:{_EngineService.input.securityKey} "
                End If

                parameters += parameterService
                parameters += parameterDataPath
                parameters += parameterPassword
                parameters += parameterLoadBlock
                parameters += parameterAddress
                parameters += parameterSecurityKey

                path = applicationInfo.rootPath
                path = IO.Path.Combine(path, applicationInfo.directoryName)

                If IO.Directory.Exists(path) Then
                    path = IO.Path.Combine(path, applicationInfo.applicationName)

                    If Not IO.File.Exists(path) Then
                        RaiseEvent WriteLine("Error: the application '" & path & "' is not exist")
                    Else
                        RaiseEvent WriteLine($"{path} -showBlock {parameters}--pause")

                        RaiseEvent Process(path, $"-showBlock {parameters} --pause")

                        Return True
                    End If
                Else
                    RaiseEvent WriteLine("Error: the directory '" & path & "' is not exist")
                End If

                Return True
            Catch ex As Exception
                RaiseEvent WriteLine("Error during showBlockLog - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to show a block of a log
        ''' </summary>
        ''' <returns></returns>
        Private Function block() As Boolean
            Try
                Dim remote As New ProxyWS(Of LogListResponseModel)
                Dim proceed As Boolean = True
                Dim blockValue As String = _Command.parameterValue("block")

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/logList/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.getData().Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    For Each item In remote.data.value.items
                        If (item.name.CompareTo(blockValue) = 0) Then
                            showBlockLog(blockValue)
                        End If
                    Next
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine("Error during block - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete a single block
        ''' </summary>
        ''' <returns></returns>
        Private Function deleteBlock() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True
                Dim blockValue As String = _Command.parameterValue("deleteBlock")

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/logBlockDelete/?securityToken={_EngineService.securityToken}&blockNumber={blockValue}")
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Delete block {blockValue} log Executed")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine("Error during deleteBlock - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete old log instance
        ''' </summary>
        ''' <returns></returns>
        Private Function deleteOldInstance() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/maintenance/cleanOldLogInstance/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Delete old instance log Executed")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine("Error during deleteBlock - " & ex.Message)

                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provide to delete old log file
        ''' </summary>
        ''' <returns></returns>
        Private Function deleteOld() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/maintenance/cleanLog/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Delete old log Executed")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine("Error during deleteOld - " & ex.Message)

                Return False
            End Try
        End Function

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Try
                Dim parameterCommand As String = ""
                Dim proceed As Boolean = True

                If _Command.haveParameter("getList") Then
                    parameterCommand = "getList"
                End If
                If _Command.haveParameter("blockExplorer") Then
                    parameterCommand = "blockExplorer"
                End If
                If _Command.haveParameter("deleteBlock") Then
                    parameterCommand = "deleteBlock"
                End If
                If _Command.haveParameter("deleteOldLogInstance") Then
                    parameterCommand = "deleteOldLogInstance"
                End If
                If _Command.haveParameter("logRotate") Then
                    parameterCommand = "logRotate"
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
                        Case "blockExplorer".ToLower()
                            If Not block() Then
                                RaiseEvent WriteLine("Problem during read block!")

                                proceed = False
                            End If
                        Case "deleteBlock".ToLower()
                            If Not deleteBlock() Then
                                RaiseEvent WriteLine("Problem during delete block!")

                                proceed = False
                            End If
                        Case "deleteOldLogInstance".ToLower()
                            If Not deleteOldInstance() Then
                                RaiseEvent WriteLine("Problem during delete old log instance!")

                                proceed = False
                            End If
                        Case "logRotate".ToLower()
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
