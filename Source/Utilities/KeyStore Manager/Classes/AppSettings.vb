Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.Support




Public Class AppSettings

    Inherits BaseEncryption(Of SettingsData)



    Public Class SettingsData

        Public dataPath As String = ""

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAll
        Public trackRotate As New LogRotateEngine.LogRotateConfig

    End Class


End Class