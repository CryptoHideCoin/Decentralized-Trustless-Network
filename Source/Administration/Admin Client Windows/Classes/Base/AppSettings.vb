Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCServerSupportLibrary.Support




Public Class AppSettings

    Inherits BaseEncryption(Of SettingsData)



    Public Class SettingsData

        Public dataPath As String = ""
        Public walletPublicAddress As String = ""

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New LogRotateEngine.LogRotateConfig

        Public useSecureAddress As Boolean = False
        Public urlMasternodeAdmin As String = ""
        Public certificateMasternodeAdmin As String = ""

    End Class


End Class