Option Compare Text
Option Explicit On





Namespace Models.Administration



    Public Class SettingModel

        Public Enum TrackRuntimeModeEnum

            dontTrack
            trackOnlyMain
            trackAllRuntime

        End Enum

        Public name As String = ""
        Public useIntranet As Boolean = False
        Public useProtectionKEY As Boolean = False

        Public protectionKEY As String = ""

        Public walletPublicAddress As String = ""
        Public walletPrivateKEY As String = ""

        Public useTrack As TrackRuntimeModeEnum = TrackRuntimeModeEnum.dontTrack
        Public trackRotate As New CHCServerSupport.Support.LogRotateEngine.LogRotateConfig

    End Class


    Public Class SettingRequestModel

        Inherits SettingModel

        Public [keywords] As String = ""



        Public Function copyIntoBaseModel() As SettingModel

            Dim tmp As New SettingModel

            tmp.name = MyBase.name

            tmp.trackRotate.frequency = MyBase.trackRotate.frequency
            tmp.trackRotate.keepFile = MyBase.trackRotate.keepFile
            tmp.trackRotate.keepLast = MyBase.trackRotate.keepFile

            tmp.useIntranet = MyBase.useIntranet
            tmp.useProtectionKEY = MyBase.useProtectionKEY

            tmp.protectionKEY = MyBase.protectionKEY

            tmp.useTrack = MyBase.useTrack

            tmp.walletPrivateKEY = MyBase.walletPrivateKEY
            tmp.walletPublicAddress = MyBase.walletPublicAddress

            Return tmp

        End Function

    End Class


End Namespace
