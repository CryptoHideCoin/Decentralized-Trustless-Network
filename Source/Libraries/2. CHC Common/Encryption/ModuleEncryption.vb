Option Compare Text
Option Explicit On

' ****************************************
' Engine: AES Encryption
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************





Namespace AreaEngine.Encryption

    ''' <summary>
    ''' This static class manage encryption/decryption string 
    ''' </summary>
    Public Class AES

        ''' <summary>
        ''' This method provide to encrypt a string with a simmetric encryption (AES)
        ''' </summary>
        ''' <param name="content"></param>
        ''' <param name="key"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function encrypt(ByVal content As String, ByVal key As String) As String
            Dim aes As New System.Security.Cryptography.RijndaelManaged
            Dim hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim encrypted As String = ""

            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = hash_AES.ComputeHash(Text.Encoding.ASCII.GetBytes(key))

                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)

                aes.Key = hash
                aes.Mode = System.Security.Cryptography.CipherMode.ECB

                Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = aes.CreateEncryptor
                Dim Buffer As Byte() = Text.Encoding.ASCII.GetBytes(content)

                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Catch ex As Exception
            End Try

            Return encrypted
        End Function

        ''' <summary>
        ''' This method provide to crypt a string with a simmetric crypt (AES)
        ''' </summary>
        ''' <param name="content"></param>
        ''' <param name="key"></param>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function decrypt(ByVal content As String, ByVal key As String) As String
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim decrypted As String = ""

            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(Text.Encoding.ASCII.GetBytes(key))

                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)

                AES.Key = hash
                AES.Mode = System.Security.Cryptography.CipherMode.ECB

                Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
                Dim Buffer As Byte() = Convert.FromBase64String(content)

                decrypted = Text.Encoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Catch ex As Exception
            End Try

            Return decrypted
        End Function

    End Class

End Namespace
