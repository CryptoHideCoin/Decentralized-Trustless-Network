Option Compare Text
Option Explicit On

Imports CHCCommonLibrary.AreaEngine.Encryption
Imports CHCCommonLibrary.AreaEngine.DataFileManagement.XML


Namespace AreaP2P

    Public Class RequestModel
        Public Property requestCode As String = "Evaluate"

        Public Property requestHash As String = ""
        Public Property dateDeterminateResult As Double = 0
        Public Property publicAddressValidator As String = ""
        Public Property approved As Boolean = False
        Public Property rejectedNote As String = ""
        Public Property signature As String = ""

        Public Overrides Function toString() As String
            Dim tmp As String = ""

            tmp += requestHash
            tmp += publicAddressValidator
            If approved Then
                tmp += "1"
            Else
                tmp += "0"
            End If
            tmp += rejectedNote

            Return tmp
        End Function

        Public Function getHash() As String
            Return HashSHA.generateSHA256(Me.toString())
        End Function
    End Class

    Public Class FileRequestModel
        Inherits BaseFile(Of RequestModel)
    End Class

End Namespace