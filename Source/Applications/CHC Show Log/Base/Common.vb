Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine





Namespace AreaCommon

    ''' <summary>
    ''' This static class run the application
    ''' </summary>
    Module Common

        Private Function showHelp() As Boolean
            Console.WriteLine("Help list command")
            Console.WriteLine("=================")
            Console.WriteLine()
            Console.WriteLine("-help                                Show this list")
            Console.WriteLine("-force                               Show a log of a service")
            Console.WriteLine("   --service:                        Set a service name")
            Console.WriteLine("   --dataPath:                       Set a data path")
            Console.WriteLine("   --password:                       Set a password to decode settings file")
            Console.WriteLine("   --mode:                           Set a mode of a detail")
            Console.WriteLine("   --securityKey:                    Set a password of a security key")
            Console.WriteLine("   --address:                        Set an address of a service")
            Console.WriteLine("<file log path>                      Show a file log paginated")

            Return True
        End Function

        ''' <summary>
        ''' This method provide to run a application
        ''' </summary>
        Sub Main()
            Try
                Dim command As New CommandStructure
                Dim engine As New CommandBuilder

                command = engine.run()

                If (command.code.ToLower.CompareTo("stream") = 0) Or
                   (command.code.ToLower.CompareTo("showBlock".ToLower) = 0) Then
                    Dim consoleClass As New ConsoleEngine

                    consoleClass.execute(command)
                ElseIf (command.code.ToLower.CompareTo("help") = 0) Then
                    showHelp()
                ElseIf command.isPath Then
                    ShowFileLogEngine.execute(command.code)
                Else
                    Console.WriteLine("Command not recognized")

                    Console.ReadKey()
                End If
            Catch ex As Exception
                Console.WriteLine("Error during sub main")

                Console.ReadKey()
            End Try
        End Sub

    End Module

End Namespace
