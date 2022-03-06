Option Compare Text
Option Explicit On


Public Class ProtocolsChain

    Public Event OpenProtocolChain(ByRef data As CHCProtocolLibrary.AreaCommon.Models.Chain.Response.SingleSetProtocol)

    Public Property protocolData As List(Of CHCProtocolLibrary.AreaCommon.Models.Chain.Response.SingleSetProtocol)

    ''' <summary>
    ''' This method provide to load a data into grid
    ''' </summary>
    ''' <returns></returns>
    Private Function loadSingleRowDataIntoGrid(ByVal rowData As CHCProtocolLibrary.AreaCommon.Models.Chain.ProtocolMinimalData) As Boolean
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(rowData.setCode)
            rowItem.Add(rowData.protocol)

            protocolDataGrid.Rows.Add(rowItem.ToArray)

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
    Public Function resetGrid() As Boolean
        protocolDataGrid.Rows.Clear()

        Return True
    End Function

    ''' <summary>
    ''' This method provide to load data into grid
    ''' </summary>
    ''' <returns></returns>
    Public Function loadDataIntoGrid() As Boolean
        For Each item In protocolData
            loadSingleRowDataIntoGrid(item.data)
        Next

        Return True
    End Function

    Private Sub protocolDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles protocolDataGrid.CellContentClick
        RaiseEvent OpenProtocolChain(protocolData(e.RowIndex))
    End Sub

End Class
