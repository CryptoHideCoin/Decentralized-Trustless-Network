Option Explicit On
Option Compare Text

' ****************************************
' Engine: Generic support element
' Release Engine: 1.0 
' 
' Date last successfully test: 02/10/2021
' ****************************************







Namespace AreaCommon.Models

    ''' <summary>
    ''' This interface contain the property of a Standard Interface
    ''' </summary>
    Public Interface StandardInterface

        Function start() As Boolean
        Function [stop]() As Boolean
        Function maintenance() As Boolean

    End Interface

End Namespace
