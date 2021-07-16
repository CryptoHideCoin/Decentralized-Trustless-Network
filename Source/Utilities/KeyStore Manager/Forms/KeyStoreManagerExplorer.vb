Option Compare Text
Option Explicit On


Public Class KeyStoreManagerExplorer

    Public Property pathData As String = ""


    Private Sub mainWalletAddressList_Load(sender As Object, e As EventArgs) Handles mainWalletAddressList.Load
        Try
            If AreaCommon.main() Then
                pathData = AreaCommon.paths.pathWalletData

                mainWalletAddressList.dataPath = pathData

                mainWalletAddressList.autonomous = True
            Else
                End
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class