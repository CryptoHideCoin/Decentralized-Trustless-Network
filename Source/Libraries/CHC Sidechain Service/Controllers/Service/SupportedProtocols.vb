Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon





Namespace Controllers

    ' GET: api/{GUID service}/service/supportedProtocolsController
    <Route("ServiceApi")>
    Public Class supportedProtocolsController

        Inherits ApiController



        ''' <summary>
        ''' This method provide to return the protocols list supported of this service
        ''' </summary>
        ''' <returns></returns>
        Public Function GetValue() As Models.Service.SupportedProtocolsResponseModel
            Dim result As New Models.Service.SupportedProtocolsResponseModel

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                result.protocols.Add("SuperminimalAdmin")

                result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            Return result
        End Function

    End Class

End Namespace
