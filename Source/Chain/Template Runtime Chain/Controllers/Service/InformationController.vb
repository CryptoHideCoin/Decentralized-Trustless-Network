Imports System.Web.Http




Namespace Controllers


    ' GET: api/{GUID service}/service/informationController
    <Route("ServiceApi")>
    Public Class informationController

        Inherits ApiController




        Public Function GetValue() As AreaCommon.Models.ServiceModel.InformationResponseModel

            Dim result As New AreaCommon.Models.ServiceModel.InformationResponseModel

            Try

                result.adminPublicWalletAddress = AreaCommon.state.information.adminPublicWalletID
                result.currentStatus = AreaCommon.state.service
                result.chainName = AreaCommon.state.information.chainName
                result.platformHost = AreaCommon.state.information.platformHost
                result.softwareRelease = AreaCommon.state.information.softwareRelease
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
