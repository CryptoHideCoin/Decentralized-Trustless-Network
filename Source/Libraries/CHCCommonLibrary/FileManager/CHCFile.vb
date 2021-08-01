Option Compare Text
Option Explicit On


Imports System.IO






Namespace AreaEngine.FileManagement

    Public Module MD5

        Private Function printByteArray(ByVal array() As Byte)
            Dim hex_value As String = "", i As Integer

            For i = 0 To array.Length - 1
                hex_value += array(i).ToString("X2")
            Next i

            Return hex_value.ToLower
        End Function

        Public Function getMD5FromFile(ByVal completeFileName As String)
            Dim hash = System.Security.Cryptography.MD5.Create()
            Dim hashValue() As Byte
            Dim fileStream As FileStream = File.OpenRead(completeFileName)

            fileStream.Position = 0
            hashValue = hash.ComputeHash(fileStream)

            Dim hash_hex = printByteArray(hashValue)

            fileStream.Close()

            Return hash_hex
        End Function

    End Module

End Namespace



