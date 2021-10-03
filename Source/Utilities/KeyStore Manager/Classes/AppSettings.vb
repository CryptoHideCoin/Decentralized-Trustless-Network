Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML
Imports CHCCommonLibrary.Support




Public Class AppSettings

    Inherits BaseFile(Of SettingsData)



    Public Class SettingsData

        Public dataPath As String = ""

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAll
        Public trackRotate As New LogRotateEngine.LogRotateConfig

    End Class


End Class