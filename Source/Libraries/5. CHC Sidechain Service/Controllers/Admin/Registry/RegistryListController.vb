Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Registry
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/registryList/
    <Route("AdministrationApi")>
    Public Class RegistryListController

        Inherits ApiController




        ''' <summary>
        ''' This method provide to get a log stream
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal securityToken As String) As RegistryListResponseModel
            Dim ownerId As String = "RegistryList-" & Guid.NewGuid.ToString
            Dim result As New RegistryListResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("RegistryListController.GetValue", ownerId, $"token={securityToken}", True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.environment.registry.getHistoryList()
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

                AreaCommon.Main.environment.log.trackException("RegistryListController.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("RegistryListController.GetValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
