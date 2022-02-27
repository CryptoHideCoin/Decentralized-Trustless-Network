Option Compare Text
Option Explicit On

' ****************************************
' Engine: Security Model
' Release Engine: 1.0 
' 
' Date last successfully test: 21/02/2022
' ****************************************



Namespace AreaModel.Administration.Security

    ''' <summary>
    ''' This class contain all information of request admin token
    ''' </summary>
    Public Class ResponseRequestAdminSecurityTokenModel

        Inherits Network.Response.BaseRemoteResponse

        Public Property tokenValue As String = ""

    End Class

    ''' <summary>
    ''' This class contain all information of request access key
    ''' </summary>
    Public Class ResponseRequestAccessKeyModel

        Inherits Network.Response.BaseRemoteResponse

        Public Property accessKey As String = ""

    End Class

End Namespace
