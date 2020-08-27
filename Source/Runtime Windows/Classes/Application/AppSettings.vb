Option Compare Text
Option Explicit On




Public Class AppSettings

    Inherits CHCCommonLibrary.CHCEngines.Common.BaseEncryption(Of SettingsData)


    Public Enum TrackRuntimeModeEnum

        dontTrack
        trackOnlyMain
        trackAllRuntime

    End Enum

    Public Class NodeList

        Public address As String = ""
        Public servicePort As String = ""

    End Class

    Public Class SettingsData

        Public virtualName As String = ""
        Public intranetMode As Boolean = False
        Public noUpdateSystemDate As Boolean = False
        Public dataPath As String = ""
        Public walletAddress As String = ""
        Public walletKey As String = ""
        Public useTrack As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New CHCServerSupport.Support.LogRotateEngine.LogRotateConfig
        Public useEventRegistry As Boolean = True
        Public urlMasternodeAdmin As String = ""
        Public certificateMasternodeAdmin As String = ""
        Public urlMasternodeStart As String = ""
        Public certificateMasternodeStart As String = ""
        Public autoStart As Boolean = False
        Public transactionChainConfig As String = ""

        Public services As New List(Of AreaChain.NodesEngine.NodeInformation.configurationPort)

    End Class

End Class