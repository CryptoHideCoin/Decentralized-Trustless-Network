Option Compare Text
Option Explicit On

Imports System.Threading
Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/setPowerOff
    <Route("AdministrationApi")>
    Public Class setPowerOffController

        Inherits ApiController


        ''' <summary>
        ''' This method provide to call in asynch the delete procedure shutdown
        ''' </summary>
        ''' <returns></returns>
        Private Function callShutDown() As Boolean
            Try
                Dim asynchThread As Thread

                asynchThread = New Thread(AddressOf AreaAsynchronous.executeShutDown)

                asynchThread.Start()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        ''' <summary>
        ''' This method provides to set a power off this service
        ''' </summary>
        ''' <param name="securityToken"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Public Function PutValue(ByVal securityToken As String) As BaseRemoteResponse
            Dim ownerId As String = "SetPowerOff-" & Guid.NewGuid.ToString
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("setPowerOff.PutValue", ownerId,, True)

                    enter = True
                    response = AreaCommon.Main.environment.adminToken.check(securityToken)

                    If (response.Length = 0) Then
                        AreaCommon.Main.securityTokenSwitchOnService = securityToken
                        AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.shutDown

                        callShutDown()
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

                AreaCommon.Main.environment.log.trackException("setPowerOff.PutValue", ownerId, ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("setPowerOff.PutValue", ownerId,, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
