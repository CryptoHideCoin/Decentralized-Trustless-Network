Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Counter





Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Counter class
    ''' </summary>
    Public Class CommandCounter : Implements CommandModel

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
        ''' This method provide to delete old data
        ''' </summary>
        ''' <returns></returns>
        Private Function deleteOld() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/maintenance/cleanCounter/?securityToken={_EngineService.SecurityToken}")
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT").Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Command delete old counter")
                    RaiseEvent WriteLine("")
                End If

                Return proceed
            Catch exFile As IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine("Error during deleteOld - " & ex.Message)

                Return False
            End Try
        End Function

        Private Function getTotal() As Boolean
            Try
                Dim filter As New QueryCounterFilter
                Dim remote As New ProxyWS(Of QueryCounterResponseModel)
                Dim proceed As Boolean = True

                If proceed Then
                    remote.url = _EngineService.buildURL($"/administration/maintenance/queryCounterValue/?securityToken={_EngineService.SecurityToken}")
                End If
                If proceed Then
                    proceed = (remote.getData("filter", filter).Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    RaiseEvent WriteLine($"Counter serve result:")
                    RaiseEvent WriteLine($"=====================")
                    RaiseEvent WriteLine("")

                    RaiseEvent WriteLine("Filters")

                    If (filter.fromTimestamp = 0) Then
                        RaiseEvent WriteLine($"   From       : Start")
                    Else
                        RaiseEvent WriteLine($"   From       : {filter.fromTimestamp}")
                    End If
                    If (filter.toTimeStamp = 0) Then
                        RaiseEvent WriteLine($"   To         : Now")
                    Else
                        RaiseEvent WriteLine($"   To         : {filter.toTimeStamp}")
                    End If
                    Select Case filter.components
                        Case QueryCounterFilter.CounterComponentEnumeration.both
                            RaiseEvent WriteLine($"   Components : all")
                        Case QueryCounterFilter.CounterComponentEnumeration.onlyAPI
                            RaiseEvent WriteLine($"   Components : only API")
                        Case QueryCounterFilter.CounterComponentEnumeration.onlyOther
                            RaiseEvent WriteLine($"   Components : not API")
                    End Select

                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine("Totals")

                    RaiseEvent WriteLine($"   API called     : {remote.data.totals.onlyAPI}")
                    RaiseEvent WriteLine($"   Other called   : {remote.data.totals.onlyOther}")
                    RaiseEvent WriteLine($"   called         : {remote.data.totals.total}")

                    RaiseEvent WriteLine("")
                    RaiseEvent WriteLine("Call for times")

                    For Each item In remote.data.timeSlots
                        RaiseEvent WriteLine($"  At {CHCCommonLibrary.AreaEngine.Miscellaneous.SupportDate.dateTimeFromTimeStamp(item.timestamp)}  : {item.value.total} called")
                    Next

                    RaiseEvent WriteLine("")
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


        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                Dim proceed As Boolean = True
                Dim parameterCommand As String = ""

                If _Command.haveParameter("clean") Then
                    parameterCommand = "clean"
                End If
                If _Command.haveParameter("total") Then
                    parameterCommand = "total"
                End If

                If (parameterCommand.Length = 0) Then
                    RaiseEvent WriteLine("Action not set!")

                    proceed = False
                End If

                If proceed Then
                    proceed = _EngineService.Init(_Command, defaultParameters)
                End If

                If proceed Then
                    Select Case parameterCommand.ToLower()
                        Case "total".ToLower()
                            If Not getTotal() Then
                                RaiseEvent WriteLine("Problem during get a total")

                                proceed = False
                            End If
                        Case "clean".ToLower()
                            If Not deleteOld() Then
                                RaiseEvent WriteLine("Problem during delete old counter")

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
