Imports CHCMasterNodeEngineLibrary



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


    Private Function getStatusSystem() As String

        Try

            Dim pws As New CHCCommonLibrary.CHCEngines.Communication.ProxyWS(Of Models.EnumPeerStatus)

            pws.url = "https://localhost:44392/api/v1/Peer/Information/CurrentStatus/"

            If pws.getData() Then

                If (pws.data = Models.EnumPeerStatus.onLine) Then

                    Return " On line"

                Else

                    Return " Off line"

                End If

            Else

                MessageBox.Show("No connection available or wrong address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

        End Try

        Return ""

    End Function


    Private Sub MenuEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        manageCommandLine()

        systemStatusLabel.Text += getStatusSystem()
        appReleaseLabel.Text += " rel." & My.Application.Info.Version.ToString()

        If Not readSettings() Then

            End

        End If

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