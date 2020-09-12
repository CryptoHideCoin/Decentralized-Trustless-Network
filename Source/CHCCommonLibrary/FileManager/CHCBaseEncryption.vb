Option Compare Text
Option Explicit On


Imports System.IO
Imports System.Xml.Serialization





Namespace CHCEngines.Common


    Public Module ModuleMain

        Public secureBaseKey As String

    End Module



    Public Class BaseEncryption(Of ClassType As {New})


        Private _originalCryptoKEY As String
        Private _combineCryptoKEY As String


        Public data As New ClassType

        Public Property fileName As String = ""

        Public Property noCrypt As Boolean = False

        Public Property cryptoKEY() As String
            Get
                Return _originalCryptoKEY
            End Get
            Set(value As String)

                _originalCryptoKEY = value
                _combineCryptoKEY = SecureBaseKey & "-" & value

            End Set
        End Property



        Public Sub New()

            _combineCryptoKEY = secureBaseKey & "-"

        End Sub



        Public Function read() As Boolean

            Dim serializer As New XmlSerializer(data.GetType)
            Dim stream As StreamReader
            Dim memory As MemoryStream

            Try

                If File.Exists(fileName) Then

                    stream = New StreamReader(fileName)

                    If _combineCryptoKEY = "-" Then

                        memory = New MemoryStream(Text.Encoding.ASCII.GetBytes(stream.ReadToEnd()))

                    Else

                        memory = New MemoryStream(Text.Encoding.ASCII.GetBytes(Encryption.AES.decrypt(stream.ReadToEnd(), _combineCryptoKEY)))

                    End If

                    stream.Close()

                    stream = New StreamReader(memory)

                    data = DirectCast(serializer.Deserialize(stream), ClassType)

                    stream.Close()

                    stream = Nothing

                    Return True

                Else

                    data = New ClassType

                    Return False

                End If

            Catch ex As Exception

                Return False

            End Try

        End Function


        Public Function save() As Boolean

            Dim temp As String
            Dim streamWriter As StreamWriter
            Dim engine As New XmlSerializer(data.GetType)

            Try

                If noCrypt Then

                    temp = fileName

                Else

                    temp = IO.Path.GetTempFileName()

                End If

                streamWriter = New StreamWriter(temp, False)

                engine.Serialize(streamWriter, data)

                streamWriter.Close()

                If Not noCrypt Then

                    If (_combineCryptoKEY = "-") Then

                        File.Delete(fileName)

                        IO.File.Move(temp, fileName)

                    Else

                        IO.File.WriteAllText(fileName, CHCEngines.Common.Encryption.AES.encrypt(File.ReadAllText(temp), _combineCryptoKEY))

                        File.Delete(temp)

                    End If

                End If

                Return True

            Catch ex As Exception

                Try

#Disable Warning BC42104 ' La variabile è stata usata prima dell'assegnazione di un valore
                    If temp.Length > 0 Then
#Enable Warning BC42104 ' La variabile è stata usata prima dell'assegnazione di un valore

                        File.Delete(temp)

                    End If

                Catch

                End Try

                Return False

            End Try

        End Function


    End Class


End Namespace
