Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication



Public Class SideChainConfigurationForm

    Private _canChangeTab As Boolean = False

    Private _items As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
    Private _currentRow As Integer = -2
    Private _currentRowDetail As Integer = -2
    Private _item As New AreaCommon.Models.Define.ChainBaseModel
    Private _itemDetail As New AreaCommon.Models.Define.TiersOfRewards
    Private _duringLoadData As Boolean = False

    Public adminURL As String
    Public certificate As String





    Private Sub createGridDetail()

        rewardDataGrid.Columns(0).Visible = False
        rewardDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        rewardDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

        rewardDataGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
        rewardDataGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

        rewardDataGrid.Columns.Add(AreaInterface.createButtonInGrid("Edit", "edit"))
        rewardDataGrid.Columns.Add(AreaInterface.createButtonInGrid("Delete", "delete"))

    End Sub


    Private Sub loadCombo(ByVal controllerName As String, ByVal combo As ComboBox)

        Try

            Dim dataList As New ProxyWS(Of List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel))
            Dim response As String

            dataList.url = adminURL & "/api/v1.0/Define/" & controllerName & "/?certificate=" & certificate

            response = dataList.getData()

            If (response = "") Then
                combo.DisplayMember = "Text"
                combo.ValueMember = "Value"

                combo.Items.Clear()

                For Each item In dataList.data

                    combo.Items.Add(New With {.Text = item.name, .Value = item.identity})

                Next
            Else
                MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error during loadComboAsset " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub SideChainConfigurationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AreaInterface.createStandardGrid(dataGridView)
        createGridDetail()

        If AreaInterface.refreshData("SidechainContracts", adminURL, certificate, _items, dataGridView) Then
            dataGridView.Sort(dataGridView.Columns(1), ComponentModel.ListSortDirection.Ascending)

            loadCombo("Assets", assetValue)
            loadCombo("PriceTables", priceListValue)
            loadCombo("RefundPlans", refundPlanValue)
            loadCombo("VisionPapers", visionPaperValue)
            loadCombo("WhitePapers", whitePaperValue)
            loadCombo("YellowPapers", yellowPaperValue)
            loadCombo("PrivacyPapers", privacyPaperValue)
            loadCombo("TermsAndConditionsPapers", TermsAndConditionsPaperValue)
        Else
            Me.Dispose()
        End If

    End Sub


    Private Sub mainTabControl_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles mainTabControl.Selecting

        If (mainTabControl.SelectedIndex = 1) Then

            If _canChangeTab Then Return

            e.Cancel = True

        End If

    End Sub


    Private Sub clearFieldDetail()

        untilAvailabilityValue.Text = "0"
        distributeValue.Text = "0"

    End Sub


    Private Sub createNewButton_Click(sender As Object, e As EventArgs) Handles createNewButton.Click

        _canChangeTab = True
        _currentRow = -1
        _item = New AreaCommon.Models.Define.ChainBaseModel
        mainTabControl.SelectedIndex = 1
        _canChangeTab = False

        identityValue.Text = "NO FILE"
        nameValue.Text = ""
        uniqueChainKeyValue.Text = ""
        typeValue.SelectedIndex = -1
        assetValue.SelectedIndex = -1
        priceListValue.SelectedIndex = -1
        refundPlanValue.SelectedIndex = -1
        visionPaperValue.SelectedIndex = -1
        whitePaperValue.SelectedIndex = -1
        yellowPaperValue.SelectedIndex = -1
        privacyPaperValue.SelectedIndex = -1
        preminedCoin.Text = "0"
        walletAddressPremined.Text = ""

        rewardDataGrid.Rows.Clear()

        clearFieldDetail()

        nameValue.Select()

    End Sub


    Private Sub reloadDataReward()

        Try

            Dim rowItem As ArrayList
            Dim rowIndex As Integer = 0

            rewardDataGrid.Rows.Clear()

            For Each item As AreaCommon.Models.Define.TiersOfRewards In _item.rewardPlan

                rowItem = New ArrayList

                rowItem.Add(rowIndex.ToString())
                rowItem.Add(item.from)
                rowItem.Add(item.distribute.ToString())

                rewardDataGrid.Rows.Add(rowItem.ToArray)

                rowIndex += 1

            Next

        Catch ex As Exception
            MessageBox.Show("Error during reloadDataReward " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click

        AreaInterface.refreshData("SideChainContracts", adminURL, certificate, _items, dataGridView)

    End Sub


    Private Function checkDuplicate() As Boolean

        Dim singleItem As AreaCommon.Models.Define.ItemKeyDescriptionModel

        For i As Integer = 0 To _items.Count - 1

            singleItem = _items(i)

            If (_currentRow <> -2) And (_currentRow = i) Then Continue For

            If (singleItem.name.CompareTo(_item.name) = 0) Then

                MessageBox.Show("More occurrence of " & _item.name & " is exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True

            End If

        Next

        Return False

    End Function


    Private Function validateData() As Boolean

        If (_item.name.Length = 0) Then

            MessageBox.Show("The Sidechain Contract name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_item.rewardPlan.Count = 0) Then

            MessageBox.Show("Insert one or more in Reward plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return Not checkDuplicate()

    End Function


    Private Function sendUpdateCurrentData(ByVal previousId As String) As Boolean

        Try

            Dim serverUpdate As New ProxyWS(Of AreaCommon.Models.Define.ChainBaseModel)
            Dim response As String

            serverUpdate.url = adminURL & "/api/v1.0/Define/SideChainContracts/?certificate=" & certificate & "&originalId=" & previousId

            serverUpdate.data = _item

            response = serverUpdate.sendData("PUT")

            If (response <> "") Then
                MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True

        Catch ex As Exception
            MessageBox.Show("Error during sendUpdateCurrentData " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function


    Private Sub nameValue_TextChanged(sender As Object, e As EventArgs) Handles nameValue.TextChanged

        If _duringLoadData Then Return

        _item.name = nameValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub uniqueChainKeyValue_TextChanged(sender As Object, e As EventArgs) Handles uniqueChainKeyValue.TextChanged

        If _duringLoadData Then Return

        _item.uniqueChainKey = uniqueChainKeyValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub typeValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles typeValue.SelectedIndexChanged

        If _duringLoadData Then Return

        If (typeValue.SelectedIndex = 0) Then
            _item.type = AreaCommon.Models.Define.EnumMode.official
        Else
            _item.type = AreaCommon.Models.Define.EnumMode.testNet
        End If

        identityValue.Text = _item.getHash()

    End Sub


    Private Sub assetValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles assetValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.assetId = assetValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub priceListValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles priceListValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.priceListId = priceListValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub refundPlanValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles refundPlanValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.refundPlanId = refundPlanValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub

    Private Sub visionPaperValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles visionPaperValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.visionPaperId = visionPaperValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub whitePaperValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles whitePaperValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.whitePaperId = whitePaperValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub yellowPaperValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles yellowPaperValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.yellowPaperId = yellowPaperValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub privacyPaperValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles privacyPaperValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.privacyPaperId = privacyPaperValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub TermsAndConditionsPaperValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TermsAndConditionsPaperValue.SelectedIndexChanged

        If _duringLoadData Then Return

        _item.termsAndConditionsId = TermsAndConditionsPaperValue.SelectedItem.Value
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub preminedCoin_TextChanged(sender As Object, e As EventArgs) Handles preminedCoin.TextChanged

        If _duringLoadData Then Return

        _item.preminedCoin = preminedCoin.Text
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub walletAddressPremined_TextChanged(sender As Object, e As EventArgs) Handles walletAddressPremined.TextChanged

        If _duringLoadData Then Return

        _item.walletAddressPremined = walletAddressPremined.Text
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub selectValueCombo(ByVal value As String, ByRef combo As ComboBox)

        Dim singleItem As Object

        For i As Integer = 0 To combo.Items.Count - 1

            singleItem = combo.Items(i)

            If singleItem.Value = value Then

                combo.SelectedIndex = i
                Return

            End If

        Next

    End Sub


    Private Sub dataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView.CellContentClick

        Dim id As String
        Dim rowPosition As Integer = 0

        Select Case e.ColumnIndex
            Case 3

                rowPosition = dataGridView.Item(0, e.RowIndex).Value.ToString()
                id = _items(rowPosition).identity

                Try

                    Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.ChainResponseModel)
                    Dim response As String

                    dataSource.url = adminURL & "/api/v1.0/Define/SidechainContracts/?certificate=" & certificate & "&id=" & id

                    response = dataSource.getData()

                    If (response = "") Then
                        _item = dataSource.data
                        _itemDetail = New AreaCommon.Models.Define.TiersOfRewards

                        _duringLoadData = True

                        nameValue.Text = _item.name
                        uniqueChainKeyValue.Text = _item.uniqueChainKey
                        typeValue.SelectedIndex = _item.type

                        selectValueCombo(_item.assetId, assetValue)
                        selectValueCombo(_item.priceListId, priceListValue)
                        selectValueCombo(_item.refundPlanId, refundPlanValue)
                        selectValueCombo(_item.visionPaperId, visionPaperValue)
                        selectValueCombo(_item.whitePaperId, whitePaperValue)
                        selectValueCombo(_item.yellowPaperId, yellowPaperValue)
                        selectValueCombo(_item.privacyPaperId, privacyPaperValue)
                        selectValueCombo(_item.termsAndConditionsId, TermsAndConditionsPaperValue)

                        preminedCoin.Text = _item.preminedCoin
                        walletAddressPremined.Text = _item.walletAddressPremined

                        reloadDataReward()

                        rewardDataGrid.Rows(0).Selected = True

                        selectItemDetailData()

                        _duringLoadData = False

                        _canChangeTab = True
                        _currentRow = rowPosition
                        mainTabControl.SelectedIndex = 1
                        _canChangeTab = False

                        nameValue.Select()
                    Else
                        MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error during dataGridView_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case 4

                rowPosition = dataGridView.Item(0, e.RowIndex).Value.ToString()
                id = _items(rowPosition).identity

                If (MessageBox.Show("Do you want to cancel the Contract " & id, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then

                    Try

                        Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.CryptoAssetResponseModel)
                        Dim response As String

                        dataSource.url = adminURL & "/api/v1.0/Define/SidechainContracs/?certificate=" & certificate & "&id=" & id

                        response = dataSource.sendData("DELETE")

                        If (response <> "") Then
                            MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            _items.RemoveAt(rowPosition)

                            AreaInterface.refreshData("SidechainContracs", adminURL, certificate, _items, dataGridView)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Error during dataGridView_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If

        End Select

    End Sub


    Private Sub enableFieldDetail(ByVal valueResult As Boolean)

        untilAvailabilityLabel.Enabled = valueResult
        distributeLabel.Enabled = valueResult
        confirmUpdateButton.Enabled = valueResult
        untilAvailabilityValue.ReadOnly = Not valueResult
        distributeValue.ReadOnly = Not valueResult

    End Sub


    Private Sub rewardDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles rewardDataGrid.CellContentClick

        Select Case e.ColumnIndex

            Case 3
                enableFieldDetail(True)

                untilAvailabilityValue.Select()
            Case 4

                Try
                    _currentRowDetail = rewardDataGrid.Item(0, e.RowIndex).Value.ToString()

                    _item.rewardPlan.RemoveAt(_currentRowDetail)

                    reloadDataReward()
                    clearFieldDetail()
                Catch ex As Exception
                    MessageBox.Show("Error during rewardDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

        End Select

    End Sub


    Private Sub selectItemDetailData()

        If (rewardDataGrid.SelectedRows.Count > 0) Then

            _currentRowDetail = rewardDataGrid.SelectedRows.Item(0).Cells(0).Value.ToString()

            Try

                _itemDetail = _item.rewardPlan(_currentRowDetail)
                _duringLoadData = True
                untilAvailabilityValue.Text = _itemDetail.from
                distributeValue.Text = _itemDetail.distribute

                _duringLoadData = False

                enableFieldDetail(False)

            Catch ex As Exception
                MessageBox.Show("Error during selectItemDetailData " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            untilAvailabilityValue.Text = ""
            distributeValue.Text = "0"

            enableFieldDetail(False)
        End If

    End Sub


    Private Sub untilAvailabilityValue_TextChanged(sender As Object, e As EventArgs) Handles untilAvailabilityValue.TextChanged

        If _duringLoadData Then Return

        If IsNumeric(untilAvailabilityValue.Text) Then
            _itemDetail.from = untilAvailabilityValue.Text
        Else
            _itemDetail.from = 0
        End If

    End Sub


    Private Sub distributeValue_TextChanged(sender As Object, e As EventArgs) Handles distributeValue.TextChanged

        If _duringLoadData Then Return

        If IsNumeric(distributeValue.Text) Then
            _itemDetail.distribute = distributeValue.Text
        Else
            _itemDetail.distribute = 0
        End If

    End Sub


    Private Function validateDataDetail() As Boolean

        If (_itemDetail.[from].ToString().Length = 0) Then

            MessageBox.Show("The limit until availability is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_itemDetail.distribute = 0) Then

            MessageBox.Show("The distribute is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return True

    End Function


    Private Sub confirmUpdateButton_Click(sender As Object, e As EventArgs) Handles confirmUpdateButton.Click

        Dim singleRow As AreaCommon.Models.Define.TiersOfRewards

        If validateDataDetail() Then

            If (_currentRowDetail <> -2) Then
                singleRow = _item.rewardPlan(_currentRowDetail)
            Else
                singleRow = New AreaCommon.Models.Define.TiersOfRewards

                _item.rewardPlan.Add(singleRow)
            End If

            With singleRow

                .from = _itemDetail.from
                .distribute = _itemDetail.distribute

            End With

            identityValue.Text = _item.getHash()

            reloadDataReward()
            selectItemDetailData()
        End If

    End Sub


    Private Sub addNewHeadBand_Click(sender As Object, e As EventArgs) Handles addNewHeadBand.Click

        _currentRowDetail = -2
        _itemDetail = New AreaCommon.Models.Define.TiersOfRewards

        enableFieldDetail(True)

        _duringLoadData = True

        clearFieldDetail()

        untilAvailabilityValue.Select()

        _duringLoadData = False

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        _canChangeTab = False
        mainTabControl.SelectedIndex = 0

    End Sub


    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click

        If validateData() Then

            If (_currentRow <> -1) Then
                If sendUpdateCurrentData(_items(_currentRow).identity) Then

                    With _items(_currentRow)

                        .identity = identityValue.Text
                        .name = nameValue.Text

                    End With

                Else
                    Return
                End If
            Else
                If sendUpdateCurrentData("") Then

                    Dim newRecord As New AreaCommon.Models.Define.ItemKeyDescriptionModel

                    newRecord.identity = identityValue.Text
                    newRecord.name = nameValue.Text

                    _items.Add(newRecord)

                Else
                    Return
                End If
            End If

            AreaInterface.reloadData(dataGridView, _items)

            _canChangeTab = False
            mainTabControl.SelectedIndex = 0

        End If

    End Sub


End Class