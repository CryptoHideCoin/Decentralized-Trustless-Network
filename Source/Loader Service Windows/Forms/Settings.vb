Option Compare Text
Option Explicit On



Public Class Settings


    Private Sub adminSettingsButton_Click(sender As Object, e As EventArgs) Handles adminSettingsButton.Click

        Try

            AreaCommon.executeExternalApplication("CHCAdminService.exe", "/Settings")

        Catch ex As Exception
            AreaCommon.log.track("adminSettingsButton_Click", "Error:" & ex.Message, "fatal")

            AreaCommon.closeApplication()
        End Try

    End Sub


    Private Sub starterSettingsButton_Click(sender As Object, e As EventArgs) Handles starterSettingsButton.Click

        Try

            Dim tmp As New Main

            tmp.SettingsMode = True

            tmp.ShowDialog()

        Catch ex As Exception
            AreaCommon.log.track("starterSettingsButton_Click", "Error:" & ex.Message, "fatal")

            AreaCommon.closeApplication()
        End Try

    End Sub


    Private Sub runTimeSettingsButton_Click(sender As Object, e As EventArgs) Handles runTimeSettingsButton.Click

        Try
            AreaCommon.executeExternalApplication("CHCRuntimeService.exe", "/Settings")
        Catch ex As Exception
            AreaCommon.log.track("runTimeSettingsButton_Click", "Error:" & ex.Message, "fatal")

            AreaCommon.closeApplication()
        End Try

    End Sub


End Class