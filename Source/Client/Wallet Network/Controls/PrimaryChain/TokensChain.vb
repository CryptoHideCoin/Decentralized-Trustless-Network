Option Compare Text
Option Explicit On



Public Class TokensChain

    Public Event OpenTokenChain(ByRef data As CHCProtocolLibrary.AreaCommon.Models.Chain.AssetStructure)

    Public Property tokensData As List(Of CHCProtocolLibrary.AreaCommon.Models.Chain.AssetStructure)

    ''' <summary>
    ''' This method provide to load a data into grid
    ''' </summary>
    ''' <returns></returns>
    Private Function loadSingleRowDataIntoGrid(ByVal rowData As CHCProtocolLibrary.AreaCommon.Models.Chain.AssetStructure) As Boolean
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(rowData.value.assetInformation.name)
            rowItem.Add(rowData.value.assetInformation.shortName)

            tokensDataGrid.Rows.Add(rowItem.ToArray)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error during loadSingleRowDataIntoGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function


    ''' <summary>
    ''' This method provide to reset a grid
    ''' </summary>
    ''' <returns></returns>
    Private Function resetGrid() As Boolean
        tokensDataGrid.Rows.Clear()

        Return True
    End Function

    ''' <summary>
    ''' This method provide to load data into grid
    ''' </summary>
    ''' <returns></returns>
    Public Function loadDataIntoGrid() As Boolean
        resetGrid()

        For Each item In tokensData
            loadSingleRowDataIntoGrid(item)
        Next

        Return True
    End Function


    Private Sub tokensDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tokensDataGrid.CellContentClick
        RaiseEvent OpenTokenChain(tokensData(e.RowIndex))
    End Sub


End Class
