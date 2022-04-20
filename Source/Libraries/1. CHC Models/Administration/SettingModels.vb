Option Compare Text
Option Explicit On

' ****************************************
' Model: Settings
' Release Engine: 1.0 
' 
' Date last successfully test: 13/04/2022
' ****************************************



Namespace AreaModel.Administration.Settings

    ''' <summary>
    ''' This method provide to collect all element of Log Service 
    ''' </summary>
    Public Class SettingsLogSidechainService

        Public Property trackConfiguration As Log.TrackRuntimeModeEnum = Log.TrackRuntimeModeEnum.trackAll
        Public Property changeLogFileMaxNumHours As Integer = 0
        Public Property changeLogFileNumRegistrations As Integer = 0
        Public Property useBufferToWrite As Boolean = False
        Public Property writeToFile As Boolean = False

    End Class

    ''' <summary>
    ''' This method provide to collect all element of a auto maintenance settings service
    ''' </summary>
    Public Class SettingsAutoMaintenanceSidechainService

        Public Property autoMaintenanceFrequencyHours As Integer = 0

        Public Property trackLogRotateConfig As New Log.LogRotateConfig

    End Class

    ''' <summary>
    ''' This class contain all properties of settings chain runtime
    ''' </summary>
    Public Class SettingsSidechainServiceBase

        Public Enum EnumServiceMode
            app
            service
            webService
        End Enum

        Public Property sideChainName As String = ""

        Public Property internalName As String = ""
        Public Property networkReferement As String = ""
        Public Property serviceMode As EnumServiceMode = EnumServiceMode.app
        Public Property middlePath As String = ""
        Public Property serviceID As String = ""
        Public Property staticIP As String = ""
        Public Property publicAddress As String = ""
        Public Property clientCertificate As String = ""

        Public Property publicPort As Integer = 0
        Public Property servicePort As Integer = 0

        Public Property intranetMode As Boolean = False
        Public Property secureChannel As Boolean = False

        Public Property useLog As Boolean = False
        Public Property useEventRegistry As Boolean = False
        Public Property useRequestCounter As Boolean = False
        Public Property useAdminMessage As Boolean = False
        Public Property useProfile As Boolean = False
        Public Property useAlert As Boolean = False

        Public Property useAutomaintenance As Boolean = False

    End Class

    ''' <summary>
    ''' This class contain all element of complete settings of a sidechain
    ''' </summary>
    Public Class SettingsSidechainServiceComplete

        Inherits SettingsSidechainServiceBase

        Public Property logSettings As New SettingsLogSidechainService
        Public Property autoMaintenance As New SettingsAutoMaintenanceSidechainService

        Public ReadOnly Property getServiceBase() As SettingsSidechainServiceBase
            Get
                Dim data As New SettingsSidechainServiceBase

                data.clientCertificate = MyBase.clientCertificate
                data.internalName = MyBase.internalName
                data.intranetMode = MyBase.intranetMode
                data.middlePath = MyBase.middlePath
                data.networkReferement = MyBase.networkReferement
                data.publicAddress = MyBase.publicAddress
                data.publicPort = MyBase.publicPort
                data.secureChannel = MyBase.secureChannel
                data.serviceID = MyBase.serviceID
                data.serviceMode = MyBase.serviceMode
                data.servicePort = MyBase.servicePort
                data.sideChainName = MyBase.sideChainName
                data.staticIP = MyBase.staticIP
                data.useAdminMessage = MyBase.useAdminMessage
                data.useAlert = MyBase.useAlert
                data.useAutomaintenance = MyBase.useAutomaintenance
                data.useEventRegistry = MyBase.useEventRegistry
                data.useLog = MyBase.useLog
                data.useProfile = MyBase.useProfile
                data.useRequestCounter = MyBase.useRequestCounter

                Return data
            End Get
        End Property

    End Class

    ''' <summary>
    ''' This class contain all information of request update settings
    ''' </summary>
    Public Class ResponseUpdateSettingsModel

        Inherits Network.Response.BaseRemoteResponse

        Public Property value As SettingsSidechainServiceComplete

    End Class

    ''' <summary>
    ''' This class response the Log Setting
    ''' </summary>
    Public Class ResponseLogSettingsModel

        Inherits Network.Response.BaseRemoteResponse

        Public Property value As New SettingsLogSidechainService

    End Class

End Namespace
