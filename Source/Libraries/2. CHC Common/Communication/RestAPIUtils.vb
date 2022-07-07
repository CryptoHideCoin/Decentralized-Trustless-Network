' ============================================================================
'    Author: Kenneth Perkins
'    Date:   Nov 18, 2020
'    Taken From: http://programmingnotes.org/
'    File: Utils.vb
'    Description: Handles general utility functions
' ============================================================================
Option Strict On
Option Explicit On





Namespace Global.Utils

    Namespace WebRequest

        Public Module modRequest

            ''' <summary>
            ''' Executes a GET request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function [Get](url As String _
                                  , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return GetAsync(url, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a GET request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function GetAsync(url As String _
                                  , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return ExecuteAsync(CHCModelsLibrary.AreaModel.Network.Communication.Method.Get, url, payload:=CType(Nothing, Byte()), options:=options)
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Post(url As String, payload As String _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return Post(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Post(url As String, payload As Byte() _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return PostAsync(url, payload:=payload, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PostAsync(url As String, payload As String _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return PostAsync(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a POST request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to post to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PostAsync(url As String, payload As Byte() _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return ExecuteAsync(CHCModelsLibrary.AreaModel.Network.Communication.Method.Post, url, payload:=payload, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Put(url As String, payload As String _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return Put(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Put(url As String, payload As Byte() _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return PutAsync(url, payload:=payload, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PutAsync(url As String, payload As String _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return PutAsync(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PUT request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to put to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PutAsync(url As String, payload As Byte() _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return ExecuteAsync(CHCModelsLibrary.AreaModel.Network.Communication.Method.Put, url, payload:=payload, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Patch(url As String, payload As String _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return Patch(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Patch(url As String, payload As Byte() _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return PatchAsync(url, payload:=payload, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PatchAsync(url As String, payload As String _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return PatchAsync(url, payload:=payload.GetBytes, options:=options)
            End Function

            ''' <summary>
            ''' Executes a PATCH request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to patch to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function PatchAsync(url As String, payload As Byte() _
                                , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return ExecuteAsync(CHCModelsLibrary.AreaModel.Network.Communication.Method.Patch, url, payload:=payload, options:=options)
            End Function

            ''' <summary>
            ''' Executes a DELETE request on the given url
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function Delete(url As String _
                                  , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
                Return DeleteAsync(url, options:=options).Result
            End Function

            ''' <summary>
            ''' Executes a DELETE request on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function DeleteAsync(url As String _
                                  , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return ExecuteAsync(CHCModelsLibrary.AreaModel.Network.Communication.Method.Delete, url, payload:=CType(Nothing, Byte()), options:=options)
            End Function

            ''' <summary>
            ''' Executes a request method on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="type">The type of request method to execute</param>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to send to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Function ExecuteAsync(type As CHCModelsLibrary.AreaModel.Network.Communication.Method _
                                    , url As String _
                                    , Optional payload As String = Nothing _
                                    , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Return ExecuteAsync(type, url, payload:=CType(payload?.GetBytes, Byte()), options:=options)
            End Function

            ''' <summary>
            ''' Executes a request method on the given url as an asynchronous operation
            ''' </summary>
            ''' <param name="type">The type of request method to execute</param>
            ''' <param name="url">The url to navigate to</param>
            ''' <param name="payload">The data to send to the specified resource</param>
            ''' <param name="options">The options for the web request</param>
            ''' <returns>The result of the given request</returns>
            Public Async Function ExecuteAsync(type As CHCModelsLibrary.AreaModel.Network.Communication.Method _
                                    , url As String _
                                    , Optional payload As Byte() = Nothing _
                                    , Optional options As CHCModelsLibrary.AreaModel.Network.Communication.Options = Nothing) As Task(Of CHCModelsLibrary.AreaModel.Network.Response.GenericResponse)
                Dim request = CType(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
                If options IsNot Nothing Then
                    request.CopyProperties(options)
                End If
                request.Method = type.ToString.ToUpper

                If payload IsNot Nothing Then
                    request.ContentLength = payload.Length
                    Using requestStream = request.GetRequestStream
                        Using payloadStream = New System.IO.MemoryStream(payload)
                            payloadStream.CopyTo(requestStream)
                        End Using
                    End Using
                End If

                Dim webResponse As System.Net.HttpWebResponse = Nothing
                Try
                    webResponse = CType(Await request.GetResponseAsync(), System.Net.HttpWebResponse)
                Catch ex As System.Net.WebException
                    If ex.Response Is Nothing Then
                        Throw
                    End If
                    webResponse = CType(ex.Response, System.Net.HttpWebResponse)
                Catch ex As Exception
                    Throw
                End Try

                Dim result = New CHCModelsLibrary.AreaModel.Network.Response.GenericResponse With {
                    .Result = webResponse,
                    .Bytes = GetBytes(webResponse)
                }

                Return result
            End Function

            Private Function GetBytes(response As System.Net.HttpWebResponse) As Byte()
                Dim bytes As Byte()
                Dim responseStream = response.GetResponseStream()
                Using memoryStream = New System.IO.MemoryStream
                    responseStream.CopyTo(memoryStream)
                    bytes = memoryStream.ToArray
                End Using
                Return bytes
            End Function

            <Runtime.CompilerServices.Extension()>
            Public Function GetBytes(str As String, Optional encode As System.Text.Encoding = Nothing) As Byte()
                If encode Is Nothing Then
                    encode = GetDefaultEncoding()
                End If
                Return encode.GetBytes(str)
            End Function

            <Runtime.CompilerServices.Extension()>
            Public Function GetString(bytes As Byte(), Optional encode As System.Text.Encoding = Nothing) As String
                If encode Is Nothing Then
                    encode = GetDefaultEncoding()
                End If
                Return encode.GetString(bytes)
            End Function

            Private Function GetDefaultEncoding() As System.Text.Encoding
                Static encode As New System.Text.UTF8Encoding
                Return encode
            End Function

            <Runtime.CompilerServices.Extension()>
            Private Sub CopyProperties(Of T1, T2)(dest As T1, src As T2)
                Dim srcProps = src.GetType().GetProperties()
                Dim destProps = dest.GetType().GetProperties()
                For Each srcProp In srcProps
                    If srcProp.CanRead Then
                        Dim destProp = destProps.FirstOrDefault(Function(x) x.Name = srcProp.Name)
                        If destProp IsNot Nothing AndAlso destProp.CanWrite Then
                            Dim value = srcProp.GetValue(src, If(srcProp.GetIndexParameters.Count = 1, New Object() {Nothing}, Nothing))
                            destProp.SetValue(dest, value)
                        End If
                    End If
                Next
            End Sub
        End Module

    End Namespace

End Namespace ' http://programmingnotes.org/
