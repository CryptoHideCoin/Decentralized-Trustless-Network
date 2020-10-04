Option Compare Text
Option Explicit On
Imports System.ComponentModel

Public Class refundDetailGroup

    Private _currentRow As Integer
    Private _item As AreaCommon.Models.Define.RefundItem
    Private _duringLoadData As Boolean


    Public dataGroup As AreaCommon.Models.Define.RefundGroup



    Private Sub cancelButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub refundDetailGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        nameValue.Text = dataGroup.name

        If (dataGroup.percentage > 0) Then
            groupValue.Text = dataGroup.percentage.ToString & " %"
        Else
            groupValue.Text = dataGroup.fixValue.ToString
        End If

        AreaInterface.createStandardGrid(itemDataGrid)

        reloadDataItem()

    End Sub


    Private Sub lockField(ByVal lockValue As Boolean)

        recipientLabel.Enabled = Not lockValue
        recipientValue.Enabled = Not lockValue

        refundInFixValue.Enabled = Not lockValue
        refundInPercentage.Enabled = Not lockValue

        value.ReadOnly = lockValue

        confirmGroup.Enabled = Not lockValue
        cancelUpdate.Enabled = Not lockValue

    End Sub


    Private Sub enableFieldDetail(ByVal valueResult As Boolean)

        recipientLabel.Enabled = valueResult
        recipientValue.Enabled = valueResult

        refundInPercentage.Enabled = valueResult
        refundInFixValue.Enabled = valueResult
        valueLabel.Enabled = valueResult
        value.Enabled = valueResult

        confirmGroup.Enabled = valueResult
        cancelUpdate.Enabled = valueResult

    End Sub


    Private Sub addNewItem_Click(sender As Object, e As EventArgs) Handles addNewItem.Click

        _currentRow = -2
        _item = New AreaCommon.Models.Define.RefundItem

        lockField(False)
        enableFieldDetail(True)

        recipientValue.Text = ""
        refundInFixValue.Checked = False
        refundInPercentage.Checked = False
        value.Text = ""

        recipientValue.Select()

    End Sub


    Private Function checkDuplicate() As Boolean

        For i As Integer = 0 To dataGroup.items.Count - 2

            Dim firstItem As AreaCommon.Models.Define.RefundItem = dataGroup.items(i)

            For j As Integer = i + 1 To dataGroup.items.Count - 1

                Dim secondItem As AreaCommon.Models.Define.RefundItem = dataGroup.items(j)

                If (firstItem.recipient = secondItem.recipient) Then

                    MessageBox.Show("More occurrence of " & firstItem.recipient & " is exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return True

                End If

            Next

        Next

        Return False

    End Function


    Private Function validateData() As Boolean

        If (_item.recipient.Length = 0) Then

            MessageBox.Show("The asset's name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If Not refundInFixValue.Checked And Not refundInPercentage.Checked Then

            MessageBox.Show("Select the refund in fix value or refund in percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        If (_item.percentage = 0) And (_item.fixValue = 0) Then

            MessageBox.Show("The value is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return True

    End Function


    Private Sub reloadDataItem()

        Try

            Dim rowItem As ArrayList
            Dim rowIndex As Integer = 0

            _duringLoadData = True

            itemDataGrid.Rows.Clear()

            For Each item As AreaCommon.Models.Define.RefundItem In dataGroup.items

                rowItem = New ArrayList

                rowItem.Add(rowIndex.ToString())
                rowItem.Add(item.recipient)

                If (item.percentage > 0) Then
                    rowItem.Add(item.percentage.ToString() & " %")
                Else
                    rowItem.Add(item.fixValue.ToString())
                End If

                itemDataGrid.Rows.Add(rowItem.ToArray)

                rowIndex += 1

            Next

            _duringLoadData = False

        Catch ex As Exception
            MessageBox.Show("Error during reloadDataItem " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub selectItemGroupData()

        If (itemDataGrid.SelectedRows.Count > 0) Then

            _currentRow = itemDataGrid.SelectedRows.Item(0).Cells(0).Value.ToString()

            Try

                _item = dataGroup.items(_currentRow)
                _duringLoadData = True
                recipientValue.Text = _item.recipient

                If _item.percentage > 0 Then
                    refundInPercentage.Checked = True

                    value.Text = _item.percentage
                Else
                    refundInFixValue.Checked = True

                    value.Text = _item.fixValue
                End If

                _duringLoadData = False

                lockField(True)

            Catch ex As Exception
                MessageBox.Show("Error during selectItemGroupData " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else

            lockField(True)

            recipientValue.Text = ""
            refundInFixValue.Checked = False
            refundInPercentage.Checked = False
            value.Text = ""

        End If

    End Sub


    Private Sub confirmGroup_Click(sender As Object, e As EventArgs) Handles confirmGroup.Click

        Dim singleRow As AreaCommon.Models.Define.RefundItem

        If validateData() Then

            If (_currentRow <> -2) Then
                singleRow = dataGroup.items(_currentRow)
            Else
                singleRow = New AreaCommon.Models.Define.RefundItem

                dataGroup.items.Add(singleRow)
            End If

            With singleRow

                .recipient = _item.recipient
                .percentage = _item.percentage
                .fixValue = _item.fixValue

            End With

            reloadDataItem()
            selectItemGroupData()

        End If

    End Sub


    Private Sub recipientValue_TextChanged(sender As Object, e As EventArgs) Handles recipientValue.TextChanged

        _item.recipient = recipientValue.Text

    End Sub


    Private Sub textChangedValue()

        If _duringLoadData Or IsNothing(_item) Then Return

        If refundInFixValue.Checked Then

            _item.percentage = 0

            If IsNumeric(value.Text.ToString.Trim) Then

                If (Decimal.Truncate(Decimal.Parse(value.Text)) = Decimal.Parse(value.Text)) Then
                    _item.fixValue = Decimal.Parse(value.Text & ",0")
                Else
                    _item.fixValue = Decimal.Parse(value.Text)
                End If

            Else
                _item.fixValue = 0
            End If

        ElseIf refundInPercentage.Checked Then

            _item.fixValue = 0

            If IsNumeric(value.Text.ToString.Trim) Then

                If (Decimal.Truncate(Decimal.Parse(value.Text)) = Decimal.Parse(value.Text)) Then
                    _item.percentage = Decimal.Parse(value.Text & ",0")
                Else
                    _item.percentage = Decimal.Parse(value.Text)
                End If

            Else
                _item.percentage = 0
            End If

        End If

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

    Private Sub recipientValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles recipientValue.SelectedIndexChanged

    End Sub

    Private Sub value_TextChanged(sender As Object, e As EventArgs) Handles value.TextChanged

        textChangedValue()

    End Sub

    Private Sub itemDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles itemDataGrid.CellContentClick

        Select Case e.ColumnIndex

            Case 3
                _currentRow = itemDataGrid.Item(0, e.RowIndex).Value.ToString()

                lockField(False)

                recipientValue.Select()
            Case 4

                Try
                    _currentRow = itemDataGrid.Item(0, e.RowIndex).Value.ToString()

                    dataGroup.items.RemoveAt(_currentRow)

                    reloadDataItem()
                    selectItemGroupData()
                Catch ex As Exception
                    MessageBox.Show("Error during itemDataGrid_CellContentClick " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

        End Select

    End Sub

    Private Sub cancelUpdate_Click(sender As Object, e As EventArgs) Handles cancelUpdate.Click

        selectItemGroupData()

    End Sub

    Private Sub confirmButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub refundDetailGroup_Validated(sender As Object, e As EventArgs) Handles Me.Validated


    End Sub


    Private Function validateAllData() As Boolean

        Dim totPercentage As Double = 0
        Dim totValue As Decimal = 0

        For Each item In dataGroup.items

            If (item.percentage > 0) Then
                totPercentage += item.percentage
            Else
                totValue += item.fixValue
            End If

        Next

        If (totPercentage > 0) And (totPercentage < 100) Then

            MessageBox.Show("The total of percentage is different than 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        ElseIf (dataGroup.fixValue > 0) And (totValue > dataGroup.fixValue) Then

            MessageBox.Show("The total of fix Value is more than " & dataGroup.fixValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If

        Return Not checkDuplicate()

    End Function


    Private Sub refundDetailGroup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not validateAllData() Then
            e.Cancel = True
        End If

    End Sub

    Private Sub itemDataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles itemDataGrid.SelectionChanged

        If _duringLoadData Then Return

        selectItemGroupData()
    End Sub


End Class