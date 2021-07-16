Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption



Namespace AreaCommon.Models.Document

    Public Class DocumentModel

        Public Property content As String = ""


        Public Overrides Function toString() As String
            Return content
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

End Namespace
