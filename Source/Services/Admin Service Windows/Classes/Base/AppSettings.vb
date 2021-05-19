Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon
Imports CHCServerSupportLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement



Public Class AppSettings

    Inherits BaseEncryption(Of SettingsData)



    Public Class SettingsData

        Public gui As Boolean = False

        Public dataPath As String = ""
        Public walletPublicAddress As String = ""
        Public portNumber As Integer = 1122

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
        Public useTrackRotate As Boolean = False
        Public trackRotate As New LogRotateEngine.LogRotateConfig

        Public useEventRegistry As Boolean = True

        Public serviceLoader As New Models.CommunicationServiceInformation
        Public serviceRuntime As New Models.CommunicationServiceInformation

        Public certificateClient As String = ""

        Public noConsoleMessage As Boolean = False
        Public recallLoader As Boolean = False

    End Class

End Class