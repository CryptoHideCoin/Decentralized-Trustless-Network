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
                Else
                    Console.ReadKey()
                End If
            Catch ex As Exception
                writeError($"Error: An error occurrent during moduleMain.startup {Err.Description}")
            End Try
        End Sub

        ''' <summary>
        ''' This method provide to write an error into console
        ''' </summary>
        ''' <param name="message"></param>
        ''' <returns></returns>
        Public Function writeError(ByVal message As String) As Boolean
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine($"Error: An error occurrent during moduleMain.startup {message}")
            Console.ReadKey()

            Return true
        End Function

    End Module

End Namespace
