Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Registry
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/registryPage/
    <Route("AdministrationApi")>
    Public Class RegistryPageController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to get a log block informations
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="index"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String, ByVal index As String) As RegistryStreamResponseModel
            Dim ownerId As String = "RegistryPage-" & Guid.NewGuid.ToString
            Dim result As New RegistryStreamResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("RegistryPageController.GetValue", ownerId, $"token={securityToken}&index={index}", True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.environment.registry.getData(index)

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

                AreaCommon.Main.environment.log.trackException("RegistryPageController.GetValue", ownerId, ex.Message)
            End Try

            If enter Then
                AreaCommon.Main.environment.log.trackExit("RegistryPageController.GetValue", ownerId, $"token={securityToken}", True)
            End If

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
