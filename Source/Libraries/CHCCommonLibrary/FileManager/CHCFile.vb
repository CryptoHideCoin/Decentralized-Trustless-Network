Option Compare Text
Option Explicit On

' ****************************************
' Engine: MD5 Manager
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************

Imports System.IO






Namespace AreaEngine.FileManagement

    Public Module MD5

        ''' <summary>
        ''' This method provide a convert an array of byte into string
        ''' </summary>
        ''' <param name="array"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Private Function printByteArray(ByVal array() As Byte) As String
            Dim hex_value As String = "", i As Integer
            Try
                For i = 0 To array.Length - 1
                    hex_value += array(i).ToString("X2")
                Next i
            Catch ex As Exception
            End Try

            Return hex_value.ToLower
        End Function

        ''' <summary>
        ''' This method provide to get a MD5 from a file
        ''' </summary>
        ''' <param name="completeFileName"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Function getMD5FromFile(ByVal completeFileName As String) As String
            Dim hash_hex As String = ""

            Try
                Dim hash = System.Security.Cryptography.MD5.Create()
                Dim hashValue() As Byte
                Dim fileStream As FileStream = File.OpenRead(completeFileName)

                fileStream.Position = 0
                hashValue = hash.ComputeHash(fileStream)

                hash_hex = printByteArray(hashValue)

                fileStream.Close()
            Catch ex As Exception
            End Try

            Return hash_hex
        End Function

    End Module

End Namespace



