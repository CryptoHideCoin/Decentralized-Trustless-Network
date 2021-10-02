Option Compare Text
Option Explicit On

' ****************************************
' Engine: File Manager Json
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************

Imports System.IO
Imports Newtonsoft.Json.JsonConvert




Namespace AreaEngine.DataFileManagement.Json

    ''' <summary>
    ''' This class manage a file Json relative an memory object file
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

                If (fileName.Length > 0) Then
                    If File.Exists(fileName) Then
                        streamReader = New StreamReader(fileName)
                        data = DeserializeObject(Of ClassType)(streamReader.ReadToEnd)
                        streamReader.Close()

                        Return True
                    End If
                End If
            Catch ex As Exception
            End Try

            data = New ClassType

            Return False
        End Function

        ''' <summary>
        ''' This method provide to save a content data property into a file
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function save() As Boolean
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

    ''' <summary>
    ''' This class manage a fast IO Base file
    ''' </summary>
    ''' <typeparam name="ClassType"></typeparam>
    Public Class IOFast(Of ClassType As {New})

        ''' <summary>
        ''' This method provide to read a data JSon from a file e return a structure
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
        ''' This method provide to save a data object in a Json file
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