Option Compare Text
Option Explicit On






''' <summary>
''' This static class run the application
''' </summary>
Module Common

    Const _OfficialLibrary As String = "Newtonsoft.Json.dll"
    Const _NewerLibrary As String = "Newtonsoft.New.Json.dll"
    Const _OlderLibrary As String = "Newtonsoft.Old.Json.dll"

    Private Property _SourceDirectory As String = ""
    Private Property _DestinationDirectory As String = ""


    ''' <summary>
    ''' This method provide to replace file library
    ''' </summary>
    ''' <returns></returns>
    Private Function copyFileLibrary(ByVal fileToUse As String) As Boolean
        Try
            Dim sourceFile As String = IO.Path.Combine(_SourceDirectory, fileToUse)
            Dim destFile As String = IO.Path.Combine(_DestinationDirectory, _OfficialLibrary)
            Dim proceed As Boolean = True

            If proceed Then
                proceed = IO.File.Exists(sourceFile)
            End If
            If proceed Then
                If IO.File.Exists(destFile) Then
                    IO.File.Delete(IO.Path.Combine(_DestinationDirectory, "temp.dll"))

                    IO.File.Move(destFile, IO.Path.Combine(_DestinationDirectory, "temp.dll"))
                End If
            End If
            If proceed Then
                IO.File.Copy(sourceFile, destFile)

                IO.File.Delete(IO.Path.Combine(_DestinationDirectory, "temp.dll"))
            End If

            Return True
        Catch ex As Exception
            Console.WriteLine($"Fatal: Problem during Main execute - {ex.Message}")

            Return False
        End Try
    End Function


    ''' <summary>
    ''' This method provide to run a application
    ''' </summary>
    Sub Main()
        Try
            Dim command As New AreaEngine.CommandLine.CommandStructure
            Dim engine As New AreaEngine.CommandLine.CommandBuilder
            Dim fileToUse As String = ""

            command = engine.run()

            If (command.code.ToLower.CompareTo("copy") = 0) Then
                If command.haveParameter("sourceDir") Then
                    _SourceDirectory = command.parameterValue("sourceDir")
                Else
                    _SourceDirectory = My.Application.Info.DirectoryPath
                End If

                If command.haveParameter("destDir") Then
                    _DestinationDirectory = command.parameterValue("destDir")
                Else
                    _DestinationDirectory = My.Application.Info.DirectoryPath
                End If

                If command.haveParameter("repair") Then
                    Select Case command.parameterValue("repair").ToLower
                        Case "useNewer".ToLower() : fileToUse = _NewerLibrary
                        Case "useOlder".ToLower() : fileToUse = _OlderLibrary
                    End Select
                End If

                If copyFileLibrary(fileToUse) Then
                    Console.WriteLine("Program recovery  complete")

                    Console.ReadKey()
                End If
            End If
        Catch ex As Exception
            Console.WriteLine($"Fatal: Problem during Main execute - {ex.Message}")
        End Try
    End Sub

End Module