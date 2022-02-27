Option Explicit On
Option Compare Text

' ****************************************
' File: Approve Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************




Namespace AreaCommon.Models.Authorization

    Public Class ApproveModel

        Public Property exempionCode As String = ""
        Public Property exempionReferement As String = ""

        ''' <summary>
        ''' This method provide to convert into a string the element of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            result += exempionCode
            result += exempionReferement

            Return result
        End Function


    End Class

End Namespace
