Option Compare Text
Option Explicit On



Public Class WalletAddressDetailForm

    Public Property closeMe As Boolean = False

    Public Property pathData As String
        Get
            Return mainCustomizeWalletAddress.pathData
        End Get
        Set(value As String)
            mainCustomizeWalletAddress.pathData = value
        End Set
    End Property


    Private Sub mainCustomizeWalletAddress_requestAccessSecurityKey(ByRef value As String, ByRef cancelValue As Boolean) Handles mainCustomizeWalletAddress.RequestAccessSecurityKey
        Try
            Dim tmp As New RequestPassword

            If (tmp.ShowDialog() = DialogResult.OK) Then
                value = tmp.passwordTextBox.Text
            Else
                cancelValue = True
            End If

            tmp.Close()

            tmp.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mainCustomizeWalletAddress_CloseMe() Handles mainCustomizeWalletAddress.CloseMe
        DialogResult = DialogResult.OK
        closeMe = True
    End Sub

    Public Sub loadData(ByVal UUID As String)
        mainCustomizeWalletAddress.UUID = UUID
    End Sub


End Class
