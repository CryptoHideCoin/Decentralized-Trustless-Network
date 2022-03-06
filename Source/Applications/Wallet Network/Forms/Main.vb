Option Compare Text
Option Explicit On


Public Class Main

    Private Sub ConfigurationManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurationManagerToolStripMenuItem.Click
        Try
            CurrentChainToolStripMenuItem.Enabled = False

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
        dataChainContainer.Visible = False
        dataSupplyContainer.Visible = False
        dataLedgerContainer.Visible = False
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
            CurrentChainToolStripMenuItem.Enabled = False

            dataNetworkContainer.Visible = True

            dataNetworkContainer.Location = New Point(0, 0)
            dataNetworkContainer.Dock = DockStyle.Fill

            dataNetworkContainer.type = elementType

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function showChainPanel(ByVal elementType As Chains.ManageType) As Boolean
        Try
            hideAllPanels()

            dataChainContainer.Visible = True

            dataChainContainer.Location = New Point(0, 0)
            dataChainContainer.Dock = DockStyle.Fill

            dataChainContainer.type = elementType

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function showChainContainer() As Boolean
        Try
            hideAllPanels()
            ExplorerToolStripMenuItem.HideDropDown()
            CurrentChainToolStripMenuItem.Enabled = False

            dataChainContainer.Visible = True

            dataChainContainer.Location = New Point(0, 0)
            dataChainContainer.Dock = DockStyle.Fill

            dataChainContainer.type = Chains.ManageType.list

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function showChainLastBlock() As Boolean
        Try
            hideAllPanels()

            dataChainContainer.Visible = True

            dataChainContainer.Location = New Point(0, 0)
            dataChainContainer.Dock = DockStyle.Fill

            dataChainContainer.type = Chains.ManageType.lastBlock

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function showSupplyPanel() As Boolean
        Try
            hideAllPanels()

            dataSupplyContainer.Visible = True

            dataSupplyContainer.Location = New Point(0, 0)
            dataSupplyContainer.Dock = DockStyle.Fill

            Return dataSupplyContainer.run()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function showLedgerSummaryPanel() As Boolean
        Try
            hideAllPanels()

            dataLedgerContainer.Visible = True

            dataLedgerContainer.Location = New Point(0, 0)
            dataLedgerContainer.Dock = DockStyle.Fill

            dataLedgerContainer.type = ledgerPanel.ManageType.summary

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function showLedgerPagePanel() As Boolean
        Try
            hideAllPanels()

            dataLedgerContainer.Visible = True

            dataLedgerContainer.Location = New Point(0, 0)
            dataLedgerContainer.Dock = DockStyle.Fill

            dataLedgerContainer.type = ledgerPanel.ManageType.ledger

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
        CurrentChainToolStripMenuItem.Enabled = False

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
        showChainContainer()
    End Sub

    Private Sub dataChainContainer_Load(sender As Object, e As EventArgs) Handles dataChainContainer.Load

    End Sub

    Private Sub dataChainContainer_OpenConfiguration() Handles dataChainContainer.OpenConfiguration
        ConfigurationManager.ShowDialog()

        dataChainContainer.Visible = False
        showMainBackground()
        CurrentChainToolStripMenuItem.Enabled = False
    End Sub

    Private Sub dataChainContainer_OpenChainDetails() Handles dataChainContainer.OpenChainDetails
        CurrentChainToolStripMenuItem.Enabled = True
    End Sub

    Private Sub LastBlockInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LastBlockInformationToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.lastBlock)
    End Sub

    Private Sub CurrentChainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrentChainToolStripMenuItem.Click

    End Sub

    Private Sub chainParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles chainParametersToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.parameters)
    End Sub

    Private Sub SetProtocolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetProtocolsToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.setProtocol)
    End Sub

    Private Sub PriceListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceListToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.priceList)
    End Sub

    Private Sub privacyPolicyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles privacyPolicyToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.privacyPolicy)
    End Sub

    Private Sub TermsAndConditionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermsAndConditionsToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.termsAndConditions)
    End Sub

    Private Sub TokensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TokensToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.tokens)
    End Sub

    Private Sub MasternodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasternodesToolStripMenuItem.Click
        showChainPanel(Chains.ManageType.masterNodes)
    End Sub

    Private Sub dataChainContainer_CloseMe() Handles dataChainContainer.CloseMe
        showMainBackground()
    End Sub

    Private Sub SupplyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles supplyToolStripMenuItem.Click
        showSupplyPanel()
    End Sub

    Private Sub generalInformationsBlockChainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles generalInformationsBlockChainToolStripMenuItem.Click
        showLedgerSummaryPanel()
    End Sub

    Private Sub monitorLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles monitorLedgerToolStripMenuItem.Click
        showLedgerPagePanel()
    End Sub

    Private Sub dataLedgerContainer_Load(sender As Object, e As EventArgs) Handles dataLedgerContainer.Load

    End Sub

    Private Sub dataLedgerContainer_OpenConfiguration() Handles dataLedgerContainer.OpenConfiguration
        ConfigurationManager.ShowDialog()

        dataLedgerContainer.Visible = False
        CurrentChainToolStripMenuItem.Enabled = False

        showMainBackground()
    End Sub
End Class
