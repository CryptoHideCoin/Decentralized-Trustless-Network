Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




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
        Public Function GetValue(ByVal securityToken As String) As InformationResponseModel
            Dim ownerId As String = "information-" & Guid.NewGuid.ToString
            Dim result As New InformationResponseModel
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("information.GetValue", ownerId,, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        result.value = AreaCommon.Main.serviceInformation

                        AreaCommon.Main.updateLastGetServiceInformation = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
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

                AreaCommon.Main.environment.log.trackException("information.GetValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("information.GetValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function


    End Class


End Namespace
