Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCCommonLibrary.Support




Public Class AppSettings

    Inherits BaseFile(Of SettingsData)



    Public Class SettingsData

        Public dataPath As String = ""
        Public currentConfiguration As String = ""

        Public useSecureProtocol As Boolean = False
        Public urlPublic As String = ""
        Public serviceId As String = ""

        Public personalPublicAddress As String = ""

        Public useServiceSecureProtocol As Boolean = False
        Public urlService As String = ""
        Public certificateService As String = ""
        Public adminPublicAddress As String = ""

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAll
        Public trackRotate As New LogRotateEngine.LogRotateConfig

    End Class


End Class