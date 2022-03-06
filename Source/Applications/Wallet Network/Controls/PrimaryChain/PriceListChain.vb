Option Compare Text
Option Explicit On



Public Class PriceListChain

    ''' <summary>
    ''' This method provide to load a data into grid
    ''' </summary>
    ''' <returns></returns>
    Private Function loadSingleRowDataIntoGrid(ByVal rowData As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableModel) As Boolean
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(rowData.code)
            rowItem.Add(rowData.description)
            rowItem.Add(rowData.contribute)

            priceDetailGrid.Rows.Add(rowItem.ToArray)

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
        priceDetailGrid.Rows.Clear()

        Return True
    End Function

    ''' <summary>
    ''' This method provide to load all data into scenario
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Public Function loadEntireData(ByVal value As CHCProtocolLibrary.AreaCommon.Models.Network.ItemPriceTableListModel) As Boolean
        codePriceList.Text = value.code

        resetGrid()

        For Each item In value.items
            loadSingleRowDataIntoGrid(item)
        Next

        Return True
    End Function

    Private Sub PriceListChain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
