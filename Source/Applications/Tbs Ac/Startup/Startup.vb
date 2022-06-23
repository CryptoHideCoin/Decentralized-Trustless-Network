Option Compare Text
Option Explicit On





Namespace AreaCommon

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module Common

        ''' <summary>
        ''' This method provide to close this application
        ''' </summary>
        ''' <param name="message"></param>
        Sub CloseApplication(ByVal message As String)
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Error: " & message)
            Console.ReadKey()

            End
        End Sub

        ''' <summary>
        ''' This method provide to run a application
        ''' </summary>
        Sub Main()
            Try
                Dim commandManager As New CommandProcessor

                commandManager.run()
            Catch ex As Exception
            End Try
        End Sub

    End Module

End Namespace
