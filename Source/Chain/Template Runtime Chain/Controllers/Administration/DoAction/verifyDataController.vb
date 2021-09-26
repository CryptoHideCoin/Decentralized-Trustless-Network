Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models




Namespace Controllers


    ' GET: api/{GUID service}/administration/doAction/verifyData
    <Route("AdministrationDoActionApi")>
    Public Class VerifyDataController

        Inherits ApiController





        Public Function GetValue(ByVal signature As String) As General.RemoteResponse
            Dim result As New General.RemoteResponse

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If (AreaCommon.state.service = CHCProtocolLibrary.AreaCommon.Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                    If AreaSecurity.checkSignature(signature) Then
                        For Each item In AreaCommon.state.currentService.listAvailableCommand
                            If (item = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.verifyData) Then
                                AreaCommon.state.currentService.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.verifyData

                                AreaCommon.state.currentService.listAvailableCommand.Clear()
                                AreaCommon.state.currentService.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cancelCurrentAction)

                                Dim ais As New Threading.Thread(AddressOf AreaData.analyzeInternalState)

                                ais.Start()

                                result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete

                                Exit For
                            End If
                        Next

                        If (result.responseStatus <> General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                            result.responseStatus = General.RemoteResponse.EnumResponseStatus.commandNotAllowed
                        End If
                    Else
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization
                    End If
                Else
                    result.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline
                End If
            Catch ex As Exception
                result.responseStatus = General.RemoteResponse.EnumResponseStatus.inError
                result.errorDescription = "503 - Generic Error"
            End Try

            result.responseTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

            Return result

        End Function


    End Class


End Namespace