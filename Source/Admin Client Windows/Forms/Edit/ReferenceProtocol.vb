Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication



Public Class ReferenceProtocolForm

    Private _canChangeTab As Boolean = False

    Private _items As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
    Private _currentRow As Integer = -2
    Private _currentRowDetail As Integer = -2
    Private _item As AreaCommon.Models.Define.ReferenceProtocolBaseModel
    Private _itemDetail As AreaCommon.Models.Define.ReferenceModel

    Public adminURL As String
    Public certificate As String







    Private Sub createGridDetail()

        referenceDataGrid.Columns(0).Visible = False
        referenceDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        referenceDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

        referenceDataGrid.Columns.Add(AreaInterface.Support.createButtonInGrid("Edit", "edit"))
        referenceDataGrid.Columns.Add(AreaInterface.Support.createButtonInGrid("Delete", "delete"))

    End Sub


    Private Sub ReferenceProtocol_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AreaInterface.createStandardGrid(dataGridView)
        createGridDetail()

        If AreaInterface.refreshData("ReferenceProtocols", adminURL, certificate, _items, dataGridView) Then
            dataGridView.Sort(dataGridView.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
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


    Private Sub createNewButton_Click(sender As Object, e As EventArgs) Handles createNewButton.Click

        _canChangeTab = True
        _currentRow = -1
        _item = New AreaCommon.Models.Define.ReferenceProtocolBaseModel
        mainTabControl.SelectedIndex = 1
        _canChangeTab = False

        nameValue.Text = ""
        referenceProtocolValue.Text = ""
        referenceDataGrid.Rows.Clear()
        referenceValue.ReadOnly = True
        referenceValue.Text = ""
        descriptionValue.ReadOnly = True
        descriptionValue.Text = ""

        identityValue.Text = "NO FILE"

        nameValue.Select()

    End Sub


    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click

        AreaInterface.refreshData("ReferenceProtocols", adminURL, certificate, _items, dataGridView)

    End Sub


    Private Function validateData() As Boolean

        If (_item.name.Length = 0) Then

            MessageBox.Show("The vision paper name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (_item.releaseProtocol.Length = 0) Then

            MessageBox.Show("The release protocol is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                        Return False

                    End If

                End If

            Next

        End If

        Return True

    End Function


    Private Function sendUpdateCurrentData(ByVal previousId As String) As Boolean

        Try

            Dim serverUpdate As New ProxyWS(Of AreaCommon.Models.Define.ReferenceProtocolBaseModel)
            Dim response As String

            serverUpdate.url = adminURL & "/api/v1.0/Define/ReferenceProtocols/?certificate=" & certificate & "&originalId=" & previousId

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


    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click

        If validateData() Then

            If (_currentRow <> -1) Then
                If sendUpdateCurrentData(_items(_currentRow).identity) Then

                    With _items(_currentRow)

                        .identity = identityValue.Text
                        .name = nameValue.Text

                    End With

                End If
            Else
                If sendUpdateCurrentData("") Then

                    Dim newRecord As New AreaCommon.Models.Define.ItemKeyDescriptionModel

                    newRecord.identity = identityValue.Text
                    newRecord.name = nameValue.Text

                    _items.Add(newRecord)

                End If
            End If

            AreaInterface.reloadData(dataGridView, _items)

            _canChangeTab = False
            mainTabControl.SelectedIndex = 0

        End If

    End Sub


    Private Sub NameValue_TextChanged(sender As Object, e As EventArgs) Handles nameValue.TextChanged

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

                    Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.ReferenceProtocolResponseModel)
                    Dim response As String

                    dataSource.url = adminURL & "/api/v1.0/Define/ReferenceProtocols/?certificate=" & certificate & "&id=" & id

                    response = dataSource.getData()

                    If (response = "") Then
                        _item = dataSource.data

                        nameValue.Text = _item.name
                        referenceProtocolValue.Text = _item.releaseProtocol

                        reloadDataDetail()

                        _currentRowDetail = -2
                        _itemDetail = New AreaCommon.Models.Define.ReferenceModel()

                        _canChangeTab = True
                        _currentRow = rowPosition
                        mainTabControl.SelectedIndex = 1
                        _canChangeTab = False

                        nameValue.Select()
                    Else
                        MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error during refreshButton " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case 4

                rowPosition = dataGridView.Item(0, e.RowIndex).Value.ToString()
                id = _items(rowPosition).identity

                If (MessageBox.Show("Do you want to cancel the Reference Protocol " & id, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then

                    Try

                        Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.GenericPaperResponseModel)
                        Dim response As String

                        dataSource.url = adminURL & "/api/v1.0/Define/ReferenceProtocols/?certificate=" & certificate & "&id=" & id

                        response = dataSource.sendData("DELETE")

                        If (response <> "") Then
                            MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            _items.RemoveAt(rowPosition)

                            AreaInterface.refreshData("ReferenceProtocols", adminURL, certificate, _items, dataGridView)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Error during dataGridView_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If

        End Select

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        _canChangeTab = False
        mainTabControl.SelectedIndex = 0

    End Sub


    Private Sub referenceProtocolValue_TextChanged(sender As Object, e As EventArgs) Handles referenceProtocolValue.TextChanged

        _item.releaseProtocol = referenceProtocolValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub

    Private Sub enableDetail(ByVal value As Boolean)

        codeLabel.Enabled = value
        referenceValue.ReadOnly = Not value
        descriptionLabel.Enabled = value
        descriptionValue.ReadOnly = Not value
        confirmReference.Enabled = value
        cancelUpdate.Enabled = value

    End Sub

    Private Sub addNewReference_Click(sender As Object, e As EventArgs) Handles addNewReference.Click

        _itemDetail = New AreaCommon.Models.Define.ReferenceModel

        referenceValue.Text = ""
        descriptionValue.Text = ""

        enableDetail(True)

        referenceValue.Select()

        _currentRowDetail = -2

    End Sub

    Private Function validateDataDetail() As Boolean

        If (_itemDetail.code.Length = 0) Then

            MessageBox.Show("The code is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (_itemDetail.description.Length = 0) Then

            MessageBox.Show("The description is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (_currentRow = -1) Then

            For Each item As AreaCommon.Models.Define.ReferenceModel In _item.references

                If (item.code.ToLower.CompareTo(referenceValue.Text.ToString.ToLower()) = 0) And
                   (item.description.ToLower.CompareTo(descriptionValue.Text.ToString.ToLower()) = 0) Then

                    MessageBox.Show("Exist other element with same key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False

                End If

            Next

        Else

            For rowPosition As Integer = 0 To _item.references.Count - 1

                If (rowPosition <> _currentRowDetail) Then

                    If (_item.references(rowPosition).code.ToLower.CompareTo(referenceValue.Text.ToString.ToLower()) = 0) Then

                        MessageBox.Show("Exist other element with same key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False

                    End If

                End If

            Next

        End If

        Return True

    End Function


    Private Sub reloadDataDetail()

        Try

            Dim rowItem As ArrayList
            Dim rowIndex As Integer = 0

            referenceDataGrid.Rows.Clear()

            For Each item As AreaCommon.Models.Define.ReferenceModel In _item.references

                rowItem = New ArrayList

                rowItem.Add(rowIndex.ToString())
                rowItem.Add(item.code)
                rowItem.Add(item.description)

                referenceDataGrid.Rows.Add(rowItem.ToArray)

                rowIndex += 1

            Next

        Catch ex As Exception
            MessageBox.Show("Error during reloadDataDetail " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub confirmReference_Click(sender As Object, e As EventArgs) Handles confirmReference.Click

        If validateDataDetail() Then

            If (_currentRowDetail <> -2) Then
                With _item.references(_currentRowDetail)

                    .code = _itemDetail.code
                    .description = _itemDetail.description

                End With
            Else
                Dim newRow As New AreaCommon.Models.Define.ReferenceModel

                newRow.code = _itemDetail.code
                newRow.description = _itemDetail.description

                _item.references.Add(newRow)

                newRow = Nothing
            End If

            identityValue.Text = _item.getHash()

            reloadDataDetail()

            selectGridDetailRow()
        End If

    End Sub

    Private Sub referenceValue_TextChanged(sender As Object, e As EventArgs) Handles referenceValue.TextChanged

        _itemDetail.code = referenceValue.Text

    End Sub

    Private Sub descriptionValue_TextChanged(sender As Object, e As EventArgs) Handles descriptionValue.TextChanged

        _itemDetail.description = descriptionValue.Text

    End Sub

    Private Sub referenceDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles referenceDataGrid.CellContentClick

        Dim rowPosition As Integer = 0

        Select Case e.ColumnIndex
            Case 3

                rowPosition = referenceDataGrid.Item(0, e.RowIndex).Value.ToString()

                With _item.references(rowPosition)
                    referenceValue.Text = .code
                    descriptionValue.Text = .description
                End With

                enableDetail(True)

                referenceValue.Select()

            Case 4

                rowPosition = referenceDataGrid.Item(0, e.RowIndex).Value.ToString()

                _item.references.RemoveAt(rowPosition)

                reloadDataDetail()

        End Select

    End Sub

    Private Sub selectGridDetailRow()

        If (referenceDataGrid.SelectedRows.Count > 0) Then

            _currentRowDetail = referenceDataGrid.SelectedRows.Item(0).Cells(0).Value.ToString()

            Try

                With _item.references(_currentRowDetail)

                    referenceValue.Text = .code
                    descriptionValue.Text = .description

                End With

            Catch ex As Exception
                MessageBox.Show("Error during selectGridDetailRow " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else

            referenceValue.Text = ""
            descriptionValue.Text = ""

        End If

        enableDetail(False)

    End Sub


    Private Sub referenceDataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles referenceDataGrid.SelectionChanged

        selectGridDetailRow()

    End Sub

    Private Sub cancelUpdate_Click(sender As Object, e As EventArgs) Handles cancelUpdate.Click

        selectGridDetailRow()

    End Sub


End Class