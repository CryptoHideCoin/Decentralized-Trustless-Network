Option Compare Text
Option Explicit On

Imports System.IO
Imports System.Xml.Serialization




Namespace CHCEngines.Common




    Public Class BaseFileDB(Of ClassType As {New})

        Public data As New ClassType

        Public fileName As String = ""



        Public Function read() As Boolean

            Try

                Dim streamReader As StreamReader
                Dim serializer As New XmlSerializer(data.GetType)

                If (fileName.Length > 0) Then

                    If File.Exists(fileName) Then

                        streamReader = New StreamReader(fileName)

                        data = DirectCast(serializer.Deserialize(streamReader), ClassType)

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

                Dim pathFile As String
                Dim streamWriter As StreamWriter
                Dim serializer As New XmlSerializer(data.GetType)

                If (fileName.Length > 0) Then

                    If File.Exists(fileName) Then

                        File.Delete(fileName)

                    End If

                    pathFile = Path.GetDirectoryName(fileName)

                    If pathFile.Length > 0 Then

                        If Not Directory.Exists(pathFile) Then

                            Directory.CreateDirectory(Path.GetDirectoryName(pathFile))

                        End If

                    End If

                    streamWriter = New StreamWriter(fileName, False)

                    serializer.Serialize(streamWriter, data)

                    streamWriter.Close()

                    Return True

                End If

            Catch ex As Exception

            End Try

            Return False

        End Function



    End Class



End Namespace