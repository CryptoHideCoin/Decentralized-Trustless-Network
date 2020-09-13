Option Compare Text
Option Explicit On







Namespace AreaBase


    Public Class Certificate

        Private Const charList As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"




        Public Shared Function createNew() As String

            Dim result As String = ""

            Try

                Dim rndChar As New Random(CInt(Date.Now.Ticks And &HFFFF))
                Dim index As Integer = 0

                For intC As Integer = 0 To 64

                    index = rndChar.Next(0, 62)
                    result += charList.Substring(index, 1)

                Next

            Catch ex As Exception
                Throw New Exception("CertificateEngine.createNew():" & ex.Message, ex)
            End Try

            Return result

        End Function


    End Class



End Namespace

