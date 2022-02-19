Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/{GUID service}/service/informationController
    <Route("ServiceApi")>
    Public Class informationController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get an information response model
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String) As Models.Service.InformationResponseModel
            Dim result As New Models.Service.InformationResponseModel
            Dim response As String = ""
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.Main.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)
                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.serviceInformation
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                        result.errorDescription = response
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
