Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication



Public Class RefundPlanForm

    Private _canChangeTab As Boolean = False

    Private _items As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
    Private _currentRow As Integer = -2
    Private _currentRowDetail As Integer = -2
    Private _item As AreaCommon.Models.Define.RefundPlanBaseModel
    Private _itemGroup As AreaCommon.Models.Define.RefundGroup
    Private _duringLoadData As Boolean = False

    Public adminURL As String
    Public certificate As String







    Private Sub createGridDetail()

        groupDataGrid.Columns(0).Visible = False
        groupDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        groupDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

        groupDataGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

        groupDataGrid.Columns.Add(AreaInterface.createButtonInGrid("Edit", "edit"))
        groupDataGrid.Columns.Add(AreaInterface.createButtonInGrid("Detail", "detail"))
        groupDataGrid.Columns.Add(AreaInterface.createButtonInGrid("Delete", "delete"))

    End Sub


    Private Sub RefundPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AreaInterface.createStandardGrid(dataGridView)
        createGridDetail()

        If AreaInterface.refreshData("RefundPlans", adminURL, certificate, _items, dataGridView) Then
            dataGridView.Sort(dataGridView.Columns(1), ComponentModel.ListSortDirection.Ascending)
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

        groupName.Text = ""
        refundInPercentage.Checked = False
        refundInFixValue.Checked = False
        value.Text = ""

    End Sub


    Private Sub createNewButton_Click(sender As Object, e As EventArgs) Handles createNewButton.Click

        _canChangeTab = True
        _currentRow = -1
        _item = New AreaCommon.Models.Define.RefundPlanBaseModel
        mainTabControl.SelectedIndex = 1
        _canChangeTab = False

        identityValue.Text = "NO FILE"
        nameValue.Text = ""
        effectiveDateValue.Value = Now

        groupDataGrid.Rows.Clear()

        clearFieldDetail()

        nameValue.Select()

    End Sub


    Private Sub reloadDataGroup()

        Try

            Dim rowItem As ArrayList
            Dim rowIndex As Integer = 0

            groupDataGrid.Rows.Clear()

            For Each item As AreaCommon.Models.Define.RefundGroup In _item.groups

                rowItem = New ArrayList

                rowItem.Add(rowIndex.ToString())
                rowItem.Add(item.name)

                If (item.percentage > 0) Then
                    rowItem.Add(item.percentage.ToString() & " %")
                Else
                    rowItem.Add(item.fixValue.ToString())
                End If

                groupDataGrid.Rows.Add(rowItem.ToArray)

                rowIndex += 1

            Next

        Catch ex As Exception
            MessageBox.Show("Error during reloadDataGroup " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click

        AreaInterface.refreshData("RefundPlans", adminURL, certificate, _items, dataGridView)

    End Sub


    Private Function validateData() As Boolean

        If (_item.name.Length = 0) Then

            MessageBox.Show("The asset's name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_item.groups.Count = 0) Then

            MessageBox.Show("Insert one or more Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_currentRow = -1) Then

            For Each item As AreaCommon.Models.Define.ItemKeyDescriptionModel In _items

                If (item.identity.ToLower.CompareTo(identityValue.Text.ToString.ToLower()) = 0) Or
                   (item.name.ToLower.CompareTo(nameValue.Text.ToString.ToLower()) = 0) Then

                    MessageBox.Show("Exist other element with same key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False

                End If

            Next

        Else

            For Each item As AreaCommon.Models.Define.ItemKeyDescriptionModel In _items

                If Not _items(_currentRow).Equals(item) Then

                    If (item.identity.ToLower.CompareTo(identityValue.Text.ToString.ToLower()) = 0) Or
                       (item.name.ToLower.CompareTo(nameValue.Text.ToString.ToLower()) = 0) Then

                        MessageBox.Show("Exist other element with same key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False

                    End If

                Else

                    If (_item.getHash = _items(_currentRow).identity) And
                       (_item.name.CompareTo(_items(_currentRow).name) = 0) Then

                        MessageBox.Show("Exist other element with same key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False

                    End If

                End If

            Next

        End If

        Return True

    End Function


    Private Function sendUpdateCurrentData(ByVal previousId As String) As Boolean

        Try

            Dim serverUpdate As New ProxyWS(Of AreaCommon.Models.Define.RefundPlanBaseModel)
            Dim response As String

            serverUpdate.url = adminURL & "/api/v1.0/Define/RefundPlans/?certificate=" & certificate & "&originalId=" & previousId

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

        _item.name = nameValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub dataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView.CellContentClick

        Dim id As String
        Dim rowPosition As Integer = 0

        Select Case e.ColumnIndex
            Case 3

                rowPosition = dataGridView.Item(0, e.RowIndex).Value.ToString()
                id = _items(rowPosition).identity

                Try

                    Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.RefundPlanResponseModel)
                    Dim response As String

                    dataSource.url = adminURL & "/api/v1.0/Define/RefundPlans/?certificate=" & certificate & "&id=" & id

                    response = dataSource.getData()

                    If (response = "") Then
                        _item = dataSource.data
                        _itemGroup = New AreaCommon.Models.Define.RefundGroup

                        _duringLoadData = True
                        nameValue.Text = _item.name

                        effectiveDateValue.Value = _item.effectiveDate

                        reloadDataGroup()

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

                If (MessageBox.Show("Do you want to cancel the Refund Plan Id " & id, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then

                    Try

                        Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.CryptoAssetResponseModel)
                        Dim response As String

                        dataSource.url = adminURL & "/api/v1.0/Define/RefundPlans/?certificate=" & certificate & "&id=" & id

                        response = dataSource.sendData("DELETE")

                        If (response <> "") Then
                            MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            _items.RemoveAt(rowPosition)

                            AreaInterface.refreshData("refundPlans", adminURL, certificate, _items, dataGridView)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Error during dataGridView_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If

        End Select

    End Sub


    Private Sub textChangedValue()

        If _duringLoadData Or IsNothing(_itemGroup) Then Return

        If refundInFixValue.Checked Then

            _itemGroup.percentage = 0

            If IsNumeric(value.Text.ToString.Trim) Then

                If (Decimal.Truncate(Decimal.Parse(value.Text)) = Decimal.Parse(value.Text)) Then
                    _itemGroup.fixValue = Decimal.Parse(value.Text & ",0")
                Else
                    _itemGroup.fixValue = Decimal.Parse(value.Text)
                End If

            Else
                _itemGroup.fixValue = 0
            End If

        ElseIf refundInPercentage.Checked Then

            _itemGroup.fixValue = 0

            If IsNumeric(value.Text.ToString.Trim) Then

                If (Decimal.Truncate(Decimal.Parse(value.Text)) = Decimal.Parse(value.Text)) Then
                    _itemGroup.percentage = Decimal.Parse(value.Text & ",0")
                Else
                    _itemGroup.percentage = Decimal.Parse(value.Text)
                End If

            Else
                _itemGroup.percentage = 0
            End If

        End If

    End Sub


    Private Sub value_TextChanged(sender As Object, e As EventArgs) Handles value.TextChanged

        textChangedValue()

    End Sub


    Private Sub enableFieldDetail(ByVal valueResult As Boolean)

        groupLabel.Enabled = valueResult
        groupName.Enabled = valueResult
        detailGroup.Enabled = valueResult
        refundInPercentage.Enabled = valueResult
        refundInFixValue.Enabled = valueResult
        valueLabel.Enabled = valueResult
        value.Enabled = valueResult

        confirmGroup.Enabled = valueResult
        cancelUpdate.Enabled = valueResult

    End Sub


    Private Sub groupDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles groupDataGrid.CellContentClick

        Select Case e.ColumnIndex

            Case 3
                lockField(False)

                groupName.Select()
            Case 4 : openDetailGroup()
            Case 5

                Try
                    _currentRowDetail = groupDataGrid.Item(0, e.RowIndex).Value.ToString()

                    _item.groups.RemoveAt(_currentRowDetail)

                    reloadDataGroup()
                    clearFieldDetail()
                Catch ex As Exception
                    MessageBox.Show("Error during priceDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

        End Select

    End Sub


    Private Sub lockField(ByVal lockValue As Boolean)

        groupName.ReadOnly = lockValue

        refundInFixValue.Enabled = Not lockValue
        refundInPercentage.Enabled = Not lockValue

        value.ReadOnly = lockValue

        confirmGroup.Enabled = Not lockValue
        cancelUpdate.Enabled = Not lockValue

    End Sub


    Private Sub selectItemGroupData()

        If (groupDataGrid.SelectedRows.Count > 0) Then

            _currentRowDetail = groupDataGrid.SelectedRows.Item(0).Cells(0).Value.ToString()

            Try

                _itemGroup = _item.groups(_currentRowDetail)
                _duringLoadData = True
                groupName.Text = _itemGroup.name

                If _itemGroup.percentage > 0 Then
                    refundInPercentage.Checked = True

                    value.Text = _itemGroup.percentage
                Else
                    refundInFixValue.Checked = True

                    value.Text = _itemGroup.fixValue
                End If

                _duringLoadData = False

                lockField(True)

            Catch ex As Exception
                MessageBox.Show("Error during selectItemGroupData " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else

            groupName.Text = ""

            refundInPercentage.Checked = False
            refundInFixValue.Checked = False
            value.Text = _itemGroup.fixValue
            lockField(True)

        End If

    End Sub


    Private Sub effectiveDateValue_ValueChanged(sender As Object, e As EventArgs) Handles effectiveDateValue.ValueChanged

        If _duringLoadData Then Return

        _item.effectiveDate = effectiveDateValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub addNewGroup_Click(sender As Object, e As EventArgs) Handles addNewGroup.Click

        _currentRowDetail = -2
        _itemGroup = New AreaCommon.Models.Define.RefundGroup

        lockField(False)
        enableFieldDetail(True)

        groupName.Text = ""
        refundInFixValue.Checked = False
        refundInPercentage.Checked = False
        value.Text = ""

        groupName.Select()

    End Sub


    Private Sub refundInPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles refundInPercentage.CheckedChanged

        If refundInPercentage.Checked Then
            valueLabel.Text = "Value (%)"

            textChangedValue()
        Else
            valueLabel.Text = "Value"
        End If

    End Sub


    Private Sub refundInFixValue_CheckedChanged(sender As Object, e As EventArgs) Handles refundInFixValue.CheckedChanged

        If refundInFixValue.Checked Then
            valueLabel.Text = "Value"

            textChangedValue()
        Else
            valueLabel.Text = "Value (%)"
        End If

    End Sub


    Private Function validateDataDetail() As Boolean

        If (_itemGroup.name.Length = 0) Then

            MessageBox.Show("The asset's name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If Not refundInFixValue.Checked And Not refundInPercentage.Checked Then

            MessageBox.Show("Select the refund in fix value or refund in percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_itemGroup.percentage = 0) And (_itemGroup.fixValue = 0) Then

            MessageBox.Show("The value is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return True

    End Function


    Private Sub confirmGroup_Click(sender As Object, e As EventArgs) Handles confirmGroup.Click

        Dim singleItem As AreaCommon.Models.Define.RefundItem
        Dim singleRow As AreaCommon.Models.Define.RefundGroup

        If validateDataDetail() Then

            If (_currentRowDetail <> -2) Then
                singleRow = _item.groups(_currentRowDetail)
            Else
                singleRow = New AreaCommon.Models.Define.RefundGroup

                _item.groups.Add(singleRow)
            End If

            With singleRow

                .name = _itemGroup.name
                .percentage = _itemGroup.percentage
                .fixValue = _itemGroup.fixValue

                For Each item In _itemGroup.items

                    singleItem = New AreaCommon.Models.Define.RefundItem

                    singleItem.recipient = item.recipient
                    singleItem.percentage = item.percentage
                    singleItem.fixValue = item.fixValue

                    .items.Add(singleItem)

                Next

            End With

            identityValue.Text = _item.getHash()

            reloadDataGroup()
            selectItemGroupData()
        End If

    End Sub


    Private Sub groupName_TextChanged(sender As Object, e As EventArgs) Handles groupName.TextChanged

        If _duringLoadData Then Return

        _itemGroup.name = groupName.Text

    End Sub


    Private Sub groupDataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles groupDataGrid.SelectionChanged

        If Not _duringLoadData Then selectItemGroupData()

    End Sub


    Private Function checkDuplicate() As Boolean

        For i As Integer = 0 To _item.groups.Count - 2

            Dim firstItem As AreaCommon.Models.Define.RefundGroup = _item.groups(i)

            For j As Integer = i + 1 To _item.groups.Count - 1

                Dim secondItem As AreaCommon.Models.Define.RefundGroup = _item.groups(j)

                If (firstItem.name = secondItem.name) Then

                    MessageBox.Show("More occurrence of " & firstItem.name & " is exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return True

                End If

            Next

        Next

        Return False

    End Function


    Private Function validateDate() As Boolean

        If (_item.name.Length = 0) Then

            MessageBox.Show("The name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_item.groups.Count = 0) Then

            MessageBox.Show("Insert one or more groups", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Dim totPercentage As Double = 0

        For Each item In _item.groups

            If (item.percentage > 0) Then
                totPercentage += item.percentage
            End If

        Next

        If (totPercentage > 0) And (totPercentage < 100) Then

            MessageBox.Show("The total of percentage is different than 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return Not checkDuplicate()

    End Function


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


    Private Sub openDetailGroup()

        Try
            Dim detail As New refundDetailGroup

            detail.dataGroup = _itemGroup

            detail.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub detailGroup_Click(sender As Object, e As EventArgs) Handles detailGroup.Click

        openDetailGroup()

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        _canChangeTab = False
        mainTabControl.SelectedIndex = 0

    End Sub

    Private Sub cancelUpdate_Click(sender As Object, e As EventArgs) Handles cancelUpdate.Click

        selectItemGroupData()

    End Sub


End Class

