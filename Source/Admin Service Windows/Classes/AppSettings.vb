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
        Public portNumber As Integer = 1122

        Public useTrack As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New CHCServerSupport.Support.LogRotateEngine.LogRotateConfig

        Public useEventRegistry As Boolean = True

        Public urlMasternodeStart As String = ""
        Public certificateMasternodeStart As String = ""

        Public urlMasternodeRuntime As String = ""
        Public certificateMasternodeRuntime As String = ""

        Public certificateClient As String = ""

    End Class

End Class