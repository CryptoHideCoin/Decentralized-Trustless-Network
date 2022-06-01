Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Administration.Settings
Imports CHCProtocolLibrary.AreaSystem
Imports CHCProtocolLibrary.AreaEngine.Keys
Imports CHCProtocolLibrary.AreaEngine.Security
Imports CHCCommonLibrary.AreaEngine.Log
Imports CHCCommonLibrary.AreaEngine.Registry




Namespace AreaChain.Runtime.Models

    ''' <summary>
    ''' This class contain the IPAddress configuration
    ''' </summary>
    Public Class IPAddressConfiguration
        Public Property local As String = ""
        Public Property [public] As String = ""
    End Class

    ''' <summary>
    ''' This class contain the response of a IO Operation
    ''' </summary>
    Public Class ResponseIOOperation
        Public Property successful As Boolean = False
        Public Property problemDescription As String = ""
        Public Property settings As New SettingsSidechainServiceComplete
    End Class

    ''' <summary>
    ''' This class contain the environment model
    ''' </summary>
    Public Class EnvironmentModel

        Public Property paths As New VirtualPathEngine
        Public Property log As New TrackEngine
        Public Property counter As New AreaEngine.CounterEngine
        Public Property registry As New RegistryEngine
        Public Property settings As New SettingsSidechainServiceComplete
        Public Property performanceProfile As New CHCProtocolLibrary.AreaEngine.PerformanceProfile.Service.PerformanceProfileService
        Public Property localWorkMachineSettings As New SettingsSidechainServiceComplete
        Public Property ipAddress As New IPAddressConfiguration
        Public Property keys As New KeysEngine
        Public Property support As New AreaCommon.Engine.SupportEngine
        Public Property adminToken As New AdminTokenEngine
        Public Property iAmLocalWorkMachine As Boolean = False

        ''' TODO: Complete this class

        'Public flow As New AreaFlow.FlowEngine

        'Public consensus As New AreaConsensus.ConsensusEngine
        'Public state As New AppState


        ''' <summary>
        ''' This method provide to read a settings
        ''' </summary>
        ''' <param name="chainServiceName"></param>
        ''' <returns></returns>
        Public Shared Function readSettings(ByVal chainServiceName As String, Optional ByVal noSetEnvironment As Boolean = False) As ResponseIOOperation
            Dim response As New ResponseIOOperation
            Try
                Dim completeFileName As String = ""
                Dim engine As New CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine

                engine.dataPath = AreaCommon.Main.environment.paths.directoryData
                engine.serviceName = chainServiceName
                engine.password = AreaCommon.Main.settingsPassword

                If (engine.read() <> CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine.ResultReadSetting.Successfull) Then
                    response.problemDescription = "Problem during read a settings"
                Else
                    response.settings = engine.data
                    response.successful = True
                End If
            Catch ex As Exception
                response.problemDescription = "Problem during read a settings"
            End Try

            Return response
        End Function

        ''' <summary>
        ''' This method provide to save settings chain operation
        ''' </summary>
        ''' <returns></returns>
        Public Function saveSettings() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engine As New CHCProtocolLibrary.AreaEngine.Settings.SettingsEngine

                engine.dataPath = AreaCommon.Main.environment.paths.settings
                engine.serviceName = settings.sideChainName
                engine.password = AreaCommon.Main.settingsPassword

                engine.data = settings

                Return engine.write()
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

End Namespace
