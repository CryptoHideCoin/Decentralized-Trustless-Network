Option Compare Text
Option Explicit On


Public Class KeyStoreManagerExplorer

    Public Property pathData As String = ""


    Private Sub mainWalletAddressList_Load(sender As Object, e As EventArgs) Handles mainWalletAddressList.Load
        Try
            If AreaCommon.main() Then
                pathData = AreaCommon.paths.pathWalletData

                mainWalletAddressList.dataPath = pathData
            Else
                End
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mainWalletAddressList_RequestAddNew() Handles mainWalletAddressList.RequestAddNew
        Try
            Dim form As New WalletAddressDetailForm

            form.pathData = pathData

            form.ShowDialog(Me)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mainWalletAddressList_RequestUpdate(UUID As String) Handles mainWalletAddressList.RequestUpdate
        Try
            Dim form As New WalletAddressDetailForm

            form.pathData = pathData
            form.loadData(UUID)

            If Not form.closeMe Then
                form.ShowDialog(Me)
            End If

            form.Close()
            form.Dispose()

            form = Nothing
        Catch ex As Exception
        End Try
    End Sub

End Class