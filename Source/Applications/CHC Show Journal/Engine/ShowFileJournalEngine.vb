Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Registry






Namespace AreaCommon

    ''' <summary>
    ''' This class contain all element to show the file
    ''' </summary>
    Public Class ShowFileJournalEngine



        ''' <summary>
        ''' This method provide to execute the code
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function execute(ByVal completeFileName As String) As Boolean
            Try
                Dim engine As New CHCCommonLibrary.AreaEngine.Registry.RegistryEngine
                Dim dataDay As List(Of CHCModelsLibrary.AreaModel.Registry.RegistryData)
                Dim singleLine As String = ""
                Dim key As String = IO.Path.GetFileName(completeFileName).Replace(".registry", "")

                If engine.init(IO.Path.GetDirectoryName(completeFileName), True) Then
                    dataDay = engine.getData(key)

                    Console.WriteLine($"Service journal: {key}")
                    Console.WriteLine("")
                    Console.WriteLine("")

                    For Each item In dataDay
                        singleLine = ""

                        singleLine += CHCCommonLibrary.AreaEngine.Miscellaneous.formatDateTimeGMT(CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(item.istant))

                        singleLine = singleLine.PadRight(50 - singleLine.Length)

                        Select Case item.type
                            Case RegistryData.TypeEvent.adminTokenReleased
                                singleLine += "Admin token released"
                                Console.ForegroundColor = ConsoleColor.White
                            Case RegistryData.TypeEvent.applicationError
                                singleLine += "Service error"
                                Console.ForegroundColor = ConsoleColor.Red
                            Case RegistryData.TypeEvent.applicationShutdown
                                singleLine += "Service shutdown"
                                Console.ForegroundColor = ConsoleColor.Gray
                            Case RegistryData.TypeEvent.applicationStartUp
                                singleLine += "Service startup"
                                Console.ForegroundColor = ConsoleColor.Gray
                            Case RegistryData.TypeEvent.autoMaintenanceStartup
                                singleLine += "Startup automaintenance"
                                Console.ForegroundColor = ConsoleColor.White
                        End Select

                        If item.description.Length > 0 Then
                            singleLine += vbNewLine
                            singleLine += Space(50)
                            singleLine += item.description
                        End If

                        If (item.fileDetail.Length > 0) Then
                            singleLine += vbNewLine
                            singleLine += Space(50)
                            singleLine += item.fileDetail
                        End If

                        Console.WriteLine(singleLine)

                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.WriteLine(StrDup(80, "-"))
                    Next
                End If

                Console.WriteLine()
                Console.WriteLine($"({dataDay.Count}) item(s)")

                Console.ReadKey()

                Return True
            Catch ex As Exception
                Console.WriteLine($"Error during execute {ex.Message}")

                Return False
            Finally
                Console.ReadKey()
            End Try
        End Function

    End Class

End Namespace