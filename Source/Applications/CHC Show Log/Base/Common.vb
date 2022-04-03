Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module Common

        ''' <summary>
        ''' This method provide to run a application
        ''' </summary>
        Sub Main()
            Try
                Dim command As New CommandStructure
                Dim engine As New CommandBuilder

                command = engine.run()

                If (Command.code.ToLower.CompareTo("force") = 0) Then
                    Dim console As New ConsoleEngine

                    'If Not (New IntegrityApplication).run() Then
                    '    Return
                    'End If

                    console.execute(Command)
                ElseIf Command.isPath Then
                    ShowFileLogEngine.execute(command.code)
                Else
                    Console.WriteLine("Command not recognized")
                End If
            Catch ex As Exception
                Console.WriteLine("Error during sub main")
            End Try
        End Sub

    End Module

End Namespace
