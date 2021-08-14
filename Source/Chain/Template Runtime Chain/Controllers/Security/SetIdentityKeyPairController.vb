Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/{GUID service}/security/setIdentityKeyPairController
    <Route("ServiceApi")>
    Public Class SetIdentityKeyPairController

        Inherits ApiController




        Public Function PutValue(ByVal signature As String, <FromBody()> ByVal value As Models.Security.SetIdentityKeyPairModel) As General.RemoteResponse
            Dim result As New General.RemoteResponse

            result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Try
                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If AreaSecurity.checkSignature(signature) Then
                        If AreaSecurity.setIdentityKeyPair(value) Then
                            AreaCommon.log.trackIntoConsole("Set Identity KeyPair")

                            result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete
                        Else
                            result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                            result.errorDescription = "Service Error"
                        End If
                    Else
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function

    End Class

End Namespace
