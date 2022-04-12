Option Compare Text
Option Explicit On

Imports System.Web.Http
Imports CHCModelsLibrary.AreaModel.Log
Imports CHCModelsLibrary.AreaModel.Information
Imports CHCModelsLibrary.AreaModel.Network.Response





Namespace Controllers

    ' GET: api/{GUID service}/service/showLogParametersController
    <Route("ServiceApi")>
    Public Class ShowLogParametersController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to return the Log Panel Parameters information
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As LogPanelParametersResponseModel
            Dim result As New LogPanelParametersResponseModel
            Dim enter As Boolean = False
            Try
                enter = True

                result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
                With result.value
                    .frequencyRefresh = AreaCommon.Main.showLogParameters.frequencyRefresh
                    .pause = AreaCommon.Main.showLogParameters.pause
                    .showOnlyInfo = AreaCommon.Main.showLogParameters.showOnlyInfo
                    .switchOff = AreaCommon.Main.showLogParameters.switchOff
                End With

                AreaCommon.Main.showLogParameters.switchOff = False
            Catch ex As Exception
                result.responseStatus = LogPanelParametersResponseModel.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            Return result
        End Function

        ''' <summary>
        ''' This method provide to put the parameter from show log panel
        ''' </summary>
        ''' <param name="parameter"></param>
        ''' <returns></returns>
        Public Function PutValue(<FromBody()> ByVal parameter As LogPanelParameters) As BaseRemoteResponse
            Dim result As New BaseRemoteResponse
            Dim response As String = ""
            Dim found As Boolean = False
            Try
                If (CHCSidechainServiceLibrary.AreaCommon.Main.serviceInformation.currentStatus = InternalServiceInformation.EnumInternalServiceState.started) Then
                    AreaCommon.Main.showLogParameters = parameter
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
