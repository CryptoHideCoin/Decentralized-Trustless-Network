Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication



Public Class PriceTableForm

    Private _canChangeTab As Boolean = False

    Private _items As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
    Private _currentRow As Integer = -2
    Private _currentRowDetail As Integer = -2
    Private _item As AreaCommon.Models.Define.PriceTableBaseModel
    Private _itemPrice As AreaCommon.Models.Define.ItemPriceTableModel
    Private _references As List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
    Private _duringLoadData As Boolean = False

    Public adminURL As String
    Public certificate As String







    Private Sub createGridDetail()

        priceDataGrid.Columns(0).Visible = False
        priceDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        priceDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

        priceDataGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

        priceDataGrid.Columns.Add(AreaInterface.Support.createButtonInGrid("Delete", "delete"))

    End Sub


    Private Function loadReferenceList() As Boolean

        Try

            Dim dataList As New ProxyWS(Of List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel))
            Dim response As String

            dataList.url = adminURL & "/api/v1.0/Define/ReferenceProtocols/?certificate=" & certificate

            response = dataList.getData()

            If (response = "") Then
                _references = dataList.data

                referenceProtocolValue.DisplayMember = "Text"
                referenceProtocolValue.ValueMember = "Value"

                For Each item In _references

                    referenceProtocolValue.Items.Add(New With {.Text = item.name, .Value = item.identity})

                Next

                Return True
            Else
                MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error during refreshButton " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try

    End Function


    Private Sub PriceTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AreaInterface.createStandardGrid(dataGridView)

        createGridDetail()

        If AreaInterface.refreshData("priceTables", adminURL, certificate, _items, dataGridView) Then
            dataGridView.Sort(dataGridView.Columns(1), ComponentModel.ListSortDirection.Ascending)

            If Not loadReferenceList() Then
                Me.Dispose()
            End If
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
        _item = New AreaCommon.Models.Define.PriceTableBaseModel
        mainTabControl.SelectedIndex = 1
        _canChangeTab = False

        identityValue.Text = "NO FILE"
        nameValue.Text = ""
        effectiveDateValue.Value = Now

        priceDataGrid.Rows.Clear()

        codePriceValue.Text = ""
        priceValue.Text = ""
        descriptionValue.Text = ""

        referenceProtocolLabel.Enabled = True
        referenceProtocolValue.Enabled = True

        nameValue.Select()

    End Sub


    Private Sub reloadDataPrice()

        Try

            Dim rowItem As ArrayList
            Dim rowIndex As Integer = 0

            priceDataGrid.Rows.Clear()

            For Each item As AreaCommon.Models.Define.ItemPriceTableModel In _item.items

                rowItem = New ArrayList

                rowItem.Add(rowIndex.ToString())
                rowItem.Add(item.code)
                rowItem.Add(item.contribute)

                priceDataGrid.Rows.Add(rowItem.ToArray)

                rowIndex += 1

            Next

        Catch ex As Exception
            MessageBox.Show("Error during reloadDataPrice " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click

        AreaInterface.refreshData("PriceTables", adminURL, certificate, _items, dataGridView)

    End Sub


    Private Function validateData() As Boolean

        If (_item.name.Length = 0) Then

            MessageBox.Show("The price name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_item.items.Count = 0) Then

            MessageBox.Show("Insert one or more Price List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            Dim serverUpdate As New ProxyWS(Of AreaCommon.Models.Define.PriceTableBaseModel)
            Dim response As String

            serverUpdate.url = adminURL & "/api/v1.0/Define/PriceTables/?certificate=" & certificate & "&originalId=" & previousId

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

                    Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.PriceTableResponseModel)
                    Dim response As String

                    dataSource.url = adminURL & "/api/v1.0/Define/PriceTables/?certificate=" & certificate & "&id=" & id

                    response = dataSource.getData()

                    If (response = "") Then
                        _item = dataSource.data
                        _itemPrice = New AreaCommon.Models.Define.ItemPriceTableModel

                        _duringLoadData = True
                        nameValue.Text = _item.name

                        effectiveDateValue.Value = _item.effectiveDate

                        reloadDataPrice()

                        _duringLoadData = False

                        _canChangeTab = True
                        _currentRow = rowPosition
                        mainTabControl.SelectedIndex = 1
                        _canChangeTab = False

                        nameValue.Select()

                        referenceProtocolLabel.Enabled = False
                        referenceProtocolValue.Enabled = False

                    Else
                        MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error during dataGridView_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case 4

                rowPosition = dataGridView.Item(0, e.RowIndex).Value.ToString()
                id = _items(rowPosition).identity

                If (MessageBox.Show("Do you want to cancel the Price Table " & id, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then

                    Try

                        Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.CryptoAssetResponseModel)
                        Dim response As String

                        dataSource.url = adminURL & "/api/v1.0/Define/PriceTables/?certificate=" & certificate & "&id=" & id

                        response = dataSource.sendData("DELETE")

                        If (response <> "") Then
                            MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            _items.RemoveAt(rowPosition)

                            AreaInterface.refreshData("priceTables", adminURL, certificate, _items, dataGridView)
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


    Private Sub priceValue_TextChanged(sender As Object, e As EventArgs) Handles priceValue.TextChanged

        If _duringLoadData Then Return

        If (priceValue.Text.ToString.Trim.Length > 0) Then

            If IsNumeric(priceValue.Text.ToString.Trim) Then

                If (Decimal.Truncate(Decimal.Parse(priceValue.Text)) = Decimal.Parse(priceValue.Text)) Then
                    _itemPrice.contribute = Decimal.Parse(priceValue.Text & ",0")
                Else
                    _itemPrice.contribute = Decimal.Parse(priceValue.Text)
                End If

            Else
                _itemPrice.contribute = 0
            End If

        Else
            _itemPrice.contribute = 0
        End If

    End Sub


    Private Sub enableFields(ByVal value As Boolean)

        priceLabel.Enabled = value
        priceValue.ReadOnly = Not value

    End Sub


    Private Sub loadReference_Click(sender As Object, e As EventArgs) Handles loadReference.Click

        Try

            Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.ReferenceProtocolResponseModel)
            Dim response As String
            Dim itemPrice As AreaCommon.Models.Define.ItemPriceTableModel

            dataSource.url = adminURL & "/api/v1.0/Define/ReferenceProtocols/?certificate=" & certificate & "&id=" & referenceProtocolValue.SelectedItem.Value

            response = dataSource.getData()

            _item.items.Clear()

            If (response = "") Then

                _duringLoadData = True

                For Each item In dataSource.data.references

                    itemPrice = New AreaCommon.Models.Define.ItemPriceTableModel

                    itemPrice.code = item.code
                    itemPrice.description = item.description

                    _item.items.Add(itemPrice)

                Next

                reloadDataPrice()

                _duringLoadData = False

                selectItemPriceData()

                priceValue.Select()

            Else
                MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error during refreshButton " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub priceDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles priceDataGrid.CellContentClick

        Select Case e.ColumnIndex

            Case 4

                Try
                    _currentRowDetail = priceDataGrid.Item(0, e.RowIndex).Value.ToString()

                    _item.items.RemoveAt(_currentRowDetail)

                    reloadDataPrice()
                Catch ex As Exception
                    MessageBox.Show("Error during priceDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

        End Select

    End Sub


    Private Sub selectItemPriceData()

        If (priceDataGrid.SelectedRows.Count > 0) Then

            _currentRowDetail = priceDataGrid.SelectedRows.Item(0).Cells(0).Value.ToString()

            Try

                _itemPrice = _item.items(_currentRowDetail)

                _duringLoadData = True

                codePriceValue.Text = _itemPrice.code
                priceValue.Text = _itemPrice.contribute.ToString()
                descriptionValue.Text = _itemPrice.description

                _duringLoadData = False

                enableFields(True)

                priceValue.SelectAll()

            Catch ex As Exception
                MessageBox.Show("Error during priceDataGrid_SelectionChanged " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub


    Private Sub priceDataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles priceDataGrid.SelectionChanged

        If Not _duringLoadData Then selectItemPriceData()

    End Sub


    Private Sub referenceProtocolValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles referenceProtocolValue.SelectedIndexChanged

        loadReference.Enabled = True

    End Sub


    Private Sub priceValue_KeyDown(sender As Object, e As KeyEventArgs) Handles priceValue.KeyDown

        If (e.KeyCode = Keys.Return) Then

            _duringLoadData = True

            identityValue.Text = _item.getHash()

            reloadDataPrice()

            _duringLoadData = False
            e.SuppressKeyPress = True

            If (priceDataGrid.SelectedRows(0).Index <= priceDataGrid.Rows.Count) Then
                priceDataGrid.Rows(priceDataGrid.SelectedRows(0).Index + 1).Selected = True
            End If

        End If

    End Sub


    Private Sub priceValue_Enter(sender As Object, e As EventArgs) Handles priceValue.Enter

        priceValue.SelectAll()

    End Sub


    Private Sub effectiveDateValue_ValueChanged(sender As Object, e As EventArgs) Handles effectiveDateValue.ValueChanged

        If _duringLoadData Then Return

        _item.effectiveDate = effectiveDateValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub


End Class
