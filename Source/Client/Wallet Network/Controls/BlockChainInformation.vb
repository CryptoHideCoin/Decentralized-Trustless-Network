Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Communication
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon.Models.Ledger


Public Class ledgerPanel

    Public Enum ManageType
        undefined
        summary
        ledger
        transactionDetail
        contentTransaction
        order
        consensus
    End Enum

    Private Property _Type As ManageType = ManageType.undefined
    Private Property _CurrentBlockNumber As CurrentBlockInformationModel
    Private Property _Data As List(Of SingleTransactionLedger)
    Private Property _AscendentOrder As Boolean = True
    Private Property _CurrentTransactionID As String = ""

    Public Event OpenConfiguration()


    ''' <summary>
    ''' This property get / let the type of interrogation
    ''' </summary>
    ''' <returns></returns>
    Public Property [type] As ManageType
        Get
            Return _Type
        End Get
        Set(value As ManageType)
            Dim controlObject As Object
            Dim addHeight As Integer = 0
            _Type = value

            summaryData.Visible = False
            ledgerPageData.Visible = False
            transactionDetailData.Visible = False
            contentInformationPanel.Visible = False

            Select Case _Type
                Case ManageType.summary
                    backButton.Enabled = False
                    titleControl.Text = "Ledger Summary"

                    controlObject = summaryData

                    readSummary()
                Case ManageType.ledger
                    titleControl.Text = "Ledger View"

                    controlObject = ledgerPageData

                    readLedgerPage()
                Case ManageType.transactionDetail
                    titleControl.Text = "Transaction detail"

                    controlObject = transactionDetailData

                    transactionDetailData.Visible = True
                    addHeight = 40
                Case ManageType.contentTransaction
                    titleControl.Text = "Transaction detail: " & _CurrentTransactionID

                    controlObject = contentInformationPanel

                    contentInformationPanel.Visible = True
                Case ManageType.order
                    titleControl.Text = "Order transaction: " & _CurrentTransactionID

                    controlObject = contentInformationPanel

                    contentInformationPanel.Visible = True
                Case ManageType.consensus
                    titleControl.Text = "Consensus transaction: " & _CurrentTransactionID

                    controlObject = contentInformationPanel

                    contentInformationPanel.Visible = True
                Case Else
                    Return
            End Select

            controlObject.Visible = True
            controlObject.Location = New Point(0, 35 + addHeight)
            controlObject.width = Me.Width
            controlObject.height = Me.Height - 40 - addHeight
        End Set
    End Property

    ''' <summary>
    ''' This method provide to read a summary
    ''' </summary>
    ''' <returns></returns>
    Private Function readSummary() As Boolean
        Try
            Dim remote As New ProxyWS(Of LedgerInformationResponseModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/ledger/ledgerInformation/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.identifyLedger.Length > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()

                Return False
            End If
            If proceed Then
                With remote.data.value
                    summaryData.identityBlockChain.Text = .identifyLedger
                    summaryData.createLedgerTimeStamp.Text = .createLedgerTimeStamp
                    summaryData.lastUpdateTimeStamp.Text = .lastUpdateTimeStamp
                    summaryData.latestTransaction.Text = .latestTransaction
                    summaryData.numBlocks.Text = .numBlocks
                    summaryData.numTransactions.Text = .numTransaction
                    summaryData.numVolumes.Text = .numVolumes
                End With
            End If

            Return proceed
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to extract the current block number (ID)
    ''' </summary>
    ''' <returns></returns>
    Private Function extractCurrentBlockData() As CurrentBlockInformationModel
        Dim result As New CurrentBlockInformationModel
        Try
            Dim remote As New ProxyWS(Of CurrentBlockInformationResponseModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/ledger/currentBlockInformation/")
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.blockNumber.Length > 0)
            Else
                result = New CurrentBlockInformationModel
            End If
            If proceed Then
                result = remote.data.value
            End If

        Catch ex As Exception
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This method provide a load data into grid
    ''' </summary>
    ''' <returns></returns>
    Private Function loadDataIntoGrid() As Boolean
        Try
            ledgerPageData.resetGrid()

            If _AscendentOrder Then
                For i As Integer = _Data.Count - 1 To 0 Step -1
                    ledgerPageData.addNewRow(_Data(i))
                Next
            Else
                For Each item In _Data
                    ledgerPageData.addNewRow(item)
                Next
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load content transaction
    ''' </summary>
    ''' <returns></returns>
    Private Function loadContentTransaction(ByVal contentHash As String) As Boolean
        Dim result As New CurrentBlockInformationModel
        Try
            Dim remote As New ProxyWS(Of BlockInformationResponseModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/ledger/contentTransaction/?blockID=" & _CurrentBlockNumber.blockNumber & "&contentHash=" & contentHash)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.Length > 0)
            End If
            If proceed Then
                contentInformationPanel.content.Text = remote.data.value
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method to load an order transaction
    ''' </summary>
    ''' <param name="orderHash"></param>
    ''' <returns></returns>
    Private Function loadOrder(ByVal orderHash As String) As Boolean
        Dim result As New CurrentBlockInformationModel
        Try
            Dim remote As New ProxyWS(Of BlockInformationResponseModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/ledger/orderTransaction/?blockID=" & _CurrentBlockNumber.blockNumber & "&contentHash=" & orderHash)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.Length > 0)
            End If
            If proceed Then
                contentInformationPanel.content.Text = remote.data.value
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method to load a consensus transaction
    ''' </summary>
    ''' <param name="orderHash"></param>
    ''' <returns></returns>
    Private Function loadConsensus(ByVal orderHash As String) As Boolean
        Dim result As New CurrentBlockInformationModel
        Try
            Dim remote As New ProxyWS(Of BlockInformationResponseModel)
            Dim proceed As Boolean = True

            If proceed Then
                remote.url = AreaCommon.buildURL("/ledger/consensusTransaction/?blockID=" & _CurrentBlockNumber.blockNumber & "&orderHash=" & orderHash)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.Length > 0)
            End If
            If proceed Then
                contentInformationPanel.content.Text = remote.data.value
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to write a block transaction's last page
    ''' </summary>
    ''' <returns></returns>
    Private Function readLedgerPage() As Boolean
        Try
            Dim remote As New ProxyWS(Of PageTransactionResponseModel)
            Dim proceed As Boolean = True
            Dim lastPageNumber As Integer

            If proceed Then
                _CurrentBlockNumber = extractCurrentBlockData()

                ledgerPageData.blockNumber.Text = "Block address: " & _CurrentBlockNumber.blockNumber
                ledgerPageData.numTransactionInBlock.Text = "Num transaction into block: " & _CurrentBlockNumber.transactionNumber

                lastPageNumber = (_CurrentBlockNumber.transactionNumber \ 20) + 1

                proceed = (_CurrentBlockNumber.blockNumber.Length > 0)
            End If
            If proceed Then
                remote.url = AreaCommon.buildURL("/ledger/pageTransactions/?blockNumber=" & _CurrentBlockNumber.blockNumber & "&pageNumber=" & lastPageNumber)
            End If
            If proceed Then
                proceed = (remote.getData() = "")
            End If
            If proceed Then
                proceed = (remote.data.responseStatus = RemoteResponse.EnumResponseStatus.responseComplete)
            End If
            If proceed Then
                proceed = (remote.data.value.pageNumber > 0)
            Else
                MessageBox.Show("Error during connection", "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)

                RaiseEvent OpenConfiguration()

                Return False
            End If
            If proceed Then
                ledgerPageData.countLabel.Text = "Count: " & lastPageNumber.ToString()
                ledgerPageData.pageNumber.Text = lastPageNumber.ToString()

                _Data = remote.data.value.transactions

                loadDataIntoGrid()
            End If

            Return proceed
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ledgerPanel_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            summaryData.Width = Me.Width
            ledgerPageData.Width = Me.Width
            transactionDetailData.Width = Me.Width
            contentInformationPanel.Width = Me.Width
        Catch ex As Exception
        End Try
        Try
            summaryData.Height = Me.Height - 40
            ledgerPageData.Height = Me.Height - 40
            transactionDetailData.Height = Me.Height - 40
            contentInformationPanel.Height = Me.Height - 40
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ledgerPageData_Load(sender As Object, e As EventArgs) Handles ledgerPageData.Load

    End Sub

    Private Sub ledgerPageData_ShowTransaction(id As Integer) Handles ledgerPageData.ShowTransaction
        For Each item As SingleTransactionLedger In _Data
            If (item.id.CompareTo(id) = 0) Then
                If transactionDetailData.loadDetail(_CurrentBlockNumber.blockNumber, item) Then
                    type = ManageType.transactionDetail
                    backButton.Enabled = True

                    Return
                End If
            End If
        Next
    End Sub

    Private Sub ledgerPanel_Load(sender As Object, e As EventArgs) Handles Me.Load
        backButton.Location = New Point(9, 5)
        titleControl.Location = New Point(37, 5)
    End Sub

    Private Sub backButton_Click(sender As Object, e As EventArgs) Handles backButton.Click
        If (type = ManageType.transactionDetail) Then
            type = ManageType.ledger

            backButton.Enabled = False
        ElseIf (type = ManageType.contentTransaction) Or (type = ManageType.order) Or (type = ManageType.consensus) Then
            type = ManageType.transactionDetail
        End If
    End Sub

    Private Sub ledgerPageData_ChangeOrder() Handles ledgerPageData.ChangeOrder
        _AscendentOrder = Not _AscendentOrder

        loadDataIntoGrid()
    End Sub

    Private Sub transactionDetailData_Load(sender As Object, e As EventArgs) Handles transactionDetailData.Load

    End Sub

    Private Sub transactionDetailData_OpenContentTransaction(ByVal transactionID As String, ByVal contentHash As String) Handles transactionDetailData.OpenContentTransaction
        _CurrentTransactionID = transactionID
        type = ManageType.contentTransaction
        backButton.Enabled = True

        loadContentTransaction(contentHash)
    End Sub

    Private Sub transactionDetailData_OpenOrder(transactionID As String, orderHash As String) Handles transactionDetailData.OpenOrder
        _CurrentTransactionID = transactionID
        type = ManageType.order
        backButton.Enabled = True

        loadOrder(orderHash)
    End Sub

    Private Sub transactionDetailData_OpenConsensus(transactionID As String, orderHash As String) Handles transactionDetailData.OpenConsensus
        _CurrentTransactionID = transactionID
        type = ManageType.consensus
        backButton.Enabled = True

        loadConsensus(orderHash)
    End Sub

End Class
