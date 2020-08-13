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

        Public gui As Boolean = False

        Public dataPath As String = ""
        Public walletPublicAddress As String = ""
        Public portNumber As Integer = 1122

        Public useTrack As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New CHCServerSupport.Support.LogRotateEngine.LogRotateConfig

        Public useEventRegistry As Boolean = True

        Public urlMasternodeStart As String = ""
        Public certificateMasternodeStart As String = ""

        Public urlMasternodeEngine As String = ""
        Public certificateMasternodeEngine As String = ""

        Public certificateClient As String = ""

        Public noConsoleMessage As Boolean = False
        Public recallStarter As Boolean = False

    End Class

End Class