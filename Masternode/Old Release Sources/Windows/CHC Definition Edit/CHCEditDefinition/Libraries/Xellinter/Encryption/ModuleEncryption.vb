Option Compare Text
Option Explicit On



Namespace AreaInfrastructure.Support.Encryption


    Module AES

        Public Function Encrypt(ByVal Content As String, ByVal strKey As String) As String

            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim encrypted As String = ""

            Try

                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strKey))

                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)

                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB

                Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
                Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(Content)

                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

                Return encrypted

            Catch ex As Exception

                Return ""

            End Try

        End Function



        Public Function Decrypt(ByVal Content As String, ByVal strKey As String) As String

            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim decrypted As String = ""

            Try

                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strKey))

                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)

                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB

                Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
                Dim Buffer As Byte() = Convert.FromBase64String(Content)

                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

                Return decrypted

            Catch ex As Exception

                Return ""

            End Try

        End Function



    End Module

End Namespace