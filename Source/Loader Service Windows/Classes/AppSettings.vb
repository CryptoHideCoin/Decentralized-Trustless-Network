Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCServerSupportLibrary.Support




Public Class AppSettings

    Inherits BaseEncryption(Of SettingsData)




    Public Class SettingsData

        Public dataPath As String = ""
        Public walletPublicAddress As String = ""
        Public portNumber As Integer = 1123

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New LogRotateEngine.LogRotateConfig

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