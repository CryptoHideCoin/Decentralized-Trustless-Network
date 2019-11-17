Option Compare Text
Option Explicit On

Imports System.IO
'Imports System.Xml.Serialization




Namespace CHCEngines.Common




    Public Class BaseFileJson(Of ClassType As {New})

        Public data As New ClassType

        Public fileName As String = ""



        Public Function read() As Boolean

            Try

                Dim streamReader As StreamReader

                If (fileName.Length > 0) Then

                    If File.Exists(fileName) Then

                        streamReader = New StreamReader(fileName)

                        data = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ClassType)(streamReader.ReadToEnd)

                        streamReader.Close()

                        Return True

                    End If

                End If

            Catch ex As Exception

            End Try

            Return False

        End Function


        Public Function save() As Boolean

            Try

                If (fileName.Length > 0) Then

                    If File.Exists(fileName) Then

                        File.Delete(fileName)

                    End If

                    File.WriteAllText(fileName, Newtonsoft.Json.JsonConvert.SerializeObject(data))

                    Return True

                End If

            Catch ex As Exception

            End Try

            Return False

        End Function



    End Class



End Namespace