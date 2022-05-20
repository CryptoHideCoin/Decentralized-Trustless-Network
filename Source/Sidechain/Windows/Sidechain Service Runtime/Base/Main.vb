Option Compare Text
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

                If proceed Then proceed = MainBootstrap.run()
                If proceed Then proceed = Service.run()
                If proceed Then proceed = Scheduler.run()
                If proceed Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.environment.log.trackMarker("Bootstrap complete")
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurrent during moduleMain.startup " & Err.Description, "Notify problem", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub manageShutDown()

        End Sub

    End Module

End Namespace
