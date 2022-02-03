Option Compare Text
Option Explicit On




Public Class SettingsPage

    Public Enum EnumPeerStatus

        offLine
        onLine

    End Enum

    Public data As New SettingsEngine.SettingsData
    Public passwordKey As String


    Public Class ResponseGetPublic

        Public response As String

    End Class



    Public Function init() As Boolean

        urlValue.Text = data.urlBase
        apiKeyValue.Text = data.apiKey
        apiPasswordValue.Text = data.apiPassword
        adminWalletAddressValue.Text = data.adminPublicAddressWallet
        adminPrivateKeyValue.Text = data.adminPublicAddressWallet

        Return True

    End Function



    Private Function connectURL(ByVal url As String) As Boolean

        Try

            Dim tmp As New CHCCommonLibrary.CHCEngines.Communication.ProxySimplyWS(Of EnumPeerStatus)
            Dim errorDescription As String

            tmp.url = url & "api/v1/Peer/Information/CurrentStatus"

            errorDescription = tmp.getData()

            Return (errorDescription.Length = 0)

        Catch ex As Exception

            Return False

        End Try

    End Function


    Private Sub connectButton_Click(sender As Object, e As EventArgs) Handles connectButton.Click

        If (urlValue.Text.Trim.Length() = 0) Then

            MessageBox.Show("URL base is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        If Not connectURL(urlValue.Text) Then

            MessageBox.Show("URL base is wrong or missing connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        RequestPassword.ShowDialog()

        If (RequestPassword.DialogResult = DialogResult.OK) Then

            passwordKey = RequestPassword.PasswordKEY

        Else

            passwordKey = ""

        End If

        DialogResult = DialogResult.OK
        Hide()

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        DialogResult = DialogResult.Cancel
        Hide()

    End Sub



End Class