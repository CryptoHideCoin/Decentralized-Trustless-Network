Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Information
Imports CHCModels.AreaModel.Service




Namespace Controllers


    ' GET: api/{GUID service}/linked/addNewService
    <RoutePrefix("LWMLinkedApi")>
    Public Class addNewServiceController

        Inherits ApiController



        ''' <summary>
        ''' This method provides to notify a new service
        ''' </summary>
        ''' <param name="internalName"></param>
        ''' <param name="portNumber"></param>
        ''' <returns></returns>
        Public Function PutValue(<FromBody()> ByVal parameter As MinimalDataToRegister) As BaseRemoteResponse
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then

                    Do While AreaCommon.Main.notAddInScheduler
                        Application.DoEvents()
                    Loop

                    AreaCommon.Main.serviceToRegister.Add(parameter)
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
