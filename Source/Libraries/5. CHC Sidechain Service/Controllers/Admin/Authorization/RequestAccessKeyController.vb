Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCModelsLibrary.AreaModel.Administration.Security
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information




Namespace Controllers


    ' GET: api/{GUID service}/administration/security/requestAccessKey/
    <Route("SecurityApi")>
    Public Class RequestAccessKeyController

        Inherits ApiController



        ''' <summary>
        ''' This method provides to return an Admin Security Token 
        ''' </summary>
        ''' <param name="signature"></param>
        ''' <returns></returns>
        Public Function GetValue(ByVal signature As String) As ResponseRequestAccessKeyModel
            Dim result As New ResponseRequestAccessKeyModel
            Dim enter As Boolean = False
            Try
                If (AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.environment.log.trackEnter("RequestAccessKey.GetValue",, True)

                    enter = True

                    If AreaSecurity.checkSignature(signature) Then
                        result.accessKey = AreaCommon.Main.environment.adminToken.createAccessKey()

                        AreaCommon.Main.environment.log.trackIntoConsole("Access Key generated")
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.Main.environment.log.trackException("RequestAccessKey.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("RequestAccessKey.GetValue",, True)
                End If
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()

            Return result
        End Function

    End Class

End Namespace
