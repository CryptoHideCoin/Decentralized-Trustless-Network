Option Compare Text
Option Explicit On

' ****************************************
' File: Notify Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************







Namespace AreaCommon.Models.Security

    ''' <summary>
    ''' This enumeration contain the component of transaction chain or client
    ''' </summary>
    Public Enum enumOfService
        administration
        loader
        runTime
        maintenance
        client
    End Enum

    ''' <summary>
    ''' This class contain all information relative to the change certificate
    ''' </summary>
    Public Class changeCertificate

        Public Property typeCommunication As enumOfService
        Public Property currentCertificate As String = ""
        Public Property newCertificate As String = ""
        Public Property signature As String = ""

    End Class

End Namespace