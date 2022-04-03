Option Compare Text
Option Explicit On

Imports CHCModels.AreaModel.Administration.Settings
Imports CHCProtocolLibrary.AreaSystem
Imports CHCProtocolLibrary.AreaEngine.Keys
Imports CHCProtocolLibrary.AreaEngine.Security
Imports CHCCommonLibrary.AreaEngine.Log
Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.Encrypted




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
        Public Property settings As New SettingsSidechainService
    End Class

    ''' <summary>
    ''' This class contain the environment model
    ''' </summary>
    Public Class EnvironmentModel

        Public Property paths As New VirtualPathEngine
        Public Property log As New TrackEngine
        Public Property counter As New CounterEngine
        Public Property registry As New RegistryEngine
        Public Property settings As New SettingsSidechainService
        Public Property localWorkMachineSettings As New SettingsSidechainService
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
                Dim engineFile As New BaseFile(Of SettingsSidechainService)

                completeFileName = IO.Path.Combine(AreaCommon.Main.environment.paths.settings, chainServiceName & ".Settings")

                If Not IO.File.Exists(completeFileName) Then
                    response.problemDescription = completeFileName & " not found." & Err.Description

                    Return response
                End If

                If (AreaCommon.Main.settingsPassword.Length > 0) Then
                    engineFile.cryptoKEY = AreaCommon.Main.settingsPassword
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.fileName = completeFileName

                If engineFile.read() Then
                    If Not noSetEnvironment Then
                        If (chainServiceName.ToLower().CompareTo("localworkmachine") = 0) Then
                            AreaCommon.Main.environment.localWorkMachineSettings = engineFile.data
                        Else
                            AreaCommon.Main.environment.settings = engineFile.data
                        End If

                        AreaCommon.Main.environment.log.trackIntoConsole("Settings data read")
                    End If

                    response.settings = engineFile.data
                    response.successful = True

                    Return response
                Else
                    response.problemDescription = "Problem during read a settings"

                    Return response
                End If
            Catch ex As Exception
                response.problemDescription = "An error occurrent during Bootstrap.readSettings " & Err.Description

                Return response
            End Try
        End Function

        ''' <summary>
        ''' This method provide to save settings chain operation
        ''' </summary>
        ''' <returns></returns>
        Public Function saveSettings() As Boolean
            Try
                Dim completeFileName As String = ""
                Dim engineFile As New BaseFile(Of SettingsSidechainService)

                completeFileName = IO.Path.Combine(AreaCommon.Main.environment.paths.settings, AreaCommon.Main.environment.settings.sideChainName & ".Settings")

                If IO.File.Exists(completeFileName) Then
                    Try
                        IO.File.Delete(completeFileName)
                    Catch ex As Exception
                        AreaCommon.Main.environment.log.trackException("AreaChain.Runtime.Models.EnvironmentModel.saveSettings", completeFileName & " cannot complete. Error = " & Err.Description)

                        Return False
                    End Try
                End If

                If (AreaCommon.Main.settingsPassword.Length > 0) Then
                    engineFile.cryptoKEY = AreaCommon.Main.settingsPassword
                Else
                    engineFile.noCrypt = True
                End If

                engineFile.fileName = completeFileName

                engineFile.data = AreaCommon.Main.environment.settings

                If engineFile.save() Then
                    Return True
                Else
                    AreaCommon.Main.environment.log.trackException("AreaChain.Runtime.Models.EnvironmentModel.saveSettings", "Problem during read a settings")

                    Return False
                End If
            Catch ex As Exception
                AreaCommon.Main.environment.log.trackException("AreaChain.Runtime.Models.EnvironmentModel.saveSettings", "An error occurrent during Bootstrap.readSettings " & Err.Description)

                Return False
            End Try
        End Function

    End Class

End Namespace
