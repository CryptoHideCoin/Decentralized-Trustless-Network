' ============================================================================
'    Author: Kenneth Perkins
'    Date:   Nov 18, 2020
'    Taken From: http://programmingnotes.org/
'    File: Utils.vb
'    Description: Handles general utility functions
' ============================================================================

Option Strict On
Option Explicit On

Imports System.Net
Imports Newtonsoft.Json
Imports System.Text




Namespace AreaEngine.Communication

    Public Class RestfulAPI(Of ClassType As {New}, ResponseType)

        Public data As New ClassType
        Public remoteResponse As ResponseType
        Public standardResponse As CHCModelsLibrary.AreaModel.Network.Response.GenericResponse
        Public options As CHCModelsLibrary.AreaModel.Network.Communication.Options
        Public url As String

        ''' <summary>
        ''' This method provide to get data from a remote url
        ''' </summary>
        ''' <returns></returns>
        Public Function getData() As String
            Try
                With Global.Utils.WebRequest.Get(url)
                    If .Result.StatusCode = HttpStatusCode.OK Then
                        data = JsonConvert.DeserializeObject(Of ClassType)(.Body)

                        Return ""
                    Else
                        Return .Result.StatusDescription
                    End If
                End With
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        ''' <summary>
        ''' This method provide to send data to remote
        ''' </summary>
        ''' <param name="methodType"></param>
        ''' <returns></returns>
        Public Function sendData(Optional ByVal methodType As CHCModelsLibrary.AreaModel.Network.Communication.Method = CHCModelsLibrary.AreaModel.Network.Communication.Method.Put) As String
            Try
                Dim reqString() As Byte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(data, Formatting.Indented))

                Select Case methodType
                    Case CHCModelsLibrary.AreaModel.Network.Communication.Method.Post
                        With Global.Utils.WebRequest.Post(url, reqString, options)
                            If (.Result.StatusCode = HttpStatusCode.OK) Then
                                remoteResponse = JsonConvert.DeserializeObject(Of ResponseType)(.Body)

                                Return ""
                            Else
                                Return .Result.StatusDescription
                            End If
                        End With
                    Case CHCModelsLibrary.AreaModel.Network.Communication.Method.Put
                        With Global.Utils.WebRequest.Put(url, reqString, options)
                            If (.Result.StatusCode = HttpStatusCode.OK) Then
                                remoteResponse = JsonConvert.DeserializeObject(Of ResponseType)(.Body)

                                Return ""
                            Else
                                Return .Result.StatusDescription
                            End If
                        End With
                    Case CHCModelsLibrary.AreaModel.Network.Communication.Method.Delete
                        With Global.Utils.WebRequest.Delete(url, options)
                            If (.Result.StatusCode = HttpStatusCode.OK) Then
                                remoteResponse = JsonConvert.DeserializeObject(Of ResponseType)(.Body)

                                Return ""
                            Else
                                Return .Result.StatusDescription
                            End If
                        End With
                    Case Else : Return "not manage"
                End Select
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

    End Class

End Namespace
