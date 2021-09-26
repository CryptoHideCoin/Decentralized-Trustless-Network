Option Compare Text
Option Explicit On

Imports System.Web.Http

Imports CHCBasicCryptographyLibrary.AreaEngine.Encryption.Base58Signature
Imports CHCCommonLibrary.AreaCommon.Models.General
Imports CHCProtocolLibrary.AreaCommon



Namespace Controllers


    ' GET: api/{GUID service}/administration/currentService
    <Route("AdministrationApi")>
    Public Class serviceStateController

        Inherits ApiController




        Public Function GetValue(ByVal signature As String) As Models.Administration.ServiceStateResponse
            Dim result As New Models.Administration.ServiceStateResponse

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If Not AreaSecurity.checkSignature(signature) Then
                        result.responseStatus = RemoteResponse.EnumResponseStatus.missingAuthorization
                    Else
                        result.componentPosition = AreaCommon.state.currentService.componentPosition
                        result.currentAction = AreaCommon.state.currentService.currentAction
                        result.listAvailableCommand = AreaCommon.state.currentService.listAvailableCommand
                        result.servicePosition = AreaCommon.state.currentService.servicePosition
                        result.currentRunCommand = AreaCommon.state.currentService.currentRunCommand
                        result.requestCancelCurrentRunCommand = AreaCommon.state.currentService.requestCancelCurrentRunCommand
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