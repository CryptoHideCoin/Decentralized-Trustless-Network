Option Compare Text
Option Explicit On


Imports TransactionChainLibrary.AreaEngine.Ledger
Imports CHCProtocolLibrary.AreaCommon





Public Class AppState

    ''' <summary>
    ''' This class contain an internal component element
    ''' </summary>
    Public Class ComponentElement

        Public Property storage As New Storage.StorageEngine
        Public Property previousVolume As New PreviousVolume.PreviousVolumeEngine
        Public Property currentVolume As New CurrentVolume.CurrentVolumeEngine
        Public Property stateDB As New State.StateEngine
        Public Property trustedStartupNodeList As New NodeList.NodeListTrustedEngine

    End Class

    Public Property serviceInformation As New Models.Service.InternalServiceInformation
    Public Property keys As New TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine

    Public Property queues As New TransactionChainLibrary.AreaEngine.Requests.QueueEngine

    Public Property currentService As New Models.Administration.ServiceStateResponse
    Public Property network As New CHCRuntimeChainLibrary.AreaRuntime.AppState.ConnectionNetwork
    Public Property component As New ComponentElement
    Public Property runTimeState As New AreaState.ChainStateEngine

    Public Property ledger As New CHCLedgerLibrary.AreaLedger.LedgerEngine

    Public Property serviceParameters As New AreaService.ServiceParameters

    Public Property noConsoleMessage As Boolean = False

    Public Property publicIpAddress As String = ""
    Public Property localIpAddress As String = ""


    Public Sub New()

        ledger.header.identifyLedger = AreaCommon.Customize.identityBlockChainDefault

    End Sub

End Class