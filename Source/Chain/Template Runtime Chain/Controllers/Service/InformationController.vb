Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/{GUID service}/service/informationController
    <Route("ServiceApi")>
    Public Class informationController

        Inherits ApiController




        Public Function GetValue(ByVal signature As String) As Models.Service.InformationResponseModel
            Dim result As New Models.Service.InformationResponseModel
            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If AreaSecurity.checkSignature(signature) Then
                        result.adminPublicAddress = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicAddress
                        result.currentStatus = AreaCommon.state.service
                        result.chainName = AreaCommon.state.information.chainName
                        result.platformHost = AreaCommon.state.information.platformHost
                        result.softwareRelease = AreaCommon.state.information.softwareRelease
                        If AreaCommon.settings.data.intranetMode Then
                            result.addressIP = AreaCommon.state.localIpAddress
                        Else
                            result.addressIP = AreaCommon.state.publicIpAddress
                        End If
                    Else
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result
        End Function


    End Class


End Namespace
