Option Compare Text
Option Explicit On


Imports TransactionChainLibrary.AreaEngine.Ledger
Imports CHCProtocolLibrary.AreaCommon





Public Class AppState



    ''' <summary>
    ''' This class provides to expone the public information of this chain
    ''' </summary>
    Public Class ServiceInformation

        Public Property adminPublicAddressID As String = ""
        Public Property intranetMode As Boolean = False
        Public Property addressIP As String = ""
        Public Property networkName As String = ""
        Public Property chainName As String = AreaCommon.Customize.chainName
        Public Property platformHost As String = ""
        Public Property softwareRelease As String = ""

    End Class

    Public Class ComponentElement

        Public Property storage As New Storage.StorageEngine
        Public Property previousVolume As New PreviousVolume.PreviousVolumeEngine
        Public Property currentVolume As New CurrentVolume.CurrentVolumeEngine
        Public Property stateDB As New State.StateEngine
        Public Property trustedStartupNodeList As New NodeList.NodeListTrustedEngine

    End Class


    Public service As Models.Service.InformationResponseModel.EnumInternalServiceState = Models.Service.InformationResponseModel.EnumInternalServiceState.notDefined
    Public information As New ServiceInformation
    Public keys As New TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine

    Public queues As New TransactionChainLibrary.AreaEngine.Requests.QueueEngine

    Public serviceState As New Models.Administration.ServiceStateResponse
    Public network As New CHCRuntimeChainLibrary.AreaRuntime.AppState.ConnectionNetwork
    Public component As New ComponentElement
    Public runtimeState As New AreaState.ChainStateEngine
    Public currentBlockLedger As New TransactionChainLibrary.AreaLedger.LedgerEngine

    Public noConsoleMessage As Boolean = False

    Public publicIpAddress As String = ""
    Public localIpAddress As String = ""

End Class