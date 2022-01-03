Option Compare Text
Option Explicit On

Imports CHCProtocolLibrary.AreaCommon.Models.Chain



Public Class Guarantors

    ''' <summary>
    ''' This method provide to load a data into grid
    ''' </summary>
    ''' <param name="totalPowerValue"></param>
    ''' <param name="symbol"></param>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Function loadData(ByVal totalPowerValue As Double, ByVal symbol As String, ByRef data As List(Of RequestAddNewNode.GuaranteeInformation)) As Boolean
        Try
            Dim rowItem As New ArrayList

            guarantorsDataGrid.Rows.Clear()

            For Each item In data
                rowItem.Add(item.publicAddress)
                rowItem.Add(Format(item.power, "#.##0,00") & " " & symbol)

                guarantorsDataGrid.Rows.Add(rowItem.ToArray)
            Next

            totalPower.Text = totalPowerValue
            symbolLabel.Text = symbol

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub confirmButton_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

End Class