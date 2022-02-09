Option Compare Text
Option Explicit On

' ****************************************
' Engine: File Manager XML
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************

Imports System.IO
Imports System.Xml.Serialization




Namespace AreaEngine.DataFileManagement.XML

    ''' <summary>
    ''' This class manage a file XML relative an memory object file
    ''' </summary>
    ''' <typeparam name="ClassType"></typeparam>
    Public Class BaseFile(Of ClassType As {New})

        Public data As New ClassType
        Public fileName As String = ""

        ''' <summary>
        ''' This method provide to read a file and position content into data property
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function read() As Boolean
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

                data = New ClassType
            Catch ex As Exception
            End Try

            Return False
        End Function

        ''' <summary>
        ''' This method provide to save a content data property in to a file 
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function save() As Boolean
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

    ''' <summary>
    ''' This class manage a fast IO Base file
    ''' </summary>
    ''' <typeparam name="ClassType"></typeparam>
    Public Class IOFast(Of ClassType As {New})

        ''' <summary>
        ''' This method provide to read a data XML from a file e return a structure
        ''' </summary>
        ''' <param name="completeFileName"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function read(ByVal completeFileName As String) As ClassType
            Try
                Dim file As New BaseFile(Of ClassType)

                file.fileName = completeFileName

                If file.read() Then
                    Return file.data
                End If
            Catch ex As Exception
            End Try

            Return New ClassType
        End Function

        ''' <summary>
        ''' This method provide to save a data object in a XML file
        ''' </summary>
        ''' <param name="completeFileName"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function save(ByVal completeFileName As String, ByRef data As ClassType) As Boolean
            Try
                Dim file As New BaseFile(Of ClassType)

                file.fileName = completeFileName
                file.data = data

                If file.save() Then
                    Return True
                End If
            Catch ex As Exception
            End Try

            Return False
        End Function

    End Class

End Namespace