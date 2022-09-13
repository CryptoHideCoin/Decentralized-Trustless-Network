Public Class MultipleBot

    Private Sub addNewButton_Click(sender As Object, e As EventArgs) Handles addNewButton.Click
        Dim newProduct As String

        newProduct = InputBox("Insert a new product", "Request")

        If (newProduct.Length > 0) Then
            productList.Items.Add(newProduct)
        End If

    End Sub

    Private Function itemCheckedCount() As Integer
        Dim count As Integer = 0

        For i As Integer = 0 To productList.Items.Count - 1
            If productList.GetItemChecked(i) Then
                count += 1
            End If
        Next

        Return count
    End Function

    Private Sub selectAllProcedure(ByVal value As Boolean)
        For i As Integer = 0 To productList.Items.Count - 1
            productList.SetItemChecked(i, value)
        Next

        productsLabel.Text = $"Select the products to use ({itemCheckedCount()}/{productList.Items.Count})"
    End Sub

    Private Sub MultipleBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        selectAllProcedure(True)
    End Sub

    Private Sub sleepTime(ByVal waitTime As Integer)
        Dim endTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() + waitTime

        Do While (CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() < endTime)

            If AreaState.closeApplication Then
                Return
            End If

            Threading.Thread.Sleep(10)
            Application.DoEvents()
        Loop
    End Sub

    Private Sub confirmButton_Click(sender As Object, e As EventArgs) Handles confirmButton.Click
        Dim addNewBot As New SettingsBot
        Dim Item As Object
        Dim waitTime As Integer = 0

        Me.Visible = False

        If (delayDuringAdd.Text.Trim.Length > 0) Then
            If IsNumeric(Val(delayDuringAdd.Text)) Then
                waitTime = Val(delayDuringAdd.Text) * 1000
            End If
        Else
            waitTime = 100
        End If

        For i = 0 To productList.Items.Count - 1
            Item = productList.Items(i)

            If productList.GetItemChecked(i) Then
                addNewBot.createNewBot(Item)

                sleepTime(waitTime)

                If AreaState.closeApplication Then
                    Exit For
                End If
            End If
        Next

        Me.Close()
    End Sub

    Private Sub selectAll_Click(sender As Object, e As EventArgs) Handles selectAllButton.Click
        selectAllProcedure(True)
    End Sub

    Private Sub noneButton_Click(sender As Object, e As EventArgs) Handles noneButton.Click
        selectAllProcedure(False)
    End Sub

    Private Sub MultipleBot_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub defaultSettings_Click(sender As Object, e As EventArgs) Handles defaultSettings.Click
        Dim defaultForm As New SettingsBot

        defaultForm.defaultMode = True

        defaultForm.ShowDialog()
    End Sub

    Private Sub productList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles productList.SelectedIndexChanged

    End Sub

    Private Sub productList_GotFocus(sender As Object, e As EventArgs) Handles productList.GotFocus

    End Sub

    Private Sub productList_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles productList.ItemCheck
        productsLabel.Text = $"Select the products to use ({itemCheckedCount()}/{productList.Items.Count})"
    End Sub
End Class