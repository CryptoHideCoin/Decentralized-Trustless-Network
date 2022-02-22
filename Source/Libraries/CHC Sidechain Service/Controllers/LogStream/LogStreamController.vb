Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCModels.AreaModel.Network.Response
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/{GUID service}/service/logStreamController
    <RoutePrefix("ServiceApi")>
    Public Class LogStreamController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a log stream
        ''' </summary>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String, ByVal mode As String) As Models.Administration.LogStreamResponseModel
            Dim result As New Models.Administration.LogStreamResponseModel
            Dim response As String = ""
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)
                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.environment.log.getDataNewer(0, (mode.ToLower() = "console"))
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
