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
            Console.WriteLine("Error: " & message)

            End
        End Sub

        ''' <summary>
        ''' This method provide to run a application
        ''' </summary>
        Sub Main()
            Dim commandManager As New CommandProcessor

            commandManager.run(Environment.CommandLine)
        End Sub

    End Module

End Namespace
