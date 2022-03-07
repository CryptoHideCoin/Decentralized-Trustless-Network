Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/setPowerOff
    <RoutePrefix("LWMAdministrationApi")>
    Public Class setPowerOffController

        Inherits ApiController



        ''' <summary>
        ''' This method provides to set a power off service
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function PutValue() As BaseRemoteResponse
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.shutDown
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
