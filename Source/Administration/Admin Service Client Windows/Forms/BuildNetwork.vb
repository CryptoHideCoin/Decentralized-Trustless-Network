Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML



Public Class BuildNetwork

    Private Class FileEngine
        Inherits BaseFile(Of CHCProtocolLibrary.AreaCommon.Models.Network.BuildNetworkModel)
    End Class

    Private _Engine As New FileEngine
    Private _PrivateRAWKey As String = ""


    Public ReadOnly Property data As CHCProtocolLibrary.AreaCommon.Models.Network.BuildNetworkModel
        Get
            Return _Engine.data
        End Get
    End Property

    Public ReadOnly Property privateRAWKey As String
        Get
            Return _PrivateRAWKey
        End Get
    End Property


    Private Function loadDataIntoStructure(Optional ByVal fromSave As Boolean = False) As Boolean
        Try
            Dim singleItem As CHCProtocolLibrary.AreaCommon.Models.Network.RefundItem
            Dim keyPairRAW As CHCProtocolLibrary.AreaWallet.Support.WalletAddressEngine.SingleKeyPair

            keyPairRAW = adminWalletAddress.keyPairRAW

            _PrivateRAWKey = keyPairRAW.privateKey

            With _Engine.data
                .informationBase.netName = networkNameText.Text
                .informationBase.specialEnvironment = specialEnvironmentText.Text

                If fromSave Then
                    .publicAddressGenesis = adminWalletAddress.value
                Else
                    keyPairRAW.decoreDataAddress(keyPairRAW.publicKey)

                    .publicAddressGenesis = keyPairRAW.publicKey
                End If

                .whitePaper.content = whitePaperText.Text
                .yellowPaper.content = yellowPaperText.Text

                With .primaryAsset.assetInformation
                    .name = assetNameText.Text
                    .shortName = shortNameText.Text
                    .symbol = symbolText.Text
                    .digit = digitText.Value
                    .nameUnit = nameUnitText.Text
                    .type = CHCProtocolLibrary.AreaCommon.Models.PrimaryChain.AssetModel.AssetTypeEnum.coin
                    .netWorkReferement = ""
                End With
                With .primaryAsset.assetPolicyInformation
                    .unlimited = unLimitedCheck.Checked
                    .burnable = burnableCheck.Checked
                    .qtaTotal = quantityTotalText.Text
                    .stakeable = stakableCheck.Checked
                    .preStake = prestakeCheck.Checked
                    .qtaInitialStake = initialStakeQuantityText.Text
                End With
                With .transactionChainParameter
                    .blockSizeFrequency = blockSizeFrequencyText.Text
                    .numberBlockInVolume = numberBlockInVolumeText.Text
                    .maxTimeOutNotRespondNode = maxTimeOutResponseNodeText.Text
                    .maxTimeOutNotEvaluateNode = maxTimeOutResponseNodeText.Text
                    .initialCoinReleasePerBlock = initialCoinReleaseBlockText.Text
                    .ruleFutureRelease = ruleFutureReleaseText.Text
                    .reviewReleaseAlgorithm = reviewReleaseAlgorithmText.Text
                    .consensusMethod = consensusMethodText.Text
                    .minimalMaintainRequest = minimalMaintainRequestText.Text
                    .minimalMaintainConsensus = minimalMaintainConsensusText.Text
                    .minimalMaintainBulletines = minimalMaintainBulletinesText.Text
                    .minimalMaintainRejected = minimalMaintainRejectedText.Text
                    .minimalMaintainTrashed = minimalMaintainTrashedText.Text
                    .minimalMaintainInternalRegistry = minimalMaintainInternalText.Text
                End With

                .refundPlan.items.Clear()

                For i As Integer = 0 To refundPlanDataGrid.Rows.Count - 1
                    singleItem = New CHCProtocolLibrary.AreaCommon.Models.Network.RefundItem

                    singleItem.recipient = refundPlanDataGrid.Item(0, i).Value
                    singleItem.description = refundPlanDataGrid.Item(1, i).Value
                    singleItem.fixValue = refundPlanDataGrid.Item(2, i).Value
                    singleItem.percentageValue = refundPlanDataGrid.Item(3, i).Value

                    .refundPlan.items.Add(singleItem)
                Next

                .privacyPolicy.content = privacyPolicyText.Text
                .generalCondition.content = generalConditionText.Text
            End With

            Return True
        Catch ex As Exception
            MessageBox.Show("Error during loadDataIntoStructure - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Sub loadDataIntoGUI()
        Try
            With _Engine.data
                networkNameText.Text = .informationBase.netName
                specialEnvironmentText.Text = .informationBase.specialEnvironment
                adminWalletAddress.value = .publicAddressGenesis
                whitePaperText.Text = .whitePaper.content
                yellowPaperText.Text = .yellowPaper.content
                With .primaryAsset.assetInformation
                    assetNameText.Text = .name
                    shortNameText.Text = .shortName
                    symbolText.Text = .symbol
                    digitText.Text = .digit
                    nameUnitText.Text = .nameUnit
                End With
                With .primaryAsset.assetPolicyInformation
                    unLimitedCheck.Checked = .unlimited
                    burnableCheck.Checked = .burnable
                    quantityTotalText.Text = .qtaTotal
                    stakableCheck.Checked = .stakeable
                    prestakeCheck.Checked = .preStake
                    initialStakeQuantityText.Text = .qtaInitialStake
                End With
                With .transactionChainParameter
                    initialCoinReleaseBlockText.text = .initialCoinReleasePerBlock
                    ruleFutureReleaseText.Text = .ruleFutureRelease
                End With

                For Each item In .refundPlan.items
                    loadDataIntoGrid(item)
                Next

                privacyPolicyText.Text = .privacyPolicy.content
                generalConditionText.Text = .generalCondition.content
            End With
        Catch ex As Exception
            MessageBox.Show("Error during loadDataIntoGUI - " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function checkFieldMissing() As Boolean
        Dim proceed As Boolean = True

        If proceed Then
            If (networkNameText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Network Name' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (adminWalletAddress.value.Trim.Length = 0) Then
                MessageBox.Show("The 'Public Wallet Address' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (adminWalletAddress.privateKey.Trim.Length = 0) Then
                MessageBox.Show("The 'Private Key' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (whitePaperText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Whitepaper' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (yellowPaperText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Yellowpaper' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (assetNameText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Asset Name' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (shortNameText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Short name' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (symbolText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Symbol' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (nameUnitText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Name Unit' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (ruleFutureReleaseText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Rule Future Release' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (privacyPolicyText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'Policy Privacy' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If
        If proceed Then
            If (generalConditionText.Text.Trim.Length = 0) Then
                MessageBox.Show("The 'General Condition' is missing", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                proceed = False
            End If
        End If

        Return proceed
    End Function

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        loadDataIntoStructure()

        DialogResult = DialogResult.OK

        Close()
    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        If loadDataIntoStructure(True) Then
            _Engine.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, "buildNetwork.data")

            _Engine.save()
        End If
    End Sub

    Private Sub prestakeCheck_CheckedChanged(sender As Object, e As EventArgs) Handles prestakeCheck.CheckedChanged
        If prestakeCheck.Checked Then
            initialStakeQuantityLabel.Enabled = True

            initialStakeQuantityText.Enabled = True
        Else
            initialStakeQuantityLabel.Enabled = False

            initialStakeQuantityText.Enabled = False
            initialStakeQuantityText.Text = "0"
        End If
    End Sub

    Private Function createButtonInGrid(ByVal textValue As String, ByVal nameValue As String) As DataGridViewButtonColumn

        Dim buttonColumn As DataGridViewButtonColumn

        buttonColumn = New DataGridViewButtonColumn()

        buttonColumn.HeaderText = ""
        buttonColumn.Text = textValue
        buttonColumn.Name = nameValue
        buttonColumn.Width = 60
        buttonColumn.UseColumnTextForButtonValue = True

        Return buttonColumn

    End Function

    Private Sub loadDataIntoGrid(ByVal data As CHCProtocolLibrary.AreaCommon.Models.Network.RefundItem)
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(data.recipient)
            rowItem.Add(data.description)
            rowItem.Add(data.fixValue)
            rowItem.Add(data.percentageValue)

            If (data.fixValue <> 0) Then
                rowItem.Add(data.fixValue & " " & symbolText.Text)
            Else
                rowItem.Add(data.percentageValue & " %")
            End If

            refundPlanDataGrid.Rows.Add(rowItem.ToArray)
        Catch ex As Exception
            MessageBox.Show("Error during loadDataIntoGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub addNewButton_Click(sender As Object, e As EventArgs) Handles addNewButton.Click
        Dim tmp As New RefundPlanDetail

        tmp.init()

        If tmp.ShowDialog() = DialogResult.OK Then
            loadDataIntoGrid(tmp.Data)
        End If

        tmp.Data = Nothing

        tmp = Nothing
    End Sub

    Private Sub refundPlanDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles refundPlanDataGrid.CellContentClick
        Try
            Select Case e.ColumnIndex
                Case 5
                    Dim tmp As New RefundPlanDetail

                    tmp.Data.recipient = refundPlanDataGrid.Item(0, e.RowIndex).Value
                    tmp.Data.description = refundPlanDataGrid.Item(1, e.RowIndex).Value
                    tmp.Data.fixValue = refundPlanDataGrid.Item(2, e.RowIndex).Value
                    tmp.Data.percentageValue = refundPlanDataGrid.Item(3, e.RowIndex).Value

                    tmp.init()

                    If (tmp.ShowDialog() = DialogResult.OK) Then
                        refundPlanDataGrid.Item(1, e.RowIndex).Value = tmp.Data.description
                        refundPlanDataGrid.Item(2, e.RowIndex).Value = tmp.Data.fixValue
                        refundPlanDataGrid.Item(3, e.RowIndex).Value = tmp.Data.percentageValue

                        If (tmp.Data.fixValue <> 0) Then
                            refundPlanDataGrid.Item(4, e.RowIndex).Value = tmp.Data.fixValue & " " & symbolText.Text
                        Else
                            refundPlanDataGrid.Item(4, e.RowIndex).Value = tmp.Data.percentageValue & " %"
                        End If
                    End If

                    tmp.Data = Nothing

                    tmp = Nothing
                Case 6
                    Dim recipient As String = refundPlanDataGrid.Item(0, e.RowIndex).Value.ToString()

                    If (MessageBox.Show("Do you want to delete the refund item '" & Recipient & "' from a list ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                        Try
                            refundPlanDataGrid.Rows.Remove(refundPlanDataGrid.Rows.Item(e.RowIndex))
                        Catch ex As Exception
                            MessageBox.Show("Problem during delete List information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub init()
        adminWalletAddress.dataPath = AreaCommon.paths.pathKeystore

        refundPlanDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        refundPlanDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        refundPlanDataGrid.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

        refundPlanDataGrid.Columns.Add(createButtonInGrid("Edit", "edit"))
        refundPlanDataGrid.Columns.Add(createButtonInGrid("Delete", "delete"))
    End Sub

    Private Sub loadButton_Click(sender As Object, e As EventArgs) Handles loadButton.Click
        _Engine.fileName = IO.Path.Combine(AreaCommon.paths.pathSettings, "buildNetwork.data")

        If _Engine.read() Then
            loadDataIntoGUI()
        End If
    End Sub

    Private Sub BuildNetwork_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        DialogResult = DialogResult.Cancel

        Close()
    End Sub

End Class