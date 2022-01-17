Option Compare Text
Option Explicit On


Public Class TransactionDetail

    Public Event OpenContentTransaction(ByVal transactionID As String, ByVal contentHash As String)
    Public Event OpenOrder(ByVal transactionID As String, ByVal orderHash As String)
    Public Event OpenConsensus(ByVal transactionID As String, ByVal orderHash As String)


    Private Sub TransactionDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        completeIDLabel.Left = 61
        registrationTimeStampLabel.Left = 6
        classLabel.Left = 110
        ordererLabel.Left = 96
        validatorLabel.Left = 91
        orderHashLabel.Left = 77
        specificDetailLabel.Left = 61

        completeID.Left = 150
        registrationTimeStamp.Left = 150
        classTransaction.Left = 150
        orderer.Left = 150
        validator.Left = 150
        orderHash.Left = 150
        specificDetail.Left = 150
    End Sub

    ''' <summary>
    ''' This method provide to load all detail information into field
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    Public Function loadDetail(ByVal blockNumber As String, ByVal item As CHCProtocolLibrary.AreaCommon.Models.Ledger.SingleTransactionLedger) As Boolean
        Try
            completeID.Text = blockNumber & "-" & item.id.ToString()
            registrationTimeStamp.Text = item.registrationTimeStamp.ToString()
            classTransaction.Text = item.type
            orderer.Text = item.requesterPublicAddress
            validator.Text = item.approverPublicAddress
            orderHash.Text = item.requestHash

            specificDetail.Text = item.detailInformation

            If (item.detailInformation.Length <> 64) Then
                specificDetail.Enabled = False
            End If

            consensusHash.Text = item.consensusHash
            transactionHash.Text = item.currentHash
            cumulativeHash.Text = item.progressiveHash

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub contentOrder_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles specificDetail.LinkClicked
        RaiseEvent OpenContentTransaction(completeID.Text, specificDetail.Text)
    End Sub

    Private Sub orderHash_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles orderHash.LinkClicked
        RaiseEvent OpenOrder(completeID.Text, orderHash.Text)
    End Sub

    Private Sub consensusHash_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles consensusHash.LinkClicked
        RaiseEvent OpenConsensus(completeID.Text, orderHash.Text)
    End Sub

End Class
