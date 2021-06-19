Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCBasicCryptographyLibrary.AreaEngine
Imports CHCProtocolLibrary.AreaWallet.Support
Imports CHCCommonLibrary.AreaCommon.Models




Namespace Controllers


    ' GET: api/{GUID service}/security/changeCertificateController
    <Route("ServiceApi")>
    Public Class changeCertificateController

        Inherits ApiController




        Public Function PutValue(<FromBody()> ByVal value As AreaCommon.Models.Security.changeCertificate) As General.RemoteResponse
            Dim result As New General.RemoteResponse

            result.requestTime = Now

            Try
                If (AreaCommon.state.service = AreaCommon.Models.ServiceModel.InformationResponseModel.EnumInternalServiceState.started) Then
                    If AreaSecurity.checkSignature(value.signature) Then
                        If AreaSecurity.changeCertificate(value) Then
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

            result.responseTime = Now

            Return result
        End Function


    End Class


End Namespace