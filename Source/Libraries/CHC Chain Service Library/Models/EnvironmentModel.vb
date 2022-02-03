Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaSystem
Imports CHCCommonLibrary.Support




Namespace AreaChain.Runtime.Models

    ''' <summary>
    ''' This class contain the environment model
    ''' </summary>
    Public Class EnvironmentModel

        Public paths As New VirtualPathEngine
        Public log As New LogEngine
        Public counter As New CounterEngine
        Public registry As New RegistryEngine
        Public settings As New AreaChain.Runtime.Models.SettingsChainService

        'Public flow As New AreaFlow.FlowEngine
        'Public support As New Engine.SupportEngine
        'Public consensus As New AreaConsensus.ConsensusEngine
        'Public state As New AppState

    End Class

End Namespace
