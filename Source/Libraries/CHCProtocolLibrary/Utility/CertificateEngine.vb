Option Compare Text
Option Explicit On

' ****************************************
' File: Certificate Engine
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************







Namespace AreaBase

    ''' <summary>
    ''' This class contain the engine relative of a certificate
    ''' </summary>
    Public Class Certificate

        Private Const charList As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"


        ''' <summary>
        ''' This method provide to create a new certificate
        ''' </summary>
        ''' <returns></returns>
        <DebuggerHiddenAttribute()> Public Shared Function createNew() As String
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

