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

            'If commandListManager.existCommand(CommandEnumeration.help) Then

            ' I check if by chance the setEnvironmentPath setting is among the commands

            ' if not there I look for the dataPath path

            'End If

            commandManager.execute()
        End Sub

    End Module

End Namespace
