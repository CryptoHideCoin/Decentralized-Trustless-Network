Public Class MenuEditor

    Private _CommandLineEngine As New CHCCommonLibrary.CHCEngines.Miscellaneous.CommandLineParameters

    Private _CompletePathValue As String = ""





    Sub manageCommandLine()

        Try

            _CommandLineEngine.decode(Environment.CommandLine.Split("/"))

            If _CommandLineEngine.exist("ForceDataPath".ToLower()) Then

                _CompletePathValue = _CommandLineEngine.GetValue("ForceDataPath".ToLower())

            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub MenuEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        manageCommandLine()

        appReleaseLabel.Text += " rel." & My.Application.Info.Version.ToString()

    End Sub

    Private Sub contractOfValueMenu_Click(sender As Object, e As EventArgs) Handles contractOfValueMenu.Click

        CryptoAssetEditor.forceDataPath = _CompletePathValue
        CryptoAssetEditor.ShowDialog()

    End Sub

    Private Sub networkButton_Click(sender As Object, e As EventArgs) Handles networkButton.Click

        TransChainEditor.forceDataPath = _CompletePathValue
        TransChainEditor.ShowDialog()

    End Sub


End Class