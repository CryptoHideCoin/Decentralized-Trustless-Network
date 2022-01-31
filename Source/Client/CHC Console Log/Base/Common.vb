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

            commandManager.command = (New CommandLineDecoder).run()

            If commandManager.execute() Then
                Select Case commandManager.command.code
                    Case CommandEnumeration.force

                    Case CommandEnumeration.undefined
                        Console.WriteLine("Command not recognized")
                End Select
            End If
        End Sub

    End Module

End Namespace
