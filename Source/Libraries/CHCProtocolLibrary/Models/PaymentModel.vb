Option Explicit On
Option Compare Text

' ****************************************
' File: Payment Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************




Namespace AreaCommon.Models.Payments

    Public Class FeeModel

        Public Property value As Double = 0
        Public Property recipient As String = ""
        Public Property exempionCode As String = ""
        Public Property exempionReferement As String = ""

        ''' <summary>
        ''' This method provide to convert into a string the element of the object
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function toString() As String
            Dim result As String = ""

            result += value.ToString()
            result += recipient
            result += exempionCode
            result += exempionReferement

            Return result
        End Function


    End Class

End Namespace
