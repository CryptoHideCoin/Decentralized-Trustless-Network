Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaEngine.Service
Imports CHCModelsLibrary.AreaModel.Information





Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Stop Serve 
    ''' </summary>
    Public Class CommandStatusServe : Implements Models.CommandModel

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
        Private Function getStatus() As Boolean
            Try
                Dim remote As New ProxyWS(Of InformationResponseModel)
                Dim proceed As Boolean = True
                Dim status As String = ""

                If proceed Then
                    remote.url = _EngineService.buildURL($"/service/information/?securityToken={_EngineService.securityToken}")
                End If
                If proceed Then
                    proceed = (remote.getData().Length = 0)
                End If
                If proceed Then
                    proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
                End If
                If proceed Then
                    Select Case remote.data.value.currentStatus
                        Case InternalServiceInformation.EnumInternalServiceState.shutDown : status = "Shut down"
                        Case InternalServiceInformation.EnumInternalServiceState.started : status = "Started"
                        Case InternalServiceInformation.EnumInternalServiceState.starting : status = "Starting"
                        Case InternalServiceInformation.EnumInternalServiceState.swithOff : status = "Switch off"
                        Case InternalServiceInformation.EnumInternalServiceState.undefined : status = "Undefined"
                        Case InternalServiceInformation.EnumInternalServiceState.waitToMaintenance : status = "Wait to maintenance"
                    End Select

                    RaiseEvent WriteLine($"The service status is {status}")
                End If

                Return proceed
            Catch exFile As System.IO.FileLoadException
                RaiseEvent IntegrityApplication(exFile.FileName)

                Return False
            Catch ex As Exception
                RaiseEvent WriteLine($"Error during getStatus - {ex.Message}")

                Return False
            End Try
        End Function

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Try
                Dim proceed As Boolean = True

                If proceed Then
                    proceed = _EngineService.Init(_Command, defaultParameters)
                End If

                If proceed Then
                    If Not getStatus() Then
                        RaiseEvent WriteLine("Problem during read the Status command!")

                        proceed = False
                    End If
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
