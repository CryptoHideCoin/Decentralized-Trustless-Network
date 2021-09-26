Option Compare Text
Option Explicit On


Imports System.Web.Http
Imports CHCCommonLibrary.AreaCommon.Models
Imports CHCProtocolLibrary.AreaCommon




Namespace Controllers


    ' GET: api/{GUID service}/administration/doAction/cleanLocalData
    <Route("AdministrationDoActionApi")>
    Public Class CleanLocalDataController

        Inherits ApiController





        Public Function GetValue(ByVal signature As String) As General.RemoteResponse
            Dim result As New General.RemoteResponse
            Dim proceed As Boolean = True

            Try
                result.requestTime = CHCCommonLibrary.AreaEngine.Miscellaneous.atMomentGMT()

                If proceed Then
                    If (AreaCommon.state.service <> Models.Service.InformationResponseModel.EnumInternalServiceState.started) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.systemOffline

                        proceed = False
                    End If
                End If
                If proceed Then
                    If Not AreaSecurity.checkSignature(signature) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.missingAuthorization

                        proceed = False
                    End If
                End If
                If proceed Then
                    For Each item In AreaCommon.state.currentService.listAvailableCommand
                        If (item = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cleanLocalData) Then
                            AreaCommon.state.currentService.currentRunCommand = CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cleanLocalData

                            AreaCommon.state.currentService.listAvailableCommand.Clear()
                            AreaCommon.state.currentService.listAvailableCommand.Add(CHCProtocolLibrary.AreaCommon.Models.Administration.EnumActionAdministration.cancelCurrentAction)

                            Dim ais As New Threading.Thread(AddressOf AreaData.cleanLocalData)

                            ais.Start()

                            result.responseStatus = General.RemoteResponse.EnumResponseStatus.responseComplete

                            Exit For
                        End If
                    Next

                    If (result.responseStatus <> General.RemoteResponse.EnumResponseStatus.responseComplete) Then
                        result.responseStatus = General.RemoteResponse.EnumResponseStatus.commandNotAllowed
                    End If
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