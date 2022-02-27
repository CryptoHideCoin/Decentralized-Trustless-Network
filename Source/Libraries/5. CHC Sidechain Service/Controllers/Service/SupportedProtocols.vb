Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCModels.AreaModel.Network.Response
Imports CHCModels.AreaModel.Information





Namespace Controllers

    ' GET: api/{GUID service}/service/supportedProtocolsController
    <RoutePrefix("ServiceApi")>
    Public Class supportedProtocolsController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to return the protocols list supported of this service
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As SupportedProtocolsResponseModel
            Dim result As New SupportedProtocolsResponseModel
            Dim enter As Boolean = False
            Try
                AreaCommon.Main.environment.log.trackEnter("supportedProtocols.GetValue",, True)

                enter = True

                result.protocols.Add("SuperminimalAdmin")

                result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.timeStampFromDateTime()
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"

                AreaCommon.Main.environment.log.trackException("supportedProtocols.GetValue", ex.Message)
            Finally
                If enter Then
                    AreaCommon.Main.environment.log.trackExit("supportedProtocols.GetValue",, True)
                End If
            End Try

            Return result
        End Function

    End Class

End Namespace
