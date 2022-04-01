Option Compare Text
Option Explicit On


Public Class ShowLogConfiguration

    Private Sub ShowLogConfiguration_Load(sender As Object, e As EventArgs) Handles Me.Load
        If AreaCommon.Main.showLogParameters.showOnlyInfo Then
            showOnlyInfo.Checked = True
        Else
            showAllTracks.Checked = True
        End If
        inPause.Checked = AreaCommon.Main.showLogParameters.pause
        frequencyRefresh.Value = AreaCommon.Main.showLogParameters.frequencyRefresh
    End Sub

    Private Sub generalInformation_CheckedChanged(sender As Object, e As EventArgs) Handles showOnlyInfo.CheckedChanged
        If showOnlyInfo.Checked Then
            AreaCommon.Main.showLogParameters.showOnlyInfo = True
        End If
    End Sub

    Private Sub showAllTracks_CheckedChanged(sender As Object, e As EventArgs) Handles showAllTracks.CheckedChanged
        If showAllTracks.Checked Then
            AreaCommon.Main.showLogParameters.showOnlyInfo = False
        End If
    End Sub

    Private Sub inPause_CheckedChanged(sender As Object, e As EventArgs) Handles inPause.CheckedChanged
        AreaCommon.Main.showLogParameters.pause = inPause.Checked
    End Sub

    Private Sub frequencyRefresh_ValueChanged(sender As Object, e As EventArgs) Handles frequencyRefresh.ValueChanged
        AreaCommon.Main.showLogParameters.frequencyRefresh = frequencyRefresh.Value
    End Sub

End Class
