Option Compare Text
Option Explicit On


Imports CHCProtocolLibrary.AreaCommon.Models.Chain





Public Class MasternodeDetail

    Private Property _Data As NodeComplete
    Private Property _BaseURL As String = ""

    Public Event GetDataSymbol(ByRef value As String)
    Public Event CloseMe()


    ''' <summary>
    ''' This method provide to load a data into panels
    ''' </summary>
    ''' <returns></returns>
    Public Function loadData(ByRef data As NodeComplete) As Boolean
        Try
            Dim rowItem As New ArrayList
            Dim symbol As String

            identityPublicAddress.Text = data.identityPublicAddress
            startConnectionTimeStamp.Text = data.startConnectionTimeStamp
            autoStartDisconnectTimeStamp.Text = data.autoDisconnectTimeStamp

            Select Case data.role
                Case RoleMasterNode.arbitration : role.Text = "Arbitration"
                Case RoleMasterNode.fullStack : role.Text = "Full stack"
                Case RoleMasterNode.newsFeeder : role.Text = "News feeder"
                Case RoleMasterNode.publisherBlockChain : role.Text = "Publisher blockchain"
                Case RoleMasterNode.query : role.Text = "Query"
                Case RoleMasterNode.validator : role.Text = "Validator"
            End Select

            refundPublicAddress.Text = data.refundPublicAddress
            power.Text = data.getPower()

            addressIPDataGrid.Rows.Clear()

            For Each item In data.addressesIP
                rowItem.Add(item.addressIP)
                If item.main Then
                    rowItem.Add("YES")
                Else
                    rowItem.Add("NO")
                End If

                If item.main Then
                    _BaseURL = item.addressIP
                End If

                addressIPDataGrid.Rows.Add(rowItem.ToArray)
            Next

            _Data = data

            RaiseEvent GetDataSymbol(symbol)

            symbolLabel.Text = symbol

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub MasternodeDetail_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            identityPublicAddress.Width = Me.Width - 50
            refundPublicAddress.Width = identityPublicAddress.Width
        Catch ex As Exception
        End Try
        Try
            role.Width = Me.Width - 525
        Catch ex As Exception
        End Try
        Try
            addressIPDataGrid.Width = Me.Width - 250
        Catch ex As Exception
        End Try
    End Sub

    Private Sub connectTo_Click(sender As Object, e As EventArgs) Handles connectTo.Click
        AreaCommon.forceBaseURL = _BaseURL

        MessageBox.Show("Masternode connected", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        RaiseEvent CloseMe()
    End Sub

    Private Sub guarantorsButton_Click(sender As Object, e As EventArgs) Handles guarantorsButton.Click
        Try
            Dim dialogGuarantors As New Guarantors

            dialogGuarantors.identityPublicAddress.Text = identityPublicAddress.Text
            dialogGuarantors.loadData(_Data.getPower(), symbolLabel.Text, _Data.guarantors)

            dialogGuarantors.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MasternodeDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
