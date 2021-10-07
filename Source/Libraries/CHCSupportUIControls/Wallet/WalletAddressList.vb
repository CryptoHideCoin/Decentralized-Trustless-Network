Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaWallet.Support

' ****************************************
' File: Wallet Address Control
' Release Engine: 1.0 
' 
' Date last successfully test: 06/10/2021
' ****************************************








Public Class WalletAddressList

    Private _BaseDataPath As String = ""
    Private _DataPath As String = ""


    Public Event RequestAddNew()
    Public Event UseAddress(ByVal value As String)
    Public Event RequestUpdate(ByVal UUID As String)


    ''' <summary>
    ''' This method provide to refresh list of a grid (list of keystore)
    ''' </summary>
    ''' <param name="items"></param>
    Private Sub refreshList(ByRef items As List(Of KeyStoreEngine.KeyStoreItem))
        Try
            Dim rowItem As ArrayList
            Dim rowIndex As Integer = 0

            For Each item As KeyStoreEngine.KeyStoreItem In items

                rowItem = New ArrayList

                rowItem.Add(rowIndex.ToString())
                rowItem.Add(item.name)
                rowItem.Add(item.uuid)

                walletAddressDataGrid.Rows.Add(rowItem.ToArray)

                rowIndex += 1

            Next
        Catch ex As Exception
            MessageBox.Show("Error during reloadData " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' This method provide to load a list data
    ''' </summary>
    Private Sub loadListData()
        Try
            Dim fileName As String = IO.Path.Combine(_dataPath, "keyAddress.list")
            Dim engine As New KeyStoreEngine

            engine.fileName = fileName

            walletAddressDataGrid.Rows.Clear()

            If engine.read() Then
                noDataLabel.Visible = False

                refreshList(engine.data)
            Else
                noDataLabel.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error during loadListData - " & Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' This method provide to get a Read User KeyStore Path
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Private Function readUserKeyStorePath(ByVal value As String) As String
        Dim path As String = IO.Path.Combine(value, "define.path")

        If IO.File.Exists(path) And (value.Trim.Length > 0) Then
            Return IO.File.ReadAllText(path)
        Else
            Return value
        End If
    End Function
    ''' <summary>
    ''' This method provide to create Button Grid
    ''' </summary>
    ''' <param name="textValue"></param>
    ''' <param name="nameValue"></param>
    ''' <returns></returns>
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
    ''' <summary>
    ''' This method provide to resize a controls
    ''' </summary>
    Private Sub resizeControl()
        Try
            configureButton.Left = 16

            listLabel.Left = 13
            listLabel.Width = 141

            walletAddressDataGrid.Left = 16
            walletAddressDataGrid.Width = (Width - 40)

            noDataLabel.Left = (Width - noDataLabel.Width) / 2

            addNewButton.Left = (Width - 132)
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' This method provide to Update Row Grid
    ''' </summary>
    ''' <param name="rowGridNumber"></param>
    Private Sub updateRowGrid(ByVal rowGridNumber As Integer)
        Try
            Dim id As String = walletAddressDataGrid.Item(2, rowGridNumber).Value.ToString()

            If autonomous Then
                Dim form As New KeyPairDetail

                form.pathData = dataPath
                form.loadData(id)

                If Not form.closeMe Then
                    form.ShowDialog(Me)
                End If

                form.Close()
                form.Dispose()

                form = Nothing
            Else
                RaiseEvent RequestUpdate(id)
            End If

            loadListData()
        Catch ex As Exception
            MessageBox.Show("Error during updateRowGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' This property get/let the data Path
    ''' </summary>
    ''' <returns></returns>
    Public Property dataPath() As String
        Get
            Return _dataPath
        End Get
        Set(value As String)
            _BaseDataPath = value
            _DataPath = readUserKeyStorePath(value)

            If (_DataPath.Trim.Length > 0) Then
                loadListData()
            End If
        End Set
    End Property
    Public Property autonomous() As Boolean = False

    ''' <summary>
    ''' This event's method manage the Wallet Address List load control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WalletAddressList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        walletAddressDataGrid.Columns(0).Visible = False
        walletAddressDataGrid.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
        walletAddressDataGrid.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

        walletAddressDataGrid.Columns.Add(createButtonInGrid("Edit", "edit"))
        walletAddressDataGrid.Columns.Add(createButtonInGrid("Delete", "delete"))
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a AddNew click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub addNewButton_Click(sender As Object, e As EventArgs) Handles addNewButton.Click
        Try
            If autonomous Then
                Dim form As New KeyPairDetail

                form.pathData = dataPath

                form.ShowDialog(Me)

                form.Close()
                form.Dispose()

                form = Nothing
            Else
                RaiseEvent RequestAddNew()
            End If

            loadListData()
        Catch ex As Exception
            MessageBox.Show("Error during addNewButton_Click - " & Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' This event's method manage the resize of a Wallet Address List
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WalletAddressList_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        resizeControl()
    End Sub
    ''' <summary>
    ''' This event's method manage a Cell Content Click 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub walletAddressDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles walletAddressDataGrid.CellContentClick
        Try
            Dim id As String
            Dim name As String

            Select Case e.ColumnIndex
                Case 3 : updateRowGrid(e.RowIndex)
                Case 4
                    name = walletAddressDataGrid.Item(1, e.RowIndex).Value.ToString()
                    id = walletAddressDataGrid.Item(2, e.RowIndex).Value.ToString()

                    If (MessageBox.Show("Do you want to cancel the Wallet Address Data '" & name & "' from a list ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                        Try
                            Dim engine As New KeyStoreEngine

                            engine.fileName = IO.Path.Combine(_dataPath, "keyAddress.list")

                            If engine.read() Then
                                engine.remove(id)

                                loadListData()
                            End If

                            engine = Nothing
                        Catch ex As Exception
                            MessageBox.Show("Problem during update KeyStore List information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show("Error during walletAddressDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' This event's method manage a Size Changed of a Wallet Address List
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WalletAddressList_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        resizeControl()
    End Sub
    ''' <summary>
    ''' This event's method manage a Paint a Wallet Address List
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WalletAddressList_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        resizeControl()
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a Cell Content Double Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub walletAddressDataGrid_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles walletAddressDataGrid.CellContentDoubleClick
        Try
            Dim id As String = walletAddressDataGrid.Item(2, e.RowIndex).Value.ToString()

            RaiseEvent UseAddress("keystoreid:" & id)
        Catch ex As Exception
            MessageBox.Show("Error during walletAddressDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' This event's method provide to manage a click of a Configure Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub configureButton_Click(sender As Object, e As EventArgs) Handles configureButton.Click
        Try
            Dim form As New ConfigurePath

            form.dataPath = dataPath

            If (form.ShowDialog() = DialogResult.OK) Then
                IO.File.WriteAllText(IO.Path.Combine(_BaseDataPath, "define.path"), form.dataPath)

                _DataPath = form.dataPath

                loadListData()
            End If

            form.Close()
            form.Dispose()

            form = Nothing
        Catch ex As Exception
            MessageBox.Show("Error during configureButton_Click " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
