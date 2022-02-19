Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/{GUID service}/security/requestAccessKeyController
    <Route("SecurityApi")>
    Public Class RequestAccessKeyController

        Inherits ApiController



        ''' <summary>
        ''' This method provides to return an Admin Security Token 
        ''' </summary>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal signature As String) As Models.Security.RequestAccessKeyModel
            Dim result As New Models.Security.RequestAccessKeyModel
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.Main.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    If AreaSecurity.checkSignature(signature) Then
                        result.accessKey = AreaCommon.Main.environment.adminToken.createAccessKey()
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function

    End Class

End Namespace
