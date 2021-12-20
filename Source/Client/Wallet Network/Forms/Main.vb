Option Compare Text
Option Explicit On


Public Class Main

    Private Sub ConfigurationManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurationManagerToolStripMenuItem.Click
        Try
            ConfigurationManager.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error", "Problem with load a configuration manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Informations.ShowDialog()
    End Sub


    Private Sub hideAllPanels()
        mainBackGround.Visible = False
        dataNetworkContainer.Visible = False
    End Sub

    Private Function showMainBackground() As Boolean
        Try
            hideAllPanels()

            mainBackGround.Visible = True

            mainBackGround.Location = New Point(0, 0)
            mainBackGround.Dock = DockStyle.Fill

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function showDataNetwork(ByVal elementType As GenericInformation.ManageType) As Boolean
        Try
            hideAllPanels()

            dataNetworkContainer.Visible = True

            dataNetworkContainer.Location = New Point(0, 0)
            dataNetworkContainer.Dock = DockStyle.Fill

            dataNetworkContainer.type = elementType

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showMainBackground()

        Try
            If Not AreaCommon.StartUp.Main() Then
                End
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurrent during Main_Load " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GeneralInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralInformationToolStripMenuItem.Click
        showDataNetwork(GenericInformation.ManageType.netWorkInformation)
    End Sub

    Private Sub WhitepaperToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles WhitepaperToolStripMenuItem1.Click
        showDataNetwork(GenericInformation.ManageType.whitePaper)
    End Sub

    Private Sub YellowpaperToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles YellowpaperToolStripMenuItem1.Click
        showDataNetwork(GenericInformation.ManageType.yellowPaper)
    End Sub

    Private Sub PrivacyPolicyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrivacyPolicyToolStripMenuItem1.Click
        showDataNetwork(GenericInformation.ManageType.privacyPolicy)
    End Sub

    Private Sub TermsAndConditionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TermsAndConditionsToolStripMenuItem1.Click
        showDataNetwork(GenericInformation.ManageType.generalConditions)
    End Sub

    Private Sub dataNetworkContainer_Load(sender As Object, e As EventArgs) Handles dataNetworkContainer.Load

    End Sub

    Private Sub dataNetworkContainer_OpenConfiguration() Handles dataNetworkContainer.OpenConfiguration
        ConfigurationManager.ShowDialog()

        dataNetworkContainer.Visible = False
        showMainBackground()
    End Sub

    Private Sub AssetPolicyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssetPolicyToolStripMenuItem.Click
        showDataNetwork(GenericInformation.ManageType.assetInformation)
    End Sub

    Private Sub TransactionChainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionChainToolStripMenuItem.Click
        showDataNetwork(GenericInformation.ManageType.transactionChainParameters)
    End Sub

    Private Sub RefundPlanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefundPlanToolStripMenuItem1.Click
        showDataNetwork(GenericInformation.ManageType.refundPlan)
    End Sub

    Private Sub ChainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChainToolStripMenuItem.Click

    End Sub
End Class
