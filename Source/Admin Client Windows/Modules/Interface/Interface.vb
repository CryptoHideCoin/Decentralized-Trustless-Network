Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication




Namespace AreaInterface


    Module Support


        Public Function createButtonInGrid(ByVal textValue As String, ByVal nameValue As String) As DataGridViewButtonColumn

            Dim buttonColumn As DataGridViewButtonColumn

            buttonColumn = New DataGridViewButtonColumn()

            buttonColumn.HeaderText = ""
            buttonColumn.Text = textValue
            buttonColumn.Name = nameValue
            buttonColumn.Width = 60
            buttonColumn.UseColumnTextForButtonValue = True

            Return buttonColumn

        End Function


        Public Sub createStandardGrid(ByRef dataGridView As DataGridView)

            dataGridView.Columns(0).Visible = False
            dataGridView.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter
            dataGridView.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter

            dataGridView.Columns.Add(createButtonInGrid("Edit", "edit"))
            dataGridView.Columns.Add(createButtonInGrid("Delete", "delete"))

        End Sub


        Public Sub reloadData(ByRef grid As DataGridView, ByRef items As List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel))

            Try

                Dim rowItem As ArrayList
                Dim rowIndex As Integer = 0

                grid.Rows.Clear()

                For Each item As AreaCommon.Models.Define.ItemKeyDescriptionModel In items

                    rowItem = New ArrayList

                    rowItem.Add(rowIndex.ToString())
                    rowItem.Add(item.name)
                    rowItem.Add(item.identity)

                    grid.Rows.Add(rowItem.ToArray)

                    rowIndex += 1

                Next

            Catch ex As Exception
                MessageBox.Show("Error during reloadData " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub


        Private Function testErrorResult(ByRef items As List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel)) As Boolean

            If (items.Count = 1) Then

                Dim item As AreaCommon.Models.Define.ItemKeyDescriptionModel = items(0)

                If item.response.error Then

                    If item.response.offline Then
                        MessageBox.Show("Error: The service is offline", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    If item.response.unAuthorized Then
                        MessageBox.Show("Error: Unauthorized request", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    Return True

                Else
                    Return False
                End If

            Else
                Return False
            End If

        End Function


        Public Function refreshData(ByVal urlInternal As String, ByVal adminURL As String, ByVal certificate As String, ByRef items As List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel), ByRef grid As DataGridView) As Boolean

            Try

                Dim dataList As New ProxyWS(Of List(Of AreaCommon.Models.Define.ItemKeyDescriptionModel))
                Dim response As String

                dataList.url = adminURL & "/api/v1.0/Define/" & urlInternal & "/?certificate=" & certificate

                response = dataList.getData()

                If (response = "") Then
                    items = dataList.data

                    If testErrorResult(items) Then Return False

                    reloadData(grid, items)

                    Return True
                Else
                    MessageBox.Show("Connection error " & response, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Return False
                End If

            Catch ex As Exception
                MessageBox.Show("Error during refreshData " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End Try

        End Function



    End Module


End Namespace
