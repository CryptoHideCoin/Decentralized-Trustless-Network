Option Compare Text
Option Explicit On

Imports CHCModelsLibrary.AreaModel.Network.Response

' ****************************************
' File: Notify Model
' Release Engine: 1.0 
' 
' Date last successfully test: 03/10/2021
' ****************************************







Namespace AreaCommon.Models.Security

    ''' <summary>
    ''' This class contain all information relative to the change certificate
    ''' </summary>
    Public Class changeCertificate

        Public Property currentCertificate As String = ""
        Public Property newCertificate As String = ""
        Public Property signature As String = ""

    End Class

    '''' <summary>
    '''' This class contain all information of request admin token
    '''' </summary>
    'Public Class RequestAdminSecurityTokenModel

    '    Inherits RemoteResponse

    '    Public Property tokenValue As String = ""

    'End Class

    '''' <summary>
    '''' This class contain all information of request access key
    '''' </summary>
    'Public Class RequestAccessKeyModel

    '    Inherits RemoteResponse

    '    Public Property accessKey As String = ""

    'End Class

End Namespace
