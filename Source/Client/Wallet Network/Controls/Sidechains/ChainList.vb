Option Compare Text
Option Explicit On


Public Class ChainList

    Private Property _NumChain As Integer = 0

    Public Event OpenChain(ByVal name As String)


    ''' <summary>
    ''' This property manage the num chains of list
    ''' </summary>
    ''' <returns></returns>
    Public Property numChains As Integer
        Get
            Return _NumChain
        End Get
        Set(value As Integer)
            _NumChain = value

            countLabel.Text = "Count: " & value.ToString()

            If (value < 11) Then
                pageNumber.Text = ""
                pageNumber.Enabled = False
                pageNextButton.Enabled = False
                pagePreviousButton.Enabled = False
            Else
                pageNumber.Text = "1"
                pageNumber.Enabled = True
                pageNextButton.Enabled = True
            End If
        End Set
    End Property

    Private Sub ChainList_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            chainDataGrid.Width = Me.Width - 15
        Catch ex As Exception
        End Try
        Try
            chainDataGrid.Height = Me.Height - 88
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' This method provide to reset a grid
    ''' </summary>
    ''' <returns></returns>
    Public Function resetGrid() As Boolean
        chainDataGrid.Rows.Clear()

        Return True
    End Function

    ''' <summary>
    ''' This method provide to load a data into grid
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Function loadDataIntoGrid(ByVal data As CHCProtocolLibrary.AreaCommon.Models.Chain.ChainMinimalData) As Boolean
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(data.name)

            If data.privateChain Then
                rowItem.Add("YES")
            Else
                rowItem.Add("NO")
            End If

            chainDataGrid.Rows.Add(rowItem.ToArray)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error during loadDataIntoGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Sub chainDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles chainDataGrid.CellContentClick
        RaiseEvent OpenChain(chainDataGrid.Rows.Item(e.RowIndex).Cells(0).Value)
    End Sub

End Class
