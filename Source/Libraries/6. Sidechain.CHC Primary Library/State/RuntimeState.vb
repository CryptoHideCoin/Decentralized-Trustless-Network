Option Compare Text
Option Explicit On


Imports CHCModels.AreaModel.Information




Namespace AreaChain.Runtime.Models

    ''' <summary>
    ''' This class contain the service of a state
    ''' </summary>
    Public Class ServiceState

        Public Property serviceInformation As New InternalServiceInformation

        'Public Property keys As New TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine

        'Public Property queues As New TransactionChainLibrary.AreaEngine.Requests.QueueEngine


        'Public Property network As New CHCRuntimeChainLibrary.AreaRuntime.AppState.ConnectionNetwork
        'Public Property component As New ComponentElement
        'Public Property runTimeState As New AreaState.ChainStateEngine

        'Public Property ledger As New CHCLedgerLibrary.AreaLedger.LedgerEngine

        'Public Property serviceParameters As New AreaService.ServiceParameters


        'Public Sub New()

        '    ledger.header.identifyLedger = AreaCommon.Customize.identityBlockChainDefault

        'End Sub

    End Class

End Namespace