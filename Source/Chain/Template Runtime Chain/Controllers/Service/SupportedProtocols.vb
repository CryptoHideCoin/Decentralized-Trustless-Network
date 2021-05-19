Imports System.Web.Http





Namespace Controllers


    ' GET: api/{GUID service}/service/supportedProtocolsController
    <Route("ServiceApi")>
    Public Class supportedProtocolsController

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.ServiceModel.SupportedProtocolsResponseModel

            Dim result As New AreaCommon.Models.ServiceModel.SupportedProtocolsResponseModel

            Try
                result.protocols.Add("BaseCommonServiceChain1")

                result.requestTime = Now
                result.responseTime = Now
            Catch ex As Exception
                result.error = True
                result.offline = True
                result.errorDescription = "503 - Generic Error"
            End Try

            Return result

        End Function


    End Class


End Namespace