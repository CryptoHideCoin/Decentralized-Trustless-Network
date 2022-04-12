Option Explicit On
Option Compare Text

' ****************************************
' Engine: ProxyWS
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************


Imports System.Net
Imports Newtonsoft.Json
Imports System.Text
Imports CHCModelsLibrary.AreaModel.Network.Response







Namespace AreaEngine.Communication

    ''' <summary>
    ''' This class manage a communication GET AND PUT with generic object into Webservice
    ''' </summary>
    ''' <typeparam name="ClassType"></typeparam>
    Public Class ProxyWS(Of ClassType As {New})

        Public data As New ClassType
        Public remoteResponse As RemoteResponse
        Public url As String


        ''' <summary>
        ''' This method provides to get a remote data
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()>
        Public Function getData() As String
            Try
                Dim request As WebRequest = WebRequest.Create(url)
                Dim response As WebResponse = request.GetResponse()
                Dim dataStream As IO.Stream = response.GetResponseStream()
                Dim reader As New IO.StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()

                data = JsonConvert.DeserializeObject(Of ClassType)(responseFromServer)

                reader.Close()
                response.Close()

                Return ""
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        ''' <summary>
        ''' This method provide to standardize a data to prepare to communicate
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function standardize() As Boolean
            Try
                data = JsonConvert.DeserializeObject(Of ClassType)(JsonConvert.SerializeObject(data, Formatting.Indented))

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' This method provides to send a remote data
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function sendData(Optional ByVal methodType As String = "PUT") As String
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

                Dim dataStream As IO.Stream = req.GetResponse().GetResponseStream()
                Dim reader As New IO.StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()

                remoteResponse = JsonConvert.DeserializeObject(Of RemoteResponse)(responseFromServer)

                reader.Close()
                dataStream.Close()

                Return ""
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

    End Class

    ''' <summary>
    ''' This class manage a communication GET AND PUT with simple type into Webservice
    ''' </summary>
    ''' <typeparam name="ClassType"></typeparam>
    Public Class ProxySimplyWS(Of ClassType)

        Public data As ClassType
        Public url As String


        ''' <summary>
        ''' This method's provides to get a remote data
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getData() As String
            Try
                Dim request As WebRequest = WebRequest.Create(url)
                Dim response As WebResponse = request.GetResponse()
                Dim dataStream As IO.Stream = response.GetResponseStream()
                Dim reader As New IO.StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()

                data = JsonConvert.DeserializeObject(Of ClassType)(responseFromServer)

                reader.Close()
                response.Close()

                Return ""
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        ''' <summary>
        ''' This method's provides to send a remote data
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function sendData(Optional ByVal methodType As String = "PUT") As String
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

                Return res
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

    End Class

End Namespace
