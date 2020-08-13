Option Compare Text
Option Explicit On




Public Class AppSettings

    Inherits CHCCommonLibrary.CHCEngines.Common.BaseEncryption(Of SettingsData)


    Public Enum TrackRuntimeModeEnum

        dontTrack
        trackOnlyMain
        trackAllRuntime

    End Enum


    Public Class SettingsData

        Public dataPath As String = ""
        Public walletPublicAddress As String = ""
        Public portNumber As Integer = 1123

        Public useTrack As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New CHCServerSupport.Support.LogRotateEngine.LogRotateConfig

        Public useEventRegistry As Boolean = True

        Public urlMasternodeAdmin As String = ""
        Public certificateMasternodeAdmin As String = ""

        Public urlMasternodeRuntime As String = ""
        Public certificateMasternodeRuntime As String = ""

        Public gui As Boolean = False

        Public autoStart As Boolean = False
        Public debugMode As Boolean = False

    End Class

End Class