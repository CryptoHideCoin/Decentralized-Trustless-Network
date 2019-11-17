Option Compare Text
Option Explicit On

' Release 1.1 - Add NoCrypt Mode



Imports System.IO
Imports System.Xml.Serialization





Namespace AreaInfrastructure.Secure



    Public Module ModuleMain

        Public SecureBaseKey As String

    End Module



    Public Class BaseEncryption(Of ClassType As {New})


        Public Data As New ClassType

        Public FileName As String = ""


        Public Property CryptoKEY() As String
            Get
                Return m_str_OriginalCryptoKEY
            End Get
            Set(value As String)

                m_str_OriginalCryptoKEY = value
                m_str_CombineCryptoKEY = SecureBaseKey & "-" & value

            End Set
        End Property

        Public Property NoCrypt As Boolean = False


        Private m_str_OriginalCryptoKEY As String
        Private m_str_CombineCryptoKEY As String

        Public Sub New()

            m_str_CombineCryptoKEY = SecureBaseKey & "-"

        End Sub

        Private Function fnMoveFileIntoTemp(ByVal strCryptFile As String) As String

            Dim strDestination As String = ""

            Try

                If NoCrypt Then Return strCryptFile

                If File.Exists(strCryptFile) Then

                    Dim strFile As String

                    strDestination = Path.GetTempFileName()

                    strFile = IO.File.ReadAllText(strCryptFile)

                    File.WriteAllText(strDestination, AreaInfrastructure.Support.Encryption.AES.Decrypt(strFile, m_str_CombineCryptoKEY))

                End If

                Return strDestination

            Catch ex As Exception

                Return ""

            End Try

        End Function




        Public Function Read() As Boolean

            Dim objStreamReader As StreamReader
            Dim objSerializer As New XmlSerializer(Data.GetType)
            Dim blnDeleteFile As Boolean = False
            Dim strFileTemp As String

            Try

                strFileTemp = fnMoveFileIntoTemp(FileName)

                If (strFileTemp.Length > 0) Then

                    If File.Exists(strFileTemp) Then

                        blnDeleteFile = True

                        objStreamReader = New StreamReader(strFileTemp)

                        Data = DirectCast(objSerializer.Deserialize(objStreamReader), ClassType)

                        objStreamReader.Close()

                        If Not NoCrypt Then

                            File.Delete(strFileTemp)

                        End If

                        Return True

                    Else

                        Return False

                    End If

                Else

                    Return False

                End If

            Catch ex As Exception

                Try

                    If blnDeleteFile And Not NoCrypt Then

                        File.Delete(strFileTemp)

                    End If

                Catch

                End Try

                Return False

            End Try

        End Function


        Public Function Save() As Boolean

            Dim strPath As String = "", strTemp As String
            Dim objStreamWriter As StreamWriter
            Dim clsEngine As New XmlSerializer(Data.GetType)

            Try

                If NoCrypt Then

                    strTemp = FileName

                Else

                    strTemp = Path.GetTempFileName()

                End If

                objStreamWriter = New StreamWriter(strTemp, False)

                clsEngine.Serialize(objStreamWriter, Data)

                objStreamWriter.Close()

                If Not NoCrypt Then

                    IO.File.WriteAllText(FileName, AreaInfrastructure.Support.Encryption.AES.Encrypt(File.ReadAllText(strTemp), m_str_CombineCryptoKEY))
                    File.Delete(strTemp)

                End If

                Return True

            Catch ex As Exception

                Try

                    If strTemp.Length > 0 Then

                        File.Delete(strTemp)

                    End If

                Catch

                End Try

                Return False

            End Try

        End Function


    End Class


End Namespace
