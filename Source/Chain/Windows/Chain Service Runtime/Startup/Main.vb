﻿Option Compare Text
Option Explicit On




Namespace AreaCommon.Startup

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module Main

        ''' <summary>
        ''' This method provide to run a application
        ''' </summary>
        Sub Main()
            Try
                Dim proceed As Boolean = True

                If proceed Then proceed = run()
                If proceed Then proceed = Maintenance.runService()
                If proceed Then proceed = Service.runService()

            Catch ex As Exception
                MessageBox.Show("An error occurrent during moduleMain.startup " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Module

End Namespace