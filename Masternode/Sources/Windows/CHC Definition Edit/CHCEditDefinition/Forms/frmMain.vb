Option Compare Text
Option Explicit On



Public Class frmMain


    Private _Data As CryptoHideCoinEditDefinition.SystemDefinition
    Private _Engine As New AreaInfrastructure.Secure.BaseEncryption(Of CryptoHideCoinEditDefinition.SystemDefinition)
    Private _NoSave As Boolean = False
    Private _CommandLineEngine As New Xellinter.Utilities.CommandLineParameters



    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        Dim dlgTemp As New FolderBrowserDialog()

        dlgTemp.RootFolder = Environment.SpecialFolder.Desktop
        dlgTemp.SelectedPath = "C:\"

        dlgTemp.Description = "Select a folder"

        If dlgTemp.ShowDialog() = DialogResult.OK Then

            txtCompletePath.Text = dlgTemp.SelectedPath

        End If

    End Sub



    Private Function ReadData(ByVal strFileName As String) As Boolean

        Try

            _Engine.NoCrypt = True
            _Engine.FileName = strFileName

            If _Engine.Read() Then

                _Data = _Engine.Data

                Return True

            End If

        Catch ex As Exception

        End Try

        Return False

    End Function



    Private Function UpdateData() As Boolean

        Try

            Dim strFileName As String = DeterminateFileName()

            If _NoSave Then Return True
            If strFileName.Length = 0 Then

                txtIdentity.Text = "NO FILE"
                Return False

            End If

            If IsNumeric(txtIdentity.Text) Then

                _Engine.NoCrypt = True
                _Engine.FileName = strFileName

                If _Engine.Save() Then

                    Return True

                End If

            End If

        Catch ex As Exception

            MessageBox.Show("Error " & ex.Message, "Error")

        End Try

        Return False

    End Function



    Private Sub CompileAllData()

        Try

            _NoSave = True

            txtIdentity.Text = _Data.Identity
            txtNetworkName.Text = _Data.NetworkName

            If (_Data.Type = CryptoHideCoinEditDefinition.SystemDefinition.EnumEntityType.COIN) Then

                cmbType.SelectedIndex = 0

            ElseIf (_Data.Type = CryptoHideCoinEditDefinition.SystemDefinition.EnumEntityType.TOKEN) Then

                cmbType.SelectedIndex = 1

            Else

                cmbType.SelectedIndex = -1

            End If

            txtCoinName.Text = _Data.Name
            txtShortName.Text = _Data.ShortName
            txtSymbol.Text = _Data.Symbol

            If (_Data.DateStartNetwork = DateTime.MinValue) Then

                chkSchedule.Checked = False
                lblDateStartNetwork.Enabled = False
                dtpStartNetwork.Enabled = False
                dtpStartNetwork.Value = #01/01/2019#

            Else

                chkSchedule.Checked = True
                lblDateStartNetwork.Enabled = True
                dtpStartNetwork.Enabled = True
                dtpStartNetwork.Value = _Data.DateStartNetwork.ToLocalTime()

            End If

            chkBurnable.Checked = _Data.Burnable
            chkNoTotal.Checked = _Data.NoLimit
            txtPremined.Text = _Data.PreminedNumber
            txtTotalCoin.Text = _Data.Total
            txtNumOfDecimal.Text = _Data.NumberOfDecimal
            lblSymbol1.Text = _Data.Symbol
            lblSymbol2.Text = _Data.Symbol
            txtWalletPremined.Text = _Data.WalletAddressPremined
            txtHourNodeConsensus.Text = _Data.NodeLayerConsensusConfiguration.Start
            txtDurateNodeConsensus.Text = _Data.NodeLayerConsensusConfiguration.Durate

            If _Data.NoLimit Then

                lblTotalCoin.Enabled = False

                txtTotalCoin.Enabled = False
                txtTotalCoin.Text = ""

                lblSymbol2.Enabled = False

            End If

            _NoSave = False

        Catch ex As Exception

            txtIdentity.Text = "ERROR"

        End Try

    End Sub



    Private Function DeterminateFileName() As String

        Dim strCompleteFileName As String

        Try

            strCompleteFileName = IO.Path.Combine(txtCompletePath.Text, "Coin.definition")

            If (strCompleteFileName.Length > 0) Then

                Return strCompleteFileName

            End If

        Catch

        End Try

        Return ""

    End Function



    Private Sub txtCompletePath_TextChanged(sender As Object, e As EventArgs) Handles txtCompletePath.TextChanged

        Try

            If Not ReadData(DeterminateFileName()) Then

                _Data = New CryptoHideCoinEditDefinition.SystemDefinition

            End If

            CompileAllData()

        Catch ex As Exception

        End Try

    End Sub



    Private Sub txtNetworkName_TextChanged(sender As Object, e As EventArgs) Handles txtNetworkName.TextChanged

        If _NoSave Then Return

        _Data.NetworkName = txtNetworkName.Text
        txtIdentity.Text = _Data.Identity

    End Sub



    Private Sub txtNetworkName_Leave(sender As Object, e As EventArgs) Handles txtNetworkName.Leave

        UpdateData()

    End Sub

    Private Sub txtCoinName_TextChanged(sender As Object, e As EventArgs) Handles txtCoinName.TextChanged

        If _NoSave Then Return

        _Data.Name = txtCoinName.Text
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub txtCoinName_Leave(sender As Object, e As EventArgs) Handles txtCoinName.Leave

        UpdateData()

    End Sub

    Private Sub txtShortName_TextChanged(sender As Object, e As EventArgs) Handles txtShortName.TextChanged

        If _NoSave Then Return

        _Data.ShortName = txtShortName.Text
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub txtShortName_Leave(sender As Object, e As EventArgs) Handles txtShortName.Leave

        UpdateData()

    End Sub

    Private Sub txtSymbol_TextChanged(sender As Object, e As EventArgs) Handles txtSymbol.TextChanged

        If _NoSave Then Return

        _Data.Symbol = txtSymbol.Text
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub txtSymbol_Leave(sender As Object, e As EventArgs) Handles txtSymbol.Leave

        UpdateData()

    End Sub



    Private Sub chkBurnable_CheckedChanged(sender As Object, e As EventArgs) Handles chkBurnable.CheckedChanged

        If _NoSave Then Return

        _Data.Burnable = chkBurnable.Checked
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub chkBurnable_Leave(sender As Object, e As EventArgs) Handles chkBurnable.Leave

        UpdateData()

    End Sub

    Private Sub txtPremined_TextChanged(sender As Object, e As EventArgs) Handles txtPremined.TextChanged

        If _NoSave Then Return

        _Data.PreminedNumber = txtPremined.Text
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub txtPremined_Leave(sender As Object, e As EventArgs) Handles txtPremined.Leave

        UpdateData()

    End Sub

    Private Sub txtTotalCoin_TextChanged(sender As Object, e As EventArgs) Handles txtTotalCoin.TextChanged

        If _NoSave Then Return

        If txtTotalCoin.Text.ToString.Length = 0 Then

            _Data.Total = 0

        Else

            _Data.Total = txtTotalCoin.Text

        End If

        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub txtTotalCoin_Leave(sender As Object, e As EventArgs) Handles txtTotalCoin.Leave

        UpdateData()

    End Sub

    Private Sub txtHourNodeConsensus_TextChanged(sender As Object, e As EventArgs) Handles txtHourNodeConsensus.TextChanged

        If _NoSave Then Return

        _Data.Total = txtTotalCoin.Text
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub txtDurateNodeConsensus_TextChanged(sender As Object, e As EventArgs) Handles txtDurateNodeConsensus.TextChanged

        If _NoSave Then Return

        _Data.NodeLayerConsensusConfiguration.Durate = txtDurateNodeConsensus.Text
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub txtDurateNodeConsensus_Leave(sender As Object, e As EventArgs) Handles txtDurateNodeConsensus.Leave

        UpdateData()

    End Sub



    ''' <summary>
    ''' This method provide to manage a command line
    ''' </summary>
    Sub ManageCommandLine()

        Try

            _CommandLineEngine.Decode(Environment.CommandLine.Split("/"))

            If _CommandLineEngine.Exist("ForceDataPath".ToLower()) Then

                txtCompletePath.Text = _CommandLineEngine.GetValue("ForceDataPath".ToLower())

                UpdateData()

            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Text += " rel." & My.Application.Info.Version.ToString()

        ManageCommandLine()

    End Sub

    Private Sub chkSchedule_CheckedChanged(sender As Object, e As EventArgs) Handles chkSchedule.CheckedChanged

        If _NoSave Then Return

        If chkSchedule.Checked Then

            lblDateStartNetwork.Enabled = True
            dtpStartNetwork.Enabled = True

        Else

            lblDateStartNetwork.Enabled = False
            dtpStartNetwork.Enabled = False

            _Data.DateStartNetwork = DateTime.MinValue

        End If

        txtIdentity.Text = _Data.Identity

    End Sub


    Private Sub chkSchedule_Leave(sender As Object, e As EventArgs) Handles chkSchedule.Leave

        UpdateData()

    End Sub


    Private Sub dtpStartNetwork_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartNetwork.ValueChanged

        If _NoSave Then Return

        If chkSchedule.Checked Then

            _Data.DateStartNetwork = dtpStartNetwork.Value.ToUniversalTime

        Else

            _Data.DateStartNetwork = DateTime.MinValue

        End If

        txtIdentity.Text = _Data.Identity

        txtHourNodeConsensus.Text = _Data.NodeLayerConsensusConfiguration.Start

    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged

        If _NoSave Then Return

        If cmbType.SelectedIndex = -1 Then

            _Data.Type = CryptoHideCoinEditDefinition.SystemDefinition.EnumEntityType.NotDefined

        ElseIf cmbType.SelectedIndex = 0 Then

            _Data.Type = CryptoHideCoinEditDefinition.SystemDefinition.EnumEntityType.COIN

        Else

            _Data.Type = CryptoHideCoinEditDefinition.SystemDefinition.EnumEntityType.TOKEN

        End If

        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub cmbType_Leave(sender As Object, e As EventArgs) Handles cmbType.Leave

        UpdateData()

    End Sub

    Private Sub chkMintable_CheckedChanged(sender As Object, e As EventArgs) Handles chkMintable.CheckedChanged

        If _NoSave Then Return

        _Data.Mintable = chkMintable.Checked
        txtIdentity.Text = _Data.Identity

    End Sub

    Private Sub chkMintable_Leave(sender As Object, e As EventArgs) Handles chkMintable.Leave

        UpdateData()

    End Sub

    Private Sub dtpStartNetwork_Leave(sender As Object, e As EventArgs) Handles dtpStartNetwork.Leave

        UpdateData()

    End Sub

    Private Sub chkNoTotal_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoTotal.CheckedChanged

        If _NoSave Then Return

        _Data.NoLimit = chkNoTotal.Checked

        If _Data.NoLimit Then

            lblTotalCoin.Enabled = False

            txtTotalCoin.Enabled = False
            txtTotalCoin.Text = ""

            lblSymbol2.Enabled = False

        Else

            lblTotalCoin.Enabled = True

            txtTotalCoin.Enabled = True
            txtTotalCoin.Text = "0"

            lblSymbol2.Enabled = True

        End If

    End Sub

    Private Sub chkNoTotal_Leave(sender As Object, e As EventArgs) Handles chkNoTotal.Leave

        UpdateData()

    End Sub

    Private Sub txtNumOfDecimal_TextChanged(sender As Object, e As EventArgs) Handles txtNumOfDecimal.TextChanged

        Try

            If _NoSave Then Return

            _Data.NumberOfDecimal = txtNumOfDecimal.Text
            txtIdentity.Text = _Data.Identity

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtNumOfDecimal_Leave(sender As Object, e As EventArgs) Handles txtNumOfDecimal.Leave

        UpdateData()

    End Sub


End Class
