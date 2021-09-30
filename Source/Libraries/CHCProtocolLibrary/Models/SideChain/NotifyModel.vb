Option Explicit On
Option Compare Text

Imports CHCCommonLibrary.AreaEngine.Encryption


Namespace AreaCommon.Models.Network

    ''' <summary>
    ''' This class contain all information reguard the notify of a request
    ''' </summary>
    Public Class NotifyModel

        Public Property netWorkHash As String = ""
        Public Property chainHash As String = ""
        Public Property requestCode As String = ""
        Public Property requestHash As String = ""
        Public Property publicAddress As String = ""
        Public Property signature As String = ""


        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += networkHash
            tmp += chainHash
            tmp += requestCode
            tmp += requestHash
            tmp += publicAddress

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function

    End Class

End Namespace