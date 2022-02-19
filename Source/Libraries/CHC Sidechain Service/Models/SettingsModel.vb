Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support




Namespace AreaChain.Runtime.Models

    ''' <summary>
    ''' This class contain all properties of settings chain runtime
    ''' </summary>
    Public Class SettingsSidechainService

        Public Property sideChainName As String = ""

        Public Property internalName As String = ""
        Public Property networkReferement As String = ""
        Public Property serviceID As String = ""
        Public Property publicAddress As String = ""
        Public Property clientCertificate As String = ""

        Public Property publicPort As Integer = 0
        Public Property servicePort As Integer = 0
        Public Property localWorkMachinePort As Integer = 0

        Public Property intranetMode As Boolean = False
        Public Property secureChannel As Boolean = False

        Public Property trackConfiguration As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAll
        Public Property changeLogFileMaxNumHours As Integer = 0
        Public Property changeLogFileNumRegistrations As Integer = 0

        Public Property useAutoMaintanance As Boolean = False
        Public Property autoMaintenanceFrequencyHours As Integer = 0

        Public Property trackRotateConfig As New LogRotateEngine.LogRotateConfig

        Public Property useEventRegistry As Boolean = False
        Public Property useRequestCounter As Boolean = False
        Public Property useAdminMessage As Boolean = False

    End Class

End Namespace
