Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication




Public Class AssetsForm

    Private _canChangeTab As Boolean = False

    Private _items As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
    Private _currentRow As Integer = -2
    Private _item As AreaCommon.Models.Define.CryptoAssetBaseModel

    Public adminURL As String
    Public certificate As String






    Private Sub resizePanel()

        Try
            containerSelected.Left = (selectedTabPage.Width - containerSelected.Width) / 2
        Catch ex As Exception
        End Try

    End Sub


    Private Sub Assets_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AreaInterface.createStandardGrid(dataGridView)

        If AreaInterface.refreshData("assets", adminURL, certificate, _items, dataGridView) Then
            resizePanel()

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
        _item = New AreaCommon.Models.Define.CryptoAssetBaseModel
        mainTabControl.SelectedIndex = 1
        _canChangeTab = False

        coinNameValue.Text = ""
        shortNameValue.Text = ""
        symbolValue.Text = ""
        numOfDecimalValue.Text = ""
        mintable.Checked = False
        burnableValue.Checked = False
        noTotalValue.Checked = False
        totalCoinValue.Text = ""
        identityValue.Text = "NO FILE"

        coinNameValue.Select()

    End Sub


    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click

        AreaInterface.refreshData("assets", adminURL, certificate, _items, dataGridView)

    End Sub


    Private Function validateData() As Boolean

        If (_item.name.Length = 0) Then

            MessageBox.Show("The asset's name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (_item.shortName.Length = 0) Then

            MessageBox.Show("The short name asset is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (_item.symbol.Length = 0) Then

            MessageBox.Show("The symbol asset is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (numOfDecimalValue.Text.ToString.Trim().Length = 0) Then

            MessageBox.Show("The number of decimal is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If Not IsNumeric(numOfDecimalValue.Text.ToString.Trim()) Then

            MessageBox.Show("The number of decimal is not a numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (totalCoinValue.Enabled And totalCoinValue.Text.ToString.Trim().Length = 0) Then

            MessageBox.Show("The number of total coin value is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If totalCoinValue.Enabled And Not IsNumeric(totalCoinValue.Text.ToString.Trim()) Then

            MessageBox.Show("The number of total coin is not a numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_currentRow = -1) Then

            For Each item As AreaCommon.Models.Define.ItemKeyDescriptionModel In _items

                If (item.identity.ToLower.CompareTo(identityValue.Text.ToString.ToLower()) = 0) Or
                   (item.name.ToLower.CompareTo(coinNameValue.Text.ToString.ToLower()) = 0) Then

                    MessageBox.Show("Exist other element with same key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False

                End If

            Next

        Else

            For Each item As AreaCommon.Models.Define.ItemKeyDescriptionModel In _items

                If Not _items(_currentRow).Equals(item) Then

                    If (item.identity.ToLower.CompareTo(identityValue.Text.ToString.ToLower()) = 0) Or
                       (item.name.ToLower.CompareTo(coinNameValue.Text.ToString.ToLower()) = 0) Then

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

            Dim serverUpdate As New ProxyWS(Of AreaCommon.Models.Define.CryptoAssetBaseModel)
            Dim response As String

            serverUpdate.url = adminURL & "/api/v1.0/Define/Assets/?certificate=" & certificate & "&originalId=" & previousId

            serverUpdate.data = _item

            _item.codeSymbol()

            response = serverUpdate.sendData("PUT")

            If (response <> "") Then
                MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True

        Catch ex As Exception
            MessageBox.Show("Error during refreshButton " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try

    End Function


    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click

        If validateData() Then

            If (_currentRow <> -1) Then
                If sendUpdateCurrentData(_items(_currentRow).identity) Then

                    With _items(_currentRow)

                        .identity = identityValue.Text
                        .name = _item.name

                    End With

                End If
            Else
                If sendUpdateCurrentData("") Then

                    Dim newRecord As New AreaCommon.Models.Define.ItemKeyDescriptionModel

                    newRecord.identity = identityValue.Text
                    newRecord.name = _item.name

                    _items.Add(newRecord)

                End If
            End If

            AreaInterface.reloadData(dataGridView, _items)

            _canChangeTab = False
            mainTabControl.SelectedIndex = 0

        End If

    End Sub


    Private Sub coinNameValue_TextChanged(sender As Object, e As EventArgs) Handles coinNameValue.TextChanged

        _item.name = coinNameValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub shortNameValue_TextChanged(sender As Object, e As EventArgs) Handles shortNameValue.TextChanged

        _item.shortName = shortNameValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub symbolValue_TextChanged(sender As Object, e As EventArgs) Handles symbolValue.TextChanged

        _item.symbol = symbolValue.Text.Trim()
        identityValue.Text = _item.getHash()

        lblSymbol2.Text = _item.symbol

    End Sub


    Private Sub numOfDecimalValue_TextChanged(sender As Object, e As EventArgs) Handles numOfDecimalValue.TextChanged

        If IsNumeric(numOfDecimalValue.Text) Then

            _item.decimalDisplay = numOfDecimalValue.Text.Trim()
            identityValue.Text = _item.getHash

        End If

    End Sub


    Private Sub totalCoinValue_TextChanged(sender As Object, e As EventArgs) Handles totalCoinValue.TextChanged

        If IsNumeric(totalCoinValue.Text) Then

            _item.totalCoin = totalCoinValue.Text.Trim()
            identityValue.Text = _item.getHash()

        End If

    End Sub


    Private Sub burnableValue_CheckedChanged(sender As Object, e As EventArgs) Handles burnableValue.CheckedChanged

        _item.burnable = burnableValue.Checked
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub mintable_CheckedChanged(sender As Object, e As EventArgs) Handles mintable.CheckedChanged

        _item.mintable = mintable.Checked
        identityValue.Text = _item.getHash()

    End Sub


    Private Sub noTotalValue_CheckedChanged(sender As Object, e As EventArgs) Handles noTotalValue.CheckedChanged

        _item.limitless = noTotalValue.Checked
        identityValue.Text = _item.getHash()

        If _item.limitless Then

            totalCoinLabel.Enabled = False
            totalCoinValue.Enabled = False
            lblSymbol2.Enabled = False

            totalCoinValue.Text = ""

        Else

            totalCoinLabel.Enabled = True
            totalCoinValue.Enabled = True
            lblSymbol2.Enabled = True

        End If

    End Sub


    Private Sub dataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView.CellContentClick

        Dim id As String
        Dim rowPosition As Integer = 0

        Select Case e.ColumnIndex
            Case 3

                rowPosition = dataGridView.Item(0, e.RowIndex).Value.ToString()
                id = _items(rowPosition).identity

                Try

                    Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.CryptoAssetResponseModel)
                    Dim response As String

                    dataSource.url = adminURL & "/api/v1.0/Define/Assets/?certificate=" & certificate & "&id=" & id

                    response = dataSource.getData()

                    If (response = "") Then
                        _item = dataSource.data

                        coinNameValue.Text = _item.name
                        burnableValue.Checked = _item.burnable
                        mintable.Checked = _item.mintable
                        noTotalValue.Checked = _item.limitless
                        shortNameValue.Text = _item.shortName
                        symbolValue.Text = _item.symbol
                        numOfDecimalValue.Text = _item.decimalDisplay
                        totalCoinValue.Text = _item.totalCoin

                        _canChangeTab = True
                        _currentRow = rowPosition
                        mainTabControl.SelectedIndex = 1
                        _canChangeTab = False

                        coinNameValue.Select()
                    Else
                        MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error during refreshButton " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case 4

                rowPosition = dataGridView.Item(0, e.RowIndex).Value.ToString()
                id = _items(rowPosition).identity

                If (MessageBox.Show("Do you want to cancel the Asset " & id, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then

                    Try

                        Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.CryptoAssetResponseModel)
                        Dim response As String

                        dataSource.url = adminURL & "/api/v1.0/Define/Assets/?certificate=" & certificate & "&id=" & id

                        response = dataSource.sendData("DELETE")

                        If (response <> "") Then
                            MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            _items.RemoveAt(rowPosition)

                            AreaInterface.refreshData("assets", adminURL, certificate, _items, dataGridView)
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


    Private Sub AssetsForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        resizePanel()

    End Sub


End Class