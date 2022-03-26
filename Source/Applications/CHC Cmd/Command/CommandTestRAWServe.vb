Option Compare Text
Option Explicit On

Imports CHCCmd.AreaCommon.Models
Imports CHCCommonLibrary.AreaEngine.CommandLine
Imports System








Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Test Serve Response
    ''' </summary>
    Public Class CommandTestRAWServe : Implements CommandModel

        Private Property _Command As CommandStructure
        Private Property _Address As String = ""






        Private Property CommandModel_command As CommandStructure Implements CommandModel.command
            Get
                Return _Command
            End Get
            Set(value As CommandStructure)
                _Command = value
            End Set
        End Property

        ''' <summary>
        ''' This method provide to process asynch request
        ''' </summary>
        ''' <returns></returns>
        Private Async Function ProcessRequests() As Task
            Dim startProcedure As Double = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime(), endProcedure As Double, durate As Double
            Dim url = $"{_Address}/api/service/test/"

            Dim options = New Utils.WebRequest.Options With {
                .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:82.0) Gecko/20100101 Firefox/82.0",
                .Headers = New Net.WebHeaderCollection From {
                    {"key", "value"}
                }
            }

            Dim response = Await Utils.WebRequest.GetAsync(url)

            endProcedure = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            durate = CDec(endProcedure) - startProcedure

            Console.WriteLine($"Status: {CInt(response.Result.StatusCode)} - {response.Result.StatusDescription}")
            Console.WriteLine($"Bytes Received: {response.Bytes.Length}")
            Console.WriteLine($"Body: {response.Body}")
            Console.WriteLine("")
            Console.WriteLine($"Begin at:{CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(startProcedure)}")
            Console.WriteLine($"End at:{CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(endProcedure)}")
            Console.WriteLine($"Complete in:{durate} msec.")
            Console.WriteLine("")
        End Function

        Private Function CommandModel_run() As Boolean Implements CommandModel.run
            Try
                If _Command.haveParameter("address") Then
                    _Address = _Command.parameterValue("address")
                Else
                    Console.WriteLine("Address parameter missing!")

                    Return False
                End If

                ProcessRequests().Wait()
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
            End Try

            Return True
        End Function

    End Class

End Namespace
