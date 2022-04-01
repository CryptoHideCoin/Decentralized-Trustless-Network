Option Compare Text
Option Explicit On

' ****************************************
' Engine: Log Model
' Release Engine: 1.0 
' 
' Date last successfully test: 21/02/2022
' ****************************************




Namespace AreaModel.Service

    ''' <summary>
    ''' This class contain the minimal data to register a new service (Local Work Machine)
    ''' </summary>
    Public Class MinimalDataToRegister
        Public Property service As String = ""
        Public Property portNumber As Integer = 0
    End Class

End Namespace
