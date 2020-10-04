Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication



Public Class GenericPapersForm

    Private _canChangeTab As Boolean = False

    Private _items As New List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)
    Private _currentRow As Integer = -2
    Private _item As AreaCommon.Models.Define.GenericPaperBaseModel

    Public adminURL As String
    Public certificate As String

    Public apiSegment As String
    Public managerTitle As String




    Private Sub VisionPapers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AreaInterface.createStandardGrid(dataGridView)

        Me.Text = Me.Text.Replace("%Title%", managerTitle)

        If AreaInterface.refreshData(apiSegment, adminURL, certificate, _items, dataGridView) Then
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
        _item = New AreaCommon.Models.Define.GenericPaperBaseModel
        mainTabControl.SelectedIndex = 1
        _canChangeTab = False

        nameValue.Text = ""
        ContentValue.Text = ""
        identityValue.Text = "NO FILE"

        nameValue.Select()

    End Sub


    Private Sub refreshButton_Click(sender As Object, e As EventArgs) Handles refreshButton.Click

        AreaInterface.refreshData(apiSegment, adminURL, certificate, _items, dataGridView)

    End Sub


    Private Function validateData() As Boolean

        If (_item.name.Length = 0) Then

            MessageBox.Show("The paper name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        If (_item.content.Length = 0) Then

            MessageBox.Show("The content is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            Dim serverUpdate As New ProxyWS(Of AreaCommon.Models.Define.GenericPaperBaseModel)
            Dim response As String

            serverUpdate.url = adminURL & "/api/v1.0/Define/" & apiSegment & "/?certificate=" & certificate & "&originalId=" & previousId

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

                    Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.GenericPaperResponseModel)
                    Dim response As String

                    dataSource.url = adminURL & "/api/v1.0/Define/" & apiSegment & "/?certificate=" & certificate & "&id=" & id

                    response = dataSource.getData()

                    If (response = "") Then
                        _item = dataSource.data

                        nameValue.Text = _item.name
                        ContentValue.Text = _item.content.Replace(vbLf, vbNewLine)

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

                If (MessageBox.Show("Do you want to cancel the Paper " & id, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then

                    Try

                        Dim dataSource As New ProxyWS(Of AreaCommon.Models.Define.GenericPaperResponseModel)
                        Dim response As String

                        dataSource.url = adminURL & "/api/v1.0/Define/" & apiSegment & "/?certificate=" & certificate & "&id=" & id

                        response = dataSource.sendData("DELETE")

                        If (response <> "") Then
                            MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            _items.RemoveAt(rowPosition)

                            AreaInterface.refreshData(apiSegment, adminURL, certificate, _items, dataGridView)
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

    Private Sub ContentValue_TextChanged(sender As Object, e As EventArgs) Handles ContentValue.TextChanged

        _item.content = ContentValue.Text.Trim()
        identityValue.Text = _item.getHash()

    End Sub

End Class
