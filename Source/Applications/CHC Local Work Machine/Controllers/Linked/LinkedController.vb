Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Network.Response
Imports CHCModelsLibrary.AreaModel.Information
Imports CHCModelsLibrary.AreaModel.Service




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
            Dim found As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then

                    Do While AreaCommon.Main.notAddInScheduler
                        Application.DoEvents()
                    Loop

                    For Each singleItem In AreaCommon.Main.serviceToRegister
                        If (singleItem.service = parameter.service) And (singleItem.portNumber = parameter.portNumber) Then
                            found = True

                            Exit For
                        End If
                    Next

                    If Not found Then
                        AreaCommon.Main.serviceToRegister.Add(parameter)
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
