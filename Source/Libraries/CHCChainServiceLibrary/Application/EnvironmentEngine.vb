Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaSystem
Imports CHCCommonLibrary.Support




Namespace AreaCommon

    Public Class EnvironmentEngine

        Public paths As New VirtualPathEngine
        Public log As New LogEngine
        Public logRotate As New LogRotateEngine
        Public counter As New CounterEngine
        Public registry As New RegistryEngine
        Public settings As New AreaChain.Runtime.Models.SettingsChainService
        Public flow As New AreaFlow.FlowEngine
        Public support As New Engine.SupportEngine
        Public consensus As New AreaConsensus.ConsensusEngine
        Public state As New AppState

    End Class

End Namespace
