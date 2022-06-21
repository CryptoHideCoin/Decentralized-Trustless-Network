Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.PerformanceProfile






Namespace AreaCommon

    ''' <summary>
    ''' This class contain all element to show the file
    ''' </summary>
    Public Class ShowFilePerformanceEngine



        ''' <summary>
        ''' This method provide to execute the code
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function execute(ByVal completeFileName As String) As Boolean
            Try
                Dim service As New CHCCommonLibrary.AreaEngine.PerformanceProfile.Service.PerformanceProfileService
                Dim singleLine As String = ""
                Dim numElements As Integer = 0

                If service.init(completeFileName) Then
                    Console.WriteLine($"Update data:{CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(service.engine.data.lastPosition)}")
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine("Markers:")
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Gray

                    For Each item In service.engine.data.markers
                        If (item.durate <> 0) Then
                            Console.WriteLine($"   Name: {item.name} durate: {item.durate.ToString("N2")} ms.")
                        End If
                    Next

                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine("Methods:")
                    Console.WriteLine("")
                    Console.ForegroundColor = ConsoleColor.Gray

                    For Each item In service.engine.data.methods
                        numElements += 1

                        singleLine = ""

                        Console.WriteLine($"   Name: {item.name}")

                        If (item.refDuring = item.maxDuring) And (item.refDuring = item.minDuring) Then
                            Console.WriteLine($"         during: {item.refDuring.ToString("N2")} ms.")
                        Else
                            Console.WriteLine($"         during: {item.refDuring.ToString("N2")} ms. - (max = {item.maxDuring.ToString("N2")} ms.) - (min = {item.minDuring.ToString("N2")} ms.)")
                        End If
                        Console.WriteLine($"         count: {item.usedCount}")
                    Next

                    Console.WriteLine()
                    Console.WriteLine()
                    Console.WriteLine($"{numElements} item(s)")
                    Console.ReadKey()
                End If

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