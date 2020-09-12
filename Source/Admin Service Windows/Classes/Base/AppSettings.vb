Option Compare Text
Option Explicit On




Public Class AppSettings

    Inherits CHCCommonLibrary.CHCEngines.Common.BaseEncryption(Of SettingsData)


    Public Enum TrackRuntimeModeEnum

        dontTrack
        trackOnlyMain
        trackAllRuntime

    End Enum

    Public Class CommunicationServiceInformation

        Public useSecure As Boolean = False
        Public url As String = ""
        Public certificate As String = ""

        Public Function secureToString() As String

            If useSecure Then

                Return "https://"

            Else

                Return "http://"

            End If

        End Function

        Public Function composeURL(ByVal intermediateValue As String, Optional ByVal useCertificate As Boolean = False) As String

            If useCertificate Then

                Return secureToString() & url & intermediateValue & "?certificate=" & certificate

            Else

                Return secureToString() & url & intermediateValue

            End If

        End Function

    End Class


    Public Class SettingsData

        Public gui As Boolean = False

        Public dataPath As String = ""
        Public walletPublicAddress As String = ""
        Public portNumber As Integer = 1122

        Public useTrack As TrackRuntimeModeEnum = TrackRuntimeModeEnum.trackAllRuntime
        Public useTrackRotate As Boolean = False
        Public trackRotate As New CHCServerSupport.Support.LogRotateEngine.LogRotateConfig

        Public useEventRegistry As Boolean = True

        Public serviceStart As New CommunicationServiceInformation
        Public serviceRuntime As New CommunicationServiceInformation

        Public certificateClient As String = ""

        Public noConsoleMessage As Boolean = False
        Public recallStarter As Boolean = False

    End Class

End Class