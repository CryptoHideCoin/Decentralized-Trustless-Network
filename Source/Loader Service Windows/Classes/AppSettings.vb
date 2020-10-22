Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCServerSupportLibrary.Support




Public Class AppSettings

    Inherits BaseEncryption(Of SettingsData)




    Public Class SettingsData

        Public Enum SourceOfUpgradeEnum
            notDefined
            staticAddress
            blockChainAddress
        End Enum

        Public Enum FrequencyUpgradeEnum
            notDefined
            every12h
            every24h
        End Enum

        Public Class ServiceData
            Public protocolSecure As Boolean = False
            Public url As String = ""
            Public certificate As String = ""
            Public applicationPath As String = ""
        End Class

        Public dataPath As String = ""
        Public walletPublicAddress As String = ""
        Public portNumber As Integer = 1123

        Public trackMode As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
        Public useTrackRotate As Boolean = False
        Public trackRotate As New LogRotateEngine.LogRotateConfig

        Public protocolSecureServiceAdmin As Boolean = False
        Public urlServiceAdmin As String = ""
        Public certificateServiceAdmin As String = ""

        Public gui As Boolean = False

        Public useEventRegistry As Boolean = True
        Public autoStart As Boolean = False
        Public debugMode As Boolean = False

        Public automaticCheckUpdate As Boolean = False
        Public sourceOfUpgrade As SourceOfUpgradeEnum = SourceOfUpgradeEnum.notDefined
        Public sourceOfUpgradeAddress As String = ""
        Public upgradeCertificate As String = ""
        Public frequencyUpgrade As FrequencyUpgradeEnum = FrequencyUpgradeEnum.notDefined

        Public services As New List(Of ServiceData)

    End Class


End Class