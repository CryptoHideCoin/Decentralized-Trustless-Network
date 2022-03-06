Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaCommon.Models.General





Public Class SupplyDetail


    ''' <summary>
    ''' This method provide to load a data integration into UI
    ''' </summary>
    ''' <returns></returns>
    Private Function loadDataIntegration(ByVal infoIntegrity As IdentifyLastTransaction, ByVal startTime As Double) As Boolean
        Try
            coordinate.Text = infoIntegrity.coordinate
            If (infoIntegrity.registrationTimeStamp = 0) Then
                registrationTimeStamp.Text = "---"
            Else
                registrationTimeStamp.Text = infoIntegrity.registrationTimeStamp
            End If
            hash.Text = infoIntegrity.hash
            progressiveHash.Text = infoIntegrity.progressiveHash
            responseTime.Text = Int(CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime() - CDec(startTime)) & " ms."

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This method provide to load a data information into display
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="symbol"></param>
    ''' <returns></returns>
    Public Function loadDataDisplay(ByRef data As CHCProtocolLibrary.AreaCommon.Models.Supply.Response.SupplyResponseModel, ByVal symbol As String) As Boolean
        Try
            Dim startTime As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            supplyPanel.totalAmount.Text = data.value.total
            supplyPanel.totalLocked.Text = data.value.locked
            supplyPanel.totalAvailable.Text = data.value.available

            If (data.value.lastStake = 0) Then
                supplyPanel.lastStakeDateTime.Text = "---"
            Else
                supplyPanel.lastStakeDateTime.Text = data.value.lastStake
            End If

            supplyPanel.symbolAmountLabel.Text = symbol
            supplyPanel.symbolAvailableLabel.Text = symbol
            supplyPanel.symbolLockedLabel.Text = symbol

            Return loadDataIntegration(data.integrityTransactionChain, startTime)
        Catch ex As Exception
            Return False
        End Try


    End Function

    Private Sub supplyPanel_Load(sender As Object, e As EventArgs) Handles supplyPanel.Load

    End Sub
End Class
