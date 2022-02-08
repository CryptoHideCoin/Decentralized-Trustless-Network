Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaSystem
Imports CHCCommonLibrary.AreaEngine.Log
Imports CHCCommonLibrary.Support




Namespace AreaChain.Runtime.Models

    ''' <summary>
    ''' This class contain the IPAddress configuration
    ''' </summary>
    Public Class IPAddressConfiguration
        Public Property local As String = ""
        Public Property [public] As String = ""
    End Class

    ''' <summary>
    ''' This class contain the environment model
    ''' </summary>
    Public Class EnvironmentModel

        Public paths As New VirtualPathEngine
        Public log As New TrackEngine
        Public counter As New CounterEngine
        Public registry As New RegistryEngine
        Public settings As New SettingsChainService
        Public ipAddress As New IPAddressConfiguration
        Public keys As New AreaEngine.Keys.KeysEngine

        'Public flow As New AreaFlow.FlowEngine
        'Public support As New Engine.SupportEngine
        'Public consensus As New AreaConsensus.ConsensusEngine
        'Public state As New AppState

    End Class

End Namespace
