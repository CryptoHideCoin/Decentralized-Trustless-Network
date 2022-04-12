Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Information
Imports CHCModelsLibrary.AreaModel.Network.Response





Namespace Controllers

    ' GET: api/{GUID service}/service/switchOffShowLogController
    <Route("ServiceApi")>
    Public Class SwitchOffShowLogController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to power off the show log panel
        ''' </summary>
        ''' <param name="parameter"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String) As BaseRemoteResponse
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim found As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    If (CHCSidechainServiceLibrary.AreaCommon.Main.environment.adminToken.check(securityToken).Length = 0) Then
                        AreaCommon.Main.showLogParameters.switchOff = True
                    Else
                        result.responseStatus = BaseRemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
