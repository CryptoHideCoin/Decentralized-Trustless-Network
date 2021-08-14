Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement
Imports CHCCommonLibrary.Support




Public Class AppSettings

    Inherits BaseEncryption(Of SettingsData)



    Public Class SettingsData

        Public dataPath As String = ""
        Public currentConfiguration As String = ""
        Public serviceId As String = ""

        Public useTrack As LogEngine.TrackRuntimeModeEnum = LogEngine.TrackRuntimeModeEnum.trackAllRuntime
        Public trackRotate As New LogRotateEngine.LogRotateConfig

        Public requesterWalletAddress As String = ""

        Public publicAddressIPPrimaryChain As String = ""

    End Class


End Class