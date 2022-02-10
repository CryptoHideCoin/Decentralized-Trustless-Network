Option Compare Text
Option Explicit On

Imports CHCServerSupportLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Public Class AppSettings

    Inherits BaseEncryption(Of SettingsData)



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
        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New LogRotateEngine.LogRotateConfig
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