Option Compare Text
Option Explicit On


Imports TransactionChainLibrary.AreaEngine.Ledger
Imports CHCProtocolLibrary.AreaCommon





Public Class AppState

    ''' <summary>
    ''' This class provides to expone the public information of this chain
    ''' </summary>
    Public Class InternalServiceInformation

        Public Property networkName As String = ""
        Public Property chainName As String = AreaCommon.Customize.chainName
        Public Property adminPublicAddress As String = ""
        Public Property intranetMode As Boolean = False
        Public Property addressIP As String = ""
        Public Property platformHost As String = ""
        Public Property softwareRelease As String = ""

    End Class

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

    Public Property service As Models.Service.InformationResponseModel.EnumInternalServiceState = Models.Service.InformationResponseModel.EnumInternalServiceState.undefined
    Public Property internalInformation As New InternalServiceInformation
    Public Property keys As New TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine

    Public Property queues As New TransactionChainLibrary.AreaEngine.Requests.QueueEngine

    Public Property currentService As New Models.Administration.ServiceStateResponse
    Public Property network As New CHCRuntimeChainLibrary.AreaRuntime.AppState.ConnectionNetwork
    Public Property component As New ComponentElement
    Public Property runTimeState As New AreaState.ChainStateEngine
    Public Property currentBlockLedger As New TransactionChainLibrary.AreaLedger.LedgerEngine
    Public Property ledgerMap As New TransactionChainLibrary.AreaLedger.LedgerMapEngine
    Public Property serviceParameters As New AreaService.ServiceParameters

    Public Property noConsoleMessage As Boolean = False

    Public Property publicIpAddress As String = ""
    Public Property localIpAddress As String = ""

End Class