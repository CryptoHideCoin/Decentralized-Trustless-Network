Option Explicit On
Option Compare Text


Imports System.Net
Imports Newtonsoft.Json
Imports System.Text







Namespace CHCEngines.Communication


    Public Class ProxyWS(Of ClassType As {New})


        Public data As New ClassType



        Public url As String






        ''' <summary>
        ''' Questo metodo si occupa di effettuare il download dei dati 
        ''' </summary>
        ''' <returns></returns>
        Public Function getData() As Boolean

            Try

                Dim request As WebRequest = WebRequest.Create(url)
                Dim response As WebResponse = request.GetResponse()
                Dim dataStream As IO.Stream = response.GetResponseStream()
                Dim reader As New IO.StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()

                data = JsonConvert.DeserializeObject(Of ClassType)(responseFromServer)

                reader.Close()
                response.Close()

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function


        ''' <summary>
        ''' Questo metodo si occupa di inviare dei dati all' URL
        ''' </summary>
        ''' <returns></returns>
        Public Function sendData(Optional ByVal methodType As String = "PUT") As Boolean

            Dim webClient As New WebClient()
            Dim reqString() As Byte

            Try

                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented))

                Dim req As WebRequest = WebRequest.Create(url)

                req.ContentType = "application/json"
                req.Method = methodType
                req.ContentLength = reqString.Length

                Dim stream = req.GetRequestStream()
                stream.Write(reqString, 0, reqString.Length)
                stream.Close()

                Dim response = req.GetResponse().GetResponseStream()

                Dim reader As New IO.StreamReader(response)
                Dim res = reader.ReadToEnd()
                reader.Close()
                response.Close()

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function


    End Class


End Namespace