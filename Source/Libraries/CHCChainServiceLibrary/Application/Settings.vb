Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support




Namespace AreaChain.Runtime.Models

    ''' <summary>
    ''' This class contain all properties of settings chain runtime
    ''' </summary>
    Public Class SettingsChainService

        Public Property chainName As String = ""

        Public Property internalName As String = ""
        Public Property networkReferement As String = ""
        Public Property serviceID As String = ""
        Public Property publicAddress As String = ""
        Public Property clientCertificate As String = ""

        Public Property publicPort As Integer = 0
        Public Property servicePort As Integer = 0

        Public Property intranetMode As Boolean = False
        Public Property secureChannel As Boolean = False

        Public Property trackConfiguration As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAll
        Public Property logFileMaxNumHours As Integer = 0
        Public Property logFileNumRegistrations As Integer = 0
        Public Property useTrackRotate As Boolean = False
        Public Property trackRotateConfig As New LogRotateEngine.LogRotateConfig

        Public Property useEventRegistry As Boolean = True
        Public Property useRequestCounter As Boolean = True

    End Class

End Namespace