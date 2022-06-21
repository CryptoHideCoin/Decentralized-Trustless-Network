Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.CommandLine








Namespace AreaCommon.Command

    ''' <summary>
    ''' This class manage the command Test Serve Response
    ''' </summary>
    Public Class CommandTestRAWServe : Implements Models.CommandModel

        Private Property _Command As CommandStructure
        Private Property _Address As String = ""

        Public Event WriteLine(ByVal message As String) Implements Models.CommandModel.WriteLine
        Public Event Process(ByVal applicationName As String, ByVal commandLine As String) Implements Models.CommandModel.Process
        Public Event IntegrityApplication(ByVal fileName As String) Implements Models.CommandModel.IntegrityApplication
        Public Event RaiseError(ByVal message As String) Implements Models.CommandModel.RaiseError
        Public Event ReadKey() Implements Models.CommandModel.ReadKey




        Private Property CommandModel_command As CommandStructure Implements Models.CommandModel.command
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

            RaiseEvent WriteLine($"Status: {CInt(response.Result.StatusCode)} - {response.Result.StatusDescription}")
            RaiseEvent WriteLine($"Bytes Received: {response.Bytes.Length}")
            RaiseEvent WriteLine($"Body: {response.Body}")
            RaiseEvent WriteLine("")
            RaiseEvent WriteLine($"Begin at:{CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(startProcedure)}")
            RaiseEvent WriteLine($"End at:{CHCCommonLibrary.AreaEngine.Miscellaneous.dateTimeFromTimeStamp(endProcedure)}")
            RaiseEvent WriteLine($"Complete in:{durate} msec.")
            RaiseEvent WriteLine("")
        End Function

        Private Function CommandModel_run() As Boolean Implements Models.CommandModel.run
            Try
                If _Command.haveParameter("address") Then
                    _Address = _Command.parameterValue("address")
                Else
                    RaiseEvent WriteLine("Address parameter missing!")

                    Return False
                End If

                ProcessRequests().Wait()
            Catch ex As Exception
                RaiseEvent WriteLine(ex.ToString)
            End Try

            Return True
        End Function

    End Class

End Namespace
