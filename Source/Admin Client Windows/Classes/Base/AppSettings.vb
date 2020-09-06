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

        Public useTrack As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New CHCServerSupport.Support.LogRotateEngine.LogRotateConfig

        Public useSecureAddress As Boolean = False
        Public urlMasternodeAdmin As String = ""
        Public certificateMasternodeAdmin As String = ""

    End Class


End Class