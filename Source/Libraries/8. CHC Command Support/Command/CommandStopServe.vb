Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaEngine.Service





Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Stop Serve 
    ''' </summary>
    Public Class CommandStopServe : Implements CommandModel

        Private Property _Command As CommandStructure
        Private Property _ParameterToShowLog As String = ""

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
        ''' This method provide to stop a serve
        ''' </summary>
        ''' <returns></returns>
        Private Function stopServe() As Boolean
            Try
                Dim remote As New ProxyWS(Of BaseRemoteResponse)
                Dim proceed As Boolean = True

                If proceed Then
                    If _ParameterToShowLog Then
                        remote.url = _EngineService.buildURL($"/service/switchOffShowLog/?securityToken={_EngineService.securityToken}")
                    Else
                        remote.url = _EngineService.buildURL($"/administration/setPowerOff/?securityToken={_EngineService.securityToken}")
                    End If
                End If
                If proceed Then
                    proceed = (remote.sendData("PUT") = "")
                End If
                If proceed Then
                    proceed = (remote.remoteResponse.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine($"Error during stopServe - {ex.Message}")

                Return False
            End Try
        End Function

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                If (_EngineService.input.service.ToLower.CompareTo("ShowLog".ToLower()) = 0) Then
                    _ParameterToShowLog = True

                    _EngineService.input.service = "localWorkMachine"
                End If

                If _EngineService.Init(_Command, defaultParameters) Then
                    If stopServe() Then
                        RaiseEvent WriteLine(Chr(34) & _EngineService.input.service & Chr(34) & " command STOP sended!")

                        Return True
                    Else
                        RaiseEvent WriteLine("Problem during execute Stop Server command!")

                        Return False
                    End If
                Else
                    Return False
                End If
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
