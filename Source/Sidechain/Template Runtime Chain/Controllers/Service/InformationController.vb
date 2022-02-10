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

                If (AreaCommon.state.serviceInformation.currentStatus = Models.Service.InternalServiceInformation.EnumInternalServiceState.started) Then
                    If AreaSecurity.checkSignature(signature) Then
                        result.value = AreaCommon.state.serviceInformation

                        'result.adminPublicAddress = AreaCommon.state.keys.key(TransactionChainLibrary.AreaEngine.KeyPair.KeysEngine.KeyPair.enumWalletType.administration).publicAddress
                        'result.currentStatus = AreaCommon.state.serviceInformation.currentStatus
                        'result.chainName = AreaCommon.state.serviceInformation.currentStatusInformation.chainName
                        'result.platformHost = AreaCommon.state.serviceInformation.currentStatusInformation.platformHost
                        'result.softwareRelease = AreaCommon.state.serviceInformation.currentStatusInformation.softwareRelease
                        'If AreaCommon.settings.data.intranetMode Then
                        '    result.addressIP = AreaCommon.state.localIpAddress
                        'Else
                        '    result.addressIP = AreaCommon.state.publicIpAddress
                        'End If
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
