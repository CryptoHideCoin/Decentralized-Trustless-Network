Option Compare Text
Option Explicit On


Imports TransactionChainLibrary.AreaEngine.Ledger
Imports CHCProtocolLibrary.AreaCommon





Public Class AppState

    Public Enum enumConnectionState

        notDefined
        offLine
        startingConnection
        connectionOffLine
        onLine

    End Enum

    Public Enum enumMasternodeRole

        notDefined
        guarantee
        fullRole
        chainService
        clientService
        light

    End Enum

    Public Class ServiceInformation

        Public Property adminPublicWalletID As String = ""
        Public Property intranetMode As Boolean = False
        Public Property addressIP As String = ""
        Public Property networkName As String = ""
        Public Property chainName As String = AreaCommon.Customize.chainName
        Public Property platformHost As String = ""
        Public Property softwareRelease As String = ""

    End Class

    Public Class ConnectionNetwork

        Public Property position As enumConnectionState = enumConnectionState.notDefined
        Public Property role As enumMasternodeRole = enumMasternodeRole.notDefined
        Public Property coinWarranty As Decimal = 0.000000001
        Public Property connectedMoment As Date = Date.MinValue
        Public Property walletWarrantyID As String = ""
        Public Property currentAction As New Models.Administration.ActionElement

    End Class

    Public Class ComponentElement

        Public Property storage As New Storage.StorageEngine
        Public Property previousVolume As New PreviousVolume.PreviousVolumeEngine
        Public Property currentVolume As New CurrentVolume.CurrentVolumeEngine
        Public Property stateDB As New State.StateEngine
        Public Property nodeList As New NodeList.NodeListTrustedEngine

    End Class


    Public service As Models.Service.InformationResponseModel.EnumInternalServiceState = Models.Service.InformationResponseModel.EnumInternalServiceState.notDefined
    Public information As New ServiceInformation
    Public keys As New TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine

    Public queues As New TransactionChainLibrary.AreaEngine.Requests.QueueEngine

    Public serviceState As New Models.Administration.ServiceStateResponse
    Public network As New ConnectionNetwork
    Public component As New ComponentElement
    Public runtimeState As New AreaState.ChainStateEngine
    Public currentBlockLedger As New TransactionChainLibrary.AreaLedger.LedgerEngine

    Public noConsoleMessage As Boolean = False

    Public publicIpAddress As String = ""
    Public localIpAddress As String = ""

End Class