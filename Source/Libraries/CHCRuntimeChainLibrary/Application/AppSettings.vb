Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.Support
Imports CHCCommonLibrary.AreaEngine.DataFileManagement


Namespace AreaRuntime

    Public Class AppSettings

        Inherits BaseEncryption(Of SettingsData)



        Public Class SettingsData
            Public networkName As String = ""
            Public serviceId As String = ""
            Public intranetMode As Boolean = False
            Public noUpdateSystemDate As Boolean = False
            Public dataPath As String = ""
            Public walletAddress As String = ""

            Public publicPort As Integer = 0
            Public servicePort As Integer = 0

            Public clientCertificate As String = ""

            Public trackConfiguration As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAll
            Public useTrackRotate As Boolean = False
            Public trackRotateConfig As New LogRotateEngine.LogRotateConfig

            Public useEventRegistry As Boolean = True
        End Class

    End Class

End Namespace