Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCProtocolLibrary.AreaCommon
Imports CHCCommonLibrary.AreaCommon.Models.General




Public Class ChainMasternodes

    Private Property _NumMasterNodes As Integer = 0
    Private Property _Data As New List(Of Models.Chain.NodeComplete)

    Public Event OpenDetail(ByRef data As Models.Chain.NodeComplete)



    ''' <summary>
    ''' This method provide to load a masternode list
    ''' </summary>
    ''' <returns></returns>
    Private Function loadMasterNodesPage() As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Dim remote As New ProxyWS(Of Models.Chain.Response.ChainMasterNodeModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/chain/chainMasterNodes/?pageIndex=" & pageNumber.Text & "&name=" & chainName)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If Not proceed Then
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Return False
            End If
            If proceed Then
                If (remote.data.value.Count > 0) Then
                    _Data = remote.data.value

                    resetGrid()

                    For Each item In remote.data.value
                        loadSingleRowDataIntoGrid(item)
                    Next
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load a data into grid
    ''' </summary>
    ''' <returns></returns>
    Private Function loadSingleRowDataIntoGrid(ByVal rowData As Models.Chain.NodeComplete) As Boolean
        Try
            Dim rowItem As New ArrayList

            rowItem.Add(rowData.identityPublicAddress)

            Select Case rowData.role
                Case Models.Chain.RoleMasterNode.arbitration : rowItem.Add("Arbitration")
                Case Models.Chain.RoleMasterNode.fullStack : rowItem.Add("Full stack")
                Case Models.Chain.RoleMasterNode.newsFeeder : rowItem.Add("News feeder")
                Case Models.Chain.RoleMasterNode.publisherBlockChain : rowItem.Add("Publisher blockchain")
                Case Models.Chain.RoleMasterNode.query : rowItem.Add("Query")
                Case Models.Chain.RoleMasterNode.validator : rowItem.Add("Validator")
            End Select

            masterNodeDataGrid.Rows.Add(rowItem.ToArray)

            Return True
        Catch ex As Exception
            MessageBox.Show("Error during loadSingleRowDataIntoGrid " & Err.Description, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function


    Public Property chainName As String = ""

    ''' <summary>
    ''' This property get / let a masternodes number
    ''' </summary>
    ''' <returns></returns>
    Public Property numMasterNodes As Integer
        Get
            Return _NumMasterNodes
        End Get
        Set(value As Integer)
            _NumMasterNodes = value

            If value = 0 Then Return

            masterNodeNumValueLabel.Text = "Total MasterNode count: " & _NumMasterNodes.ToString()
            countLabel.Text = "Count: " & Math.Ceiling(value / 10).ToString()

            pageNumber.Text = "1"

            If (value < 11) Then
                pageNumber.Enabled = False
                pageNextButton.Enabled = False
                pagePreviousButton.Enabled = False
            Else

                pageNumber.Enabled = True
                pageNextButton.Enabled = True
            End If

            loadMasterNodesPage()
        End Set
    End Property

    ''' <summary>
    ''' This method provide to reset a grid
    ''' </summary>
    ''' <returns></returns>
    Private Function resetGrid() As Boolean
        masterNodeDataGrid.Rows.Clear()

        Return True
    End Function

    Private Sub masterNodeDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles masterNodeDataGrid.CellContentClick
        RaiseEvent OpenDetail(_Data(e.RowIndex))
    End Sub

    Private Sub ChainMasternodes_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            masterNodeDataGrid.Width = Me.Width
        Catch ex As Exception
        End Try
        Try
            masterNodeDataGrid.Height = Me.Height - 83
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChainMasternodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
