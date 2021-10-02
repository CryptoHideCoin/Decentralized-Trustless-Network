Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCCommonLibrary.Support




Public Class AppSettings

    Inherits BaseFile(Of SettingsData)



    Public Class SettingsData

        Public dataPath As String = ""
        Public currentConfiguration As String = ""
        Public serviceId As String = ""
        Public serviceWalletAddressAdmin As String = ""

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAll
        Public trackRotate As New LogRotateEngine.LogRotateConfig

        Public useSecureProtocol As Boolean = False
        Public urlNodeServiceAdmin As String = ""
        Public certificateServiceAdmin As String = ""

    End Class


End Class